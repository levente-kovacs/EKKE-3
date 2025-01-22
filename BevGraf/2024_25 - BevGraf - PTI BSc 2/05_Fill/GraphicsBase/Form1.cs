using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
        PointF p0, p1;
        bool isDrawing = false;

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap(canvas.Width, canvas.Height);
            for (int y = 0; y < bmp.Height; y++)
                for (int x = 0; x < bmp.Width; x++)
                    bmp.SetPixel(x, y, Color.White);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            canvas.Image = bmp;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    isDrawing = true;
                    p0 = e.Location;
                    bmp.SetPixel((int)p0.X, (int)p0.Y, Color.Black);
                    canvas.Invalidate();
                    break;
                case MouseButtons.Right:
                    bmp.FillScanLine(Color.Black, Color.Yellow);
                    break;
                default:
                    break;
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawing)
            {
                p1 = e.Location;
                bmp.SetLine(p0, p1, Color.Black);
                p0 = p1;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            isDrawing = false;
        }
    }
}
