using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    class Cross : RasterObject
    {
        public MyPoint Center { get; private set; }
        public int Width { get; private set; }
        public Cross(MyPoint center, int width, Color color): base(color)
        {
            Center = center;
            Width = width;
            Update();
        }
        public override MyPoint DetectObject(MyPoint mousePoint, int radius)
        {
            if (ExtensionMethods.IsInCircle(mousePoint, Center, radius))
                return Center;
            return null;
        }

        public override void Update()
        {
            var firstLine = LineGenerator.GetPixels(
                new MyPoint(Center.X - Width / 2, Center.Y + Width / 2).GetPoint(),
                new MyPoint(Center.X + Width / 2, Center.Y - Width / 2).GetPoint(),
                Color);
            var secondLine = LineGenerator.GetPixels(
               new MyPoint(Center.X - Width / 2, Center.Y - Width / 2).GetPoint(),
               new MyPoint(Center.X + Width / 2, Center.Y + Width / 2).GetPoint(),
               Color);

            _pixels.AddRange(firstLine);
            _pixels.AddRange(secondLine);
        }

        public override void MoveRasterObject(MyPoint from, MyPoint to)
        {
            MyPoint movedCenter = ExtensionMethods.MovePoint(Center, from, to);
            Center = movedCenter;
            Update();
        }

        public override RasterObject Clone()
        {
            return new Cross(Center, Width, Color);
        }

        public override void DrawConstraints(Graphics g)
        {
        }

        public override bool RemoveConstraintByClick(MyPoint mousePoint)
        {
            return false;
        }

        public override bool DetectConstraint(MyPoint mousePoint)
        {
            return false;
        }
    }
}
