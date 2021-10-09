using System.Collections.Generic;

namespace PolygonEditor.RasterGraphics.Models
{
    abstract class RasterObject
    {
        protected List<Pixel> _pixels;
        public List<Pixel> GetPixels() => _pixels;
        abstract public void Update();
    }
}