using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RRtoR = System.Func<float, float, float>;

namespace GraphicsDLL
{
    public static class ExtensionGraphics
    {
        public static void DrawPixel(this Graphics g, Pen pen, float x, float y)
        {
            g.DrawRectangle(pen, x, y, 0.5f, 0.5f);
        }
        public static void DrawPixel(this Graphics g, Color color, float x, float y)
        {
            g.DrawPixel(new Pen(color), x, y);
        }

        #region 2D graphics
        public static void DrawLineDDA(this Graphics g, Pen pen,
            float x0, float y0, float x1, float y1)
        {
            float dx = x1 - x0;
            float dy = y1 - y0;
            float length = MathF.Abs(dx);
            if (MathF.Abs(dy) > length)
                length = MathF.Abs(dy);
            float nx = dx / length;
            float ny = dy / length;
            float x = x0;
            float y = y0;
            g.DrawPixel(pen, x, y);
            for (int i = 0; i < length; i++)
            {
                x += nx;
                y += ny;
                g.DrawPixel(pen, x, y);
            }
        }
        public static void DrawLineDDA(this Graphics g, Color c0, Color c1,
            float x0, float y0, float x1, float y1)
        {
            float dx = x1 - x0;
            float dy = y1 - y0;
            float length = MathF.Abs(dx);
            if (MathF.Abs(dy) > length)
                length = MathF.Abs(dy);
            float nx = dx / length;
            float ny = dy / length;

            float dR = c1.R - c0.R;
            float dG = c1.G - c0.G;
            float dB = c1.B - c0.B;
            float nR = dR / length;
            float nG = dG / length;
            float nB = dB / length;

            float R = c0.R;
            float G = c0.G;
            float B = c0.B;
            float x = x0;
            float y = y0;
            g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), x, y);
            for (int i = 0; i < length; i++)
            {
                R += nR;
                G += nG;
                B += nB;
                x += nx;
                y += ny;
                g.DrawPixel(Color.FromArgb((int)R, (int)G, (int)B), x, y);
            }
        }

        public static void DrawLineMidPointV1(this Graphics g, Pen pen,
            int x0, int y0, int x1, int y1)
        {
            throw new HomeworkException();
        }
        public static void DrawLineMidPointV2(this Graphics g, Pen pen,
            int x0, int y0, int x1, int y1)
        {
            throw new ProjectException();
        }

        public static void ClipCS(this Graphics g, Pen pen, RectangleF win,
            PointF p0, PointF p1)
        {
            byte code0 = p0.OutCode(win);
            byte code1 = p1.OutCode(win);
            bool accept = false;
            while (true)
            {
                if ((code0 | code1) == 0)
                {
                    accept = true;
                    break;
                }
                else if ((code0 & code1) != 0)
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
        public static void ClipToConvex(this Graphics g, Pen pen,
            PointF[] win, PointF p0, PointF p1)
        {
            throw new ProjectException();
        }

        public delegate float RtoR(float x);
        public static void DrawParametricCurve(this Graphics g, Pen pen,
            Func<float, float> x, Func<float, float> y,
            float a, float b, int n = 500)
        {
            if (b <= a)
                throw new Exception("Wrong interval!");

            float h = (b - a) / n;
            float t = a;
            PointF p0 = new PointF(x(t), y(t));
            while (t < b)
            {
                t += h;
                PointF p1 = new PointF(x(t), y(t));
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }

        public static void DrawEpicycliod(this Graphics g, Pen pen,
            int a, int b, int n = 500)
        {
            throw new ProjectException();
            //Semmi más nem kell, mint egy jól felparaméterezett
            //g.DrawParametricCurve(..., n);
            //Figyeljenek, hogy az itt kapott a és b NEM a paramétertartomány végpontjai!
            //https://oc.uni-eszterhazy.hu/apps/files/?dir=/Share/Bevezet%C3%A9s%20a%20sz%C3%A1m%C3%ADt%C3%B3g%C3%A9pi%20grafik%C3%A1ba/Param%C3%A9teres%20g%C3%B6rb%C3%A9k&fileid=739899408#pdfviewer
        }

        public static void DrawHermiteArc(this Graphics g, Pen pen, Hermite h, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => Hermite.Basis.H0(t) * h.p0.x +
                     Hermite.Basis.H1(t) * h.p1.x +
                     Hermite.Basis.H2(t) * h.t0.x +
                     Hermite.Basis.H3(t) * h.t1.x,
                t => Hermite.Basis.H0(t) * h.p0.y +
                     Hermite.Basis.H1(t) * h.p1.y +
                     Hermite.Basis.H2(t) * h.t0.y +
                     Hermite.Basis.H3(t) * h.t1.y,
                0f, 1f, n);
        }
        public static void DrawBezier3(this Graphics g, Pen pen, Bezier3 b, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => Bezier3.Basis.B0(t) * b.p0.x +
                     Bezier3.Basis.B1(t) * b.p1.x +
                     Bezier3.Basis.B2(t) * b.p2.x +
                     Bezier3.Basis.B3(t) * b.p3.x,
                t => Bezier3.Basis.B0(t) * b.p0.y +
                     Bezier3.Basis.B1(t) * b.p1.y +
                     Bezier3.Basis.B2(t) * b.p2.y +
                     Bezier3.Basis.B3(t) * b.p3.y,
                0f, 1f, n);
        }
        public static void DrawBezier3P(this Graphics g, Pen pen, Bezier3P b, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => Bezier3P.Basis.B0(t, b.p) * b.p0.x +
                     Bezier3P.Basis.B1(t, b.p) * b.p1.x +
                     Bezier3P.Basis.B2(t, b.p) * b.p2.x +
                     Bezier3P.Basis.B3(t, b.p) * b.p3.x,
                t => Bezier3P.Basis.B0(t, b.p) * b.p0.y +
                     Bezier3P.Basis.B1(t, b.p) * b.p1.y +
                     Bezier3P.Basis.B2(t, b.p) * b.p2.y +
                     Bezier3P.Basis.B3(t, b.p) * b.p3.y,
                0f, 1f, n);
        }
        public static void DrawBezierN(this Graphics g, Pen pen, BezierN b, int n = 500)
        {
            float h = 1.0f / n;
            float t = 0.0f;
            PointF p0 = new PointF(0, 0);
            for (int i = 0; i < b.p.Count; i++)
            {
                p0.X += b.p[i].x * BezierN.Basis.B(i, b.p.Count - 1, t);
                p0.Y += b.p[i].y * BezierN.Basis.B(i, b.p.Count - 1, t);
            }
            while (t < 1.0)
            {
                t += h;
                PointF p1 = new PointF(0, 0);
                for (int i = 0; i < b.p.Count; i++)
                {
                    p1.X += b.p[i].x * BezierN.Basis.B(i, b.p.Count - 1, t);
                    p1.Y += b.p[i].y * BezierN.Basis.B(i, b.p.Count - 1, t);
                }
                g.DrawLine(pen, p0, p1);
                p0 = p1;
            }
        }
        public static void DrawBSpline(this Graphics g, Pen pen, BSpline b, int n = 500)
        {
            g.DrawParametricCurve(pen,
                t => BSpline.Basis.N0(t) * b.p0.x +
                     BSpline.Basis.N1(t) * b.p1.x +
                     BSpline.Basis.N2(t) * b.p2.x +
                     BSpline.Basis.N3(t) * b.p3.x,
                t => BSpline.Basis.N0(t) * b.p0.y +
                     BSpline.Basis.N1(t) * b.p1.y +
                     BSpline.Basis.N2(t) * b.p2.y +
                     BSpline.Basis.N3(t) * b.p3.y,
                0f, 1f, n);
        }
        public static void CornerCutting(this Graphics g, Pen pen, List<Vector2F> v, int level)
        {
            if (level == 0)
            {
                for (int i = 0; i < v.Count - 1; i++)
                    g.DrawLine(pen, v[i], v[i + 1]);
            }
            else
            {
                List<Vector2F> temp = new List<Vector2F>();
                for (int i = 0; i < v.Count - 1; i++)
                {
                    temp.Add((3 * v[i] + 1 * v[i + 1]) * 0.25f);
                    temp.Add((1 * v[i] + 3 * v[i + 1]) * 0.25f);
                }
                g.CornerCutting(pen, temp, level - 1);
            }
        }
        #endregion


        #region 3D graphics
        private static Matrix4F projection = Matrix4F.Projection.Parallel(0, 0, -1);
        private static Matrix4F transformation;
        public static Vector2F centerOfCanvas = new Vector2F(0, 0);
        private static Vector4F O = new Vector4F(0, 0, 0);
        private static Vector4F E1 = new Vector4F(1, 0, 0);
        private static Vector4F E2 = new Vector4F(0, 1, 0);
        private static Vector4F E3 = new Vector4F(0, 0, 1);
        private static Vector4F camera = new Vector4F(0, 0, 0);

        public static Vector4F o { get { return Projection.Project(Transformation.Transform(O)); } }
        public static Vector4F e1 { get { return Projection.Project(Transformation.Transform(E1)); } }
        public static Vector4F e2 { get { return Projection.Project(Transformation.Transform(E2)); } }
        public static Vector4F e3 { get { return Projection.Project(Transformation.Transform(E3)); } }

        static ExtensionGraphics()
        {
            transformation = new Matrix4F();
            transformation.LoadIdentity();
        }

        public static class Projection
        {
            public static void SetParallel(float vx, float vy, float vz)
            {
                projection = Matrix4F.Projection.Parallel(vx, vy, vz);
                camera = -1000000 * new Vector4F(vx, vy, vz);
            }
            public static void SetCentral(float s)
            {
                projection = Matrix4F.Projection.Central(s);
                camera = new Vector4F(0, 0, s);
            }
            public static Vector4F Project(Vector4F v)
            {
                Vector4F res = projection * v;
                res.ToCartesian();
                res += centerOfCanvas;
                return res;
            }
        }

        public static class Transformation
        {
            public static void Push(Matrix4F trans)
            {
                transformation = trans * transformation;
            }
            public static void LoadIdentity()
            {
                transformation.LoadIdentity();
            }
            public static Vector4F Transform(Vector4F v)
            {
                return transformation * v;
            }
        }

        public static void DrawParametricCurve3D(this Graphics g, Pen pen,
            Func<float, float> x, Func<float, float> y, Func<float, float> z,
            float a, float b, int n = 500)
        {
            if (b <= a)
                throw new Exception("Wrong interval!");

            float h = (b - a) / n;
            float t = a;
            Vector4F v0 = new Vector4F(x(t), y(t), z(t));
            Vector4F pv0 = Projection.Project(Transformation.Transform(v0));
            while (t < b)
            {
                t += h;
                Vector4F v1 = new Vector4F(x(t), y(t), z(t));
                Vector4F pv1 = Projection.Project(Transformation.Transform(v1));
                g.DrawLine(pen, pv0, pv1);
                pv0 = pv1;
            }
        }
        //public delegate float RRtoR(float x, float y);
        public static void DrawParametricSurface(this Graphics g, Pen pen,
            RRtoR x, RRtoR y, RRtoR z,
            float a, float b,
            float c, float d,
            int du = 15, int dv = 15,
            int nu = 500, int nv = 500)
        {
            float v = c;
            float hv = (d - c) / dv;
            while (v < d)
            {
                g.DrawParametricCurve3D(pen,
                    _u => x(_u, v),
                    _u => y(_u, v),
                    _u => z(_u, v),
                    a, b, nu);
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
                    a, b, nu);
                u += hu;
            }
        }
        public static void DisplayBRep(this Graphics g, Pen pen, ModelBRep model, bool backfaceCulling = true)
        {
            foreach (Triangle triangle in model.triangles.OrderBy(t => t.WeightZ))
            {
                Vector4F a = Transformation.Transform(triangle.a);
                Vector4F b = Transformation.Transform(triangle.b);
                Vector4F c = Transformation.Transform(triangle.c);

                Triangle tri = new Triangle(a, b, c);
                if (!backfaceCulling || tri.IsVisible(camera))
                {
                    a = Projection.Project(a);
                    b = Projection.Project(b);
                    c = Projection.Project(c);

                    g.DrawLine(pen, a, b);
                    g.DrawLine(pen, c, b);
                    g.DrawLine(pen, a, c);
                }
            }
        }
        public static void FlatShadingBRep(this Graphics g, Color color, ModelBRep model)
        {
            List<Triangle> transformed = new List<Triangle>();
            foreach (Triangle triangle in model.triangles)
            {
                Vector4F a = Transformation.Transform(triangle.a);
                Vector4F b = Transformation.Transform(triangle.b);
                Vector4F c = Transformation.Transform(triangle.c);
                transformed.Add(new Triangle(a, b, c));
            }

            foreach (Triangle triangle in transformed
                                            .Where(t => t.IsVisible(camera))
                                            .OrderBy(t => t.WeightZ))
            {
                Vector4F a = Projection.Project(triangle.a);
                Vector4F b = Projection.Project(triangle.b);
                Vector4F c = Projection.Project(triangle.c);

                float visibilityValue = triangle.VisibilityValueA(camera);
                Color col = Color.FromArgb((int)(visibilityValue * color.R),
                                           (int)(visibilityValue * color.G),
                                           (int)(visibilityValue * color.B));
                g.FillPolygon(new SolidBrush(col), new PointF[] { a, b, c });
            }
        }
        #endregion
    }
}
