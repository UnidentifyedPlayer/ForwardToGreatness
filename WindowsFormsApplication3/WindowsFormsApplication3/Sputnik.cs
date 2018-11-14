using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication3
{
    public class Sputnik : Planet
    {
        public Sputnik(double aphel, double perih, double speed, double inclin, double eccentricity, Vector SunPosition, double planetRadius, double viewDist, Color col) : base(aphel, perih, speed, inclin, eccentricity, SunPosition, planetRadius, viewDist, col)
        {

        }
        public void Tick()
        {
            curPosition += step;
            curCoordPosition.x = EllipseCenter.x + a * Math.Cos(curPosition);
            curCoordPosition.y = EllipseCenter.y + b * Math.Sin(curPosition);
            double dz = (curCoordPosition.x - EllipseCenter.x) * incltan / 100;
            double k = (viewDistance - dz) / radius;
            radius = (viewDistance / k);
        }

    }
}
