using PolygonEditor.RasterGraphics.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace PolygonEditor.RasterGraphics.Helpers
{
    public static class LineGenerator
    {
        public static List<Pixel> GetPixels(Point p1, Point p2, Color color)
        {
            List<Pixel> linePixels = new List<Pixel>();
            int dx = Math.Abs(p2.X - p1.X);
            int dy = Math.Abs(p2.Y - p1.Y);

            int symetricByX = p1.X;
            int symetricXP2 = new Pixel(p2, color).GetSymetricPixelByX(symetricByX).X;

            if (p2.Y <= p1.Y) // 1-4/8
            {
                if (p2.X > p1.X) // 1-2/8
                {
                    if (dx > dy) // 1/8
                    {
                        return MidpointLine_NE_E(p1.X, p1.Y, p2.X, p2.Y, color);
                    }
                    else // 2/8
                    {
                        return MidpointLine_N_NE(p1.X, p1.Y, p2.X, p2.Y, color);
                    }
                }
                else // 3-4/8
                {
                    if (dx > dy) // 4/8
                    {
                        List<Pixel> symetricPixels = MidpointLine_NE_E(p1.X, p1.Y, symetricXP2, p2.Y, color);
                        return Pixel.GetPixelsSymetricByX(symetricPixels, symetricByX);
                    }
                    else // 3/8
                    {
                        List<Pixel> symetricPixels = MidpointLine_N_NE(p1.X, p1.Y, symetricXP2, p2.Y, color);
                        return Pixel.GetPixelsSymetricByX(symetricPixels, symetricByX);
                    }
                }
            }
            else // 5-8/8
            {
                if (p2.X > p1.X) // 7-8/8
                {
                    if (dx > dy) // 8/8
                    {
                        List<Pixel> symetricPixels = MidpointLine_NE_E(symetricXP2, p2.Y, p1.X, p1.Y, color);
                        return Pixel.GetPixelsSymetricByX(symetricPixels, symetricByX);
                    }
                    else // 7/8
                    {
                        List<Pixel> symetricPixels = MidpointLine_N_NE(symetricXP2, p2.Y, p1.X, p1.Y, color);
                        return Pixel.GetPixelsSymetricByX(symetricPixels, symetricByX);
                    }
                }
                else // 5-6/8
                {
                    if (dx > dy) // 5/8
                    {
                        return MidpointLine_NE_E(p2.X, p2.Y, p1.X, p1.Y, color);
                    }
                    else // 6/8
                    {
                        return MidpointLine_N_NE(p2.X, p2.Y, p1.X, p1.Y, color);
                    }
                }
            }
        }

        static List<Pixel> MidpointLine_NE_E(int x1, int y1, int x2, int y2, Color color)
        {
            int dx = x2 - x1;
            int dy = y1 - y2;
            int d = 2 * dy - dx;
            int incrE = 2 * dy;
            int incrNE = 2 * (dy - dx);
            int x = x1;
            int y = y1;

            List<Pixel> pixelsToReturn = new List<Pixel>();
            pixelsToReturn.Add(new Pixel(x, y, color));
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
                    y--;
                }
                pixelsToReturn.Add(new Pixel(x, y, color));
            }
            return pixelsToReturn;
        }

        static List<Pixel> MidpointLine_N_NE(int x1, int y1, int x2, int y2, Color color)
        {
            int dx = x2 - x1;
            int dy = y1 - y2;
            int d = 2 * dx - dy;
            int incrN = 2 * dx;
            int incrNE = 2 * (dx - dy);
            int x = x1;
            int y = y1;

            List<Pixel> pixelsToReturn = new List<Pixel>();
            pixelsToReturn.Add(new Pixel(x, y, color));
            while (y > y2)
            {
                if (d < 0) //choose N 
                {
                    d += incrN;
                    y--;
                }
                else //choose NE 
                {
                    d += incrNE;
                    x++;
                    y--;
                }
                pixelsToReturn.Add(new Pixel(x, y, color));
            }
            return pixelsToReturn;
        }
    }
}
