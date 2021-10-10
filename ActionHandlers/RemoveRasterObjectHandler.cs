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
    public class RemoveRasterObjectHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private RasterObject? detectedRasterObject = null;
        private PictureBox _drawingArea;

        public RemoveRasterObjectHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea)
        {
            _rasterObjects = rasterObjects;
            _helperTextBox = textBoxHelper;
            _drawingArea = drawingArea;
        }

        public void Cancel()
        {
            _drawingArea.Cursor = Cursors.Default;
            detectedRasterObject = null;
        }

        public void Finish()
        {
            Cancel();
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            if (detectedRasterObject != null)
            {
                _rasterObjects.Remove(detectedRasterObject);
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            Point mousePoint = new Point(e.X, e.Y);
            for(int i = 0; i < _rasterObjects.Count; i++)
            {
                var point = _rasterObjects[i].DetectObject(mousePoint, Constants.DETECTION_RADIUS);
                if (point != null)
                {
                    _drawingArea.Cursor = Cursors.Hand;
                    detectedRasterObject = _rasterObjects[i];
                    return;
                }
            }
            detectedRasterObject = null;
            _drawingArea.Cursor = Cursors.Default;
        }
    }
}
