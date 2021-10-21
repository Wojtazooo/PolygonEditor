using PolygonEditor.Constraints;
using PolygonEditor.Constraints.CircleConstraints;
using PolygonEditor.RasterGraphics.Helpers;
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
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);

            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj is Circle)
                {
                    Circle circle = (Circle)rasterObj;

                    var detectedMyPoint = circle.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                    if (detectedMyPoint != null)
                    {
                        if (circle.ConstantRadiusConstraint != null && circle.tangentToPolygonConstraint != null)
                        {
                            MessageBox.Show("Circle contains constant radius and is tangent to Polygon. Can't add constant center", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        _ = new ConstantCenterConstraint(circle, circle.Center);
                    }
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj is Circle)
                {
                    if (rasterObj.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS) != null)
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
