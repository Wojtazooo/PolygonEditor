using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.CircleConstraints
{
    public class ConstantRadiusConstraint : CircleConstraint
    {
        private int _radiusLength;

        public ConstantRadiusConstraint(Circle circle, int radiusLength) : base(circle)
        {
            _radiusLength = radiusLength;
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            MyPoint center = GetCenterDrawingPoint();
            center.Y -= 10;
            GraphicsApplier.ApplyString(g, _radiusLength.ToString(), center);
            g.DrawLine(Pens.Black, _circle.Center.GetPoint(), new MyPoint(_circle.Center.X + _radiusLength, _circle.Center.Y).GetPoint());
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            _circle.SetRadius(_radiusLength);
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return ExtensionMethods.CountMiddleOfSegment(_circle.Center, new MyPoint(_circle.Center.X + _radiusLength, _circle.Center.Y));
        }

        public override void SetConstraintOnObject()
        {
            _circle.SetConstantRadiusConstraint(this);
        }
    }
}
