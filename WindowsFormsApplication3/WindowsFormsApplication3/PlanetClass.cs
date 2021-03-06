﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication3
{
    public class Planet
    {
         public List<Planet> sputniks;
        public double a;
        public double b;
        public Vector EllipseCenter;
        public double curPosition;
        public Vector curCoordPosition;
        public double inclination;
        public double incltan;
        public double step;
        public double radius;
        public double viewDistance;
        public Color color;
        public Planet(double aphel, double perih, double speed, double inclin, double eccentricity, Vector SunPosition, double planetRadius, double viewDist, Color col)
        {
            sputniks = new List<Planet>(1);
            curPosition = 0;
            a = (aphel + perih)/2;
            b = a * Math.Sqrt(1 - Math.Pow(eccentricity,2));
            double fromSunToCenter = a - perih;
            EllipseCenter = new Vector(SunPosition.x + fromSunToCenter, SunPosition.y);
            inclination = Math.PI*inclin/180;
            double length = Math.PI * (a + b); //длина эллипса в пикселях при условии, что 1 пиксель ~ 0.026 см
            step = 2 * Math.PI / (length/speed);
            curCoordPosition = new Vector(EllipseCenter.x + a * Math.Cos(curPosition), EllipseCenter.y + b * Math.Sin(curPosition));
            radius = planetRadius;
            incltan = Math.Tan(inclination);
            double dz = a * Math.Tan(inclination);
            double k = (viewDist+dz) / radius;
            radius = viewDist / k;
            viewDistance = viewDist;
            color = col;
        }
        public virtual void Tick()
        {
            curPosition += step;
            double priorx = curCoordPosition.x;
            double priory = curCoordPosition.y;
            curCoordPosition.x = EllipseCenter.x + a * Math.Cos(curPosition);
            curCoordPosition.y = EllipseCenter.y + b * Math.Sin(curPosition);
            double dz = (curCoordPosition.x - EllipseCenter.x) * incltan/100;
            double k = (viewDistance - dz) / radius;
            radius = (viewDistance / k);
            if(sputniks.Count!=0)
                foreach (Planet a in sputniks)
                {
                    a.EllipseCenter.x = a.EllipseCenter.x+(curCoordPosition.x - priorx);
                    a.EllipseCenter.y = a.EllipseCenter.y + (curCoordPosition.y - priory);
                    a.Tick();
                }
        }
    }
}
