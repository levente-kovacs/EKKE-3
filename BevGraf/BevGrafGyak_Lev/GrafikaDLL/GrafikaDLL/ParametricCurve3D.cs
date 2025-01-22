using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class ParametricCurve3D
    {


        public ExtensionGraphics.RtoR x;
        public ExtensionGraphics.RtoR y;
        public ExtensionGraphics.RtoR z;
        public double a;
        public double b;

        public ParametricCurve3D(ExtensionGraphics.RtoR x, ExtensionGraphics.RtoR y, ExtensionGraphics.RtoR z, double a, double b)
        {
            this.x = x ?? throw new ArgumentNullException(nameof(x));
            this.y = y ?? throw new ArgumentNullException(nameof(y));
            this.z = z ?? throw new ArgumentNullException(nameof(z));
            this.a = a;
            this.b = b;
        }
    }
}
