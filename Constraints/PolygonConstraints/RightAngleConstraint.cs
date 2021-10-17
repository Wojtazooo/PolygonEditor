using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    class RightAngleConstraint : PolygonConstraint
    {
        public RightAngleConstraint(Polygon polygon, List<Point> relatedPoints) : base(polygon)
        {
            foreach (var i in relatedPoints)
            {
                RelatedVertices.Add(_polygon.Vertices.IndexOf(i));
            }
            _polygon.AddContraint(this);
        }
        public override void DrawConstraintInfo(Graphics g)
        {
            GraphicsApplier.ApplyString(g, "right angle", GetCenterPointFirstEdge());
            GraphicsApplier.ApplyString(g, "right angle", GetCenterPointSecondEdge());
        }

        public override void EnforceConstraint(Point constantPoint)
        {
            (Point v1, Point v2) = (_polygon.Vertices[RelatedVertices[0]], _polygon.Vertices[RelatedVertices[1]]);
            (Point w1, Point w2) = (_polygon.Vertices[RelatedVertices[2]], _polygon.Vertices[RelatedVertices[3]]);

            if (v1 == constantPoint || v2 == constantPoint)
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveRightAngle(v1, v2, w1, w2);
                _polygon.MoveVertex(w2, movedPoint);
            }
            else
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveRightAngle(w1,w2,v1,v2);
                _polygon.MoveVertex(v2, movedPoint);
            }
        }

        public override Point GetCenterDrawingPoint()
        {
            return GetCenterPointFirstEdge();
        }

        private Point GetCenterPointFirstEdge()
        {
            Point v1 = _polygon.Vertices[RelatedVertices[0]];
            Point v2 = _polygon.Vertices[RelatedVertices[1]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }

        private Point GetCenterPointSecondEdge()
        {
            Point v1 = _polygon.Vertices[RelatedVertices[2]];
            Point v2 = _polygon.Vertices[RelatedVertices[3]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }
    }
}
