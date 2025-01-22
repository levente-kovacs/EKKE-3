using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        Vector2F p0, p1, t0, t1;
        Pen penCurve = new Pen(Color.Blue, 2f);

        public Form1()
        {
            InitializeComponent();
            p0 = new Vector2F(50, canvas.Height - 50);
            t0 = new Vector2F(canvas.Width / 2 - 50, 50);
            p1 = new Vector2F(canvas.Width / 2 + 50, 270);
            t1 = new Vector2F(canvas.Width - 50, canvas.Height - 50);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawPointF(Pens.Black, Brushes.White, new PointF(p0.x, p0.y));
            g.DrawPointF(Pens.Black, Brushes.White, new PointF(p1.x, p1.y));
            g.DrawLine(Pens.Black, new PointF(p0.x, p0.y), new PointF(t0.x, t0.y));
            g.DrawLine(Pens.Black, new PointF(p1.x, p1.y), new PointF(t1.x, t1.y));
            float lambda = 1;
            HermiteArc arc = new HermiteArc(p0, p1, 
                (t0 - p0) * lambda, 
                (t1 - p1) * lambda);
            g.DrawHermiteArc(penCurve, arc);
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
