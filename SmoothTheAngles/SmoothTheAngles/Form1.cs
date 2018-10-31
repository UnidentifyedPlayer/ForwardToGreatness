using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmoothTheAngles
{
    public partial class Form1 : Form
    {
        Graphics g;
        PointF[] pointsArr;
        int radius;
        int counter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
        }
        private void DrawTheSmoothed(PointF P0, PointF p1, PointF p2, float radius, int i , ref PointF[,] lineArgs, int counter)
        {
            double dx1 = P0.X - p1.X;
            double dx2 = P0.X - p2.X;
            double dy1 = P0.Y - p1.Y;
            double dy2 = P0.Y - p2.Y;

            double theAngle = ( Math.Atan2(dy1, dx1) - Math.Atan2(dy2, dx2)) /2;
            double tangensu = Math.Abs(Math.Tan(theAngle));
            double smoothedLinePart1 = radius / tangensu;
            double line10 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);
            double line02 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);
            double line = Math.Min(line10, line02);

            if (smoothedLinePart1 > line)
            {
                smoothedLinePart1 = line;
                radius = (float)(line / Math.Tan(theAngle));
            }

            PointF pointS1 = PointOfSmoothering(P0, smoothedLinePart1, line10, dx1, dy1);
            PointF pointS2 = PointOfSmoothering(P0, smoothedLinePart1, line02, dx2, dy2);
            if (i == 0)
            {
                lineArgs[counter - 1, 1] = pointS2;
                lineArgs[i, 0] = pointS1;
            }
            else 
            {
                lineArgs[i, 0] = pointS1;
                lineArgs[i - 1, 1] = pointS2;
            }

            double dx = (P0.X  - pointS1.X) + (P0.X - pointS2.X);
            double dy = (P0.Y - pointS1.Y) + (P0.Y - pointS2.Y);

            double L = FindLength(dx, dy);
            double d = FindLength(smoothedLinePart1, radius);

            PointF CircleCenter = PointOfSmoothering(P0, d, L, dx, dy);

            double angleToBegin = Math.Atan2(pointS1.Y - CircleCenter.Y, pointS1.X - CircleCenter.X);
            double angleToEnd = Math.Atan2( pointS2.Y - CircleCenter.Y, pointS2.X - CircleCenter.X);

            double theCycle = angleToEnd - angleToBegin;
            if (theCycle < 0)
            {
                angleToBegin = angleToEnd;
                theCycle = -theCycle;
            }
            if (theCycle > Math.PI)
            {
                theCycle = Math.PI - theCycle;
            }

                Pen myPen = new Pen(Color.Black,2);

            g.DrawArc(myPen, CircleCenter.X - radius, CircleCenter.Y - radius, 2 * radius, 2 * radius, (float)((180  / Math.PI) * angleToBegin), (float)((180 / Math.PI)* theCycle));

        }
        private PointF PointOfSmoothering(PointF p, double smoothedLinePart, double line,  double dx, double dy)
        {
            double diff = smoothedLinePart / line;
            return new PointF((float)(p.X - dx * diff), (float)(p.Y - dy * diff));
        }
        private double FindLength(double dx, double dy)
        {
            return Math.Sqrt(dx * dx + dy * dy);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            counter = 0;
            if(!Int32.TryParse(textBox1.Text,out radius)||!Int32.TryParse(textBox2.Text, out counter))
            {
                MessageBox.Show("Try putting the normal numbers once in a while(integral, that is).");
            }
            else
            { 
                pointsArr = new PointF[counter];
                counter = 0;
                g.Clear(Color.White);
            }
        }
        public void DrawDDA(Pen pen, int x1, int y1, int x2, int y2)
        {
            float xk = x1, yk = y1;
            float k = Math.Max(Math.Abs(y2 - y1), Math.Abs(x2 - x1));
            for (int i = 0; i < k; i++)
            {
                this.g.DrawRectangle(pen, xk, yk, 1, 1);
                xk += (x2 - x1) / k;
                yk += (y2 - y1) / k;
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (counter < pointsArr.Length)
            {
                Pen muhPen = new Pen(Color.SteelBlue);
                pointsArr[counter].X = e.X;
                pointsArr[counter].Y = e.Y;
                counter++;
                DrawDDA(muhPen, e.X + 4, e.Y, e.X - 4, e.Y);
                DrawDDA(muhPen, e.X, e.Y-4, e.X, e.Y+4);
            }
            else
            {
                MessageBox.Show("You're done with installing coordinates,\n consider activating the drawing process");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Polygon A = new Polygon(counter, radius, pointsArr,pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            A.Draw();
            g.DrawImage(A.bitmap,pictureBox1.ClientRectangle);
        }


        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Text = "X = " + e.X + " Y = " + e.Y;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            pointsArr = new PointF[] { new PointF(50, 50), new PointF(50, 100), new PointF(200, 100), new PointF(200, 50) };
            counter = 4;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            pointsArr = new PointF[] { new PointF(365, 327),  new PointF(159, 78), new PointF(338, 74), new PointF(156, 192) };
            counter = 4;
        }
    }
}
