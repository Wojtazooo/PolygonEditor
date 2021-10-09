using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    class Line : RasterObject
    {
        public Point P1 { get; private set; }
        public Point P2 { get; private set; }
        private Color _color;

        public Line(Color color)
        {
            _color = color;
        }

        public Line(Point p1, Point p2, Color color)
        {
            P1 = p1;
            P2 = p2;
            _color = color;
            Update();
        }

        public void SetP1(Point p1)
        {
            P1 = p1;
            Update();
        }

        public void SetP2(Point p2)
        {
            P2 = p2;
            Update();
        }

        public void SetP1AndP2(Point p1, Point p2)
        {
            P1 = p1;
            P2 = p2;
            Update();
        }

        public void SetColor(Color color)
        {
            _color = color;
            Update();
        }

        public override void Update()
        {
            _pixels = LineGenerator.GetPixels(P1, P2, _color);
        }
    }
}
