using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Strream_1_server
{
    internal class Program
    {
        static TcpListener figyelo = null;
        static Thread kapcsolatok = null;
        public static List<Thread> futoSzalak = new List<Thread>();
        static void Main(string[] args)
        {

            string ipcim = ConfigurationManager.AppSettings["Ip-cim"];
            string portszam = ConfigurationSettings.AppSettings["Port"];
            IPAddress ip = IPAddress.Parse(ipcim);
            int port = int.Parse(portszam);
            figyelo = new TcpListener(ip, port);
            figyelo.Start();
            kapcsolatok = new Thread(KapcsolatFogadas);
            kapcsolatok.Start();
            Console.WriteLine(ipcim);
            Console.ReadLine();
            figyelo.Stop();
            kapcsolatok.Abort();
        }
        static void KapcsolatFogadas()
        {
            while (true)
            {
                TcpClient bejovo = figyelo.AcceptTcpClient();
                Console.WriteLine("Új kapcsolat");
                KKomm k = new KKomm(bejovo);
                Thread t = new Thread(k.KomIndit);
                lock (futoSzalak)
                {
                    futoSzalak.Add(t);
                }
                t.Start();
            }
        }
    }
}
