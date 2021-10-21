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
    public class CircleTangentToPolygonConstraint : CircleConstraint
    {
        public Polygon Polygon { get; private set; }
        public int V1 { get; private set; }
        public int V2 { get; private set; }

        public CircleTangentToPolygonConstraint(Circle circle, Polygon polygon, int v1, int v2): base(circle)
        {
            Polygon = polygon;
            V1 = v1;
            V2 = v2;
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            MyPoint center = ExtensionMethods.FindPointWhereCircleStickToLine(
                Polygon.Vertices[V1],
                Polygon.Vertices[V2],
                _circle
                );

            GraphicsApplier.ApplyCircle(
                g,
                center,
                Constants.DETECTION_RADIUS/2);
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            if(_circle.ConstantCenterConstraint == null)
            {
                MyPoint newCenter = ExtensionMethods.FindCenterOfCircleTangentToEdge(Polygon.Vertices[V1], Polygon.Vertices[V2], _circle.Radius);
                _circle.SetCenter(newCenter);
            }
            else
            {
                var newRadius = 2*ExtensionMethods.CountDistanceFromCircleCenterToLine(_circle.Center, Polygon.Vertices[V1], Polygon.Vertices[V2]);
                _circle.SetRadius((int)Math.Round(newRadius));
            }
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return ExtensionMethods.CountMiddleOfSegment(Polygon.Vertices[V1], Polygon.Vertices[V2]);
        }

        public override void SetConstraintOnObject()
        {
            _circle.SetTangentConstraint(this);
        }
    }
}
