using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SmoothTheAngles
{
    public class Polygon
    {
        public Bitmap bitmap;
        public PointF[,] pts;
        public MyPoint[] TheP;
        public int Angles;
        public float radius;
        public Polygon(int ang, float rad, PointF[] pt, int w, int h)
        {
            TheP = new MyPoint[ang];
            pts = new PointF[ang, 2];
            for(int i = 0; i < ang; i++)
            {
                TheP[i] = new MyPoint(pt[i], rad);
            }
            Angles = ang;
            radius = rad;
            bitmap = new Bitmap(w, h);
        }
        public Polygon(int rad, int ang, int w, int h)
        {
            TheP = new MyPoint[ang];
            pts = new PointF[ang,2];
            Angles = 0;
            bitmap = new Bitmap(w, h);
            radius = rad;
        }
        public Polygon()
        {
            TheP = new MyPoint[0];
            pts = new PointF[0, 0];
            bitmap = new Bitmap(1, 1);
            Angles = 0;
            radius = 0;
        }
        private double ToRadians(double y0,double x0, double y1, double x1)
        {
            double k = (y0 - y1) / (x0 - x1);
            return (Math.Atan(k) < 0) ? (2 * Math.PI - Math.Abs(Math.Atan(k))) : Math.Atan(k);
        }
        private double ToRadians(double y, double x)
        {
            double kk2 = y / x;
            return (Math.Atan2(y,x) < 0) ? (2 * Math.PI - Math.Abs(Math.Atan2(y,x))) : Math.Atan2(y,x);
        }
        public void FindCoordinates(int i, float radius, PointF p1, PointF p2)
        {

            double dx1 = -(TheP[i].p.X - p1.X);
            double dx2 = -(TheP[i].p.X - p2.X);
            double dy1 = -(TheP[i].p.Y - p1.Y);
            double dy2 = -(TheP[i].p.Y - p2.Y);

            double kk1 = (dx1 == 0) ? 0 : dy1 / dx1;
            double kk2 = (dx2 == 0) ? 0 : dy2 / dx2;
            double tangi, angle;
            double tangent;
            double tt;
            double fullangle;
            //((kk1<0)?(Math.PI + Math.Atan(kk1)):(Math.Atan(kk1)))
            //((kk2 < 0) ? (Math.PI + Math.Atan(kk2)) : (Math.Atan(kk2)))
            double alk1 = Math.Atan(kk1);
            double alk2 = Math.Atan(kk2);
            double al1 = Math.Atan2(dy1, dx1);
                double al2 = Math.Atan2(dy2, dx2);
            double an1 = (kk1 == 0) ? ((dx1 == 0) ? (Math.PI / 2) : 0): ToRadians(dy1, dx1);
                double an2 = (kk2 == 0) ? ((dx2 == 0) ? (Math.PI / 2) : 0) : ToRadians(dy2, dx2);
            if ((kk1 == 0) && (kk2 == 0))
            {
                tangi = ((dx1 == 0) ? Math.Sign(dy1) : Math.Sign(dx1)) * ((dx2 == 0) ? Math.Sign(dy2) : Math.Sign(dx2));
               angle = Math.Abs(Math.Atan(tangi));
                fullangle = 0;
                tangent = tangi;
            }
            else
            {
                fullangle = (Math.Abs(an1 - an2) > Math.PI) ? (2 * Math.PI - Math.Abs(an1 - an2)) : Math.Abs(an1 - an2);
                tangi = Math.Tan(fullangle);
                angle = fullangle / 2;
                tt = Math.Atan(tangi);
                // angle = (tangi<0)?((Math.PI - Math.Abs(Math.Atan(tangi)))/2):(Math.Atan(tangi)/2);
                tangent = Math.Tan(Math.Atan(tangi) / 2);

            }
            double tangensu = Math.Tan(angle);
            // double circleAngle = Math.PI - 
            double tang = radius / Math.Abs(tangensu);
            double line1 = FindLength(dx1, dy1);
            double line2 = FindLength(dx2, dy2);
            double length = Math.Min(line1, line2);
            PointF pt1;
            PointF pt2;
            if (length < 2 * tang)
            {
                tang = length / 2;
                radius = (float)(tang * Math.Abs(tangensu));
                pt1 = FindPoint1(TheP[i].p, tang, line1, -dx1, -dy1);
                pt2 = FindPoint2(TheP[i].p, tang, line2, -dx2, -dy2 );
            }
                pt1 = FindPoint1(TheP[i].p, tang, line1, -dx1, -dy1);
                pt2 = FindPoint2(TheP[i].p, tang, line2, -dx2, -dy2);
            if (i == 0)
            {
                pts[Angles - 1, 1] = pt2;
                pts[i, 0] = pt1;
            }
            else
            {
                pts[i, 0] = pt1;
                pts[i - 1, 1] = pt2;
            }
                double trace = FindLength(tang, radius);
            double k = ((kk1 == 0) && (kk2 == 0)) ? (tangi) : (Math.Tan((an1 +an2)/2));//((tangensu+kk1)/(1-kk1*tangensu)));
            double b = TheP[i].p.Y - k * TheP[i].p.X;
            double kr1 = (kk1 == 0) ? 0 : (-1 / kk1);
            double kr2 = (kk2 == 0) ? 0 : (-1 / kk2);
            PointF CircleCenter;
            if ((dy1 == 0) & (Math.Round(kr1*1000000) == 0))
            {
                CircleCenter = new PointF(pt1.X, (float)(k * pt1.X + b));
            }
            else
            {
                double br1 = pt1.Y - kr1 * pt1.X;
                CircleCenter = new PointF((float)((br1 - b) / (k - kr1)), (float)(k * (br1 - b) / (k - kr1) + b));
            }
            double AngleToBegin = ToRadians(pt1.Y - CircleCenter.Y, pt1.X - CircleCenter.X);
            double AngleToEnd = ToRadians( pt2.Y - CircleCenter.Y, pt2.X - CircleCenter.X);
            double TheCycle = AngleToEnd - AngleToBegin;

            if (Math.Abs(TheCycle) > Math.PI)
            {
                TheCycle = -Math.Sign(TheCycle) * (-Math.Abs(TheCycle) + 2 * Math.PI);
            }
            if (kr2 != 0)
            {
                double ttt = Math.Tan(AngleToBegin + TheCycle);
                double tttt = Math.Tan(AngleToBegin - TheCycle);
                TheCycle = (Math.Round(Math.Tan(AngleToBegin + TheCycle), 2) == Math.Round(kr2, 2)) ? TheCycle : (-TheCycle);
            }


            TheP[i].TheCycle = TheCycle;
            TheP[i].AngleToBegin = AngleToBegin;
            TheP[i].radius = radius;
            TheP[i].CircleCenter = CircleCenter;
            TheP[i].pt1 = pt1;
            TheP[i].pt2 = pt2;
        }
        public void Draw()
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                PointF[,] lineArgs = new PointF[Angles, 2];
                g.Clear(Color.White);
                for (int i = 0; i < TheP.Length; i++)
                {
                    if (i == 0)
                    {
                       FindCoordinates(i, radius, TheP[i + 1].p, TheP[TheP.Length - 1].p);
                    }
                    else if (i == (TheP.Length - 1))
                    {
                        FindCoordinates(i, radius, TheP[0].p, TheP[i - 1].p);
                    }
                    else
                    {
                        FindCoordinates(i,radius, TheP[i + 1].p, TheP[i - 1].p);
                    }
                }
                Pen muhPen = new Pen(Color.Black);
                for (int i = 0; i < TheP.Length; i++)
                {
                    float xk = (int)pts[i, 0].X, yk = (int)pts[i, 0].Y;
                    float k = Math.Max(Math.Abs((int)pts[i, 1].Y - (int)pts[i, 0].Y), Math.Abs((int)pts[i, 1].X - (int)pts[i, 0].X));
                    for (int o = 0; o < k; o++)
                    {
                        g.DrawRectangle(muhPen, xk, yk, 1, 1);
                        xk += ((int)pts[i, 1].X - (int)pts[i, 0].X) / k;
                        yk += ((int)pts[i, 1].Y - (int)pts[i, 0].Y) / k;
                    }
                    //DrawDDA(muhPen, (int)pts[i, 0].X, (int)pts[i, 0].Y, (int)pts[i, 1].X, (int)pts[i, 1].Y);
                    //g.DrawArc(muhPen, TheP[i].CircleCenter.X - TheP[i].radius, TheP[i].CircleCenter.Y - TheP[i].radius, 2 * TheP[i].radius, 2 * TheP[i].radius, (float)((180 / Math.PI) * TheP[i].AngleToBegin), (float)((180 / Math.PI) * TheP[i].TheCycle));
                    Dyga(ref bitmap, muhPen.Color, TheP[i].CircleCenter.X, TheP[i].CircleCenter.Y, TheP[i].radius, (float)((180 / Math.PI) * TheP[i].AngleToBegin), (float)((180 / Math.PI) *(TheP[i].TheCycle)));
                    bitmap.SetPixel((int)TheP[i].CircleCenter.X, (int)TheP[i].CircleCenter.Y, Color.Red);
                    bitmap.SetPixel((int)TheP[i].pt1.X, (int)TheP[i].pt1.Y, Color.Red);
                    bitmap.SetPixel((int)TheP[i].pt2.X, (int)TheP[i].pt2.Y, Color.Red);
                    bitmap.SetPixel((int)TheP[i].p.X, (int)TheP[i].p.Y, Color.CornflowerBlue);
                    bitmap.SetPixel((int)TheP[i].p.X+1, (int)TheP[i].p.Y-1, Color.CornflowerBlue);
                    bitmap.SetPixel((int)TheP[i].p.X+1, (int)TheP[i].p.Y+1, Color.CornflowerBlue);
                    bitmap.SetPixel((int)TheP[i].p.X-1, (int)TheP[i].p.Y-1, Color.CornflowerBlue);
                    bitmap.SetPixel((int)TheP[i].p.X-1, (int)TheP[i].p.Y+1, Color.CornflowerBlue);
                }
            }
        }
        public void DrawPoints(int x, int y)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                Pen muhPen = new Pen(Color.SteelBlue);
                TheP[Angles] = new MyPoint(new PointF(x,y),radius);
                TheP[Angles].p.Y = y;
                Angles++;
                DrawDDA(muhPen, x + 4, y, x - 4, y, ref bitmap);
                DrawDDA(muhPen, x, y - 4, x, y + 4, ref bitmap);
            }
        }
        private double FindLength(double dx, double dy)
        {
            return Math.Sqrt(dx * dx + dy * dy);
        }
        public void DrawDDA(Pen pen, int x1, int y1, int x2, int y2, ref Bitmap btm)
        {
            float xk = x1, yk = y1;
            float k = Math.Max(Math.Abs(y2 - y1), Math.Abs(x2 - x1));
            for (int i = 0; i < k; i++)
            {
                //this.g.DrawRectangle(pen, xk, yk, 1, 1);
                btm.SetPixel( (int)xk, (int)yk,pen.Color);
                xk += (x2 - x1) / k;
                yk += (y2 - y1) / k;
            }
        }
        public static void Dyga(ref Bitmap btm, Color color, float centerX, float centerY, float radius, float angle1, float sweepangle)
        {
            angle1 = (float)((angle1 / 180) * Math.PI);
            angle1 = (float)(2 * Math.PI - angle1);
            sweepangle = (float)((-sweepangle / 180) * Math.PI); // переход из градусов в радианы

           // if (sweepangle < 0)
           // {
             //   angle1 = angle1 + sweepangle;
              //  sweepangle = -sweepangle;
            //}
            float koef = (float)(Math.PI * 2 / (Math.Abs(sweepangle))); //определение  
            float iterations = 10 * (float)Math.Round((2 * radius) / koef);       //оптимального количества 
            float delta = (sweepangle) / iterations;                           //итераций

            float x1 = centerX + radius * (float)Math.Cos(angle1);
            float y1 = centerY - radius * (float)Math.Sin(angle1);
            btm.SetPixel((int)x1, (int)y1, color);
            for (int i = 0; i < iterations; i++)
            {
                angle1 += delta;
                x1 = centerX + radius * (float)Math.Cos(angle1);
                y1 = centerY - radius * (float)Math.Sin(angle1);
                btm.SetPixel((int)x1, (int)y1, color);
            }

        }
        public PointF FindPoint1(PointF p, double line1, double line2, double dx, double dy)
        {
            double ratio = line1 / line2;
            return new PointF((float)(p.X - dx*ratio), (float)(p.Y - dy*ratio));
        }
        public PointF FindPoint2(PointF p, double line1, double line2, double dx, double dy)
        {
            double ratio = line1 / line2;
            return new PointF((float)(p.X - dx * ratio), (float)(p.Y - dy * ratio));
        }

    }
    public class MyPoint
    {
    public PointF p;
        public double TheCycle;
        public double AngleToBegin;
        public PointF CircleCenter;
        public float radius;
        public PointF pt1;
        public PointF pt2;
        public MyPoint(PointF t, float rad)
        {
            p = t;
            TheCycle = 0;
            AngleToBegin = 0;
            CircleCenter = new PointF(0, 0);
            radius = rad;
            pt1 = new PointF(0, 0);
            pt2 = new PointF(0, 0);
        }
    }
}
