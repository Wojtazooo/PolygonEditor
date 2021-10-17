﻿using PolygonEditor.RasterGraphics.Models;
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
    public abstract class PolygonConstraint : IConstraint
    {
        protected Polygon _polygon;
        public List<int> RelatedVertices;

        public PolygonConstraint(Polygon polygon)
        {
            _polygon = polygon;
            _polygon.AddContraint(this);
        }
        public abstract void EnforceConstraint(Point constantPoint);

        public RasterObject GetRasterObject()
        {
            return _polygon;
        }

        public abstract void DrawConstraintInfo(Graphics g);
        public abstract Point GetCenterDrawingPoint();
    }
}
