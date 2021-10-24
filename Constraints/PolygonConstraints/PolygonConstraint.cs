using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    public abstract class PolygonConstraint : IConstraint
    {
        protected Polygon _polygon;
        public (int a, int b) RelatedVertices;
        public bool MoreThanOneEdge => SecondEdge.HasValue;
        public PolygonConstraint RelatedConstraint;
        public (int a, int b)? SecondEdge; 

        public PolygonConstraint(Polygon polygon)
        {
            _polygon = polygon;
        }

        public abstract void EnforceConstraint(MyPoint constantMyPoint);

        public RasterObject GetRasterObject()
        {
            return _polygon;
        }

        public void AddRelatedConstraint(PolygonConstraint relatedConstraint)
        {
            RelatedConstraint = relatedConstraint;
        }

        public abstract void DrawConstraintInfo(Graphics g);
        public abstract MyPoint GetCenterDrawingPoint();
    }
}