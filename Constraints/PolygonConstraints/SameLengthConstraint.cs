﻿using PolygonEditor.RasterGraphics.Helpers;
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
        public SameLengthConstraint(Polygon polygon, List<Point> relatedPoints) : base(polygon) 
        {
            foreach(var i in relatedPoints)
            {
                RelatedVertices.Add(_polygon.Vertices.IndexOf(i));
            }
            _polygon.AddContraint(this);
        }

        public override void DrawConstraintInfo(Graphics g)
        {
            GraphicsApplier.ApplyString(g, "same length", GetCenterPointFirstEdge());
            GraphicsApplier.ApplyString(g, "same length", GetCenterPointSecondEdge());

        }

        public override void EnforceConstraint(Point constantPoint)
        {
            (Point v1, Point v2) = (_polygon.Vertices[RelatedVertices[0]], _polygon.Vertices[RelatedVertices[1]]);
            (Point w1, Point w2) = (_polygon.Vertices[RelatedVertices[2]], _polygon.Vertices[RelatedVertices[3]]);

            if(v1 == constantPoint || v2 == constantPoint)
            {
                int length = (int)ExtensionMethods.PixelDistance(v1, v2);
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(w1,w2,length);
                _polygon.MoveVertex(w1, movedPoint);
            }
            else
            {
                int length = (int)ExtensionMethods.PixelDistance(w1, w2);
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(v1, v2, length);
                _polygon.MoveVertex(v1, movedPoint);
            }
        }

        public override Point GetCenterDrawingPoint()
        {
            return GetCenterPointFirstEdge();
        }

        private Point GetCenterPointFirstEdge()
        {
            Point v1 = _polygon.Vertices[RelatedVertices[0]];
            Point v2 = _polygon.Vertices[RelatedVertices[1]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }

        private Point GetCenterPointSecondEdge()
        {
            Point v1 = _polygon.Vertices[RelatedVertices[2]];
            Point v2 = _polygon.Vertices[RelatedVertices[3]];
            return ExtensionMethods.CountMiddleOfSegment(v1, v2);
        }
    }
}
