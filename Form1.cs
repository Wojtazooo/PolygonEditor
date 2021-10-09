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
        private Line testLine2;
        private Polygon testPolygon;
        private RasterGraphicsApplier pointsApplier;
        private List<RasterObject> testRasterObjects;
        
        public MainForm()
        {
            InitializeComponent();
            pointsApplier = new RasterGraphicsApplier(DrawingArea);
            GenerateRasterObjects();
            UpdateView();
        }

        public void GenerateRasterObjects()
        {
            testLine = new Line(
              new Point(0, 0),
              new Point(0, 0),
              Color.Gray
              );
            testLine2 = new Line(
              new Point(0, 0),
              new Point(0, 0),
              Color.Gray
              );

            var polygonPoints = new List<Point>();
            testPolygon = new Polygon(polygonPoints, Color.Blue);

            testRasterObjects = new List<RasterObject>();
            testRasterObjects.Add(testLine);
            testRasterObjects.Add(testLine2);
            testRasterObjects.Add(testPolygon);
        }

        private void UpdateView()
        {
            pointsApplier.Apply(testRasterObjects);
        }

        private void DrawingArea_MouseMove(object sender, MouseEventArgs e)
        {
            if (testPolygon.Vertices.Count > 0)
                testLine2.SetP1(testPolygon.Vertices[0]);
            testLine.SetP2(new Point(e.X, e.Y));
            testLine2.SetP2(new Point(e.X, e.Y));

            UpdateView();
        }

        private void DrawingArea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var mousePoint = new Point(e.X, e.Y);
            testLine.SetP1(testLine.P2);
            testLine.SetP2(new Point(e.X, e.Y));
            testPolygon.AddVertex(mousePoint);
            UpdateView();
        }
    }
}
