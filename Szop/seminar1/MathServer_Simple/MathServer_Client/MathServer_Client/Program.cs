using System.Net.Sockets;
using System.Text;

namespace MathServer_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 12345);
            StreamWriter w = new StreamWriter(client.GetStream(), Encoding.UTF8);
            StreamReader r = new StreamReader(client.GetStream(), Encoding.UTF8);
            string answer = r.ReadLine();
            Console.WriteLine(answer);
            while (answer.ToLower()!="bye")
            {
                Console.WriteLine("The command? ");
                string command = Console.ReadLine();
                w.WriteLine(command); w.Flush();//!!!!!!!!!!!!!!!!!!!!
                answer = r.ReadLine();
                if (answer == "OK*")
                {
                    while (answer != "OK!")
                    {
                        Console.WriteLine(answer);
                        answer = r.ReadLine();
                    }
                }
                else
                    Console.WriteLine(answer);
            }

        }
    }
}
