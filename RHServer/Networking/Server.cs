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
    class Server : ConnectionListener
    {
        private TcpListener listener;

        private ConnectionWorker worker;
        private Thread thread;

        public int port;
        public List<Socket> connections;

        public Mutex mutex;
        public static Server instance;
        public System.Timers.Timer tick_timer;
        public Server(int port)
        {
            mutex = new Mutex();
            this.port = port;
            connections = new List<Socket>();
            DataRouter.getInstance();
            instance = this;

            tick_timer = new System.Timers.Timer();
            tick_timer.Interval = 1d / 60d;
            tick_timer.Elapsed += Tick_timer_Elapsed;
        }

        private void Tick_timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            mutex.WaitOne();
            foreach (Socket s in connections)
                s.SendMessage(DataPackages.Message_Alive());
            mutex.ReleaseMutex();
        }

        public void Stop()
        {
            try
            {
                worker.Stop();
                mutex.WaitOne();
                foreach (Socket s in connections)
                    s.Stop();
                mutex.ReleaseMutex();
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
                thread.Start();
                tick_timer.Start();
                
                
            } catch(ArgumentOutOfRangeException e)
            {
                Console.WriteLine($"[Server]: {e.Message}");
            }
        }

        public void onConnect(TcpClient c)
        {
            Socket s = new Socket(c);
            s.onMessageReceived += DataRouter.getInstance().OnMessageReceived;
            s.onSocketError += OnSocketError;
            connections.Add(s);
            s.Start();
            Console.WriteLine($"[Server]: A Client connected [{c.Client.RemoteEndPoint.ToString()}]");
        }

        
        public void OnSocketError(Socket s, String message)
        {
            Console.WriteLine($"[Server]: Dropping Connection with {s.ip_endpoint}" +
                            $"\n reason: {message}");
            s.Stop();
            mutex.WaitOne();
            connections.Remove(s);
            mutex.ReleaseMutex();
            Console.WriteLine($"[Server]: Connection with {s.ip_endpoint}" +
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
            try
            {
                TcpClient client = worker.server.EndAcceptTcpClient(result);
                worker.handle.onConnect(client);
            } catch(Exception ex)
            {

            }
            accepting = false;
        }
    }

    interface ConnectionListener
    {
        void onConnect(TcpClient c);
    }
}
