using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    class RemoveVertexHandler : ActionHandler
    {
        List<Cross> _redCrosses;
        private PictureBox _drawingArea;
        private Polygon _polygonToEdit;
        private List<RasterObject> _rasterObjects;
        private SelectionHandler _selector;

        public RemoveVertexHandler(List<RasterObject> rasterObjects, PictureBox drawingArea) 
        {
            _selector = new SelectionHandler(rasterObjects, null, drawingArea);
            _rasterObjects = rasterObjects;
            _redCrosses = new List<Cross>();
            _drawingArea = drawingArea;
        }

        private void AddCrosses()
        {
            foreach (var point in _polygonToEdit.Vertices)
            {
                _redCrosses.Add(new Cross(point, Constants.CROSS_WIDTH, Color.Red));
            }
            _rasterObjects.AddRange(_redCrosses);
        }

        private void RemoveCrosses()
        {
            _redCrosses.ForEach(cross => _rasterObjects.Remove(cross));

        }

        public void Cancel()
        {
            RemoveCrosses();
        }

        public void Submit()
        {
            _selector = new SelectionHandler(_rasterObjects, null, _drawingArea);
            _polygonToEdit = null;
            RemoveCrosses();
            _redCrosses = new List<Cross>();
        }

        public void Finish()
        {
            RemoveCrosses();
        }

        public void HandleMouseClick(MouseEventArgs e) 
        {
            if(_polygonToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.clickedRasterObject is Polygon)
                {
                    _polygonToEdit = (Polygon)_selector.clickedRasterObject;
                    AddCrosses();
                }
            }
            else
            {
                Point mousePoint = new Point(e.X, e.Y);
                Point? detectedPoint = _polygonToEdit.DetectObject(mousePoint, Constants.CROSS_WIDTH);
                if (detectedPoint != null)
                {
                    _polygonToEdit.RemoveVertex(detectedPoint.Value);
                    for (int i = 0; i < _redCrosses.Count; i++)
                        if (_redCrosses[i].Center == detectedPoint.Value)
                        {
                            _rasterObjects.Remove(_redCrosses[i]);
                            _redCrosses.RemoveAt(i);
                        }
                }
            }
        }

        public void HandleMouseMove(MouseEventArgs e) 
        {
            if(_polygonToEdit == null)
            {
                _selector.HandleMouseMove(e);
               
            }
            else
            {
                Point mousePoint = new Point(e.X, e.Y);
                Point? detectedPoint = _polygonToEdit.DetectObject(mousePoint, Constants.CROSS_WIDTH);
                if (detectedPoint != null && _polygonToEdit.Vertices.Contains(detectedPoint.Value))
                {
                    _drawingArea.Cursor = Cursors.Hand;
                }
                else
                {
                    _drawingArea.Cursor = Cursors.Default;
                }
            }
        }
    }
}
