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
        public static class Settings
        {
            public static int GRAB_DISTANCE = 5;
        }

        public static bool IsGrabbedBy(this PointF point, PointF other)
        {
            return MathF.Abs(point.X - other.X) <= Settings.GRAB_DISTANCE &&
                   MathF.Abs(point.Y - other.Y) <= Settings.GRAB_DISTANCE;
        }

        public const byte TOP = 1;
        public const byte RIGHT = 2;
        public const byte BOTTOM = 4;
        public const byte LEFT = 8;
        public static byte OutCode(this PointF p, RectangleF win)
        {
            byte code = 0;
            
            if (p.X < win.Left)
                code |= LEFT;
            else if (p.X > win.Right)
                code |= RIGHT;

            if (p.Y < win.Top)
                code |= TOP;
            else if (p.Y > win.Bottom)
                code |= BOTTOM;
            
            return code;
        }
    }
}
