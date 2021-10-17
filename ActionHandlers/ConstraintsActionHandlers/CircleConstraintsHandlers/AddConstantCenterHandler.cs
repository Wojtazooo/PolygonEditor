using PolygonEditor.Constraints;
using PolygonEditor.Constraints.CircleConstraints;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers.CircleConstraintsHandlers
{
    class AddConstantCenterHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;
        private ConstraintsEnforcer _constraintsEnforcer;


        public AddConstantCenterHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        {
            _rasterObjects = rasterObjects;
            _helperTextBox = textBoxHelper;
            _drawingArea = drawingArea;
            _constraintsEnforcer = constraintsEnforcer;
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj is Circle)
                {
                    Circle circle = (Circle)rasterObj;

                    var detectedPoint = circle.DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                    if (detectedPoint.HasValue)
                    {
                        _ = new ConstantCenterConstraint(circle, circle.Center);
                    }
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj is Circle)
                {
                    if (rasterObj.DetectObject(mousePoint, Constants.DETECTION_RADIUS).HasValue)
                    {
                        _drawingArea.Cursor = Cursors.Hand;
                        return;
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
