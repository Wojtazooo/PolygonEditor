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

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    class MovePolygonVertexHandler : ActionHandler
    {
        private MyPoint _previousMyPoint;
        private int _vertexToMove;
        private MyPoint _startMyPoint;
        bool moving = false;
        private SelectionHandler _selector;
        private List<RasterObject> _rasterObjects;
        private PictureBox _drawingArea;
        private Polygon _polygonToEdit;
        private List<Circle> _helpCircles = new List<Circle>();
        private ConstraintsEnforcer _constraintsEnforcer;


        public MovePolygonVertexHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        {
            _selector = new SelectionHandler(rasterObjects, null, drawingArea);
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
            _constraintsEnforcer = constraintsEnforcer;
        }

        public void Cancel()
        {
            RemoveCircles();
        }

        public void Finish()
        {
            RemoveCircles();
        }

        public void Submit()
        {
            RemoveCircles();
            _polygonToEdit = null;
            _selector = new SelectionHandler(_rasterObjects, null, _drawingArea);
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.clickedRasterObject is Polygon)
                {
                    _polygonToEdit = (Polygon)_selector.clickedRasterObject;
                    _selector.Cancel();
                    AddCircles();
                }
            }
        }

        public void HandleMouseDown(MouseEventArgs e)
        {
            if(_polygonToEdit != null)
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                MyPoint detectedMyPoint = _polygonToEdit.DetectObject(mouseMyPoint, Constants.CROSS_WIDTH);
                if (detectedMyPoint != null && _polygonToEdit.Vertices.Contains(detectedMyPoint))
                {
                    _drawingArea.Cursor = Cursors.SizeAll;
                    _vertexToMove = _polygonToEdit.Vertices.FindIndex(p => p == detectedMyPoint);
                    moving = true;
                    _previousMyPoint = mouseMyPoint;
                    _startMyPoint = mouseMyPoint;
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            if(_polygonToEdit == null)
            {
                _selector.HandleMouseMove(e);
            }
            else
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                if (moving)
                {
                    _polygonToEdit.MoveVertex(_polygonToEdit.Vertices[_vertexToMove], mouseMyPoint);
                    _constraintsEnforcer.EnforcePolygonConstraints(_polygonToEdit, ExtensionMethods.GetVertexNumberFromPoint(_polygonToEdit, mouseMyPoint));
                    _rasterObjects.ForEach(obj =>
                    {
                        if(obj is Circle)
                        {
                            _constraintsEnforcer.EnforceCircleConstraint(((Circle)obj));
                        }
                    });
                    UpdateCircles();
                }
            }
        }

        public void HandleMouseUp(MouseEventArgs e)
        {
            moving = false;
            _drawingArea.Cursor = Cursors.Default;
        }

        private void AddCircles()
        {
            _helpCircles = new List<Circle>();
            foreach(var v in _polygonToEdit.Vertices)
            {
                var helpCircle = new Circle(v, Constants.DETECTION_RADIUS, _polygonToEdit.Color);
                _helpCircles.Add(helpCircle);
                _rasterObjects.Add(helpCircle);
            }
        }

        private void RemoveCircles()
        {
            foreach(var c in _helpCircles)
            {
                _rasterObjects.Remove(c);
            }
            _helpCircles.Clear();
        }

        private void UpdateCircles()
        {
            RemoveCircles();
            AddCircles();
        }
    }
}
