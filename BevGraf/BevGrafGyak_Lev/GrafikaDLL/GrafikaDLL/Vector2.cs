using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public class Vector2
    {
        public double x, y;

        public Vector2() : this(0.0, 0.0)
        {

        }
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public bool IsGrabbedBy(Point point)
        {
            return Math.Abs(x - point.X) <= ExtensionPoint.GRAB_DIST &&
                   Math.Abs(y - point.Y) <= ExtensionPoint.GRAB_DIST;
        }

        public static Vector2 operator +(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x + v2.x, v1.y + v2.y);
        }
        public static Vector2 operator -(Vector2 v1, Vector2 v2)
        {
            return new Vector2(v1.x - v2.x, v1.y - v2.y);
        }
    }
}
