using PolygonEditor.Constraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor
{
    public static class ExtensionMethods
    {
        public static double PixelDistance(MyPoint p1, MyPoint p2)
        {
            double dx = p1.X - p2.X;
            double dy = p1.Y - p2.Y;
            return Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));
        }

        public static bool IsInCircle(MyPoint point, MyPoint circleCenter, double radius)
        {
            double dx = point.X - circleCenter.X;
            double dy = point.Y - circleCenter.Y;
            return (Math.Pow(dx, 2) + Math.Pow(dy, 2) <= Math.Pow(radius, 2));
        }

        public static double CountDistanceFromCircleCenterToLine(MyPoint circleCenter, MyPoint p1, MyPoint p2)
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

        public static bool IsPointInSegment(MyPoint circleCenter, MyPoint p1, MyPoint p2, int detectionRadius)
        {
            if (p1.X == p2.X) return Math.Abs(p1.X - circleCenter.X) < detectionRadius;

            double a = PixelDistance(p1, p2);
            double b = PixelDistance(p1, circleCenter);
            double c = PixelDistance(p2, circleCenter);

            double p = (a + b + c) / 2;

            double height = Math.Sqrt(p * (p - a) * (p - b) * (p - c)) / a;

            return height <= detectionRadius && a > b && a > c;
        }

        public static MyPoint MovePoint(MyPoint pointToMove, MyPoint mouseFrom, MyPoint mouseTo)
        {
            double dx = mouseTo.X - mouseFrom.X;
            double dy = mouseTo.Y - mouseFrom.Y;
            return new MyPoint(pointToMove.X + dx, pointToMove.Y + dy);
        }

        public static MyPoint MovePointToAchieveLength(MyPoint pointToMove, MyPoint seceondPoint, double length)
        {
            double c = ExtensionMethods.PixelDistance(pointToMove, seceondPoint);

            double lengthDiff = c - length;
            double dx = seceondPoint.X - pointToMove.X;
            double dy = seceondPoint.Y - pointToMove.Y;

            if (c == 0) return pointToMove;

            double px = ((c - length) * dx) / c;
            double py = ((c - length) * dy) / c;

            return new MyPoint(pointToMove.X + px, pointToMove.Y + py);
        }

        public static MyPoint MovePointToAchieveRightAngle(MyPoint constv1, MyPoint constv2, MyPoint constw1, MyPoint w2)
        {
            double length = PixelDistance(constw1, w2);
            double dx1 = constv2.X - constv1.X;
            double dy1 = constv2.Y - constv1.Y;
            
            MyPoint rightAngle = new MyPoint(constw1.X - dy1, constw1.Y + dx1);
            MyPoint rightAngleSecond = new MyPoint(constw1.X + dy1, constw1.Y - dx1);

            if (PixelDistance(w2, rightAngle) < PixelDistance(w2, rightAngleSecond)) return MovePointToAchieveLength(rightAngle, constw1, length);
            else return MovePointToAchieveLength(rightAngleSecond, constw1, length);
        }

        public static MyPoint FindCenterOfCircleTangentToEdge(MyPoint v1, MyPoint v2, int Radius)
        {
            double dx = v2.X - v1.X;
            double dy = v1.Y - v2.Y;

            MyPoint w1 = CountMiddleOfSegment(v1, v2);
            MyPoint rightAnglePoint = new MyPoint(w1.X + dy, w1.Y + dx);

            return MovePointToAchieveLength(rightAnglePoint, w1, Radius);
        }

        public static int GetVertexNumberFromPoint(Polygon polygon, MyPoint vertexPoint)
        {
            for(int i = 0; i < polygon.Vertices.Count; i++)
            {
                if (polygon.Vertices[i] == vertexPoint) return i;
            }
            return 0;
        }

        public static MyPoint CountMiddleOfSegment(MyPoint a, MyPoint b)
        {
            double dx = a.X - b.X;
            double dy = a.Y - b.Y;
            return new MyPoint(b.X + (0.5 * dx), b.Y + (0.5 * dy));
        }

        public static MyPoint FindPointWhereCircleStickToLine(MyPoint v1, MyPoint v2, Circle circle)
        {
            double dx = v2.X - v1.X;
            double dy = v2.Y - v1.Y;

            MyPoint rightAngle = new MyPoint(circle.Center.X - dy, circle.Center.Y + dx);
            MyPoint rightAngleSecond = new MyPoint(circle.Center.X + dy, circle.Center.Y - dx);

            if(PixelDistance(v1, rightAngle) < PixelDistance(v1, rightAngleSecond))
            {
                return MovePointToAchieveLength(rightAngle, circle.Center, circle.Radius);
            }
            else
            {
                return MovePointToAchieveLength(rightAngleSecond, circle.Center, circle.Radius);
            }
        }

        public static MyPoint FindLeftUpperCornerForRectangle(MyPoint center, int width, int height)
        {
            return new MyPoint(center.X - (int)(width / 2), center.Y - (int)(height / 2));
        }

        public static string ShowDialogToInsertValue(string text, string caption, int initialValue)
        {
            Form prompt = new Form()
            {
                Width = 300,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
            TextBox textBox = new TextBox() { Left = 50, Top = 40, Width = 200 };
            textBox.Text = initialValue.ToString();
            Button confirmation = new Button() { Text = "Ok", Left = 100, Width = 100, Top = 80, DialogResult = DialogResult.OK };
            confirmation.Click += (sender, e) => { prompt.Close(); };
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
