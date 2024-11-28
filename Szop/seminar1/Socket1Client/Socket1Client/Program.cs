using System.Net.Sockets;
using System.Text;

namespace Socket1Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1", 12345);
            StreamWriter w = new StreamWriter(client.GetStream(), Encoding.UTF8);
            StreamReader r = new StreamReader(client.GetStream(), Encoding.UTF8);
            string message = r.ReadLine();
            Console.WriteLine(message);
            string exercise = Console.ReadLine();
            w.WriteLine(exercise);
            w.Flush();
            string answer = r.ReadLine();
            Console.WriteLine(answer);
            Console.ReadKey();
        }
    }
}
