using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class BSpline
    {
        public static class Basis
        {
            public static float N0(float t) { return 1.0f / 6.0f * (1.0f - t) * (1.0f - t) * (1.0f - t); }
            public static float N1(float t) { return 0.5f * t * t * t - t * t + 2.0f / 3.0f; }
            public static float N2(float t) { return -0.5f * t * t * t + 0.5f * t * t + 0.5f * t + 1.0f / 6.0f; }
            public static float N3(float t) { return 1.0f / 6.0f * t * t * t; }
        }

        public Vector2F p0, p1, p2, p3;

        public BSpline(Vector2F p0, Vector2F p1, Vector2F p2, Vector2F p3)
        {
            this.p0 = p0 ?? throw new ArgumentNullException(nameof(p0));
            this.p1 = p1 ?? throw new ArgumentNullException(nameof(p1));
            this.p2 = p2 ?? throw new ArgumentNullException(nameof(p2));
            this.p3 = p3 ?? throw new ArgumentNullException(nameof(p3));
        }
    }
}
