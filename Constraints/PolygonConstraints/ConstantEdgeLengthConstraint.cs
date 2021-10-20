using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    public class ConstantEdgeLengthConstraint : PolygonConstraint
    {
        private int _constantLength;

        public ConstantEdgeLengthConstraint(Polygon polygon, MyPoint v1, MyPoint v2, int constantLength) : base(polygon)
        {
            int numberOfV1 = 0;
            int numberOfV2 = 0;
            for (int i = 0; i < polygon.Vertices.Count; i++)
            {
                if (polygon.Vertices[i] == v1)
                {
                    numberOfV1 = i;
                }
                else if (polygon.Vertices[i] == v2)
                {
                    numberOfV2 = i;
                }
            }

            RelatedVertices.Add(numberOfV1);
            RelatedVertices.Add(numberOfV2);
            _constantLength = constantLength;
            _polygon.AddContraint(this);
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            (MyPoint, MyPoint) _edgeMyPoints = (_polygon.Vertices[RelatedVertices[0]], _polygon.Vertices[RelatedVertices[1]]);

            if (constantMyPoint == _edgeMyPoints.Item1)
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(_edgeMyPoints.Item2, _edgeMyPoints.Item1, _constantLength);
                _polygon.MoveVertex(_edgeMyPoints.Item2, movedMyPoint);
            }
            else
            {
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(_edgeMyPoints.Item1, _edgeMyPoints.Item2, _constantLength);
                _polygon.MoveVertex(_edgeMyPoints.Item1, movedMyPoint);
            }
        }

        private MyPoint RelationCenterMyPoint()
        {
            return ExtensionMethods.CountMiddleOfSegment(
                    _polygon.Vertices[RelatedVertices[0]],
                    _polygon.Vertices[RelatedVertices[1]]);
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            MyPoint center = RelationCenterMyPoint();
            GraphicsApplier.ApplyString(g, _constantLength.ToString(), center);
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return RelationCenterMyPoint();
        }
    }
}
