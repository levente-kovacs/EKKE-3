using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF p0;

        public Form1()
        {
            InitializeComponent();
            p0 = new PointF(canvas.Width / 2, canvas.Height / 2);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLine(Pens.Black, 100, 200, canvas.Width, canvas.Height);
            g.DrawLine(new Pen(Color.Red, 3.4f), 
                p0.X, 0, 
                p0.X, canvas.Height);

            g.FillRectangle(new SolidBrush(Color.FromArgb(255, 255, 0)),
                p0.X + 50, p0.Y - 120, 100, 200);
            g.DrawRectangle(Pens.Black,
                p0.X + 50, p0.Y - 120, 100, 200);
            g.FillEllipse(new SolidBrush(Color.FromArgb(0, 255, 255)),
               p0.X + 50, p0.Y - 120, 100, 200);
            g.DrawEllipse(Pens.Black,
                p0.X + 50, p0.Y - 120, 100, 200);

            p0 = new PointF(p0.X - 100, p0.Y - 100);
            float r = 100;
            g.DrawEllipse(Pens.Red,
                p0.X - r, p0.Y - r, 2 * r, 2 * r);
            //g.DrawRectangle(Pens.Black, p0.X, p0.Y, 0.5f, 0.5f);
            g.DrawPixel(Pens.Blue, p0.X, p0.Y);

            p0 = new PointF(p0.X + 50, p0.Y + 50);
            for (int i = 0; i < 256; i++)
            {
                for (int j = 0; j < 256; j++)
                {
                    g.DrawPixel(Color.FromArgb(255 - j, i, 0),
                        p0.X + i, p0.Y + j);
                }
            }
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
