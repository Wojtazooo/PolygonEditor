using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    class Polygon : RasterObject
    {
        public List<Point> Vertices { get; private set; }
        
        public Polygon(Color color): base(color)
        {
            Vertices = new List<Point>();
        }

        public Polygon(List<Point> vertices, Color color): base(color)
        {
            this.Vertices = vertices;
            Update();
        }

        public Polygon(Polygon polygon): base(polygon.Color)
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
                polygonPixels.AddRange(CircleGenerator.GetPixels(Vertices[v], Constants.DETECTION_RADIUS, Color));
            }
            _pixels = polygonPixels;
        }

        public void AddVertex(Point vertex)
        {
            Vertices.Add(vertex);
            Update();
        }

        public override Point? DetectObject(Point mousePoint, int radius)
        {
            foreach (var v in Vertices)
            {
                if (ExtensionMethods.IsInCircle(mousePoint, v, Constants.DETECTION_RADIUS))
                    return v;
            }

            for (int v = 0; v < Vertices.Count; v++)
            {
                Point currentV = Vertices[v];
                Point nextV = Vertices[(v + 1) % Vertices.Count];
                if (ExtensionMethods.IsPointInSegment(mousePoint, currentV, nextV, Constants.DETECTION_RADIUS))
                {
                    return mousePoint;
                }
            }
            return null;
        }

        public override void Move(Point from, Point to)
        {
            for(int v = 0; v < Vertices.Count; v++)
            {
                Point newV = ExtensionMethods.MovePoint(Vertices[v], from, to);
                Vertices[v] = newV;
            }
            Update();
        }

        public override RasterObject Clone()
        {
            return new Polygon(this);
        }
    }
}
