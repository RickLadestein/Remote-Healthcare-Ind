using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Sockets;
using System.Net.Security;
using System.Threading;
using System.Net;
using System.Timers;

namespace RHServer.Networking
{
    class Server : ConnectionListener, ConnectionEventListener
    {
        private TcpListener listener;
        private System.Timers.Timer tickrate;

        private ConnectionWorker worker;
        private Thread thread;

        public int port;
        public List<Connection> connections, deletions;
        public Server(int port)
        {
            this.port = port;
            connections = new List<Connection>();
            deletions = new List<Connection>();
            tickrate = new System.Timers.Timer(1000 / 128);
            tickrate.AutoReset = true;
            tickrate.Elapsed += onTimerEvent;
            DataRouter.getInstance();
        }

        public void Stop()
        {
            try
            {
                worker.Stop();
            } catch(Exception e)
            {
                Console.WriteLine($"[Server]: {e.Message}");
            }
        }

        public void Start()
        {
            try
            {
                listener = new TcpListener(IPAddress.Any, port);
                this.worker = new ConnectionWorker(listener, this);
                thread = new Thread(new ThreadStart(worker.Start));
                listener.Start();
                tickrate.Start();
                thread.Start();
                
                
            } catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"[Server]: {e.Message}");
            }
        }

        public void onTimerEvent(Object source, ElapsedEventArgs e)
        {
            for (int i = 0; i < connections.Count; i++)
                try
                {
                    connections[i].ReadData();
                }
                catch (Exception ex) { }

            for (int i = 0; i < connections.Count; i++)
                try
                {
                    byte[] data = Encoding.UTF8.GetBytes(DataPackages.Message_Alive());
                    connections[i].SendData(data, (ushort)data.Length);
                }
                catch (Exception ex) { }

            for (int i = 0; i < connections.Count; i++)
                try
                {
                    connections[i].update();
                }
                catch (Exception ex) { }

            for (int i = 0; i < deletions.Count; i++)
            {
                string endpoint = deletions[i].ip_endpoint;
                Connection toremove = null;
                for (int j = 0; j < connections.Count; j++)
                    if (connections[j].ip_endpoint == endpoint)
                    {
                        toremove = connections[j];
                        j = connections.Count;
                    }
                connections.Remove(toremove);
            }
            deletions.Clear();
        }

        public void onConnect(TcpClient c)
        {
            connections.Add(new Connection(c, this));
            Console.WriteLine($"[Server]: A Client connected [{c.Client.RemoteEndPoint.ToString()}]");
        }

        public void onDataReceived(Connection c, byte[] data, ushort length)
        {
            String output = Encoding.UTF8.GetString(data);
            DataRouter.getInstance().ParseCommand(c, output);
        }

        public void onConnectionError(Connection c, Exception e)
        {
            Console.WriteLine($"[Server]: Dropping Connection with {c.ip_endpoint}" +
                $"\n reason: {e.Message}");
            c.EndConnection();
            deletions.Add(c);
            Console.WriteLine($"[Server]: Connection with {c.ip_endpoint}" +
                $" terminated");
        }
    }

    class ConnectionWorker
    {
        private TcpListener server;
        private ConnectionListener handle;
        private bool running = false;

        private bool accepting = false;
        public ConnectionWorker(TcpListener listener, ConnectionListener handle)
        {
            this.server = listener;
            this.handle = handle;
        }

        public void Start()
        {
            running = true;
            while(running)
            {
                try
                {
                    if (!accepting)
                    {
                        accepting = true;
                        server.BeginAcceptSocket(new AsyncCallback(onClientConnect), this);
                    }
                } catch(Exception e)
                {
                    Stop();
                }
            }
        }

        public void Stop()
        {
            if (!running)
            {
                Console.WriteLine("[Server]: Could not stop, server already stopped");
                return;
            }
            try
            {
                while(server.Pending())
                {
                    Thread.Sleep(1000);
                }
                server.Stop();
                running = false;
            } catch(SocketException e)
            {
                Console.WriteLine($"[Server]: {e.Message}");
            }
        }

        public void onClientConnect(IAsyncResult result)
        {
            ConnectionWorker worker = (ConnectionWorker) result.AsyncState;
            TcpClient client = worker.server.EndAcceptTcpClient(result);
            worker.handle.onConnect(client);
            accepting = false;
        }
    }

    interface ConnectionListener
    {
        void onConnect(TcpClient c);
    }
}
