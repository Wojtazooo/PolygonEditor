using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers
{
    class MoveRasterObjectHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private RasterObject _selectedObject;
        private RasterObject _copyObject;
        private Point? _startedPoint;
        private Point? _previousPoint;
        private PictureBox _drawingArea;
        private object _helperTextBox;

        public MoveRasterObjectHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, TextBox helperTextBox)
        {
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
            _helperTextBox = helperTextBox;

        }

        public void Cancel()
        {
            _selectedObject = null;
            _rasterObjects.Remove(_copyObject);
            _drawingArea.Cursor = Cursors.Default;
        }

        public void Finish()
        {
            Cancel();
        }

        public bool HandleKeybordKeyClick(KeyEventArgs e)
        {
            return false;
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            if (_selectedObject == null)
            {
                foreach (var obj in _rasterObjects)
                {
                    Point? detectedPoint = obj.DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                    if (detectedPoint != null)
                    {
                        _selectedObject = obj;
                        _startedPoint = mousePoint;
                        _previousPoint = mousePoint;
                    }
                    else
                    {
                    }
                }

                if (_selectedObject != null)
                {
                    _drawingArea.Cursor = Cursors.SizeAll;
                    _copyObject = _selectedObject.Clone();
                    _copyObject.SetColor(Color.LightGray);
                    _rasterObjects.Add(_copyObject);
                }
            }
            else
            {
                _drawingArea.Cursor = Cursors.Default;
                _selectedObject.MovePolygon(_startedPoint.Value, mousePoint);
                _selectedObject = null;
                _rasterObjects.Remove(_copyObject);
            }

        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            if(_selectedObject != null)
            {
                _copyObject.MovePolygon(_previousPoint.Value, mousePoint);
                _previousPoint = mousePoint;
            }
            else
            {
                Point? detectedPoint = null;
                foreach (var obj in _rasterObjects)
                {
                    detectedPoint = obj.DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                    if (detectedPoint != null)
                    {
                        break;
                    }
                }
                if(detectedPoint.HasValue)
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
}
