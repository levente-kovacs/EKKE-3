using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Vector2F p0 = new Vector2F(100, 400),
                 t0 = new Vector2F(400, 30),
                 p1 = new Vector2F(600, 200),
                 t1 = new Vector2F(800, 500);
        Pen penCurve = new Pen(Color.Blue, 3f);

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawRectangle(Pens.Black, p0.x - 5, p0.y - 5, 10, 10);
            g.DrawRectangle(Pens.Black, p1.x - 5, p1.y - 5, 10, 10);
            g.DrawLine(Pens.Black, p0.x, p0.y, t0.x, t0.y);
            g.DrawLine(Pens.Black, p1.x, p1.y, t1.x, t1.y);
            float s = 2;
            Hermite arc = new Hermite(p0, p1, s * (t0 - p0), s * (t1 - p1));
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
