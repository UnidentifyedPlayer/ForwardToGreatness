using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication3
{
    public class Vector
    {
        public double x;
        public double y;
            public Vector(double x, double y)
        {
            this.x = x;
            this.y = y; 
        }
        public Vector(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
