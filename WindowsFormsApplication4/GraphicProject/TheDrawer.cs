using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ExpressionParser;
using ExpressionTreeClasses;
using WindowsFormsApplication4.QuickMaths;

namespace WindowsFormsApplication4
{
    public enum DrawMode
    {
         TwoDimensional = 1,
        TwoComplexDimensional = 2,
        ThreeDimensioal = 3
    }
    class TheDrawer
    {
        private OperationClass XFunc;
        private OperationClass YFunc;
        private OperationClass ZFunc;
        private OperationClass CXFunc;
        private OperationClass CYFunc;
        private OperationClass TLowerBound;
        private OperationClass THigherBound;
        private OperationClass YLowerBound;
        private OperationClass YHigherBound;
        private OperationClass XLowerBound;
        private OperationClass XHigherBound;
        private int PenWidth;
        private int FragmentationDepth;
        private int XFragmentationDepth;
        private int YFragmentationDepth;
        private int Iterations;
        public  Color GraphColor { get; private set; }
        private Color BackgroundColor;
        private Color AxisColor;
        private DrawMode DrawingMode;
        private const double PixelsToCoordinates = 36.7; 

        public TheDrawer()
        {
            DrawingMode = (DrawMode)1;
            GraphColor = Color.Black;
            BackgroundColor = Color.White;
            AxisColor = Color.Black;
            PenWidth = 1;
        }
        public void SetTwoDimenDrawer(string xfunc, string yfunc, string tlowbound, string tupbound)
        {
            ParsedExp parser = new ParsedExp();
            parser.InsertExpression(xfunc);
            XFunc = parser.ExpTree();
            parser.InsertExpression(yfunc);
            YFunc = parser.ExpTree();
            parser.InsertExpression(tlowbound);
            TLowerBound = parser.ExpTree();
            parser.InsertExpression(tupbound);
            THigherBound = parser.ExpTree();
            FragmentationDepth = 200;
        }
        public void SetThreeDimenDrawer(string zfunc, string xlowbound, string xupbound, string ylowbound, string yupbound)
        {
            ParsedExp parser = new ParsedExp();
            parser.InsertExpression(zfunc);
            ZFunc = parser.ExpTree();
            parser.InsertExpression(xlowbound);
            XLowerBound = parser.ExpTree();
            parser.InsertExpression(xupbound);
            XHigherBound = parser.ExpTree();
            parser.InsertExpression(ylowbound);
            YLowerBound = parser.ExpTree();
            parser.InsertExpression(yupbound);
            YHigherBound = parser.ExpTree();
            XFragmentationDepth = 50;
            YFragmentationDepth = 50;
        }
        public void SetTwoDimenComplexDrawer( string xz, string yz, string xc, string yc)
        {
            ParsedExp parser = new ParsedExp();
            parser.InsertExpression(xz);
            XFunc = parser.ExpTree();
            parser.InsertExpression(yz);
            YFunc = parser.ExpTree();
            parser.InsertExpression(xc);
            CXFunc = parser.ExpTree();
            parser.InsertExpression(yc);
            CYFunc = parser.ExpTree();
            Iterations = 50;
        }
        public void SetDrawMode(int mode)
        {
            DrawingMode = (DrawMode)mode;
        }
        public void SetGraphColor(Color color)
        {
            GraphColor = color;
        }
        public void SetBackgroundColor(Color color)
        {
            BackgroundColor = color;
        }
        public void SetAxisColor(Color color)
        {
            AxisColor = color;
        }
        private double X(double t)
        {
            return XFunc.Cacluate(ref t);
        }
        private double Y(double t)
        {
            return YFunc.Cacluate(ref t);
        }
        private double CX(double t)
        {
            return CXFunc.Cacluate(ref t);
        }
        private double CY(double t)
        {
            return CYFunc.Cacluate(ref t);
        }

