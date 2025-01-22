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
        Vector2 p0 = new Vector2(100, 400);
        Vector2 p1 = new Vector2(550, 100);
        Vector2 t0 = new Vector2(200, 140);
        Vector2 t1 = new Vector2(700, 400);

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawRectangle(Pens.Black, (float)p0.x - 4, (float)p0.y - 4, 8, 8);
            g.DrawRectangle(Pens.Black, (float)p1.x - 4, (float)p1.y - 4, 8, 8);
            g.DrawLine(Pens.Black, (float)p0.x, (float)p0.y, (float)t0.x, (float)t0.y);
            g.DrawLine(Pens.Black, (float)p1.x, (float)p1.y, (float)t1.x, (float)t1.y);
            g.DrawHermiteArc(new Pen(Color.Blue, 3f), p0, p1, t0 - p0, t1 - p1);

            /*
             * Project: készíteni olyan programot, mely több Hermite ívet
              csatlakoztat egymáshoz (ezeket kényelmesen lehessen egérrel fölvenni)

            */
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
