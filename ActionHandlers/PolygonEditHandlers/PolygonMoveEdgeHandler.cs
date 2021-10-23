using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolygonEditor.ActionHandlers.GeneralEditHandlers;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    internal class PolygonMoveEdgeHandler : ActionHandler
    {
        private MyPoint _previousMyPoint;
        private (int a, int b) _edgeToMove;
        private MyPoint _startMyPoint;
        bool _moving = false;
        private SelectionHandler _selector;
        private Polygon _polygonToEdit;
        private List<Circle> _helpCircles = new List<Circle>();

        public PolygonMoveEdgeHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        :base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            _selector = new SelectionHandler(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer);
            AddInstructions(InstructionTexts.MoveEdgeInstruction);
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
            _selector = new SelectionHandler(RasterObjects, HelperTextBox, DrawingArea, ConstraintsEnforcer);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            if(_polygonToEdit == null)
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
            var mouseMyPoint = new MyPoint(e.X, e.Y);
            if (_polygonToEdit == null) return;
            var (a, b) = _polygonToEdit.isEdgeClicked(mouseMyPoint);
            if (a == null || b == null) return;
            DrawingArea.Cursor = Cursors.SizeAll;
            _edgeToMove = (_polygonToEdit.Vertices.FindIndex(p => p == a), _polygonToEdit.Vertices.FindIndex(p => p == b));
            _moving = true;
            _previousMyPoint = mouseMyPoint;
            _startMyPoint = mouseMyPoint;
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            if (_polygonToEdit == null)
            {
                _selector.HandleMouseMove(e);
            }
            else
            {
                var mouseMyPoint = new MyPoint(e.X, e.Y);
                if (!_moving) return;
                var a2 = ExtensionMethods.MovePoint(_polygonToEdit.Vertices[_edgeToMove.a], _previousMyPoint, mouseMyPoint);
                var b2 = ExtensionMethods.MovePoint(_polygonToEdit.Vertices[_edgeToMove.b], _previousMyPoint, mouseMyPoint);

                (a2, b2) = _polygonToEdit.MoveEdge(_polygonToEdit.Vertices[_edgeToMove.a], _polygonToEdit.Vertices[_edgeToMove.b], _previousMyPoint, mouseMyPoint);
                _previousMyPoint = mouseMyPoint;

                ConstraintsEnforcer.EnforcePolygonConstraints(_polygonToEdit, ExtensionMethods.GetVertexNumberFromPoint(_polygonToEdit, a2));
                ConstraintsEnforcer.EnforcePolygonConstraints(_polygonToEdit, ExtensionMethods.GetVertexNumberFromPoint(_polygonToEdit, b2));
                RasterObjects.ForEach(obj =>
                {
                    if (obj is Circle)
                    {
                        ConstraintsEnforcer.EnforceCircleConstraint(((Circle)obj));
                    }
                });

                UpdateCircles();
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
            foreach (var v in _polygonToEdit.Vertices)
            {
                var helpCircle = new Circle(v, Constants.DETECTION_RADIUS, _polygonToEdit.Color);
                _helpCircles.Add(helpCircle);
                RasterObjects.Add(helpCircle);
            }
        }

        private void RemoveCircles()
        {
            foreach (var c in _helpCircles)
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
