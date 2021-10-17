using PolygonEditor.Constraints;
using PolygonEditor.Constraints.PolygonConstraints;
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
            Point mousePoint = new Point(e.X, e.Y);

            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj is Polygon)
                {
                    Polygon polygon = (Polygon)rasterObj;

                    var edge = polygon.isEdgeClicked(mousePoint);
                    if (edge.a.HasValue && edge.b.HasValue)
                    {
                        string value = ExtensionMethods.ShowDialog("Insert length", "Add constraint", (int)ExtensionMethods.PixelDistance(edge.a.Value, edge.b.Value));
                        int length;
                        if (value != null && int.TryParse(value, out length))
                        {
                            HandleAddConstraint(length, polygon, edge.a.Value, edge.b.Value);
                            _constraintsEnforcer.EnforcePolygonConstraints(polygon, polygon.Vertices.IndexOf(edge.a.Value));
                        }
                    }
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            foreach (var rasterObj in _rasterObjects)
            {
                if(rasterObj is Polygon)
                {
                    var edge = ((Polygon)rasterObj).isEdgeClicked(mousePoint);
                    if(edge.a.HasValue && edge.b.HasValue)
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

        private void HandleAddConstraint(int insertedLength, Polygon polygon, Point a, Point b)
        {
            var constraint = new ConstantEdgeLengthConstraint(polygon, a, b, insertedLength);
        }
    }
}
