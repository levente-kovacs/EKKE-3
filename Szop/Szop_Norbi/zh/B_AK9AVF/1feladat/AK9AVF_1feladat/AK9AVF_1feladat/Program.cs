using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AK9AVF_1feladat
{    class list
    {
        static bool prim(int x)
        {
            int gyoke = (int)(Math.Sqrt(x));
            for (int i = 2; i <= gyoke; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }

        List<int> adatok = new List<int>();
        public int alsoDb = 0;
        public int felsoDb = 0;        
        int i = 0;
        int j = 10;

        public list(int x)
        {            
            j = x;
            for (int i = 0; i < x; i++)
            {
                adatok.Add(i);
            }
        }
        public void KiIr()
        {
            foreach (int i in adatok)
            {
                Console.WriteLine(i);
            }
        }

        public void eleje()
        {           
            while (i < j)
            {
                lock (typeof(Program))
                {
                    if (prim(i))
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine(i);
                        alsoDb++;
                    }
                    i++;
                }                   
            }
            lock (typeof(Program))
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(alsoDb);
            }                  
        }

        public void vege()
        {
            
            while (i < j)
            {
                lock (typeof(Program))
                {
                    if (prim(j))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(j);
                        felsoDb++;
                    }
                    j--;
                }               
            }
            lock (typeof(Program))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(felsoDb);
            }
            
            

        }
    }

    internal class Program
    {
        
        static void Main(string[] args)
        {
            list adatok = new list(10);
            adatok.KiIr();
            Thread t1 = new Thread(adatok.eleje);
            Thread t2 = new Thread(adatok.vege);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.ReadLine();
        }
    }
}
