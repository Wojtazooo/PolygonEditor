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
        
        private static int _constraintCounter = 0;
        public int Id { get; private set; }

        public (int a, int b) SecondEdge;
        
        public SameLengthConstraint(Polygon polygon, List<MyPoint> relatedMyPoints) : base(polygon) 
        {
            _constraintCounter++;
            Id = _constraintCounter;
            RelatedVertices.a = _polygon.Vertices.IndexOf(relatedMyPoints[0]);
            RelatedVertices.b = _polygon.Vertices.IndexOf(relatedMyPoints[1]);
            SecondEdge.a = _polygon.Vertices.IndexOf(relatedMyPoints[2]);
            SecondEdge.b = _polygon.Vertices.IndexOf(relatedMyPoints[3]);
            _polygon.AddContraint(this);
            MoreThanOneEdge = true;
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            GraphicsApplier.ApplyString(g, $"== {Id}", GetCenterMyPointFirstEdge());
            GraphicsApplier.ApplyString(g, $"== {Id}", GetCenterMyPointSecondEdge());
        }

        public override void EnforceConstraint(MyPoint constantMyPoint)
        {
            (MyPoint v1, MyPoint v2) = (_polygon.Vertices[RelatedVertices.a], _polygon.Vertices[RelatedVertices.b]);
            (MyPoint w1, MyPoint w2) = (_polygon.Vertices[SecondEdge.a], _polygon.Vertices[SecondEdge.b]);

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
            MyPoint v1 = _polygon.Vertices[RelatedVertices.a];
            MyPoint v2 = _polygon.Vertices[RelatedVertices.b];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }

        private MyPoint GetCenterMyPointSecondEdge()
        {
            MyPoint v1 = _polygon.Vertices[SecondEdge.a];
            MyPoint v2 = _polygon.Vertices[SecondEdge.b];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }
    }
}
