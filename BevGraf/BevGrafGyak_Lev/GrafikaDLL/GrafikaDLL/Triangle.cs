using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Triangle
    {
        public Vector4 a;
        public Vector4 b;
        public Vector4 c;

        public Triangle(Vector4 a, Vector4 b, Vector4 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
    }
}
