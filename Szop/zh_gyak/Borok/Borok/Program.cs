using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
Borok – BlockingCollection és Task – 70 pont 
BlockingCollection és Task használatával oldja meg a következő termelő-fogyasztó problémát! A termelők bort öntenek két különböző hordóba. 
(Mindegyik 1 litert egyszerre.) Az egyikbe vöröset, a másikba fehéret. Két típusú termelő van: az egyik csak vörösbort, a másik típusú csak fehérbort tud termelni. 
Mindegyik különböző mennyiségben állítja elő ezeket. A vörösbor előállításához kell a több idő, a fehérboréhoz kevesebb (Thread.Sleep). 
A fogyasztóknak is két típusa, az egyik csak vörösbort, a másik típusú csak fehérbort fogyaszt. (Egyszerre 1 litert.) 
A berakásról és a kivételről is üzeneteket írnak ki, minden bortípushoz különböző szín tartozzon. A fogyasztók valamennyi bort elfogyasztják.  
A kollekciókhoz (2 darab van) a hozzáférést, a termelők és a fogyasztók kontrollálását a Supervisor osztály végezze. 
A lista mérete konstansként legyen megadva. (A hordok nevei: piros és feher.) 
A termelő osztály mezői: 
    - Bor típus: vörös vagy fehér. (String) 
    - Colour: Piros, sárga. ConsoleColor típusú 
    - Mennyiség: mennyi bort kell előállítania. Típusa: double. 
    - WorkTime: a „termelés” után hány millisec-et kell várni. (Lehet előtte is.:-). int. Vörösbor esetén 10, fehér esetén 5 legyen. 
A fogyasztó osztály mezői 
    - Bor típus: vörös vagy fehér. (String) 
    - Colour: Piros, sárga. ConsoleColor típusú 
Négy termelő és négy fogyasztó legyen! A fenti korlátokon kívül más megkötés nincs. 
*/

namespace Borok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("asd");
            //VineProducer whiteProducer = new VineProducer("feher", ConsoleColor.White, 22, 5);
            //VineProducer redProducer = new VineProducer("piros", ConsoleColor.Red, 20, 10);
            //Task whiteProdTask = Task.Run(() => whiteProducer.Termel());
            //Task redProdTask = Task.Run(() => redProducer.Termel());
            //Task.WaitAll(redProdTask, whiteProdTask);

            //VineConsumer whiteConsumer = new VineConsumer("feher", ConsoleColor.White);
            //VineConsumer redConsumer = new VineConsumer("piros", ConsoleColor.Red);
            //Task whiteConsTask = Task.Run(() => whiteConsumer.Fogyaszt());
            //Task redConsTask = Task.Run(() => redConsumer.Fogyaszt());
            //Task.WaitAll(redConsTask, whiteConsTask);


            VineProducer whiteProducer1 = new VineProducer("feher", ConsoleColor.White, 22, 5);
            VineProducer whiteProducer2 = new VineProducer("feher", ConsoleColor.White, 22, 5);
            VineProducer redProducer1 = new VineProducer("piros", ConsoleColor.Red, 20, 10);
            VineProducer redProducer2 = new VineProducer("piros", ConsoleColor.Red, 20, 10);

            VineConsumer whiteConsumer1 = new VineConsumer("feher", ConsoleColor.White);
            VineConsumer whiteConsumer2 = new VineConsumer("feher", ConsoleColor.White);
            VineConsumer redConsumer1 = new VineConsumer("piros", ConsoleColor.Red);
            VineConsumer redConsumer2 = new VineConsumer("piros", ConsoleColor.Red);

            Task t1 = Task.Run(() => whiteProducer1.Termel());
            Task t2 = Task.Run(() => whiteProducer2.Termel());
            Task t3 = Task.Run(() => redProducer1.Termel());
            Task t4 = Task.Run(() => redProducer2.Termel());
            Task t5 = Task.Run(() => whiteConsumer1.Fogyaszt());
            Task t6 = Task.Run(() => whiteConsumer2.Fogyaszt());
            Task t7 = Task.Run(() => redConsumer1.Fogyaszt());
            Task t8 = Task.Run(() => redConsumer2.Fogyaszt());
            Task.WaitAll(t1, t2, t3, t4);

            Supervisor.redBarrel.CompleteAdding();
            Supervisor.whiteBarrel.CompleteAdding();
            // Prevent the application from exiting
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();


            //VineProducer tVoros = new VineProducer("piros", ConsoleColor.Red, 20, 10);
            //VineProducer tFeher = new VineProducer("feher", ConsoleColor.White, 22, 5);
            //Task tv = Task.Run(() => tVoros.Termel());
            //Task tf = Task.Run(() => tFeher.Termel());
            //Task.WaitAll(tv, tf);

            //VineConsumer fVoros = new VineConsumer("piros", ConsoleColor.Red);
            //VineConsumer fFeher = new VineConsumer("feher", ConsoleColor.White);
            //Task fv = Task.Run(() => fVoros.Fogyaszt());
            //Task ff = Task.Run(() => fFeher.Fogyaszt());
            //Task.WaitAll(fv, ff);
        }
    }
}
