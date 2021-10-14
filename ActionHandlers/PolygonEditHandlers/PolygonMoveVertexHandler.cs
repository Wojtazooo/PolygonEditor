using PolygonEditor.Constraints;
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
        private Point _previousPoint;
        private Point _vertexToMove;
        private Point _startPoint;
        bool moving = false;
        private SelectionHandler _selector;
        private List<RasterObject> _rasterObjects;
        private PictureBox _drawingArea;
        private Polygon _polygonToEdit;
        private List<Circle> _helpCircles = new List<Circle>();
        private List<IConstraint> _constraints; 


        public MovePolygonVertexHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, List<IConstraint> constraints)
        {
            _selector = new SelectionHandler(rasterObjects, null, drawingArea);
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
            _constraints = constraints;
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
                Point mousePoint = new Point(e.X, e.Y);
                Point? detectedPoint = _polygonToEdit.DetectObject(mousePoint, Constants.CROSS_WIDTH);
                if (detectedPoint != null && _polygonToEdit.Vertices.Contains(detectedPoint.Value))
                {
                    _drawingArea.Cursor = Cursors.SizeAll;
                    _vertexToMove = detectedPoint.Value;
                    moving = true;
                    _previousPoint = mousePoint;
                    _startPoint = mousePoint;
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
                Point mousePoint = new Point(e.X, e.Y);
                if (moving)
                {
                    _polygonToEdit.MoveVertex(_vertexToMove, mousePoint);
                    _vertexToMove = mousePoint;

                    var lockedPoints = new List<Point>();
                    lockedPoints.Add(mousePoint);
                    ExtensionMethods.ApplyConstraints(_constraints, lockedPoints);
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
