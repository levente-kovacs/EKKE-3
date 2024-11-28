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
using System.Xml.Linq;

namespace Ebay
{
    class Products
    {
        string code;

        public string Code { get; set; }
        string name;
        public string Name { get; set; }
        int price;
        public int Price { get; set; }

        string user;

        public string User { get; set; }

        public Products(string p1, string p2, int p3, string p4)
        {
            Code = p1; Name = p2; Price = p3; User = p4;
        }
    
    }
    class CommunicationClass
    {
        StreamWriter w = null;
        StreamReader r = null;
        string user = null;
        List<Products> products = new List<Products>();

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
                        case "login": Login(line[0], line[1]);break;
                        case "add": Add(line[0], line[1], int.Parse(line[2])); break;
                        case "bid": Bid(line[0], int.Parse(line[1])); break;
                        case "list": List(); break;
                        case "bye": w.WriteLine("Bye"); break;
                        default: w.WriteLine("ERR|Unknow command"); break;
                    }
                    w.Flush();
                }
                catch (Exception e) { Console.WriteLine("Rude client...."); break; }
            }

        }

        void List()
        {
            w.WriteLine("OK*");
            lock (products)
            {
                foreach (Products item in products)
                    w.WriteLine($"{item.Code}, {item.Name},  {item.Price}, {item.User}");
            }
            w.WriteLine("OK!");
        
        }
        void Add(string code, string name, int price)
        {
            if (this.user == null)
                w.Write("Err|Log in, please");
            else
            {
                bool exist = false;
                lock (products)
                {
                    for (int i = 0; i < products.Count && !exist; i++)
                        if (products[i].Code == code)
                            exist = true;
                    if (!exist)
                    {
                        products.Add(new Products(code, name, price, user));
                        w.WriteLine("OK|It has been added");
                    }
                    else
                        w.WriteLine("ERR|It exists");
                }
            }
        }

        void Bid(string code, int price)
        {
            if (this.user == null)
                w.Write("Err|Log in, please");
            else
            {
                bool exist = false;
                lock (products)
                {
                    int pos = -1;
                    for (int i = 0; i < products.Count && !exist; i++)
                        if (products[i].Code == code)
                        {
                            exist = true;
                            pos = i;
                        }
                    if (exist)
                    {
                        if (price <= products[pos].Price)
                            w.WriteLine("ERR|Low prices");
                        else
                        {
                            products[pos].Price = price;
                            w.WriteLine("OK|It has been changed");
                        }
                    }
                    else
                        w.WriteLine("ERR|It doesn't exist");
                }
            }
        }
        void Login(string name, string password)
        {
            if (Program.users.Contains(name + ";" + password))
            {
                this.user = name;
                w.WriteLine("You have logged in");

            }
            else
                w.WriteLine("Incorrect name or password");
        }
        
    }
    internal class Program
    {
        static public List<string> users = new List<string>();
        static void Main(string[] args)
        {
            string ip = "127.0.0.1"; int port = 12345;
            IPAddress ipaddress = IPAddress.Parse(ip);
            
            StreamReader inp = new StreamReader("users.txt");
            while (!inp.EndOfStream)
            {
                users.Add(inp.ReadLine());
            }
            inp.Close();
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
