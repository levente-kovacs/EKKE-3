using System.Diagnostics;
using System.Threading;

internal class Program
{
    const int N = 100000000;
    static int[] array = new int[N];

   // [ThreadStatic]
    static long sum = 0;

    static long TotalSum = 0;


    static void Sum1()
    {
        for (int i = 0; i < N / 2; i++)
        {
            Interlocked.Add(ref sum, array[i]);
            //sum += array[i]; 

        }
        //Interlocked.Add(ref TotalSum,sum);
    }

    static void Sum2()
    {
        for (int i = N / 2; i < N; i++)
        {
            Interlocked.Add(ref sum, array[i]);
            //sum += array[i]; 

        }
        //Interlocked.Add(ref TotalSum, sum);
    }


    private static void Main(string[] args)
    {
        for (int i = 0; i < N; i++)
        {
            array[i] = 1;
        }
        Stopwatch sw = new Stopwatch(); 
        sw.Start();
        Thread t1 = new Thread(Sum1);
        Thread t2 = new Thread(Sum2);
        t1.Start(); t2.Start(); t1.Join(); t2.Join();
       // Console.WriteLine(TotalSum);
        Console.WriteLine(sum);
        sw.Stop();Console.WriteLine(sw.ElapsedMilliseconds.ToString());
        Console.ReadKey();

    }
}