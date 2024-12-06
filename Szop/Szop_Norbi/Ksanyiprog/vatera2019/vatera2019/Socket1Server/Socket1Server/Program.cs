using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket1Server
{
    class Product
    {
        string _code;

        public String Code
        {
            get { return _code; }
            set { _code = value; }
        }
        
        string _name;
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        int _curr_price;
        public int Curr_price
        {
            get { return _curr_price;}
            set { _curr_price = value; }
        }

        string _user;
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public Product(string code, string name, int curr_price, string user)
        {
            Code = code;
            Name = name;
            Curr_price = curr_price;
            User = user;
        }
    }
    class ClientComm
    {
        StreamWriter w=null;
        StreamReader r=null;
        TcpClient cl;
        static List<Product> p_list = new List<Product>();
        string User_name = null;

        public ClientComm(TcpClient client)
        {
            cl = client;
            w = new StreamWriter(cl.GetStream(), Encoding.UTF8);
            r = new StreamReader(cl.GetStream(), Encoding.UTF8);
        }

        public void Start()
        {
            
            w.WriteLine("Luke, Ich bin Vatera server");
            w.Flush();
            string command = r.ReadLine();
            try
            {
                while (command != "BYE")
                {
                    string[] line = command.Split('|');
                    switch (line[0].ToUpper())
                    {
                        case "LOGIN": Login(line[1], line[2]); break;
                        case "ADD": Add(line[1], line[2], int.Parse(line[3])); break;
                        case "LICIT": Licit(line[1], int.Parse(line[2])); break;
                        case "LIST": List(); break;
                        case "BYE": w.WriteLine("BYE"); break;
                        default: w.WriteLine("ERR|Nincs ilyen művelet"); break;
                    }
                    w.Flush();
                    command = r.ReadLine();
                }
            }
            catch (Exception e) {
                w.WriteLine("Kpacsolat bontva!"); w.Flush();
                if (e is ThreadAbortException)
                    Console.WriteLine("Ez van! {0}", e.Message);
                Console.WriteLine("Mocsok kliens bontott! {0}", e.Message);
            }

        }

        void Licit(string code, int price)
        {
            if (User_name == null)
                w.WriteLine("OK|Jelentkezz be!!!");
            else
            {
                int i = 0;
                lock (p_list)
                {
                    for (i = 0; i < p_list.Count && code != p_list[i].Code; i++) ;
                    if (i < p_list.Count)
                    {
                        if (p_list[i].Curr_price >= price)
                        {
                            w.WriteLine("OK|Magasabb árat kell megadni");
                        }
                        else
                        {
                            p_list[i].Curr_price = price;
                            p_list[i].User = User_name;
                            w.WriteLine("OK|Sikeres licit");
                        }
                       
                    }
                    else
                        w.WriteLine("OK|Nincs ilyen!");
                }
            }
        
        }
        void List()
        {
            lock (p_list)
            {
                w.WriteLine("OK*");
                foreach (Product item in p_list)
                    w.WriteLine(item.Code + " " + item.Name + " " + item.Curr_price + " " + item.User);
                w.WriteLine("OK!");
            }
        }
        void Login(string name, string passwd)
        {
           // if (name == "Zorro" && passwd == "Zorro")
            //{
                w.WriteLine("OK|Sikeres bejelentkezés");
                User_name = name;
            //}
            //else
                //w.WriteLine("Hibás próbálkozás");
        }
        void Add(string code, string name, int price)
        {
            if (User_name == null)
                w.WriteLine("OK|Jelentkezz be!!!");
            else
            {
                int i = 0;
                lock (p_list)
                {
                    for (i = 0; i < p_list.Count && code != p_list[i].Code; i++) ;
                    if (i == p_list.Count)
                    {
                        p_list.Add(new Product(code, name, price, User_name));
                        Console.WriteLine(User_name);
                        w.WriteLine("OK|Sikeres felvitel!");
                    }
                    else
                        w.WriteLine("OK|Már van ilyen!");
                }
            }
        }

      
    }

    class Program
    {
        static String IpAddre = "127.0.0.1";
        static int port = 12345;
        static List<Thread> running_threads = new List<Thread>();
        static TcpListener listener = null;

        static void Indit()
        {

            try
            {
                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    ClientComm cl = new ClientComm(client);
                    Thread t = new Thread(cl.Start);
                    t.Start();
                    running_threads.Add(t);
                    Console.WriteLine("Új kapcsolat!");
                }
            }
            catch (Exception e) { Console.WriteLine("Élő kliens"); }
           
        
        }
        static void Main(string[] args)
        {
            IPAddress ip = IPAddress.Parse(IpAddre);
            listener = new TcpListener(ip, port);
            listener.Start();
            Thread t = new Thread(Indit);
            t.Start();
            Console.WriteLine("A szerver elindult!");
            Console.ReadLine();
            foreach (Thread t1 in running_threads)
            {
                t1.Abort();
            }
            listener.Stop();
            t.Abort();
            Console.WriteLine("Vége(m) van?");
        }
    }
}
