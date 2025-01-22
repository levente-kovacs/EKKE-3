using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen1 = new Pen(Color.Magenta, 3f);
        float alpha1 = 0;
        float beta1 = 0;
        float gamma1 = 0;
        float lambda1 = 100;
        CubeBRep cube1 = new CubeBRep();

        Pen pen2 = new Pen(Color.OrangeRed, 6f);
        float alpha2 = 0;
        float beta2 = 0;
        float gamma2 = 0;
        float lambda2 = 200;
        CubeBRep cube2 = new CubeBRep();
        ModelBRep suzanne = new BRepObj("Suzanne.obj");
        float R1 = 1.5f;
        float r1 = 0.5f;
        ModelBRep torus;

        public Form1()
        {
            InitializeComponent();
            //ExtensionGraphics.Projection.SetParallel(0.4f, 0.4f, -0.57f);
            ExtensionGraphics.Projection.SetCentral(500);
            ExtensionGraphics.centerOfCanvas = new Vector2F(canvas.Width / 2, canvas.Height / 2);
            torus = new BRepParametricSurface(
                (u, v) => (R1 + r1 * MathF.Cos(u)) * MathF.Cos(v),
                (u, v) => (R1 + r1 * MathF.Cos(u)) * MathF.Sin(v),
                (u, v) => r1 * MathF.Sin(u),
                0, 2 * MathF.PI,
                0, 2 * MathF.PI,
                25, 25);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            //g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

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
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.Translate(100, -50, 10));
            g.FlatShadingBRep(Color.Magenta, torus);
            g.DisplayBRep(pen1, cube1);

            ExtensionGraphics.Transformation.LoadIdentity();
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.Scale(lambda2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotX(alpha2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotY(beta2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.RotZ(gamma2));
            ExtensionGraphics.Transformation.Push(Matrix4F.Transformations.Translate(100, -150, 10));
            g.FlatShadingBRep(Color.OrangeRed, suzanne);
            //g.FlatShadingBRep(Color.OrangeRed, cube2);
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
