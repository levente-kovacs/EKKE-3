using System.Threading;

internal class Program
{
    static int numberOfOddNumbers = 0;
    static int numberOfEvenNumbers = 0;
    const int N = 10000;
    static int[] numbers =new int[N];

    static void CalculateLow()
    {
        for (int i = 0; i < N / 2; i++)
        {
            if (numbers[i] % 2 == 0)
                Interlocked.Increment(ref numberOfEvenNumbers);
            else
                Interlocked.Increment(ref numberOfOddNumbers);
           // Console.WriteLine(i);
        }
    
    }

    static void CalculateUp()
    {
        for (int i = N/2; i < N; i++)
        {
            if (numbers[i] % 2 == 0)
                Interlocked.Increment(ref numberOfEvenNumbers);
            else
                Interlocked.Increment(ref numberOfOddNumbers);
        }

    }
    private static void Main(string[] args)
    {
        for (int i = 0; i < N; i++) {
            numbers[i] = i;
        }
        Thread t1 = new Thread(CalculateLow); //t1.IsBackground = true;
        t1.Start();
        Thread t2 = new Thread(CalculateUp); t2.Start();//t1.IsBackground = true; t2.Start();
        Console.WriteLine(t1.IsAlive);
        t1.Join(); Console.WriteLine(t1.IsAlive); t2.Join();
        Console.WriteLine($"Odd numbers {numberOfOddNumbers}, even numbers: {numberOfEvenNumbers}");
        //Console.ReadKey();
    }
}
// 2 threads and two methods. numberofodd, numberofeven. Array with
//N=100000,Calculete the number of odd and even numbers. How many
//do we have?