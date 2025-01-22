using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GraphicsDLL
{
    public static class ExtensionGraphics
    {
        #region 2D graphics
        public static void DrawPixel(this Graphics g, Pen pen, float x, float y)
        {
            g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
        }
        public static void DrawPixel(this Graphics g, Color c, float x, float y)
        {
            g.DrawRectangle(new Pen(c), x, y, 0.5f, 0.5f);
        }

        public static void DrawPointF(this Graphics g, Pen pen, Brush brush, PointF p)
        {
            g.FillRectangle(brush, p.X - ExtensionPointF.POINT_SIZE,
                                   p.Y - ExtensionPointF.POINT_SIZE,
                                   2 * ExtensionPointF.POINT_SIZE,
                                   2 * ExtensionPointF.POINT_SIZE);
            g.DrawRectangle(pen, p.X - ExtensionPointF.POINT_SIZE,
                                   p.Y - ExtensionPointF.POINT_SIZE,
                                   2 * ExtensionPointF.POINT_SIZE,
                                   2 * ExtensionPointF.POINT_SIZE);
        }

        public static void DrawLineDDA(this Graphics g, Pen pen, PointF p0, PointF p1)
        {
            float dx = p1.X - p0.X;
            float dy = p1.Y - p0.Y;

            float length = MathF.Abs(dx);
            if (MathF.Abs(dy) > length)
                length = MathF.Abs(dy);

            float diffX = dx / length;
            float diffY = dy / length;

            float x = p0.X;
            float y = p0.Y;

            g.DrawPixel(pen, x, y);
            for (int i = 0; i < length; i++)
            {
                x += diffX;
                y += diffY;
                g.DrawPixel(pen, x, y);
            }
        }
        public static void DrawLineDDA(this Graphics g, Color c0, Color c1, PointF p0, PointF p1)
        {
            float dx = p1.X - p0.X;
            float dy = p1.Y - p0.Y;
            float dR = c1.R - c0.R;
            float dG = c1.G - c0.G;
            float dB = c1.B - c0.B;

            float length = MathF.Abs(dx);
            if (MathF.Abs(dy) > length)
                length = MathF.Abs(dy);

            float diffX = dx / length;
            float diffY = dy / length;
            float diffR = dR / length;
            float diffG = dG / length;
            float diffB = dB / length;

            float x = p0.X;
            float y = p0.Y;
            float R = c0.R;
            float G = c0.G;
            float B = c0.B;

            g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), x, y);
            for (int i = 0; i < length; i++)
            {
                x += diffX;
                y += diffY;
                R += diffR;
                G += diffG;
                B += diffB;
                g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), x, y);
            }
        }

        public static void MidPointV1(this Graphics g, Pen pen, PointF p0, PointF p1)
        {
            throw new HomeworkException();
        }
        public static void MidPointV2(this Graphics g, Pen pen, PointF p0, PointF p1)
        {
            throw new HomeworkException();
        }
        public static void MidPointV2(this Graphics g, Color c0, Color c1, PointF p0, PointF p1)
        {
            throw new ProjectException();
        }
        public static void MidPointV2Dashed(this Graphics g, Pen pen, PointF p0, PointF p1, int size, int space)
        {
            throw new HomeworkException();
        }
        public static void MidPointV2Dashed(this Graphics g, Color c0, Color c1, PointF p0, PointF p1, int size, int space)
        {
            throw new HomeworkException();
        }
        public static void MidPointV2DashedExtra(this Graphics g, Pen pen, PointF p0, PointF p1, int size, int space, int r)
        {
            throw new HomeworkException();
        }

        public static void DrawCirclePoints(this Graphics g, Pen pen, float x, float y)
        {
            g.DrawPixel(pen, x, y);
            g.DrawPixel(pen, -x, -y);
            g.DrawPixel(pen, -x, y);
            g.DrawPixel(pen, x, -y);
            g.DrawPixel(pen, y, x);
            g.DrawPixel(pen, -y, -x);
            g.DrawPixel(pen, -y, x);
            g.DrawPixel(pen, y, -x);
        }
        public static void DrawCirclePoints(this Graphics g, Pen pen, float x, float y, float ox, float oy)
        {
            g.DrawPixel(pen, x + ox, y + oy);
            g.DrawPixel(pen, -x + ox, -y + oy);
            g.DrawPixel(pen, -x + ox, y + oy);
            g.DrawPixel(pen, x + ox, -y + oy);
            g.DrawPixel(pen, y + ox, x + oy);
            g.DrawPixel(pen, -y + ox, -x + oy);
            g.DrawPixel(pen, -y + ox, x + oy);
            g.DrawPixel(pen, y + ox, -x + oy);
        }
        public static void DrawCircle(this Graphics g, Pen pen, float r)
        {
            throw new HomeworkException();
        }
        public static void DrawCircle(this Graphics g, Pen pen, PointF O, float r)
        {
            throw new HomeworkException();
        }
        public static void DrawCircle(this Graphics g, Color c0, Color c1, PointF O, float r)
        {
            throw new ProjectException();
        }
        public static void DrawCircleColorSpectrum(this Graphics g, PointF O, float r)
        {
            throw new ProjectException();
        }

        public static void ClipCS(this Graphics g, Pen pen, PointF p0, PointF p1, RectangleF win)
        {
            byte code0 = p0.OutCode(win);
            byte code1 = p1.OutCode(win);
            bool accept = false;
            while (true)
            {
                if ((code0 | code1) == ExtensionPointF.INSIDE)
                {
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != ExtensionPointF.INSIDE)
                {
                    break;
                }
                else
                {
                    byte code = code0 != ExtensionPointF.INSIDE ? code0 : code1;

                    float x = 0, y = 0;
                    if ((code & ExtensionPointF.LEFT) != 0)
                    {
                        x = win.Left;
                        y = p0.Y + (p1.Y - p0.Y) * (win.Left - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & ExtensionPointF.RIGHT) != 0)
                    {
                        x = win.Right;
                        y = p0.Y + (p1.Y - p0.Y) * (win.Right - p0.X) / (p1.X - p0.X);
                    }
                    else if ((code & ExtensionPointF.TOP) != 0)
                    {
                        x = p0.X + (p1.X - p0.X) * (win.Top - p0.Y) / (p1.Y - p0.Y);
                        y = win.Top;
                    }
                    else if ((code & ExtensionPointF.BOTTOM) != 0)
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
        public static void ClipConvex(this Graphics g, Pen pen, PointF p0, PointF p1, List<PointF> window)
        {
            throw new ProjectException();
        }
        public static void ClipConcave(this Graphics g, Pen pen, PointF p0, PointF p1, List<PointF> window)
        {
            throw new ProjectException();
        }
        public static void ClipConcave(this Graphics g, Pen pen, PointF p0, PointF p1, List<List<PointF>> window)
        {
            throw new ProjectException();
        }

        public delegate float RtoR(float x);
        public delegate float RRtoR(float x, float y);
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
        public static void DrawHermiteArc(this Graphics g, Pen pen, HermiteArc arc, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => HermiteArc.H0(t) * arc.p0.x + HermiteArc.H1(t) * arc.p1.x +
                     HermiteArc.H2(t) * arc.t0.x + HermiteArc.H3(t) * arc.t1.x,
                t => HermiteArc.H0(t) * arc.p0.y + HermiteArc.H1(t) * arc.p1.y +
                     HermiteArc.H2(t) * arc.t0.y + HermiteArc.H3(t) * arc.t1.y,
                0.0f, 1.0f, n);
        }
        public static void DrawHermiteArcs(this Graphics g, Pen pen, List<Vector2F> p, List<Vector2F> t, bool isClosed = false, int n = 500)
        {
            throw new ProjectException();
        }
        public static void DrawBezier3(this Graphics g, Pen pen, Bezier3 curve, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => Bezier3.B0(t) * curve.p0.x + Bezier3.B1(t) * curve.p1.x +
                     Bezier3.B2(t) * curve.p2.x + Bezier3.B3(t) * curve.p3.x,
                t => Bezier3.B0(t) * curve.p0.y + Bezier3.B1(t) * curve.p1.y +
                     Bezier3.B2(t) * curve.p2.y + Bezier3.B3(t) * curve.p3.y,
                0f, 1f, n);
        }
        public static void DrawBezier3P(this Graphics g, Pen pen, Bezier3P curve, float p, int n = 500)
        {
            throw new ProjectException();
        }
        public static void DrawBezierN(this Graphics g, Pen pen, BezierN curve, int n = 500)
        {
            throw new ProjectException();
        }
        public static void DrawBSpline(this Graphics g, Pen pen, BSpline curve, int n = 500)
        {
            throw new ProjectException();
        }
        public static void CornerCutting(this Graphics g, Pen pen, List<Vector2F> v, int level)
        {
            throw new ProjectException();
        }
        public static void LaneRiesenfeld(this Graphics g, Pen pen, List<Vector2F> v, float[] mask, int level)
        {
            throw new ProjectException();
        }
        #endregion

        #region 3D graphics
        public static Matrix4F projection;
        public static Matrix4F transformation;
        public static Vector4F centerOfCanvas;
        private static Vector4F o = new Vector4F(0, 0, 0);
        private static Vector4F e1 = new Vector4F(50, 0, 0);
        private static Vector4F e2 = new Vector4F(0, 50, 0);
        private static Vector4F e3 = new Vector4F(0, 0, 50);
        private static Vector4F camera = new Vector4F(0, 0, 0);
        public static Vector4F O
        {
            get
            {
                Vector4F res = projection * o;
                res.ToCartesian();
                res += centerOfCanvas;
                return res;
            }
        }
        public static Vector4F E1
        {
            get
            {
                Vector4F res = projection * e1;
                res.ToCartesian();
                res += centerOfCanvas;
                return res;
            }
        }
        public static Vector4F E2
        {
            get
            {
                Vector4F res = projection * e2;
                res.ToCartesian();
                res += centerOfCanvas;
                return res;
            }
        }
        public static Vector4F E3
        {
            get
            {
                Vector4F res = projection * e3;
                res.ToCartesian();
                res += centerOfCanvas;
                return res;
            }
        }

        static ExtensionGraphics()
        {
            projection = Matrix4F.Projection.Perpendicular();
            transformation = new Matrix4F();
            transformation.LoadIdentity();
            centerOfCanvas = new Vector4F(0f, 0f, 0f);
        }

        public static void SetProjection(Matrix4F projection)
        {
            ExtensionGraphics.projection = projection;
        }
        public static void SetParallelProjection(Vector4F v)
        {
            SetProjection(Matrix4F.Projection.Parallel(v));
            camera = -100000 * v;
        }
        public static void SetCentralProjection(float s)
        {
            SetProjection(Matrix4F.Projection.Central(s));
            camera = new Vector4F(0, 0, s);
        }
        public static void PushTransformation(Matrix4F transformation)
        {
            ExtensionGraphics.transformation = transformation * ExtensionGraphics.transformation;
        }
        public static void LoadIdentity()
        {
            ExtensionGraphics.transformation.LoadIdentity();
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
        //Egy ember a DrawBezierN3D, DrawHermiteCurves3D és DrawBSpline3D közül csak egyet adhat be!
        public static void DrawBezierN3D(this Graphics g, Pen pen, 
            List<Vector4F> v, int n = 500)
        {
            throw new ProjectException();
        }
        public static void DrawHermiteCurves3D(this Graphics g, Pen pen,
            List<Vector4F> v, int n = 500)
        {
            throw new ProjectException();
        }
        public static void DrawBSpline3D(this Graphics g, Pen pen,
            List<Vector4F> v, int n = 500)
        {
            throw new ProjectException();
        }

        public static void DrawParametricSurface(this Graphics g, Pen pen,
            RRtoR x, RRtoR y, RRtoR z,
            float a, float b,
            float c, float d,
            int m = 20, int n = 20)
        {
            float v = c;
            float hv = (d - c) / n;
            while(v < d)
            {
                g.DrawParametricCurve3D(pen,
                    _u => x(_u, v),
                    _u => y(_u, v),
                    _u => z(_u, v),
                    a, b);
                v += hv;
            }

            float u = a;
            float hu = (b - a) / m;
            while(u < b)
            {
                g.DrawParametricCurve3D(pen,
                    _v => x(u, _v),
                    _v => y(u, _v),
                    _v => z(u, _v),
                    c, d);
                u += hu;
            }
        }
        public static void DrawParametricHedgehogSurface(this Graphics g, Pen pen,
            RRtoR x, RRtoR y, RRtoR z,
            float a, float b,
            float c, float d,
            int m = 20, int n = 20)
        {
            throw new ProjectException();
        }
        public static void DrawCoonsPatch(this Graphics g, Pen pen,
            Curve3DF a1, Curve3DF a2,
            Curve3DF b1, Curve3DF b2)
        {
            throw new ProjectException();
        }
        public static void DrawBezier3Surface(this Graphics g, Pen pen,
            Vector4F[,] pointNet)
        {
            throw new ProjectException();
        }
        public static void DrawBezier3HedgehogSurface(this Graphics g, Pen pen,
            Vector4F[,] pointNet)
        {
            throw new ProjectException();
        }
        public static void DrawBSplineSurface(this Graphics g, Pen pen,
            Vector4F[,] pointNet)
        {
            //Itt viszont a Bezier3 miatt kikötés, hogy legalább 5x5 kontrollpont legyen
            throw new ProjectException();
        }
        public static void DrawBezierNSurface(this Graphics g, Pen pen,
            Vector4F[,] pointNet)
        {
            throw new ProjectException();
        }

        public static void DrawWireframeBRep(this Graphics g, Pen pen,
            BRep brep, bool backfaceCulling = false)
        {
            foreach (var triangle in brep.triangles)
            {
                Vector4F pa = transformation * triangle.a;
                Vector4F pb = transformation * triangle.b;
                Vector4F pc = transformation * triangle.c;

                bool isFrontFace = true;
                if (backfaceCulling)
                {
                    Triangle tri = new Triangle(pa, pb, pc);
                    Vector4F normal = tri.NormalAtA;
                    Vector4F toCamera = camera - tri.a;
                    float dotProduct = normal * toCamera;
                    dotProduct /= normal.Length;
                    dotProduct /= toCamera.Length;
                    if (dotProduct < 0)
                        isFrontFace = false;
                }

                if (isFrontFace)
                {
                    pa = projection * pa;
                    pa.ToCartesian();
                    pa += centerOfCanvas;

                    pb = projection * pb;
                    pb.ToCartesian();
                    pb += centerOfCanvas;

                    pc = projection * pc;
                    pc.ToCartesian();
                    pc += centerOfCanvas;

                    g.DrawLine(pen, pa, pb);
                    g.DrawLine(pen, pb, pc);
                    g.DrawLine(pen, pc, pa);
                }
            }
        }
        public static void DrawBRepWithFlatShading(this Graphics g, Color color,
            BRep bprep)
        {
            throw new ProjectException();
        }
        public static void DrawBRepWithFlatShading2(this Graphics g, Color color,
            BRep bprep)
        {
            //Ez az, amikor egy csúcs esetén a többi oda csatlakozó lapnak is nézem
            //ugyanabban a pontban a normálisát és ezeket átlagolom.
            throw new ProjectException();
        }
        public static void DrawBRepWithGouraudShading(this Graphics g, Color color,
            BRep bprep)
        {            
            throw new ProjectException();
        }
        public static void DrawBRepWithPhongShading(this Graphics g, Color color,
            BRep bprep)
        {
            throw new ProjectException();
        }
        /*
         * Legalább 3 BRep modellt tegyenek bele egy listába!
         * Jelenítsék meg ZBuffer algoritmussal őket!
         */
        #endregion
    }
}
