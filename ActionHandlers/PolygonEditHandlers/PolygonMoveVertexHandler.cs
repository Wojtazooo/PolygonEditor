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
using PolygonEditor.ActionHandlers.GeneralEditHandlers;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    class MovePolygonVertexHandler : ActionHandler
    {
        private MyPoint _previousMyPoint;
        private int _vertexToMove;
        private MyPoint _startMyPoint;
        private bool _moving = false;
        private SelectionHandler _selector;
        private Polygon _polygonToEdit;
        private List<Circle> _helpCircles = new List<Circle>();


        public MovePolygonVertexHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
            :base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            InitSelector();
            AddInstructions(InstructionTexts.MoveVertexInstruction);
        }

        private void InitSelector()
        {
            _selector = new SelectionHandler(RasterObjects, HelperTextBox, DrawingArea, ConstraintsEnforcer);
        }

        public override void Cancel()
        {
            RemoveCircles();
        }

        public override void Finish()
        {
            RemoveCircles();
            base.Finish();
        }

        public override void Submit()
        {
            RemoveCircles();
            _polygonToEdit = null;
            InitSelector();
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.ClickedRasterObject is Polygon)
                {
                    _polygonToEdit = (Polygon)_selector.ClickedRasterObject;
                    _selector.Cancel();
                    AddCircles();
                }
            }
        }

        public override void HandleMouseDown(MouseEventArgs e)
        {
            if(_polygonToEdit != null)
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                MyPoint detectedMyPoint = _polygonToEdit.DetectObject(mouseMyPoint, Constants.CROSS_WIDTH);
                if (detectedMyPoint != null && _polygonToEdit.Vertices.Contains(detectedMyPoint))
                {
                    DrawingArea.Cursor = Cursors.SizeAll;
                    _vertexToMove = _polygonToEdit.Vertices.FindIndex(p => p == detectedMyPoint);
                    _moving = true;
                    _previousMyPoint = mouseMyPoint;
                    _startMyPoint = mouseMyPoint;
                }
            }
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            if(_polygonToEdit == null)
            {
                _selector.HandleMouseMove(e);
            }
            else
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                if (_moving)
                {
                    _polygonToEdit.MoveVertex(_polygonToEdit.Vertices[_vertexToMove], mouseMyPoint);
                    ConstraintsEnforcer.EnforcePolygonConstraints(_polygonToEdit, ExtensionMethods.GetVertexNumberFromPoint(_polygonToEdit, _polygonToEdit.Vertices[_vertexToMove]));
                    RasterObjects.ForEach(obj =>
                    {
                        if(obj is Circle)
                        {
                            ConstraintsEnforcer.EnforceCircleConstraint(((Circle)obj));
                        }
                    });
                    UpdateCircles();
                }
            }
        }

        public override void HandleMouseUp(MouseEventArgs e)
        {
            _moving = false;
            DrawingArea.Cursor = Cursors.Default;
        }

        private void AddCircles()
        {
            _helpCircles = new List<Circle>();
            foreach(var v in _polygonToEdit.Vertices)
            {
                var helpCircle = new Circle(v, Constants.DETECTION_RADIUS, _polygonToEdit.Color);
                _helpCircles.Add(helpCircle);
                RasterObjects.Add(helpCircle);
            }
        }

        private void RemoveCircles()
        {
            foreach(var c in _helpCircles)
            {
                RasterObjects.Remove(c);
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
