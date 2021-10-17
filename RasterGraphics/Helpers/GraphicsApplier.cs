using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.RasterGraphics.Helpers
{
    public static class GraphicsApplier
    {
        public static void ApplyString(Graphics g, string stringToApply, Point center)
        {
            var stringSize = g.MeasureString(stringToApply.ToString(), Constants.CONSTRAINTS_FONT);
            stringSize.Width += 2;
            stringSize.Height += 2;

            Point leftUpperCorner =
                ExtensionMethods.FindLeftUpperCornerForRectangle(
                    center,
                    (int)stringSize.Width,
                    (int)stringSize.Height);

            Rectangle rectangle = new Rectangle(leftUpperCorner, stringSize.ToSize());

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(stringToApply.ToString(), Constants.CONSTRAINTS_FONT, Brushes.Black, rectangle);
        }

        public static void ApplyCircle(Graphics g, Point center, int radius)
        {
            g.FillEllipse(Brushes.Black, new Rectangle(center.X - radius, center.Y - radius, 2*radius, 2*radius));
        }
    }
}
