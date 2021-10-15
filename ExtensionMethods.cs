﻿using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor
{
    public static class ExtensionMethods
    {
        public static double PixelDistance(Point p1, Point p2)
        {
            int dx = p1.X - p2.X;
            int dy = p1.Y - p2.Y;
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }

        public static bool IsInCircle(Point point, Point circleCenter, int radius)
        {
            int dx = point.X - circleCenter.X;
            int dy = point.Y - circleCenter.Y;
            return (Math.Pow(dx, 2) + Math.Pow(dy, 2) <= Math.Pow(radius, 2));
        }

        public static double CountDistanceFromCircleCenterToLine(Point circleCenter, Point p1, Point p2)
        {
            if (p1.X == p2.X) 
                return Math.Abs(p1.X - circleCenter.X);

            double a = PixelDistance(p1, p2);
            double b = PixelDistance(p1, circleCenter);
            double c = PixelDistance(p2, circleCenter);

            double p = (a + b + c) / 2;

            double height = Math.Sqrt(p * (p - a) * (p - b) * (p - c))/a;
            return height;
        }

        public static bool IsPointInSegment(Point circleCenter, Point p1, Point p2, int detectionRadius)
        {
            if (p1.X == p2.X) return Math.Abs(p1.X - circleCenter.X) < detectionRadius;

            double a = PixelDistance(p1, p2);
            double b = PixelDistance(p1, circleCenter);
            double c = PixelDistance(p2, circleCenter);

            double p = (a + b + c) / 2;

            double height = Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / a;

            return height <= detectionRadius && a > b && a > c;
        }

        public static Point MovePoint(Point pointToMove, Point mouseFrom, Point mouseTo)
        {
            int dx = mouseTo.X - mouseFrom.X;
            int dy = mouseTo.Y - mouseFrom.Y;
            return new Point(pointToMove.X + dx, pointToMove.Y + dy);
        }

        public static Point MovePointToAchieveLength(Point pointToMove, Point seceondPoint, int length)
        {
            double c = ExtensionMethods.PixelDistance(pointToMove, seceondPoint);

            double lengthDiff = c - length;
            int dx = seceondPoint.X - pointToMove.X;
            int dy = seceondPoint.Y - pointToMove.Y;

            double p = (c - length) / c;

            return new Point((int)(pointToMove.X + p * dx), (int)(pointToMove.Y + p * dy));

        }

        //public static void ApplyConstraints(List<IConstraint> constraints, List<Point> lockedPoints)
        //{
        //    foreach (var c in constraints)
        //    {
        //        c.EnforceConstraint(lockedPoints);
        //    }
        //}

        public static int GetVertexNumberFromPoint(Polygon polygon, Point vertexPoint)
        {
            for(int i = 0; i < polygon.Vertices.Count; i++)
            {
                if (polygon.Vertices[i] == vertexPoint) return i;
            }
            return 0;
        }

    }
}
