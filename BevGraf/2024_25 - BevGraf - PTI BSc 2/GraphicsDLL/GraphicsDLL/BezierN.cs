using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public class BezierN
    {
        public static class Basis
        {
            private static int Binom(int n, int k)
            {
                if (k == 0 || k == n) return 1;
                if (n == 0) return 0;
                return Binom(n - 1, k - 1) + Binom(n - 1, k);
            }

            public static float B(int i, int n, float t)
            {
                return Binom(n, i) * MathF.Pow(1.0f - t, n - i) * MathF.Pow(t, i);
            }
        }

        public List<Vector2F> p = new List<Vector2F>();

        public BezierN(List<Vector2F> p)
        {
            this.p = p;
        }
    }
}
