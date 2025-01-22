using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen1 = new Pen(Color.Red, 3);
        float r1 = 200;
        float m1 = 50;

        Pen pen2 = new Pen(Color.Blue, 3);
        float r2 = 100;
        float m2 = 100;

        public Form1()
        {
            InitializeComponent();

            ExtensionGraphics.centerOfCanvas = new Vector4F(canvas.Width / 2,
                                                            canvas.Height / 2,
                                                            0);
            ExtensionGraphics.SetProjection(
                Matrix4F.Projection.Parallel(
                    new Vector4F(0.4f, 0.4f, -0.6f)));
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawLine(new Pen(Color.Red, 3), ExtensionGraphics.O, ExtensionGraphics.E1);
            g.DrawLine(new Pen(Color.Green, 3), ExtensionGraphics.O, ExtensionGraphics.E2);
            g.DrawLine(new Pen(Color.Blue, 3), ExtensionGraphics.O, ExtensionGraphics.E3);

            ExtensionGraphics.LoadIdentity();
            ExtensionGraphics.PushTransformation(
                Matrix4F.Transformation.Translate(new Vector4F(-150, 60, 10)));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateX(alpha1));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateY(beta1));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateZ(gamma1));
            g.DrawParametricCurve3D(pen1,
                t => r1 * MathF.Cos(t),
                t => r1 * MathF.Sin(t),
                t => m1 * t / (2 * MathF.PI),
                -10 * MathF.PI, 10 * MathF.PI);

            ExtensionGraphics.LoadIdentity();
            ExtensionGraphics.PushTransformation(
                Matrix4F.Transformation.Translate(new Vector4F(150, -60, 10)));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateX(alpha2));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateY(beta2));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateZ(gamma2));
            g.DrawParametricCurve3D(pen2,
                t => r2 * MathF.Cos(t),
                t => r2 * MathF.Sin(t),
                t => m2 * t / (2 * MathF.PI),
                -10 * MathF.PI, 10 * MathF.PI);
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

        float alpha1 = 0;
        float beta1 = 0;
        float gamma1 = 0;
        float alpha2 = 0;
        float beta2 = 0;
        float gamma2 = 0;
        private void timer_Tick(object sender, EventArgs e)
        {
            alpha1 += 0.01f;
            beta1 += 0.02f;
            gamma1 += 0.03f;
            alpha2 -= 0.01f;
            beta2 -= 0.02f;
            gamma2 -= 0.03f;
            canvas.Invalidate();
        }
    }
}
