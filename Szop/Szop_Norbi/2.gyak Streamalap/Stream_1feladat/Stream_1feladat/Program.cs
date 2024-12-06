using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Stream_1feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {

            TcpClient csatl = null;
            StreamReader server = null;
            StreamWriter kliens = null;
            bool end = false;
            try
            {
                string ipcim = "127.0.0.1";
                int port = 2456;
                IPAddress ip = IPAddress.Parse(ipcim);
                csatl = new TcpClient(ipcim, port);
                server = new StreamReader(csatl.GetStream(), Encoding.UTF8);
                kliens = new StreamWriter(csatl.GetStream(), Encoding.UTF8);
                Console.WriteLine("A kapcsolat sikeresen létrejött.");
                string udvozles = server.ReadLine();
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
                Console.ForegroundColor =ConsoleColor.Gray;
                string feladat = Console.ReadLine();
                kliens.WriteLine(feladat);
                kliens.Flush();
                string visszatero = server.ReadLine();
                string[] adat = visszatero.Split('|');
                
                switch (adat[0])
                {
                    case "OK": Console.WriteLine($"Eredmény: {adat[1]}");
                        break;
                    case "ERR":
                        Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("ERR|Nullával való osztás");
                        break;
                    case "OK*":
                        {
                            string valasz = null;
                            while (valasz != "OK!")
                            {
                                valasz = server.ReadLine();
                                Console.WriteLine(valasz);
                            } 
                        }
                        
                        break;
                    case "BYE":
                        end = true;
                        break;
                    case "A kapcsolat megszakadt":
                        Console.WriteLine("Time out");
                        end = true;
                        break;
                    default: Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nem megfelelő parancs");
                        break;
                    
                }
            }
            Console.ReadLine();
        }
    }
}
