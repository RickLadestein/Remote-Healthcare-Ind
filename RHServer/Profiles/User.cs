using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Profiles
{
    public abstract class User
    {
        public Guid id;
        public string hash;
        public bool active;
    }
}
