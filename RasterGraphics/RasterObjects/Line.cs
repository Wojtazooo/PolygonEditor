using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    public class Line : RasterObject
    {
        public MyPoint P1 { get; private set; }
        public MyPoint P2 { get; private set; }
        
        public Line(Color color): base(color) { }

        public Line(MyPoint p1, MyPoint p2, Color color): base(color)
        {
            P1 = p1;
            P2 = p2;
            Color = color;
            Update();
        }

        public void SetP1(MyPoint p1)
        {
            P1 = p1;
            Update();
        }

        public void SetP2(MyPoint p2)
        {
            P2 = p2;
            Update();
        }

        public void SetP1AndP2(MyPoint p1, MyPoint p2)
        {
            P1 = p1;
            P2 = p2;
            Update();
        }

        public override void Update()
        {
            _pixels = LineGenerator.GetPixels(P1.GetPoint(), P2.GetPoint(), Color);
        }

        public override MyPoint DetectObject(MyPoint mousePoint, int radius)
        {
            return null;
        }

        public override void MoveRasterObject(MyPoint from, MyPoint to)
        {
            MyPoint newP1 = ExtensionMethods.MovePoint(P1, from, to);
            MyPoint newP2 = ExtensionMethods.MovePoint(P2, from, to);
            SetP1AndP2(newP1, newP2);
        }

        public override RasterObject Clone()
        {
            return new Line(P1, P2, Color);
        }

        public override void DrawConstraints(Graphics g)
        {
        }

        public override bool RemoveConstraintByClick(MyPoint mousePoint)
        {
            return false;
        }

        public override bool DetectConstraint(MyPoint mousePoint)
        {
            return false;
        }
    }
}
