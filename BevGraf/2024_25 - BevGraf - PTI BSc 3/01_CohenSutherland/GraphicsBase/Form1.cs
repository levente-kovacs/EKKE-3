using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        RectangleF win = new RectangleF(50, 80, 450, 260);
        //PointF p0 = new PointF(100, 100);
        //PointF p1 = new PointF(400, 200);
        PointF[] p = new PointF[10];
        Random rnd = new Random();
        Pen penWin = new Pen(Color.Black, 3f);
        Pen penFull = new Pen(Color.Gray, 1f);
        Pen penIn = new Pen(Color.Magenta, 2f);
        int grabbed = -1;

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < p.Length; i++)
            {
                p[i] = new PointF(rnd.Next(canvas.Width), rnd.Next(canvas.Height));
            }
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < p.Length - 1; i++)
                g.DrawLine(penFull, p[i], p[i + 1]);
            g.DrawLine(penFull, p[p.Length - 1], p[0]);

            //g.DrawLine(penFull, p0, p1);
            g.DrawRectangle(penWin, win);
            //g.ClipCS(penIn, p0, p1, win);

            for (int i = 0; i < p.Length - 1; i++)
                g.ClipCS(penIn, p[i], p[i + 1], win);
            g.ClipCS(penIn, p[p.Length - 1], p[0], win);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < p.Length; i++)
            {
                if (p[i].IsGrabbedBY(e.Location))
                    grabbed = i;
            }
            //if (p0.IsGrabbedBY(e.Location))
            //    grabbed = 0;
            //else if (p1.IsGrabbedBY(e.Location))
            //    grabbed = 1;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                //switch (grabbed)
                //{
                //    case 0: p0 = e.Location; break;
                //    case 1: p1 = e.Location; break;
                //    default: break;
                //}
                p[grabbed] = e.Location;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
