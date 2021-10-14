using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints
{
    public interface IConstraint
    {
        public bool Check();
        public void EnforceConstraint(List<Point> constantPoints);
    }

    public abstract class PolygonConstraint : IConstraint
    {
        protected Polygon _polygon;

        public PolygonConstraint(Polygon polygon)
        {
            _polygon = polygon;
        }
        public abstract bool Check();
        public abstract void EnforceConstraint(List<Point> constantPoints);
    }

    public class ConstantEdgeLength : PolygonConstraint
    {
        private (int,int) _edgeVerticesNumbers;
        private int _constantLength;

        public ConstantEdgeLength(Polygon polygon, Point v1, Point v2, int constantLength): base(polygon)
        {
            int numberOfV1 = 0;
            int numberOfV2 = 0;
            for(int i = 0; i < polygon.Vertices.Count; i++)
            {
                if(polygon.Vertices[i] == v1)
                {
                    numberOfV1 = i;
                }
                else if(polygon.Vertices[i] == v2)
                {
                    numberOfV2 = i;
                }
            }
            _edgeVerticesNumbers = (numberOfV1, numberOfV2);
            _constantLength = constantLength;
        }

        public override bool Check()
        {
            Point p1 = _polygon.Vertices[_edgeVerticesNumbers.Item1];
            Point p2 = _polygon.Vertices[_edgeVerticesNumbers.Item2];
            return (int)ExtensionMethods.PixelDistance(p1, p2) == _constantLength;
        }

        public override void EnforceConstraint(List<Point> constantPoints)
        {
            (Point, Point) _edgePoints = (_polygon.Vertices[_edgeVerticesNumbers.Item1], _polygon.Vertices[_edgeVerticesNumbers.Item2]);

            if(constantPoints?.Contains(_edgePoints.Item1) == true)
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(_edgePoints.Item2, _edgePoints.Item1, _constantLength);
                _polygon.MoveVertex(_edgePoints.Item2, movedPoint);
            }
            else
            {
                Point movedPoint = ExtensionMethods.MovePointToAchieveLength(_edgePoints.Item1, _edgePoints.Item2, _constantLength);
                _polygon.MoveVertex(_edgePoints.Item1, movedPoint);
            }

        }
    }
}
