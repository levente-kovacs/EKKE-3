using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen = new Pen(Color.Red, 3);

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawParametricCurve(pen,
                t => 100 * MathF.Cos(3 * t) * MathF.Sin(t) + canvas.Width / 2,
                t => 100 * MathF.Sin(2 * t) + canvas.Height / 2,
                0, 2 * MathF.PI);
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
