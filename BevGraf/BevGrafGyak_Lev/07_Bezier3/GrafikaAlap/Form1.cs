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
        List<Vector2> p = new List<Vector2>();
        int grabbed = -1;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            for (int i = 0; i < p.Count; i++)
            {
                g.DrawRectangle(Pens.Black, (float)p[i].x - 4, (float)p[i].y - 4, 8, 8);
            }
            for (int i = 0; i < p.Count - 1; i++)
            {
                g.DrawLine(Pens.Black, (float)p[i].x, (float)p[i].y, (float)p[i + 1].x, (float)p[i + 1].y);
            }

            if (p.Count == 4)
                g.DrawBezier3(new Pen(Color.Blue, 3f), p[0], p[1], p[2], p[3]);

        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < p.Count; i++)
            {
                if (p[i].IsGrabbedBy(e.Location))
                    grabbed = i;
            }

            if (p.Count < 4)
            {
                if (grabbed == -1)
                {
                    p.Add(new Vector2(e.X, e.Y));
                    grabbed = p.Count - 1;
                    canvas.Invalidate();
                }
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                p[grabbed].x = e.X;
                p[grabbed].y = e.Y;
                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
