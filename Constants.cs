using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public static class Constants
    {
        public const int DETECTION_RADIUS = 10;
        public const int REFRESH_TIME_IN_MS = 5;
        public const int CROSS_WIDTH = 20;
        public const int ADD_VERTEX_CIRCLE_RADIUS = 10;
        public static readonly Font CONSTRAINTS_FONT = new Font("Arial", 12);
    }
}
