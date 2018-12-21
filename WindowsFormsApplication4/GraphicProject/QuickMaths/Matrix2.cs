using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication4.QuickMaths
{
    class Matrix2
    {
        private double[] matrix;
        public Matrix2(double[,] m)
        {
            matrix = new double[4];
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < 2; j++)
                    matrix[i * 2 + j] = m[i, j];
        }
        public Matrix2(double x, double y)
        {
            matrix = new double[4];
            matrix[0] = x;
            matrix[1] = 0;
            matrix[2] = 0;
            matrix[3] = y;
        }
        public double this[int r, int c]
        {
            get { return matrix[r * 2 + c]; }
            set { matrix[r * 2 + c] = value; }
        }

        public static Vector2D operator *(Matrix2 matrix, Vector2D vector)
        {
            Vector2D newvector = new Vector2D(0,0);
            for(int row = 0; row<2; row++)
            {
                    double sum = 0;
                    for(int i = 0; i<2; i++)
                    {
                        sum += matrix[row, i] * vector[i];
                    }
                    newvector[row] = sum;
            }
            return newvector;
        }
        public static Matrix2 Zero()
        {
            var m = new double[2, 2] { { 0, 0 }, { 0, 0 } };
            return new Matrix2(m);
        }
    }
}
