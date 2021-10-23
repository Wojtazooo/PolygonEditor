using System.Collections.Generic;
using System.Windows.Forms;
using PolygonEditor.Constraints;
using PolygonEditor.GlobalHelpers;
using PolygonEditor.RasterGraphics.Models;

namespace PolygonEditor.ActionHandlers.GeneralEditHandlers
{
    public class RemoveRasterObjectHandler : ActionHandler
    {
        private readonly SelectionHandler _selectionHandler;

        public RemoveRasterObjectHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
            _selectionHandler = new SelectionHandler(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer);
            AddInstructions(InstructionTexts.RemoveRasterObjectInstruction);
        }

        public override void Cancel()
        {
            DrawingArea.Cursor = Cursors.Default;
        }

        public override void Finish()
        {
            Cancel();
            base.Finish();
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            _selectionHandler.HandleMouseClick(e);
            if(_selectionHandler.ClickedRasterObject != null)
            {
                RasterObjects.Remove(_selectionHandler.ClickedRasterObject);
                _selectionHandler.Cancel();
            }
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            _selectionHandler.HandleMouseMove(e);
        }
    }
}
