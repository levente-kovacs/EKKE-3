using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
Írjunk egy programot, amely két metódust felhasználva megszámolja, hogy melyik egy 10000 elemű listában a legnagyobb és
a legkisebb elem, és ezek hányszor fordulnak elő!
*/
namespace egyszeru3esfel
{
    class Program
    {
        static int[] arr = new int[10];
        static int min;
        static int max;
        static int minDb;
        static int maxDb;

        static void Feltolt()
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(0,10);
            }
        }

        static void Min()
        {
            min = arr.Min();
            minDb = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                lock (arr)
                {
                    if (min == arr[i]) minDb++;
                }
            }
        }

        static void Max()
        {
            max = arr.Max();
            maxDb = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                lock (arr)
                {
                    if (max == arr[i]) maxDb++;
                }
            }
        }

        static void Main(string[] args)
        {
            Feltolt();
            Thread t1 = new Thread(Min);
            Thread t2 = new Thread(Max);
            t1.Start();
            t2.Start();
            t1.Join();
            t2.Join();
            Console.WriteLine($"Min: {min}, MinDb: {minDb}, Max: {max}, MaxDb: {maxDb}");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.ReadLine();

        }
    }
}
