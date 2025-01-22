﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class User
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public int Egyenleg { get; set; }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
            Egyenleg = 0;
        }

    }
}
