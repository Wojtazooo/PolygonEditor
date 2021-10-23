using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PolygonEditor.Constraints;
using PolygonEditor.GlobalHelpers;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;

namespace PolygonEditor.ActionHandlers.CircleEditHandlers
{
    internal class AddCircleHandler : ActionHandler
    {
        private Circle _circle;
        private readonly Color _color;
        private Line _helpRadiusLine = new Line(Color.DarkGray);

        public AddCircleHandler(
            List<RasterObject> rasterObjects,
            TextBox helperTextBox,
            PictureBox drawingArea,
            ConstraintsEnforcer constraintsEnforcer,
            Color circleColor
        )
            : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            RasterObjects.Add(_helpRadiusLine);
            _color = circleColor;
            DrawingArea.Cursor = Cursors.Cross;
            AddInstructions(InstructionTexts.AddCircleInstruction);
        }

        public override void Submit()
        {
            RasterObjects.Remove(_helpRadiusLine);
            _helpRadiusLine = new Line(Color.DarkGray);
            RasterObjects.Add(_helpRadiusLine);
            _circle = null;
        }

        public override void Cancel()
        {
            RasterObjects.Remove(_circle);
            Submit();
        }

        public override void Finish()
        {
            RasterObjects.Remove(_helpRadiusLine);
            DrawingArea.Cursor = Cursors.Default;
            base.Finish();
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            if (_circle == null) return;
            var mouseMyPoint = new MyPoint(e.X, e.Y);
            var circleCenter = _circle.Center;
            var newRadius = (int) ExtensionMethods.PixelDistance(mouseMyPoint, circleCenter);
            _circle.SetRadius(newRadius);
            _helpRadiusLine.SetP1AndP2(_circle.Center, mouseMyPoint);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            var clickedMyPoint = new MyPoint(e.X, e.Y);
            if (_circle == null)
            {
                _circle = new Circle(clickedMyPoint, 0, _color);
                RasterObjects.Add(_circle);
            }
            else
            {
                Submit();
            }
        }
    }
}