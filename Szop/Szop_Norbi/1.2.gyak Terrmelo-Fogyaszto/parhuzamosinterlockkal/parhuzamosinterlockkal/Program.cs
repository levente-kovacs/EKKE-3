using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace parhuzamosinterlockkal
{
    internal class Program
    {
        static int[] tomb = new int[1000000];
        static int osszeg = 0;
        static void Main(string[] args)
        {
            List<int> teszt = new List<int>();
            for (int i = 0; i < 10; i++)
            {
                teszt.Add(i);
            }
            for (int i = 0; i < teszt.Count; i++)
            {
                teszt.RemoveAt(i);
                Console.WriteLine(i);
            }
            Random rnd = new Random();
            for (int i = 0; i < tomb.Length; i++)
            {
                tomb[i] = rnd.Next(100, 200);
            }
            Thread t1 = new Thread(osszeg1);
            t1.Start();
            Thread t2 = new Thread(osszeg2);
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine($"Összeg a két szálon {osszeg}");
            int norm = 0; // mennyi valójában
            foreach (int x in tomb)
            {
                norm += x; ;
            }
            Console.WriteLine($"Összeg valójában {norm}");
            if(norm!=osszeg)
                Console.WriteLine("Hiba van");
            Console.ReadLine();
        }
        static void osszeg1()
        {
            for (int i = 0; i < tomb.Length / 2; i++)            
                Interlocked.Add(ref osszeg, tomb[i]);            
        }
        static void osszeg2()
        {           
                for (int i = tomb.Length/2; i < tomb.Length; i++)                
                    Interlocked.Add(ref osszeg, tomb[i]);                          
        }
    }

}
