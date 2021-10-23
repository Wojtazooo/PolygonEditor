using System.Collections.Generic;
using System.Windows.Forms;
using PolygonEditor.Constraints;
using PolygonEditor.GlobalHelpers;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;

namespace PolygonEditor.ActionHandlers.GeneralEditHandlers
{
    class MoveRasterObjectHandler : ActionHandler
    {
        private RasterObject _selectedObject;
        private MyPoint _previousMyPoint;

        public MoveRasterObjectHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, TextBox helperTextBox, ConstraintsEnforcer constraintsEnforcer)
        : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)

        {
            AddInstructions(InstructionTexts.MoveRasterObjectInstruction);
        }

        public override void Cancel()
        {
            _selectedObject = null;
            DrawingArea.Cursor = Cursors.Default;
        }

        public override void Finish()
        {
            Cancel();
            base.Finish();
        }

        public override void HandleMouseDown(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            if (_selectedObject == null)
            {
                foreach (var obj in RasterObjects)
                {
                    MyPoint detectedMyPoint = obj.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                    if (detectedMyPoint != null)
                    {
                        _selectedObject = obj;
                        _previousMyPoint = mouseMyPoint;
                    }
                }

                if (_selectedObject != null)
                {
                    DrawingArea.Cursor = Cursors.SizeAll;
                }
            }
        }
        public override void HandleMouseUp(MouseEventArgs e)
        {
            _selectedObject = null;
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            if(_selectedObject != null)
            {
                if (_selectedObject is Circle)
                {
                    Circle selectedCircle = (Circle)_selectedObject;
                    if(selectedCircle.tangentToPolygonConstraint != null)
                    {
                        selectedCircle.tangentToPolygonConstraint.Polygon.MoveRasterObject(_previousMyPoint, mouseMyPoint);
                    }
                    ConstraintsEnforcer.EnforceCircleConstraint(selectedCircle);
                }
                RasterObjects.ForEach(obj =>
                {
                    if (obj is Circle)
                    {
                        ConstraintsEnforcer.EnforceCircleConstraint(((Circle)obj));
                    }
                });

                _selectedObject.MoveRasterObject(_previousMyPoint, mouseMyPoint);
                _previousMyPoint = mouseMyPoint;
            }
            else
            {
                MyPoint detectedMyPoint = null;
                foreach (var obj in RasterObjects)
                {
                    detectedMyPoint = obj.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                    if (detectedMyPoint != null)
                    {
                        break;
                    }
                }
                if(detectedMyPoint != null)
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
}
