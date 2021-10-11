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
        
        public Line(Color color): base(color) { }

        public Line(Point p1, Point p2, Color color): base(color)
        {
            P1 = p1;
            P2 = p2;
            Color = color;
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

        public override void Update()
        {
            _pixels = LineGenerator.GetPixels(P1, P2, Color);
        }

        public override Point? DetectObject(Point mousePoint, int radius)
        {
            return null;
        }

        public override void Move(Point from, Point to)
        {
            Point newP1 = ExtensionMethods.MovePoint(P1, from, to);
            Point newP2 = ExtensionMethods.MovePoint(P2, from, to);
            SetP1AndP2(newP1, newP2);
        }

        public override RasterObject Clone()
        {
            return new Line(P1, P2, Color);
        }
    }
}
