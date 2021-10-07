using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    class Line : RasterObject
    {
        public Point P1 
        {
            get => P1;
            set { P1 = value; Update(); }
        }
        public Point P2
        {
            get => P2;
            set { P2 = value; Update(); }
        }
        public Color Color
        {
            get => Color;
            set { Color = value; Update(); }
        }

        void Update()
        {
            // TODO: Implement Udpating method which will Generate line from RasterGraphicGenerator
            // _pixels = GenerateLine(p1,p2,color)
        }
    }
}
