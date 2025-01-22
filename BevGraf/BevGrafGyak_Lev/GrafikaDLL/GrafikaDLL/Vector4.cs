using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Vector4
    {
        public double x, y, z, w;

        public Vector4() : this(0, 0, 0)
        {
        }
        public Vector4(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 1.0f;
        }
        public Vector4(double x, double y, double z, double w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void Normalize()
        {

        }
        public void ToCartesian()
        {
            this.x /= this.w;
            this.y /= this.w;
            this.z /= this.w;
            this.w = 1.0;
        }

        public static Vector4 operator +(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, a.z + b.z);
        }
        public static Vector4 operator +(Vector4 a, Vector2 b)
        {
            return new Vector4(a.x + b.x, a.y + b.y, 0.0f);
        }
        public static Vector4 operator -(Vector4 a, Vector4 b)
        {
            return new Vector4(a.x - b.x, a.y - b.y, a.z - b.z);
        }
        public static Vector4 operator *(double a, Vector4 v)
        {
            return new Vector4(a * v.x, a * v.y, a * v.z);
        }
        public static Vector4 operator *(Vector4 v, double a)
        {
            return new Vector4(a * v.x, a * v.y, a * v.z);
        }
        public static Vector4 operator ^(Vector4 v0, Vector4 v1)
        {
            //https://hu.wikipedia.org/wiki/Vektori%C3%A1lis_szorzat
            throw new HomeworkNotImplementedException();
        }
    }
}
