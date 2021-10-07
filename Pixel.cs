using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public class Pixel
    {
        private Point _point;
        public Color Color;
        public int X => _point.X;
        public int Y => _point.Y;

        public Pixel(Point point, Color color)
        {
            this._point = point;
            this.Color = color;
        }
    }
}
