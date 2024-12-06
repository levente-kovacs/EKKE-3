using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace megadott_fogy_db
{
    internal class Fogyaszto
    {
        ConsoleColor szin;
        private int megtalaltdb;
        private int azon;
        private static int sorszam;
        public Fogyaszto(ConsoleColor szin)
        {
            this.szin = szin;
            lock(typeof(Fogyaszto))              
            {
                sorszam++;
            }
            this.azon = sorszam;
        }

        public int Megtalaltdb
        {
            get { return megtalaltdb; }
        }

        public void FogyasztoElkezd()
        {
            Gyujto.FogyasztoSzalIndul();
            for (int i = 0; i < 20; i++)
            {
                try
                {
                    int ertek = Gyujto.Kivesz();
                    Console.ForegroundColor = szin;
                    Console.WriteLine($"{azon}. fogyasztó: {ertek}\t");
                    megtalaltdb++;

                }
                catch { Console.WriteLine("Minden termelő leállt"); break; }

            } 
               
            
            Gyujto.FogyasztoSzalLeall();
        }

    }
}
