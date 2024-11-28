using System.Diagnostics;

internal class Program
{
    const int N = 1000000;
    static int[] array=new int[N];
    static long sum = 0;

    static void Sum1()
    {
        for (int i = 0; i < N/2 ; i++)
        {
            Interlocked.Add(ref sum, array[i]);
            //sum += array[i]; 
           
        }
    }

    static void Sum2()
    {
        for (int i = N/2; i < N; i++)
        {
            Interlocked.Add(ref sum, array[i]);
            //sum += array[i]; 

        }
    }


    private static void Main(string[] args)
    {
        for (int i = 0; i < N; i++)
        {
            array[i] = 1;
        }
        Thread t1 = new Thread(Sum1);
        Thread t2 = new Thread(Sum2);
        t1.Start();t2.Start();t1.Join();t2.Join();
        Console.WriteLine(sum);
        Console.ReadKey();
        
    }
}

//2 threads and two methods. numberofodd, numberofeven. Array with
//N=100000, 