﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RHServer.Profiles
{
    abstract class User
    {
        public Guid id;
        public string hash;
        public Boolean active;
    }
}
