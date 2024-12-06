using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Socket1Client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 12345);
            
                StreamReader r = new StreamReader(client.GetStream(), Encoding.UTF8);
                StreamWriter w = new StreamWriter(client.GetStream(), Encoding.UTF8);
                string comm = r.ReadLine();
                Console.WriteLine(comm);
                string task = Console.ReadLine();
                w.WriteLine(task);
                w.Flush();
            try
            {
                while (task.ToUpper() != "BYE")
                {
                    string answer = r.ReadLine();
                    if (answer == "OK*") //több soros válasz
                        while (answer != "OK!")
                        {
                            answer = r.ReadLine();
                            Console.WriteLine(answer);
                        }
                    else
                    {
                        string[] line = answer.Split('|');
                        if (line[0] == "ERR")
                            Console.WriteLine("Hibás parancs");
                        else
                            Console.WriteLine("Az eredmény: {0}", line[1]);
                    }
                    Console.WriteLine("A következő parancs?");
                    task = Console.ReadLine();
                    w.WriteLine(task);
                    w.Flush();
                }
            }
            catch (Exception e) { Console.WriteLine("A szerver halott"); Console.WriteLine(task); }
            Console.ReadKey();
        }
    }
}
