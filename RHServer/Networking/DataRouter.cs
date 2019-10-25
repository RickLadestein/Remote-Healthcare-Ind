using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RHServer.IO;
using RHServer.Profiles;

namespace RHServer.Networking
{
    class DataRouter
    {
        private static DataRouter instance;
        public static DataRouter getInstance()
        {
            if (instance == null)
                instance = new DataRouter();
            return instance;
        }


        private List<Doctor> doctors;
        private List<Patient> patients;
        private DataRouter()
        {
            doctors = new List<Doctor>();
            patients = new List<Patient>();
        }

        private void importData()
        {
            string input = FileManager.GetInstance().GetFileContents("users.cfg");
            dynamic data = JsonConvert.DeserializeObject(input);

            doctors = (List<Doctor>)data.doctors;
            patients = (List<Patient>)data.patients;
            return;
        }

        private Boolean login(string username, string password)
        {
            foreach(Doctor d in doctors)
                if(d.username == username && d.password == password)
                    return true;

            return false;
        } 

        public void parseCommand(Connection c, string msg)
        {
            dynamic data = JsonConvert.DeserializeObject(msg);

            string output;
            byte[] toSend;
            switch(data.command)
            {
                case "ACK":
                    break;
                case "GET_FILENAMES":
                    toSend = Encoding.UTF8.GetBytes(DataPackages.GetInstance().FileNameResponse(FileManager.GetInstance().GetFileNames()));
                    c.SendData(toSend, (ushort)toSend.Length);
                    break;
                case "GET_FILE":
                    output = FileManager.GetInstance().GetFileContents(data.filename);
                    toSend = Encoding.UTF8.GetBytes(DataPackages.GetInstance().FileContentResponse(data.filename, output));
                    c.SendData(toSend, (ushort)toSend.Length);
                    break;
                case "SYSTEM_LOGIN":
                    if (login(data.username, data.password))
                    {
                        toSend = Encoding.UTF8.GetBytes(DataPackages.GetInstance().AckMessage());
                        c.SendData(toSend, (ushort)toSend.Length);
                    } 
                    else
                    {
                        toSend = Encoding.UTF8.GetBytes(DataPackages.GetInstance().ErrorMessage(data.command, "Invalid credentials"));
                        c.SendData(toSend, (ushort)toSend.Length);
                    }
                    break;
                       

            }
        }
    }
}
