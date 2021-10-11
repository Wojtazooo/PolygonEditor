using PolygonEditor.ActionHandlers;
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
        private RasterGraphicsApplier pointsApplier;
        private List<RasterObject> rasterObjects;
        private ActionHandler activeActionHandler;
        private Timer _timer;
        
        public MainForm()
        {
            InitializeComponent();
            rasterObjects = new List<RasterObject>();
            pointsApplier = new RasterGraphicsApplier(DrawingArea, rasterObjects);
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
            pointsApplier.Apply();
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            activeActionHandler?.HandleMouseMove(mouseEventArgs);
        }

        private void ButtonAddPolygon_Click(object sender, System.EventArgs e)
        {
            activeActionHandler?.Finish();
            activeActionHandler = new AddPolygonHandler(rasterObjects, textBoxHelper, PictureBoxSelectedColor.BackColor, DrawingArea);
        }

        private void ButtonPickColor_Click(object sender, System.EventArgs e)
        {
            activeActionHandler?.Finish();
            activeActionHandler = null;
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = PictureBoxSelectedColor.BackColor;

            if (colorDialog.ShowDialog() == DialogResult.OK)
                PictureBoxSelectedColor.BackColor = colorDialog.Color;
        }

        private void DrawingArea_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                activeActionHandler?.HandleMouseClick(e);
            else if (e.Button == MouseButtons.Right)
            {
                activeActionHandler?.Submit();
            }
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (activeActionHandler != null && activeActionHandler.HandleKeybordKeyClick(e)) return;
            
            if (e.KeyCode == Keys.Escape)
            {
                activeActionHandler?.Cancel();
                activeActionHandler = null;
            }
            if(e.KeyCode == Keys.Delete)
            {
                ButtonDeleteObject_Click(null,null);
            }
            else if(e.KeyCode == Keys.E)
            {
                ButtonEditObject_Click(null,null);
            }
        }

        private void ButtonDeleteObject_Click(object sender, EventArgs e)
        {
            activeActionHandler?.Finish();
            activeActionHandler = new RemoveRasterObjectHandler(rasterObjects, textBoxHelper, DrawingArea);
        }

        private void ShowWhereDetectionWorks()
        {
            for (int i = 0; i < DrawingArea.Width; i++)
            {
                for (int j = 0; j < DrawingArea.Height; j++)
                {
                    Point p = new Point(i, j);
                    if (rasterObjects[0].DetectObject(p, Constants.DETECTION_RADIUS) != null)
                    {
                        rasterObjects.Add(new Pixel(p, Color.Red));
                    }
                }
            }
        }

        private void ButtonEditObject_Click(object sender, EventArgs e)
        {
            activeActionHandler?.Finish();
            activeActionHandler = new EditPolygonHandler(rasterObjects, textBoxHelper, DrawingArea);
        }
 		private void ButtonMoveObject_Click(object sender, EventArgs e)
        {
            activeActionHandler?.Finish();
            activeActionHandler = new MoveRasterObjectHandler(rasterObjects, DrawingArea); 
        }

        private void ButtonAddCircle_Click(object sender, EventArgs e)
        {
            activeActionHandler?.Finish();
            activeActionHandler = new AddCircleHandler(rasterObjects, textBoxHelper, PictureBoxSelectedColor.BackColor, DrawingArea);
        }
    }
}
