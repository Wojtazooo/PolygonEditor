using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers.PolygonConstrainsHandlers
{
    class AddSameLengthHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;
        private ConstraintsEnforcer _constraintsEnforcer;

        public AddSameLengthHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        {
            _rasterObjects = rasterObjects;
            _helperTextBox = textBoxHelper;
            _drawingArea = drawingArea;
            _constraintsEnforcer = constraintsEnforcer;
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj is Polygon)
                {
                    var edge = ((Polygon)rasterObj).isEdgeClicked(mousePoint);
                    if (edge.a.HasValue && edge.b.HasValue)
                    {
                        _drawingArea.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        _drawingArea.Cursor = Cursors.Default;
                    }
                }
            }
        }
    }
}
