using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestTask4_3D.Math
{
    public struct Vector3
    {
        public float[] values;
        public Vector3(float x, float y, float z)
        {
            values = new float[3];
            values[0] = x; values[1] = y; values[2] = z;
        }
        public float X { get { return values[0]; } set { values[0] = value; } }
        public float Y { get { return values[1]; } set { values[1] = value; } }
        public float Z { get { return values[2]; } set { values[2] = value; } }
        public float this[int idx]
        {
            get { return values[idx]; }
            set { values[idx] = value; }
        }
        public static implicit operator Vector3(Vector4 v)
        {
            return v.W == 0 ? new Vector3(v.X, v.Y, v.Z) : new Vector3(v.X / v.W, v.Y / v.W, v.Z / v.W);
        }
        public static Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }
        public static Vector3 operator *(Vector3 a, float b)
        {
            return new Vector3(b * a.X, b * a.Y, b * a.Z);
        }
        public static Vector3 operator *(float b , Vector3 a)
        {
            return new Vector3(b * a.X, b * a.Y, b * a.Z);
        }
        public static Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }
        public static float FindDistance(Vector3 a, Vector3 b)
        {
            return (float)System.Math.Sqrt(System.Math.Pow(a.X - b.X, 2) + System.Math.Pow(a.Y - b.Y, 2) + System.Math.Pow(a.Z - b.Z, 2));
        }
    }
}
