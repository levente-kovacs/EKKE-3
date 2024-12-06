using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Termelofogy1
{
    /*
     Készítsünk többszálú, termelő-fogyasztó modellű megoldást az alábbiakra:

        -    a puffer mérete maximum 100 elem,
        -    három termelő kell
        -    a termelők adott F számmal osztható random számokat állítanak elő, adott N mennyiségben, a 10000..90000 intervallumból
             Ha berakták a számot, írják ki a számot, és azt, hogy berakták. 
        -    az első termelő 200 db 3-al osztható számot,
        -    a második termelő 100 db, 5-el oszthatót,
        -    a harmadik termelő 200 db, 7-el oszthatót,
        -    három fogyasztó kell
        -    az egyes fogyasztók az előállított random számokat kiírják a képernyőre, minden fogyasztó más-más színt használ (vörös, fehér, zöld).
        -    a fogyasztók álljanak le, ha már a termelők által előállított összes számot kiírták.
        -    Nem lehet berakni a pufferbe, ha legalább 100 elem van benne.
        -    0 elemnél nem lehet kivenni....
        -    A console ablak fejléce mutassa, hogy hány elem van a pufferben. :-)
    */

    class Termelo
    {
        int oszto;
        int db;

        public Termelo(int oszto, int db)
        {
            this.oszto = oszto;
            this.db = db;
        }

        public void Start()
        {
            Felugyelo.ProducerStarted();
            Random rnd = new Random();
            int count = 0;
            int number;
            while (this.db != count)
            {
                number = rnd.Next(10000,90000);
                if(number % oszto == 0)
                {
                    Felugyelo.Insert(number);
                    count++;
                    Console.WriteLine($"Berakta: {number}");
                }
            }

            Felugyelo.ProducerStopped();
        }
    }

    class Consumer
    {
        ConsoleColor c1;
        public Consumer(ConsoleColor c)
        {
            this.c1 = c;
        }

        public void DoIt()
        {
            Felugyelo.ConsumerStarted();
            bool end = false;
            int number = 0;
            while (!end)
            {
                try
                {
                    number = Felugyelo.Consume();
                }
                catch { end = true; }
                lock (typeof(Consumer))
                {
                    Console.ForegroundColor = c1;
                    Console.WriteLine(number);
                }
            }
            Felugyelo.ConsumerStopped();
        }
    }

    class Felugyelo
    {
        static List<int> buffer = new List<int>();
        const int maxsize = 100;
        static int numberOfConsumer = 0;
        static int numberofProducer = 0;
        static bool isConsumersStopped = false;
        static bool isProducersStopped = false;

        static public void WriteBufferCount()
        {
            Console.Title = "Current element in buffer: " + buffer.Count;
        }

        static public void ProducerStarted()
        {
            lock (typeof(Felugyelo))
            {
                numberofProducer++;
                Console.WriteLine("Termelő elindult");
            }
        }

        static public void ConsumerStarted()
        {
            lock (typeof(Felugyelo))
            {
                numberOfConsumer++;
                Console.WriteLine("Fogyasztó elindult");
            }
        }
        static public void ProducerStopped()
        {
            lock (typeof(Felugyelo))
            {
                numberofProducer--;
                Console.WriteLine("Termelő leállt");
            }
            if (numberofProducer <= 0)
            {
                isProducersStopped = true;
                lock (buffer)
                {
                    Monitor.PulseAll(buffer);
                }
            }
        }

        static public void ConsumerStopped()
        {
            lock (typeof(Felugyelo))
            {
                numberOfConsumer--;
                Console.WriteLine("Fogyasztó elállt");
            }
            if (numberOfConsumer <= 0)
            {
                isConsumersStopped = true;
                lock (buffer)
                {
                    Monitor.PulseAll(buffer);
                }
            }
        }

        public static void Insert(int number)
        {
            lock (buffer)
            {
                while (buffer.Count == maxsize)
                {
                    if (isConsumersStopped)
                        throw new Exception("Stop");
                    Monitor.Wait(buffer);
                }
                buffer.Add(number);
                WriteBufferCount();
                Monitor.PulseAll(buffer);
            }
        }
        static public int Consume()
        {
            int number = 0;
            lock (buffer)
            {
                while (buffer.Count == 0)
                {
                    if (isProducersStopped)
                        throw new Exception("Stop");
                    Monitor.Wait(buffer);
                }
                number = buffer[0];
                buffer.RemoveAt(0);
                WriteBufferCount();
                Monitor.PulseAll(buffer);
            }
            return number;
        }

    }

    class Program
    {

        static void Main(string[] args)
        {
            Termelo ter1 = new Termelo(3, 200);
            Termelo ter2 = new Termelo(5, 100);
            Termelo ter3 = new Termelo(7, 200);
            Thread t1 = new Thread(ter1.Start);
            Thread t2 = new Thread(ter2.Start);
            Thread t3 = new Thread(ter3.Start);
            Consumer c1 = new Consumer(ConsoleColor.Red);
            Consumer c2 = new Consumer(ConsoleColor.Green);
            Consumer c3 = new Consumer(ConsoleColor.White);
            Thread t4 = new Thread(c1.DoIt);
            Thread t5 = new Thread(c2.DoIt);
            Thread t6 = new Thread(c3.DoIt);
            t1.Start(); t2.Start(); t3.Start(); t4.Start(); t5.Start(); t6.Start();
            Console.ReadKey();
        }
    }
}
