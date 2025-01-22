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
        Point c = new Point(0, 0);
        Point p = new Point(200, 100);
        int grabbed = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawLine(Pens.Black, p, c);
            g.DrawRectangle(Pens.Black, p.X - ExtensionPoint.GRAB_DIST,
                                        p.Y - ExtensionPoint.GRAB_DIST,
                                        2 * ExtensionPoint.GRAB_DIST,
                                        2 * ExtensionPoint.GRAB_DIST);
            g.DrawRectangle(Pens.Black, c.X - ExtensionPoint.GRAB_DIST,
                                        c.Y - ExtensionPoint.GRAB_DIST,
                                        2 * ExtensionPoint.GRAB_DIST,
                                        2 * ExtensionPoint.GRAB_DIST);
            int r = (int)c.DistanceTo(p);
            //g.DrawCircle(Pens.Blue, c, r);
            g.DrawParametricCurve(Pens.Blue,
                t => r * Math.Cos(t) + c.X,
                t => r * Math.Sin(t) + c.Y,
                0, 2 * Math.PI);

            g.DrawParametricCurve(new Pen(Color.Red, 3f),
                t => 50 * (3.0 * Math.Cos(2 * t)) + c.X,
                t => 50 * (1.0 + Math.Cos(2 * t) * Math.Cos(2 * t)) + c.Y,
                0, 8 * Math.PI);

            /*
             * Project: Keresni olyan görbét (érdemes szétnézni a cikloisoknál pl),
             * aminek a koordináta függvényeiben nem csak a paraméter változik, hanem 
             * attól függően az alakja is, hogy milyen skalárok vannak benne.
             * 
             * Módosítani kell a DrawParametricCurve metódust, hogy emiatt tudjon
             * ne csak RtoR, hanem pl R3toR függvényeket is fogadni, és ilyenet
             * rajzolni a képernyő közepére.
             * 
             * Minden olyan dolog, ami a görbe alakját módosítja, legyen állítható
             * scrollbarral!
             */
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (c.IsGrabbedBy(e.Location))
                grabbed = 0;
            else if (p.IsGrabbedBy(e.Location))
                grabbed = 1;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                if (grabbed == 0)
                    c = e.Location;
                else if (grabbed == 1)
                    p = e.Location;

                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
