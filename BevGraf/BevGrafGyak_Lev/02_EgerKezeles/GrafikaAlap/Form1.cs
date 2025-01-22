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
        int x = 200;
        int y = 200;
        int size = 100;
        int dx, dy;
        Brush brush = new SolidBrush(Color.Red);
        bool isGrabbed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.FillRectangle(brush, x, y, size, size);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (x <= e.X && e.X < x + size &&
                y <= e.Y && e.Y < y + size)
            {
                isGrabbed = true;
                dx = e.X - x;
                dy = e.Y - y;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isGrabbed)
            {
                x = e.X - dx;
                y = e.Y - dy;
                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isGrabbed = false;
        }
    }
}
