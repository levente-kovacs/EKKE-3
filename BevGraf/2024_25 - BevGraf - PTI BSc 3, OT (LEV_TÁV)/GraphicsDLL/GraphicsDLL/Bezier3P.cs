using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class Bezier3P
    {
        public static float B0(float t, float p) { throw new HomeworkException(); }
        public static float B1(float t, float p) { throw new HomeworkException(); }
        public static float B2(float t, float p) { throw new HomeworkException(); }
        public static float B3(float t, float p) { throw new HomeworkException(); }

        public Vector2F p0, p1, p2, p3;

        public Bezier3P(Vector2F p0, Vector2F p1, Vector2F p2, Vector2F p3)
        {
            this.p0 = p0 ?? throw new ArgumentNullException(nameof(p0));
            this.p1 = p1 ?? throw new ArgumentNullException(nameof(p1));
            this.p2 = p2 ?? throw new ArgumentNullException(nameof(p2));
            this.p3 = p3 ?? throw new ArgumentNullException(nameof(p3));
        }
    }
}
