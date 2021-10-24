using PolygonEditor.RasterGraphics.Models;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PolygonEditor.ActionHandlers.ConstraintsActionHandlers.CircleConstraintsHandlers;
using PolygonEditor.Constraints;
using PolygonEditor.Constraints.CircleConstraints;
using PolygonEditor.Constraints.PolygonConstraints;
using PolygonEditor.RasterGraphics.RasterObjects;

namespace PolygonEditor.RasterGraphics.Helpers
{
    public static class SampleScene
    {
        public static void GenerateScene(List<RasterObject> rasterObjects)
        {
            AddPolygonWithSameLength(rasterObjects);
            AddSquare(rasterObjects);
            AddSquareWithConstantCenter(rasterObjects);
            AddTriangleWithSameLength(rasterObjects);
            AddSimpleCircle(rasterObjects);
        }

        private static void AddPolygonWithSameLength(List<RasterObject> rasterObjects)
        {
            var p1 = new MyPoint(300, 700);
            var p2 = new MyPoint(700, 700);
            var p3 = new MyPoint(600, 900);
            var p4 = new MyPoint(200, 900);
            var p5 = new MyPoint(100, 500);

            var polygon = new Polygon(new List<MyPoint> {p1, p2, p3, p4, p5}, Color.Blue);

            var relatedMyPoint = new List<MyPoint>
            {
                p1,
                p2,
                p2,
                p3
            };
            var relatedMyPoint2 = new List<MyPoint>
            {
                p2,
                p3,
                p1,
                p2
            };
            var constraint1 = new SameLengthConstraint(polygon, relatedMyPoint);
            var constraint2 = new SameLengthConstraint(polygon, relatedMyPoint2, false);
            constraint1.AddRelatedConstraint(constraint2);
            constraint2.AddRelatedConstraint(constraint1);

            var relatedMyPoint3 = new List<MyPoint>
            {
                p3,
                p4,
                p4,
                p5
            };
            var relatedMyPoint4 = new List<MyPoint>
            {
                p4,
                p5,
                p3,
                p4
            };
            var constraint3 = new RightAngleConstraint(polygon, relatedMyPoint3);
            var constraint4 = new RightAngleConstraint(polygon, relatedMyPoint4, false);
            constraint3.AddRelatedConstraint(constraint4);
            constraint4.AddRelatedConstraint(constraint3);


            Circle tangentCircle = new Circle(new MyPoint(300, 300), 100, Color.Black);
            _ = new CircleTangentToPolygonConstraint(tangentCircle, polygon, polygon.Vertices.IndexOf(p5),
                polygon.Vertices.IndexOf(p1));

            rasterObjects.Add(polygon);
            rasterObjects.Add(tangentCircle);
            ConstraintsEnforcer.EnforcePolygonConstraints(polygon, polygon.Vertices.IndexOf(p1));
            ConstraintsEnforcer.EnforceCircleConstraint(tangentCircle);
            _ = new ConstantCenterConstraint(tangentCircle, tangentCircle.Center);
            ConstraintsEnforcer.EnforceCircleConstraint(tangentCircle);
        }

        private static void AddSquare(List<RasterObject> rasterObjects)
        {
            var p1 = new MyPoint(300, 100);
            var p2 = new MyPoint(600, 100);
            var p3 = new MyPoint(600, 400);
            var p4 = new MyPoint(300, 400);
            var square = new Polygon(new List<MyPoint> {p1, p2, p3, p4}, Color.DarkGreen);



            _ = new ConstantEdgeLengthConstraint(square, p1, p2, 300);
            _ = new ConstantEdgeLengthConstraint(square, p2, p3, 300);
            _ = new ConstantEdgeLengthConstraint(square, p3, p4, 300);
            _ = new ConstantEdgeLengthConstraint(square, p1, p4, 300);

            
            rasterObjects.Add(square);
        }

        private static void AddSquareWithConstantCenter(List<RasterObject> rasterObjects)
        {
            Circle c1 = new Circle(new MyPoint(900, 300), 150, Color.LawnGreen);
            _ = new ConstantRadiusConstraint(c1, 150);
            rasterObjects.Add(c1);
        }
        
        private static void AddTriangleWithSameLength(List<RasterObject> rasterObjects)
        {
            var p1 = new MyPoint(800, 550);
            var p2 = new MyPoint(1000, 550);
            var p3 = new MyPoint(900, 800);

            var triangle = new Polygon(new List<MyPoint> {p1, p2, p3}, Color.DarkMagenta);
            
            var relatedMyPoint = new List<MyPoint>
            {
                p2,
                p3,
                p3,
                p1
            };
            var relatedMyPoint2 = new List<MyPoint>
            {
                p3,
                p1,
                p2,
                p3
            };
            var constraint1 = new SameLengthConstraint(triangle, relatedMyPoint);
            var constraint2 = new SameLengthConstraint(triangle, relatedMyPoint2, false);
            constraint1.AddRelatedConstraint(constraint2);
            constraint2.AddRelatedConstraint(constraint1);

            Circle tangentCircle = new Circle(new MyPoint(200,200), 50, Color.Black);

            _ = new CircleTangentToPolygonConstraint(tangentCircle, triangle, 0, 1);
            
            ConstraintsEnforcer.EnforceCircleConstraint(tangentCircle);
            
            rasterObjects.Add(tangentCircle);
            rasterObjects.Add(triangle);
        }

        private static void AddSimpleCircle(List<RasterObject> rasterObjects)
        {
            Circle tangentCircle = new Circle(new MyPoint(600,560), 70, Color.Black);
            rasterObjects.Add(tangentCircle);
        }
        
    }
}