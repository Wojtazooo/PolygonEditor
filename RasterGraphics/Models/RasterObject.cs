using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Helpers;
using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor.RasterGraphics.Models
{
    public abstract class RasterObject
    {
        protected List<Pixel> _pixels = new List<Pixel>();
        public Color Color { get; protected set; }
        public List<Pixel> GetPixels() => _pixels;
        public RasterObject(Color color) { Color = color; }
        public void SetColor(Color color)
        {
            Color = color;
            Update();
        }
        abstract public void Update();
        abstract public MyPoint DetectObject(MyPoint mousePoint, int radius);
        abstract public void MoveRasterObject(MyPoint from, MyPoint to);
        abstract public RasterObject Clone();
        abstract public void DrawConstraints(Graphics g);
        abstract public bool RemoveConstraintByClick(MyPoint mousePoint);
        abstract public bool DetectConstraint(MyPoint mousePoint);

    }
}