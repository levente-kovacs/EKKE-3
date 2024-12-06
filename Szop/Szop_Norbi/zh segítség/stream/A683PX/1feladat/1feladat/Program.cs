using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace _1feladat
{
    // szomszed:Kerenyi Robert
    class BigVector
    {

        private int[] array = new int[1000];
        public int Sum = 0;
        public int also = 0;
        public int felso = 0;
         int i = 0;
         int j = 999;

        public BigVector()
        {
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 1;
            }
        }
      

        public void alsofele()
        {
            

            while (i < j)
            {
                lock (array)
                {
                    
                    Sum += array[i];
                    i++;
                    also++;
                }
            }
        }

        public void felsofele()
        {
            

            while (i < j)
            {
                lock (array)
                {
                    Sum += array[i];
                    j--;
                    felso++;
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            BigVector bv = new BigVector();
            Thread t1 = new Thread(bv.alsofele);
            Thread t2 = new Thread(bv.felsofele);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine(" Tomb osszege: {0}, Also altal hozza adott: {1} db, Felso altal hozzaadott: {2} db", bv.Sum, bv.also, bv.felso);
            Console.ReadLine();
        }
    }


}
