using PolygonEditor.Constraints.PolygonConstraints;
using PolygonEditor.RasterGraphics.Helpers;
using PolygonEditor.RasterGraphics.Models;
using PolygonEditor.RasterGraphics.RasterObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.Constraints
{
    public class ConstraintsEnforcer
    {
        private List<RasterObject> _rasterObjects;

        public ConstraintsEnforcer(List<RasterObject> rasterObjects)
        {
            _rasterObjects = rasterObjects;
        }

        public static void EnforcePolygonConstraints(Polygon polygon, int startVertex, List<PolygonConstraint> constraintsToEnforce = null)
        {
            var leftConstraints = new List<PolygonConstraint>(polygon.Constraints);
            if (constraintsToEnforce != null)
            {
                leftConstraints = constraintsToEnforce;
            }

            if (leftConstraints.Count == 0) return;            

            var leftCounter = 0;
            var leftContinue = true;
            var rightCounter = 0;
            var rightContinue = true;
            var n = polygon.Vertices.Count;
            var previousLeftIndex = startVertex;
            var leftIndex = (startVertex + n - 1) % n;
            var previousRightIndex = startVertex;
            var rightIndex = (startVertex + 1) % n;

            while (leftContinue && leftConstraints.Count > 0)
            {
                var nextLeftConstraint = leftConstraints.Find(c =>
                    (c.RelatedVertices.a == leftIndex || c.RelatedVertices.b == leftIndex) &&
                    (c.RelatedVertices.a == previousLeftIndex || c.RelatedVertices.b == previousLeftIndex) );
                if (nextLeftConstraint != null)
                {
                    nextLeftConstraint.EnforceConstraint(polygon.Vertices[previousLeftIndex]);
                    leftContinue = true;
                    previousLeftIndex = leftIndex;
                    leftIndex = (leftIndex + n - 1) % n;
                    leftConstraints.Remove(nextLeftConstraint);
                    if(nextLeftConstraint.MoreThanOneEdge)
                        leftCounter++;
                }
                else
                {
                    leftContinue = false;
                }
            }

            while (rightContinue && leftConstraints.Count > 0)
            {
                var nextRightConstraint = leftConstraints.Find(c =>
                    (c.RelatedVertices.a == rightIndex || c.RelatedVertices.b == rightIndex) &&
                    (c.RelatedVertices.a == previousRightIndex || c.RelatedVertices.b == previousRightIndex) );
                if (nextRightConstraint != null)
                {
                    nextRightConstraint.EnforceConstraint(polygon.Vertices[previousRightIndex]);
                    rightContinue = true;
                    previousRightIndex = rightIndex;
                    rightIndex = (rightIndex + 1) % n;
                    leftConstraints.Remove(nextRightConstraint);
                    if(nextRightConstraint.MoreThanOneEdge)
                        rightCounter++;
                }
                else
                {
                    rightContinue = false;
                }
            }
            
            if(leftConstraints.Count > 0 && leftCounter > 0 && rightCounter > 0)
                EnforcePolygonConstraints(polygon, leftConstraints[0].RelatedVertices.a, leftConstraints);
        }

        public void EnforceCircleConstraint(Circle circle)
        {
            circle.ConstantCenterConstraint?.EnforceConstraint(null);
            circle.ConstantRadiusConstraint?.EnforceConstraint(null);
            circle.tangentToPolygonConstraint?.EnforceConstraint(null);
        }
    }
}