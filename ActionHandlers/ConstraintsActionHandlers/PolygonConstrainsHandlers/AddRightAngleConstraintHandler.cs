﻿using PolygonEditor.Constraints;
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

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers.PolygonConstrainsHandlers
{
    class AddRightAngleConstraintHandler : ActionHandler
    {
        private (MyPoint a, MyPoint b) firstSelectedLine;
        private Cross _helpCross;

        public AddRightAngleConstraintHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        :base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            AddInstructions(InstructionTexts.PerpendicularConstraintInstruction);
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

        public override void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);

            for (int i = 0; i < RasterObjects.Count; i++)
            {
                RasterObject rasterObj = RasterObjects[i];
                if (rasterObj is Polygon)
                {
                    Polygon polygon = (Polygon)rasterObj;
                    var edge = polygon.isEdgeClicked(mouseMyPoint);

                    if (edge.a != null && edge.b != null)
                    {
                        if (firstSelectedLine.a == null)
                        {
                            _helpCross = new Cross(mouseMyPoint, Constants.CROSS_WIDTH, Color.Green);
                            RasterObjects.Add(_helpCross);
                            firstSelectedLine = (edge.a, edge.b);
                            return;
                        }
                        else if (firstSelectedLine.a != null && firstSelectedLine.b != null && edge.a == firstSelectedLine.a && edge.b == firstSelectedLine.b)
                        {
                            continue;
                        }
                        else
                        {
                            RasterObjects.Remove(_helpCross);
                            var relatedMyPoint = new List<MyPoint> {
                                firstSelectedLine.a,
                                firstSelectedLine.b,
                                edge.a,
                                edge.b };
                            var relatedMyPoint2 = new List<MyPoint> {
                                edge.a,
                                edge.b,
                                firstSelectedLine.a,
                                firstSelectedLine.b
                                };
                            var constraint1 = new RightAngleConstraint(polygon, relatedMyPoint);
                            var constraint2 = new RightAngleConstraint(polygon, relatedMyPoint2, false);
                            constraint1.AddRelatedConstraint(constraint2);
                            constraint2.AddRelatedConstraint(constraint1);
                            ConstraintsEnforcer.EnforcePolygonConstraints(polygon, polygon.Vertices.IndexOf(edge.a));
                            firstSelectedLine = (null, null);
                            return;
                        }
                    }
                }
            }
        }
    }
}
