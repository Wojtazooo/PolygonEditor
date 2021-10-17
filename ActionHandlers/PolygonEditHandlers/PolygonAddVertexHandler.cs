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
            RemoveCirclePointer();
            RemoveVertexCircles();
        }

        public void Finish()
        {
            RemoveCirclePointer();
            RemoveVertexCircles();
        }

        public void Submit()
        {
            RemoveCirclePointer();
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.clickedRasterObject is Polygon)
                {
                    _polygonToEdit = (Polygon)_selector.clickedRasterObject;
                    _selector.Cancel();
                    AddCirclePointer(mousePoint);
                    AddVertexCircles();
                }
            }
            else
            {
                _polygonToEdit.AddVertexInsideEdge(mousePoint);
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
                Point mousePoint = new Point(e.X, e.Y);
                (Point? a, Point? b) = _polygonToEdit.isEdgeClicked(mousePoint);
                if(a.HasValue && b.HasValue)
                {
                    if (_helpAddCircle == null) AddCirclePointer(mousePoint);
                    else UpdateCirclePointer(mousePoint);
                }
                else
                {
                    RemoveCirclePointer();
                }
            }
        }

        public void AddCirclePointer(Point mousePoint)
        {
            _helpAddCircle = new Circle(mousePoint, Constants.ADD_VERTEX_CIRCLE_RADIUS, Color.Green);
            _rasterObjects.Add(_helpAddCircle);
        }

        public void RemoveCirclePointer()
        {
            _rasterObjects.Remove(_helpAddCircle);
            _helpAddCircle = null;
        }

        public void UpdateCirclePointer(Point mousePoint)
        {
            _helpAddCircle.SetCenter(mousePoint);
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
