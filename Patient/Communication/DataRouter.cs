using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Patient.Communication;

namespace Patient.Communication
{
    class DataRouter
    {
        public static DataRouter instance;
        private ConnectionResponseListener c_l;
        public static DataRouter GetInstance()
        {
            if (instance == null)
                instance = new DataRouter();
            return instance;
        }

        List<Tuple<ConnectionResponseListener, string>> queries;
        private DataRouter()
        {
            queries = new List<Tuple<ConnectionResponseListener, string>>();
        }

        public void SendMessage(Socket c, string msg, string command, ConnectionResponseListener l, bool isQuery)
        {
            if(isQuery)
            {
                queries.Add(new Tuple<ConnectionResponseListener, string>(l, command));
            }
            byte[] data = Encoding.UTF8.GetBytes(msg);
            c.SendMessage(data);
        }

        private void ParseMessageResponse(string code, string command, dynamic data)
        {
            Tuple<ConnectionResponseListener, string> query = null;
            for (int i = 0; i < queries.Count; i++)
            {
                if (command == queries[i].Item2)
                    query = queries[i];
            }
            if(query != null)
            {
                if (code == "ACK")
                    query.Item1.onMessageResponse(command, data.data);
                else if (code == "ERROR")
                    query.Item1.onMessageResponseError(command, (string)data.data.info);
            }
        }

        public void OnMessageReceived(Socket c, String msg)
        {
            dynamic data = JsonConvert.DeserializeObject(msg);
            String code = (String)data.command;
            if(code == "ACK" || code == "ERROR")
            {
                string command = (string)data.data.command;
                ParseMessageResponse(code, command, data);
            } else if(code == "ALIVE")
            {
                SendMessage(c, Datapackages.Message_Alive(), "ALIVE", null, false);
            } else
            {
                string command = (string)data.data.command;
                if(this.c_l != null)
                {
                    this.c_l.onGenericMessageReceived(command, data);
                }
                
            }
        }

        public void setGenericMessageListener(ConnectionResponseListener l)
        {
            this.c_l = l;
        }
    }
}

public interface ConnectionResponseListener
{
    void onMessageResponse(string command, dynamic data);
    void onMessageResponseError(string command, string info);

    void onGenericMessageReceived(string command, dynamic data);
}
