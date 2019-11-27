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

#region Initialization
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

            ImportData();
        }

        public enum USERTYPES
        {
            DOCTOR = 0x00,
            PATIENT = 0x01
        }

        public enum FILELOCATIONS
        {
            DATA = 0x00,
            USERS = 0x01,
            IMAGES = 0x02
        }

        private void ImportData()
        {
            string input = FileManager.GetFileContents("doctors.json", "resources\\users");
            dynamic data = JsonConvert.DeserializeObject(input);
            doctors = ((JArray) data.users).ToObject<List<Doctor>>();

            input = FileManager.GetFileContents("patients.json", "resources\\users");
            data = JsonConvert.DeserializeObject(input);
            patients = ((JArray)data.users).ToObject<List<Patient>>();
            return;
        }
#endregion
        public void ParseCommand(Connection c, string msg)
        {
            Logger.LogReceiveMessage(msg);
            try
            {
                dynamic data = JsonConvert.DeserializeObject(msg);
                dynamic inner_data = data.data;
                string output;
                byte[] toSend;
                switch ((String)data.command)
                {
                    case "ACK":
                        break;
                    case "ERROR":
                        break;
                    case "file/getnames":
                        GetFileNames(c, inner_data);
                        break;
                    case "file/create":
                        break;
                    case "file/delete":
                        break;
                    case "file/get":
                        GetFile(c, inner_data);
                        break;
                    case "user/login":
                        Login(c, inner_data);
                        break;
                    case "user/logout":
                        Logout(c, inner_data);
                        break;
                    case "user/data":
                        break;
                    case "user/msg":
                        break;
                    case "patients/get_online":
                        break;
                    case "doctors/get_online":
                        break;
                    case "ALIVE":
                        SendDataToConnection(c, DataPackages.Message_Alive());
                        break;

                    default:
                        break;
                }
            } catch(Exception ex)
            {

            }
        }

        private void Login(Connection c, dynamic data)
        {
            if (data.type == USERTYPES.PATIENT)
            {
                //do something if patient wants to login
            } else
            {
                foreach (Doctor d in doctors)
                {
                    if (d.hash == (String)data.hash)
                    {
                        if (d.active)
                        {
                            SendDataToConnection(c, DataPackages.Response_Error("user/login", "User already logged in"));
                        }
                        else
                        {
                            d.active = true;
                            SendDataToConnection(c, DataPackages.Response_Ack("user/login", "", d.id));
                        }
                        break;
                    }
                }
                    SendDataToConnection(c, DataPackages.Response_Error("user/login", "no user found with username or password combination"));
            }
        }

        private void Logout(Connection c, dynamic data)
        {
            if (data.type == USERTYPES.PATIENT)
            {
                //do something if patient
            } else
            {
                foreach (Doctor d in doctors) 
                {
                    if (d.id.Equals((Guid)data.id))
                    {
                        if(d.active)
                        {
                            d.active = false;
                            SendDataToConnection(c, DataPackages.Response_Ack("user/logout", "", null));
                        } else
                        {
                            SendDataToConnection(c, DataPackages.Response_Error("user/logout", "user not logged in"));
                        }
                        return;
                    }
                }
                SendDataToConnection(c, DataPackages.Response_Error("user/logout", "uid not found for user"));
            }
        }

        private void GetFileNames(Connection c, dynamic data)
        {
            String path = data.location;
            List<String> files = FileManager.GetFileNames(path);
            SendDataToConnection(c, DataPackages.Response_Ack("file/getnames", "", files));
        }

        private void GetFile(Connection c, dynamic data)
        {
            String path = data.location;
            String file = data.file;
            String contents = FileManager.GetFileContents(file, path);
            if (contents == "ERROR")
                SendDataToConnection(c, DataPackages.Response_Error("file/get", "Error 404: File was not found"));
            else
                SendDataToConnection(c, DataPackages.Response_Ack("file/get", "", contents));
        }

        private void SendDataToConnection(Connection c, String msg)
        {
            byte[] output = Encoding.UTF8.GetBytes(msg);
            ushort length = (ushort)msg.Length;
            c.SendData(output, length);
            Logger.LogSendMessage(msg);
        }
    }
}
