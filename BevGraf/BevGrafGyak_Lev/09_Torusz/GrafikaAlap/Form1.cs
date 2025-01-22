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
        double R = 50;
        double r = 20;
        Pen p = new Pen(Color.Red, 2f);

        public Form1()
        {
            InitializeComponent();
            ExtensionGraphics.centerOfCanvas = new Vector2(canvas.Width / 2, canvas.Height / 2);
            ExtensionGraphics.projection = Matrix4.Projection.Parallel(
                new Vector4(0.8, 0.7, -0.84));

            SetTransformations();
        }

        private void SetTransformations()
        {
            ExtensionGraphics.ClearMatrix();
            ExtensionGraphics.PushMatrix(Matrix4.Transformation.Scale(sbScale.Value / 10.0));
            ExtensionGraphics.PushMatrix(Matrix4.Transformation.RotateX(sbRotateX.Value / 100.0));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.DrawParametricSurface(p,
                (u, v) => (R + r * Math.Cos(u)) * Math.Cos(v),
                (u, v) => (R + r * Math.Cos(u)) * Math.Sin(v),
                (u, v) => r * Math.Sin(u),
                0, 2 * Math.PI,
                0, 2 * Math.PI);
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

        private void sbParallel_ValueChanged(object sender, EventArgs e)
        {
            ExtensionGraphics.projection = Matrix4.Projection.Parallel(
                new Vector4(sbParallelX.Value / 100.0,
                            sbParallelY.Value / 100.0, 
                            sbParallelZ.Value / 100.0));
            canvas.Invalidate();
        }

        private void sbTransformations_ValueChanged(object sender, EventArgs e)
        {
            SetTransformations();
            canvas.Invalidate();
        }
    }
}
