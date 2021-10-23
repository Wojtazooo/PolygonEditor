using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    class RightAngleConstraint : PolygonConstraint
    {
        private static int _constraintCounter = 0;
        public int Id { get; private set; }

        public (int a, int b) SecondEdge; 

        public RightAngleConstraint(Polygon polygon, List<MyPoint> relatedMyPoints) : base(polygon)
        {
            _constraintCounter++;
            Id = _constraintCounter;
            RelatedVertices.a = _polygon.Vertices.IndexOf(relatedMyPoints[0]);
            RelatedVertices.b = _polygon.Vertices.IndexOf(relatedMyPoints[1]);
            SecondEdge.a = _polygon.Vertices.IndexOf(relatedMyPoints[2]);
            SecondEdge.b = _polygon.Vertices.IndexOf(relatedMyPoints[3]);
            _polygon.AddContraint(this);
            MoreThanOneEdge = true;
        }
        public override void DrawConstraintInfo(Graphics g)
        {
            GraphicsApplier.ApplyString(g, $"|_ {Id}", GetCenterMyPointFirstEdge());
            GraphicsApplier.ApplyString(g, $"|_  {Id}", GetCenterMyPointSecondEdge());
        }

        private bool Check()
        {
            return ExtensionMethods.CheckIfTwoEdgesArePerpendicular(
                _polygon,
                _polygon.Vertices[RelatedVertices.a],
                _polygon.Vertices[RelatedVertices.b],
                _polygon.Vertices[SecondEdge.a],
                _polygon.Vertices[SecondEdge.b]
            );
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            (MyPoint v1, MyPoint v2) = (_polygon.Vertices[RelatedVertices.a], _polygon.Vertices[RelatedVertices.b]);
            (MyPoint w1, MyPoint w2) = (_polygon.Vertices[SecondEdge.a], _polygon.Vertices[SecondEdge.b]);

            // if (v1 == w1 || v1 == v2 || v2 == w1 || v2 == w2)
            // {
            //     EnforceConstraintWhenOnlyThreePoints( v1,  v2,  w1,  w2, constantMyPoint);
            //     return;
            // }

            if (v1.GetPoint() == constantMyPoint.GetPoint() || v2.GetPoint() == constantMyPoint.GetPoint())
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(v1, v2, w1, w2);
                _polygon.MoveVertex(w2, movedMyPoint);
            }
            else
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(w1,w2,v1,v2);
                _polygon.MoveVertex(v2, movedMyPoint);
            }
        }

        private void EnforceConstraintWhenOnlyThreePoints(MyPoint v1m, MyPoint v2m, MyPoint w1m, MyPoint w2m, MyPoint constantm)
        {
            // Point v1 = v1m.GetPoint();
            // Point v2 = v2m.GetPoint();
            // Point w1 = w1m.GetPoint();
            // Point w2 = w2m.GetPoint();
            // Point constant = constantm.GetPoint();
            //
            //
            // List<Point> points = new List<Point>();
            // List<MyPoint> myPoints = new List<MyPoint>();
            //
            // if (v1 == w1)
            // {
            //     points = new List<Point> {v2, v1, w2};
            //     myPoints = new List<MyPoint> {v2m, v1m, w2m};
            // }
            // else if (v1 == w2)
            // {
            //     points = new List<Point> {v2, v1, w1};
            //     myPoints = new List<MyPoint> {v2m, v1m, w2m};
            // }
            // else if (w1 == v2)
            // {
            //     points = new List<Point> {v1, v2, w2};
            //     myPoints = new List<MyPoint> {v2m, v1m, w2m};
            // }
            // else if (w2 == v2)
            // {
            //     points = new List<Point> {v1, v2, w1};
            //     myPoints = new List<MyPoint> {v2m, v1m, w2m};
            // }
            //
            // if (points.Count == 0) throw new NotImplementedException();
            //
            // int constantIndex = -1;
            // for (int i = 0; i < points.Count; i++)
            // {
            //     if (points[i] == constant)
            //         constantIndex = i;
            // }
            //
            // if (constantIndex == -1) throw new NotImplementedException();
            //
            //
            //
            // if (constantIndex == 0)
            // {
            //     MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(
            //         new MyPoint(points[0]),
            //         new MyPoint(points[1]),
            //         new MyPoint(points[1]),
            //         new MyPoint(points[2]));
            //     
            //     _polygon.MoveVertex(myPoints[0], movedMyPoint);
            // }
            // else if(constantIndex == 1)
            // {
            //     MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(
            //         new MyPoint(points[0]),
            //         new MyPoint(points[1]),
            //         new MyPoint(points[1]),
            //         new MyPoint(points[2]));
            //     
            //     _polygon.MoveVertex(myPoints[0], movedMyPoint);
            //     _polygon.MoveVertex(myPoints[0], movedMyPoint);
            // }
            // else
            // {
            //     MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(
            //         new MyPoint(points[2]),
            //         new MyPoint(points[1]),
            //         new MyPoint(points[1]),
            //         new MyPoint(points[0]));
            //     
            //     _polygon.MoveVertex(myPoints[2], movedMyPoint);
            // }
            //
            if(v1m == w1m || v2m == w2m)
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(v1m, v2m, w1m, w2m);
                _polygon.MoveVertex(w2m, movedMyPoint);
            }
            else if(v2m == w1m || v2m == w2m)
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(w1m, w2m, v2m, v1m);
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
