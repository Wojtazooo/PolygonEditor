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
    public class ConstantCenterConstraint : CircleConstraint
    {
        private MyPoint _constantCenter;

        public ConstantCenterConstraint(Circle circle, MyPoint constantCenter) : base(circle)
        {
            _constantCenter = constantCenter;
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            MyPoint center = new MyPoint(_circle.Center);
            GraphicsApplier.ApplyCircle(g, center, Constants.CENTER_POINT_RADIUS);
            center.Y -= 20;
            Point circleCenterToDraw = _constantCenter.GetPoint();
            GraphicsApplier.ApplyString(g, $"({circleCenterToDraw.X},{circleCenterToDraw.Y})", center);
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            _circle.SetCenter(_constantCenter);
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return (new MyPoint(_circle.Center.X, _circle.Center.Y - 10));
        }

        public override void SetConstraintOnObject()
        {
            _circle.SetConstantCenterConstraint(this);
        }
    }
}
