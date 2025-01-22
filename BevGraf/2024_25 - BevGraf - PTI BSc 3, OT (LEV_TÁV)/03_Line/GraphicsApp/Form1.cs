using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF p0, p1;
        int grabbed = -1;

        public Form1()
        {
            InitializeComponent();
            p0 = new PointF(50, 50);
            p1 = new PointF(canvas.Width - 50, canvas.Height - 50);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawPointF(Pens.Red, new SolidBrush(canvas.BackColor), p0);
            g.DrawPointF(Pens.Green, new SolidBrush(canvas.BackColor), p1);
            
            g.DrawLineDDA(Color.Red, Color.Green, p0, p1);
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (p0.IsGrabbedBy(e.Location))
                grabbed = 0;
            else if (p1.IsGrabbedBy(e.Location))
                grabbed = 1;
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                switch (grabbed)
                {
                    case 0: p0 = e.Location; break;
                    case 1: p1 = e.Location; break;
                    default: break;
                }

                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }
    }
}
