using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class Matrix4F
    {
        public float[,] M;

        public Matrix4F()
        {
            this.M = new float[4, 4];
        }
        public Matrix4F(Matrix4F matrix)
        {
            this.M = new float[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this[i, j] = matrix[i, j];
        }

        public float this[int i, int j]
        {
            get { return this.M[i, j]; }
            set { this.M[i, j] = value; }
        }

        public void LoadIdentity()
        {
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this[i, j] = 0;
            this[0, 0] = 1;
            this[1, 1] = 1;
            this[2, 2] = 1;
            this[3, 3] = 1;
        }

        public static Matrix4F operator *(Matrix4F a, Matrix4F b)
        {
            Matrix4F res = new Matrix4F();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    float sum = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    res[i, j] = sum;
                }
            }
            return res;
        }
        public static Vector4F operator *(Matrix4F a, Vector4F v)
        {
            Vector4F res = new Vector4F();
            res.x = a[0, 0] * v.x + a[0, 1] * v.y + a[0, 2] * v.z + a[0, 3] * v.w;
            res.y = a[1, 0] * v.x + a[1, 1] * v.y + a[1, 2] * v.z + a[1, 3] * v.w;
            res.z = a[2, 0] * v.x + a[2, 1] * v.y + a[2, 2] * v.z + a[2, 3] * v.w;
            res.w = a[3, 0] * v.x + a[3, 1] * v.y + a[3, 2] * v.z + a[3, 3] * v.w;
            return res;
        }

        public static class Projection
        {
            public static Matrix4F Parallel(Vector4F v)
            {
                Matrix4F res = new Matrix4F();
                res.LoadIdentity();
                res[0, 2] = -v.x / v.z;
                res[1, 2] = -v.y / v.z;
                res[2, 2] = 0;
                return res;
            }
            public static Matrix4F Perpendicular()
            {
                return Parallel(new Vector4F(0, 0, -1));
            }
            public static Matrix4F Central(float s)
            {
                Matrix4F res = new Matrix4F();
                res.LoadIdentity();
                res[2, 2] = 0;
                res[3, 2] = -1.0f / s;
                return res;
            }
        }

        public static class Transformation
        {
            public static Matrix4F Translate(Vector4F v)
            {
                Matrix4F res = new Matrix4F();
                res.LoadIdentity();
                res[0, 3] = v.x;
                res[1, 3] = v.y;
                res[2, 3] = v.z;
                return res;
            }
            public static Matrix4F Scale(float lambda)
            {
                Matrix4F res = new Matrix4F();
                res.LoadIdentity();
                res[0, 0] = lambda;
                res[1, 1] = lambda;
                res[2, 2] = lambda;
                return res;
            }
            public static Matrix4F RotateX(float alpha)
            {
                Matrix4F res = new Matrix4F();
                res.LoadIdentity();
                res[1, 1] = MathF.Cos(alpha);
                res[1, 2] = -MathF.Sin(alpha);
                res[2, 1] = MathF.Sin(alpha);
                res[2, 2] = MathF.Cos(alpha);
                return res;
            }
            public static Matrix4F RotateY(float beta)
            {
                Matrix4F res = new Matrix4F();
                res.LoadIdentity();
                res[0, 0] = MathF.Cos(beta);
                res[0, 2] = MathF.Sin(beta);
                res[2, 0] = -MathF.Sin(beta);
                res[2, 2] = MathF.Cos(beta);
                return res;
            }
            public static Matrix4F RotateZ(float gamma)
            {
                Matrix4F res = new Matrix4F();
                res.LoadIdentity();
                res[0, 0] = MathF.Cos(gamma);
                res[0, 1] = -MathF.Sin(gamma);
                res[1, 0] = MathF.Sin(gamma);
                res[1, 1] = MathF.Cos(gamma);
                return res;
            }
        }
    }

}
