using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
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
                    bitmapToApply.SetPixel(p.X, p.Y, p.Color);
                }
            }
            _picture.Image = bitmapToApply;
        }
    }
}
