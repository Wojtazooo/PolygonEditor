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
        private MyPoint _constantCenter;

        public ConstantCenterConstraint(Circle circle, MyPoint constantCenter) : base(circle)
        {
            _circle.Constraints.RemoveAll(c => c is CircleTangentToPolygonConstraint);
            _constantCenter = constantCenter;
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            MyPoint center = new MyPoint(_circle.Center);
            GraphicsApplier.ApplyCircle(g, center, Constants.CENTER_POINT_RADIUS);
            center.Y -= 20;
            GraphicsApplier.ApplyString(g, $"({_constantCenter.X},{_constantCenter.Y})", center);
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            _circle.SetCenter(_constantCenter);
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return (new MyPoint(_circle.Center.X, _circle.Center.Y - 10));
        }
    }
}
