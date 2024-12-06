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

namespace AK9AVF_2feladat
{
    class Program
    {
        static string ipcim = ConfigurationManager.AppSettings["Ip-cim"];
        static int port = int.Parse(ConfigurationSettings.AppSettings["Port"]);
        static IPAddress ip = null;
        static TcpListener figyelo = null;
        static Thread kapcsolatok = null;
        public static List<Thread> futo_szalak = new List<Thread>();
        static void Komm()
        {
            while (true)
            {
                TcpClient client = figyelo.AcceptTcpClient();
                KliensKomm cl = new KliensKomm(client);
                Thread t = new Thread(cl.CommStart);
                lock (futo_szalak) 
                {
                    futo_szalak.Add(t);                    
                }
                t.Start();
            }
        }
        static void Main(string[] args)
        {
            ip = IPAddress.Parse(ipcim);
            figyelo = new TcpListener(ip, port);
            figyelo.Start();
            kapcsolatok = new Thread(Komm);
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
        public Motor(string rendszam, string tipus, int km, int dij)
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
            new Motor("123-UBD","Yamaha Fazer",250,15),
            new Motor("345-FKJ","Ducati Panigale", 300, 12),
            new Motor("672-UJL","BMW R 1250 RS", 4000, 25),
        };

        static List<User> users = new List<User>()
        {
            new User("admin", "admin"),
        };


        public void CommStart()
        {
            bool torlesKell = true;
            w.WriteLine("Motorok kölcsönzése");
            w.Flush();
            bool end = false;
            try
            {
                while (!end)
                {
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
                        case "HELP": Help();break;
                        case "LISTA": Lista(); break;
                        case "LOGIN": try { Login(temp[1], temp[2]); } catch { w.WriteLine("Kérem adja meg a felhasználónevet és a jelszót is!"); } break;
                        case "LOGOUT": Logout(); break;
                        case "KOLCSONZES": Kolcsonzes(temp[1]); break;
                        case "VISSZAVISZ": try { Visszavisz(temp[1], int.Parse(temp[2])); } catch (FormatException) { w.WriteLine("Hibás adat"); } catch { w.WriteLine("Kevés adat"); } break;                        
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
                lock (AK9AVF_2feladat.Program.futo_szalak)
                {
                    Thread ez = Thread.CurrentThread;
                    int i = AK9AVF_2feladat.Program.futo_szalak.IndexOf(ez);
                    if (i != -1)
                        AK9AVF_2feladat.Program.futo_szalak.RemoveAt(i);
                }
            }

        }
        void Help()
        {
            w.WriteLine("OK*");
            w.WriteLine("LOGIN -> LOGIN|felhasznalonev|jelszo  -> Belépés a rendszerbe.");
            w.WriteLine("LOGOUT -> Kilépés a rendszerből.");
            w.WriteLine("LISTA -> Kilistázza a motorokat.");
            w.WriteLine("KOLCSONZES-> KOLCSONZES|rendszám -> Kikölcsönzi a motort.");
            w.WriteLine("VISSZAVISZ-> VISSZAVISZ|rendszám|km -> A kivánt motort vissza visszük.");
            w.WriteLine("OK!");
        }
        void Lista()
        {
            w.WriteLine("OK*");
            lock (motors)
            {
                foreach (Motor temp in motors)
                    w.WriteLine("Rendszam: {0}, Tipus: {2}, Km: {3}, Kölcsönzési díj/km: {4}",
                        temp.Rendszam, temp.Tipus, temp.Km, temp.Dij);
            }
            w.WriteLine("OK!");
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
                        else w.WriteLine("Nincs ilyen rendszámú motor!");
                    }
                }
            }
        }
        void Visszavisz(string rendszam, int km)
        {
            if (user == null)
                w.WriteLine("ERR|Lépjen be");
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
                                    w.WriteLine("Motor visszaadva");
                                }
                                else w.WriteLine("A visszaadott motor km-e nem lehet kisebb, mint a korábbi.");
                            }
                            else
                            {
                                w.WriteLine("Ezzel a rendszámmal nincs kikölcsönzött motor");
                            }

                        }
                    }
                }
            }
        }        
    }
}


