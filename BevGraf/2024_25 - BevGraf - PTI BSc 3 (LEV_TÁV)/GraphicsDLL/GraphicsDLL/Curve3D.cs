using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class Curve3D
    {
        public ExtensionGraphics.RtoR x;
        public ExtensionGraphics.RtoR y;
        public ExtensionGraphics.RtoR z;
        public float a;
        public float b;
        public int n;

        public Curve3D(ExtensionGraphics.RtoR x, ExtensionGraphics.RtoR y, ExtensionGraphics.RtoR z, float a, float b, int n = 500)
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
