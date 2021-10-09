using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.ActionHandlers
{
    interface ActionHandler
    {
        void HandleMouseMove(MouseEventArgs e);
        void HandleMouseClick(MouseEventArgs e);
        void Finish();
        void Cancel();
    }
}
