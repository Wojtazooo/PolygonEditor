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

        public CircleTangentToPolygonConstraint tangentToPolygonConstraint { get; private set; }
        public ConstantCenterConstraint ConstantCenterConstraint { get; private set; }
        public ConstantRadiusConstraint ConstantRadiusConstraint { get; private set; }

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
            tangentToPolygonConstraint?.DrawConstraintInfo(g);
            ConstantRadiusConstraint?.DrawConstraintInfo(g);
            ConstantCenterConstraint?.DrawConstraintInfo(g);
        }

        public void AddConstraint(CircleConstraint constraint)
        {
            constraint.SetConstraintOnObject();
        }
        
        public void SetTangentConstraint(CircleTangentToPolygonConstraint constraint)
        {
            tangentToPolygonConstraint = constraint;
        }

        public void SetConstantCenterConstraint(ConstantCenterConstraint constraint)
        {
            ConstantCenterConstraint = constraint;
        }

        public void SetConstantRadiusConstraint(ConstantRadiusConstraint constraint)
        {
            ConstantRadiusConstraint = constraint;
        }
        public override bool RemoveConstraintByClick(MyPoint mousePoint)
        {
            if(ConstantRadiusConstraint != null && ExtensionMethods.IsInCircle(ConstantRadiusConstraint?.GetCenterDrawingPoint(), mousePoint, Constants.DETECTION_RADIUS))
            {
                ConstantRadiusConstraint = null;
                return true;
            }
            if (ConstantCenterConstraint != null && ExtensionMethods.IsInCircle(ConstantCenterConstraint?.GetCenterDrawingPoint(), mousePoint, Constants.DETECTION_RADIUS))
            {
                ConstantCenterConstraint = null;
                return true;
            }
            if (tangentToPolygonConstraint != null && ExtensionMethods.IsInCircle(tangentToPolygonConstraint?.GetCenterDrawingPoint(), mousePoint, Constants.DETECTION_RADIUS))
            {
                tangentToPolygonConstraint = null;
                return true;
            }
            return false;
        }

        public override bool DetectConstraint(MyPoint mousePoint)
        {
            if (ConstantRadiusConstraint != null && ExtensionMethods.IsInCircle(ConstantRadiusConstraint?.GetCenterDrawingPoint(), mousePoint, Constants.DETECTION_RADIUS))
            {
                return true;
            }
            if (ConstantCenterConstraint != null && ExtensionMethods.IsInCircle(ConstantCenterConstraint?.GetCenterDrawingPoint(), mousePoint, Constants.DETECTION_RADIUS))
            {
                return true;
            }
            if (tangentToPolygonConstraint != null && ExtensionMethods.IsInCircle(tangentToPolygonConstraint?.GetCenterDrawingPoint(), mousePoint, Constants.DETECTION_RADIUS))
            {
                return true;
            }
            return false;
        }
    }
}
