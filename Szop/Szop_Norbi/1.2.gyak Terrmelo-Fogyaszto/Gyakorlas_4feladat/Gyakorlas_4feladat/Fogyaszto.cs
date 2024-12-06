using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_4feladat
{
    internal class Fogyaszto
    {
        ConsoleColor szin;
        private int megtalaltdb;
        private int azon;
        public Fogyaszto(ConsoleColor szin, int azon)
        {
            this.szin = szin;
            this.azon = azon;
        }

        public int Megtalaltdb
        {
            get { return megtalaltdb; }
        }

        public void FogyasztoElkezd()
        {
            Gyujto.FogyasztoSzalIndul();
            while (true)
            {
                try
                {
                    int ertek = Gyujto.Kivesz();
                    Console.ForegroundColor = szin;
                    Console.WriteLine($"{azon}. fogyasztó: {ertek}\t");
                    megtalaltdb++;

                }
                catch { break; }
            }
            Gyujto.FogyasztoSzalLeall();
        }
        
    }
}
