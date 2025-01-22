using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp;
       

        public Form1()
        {
            InitializeComponent();
            bmp = new Bitmap("pre2_03.png");
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            canvas.Image = bmp;
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            bmp = bmp.SupersamplingV1();
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
           
        }
    }
}
