﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TestTask4_3D.ThirdDimension
{
    public class Scene
    {
        public List<IModel> Models = new List<IModel>();
        public Bitmap DrawSceneImage(Screen s, Camera c)
        {
            Bitmap bmp = new Bitmap(s.Size.Width, s.Size.Height);
            Graphics g = Graphics.FromImage(bmp);
            List<PolyLine3D> lines = new List<PolyLine3D>();
            foreach (var m in Models)
                foreach (var pl in m.GetLines())
                {
                    var p = new PolyLine3D(pl.points.ConvertAll(a => c.Model2Camera(a)), false);
                    lines.Add(p);
                }
            lines.Sort(new Comparison<PolyLine3D>((a, b) => { return (int)(a.points.Average(x => x.Z) - b.points.Average(x => x.Z)); }));
            foreach (var l in lines)
            {
                var p = l.points.ConvertAll(a => s.Real2Screen(new PointF(a.X, a.Y))).ToArray();
                g.DrawLines(Pens.Black, p);
            }

            lines.Clear();
            g.Dispose();
            return bmp;
        }
    }
}
