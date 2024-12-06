using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sakktabla
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
       }
        private void button1_Click(object sender, EventArgs e)
        {
           Graphics g = this.CreateGraphics();
           Negyzet n = new Negyzet(10, 361, 50, -50);
           Thread t = new Thread(() => n.rajzol(g));
           t.Start();
           Negyzet n2 = new Negyzet(10, 10, 50, 50);
           Thread t2 = new Thread (() => n2.rajzol(g));
           t2.Start();
           bool stop = false;
           while (!stop)
           {
               if (n2.gety() >= n.gety())
               {
                   t.Abort();
                   t2.Abort();
                   stop = true;
               }
           }
       }
        
    }
    class Negyzet
    {
        int x, y, sz, iranysz;
        Graphics g;
        public int getx()
        {
            return x;
        }
        public int gety()
        {
            return y;
        }
        public Negyzet(int x, int y, int sz, int iranysz)
        {
            this.x = x;
            this.y = y;
            this.sz = sz;
            this.iranysz = iranysz;
        }
        public void rajzol(Graphics g2)
        {
            this.g = g2;
            SolidBrush brush = new SolidBrush(Color.Khaki);
            int plusz = 0;
            if (iranysz < 0)
                plusz = 1;

            RectangleF rec = new RectangleF(x, y, sz, sz);
            int startx = x;
            for (int j = 0; j < 8; j++)
            {
                for (int i = 0; i < 8; i++)
                {
                    if ((i + j + plusz) % 2 == 0)
                    {
                        brush = new SolidBrush(Color.Khaki);
                    }
                    else
                        brush = new SolidBrush(Color.White);
                    lock (typeof(Program))
                    {
                        rec = new RectangleF(x, y, sz, sz);
                        g.FillRectangle(brush, rec);
                        x += sz;
                    }
                }
                lock (typeof(Program))
                {
                    y += iranysz;
                    x = startx;
                }
                Thread.Sleep(100);
            }
        }

    }
}
