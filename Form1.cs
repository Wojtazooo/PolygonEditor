using PolygonEditor.ActionHandlers;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
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
        
        public MainForm()
        {
            InitializeComponent();
            pointsApplier = new RasterGraphicsApplier(DrawingArea);
            rasterObjects = new List<RasterObject>();
            InitializeSelectedColor();
            UpdateView();
        }

        public void InitializeSelectedColor()
        {
            PictureBoxSelectedColor.BackColor = Color.Black;
        }

        private void UpdateView()
        {
            pointsApplier.Apply(rasterObjects);
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs mouseEventArgs)
        {
            activeActionHandler?.HandleMouseMove(mouseEventArgs);
            UpdateView();
        }

        private void ButtonAddPolygon_Click(object sender, System.EventArgs e)
        {
            activeActionHandler?.Cancel();
            activeActionHandler = new AddPolygonHandler(rasterObjects, textBoxHelper, PictureBoxSelectedColor.BackColor);
            UpdateView();
        }

        private void ButtonPickColor_Click(object sender, System.EventArgs e)
        {
            activeActionHandler?.Cancel();
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
                activeActionHandler?.Finish();
                activeActionHandler = null;
            }
            UpdateView();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Escape)
            {
                activeActionHandler?.Cancel();
                activeActionHandler = null;
            }
            UpdateView();
        }
    }
}
