using System;
using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor
{
    public static class RasterGraphicsGenerator
    {
        public static List<Pixel> GetLinePoints(Point p1, Point p2, Color color)
        {
            List<Pixel> linePixels = new List<Pixel>();

            // TODO: Implement Bresenham's line algorithm for all angle cases

            // test line drawing
            //int minX = Math.Min(p1.X, p2.X);
            //int maxX = Math.Max(p1.X, p2.X);

            //for (int i = minX; i < maxX; i++)
            //{
            //    linePixels.Add(new Pixel(new Point(i, p1.Y), color));
            //}

            return MidpointLine(p1.X, p1.Y, p2.X, p2.Y, color);
        }

        static List<Pixel> MidpointLine(int x1, int y1, int x2, int y2, Color color)
        {
            int dx = x2 - x1;
            int dy = y2 - y1;
            int d = 2 * dy - dx; //initial value of d
            int incrE = 2 * dy; //increment used for move to E
            int incrNE = 2 * (dy-dx); //increment used for move to NE
            int x = x1;
            int y = y1;

            List<Pixel> pixelsToReturn = new List<Pixel>();
            pixelsToReturn.Add(new Pixel(new Point(x, y), color));
            while (x < x2)
            {
                if (d < 0) //choose E 
                {
                    d += incrE;
                    x++;
                }
                else //choose NE 
                {
                    d += incrNE;
                    x++;
                    y++;
                }
                pixelsToReturn.Add(new Pixel(new Point(x, y), color));
            }
            return pixelsToReturn;
        }
    }
}
