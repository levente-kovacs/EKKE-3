using System.Collections.Concurrent;

namespace ProducerConsumerBlocking
{
    internal class Program
    {
        const int BufferSize = 40;
        static BlockingCollection<int> buffer = new BlockingCollection<int>(BufferSize);
        static void Main(string[] args)
        {
            Task t1 = Task.Run(() => Producer1(1,10000));
            Task t2 = Task.Run(() => Producer1(10001,20000));
            Task t3 = Task.Run(() => Producer1(20001,30000));
            Task t4 = Task.Run(() => Producer1(30001,40000));
            Task t5 = Task.Run(() => Consumer1());
            Task t6 = Task.Run(() => Consumer1());
            Task.WaitAll(t1, t2, t3, t4);
            buffer.CompleteAdding();
            Console.WriteLine("That is all???");

        }

        static bool isPrime(int number)
        {
            bool prime = true;
            for (int i = 2; i <= Math.Sqrt(number) && prime; i++)
                if (number % i == 0)
                    prime = false;
            return prime;
        }

        static void Producer1(int from, int until)
        {
            for (int i = from; i <= until; i++)
                if (isPrime(i))
                {
                    buffer.Add(i);
                    Console.WriteLine($"{i} has been added");
                }
            Console.WriteLine("A producer stops");
            //buffer.CompleteAdding();
        }

        static void Consumer1()
        {
            while (!buffer.IsCompleted)
            {
                int item2 = buffer.Take();
                Console.WriteLine($"{item2} has been removed");
            }
            Console.WriteLine("Consumer stops");

           
        }
    }
}
