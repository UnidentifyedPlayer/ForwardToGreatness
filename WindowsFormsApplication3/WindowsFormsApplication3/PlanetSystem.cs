using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApplication3
{
    class PlanetSystem
    {
        public List<Planet> planets = new List<Planet>();
        public Vector SunPosition;
        public float SunRad;
        public Bitmap DrawSystem(Size z)
        {
            Bitmap btm = new Bitmap(z.Width, z.Height);
            Graphics g = Graphics.FromImage(btm);
            g.DrawEllipse(Pens.Black, (float)SunPosition.x - SunRad, (float)SunPosition.y - SunRad, 2 * SunRad, 2 * SunRad);
            foreach(Planet p in planets)
            {
                g.DrawEllipse(Pens.Black, (float)(p.EllipseCenter.x - p.a), (float)(p.EllipseCenter.y - p.b), (float)(2 * p.a), (float)(2 * p.b));
                g.DrawEllipse(Pens.Black, (float)(p.curCoordPosition.x - p.radius), (float)(p.curCoordPosition.y - p.radius), (float)(2 * p.radius), (float)(2 * p.radius));
            }
            g.Dispose();
            return btm;
        }
        public void Tick()
        {
            foreach (Planet p in planets)
            {
                p.Tick();
            }
        }
    }
}
