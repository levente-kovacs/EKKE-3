using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        float r = 20;

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawParametricCurve(Pens.Black,
                t => r * (
                10 * MathF.Sin(2.78f * t) * MathF.Round(MathF.Sqrt(MathF.Cos(MathF.Cos(8.2f * t))))
                ) + canvas.Width / 2,
                t => r * (
                9 * MathF.Pow(MathF.Cos(2.78f * t), 2) * MathF.Sin(MathF.Sin(8.2f * t))
                )
                + canvas.Height / 2,
                -2 * MathF.PI, 2 * MathF.PI,
                5000);
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
