﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using RHServer.IO;
using RHServer.Profiles;
using System.Threading;
using System.Security.Cryptography;

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

        public void ForceLogout(String id)
        {
            list_mutex.WaitOne();
            foreach(User u in users)
            {
                if (u.id.ToString() == id && u.active)
                {
                    Console.WriteLine($"[Server]: forced {u.id} to inactive");
                    u.active = false;
                }
            }
            list_mutex.ReleaseMutex();
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
        public void OnMessageReceived(Socket handle, byte[] data, int length)
        {
            String output = Encoding.UTF8.GetString(data);
            ParseCommand(handle, output);
        }

        public void ParseCommand(Socket c, string msg)
        {
            Logger.LogReceiveMessage(msg);
            try
            {
                dynamic data = JsonConvert.DeserializeObject(msg);
                dynamic inner_data = data.data;
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
                        SendMessage(c, inner_data);
                        break;
                    case "user/msg":
                        SendMessage(c, inner_data);
                        break;
                    case "user/edit":
                        EditUser(c, inner_data);
                        break;
                    case "user/add":
                        AddUser(c, inner_data);
                        break;
                    case "patients/get_online":
                        GetActivePatients(c);
                        break;
                    case "doctors/get_online":
                        GetActiveDoctors(c);
                        break;
                    case "patient/get_all":
                        GetAllPatients(c);
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

        private void Login(Socket c, dynamic data)
        {
            list_mutex.WaitOne();
            bool found = false;
            String hash = (String) data.hash;
            foreach (User u in users)
                if (u.hash == hash && !found)
                {
                    if (u.active)
                    {
                        SendDataToConnection(c, DataPackages.Response_Error("user/login", "Could not login user: User does is already logged in"));
                    }
                    else
                    {
                        u.active = true;
                        u.id = Guid.NewGuid();
                        c.id = u.id.ToString();
                        if(u is Doctor)
                            SendDataToConnection(c, DataPackages.Response_Ack("user/login", u.id.ToString(), (Doctor) u));
                        else
                            SendDataToConnection(c, DataPackages.Response_Ack("user/login", u.id.ToString(), (Patient) u));
                        found = true;
                        break;
                    }
                }
            if (!found)
                SendDataToConnection(c, DataPackages.Response_Error("user/login", "Could not login user: No user exists with that Username/Password combination"));
            list_mutex.ReleaseMutex();
        }

        private void Logout(Socket c, dynamic data)
        {
            list_mutex.WaitOne();
            bool found = false;
            foreach (User u in users)
                if (u.id.ToString() == (string)data.id && !found)
                {
                    if (!u.active)
                    {
                        SendDataToConnection(c, DataPackages.Response_Error("user/logout", "Could not logout user: User is not logged in"));
                    }
                    else
                    {
                        u.active = false;
                        u.id = Guid.Empty;
                        SendDataToConnection(c, DataPackages.Response_Ack("user/logout", u.id.ToString(), null));
                        found = true;
                        break;
                    }
                }
            if (!found)
                SendDataToConnection(c, DataPackages.Response_Error("user/logout", "Could not logout user: User does not exist"));
            list_mutex.ReleaseMutex();
        }

        private void CheckLogin(Socket c, Guid id)
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

        private void CreateFile(Socket c, dynamic data)
        {
            String file = data.file;
            String location = data.location;
            bool succes = !FileManager.CheckIfFileExists(file, location);
            if (succes)
            {
                List<BikeMeasurement> ms = ((JArray)data.data).ToObject<List<BikeMeasurement>>();
                FileManager.WriteFileContents(file, location, JsonConvert.SerializeObject(ms));
                this.SendDataToConnection(c, DataPackages.Response_Ack("file/create", "", null));
            } else
            {
                this.SendDataToConnection(c, DataPackages.Response_Error("file/create", "Could not create file: file already exists"));
            }
        }

        private void DeleteFile(Socket c, dynamic data)
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

        private void GetFileNames(Socket c, dynamic data)
        {
            String path = data.location;
            String format = data.format;
            List<String> files = FileManager.GetFileNames(path, format);
            SendDataToConnection(c, DataPackages.Response_Ack("file/getnames", "", files));
        }

        private void GetFile(Socket c, dynamic data)
        {
            String path = data.location;
            String file = data.file;
            String contents = FileManager.GetFileContents(file, path);
            if (contents == "ERROR")
                SendDataToConnection(c, DataPackages.Response_Error("file/get", "Error 404: File was not found"));
            else
                SendDataToConnection(c, DataPackages.Response_Ack("file/get", "", contents));
        }

        private void SendMessage(Socket c, dynamic data)
        {
            String target = data.target;
            String command = "user/msg";

            if (((string)data.command) == "user/msg")
            {
                Console.WriteLine("");
            }
            Socket t_connection = null;
            foreach (Socket con in Server.instance.connections)
                if (con.id == target)
                {
                    t_connection = con;
                    break;
                }
            if (t_connection != null)
                SendDataToConnection(t_connection, DataPackages.Message_Generic(command, data));
            else
                SendDataToConnection(c, DataPackages.Response_Error(command, "Could not send data to target: Target does not exist"));
        }

        private void GetActivePatients(Socket c)
        {
            list_mutex.WaitOne();
            List<User> patients = new List<User>();
            foreach(User u in users)
            {
                if (u is Patient && u.active)
                    patients.Add(u);
            }
            this.SendDataToConnection(c, DataPackages.Response_Ack("patients/get_online", "", patients));
            list_mutex.ReleaseMutex();
        }

        private void GetActiveDoctors(Socket c)
        {
            list_mutex.WaitOne();
            List<User> doctors = new List<User>();
            foreach (User u in users)
            {
                if (u is Doctor && u.active)
                    doctors.Add(u);
            }
            this.SendDataToConnection(c, DataPackages.Response_Ack("doctors/get_online", "", doctors));
            list_mutex.ReleaseMutex();
        }

        private void EditUser(Socket c, dynamic data)
        {
            JObject tmp = JObject.FromObject(data.data);
            Patient p = tmp.ToObject<Patient>();

            list_mutex.WaitOne();
            for (int i = 0; i < users.Count; i++)
                if (p.id == users[i].id)
                {
                    users.RemoveAt(i);
                    i = users.Count;
                }
            p.active = true;

            string output = "";
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] bdata = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(p.birthday.ToString() + p.first_name + p.sur_name));
                foreach (byte b in bdata)
                    output += b.ToString("x2");
            }
            p.hash = output;
            users.Add(p);
            SaveUsers();
            list_mutex.ReleaseMutex();
            SendDataToConnection(c, DataPackages.Response_Ack("user/edit", "", null));
        }

        private void AddUser(Socket c, dynamic data)
        {
            JObject tmp = JObject.FromObject(data.data);
            Patient p = tmp.ToObject<Patient>();

            list_mutex.WaitOne();
            string output = "";
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] bdata = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(p.birthday.ToString() + p.first_name + p.sur_name));
                foreach (byte b in bdata)
                    output += b.ToString("x2");
            }
            p.hash = output;
            users.Add(p);
            SaveUsers();
            list_mutex.ReleaseMutex();
            SendDataToConnection(c, DataPackages.Response_Ack("user/add", "", null));
        }

        private void GetAllPatients(Socket c)
        {
            List<Patient> output = new List<Patient>();
            list_mutex.WaitOne();
            foreach (User u in users)
                if (u is Patient)
                    output.Add((Patient)u);
            this.SendDataToConnection(c, DataPackages.Response_Ack("patient/get_all", "", output));
            list_mutex.ReleaseMutex();
        }
        private void SendDataToConnection(Socket c, String msg)
        {
            byte[] output = Encoding.UTF8.GetBytes(msg);
            ushort length = (ushort)msg.Length;
            c.SendMessage(output);
            Logger.LogSendMessage(msg);
        }

        private void SaveUsers()
        {
            List<Patient> patients = new List<Patient>();
            List<Doctor> doctors = new List<Doctor>();
            foreach (User u in users)
                if (u is Patient)
                    patients.Add((Patient)u);
                else
                    doctors.Add((Doctor)u);

            FileManager.DeleteFile("patients.json", "resources\\users");
            FileManager.DeleteFile("doctors.json", "resources\\user");

            FileManager.WriteFileContents("patients.json", "resources\\users", JsonConvert.SerializeObject(new { users = patients }));
            FileManager.WriteFileContents("doctors.json", "resources\\users", JsonConvert.SerializeObject(new { users = doctors }));

        }
    }
}
