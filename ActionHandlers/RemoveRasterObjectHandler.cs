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
        private PictureBox _drawingArea;
        private SelectionHandler _selectionHandler;

        public RemoveRasterObjectHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea)
        {
            _rasterObjects = rasterObjects;
            _helperTextBox = textBoxHelper;
            _drawingArea = drawingArea;
            _selectionHandler = new SelectionHandler(rasterObjects, textBoxHelper, drawingArea);
        }

        public void Cancel()
        {
            _drawingArea.Cursor = Cursors.Default;
        }

        public void Finish()
        {
            Cancel();
        }

        public bool HandleKeybordKeyClick(KeyEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            _selectionHandler.HandleMouseClick(e);
            if(_selectionHandler.clickedRasterObject != null)
            {
                _rasterObjects.Remove(_selectionHandler.clickedRasterObject);
                _selectionHandler.Cancel();
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            return false;
        }
    }
}
