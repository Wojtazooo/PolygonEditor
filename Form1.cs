using PolygonEditor.ActionHandlers;
using PolygonEditor.ActionHandlers.CircleEditHandlers;
using PolygonEditor.ActionHandlers.ConstraintsActionHandlers;
using PolygonEditor.ActionHandlers.PolygonEditHandlers;
using PolygonEditor.Constraints;
using PolygonEditor.Constraints.PolygonConstraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PolygonEditor
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        private RasterGraphicsApplier _pointsApplier;
        private List<RasterObject> _rasterObjects;
        private ActionHandler _activeActionHandler;
        private Timer _timer;
        private ConstraintsEnforcer _constraintsEnforcer;
        public Polygon TestPolygon;



        public MainForm()
        {
            InitializeComponent();
            _rasterObjects = new List<RasterObject>();
            _pointsApplier = new RasterGraphicsApplier(DrawingArea, _rasterObjects);
            _constraintsEnforcer = new ConstraintsEnforcer(_rasterObjects);
            InitializeSelectedColor();
            InitializeRefreshTimer();
        }

        public void InitializeRefreshTimer()
        {
            _timer = new Timer();
            _timer.Interval = Constants.REFRESH_TIME_IN_MS;
            _timer.Tick += new EventHandler(UpdateView);
            _timer.Start();
        }

        public void InitializeSelectedColor()
        {
            PictureBoxSelectedColor.BackColor = Color.Black;
        }

        private void UpdateView(object sender, EventArgs e)
        {
            _pointsApplier.Apply();
        }

        private void ButtonPickColor_Click(object sender, System.EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = null;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = PictureBoxSelectedColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
                PictureBoxSelectedColor.BackColor = colorDialog.Color;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_activeActionHandler != null && _activeActionHandler.HandleKeybordKeyClick(e)) return;
            
            if (e.KeyCode == Keys.Escape)
            {
                _activeActionHandler?.Cancel();
                _activeActionHandler = null;
            }
            if(e.KeyCode == Keys.Delete)
            {
                ButtonDeleteObject_Click(null,null);
            }
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            _activeActionHandler?.HandleMouseMove(mouseEventArgs);
        }

        private void DrawingArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                _activeActionHandler?.HandleMouseClick(e);
            else if (e.Button == MouseButtons.Right)
            {
                _activeActionHandler?.Submit();
            }
        }

        private void ButtonAddPolygon_Click(object sender, System.EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new AddPolygonHandler(_rasterObjects, textBoxHelper, PictureBoxSelectedColor.BackColor, DrawingArea);
        }

        private void ButtonDeleteObject_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new RemoveRasterObjectHandler(_rasterObjects, textBoxHelper, DrawingArea);
        }

 		private void ButtonMoveObject_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new MoveRasterObjectHandler(_rasterObjects, DrawingArea, textBoxHelper); 
        }

        private void ButtonAddCircle_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new AddCircleHandler(_rasterObjects, textBoxHelper, PictureBoxSelectedColor.BackColor, DrawingArea);
        }

        private void ButtonMoveVertex_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new MovePolygonVertexHandler(_rasterObjects, DrawingArea, _constraintsEnforcer);
        }

        private void DrawingArea_MouseUp(object sender, MouseEventArgs e)
        {
            _activeActionHandler?.HandleMouseUp(e);
        }

        private void DrawingArea_MouseDown(object sender, MouseEventArgs e)
        {
            _activeActionHandler?.HandleMouseDown(e);
        }

        private void ButtonEditRadius_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new CircleChangeRadiusHandler(_rasterObjects, DrawingArea, textBoxHelper);
        }

        private void ButtonAddVertex_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new PolygonAddVertexHandler(_rasterObjects, DrawingArea);
        }

        private void ButtonConstantCenter_Click(object sender, EventArgs e)
        {

        }

        private void ButtonConstantRadius_Click(object sender, EventArgs e)
        {

        }

        private void ButtonMoveEdge_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new PolgonMoveEdgeHandler(_rasterObjects, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonRemoveVertex_Click_1(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new PolygonRemoveVertexHandler(_rasterObjects, DrawingArea);
        }

        private void ButtonPerpendicular_Click(object sender, EventArgs e)
        {

        }

        private void ButtonSameLength_Click(object sender, EventArgs e)
        {

        }

        private void ButtonConstantLength_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new AddConstantEdgeLengthHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonRemoveConstraint_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new RemoveConstraintHandler(_rasterObjects, textBoxHelper,DrawingArea);
        }

        private void ButtonTangentLine_Click(object sender, EventArgs e)
        {

        }
    }
}
