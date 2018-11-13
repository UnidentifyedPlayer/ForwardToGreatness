using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestTask4_3D.ThirdDimension
{
    public class Screen
    {
        public Size Size { get; private set; }
        public int SizeW { get; private set; }
        public int SizeH { get; private set; }
        public RectangleF Rectangle { get; private set; }
        public Screen(int width,int height, RectangleF r)
        {
            SizeW = width;
            SizeH = height;
            Rectangle = r;
        }
        public Point Real2Screen(PointF p)
        {
            return new Point((int)((p.X - Rectangle.X) / Rectangle.Width * SizeW), (int)((Rectangle.Y - p.Y) / Rectangle.Height * SizeH));
        }
    }
}