        public double CacllowT()
        {
            double v0 = 0;
            return TLowerBound.Cacluate(ref v0);
        }
        public double CacltopT()
        {
            double v0 = 0;
            return THigherBound.Cacluate(ref v0);
        }
        public double CacllowY()
        {
            double v0 = 0;
            return YLowerBound.Cacluate(ref v0);
        }
        public double CacltopY()
        {
            double v0 = 0;
            return YHigherBound.Cacluate(ref v0);
        }
        public double CacllowX()
        {
            double v0 = 0;
            return TLowerBound.Cacluate(ref v0);
        }
        public double CacltopX()
        {
            double v0 = 0;
            return XHigherBound.Cacluate(ref v0);
        }
        public void Draw(Transition Transitor, Camera camera,Graphics g)
        {
            switch (DrawingMode)
            {
                case (DrawMode)1:
                    DrawTwoDimensionalFunc(Transitor, g);
                    break;
                case (DrawMode)2:
                    DrawTwoDimenComplexFunc(Transitor, g);
                    break;
                case (DrawMode)3:
                    DrawThreeDimensionalFunc(Transitor,camera,g);
                    break;
            }
        }
        public void DrawTwoDimensionalFunc(Transition Transitor, Graphics g)
        {
            g.Clear(BackgroundColor);
            double lowt = CacllowT();
            double x0 = X(CacllowT());
            double y0 = Y(CacllowT());
            double step = (CacltopT() - CacllowT()) / FragmentationDepth;
            DrawAxis(Transitor, g);
            double t = CacllowT();
            if ((-10000000 > x0 || x0 > 10000000 || -10000000 > y0 || y0 > 10000000))
            {
                t += step;
                x0 = X(t);
                y0 = Y(t); 
            }
                for (t =t+step; t <= CacltopT(); t = t + step)
            {
                double x1 = X(t);
                double y1 = Y(t);
                if (!(-10000000 > x1 || x1 > 10000000 || -10000000 > y1 || y1 > 10000000))
                    g.DrawLine(new Pen(GraphColor,PenWidth), Transitor.Wx(x0), Transitor.Wy(y0), Transitor.Wx(x1), Transitor.Wy(y1));
                x0 = x1;
                y0 = y1;
            }
        }
        public void DrawAxis(Transition Transitor, Graphics g)
        {
            bool drawnumbers = Transitor.Region.Width < 30;
            bool drawdivisions = Transitor.Region.Width < 120;
            if ((Transitor.Region.Y >= 0) && (Transitor.Region.Y - Transitor.Region.Height <= 0))
            { 
                    float z = Transitor.Region.X + Transitor.Region.Width;
                g.DrawLine(new Pen(AxisColor), Transitor.Wx(Transitor.Region.X), Transitor.Wy(0f), Transitor.Wx(Transitor.Region.X + Transitor.Region.Width), Transitor.Wy(0f));
                if (drawdivisions)
                {
                    while (z > Transitor.Region.X)
                    {
                        int buff = (int)Math.Floor(z);
                        if (buff != 0)
                        {
                            g.DrawLine(new Pen(AxisColor, 2), Transitor.Wx(buff), Transitor.Wy(-0.25), Transitor.Wx(buff), Transitor.Wy(0.25));
                            if (drawnumbers)
                                g.DrawString(buff.ToString(), new Font("Arial", 8, FontStyle.Bold), new SolidBrush(Color.Black), Transitor.Wx(buff), Transitor.Wy(0.4f));
                        }
                        z--;

                    }
                    z = Transitor.Region.X + Transitor.Region.Width;
                    float buf = (float)(z - z % 0.2);
                    while (buf > Transitor.Region.X)
                    {
                        g.DrawLine(new Pen(AxisColor, 1), Transitor.Wx(buf), Transitor.Wy(-0.1), Transitor.Wx(buf), Transitor.Wy(0.1));
                        buf = buf - 0.2f;
                    }
                }
            }
            if ((Transitor.Region.X <= 0) && (Transitor.Region.X + Transitor.Region.Width >= 0))
            {
                float z = Transitor.Region.Y ;
                g.DrawLine(new Pen(AxisColor), (float)Transitor.Wx(0f), (float)Transitor.Wy(Transitor.Region.Y), (float)Transitor.Wx(0f), (float)Transitor.Wy(Transitor.Region.Y - Transitor.Region.Height));
                if (drawdivisions)
                {
                    while (z > Transitor.Region.Y - Transitor.Region.Height)
                    {
                        int buff = (int)Math.Floor(z);
                        if (buff != 0)
                        {
                            g.DrawLine(new Pen(AxisColor, 2), Transitor.Wx(-0.25), Transitor.Wy(buff), Transitor.Wx(0.25), Transitor.Wy(buff));
                            if (drawnumbers)
                                g.DrawString(buff.ToString(), new Font("Arial", 8, FontStyle.Bold), new SolidBrush(Color.Black), Transitor.Wx(-0.4f), Transitor.Wy(buff));
                        }
                        z--;
                    }
                    z = Transitor.Region.Y;
                    float buf = (float)(z - z % 0.2);
                    while (buf > Transitor.Region.Y - Transitor.Region.Height)
                    {
                        g.DrawLine(new Pen(AxisColor, 1), Transitor.Wx(-0.1), Transitor.Wy(buf), Transitor.Wx(0.1), Transitor.Wy(buf));
                        buf = buf - 0.2f;
                    }
                }
            }
        }

