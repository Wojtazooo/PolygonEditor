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

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers.PolygonConstrainsHandlers
{
    class AddRightAngleConstraintHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private readonly PictureBox _drawingArea;
        private ConstraintsEnforcer _constraintsEnforcer;
        private (Point? a, Point? b) firstSelectedLine;
        private Cross _helpCross;

        public AddRightAngleConstraintHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
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

        public void HandleMouseClick(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);

            for (int i = 0; i < _rasterObjects.Count; i++)
            {
                RasterObject rasterObj = _rasterObjects[i];
                if (rasterObj is Polygon)
                {
                    Polygon polygon = (Polygon)rasterObj;
                    var edge = polygon.isEdgeClicked(mousePoint);

                    if (edge.a.HasValue && edge.b.HasValue)
                    {
                        if (!firstSelectedLine.a.HasValue)
                        {
                            _helpCross = new Cross(mousePoint, Constants.CROSS_WIDTH, Color.Green);
                            _rasterObjects.Add(_helpCross);
                            firstSelectedLine = (edge.a.Value, edge.b.Value);
                            return;
                        }
                        else if (firstSelectedLine.a.HasValue && firstSelectedLine.b.HasValue && edge.a.Value == firstSelectedLine.a.Value && edge.b.Value == firstSelectedLine.b.Value)
                        {
                            continue;
                        }
                        else
                        {
                            _rasterObjects.Remove(_helpCross);
                            var relatedPoint = new List<Point> {
                                firstSelectedLine.a.Value,
                                firstSelectedLine.b.Value,
                                edge.a.Value,
                                edge.b.Value };
                            _ = new RightAngleConstraint(polygon, relatedPoint);
                            _constraintsEnforcer.EnforcePolygonConstraints(polygon, polygon.Vertices.IndexOf(edge.a.Value));
                            firstSelectedLine = (null, null);
                            return;
                        }
                    }
                }
            }
        }
    }
}
