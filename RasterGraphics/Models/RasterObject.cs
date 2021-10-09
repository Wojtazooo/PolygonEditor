using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor.RasterGraphics.Models
{
    public abstract class RasterObject
    {
        protected List<Pixel> _pixels = new List<Pixel>();
        public List<Pixel> GetPixels() => _pixels;
        abstract public void Update();
        abstract public Point? DetectObject(Point mousePoint, int radius);
    }
}