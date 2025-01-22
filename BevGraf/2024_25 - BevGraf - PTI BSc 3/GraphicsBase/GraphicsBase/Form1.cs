using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLineDDA(Pens.Black, 100, 100, 400, 200);
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
