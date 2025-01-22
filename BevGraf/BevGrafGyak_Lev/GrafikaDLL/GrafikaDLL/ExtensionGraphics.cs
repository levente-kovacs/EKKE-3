using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public static class ExtensionGraphics
    {
        private static void DrawPixel(this Graphics g,
            Pen pen, int x, int y)
        {
            g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
        }
        private static void DrawPixel(this Graphics g,
            Color color, int x, int y)
        {
            g.DrawRectangle(new Pen(color), x, y, 0.5f, 0.5f);
        }

        public static void DrawLineDDA(this Graphics g,
            Pen pen, int x1, int y1, int x2, int y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float length = Math.Abs(dx);
            if (Math.Abs(dy) > dx)
                length = Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float x = x1, y = y1;
            g.DrawPixel(pen, (int)x, (int)y);
            for (int i = 0; i < length; i++)
            {
                x += incX;
                y += incY;
                g.DrawPixel(pen, (int)x, (int)y);
            }
        }
        public static void DrawLineDDA(this Graphics g,
            Color c1, Color c2, int x1, int y1, int x2, int y2)
        {
            float dx = x2 - x1;
            float dy = y2 - y1;
            float dR = c2.R - c1.R;
            float dG = c2.G - c1.G;
            float dB = c2.B - c1.B;
            float length = Math.Abs(dx);
            if (Math.Abs(dy) > dx)
                length = Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float incR = dR / length;
            float incG = dG / length;
            float incB = dB / length;
            float x = x1, y = y1;
            float R = c1.R, G = c1.G, B = c1.B;
            g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), (int)x, (int)y);
            for (int i = 0; i < length; i++)
            {
                x += incX; y += incY;
                R += incR; G += incG; B += incB;
                g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), (int)x, (int)y);
            }
        }
        public static void DrawLineDDA(this Graphics g,
           Color[] colors, int x1, int y1, int x2, int y2)
        {
            throw new ProjectNotImplementedException();
        }
        public static void DrawLineMidPoint45(this Graphics g,
            Pen pen, int x1, int y1, int x2, int y2)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int d = 2 * dy - dx;
            int x = x1, y = y1;
            for (int i = 0; i < dx; i++)
            {
                g.DrawPixel(pen, x, y);
                if (d > 0)
                {
                    y++;
                    d += 2 * (dy - dx);
                }
                else
                {
                    d += 2 * dy;
                }
                x++;
            }
        }
        public static void DrawLineMidPoint(this Graphics g,
            Pen pen, int x1, int y1, int x2, int y2)
        {
            throw new HomeworkNotImplementedException();
        }
        public static void DrawLineMidPoint(this Graphics g,
            Color c1, Color c2, int x1, int y1, int x2, int y2)
        {
            throw new HomeworkNotImplementedException();
        }
        public static void DrawLineMidPoint(this Graphics g,
           Color[] colors, int x1, int y1, int x2, int y2)
        {
            throw new ProjectNotImplementedException();
        }

        private static void DrawCirclePoints(this Graphics g,
            Pen pen, int x, int y)
        {
            g.DrawPixel(pen, -x, -y);
            g.DrawPixel(pen, -x, +y);
            g.DrawPixel(pen, +x, -y);
            g.DrawPixel(pen, +x, +y);
            g.DrawPixel(pen, -y, -x);
            g.DrawPixel(pen, -y, +x);
            g.DrawPixel(pen, +y, -x);
            g.DrawPixel(pen, +y, +x);
        }
        private static void DrawCirclePoints(this Graphics g,
            Pen pen, Point c, int x, int y)
        {
            throw new HomeworkNotImplementedException();
        }
        public static void DrawCircle(this Graphics g,
            Pen pen, int r)
        {
            int x = 0;
            int y = r;
            g.DrawCirclePoints(pen, x, y);
            int h = 1 - r;
            while (y > x)
            {
                if (h < 0)
                {
                    h += 2 * x + 3;
                }
                else
                {
                    h += 2 * (x - y) + 5;
                    y--;
                }
                x++;
                g.DrawCirclePoints(pen, x, y);
            }
        }
        public static void DrawCircle(this Graphics g,
            Pen pen, Point c, int r)
        {
            throw new HomeworkNotImplementedException();
        }
        private static void DrawCircle(this Graphics g,
            Color c1, Color c2, Point c, int r)
        {
            throw new ProjectNotImplementedException();
        }
        private static void DrawCircle(this Graphics g,
            Color[] colors, Point c, int r)
        {
            if (colors.Length != 8)
                throw new Exception();

            throw new ProjectNotImplementedException();
        }

        private const byte INSIDE = 0;
        private const byte TOP = 1;
        private const byte RIGHT = 2;
        private const byte BOTTOM = 4;
        private const byte LEFT = 8;

        private static byte OutCode(Rectangle win, PointF p)
        {
            byte code = INSIDE;

            if (p.X < win.Left) code |= LEFT;
            else if (win.Right < p.X) code |= RIGHT;

            if (p.Y < win.Top) code |= TOP;
            else if (win.Bottom < p.Y) code |= BOTTOM;

            return code;
        }
        public static void ClipCS(this Graphics g,
            Pen pen, Rectangle win, PointF p1, PointF p2)
        {
            byte code1 = OutCode(win, p1);
            byte code2 = OutCode(win, p2);
            bool accept = false;
            while (true)
            {
                if ((code1 | code2) == INSIDE)
                {
                    accept = true;
                    break;
                }
                else if ((code1 & code2) != INSIDE)
                {
                    break;
                }
                else
                {
                    byte code = code1 != INSIDE ? code1 : code2;
                    float x = 0, y = 0;
                    if ((code & TOP) != INSIDE)
                    {
                        x = p1.X + (p2.X - p1.X) * (win.Top - p1.Y) / (p2.Y - p1.Y);
                        y = win.Top;
                    }
                    else if ((code & BOTTOM) != INSIDE)
                    {
                        x = p1.X + (p2.X - p1.X) * (win.Bottom - p1.Y) / (p2.Y - p1.Y);
                        y = win.Bottom;
                    }
                    else if ((code & LEFT) != INSIDE)
                    {
                        x = win.Left;
                        y = p1.Y + (p2.Y - p1.Y) * (win.Left - p1.X) / (p2.X - p1.X);
                    }
                    else if ((code & RIGHT) != INSIDE)
                    {
                        x = win.Right;
                        y = p1.Y + (p2.Y - p1.Y) * (win.Right - p1.X) / (p2.X - p1.X);
                    }
                    else break;

                    if (code == code1)
                    {
                        p1.X = x;
                        p1.Y = y;
                        code1 = OutCode(win, p1);
                    }
                    else
                    {
                        p2.X = x;
                        p2.Y = y;
                        code2 = OutCode(win, p2);
                    }
                }
            }
            if (accept)
                g.DrawLine(pen, p1, p2);
        }
        public static void ClipCS(this Graphics g,
            Pen pen, Rectangle[] win, PointF p1, PointF p2)
        {
            throw new ProjectNotImplementedException();
        }
        public static void ClipCocavePolygon(this Graphics g,
            Pen pen, Point[][] polygon, PointF p1, PointF p2)
        {
            throw new ProjectNotImplementedException();
        }

        public delegate double RtoR(double x);
        public static void DrawParametricCurve(this Graphics g,
            Pen pen, RtoR X, RtoR Y, double a, double b, int n = 500)
        {
            double t = a;
            double h = (b - a) / n;
            Vector2 v0 = new Vector2(X(t), Y(t));
            Vector2 v1;
            while (t < b)
            {
                t += h;
                v1 = new Vector2(X(t), Y(t));
                g.DrawLine(pen, (float)v0.x, (float)v0.y, (float)v1.x, (float)v1.y);
                v0 = v1;
            }
        }

        private static double H0(double t) { return 2 * t * t * t - 3 * t * t + 1; }
        private static double H1(double t) { return -2 * t * t * t + 3 * t * t; }
        private static double H2(double t) { return t * t * t - 2 * t * t + t; }
        private static double H3(double t) { return t * t * t - t * t; }

        public static void DrawHermiteArc(this Graphics g,
            Pen pen, Vector2 p0, Vector2 p1, Vector2 t0, Vector2 t1, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => H0(t) * p0.x + H1(t) * p1.x + H2(t) * t0.x + H3(t) * t1.x,
                t => H0(t) * p0.y + H1(t) * p1.y + H2(t) * t0.y + H3(t) * t1.y,
                0.0, 1.0, n);
        }
        public static void DrawHermiteCurve(this Graphics g,
            Color c0, Color c1, HermiteArc[] arcs)
        {
            throw new ProjectNotImplementedException();
        }

        private static double B0(double t) { return (1 - t) * (1 - t) * (1 - t); }
        private static double B1(double t) { return 3 * (1 - t) * (1 - t) * t; }
        private static double B2(double t) { return 3 * (1 - t) * t * t; }
        private static double B3(double t) { return t * t * t; }

        private static double B0(double t, double p) { return 0; }
        //

        public static void DrawBezier3(this Graphics g, Pen pen,
            Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => B0(t) * p0.x + B1(t) * p1.x + B2(t) * p2.x + B3(t) * p3.x,
                t => B0(t) * p0.y + B1(t) * p1.y + B2(t) * p2.y + B3(t) * p3.y,
                0, 1, n);
        }
        public static void DrawBezierP(this Graphics g, Pen pen, double p,
            Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, int n = 500)
        {
            throw new ProjectNotImplementedException();
        }
        public static void DrawBezierN(this Graphics g, Pen pen,
            List<Vector2> v, int n = 500)
        {
            throw new ProjectNotImplementedException();
        }
        public static void DrawBezierNdeCasteljouRecursive(this Graphics g, Pen pen,
            List<Vector2> v, int n = 500)
        {
            throw new ProjectNotImplementedException();
        }
        public static void DrawBezierNdeCasteljouIterative(this Graphics g, Pen pen,
            List<Vector2> v, int n = 500)
        {
            throw new ProjectNotImplementedException();
        }
        public static void DrawBSpline(this Graphics g, Pen pen,
            Vector2 p0, Vector2 p1, Vector2 p2, Vector2 p3, int n = 500)
        {
            throw new HomeworkNotImplementedException();
        }
        public static void DrawBSpline(this Graphics g, Pen pen,
            List<Vector2> v, CurveType curveType = CurveType.Standard, int n = 500)
        {
            throw new ProjectNotImplementedException();
        }

        //3D graphics
        public static Matrix4 projection;
        public static Matrix4 transformation;
        public static Vector2 centerOfCanvas = new Vector2(0, 0);

        public static void PushMatrix(Matrix4 matrix)
        {
            transformation = matrix * transformation;
        }
        public static void ClearMatrix()
        {
            transformation.LoadIdentity();
        }

        static ExtensionGraphics()
        {
            projection = Matrix4.Projection.Perpendicular();
            transformation = new Matrix4();
            transformation.LoadIdentity();
        }

        public static void DrawParametricCurve3D(this Graphics g, Pen pen,
            RtoR x, RtoR y, RtoR z,
            double a, double b, int n = 500)
        {
            double t = a;
            double h = (b - a) / n;
            Vector4 v0 = new Vector4(x(t), y(t), z(t));
            Vector4 v1, pv0, pv1;
            while (t < b)
            {
                t += h;
                v1 = new Vector4(x(t), y(t), z(t));
                pv0 = projection * (transformation * v0);
                pv1 = projection * (transformation * v1);
                pv0.ToCartesian();
                pv1.ToCartesian();
                pv0 += centerOfCanvas;
                pv1 += centerOfCanvas;
                g.DrawLine(pen, (float)pv0.x, (float)pv0.y, (float)pv1.x, (float)pv1.y);
                v0 = v1;
            }
        }

        public delegate double RRtoR(double x, double y);

        public static void DrawParametricSurface(this Graphics g, Pen pen,
            RRtoR x, RRtoR y, RRtoR z,
            double a, double b,
            double c, double d,
            int n = 20, int m = 20)
        {
            double v = c;
            double h1 = (d - c) / n;
            while (v < d)
            {
                g.DrawParametricCurve3D(pen,
                    U => x(U, v),
                    U => y(U, v),
                    U => z(U, v),
                    a, b, n);
                v += h1;
            }

            double u = a;
            double h2 = (b - a) / m;
            while (u < b)
            {
                g.DrawParametricCurve3D(pen,
                    V => x(u, V),
                    V => y(u, V),
                    V => z(u, V),
                    c, d, m);
                u += h2;
            }
        }

        public static void DrawParametricSurfaceWithPointsAndNormals(this Graphics g, Pen pen,
            RRtoR x, RRtoR y, RRtoR z,
            double a, double b,
            double c, double d,
            int n = 20, int m = 20)
        {
            throw new ProjectNotImplementedException();
        }

        public static void DrawBRep(this Graphics g, Pen pen, BRep model)
        {
            foreach (Triangle triangle in model.triangles)
            {
                Vector4 pA = projection * (transformation * triangle.a);
                pA.ToCartesian();
                pA += centerOfCanvas;

                Vector4 pB = projection * (transformation * triangle.b);
                pB.ToCartesian();
                pB += centerOfCanvas;

                Vector4 pC = projection * (transformation * triangle.c);
                pC.ToCartesian();
                pC += centerOfCanvas;

                g.DrawLine(pen, (float)pA.x, (float)pA.y, (float)pB.x, (float)pB.y);
                g.DrawLine(pen, (float)pC.x, (float)pC.y, (float)pB.x, (float)pB.y);
                g.DrawLine(pen, (float)pA.x, (float)pA.y, (float)pC.x, (float)pC.y);
            }
        }

        public static void DrawBRepWithBackfaceCulling(this Graphics g, Pen pen, BRep model)
        {
            throw new ProjectNotImplementedException();
        }
        public static void FillBRepWithFlatShading(this Graphics g, Pen pen, BRep model)
        {
            throw new ProjectNotImplementedException();
        }
        public static void FillBRepWithGouraudShading(this Graphics g, Pen pen, BRep model)
        {
            throw new ProjectNotImplementedException();
        }
        public static void FillBRepWithPhongShading(this Graphics g, Pen pen, BRep model)
        {
            throw new ProjectNotImplementedException();
        }

        public static void DrawCoonsPatch(Pen pen,
            ParametricCurve3D a1,
            ParametricCurve3D a2,
            ParametricCurve3D b1,
            ParametricCurve3D b2)
        {
            throw new ProjectNotImplementedException();
        }

        //2D subdivision
        public static void DrawCornerCutting(this Graphics g, Pen pen,
            List<Vector2> p, int level)
        {
            throw new ProjectNotImplementedException();
        }
    }
}
