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
    class AddCircleTangentToEdge : ActionHandler
    {
        private Circle _selectedCircle;

        public AddCircleTangentToEdge(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea,
            ConstraintsEnforcer constraintsEnforcer)
            : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            ConstraintsEnforcer = constraintsEnforcer;
            AddInstructions(InstructionTexts.AddCircleTangentConstraintInstruction);
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach (var rasterObj in RasterObjects)
            {
                if (rasterObj is Circle)
                {
                    var detectedMyPoint = ((Circle) rasterObj).DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                    if (detectedMyPoint != null)
                    {
                        DrawingArea.Cursor = Cursors.Hand;
                    }
                    else
                    {
                        DrawingArea.Cursor = Cursors.Default;
                    }
                }
            }
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);

            for (int i = 0; i < RasterObjects.Count; i++)
            {
                RasterObject rasterObj = RasterObjects[i];
                if (_selectedCircle == null)
                {
                    if (rasterObj is Circle)
                    {
                        Circle circle = (Circle) rasterObj;
                        var detectedMyPoint = circle.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                        if (detectedMyPoint != null)
                        {
                            if (circle.ConstantRadiusConstraint != null && circle.ConstantCenterConstraint != null)
                            {
                                MessageBox.Show(
                                    "Circle contains constant radius and constant center. Can't make it tangent to polygon",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }

                            _selectedCircle = circle;
                        }
                    }
                }
                else
                {
                    if (rasterObj is Polygon)
                    {
                        Polygon polygon = (Polygon) rasterObj;
                        var edge = polygon.isEdgeClicked(mouseMyPoint);
                        if (edge.a != null && edge.b != null)
                        {
                            int v1 = polygon.Vertices.FindIndex(v => v == edge.a);
                            int v2 = polygon.Vertices.FindIndex(v => v == edge.b);

                            _ = new CircleTangentToPolygonConstraint(_selectedCircle, polygon, v1, v2);
                            ConstraintsEnforcer.EnforceCircleConstraint(_selectedCircle);
                            _selectedCircle = null;
                        }
                    }
                }
            }
        }
    }
}