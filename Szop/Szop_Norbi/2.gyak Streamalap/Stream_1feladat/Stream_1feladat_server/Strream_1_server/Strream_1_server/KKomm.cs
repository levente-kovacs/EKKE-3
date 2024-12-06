using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Strream_1_server
{
    internal class KKomm
    {
        private StreamWriter server;
        private StreamReader kliens;

        static string Osztas(string a, string b)
        {
            if(a == "0" || b == "0")            
                return "ERR";

            int x = int.Parse(a);
            int y = int.Parse(b);
            double eredmeny = (double)x / y;
            return Math.Round(eredmeny, 2).ToString();



        }

        public KKomm(TcpClient bejovo)
        {
            server = new StreamWriter(bejovo.GetStream(), Encoding.UTF8);
            kliens = new StreamReader(bejovo.GetStream(), Encoding.UTF8);
        }

        public void KomIndit()
        {
            bool torles = true;
            server.WriteLine("SZ Server | 0.2");
            server.Flush();
            bool kommVege = false;
            try
            {
                while(!kommVege)
                {
                    ReaderFromStream rs = new ReaderFromStream();
                    string feladat = rs.ReadLine(kliens, 120000);
                    Console.WriteLine(feladat);
                    if(feladat == null)
                    {
                        kommVege = true;
                        break;
                    }

                    string[] adat = feladat.Split('|');            
                    
                    switch (adat[0])
                    {
                        case "osztas":
                            {
                                string ertek = Osztas(adat[1], adat[2]);
                                if (ertek == "ERR")
                                {
                                    server.WriteLine(ertek);
                                }
                                else
                                    server.WriteLine($"OK|{ertek}");
                                server.Flush();
                            }
                            
                            break;
                        case "10":
                            {
                                server.WriteLine("OK*");
                                server.Flush();
                                for (int i = 0; i < 10; i++)
                                {
                                    server.WriteLine(i);
                                    server.Flush();
                                }
                                server.WriteLine("OK!");
                                server.Flush();
                            }                            
                            break;

                        default:
                            server.WriteLine("A kapcsolat megszakadt");
                            break;
                    }

                }
            }
            catch (Exception e)
            {
                if (e is ThreadAbortException)
                    torles = false;

                kommVege = true;
            }
            
            if (torles)
            {
                Console.WriteLine("Kapcsolat törölve");
                lock (Strream_1_server.Program.futoSzalak)
                {
                    Thread mostFutoSzal = Thread.CurrentThread;
                    int index = Strream_1_server.Program.futoSzalak.IndexOf(mostFutoSzal);
                    if(index != -1)
                        Strream_1_server.Program.futoSzalak.RemoveAt(index);
                }
            }
        }


    }
}
