using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        Bitmap bmp; //még inicializálni kell, stb...

        public Form1()
        {
            InitializeComponent();
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            float r = 300;
            g.DrawParametricCurve(Pens.Black,
                t => r * MathF.Cos(t) + canvas.Width / 2,
                t => r * MathF.Sin(t) + canvas.Height / 2,
                0f, 2 * MathF.PI);
            //Project: Epicycloid úgy, hogy a és b értékek csúszkán legyenek változtathatók

            //bmp.DrawImplicitCurve(Color.Red,
            //    (x, y) => (x - canvas.Width / 2) * (x - canvas.Width / 2) + 
            //              (y - canvas.Height / 2) * (y - canvas.Height / 2) -
            //              10000);
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
