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
        private Line testLine;
        private RasterGraphicsApplier pointsApplier;
        private List<RasterObject> testRasterObjects;
        
        public MainForm()
        {
            InitializeComponent();

            testLine = new Line(
                new Point(DrawingArea.Width / 2, DrawingArea.Height / 2), 
                new Point(DrawingArea.Width / 2, DrawingArea.Height / 2), 
                Color.Green
                );
            testRasterObjects = new List<RasterObject>();
            testRasterObjects.Add(testLine);

            pointsApplier = new RasterGraphicsApplier(DrawingArea);
            UpdateView();
        }

        private void UpdateView()
        {
            pointsApplier.Apply(testRasterObjects);
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            testLine.SetP2(new Point(e.X, e.Y));
            UpdateView();
        }

        private void DrawingArea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            testLine.SetP2(new Point(e.X, e.Y));
            UpdateView();
        }
    }
}
