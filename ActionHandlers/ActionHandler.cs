using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers
{
    public class ActionHandler
    {
        protected List<RasterObject> RasterObjects;
        protected TextBox HelperTextBox;
        protected PictureBox DrawingArea;
        protected ConstraintsEnforcer ConstraintsEnforcer;

        protected ActionHandler(List<RasterObject> rasterObjects, TextBox helperTextBox, PictureBox drawingArea, ConstraintsEnforcer constraintsEnforcer)
        {
            RasterObjects = rasterObjects;
            HelperTextBox = helperTextBox;
            DrawingArea = drawingArea;
            ConstraintsEnforcer = constraintsEnforcer;
        }

        public virtual void HandleMouseMove(MouseEventArgs e) { }
        public virtual void HandleMouseClick(MouseEventArgs e) { }
        public virtual void HandleMouseUp(MouseEventArgs e) { }
        public virtual void HandleMouseDown(MouseEventArgs e) { }
        // returns true if key click was handled
        public virtual bool HandleKeyboardKeyClick(KeyEventArgs e) { return false; }
        public virtual void Finish() { RemoveInstructions(); }
        public virtual void Cancel() { }
        public virtual void Submit() { }

        private void RemoveInstructions()
        {
            HelperTextBox.Lines = null;
        }

        protected void AddInstructions(string[] instructionsToAdd)
        {
            HelperTextBox.Lines = instructionsToAdd;
        }
    }
}
