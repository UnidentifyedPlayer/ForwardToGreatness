using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.QuickMaths
{
    class Vector2D
    {
        public double[] values;
        public Vector2D(double x, double y)
        {
            values = new double[2];
            values[0] = x; values[1] = y;
        }
        public Vector2D()
        {
            values = new double[2];
            values[0] = 0; values[1] = 0;
        }
        public double X { get { return values[0]; } set { values[0] = value; } }
        public double Y { get { return values[1]; } set { values[1] = value; } }
        public double this[int idx]
        {
            get { return values[idx]; }
            set { values[idx] = value; }
        }
        public static double Distance(Vector2D v1, Vector2D v2)
        {
            return Math.Sqrt(Math.Pow(v2.X - v1.X, 2) + Math.Pow(v2.Y - v1.Y, 2));
        }
    }
}
