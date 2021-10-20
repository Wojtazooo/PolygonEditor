using PolygonEditor.Constraints.CircleConstraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PolygonEditor.RasterGraphics.RasterObjects
{
    public class Circle : RasterObject
    {
        public MyPoint Center { get; private set; }
        public int Radius { get; private set; }

        public List<CircleConstraint> Constraints { get; private set; } = new List<CircleConstraint>();

        public Circle(MyPoint center, int radius, Color color): base(color)
        {
            Center = center;
            Radius = radius;
            Update();
        }

        public override void Update()
        {
            _pixels = CircleGenerator.GetPixels(Center.GetPoint(),Radius,Color);
        }

        public void SetRadius(int newRadius)
        {
            Radius = newRadius;
            Update();
        }

        public void SetCenter(MyPoint center)
        {
            Center = center;
            Update();
        }

        public override MyPoint DetectObject(MyPoint mousePoint, int radius)
        {
            if (ExtensionMethods.IsInCircle(mousePoint, Center, radius))
                return Center;
            int mouseCenterDist = (int)ExtensionMethods.PixelDistance(mousePoint, Center);
            if (mouseCenterDist <= Radius + radius && mouseCenterDist >= Radius - radius)
                return mousePoint;
            return null;
        }

        public override void MoveRasterObject(MyPoint from, MyPoint to)
        {
            MyPoint newCenter = ExtensionMethods.MovePoint(Center, from, to);
            this.SetCenter(newCenter);
        }

        public override RasterObject Clone()
        {
            return new Circle(Center, Radius, Color);
        }

        public override void DrawConstraints(Graphics g)
        {
            foreach(var constraint in Constraints)
            {
                constraint.DrawConstraintInfo(g);
            }
        }

        public void AddConstraint(CircleConstraint constraint)
        {
            Constraints.Add(constraint);
        }

        public override bool RemoveConstraintByClick(MyPoint mousePoint)
        {
            for (int i = 0; i < Constraints.Count; i++)
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
            for (int i = 0; i < Constraints.Count; i++)
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
