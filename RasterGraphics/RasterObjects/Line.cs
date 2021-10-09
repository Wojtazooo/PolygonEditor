using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System.Drawing;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    class Line : RasterObject
    {
        private Point _p1;
        private Point _p2;
        private Color _color;

        public Line(Point p1, Point p2, Color color)
        {
            _p1 = p1;
            _p2 = p2;
            _color = color;
            Update();
        }

        public void SetP1(Point p1)
        {
            _p1 = p1;
            Update();
        }

        public void SetP2(Point p2)
        {
            _p2 = p2;
            Update();
        }
        public void SetColor(Color color)
        {
            _color = color;
            Update();
        }

        void Update()
        {
            _pixels = LineGenerator.GetPixels(_p1, _p2, _color);
        }
    }
}
