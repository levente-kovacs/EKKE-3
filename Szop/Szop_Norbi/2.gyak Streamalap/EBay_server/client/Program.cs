using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClient list = new TcpClient("127.0.0.1", 12345);
            StreamReader read = new StreamReader(list.GetStream(), Encoding.UTF8);
            StreamWriter write = new StreamWriter(list.GetStream(), Encoding.UTF8);
            Console.WriteLine("Succesfull connection");
            string message = read.ReadLine();
            Console.WriteLine("Server message: {0}", message);
            bool end = false;
            while (!end)
            {
                string command = Console.ReadLine();
                write.WriteLine(command); write.Flush();
                string answer = read.ReadLine();
                if (answer == "OK*")
                {
                    Console.WriteLine(answer);
                    while (answer != "OK!")
                    {
                        answer = read.ReadLine();
                        Console.WriteLine(answer);
                    }
                }
                else
                    Console.WriteLine(answer);
                if (answer == "BYE")
                    end = true;
            }
        }
    }
}
