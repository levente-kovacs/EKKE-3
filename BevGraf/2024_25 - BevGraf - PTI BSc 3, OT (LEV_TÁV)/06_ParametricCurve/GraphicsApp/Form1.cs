using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            float r = 100;
            PointF O = new PointF(canvas.Width / 2, canvas.Height / 2);
            g.DrawParametricCurve(Pens.Red,
                t => r * MathF.Cos(t) + O.X,
                t => r * MathF.Sin(t) + O.Y,
                0.0f, 2 * MathF.PI);

            float a = 0.5f;
            g.DrawParametricCurve(Pens.Red,
                t => r * a * (2 * MathF.Cos(t) - MathF.Cos(2 * t)) + O.X,
                t => r * a * (2 * MathF.Sin(t) - MathF.Sin(2 * t)) + O.Y,
                0.0f, 2 * MathF.PI);
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
    }
}
