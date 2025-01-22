using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    internal class Utalas
    {
        public User Kitol { get; set; }

        public User Kinek { get; set; }

        public int Mennyit { get; set; }

        public DateTime Mikor { get; set; }

        public Utalas(User kitol, User kinek, int mennyit)
        {
            Kitol = kitol;
            Kinek = kinek;
            Mennyit = mennyit;
            Mikor = DateTime.Now;
        }
    }
}
