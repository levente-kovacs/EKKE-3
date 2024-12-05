using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Borok
{
    internal class VineProducer
    {
        string vineType;

        ConsoleColor colour;

        int amount;

        int workTime;

        public VineProducer(string vineType, ConsoleColor colour, int amount, int workTime)
        {
            this.vineType = vineType;
            this.colour = colour;
            this.amount = amount;
            this.workTime = workTime;
        }
        public void Termel()
        {
            for (int i = 0; i < amount; i++)
            {
                Supervisor.Berak(vineType);
                lock (typeof(Program))
                {
                    Console.ForegroundColor = colour;
                    Console.WriteLine($"+\tTermeltünk 1l {vineType}bort.");
                }
                Thread.Sleep(this.workTime);
            }
        }

    }
}
