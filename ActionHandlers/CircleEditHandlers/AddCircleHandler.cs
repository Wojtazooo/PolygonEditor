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
using PolygonEditor.RasterGraphics.Helpers;

namespace PolygonEditor.ActionHandlers
{
    class AddCircleHandler : ActionHandler
    {
        private Circle _circle;
        private Color _color;
        private Line _helpRadiusLine = new Line(Color.DarkGray);
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;

        public AddCircleHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, Color circleColor, PictureBox drawingArea)
        {
            _rasterObjects = rasterObjects;
            _rasterObjects.Add(_helpRadiusLine);
            _helperTextBox = helperTextBox;
            _color = circleColor;
            _drawingArea = drawingArea;
            _drawingArea.Cursor = Cursors.Cross;
        }

        public void Submit()
        {
            _rasterObjects.Remove(_helpRadiusLine);
            _helpRadiusLine = new Line(Color.DarkGray);
            _rasterObjects.Add(_helpRadiusLine);
            _circle = null;
        }

        public void Cancel()
        {
            _rasterObjects.Remove(_circle);
            Submit();
        }

        public void Finish()
        {
            _rasterObjects.Remove(_helpRadiusLine);
            RemoveInstruction();
            _drawingArea.Cursor = Cursors.Default;
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
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                MyPoint circleCenter = _circle.Center;
                int newRadius = (int)ExtensionMethods.PixelDistance(mouseMyPoint, circleCenter);
                _circle.SetRadius(newRadius);
                _helpRadiusLine.SetP1AndP2(_circle.Center, mouseMyPoint);
            }
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint clickedMyPoint = new MyPoint(e.X, e.Y);
            if (_circle == null)
            {
                _circle = new Circle(clickedMyPoint, 0, _color);
                _rasterObjects.Add(_circle);
            }
            else
            {
                Submit();
            }
        }

        public bool HandleKeybordKeyClick(KeyEventArgs e)
        {
            return false;
        }
    }
}
