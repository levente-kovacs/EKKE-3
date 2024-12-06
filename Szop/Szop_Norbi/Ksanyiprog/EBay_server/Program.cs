using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EBay_server
{
    class Product
    {
        string name, code, user = null;
        int curr_price;
        public string User
        {
            get { return user; }
            set { user = value; }
        }
        public string Code
        {
            get { return code; }
            set { code = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Curr_price
        {
            get { return curr_price; }
            set { curr_price = value; }
        }
        public Product(string name, string code, int curr_price, string user)
        {
            this.name = name; this.code = code; this.curr_price = curr_price; this.user = user;
        }
   }
    class Protocol
    { 
        static List<Product> Products = new List<Product>();
        public StreamReader r;
        public StreamWriter w;
        public string user = null;

        public Protocol(TcpClient c)
        {
            this.r = new StreamReader(c.GetStream(), Encoding.UTF8);
            this.w = new StreamWriter(c.GetStream(), Encoding.UTF8);
        }

        public void StartKomm()
        {
            w.WriteLine("Auction 1.0 beta");
            w.Flush();
            bool ok = true;
            while (ok)
            {
                string command = null;
                try
                {
                    string message = r.ReadLine();// add|1212|1212|1212
                    string[] param = message.Split('|');
                    command = param[0].ToUpper();
                    switch (command)
                    {
                        case "LOGIN": Login(param[1], param[2]); break;
                        case "ADD": int price = int.Parse(param[3]); Add(param[1], param[2], price); break;
                        case "LIST": List(); break;
                        case "BID": int price2 = int.Parse(param[2]); Bid(param[1], price2); break;
                        case "BYE": w.WriteLine("BYE"); ok = false; break;
                        default: w.WriteLine("ERR|Unknown command"); break;
                    }
                }
                catch (Exception e)
                {
                    w.WriteLine("ERR|{0}", e.Message);
                }
                w.Flush();
            }
            Console.WriteLine("The client disconnected");
        }
        void Login(string name, string passw)
        { 
           //if (name=="" && passw="")
            user = name;
            w.WriteLine("OK");
        }
        void Add(string code, string name, int price)
        { 
          if (this.user == null)  //method can be called after login
          {
              w.WriteLine("ERR|Log in, please");
          }
          else
          {
              lock (Products)  // it is a shared resource
              { 
                 int i=0;
                 for (i = 0; i < Products.Count && Products[i].Code != code; i++) ; //an existing code???
                 if (i < Products.Count)  //if it exists
                 {
                     w.WriteLine("ERR|Already exists");
                 }
                 else
                 {
                     Product temp = new Product(name, code, price, this.user);
                     Products.Add(temp); //we add it to the list
                     w.WriteLine("OK");
                 }
              }
          }
        }
        void List()
        {
            w.WriteLine("OK*");
            lock (Products)
            {
                foreach (Product item in Products)
                    w.WriteLine(item.Code + ", " + item.Name + ", " + item.Curr_price + ", " + item.User);
            }
            w.WriteLine("OK!");
        }

        void Bid(string code, int price)
        { 
         if(user == null)
         {
              w.WriteLine("ERR|Log in, please!"); //only after login
         }
          else
          {
              lock (Products)
              {
                  int j = 0;
                  for (j=0;j<Products.Count && Products[j].Code!=code;j++);  //exisiting code?
                  if (j >= Products.Count) //no, unknown product
                  {
                      w.WriteLine("ERR|This code is not found");
                  }
                  else
                      if (Products[j].Curr_price < price)  //the offere price is larger then the curr?
                      {
                          Products[j].Curr_price = price;  //change it!
                          Products[j].User = user;
                          w.WriteLine("OK");
                      }
                      else
                          w.WriteLine("ERR|Low price");
              }
          }
         }
    }


    class Program
    {
        static void Main(string[] args)
        {
            IPAddress ip=IPAddress.Parse("127.0.0.1");
            TcpListener listener = new TcpListener(ip, 12345);
            listener.Start();
            bool ende = false;
            while (!ende)
            {
                Console.WriteLine("The server is waiting for an incoming connection...");
                TcpClient client = listener.AcceptTcpClient();
                Protocol pr = new Protocol(client);
                Thread th = new Thread(pr.StartKomm);
                th.Start();
            }
        }
    }
}
