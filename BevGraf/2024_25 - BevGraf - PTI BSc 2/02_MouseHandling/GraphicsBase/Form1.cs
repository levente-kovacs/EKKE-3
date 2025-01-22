namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Point p0 = new Point(100, 100);
        int s = 200;
        int dx, dy;
        Brush brush = Brushes.Blue;
        bool isGrabbed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.FillRectangle(brush, p0.X, p0.Y, s, s);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (p0.X <= e.X && e.X < p0.X + s &&
                p0.Y <= e.Y && e.Y < p0.Y + s)
            {
                dx = e.X - p0.X;
                dy = e.Y - p0.Y;
                isGrabbed = true; 
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isGrabbed)
            {
                p0 = new Point(e.X - dx, e.Y - dy);
                if (p0.X < 0) p0.X = 0;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isGrabbed = false;
        }
    }
}