        internal void SetPenWidth(int value)
        {
            PenWidth = value;
        }

        internal void SetFragmentation(decimal value)
        {
            FragmentationDepth = (int)value;
        }

        internal void SetIterations(decimal value)
        {
            Iterations = (int)value;
        }

        public void DrawThreeDimensionalFunc(Transition Transitor,Camera camera,Graphics g)
        {
            g.Clear(BackgroundColor);
            double v0 = 0;
            double x0 = XLowerBound.Cacluate(ref v0);
            double y0 = YLowerBound.Cacluate(ref v0);
            double xdist = XHigherBound.Cacluate(ref v0) - x0;
            double ydist = YHigherBound.Cacluate(ref v0) - y0;
            double xstep = xdist / XFragmentationDepth;
            double ystep = ydist / YFragmentationDepth;
            DrawCube(Transitor,camera, g);
        }
        private void DrawCube(Transition Transitor, Camera camera, Graphics g) {
            Vector4[] arr = new Vector4[4];
            PointF[] arrp = new PointF[4];
            arr[0] = new Vector4(0, 0, 0);
            arr[1] = new Vector4(0, 1, 0);
            arr[2] = new Vector4(1, 1, 0);
            arr[3] = new Vector4(1, 0, 0);
            for(int i = 0; i<4; i++)
            {
                arr[i] = camera.ViewMatrix() * arr[0];
                arrp[i].X = (float)Transitor.Wx(arr[i].X);
                arrp[i].Y = (float)Transitor.Wy(arr[i].Y);

            }
            g.DrawLines(new Pen(GraphColor), arrp);
        }
        public void DrawTwoDimenComplexFunc(Transition Transitor, Graphics g)
        {
            g.Clear(BackgroundColor);
            double x0 = X(0);
            double y0 = Y(0);
            double xc = CX(0);
            double yc = CY(0);
                DrawAxis(Transitor, g);
            for (double t = 0; t <= Iterations; t++)
            {
                double x1 = x0*x0 - y0*y0 +xc;
                double y1 = 2*x0*y0 +yc;
                if (-10000000 > x1 || x1 > 10000000 || -10000000 > y1 || y1 > 10000000)
                    break;
                g.DrawLine(new Pen(GraphColor, PenWidth), Transitor.Wx(x0), Transitor.Wy(y0), Transitor.Wx(x1), Transitor.Wy(y1));
                x0 = x1;
                y0 = y1;
            }
        }
        public void FindCorrelation(int x2, int y2, Transition Transitor, Graphics g)
        {
            g.DrawString("lalala", new Font("Arial", 10, FontStyle.Bold), new SolidBrush(Color.Black), x2,y2);
            double lowt = CacllowT();
            Vector2D vp = new Vector2D(Transitor.RealX(x2), Transitor.RealY(y2));
            Vector2D v0 = new Vector2D(X(CacllowT()), Y(CacllowT()));
            Vector2D vt1 = new Vector2D(); 
                Vector2D vt2 = new Vector2D();
            double t2 = 0;
            double koef = 0;
            double step = (CacltopT() - CacllowT()) / FragmentationDepth;
            for (double t = CacllowT() + step; t <= CacltopT(); t = t + step)
            {
                Vector2D v1 = new Vector2D(X(t), Y(t));
                double disv0v1 = Vector2D.Distance(v0, v1);
                double disvv0 = Vector2D.Distance(vp, v0);
                double disvv1 = Vector2D.Distance(vp, v1);
                if (disv0v1 / (disvv0 + disvv1) > koef)
                {
                    koef = disv0v1 / (disvv0 + disvv1);
                    vt1 = v0;
                    vt2 = v1;
                    t2 = t; 
                }
                //if (Math.Abs(km-kd)<0.15&&(Math.Sign(y1 - y0)== Math.Sign(y - y0))&& (Math.Sign(x1 - x0) == Math.Sign(x - x0)))
                //{
                //    double tm = t + step*(y - y0) / (y1 - y0);
                //    if(y<0 && y > -10)
                //    {
                //        g.DrawString("t = " + tm.ToString(), new Font(new FontFamily("Arial"), 8), new SolidBrush(GraphColor) , x2, y2 - 5);
                //    }
                //    else
                //        g.DrawString("t = " + tm.ToString(), new Font(new FontFamily("Arial"), 8), new SolidBrush(GraphColor), x2, y2 +  5);
                //    break;
                //}
                v0 = v1;
            }
            if (koef > 0.5)
            {
                double ts = t2 - step * (Vector2D.Distance(vp, vt2) / Vector2D.Distance(vt1, vt2));
                g.DrawString((t2 - step*(Vector2D.Distance(vp,vt2)/Vector2D.Distance(vt1,vt2))).ToString(), new Font("Arial", 10, FontStyle.Bold), new SolidBrush(GraphColor), x2, y2 + 5);
            }
        }
        public void FindCorrelation(int x2, int y2, Transition Transitor, ref  Bitmap bit)
        {
            using (Graphics g = Graphics.FromImage(bit))
            {
                double lowt = CacllowT();
                Vector2D vp = new Vector2D(Transitor.RealX(x2), Transitor.RealY(y2));
                Vector2D v0 = new Vector2D(X(CacllowT()), Y(CacllowT()));
                Vector2D vt1 = new Vector2D();
                Vector2D vt2 = new Vector2D();
                double t2 = 0;
                double koef = 0;
                double step = (CacltopT() - CacllowT()) / FragmentationDepth;
                for (double t = CacllowT() + step; t <= CacltopT(); t = t + step)
                {
                    Vector2D v1 = new Vector2D(X(t), Y(t));
                    double disv0v1 = Vector2D.Distance(v0, v1);
                    double disvv0 = Vector2D.Distance(vp, v0);
                    double disvv1 = Vector2D.Distance(vp, v1);
                    if (disv0v1 / (disvv0 + disvv1) > koef)
                    {
                        koef = disv0v1 / (disvv0 + disvv1);
                        vt1 = v0;
                        vt2 = v1;
                        t2 = t;
                    }
                    //if (Math.Abs(km-kd)<0.15&&(Math.Sign(y1 - y0)== Math.Sign(y - y0))&& (Math.Sign(x1 - x0) == Math.Sign(x - x0)))
                    //{
                    //    double tm = t + step*(y - y0) / (y1 - y0);
                    //    if(y<0 && y > -10)
                    //    {
                    //        g.DrawString("t = " + tm.ToString(), new Font(new FontFamily("Arial"), 8), new SolidBrush(GraphColor) , x2, y2 - 5);
                    //    }
                    //    else
                    //        g.DrawString("t = " + tm.ToString(), new Font(new FontFamily("Arial"), 8), new SolidBrush(GraphColor), x2, y2 +  5);
                    //    break;
                    //}
                    v0 = v1;
                }
                if (koef > 0.5)
                {
                    double ts = t2 - step * (Vector2D.Distance(vp, vt2) / Vector2D.Distance(vt1, vt2));
                    g.DrawString("t = " + (t2 - step * (Vector2D.Distance(vp, vt2) / Vector2D.Distance(vt1, vt2))).ToString(), new Font("Arial", 8, FontStyle.Italic), new SolidBrush(GraphColor), x2, y2 - 15);
                    g.DrawString("y = " + Transitor.RealY(y2).ToString(), new Font("Arial", 8, FontStyle.Italic), new SolidBrush(GraphColor), x2, y2 - 25);
                    g.DrawString("x = " + Transitor.RealX(x2).ToString(), new Font("Arial", 8, FontStyle.Italic), new SolidBrush(GraphColor), x2, y2 - 35);
                }
            }
            }


















