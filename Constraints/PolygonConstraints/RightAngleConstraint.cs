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


        public RightAngleConstraint(Polygon polygon, List<MyPoint> relatedMyPoints, bool increaseCounter = true) : base(polygon)
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
            GraphicsApplier.ApplyString(g, $"|_ {Id}", GetCenterMyPointFirstEdge());
        }

        private bool Check()
        {
            return SecondEdge != null && ExtensionMethods.CheckIfTwoEdgesArePerpendicular(
                _polygon,
                _polygon.Vertices[RelatedVertices.a],
                _polygon.Vertices[RelatedVertices.b],
                _polygon.Vertices[SecondEdge.Value.a],
                _polygon.Vertices[SecondEdge.Value.b]
            );
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            if(!SecondEdge.HasValue) return;
            (MyPoint v1, MyPoint v2) = (_polygon.Vertices[RelatedVertices.a], _polygon.Vertices[RelatedVertices.b]);
            (MyPoint w1, MyPoint w2) = (_polygon.Vertices[SecondEdge.Value.a], _polygon.Vertices[SecondEdge.Value.b]);

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
            MyPoint v1 = _polygon.Vertices[SecondEdge.Value.a];
            MyPoint v2 = _polygon.Vertices[SecondEdge.Value.b];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }
    }
}
