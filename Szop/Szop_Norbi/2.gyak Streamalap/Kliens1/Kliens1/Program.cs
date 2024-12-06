using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Kliens1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient csatl = null;
            StreamReader r = null;
            StreamWriter w = null;
            try
            {
                //string ipCim = ConfigurationManager.AppSettings["IP-cim"];
                string ipcim = "127.0.0.1";
                string portszam = "2456";
                IPAddress ip = IPAddress.Parse(ipcim);
                int port = int.Parse(portszam);
                csatl = new TcpClient(ipcim, port);
                r = new StreamReader(csatl.GetStream());
                w = new StreamWriter(csatl.GetStream(), Encoding.UTF8);
                Console.WriteLine("Sikerült");
            }
            catch
            {
                csatl = null;
            }
            string udvozles = r.ReadLine();
            Console.WriteLine(udvozles);
            bool end = false;
            while (!end)
            {
                string command = Console.ReadLine();
                w.WriteLine(command);
                w.Flush();
                string m = r.ReadLine();
                string[] ss = m.Split('|');
                if (ss[0] == "ERR")
                    Console.WriteLine($"Hiba, kód:{ss[1]},{ss[2]}");
                else
                {
                    Console.WriteLine(m);
                }
                if (m == "BYE")
                    end = true;
            }
        }
    }
}
