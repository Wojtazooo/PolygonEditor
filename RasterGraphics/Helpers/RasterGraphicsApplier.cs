using PolygonEditor.RasterGraphics.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace PolygonEditor.RasterGraphics.Helpers
{
    class RasterGraphicsApplier
    {
        private PictureBox _picture;
        public RasterGraphicsApplier(PictureBox picture)
        {
            _picture = picture;
        }

        public void Apply(List<RasterObject> rasterObjects)
        {
            Bitmap bitmapToApply = new(_picture.Width, _picture.Height);

            foreach(var o in rasterObjects)
            {
                foreach(var p in o.GetPixels())
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
