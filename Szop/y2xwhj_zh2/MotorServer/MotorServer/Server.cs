using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MotorServer
{
    internal class Server
    {
        StreamReader sReader;
        StreamWriter sWriter;
        string loggedUser = string.Empty;

        public Server(TcpClient c)
        {
            this.sReader = new StreamReader(c.GetStream(), Encoding.UTF8);
            this.sWriter = new StreamWriter(c.GetStream(), Encoding.UTF8);
        }

        public void StartKomm()
        {
            sWriter.WriteLine("Motor Project --- Type 'HILFE' for the available commands!");
            sWriter.Flush();
            bool ok = true;
            while (ok)
            {
                string parancs = string.Empty;
                try
                {
                    string commands = sReader.ReadLine();
                    string[] lineParts = commands.Split('|');
                    parancs = lineParts[0].ToUpper();
                    switch (parancs)
                    {
                        case "HILFE": Help(); break;
                        case "LISTA": GetMotorsList(); break;
                        case "LOGIN": Login(lineParts[1], lineParts[2]); break;
                        case "LOGOUT": Logout(); break;
                        case "KOLCSONZES": Rent(lineParts[1]); break;
                        case "VISSZAVISZ": Return(lineParts[1], int.Parse(lineParts[2])); break;
                        case "EXIT": sWriter.WriteLine("The client disconnected"); ok = false; break;
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
            sWriter.WriteLine("LOGOUT:To log out");
            sWriter.WriteLine("KOLCSONZES|<rendszam>: To rent a bike");
            sWriter.WriteLine("VISSZAVISZ|<rendszam>|<km>: To return a bike");
            sWriter.WriteLine("EXIT:To disconnect");
            sWriter.WriteLine("OK!");
        }

        void Login(string name, string password)
        {
            foreach (User user in Program.Users)
            {
                if (user.Name == name && user.Password == password)
                {
                    loggedUser = name;
                    sWriter.WriteLine("OK|You have logged in!");
                    break;
                }
            }
            if (loggedUser != name)
            {
                sWriter.WriteLine("ERR|Incorrect name or password.");
            }
        }

        void Logout()
        {
            if (loggedUser != String.Empty)
            {
                loggedUser = String.Empty;
                sWriter.WriteLine("OK|Logged out successfully.");
            }
            else
            {
                sWriter.WriteLine("ERR|You were not logged in.");
            }
        }

        void GetMotorsList()
        {
            sWriter.WriteLine("OK*");
            lock (Program.Motors)
            {
                foreach (Motor motor in Program.Motors)
                {
                    sWriter.WriteLine(motor.ToString());
                }
            }
            sWriter.WriteLine("OK!");
        }

        private void Rent(string regNum)
        {
            if (loggedUser != "")
            {
                lock (Program.Motors)
                {
                    bool isMotorFound = false;
                    bool isMotorFree = false;

                    foreach (Motor motor in Program.Motors)
                    {
                        if (motor.RegNum == regNum.ToUpper())
                        {
                            isMotorFound = true;
                            if (!motor.IsRented)
                            {
                                isMotorFree = true;
                                motor.IsRented = true;
                                sWriter.WriteLine($"OK|You rented this bike: {motor.ToString()}");
                            }                        
                        }
                    }
                    if (!isMotorFound)
                    {
                        sWriter.WriteLine($"ERR|We don't own this bike.");
                    }
                    if (isMotorFound && !isMotorFree)
                    {
                        sWriter.WriteLine($"ERR|This bike is currently not available.");
                    }
                }
            }
            else
            {
                sWriter.WriteLine("ERR|You are not logged in.");
            }
        }

        private void Return(string regNum, int newKms)
        {
            if (loggedUser != "")
            {
                lock (Program.Motors)
                {
                    bool isMotorFound = false;
                    bool isMotorFree = false;
                    bool isKmsRight = false;

                    foreach (Motor motor in Program.Motors)
                    {
                        if (motor.RegNum == regNum.ToUpper())
                        {
                            isMotorFound = true;
                            if (motor.IsRented)
                            {
                                isMotorFree = false;
                                if (motor.Kms <= newKms)
                                {
                                    isKmsRight = true;
                                    motor.IsRented = false;
                                    sWriter.WriteLine($"OK|The rent fee is: {(newKms - motor.Kms) * motor.Fee}");
                                }
                            }
                        }
                    }
                    if (!isMotorFound)
                    {
                        sWriter.WriteLine($"ERR|We don't own this bike.");
                    }
                    if (!isKmsRight)
                    {
                        sWriter.WriteLine($"ERR|Incorrect kms data.");
                    }
                    if (isMotorFound && isMotorFree)
                    {
                        sWriter.WriteLine($"ERR|This bike was not rented.");
                    }
                }
            }
            else
            {
                sWriter.WriteLine("ERR|You are not logged in.");
            }

        }



    }
}
