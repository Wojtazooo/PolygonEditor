using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers.CircleEditHandlers
{
    class CircleChangeRadiusHandler : ActionHandler
    {
        private PictureBox _drawingArea;
        private TextBox _helperTextBox;
        private List<RasterObject> _rasterObjects;
        private SelectionHandler _selector;
        private Circle _circleToEdit;
        private bool _moving = false;
        private Line _helpRadius = null;

        public CircleChangeRadiusHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, TextBox helperTextBox)
        {
            _selector = new SelectionHandler(rasterObjects, helperTextBox, drawingArea);
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
            _helperTextBox = helperTextBox;
        }

        public void Cancel()
        {
            _helpRadius = null;
            RemoveHelpRadius();
        }

        public void Finish()
        {
            _helpRadius = null;
            RemoveHelpRadius();
        }

        public void Submit()
        {
            _circleToEdit = null;
            _selector = new SelectionHandler(_rasterObjects, null, _drawingArea);
            RemoveHelpRadius();
        }


        public void HandleMouseClick(MouseEventArgs e)
        {
            if (_circleToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.clickedRasterObject is Circle)
                {
                    Point mousePoint = new Point(e.X, e.Y);
                    _circleToEdit = (Circle)_selector.clickedRasterObject;
                    _selector.Cancel();
                    AddHelpRadius(mousePoint);
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            if (_circleToEdit == null)
            {
                _selector.HandleMouseMove(e);
            }
            else
            {
                Point mousePoint = new Point(e.X, e.Y);
                handleCursorChange(mousePoint);
                if (_moving)
                {
                    int newRadius = (int)ExtensionMethods.PixelDistance(mousePoint, _circleToEdit.Center);
                    _circleToEdit.SetRadius(newRadius);
                    UpdateHelpRadius(mousePoint);
                }
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            _moving = false;
            _drawingArea.Cursor = Cursors.Default;
        }

        public void HandleMouseDown(MouseEventArgs e)
        {
            if (_circleToEdit != null)
            {
                Point mousePoint = new Point(e.X, e.Y);
                Point? detectedPoint = _circleToEdit.DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                if (detectedPoint.HasValue)
                {
                    _moving = true;
                }
            }
        }

        private void AddHelpRadius(Point mousePoint)
        {
            _helpRadius = new Line(_circleToEdit.Center, mousePoint, Color.LightGray);
            _rasterObjects.Add(_helpRadius);
        }

        private void RemoveHelpRadius()
        {
            _rasterObjects.Remove(_helpRadius);
            _helpRadius = null;
        }

        private void UpdateHelpRadius(Point mousePoint)
        {
            _helpRadius.SetP2(mousePoint);
        }

        private void handleCursorChange(Point mousePoint)
        {
            Point? detectedPoint = _circleToEdit.DetectObject(mousePoint, Constants.DETECTION_RADIUS);
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
