using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace tombfeltoltes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            tomb adat1 = new tomb(1);
            adat1.feltolt();
            Thread t1 = new Thread(adat1.alsof);
            Thread t2 = new Thread(adat1.felsof);
            t1.Start();t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(adat1.Osszeg);
            Console.ReadKey();
        }
    }
    class tomb
    {
        
        int szamjegy = 0;
        int osszeg = 0;
        public tomb(int szamjegy) 
        {            
            this.szamjegy = szamjegy;
        }

        int[] adatok = new int[500000];                

        public void feltolt()
        {

            for (int i = 0; i < adatok.Length; i++)
            {
                adatok[i] = szamjegy;
            }

        }

        public void alsof()
        {
            for(int i = 0; i < adatok.Length / 2; i++)
			{
                lock (typeof(Program))
                {
                    osszeg += adatok[i];
                }
                
            }
        }
        public void felsof()
        {
            for (int i = adatok.Length / 2; i < adatok.Length; i++)
            {
                lock (typeof(Program))
                {
                    osszeg += adatok[i];
                }

            }
        }

        public int Osszeg 
        {
            get
            {
                return osszeg;
            }             
        }

    }
}
