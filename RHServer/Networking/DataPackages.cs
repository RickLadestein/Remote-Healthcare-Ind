using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace RHServer.Networking
{
    class DataPackages
    {
        private static DataPackages instance;
        public static DataPackages GetInstance()
        {
            if (instance == null)
                instance = new DataPackages();
            return instance;
        }

        public String AckMessage()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "ACK",
                status = "ACK"
            });
        }

        public String AliveMessage()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "GET_ALIVE"
            });
        }

        public String ErrorMessage(String cmd, String msg)
        {
            return JsonConvert.SerializeObject(new
            {
                command = cmd,
                status = "Error",
                info = msg
            });
        }

        public String LoginResponse(bool result)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "SYSTEM_LOGIN",
                result = "TRUE"
            });
        }

        public String FileNameResponse(List<String> names)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "GET_FILENAMES",
                result = names
            });
        }

       public String FileContentResponse(String filename, String content)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "GET_FILE",
                file_name = filename,
                content = content
            });
        }
    }
}
