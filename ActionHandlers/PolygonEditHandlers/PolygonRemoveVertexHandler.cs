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
using PolygonEditor.ActionHandlers.GeneralEditHandlers;
using PolygonEditor.Constraints;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    class PolygonRemoveVertexHandler : ActionHandler
    {
        List<Cross> _redCrosses;
        private Polygon _polygonToEdit;
        private SelectionHandler _selector;

        public PolygonRemoveVertexHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
            :base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            _redCrosses = new List<Cross>();
            InitSelector();
            AddInstructions(InstructionTexts.RemoveVertexInstruction);
        }
        
        private void InitSelector()
        {
            _selector = new SelectionHandler(RasterObjects, HelperTextBox, DrawingArea, ConstraintsEnforcer);
        }

        private void AddCrosses()
        {
            foreach (var point in _polygonToEdit.Vertices)
            {
                _redCrosses.Add(new Cross(point, Constants.CROSS_WIDTH, Color.Red));
            }
            RasterObjects.AddRange(_redCrosses);
        }

        private void RemoveCrosses()
        {
            _redCrosses.ForEach(cross => RasterObjects.Remove(cross));

        }

        public override void Cancel()
        {
            RemoveCrosses();
        }

        public override void Submit()
        {
            InitSelector();
            _polygonToEdit = null;
            RemoveCrosses();
            _redCrosses = new List<Cross>();
        }

        public override void Finish()
        {
            RemoveCrosses();
            base.Finish(); 
        }

        public override void HandleMouseClick(MouseEventArgs e) 
        {
            if(_polygonToEdit == null)
            {
                _selector.HandleMouseClick(e);
                if (_selector.ClickedRasterObject is Polygon)
                {
                    _polygonToEdit = (Polygon)_selector.ClickedRasterObject;
                    AddCrosses();
                }
            }
            else
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                MyPoint detectedMyPoint = _polygonToEdit.DetectObject(mouseMyPoint, Constants.CROSS_WIDTH);
                if (detectedMyPoint != null)
                {
                    _polygonToEdit.RemoveVertex(detectedMyPoint);
                    for (int i = 0; i < _redCrosses.Count; i++)
                        if (_redCrosses[i].Center == detectedMyPoint)
                        {
                            RasterObjects.Remove(_redCrosses[i]);
                            _redCrosses.RemoveAt(i);
                        }
                }
            }
        }

        public override void HandleMouseMove(MouseEventArgs e) 
        {
            if(_polygonToEdit == null)
            {
                _selector.HandleMouseMove(e);
               
            }
            else
            {
                MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
                MyPoint detectedMyPoint = _polygonToEdit.DetectObject(mouseMyPoint, Constants.CROSS_WIDTH);
                if (detectedMyPoint != null && _polygonToEdit.Vertices.Contains(detectedMyPoint))
                {
                    DrawingArea.Cursor = Cursors.Hand;
                }
                else
                {
                    DrawingArea.Cursor = Cursors.Default;
                }
            }
        }
    }
}
