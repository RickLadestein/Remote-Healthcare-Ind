using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using RHServer.Networking;

namespace RHServer
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program();
        }

        public Server server;

        public Program()
        {
            server = new Server(25565);
            server.Start();
            Run();
        }

        public void Run()
        {
            Connection sender = new Connection(new TcpClient("localhost", 25565), null);
            String tosend = "Helloworld";
            String end = "{ COMMAND: END }";


            int count = 0;
            bool looping = true;
            while(looping)
            {
                byte[] data = Encoding.UTF8.GetBytes(DataPackages.GetInstance().AliveMessage());
                byte[] data2 = Encoding.UTF8.GetBytes(end);
                sender.SendData(data, (ushort) data.Length);
                Thread.Sleep(1000);
                count++;
                if (count == 10)
                    looping = false;
                //looping = false;
            }

            while(true)
            {
                Thread.Sleep(1000);
            }
        }
    }
}
