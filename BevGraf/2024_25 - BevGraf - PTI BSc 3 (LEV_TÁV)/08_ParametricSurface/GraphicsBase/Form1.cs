using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        
        Pen pen = new Pen(Color.Purple, 3f);
        float R = 300;
        float r = 50;

        float alpha1 = 0;
        float beta1 = 0;
        float gamma1 = 0;

        public Form1()
        {
            InitializeComponent();

            ExtensionGraphics.SetCenterOfCanvas(new Vector4F(canvas.Width / 2, canvas.Height / 2, 0));
            //ExtensionGraphics.Projection.SetParallel(0.4f, 0.4f, -0.6f);
            ExtensionGraphics.Projection.SetCentral(1000);
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
            g.DrawParametricSurface(pen,
                (u, v) => (R + r * MathF.Cos(u)) * MathF.Cos(v),
                (u, v) => (R + r * MathF.Cos(u)) * MathF.Sin(v),
                (u, v) => r * MathF.Sin(u),
                0, 2 * MathF.PI,
                0, 2 * MathF.PI,
                10, 20,
                200, 200);
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
            canvas.Invalidate();
        }
    }
}
