using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        Vector2F p0, p1, p2, p3;

        public Form1()
        {
            InitializeComponent();
            p0 = new Vector2F(50, canvas.Height - 50);
            p1 = new Vector2F(100, 50);
            p2 = new Vector2F(canvas.Width - 100, 50);
            p3 = new Vector2F(canvas.Width - 50, canvas.Height - 50);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawPointF(Pens.Black, Brushes.White, new PointF(p0.x, p0.y));
            g.DrawPointF(Pens.Black, Brushes.White, new PointF(p1.x, p1.y));
            g.DrawPointF(Pens.Black, Brushes.White, new PointF(p2.x, p2.y));
            g.DrawPointF(Pens.Black, Brushes.White, new PointF(p3.x, p3.y));
            g.DrawLine(Pens.Black, p0.x, p0.y, p1.x, p1.y);
            g.DrawLine(Pens.Black, p2.x, p2.y, p1.x, p1.y);
            g.DrawLine(Pens.Black, p3.x, p3.y, p2.x, p2.y);
            Bezier3 curve = new Bezier3(p0, p1, p2, p3);
            g.DrawBezier3(new Pen(Color.Blue, 2), curve);
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
