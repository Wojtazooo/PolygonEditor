using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Intrinsics;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    class SameLengthConstraint : PolygonConstraint
    {
        
        private static int _constraintCounter = 0;
        public int Id { get; private set; }
        public (int a, int b) SecondEdge;
        
        public SameLengthConstraint(Polygon polygon, List<MyPoint> relatedMyPoints, bool increaseCounter = true) : base(polygon) 
        {
            if(increaseCounter)
                _constraintCounter++;
            Id = _constraintCounter;
            RelatedVertices.a = _polygon.Vertices.IndexOf(relatedMyPoints[0]);
            RelatedVertices.b = _polygon.Vertices.IndexOf(relatedMyPoints[1]);
            SecondEdge = new(_polygon.Vertices.IndexOf(relatedMyPoints[2]),
                _polygon.Vertices.IndexOf(relatedMyPoints[3]));
            _polygon.AddContraint(this);
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            GraphicsApplier.ApplyString(g, $"== {Id}", GetCenterMyPointFirstEdge());
            GraphicsApplier.ApplyString(g, $"== {Id}", GetCenterMyPointSecondEdge());
        }

        bool CheckConstraint()
        {
            var l1 = ExtensionMethods.PixelDistance(_polygon.Vertices[RelatedVertices.a], _polygon.Vertices[RelatedVertices.b]);
            var l2 = ExtensionMethods.PixelDistance(_polygon.Vertices[SecondEdge.a], _polygon.Vertices[SecondEdge.b]);
            return (Math.Abs(Math.Abs(l1) - Math.Abs(l2))) < Constants.PIXEL_TOLERANCE;
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            if (CheckConstraint()) return;
            (MyPoint v1m, MyPoint v2m) = (_polygon.Vertices[RelatedVertices.a], _polygon.Vertices[RelatedVertices.b]);
            (MyPoint w1m, MyPoint w2m) = (_polygon.Vertices[SecondEdge.a], _polygon.Vertices[SecondEdge.b]);

            Point v1 = v1m.GetPoint();
            Point v2 = v2m.GetPoint();
            Point w1 = w1m.GetPoint();
            Point w2 = w2m.GetPoint();
            Point constant = constantMyPoint.GetPoint();

            double lengthV = ExtensionMethods.PixelDistance(v1m, v2m); 
            double lengthW = ExtensionMethods.PixelDistance(w1m, w2m); 
            
            if (v1 == w2)
            {
                if (constant == v2 || constant == v1)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(w1m,w2m,lengthV);
                    _polygon.MoveVertex(w1m, movedMyPoint);
                    return;
                }
                else if (constant == w1)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(v2m,v1m,lengthW);
                    _polygon.MoveVertex(v2m, movedMyPoint);
                    return;
                }
            }
            else if (v2 == w2)
            {
                if (constant == v1 || constant == v2)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(w1m,w2m,lengthV);
                    _polygon.MoveVertex(w1m, movedMyPoint);
                    return;
                }
                else if (constant == w1)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(v1m,v2m,lengthW);
                    _polygon.MoveVertex(v1m, movedMyPoint);
                    return;
                }
            }
            else if (v2 == w1)
            {
                if (w2 == constant || w1 == constant)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(v1m,v2m,lengthW);
                    _polygon.MoveVertex(v1m, movedMyPoint);
                    return;
                }
                else if (v1 == constant)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(w2m,w1m,lengthV);
                    _polygon.MoveVertex(w2m, movedMyPoint);
                    return;
                }
            }
            else if (v1 == w1)
            {
                if (v2 == constant || v1 == constant)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(w2m,w1m,lengthV);
                    _polygon.MoveVertex(w2m, movedMyPoint);
                    return;
                }
                else if (w2 == constant)
                {
                    MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(v2m,v1m,lengthW);
                    _polygon.MoveVertex(v2m, movedMyPoint);
                    return;
                }
            }

            if(v1 == constant || v2 == constant)
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(w1m,w2m,lengthV);
                _polygon.MoveVertex(w1m, movedMyPoint);
            }
            else
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(v1m, v2m, lengthW);
                _polygon.MoveVertex(v1m, movedMyPoint);
            }
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return GetCenterMyPointFirstEdge();
        }

        private MyPoint GetCenterMyPointFirstEdge()
        {
            MyPoint v1 = _polygon.Vertices[RelatedVertices.a];
            MyPoint v2 = _polygon.Vertices[RelatedVertices.b];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }

        private MyPoint GetCenterMyPointSecondEdge()
        {
            MyPoint v1 = _polygon.Vertices[SecondEdge.a];
            MyPoint v2 = _polygon.Vertices[SecondEdge.b];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }
    }
}
