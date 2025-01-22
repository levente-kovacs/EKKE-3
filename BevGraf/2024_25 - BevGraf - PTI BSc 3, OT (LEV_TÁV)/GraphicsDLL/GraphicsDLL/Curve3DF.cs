using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class Curve3DF
    {
        public Func<float, float> x;
        public Func<float, float> y;
        public Func<float, float> z;
        public float a;
        public float b;
        public int n;

        public Curve3DF(Func<float, float> x, Func<float, float> y, Func<float, float> z, float a, float b, int n = 500)
        {
            this.x = x ?? throw new ArgumentNullException(nameof(x));
            this.y = y ?? throw new ArgumentNullException(nameof(y));
            this.z = z ?? throw new ArgumentNullException(nameof(z));
            this.a = a;
            this.b = b;
            this.n = n;
        }
    }
}
