using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GrafikaDLL
{
    public static class ExtensionPoint
    {
        public static int GRAB_DIST = 4;

        public static bool IsGrabbedBy(this Point p, Point point)
        {
            return Math.Abs(p.X - point.X) <= GRAB_DIST &&
                   Math.Abs(p.Y - point.Y) <= GRAB_DIST;
        }

        public static double DistanceTo(this Point p, Point point)
        {
            return Math.Sqrt((p.X - point.X) * (p.X - point.X) +
                             (p.Y - point.Y) * (p.Y - point.Y));
        }
    }
}
