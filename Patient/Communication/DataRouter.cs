﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Patient.Communication
{
    class DataRouter
    {
        public static DataRouter instance;
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

        public void SendMessage(Connection c, string msg, string command, ConnectionResponseListener l, bool isQuery)
        {
            if(isQuery)
            {
                queries.Add(new Tuple<ConnectionResponseListener, string>(l, command));
            }
            byte[] data = Encoding.UTF8.GetBytes(msg);
            c.SendData(data, (ushort)data.Length);
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
                    query.Item1.onMessageResponse(command, data.data.data);
                else if (code == "ERROR")
                    query.Item1.onMessageResponseError(command, (string)data.info);
            }
        }

        public void OnMessageReceived(Connection c, String msg)
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
            }
        }
    }
}

interface ConnectionResponseListener
{
    void onMessageResponse(string command, object data);
    void onMessageResponseError(string command, string info);
}