using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using WindowsFormsApplication4.QuickMaths;

namespace WindowsFormsApplication4
{
    public class Transition
    {
        public RectangleF Region { get; set; }
        public RectangleF StartingRegion { get; set; }
        public Size WindowSize { get; private set; }
        private Matrix2 ScaleMatrix { get; set; }
        public const float koef = 1.25f;
        public Transition(RectangleF field)
        {
            Region = field;
            StartingRegion = field;
            WindowSize = new Size();
        }

        public double RealX(int wx)
        {
            return ((wx * Region.Width) / (WindowSize.Width) + Region.X);
        }
        public double RealY(int wy)
        {
            return (Region.Y-(wy * Region.Height) / (WindowSize.Height));
        }
        public int Wx(double rx)
        {
            return (int)Math.Round(WindowSize.Width * (rx - Region.X) / Region.Width);
        }
        public int Wy(double ry)
        {
            return (int)Math.Round(WindowSize.Height * (Region.Y - ry) / Region.Height);
        }

        public void ZoomOut(int x, int y)
        {
            if(Region.Width<1000)
            Region = new RectangleF((float)(RealX(x) + koef * (Region.X - RealX(x))), (float)(RealY(y) + koef * (Region.Y - RealY(y))), (float)Region.Width * koef, (float)Region.Height * koef);
        }
        public void ZoomIn(int x, int y)
        {
            if (Region.Width > 0.0003)
                Region = new RectangleF((float)(RealX(x) + 1/koef * (Region.X - RealX(x))), (float)(RealY(y) + 1/koef *(Region.Y- RealY(y))), (float)Region.Width / koef, (float)Region.Height / koef);
        }
        public void WindowChange(Size newsize)
        {
            WindowSize = newsize;
            ScaleMatrix = new Matrix2(Region.Width / WindowSize.Width, Region.Height / WindowSize.Height);
        }
        public void PaperMoved(Point D)
        {
            Vector2D movementVector = new Vector2D(D.X, D.Y);
            movementVector = ScaleMatrix * movementVector; 
            Region = new RectangleF((float)(Region.X - movementVector.X), (float)(Region.Y + movementVector.Y), Region.Width, Region.Height);
            ScaleMatrix = new Matrix2(Region.Width / WindowSize.Width, Region.Height / WindowSize.Height);
        }
        //{X = -1.16950977 Y = 0.288118362 Width = 0.0252976883 Height = 0.0168651268}
}
}
