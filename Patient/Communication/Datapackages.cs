using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Security.Cryptography;
using Patient.Bike;
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
        public static String Message_Ack(Guid id, string msg, Object data)
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

        public static String Message_Error(Guid id, string msg, Object data)
        {
            return JsonConvert.SerializeObject(new
            {
                msg = "ERROR",
                data = new
                {
                    id = id,
                    info = msg,
                    data = data
                }
            });
        }

        public static String Message_GetFilenames(Guid id, string location, string format)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/getnames",
                data = new
                {
                    id = id,
                    location = location,
                    format = format
                }
            });
        }

        public static String Message_CreateFile(Guid id, string location, string filename, Object data)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/create",
                data = new
                {
                    id = id,
                    location = location,
                    file = filename,
                    data = data
                }
            });
        }

        public static String Message_DeleteFile(Guid id, string location, string filename)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/delete",
                data = new
                {
                    id = id,
                    location = location,
                    file = filename
                }
            });
        }

        public static String Message_GetFile(Guid id, string location, string filename)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "file/get",
                data = new
                {
                    id = id,
                    location = location,
                    file = filename
                }
            });
        }

        public static String Message_Login(string hash)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "user/login",
                data = new
                {
                    hash = hash
                }
            }); ;
        }

        public static String Message_Logout(Guid id)
        {
            return JsonConvert.SerializeObject(new 
            { 
                command = "user/logout",
                data = new
                {
                    id = id
                }
            });
        }

        public static String Message_TrainingData(Guid id, String doctor_uid, BikeMeasurement data)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "user/data",
                data = new
                {
                    command = "user/data",
                    id = id,
                    target = doctor_uid,
                    measurement = data
                }
            });
        }

        public static String Message_Message(string id, String patient_uid, String msg)
        {
            return JsonConvert.SerializeObject(new
            {
                command = "user/msg",
                data = new
                {
                    command = "user/msg",
                    id = id,
                    target = patient_uid,
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

        public static String Message_GetAllPatients()
        {
            return JsonConvert.SerializeObject(new
            {
                command = "patient/get_all",
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
