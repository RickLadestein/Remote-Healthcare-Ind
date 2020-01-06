using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Profiles
{
    class Doctor : User
    {
        public string username;
        

        public Doctor(string username)
        {
            this.username = username;
            this.id = Guid.NewGuid();
        }
    }
}
