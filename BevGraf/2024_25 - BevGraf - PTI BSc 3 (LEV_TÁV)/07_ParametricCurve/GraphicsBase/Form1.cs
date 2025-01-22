using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        
        Pen pen1 = new Pen(Color.Purple, 3f);
        float r1 = 300;
        float m1 = 50;

        Pen pen2 = new Pen(Color.Orange, 5f);
        float r2 = 100;
        float m2 = 100;

        float alpha1 = 0;
        float beta1 = 0;
        float gamma1 = 0;

        float alpha2 = 0;
        float beta2 = 0;
        float gamma2 = 0;

        public Form1()
        {
            InitializeComponent();

            ExtensionGraphics.SetCenterOfCanvas(new Vector4F(canvas.Width / 2, canvas.Height / 2, 0));
            ExtensionGraphics.Projection.SetParallel(0.4f, 0.4f, -0.6f);
            //ExtensionGraphics.Projection.SetCentral(1000);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            ExtensionGraphics.Transformation.LoadIdentity();
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.Scale(100));
            g.DrawLine(new Pen(Color.Red, 3f), ExtensionGraphics.o, ExtensionGraphics.e1);
            g.DrawLine(new Pen(Color.Green, 3f), ExtensionGraphics.o, ExtensionGraphics.e2);
            g.DrawLine(new Pen(Color.Blue, 3f), ExtensionGraphics.o, ExtensionGraphics.e3);

            ExtensionGraphics.Transformation.LoadIdentity();
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.RotateX(alpha1));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.RotateY(beta1));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.RotateZ(gamma1));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.Translate(100, 50, -200));
            g.DrawParametricCurve3D(pen1,
                t => r1 * MathF.Cos(t),
                t => r1 * MathF.Sin(t),
                t => m1 * t / (2 * MathF.PI),
                -10 * MathF.PI, 10 * MathF.PI,
                2000);

            ExtensionGraphics.Transformation.LoadIdentity();
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.RotateX(alpha2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.RotateY(beta2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.RotateZ(gamma2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformation.Translate(-100, -50, 200));
            g.DrawParametricCurve3D(pen2,
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

        private void timer_Tick(object sender, EventArgs e)
        {
            alpha1 += 0.01f;
            beta1 += 0.02f;
            gamma1 -= 0.01f;

            alpha2 -= 0.01f;
            beta2 -= 0.02f;
            gamma2 += 0.01f;
            canvas.Invalidate();
        }
    }
}
