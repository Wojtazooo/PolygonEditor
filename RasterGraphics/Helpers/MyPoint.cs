using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.RasterGraphics.Helpers
{
    public class MyPoint
    {
        public double X { get; set; }
        public double Y { get; set; }

        public MyPoint()
        {
            X = 0;
            Y = 0;
        }

        public MyPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public MyPoint(Point p)
        {
            X = p.X;
            Y = p.Y;
        }
        public MyPoint(MyPoint p)
        {
            X = p.X;
            Y = p.Y;
        }
        public Point GetPoint()
        {
            return new Point((int)Math.Round(X), (int)Math.Round(Y));
        }

        public static bool operator ==(MyPoint a, MyPoint b)
        {
            if (a is null)
            {
                if(b is null)
                {
                    return true;
                }
                return false;
            }
            return a.Equals(b);
        }

        public static bool operator !=(MyPoint a, MyPoint b) 
        {
            return !(a == b);
        }

        protected virtual bool Equals(MyPoint other) => other?.X == X && other?.Y == Y;

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
