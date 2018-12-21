using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TestTask4_3D.ThirdDimension;
using TestTask4_3D.Math;
using TestTask4_3D.Models;

namespace TestTask4_3D
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
            //s.Models.Add(new Models.CubeModel(new Vector3(0, 0, 0), new Vector3(1.7f, 1.7f, 1f)));
            //Random rnd
            s.Models.Add(new Models.Line3D(new Vector3(0, 0, 0), new Vector3(10f, 0, 0)));
            s.Models.Add(new Models.Line3D(new Vector3(0, 0, 0), new Vector3(0, 10f, 0)));
            s.Models.Add(new Models.Line3D(new Vector3(0, 0, 0), new Vector3(0, 0, 10f)));
            s.a = new Models.Triangle(new Vector3(1f, 0f, 0f), new Vector3(0f, 1f, 0f), new Vector3(0.5f, 0.5f, 1f));
            s.b = new Models.Triangle(new Vector3(1.5f, 2f, 0.25f), new Vector3(0f, 0.5f, 0.25f), new Vector3(0.8f, 0.3f, 1.25f));
            for(int i = 0; i<3; i++)
            {
                dataGridView1.Rows.Add();
                for(int z = 0; z<3; z++)
                {
                    dataGridView1[z,i].Value = s.a.Points[i].values[z];
                    dataGridView1[z+3,i].Value = s.b.Points[i].values[z];
                }
            }
        }

        private Scene s = new Scene();
        private Camera camera = new Camera();
        private float squareside = 2f;

        private void ExampleForm_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            Bitmap bmp = s.DrawSceneImage(new ThirdDimension.Screen((Size.Width-305), Size.Height, new RectangleF(-(squareside/2), (squareside / 2), squareside, squareside)), camera);
            e.Graphics.DrawImage(bmp, 0, 0);
            bmp.Dispose();
        }

        private void ExampleForm_MouseClick(object sender, MouseEventArgs e)
        {
        }
        Point lastPosition = new Point();
        private void ExampleForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && !lastPosition.IsEmpty)
            {
                Point dp = new Point(e.X - lastPosition.X, e.Y - lastPosition.Y);
                float alpha = dp.X * (float)System.Math.PI / 180f;
                float betta = dp.Y * (float)System.Math.PI / 180f;
                camera.View = Matrix4.CreateRotationMatrix(0, betta) * Matrix4.CreateRotationMatrix(2, alpha) * camera.View;
                lastPosition = e.Location;
                Invalidate();
            }
            else
            {
                Text = "X = " + e.X + " Y = " + e.Y; ;
            }
        }

        private void ExampleForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPosition = e.Location;
        }

        private void ExampleForm_MouseUp(object sender, MouseEventArgs e)
        {
            lastPosition = new Point();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int z = 0; z < 3; z++)
                {
                    s.a.Points[i].values[z] = float.Parse(dataGridView1[z, i].Value.ToString());
                    s.b.Points[i].values[z] = float.Parse(dataGridView1[z + 3, i].Value.ToString());
                }
            }
            Invalidate();

            //Triangle a = new Triangle();
        }

        private void ExampleForm_MouseWheel(object sender, MouseEventArgs e)
        {
            bool isZoomingIn = System.Math.Sign(e.Delta)>0;
            squareside = (isZoomingIn) ? (squareside / 1.25f) : (squareside * 1.25f);
            Invalidate();
        }
    }
}
