using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Server
{
    internal class Szerver
    {

        StreamReader sReader;
        StreamWriter sWriter;
        string loggedUser = string.Empty;

        public Szerver(TcpClient c)
        {
            this.sReader = new StreamReader(c.GetStream(), Encoding.UTF8);
            this.sWriter = new StreamWriter(c.GetStream(), Encoding.UTF8);
        }

        public void StartKomm()
        {
            sWriter.WriteLine("Exaple Project --- Type 'HELP' for available commands!");
            sWriter.Flush();
            bool ok = true;
            while (ok)
            {
                string parancs = string.Empty;
                try
                {
                    string commands = sReader.ReadLine();
                    string[] lineParts = commands.Split('|'); // <- SZEPARÁTORT ÁTÍRNI AZ ADATOK SZERINT !
                    parancs = lineParts[0].ToUpper();
                    switch (parancs)
                    {
                        case "HELP": Help(); break;
                        case "LOGIN": Login(lineParts[1], lineParts[2]); break;
                        case "LOGOUT": Logout(); break;
                        case "FELTOLT": Feltolt(lineParts[1]); break;
                        case "LEKERDEZ": Lekerdez(); break;
                        case "UTAL": Utal(lineParts[1], lineParts[2]); break;
                        case "UTALASOK": UtalasokListazasa(); break;
                        case "EXIT": sWriter.WriteLine("The cliend disconnected"); ok = false; break;
                        default: sWriter.WriteLine("ERR|Invalid command"); break;
                    }
                }
                catch (Exception e)
                {
                    sWriter.WriteLine("ERR|{0}", e.Message);
                }
                try
                {
                    sWriter.Flush();
                }
                catch
                {
                    ok = false;
                    sWriter.WriteLine("Client aborted.");
                }
            }
            Console.WriteLine("The client disconnected({0}) .", loggedUser);
        }

        void Help()
        {
            sWriter.WriteLine("OK*");
            sWriter.WriteLine("LOGIN|<name>|<pass>: To log in");
            sWriter.WriteLine("LOGOUT: To log out");
            sWriter.WriteLine("FELTOLT: Egyenleg feltolteshez");
            sWriter.WriteLine("LEKERDEZ: Egyenleg lekérdezése");
            sWriter.WriteLine("UTAL: Utalás");
            sWriter.WriteLine("UTALASOK: Utalások listája");
            sWriter.WriteLine("EXIT: To disconnect");
            sWriter.WriteLine("OK!");
        }

        void Login(string name, string password)
        {
            foreach (User user in Program.Users)
            {
                if (user.Name == name && user.Password == password)
                {
                    loggedUser = name;                    
                    sWriter.WriteLine("OK|You have logged in");
                    //Program.ActiveUsers.Add(login_user);
                    break;
                }
            }
            if (loggedUser != name)
            {
                sWriter.WriteLine("ERR|Incorrect name or password");
            }
        }

        void Logout()
        {
            if (loggedUser != String.Empty)
            {
                loggedUser = String.Empty;
                sWriter.WriteLine("OK.");
                //Program.ActiveUsers.Remove(login_user);
            }
            else
            {
                sWriter.WriteLine("ERR|Nem is volt login.");
            }
        }

        private void UtalasokListazasa()
        {
            if (Program.Utalasok.Count > 0)
            {
                sWriter.WriteLine("OK*");
                Program.Utalasok.ForEach(x => sWriter.WriteLine($"{x.Kitol} utalt {x.Mennyit} Ft-ot {x.Kinek} felhasználónak."));
                sWriter.WriteLine("OK!");
            }
            else
            {
                sWriter.WriteLine($"ERR|Nem történt még utalás.");
            }
        }

        private int Lekerdez()
        {
            if (loggedUser != "")
            {
                foreach (User user in Program.Users)
                {
                    if (user.Name == loggedUser)
                    {
                        sWriter.WriteLine($"OK|EGYENLEG: {user.Egyenleg}");
                        return user.Egyenleg;
                    }
                }
            }
            else
            {
                sWriter.WriteLine("ERR|Nobody logged in");
            }
            return -1;
        }

        private void Feltolt(string osszeg)
        {
            if (loggedUser != "")
            {
                foreach (User user in Program.Users)
                {
                    if (user.Name == loggedUser)
                    {
                        user.Egyenleg += int.Parse(osszeg);
                        sWriter.WriteLine($"OK|EGYENLEG FELTÖLTVE. ÚJ EGYENLEG: {user.Egyenleg}");                        
                        break;
                    }
                }
            }
            else
            {
                sWriter.WriteLine("ERR|Nobody logged in");
            }

        }

        private void Utal(string celUserName, string osszeg)
        {
            if (loggedUser != "")
            {
                if (Lekerdez() == -1)
                {
                    sWriter.WriteLine($"ERR|Hiba az egyenleged lekérdezése közben.");
                }
                else
                {
                    User celUserObj = new User("", "");
                    foreach (User user in Program.Users)
                    {
                        if (user.Name == celUserName)
                        {
                            celUserObj = user;
                        }
                    }

                    foreach (User user in Program.Users)
                    {
                        if (celUserObj.Name != "")
                        {
                            if (loggedUser == user.Name)
                            {
                                celUserObj.Egyenleg += int.Parse(osszeg);
                                user.Egyenleg -= int.Parse(celUserName);
                                sWriter.WriteLine($"OK|Az utalás megtörtént.");
                            }                            
                        }
                    }
                }
            }
            else
            {
                sWriter.WriteLine("ERR|Nobody logged in");
            }
        }


        //void Userlist()
        //{
        //    if (this.login_user != "admin")
        //    {
        //        output.WriteLine("ERR|Please log in as Amin");
        //    }
        //    else
        //    {
        //        output.WriteLine("OK*");
        //        output.WriteLine("User".PadLeft(30) + "Password".PadLeft(15));
        //        lock (Program.Users)
        //        {
        //            foreach (User user in Program.Users)
        //            {
        //                output.WriteLine(user.Name.PadLeft(30) + user.Password.PadLeft(15));
        //            }
        //        }
        //        output.WriteLine("OK!");
        //    }
        //}

        //void Onlineuserlist()
        //{
        //    output.WriteLine("OK*");
        //    output.WriteLine("Aktív users:".PadLeft(30));
        //    lock (Program.ActiveUsers)
        //    {
        //        foreach (String name in Program.ActiveUsers)
        //        {
        //            output.WriteLine(name.PadLeft(30));
        //        }
        //    }
        //    output.WriteLine("OK!");
        //}

        //void rental(string id)
        //{
        //    if (login_user != String.Empty)
        //    {
        //        lock (Program.Films)
        //        {
        //            int j = 0;
        //            for (j = 0; j < Program.Films.Count && Program.Films[j].Id != id; j++) ;
        //            if (j >= Program.Films.Count)
        //            {
        //                output.WriteLine("ERR|Missing DVD");
        //            }
        //            else
        //                if (Program.Films[j].User == String.Empty)
        //            {
        //                Program.Films[j].User = login_user;
        //                Program.Films[j].Rented = true;
        //                output.WriteLine("OK|Rented");
        //            }
        //            else
        //            {
        //                output.WriteLine("ERR|This film has been rented");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        output.WriteLine("ERR|Log in to rent!");
        //    }

        //}

        //void Back(string id)
        //{
        //    if (login_user != String.Empty)
        //    {
        //        lock (Program.Films)
        //        {
        //            int j = 0;
        //            for (j = 0; j < Program.Films.Count && Program.Films[j].Id != id; j++) ;
        //            if (j >= Program.Films.Count)
        //            {
        //                output.WriteLine("ERR|Missing DVD");
        //            }
        //            else
        //                if (Program.Films[j].User == login_user)
        //            {
        //                Program.Films[j].User = String.Empty;
        //                Program.Films[j].Rented = false;
        //                output.WriteLine("OK|Back is okay");
        //            }
        //            else
        //            {
        //                output.WriteLine("ERR|Rented by other user!");
        //            }
        //        }
        //    }
        //    else
        //    {
        //        output.WriteLine("ERR|Log in for taking back");
        //    }
        //}

        //void Adduser(string name, string password)
        //{
        //    if (this.login_user != "admin")
        //    {
        //        output.WriteLine("ERR|Log in as admin");
        //    }
        //    else
        //    {
        //        Boolean missing = true;
        //        lock (Program.Users)
        //        {
        //            foreach (User user in Program.Users)
        //            {
        //                if (user.name == name)
        //                {
        //                    output.WriteLine("ERR|Existing user");
        //                    missing = false;
        //                    break;
        //                }
        //            }
        //            if (missing)
        //            {
        //                User newUser = new User(name, password);
        //                Program.Users.Add(newUser);
        //                output.WriteLine("OK|Saved data");
        //            }
        //        }
        //    }
        //}

        //void Userdel(string name)
        //{
        //    if (this.login_user != "admin")
        //    {
        //        output.WriteLine("ERR|Log in as admin");
        //    }
        //    else
        //    {
        //        bool missing = true;
        //        lock (Program.Users)
        //        {
        //            foreach (User user in Program.Users)
        //            {
        //                if (user.name == name)
        //                {
        //                    Program.Users.Remove(user);
        //                    output.WriteLine("OK|The user has been deleted.");
        //                    missing = false;
        //                    break;
        //                }
        //            }
        //            if (missing)
        //            {
        //                output.WriteLine("ERR|Existing user");
        //            }
        //        }
        //    }
        //}
        //void Lista()
        //{
        //    output.WriteLine("OK*");
        //    output.WriteLine("ID".PadRight(12) + "Film title: ".PadRight(15) + "Film rented: ");
        //    foreach (DVD_film film in Program.Films)
        //        output.WriteLine(film.Id.PadRight(12) + film.Title.PadRight(15) + film.Rented);
        //    output.WriteLine("OK!");
        //}

    }
}
