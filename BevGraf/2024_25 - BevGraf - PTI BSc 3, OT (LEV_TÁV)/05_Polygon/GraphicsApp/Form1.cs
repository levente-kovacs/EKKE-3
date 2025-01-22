using GraphicsDLL;

namespace GraphicsApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF p0, p1;
        List<PointF> polygon = new List<PointF>();
        int grabbed = -1;
        int grabbedPoly = -1;

        Pen penLineFull = new Pen(Color.Gray, 1);
        Pen penLineIn = new Pen(Color.Green, 2);
        Pen penLineWindow = new Pen(Color.Black, 3);

        public Form1()
        {
            InitializeComponent();
            p0 = new PointF(50, 50);
            p1 = new PointF(canvas.Width - 50, canvas.Height - 50);

        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            g.DrawLine(penLineFull, p0, p1);

            for (int i = 0; i < polygon.Count; i++)
                g.DrawPointF(penLineWindow, Brushes.White, polygon[i]);
            for (int i = 0; i < polygon.Count - 1; i++)
                g.DrawLine(penLineWindow, polygon[i], polygon[i + 1]);
            if (polygon.Count > 2)
                g.DrawLine(penLineWindow, polygon[polygon.Count - 1], polygon[0]);
        }
        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (p0.IsGrabbedBy(e.Location))
                grabbed = 0;
            else if (p1.IsGrabbedBy(e.Location))
                grabbed = 1;

            if (grabbed == -1)
            {
                for (int i = 0; i < polygon.Count; i++)
                {
                    if (polygon[i].IsGrabbedBy(e.Location))
                        grabbedPoly = i;
                }

                if (grabbedPoly == -1)
                {
                    polygon.Add(e.Location);
                    grabbedPoly = polygon.Count - 1;
                    canvas.Invalidate();
                }
            }
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
            else if (grabbedPoly != -1)
            {
                polygon[grabbedPoly] = e.Location;
                canvas.Invalidate();
            }
        }
        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
            grabbedPoly = -1;
        }
    }
}
