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
        Rectangle win = new Rectangle(50, 70, 500, 300);
        Pen penWin = new Pen(Color.Black, 2);
        Pen penLineFull = Pens.Gray;
        Pen penLineIn = Pens.Red;

        Random rnd = new Random();
        List<Point> p = new List<Point>();
        public Form1()
        {
            InitializeComponent();

            for (int i = 0; i < 100; i++)
                p.Add(new Point(rnd.Next(canvas.Width), rnd.Next(canvas.Height)));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < p.Count; i += 2)
            {
                g.DrawLine(penLineFull, p[i], p[i + 1]);
                g.ClipCS(penLineIn, win, p[i], p[i + 1]);
            }
            g.DrawRectangle(penWin, win);
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
