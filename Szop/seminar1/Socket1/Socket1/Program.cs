using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Socket1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string ip = "127.0.0.1"; int port = 12345;
            IPAddress ipaddress = IPAddress.Parse(ip);
            TcpListener tcp = new TcpListener(ipaddress, port);
            tcp.Start();
            TcpClient client = tcp.AcceptTcpClient(); //The code stops here....
            Console.WriteLine("A new client :-))");
            StreamWriter w = new StreamWriter(client.GetStream(), Encoding.UTF8);
            StreamReader r = new StreamReader(client.GetStream(), Encoding.UTF8);
            w.WriteLine("Luke, Ich bin dein Vater - strange server welcome...");
            w.Flush();
            string taskToDo= r.ReadLine();
            Console.WriteLine("The client asked: " + taskToDo);
            w.WriteLine("I cannot solve...:-((");
            w.Flush();
            Console.ReadLine();
            



        }
    }
}
