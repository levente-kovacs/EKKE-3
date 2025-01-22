﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsDLL
{
    public static class ExtensionBitmap
    {
        public static void SetLine(this Bitmap bmp, PointF p0, PointF p1, Color c)
        {
            float dx = p1.X - p0.X;
            float dy = p1.Y - p0.Y;
            float length = Math.Abs(dx);
            if (Math.Abs(dy) > length)
                length = Math.Abs(dy);
            float incX = dx / length;
            float incY = dy / length;
            float x = p0.X, y = p0.Y;
            bmp.SetPixel((int)x, (int)y, c);
            for (int i = 0; i < length; i++)
            {
                x += incX;
                y += incY;
                bmp.SetPixel((int)x, (int)y, c);
            }
        }
        
        public static void FillScanline(this Bitmap bmp, Color border, Color fill)
        {
            for (int y = 0; y < bmp.Height; y++)
            {
                bool inside = false;
                for (int x = 0; x < bmp.Width; x++)
                {
                    Color c = bmp.GetPixel(x, y);
                    if (c.R == border.R && c.G == border.G && c.B == border.B)
                    {
                        inside = !inside;
                        continue;
                    }
                    if (inside)
                        bmp.SetPixel(x, y, fill);
                }
            }
        }

        private static bool ISODD = false; 
        public static Bitmap SupersamplingV1(this Bitmap bmp)
        {
            Bitmap result = new Bitmap(bmp.Width, bmp.Height);
            for (int y = 0; y < bmp.Height - 1; y++)
            {
                for (int x = 0; x < bmp.Width - 1; x++)
                {
                    Color c0 = bmp.GetPixel(x, y);
                    Color c1 = bmp.GetPixel(x + 1, y);
                    Color c2 = bmp.GetPixel(x, y + 1);
                    Color c3 = bmp.GetPixel(x + 1, y + 1);

                    Color c = Color.FromArgb(
                        (c0.R + c1.R + c2.R + c3.R) / 4,
                        (c0.G + c1.G + c2.G + c3.G) / 4,
                        (c0.B + c1.B + c2.B + c3.B) / 4
                        );
                    result.SetPixel(x, y, c);
                }
            }

            ISODD = !ISODD;
            return result;
        }

        public delegate float ImplicitExpression(float x, float y);
        public static void DrawImplicitCurve(this Bitmap bmp,
            Color color,
            ImplicitExpression curve)
        {
            throw new Exception();
        }
        public static void FillImplicitCurve(this Bitmap bmp,
            Color color,
            ImplicitExpression curve)
        {
            throw new Exception();
        }
    }
}
