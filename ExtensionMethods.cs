using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public static class ExtensionMethods
    {
        public static int PixelDistance(Point p1, Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            int distance = (int)Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
            return distance;
        }

        public static bool IsInCircle(Point point, Point circleCenter, int radius)
        {
            int dx = point.X - circleCenter.X;
            int dy = point.Y - circleCenter.Y;
            return (Math.Pow(dx, 2) + Math.Pow(dy, 2) <= Math.Pow(radius, 2));
        }

        public static int CountDistanceFromCircleCenterToLine(Point circleCenter, Point p1, Point p2)
        {
            return 0;
        }
    }
}
