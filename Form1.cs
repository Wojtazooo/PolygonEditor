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
        private Circle testCircle;
        
        public MainForm()
        {
            InitializeComponent();
            pointsApplier = new RasterGraphicsApplier(DrawingArea);
            rasterObjects = new List<RasterObject>();


            var middleX = DrawingArea.Width / 2;
            var middleY = DrawingArea.Height / 2;

            //var l1 = new Line(
            //    new Point(middleX - 300, middleY),
            //    new Point(middleX + 300, middleY),
            //    Color.Gray
            //    );
            //var l2 = new Line(
            //    new Point(middleX, middleY - 300),
            //    new Point(middleX, middleY + 300),
            //    Color.Gray
            //    );

            //int RDividedBySqrt2 = (int)(300 / Math.Sqrt(2));

            //var l3 = new Line(
            //   new Point(middleX - RDividedBySqrt2, middleY + RDividedBySqrt2),
            //   new Point(middleX + RDividedBySqrt2, middleY - RDividedBySqrt2),
            //   Color.Gray
            //   );

            //var l4 = new Line(
            //  new Point(middleX + RDividedBySqrt2, middleY + RDividedBySqrt2),
            //  new Point(middleX - RDividedBySqrt2, middleY - RDividedBySqrt2),
            //  Color.Gray
            //  );

            testCircle = new Circle(new Point(DrawingArea.Width/2 - 200, DrawingArea.Height/2), 300, Color.Black);
            rasterObjects.Add(testCircle);
            //rasterObjects.Add(l1);
            //rasterObjects.Add(l2);
            //rasterObjects.Add(l3);
            //rasterObjects.Add(l4);


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
