using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public static class ExtensionPointF 
    {
        public static bool IsGrabbedBY(this PointF point, PointF p)
        {
            return MathF.Abs(p.X - point.X) < Settings.GRAB_DISTANCE &&
                   MathF.Abs(p.Y - point.Y) < Settings.GRAB_DISTANCE;
        }

        public static byte OutCode(this PointF p, RectangleF win)
        {
            byte code = 0;

            if (p.X < win.Left)
                code |= CohenSutherlandHelper.LEFT;
            else if (win.Right < p.X)
                code |= CohenSutherlandHelper.RIGHT;

            if (p.Y < win.Top)
                code |= CohenSutherlandHelper.TOP;
            else if (win.Bottom < p.Y)
                code |= CohenSutherlandHelper.BOTTOM;

            return code;
        }
    }
}
