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

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers.PolygonConstrainsHandlers
{
    class AddSameLengthHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;
        private ConstraintsEnforcer _constraintsEnforcer;
        private (MyPoint a, MyPoint b) firstSelectedLine;
        private Cross _helpCross;

        public AddSameLengthHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
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
                if (rasterObj is Polygon)
                {
                    var edge = ((Polygon)rasterObj).isEdgeClicked(mouseMyPoint);
                    if (edge.a != null && edge.b != null)
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

            for(int i = 0; i < _rasterObjects.Count; i++)
            {
                RasterObject rasterObj = _rasterObjects[i];
                if (rasterObj is Polygon)
                {
                    Polygon polygon = (Polygon)rasterObj;
                    var edge = polygon.isEdgeClicked(mouseMyPoint);

                    if(edge.a != null && edge.b != null)
                    {


                        if (firstSelectedLine.a == null)
                        {
                            _helpCross = new Cross(mouseMyPoint, Constants.CROSS_WIDTH, Color.Green);
                            _rasterObjects.Add(_helpCross);
                            firstSelectedLine = (edge.a, edge.b);
                            return;
                        }
                        else if(firstSelectedLine.a != null && firstSelectedLine.b != null && edge.a == firstSelectedLine.a && edge.b == firstSelectedLine.b)
                        {
                            continue;
                        }
                        else
                        {
                            _rasterObjects.Remove(_helpCross);
                            var relatedMyPoint = new List<MyPoint> {
                                firstSelectedLine.a,
                                firstSelectedLine.b,
                                edge.a,
                                edge.b};

                            var relatedMyPoint2 = new List<MyPoint> {
                                edge.a,
                                edge.b,
                                firstSelectedLine.a,
                                firstSelectedLine.b,
                               };
                            _ = new SameLengthConstraint(polygon, relatedMyPoint);
                           // _ = new SameLengthConstraint(polygon, relatedMyPoint2);
                            _constraintsEnforcer.EnforcePolygonConstraints(polygon, polygon.Vertices.IndexOf(edge.a));
                            firstSelectedLine = (null, null);
                            return;
                        }
                    }
                }
            }
        }
    }
}
