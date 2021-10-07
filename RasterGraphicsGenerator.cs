using System;
using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor
{
    public static class RasterGraphicsGenerator
    {
        public static List<Pixel> GetLinePoints(Point p1, Point p2, Color color)
        {
            List<Pixel> linePixels = new List<Pixel>();

            // TODO: Implement Bresenham's line algorithm for all angle cases

            // test line drawing
            int minX = Math.Min(p1.X, p2.X);
            int maxX = Math.Max(p1.X, p2.X);

            for (int i = minX; i < maxX; i++)
            {
                linePixels.Add(new Pixel(new Point(i, p1.Y), color));
            }

            return linePixels;
        }
    }
}
