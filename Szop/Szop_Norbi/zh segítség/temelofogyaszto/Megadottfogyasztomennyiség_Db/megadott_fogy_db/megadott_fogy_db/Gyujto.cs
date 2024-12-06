using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace megadott_fogy_db
{
    internal class Gyujto
    {
        private static List<int> lista = new List<int>();
        private const int maxMeret = 10;
        static bool termelokLealltak = false;
        static bool fogyasztokLealltak = false;
        static int termeloFutdb = 0;
        static int fogyasztoFutdb = 0;

        public static void FogyasztoSzalLeall()
        {

            lock (typeof(Gyujto))
            {
                if (fogyasztoFutdb > 0)
                    fogyasztoFutdb--;
                if (fogyasztoFutdb <= 0)
                {
                    fogyasztokLealltak = true;
                    lock (lista)
                    {
                        Monitor.PulseAll(lista);
                    }
                }
            }
        }
        public static void FogyasztoSzalIndul()
        {
            lock (typeof(Gyujto))
            {
                fogyasztoFutdb++;
            }
        }
        public static void TermeloSzalIndul()
        {
            lock (typeof(Gyujto))
            {
                termeloFutdb++;
            }
        }
        public static void TermeloSzalLeall()
        {
            lock (typeof(Gyujto))
            {
                if (termeloFutdb > 0)
                    termeloFutdb--;
                if (termeloFutdb <= 0)
                {
                    termelokLealltak = true;
                    lock (lista)
                    {
                        Monitor.PulseAll(lista);
                    }
                }
            }
        }
        public static int Kivesz()
        {
            int x;
            lock (lista)
            {
                while (lista.Count == 0)
                {
                    if (termelokLealltak)
                        throw new Exception("Minden termelő leállt");
                    Monitor.Wait(lista);
                }
                x = lista[0];
                lista.RemoveAt(0);
                Monitor.PulseAll(lista);
            }
            return x;
        }
        public static void Berak(int x)
        {
            lock (lista)
            {
                while (lista.Count == maxMeret)
                {
                    if (fogyasztokLealltak)
                        throw new Exception("Minden fogyasztó leállt");
                    Monitor.Wait(lista);
                }
                lista.Add(x);
                Monitor.PulseAll(lista);
            }
        }
    }
}

