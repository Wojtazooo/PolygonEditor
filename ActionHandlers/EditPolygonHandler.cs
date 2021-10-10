using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers
{
    class EditPolygonHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;
        private SelectionHandler _selectionHandler;
        private List<RasterObject> _helperRasterObjects;
        private Polygon _polygonToEdit = null;

        public EditPolygonHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea)
        {
            _rasterObjects = rasterObjects;
            _helperRasterObjects = new List<RasterObject>();
            _helperTextBox = textBoxHelper;
            _drawingArea = drawingArea;
            _selectionHandler = new SelectionHandler(rasterObjects, textBoxHelper, drawingArea);
        }

        public void Cancel()
        {
            _selectionHandler = null;
            DeleteHelpingObjects();
        }

        public void Finish()
        {
            Cancel();
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            if(_polygonToEdit == null)
            {
                _selectionHandler?.HandleMouseClick(e);
                if (_selectionHandler.clickedRasterObject is Polygon)
                {
                    PolygonClicked();
                }
            }
            else
            {

            }
        }

        private void PolygonClicked()
        {
            _polygonToEdit = (Polygon)_selectionHandler.clickedRasterObject;
            _selectionHandler.Cancel();
            AddHelpingObjects();
        }

        private void AddHelpingObjects()
        {
            foreach(var v in _polygonToEdit.Vertices)
            {
                Circle vertexCircle = new Circle(v, Constants.DETECTION_RADIUS, _polygonToEdit.Color);
                _helperRasterObjects.Add(vertexCircle);
            }
            _rasterObjects.AddRange(_helperRasterObjects);
        }

        private void DeleteHelpingObjects()
        {
            foreach (var circle in _helperRasterObjects)
            {
                _rasterObjects.Remove(circle);
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            if (_polygonToEdit == null)
                _selectionHandler?.HandleMouseMove(e);
        }

        public bool HandleKeybordKeyClick(KeyEventArgs e)
        {


            return false;
        }
    }
}
