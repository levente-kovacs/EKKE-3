using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Streamkomm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*string gepNeve = Dns.GetHostName();
            IPHostEntry cimek = Dns.GetHostEntry(gepNeve);
            foreach (IPAddress ip in cimek.AddressList)
                Console.WriteLine($"IP cim: {ip}");
            string teljesNev = Assembly.GetExecutingAssembly().Location;
            Console.WriteLine($"A futó program neve {teljesNev}");
            string portSzam = ConfigurationSettings.AppSettings["portSzam"];*/
            TcpListener figyelo = null;
            try
            {
                string ipcim = ConfigurationManager.AppSettings["IP-cim"];
                string portszam = ConfigurationSettings.AppSettings["portszam"];
                IPAddress ip = IPAddress.Parse(ipcim);
                int port = int.Parse(portszam);
                figyelo = new TcpListener(ip, port);
                figyelo.Start();
                Console.WriteLine(ipcim);
            }
            catch
            {
                figyelo=null;
            }
            TcpClient bejovo = figyelo.AcceptTcpClient(); Console.WriteLine("Stop");
            StreamWriter iro = new StreamWriter(bejovo.GetStream(),Encoding.UTF8);
            StreamReader olvaso = new StreamReader(bejovo.GetStream());
            //kiírni
            iro.WriteLine("SZG SZERVER|1.0");
            iro.Flush();
            bool vege = false;
            while (!vege)
            {
                string feladat = olvaso.ReadLine();
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
                            if(b == 0)
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
                        //iro.WriteLine("BYE");
                        //iro.Flush();
                        break;
                }
            }
        }
    }
}
