using System.Buffers;
using System.Diagnostics;

internal class Program
{

    const int N = 100000;
    static int[] a=new int[N];
    static int sum = 0;

    static void ToSumWithoutThreads()
    {
        for (int i = 0; i < N; i++)
            sum += a[i];
        
    }

    static void LowerPart()
    {
        for (int i = 0; i < N/2; i++)
            Interlocked.Add(ref sum, a[i]);
       
    }

    static void UpperPart()
    {
        for (int i = N/2; i < N; i++)
            Interlocked.Add(ref sum, a[i]);
    }

    static void LowerPartThreadPool(Object o)
    {
        CountdownEvent countdownEvent =(CountdownEvent) o;
        for (int i = 0; i < N / 2; i++)
            Interlocked.Add(ref sum, a[i]);
        countdownEvent.Signal();

    }

    static void UpperPartThreadPool(Object o)
    {
        CountdownEvent countdownEvent = (CountdownEvent)o;
        for (int i = N / 2; i < N; i++)
            Interlocked.Add(ref sum, a[i]);
        countdownEvent.Signal();
    }

    static void LowerPartLock()
    {

        for (int i = 0; i < N / 2; i++)
            lock (a)
            {
                sum += a[i];
            }
        
    }

    static void UpperPartLock()
    {
        for (int i = N / 2; i < N; i++)
            lock (a)
            {
                sum += a[i];
            }
    }




    private static void Main(string[] args)
    {
        for (int i = 0; i < N; i++)
            a[i] = 1;
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ToSumWithoutThreads();
        Console.WriteLine("NoThread:"+sum);
        stopwatch.Stop(); ;
        Console.WriteLine(stopwatch.ElapsedTicks);
        stopwatch.Reset();
        sum = 0;
        stopwatch.Start();
        Thread t1 =new Thread(LowerPart); 
        Thread t2 =new Thread(UpperPart);
        t1.Start();t2.Start(); t1.Join(); t2.Join();
        Console.WriteLine("Dedicated, Interlocked"+sum);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        stopwatch.Reset();
        stopwatch.Start();
        CountdownEvent countdownEvent = new CountdownEvent(2);
        sum = 0;
        ThreadPool.QueueUserWorkItem(LowerPartThreadPool, countdownEvent);
        ThreadPool.QueueUserWorkItem(UpperPartThreadPool, countdownEvent);
        countdownEvent.Wait();
        Console.WriteLine("ThreadPool"+sum);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        stopwatch.Reset();
        stopwatch.Start();
        sum = 0;
        t1 = new Thread(LowerPartLock);
        t2 = new Thread(UpperPartLock);
        t1.Start(); t2.Start(); t1.Join(); t2.Join();
        Console.WriteLine("Dedicated threads, +Lock"+sum);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        sum = 0;
        stopwatch.Reset();
        stopwatch.Start();
        Parallel.For(0, N, (i) =>
        {
            Interlocked.Add(ref sum, a[i]);
            //Console.Write("{0} ",i);
        });
        Console.WriteLine("Parallel.For"+sum);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        sum = 0;
        stopwatch.Reset();
        stopwatch.Start();
        Task task = Task.Run(LowerPart);
        Task task2 = Task.Run(UpperPart);
        Task.WaitAll(task, task2);
        Console.WriteLine("Taszk"+sum);
        stopwatch.Stop();
        Console.WriteLine(stopwatch.ElapsedTicks);
        Console.ReadLine();
    }
}