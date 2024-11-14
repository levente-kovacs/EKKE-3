using System.Collections.Concurrent;

internal class Program
{
    const int bufferSize = 100;
    static BlockingCollection<int> buffer = new BlockingCollection<int>(bufferSize);
    static Random rn = new Random();
    private static void Main(string[] args)
    {
        Task t1 = Task.Run(() => Insert(200, 3));
        Task t2 = Task.Run(() => Insert(100, 5));
        Task t3 = Task.Run(() => Insert(200, 7));
        Task t4 = Task.Run(() => Remove(ConsoleColor.Red));
        Task t5 = Task.Run(() => Remove(ConsoleColor.White));
        Task t6 = Task.Run(() => Remove(ConsoleColor.Green));
        Task.WaitAll(t1, t2, t3);
        buffer.CompleteAdding();
    }
    public static void Insert(int db, int f)
    {
        for (int i = 0; i < db; i++)
        {
            int number = rn.Next(10000, 90000);
            while (number % f != 0)
            {
                number = rn.Next(10000, 90000);
            }
            buffer.Add(number);
            Console.WriteLine("Beraktam: " + number);
        }
    }
    public static void Remove(System.ConsoleColor color)
    {
        int number = 0;
        while (!buffer.IsCompleted)
        {
            number = buffer.Take();
            lock (typeof(Program))
            { 
               Console.ForegroundColor = color;
               Console.WriteLine(number);
            }
        }
    }
}