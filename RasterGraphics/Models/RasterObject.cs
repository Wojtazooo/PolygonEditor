using System.Collections.Generic;

namespace PolygonEditor.RasterGraphics.Models
{
    public abstract class RasterObject
    {
        protected List<Pixel> _pixels = new List<Pixel>();
        public List<Pixel> GetPixels() => _pixels;
        abstract public void Update();
    }
}