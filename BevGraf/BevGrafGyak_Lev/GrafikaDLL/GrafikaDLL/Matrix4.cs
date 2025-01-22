using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Matrix4
    {
        public double[,] M;

        public Matrix4()
        {
            this.M = new double[4, 4];
        }
        public Matrix4(Matrix4 matrix)
        {
            this.M = new double[4, 4];
            for (int i = 0; i < 4; i++)
                for (int j = 0; j < 4; j++)
                    this[i, j] = matrix[i, j];
        }

        public double this[int i, int j]
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

        public static Matrix4 operator +(Matrix4 a, Matrix4 b)
        {
            Matrix4 res = new Matrix4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    res[i, j] = a[i, j] + b[i, j];
                }
            }
            return res;
        }
        public static Matrix4 operator *(Matrix4 a, Matrix4 b)
        {
            Matrix4 res = new Matrix4();
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < 4; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    res[i, j] = sum;
                }
            }
            return res;
        }
        public static Vector4 operator *(Matrix4 a, Vector4 v)
        {
            Vector4 res = new Vector4();
            res.x = a[0, 0] * v.x + a[0, 1] * v.y + a[0, 2] * v.z + a[0, 3] * v.w;
            res.y = a[1, 0] * v.x + a[1, 1] * v.y + a[1, 2] * v.z + a[1, 3] * v.w;
            res.z = a[2, 0] * v.x + a[2, 1] * v.y + a[2, 2] * v.z + a[2, 3] * v.w;
            res.w = a[3, 0] * v.x + a[3, 1] * v.y + a[3, 2] * v.z + a[3, 3] * v.w;
            return res;
        }
        public static Vector4 operator *(Vector4 v, Matrix4 a)
        {
            throw new HomeworkNotImplementedException();
        }

        public class Projection
        {
            public static Matrix4 Parallel(Vector4 v)
            {
                Matrix4 res = new Matrix4();
                res.LoadIdentity();
                res[0, 2] = -v.x / v.z;
                res[1, 2] = -v.y / v.z;
                res[2, 2] = 0;
                return res;
            }
            public static Matrix4 Perpendicular()
            {
                return Parallel(new Vector4(0, 0, -1));
            }
            public static Matrix4 Central(double s)
            {
                Matrix4 res = new Matrix4();
                res.LoadIdentity();
                res[2, 2] = 0;
                res[3, 2] = -1 / s;
                return res;
            }
        }

        public class Transformation
        {
            public static Matrix4 Scale(double lambda)
            {
                Matrix4 res = new Matrix4();
                res.LoadIdentity();
                res[0, 0] = lambda;
                res[1, 1] = lambda;
                res[2, 2] = lambda;
                return res;
            }

            public static Matrix4 RotateX(double alpha)
            {
                Matrix4 res = new Matrix4();
                res.LoadIdentity();
                res[1, 1] = Math.Cos(alpha);
                res[1, 2] = -Math.Sin(alpha);
                res[2, 1] = Math.Sin(alpha);
                res[2, 2] = Math.Cos(alpha);
                return res;
            }
        }
    }
}
