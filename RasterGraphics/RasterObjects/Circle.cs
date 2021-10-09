using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    class Circle : RasterObject
    {
        public Point Center { get; private set; }
        public int Radius { get; private set; }
        public Color Color { get; private set; }

        public Circle(Point center, int radius, Color color)
        {
            Center = center;
            Radius = radius;
            Color = color;
            Update();
        }

        public override void Update()
        {
            _pixels = CircleGenerator.GetPixels(Center,Radius,Color);
        }

        public void SetRadius(int newRadius)
        {
            Radius = newRadius;
            Update();
        }

        public void SetColor(Color color)
        {
            Color = color;
            Update();
        }
    }
}
