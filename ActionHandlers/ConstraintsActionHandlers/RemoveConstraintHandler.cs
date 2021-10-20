﻿using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers
{
    class RemoveConstraintHandler : ActionHandler
    {
        private List<RasterObject> _rasterObjects;
        private TextBox _helperTextBox;
        private PictureBox _drawingArea;

        public RemoveConstraintHandler(List<RasterObject> rasterObjects, TextBox textBoxHelper, PictureBox drawingArea)
        {
            _rasterObjects = rasterObjects;
            _helperTextBox = textBoxHelper;
            _drawingArea = drawingArea;
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach (var rasterObj in _rasterObjects)
            {
                if (rasterObj.RemoveConstraintByClick(mouseMyPoint)) return;
            }
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach(var rasterObj in _rasterObjects)
            {
                if (rasterObj.DetectConstraint(mouseMyPoint))
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
