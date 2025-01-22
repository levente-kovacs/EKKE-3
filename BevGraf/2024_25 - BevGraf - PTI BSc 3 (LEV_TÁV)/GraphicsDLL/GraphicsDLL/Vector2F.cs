using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class Vector2F
    {
        public float x, y;

        public Vector2F(float x = 0, float y = 0)
        {
            this.x = x;
            this.y = y;
        }

        public static Vector2F operator +(Vector2F u, Vector2F v)
        {
            return new Vector2F(u.x + v.x, u.y + v.y);
        }
        public static Vector2F operator -(Vector2F u, Vector2F v)
        {
            return new Vector2F(u.x - v.x, u.y - v.y);
        }
        public static Vector2F operator *(Vector2F u, float lambda)
        {
            return new Vector2F(u.x * lambda, u.y  * lambda);
        }
        public static Vector2F operator *(float lambda, Vector2F u)
        {
            return u * lambda;
        }

        //implicit operator: Vector2F -> PointF
    }
}
