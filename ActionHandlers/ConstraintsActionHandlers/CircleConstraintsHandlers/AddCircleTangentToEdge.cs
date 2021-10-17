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
    class AddCircleTangentToEdge : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private readonly PictureBox _drawingArea;
        private ConstraintsEnforcer _constraintsEnforcer;
        private Circle selectedCircle;

        public AddCircleTangentToEdge(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
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
                if (rasterObj is Circle)
                {
                    var detectedPoint = ((Circle)rasterObj).DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                    if (detectedPoint.HasValue)
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
                if(selectedCircle == null)
                {
                    if (rasterObj is Circle)
                    {
                        Circle circle = (Circle)rasterObj;
                        var detectedPoint = circle.DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                        if (detectedPoint.HasValue)
                        {
                            selectedCircle = circle;
                        }
                    }
                }
                else
                {
                    if(rasterObj is Polygon)
                    {
                        Polygon polygon = (Polygon)rasterObj;
                        var edge = polygon.isEdgeClicked(mousePoint);
                        if(edge.a.HasValue && edge.b.HasValue)
                        {
                            int v1 = polygon.Vertices.FindIndex(v => v == edge.a.Value);
                            int v2 = polygon.Vertices.FindIndex(v => v == edge.b.Value);

                            _ = new CircleTangentToPolygonConstraint(selectedCircle, polygon, v1,v2);
                            _constraintsEnforcer.EnforceCircleConstraint(selectedCircle);
                            selectedCircle = null;
                        }
                    }
                }
            }
        }
    }
}
