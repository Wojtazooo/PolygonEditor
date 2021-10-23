using PolygonEditor.Constraints;
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

namespace PolygonEditor.ActionHandlers
{
    class MoveRasterObjectHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private RasterObject _selectedObject;
        private MyPoint _previousMyPoint;
        private PictureBox _drawingArea;
        private TextBox _helperTextBox;
        private ConstraintsEnforcer _constraintsEnforcer;

        public MoveRasterObjectHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, TextBox helperTextBox, ConstraintsEnforcer constraintsEnforcer)
        {
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
            _helperTextBox = helperTextBox;
            _constraintsEnforcer = constraintsEnforcer;
        }

        public void Cancel()
        {
            _selectedObject = null;
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

        public void HandleMouseDown(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            if (_selectedObject == null)
            {
                foreach (var obj in _rasterObjects)
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
                    _drawingArea.Cursor = Cursors.SizeAll;
                }
            }
        }
        public void HandleMouseUp(MouseEventArgs e)
        {
            _selectedObject = null;
        }

        public void HandleMouseMove(MouseEventArgs e)
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
                    _constraintsEnforcer.EnforceCircleConstraint(selectedCircle);
                }
                _rasterObjects.ForEach(obj =>
                {
                    if (obj is Circle)
                    {
                        _constraintsEnforcer.EnforceCircleConstraint(((Circle)obj));
                    }
                });

                _selectedObject.MoveRasterObject(_previousMyPoint, mouseMyPoint);
                _previousMyPoint = mouseMyPoint;
            }
            else
            {
                MyPoint detectedMyPoint = null;
                foreach (var obj in _rasterObjects)
                {
                    detectedMyPoint = obj.DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                    if (detectedMyPoint != null)
                    {
                        break;
                    }
                }
                if(detectedMyPoint != null)
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
