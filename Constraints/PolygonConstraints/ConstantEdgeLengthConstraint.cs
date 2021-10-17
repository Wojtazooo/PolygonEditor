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

        public ConstantEdgeLengthConstraint(Polygon polygon, Point v1, Point v2, int constantLength) : base(polygon)
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
        }

        public override void EnforceConstraint(Point constantPoint)
        {
            (Point, Point) _edgePoints = (_polygon.Vertices[RelatedVertices[0]], _polygon.Vertices[RelatedVertices[1]]);

            if (constantPoint == _edgePoints.Item1)
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(_edgePoints.Item2, _edgePoints.Item1, _constantLength);
                _polygon.MoveVertex(_edgePoints.Item2, movedPoint);
            }
            else
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(_edgePoints.Item1, _edgePoints.Item2, _constantLength);
                _polygon.MoveVertex(_edgePoints.Item1, movedPoint);
            }
        }

        private Point RelationCenterPoint()
        {
            return ExtensionMethods.CountMiddleOfSegment(
                    _polygon.Vertices[RelatedVertices[0]],
                    _polygon.Vertices[RelatedVertices[1]]);
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            var stringSize = g.MeasureString(_constantLength.ToString(), Constants.CONSTRAINTS_FONT);
            stringSize.Width += 2;
            stringSize.Height += 2;

            Point center = RelationCenterPoint();

            Point leftUpperCorner = 
                ExtensionMethods.FindLeftUpperCornerForRectangle(
                    center,
                    (int)stringSize.Width, 
                    (int)stringSize.Height);

            Rectangle rectangle = new Rectangle(leftUpperCorner, stringSize.ToSize());

            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.DrawString(_constantLength.ToString(), Constants.CONSTRAINTS_FONT, Brushes.Black, rectangle);
        }

        public override Point GetCenterDrawingPoint()
        {
            return RelationCenterPoint();
        }
    }
}
