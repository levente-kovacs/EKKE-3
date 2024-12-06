using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Stream_feladat2_kliens
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient csatl = null;
            StreamReader olvaso = null;
            StreamWriter iro = null;
            string ipcim = ConfigurationManager.AppSettings["Ip-cim"];
            IPAddress ip = IPAddress.Parse(ipcim);
            int port = int.Parse(ConfigurationSettings.AppSettings["Port"]);
            bool end = false;
            try
            {
                csatl = new TcpClient(ipcim, port);
                olvaso = new StreamReader(csatl.GetStream(), Encoding.UTF8);
                iro = new StreamWriter(csatl.GetStream(), Encoding.UTF8);
                Console.WriteLine("A kapcsolat sikeresen létrejött");
                string udvozles = olvaso.ReadLine();
                Console.WriteLine(udvozles);

            }
            catch
            {
                csatl = null;
                Console.WriteLine("A kliens nem tud csatlakozni a szerverhez.");
                end = true;
            }
            while (!end)
            {
                string feladat = Console.ReadLine();
                iro.WriteLine(feladat);
                iro.Flush();
                string visszatero = olvaso.ReadLine();
                Console.WriteLine($"Eredmény: {visszatero}");
            }
            Console.ReadLine();
        }
    }
}
