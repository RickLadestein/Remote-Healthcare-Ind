using System;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using RHServer.Networking;
using RHServer.IO;

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
            Logger.SetLogMode(Logger.LOGMODE.LIMITED);
            server.Start();
            Run();
        }

        public void Run()
        {
            while(true)
            {
                Thread.Sleep(1);
            }
        }
    }
}
