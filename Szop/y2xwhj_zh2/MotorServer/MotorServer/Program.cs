using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Configuration;

namespace MotorServer
{
    internal class Program
    {
        public static List<User> Users = new List<User>();
        public static List<Motor> Motors = new List<Motor>();

        static void ReadData()
        {
            string[] fileUsers = File.ReadAllLines("userek.txt", Encoding.Default);
            foreach (string sor in fileUsers)
            {
                string[] data = sor.Split('|');
                User newUser = new User(data[0], data[1]);
                Users.Add(newUser);
            }

            string[] films = File.ReadAllLines("motorok.txt", Encoding.Default);
            foreach (string sor in films)
            {
                string[] data = sor.Split('|');
                Motor newMotor = new Motor(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]));
                Motors.Add(newMotor);
            }
        }

        static void Main(string[] args)
        {
            string configIp = ConfigurationManager.AppSettings["IP"];
            string configPort = ConfigurationManager.AppSettings["port"];

            IPAddress ip = IPAddress.Parse(configIp);
            int port = int.Parse(configPort);

            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            ReadData();

            while (true)
            {
                Console.WriteLine("The server has been startad...");
                TcpClient client = listener.AcceptTcpClient();
                Server rental = new Server(client);
                Thread thread = new Thread(rental.StartKomm);
                thread.Start();
            }
        }
    }
}
