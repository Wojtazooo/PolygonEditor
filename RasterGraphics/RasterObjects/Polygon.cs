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
        public List<MyPoint> Vertices { get; private set; }
        public List<PolygonConstraint> Constraints { get; private set; } = new List<PolygonConstraint>();

        public Polygon(Color color) : base(color)
        {
            Vertices = new List<MyPoint>();
        }

        public Polygon(List<MyPoint> vertices, Color color) : base(color)
        {
            this.Vertices = vertices;
            Update();
        }

        public Polygon(Polygon polygon) : base(polygon.Color)
        {
            Vertices = new List<MyPoint>(polygon.Vertices);
            Update();
        }

        public override void Update()
        {
            var polygonPixels = new List<Pixel>();
            for (int v = 0; v < Vertices.Count; v++)
            {
                polygonPixels.AddRange(LineGenerator.GetPixels(Vertices[v].GetPoint(), Vertices[(v + 1) % Vertices.Count].GetPoint(), Color));
            }
            _pixels = polygonPixels;
        }

        public void AddVertex(MyPoint vertex)
        {
            Vertices.Add(vertex);
            Update();
        }

        public void RemoveVertex(MyPoint vertex)
        {
            for(int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i] == vertex)
                {
                    Constraints.RemoveAll(constraint => constraint.RelatedVertices.Contains(i));
                    Constraints.ForEach(c =>
                    {
                        if(c.RelatedVertices.TrueForAll(v => v > i))
                        {
                            c.RelatedVertices.ForEach(v => v--);
                        }
                    });
                }
            }

            var pointToDelete = Vertices.Find(mp => mp == vertex);
            Vertices.Remove(pointToDelete);
            Update();
        }
        public override MyPoint DetectObject(MyPoint mousePoint, int radius)
        {
            foreach (var v in Vertices)
            {
                if (ExtensionMethods.IsInCircle(mousePoint, v, radius))
                    return v;
            }

            for (int v = 0; v < Vertices.Count; v++)
            {
                MyPoint currentV = Vertices[v];
                MyPoint nextV = Vertices[(v + 1) % Vertices.Count];
                if (ExtensionMethods.IsPointInSegment(mousePoint, currentV, nextV, radius))
                {
                    return mousePoint;
                }
            }
            return null;
        }

        public MyPoint isVertexClicked(MyPoint mousePoint)
        {
            foreach (var v in Vertices)
            {
                if (ExtensionMethods.IsInCircle(mousePoint, v, Constants.DETECTION_RADIUS))
                    return v;
            }
            return null;
        }

        public (MyPoint a, MyPoint b) isEdgeClicked(MyPoint mousePoint)
        {
            for (int v = 0; v < Vertices.Count; v++)
            {
                MyPoint currentV = Vertices[v];
                MyPoint nextV = Vertices[(v + 1) % Vertices.Count];
                if (ExtensionMethods.IsPointInSegment(mousePoint, currentV, nextV, Constants.DETECTION_RADIUS))
                {
                    return (currentV, nextV);
                }
            }
            return (null, null);
        }

        public override void MoveRasterObject(MyPoint from, MyPoint to)
        {
            for(int v = 0; v < Vertices.Count; v++)
            {
                MyPoint newV = ExtensionMethods.MovePoint(Vertices[v], from, to);
                Vertices[v] = newV;
            }
            Update();
        }

        public MyPoint MoveVertex(MyPoint vertex, MyPoint to)
        {
            if (!Vertices.Contains(vertex)) return vertex;

            MyPoint movedPoint = ExtensionMethods.MovePoint(vertex, vertex, to);
            for(int i = 0; i < Vertices.Count; i++)
            {
                if (Vertices[i] == vertex)
                    Vertices[i] = movedPoint;
            }
            Update();
            return movedPoint;
        }

        public (MyPoint, MyPoint) MoveEdge(MyPoint endOfEdge1, MyPoint endOfEdge2, MyPoint from, MyPoint to)
        {
            double dx = to.X - from.X;
            double dy = to.Y - from.Y;
            MyPoint newEdgeEnd1 = new MyPoint(endOfEdge1.X + dx, endOfEdge1.Y + dy);
            MyPoint newEdgeEnd2 = new MyPoint(endOfEdge2.X + dx, endOfEdge2.Y + dy);
            MoveVertex(endOfEdge1, newEdgeEnd1);
            MoveVertex(endOfEdge2, newEdgeEnd2);
            return (newEdgeEnd1, newEdgeEnd2);
        }

        public void AddVertexInsideEdge(MyPoint vertexToAdd)
        {
            (MyPoint a, MyPoint b) = isEdgeClicked(vertexToAdd);
            List<MyPoint> newVertices = new List<MyPoint>();

            if (a != null && b != null)
            {
                for(int v = 0; v < Vertices.Count; v++)
                {
                    newVertices.Add(Vertices[v]);
                    if(Vertices[v] == a)
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

        public override bool RemoveConstraintByClick(MyPoint mousePoint)
        {
            for(int i = 0; i < Constraints.Count; i++)
            {
                MyPoint constraintCenterPoint = new MyPoint(Constraints[i].GetCenterDrawingPoint());
                if (ExtensionMethods.IsInCircle(constraintCenterPoint, mousePoint, Constants.DETECTION_RADIUS))
                {
                    Constraints.Remove(Constraints[i]);
                    return true;
                }
            }
            return false;
        }

        public override bool DetectConstraint(MyPoint mousePoint)
        {
            for(int i = 0; i < Constraints.Count; i++)
            {
                MyPoint constraintCenterPoint = new MyPoint(Constraints[i].GetCenterDrawingPoint());
                if (ExtensionMethods.IsInCircle(constraintCenterPoint, mousePoint, Constants.DETECTION_RADIUS))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
