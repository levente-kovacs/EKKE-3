﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace labda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            labda l = new labda(10, 5, 1, 1);
            Thread t = new Thread(l.mozog);
            t.Start();
            labda l2 = new labda(30, 2, -1, 1);
            Thread t1 = new Thread(l2.mozog);
            t1.Start();
            labda l3 = new labda(70, 10, -1, -1);
            Thread t2 = new Thread(l3.mozog);
            t2.Start();
            bool stop = false;
            while (!stop)
            {
                if(l.currposX == l2.currposX && l.currposY == l2.currposY || 
                    l.currposX == l3.currposX && l.currposY == l3.currposY ||
                    l2.currposX == l3.currposX && l2.currposY == l3.currposY)
                {
                    t.Abort();
                    t1.Abort();
                    t2.Abort();
                }
            }
        }
    }
    class labda
    {
        public int currposX, currposY, intx, inty;
        public labda(int currposX, int currposY, int intx, int inty)
        {
            this.currposX = currposX;
            this.currposY = currposY;
            this.intx = intx;
            this.inty = inty;
        }
        public void mozog()
        {
            while (true)
            {
                lock(typeof(Program))
                {
                    Console.SetCursorPosition(currposX, currposY);
                    Console.WriteLine(' ');
                }
                if(currposX < 80 && currposX > 0 && currposY <25 && currposY > 0)
                {
                    currposX += intx;
                    currposY += inty;
                }
                if( currposX == 0 || currposX == 80)
                {
                    intx *= -1;
                    currposX += intx;
                }
                if (currposY == 0 || currposY == 25)
                {
                    inty *= -1;
                    currposY += inty;
                }
                lock (typeof(Program))
                {
                    Console.SetCursorPosition(currposX, currposY);
                    Console.WriteLine('O');
                }
                Thread.Sleep(100); //43:34
            }
        }


    }
}
