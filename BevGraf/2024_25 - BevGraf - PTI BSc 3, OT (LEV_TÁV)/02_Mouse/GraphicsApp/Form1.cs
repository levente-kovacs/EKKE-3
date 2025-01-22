using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        RectangleF rect = new RectangleF(100, 200, 200, 200);
        bool isGrabbed = false;
        float dx, dy;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.FillRectangle(Brushes.Chocolate, rect);
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (rect.Left <= e.X && e.X < rect.Right &&
                rect.Top <= e.Y && e.Y < rect.Bottom)
            {
                isGrabbed = true;
                dx = e.X - rect.Left;
                dy = e.Y - rect.Top;
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isGrabbed)
            {
                rect.X = e.X - dx;
                rect.Y = e.Y - dy;

                if (rect.X < 0) rect.X = 0;
                if (canvas.Width <= rect.Right) rect.X = canvas.Width - rect.Width;

                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isGrabbed = false;
        }
    }
}
