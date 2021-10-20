using PolygonEditor.Constraints.PolygonConstraints;
using PolygonEditor.RasterGraphics.Helpers;
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
    public class ConstraintsEnforcer
    {
        private List<RasterObject> _rasterObjects;

        public ConstraintsEnforcer(List<RasterObject> rasterObjects)
        {
            _rasterObjects = rasterObjects;
        }

        public void EnforcePolygonConstraints(Polygon polygon, int startVertex)
        {
            int n = polygon.Vertices.Count;
            int i = (startVertex + n - 1) % n;
            bool nextI = false; // if there is next relation
            bool nextJ = false;
            int j = (startVertex + 1) % n;

            List<PolygonConstraint> leftConstraints = new List<PolygonConstraint>();
            foreach (var c in polygon.Constraints)
            {
                leftConstraints.Add(c);
            }

            // wywołaj wszystkie z pierwszym wierzchołkiem
            foreach (var c in polygon.Constraints)
            {
                if (c.RelatedVertices.Contains(startVertex) && c.RelatedVertices.Contains(i))
                {
                    c.EnforceConstraint(polygon.Vertices[startVertex]);
                    leftConstraints.Remove(c);
                    nextI = true;
                }
                else if (c.RelatedVertices.Contains(startVertex) && c.RelatedVertices.Contains(j))
                {
                    c.EnforceConstraint(polygon.Vertices[startVertex]);
                    leftConstraints.Remove(c);
                    nextJ = true;
                }
            }

            int iterationCounter = 0;

            while (leftConstraints.Count > 0 && (nextI || nextJ) && iterationCounter < 10)
            {
                iterationCounter++;
                // operacje dla i
                if (nextI)
                {
                    nextI = false;
                    for (int m = 0; m < leftConstraints.Count; m++)
                    {
                        var nextConstr = leftConstraints[m];
                        if (nextConstr.RelatedVertices.Contains(i))
                        {
                            nextConstr.EnforceConstraint(polygon.Vertices[i]);
                            leftConstraints.Remove(nextConstr);
                            nextI = true;
                            break;
                        }
                    }
                    i = (i + n - 1) % polygon.Vertices.Count;
                }



                // operacje dla j
                if (nextJ)
                {
                    nextJ = false;
                    for (int m = 0; m < leftConstraints.Count; m++)
                    {
                        var nextConstr = leftConstraints[m];
                        if (nextConstr.RelatedVertices.Contains(j))
                        {
                            nextConstr.EnforceConstraint(polygon.Vertices[j]);
                            leftConstraints.Remove(nextConstr);
                            nextJ = true;
                            break;
                        }
                    }
                    j = (j + 1) % polygon.Vertices.Count;
                }
            }
        }

        public void EnforceCircleConstraint(Circle circle)
        {
            foreach(var c in circle.Constraints)
            {
                c.EnforceConstraint(new MyPoint());
            }
        }

    }
}
