using System;
using System.Collections.Generic;
using System.Text;

namespace Patient
{
    public class Doctor : User
    {
        public string username;
        public Boolean active;

        public Doctor(string username, Guid id)
        {
            this.username = username;
            this.id = id;
        }
    }
}
