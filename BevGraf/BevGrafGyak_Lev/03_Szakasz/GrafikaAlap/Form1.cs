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
        Point p0 = new Point(100, 50);
        Point p1 = new Point(600, 270);
        int grabbed = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //g.DrawLineDDA(Pens.Black, p0.X, p0.Y, p1.X, p1.Y);
            g.DrawLineDDA(Color.Yellow, Color.DarkMagenta, p0.X, p0.Y, p1.X, p1.Y);
            //g.DrawLineMidPoint45(Pens.Black, p0.X, p0.Y, p1.X, p1.Y);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (p0.IsGrabbedBy(e.Location))
                grabbed = 0;
            else if (p1.IsGrabbedBy(e.Location))
                grabbed = 1;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                if (grabbed == 0)
                    p0 = e.Location;
                else if (grabbed == 1)
                    p1 = e.Location;

                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
