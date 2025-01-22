using System.Drawing;

namespace GraphicsDLL
{
    public static class ExtensionGraphics
    {
        public static void DrawLineDDA(this Graphics g, Pen pen, int x0, int y0, int x1, int y1)
        {
            float dx = x1 - x0;
            float dy = y1 - y0;
            float length = Math.Abs(dx);
            if (Math.Abs(dy) > length)
                length = Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float x = x0, y = y0;
            g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
            for (int i = 0; i < length; i++)
            {
                x += incX;
                y += incY;
                g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
            }
        }
    
        public static void ClipCS(this Graphics g, Pen pen,
            PointF p0, PointF p1, RectangleF win)
        {
            byte code0 = p0.OutCode(win);
            byte code1 = p1.OutCode(win);

            bool accept = false;

            while (true)
            {
                if ((code0 | code1) == CohenSutherlandHelper.INSIDE)
                {
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != CohenSutherlandHelper.INSIDE)
                {
                    break;
                }
                else
                {
                    byte code = code0 != CohenSutherlandHelper.INSIDE ? code0 : code1;

                    float x = 0, y = 0;
                    if ((code & CohenSutherlandHelper.LEFT) != 0)
                    {
                        x = win.Left;
                        y = p0.Y + (p1.Y - p0.Y) * (win.Left - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & CohenSutherlandHelper.RIGHT) != 0)
                    {
                        x = win.Right;
                        y = p0.Y + (p1.Y - p0.Y) * (win.Right - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & CohenSutherlandHelper.TOP) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (win.Top - p0.Y) / (p1.Y - p0.Y);
                        y = win.Top;
                    }
                    else if ((code & CohenSutherlandHelper.BOTTOM) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (win.Bottom - p0.Y) / (p1.Y - p0.Y);
                        y = win.Bottom;
                    }
                    else break;

                    if (code == code0)
                    {
                        p0.X = x;
                        p0.Y = y;
                        code0 = p0.OutCode(win);
                    }
                    else
                    {
                        p1.X = x;
                        p1.Y = y;
                        code1 = p1.OutCode(win);
                    }

                }
            }

            if (accept)
                g.DrawLine(pen, p0, p1);
        }

        public delegate bool StringToBool(string s);
        public delegate float RtoR(float x);
        public static void DrawParametricCurve(this Graphics g,
            Pen pen,
            RtoR x, RtoR y,
            float a, float b,
            int n = 500)
        {
            if (b <= a)
                throw new Exception("Wrong interval!");

            float t = a;
            float h = (b - a) / n;
            PointF p0 = new PointF(x(t), y(t));
            while(t < b)
            {
                t += h;
                PointF p1 = new PointF(x(t), y(t));
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }
    }
}
