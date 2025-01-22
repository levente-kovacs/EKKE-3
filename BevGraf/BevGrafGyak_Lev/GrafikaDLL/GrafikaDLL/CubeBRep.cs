using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class CubeBRep : BRep
    {
        public CubeBRep()
        {
            vertices = new List<Vector4>()
            {
                new Vector4(0, 0, 0),
                new Vector4(0, 0, 1),
                new Vector4(0, 1, 1),
                new Vector4(0, 1, 0),
                new Vector4(1, 0, 0),
                new Vector4(1, 0, 1),
                new Vector4(1, 1, 1),
                new Vector4(1, 1, 0)
            };

            triangles = new List<Triangle>()
            {
                new Triangle(vertices[0], vertices[1], vertices[2]),
                new Triangle(vertices[0], vertices[2], vertices[3]),

                new Triangle(vertices[7], vertices[6], vertices[5]),
                new Triangle(vertices[7], vertices[5], vertices[4]),

                new Triangle(vertices[0], vertices[4], vertices[5]),
                new Triangle(vertices[0], vertices[5], vertices[1]),

                new Triangle(vertices[1], vertices[5], vertices[6]),
                new Triangle(vertices[1], vertices[6], vertices[2]),

                new Triangle(vertices[2], vertices[6], vertices[7]),
                new Triangle(vertices[2], vertices[7], vertices[3]),

                new Triangle(vertices[3], vertices[7], vertices[0]),
                new Triangle(vertices[3], vertices[0], vertices[4]),
            };
        }
    }
}
