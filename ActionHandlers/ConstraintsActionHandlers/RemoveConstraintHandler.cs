using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PolygonEditor.GlobalHelpers;

namespace PolygonEditor.ActionHandlers.ConstraintsActionHandlers
{
    class RemoveConstraintHandler : ActionHandler
    {
        public RemoveConstraintHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            AddInstructions(InstructionTexts.RemoveConstraintInstruction);
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach (var rasterObj in RasterObjects)
            {
                if (rasterObj.RemoveConstraintByClick(mouseMyPoint)) return;
            }
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            foreach(var rasterObj in RasterObjects)
            {
                if (rasterObj.DetectConstraint(mouseMyPoint))
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
