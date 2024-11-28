using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Maxmin
{
    //https://aries.ektf.hu/~ksanyi/SOP/exs.txt
    //Write a program that lunches two threads 
    //for calculating the highest and the 
    //lowest items of an array of size 100000 and 
    //their position in the array. How often they occure.

    class Program
    {
        static int[] array=new int[100000000];
        static int max = int.MinValue;
        static int min=int.MaxValue;
        static int numberOfMax = 0;
        static int numberOfMin = 0;


        static void Max2(Object obj)
        {
            CountdownEvent ev = (CountdownEvent)obj;
            for (int i = 0; i < array.Length; i++)
                if (array[i] > max)
                {
                    max = array[i];
                    numberOfMax = 1;
                }
                else if (array[i] == max)
                {
                    numberOfMax++;
                }
            ev.Signal();
        }

        static void Max()
        {
           for (int i=0;i<array.Length;i++)
               if (array[i] > max)
               {
                   max = array[i];
                   numberOfMax = 1;
               }
                else if (array[i]==max)
                {
                    numberOfMax++;
                }
        }
        static void MaxMin1()
        {
            
            for (int i = 0; i < array.Length / 2; i++)
            {
                lock (array)
                {
                    if (array[i] > max)
                    {
                        max = array[i];
                        numberOfMax = 1;
                    }
                    else if (array[i] == max)
                    {
                        numberOfMax++;
                    }
                    else if (array[i] < min)
                    {
                        min = array[i];
                        numberOfMin = 1;
                    }
                    else if (array[i] == min)
                    {
                        numberOfMin++;
                        
                    }
                }
            }
        }
        static void Min2(Object obj)
        {
            CountdownEvent ev = (CountdownEvent)obj;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    numberOfMin = 1;
                }
                else if (array[i] == min)
                {
                    numberOfMin++;
                }
            }
            ev.Signal();
        }
        static void Min()
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < min)
                {
                    min = array[i];
                    numberOfMin = 1;
                }
                else if (array[i] == min)
                {
                    numberOfMin++;
                }
            }
        }
        static void MaxMin2()
        {
            for (int i = array.Length/2; i < array.Length; i++)
            {
                lock (array)
                {
                    if (array[i] < min)
                    {
                        min = array[i];
                        numberOfMin = 1;
                    }
                    else if (array[i] == min)
                    {
                        numberOfMin++;
                    }
                    if (array[i] > max)
                    {
                        max = array[i];
                        numberOfMax = 1;
                    }
                    else if (array[i] == max)
                    {
                        numberOfMax++;
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Random rn = new Random();
            for (int i = 0; i < array.Length; i++)
                array[i] = rn.Next(1, 1000);

            //First solution
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Max();
            Min();
            Console.WriteLine("Maximum: {0}, occurs {1}", max, numberOfMax);
            Console.WriteLine("Minimum: {0}, occurs {1}", min, numberOfMin);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            max = int.MinValue;
            min = int.MaxValue;
            numberOfMax = 0;
            numberOfMin = 0;
            sw.Reset();
            sw.Start();

            Thread t1 = new Thread(Max);
            Thread t2 = new Thread(Min);
            t1.Start();
            t2.Start();
            t1.Join(); t2.Join();
            Console.WriteLine("Maximum: {0}, occurs {1}", max, numberOfMax);
            Console.WriteLine("Minimum: {0}, occurs {1}", min, numberOfMin);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);
            max = int.MinValue;
            min = int.MaxValue;
            numberOfMax = 0;
            numberOfMin = 0;
            sw.Reset();
            sw.Start();
            Thread t3 = new Thread(MaxMin1);
            Thread t4 = new Thread(MaxMin2);
            t3.Start();
            t4.Start();
            t3.Join(); t4.Join();
            Console.WriteLine("Maximum: {0}, occurs {1}", max, numberOfMax);
            Console.WriteLine("Minimum: {0}, occurs {1}", min, numberOfMin);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);


            //------------
            max = int.MinValue;
            min = int.MaxValue;
            numberOfMax = 0;
            numberOfMin = 0;
            sw.Reset();
            sw.Start();

            CountdownEvent event1 = new CountdownEvent(2);
            ThreadPool.QueueUserWorkItem(Max2, event1);
            ThreadPool.QueueUserWorkItem(Min2, event1);
            event1.Wait();
            Console.WriteLine("Maximum: {0}, occurs {1}", max, numberOfMax);
            Console.WriteLine("Minimum: {0}, occurs {1}", min, numberOfMin);
            sw.Stop();
            Console.WriteLine(sw.ElapsedTicks);

            Console.ReadKey();
        }
    }
}
