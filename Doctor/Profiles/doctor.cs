using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor
{
    public class Doctor : User
    {
        public string username;
        public string hash;
        public Boolean active;

        public Doctor(string username, string hash)
        {
            this.username = username;
            this.hash = hash;
            this.active = false;
            this.id = Guid.NewGuid();
        }
    }
}
