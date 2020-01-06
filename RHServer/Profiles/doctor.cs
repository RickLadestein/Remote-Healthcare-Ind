using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Profiles
{
    class doctor : User
    {
        public string username;
        public string hash;
        public Boolean active;

        public doctor(string username, string hash)
        {
            this.username = username;
            this.hash = hash;
            this.active = false;
            this.id = Guid.NewGuid();
        }
    }
}
