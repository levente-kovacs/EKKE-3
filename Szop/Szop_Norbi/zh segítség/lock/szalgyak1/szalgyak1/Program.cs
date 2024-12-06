using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace szalgyak1
{
    internal class Program
    {
        const int N = 1000000;
        static int[] adatok = new int[N];
        static int osszeg = 0;
        static void elj1()
        {
            //or (int i = 0; i < N / 2; i++) mind a két megoldás jó
            //   lock (adatok)
            //   {
            //       osszeg += adatok[i];
            //   }
            int osszeg1 = 0;
            for (int i = 0; i < N/2; i++)
                osszeg1 += adatok[i];
            lock (typeof(Program)) // ha nincs mit lockolni (tömb,lista stb) lock (adatok)
            {
                osszeg += osszeg1;
            }
        }
        static void elj2()
        {
            //for (int i = N / 2; i < N; i++) mind a két megoldás jó
            //   lock (adatok)
            //   {
            //       osszeg += adatok[i];
            //   }
            int osszeg2 = 0;    
            for (int i = N/2; i < N; i++) 
                    osszeg2 += adatok[i];
            lock (typeof(Program)) // lock (adatok)
            {
                osszeg += osszeg2;
            }
        }
        static void Main(string[] args)
        {
            for(int i = 0; i < adatok.Length; i++)
                adatok[i] = i;
            Thread t1 = new Thread(elj1);
            Thread t2 = new Thread(elj2);
            t1.Priority = ThreadPriority.Highest;
            t2.Priority = ThreadPriority.Lowest;
            t1.Start(); t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(osszeg);
            //elj1();
            //elj2();
            Console.ReadKey();
        }
    }
}
