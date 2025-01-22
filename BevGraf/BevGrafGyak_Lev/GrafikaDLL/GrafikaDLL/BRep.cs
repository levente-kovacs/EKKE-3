using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class BRep
    {
        public BRep()
        {
            
        }
        public BRep(string file, FileType fileType)
        {
            throw new ProjectNotImplementedException();
        }

        public List<Vector4> vertices = new List<Vector4>();
        public List<Triangle> triangles = new List<Triangle>();
    }
}
