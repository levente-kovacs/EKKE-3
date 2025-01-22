using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen penCurve1 = new Pen(Color.Red, 3f);
        float r1 = 100;
        float m1 = 30;
        float alpha1 = 0;
        float beta1 = 0;
        float gamma1 = 0;
        float lambda1 = 1;

        Pen penCurve2 = new Pen(Color.OrangeRed, 6f);
        float r2 = 50;
        float m2 = 70;
        float alpha2 = 0;
        float beta2 = 0;
        float gamma2 = 0;

        public Form1()
        {
            InitializeComponent();
            //ExtensionGraphics.Projection.SetParallel(0.4f, 0.4f, -0.57f);
            ExtensionGraphics.Projection.SetCentral(500);
            ExtensionGraphics.centerOfCanvas = new Vector2F(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            ExtensionGraphics.Transformation.LoadIdentity();
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.Scale(100));
            g.DrawLine(new Pen(Color.Red, 3), ExtensionGraphics.o, ExtensionGraphics.e1);
            g.DrawLine(new Pen(Color.Green, 3), ExtensionGraphics.o, ExtensionGraphics.e2);
            g.DrawLine(new Pen(Color.Blue, 3), ExtensionGraphics.o, ExtensionGraphics.e3);

            ExtensionGraphics.Transformation.LoadIdentity();
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.Scale(lambda1));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotX(alpha1));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotY(beta1));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotZ(gamma1));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.Translate(300, -50, 10));
            g.DrawParametricCurve3D(penCurve1,
                t => r1 * MathF.Cos(t),
                t => r1 * MathF.Sin(t),
                t => m1 * t / (2 * MathF.PI),
                -20 * MathF.PI, 20 * MathF.PI,
                2000);

            ExtensionGraphics.Transformation.LoadIdentity();
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotX(alpha2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotY(beta2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotZ(gamma2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.Translate(-300, -50, 10));
            g.DrawParametricCurve3D(penCurve2,
                t => r2 * MathF.Cos(t),
                t => r2 * MathF.Sin(t),
                t => m2 * t / (2 * MathF.PI),
                -10 * MathF.PI, 10 * MathF.PI,
                2000);
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

        private void sbParallelVX_ValueChanged(object sender, EventArgs e)
        {
            lblParallelVX.Text = $"v.x = {sbParallelVX.Value / 100.0:0.00}";
            lblParallelVY.Text = $"v.y = {sbParallelVY.Value / 100.0:0.00}";
            lblParallelVZ.Text = $"v.z = {sbParallelVZ.Value / 100.0:0.00}";
            ExtensionGraphics.Projection.SetParallel(sbParallelVX.Value / 100.0f,
                                                     sbParallelVY.Value / 100.0f,
                                                     sbParallelVZ.Value / 100.0f);
            canvas.Invalidate();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            alpha1 += 0.01f;
            beta1 += 0.02f;
            gamma1 += 0.03f;

            alpha2 -= 0.01f;
            beta2 += 0.02f;
            gamma2 -= 0.03f;

            //lambda1 += lambdaD;
            //if (lambda1 >= 1.5 || lambda1 < 0.5)
            //    lambdaD *= -1f;
            canvas.Invalidate();
        }

        private void sbCentral_ValueChanged(object sender, EventArgs e)
        {
            lblCentral.Text = $"s = {sbCentral.Value}";
            ExtensionGraphics.Projection.SetCentral(sbCentral.Value);
            canvas.Invalidate();
        }
    }
}
