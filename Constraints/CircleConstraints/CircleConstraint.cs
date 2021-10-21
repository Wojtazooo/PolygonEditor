using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.CircleConstraints
{
    public abstract class CircleConstraint : IConstraint
    {
        protected Circle _circle;

        public CircleConstraint(Circle circle)
        {
            _circle = circle;
            _circle.AddConstraint(this);
        }

        public RasterObject GetRasterObject()
        {
            return _circle;
        }
        public abstract void EnforceConstraint(MyPoint constantMyPoint);
        public abstract void DrawConstraintInfo(Graphics g);
        public abstract MyPoint GetCenterDrawingPoint();
        public abstract void SetConstraintOnObject();
    }
}
