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
    class PolgonMoveEdgeHandler : ActionHandler
    {
        private MyPoint _previousMyPoint;
        private (int a, int b) _edgeToMove;
        private MyPoint _startMyPoint;
        bool moving = false;
        private SelectionHandler _selector;
        private Polygon _polygonToEdit;
        private List<Circle> _helpCircles = new List<Circle>();
        private List<RasterObject> _rasterObjects;
        private PictureBox _drawingArea;
        private ConstraintsEnforcer _constraintsEnforcer;
        private List<RasterObject> rasterObjects;
        private PictureBox drawingArea;

        public PolgonMoveEdgeHandler(List<RasterObject> rasterObjects, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        {
            _selector = new SelectionHandler(rasterObjects, null, drawingArea);
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
            _constraintsEnforcer = constraintsEnforcer;
        }

        public PolgonMoveEdgeHandler(List<RasterObject> rasterObjects, PictureBox drawingArea)
        {
            this.rasterObjects = rasterObjects;
            this.drawingArea = drawingArea;
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
            if(_polygonToEdit == null)
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
            if (_polygonToEdit != null)
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                (MyPoint a, MyPoint b) = _polygonToEdit.isEdgeClicked(mouseMyPoint);
                
                if(a != null && b != null)
                {
                    _drawingArea.Cursor = Cursors.SizeAll;
                    _edgeToMove = (_polygonToEdit.Vertices.FindIndex(p => p == a), _polygonToEdit.Vertices.FindIndex(p => p == b));
                    moving = true;
                    _previousMyPoint = mouseMyPoint;
                    _startMyPoint = mouseMyPoint;
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseMove(e);
            }
            else
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                if (moving)
                {
                    MyPoint a2 = ExtensionMethods.MovePoint(_polygonToEdit.Vertices[_edgeToMove.a], _previousMyPoint, mouseMyPoint);
                    MyPoint b2 = ExtensionMethods.MovePoint(_polygonToEdit.Vertices[_edgeToMove.b], _previousMyPoint, mouseMyPoint);

                    (a2, b2) = _polygonToEdit.MoveEdge(_polygonToEdit.Vertices[_edgeToMove.a], _polygonToEdit.Vertices[_edgeToMove.b], _previousMyPoint, mouseMyPoint);
                    _previousMyPoint = mouseMyPoint;

                    _constraintsEnforcer.EnforcePolygonConstraints(_polygonToEdit, ExtensionMethods.GetVertexNumberFromPoint(_polygonToEdit, a2));
                    _constraintsEnforcer.EnforcePolygonConstraints(_polygonToEdit, ExtensionMethods.GetVertexNumberFromPoint(_polygonToEdit, b2));
                    _rasterObjects.ForEach(obj =>
                    {
                        if (obj is Circle)
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
            foreach (var v in _polygonToEdit.Vertices)
            {
                var helpCircle = new Circle(v, Constants.DETECTION_RADIUS, _polygonToEdit.Color);
                _helpCircles.Add(helpCircle);
                _rasterObjects.Add(helpCircle);
            }
        }

        private void RemoveCircles()
        {
            foreach (var c in _helpCircles)
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
