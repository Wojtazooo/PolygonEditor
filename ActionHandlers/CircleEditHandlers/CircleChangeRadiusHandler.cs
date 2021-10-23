using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PolygonEditor.ActionHandlers.GeneralEditHandlers;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.CircleEditHandlers
{
    internal class CircleChangeRadiusHandler : ActionHandler
    {
        private SelectionHandler _selector;
        private Circle _circleToEdit;
        private bool _moving;
        private Line _helpRadius;

        public CircleChangeRadiusHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, TextBox helperTextBox, ConstraintsEnforcer constraintsEnforcer): 
            base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            _selector = new SelectionHandler(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer);
            AddInstructions(InstructionTexts.ChangeCircleRadiusInstruction);
        }

        public override void Cancel()
        {
            RemoveHelpRadius();
        }

        public override void Finish()
        {
            RemoveHelpRadius();
            base.Finish();
        }

        public override void Submit()
        {
            _circleToEdit = null;
            _selector = new SelectionHandler(RasterObjects, HelperTextBox, DrawingArea, ConstraintsEnforcer);
            RemoveHelpRadius();
        }


        public override void HandleMouseClick(MouseEventArgs e)
        {
            if (_circleToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.ClickedRasterObject is Circle)
                {
                    _circleToEdit = (Circle)_selector.ClickedRasterObject;
                    _selector.Cancel();
                    AddHelpRadius();
                }
            }
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            if (_circleToEdit == null)
            {
                _selector.HandleMouseMove(e);
            }
            else
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                HandleCursorChange(mouseMyPoint);
                if (_moving)
                {
                    int newRadius = (int)ExtensionMethods.PixelDistance(mouseMyPoint, _circleToEdit.Center);
                    _circleToEdit.SetRadius(newRadius);
                    ConstraintsEnforcer.EnforceCircleConstraint(_circleToEdit);
                    UpdateHelpRadius();
                }
            }
        }

        public override void HandleMouseUp(MouseEventArgs e)
        {
            _moving = false;
            DrawingArea.Cursor = Cursors.Default;
        }

        public override void HandleMouseDown(MouseEventArgs e)
        {
            if (_circleToEdit == null) return;
            var mouseMyPoint = new MyPoint(e.X, e.Y);
            var detectedMyPoint = _circleToEdit.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
            if (detectedMyPoint != null)
            {
                _moving = true;
            }
        }

        private void AddHelpRadius()
        {
            MyPoint radiusMyPoint = new MyPoint(_circleToEdit.Center.X + _circleToEdit.Radius, _circleToEdit.Center.Y);
            _helpRadius = new Line(_circleToEdit.Center, radiusMyPoint, Color.Red);
            RasterObjects.Add(_helpRadius);
        }

        private void RemoveHelpRadius()
        {
            RasterObjects.Remove(_helpRadius);
            _helpRadius = null;
        }

        private void UpdateHelpRadius()
        {
            var radiusMyPoint = new MyPoint(_circleToEdit.Center.X + _circleToEdit.Radius, _circleToEdit.Center.Y);
            _helpRadius.SetP2(radiusMyPoint);
        }

        private void HandleCursorChange(MyPoint mouseMyPoint)
        {
            var detectedMyPoint = _circleToEdit.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
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
