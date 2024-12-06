using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gyakorlas_4feladat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 40);
            for (int i = 0; i < 3; i++)
            {
                int kezd = 10000;
                int vege = 90000;
                int oszto;
                int db = 200;
                switch (i)
                {
                    case 1:oszto = 5;
                        db = 100;
                        break;
                    case 2:oszto = 7;
                        break;
                    default:oszto = 3;
                        break;                        
                }                
                Termelo t = new Termelo(oszto, db,kezd,vege);
                Thread termelo = new Thread(t.Elkezd);
                termelo.Start();
                }

            //for (int i = 0; i < 3; i++)
            //{
            //    ConsoleColor szin = ConsoleColor.Gray;
            //    switch (i)
            //    {
            //        case 1:
            //            szin = ConsoleColor.Red;
            //            break;
            //        case 2:
            //            szin = ConsoleColor.Green;
            //            break;
            //        default:
            //            szin = ConsoleColor.White;
            //            break;
            //    }
            //    Fogyaszto f = new Fogyaszto(szin,i+1);
            //    Thread fogyaszto = new Thread(f.FogyasztoElkezd);
            //    fogyaszto.Start();
            //    Console.WriteLine($"Fogyasztó elfogyasztott: {f.Megtalaltdb}"); 
            //    
            //}
           Fogyaszto f1 = new Fogyaszto(ConsoleColor.Red,1);
           Thread fogyaszto = new Thread(f1.FogyasztoElkezd);
           fogyaszto.Start();
           Fogyaszto f2 = new Fogyaszto(ConsoleColor.Green,2);
           Thread fogyaszto2 = new Thread(f2.FogyasztoElkezd);
           fogyaszto2.Start();
           Fogyaszto f3 = new Fogyaszto(ConsoleColor.White,3);
           Thread fogyaszto3 = new Thread(f3.FogyasztoElkezd);
           fogyaszto3.Start();
           
           fogyaszto.Join();
           fogyaszto2.Join();
           fogyaszto3.Join();
           Console.WriteLine($"1. fogyasztó kivett: {f1.Megtalaltdb}");
           Console.WriteLine($"2. fogyasztó kivett: {f2.Megtalaltdb}");
           Console.WriteLine($"3. fogyasztó kivett: {f3.Megtalaltdb}");

            Console.ReadLine();
        }
    }
}
