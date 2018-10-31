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

namespace TestTask4_3D
{
    public partial class ExampleForm : Form
    {
        public ExampleForm()
        {
            InitializeComponent();
            //s.Models.Add(new Models.CubeModel(new Vector3(-0.5f, 0.5f, -0.5f), new Vector3(0.7f, -0.7f, 0.7f)));
            //s.Models.Add(new Models.Line3D(new Vector3(0, 0, 0), new Vector3(1f, 0, 0)));
            //s.Models.Add(new Models.Line3D(new Vector3(0, 0, 0), new Vector3(0, 1f, 0)));
            s.Models.Add(new Models.Line3D(new Vector3(0, 0, 0), new Vector3(0, 0, 1f)));
        }

        private Scene s = new Scene();
        private Camera camera = new Camera();

        private void ExampleForm_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = s.DrawSceneImage(new ThirdDimension.Screen(Size, new RectangleF(-1f, 1f, 2f, 2f)), camera);
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
        }

        private void ExampleForm_MouseDown(object sender, MouseEventArgs e)
        {
            lastPosition = e.Location;
        }

        private void ExampleForm_MouseUp(object sender, MouseEventArgs e)
        {
            lastPosition = new Point();
        }
    }
}
