using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask4_3D.Math;

namespace TestTask4_3D.ThirdDimension
{
    public class PolyLine3D
    {
        public List<Vector3> points { get; private set; }
        public PolyLine3D(IList<Vector3> p, bool closed = true)
        {
            points = new List<Vector3>(p);
            if (closed)
            points.Add(points[0]);
        }
    }
}
