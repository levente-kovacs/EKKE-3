using System.Reflection.Metadata;
using System;
using Flag;
using System.Drawing;

internal class Program
{

//  1) 
//  Készítsünk olyan programot, amely a magyar zászlót rajzolja ki a karakteres képernyőre az alábbi módon: készítsünk először egy külön osztályt az alábbi adatokkal:

//    y1,y2 egész szám adatok,
//    szín
//    kirajzolandó csillagok darabszáma
//    egy kirajzol() paraméter nélküli void-os függvény, mely a képernyőn az adott y1..y2 koordináták közé eső sávban adott színnel random
//    koordinátákra csillag karaktert rajzol.

//  Példányosítsuk meg az osztályt 3 példányra, az első a y1 = 0, y2 = 7, szín = piros beállítások mellett egy piros sávot rajzol hasonlóan a második fehér,
//  a harmadik zöld sávot rajzol ki.A képernyő 25 soros(0..24), és 80 oszlopos(0..79).

//  Hívjuk meg a három kirajzol() függvényt egymás után, hogy megkapjuk a három sávot.


    private static void Main(string[] args)
    {
        //Console.SetWindowSize(60, 130);
        //FlagClass flag1 = new FlagClass(0, 8, ConsoleColor.Red, 119);
        FlagClass flag1 = new FlagClass(0, 7, ConsoleColor.Red, 80);
        Thread thread1 = new Thread(flag1.kirajzol);
        thread1.Start();
        //flag1.kirajzol();
        //FlagClass flag2 = new FlagClass(9, 17, ConsoleColor.White, 119);
        FlagClass flag2 = new FlagClass(8, 15, ConsoleColor.White, 80);
        Thread thread2 = new Thread(flag2.kirajzol);
        thread2.Start();
        //flag2.kirajzol();
        //FlagClass flag3 = new FlagClass(18, 26, ConsoleColor.Green, 119);
        FlagClass flag3 = new FlagClass(16, 23, ConsoleColor.Green, 80);
        Thread thread3 = new Thread(flag3.kirajzol);
        thread3.Start();
        //flag3.kirajzol();

        //lock (typeof(Program))
        //{
        //    Console.SetCursorPosition(0, 30);
        //    Console.WriteLine($"H: {Console.WindowHeight}");
        //    Console.WriteLine($"W: {Console.WindowWidth}");

        //}

        Console.ReadKey();
    }
}