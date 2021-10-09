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
        public Color Color { get; private set; }
        public int VertexRadius = 5;

        public Polygon(Color color)
        {
            Vertices = new List<Point>();
            Color = color;
        }

        public Polygon(List<Point> vertices, Color color)
        {
            this.Vertices = vertices;
            Color = color;
            Update();
        }

        public override void Update()
        {
            var polygonPixels = new List<Pixel>();
            for (int v = 0; v < Vertices.Count; v++)
            {
                polygonPixels.AddRange(LineGenerator.GetPixels(Vertices[v], Vertices[(v + 1) % Vertices.Count], Color));
                polygonPixels.AddRange(CircleGenerator.GetPixels(Vertices[v], VertexRadius, Color));
            }
            _pixels = polygonPixels;
        }

        public void AddVertex(Point vertex)
        {
            Vertices.Add(vertex);
            Update();
        }

        public void SetColor(Color color)
        {
            Color = color;
            Update();
        }
    }
}
