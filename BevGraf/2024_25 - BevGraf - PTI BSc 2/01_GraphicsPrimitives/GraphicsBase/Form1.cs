namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen pen;
        Point p0, p1;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLine(Pens.Black, 20, 45, 230, 120);
            pen = new Pen(Color.Blue, 3.12f);
            p0 = new Point(canvas.Width / 2, 0);
            p1 = new Point(canvas.Width / 2, canvas.Height);
            g.DrawLine(pen, p0, p1);
            pen = new Pen(Color.FromArgb(128, 145, 207, 12), 3.12f);
            g.DrawLine(pen, 0, 0, canvas.Width, canvas.Height);

            g.FillRectangle(Brushes.Yellow, 100, 100, 300, 100);
            g.DrawRectangle(Pens.Black, 100, 100, 300, 100);

            g.FillEllipse(Brushes.Red, 100, 100, 300, 100);
            g.DrawEllipse(Pens.Blue, 100, 100, 300, 100);

            p0 = new Point(450, 200);
            float r = 120;
            g.DrawEllipse(pen, p0.X - r, p0.Y - r, 2 * r, 2 * r);
            g.DrawLine(Pens.Black, p0.X, p0.Y, p0.X + 0.5f, p0.Y + 0.5f);

            p0 = new Point(70, 130);
            for (int y = 0; y < 256; y++)
            {
                for (int x = 0; x < 256; x++)
                {
                    g.DrawRectangle(new Pen(Color.FromArgb(x, y, 0)), 
                        p0.X + x, p0.Y + y, 0.5f, 0.5f);
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
