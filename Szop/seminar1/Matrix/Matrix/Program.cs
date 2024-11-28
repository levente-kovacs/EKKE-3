using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Matrix
{
    /*
     * 2 threads

and 
80x25

1st places X in matrix, in a random position 2000  finds O in the random position
it does nothing
2dn places O in matrix, in a random position 2000
finds X in the random position it does nothing...
     * 
     * 
     */
    internal class Program
    {
        const int N = 80; const int M = 25;
        static char[,] matrix = new char[N, M];
        static int howmany = 2000;
        static Random rn = new Random();
        static void ThreadX()
        {
            for (int i = 0; i < howmany; i++)
            {
                int x = rn.Next(0, 80); int y = rn.Next(0, 25);
                lock (matrix)
                {
                    if (matrix[x, y] != 'O')
                        matrix[x, y] = 'X';
                }
            }
        }
        

        static void ThreadO()
        {
            for (int i = 0; i < howmany; i++)
            {
                int x = rn.Next(0, 80); int y = rn.Next(0, 25);
                lock (matrix)
                {
                    if (matrix[x, y] != 'X')
                        matrix[x, y] = 'O';
                }
            }
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(ThreadX);
            Thread t2 = new Thread(ThreadO);
            t1.Priority = ThreadPriority.Lowest;
            t2.Priority=ThreadPriority.Highest;
            t1.Start(); t2.Start();
            t1.Join(); t2.Join();
            int sumX = 0; int sumO = 0;
            for (int i = 0; i < N; i++)
                for (int j = 0; j < M; j++)
                    if (matrix[i, j] == 'X')
                        sumX++;
                    else
                        if (matrix[i, j] == 'O')
                            sumO++;
            Console.WriteLine("X: {0} O: {1}", sumX, sumO);
            Console.ReadKey();
            
        }
    }
}
