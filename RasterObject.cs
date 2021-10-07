using System.Collections.Generic;

namespace PolygonEditor
{
    abstract class RasterObject
    {
        protected List<Pixel> _pixels;
        List<Pixel> GetPixels() => _pixels;
    }
}