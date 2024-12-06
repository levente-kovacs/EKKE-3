using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace primszamkereso
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.SetWindowSize(140, 40);
            for (int i = 0; i < 4; i++)
            {
                int k = 10000 * i;
                int v = 10000 * (i + 1) - 1;
                Termelo t = new Termelo(k, v); // termelo objektum
                Thread thr = new Thread(t.elkezd); // ennek elkezd metódusa lesz egy szál
                thr.Start();
            }
            //4 termelő után jön a fogyasztó
            Fogyaszto f1 = new Fogyaszto(ConsoleColor.Yellow);
            Thread thr1 = new Thread(f1.elkezd);
            thr1.Start();
            Fogyaszto f2 = new Fogyaszto(ConsoleColor.Green);
            Thread thr2 = new Thread(f2.elkezd);
            thr2 .Start();
            thr1.Join();
            thr2.Join();
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("\n");
            Console.WriteLine($"Az 1. fogyasztó {f1.darabSzam} prímet írt ki.");
            Console.WriteLine($"A 2. fogyasztó {f2.darabSzam} prímet írt ki.");
            Console.ReadLine();
        }
    }
    class Termelo
    {
        protected int intervallum_kezd;
        protected int intervallum_vege;
        protected int azon;
        static int sorszam = 0;

        public Termelo(int k, int v)
        {
            this.intervallum_kezd = k;
            this.intervallum_vege = v;
            sorszam++;
            azon = sorszam;
        }
        public void elkezd()
        {
            Gyujto.termeloSzalindul();
            for (int i = intervallum_kezd; i <= intervallum_vege; i++)
            {
                if (prim_e(i))
                {
                    Gyujto.berak(i);
                }

            }
            Console.WriteLine($"\n\n{azon}. termelő leáll!\n");
            Gyujto.termeloSzalLeall();
        }
        public bool prim_e(int x)
        {
            int gyoke = (int)(Math.Sqrt(x));
            for (int i = 2; i <= gyoke; i++)
            {
                if (x % i == 0) return false;
            }
            return true;
        }
    }
    class Fogyaszto
    {
        protected ConsoleColor szin = ConsoleColor.Black;
        protected int _darabSzam = 0;

        public Fogyaszto(ConsoleColor szin)
        {
            this.szin = szin;
        }
        public int darabSzam
        {
            get
            {
                return _darabSzam;
            }
        }
        public void elkezd()
        {
            this._darabSzam = 0;
            Gyujto.fogyasztoSzalindul();
            while (true)
            {
                try
                {
                    int x = Gyujto.kivesz();
                    Console.ForegroundColor = this.szin;
                    Console.Write("{0,6}",x);
                    this._darabSzam++;
                }
                catch { break; }
            }
            Gyujto.fogyasztoSzalLeall();
        }
    }
    class Gyujto
    {
        static List<int> lista = new List<int>();
        const int maxMeret = 50;
        static bool _termelokLealltak = false;
        static int _termeloSzalFutDb = 0;
        static bool _fogyasztokLealltak = false;
        static int _fogyasztoSzalFutDb = 0;

        public static void fogyasztoSzalindul()
        {
            lock (typeof(Gyujto))
            {
                _fogyasztoSzalFutDb++;
            }
        }
        public static void fogyasztoSzalLeall()
        {
            lock (typeof(Gyujto))
            {
                if (_fogyasztoSzalFutDb > 0)
                    _fogyasztoSzalFutDb--;
                if(_fogyasztoSzalFutDb <= 0)
                {
                    _fogyasztokLealltak = true;
                    lock (lista)
                    {
                        Monitor.PulseAll(lista);
                    }
                }                
            }
        }
        public static bool fogyasztokLealltak
        {
            get { return _fogyasztokLealltak; }
        }
        public static void termeloSzalindul()
        {
            lock (typeof(Gyujto))
            {
                _termeloSzalFutDb++;
            }
        }
        public static void termeloSzalLeall()
        {
            lock (typeof(Gyujto))
            {
                if (_termeloSzalFutDb > 0)
                    _termeloSzalFutDb--;
                if (_termeloSzalFutDb <= 0)
                {
                    _termelokLealltak = true;
                    lock (lista)
                    {
                        Monitor.PulseAll(lista);
                    }
                }
            }
        }
        public static bool termelokLealltak
        {
            get { return _termelokLealltak; }
        }
        public static int kivesz()
        {
            int x;
            lock (lista)
            {
                while(lista.Count == 0)
                {
                    if (termelokLealltak)
                        throw new Exception("Leállt minden termelő");
                    Monitor.Wait(lista);
                }
                x = lista[0];
                lista.RemoveAt(0);
                Monitor.PulseAll(lista);
            }
            return x;
        }
        public static void berak(int x)
        {
            lock (lista)
            {
                while(lista.Count >= maxMeret)
                {
                    
                    if (fogyasztokLealltak)
                        throw new Exception("Leaállt minden fogyasztó");
                    Monitor.Wait(lista);
                }
                lista.Add(x);
                Monitor.PulseAll(lista);
            }
        }
    }
    
}
