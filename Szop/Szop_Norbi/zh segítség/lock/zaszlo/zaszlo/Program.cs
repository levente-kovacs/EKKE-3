using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zaszlo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            sor s0 = new sor(0, 7, ConsoleColor.Red, 16000);
            Thread t0 = new Thread(s0.Kirajzol);
            t0.Start();
            sor s1 = new sor(8, 15, ConsoleColor.White, 16000);
            Thread t1 = new Thread(s1.Kirajzol);
            t1.Start();
            sor s2 = new sor(16, 24, ConsoleColor.Green, 16000);
            Thread t2 = new Thread(s2.Kirajzol);
            t2.Start();
            Console.ReadKey();
        }
    }

    class sor
    {
        Random rnd = new Random();
        public int y1, y2,db;
        ConsoleColor szin;
        public sor(int y1,int y2,ConsoleColor szin, int db)
        {
            this.y1 = y1;
            this.y2 = y2;
            this.db = db;
            this.szin = szin;
        }
        
        public void Kirajzol()
        {
            
            bool vege = false;
            while (!vege)
            {

                    for (int i = 0; i < db; i++)
                    {
                    lock (typeof(Program))
                    {
                        int x = rnd.Next(0, 80);
                        int y = rnd.Next(0, 25);
                        if (y >= y1 && y <= y2)
                        {
                            Console.SetCursorPosition(x, y);
                            Console.ForegroundColor = szin;
                            Console.Write("*");
                        }
                    }
                                                
                    }

                vege = true;
            }
        }
        
    }
}
