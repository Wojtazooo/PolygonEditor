using System.Collections.Generic;
using System.Windows.Forms;
using PolygonEditor.Constraints;
using PolygonEditor.GlobalHelpers;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;

namespace PolygonEditor.ActionHandlers.GeneralEditHandlers
{
    class SelectionHandler : ActionHandler
    {
        private RasterObject DetectedRasterObject { get; set; }
        public RasterObject ClickedRasterObject { get; private set; }

        public SelectionHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
            : base(rasterObjects, helperTextBox, drawingArea, constraintsEnforcer)
        {
        }

        public override void Cancel()
        {
            DetectedRasterObject = null;
            ClickedRasterObject = null;
            DrawingArea.Cursor = Cursors.Default;
        }

        public override void HandleMouseClick(MouseEventArgs e)
        {
            if(DetectedRasterObject != null)
            {
                ClickedRasterObject = DetectedRasterObject;
            }
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
            MyPoint mouseMyPoint = new MyPoint(e.X, e.Y);
            for (int i = 0; i < RasterObjects.Count; i++)
            {
                var point = RasterObjects[i].DetectObject(mouseMyPoint, Constants.DETECTION_RADIUS);
                if (point != null)
                {
                    DrawingArea.Cursor = Cursors.Hand;
                    DetectedRasterObject = RasterObjects[i];
                    return;
                }
            }
            Cancel();
        }
    }
}
