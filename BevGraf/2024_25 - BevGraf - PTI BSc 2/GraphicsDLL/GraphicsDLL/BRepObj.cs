using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class BRepObj : ModelBRep
    {
        public BRepObj(string file)
        {
            using (StreamReader sr = new StreamReader(file))
            {
                while (!sr.EndOfStream)
                {
                    string row = sr.ReadLine();
                    string[] data = row.Split(' ');
                    switch (data[0])
                    {
                        case "v": 
                            vertices.Add(new Vector4F(float.Parse(data[1], CultureInfo.InvariantCulture),
                                                      float.Parse(data[2], CultureInfo.InvariantCulture),
                                                      float.Parse(data[3], CultureInfo.InvariantCulture)));
                            break;
                        case "f":
                            triangles.Add(new Triangle(vertices[int.Parse(data[1]) - 1],
                                                       vertices[int.Parse(data[2]) - 1],
                                                       vertices[int.Parse(data[3]) - 1]));
                            break;
                        default: break;
                    }
                }
            }
        }
    }
}
