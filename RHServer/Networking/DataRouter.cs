using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RHServer.IO;
using RHServer.Profiles;
using System.Threading;

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

        private List<User> users;
        private Mutex list_mutex;
        private DataRouter()
        {
            list_mutex = new Mutex();
            users = new List<User>();

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
            list_mutex.WaitOne();
            List<Doctor> doctors = new List<Doctor>();
            string input = FileManager.GetFileContents("doctors.json", "resources\\users");
            dynamic data = JsonConvert.DeserializeObject(input);
            doctors = ((JArray) data.users).ToObject<List<Doctor>>();

            List<Patient> patients = new List<Patient>();
            input = FileManager.GetFileContents("patients.json", "resources\\users");
            data = JsonConvert.DeserializeObject(input);
            patients = ((JArray)data.users).ToObject<List<Patient>>();

            foreach (Patient p in patients)
                users.Add(p);
            foreach (Doctor d in doctors)
                users.Add(d);
            list_mutex.ReleaseMutex();
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
                        CreateFile(c, inner_data);
                        break;
                    case "file/delete":
                        DeleteFile(c, inner_data);
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
            list_mutex.WaitOne();
            if (data.type == USERTYPES.PATIENT)
            {
                //do something if patient wants to login
            } else
            {
                foreach (User u in users)
                {
                    if (u is Doctor)
                    {
                        Doctor d = (Doctor) u;
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
                }
                    SendDataToConnection(c, DataPackages.Response_Error("user/login", "no user found with username or password combination"));
            }
            list_mutex.ReleaseMutex();
        }

        private void Logout(Connection c, dynamic data)
        {
            list_mutex.WaitOne();
            if (data.type == USERTYPES.PATIENT)
            {
                //do something if patient
            } else
            {
                foreach (User u in users)
                {
                    if (u is Doctor)
                    {
                        Doctor d = (Doctor)u;
                        if (d.id.Equals((Guid)data.id))
                        {
                            if (d.active)
                            {
                                d.active = false;
                                SendDataToConnection(c, DataPackages.Response_Ack("user/logout", "", null));
                            }
                            else
                            {
                                SendDataToConnection(c, DataPackages.Response_Error("user/logout", "user not logged in"));
                            }
                            return;
                        }
                    }
                }
                SendDataToConnection(c, DataPackages.Response_Error("user/logout", "uid not found for user"));
            }
            list_mutex.ReleaseMutex();
        }

        private void CheckLogin(Connection c, Guid id)
        {
            list_mutex.WaitOne();
            bool found = false;
            foreach(User p in users)
            {
                if (p.id == id)
                {
                    found = true;
                    break;
                }
            }

            if(!found)
            list_mutex.ReleaseMutex();
        }

        private void CreateFile(Connection c, dynamic data)
        {
            bool succes = FileManager.CreateFile(data.file, data.location);
            if (succes)
            {
                FileManager.WriteFileContents(data.file, data.location, data.data);
                this.SendDataToConnection(c, DataPackages.Response_Ack("file/create", "", null));
            } else
            {
                this.SendDataToConnection(c, DataPackages.Response_Error("file/create", "Could not create file: file already exists"));
            }
        }

        private void DeleteFile(Connection c, dynamic data)
        {
            bool succes = FileManager.DeleteFile(data.file, data.location);
            if(succes)
            {
                this.SendDataToConnection(c, DataPackages.Response_Ack("file/delete", "", null));
            }
            else
            {
                this.SendDataToConnection(c, DataPackages.Response_Error("file/delete", "Could not delete file: file does not exist"));
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
