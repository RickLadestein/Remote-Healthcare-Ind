using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Profiles
{
    class Doctor
    {
        public string username;
        public string password;
        public Guid uid;

        public Doctor(string username, string password, Guid uid)
        {
            this.username = username;
            this.password = password;
            this.uid = uid;
        }
    }
}
