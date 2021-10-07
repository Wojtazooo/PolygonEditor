using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            testLine = new Line(new Point(DrawingArea.Width/2, DrawingArea.Height/2), new Point(DrawingArea.Width / 2, DrawingArea.Height / 2), Color.Black);
            testRasterObjects = new List<RasterObject>();
            testRasterObjects.Add(testLine);

            pointsApplier = new RasterGraphicsApplier(DrawingArea);
            UpdateView();
        }

        private void UpdateView()
        {
            pointsApplier.Apply(testRasterObjects);
        }

        private void DrawingArea_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            testLine.SetP2(new Point(e.X, e.Y));
            UpdateView();
        }
    }
}
