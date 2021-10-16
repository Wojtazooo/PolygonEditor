using PolygonEditor.RasterGraphics.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PolygonEditor.RasterGraphics.Helpers
{
    class RasterGraphicsApplier
    {
        private PictureBox _picture;
        private Bitmap bitmapToApply;
        private List<RasterObject> _rasterObjects;
        public RasterGraphicsApplier(PictureBox picture, List<RasterObject> rasterObjects)
        {
            _picture = picture;
            _rasterObjects = rasterObjects;
        }

        private void ApplyConstraintsInfo(Bitmap bitmapToApply)
        {
            Graphics g = Graphics.FromImage(bitmapToApply);
            foreach (var ro in _rasterObjects)
            {
                ro.DrawConstraints(g);
            }
            g.Flush();
            g.Dispose();
        }

        public void Apply()
        {
            bitmapToApply?.Dispose();
            bitmapToApply = new(_picture.Width, _picture.Height);
            ApplyConstraintsInfo(bitmapToApply);

            foreach (var o in _rasterObjects)
            {
                foreach (var p in o.GetPixels())
                {
                    if (p.X >= 0 && p.X < bitmapToApply.Width && p.Y >= 0 && p.Y < bitmapToApply.Height)
                    {
                        bitmapToApply.SetPixel(p.X, p.Y, p.Color);
                    }
                }
            }
            _picture.Image = bitmapToApply;
        }
    }
}
