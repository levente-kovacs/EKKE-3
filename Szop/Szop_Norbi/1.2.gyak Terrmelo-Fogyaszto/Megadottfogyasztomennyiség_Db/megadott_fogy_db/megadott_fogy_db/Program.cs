using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace megadott_fogy_db
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(140, 40);
            
                int kezd = 10000;
                int vege = 90000;
                //int oszto;
                //int db = 200;
               
            Termelo t1 = new Termelo(3, 200, kezd, vege);
            Termelo t2 = new Termelo(5, 100, kezd, vege);
            Termelo t3 = new Termelo(7, 200, kezd, vege);
            Thread termelo1 = new Thread(t1.Elkezd);
            Thread termelo2 = new Thread(t2.Elkezd);
            Thread termelo3 = new Thread(t3.Elkezd);
            termelo1.Start();
            termelo2.Start();
            termelo3.Start();
            

            Fogyaszto f1 = new Fogyaszto(ConsoleColor.Red);
            Thread fogyaszto = new Thread(f1.FogyasztoElkezd);
            fogyaszto.Start();
            Fogyaszto f2 = new Fogyaszto(ConsoleColor.Green);
            Thread fogyaszto2 = new Thread(f2.FogyasztoElkezd);
            fogyaszto2.Start();
            Fogyaszto f3 = new Fogyaszto(ConsoleColor.White);
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
