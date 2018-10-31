using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask4_3D.Math;

namespace TestTask4_3D.ThirdDimension
{
    public class Camera
    {
        public Matrix4 View { get; set; }
        public Matrix4 Projection { get; set; }
        public Camera()
        {
            View = Matrix4.One();
            Projection = Matrix4.One();
        }

        public Vector3 Model2Camera(Vector3 point)
        {
            return Projection * View * ((Vector4)point);
        }
    }
}
