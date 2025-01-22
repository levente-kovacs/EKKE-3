using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class BRepSurface : BRep
    {
        public BRepSurface(ExtensionGraphics.RRtoR x,
                           ExtensionGraphics.RRtoR y,
                           ExtensionGraphics.RRtoR z,
                           float a, float b,
                           float c, float d,
                           int m = 20, int n = 20)
        {
            throw new ProjectException();
        }
    }
}
