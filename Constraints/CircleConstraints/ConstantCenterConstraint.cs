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
    class ConstantCenterConstraint : CircleConstraint
    {
        private Point _constantCenter;

        public ConstantCenterConstraint(Circle circle, Point constantCenter) : base(circle)
        {
            _circle.Constraints.RemoveAll(c => c is CircleTangentToPolygonConstraint);
            _constantCenter = constantCenter;
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            Point center = _circle.Center;
            GraphicsApplier.ApplyCircle(g, center, Constants.CENTER_POINT_RADIUS);
            center.Y -= 20;
            GraphicsApplier.ApplyString(g, $"({_constantCenter.X},{_constantCenter.Y})", center);
        }

        public override void EnforceConstraint(Point constantPoint)
        {
            _circle.SetCenter(_constantCenter);
        }

        public override Point GetCenterDrawingPoint()
        {
            return (new Point(_circle.Center.X, _circle.Center.Y - 10));
        }
    }
}
