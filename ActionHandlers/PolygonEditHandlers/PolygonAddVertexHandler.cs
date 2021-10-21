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
    class PolygonAddVertexHandler : ActionHandler
    {
        private SelectionHandler _selector;
        private List<RasterObject> _rasterObjects;
        private PictureBox _drawingArea;
        private Polygon _polygonToEdit;
        private Circle _helpAddCircle;
        private List<Circle> _helpCircles;
        public PolygonAddVertexHandler(List<RasterObject> rasterObjects, PictureBox drawingArea)
        {
            _selector = new SelectionHandler(rasterObjects, null, drawingArea);
            _rasterObjects = rasterObjects;
            _drawingArea = drawingArea;
        }

        public void Cancel()
        {
            _polygonToEdit = null;
            _selector = new SelectionHandler(_rasterObjects, null, _drawingArea);
            RemoveCirclePointer();
            RemoveVertexCircles();
        }

        public void Finish()
        {
            _polygonToEdit = null;
            _selector = new SelectionHandler(_rasterObjects, null, _drawingArea);
            RemoveCirclePointer();
            RemoveVertexCircles();
        }

        public void Submit()
        {
            _polygonToEdit = null;
            _selector = new SelectionHandler(_rasterObjects, null, _drawingArea);
            RemoveCirclePointer();
            RemoveVertexCircles();
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.clickedRasterObject is Polygon)
                {
                    _polygonToEdit = (Polygon)_selector.clickedRasterObject;
                    _selector.Cancel();
                    AddCirclePointer(mouseMyPoint);
                    AddVertexCircles();
                }
            }
            else
            {
                _polygonToEdit.AddVertexInsideEdge(mouseMyPoint);
                UpdateVertexCircles();
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
                (MyPoint a, MyPoint b) = _polygonToEdit.isEdgeClicked(mouseMyPoint);
                if(a != null && b != null)
                {
                    if (_helpAddCircle == null) AddCirclePointer(mouseMyPoint);
                    else UpdateCirclePointer(mouseMyPoint);
                }
                else
                {
                    RemoveCirclePointer();
                }
            }
        }

        public void AddCirclePointer(MyPoint mouseMyPoint)
        {
            _helpAddCircle = new Circle(mouseMyPoint, Constants.ADD_VERTEX_CIRCLE_RADIUS, Color.Green);
            _rasterObjects.Add(_helpAddCircle);
        }

        public void RemoveCirclePointer()
        {
            _rasterObjects.Remove(_helpAddCircle);
            _helpAddCircle = null;
        }

        public void UpdateCirclePointer(MyPoint mouseMyPoint)
        {
            _helpAddCircle.SetCenter(mouseMyPoint);
        }

        private void AddVertexCircles()
        {
            _helpCircles = new List<Circle>();
            foreach (var v in _polygonToEdit.Vertices)
            {
                var helpCircle = new Circle(v, Constants.DETECTION_RADIUS, _polygonToEdit.Color);
                _helpCircles.Add(helpCircle);
                _rasterObjects.Add(helpCircle);
            }
        }

        private void RemoveVertexCircles()
        {
            if (_helpCircles == null) return;
            foreach (var c in _helpCircles)
            {
                _rasterObjects.Remove(c);
            }
            _helpCircles.Clear();
        }

        private void UpdateVertexCircles()
        {
            RemoveVertexCircles();
            AddVertexCircles();
        }
    }
}
