using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class BRepParametricSurface : ModelBRep
    {
        public BRepParametricSurface(Func<float, float, float> x, 
                                     Func<float, float, float> y, 
                                     Func<float, float, float> z,
                                     float a, float b,
                                     float c, float d,
                                     int du = 15, int dv = 15)
        {
            float v = c;
            float hv = (d - c) / dv;
            while(v < d)
            {
                float u = a;
                float hu = (b - a) / du;
                while(u < b)
                {
                    triangles.Add(new Triangle(new Vector4F(x(u, v),
                                                            y(u, v),
                                                            z(u, v)),                                               
                                               new Vector4F(x(u + hu, v + hv),
                                                            y(u + hu, v + hv),
                                                            z(u + hu, v + hv)),
                                               new Vector4F(x(u + hu, v),
                                                            y(u + hu, v),
                                                            z(u + hu, v))));
                    triangles.Add(new Triangle(new Vector4F(x(u, v),
                                                            y(u, v),
                                                            z(u, v)),                                               
                                               new Vector4F(x(u, v + hv),
                                                            y(u, v + hv),
                                                            z(u, v + hv)),
                                               new Vector4F(x(u + hu, v + hv),
                                                            y(u + hu, v + hv),
                                                            z(u + hu, v + hv))));

                    u += hu;
                }
                v += hv;
            }
        }
    }
}
