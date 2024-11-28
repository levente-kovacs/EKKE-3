using System.Diagnostics;
using System.Security.Cryptography;

internal class Program
{
    const int N = 100000;
    static int[] a = new int[N];
    static Random rn = new Random();
    static void Put()
    {
        for (int i = 0; i < N; i++)
            lock (a)
            {
                a[i] = rn.Next(1, 1000);
            }
    }

    static void PutWithThreadPool(Object obj)
    {
        CountdownEvent ev = (CountdownEvent)obj;
        for (int i = 0; i < N; i++)
            lock (a)
            {
                a[i] = rn.Next(1, 1000);
            }
        ev.Signal();
    }

    static void Remove()
    {
        for (int i = 0; i < N; i++)
        {
            int pos = rn.Next(0, N);
            lock (a)
            {
                a[pos] = 0;
            }
        }
    }
    static void RemoveThreadPool(Object obj)
    {
        CountdownEvent ev = (CountdownEvent)obj;
        for (int i = 0; i < N; i++)
        {
            int pos = rn.Next(0, N);
            lock (a)
            {
                a[pos] = 0;
            }
        }
        ev.Signal();
    }

    private static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        CountdownEvent ce = new CountdownEvent(2);
        ThreadPool.QueueUserWorkItem(PutWithThreadPool, ce);
        ThreadPool.QueueUserWorkItem(RemoveThreadPool, ce);
        ce.Wait();
        for (int i = 0; i < N; i++)
            if (a[i] != 0)
                Console.Write("{0} ", a[i]);
        sw.Stop();
        Console.WriteLine($"The ellapsed time: {sw.ElapsedTicks}");
        Console.ReadLine();
        sw.Reset();
        sw.Start();
        Thread t1 = new Thread(Put);
        Thread t2 = new Thread(Remove);
        t1.Start();t2.Start(); t1.Join();t2.Join();
        for (int i = 0; i < N; i++)
            if (a[i] != 0)
                Console.Write("{0} ", a[i]);
        sw.Stop();
        Console.WriteLine($"The ellapsed time: {sw.ElapsedTicks}");
        Console.ReadKey();


    }
}