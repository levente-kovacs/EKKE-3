using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stream_feladat2_server
{
    internal class KKomm
    {

        private StreamWriter w;
        private StreamReader r;

        public KKomm(TcpClient bejovo)
        {
            w = new StreamWriter(bejovo.GetStream(),Encoding.UTF8);
            r = new StreamReader(bejovo.GetStream(),Encoding.UTF8);
        }
        private void Olvasas(StreamReader olvaso,string feladat,ref bool vege)
        {
            
        }
        private string Add(string a,string b)
        {
            int x = int.Parse(a);
            int y = int.Parse(b);
            int c = x + y;
            return c.ToString();
        }

        public void KomIndit()
        {
            bool torles = true;

            w.WriteLine("Server|1.0");
            w.Flush();
            bool vege = false;

            try
            {
                while (!vege)
                {
                    ReaderFromStream rs = new ReaderFromStream();
                    string feladat = rs.ReadLine(r, 90000);
                    Console.WriteLine(feladat);
                    string[] adat = feladat.Split('|');
                    switch (adat[0])
                    {
                        case "ADD":
                            w.WriteLine(Add(adat[1], adat[2]));
                            w.Flush();
                            break;
                        case "FIBO":
                            break;
                        case "PRIM":
                            break;
                        case "BYE":
                            vege = false;
                            break;

                    }
                }
            }
            catch (Exception e)
            {
                if (e is ThreadAbortException)
                    torles = false;
                                
            }
            if (torles)
            {
                Console.WriteLine("Kapcsolat törölve");
                lock (Stream_feladat2_server.Program.futoSzalak)
                {
                    Thread mostFutoSzal = Thread.CurrentThread;
                    int index = Stream_feladat2_server.Program.futoSzalak.IndexOf(mostFutoSzal);
                    if (index != -1)
                        Stream_feladat2_server.Program.futoSzalak.RemoveAt(index);
                }
            }
        }
        void Fib(int num)
        {
            long f1 = 1; long f2 = 1; long fib = f1 + f2; int db = 2;
            while (db <= num)
            {
                fib = f1 + f2;
                f1 = f2;
                f2 = fib;
                db++;
            }
            if (num == 1 || num == 2)
                w.WriteLine("1");
            else
                w.WriteLine(fib);
        }
        void Fibs(int num)
        {
            w.WriteLine("OK*");
            long f1 = 1; long f2 = 1; long fib = f1 + f2; int db = 2;
            w.WriteLine(1);
            if (num > 1)
                w.WriteLine(1);
            while (db <= num)
            {
                fib = f1 + f2;
                w.WriteLine(fib);
                f1 = f2;
                f2 = fib;
                db++;
            }
            w.WriteLine("OK!");
        }

        void Sum(long num)
        {
            long db = 0;
            while (num != 0)
            {
                db += num % 10;
                num /= 10;
            }
            w.WriteLine(db);
        }
    }

}

