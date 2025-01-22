using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GrafikaDLL;

namespace GrafikaAlap
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawLine(new Pen(Color.Black, 3), 50, 100, 500, 350);
            g.DrawLine(Pens.Red, 50, 120, 500, 370);
            g.DrawLine(Pens.Black, 0, 0, canvas.Width, canvas.Height);
            //Hf.: A másik átló berajzolása
            Point p0 = new Point(0, canvas.Height / 2);
            Point p1 = new Point(canvas.Width, canvas.Height / 2);
            g.DrawLine(Pens.Brown, p0, p1);
            //Hf.: Az 'y' tengely megrajzolása

            //g.FillRectangle(new SolidBrush(Color.FromArgb(0, 255, 255)), 400, 50, 100, 70);
            g.FillRectangle(Brushes.Cyan, 400, 50, 100, 70);
            g.DrawRectangle(Pens.Black, 400, 50, 100, 70);

            g.FillEllipse(Brushes.Yellow, 520, 50, 100, 70);
            g.DrawRectangle(Pens.Black, 520, 50, 100, 70);
            g.DrawEllipse(Pens.Black, 520, 50, 100, 70);

            Point center = new Point(520, 200);
            int r = 50;
            g.DrawEllipse(Pens.Black, center.X - r, center.Y - r, 2 * r, 2 * r);
            g.DrawRectangle(Pens.Red, center.X, center.Y, 0.5f, 0.5f);
            //g.FillRectangle(Brushes.Red, center.X, center.Y, 1, 1);

            Point p = new Point(100, 100);
            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(0, (y + y) % 256, (x + x) % 256)), 
                        x + p.X, y + p.Y, 0.5f, 0.5f);
                }
            }
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
