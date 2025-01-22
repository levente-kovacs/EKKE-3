using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point p = new Point(690, 200);
        bool isGrabbed = false;
        int dx, dy;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLine(Pens.Black, 100, 200, 700, 300);
            g.DrawLine(new Pen(Color.Red, 3), canvas.Width / 2, 0, canvas.Width / 2, canvas.Height);

            //g.FillRectangle(Brushes.Yellow, 200, 120, 400, 230);
            //g.DrawRectangle(Pens.Black, 200, 120, 400, 230);
            g.DrawAndFillRectangle(Pens.Black, Brushes.Yellow, 200, 120, 400, 230);

            g.FillEllipse(new SolidBrush(Color.Violet), 200, 120, 400, 230);
            g.DrawEllipse(Pens.Green, 200, 120, 400, 230);

            Point o = new Point(660, 370);
            int r = 120;
            g.DrawEllipse(Pens.Blue, o.X - r, o.Y - r, 2 * r, 2 * r);
            g.DrawRectangle(Pens.Black, o.X, o.Y, 0.5f, 0.5f);
            
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(j, i, 102)), 
                        p.X + i, p.Y + j, 0.5f, 0.5f);
                }
            }
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (p.X <= e.X && e.X < p.X + 256 &&
                p.Y <= e.Y && e.Y < p.Y + 256)
            {
                isGrabbed = true;
                dx = e.X - p.X;
                dy = e.Y - p.Y;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isGrabbed)
            {
                p.X = e.X - dx;
                p.Y = e.Y - dy;
                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isGrabbed = false;
        }
    }
}
