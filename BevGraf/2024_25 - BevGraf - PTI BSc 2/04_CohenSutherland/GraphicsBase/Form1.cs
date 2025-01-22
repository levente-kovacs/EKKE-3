using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF p0 = new PointF(100, 100);
        PointF p1 = new PointF(300, 120);
        int grabbed = -1;
        RectangleF window = new RectangleF(80, 90, 500, 250);

        Pen pWin = new Pen(Color.Black, 3f);
        Pen pLineFull = new Pen(Color.Gray);
        Pen pLineIn = new Pen(Color.Red, 2f);

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawLine(pLineFull, p0, p1);
            g.DrawRectangle(pWin, window);
            g.ClipCS(pLineIn, window, p0, p1);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (p0.IsGrabbedBy(e.Location))
                grabbed = 0;
            else if (p1.IsGrabbedBy(e.Location))
                grabbed = 1;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                switch (grabbed)
                {
                    case 0: p0 = e.Location; break;
                    case 1: p1 = e.Location; break;
                    default: break;
                }
                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
