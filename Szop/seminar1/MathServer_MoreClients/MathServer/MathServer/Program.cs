using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Configuration;
using System.Net;
using System.Net.Sockets;
using System.IO;
namespace MathServer
{
    class CommunicationClass
    {
        StreamWriter w = null;
        StreamReader r = null;

        public CommunicationClass(TcpClient client)
        {
            w = new StreamWriter(client.GetStream(), Encoding.UTF8);
            r = new StreamReader(client.GetStream(), Encoding.UTF8);
            w.WriteLine("Math Server 1.0"); w.Flush();
        }

        public void CommunicationStart()
        {
            string command = "";
            while (command.ToLower() != "bye")
            {
                try
                {
                    command = r.ReadLine();
                    string[] line = command.ToLower().Split('|');
                    switch (line[0])
                    {
                        case "add": int result = int.Parse(line[1]) + int.Parse(line[2]); w.WriteLine(result); break;
                        case "primes": Primes(int.Parse(line[1])); break;
                        case "fibo": int fibo = Fibo(int.Parse(line[1])); w.WriteLine(fibo); break;
                        case "bye": w.WriteLine("Bye"); break;
                        default: w.WriteLine("ERR|Unknow command"); break;
                    }
                    w.Flush();
                }
                catch (Exception e) { Console.WriteLine("Rude client...."); break; }
            }

        }
        bool IsPrime(int number)
        {
            bool prime = true;
            for (int i = 2; i <= Math.Sqrt(number) && prime; i++)
            {
                if (number % i == 0)
                    prime = false;
            }
            return prime;
        }
         void Primes(int n)
        {
            w.WriteLine("OK*");
            for (int i = 2; i <= n; i++)
                if (IsPrime(i))
                    w.WriteLine("{0} ", i);
            w.WriteLine("OK!");
        }
        int Fibo(int n)
        {
            if (n == 1 || n == 2)
                return 1;
            int f1 = 1; int f2 = 1; int f3 = 0; ;
            for (int i = 2; i <= n; i++)
            {
                f3 = f1 + f2;
                f1 = f2; f2 = f3;
            }
            return f3;
        }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string ip = "127.0.0.1"; int port = 12345;
            IPAddress ipaddress = IPAddress.Parse(ip);
            TcpListener tcp = new TcpListener(ipaddress, port);
            tcp.Start();
            while (true)
            {
                TcpClient client = tcp.AcceptTcpClient(); //The code stops here....
                Console.WriteLine("A new client :-))");
                CommunicationClass cl = new CommunicationClass(client);
                Thread t = new Thread(cl.CommunicationStart);
                t.Start();
            }
        }
    }
}
