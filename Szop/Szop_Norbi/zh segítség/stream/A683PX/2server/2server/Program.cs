using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Socket1
{
    
    class Program
    {
        static string ipadd = "127.0.0.1";
        static int port = 50000;
        static IPAddress ip = null;
        static TcpListener figyelo = null;
        static Thread kapcsolatok = null;
        public static List<Thread> futo_szalak = new List<Thread>();
        static void Comm()
        {
            while (true)
            {
                TcpClient client = figyelo.AcceptTcpClient();
                KliensKomm cl = new KliensKomm(client);
                Thread t = new Thread(cl.CommStart);
                lock (futo_szalak) // tároljuk el a szálakat
                {
                    futo_szalak.Add(t); // ha csak a szálat tároljuk
                    //futo_szalak.Add(new Tuple<KliensKomm,Thread>(k,t)); // klienskomm is tárolva
                }
                t.Start();
            }
        }
        static void Main(string[] args)
        {
            ip = IPAddress.Parse(ipadd);
            figyelo = new TcpListener(ip, port);
            figyelo.Start();
            kapcsolatok =new Thread(Comm);
            kapcsolatok.Start();
            Console.ReadLine();
            figyelo.Stop();
            kapcsolatok.Abort();
        }
    }
    class User
    {
        private string name;
        private string password;
        public User(string name, string pw)
        {
            this.name = name;
            this.password = pw;
        }

        public string Name
        {
            get { return this.name; }
        }
        public string Password
        {
            get { return this.password; }
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is User))
                return false;
            User other = obj as User;
            return this.Name == other.Name && this.Password == other.Password;
        }
    }

    class Motor
    {
        private string rendszam;
        private string tipus;
        private int dij;
        private int km;
        private bool kolcsonozve;
        public Motor(string rendszam, string tipus, int dij, int km,string user)
        {
            this.rendszam = rendszam;
            this.tipus = tipus;
            this.dij = dij;
            this.km = km;
            this.kolcsonozve = false;
        }

        public bool Kolcsonozve
        {
            get { return this.kolcsonozve; }
            set { this.kolcsonozve = value; }
        }

        public string Rendszam
        {
            get { return this.rendszam; }
        }

        public string Tipus
        {
            get { return this.tipus; }
        }
        public int Dij
        {
            get { return this.dij; }
        }
        public int Km
        {
            get { return this.km; }
            set { this.km = value; }
        }

    }

    class KliensKomm
    {
        StreamReader r = null;
        StreamWriter w = null;        
        public string user = null;
        public KliensKomm(TcpClient client)
        {
            r = new StreamReader(client.GetStream(), Encoding.UTF8);
            w = new StreamWriter(client.GetStream(), Encoding.UTF8);
        }

        static List<Motor> motors = new List<Motor>(){
            new Motor("123","A1", , 1234, "felhasznalo"),
            new Motor("324-ASD","A3", "Audi", 234332,"felhasznalo"),
            new Motor("435-ASD","A6", "Audi", 324543,"felhasznalo"),
            new Motor("654-ASD","A7", "Audi", 43532,"felhasznalo"),
            new Motor("578-ADS","A8", "Audi", 12432, "felhasznalo"),
            new Motor("576-ASD","A7", "Audi", 543543, "felhasznalo"),
        };

        static List<User> users = new List<User>()
        {
            new User("admin", "admin"),
            new User("teszt2", "T3st123"),
            new User("teszt3", "T3st123"),
            new User("teszt4", "T3st123"),
        };


        public void CommStart()
        {
            bool torlesKell = true;
            w.WriteLine("Auto Server v1.1");
            w.Flush();
            bool end = false;
            try
            {
                while (!end)
                {
                    /*ReaderFromStream rs = new ReaderFromStream(); StreamWriter helyett
                    string feladat = rs.ReadLine(olvaso, 9000); HA KÜLÖN KELL VÁLASZTANI*/
                    string command;
                    try
                    {
                        command = r.ReadLine();
                    }
                    catch
                    {
                        break;
                    }

                    string[] temp = command.Split('|');
                    switch (temp[0])
                    {
                        case "LIST": List(); break;
                        case "LOGIN": try { Login(temp[1], temp[2]); } catch { w.WriteLine("Kérem adja meg a felhasználónevet és a jelszót is!"); } break;
                        case "LOGOUT": Logout(); break;
                        case "KOLCSONZES": Kolcsonzes(temp[1]); break;
                        case "VISSZAVISZ": try { Visszavisz(temp[1], int.Parse(temp[2])); } catch (FormatException) { w.WriteLine("Hibás adat"); } catch { w.WriteLine("Kevés adat"); } break;
                        case "ADD": try { Add(temp[1], temp[2], temp[3], int.Parse(temp[4])); } catch (FormatException) { w.WriteLine("Hibás adat"); } catch { w.WriteLine("Kevés adat"); } break;
                        case "EXIT": end = true; w.WriteLine("Exit"); break;
                        default: w.WriteLine("ERR|Unknown command"); break;
                    }
                    w.Flush();
                }
            }
            catch (Exception e)
            {
                if (e is ThreadAbortException)
                    torlesKell = false;
            }
            if (torlesKell)
            {
                Console.WriteLine("Kapcsolat törölve!");
                lock (Socket1.Program.futo_szalak)
                {
                    Thread ez = Thread.CurrentThread;
                    int i = Socket1.Program.futo_szalak.IndexOf(ez); // megkeresem a processzt a futó szálak listájában.
                    if (i != -1)
                        Socket1.Program.futo_szalak.RemoveAt(i); //namespace.Program.lista neve
                }
            }

        }
        void List()
        {
            w.WriteLine("OK*"); // figyelni, hogy milyen jelölő kell
            lock (motors)
            {
                foreach (Motor temp in motors)
                    w.WriteLine("Rendszam: {0}, Marka: {1}, Tipus: {2}, Km: {3}, Kolcsonozve: {4}",
                        temp.Rendszam, temp.Dij, temp.Tipus, temp.Km, temp.Kolcsonozve ? "Igen" : "Nem");
            }
            w.WriteLine("OK!"); // figyelni, hogy milyen jelölő kell
        }

        void Login(string username, string password)
        {
            User newUser = new User(username, password);
            if (user != null)
            {
                w.WriteLine("Ön már be van jelentkezve");
            }
            else
            {
                lock (users)
                {
                    if (users.Contains(newUser))
                    {
                        w.WriteLine("Sikeres bejelentkezés");
                        user = username;

                    }
                    else
                    {
                        w.WriteLine("Rossz felhasználónév vagy jelszó!");
                    }
                }
            }

        }

        void Logout()
        {
            if (user == null)
                w.WriteLine("Nincs bejelentkezve");
            user = null;
            w.WriteLine("Sikeres kilépés!");
        }

        void Kolcsonzes(string rendszam)
        {
            if (user == null)
                w.WriteLine("ERR|Kérem lépjen be");
            else
            {
                lock (motors)
                {
                    foreach (Motor temp in motors)
                    {
                        if (temp.Rendszam == rendszam)
                        {
                            if (!temp.Kolcsonozve)
                            {
                                w.WriteLine("OK");
                                temp.Kolcsonozve = true;
                                break;
                            }
                            else
                            {
                                w.WriteLine("Már ki van kölcsönözve");
                                break;
                            }
                        }
                        else w.WriteLine("Nincs ilyen rendszámú autó!");
                    }
                }
            }
        }
        void Visszavisz(string rendszam, int km)
        {
            if (user == null)
                w.WriteLine("ERR|Log in, please");
            else
            {
                lock (motors)
                {

                    foreach (Motor temp in motors)
                    {
                        if (temp.Rendszam == rendszam)
                        {
                            if (temp.Kolcsonozve)
                            {                                
                                if (km > temp.Km)
                                {
                                    temp.Km = km;
                                    temp.Kolcsonozve = false;
                                    w.WriteLine("Auto visszaadva");
                                }
                                else w.WriteLine("A visszaadott auto km-e nem lehet kisebb, mint a korábbi.");
                            }
                            else
                            {
                                w.WriteLine("Ezzel a rendszámmal nincs kikölcsönzött autó");
                            }

                        }
                    }
                }
            }
        }
        void Add(string rendszam, string tipus, string marka, int km)
        {
            if (this.user == null)  
            {
                w.WriteLine("ERR|Kérem jelentkezzen be");
            }
            else
            {
                lock (motors)  // it is a shared resource
                {
                    int i = 0;
                    for (i = 0; i < motors.Count && motors[i].Rendszam != rendszam; i++) ; //an existing code???
                    if (i < motors.Count)  //if it exists
                    {
                        w.WriteLine("ERR|Already exists");
                    }
                    else
                    {
                        Motor temp = new Motor(rendszam, tipus, marka,km,this.user);
                        motors.Add(temp); //we add it to the list
                        w.WriteLine("Rögzítés sikerült");
                    }
                }
            }
        }
    }

    /*class ReaderFromStream
    {
        protected StreamReader r;
        protected string line = null;
        protected void DoRead()
        {
            line = r.ReadLine();
        }
        public string ReadLine(StreamReader r, int timeoutMSec)
        {
            this.r = r;
            this.line = null;
            Thread t = new Thread(DoRead);
            t.Start();
            if (t.Join(timeoutMSec) == false)
            {
                t.Abort();
                return null;
            }
            return line;
        }
    }*/
                }

