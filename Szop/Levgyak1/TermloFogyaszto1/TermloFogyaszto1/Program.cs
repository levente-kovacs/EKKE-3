using System.Data.SqlTypes;
using System.Drawing;

class SuperVisor
{
    const int bufferSize = 100;
    static List<int> buffer = new List<int>();
    static int numberOfConsumer = 0;
    static int numberOfProducer = 0;
    static bool ConsumersStopped = false;
    static bool ProducerStopped = false;

    public static void ConsumerStarts()
    {
        Interlocked.Increment(ref numberOfConsumer);

    }

    public static void ConsumerEnds()
    {
        Interlocked.Decrement(ref numberOfConsumer);
        if (numberOfConsumer == 0)
        {
            ConsumersStopped = true;
            lock (buffer)
            {
                Monitor.PulseAll(buffer);
            }
        }
    }
    public static void ProducersStopped()
    {
        Interlocked.Decrement(ref numberOfProducer);
        if (numberOfProducer == 0)
        {
            ProducerStopped = true;
            lock (buffer)
            {
                Monitor.PulseAll(buffer);
            }
        }
    }
    public static void ProducerStarts()
    {
        Interlocked.Increment(ref numberOfProducer);
    }

    public static void Insert(int number)
    {
        lock (buffer)
        {
            while (bufferSize <= buffer.Count)
            {
                if (ConsumersStopped)
                    throw new Exception("Nincs több fogyasztó");
                Monitor.Wait(buffer);
            }
            //Console.WriteLine("Berakva: " + number);
            buffer.Add(number);
            Monitor.PulseAll(buffer);
        }
    }

    public static int Remove()
    {
        int temp = 0;
        lock (buffer)
        {
            while (buffer.Count <= 0)
            {
                if (ProducerStopped)
                    throw new Exception("Nincs több termelő");
                Monitor.Wait(buffer);
            }
            temp = buffer[0];
            buffer.RemoveAt(0);
            Monitor.PulseAll(buffer);
        }
        return temp;
    }
}

class Producer
{
    int db = 0; int f = 0; Random rn = new Random();
    public Producer(int db, int f)
    {
        this.db = db; this.f = f;
    }

    public void DoWork()
    {
        SuperVisor.ProducerStarts(); int number = 0;
        for (int i = 0; i < db; i++)
        {
            number = rn.Next(10000, 90000);
            while (number%f!=0)
                number = rn.Next(10000, 90000);
            try
            {
                SuperVisor.Insert(number); Console.WriteLine("Berakva: " + number);
            }
            catch { Console.WriteLine("Ohh, nem tudok termelni"); }
        }
        SuperVisor.ProducersStopped();

    }

}

class Consumer
{
    System.ConsoleColor color;

    public Consumer(System.ConsoleColor color)
    {
        this.color = color;
    }

    public void DoWork()
    {
        SuperVisor.ConsumerStarts(); int number = 0;
        while (true)
        {
            try
            {
                 number = SuperVisor.Remove();
            }
            catch { Console.WriteLine("Nincs több termelő"); break; }
            lock (typeof(Program))
            {
                Console.ForegroundColor = color;
                Console.WriteLine($"A kivett érték: {number}");
            }
        }
        SuperVisor.ConsumerEnds();
    }
}


internal class Program
{
    private static void Main(string[] args)
    {
        Producer p1=new Producer(200,3);
        Producer p2 = new Producer(100, 5);
        Producer p3 = new Producer(200, 7);
        Thread t1 = new Thread(p1.DoWork);
        Thread t2 = new Thread(p2.DoWork);
        Thread t3 = new Thread(p3.DoWork);
        Consumer c1 = new Consumer(ConsoleColor.Red);
        Consumer c2 = new Consumer(ConsoleColor.White);
        Consumer c3 = new Consumer(ConsoleColor.Green);
        Thread t4 =new Thread(c1.DoWork);
        Thread t5 = new Thread(c2.DoWork);
        Thread t6 = new Thread(c3.DoWork);
        t1.Start();t2.Start();t3.Start();
        t4.Start();t5.Start();t6.Start();
        Console.ReadKey();
    }
}