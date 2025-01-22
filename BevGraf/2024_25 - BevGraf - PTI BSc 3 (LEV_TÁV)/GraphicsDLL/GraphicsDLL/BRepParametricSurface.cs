using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class BRepParametricSurface : Object3D
    {
        public BRepParametricSurface(Func<float, float, float> x, 
                                     Func<float, float, float> y, 
                                     Func<float, float, float> z,
                                     float a, float b, float c, float d,
                                     float m = 20, float n = 20)
        {
            throw new ProjectException();
        }
    }
}
