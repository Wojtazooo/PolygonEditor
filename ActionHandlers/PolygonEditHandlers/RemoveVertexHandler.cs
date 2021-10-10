using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers.PolygonEditHandlers
{
    class RemoveVertexHandler : PolygonEditGenericHandler
    {
        public RemoveVertexHandler(Polygon polygon) : base(polygon) { }

        public override void HandleMouseClick(MouseEventArgs e)
        {
        }

        public override void HandleMouseMove(MouseEventArgs e)
        {
        }
    }
}
