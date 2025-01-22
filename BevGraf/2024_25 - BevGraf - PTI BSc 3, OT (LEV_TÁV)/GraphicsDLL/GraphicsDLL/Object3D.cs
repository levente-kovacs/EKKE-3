using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class Object3D
    {
        public Matrix4F transformation;

        public Object3D()
        {
            this.transformation = new Matrix4F();
            this.transformation.LoadIdentity();
        }

        public void PushTransformation(Matrix4F transformation)
        {
            this.transformation = transformation * this.transformation;
        }
        public void LoadIdentity()
        {
            this.transformation.LoadIdentity();
        }
    }
}
