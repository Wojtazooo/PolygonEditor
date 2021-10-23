using System.Collections.Generic;
using System.Windows.Forms;
using PolygonEditor.Constraints;
using PolygonEditor.Constraints.CircleConstraints;
using PolygonEditor.GlobalHelpers;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers.CircleConstraintsHandlers
{
    class AddConstantRadiusHandler : ActionHandler
    {
        public AddConstantRadiusHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea,
            ConstraintsEnforcer constraintsEnforcer)
            : base(rasterObjects, textBoxHelper, drawingArea, constraintsEnforcer)
        {
            ConstraintsEnforcer = constraintsEnforcer;
            AddInstructions(InstructionTexts.AddConstantRadiusCircleConstraintInstruction);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);

            foreach (var rasterObj in RasterObjects)
            {
                if (rasterObj is Circle)
                {
                    Circle circle = (Circle) rasterObj;

                    var detectedMyPoint = circle.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                    if (detectedMyPoint != null)
                    {
                        if (circle.ConstantCenterConstraint != null && circle.tangentToPolygonConstraint != null)
                        {
                            MessageBox.Show(
                                "Circle contains constant center and is tangent to Polygon. Can't add constant radius",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        string value =
                            ExtensionMethods.ShowDialogToInsertValue("Insert length", "Add constraint", circle.Radius);
                        int length;
                        if (value != null && int.TryParse(value, out length))
                        {
                            _ = new ConstantRadiusConstraint(circle, length);
                            ConstraintsEnforcer.EnforceCircleConstraint(circle);
                        }
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