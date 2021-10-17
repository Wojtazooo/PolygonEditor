using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.CircleConstraints
{
    class CircleTangentToPolygonConstraint : CircleConstraint
    {
        private Polygon _polygon;
        private int _v1;
        private int _v2;

        public CircleTangentToPolygonConstraint(Circle circle, Polygon polygon, int v1, int v2): base(circle)
        {
            _circle.Constraints.RemoveAll(c => c is ConstantCenterConstraint);
            _polygon = polygon;
            _v1 = v1;
            _v2 = v2;
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            Point center = ExtensionMethods.CountMiddleOfSegment(_polygon.Vertices[_v1], _polygon.Vertices[_v2]);
            GraphicsApplier.ApplyCircle(
                g,
                center,
                Constants.DETECTION_RADIUS/2);
        }

        public override void EnforceConstraint(Point constantPoint)
        {
            Point newCenter = ExtensionMethods.FindCenterOfCircleTangentToEdge(_polygon.Vertices[_v1], _polygon.Vertices[_v2], _circle.Radius);
            _circle.SetCenter(newCenter);
        }

        public override Point GetCenterDrawingPoint()
        {
            return ExtensionMethods.CountMiddleOfSegment(_polygon.Vertices[_v1], _polygon.Vertices[_v2]);
        }
    }
}
