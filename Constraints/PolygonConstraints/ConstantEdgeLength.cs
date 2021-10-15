using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    public class ConstantEdgeLength : PolygonConstraint
    {
        private int _constantLength;

        public ConstantEdgeLength(Polygon polygon, Point v1, Point v2, int constantLength) : base(polygon)
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

            RelatedVertices = new List<int> { numberOfV1, numberOfV2 };
            _constantLength = constantLength;
        }

        public override void EnforceConstraint(Point constantPoint)
        {
            (Point, Point) _edgePoints = (_polygon.Vertices[RelatedVertices[0]], _polygon.Vertices[RelatedVertices[1]]);

            if (constantPoint == _edgePoints.Item1)
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(_edgePoints.Item2, _edgePoints.Item1, _constantLength);
                _polygon.MoveVertex(_edgePoints.Item2, movedPoint);

                SetNextConstraints(RelatedVertices[1]);
            }
            else
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(_edgePoints.Item1, _edgePoints.Item2, _constantLength);
                _polygon.MoveVertex(_edgePoints.Item1, movedPoint);
                SetNextConstraints(RelatedVertices[0]);
            }
        }

        private void SetNextConstraints(int movedVertex)
        {
            nextPolygonConstraints = new List<PolygonConstraint>();
            foreach (var c in _polygon.Constraints)
            {
                if (c.RelatedVertices.Contains(movedVertex))
                {
                    nextPolygonConstraints.Add(c);
                }
            }
        }
    }
}
