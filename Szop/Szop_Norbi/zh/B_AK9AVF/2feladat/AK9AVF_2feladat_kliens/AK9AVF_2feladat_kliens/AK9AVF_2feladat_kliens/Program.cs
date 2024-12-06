using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AK9AVF_2feladat_kliens
{
    
   class Program
   {       
       static void Main(string[] args)
       {
           TcpClient client = new TcpClient("127.0.0.1", 2456);
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
