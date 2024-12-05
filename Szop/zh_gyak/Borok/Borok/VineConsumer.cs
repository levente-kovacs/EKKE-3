using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borok
{
    internal class VineConsumer
    {
        string vineType;

        ConsoleColor colour;

        public VineConsumer(string vineType, ConsoleColor colour)
        {
            this.vineType = vineType;
            this.colour = colour;
        }
        public void Fogyaszt()
        {
            while (true)
            {
                try
                {
                    Supervisor.Kivesz(vineType, colour);
                    lock (typeof(Program))
                    {
                        Console.ForegroundColor = colour;
                        Console.WriteLine($"-\tElfogyasztottunk 1l {vineType}bort.");
                    }
                }
                catch { Console.WriteLine("A termelők leálltak."); break; }

            }
        }
    }
}
