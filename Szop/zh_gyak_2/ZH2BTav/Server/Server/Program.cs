using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    internal class Program
    {
        public static List<User> Users = new List<User>();
        public static List<Utalas> Utalasok = new List<Utalas>();

        static void ReadingData()
        {
            string[] fileUsers = File.ReadAllLines("users.txt", Encoding.Default);
            foreach (string sor in fileUsers)
            {
                string[] data = sor.Split('|');
                User newUser = new User(data[0], data[1]);
                Users.Add(newUser);
            }

            //string[] films = File.ReadAllLines("lista.txt", Encoding.Default);
            //foreach (string sor in films)
            //{
            //    string[] data = sor.Split('|');
            //    DVD_film ujDVD = new DVD_film(data[0], data[1], false);
            //    Films.Add(ujDVD);
            //}
        }


        static void Main(string[] args)
        {
            string configIp = ConfigurationManager.AppSettings["IP"];
            string configPort = ConfigurationManager.AppSettings["port"];

            IPAddress ip = IPAddress.Parse(configIp);
            int port = int.Parse(configPort);

            TcpListener listener = new TcpListener(ip, port);
            listener.Start();

            ReadingData();

            bool vege = false;
            while (!vege)
            {
                Console.WriteLine("The server has been startad...");
                TcpClient kliens = listener.AcceptTcpClient();
                Szerver rental = new Szerver(kliens);
                Thread th = new Thread(rental.StartKomm);
                th.Start();
            }

        }
    }
}
