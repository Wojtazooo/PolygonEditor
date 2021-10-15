using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    public abstract class PolygonConstraint : IConstraint
    {
        protected Polygon _polygon;
        public List<int> RelatedVertices;
        public List<PolygonConstraint> nextPolygonConstraints;
        public List<PolygonConstraint> polygonConstraints;

        public PolygonConstraint(Polygon polygon)
        {
            _polygon = polygon;
        }
        public abstract void EnforceConstraint(Point constantPoint);

        public RasterObject GetRasterObject()
        {
            return _polygon;
        }
    }
}
