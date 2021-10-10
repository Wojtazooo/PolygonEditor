using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor.RasterGraphics.Models
{
    public class Pixel : RasterObject
    {
        public int X;
        public int Y;
        public Color Color;

        public Pixel(int x, int y, Color color)
        {
            _pixels.Add(this);
            this.X = x;
            this.Y = y;
            this.Color = color;
        }

        public Pixel(Point p, Color color)
        {
            _pixels.Add(this);
            this.X = p.X;
            this.Y = p.Y;
            this.Color = color;
        }

        public Pixel GetSymetricPixelByX(int x)
        {
            int symetricX = 2 * x - X;
            return new Pixel(symetricX, Y, Color);
        }

        public Pixel GetSymetricPixelByY(int y)
        {
            int symetricY = 2 * y - Y;
            return new Pixel(X, symetricY, Color);
        }

        public static List<Pixel> GetPixelsSymetricByX(List<Pixel> pixels, int x)
        {
            List<Pixel> xSymetricPixels = new List<Pixel>();
            foreach (var p in pixels)
                xSymetricPixels.Add(p.GetSymetricPixelByX(x));
            return xSymetricPixels;
        }
        public static List<Pixel> GetPixelsSymetricByY(List<Pixel> pixels, int y)
        {
            List<Pixel> ySymetricPixels = new List<Pixel>();
            foreach (var p in pixels)
                ySymetricPixels.Add(p.GetSymetricPixelByY(y));
            return ySymetricPixels;
        }

        public override void Update()
        {
            return;
        }

        public override Point? DetectObject(Point mousePoint, int radius)
        {
            Point thisPoint = new Point(X, Y);
            if (ExtensionMethods.IsInCircle(thisPoint, mousePoint, radius))
                return thisPoint;
            return null;
        }
    }
}
