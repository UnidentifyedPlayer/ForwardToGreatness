﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask4_3D.ThirdDimension;

namespace TestTask4_3D.Models
{
    public class Line3D : IModel
    {
        private Math.Vector3 point1, point2;
        public bool isIntersectionLine { get; private set; }
        public Line3D(Math.Vector3 p1, Math.Vector3 p2, bool isinterline = false)
        {
            point1 = p1;
            point2 = p2;
            isIntersectionLine = isinterline;
        }
        public List<PolyLine3D> GetLines()
        {
            return new List<PolyLine3D>() { new PolyLine3D(new List<Math.Vector3>(){point1, point2}, false, isIntersectionLine) };
        }
    }
}
