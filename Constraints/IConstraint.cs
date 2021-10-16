using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints
{
    public interface IConstraint
    {
        public void EnforceConstraint(Point constantPoint); 
        public RasterObject GetRasterObject();
        public void DrawConstraintInfo(Graphics g);
        public Point GetCenterDrawingPoint();
    }
}
