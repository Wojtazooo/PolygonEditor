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
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj is Circle)
                {
                    var detectedMyPoint = ((Circle)rasterObj).DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                    if (detectedMyPoint != null)
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
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);

            for (int i = 0; i < _rasterObjects.Count; i++)
            {
                RasterObject rasterObj = _rasterObjects[i];
                if(selectedCircle == null)
                {
                    if (rasterObj is Circle)
                    {
                        Circle circle = (Circle)rasterObj;
                        var detectedMyPoint = circle.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                        if (detectedMyPoint!= null)
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
                        var edge = polygon.isEdgeClicked(mouseMyPoint);
                        if(edge.a != null && edge.b != null)
                        {
                            int v1 = polygon.Vertices.FindIndex(v => v == edge.a);
                            int v2 = polygon.Vertices.FindIndex(v => v == edge.b);

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
