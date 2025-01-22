using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace KliensProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["IP"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);

            TcpClient kliens = new TcpClient(ip, port);

            //TcpClient kliens = new TcpClient("127.0.0.1", 1111);
            StreamReader sReader = new StreamReader(kliens.GetStream(), Encoding.UTF8);
            StreamWriter sWriter = new StreamWriter(kliens.GetStream(), Encoding.UTF8);
            string szerver_valasz = sReader.ReadLine();
            Console.WriteLine(szerver_valasz);
            //string parancsok;// = olvas.ReadLine();
            //Console.WriteLine(parancsok);
            string kliens_szoveg = Console.ReadLine();
            sWriter.WriteLine(kliens_szoveg);
            sWriter.Flush();
            while (kliens_szoveg.ToUpper() != "EXIT")
            {
                szerver_valasz = sReader.ReadLine();
                //Console.WriteLine(szerver_valasz);
                if (szerver_valasz == "OK*")
                {
                    szerver_valasz = sReader.ReadLine();
                    while (szerver_valasz != "OK!")
                    {
                        Console.WriteLine(szerver_valasz);
                        szerver_valasz = sReader.ReadLine();
                    }
                }
                else
                {
                    string[] sor = szerver_valasz.Split('|');
                    if (sor[0] == "ERR")
                        Console.WriteLine("Hiba: " + sor[1]);
                    else
                        Console.WriteLine($"A művelet eredménye: {sor[1]}");
                }
                Console.WriteLine("\nMi a következő parancs?");
                kliens_szoveg = Console.ReadLine();
                sWriter.WriteLine(kliens_szoveg);
                sWriter.Flush();
            }

        }
    }
}
