using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints.PolygonConstraints
{
    class SameLengthConstraint : PolygonConstraint
    {
        public SameLengthConstraint(Polygon polygon, List<MyPoint> relatedMyPoints) : base(polygon) 
        {
            foreach(var i in relatedMyPoints)
            {
                RelatedVertices.Add(_polygon.Vertices.IndexOf(i));
            }
            _polygon.AddContraint(this);
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            GraphicsApplier.ApplyString(g, "same length", GetCenterMyPointFirstEdge());
            GraphicsApplier.ApplyString(g, "same length", GetCenterMyPointSecondEdge());

        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            (MyPoint v1, MyPoint v2) = (_polygon.Vertices[RelatedVertices[0]], _polygon.Vertices[RelatedVertices[1]]);
            (MyPoint w1, MyPoint w2) = (_polygon.Vertices[RelatedVertices[2]], _polygon.Vertices[RelatedVertices[3]]);

            if(v1 == constantMyPoint || v2 == constantMyPoint)
            {
                int length = (int)ExtensionMethods.PixelDistance(v1, v2);
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(w1,w2,length);
                _polygon.MoveVertex(w1, movedMyPoint);
            }
            else
            {
                int length = (int)ExtensionMethods.PixelDistance(w1, w2);
                MyPoint movedMyPoint = ExtensionMethods.MovePointToAchieveLength(v1, v2, length);
                _polygon.MoveVertex(v1, movedMyPoint);
            }
        }

        public override MyPoint GetCenterDrawingPoint()
        {
            return GetCenterMyPointFirstEdge();
        }

        private MyPoint GetCenterMyPointFirstEdge()
        {
            MyPoint v1 = _polygon.Vertices[RelatedVertices[0]];
            MyPoint v2 = _polygon.Vertices[RelatedVertices[1]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }

        private MyPoint GetCenterMyPointSecondEdge()
        {
            MyPoint v1 = _polygon.Vertices[RelatedVertices[2]];
            MyPoint v2 = _polygon.Vertices[RelatedVertices[3]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }
    }
}
