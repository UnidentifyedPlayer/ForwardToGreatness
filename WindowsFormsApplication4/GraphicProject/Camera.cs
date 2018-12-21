using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication4.QuickMaths;

namespace WindowsFormsApplication4
{
    class Camera
    {
        Matrix4 CameraDirection;
        Vector4 CameraPosition;
        public Camera()
        {
            CameraPosition = new Vector4(0, 0, -10);
            CameraDirection = Matrix4.One();
        }
        public void RotateCamera(float dx, float dy)
        {
            CameraDirection = Matrix4.CreateRotationMatrix(0, dx) * Matrix4.CreateRotationMatrix(1, dy) * CameraDirection;
            Vector4 DirectionVector = new Vector4(CameraDirection[2, 0], CameraDirection[2, 1], CameraDirection[2, 2]);
            CameraPosition = DirectionVector * (10 / DirectionVector.Length());
        }
        public Matrix4 ViewMatrix()
        {
            Matrix4 CamPos = Matrix4.One();
            CamPos[0, 3] = -CameraPosition[0];
            CamPos[1, 3] = -CameraPosition[1];
            CamPos[2, 3] = -CameraPosition[2];
            return CameraDirection * CamPos;
        }

    }
}
