using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MotorClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["IP"];
            int port = int.Parse(ConfigurationManager.AppSettings["port"]);

            TcpClient kliens = new TcpClient(ip, port);

            StreamReader sReader = new StreamReader(kliens.GetStream(), Encoding.UTF8);
            StreamWriter sWriter = new StreamWriter(kliens.GetStream(), Encoding.UTF8);
            string server_response = sReader.ReadLine();
            Console.WriteLine(server_response);
            string client_string = Console.ReadLine();
            sWriter.WriteLine(client_string);
            sWriter.Flush();
            while (client_string.ToUpper() != "EXIT")
            {
                server_response = sReader.ReadLine();
                if (server_response == "OK*")
                {
                    server_response = sReader.ReadLine();
                    while (server_response != "OK!")
                    {
                        Console.WriteLine(server_response);
                        server_response = sReader.ReadLine();
                    }
                }
                else
                {
                    string[] sor = server_response.Split('|');
                    if (sor[0] == "ERR")
                        Console.WriteLine("Error: " + sor[1]);
                    else
                        Console.WriteLine($"Result: {sor[1]}");
                }
                Console.WriteLine("\nWhat is your next command?");
                client_string = Console.ReadLine();
                sWriter.WriteLine(client_string);
                sWriter.Flush();
            }

        }
    }
}
