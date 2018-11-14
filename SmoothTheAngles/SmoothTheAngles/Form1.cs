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
        Polygon A = new Polygon();
        int radius;
        int counter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
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
                A = new Polygon(radius, counter, pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                pointsArr = new PointF[counter];
                counter = 0;

                g.Clear(Color.White);
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (A.Angles < A.TheP.Length)
            {
                A.DrawPoints(e.X, e.Y);
                g.DrawImage(A.bitmap, pictureBox1.ClientRectangle);
            }
            else
            {
                MessageBox.Show("You're done with installing coordinates,\n consider activating the drawing process");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            A.Draw();
            g.DrawImage(A.bitmap,pictureBox1.ClientRectangle);
            string s = " ";
            for (int i = 0; i < pointsArr.Length; i++)
            {
                s = s + pointsArr[i].X.ToString() + ", " + pointsArr[i].Y.ToString() + "\n";
            }
            textBox3.Text = s;
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
