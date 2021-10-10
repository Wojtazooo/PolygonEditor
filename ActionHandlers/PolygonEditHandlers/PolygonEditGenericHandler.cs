using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    public abstract class PolygonEditGenericHandler
    {
        private Polygon _polygonToEdit;
        public PolygonEditGenericHandler(Polygon polygon)
        {
            _polygonToEdit = polygon;
        }
        public abstract void HandleMouseMove(MouseEventArgs e);
        public abstract void HandleMouseClick(MouseEventArgs e);
    }
}
