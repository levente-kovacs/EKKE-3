using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class BRepCube : BRep
    {
        public BRepCube()
        {
            this.vertices.Add(new Vector4F(0, 0, 0));
            this.vertices.Add(new Vector4F(0, 0, 1));
            this.vertices.Add(new Vector4F(0, 1, 1));
            this.vertices.Add(new Vector4F(0, 1, 0));
            this.vertices.Add(new Vector4F(1, 0, 0));
            this.vertices.Add(new Vector4F(1, 0, 1));
            this.vertices.Add(new Vector4F(1, 1, 1));
            this.vertices.Add(new Vector4F(1, 1, 0));

            this.triangles.Add(new Triangle(vertices[0], vertices[1], vertices[2]));
            this.triangles.Add(new Triangle(vertices[0], vertices[2], vertices[3]));
            this.triangles.Add(new Triangle(vertices[7], vertices[6], vertices[5]));
            this.triangles.Add(new Triangle(vertices[7], vertices[5], vertices[4]));
            this.triangles.Add(new Triangle(vertices[0], vertices[4], vertices[5]));
            this.triangles.Add(new Triangle(vertices[0], vertices[5], vertices[1]));
            this.triangles.Add(new Triangle(vertices[1], vertices[5], vertices[6]));
            this.triangles.Add(new Triangle(vertices[1], vertices[6], vertices[2]));
            this.triangles.Add(new Triangle(vertices[2], vertices[6], vertices[7]));
            this.triangles.Add(new Triangle(vertices[2], vertices[7], vertices[3]));
            this.triangles.Add(new Triangle(vertices[3], vertices[7], vertices[4]));
            this.triangles.Add(new Triangle(vertices[3], vertices[4], vertices[0]));
        }
    }
}
