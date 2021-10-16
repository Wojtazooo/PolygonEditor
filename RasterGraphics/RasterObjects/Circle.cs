using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    public class Circle : RasterObject
    {
        public Point Center { get; private set; }
        public int Radius { get; private set; }

        public Circle(Point center, int radius, Color color): base(color)
        {
            Center = center;
            Radius = radius;
            Update();
        }

        public override void Update()
        {
            _pixels = CircleGenerator.GetPixels(Center,Radius,Color);
        }

        public void SetRadius(int newRadius)
        {
            Radius = newRadius;
            Update();
        }

        public void SetCenter(Point center)
        {
            Center = center;
            Update();
        }

        public override Point? DetectObject(Point mousePoint, int radius)
        {
            if (ExtensionMethods.IsInCircle(mousePoint, Center, radius))
                return Center;
            int mouseCenterDist = (int)ExtensionMethods.PixelDistance(mousePoint, Center);
            if (mouseCenterDist <= Radius + radius && mouseCenterDist >= Radius - radius)
                return mousePoint;
            return null;
        }

        public override void MovePolygon(Point from, Point to)
        {
            Point newCenter = ExtensionMethods.MovePoint(Center, from, to);
            this.SetCenter(newCenter);
        }

        public override RasterObject Clone()
        {
            return new Circle(Center, Radius, Color);
        }

        public override void DrawConstraints(Graphics g)
        {
        }

        public override bool RemoveConstraintByClick(Point mousePoint)
        {
            return false;
        }

        public override bool DetectConstraint(Point mousePoint)
        {
            return false;
        }

    }
}
