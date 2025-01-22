using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Red, 3);
        BRepCube cube = new BRepCube();

        public Form1()
        {
            InitializeComponent();

            ExtensionGraphics.centerOfCanvas = new Vector4F(canvas.Width / 2,
                                                            canvas.Height / 2,
                                                            0);
            //ExtensionGraphics.SetParallelProjection(
            //    new Vector4F(0.4f, 0.4f, -0.6f));
            ExtensionGraphics.SetCentralProjection(1000);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            g.DrawLine(new Pen(Color.Red, 3), ExtensionGraphics.O, ExtensionGraphics.E1);
            g.DrawLine(new Pen(Color.Green, 3), ExtensionGraphics.O, ExtensionGraphics.E2);
            g.DrawLine(new Pen(Color.Blue, 3), ExtensionGraphics.O, ExtensionGraphics.E3);

            ExtensionGraphics.LoadIdentity();
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.Scale(300));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateX(alpha1));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateY(beta1));
            ExtensionGraphics.PushTransformation(Matrix4F.Transformation.RotateZ(gamma1));
            g.DrawWireframeBRep(pen, cube, true);
            
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
