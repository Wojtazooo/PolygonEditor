using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolygonEditor.RasterGraphics.Helpers
{
    public static class CircleGenerator
    {

        public static List<Pixel> GetPixels(Point center, int radius, Color color)
        {
            var allCirclePixels = CreatePartsOfCircle(center, radius, color);
            MoveToCenter(allCirclePixels, center);
            return allCirclePixels;
        }

        private static void MoveToCenter(List<Pixel> allCirclePixels, Point center)
        {
            allCirclePixels.ForEach(p =>
            {
                p.X += center.X;
                p.Y += center.Y;
            });
        }

        private static List<Pixel> CreatePartsOfCircle(Point center, int radius, Color color)
        {
            var circleParts = new List<List<Pixel>>();
            for (int i = 0; i < 8; i++)
                circleParts.Add(new List<Pixel>());
            circleParts[6] = MidpointCircle_1(center, radius, color);
            circleParts[6].ForEach(p =>
            {
                circleParts[0].Add(new Pixel(p.Y, -p.X, color));
                circleParts[1].Add(new Pixel(p.X, -p.Y, color));
                circleParts[2].Add(new Pixel(-p.X, -p.Y, color));
                circleParts[3].Add(new Pixel(-p.Y, -p.X, color));
                circleParts[4].Add(new Pixel(-p.Y, p.X, color));
                circleParts[5].Add(new Pixel(-p.X, p.Y, color));
                circleParts[7].Add(new Pixel(p.Y, p.X, color));
            });

            var allCirclePixels = new List<Pixel>();
            foreach (var list in circleParts)
            {
                allCirclePixels.AddRange(list);
            }
            return allCirclePixels;
        }

        private static List<Pixel> MidpointCircle_1(Point center, int radius, Color color)
        {
            int deltaE = 3;
            int detaeNE = 5 - 2 * radius;
            int d = 1 - radius;
            int x = 0;
            int y = radius;

            List<Pixel> pixelsToReturn = new List<Pixel>();
            pixelsToReturn.Add(new Pixel(x, y, color));
            while (y > x)
            {
                if (d < 0) //Select E
                {
                    d += deltaE;
                    deltaE += 2;
                    detaeNE += 2;
                }
                else //SelectNE
                {
                    d += detaeNE;
                    deltaE += 2;
                    detaeNE += 4; y--;
                }
                x++;
                pixelsToReturn.Add(new Pixel(x, y, color));
            }
            return pixelsToReturn;
        }

        private static List<Pixel> MidpointCircle_2(Point center, int radius, Color color)
        {
            int delta1 = 3;
            int delta2 = 5 - 2 * radius;
            int d = 1 - radius;

            int x = radius;
            int y = 0;
            
            List<Pixel> pixelsToReturn = new List<Pixel>();
            pixelsToReturn.Add(new Pixel(x, y, color));
            while (x > y)
            {
                if (d < 0)
                {
                    d += delta1;
                    delta1 += 2;
                    delta2 += 2;
                }
                if (d > 0)
                {
                    d += delta2;
                    delta1 += 2;
                    delta2 += 4;
                    x--;
                }
                y++;
                pixelsToReturn.Add(new Pixel(x, y, color));
            }
            return pixelsToReturn;
        }
    }
}
