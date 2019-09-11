using System;
using System.Collections.Generic;
using System.Text;
using RHServer.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RHServer.Networking
{
    class ServerCommandHandler : ICommandListener
    {
        public static ServerCommandHandler instance;
        public static ServerCommandHandler GetInstance()
        {
            if (instance == null)
                instance = new ServerCommandHandler();
            return instance;
        }
        private FileManager handler;

        

        private ServerCommandHandler()
        {

        }

        private void HandleCommand(Connection c, String command, String msg)
        {
            switch(command)
            {
                case "ACK":
                    break;
                case "GET_ALIVE":
                    String output = DataPackages.GetInstance().AckMessage();
                    byte[] data = Encoding.UTF8.GetBytes(output);
                    c.SendData(data, (ushort) data.Length);
                    Console.WriteLine($"[Server -> Client]: {Encoding.UTF8.GetString(data)}");
                    break;
                case "SYSTEM_LOGIN":
                    break;
                case "GET_FILENAMES":
                    break;
                case "GET_FILE":
                    break;
                case "CREATE_FILE":
                    break;
                case "DELETE_FILE":
                    break;
                case "GET_PATIENTS":
                    break;
            }
        }

        public void OnCommandReceived(Connection c, string msg)
        {
            dynamic message = JsonConvert.DeserializeObject(msg);
            String command = message.command;
            HandleCommand(c, command, msg);
        }
    }

    interface ICommandListener
    {
        void OnCommandReceived(Connection c, String msg);
    }
}
