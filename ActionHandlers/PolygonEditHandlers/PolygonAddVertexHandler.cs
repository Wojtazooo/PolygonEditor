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
using PolygonEditor.ActionHandlers.GeneralEditHandlers;
using PolygonEditor.Constraints;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    class PolygonAddVertexHandler : ActionHandler
    {
        private SelectionHandler _selector;
        private Polygon _polygonToEdit;
        private Circle _helpAddCircle;
        private List<Circle> _helpCircles;

        public PolygonAddVertexHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea,
            ConstraintsEnforcer constraintsEnforcer)
            : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            AddInstructions(InstructionTexts.AddVertexInstruction);
            InitSelector();
        }

        private void InitSelector()
        {
            _selector = new SelectionHandler(RasterObjects, HelperTextBox, DrawingArea, ConstraintsEnforcer);
        }
        
        public override void Cancel()
        {
            _polygonToEdit = null;
            RemoveCirclePointer();
            RemoveVertexCircles();
        }

        public override void Finish()
        {
            _polygonToEdit = null;
            InitSelector();
            RemoveCirclePointer();
            RemoveVertexCircles();
            base.Finish();
        }

        public override void Submit()
        {
            _polygonToEdit = null;
            InitSelector();
            RemoveCirclePointer();
            RemoveVertexCircles();
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            var mouseMyPoint = new MyPoint(e.X, e.Y);
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.ClickedRasterObject is Polygon)
                {
                    _polygonToEdit = (Polygon) _selector.ClickedRasterObject;
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

        public override void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseMove(e);
            }
            else
            {
                var (a, b) = _polygonToEdit.isEdgeClicked(mouseMyPoint);
                if (a != null && b != null)
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

        private void AddCirclePointer(MyPoint mouseMyPoint)
        {
            _helpAddCircle = new Circle(mouseMyPoint, Constants.ADD_VERTEX_CIRCLE_RADIUS, Color.Green);
            RasterObjects.Add(_helpAddCircle);
        }

        private void RemoveCirclePointer()
        {
            RasterObjects.Remove(_helpAddCircle);
            _helpAddCircle = null;
        }

        private void UpdateCirclePointer(MyPoint mouseMyPoint)
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
                RasterObjects.Add(helpCircle);
            }
        }

        private void RemoveVertexCircles()
        {
            if (_helpCircles == null) return;
            foreach (var c in _helpCircles)
            {
                RasterObjects.Remove(c);
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