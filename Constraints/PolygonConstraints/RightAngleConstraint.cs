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
        public RightAngleConstraint(Polygon polygon, List<MyPoint> relatedMyPoints) : base(polygon)
        {
            foreach (var i in relatedMyPoints)
            {
                RelatedVertices.Add(_polygon.Vertices.IndexOf(i));
            }
            _polygon.AddContraint(this);
        }
        public override void DrawConstraintInfo(Graphics g)
        {
            GraphicsApplier.ApplyString(g, "right angle", GetCenterMyPointFirstEdge());
            GraphicsApplier.ApplyString(g, "right angle", GetCenterMyPointSecondEdge());
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            (MyPoint v1, MyPoint v2) = (_polygon.Vertices[RelatedVertices[0]], _polygon.Vertices[RelatedVertices[1]]);
            (MyPoint w1, MyPoint w2) = (_polygon.Vertices[RelatedVertices[2]], _polygon.Vertices[RelatedVertices[3]]);

            if (v1 == w1 || v1 == v2 || v2 == w1 || v2 == w2)
            {
                EnforceConstraintWhenOnlyThreePoints( v1,  v2,  w1,  w2);
                return;
            }

            if (v1 == constantMyPoint || v2 == constantMyPoint)
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

        private void EnforceConstraintWhenOnlyThreePoints(MyPoint v1, MyPoint v2, MyPoint w1, MyPoint w2)
        {
            if(v1 == w1 || v2 == w2)
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(v1, v2, w1, w2);
                _polygon.MoveVertex(w2, movedMyPoint);
            }
            else if(v2 == w1 || v2 == w2)
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveRightAngle(w1, w2, v2, v1);
                _polygon.MoveVertex(v1, movedMyPoint);
            }
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return GetCenterMyPointFirstEdge();
        }

        private MyPoint GetCenterMyPointFirstEdge()
        {
            MyPoint v1 = _polygon.Vertices[RelatedVertices[0]];
            MyPoint v2 = _polygon.Vertices[RelatedVertices[1]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }

        private MyPoint GetCenterMyPointSecondEdge()
        {
            MyPoint v1 = _polygon.Vertices[RelatedVertices[2]];
            MyPoint v2 = _polygon.Vertices[RelatedVertices[3]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }
    }
}
