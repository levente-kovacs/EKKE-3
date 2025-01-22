using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;

        Vector2F p0, p1, t0, t1;
        float lambda = 1f;

        public Form1()
        {
            InitializeComponent();
            p0 = new Vector2F(100, canvas.Height - 100);
            t0 = new Vector2F(200, 200);
            p1 = new Vector2F(canvas.Width / 2 + 50, canvas.Height / 2);
            t1 = new Vector2F(canvas.Width - 200, 600);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawRectangle(Pens.Black, p0.x - 5, p0.y - 5, 10, 10);
            g.DrawRectangle(Pens.Black, p1.x - 5, p1.y - 5, 10, 10);
            g.DrawLine(Pens.Black, p0, t0);
            g.DrawLine(Pens.Black, p1, t1);
            g.DrawHermiteArc(new Pen(Color.Blue, 3f),
                new Hermite(p0, p1, 
                (t0 - p0) * lambda, 
                (t1 - p1) * lambda));
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

        private void sbLambda_ValueChanged(object sender, EventArgs e)
        {
            lambda = sbLambda.Value / 100f;
            canvas.Invalidate();
        }
    }
}
