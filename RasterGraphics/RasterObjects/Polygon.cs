using PolygonEditor.Constraints;
using PolygonEditor.Constraints.PolygonConstraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    public class Polygon : RasterObject
    {
        public List<Point> Vertices { get; private set; }
        public List<PolygonConstraint> Constraints { get; private set; } = new List<PolygonConstraint>();

        public Polygon(Color color) : base(color)
        {
            Vertices = new List<Point>();
        }

        public Polygon(List<Point> vertices, Color color) : base(color)
        {
            this.Vertices = vertices;
            Update();
        }

        public Polygon(Polygon polygon) : base(polygon.Color)
        {
            Vertices = new List<Point>(polygon.Vertices);
            Update();
        }

        public override void Update()
        {
            var polygonPixels = new List<Pixel>();
            for (int v = 0; v < Vertices.Count; v++)
            {
                polygonPixels.AddRange(LineGenerator.GetPixels(Vertices[v], Vertices[(v + 1) % Vertices.Count], Color));
            }
            _pixels = polygonPixels;
        }

        public void AddVertex(Point vertex)
        {
            Vertices.Add(vertex);
            Update();
        }

        public void RemoveVertex(Point vertex)
        {
            for(int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i] == vertex)
                    Constraints.RemoveAll(constraint => constraint.RelatedVertices.Contains(i));
            }
            Vertices.Remove(vertex);
            Update();
        }
        public override Point? DetectObject(Point mousePoint, int radius)
        {
            foreach (var v in Vertices)
            {
                if (ExtensionMethods.IsInCircle(mousePoint, v, radius))
                    return v;
            }

            for (int v = 0; v < Vertices.Count; v++)
            {
                Point currentV = Vertices[v];
                Point nextV = Vertices[(v + 1) % Vertices.Count];
                if (ExtensionMethods.IsPointInSegment(mousePoint, currentV, nextV, radius))
                {
                    return mousePoint;
                }
            }
            return null;
        }

        public Point? isVertexClicked(Point mousePoint)
        {
            foreach (var v in Vertices)
            {
                if (ExtensionMethods.IsInCircle(mousePoint, v, Constants.DETECTION_RADIUS))
                    return v;
            }
            return null;
        }

        public (Point? a, Point? b) isEdgeClicked(Point mousePoint)
        {
            for (int v = 0; v < Vertices.Count; v++)
            {
                Point currentV = Vertices[v];
                Point nextV = Vertices[(v + 1) % Vertices.Count];
                if (ExtensionMethods.IsPointInSegment(mousePoint, currentV, nextV, Constants.DETECTION_RADIUS))
                {
                    return (currentV, nextV);
                }
            }
            return (null, null);
        }

        public override void MovePolygon(Point from, Point to)
        {
            for(int v = 0; v < Vertices.Count; v++)
            {
                Point newV = ExtensionMethods.MovePoint(Vertices[v], from, to);
                Vertices[v] = newV;
            }
            Update();
        }

        public void MoveVertex(Point vertex, Point to)
        {
            if (!Vertices.Contains(vertex)) return;

            Point movedPoint = ExtensionMethods.MovePoint(vertex, vertex, to);
            for(int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i] == vertex)
                    Vertices[i] = movedPoint;
            }
            Update();
        }

        public void MoveEdge(Point endOfEdge1, Point endOfEdge2, Point from, Point to)
        {
            int dx = to.X - from.X;
            int dy = to.Y - from.Y;
            Point newEdgeEnd1 = new Point(endOfEdge1.X + dx, endOfEdge1.Y + dy);
            Point newEdgeEnd2 = new Point(endOfEdge2.X + dx, endOfEdge2.Y + dy);
            MoveVertex(endOfEdge1, newEdgeEnd1);
            MoveVertex(endOfEdge2, newEdgeEnd2);
        }

        public void AddVertexInsideEdge(Point vertexToAdd)
        {
            (Point? a, Point? b) = isEdgeClicked(vertexToAdd);
            List<Point> newVertices = new List<Point>();

            if (a.HasValue && b.HasValue)
            {
                for(int v = 0; v < Vertices.Count; v++)
                {
                    newVertices.Add(Vertices[v]);
                    if(Vertices[v] == a.Value)
                    {
                        newVertices.Add(vertexToAdd);
                        Constraints.RemoveAll(constraint => constraint.RelatedVertices.Contains(v) && constraint.RelatedVertices.Contains(v+1));
                    }
                }
                Vertices = newVertices;
            }
            Update();
        }

        public override RasterObject Clone()
        {
            return new Polygon(this);
        }

        public void AddContraint(PolygonConstraint constraint)
        {
            Constraints.Add(constraint);
        }

        public void RemoveContraint(PolygonConstraint constraint)
        {
            Constraints.Remove(constraint);
        }

        public override void DrawConstraints(Graphics g) 
        {
            foreach(var c in Constraints)
            {
                c.DrawConstraintInfo(g);
            }
        }

        public override bool RemoveConstraintByClick(Point mousePoint)
        {
            for(int i = 0; i < Constraints.Count; i++)
            {
                Point constraintCenterPoint = Constraints[i].GetCenterDrawingPoint();
                if (ExtensionMethods.IsInCircle(constraintCenterPoint, mousePoint, Constants.DETECTION_RADIUS))
                {
                    Constraints.Remove(Constraints[i]);
                    return true;
                }
            }
            return false;
        }

        public override bool DetectConstraint(Point mousePoint)
        {
            for(int i = 0; i < Constraints.Count; i++)
            {
                Point constraintCenterPoint = Constraints[i].GetCenterDrawingPoint();
                if (ExtensionMethods.IsInCircle(constraintCenterPoint, mousePoint, Constants.DETECTION_RADIUS))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
