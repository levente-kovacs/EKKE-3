using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF p0, p1;
        RectangleF window;
        int grabbed = -1;

        Pen penLineFull = new Pen(Color.Gray, 1);
        Pen penLineIn = new Pen(Color.Green, 2);
        Pen penLineWindow = new Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
            p0 = new PointF(50, 50);
            p1 = new PointF(canvas.Width - 50, canvas.Height - 50);
            window = new RectangleF(100, 100, canvas.Width - 200, canvas.Height - 200);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLine(penLineFull, p0, p1);
            g.DrawRectangle(penLineWindow, window);
            g.ClipCS(penLineIn, p0, p1, window);
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
