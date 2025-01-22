using GraphicsDLL;

namespace GraphicsBase
{
    public partial class Form1 : Form
    {
        Graphics g;
        float lambda = 1f;
        List<Vector2F> v = new List<Vector2F>();
        int grabbed = -1;

        public Form1()
        {
            InitializeComponent();

        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;

            for (int i = 0; i < v.Count; i += 2)
                g.DrawRectangle(Pens.Black, v[i].x - 5, v[i].y - 5, 10, 10);
            for (int i = 0; i < v.Count - 1; i += 2)
                g.DrawLine(Pens.Black, v[i], v[i + 1]);

            for (int i = 0; i < v.Count - 3; i += 2)
            {
                g.DrawHermiteArc(new Pen(Color.Blue, 3f),
                    new Hermite(v[i],
                                v[i + 2],
                                lambda * (v[i + 1] - v[i]),
                                lambda * (v[i + 3] - v[i + 2])));
            }

            if (cbIsClosed.Checked && v.Count > 3)
                g.DrawHermiteArc(new Pen(Color.Blue, 3f),
                    new Hermite(v[v.Count - 2],
                                v[0],
                                lambda * (v[v.Count - 1] - v[v.Count - 2]),
                                lambda * (v[1] - v[0])));
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < v.Count; i++)
            {
                if (v[i].IsGrabbedBy(e.Location))
                {
                    grabbed = i;
                    break;
                }
            }
            if (grabbed == -1)
            {
                v.Add(new Vector2F(e.X, e.Y));
                v.Add(new Vector2F(e.X, e.Y));
                grabbed = v.Count - 1;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (grabbed != -1)
            {
                v[grabbed].x = e.X;
                v[grabbed].y = e.Y;
                canvas.Invalidate();
            }
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            grabbed = -1;
        }

        private void sbLambda_ValueChanged(object sender, EventArgs e)
        {
            lambda = sbLambda.Value / 100f;
            canvas.Invalidate();
        }

        private void cbIsClosed_CheckedChanged(object sender, EventArgs e)
        {
            canvas.Invalidate();
        }
    }
}
