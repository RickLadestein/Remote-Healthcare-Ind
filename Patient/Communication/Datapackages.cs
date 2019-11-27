using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;

namespace Patient.Communication
{
    class Datapackages
    {
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

        public static String Message_Alive()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "ALIVE"
            });
        }
        public static String Message_Ack(string msg, Object data)
        {
            return JsonConvert.SerializeObject(new
            {
                msg = "ACK",
                data = new
                {
                    info = msg,
                    data = data
                }
            });
        }

        public static String Message_Error(string msg, Object data)
        {
            return JsonConvert.SerializeObject(new
            {
                msg = "ERROR",
                data = new
                {
                    info = msg,
                    data = data
                }
            });
        }

        public static String Message_GetFilenames(string location, string format)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/getnames",
                data = new
                {
                    location = location,
                    format = format
                }
            });
        }

        public static String Message_CreateFile(string location, string filename, Object data)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/create",
                data = new
                {
                    location = location,
                    file = filename,
                    data = data
                }
            });
        }

        public static String Message_DeleteFile(string location, string filename)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/delete",
                data = new
                {
                    location = location,
                    file = filename
                }
            });
        }

        public static String Message_GetFile(string location, string filename)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/get",
                data = new
                {
                    location = location,
                    file = filename
                }
            });
        }

        public static String Message_Login(string username, string password, USERTYPES type)
        {
            string output = "";
            if (type != USERTYPES.PATIENT)
            {
                using (MD5 md5Hash = MD5.Create())
                {
                    byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(username + password));
                    foreach (byte b in data)
                        output += b.ToString("x2");
                }
            }

            return JsonConvert.SerializeObject(new
            {
                command = "user/login",
                data = new
                {
                    type = type,
                    hash = output
                }
            });
        }

        public static String Message_Logout(String uid)
        {
            return JsonConvert.SerializeObject(new 
            { 
                command = "user/logout",
                data = new
                {
                    uid = uid
                }
            });
        }

        public static String Message_TrainingData(String doctor_uid, Object data)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "user/data",
                data = data
            });
        }

        public static String Message_Message(String patient_uid, String msg)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "user/msg",
                data = new
                {
                    msg = msg
                }
            });
        }

        public static String Message_GetPatientsUID()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "patients/get_online",
                data = new { }
            });
        }

        public static String Message_GetDoctorsUID()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "doctors/get_online",
                data = new { }
            });
        }
    }
}
