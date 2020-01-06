using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RHServer.Networking
{
    class DataPackages
    {
        public static String Response_Ack(string command, string info, Object data)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "ACK",
                data = new
                {
                    command = command,
                    info = info,
                    data = data
                }
            });
        }

        public static String Response_Error(string command, string info)
        {
            return JsonConvert.SerializeObject(new 
            {
                command = "ERROR",
                data = new
                {
                    command = command,
                    info = info
                }
            });
        }

        public static String Message_Alive()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "ALIVE"
            });
        }

        public static String Message_Generic(string command, object data)
        {
            return JsonConvert.SerializeObject(new
            {
                command = command,
                data = data
            });
        }
    }
}
