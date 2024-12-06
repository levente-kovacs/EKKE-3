using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Stream_feladat2_server
{
    internal class Program
    {
        static TcpListener figyelo = null;
        static Thread kapcsolatok = null;
        static public List<Thread> futoSzalak = new List<Thread>();

        static void Kapcsolat()
        {
            while (true)
            {
                TcpClient bejovo = figyelo.AcceptTcpClient();
                Console.WriteLine("Új kapcsolat jött létre.");
                KKomm kliens = new KKomm(bejovo);
                Thread t = new Thread(kliens.KomIndit);
                lock (futoSzalak)
                {
                    futoSzalak.Add(t);
                }
                t.Start();
            }
        }


        static void Main(string[] args)
        {

            string ipcim = ConfigurationManager.AppSettings["Ip-cim"];
            int port = int.Parse(ConfigurationSettings.AppSettings["Port"]);
            IPAddress ip = IPAddress.Parse(ipcim);
            figyelo = new TcpListener(ip, port);
            figyelo.Start();
            kapcsolatok = new Thread(Kapcsolat);
            kapcsolatok.Start();
            Console.WriteLine(ipcim);
            Console.ReadLine();
            figyelo.Stop();
            kapcsolatok.Abort();

        }
    }
}
