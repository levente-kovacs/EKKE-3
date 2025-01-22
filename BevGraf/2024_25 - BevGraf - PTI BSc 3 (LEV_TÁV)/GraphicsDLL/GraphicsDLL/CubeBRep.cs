using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class CubeBRep : BRep
    {
        public CubeBRep()
        {
            vertices.Add(new Vector4F(1, -1, -1));
            vertices.Add(new Vector4F(1, 1, -1));
            vertices.Add(new Vector4F(1, 1, 1));
            vertices.Add(new Vector4F(1, -1, 1));
            vertices.Add(new Vector4F(-1, -1, -1));
            vertices.Add(new Vector4F(-1, 1, -1));
            vertices.Add(new Vector4F(-1, 1, 1));
            vertices.Add(new Vector4F(-1, -1, 1));

            triangles.Add(new Triangle(vertices[3], vertices[6], vertices[7]));
            triangles.Add(new Triangle(vertices[3], vertices[2], vertices[6]));
            triangles.Add(new Triangle(vertices[0], vertices[1], vertices[2]));
            triangles.Add(new Triangle(vertices[0], vertices[2], vertices[3]));
            triangles.Add(new Triangle(vertices[0], vertices[5], vertices[1]));
            triangles.Add(new Triangle(vertices[0], vertices[4], vertices[5]));
            triangles.Add(new Triangle(vertices[2], vertices[1], vertices[5]));
            triangles.Add(new Triangle(vertices[5], vertices[6], vertices[2]));
            triangles.Add(new Triangle(vertices[6], vertices[5], vertices[4]));
            triangles.Add(new Triangle(vertices[4], vertices[7], vertices[6]));
            triangles.Add(new Triangle(vertices[4], vertices[0], vertices[3]));
            triangles.Add(new Triangle(vertices[3], vertices[7], vertices[4]));
        }
    }
}
