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
    class RemoveVertexHandler : PolygonEditGenericHandler
    {
        List<Cross> _redCrosses;

        public RemoveVertexHandler(Polygon polygon, List<RasterObject> rasterObjects, PictureBox drawingArea) : base(polygon, rasterObjects, drawingArea)
        {
            _redCrosses = new List<Cross>();
            foreach (var point in polygon.Vertices)
            {
                _redCrosses.Add(new Cross(point, Constants.CROSS_WIDTH, Color.Red));
            }
            _rasterObjects.AddRange(_redCrosses);
        }

        public override void Cancel()
        {
            _redCrosses.ForEach(cross => _rasterObjects.Remove(cross));
        }

        public override void HandleMouseClick(MouseEventArgs e) 
        {
            Point mousePoint = new Point(e.X, e.Y);
            Point? detectedPoint = _polygonToEdit.DetectObject(mousePoint, Constants.CROSS_WIDTH);
            if(detectedPoint != null)
            {
                _polygonToEdit.RemoveVertex(detectedPoint.Value);
                for(int i = 0; i < _redCrosses.Count; i++)
                    if(_redCrosses[i].Center == detectedPoint.Value)
                    {
                        _rasterObjects.Remove(_redCrosses[i]);
                        _redCrosses.RemoveAt(i);
                    }
            }
        }

        public override void HandleMouseMove(MouseEventArgs e) 
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
