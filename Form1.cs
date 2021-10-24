using PolygonEditor.ActionHandlers;
using PolygonEditor.ActionHandlers.CircleEditHandlers;
using PolygonEditor.ActionHandlers.ConstraintsActionHandlers;
using PolygonEditor.ActionHandlers.ConstraintsActionHandlers.CircleConstraintsHandlers;
using PolygonEditor.ActionHandlers.ConstraintsActionHandlers.PolygonConstrainsHandlers;
using PolygonEditor.ActionHandlers.PolygonEditHandlers;
using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using PolygonEditor.ActionHandlers.GeneralEditHandlers;
using PolygonEditor.Constraints.PolygonConstraints;

namespace PolygonEditor
{
    public partial class MainForm : Form
    {
        private readonly RasterGraphicsApplier _pointsApplier;
        private readonly List<RasterObject> _rasterObjects;
        private ActionHandler _activeActionHandler;
        private Timer _timer;
        private readonly ConstraintsEnforcer _constraintsEnforcer;
        public Polygon TestLine;
        public Circle TestCircle;


        public MainForm()
        {
            InitializeComponent();
            _rasterObjects = new List<RasterObject>();
            _pointsApplier = new RasterGraphicsApplier(DrawingArea, _rasterObjects);
            _constraintsEnforcer = new ConstraintsEnforcer(_rasterObjects);
            InitializeSelectedColor();
            InitializeRefreshTimer();
            SampleScene.GenerateScene(_rasterObjects);
        }

        private void InitializeRefreshTimer()
        {
            _timer = new Timer();
            _timer.Interval = Constants.REFRESH_TIME_IN_MS;
            _timer.Tick += UpdateView;
            _timer.Start();
        }

        private void InitializeSelectedColor()
        {
            PictureBoxSelectedColor.BackColor = Color.Black;
        }

       


        private void UpdateView(object sender, EventArgs e)
        {
            _pointsApplier.Apply();
        }

        private void ButtonPickColor_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = null;
            var colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = PictureBoxSelectedColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
                PictureBoxSelectedColor.BackColor = colorDialog.Color;
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (_activeActionHandler != null && _activeActionHandler.HandleKeyboardKeyClick(e)) return;

            switch (e.KeyCode)
            {
                case Keys.Escape:
                    _activeActionHandler?.Finish();
                    _activeActionHandler = null;
                    break;
                case Keys.Delete:
                    ButtonDeleteObject_Click(null, null);
                    break;
            }
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            _activeActionHandler?.HandleMouseMove(mouseEventArgs);
        }

        private void DrawingArea_MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    _activeActionHandler?.HandleMouseClick(e);
                    break;
                case MouseButtons.Right:
                    _activeActionHandler?.Submit();
                    break;
            }
        }

        private void ButtonAddPolygon_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();

            _activeActionHandler = new AddPolygonHandler(_rasterObjects, textBoxHelper, DrawingArea,
                _constraintsEnforcer,
                PictureBoxSelectedColor.BackColor);
        }

        private void ButtonDeleteObject_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new RemoveRasterObjectHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonMoveObject_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new MoveRasterObjectHandler(_rasterObjects, DrawingArea, textBoxHelper, _constraintsEnforcer);
        }

        private void ButtonAddCircle_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new AddCircleHandler(_rasterObjects, textBoxHelper, DrawingArea,
                _constraintsEnforcer, PictureBoxSelectedColor.BackColor);
        }

        private void ButtonMoveVertex_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new MovePolygonVertexHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
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
            _activeActionHandler =
                new CircleChangeRadiusHandler(_rasterObjects, DrawingArea, textBoxHelper, _constraintsEnforcer);
        }

        private void ButtonAddVertex_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new PolygonAddVertexHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonConstantCenter_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new AddConstantCenterHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonConstantRadius_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new AddConstantRadiusHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonMoveEdge_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new PolygonMoveEdgeHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonRemoveVertex_Click_1(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new PolygonRemoveVertexHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonPerpendicular_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new AddRightAngleConstraintHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonSameLength_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new AddSameLengthHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonConstantLength_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new AddConstantEdgeLengthHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonRemoveConstraint_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new RemoveConstraintHandler(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }

        private void ButtonTangentLine_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler =
                new AddCircleTangentToEdge(_rasterObjects, textBoxHelper, DrawingArea, _constraintsEnforcer);
        }
    }
}