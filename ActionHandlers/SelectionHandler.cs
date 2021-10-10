using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers
{
    class SelectionHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        public RasterObject? detectedRasterObject { get; private set; }
        public RasterObject? clickedRasterObject { get; private set; }

        private PictureBox _drawingArea;

        public SelectionHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea)
        {
            _rasterObjects = rasterObjects;
            _helperTextBox = textBoxHelper;
            _drawingArea = drawingArea;
        }

        public void Cancel()
        {
            detectedRasterObject = null;
            clickedRasterObject = null;
            _drawingArea.Cursor = Cursors.Default;
        }

        public void Finish()
        {
            return;
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            if(detectedRasterObject != null)
            {
                clickedRasterObject = detectedRasterObject;
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            for (int i = 0; i < _rasterObjects.Count; i++)
            {
                var point = _rasterObjects[i].DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                if (point != null)
                {
                    _drawingArea.Cursor = Cursors.Hand;
                    detectedRasterObject = _rasterObjects[i];
                    return;
                }
            }
            Cancel();
        }

        public void InsertInstructions()
        {
            _helperTextBox.Lines = InstructionTexts.Selection;
        }

        public bool HandleKeybordKeyClick(KeyEventArgs e)
        {
            return false;
        }
    }
}
