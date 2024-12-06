using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SocClient
{
    class Program
    {
        /*    TcpClient csatl = null;
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
            }*/
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 50000);
            StreamReader r = new StreamReader(client.GetStream(), Encoding.UTF8);
            StreamWriter w = new StreamWriter(client.GetStream(), Encoding.UTF8);
            bool end = false;
            string message = r.ReadLine();
            Console.WriteLine(message);
            while (!end)
            {
                string command = Console.ReadLine();
                w.WriteLine(command);
                w.Flush();
                message = r.ReadLine();
                Console.WriteLine(message);
                if (message == "OK*")
                {
                    Console.WriteLine("Ez egy többsoros üzenet");
                    while (message != "OK!")
                    {
                        message = r.ReadLine();
                        Console.WriteLine(message);
                    }
                }
                if (command == "EXIT")
                    end = true; 
            }
        }
    }
}
