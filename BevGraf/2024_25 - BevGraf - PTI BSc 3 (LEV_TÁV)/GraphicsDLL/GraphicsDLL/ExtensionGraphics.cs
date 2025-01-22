using System.ComponentModel;
using System.Drawing;

namespace GraphicsDLL
{
    public static class ExtensionGraphics
    {
        #region 2D graphics
        public static void DrawPixel(this Graphics g, Pen pen, float x, float y)
        {
            g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
        }
        public static void DrawPixel(this Graphics g, Color color, float x, float y)
        {
            g.DrawRectangle(new Pen(color), x, y, 0.5f, 0.5f);
        }

        public static void DrawAndFillRectangle(this Graphics g, Pen pen, Brush brush,
            float x, float y, float width, float height)
        {
            g.FillRectangle(brush, x, y, width, height);
            g.DrawRectangle(pen, x, y, width, height);
        }

        public static void DrawLineDDA(this Graphics g, Pen pen, float x0, float y0, float x1, float y1)
        {
            float dx = x1 - x0;
            float dy = y1 - y0;
            float length = MathF.Abs(dx);
            if (MathF.Abs(dy) > length)
                length = MathF.Abs(dy);

            float x = x0;
            float y = y0;
            float nx = dx / length;
            float ny = dy / length;

            g.DrawPixel(pen, x, y);
            for (int i = 0; i < length; i++)
            {
                x += nx;
                y += ny;
                g.DrawPixel(pen, x, y);
            }
        }
        public static void DrawLineDDA(this Graphics g, Color c0, Color c1, float x0, float y0, float x1, float y1)
        {
            float dx = x1 - x0;
            float dy = y1 - y0;
            float length = MathF.Abs(dx);
            if (MathF.Abs(dy) > length)
                length = MathF.Abs(dy);

            float x = x0;
            float y = y0;
            float nx = dx / length;
            float ny = dy / length;

            float R = c0.R;
            float G = c0.G;
            float B = c0.B;
            float dR = c1.R - c0.R;
            float dG = c1.G - c0.G;
            float dB = c1.B - c0.B;
            float nR = dR / length;
            float nG = dG / length;
            float nB = dB / length;

            g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), x, y);
            for (int i = 0; i < length; i++)
            {
                x += nx;
                y += ny;

                R += nR;
                G += nG;
                B += nB;

                g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), x, y);
            }
        }

        public static void DrawLineMidpointV1(this Graphics g, Pen pen,
            float x0, float y0, float x1, float y1)
        {
            throw new HomeworkException();
        }
        public static void DrawLineMidpointV2(this Graphics g, Pen pen,
            float x0, float y0, float x1, float y1)
        {
            throw new HomeworkException();
        }
        public static void DrawLineMidpointV2(this Graphics g, Color c0, Color c1,
            float x0, float y0, float x1, float y1)
        {
            throw new ProjectException();
        }
        public static void DrawDashedLineMidpointV2(this Graphics g, int dashLength, int spaceLength,
            Color c0, Color c1,
            float x0, float y0, float x1, float y1)
        {
            throw new ProjectException();
        }

        public static void DrawMidPointCircle(this Graphics g, Pen pen,
            float x0, float y0, float r)
        {
            throw new HomeworkException();
        }
        public static void DrawMidPointCircle(this Graphics g, Color c0, Color c1,
            float x0, float y0, float r)
        {
            throw new ProjectException();
        }

        public const byte INSIDE = 0;
        public const byte TOP = 1;
        public const byte RIGHT = 2;
        public const byte BOTTOM = 4;
        public const byte LEFT = 8;
        public static void DrawLineCS(this Graphics g, Pen pen, PointF p0, PointF p1, RectangleF win)
        {
            byte code0 = p0.OutCode(win);
            byte code1 = p1.OutCode(win);
            bool accept = false;
            while (true)
            {
                if ((code0 | code1) == INSIDE)
                {
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != INSIDE)
                {
                    break;
                }
                else
                {
                    byte code = code0 != INSIDE ? code0 : code1;

                    float x = 0, y = 0;
                    if ((code & LEFT) != 0)
                    {
                        x = win.Left;
                        y = p0.Y + (p1.Y - p0.Y) * (win.Left - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & RIGHT) != 0)
                    {
                        x = win.Right;
                        y = p0.Y + (p1.Y - p0.Y) * (win.Right - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & TOP) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (win.Top - p0.Y) / (p1.Y - p0.Y);
                        y = win.Top;
                    }
                    else if ((code & BOTTOM) != 0)
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
        public static void DrawLineCS3D(this Graphics g, Pen pen, Vector3F p0, Vector3F p1, CuboidF win)
        {
            throw new ProjectException();
        }
        public static void DrawLineByClipToConvexPolygon(this Graphics g, Pen pen,
            PointF p0, PointF p1, PointF[] win)
        {
            throw new ProjectException();
        }
        public static void DrawLineByClipToConcavePolygon(this Graphics g, Pen pen,
            PointF p0, PointF p1, PointF[] win)
        {
            throw new HomeworkException();
        }
        public static void DrawLineByClipToConcavePolygon(this Graphics g, Pen pen,
            PointF p0, PointF p1, PointF[][] win)
        {
            throw new ProjectException();
        }

        public delegate float RtoR(float x);
        public static void DrawParametricCurve(this Graphics g, Pen pen,
            RtoR x, RtoR y, float a, float b, int n = 500)
        {
            float t = a;
            float h = (b - a) / n;
            PointF p0 = new PointF(x(t), y(t));
            PointF p1;
            while (t < b)
            {
                t += h;
                p1 = new PointF(x(t), y(t));
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }

        public static void DrawHermiteArc(this Graphics g, Pen pen, Hermite arc)
        {
            g.DrawParametricCurve(pen,
                t => Hermite.H0(t) * arc.p0.x + Hermite.H1(t) * arc.p1.x +
                     Hermite.H2(t) * arc.t0.x + Hermite.H3(t) * arc.t1.x,
                t => Hermite.H0(t) * arc.p0.y + Hermite.H1(t) * arc.p1.y +
                     Hermite.H2(t) * arc.t0.y + Hermite.H3(t) * arc.t1.y,
                0f, 1f);
        }
        public static void DrawHermiteCurve(this Graphics g, Pen pen,
            List<Point> p, List<Point> t, bool closed = false)
        {
            throw new HomeworkException();
        }

        public static void DrawBezier3F(this Graphics g, Pen pen, Bezier3F curve)
        {
            g.DrawParametricCurve(pen,
                t => Bezier3F.B0(t) * curve.p0.x + Bezier3F.B1(t) * curve.p1.x +
                     Bezier3F.B2(t) * curve.p2.x + Bezier3F.B3(t) * curve.p3.x,
                t => Bezier3F.B0(t) * curve.p0.y + Bezier3F.B1(t) * curve.p1.y +
                     Bezier3F.B2(t) * curve.p2.y + Bezier3F.B3(t) * curve.p3.y,
                0f, 1f);
        }
        //public static void DrawBezier3FP(this Graphics g, Pen pen, Bezier3FP curve)
        //{
        //    throw new ProjectException();
        //}
        public static void DrawBezierFN(this Graphics g, Pen pen, BezierFN curve)
        {
            throw new ProjectException();
        }
        public static void DrawBSpline(this Graphics g, Pen pen, BSpline curve)
        {
            throw new ProjectException();
        }

        public static void DrawCornerCutting(this Graphics g, Pen pen, List<Vector2F> v, int level)
        {
            throw new ProjectException();
        }
        public static void DrawLaneRiesenfeldCutting(this Graphics g, Pen pen,
            List<Vector2F> v, float[] mask, int level)
        {
            throw new ProjectException();
        }
        #endregion

        #region 3D graphics
        private const float infiniteDistance = 1000000;
        private static Vector4F centerOfCanvas;
        private static Vector4F camera;
        private static Matrix4F projection;
        private static Matrix4F transformation;

        private static Vector4F O = new Vector4F(0, 0, 0);
        private static Vector4F E1 = new Vector4F(1, 0, 0);
        private static Vector4F E2 = new Vector4F(0, 1, 0);
        private static Vector4F E3 = new Vector4F(0, 0, 1);

        public static Vector4F o { get { return Projection.Project(Transformation.Transform(O)); } }
        public static Vector4F e1 { get { return Projection.Project(Transformation.Transform(E1)); } }
        public static Vector4F e2 { get { return Projection.Project(Transformation.Transform(E2)); } }
        public static Vector4F e3 { get { return Projection.Project(Transformation.Transform(E3)); } }

        static ExtensionGraphics()
        {
            centerOfCanvas = new Vector4F(0, 0, 0);
            projection = Matrix4F.Projection.Perpendicular();
            camera = new Vector4F(0, 0, infiniteDistance);
            transformation = new Matrix4F();
            transformation.LoadIdentity();
        }
        public static void SetCenterOfCanvas(Vector4F centerOfCanvas)
        {
            ExtensionGraphics.centerOfCanvas = centerOfCanvas;
        }

        public static class Projection
        {
            public static void SetParallel(float vx, float vy, float vz)
            {
                ExtensionGraphics.projection = Matrix4F.Projection.Parallel(vx, vy, vz);
                ExtensionGraphics.camera = -infiniteDistance * new Vector4F(vx, vy, vz);
            }
            public static void SetCentral(float d)
            {
                ExtensionGraphics.projection = Matrix4F.Projection.Central(d);
                ExtensionGraphics.camera = new Vector4F(0, 0, d);
            }
            public static Vector4F Project(Vector4F v)
            {
                Vector4F res = ExtensionGraphics.projection * v;
                res.ToCartesian();
                res += centerOfCanvas;
                return res;
            }
        }

        public static class Transformation
        {
            public static void LoadIdentity()
            {
                ExtensionGraphics.transformation.LoadIdentity();
            }
            public static void Push(Matrix4F transformation)
            {
                ExtensionGraphics.transformation = transformation * ExtensionGraphics.transformation;
            }
            public static Vector4F Transform(Vector4F v)
            {
                return ExtensionGraphics.transformation * v;
            }
        }

        public static void DrawParametricCurve3D(this Graphics g, Pen pen,
            RtoR x, RtoR y, RtoR z,
            float a, float b, int n = 500)
        {
            float t = a;
            float h = (b - a) / n;
            Vector4F v0 = new Vector4F(x(t), y(t), z(t));
            Vector4F pv0 = projection * (transformation * v0);
            pv0.ToCartesian();
            pv0 += centerOfCanvas;
            while (t < b)
            {
                t += h;
                Vector4F v1 = new Vector4F(x(t), y(t), z(t));
                Vector4F pv1 = projection * (transformation * v1);
                pv1.ToCartesian();
                pv1 += centerOfCanvas;
                g.DrawLine(pen, pv0, pv1);
                pv0 = pv1;
            }
        }
        //A DrawBezierN3D, DrawBSpline3D és DrawHermiteCurve3D projektek
        //közül egy ember csak egyet mutathat be!
        public static void DrawBezierN3D(this Graphics g, Pen pen, List<Vector4F> v)
        {
            throw new ProjectException();
        }
        public static void DrawBSpline3D(this Graphics g, Pen pen, List<Vector4F> v)
        {
            throw new ProjectException();
        }
        public static void DrawHermiteCurve3D(this Graphics g, Pen pen, List<Vector4F> v)
        {
            throw new ProjectException();
        }

        public delegate float RRtoR(float x, float y);
        public static void DrawParametricSurface(this Graphics g, Pen pen,
            RRtoR x, RRtoR y, RRtoR z,
            float a, float b,
            float c, float d,
            int du = 20, int dv = 20,
            int m = 500, int n = 500)
        {
            float v = c;
            float hv = (d - c) / dv;
            while (v < d)
            {
                g.DrawParametricCurve3D(pen,
                    _u => x(_u, v),
                    _u => y(_u, v),
                    _u => z(_u, v),
                    a, b, m);
                v += hv;
            }

            float u = a;
            float hu = (b - a) / du;
            while (u < b)
            {
                g.DrawParametricCurve3D(pen,
                    _v => x(u, _v),
                    _v => y(u, _v),
                    _v => z(u, _v),
                    c, d, n);
                u += hu;
            }
        }
        public static void DrawParametricSurfaceHedgehog(this Graphics g, Pen pen, Pen penNail,
            RRtoR x, RRtoR y, RRtoR z,
            float a, float b,
            float c, float d,
            int du = 20, int dv = 20,
            int m = 500, int n = 500)
        {
            //2 jegy
            throw new ProjectException();
        }
        public static void DrawCoonsPatch(this Graphics g, Pen pen,
            Curve3D a1, Curve3D a2, Curve3D b1, Curve3D b2)
        {
            //2 jegy
            throw new ProjectException();
        }
        public static void DrawBezier3Surface(this Graphics g, Pen pen, Vector4F[,] controlNet)
        {
            throw new ProjectException();
        }
        public static void DrawBezierMNSurface(this Graphics g, Pen pen, Vector4F[,] controlNet)
        {
            //2 jegy
            throw new ProjectException();
        }
        public static void DrawBSplineSurface(this Graphics g, Pen pen, Vector4F[,] controlNet)
        {
            //2 jegy
            //Legalább 5x5-ös kontrollpont háló kell
            throw new ProjectException();
        }

        public static void DisplayBRep(this Graphics g, Pen pen, BRep model)
        {
            foreach (Triangle triangle in model.triangles)
            {
                Vector4F a = Projection.Project(Transformation.Transform(triangle.a));
                Vector4F b = Projection.Project(Transformation.Transform(triangle.b));
                Vector4F c = Projection.Project(Transformation.Transform(triangle.c));

                g.DrawLine(pen, a, b);
                g.DrawLine(pen, b, c);
                g.DrawLine(pen, c, a);
            }
        }
        public static void DisplayBRepBackfaceCulling(this Graphics g, Pen pen, BRep model)
        {
            foreach (Triangle triangle in model.triangles)
            {
                Vector4F a = Transformation.Transform(triangle.a);
                Vector4F b = Transformation.Transform(triangle.b);
                Vector4F c = Transformation.Transform(triangle.c);
                Triangle tri = new Triangle(a, b, c);
                if (tri.IsVisible(camera))
                {
                    a = Projection.Project(a);
                    b = Projection.Project(b);
                    c = Projection.Project(c);

                    g.DrawLine(pen, a, b);
                    g.DrawLine(pen, b, c);
                    g.DrawLine(pen, c, a);
                }
            }
        }
        public static void DisplayBRepFlatShading(this Graphics g, Color color, BRep model)
        {
            throw new ProjectException();
        }
        public static void DisplayBRepFlatShading2(this Graphics g, Color color, BRep model)
        {
            //Minden lapnál figyelembe vesszük a szomszéd lapok normálisát is
            throw new ProjectException();
        }
        public static void DisplayBRepGouraudShading(this Graphics g, Color color, BRep model)
        {
            //2 jegy
            throw new ProjectException();
        }
        public static void DisplayBRepPhongShading(this Graphics g, Color color, BRep model)
        {
            //2 jegy
            throw new ProjectException();
        }
        public static void DisplayWingedEdge(this Graphics g, Pen pen, WingedEdge model)
        {
            throw new ProjectException();
        }
        //2 jegy: Listányi objektumot megjeleníteni Z-bufferrel
        #endregion
    }
}
