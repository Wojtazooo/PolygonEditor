using PolygonEditor.ActionHandlers;
using PolygonEditor.ActionHandlers.CircleEditHandlers;
using PolygonEditor.ActionHandlers.PolygonEditHandlers;
using PolygonEditor.Constraints;
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

        public Polygon TestPolygon;

        public List<IConstraint> constraints;


        public MainForm()
        {
            InitializeComponent();
            _rasterObjects = new List<RasterObject>();
            _pointsApplier = new RasterGraphicsApplier(DrawingArea, _rasterObjects);
            InitializeSelectedColor();
            InitializeRefreshTimer();

            InitTestPolygonn();
        }

        public void InitTestPolygonn()
        {
            TestPolygon = new Polygon(Color.Red);

            Point p1 = new Point(100, 100);
            Point p2 = new Point(200, 100);
            Point p3 = new Point(200, 200);
            Point p4 = new Point(100, 200);
            Point p5 = new Point(1100, 500);
            //Point p6 = new Point(600, 500);





            TestPolygon.AddVertex(p1);
            TestPolygon.AddVertex(p2);
            TestPolygon.AddVertex(p3);
            //TestPolygon.AddVertex(p4);
            //TestPolygon.AddVertex(p5);
            //TestPolygon.AddVertex(p6);




            _rasterObjects.Add(TestPolygon);

            constraints = new List<IConstraint>();

            var TestConstraint = new ConstantEdgeLength(TestPolygon, p1,p2, 100);
            var TestConstraint2 = new ConstantEdgeLength(TestPolygon, p2, p3, 100);
            //var TestConstraint3 = new ConstantEdgeLength(TestPolygon, p3, p4, 100);
            //var TestConstraint4 = new ConstantEdgeLength(TestPolygon, p4, p5, 100);
            //var TestConstraint5 = new ConstantEdgeLength(TestPolygon, p5, p1, 100);

            //var TestConstraint4 = new ConstantEdgeLength(TestPolygon, p4, p1, 100);

            //var TestConstraint4 = new ConstantEdgeLength(TestPolygon, p4, p1, 100);

            // var TestConstraint4 = new ConstantEdgeLength(TestPolygon, p4, p1, 200);

            constraints.Add(TestConstraint);
            constraints.Add(TestConstraint2);
            //constraints.Add(TestConstraint3);
            //constraints.Add(TestConstraint4);
            //constraints.Add(TestConstraint5);


            //constraints.Add(TestConstraint4);

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

        private void ButtonRemoveVertex_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new PolygonRemoveVertexHandler(_rasterObjects, DrawingArea);
        }

        private void ButtonMoveVertex_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new MovePolygonVertexHandler(_rasterObjects, DrawingArea, constraints);
        }

        private void MoveSegmentButton_Click(object sender, EventArgs e)
        {
            _activeActionHandler?.Finish();
            _activeActionHandler = new PolgonMoveEdgeHandler(_rasterObjects, DrawingArea);
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

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (var c in constraints)
            {
                {
                    c.EnforceConstraint(null);
                    _pointsApplier.Apply();
                }
            }
        }
    }
}
