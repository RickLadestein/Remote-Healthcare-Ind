using System;
using System.Collections.Generic;
using System.Text;

namespace Doctor
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
