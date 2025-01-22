using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Red, 3);
        float R = 200;
        float r = 50;

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
            g.DrawParametricSurface(pen,
                (u, v) => (R + r * MathF.Cos(u)) * MathF.Cos(v),
                (u, v) => (R + r * MathF.Cos(u)) * MathF.Sin(v),
                (u, v) => r * MathF.Sin(u),
                0, 2 * MathF.PI,
                0, 2 * MathF.PI,
                10, 20);
            
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
        private void timer_Tick(object sender, EventArgs e)
        {
            alpha1 += 0.01f;
            beta1 += 0.02f;
            gamma1 += 0.03f;
            canvas.Invalidate();
        }
    }
}
