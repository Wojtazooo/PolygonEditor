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
using PolygonEditor.Constraints;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers
{
    public class AddPolygonHandler : ActionHandler
    {
        private Polygon _polygon;
        private Line helpLine1 = new Line(Color.DarkGray);
        private Line helpLine2 = new Line(Color.DarkGray);

        public AddPolygonHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer, Color polygonColor)
            :base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            _polygon = new Polygon(polygonColor);
            RasterObjects.Add(_polygon);
            RasterObjects.Add(helpLine1);
            RasterObjects.Add(helpLine2);
            DrawingArea.Cursor = Cursors.Cross;
            AddInstructions(InstructionTexts.AddPolygonInstruction);
        }

        public override void Submit()
        {
            RasterObjects.Remove(helpLine1);
            RasterObjects.Remove(helpLine2);
            _polygon = new Polygon(_polygon.Color);
            RasterObjects.Add(_polygon);
            helpLine1 = new Line(Color.DarkGray);
            helpLine2 = new Line(Color.DarkGray);
            RasterObjects.Add(helpLine1);
            RasterObjects.Add(helpLine2);
        }

        public override void Cancel()
        {
            RasterObjects.Remove(helpLine1);
            RasterObjects.Remove(helpLine2);
            RasterObjects.Remove(_polygon);
            DrawingArea.Cursor = Cursors.Default;
        }

        public override void Finish()
        {
            RasterObjects.Remove(helpLine1);
            RasterObjects.Remove(helpLine2);
            if (_polygon.Vertices.Count < 3)
                RasterObjects.Remove(_polygon);
            DrawingArea.Cursor = Cursors.Default;
            base.Finish();
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            if(_polygon?.Vertices.Count >= 1)
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                helpLine1.SetP1AndP2(_polygon.Vertices.First(), mouseMyPoint);
                helpLine2.SetP1AndP2(_polygon.Vertices.Last(), mouseMyPoint);
            }
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint clickedMyPoint = new MyPoint(e.X, e.Y);
            if (e.Button == MouseButtons.Left)
            {
                _polygon.AddVertex(clickedMyPoint);
            }
            else if (e.Button == MouseButtons.Right)
            {
                Finish();
            }
        }

        public override bool HandleKeyboardKeyClick(KeyEventArgs e)
        {
            return false;
        }
    }
}
