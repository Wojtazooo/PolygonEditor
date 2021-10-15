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

        public void Apply()
        {
            bitmapToApply?.Dispose();
            bitmapToApply = new(_picture.Width, _picture.Height);


            //RectangleF rectf = new RectangleF(70, 90, 90, 50);

            //Graphics g = Graphics.FromImage(bitmapToApply);

            //g.SmoothingMode = SmoothingMode.AntiAlias;
            //g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            //g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            //g.DrawString("yourText", new Font("Tahoma", 12), Brushes.Black, rectf);

            //g.Flush();


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
