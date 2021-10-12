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
        public Point Center { get; private set; }
        public int Width { get; private set; }
        public Cross(Point center, int width, Color color): base(color)
        {
            Center = center;
            Width = width;
            Update();
        }
        public override Point? DetectObject(Point mousePoint, int radius)
        {
            if (ExtensionMethods.IsInCircle(mousePoint, Center, radius))
                return Center;
            return null;
        }

        public override void Update()
        {
            var firstLine = LineGenerator.GetPixels(
                new Point(Center.X - Width / 2, Center.Y + Width / 2),
                new Point(Center.X + Width / 2, Center.Y - Width / 2),
                Color);
            var secondLine = LineGenerator.GetPixels(
               new Point(Center.X - Width / 2, Center.Y - Width / 2),
               new Point(Center.X + Width / 2, Center.Y + Width / 2),
               Color);

            _pixels.AddRange(firstLine);
            _pixels.AddRange(secondLine);
        }

        public override void MovePolygon(Point from, Point to)
        {
            Point movedCenter = ExtensionMethods.MovePoint(Center, from, to);
            Center = movedCenter;
            Update();
        }

        public override RasterObject Clone()
        {
            return new Cross(Center, Width, Color);
        }
    }
}
