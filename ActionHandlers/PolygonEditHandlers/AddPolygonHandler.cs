using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers
{
    public class AddPolygonHandler : ActionHandler
    {
        private Polygon _polygon;
        private Line helpLine1 = new Line(Color.DarkGray);
        private Line helpLine2 = new Line(Color.DarkGray);
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;

        public AddPolygonHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, Color polygonColor, PictureBox drawingArea)
        {
            _polygon = new Polygon(polygonColor);
            _rasterObjects = rasterObjects;
            _rasterObjects.Add(_polygon);
            _rasterObjects.Add(helpLine1);
            _rasterObjects.Add(helpLine2);
            _helperTextBox = helperTextBox;
            _helperTextBox.Lines = InstructionTexts.AddPolygon;
            helperTextBox.ForeColor = Color.Red;
            _drawingArea = drawingArea;
            _drawingArea.Cursor = Cursors.Cross;
        }

        public void Submit()
        {
            _rasterObjects.Remove(helpLine1);
            _rasterObjects.Remove(helpLine2);
            _polygon = new Polygon(_polygon.Color);
            _rasterObjects.Add(_polygon);
            helpLine1 = new Line(Color.DarkGray);
            helpLine2 = new Line(Color.DarkGray);
            _rasterObjects.Add(helpLine1);
            _rasterObjects.Add(helpLine2);
        }

        public void Cancel()
        {
            _rasterObjects.Remove(helpLine1);
            _rasterObjects.Remove(helpLine2);
            _rasterObjects.Remove(_polygon);
            RemoveInstruction();
            _drawingArea.Cursor = Cursors.Default;
        }

        public void Finish()
        {
            _rasterObjects.Remove(helpLine1);
            _rasterObjects.Remove(helpLine2);
            if (_polygon.Vertices.Count < 3)
                _rasterObjects.Remove(_polygon);
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
            if(_polygon?.Vertices.Count >= 1)
            {
                Point mousePoint = new Point(e.X, e.Y);
                helpLine1.SetP1AndP2(_polygon.Vertices.First(), mousePoint);
                helpLine2.SetP1AndP2(_polygon.Vertices.Last(), mousePoint);
            }
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            Point clickedPoint = new Point(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                _polygon.AddVertex(clickedPoint);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Finish();
            }
        }

        public bool HandleKeybordKeyClick(KeyEventArgs e)
        {
            return false;
        }
    }
}
