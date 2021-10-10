using PolygonEditor.RasterGraphics.Models;
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
        protected Polygon _polygonToEdit;
        protected List<RasterObject> _rasterObjects;
        protected PictureBox _drawingArea;

        public PolygonEditGenericHandler(Polygon polygon, List<RasterObject> rasterObjects, PictureBox drawingArea)
        {
            _polygonToEdit = polygon;
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
        }
        public abstract void HandleMouseMove(MouseEventArgs e);
        public abstract void HandleMouseClick(MouseEventArgs e);

        public abstract void Cancel();
    }
}
