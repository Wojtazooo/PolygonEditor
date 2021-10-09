using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using PolygonEditor;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers
{
    class AddCircleHandler : ActionHandler
    {
        private Circle _circle;
        private Color _color;
        private Line _helpRadiusLine = new Line(Color.DarkGray);
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;

        public AddCircleHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, Color circleColor)
        {
            _rasterObjects = rasterObjects;
            _rasterObjects.Add(_helpRadiusLine);
            _helperTextBox = helperTextBox;
            _color = circleColor;
        }

        public void Cancel()
        {
            _rasterObjects.Add(_helpRadiusLine);
            _rasterObjects.Remove(_circle);
            RemoveInstruction();
        }

        public void Finish()
        {
            _rasterObjects.Remove(_helpRadiusLine);
            RemoveInstruction();
        }

        private void RemoveInstruction()
        {
            _helperTextBox.Lines = null;
            _helperTextBox.ForeColor = Color.White;
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            if(_circle != null)
            {
                Point mousePoint = new Point(e.X, e.Y);
                Point circleCenter = _circle.Center;
                int newRadius = ExtensionMethods.PixelDistance(mousePoint, circleCenter);
                _circle.SetRadius(newRadius);
                _helpRadiusLine.SetP1AndP2(_circle.Center, mousePoint);
            }
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            Point clickedPoint = new Point(e.X, e.Y);
            if (_circle == null)
            {
                _circle = new Circle(clickedPoint, 0, _color);
                _rasterObjects.Add(_circle);
            }
            else
            {
                Point circleCenter = _circle.Center;
                int newRadius = ExtensionMethods.PixelDistance(clickedPoint, circleCenter);
                _circle.SetRadius(newRadius);
            }
        }
    }
}
