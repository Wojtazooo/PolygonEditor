using System.Collections.Generic;

namespace PolygonEditor.RasterGraphics.Models
{
    abstract class RasterObject
    {
        protected List<Pixel> _pixels;
        public abstract List<Pixel> GetPixels();
    }
}