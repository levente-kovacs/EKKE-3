namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;

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
            
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {

        }
    }
}
