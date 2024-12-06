using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server2_tobbszal
{
    internal class Program
    {
        static TcpListener figyelo = null;
        static Thread kapcsolatok = null;
        public static List<Thread> futo_szalak = new List<Thread>();//szál tárolására Ha ezt használjuk, csak a szálat tároljuk
        //static List<Tuple<KliensKomm,Thread>> futo_szalak ( new List<Tuple<KliensKomm,Thread>>(); //ha ezt, akkor az osztályt is.
        static void Main(string[] args)
        {
            string ipcim = ConfigurationManager.AppSettings["IP-cim"];
            string portszam = ConfigurationSettings.AppSettings["portszam"];
            IPAddress ip = IPAddress.Parse(ipcim);
            int port = int.Parse(portszam);
            figyelo = new TcpListener(ip, port);
            figyelo.Start();
            kapcsolatok = new Thread(kapcsolatFogad);
            kapcsolatok.Start();
            Console.WriteLine(ipcim);
            Console.ReadLine();

            figyelo.Stop();
            kapcsolatok.Abort(); //vagy így abortáljuk a szálakat, vagy
            /*lock (futo_szalak)
                foreach (Tuple<KlinesKomm,Thread> p in futo_szalak)
                {
                    try
                    {
                        p.Item2.Abort();
                    }
                    catch{}
                }
            }*/
            //Environment.Exit(0);            
        }
        static void kapcsolatFogad()
        {
            while (true)
            {
                TcpClient bejovo = figyelo.AcceptTcpClient(); Console.WriteLine("Új kapcsolat"); // itt várunk a kapcsolatra
                KliensKomm k = new KliensKomm(bejovo);
                Thread t = new Thread(k.kommIndit);
                lock (futo_szalak) // tároljuk el a szálakat
                {
                    futo_szalak.Add(t); // ha csak a szálat tároljuk
                    //futo_szalak.Add(new Tuple<KliensKomm,Thread>(k,t)); // klienskomm is tárolva
                }
                t.Start();
            }
        }
    }
    class KliensKomm
    {
        protected StreamWriter iro;
        protected StreamReader olvaso;

        public KliensKomm(TcpClient bejovo)
        {
            iro = new StreamWriter(bejovo.GetStream(),Encoding.UTF8);
            olvaso = new StreamReader(bejovo.GetStream());
        }
        public void kommIndit()
        {
            bool torles_kell = true;
            iro.WriteLine("SZG SZERVER| 1.0");
            iro.Flush();
            bool vege = false;
            try
            {
                while (!vege)
                {
                    ReaderFromStream rs = new ReaderFromStream();
                    string feladat = rs.ReadLine(olvaso, 9000); //

                    Console.WriteLine(feladat);
                    string[] ss = feladat.Split('|');
                    switch (ss[0])
                    {
                        case "OSSZEAD":
                            {
                                int a = int.Parse(ss[1]);
                                int b = int.Parse(ss[2]);
                                int c = a + b;
                                iro.WriteLine($"EREDMENY|{c}");
                                iro.Flush();
                                Console.WriteLine("Kész");

                            }
                            break;
                        case "OSZTAS":
                            {
                                int a = int.Parse(ss[1]);
                                int b = int.Parse(ss[2]);
                                if (b == 0)
                                {
                                    iro.WriteLine("ERR|101|nullával osztás");
                                }
                                else
                                {
                                    int c = a / b;
                                    iro.WriteLine($"EREDMENY|{c}");
                                }
                                iro.Flush();
                            }
                            break;
                        case "BYE":
                            vege = true;
                            iro.WriteLine("BYE");
                            iro.Flush();
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                if (e is ThreadAbortException)
                    torles_kell = false;
            }
            if (torles_kell)
            {
                Console.WriteLine("Kapcsolat törölve!");
                lock (Server2_tobbszal.Program.futo_szalak)
                {
                    Thread ez = Thread.CurrentThread;
                    int i = Server2_tobbszal.Program.futo_szalak.IndexOf(ez); // megkeresem a processzt a futó szálak listájában.
                    if (i != -1)
                        Server2_tobbszal.Program.futo_szalak.RemoveAt(i);
                }
            }
        }
    }
    class ReaderFromStream
    {
        protected StreamReader r;
        protected string line = null;
        protected void DoRead()
        {
            line = r.ReadLine();
        }
        public string ReadLine(StreamReader r, int timeoutMSec)
        {
            this.r = r;
            this.line = null;
            Thread t = new Thread(DoRead);
            t.Start();
            if (t.Join(timeoutMSec) == false)
            {
                t.Abort();
                return null;
            }
            return line;
        }
    }
}
