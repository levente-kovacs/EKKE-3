using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gyakorlas_4feladat
{
    internal class Termelo
    {
        private int oszto;
        private int db;
        private int talalt = 0;
        private int k;
        private int v;        
        static private int sorszam;
        private int azon;
        Random rnd = new Random();
        public Termelo(int oszto, int db,int k,int v)
        {
            this.oszto = oszto;
            this.db = db;
            this.k = k;
            this.v = v;
            lock (typeof(Termelo))
            {
                sorszam++;
            }            
            azon = sorszam;
        }
        public void Elkezd()
        {
            Gyujto.TermeloSzalIndul();
            while(talalt < db)
            {
                int ertek = rnd.Next(k,v);
                if (Oszthato(ertek))
                {
                    Gyujto.Berak(ertek);
                    talalt++;                    
                    Console.WriteLine($"{azon}. termelő berakta: {ertek}");
                }                
            }
            Console.WriteLine($"{azon}. termelő leállt!");
            Gyujto.TermeloSzalLeall();
        }

        public bool Oszthato(int ertek)
        {
            if (ertek % oszto == 0)
                return true;
            return false;
        }
    }
}
