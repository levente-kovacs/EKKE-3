using System.Data;

namespace ProducerConsumer1
{
    class Supervisor
    {
        const int BufferSize = 50;
        static List<int> buffer = new List<int>();
        static int numberOfProducers = 0;
        static int numberOfConsumers = 0;
        static bool producersStopped = false;
        static bool consumersStopped = false;

        public static void ProducersStart()
        {
            Interlocked.Increment(ref numberOfProducers); //lock???
        }

        public static void ConsumersStart()
        {
            Interlocked.Increment(ref numberOfConsumers); //lock??
        }

        public static void ProducersStop()
        {
            Interlocked.Decrement(ref numberOfProducers); //lock??
            if (numberOfProducers <= 0)
            {
                producersStopped = true;
                lock (buffer)
                {
                    Monitor.PulseAll(buffer);
                }
                //throw new Exception("Producers stopped");

            }
        }

        public static void ConsumersStop()
        {
            Interlocked.Decrement(ref numberOfConsumers); //lock???
            if (numberOfConsumers <= 0)
            {
                consumersStopped = true;
                lock (buffer)
                {
                    Monitor.PulseAll(buffer);
                }
                //throw new Exception("Consumers stopped");

            }

        }

        public static void AddItem(int item)
        {
            lock (buffer)
            {
                while (buffer.Count >= BufferSize)
                    if (consumersStopped)
                        throw new Exception("No more consumer");
                    else
                        Monitor.Wait(buffer);
                buffer.Add(item);
                Monitor.PulseAll(buffer);
            }
        }

        public static int Removeitem()
        {
            int item = 0;
            lock (buffer)
            {
                while (buffer.Count <=0)
                    if (producersStopped)
                        throw new Exception("No more producer");
                    else
                        Monitor.Wait(buffer);

                item = buffer[0];
                buffer.RemoveAt(0);
                Monitor.PulseAll(buffer);
            }
            return item;
        }
    }

    class Producer
    {
        ConsoleColor colour;
        int from; int until;
        public Producer(ConsoleColor colour, int from, int until)
        {
            this.colour = colour;
            this.from = from; this.until = until;
        }

        static bool isPrime(int number)
        {
            bool prime = true;
            for (int i = 2; i <= Math.Sqrt(number) && prime; i++)
                if (number % i == 0)
                    prime = false;
            return prime;
        }
        public void Work()
        {
            Supervisor.ProducersStart();
            for (int i = from; i <= until; i++)
            {
                if (isPrime(i))
                    try
                    {
                        Supervisor.AddItem(i);
                        Console.WriteLine($"{i} has been added.");
                    }
                    catch { Console.WriteLine("No more consumer");break; }
            }
            Supervisor.ProducersStop();
        }
    }

    class Consumer
    {
        ConsoleColor colour;
        public Consumer(ConsoleColor c1)
        {
            this.colour = c1;
        }

        public void Consume()
        {
            Supervisor.ConsumersStart();
            while (true)
            {
                try
                {
                    int item = Supervisor.Removeitem();
                    lock (typeof(Program))
                    {
                        Console.ForegroundColor = this.colour;
                        Console.WriteLine(item);
                    }

                }
                catch { Console.WriteLine("No more producer"); break; }
            }
            Supervisor.ConsumersStop();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Producer p1 = new Producer(ConsoleColor.Black, 1, 10000);
            Producer p2 = new Producer(ConsoleColor.Black, 10001, 20000);
            Producer p3 = new Producer(ConsoleColor.Black, 20001, 30000);
            Producer p4 = new Producer(ConsoleColor.Black, 30001, 40000);
            Thread t1 = new Thread(p1.Work);
            Thread t2 = new Thread(p2.Work);
            Thread t3 = new Thread(p3.Work);
            Thread t4 = new Thread(p4.Work);
            t1.Start(); t2.Start(); t3.Start(); t4.Start();
            Consumer c1 = new Consumer(ConsoleColor.Blue);
            Consumer c2 = new Consumer(ConsoleColor.Red);
            Thread t5 = new Thread(c1.Consume);
            Thread t6 = new Thread(c2.Consume);
            t5.Start(); t6.Start();


        }
    }
}
