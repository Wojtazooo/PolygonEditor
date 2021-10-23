using PolygonEditor.Constraints;
using PolygonEditor.Constraints.CircleConstraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System.Collections.Generic;
using System.Windows.Forms;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers.CircleConstraintsHandlers
{
    class AddConstantCenterHandler : ActionHandler
    {
        public AddConstantCenterHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
            :base(rasterObjects, textBoxHelper, drawingArea, constraintsEnforcer)
        {
            ConstraintsEnforcer = constraintsEnforcer;
            AddInstructions(InstructionTexts.AddConstantCenterCircleConstraintInstruction);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);

            foreach (var rasterObj in RasterObjects)
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

        public override void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach (var rasterObj in RasterObjects)
            {
                if (rasterObj is Circle)
                {
                    if (rasterObj.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS) != null)
                    {
                        DrawingArea.Cursor = Cursors.Hand;
                        return;
                    }
                    else
                    {
                        DrawingArea.Cursor = Cursors.Default;
                    }
                }
            }
        }
    }
}
