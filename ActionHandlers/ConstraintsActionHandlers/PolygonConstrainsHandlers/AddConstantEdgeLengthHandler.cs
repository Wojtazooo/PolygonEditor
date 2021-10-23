using PolygonEditor.Constraints;
using PolygonEditor.Constraints.PolygonConstraints;
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
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers
{
    class AddConstantEdgeLengthHandler : ActionHandler
    {
        public AddConstantEdgeLengthHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
            : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            AddInstructions(InstructionTexts.AddConstantEdgeLengthConstraintInstruction);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);

            foreach (var rasterObj in RasterObjects)
            {
                if (rasterObj is Polygon)
                {
                    Polygon polygon = (Polygon)rasterObj;

                    var edge = polygon.isEdgeClicked(mouseMyPoint);
                    if (edge.a != null && edge.b != null)
                    {
                        string value = ExtensionMethods.ShowDialogToInsertValue("Insert length", "Add constraint", (int)ExtensionMethods.PixelDistance(edge.a, edge.b));
                        int length;
                        if (value != null && int.TryParse(value, out length))
                        {
                            HandleAddConstraint(length, polygon, edge.a, edge.b);
                            ConstraintsEnforcer.EnforcePolygonConstraints(polygon, polygon.Vertices.IndexOf(edge.a));
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
                if (rasterObj is Polygon)
                {
                    var edge = ((Polygon)rasterObj).isEdgeClicked(mouseMyPoint);
                    if (edge.a != null && edge.b != null)
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

        private static void HandleAddConstraint(int insertedLength, Polygon polygon, MyPoint a, MyPoint b)
        {
            _ = new ConstantEdgeLengthConstraint(polygon, a, b, insertedLength);
        }
    }
}
