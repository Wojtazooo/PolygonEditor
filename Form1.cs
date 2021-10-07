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
        public MainForm()
        {
            InitializeComponent();

            Line line1 = new Line(new Point(100, 100), new Point(150, 100), Color.Black);
            Line line2 = new Line(new Point(100, 200), new Point(200, 200), Color.Black);
            Line line3 = new Line(new Point(100, 300), new Point(250, 400), Color.Black);
            Line line4 = new Line(new Point(100, 400), new Point(300, 400), Color.Black);

            List<RasterObject> rasterObjects = new List<RasterObject>();
            rasterObjects.Add(line1);
            rasterObjects.Add(line2);
            rasterObjects.Add(line3);
            rasterObjects.Add(line4);

            RasterGraphicsApplier pointsApplier = new RasterGraphicsApplier(DrawingArea);
            pointsApplier.Apply(rasterObjects);
        }

    }
}