        static public Bitmap DrawMandelbrot(Transition Transitor)
        {

            double currentX = Transitor.Region.X;
            double currentY = Transitor.Region.Y;
            double a;
            double b;
            double bufaa;
            double bufbb;
            double buf2ab;
            double za;
            double zb;
            bool IsPointInSet;
            int maxiter = 150;
            int maxiterminusone = maxiter - 1;
            double colorKoef = 255f / (float)maxiter;
            Bitmap btm = new Bitmap(Transitor.WindowSize.Width, Transitor.WindowSize.Height);
            //btm.SetPixel((int)Transitor.Wx(0f), (int)Transitor.Wy(0f), Color.Black);
            double stepx = Transitor.Region.Width / Transitor.WindowSize.Width;
            double stepy = Transitor.Region.Height / Transitor.WindowSize.Height;
            for(int i = 0; i<btm.Height; i++)
            {
                currentX = Transitor.Region.X;
                for(int z = 0; z<btm.Width;z++)
                {
                    a = currentX;
                    b = currentY;
                    za = 0;
                    zb = 0;
                    IsPointInSet = true;
                    for( int iterations = 0; iterations<(int)maxiter; iterations++)
                    {
                        bufaa = a*a ;
                        bufbb= b*b;
                        buf2ab = 2 * a * b;
                        a = bufaa - bufbb + 0.285;
                        b = buf2ab + 0.01;
                        if (a * a + b * b > 4)
                        {
                            int col = (int)Math.Round(colorKoef * iterations);
                            if (iterations == 0)
                            {
                                btm.SetPixel(z, i, Color.Blue);
                            }
                            else if(iterations<maxiterminusone)
                                    btm.SetPixel(z, i, Color.FromArgb(col, col, 255));
                            else if(iterations == maxiterminusone)
                                btm.SetPixel(z, i, Color.Yellow);
                            //btm.SetPixel(z, i, Color.FromArgb(iterations*255 / 50 , 255*iterations / 50, 255*iterations / 50));
                            IsPointInSet = false;
                            break;
                        }
                    }
                    if (IsPointInSet)
                        btm.SetPixel(z, i, Color.Black);
                    currentX += stepx;
                }
                currentY -= stepy;
            }
            return btm;
        }
        static public Bitmap DrawMandelbrotDecimal(Transition Transitor)
        {

            decimal currentX = (decimal)Transitor.Region.X;
            decimal startX = (decimal)Transitor.Region.X;
            decimal currentY = (decimal)Transitor.Region.Y;
            decimal a;
            decimal b;
            decimal bufa;
            decimal bufb;
            decimal za;
            decimal zb;
            bool IsPointInSet;
            int maxiter = 150;
            int maxiterminusone = maxiter - 1;
            double colorKoef = 255f / (float)maxiter;
            Bitmap btm = new Bitmap(Transitor.WindowSize.Width, Transitor.WindowSize.Height);
            //btm.SetPixel((int)Transitor.Wx(0f), (int)Transitor.Wy(0f), Color.Black);
            decimal stepx = (decimal)Transitor.Region.Width / Transitor.WindowSize.Width;
            decimal stepy = (decimal)Transitor.Region.Height / Transitor.WindowSize.Height;
            for (int i = 0; i < btm.Height; i++)
            {
                currentX = startX;
                for (int z = 0; z < btm.Width; z++)
                {
                    a = currentX;
                    b = currentY;
                    za = 0;
                    zb = 0;
                    IsPointInSet = true;
                    for (int iterations = 0; iterations < (int)maxiter; iterations++)
                    {
                        bufa = za * za - zb * zb;
                        bufb = 2 * za * zb;
                        za = bufa + a;
                        zb = bufb + b;
                        if (za * za + zb * zb > 4)
                        {
                            int col = (int)Math.Round(colorKoef * iterations);
                            if (iterations == 0)
                            {
                                btm.SetPixel(z, i, Color.Blue);
                            }
                            else if (iterations < maxiterminusone)
                                btm.SetPixel(z, i, Color.FromArgb(col, col, 255));
                            else if (iterations == maxiterminusone)
                                btm.SetPixel(z, i, Color.Yellow);
                            //btm.SetPixel(z, i, Color.FromArgb(iterations*255 / 50 , 255*iterations / 50, 255*iterations / 50));
                            IsPointInSet = false;
                            break;
                        }
                    }
                    if (IsPointInSet)
                        btm.SetPixel(z, i, Color.Black);
                    currentX += stepx;
                }
                currentY -= stepy;
            }
            return btm;
        }
       
        //public Bitmap DrawTheFunction(Transition Transitor)
        //{
        //    double tStart = TLowerBound.Cacluate(0);
        //    double tEnd = THigherBound.Cacluate(0);

        //}
    }
}
