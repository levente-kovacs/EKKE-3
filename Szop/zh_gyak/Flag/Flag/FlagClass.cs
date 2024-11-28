using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Flag
{
    internal class FlagClass
    {
        static Random rnd = new Random();

        public FlagClass(int y1, int y2, ConsoleColor color, int rowLength)
        {
            this.y1 = y1;
            this.y2 = y2;
            this.color = color;
            this.rowLength = rowLength;
        }

        public int y1 { get; set; }
        public int y2 { get; set; }
        public ConsoleColor color { get; set; }
        public int rowLength { get; set; }

        public void kirajzol()
        {
            int i = 0;
            int reps = (y2 - y1 + 1) * rowLength;
            List<string> usedValues = new List<string>();

            while (i < ((y2 - y1 + 1) * rowLength))
            {
                int col = rnd.Next(rowLength);
                int row = rnd.Next(y1, y2 + 1);
                if (!usedValues.Contains($"{row}-{col}"))
                {
                    lock (typeof(Program))
                    {
                        usedValues.Add($"{row}-{col}");
                        Console.SetCursorPosition(col, row);
                        Console.BackgroundColor = this.color;
                        Console.WriteLine(" ");
                    }
                    i++;
                }
            }

            //Console.SetCursorPosition(0, 10);
            //Console.BackgroundColor = ConsoleColor.Black;
            //Console.ForegroundColor = ConsoleColor.White;
            //int counter = 0;
            //foreach (var item in usedValues)
            //{
            //    //Console.WriteLine("asd");
            //    Console.WriteLine($"{counter}. {item}");
            //    counter++;
            //}
        }

        
    }
}
