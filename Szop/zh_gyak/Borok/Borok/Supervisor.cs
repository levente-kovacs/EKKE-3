using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Borok
{
    internal class Supervisor
    {
        public static int whiteBarrelCapacity = 8;
        public static BlockingCollection<int> whiteBarrel = new BlockingCollection<int>(whiteBarrelCapacity);
        public static int redBarrelCapacity = 10;
        public static BlockingCollection<int> redBarrel = new BlockingCollection<int>(redBarrelCapacity);

        public static void Berak(string vineType)
        {
            switch (vineType)
            {
                case "feher":
                    while (whiteBarrel.Count >= whiteBarrelCapacity)
                    {
                        whiteBarrel.Add(1);
                    }
                    whiteBarrel.CompleteAdding();
                    break;
                case "piros":
                    while (redBarrel.Count >= redBarrelCapacity)
                    {
                        redBarrel.Add(1);
                    }
                    redBarrel.CompleteAdding();
                    break;
            }
        }

        public static void Kivesz(string vineType, ConsoleColor colour)
        {
            switch (vineType)
            {
                case "feher":
                    //while (!whiteBarrel.IsCompleted)
                    //{
                        whiteBarrel.Take();
                    //}
                    break;
                case "piros":
                    //while (!redBarrel.IsCompleted)
                    //{
                        redBarrel.Take();
                    //}
                    break;
            }
        }

            //    switch (vineType)
            //    {
            //        case "feher":
            //            while (!whiteBarrel.IsCompleted)
            //            {
            //                Console.WriteLine("Supervisor kivesz feher while");
            //                whiteBarrel.Take();
            //                lock (typeof(Program))
            //                {
            //                    Console.ForegroundColor = colour;
            //                    Console.WriteLine($"1 liter {vineType} bort kivettünk a hordójából.");
            //                }
            //            }
            //            break;
            //        case "piros":
            //            while (!redBarrel.IsCompleted)
            //            {
            //                Console.WriteLine("Supervisor kivesz piros while");
            //                redBarrel.Take();
            //                lock (typeof(Program))
            //                {
            //                    Console.ForegroundColor = colour;
            //                    Console.WriteLine($"1 liter {vineType} bort kivettünk a hordójából.");
            //                }
            //            }
            //            break;
            //    }
            //}



            //static int pirosHordoMeret = 10;
            //static BlockingCollection<int> piros = new BlockingCollection<int>(pirosHordoMeret);
            //static int feherHordoMeret = 8;
            //static BlockingCollection<int> feher = new BlockingCollection<int>(feherHordoMeret);

            //public static void Berak(string borTipus)
            //{
            //    switch (borTipus)
            //    {
            //        case "feher":
            //            while (feher.Count >= feherHordoMeret)
            //            {
            //                feher.Add(1);
            //            }
            //            feher.CompleteAdding();
            //            break;
            //        case "piros":
            //            while (piros.Count >= pirosHordoMeret)
            //            {
            //                piros.Add(1);
            //            }
            //            piros.CompleteAdding();
            //            break;
            //    }
            //}
            //public static void Kivesz(string borTipus, ConsoleColor colour)
            //{
            //    switch (borTipus)
            //    {
            //        case "feher":
            //            while (!feher.IsCompleted)
            //            {
            //                feher.Take();
            //                lock (typeof(Program))
            //                {
            //                    Console.ForegroundColor = colour;
            //                    Console.WriteLine($"1 liter {borTipus} bort kivettünk a hordójából.");
            //                }
            //            }
            //            break;
            //        case "piros":
            //            while (!piros.IsCompleted)
            //            {
            //                piros.Take();
            //                lock (typeof(Program))
            //                {
            //                    Console.ForegroundColor = colour;
            //                    Console.WriteLine($"1 liter {borTipus} bort kivettünk a hordójából.");
            //                }
            //            }
            //            break;
            //    }
            //}
    }
}
