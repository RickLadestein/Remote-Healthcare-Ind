using System;
using System.Collections.Generic;
using System.Threading;
using System.Text;
using System.Net.Sockets;
using System.Net.Security;
using System.Net;
using System.Timers;

namespace Patient.Communication
{

    public class Socket
    {
        public delegate void message_received_delegate(Socket handle, byte[] data, int length);
        public delegate void on_socket_error_delegate(Socket s, String message);

        private readonly int MAX_MESSAGE_TIMEOUT = 10;

        public message_received_delegate onMessageReceived;
        public on_socket_error_delegate onSocketError;
        public Boolean connected;
        public Boolean running;
        public String id;

        private Stack<byte[]> outbound_messages;
        private Mutex stack_mutex;
        private int time_since_last_message;

        private TcpClient tcp_client;
        public String ip_endpoint;
        private NetworkStream stream;
        private Thread thread;
        private System.Timers.Timer tickTimer;

        public Socket(String host, int port)
        {
            this.outbound_messages = new Stack<byte[]>();
            this.stack_mutex = new Mutex();

            this.tickTimer = new System.Timers.Timer(1000);
            this.tickTimer.Elapsed += this.OnTimerTick;
            this.time_since_last_message = 0;

            try
            {
                ConnectTcp(host, port);
                this.tickTimer.Start();
            }
            catch (Exception e)
            {
                connected = false;
            }
            this.id = "";
        }

        public Socket(TcpClient client)
        {
            this.outbound_messages = new Stack<byte[]>();
            this.stack_mutex = new Mutex();

            this.tickTimer = new System.Timers.Timer(1000);
            this.tickTimer.Elapsed += this.OnTimerTick;
            this.time_since_last_message = 0;
            this.tcp_client = client;
            this.ip_endpoint = this.tcp_client.Client.RemoteEndPoint.ToString();
            this.id = "";
            this.stream = tcp_client.GetStream();
        }

        public void SendMessage(String message)
        {
            byte[] output = Encoding.UTF8.GetBytes(message);
            SendMessage(output);
        }

        public void SendMessage(byte[] message)
        {
            stack_mutex.WaitOne();
            ushort length = (ushort)message.Length;
            byte lower = (byte)(length >> 8);
            byte upper = (byte)(length & 0x00FF);
            byte[] message_length = new byte[2] { lower, upper };
            byte[] tosend = new byte[message.Length + 2];
            message_length.CopyTo(tosend, 0);
            message.CopyTo(tosend, 2);
            outbound_messages.Push(tosend);
            stack_mutex.ReleaseMutex();
        }

        public void Start()
        {
            this.thread = new Thread(() => this.Loop(this));
            this.running = true;
            this.thread.Start();
        }

        public void Stop()
        {
            this.running = false;
            this.tickTimer.Stop();
            this.thread.Join();

        }

        public Boolean GetConnected()
        {
            return this.tcp_client.Connected;
        }

        public void Loop(Socket s)
        {
            while (s.running)
            {
                if (s.time_since_last_message >= s.MAX_MESSAGE_TIMEOUT)
                {
                    s.running = false;
                }

                if (s.GetConnected())
                {
                    try
                    {
                        s.ReceiveTcp(s);
                        s.SendTcp(s);
                    }
                    catch (Exception e)
                    {
                        s.running = false;
                        onSocketError?.Invoke(s, e.Message);
                    }
                }
                else
                {
                    s.running = false;
                }
            }

            if (s.GetConnected())
            {
                s.tcp_client.Close();
            }
            this.connected = false;
        }

        private void SendTcp(Socket s)
        {
            s.stack_mutex.WaitOne();
            if (s.outbound_messages.Count > 0)
            {
                byte[] data = s.outbound_messages.Pop();
                s.stream.Write(data, 0, data.Length);
                s.stream.Flush();
            }
            s.stack_mutex.ReleaseMutex();
        }

        private void ReceiveTcp(Socket s)
        {
            while (s.stream.DataAvailable)
            {
                //Receive first bytes: first bytes contain message size
                byte[] data_size = new byte[2];
                s.stream.Read(data_size, 0, 2);
                ushort message_size = (ushort)(data_size[1] + (data_size[0] << 8));

                //Receive the message and send to delegate
                byte[] data = new byte[message_size];
                s.stream.Read(data, 0, message_size);
                s.onMessageReceived?.Invoke(s, data, data.Length);
                s.time_since_last_message = 0;
            }
        }

        private void ConnectTcp(String ip, int port)
        {
            tcp_client = new TcpClient();
            tcp_client.Connect(ip, port);
            this.stream = tcp_client.GetStream();
            this.ip_endpoint = this.tcp_client.Client.RemoteEndPoint.ToString();
        }

        private void OnTimerTick(Object source, System.Timers.ElapsedEventArgs e)
        {
            this.time_since_last_message += 1;
            if (!this.running)
                this.Stop();
        }


    }
}
