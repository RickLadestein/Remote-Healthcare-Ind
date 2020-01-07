using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Profiles
{
    public class Doctor : User
    {
        public string username;

        public Doctor(string username)
        {
            this.username = username;
            this.active = false;
            this.id = Guid.NewGuid();
        }
    }
}
