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

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers
{
    class AddConstantEdgeLengthHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;
        private ConstraintsEnforcer _constraintsEnforcer;

        public AddConstantEdgeLengthHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
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
                if (rasterObj is Polygon)
                {
                    Polygon polygon = (Polygon)rasterObj;

                    var edge = polygon.isEdgeClicked(mouseMyPoint);
                    if (edge.a != null && edge.b != null)
                    {
                        string value = ExtensionMethods.ShowDialog("Insert length", "Add constraint", (int)ExtensionMethods.PixelDistance(edge.a, edge.b));
                        int length;
                        if (value != null && int.TryParse(value, out length))
                        {
                            HandleAddConstraint(length, polygon, edge.a, edge.b);
                            _constraintsEnforcer.EnforcePolygonConstraints(polygon, polygon.Vertices.IndexOf(edge.a));
                        }
                    }
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach (var rasterObj in _rasterObjects)
            {
                if(rasterObj is Polygon)
                {
                    var edge = ((Polygon)rasterObj).isEdgeClicked(mouseMyPoint);
                    if(edge.a != null && edge.b != null)
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

        private void HandleAddConstraint(int insertedLength, Polygon polygon, MyPoint a, MyPoint b)
        {
            var constraint = new ConstantEdgeLengthConstraint(polygon, a, b, insertedLength);
        }
    }
}
