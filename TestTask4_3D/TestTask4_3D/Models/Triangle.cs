using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask4_3D.Math;
using TestTask4_3D.ThirdDimension;

namespace TestTask4_3D.Models
{
    public class Triangle:IModel
    {
        public  List<Vector3> Points { get; private set; }
        public Triangle(Vector3 p1, Vector3 p2, Vector3 p3)
        {
            Points = new List<Vector3> { p1, p2, p3 };
        }
        public List<PolyLine3D> GetLines()
        {
            return new List<PolyLine3D>() { new PolyLine3D( new List<Vector3>() { Points[0], Points[1], Points[2] }) };
        }

        public Vector3 Normal()
        {
            Vector3 a = Points[1] - Points[0];
            Vector3 b = Points[2] - Points[0];
            return new Vector3(a.Y * b.Z - b.Y * a.Z, a.X * b.Y - b.X * a.Y, a.Z * b.X - b.Z * a.X);
        }
        public Vector4 Plain()
        {
            Vector3 a = this.Normal();
            Vector3 b = Points[0];
            return new Vector4(a.X,a.Y,a.Z,-(b.X*a.X+ b.Y * a.Y+ b.Z * a.Z));
        }
        public static Line3D FindTrianIntersection(Triangle a, Triangle b, ref bool IsThereAnIntersection)
        {
            Vector4 secplain = b.Plain();
            Random rnd = new Random();
            float x = rnd.Next(0, 100);
            float y = rnd.Next(0, 100);
            float z = (secplain.X * x + secplain.Y * y + secplain.W) / secplain.Z;
            List <Vector3> interpoints= FindPointsInters(a.Points, secplain);
            List<Vector3> interline = new List<Vector3>();
            if (interpoints.Count == 2)
            {
                int gg = 0;
                bool[] g = new bool[2];
                g[0] = IsPointInTrian(interpoints[0], b);
                gg = (g[0]) ? gg++ : gg;
                g[1] = IsPointInTrian(interpoints[1], b);
                gg = (g[1]) ? gg++ : gg;
                AreLinesIntersect(interpoints[0], interpoints[1], b.Points[0], b.Points[1], ref interline);
                AreLinesIntersect(interpoints[0], interpoints[1], b.Points[1], b.Points[2], ref interline);
                AreLinesIntersect(interpoints[0], interpoints[1], b.Points[2], b.Points[0], ref interline);
                switch (interline.Count)
                {
                    case 1:
                        if (g[0])
                            interpoints[1] = interline[0];
                        else
                            interpoints[0] = interline[0];
                        IsThereAnIntersection = true;
                        break;
                    case 2:
                        interpoints[0] = interline[0];
                        interpoints[1] = interline[1];
                        IsThereAnIntersection = true;
                        break;
                    case 0:
                        if (gg == 0)
                            IsThereAnIntersection = false;
                        else
                            IsThereAnIntersection = true;
                        break;
                }
            }
            else if (interpoints.Count == 1)
            {
                if (IsPointInTrian(interpoints[0], b))
                    IsThereAnIntersection = true;
                else
                    IsThereAnIntersection = false;
                interpoints.Add(interpoints[0]);
            }
            else
            {
                IsThereAnIntersection = false;
                interpoints.Add(new Vector3(0, 0, 0));
                interpoints.Add(new Vector3(0, 0, 0));
            }

            return new Line3D(interpoints[0], interpoints[1]);
        }
        public static List<Vector3> FindPointsInters(List<Vector3> a, Vector4 b)
        {
            Vector3 a0;
            Vector3 a1;
            Vector3 interpoint = new Vector3();
            List<Vector3> arr = new List<Vector3>();
            bool flag = false;
            for (int i = 0; i < 3; i++)
            {
                flag = false;
                if (i == 2)
                {
                    a0 = a[2];
                    a1 = a[0];
                }
                else
                {
                    a0 = a[i];
                    a1 = a[i+1];
                }
                flag = FindPointIntersect(a0, a1, b, ref interpoint);
                float s = Math.Vector3.FindDistance(a0, a1);
                if (flag)
                {
                    if ((s >= Math.Vector3.FindDistance(a0, interpoint)) && (s >= Math.Vector3.FindDistance(a1, interpoint)))
                        arr.Add(interpoint);
                }
            }
            return arr;
        }
        public static bool FindPointIntersect(Vector3 a0, Vector3 a1, Vector4 b, ref Vector3 inter)
        {
            Vector3 a = a1 - a0;
            if ((b.X * a.X + b.Y * a.Y + b.Z * a.Z) != 0)
            {
                float k = -(b.X * a0.X + b.Y * a0.Y + b.Z * a0.Z + b.W) / (b.X * a.X + b.Y * a.Y + b.Z * a.Z);
                inter = a0 + a * k;
                return true;
            }
            else
                return false;
        }
        public static bool IsPointInTrian(Vector3 b, Triangle a)
        {
            Vector4 secplain = a.Plain();
            Vector3 a0;
            Vector3 a1;
            Random rnd = new Random();
            float x = (a.Points[0].X+ a.Points[1].X+ a.Points[2].X)/3;
            float y = (a.Points[0].Y + a.Points[1].Y + a.Points[2].Y) / 3;
            float z = (secplain.X * x + secplain.Y * y + secplain.W) / secplain.Z;
            Vector3 b1 = new Vector3(x, y, z);
            int g = 0;
            for (int i = 0; i < 3; i++)
            {
                if (i == 2)
                {
                    a0 = a.Points[2];
                    a1 = a.Points[0];
                }
                else
                {
                    a0 = a.Points[i];
                    a1 = a.Points[i+1];
                }
                if (DoesRayIntersectWithLine(a0, a1, b, b1))
                    g++;
            }
            if (g == 1)
                return true;
            else
                return false;
        }
        public static bool AreLinesIntersect(Vector3 a0, Vector3 a1, Vector3 b0, Vector3 b1, ref List<Vector3> arr)
        {
            Vector3 a = a1 - a0;
            Vector3 b = b1 - b0;
            if (!AreLineCollinear(a, b))
            {
                float k;
                if ((b.X * a.Y - b.Y * a.X) != 0)
                    k = (a.X * (b0.Y - a0.Y) - a.Y * (b0.X - a0.X)) / (b.X * a.Y - b.Y * a.X);
                else if ((b.Y * a.Z - b.Z * a.Y) != 0)
                    k = (a.Y * (b0.Z - a0.Z) - a.Z * (b0.Y - a0.Y)) / (b.Y * a.Z - b.Z * a.Y);
                else
                    return false;
                Vector3 c = b0 + k * b;
                Vector3 tv = c - a0;
                float sa = Vector3.FindDistance(a0, a1);
                float sb = Vector3.FindDistance(b0, b1);
                if (((Vector3.FindDistance(c, a1) >= sa) && (Vector3.FindDistance(a0, c) <= sa)) && ((Vector3.FindDistance(b0, c) >= sb) && (Vector3.FindDistance(b, c) < sb)))
                {
                    arr.Add(c);
                    return true;
                }
                else
                    return false;
            }
            else if (IsPointOnTheLine(a0, b0, b))
            {
                float a0b0 = Vector3.FindDistance(a0, b0);
                float a0b1 = Vector3.FindDistance(a0, (b0 + b));
                float b0b1 = Vector3.FindDistance(b0, (b0 + b));
                if ((a0b0 < a0b1) || (a0b0 < b0b1))
                {
                    arr.Add((a0b1 < b0b1) ? b1 : b0);
                }
                else
                    arr.Add(a0);
                return true;
            }
            else
                return false;

           // if (a.X != 0)
             //   t = tv.X / a.X;
        }
        public static bool DoesRayIntersectWithLine(Vector3 a0, Vector3 a1, Vector3 b0, Vector3 b1)
        {
            Vector3 a = a1 - a0;
            Vector3 b = b1 - b0;
            float k;
            if ((b.X * a.Y - b.Y * a.X) != 0)
                k = (a.X * (b0.Y - a0.Y) - a.Y * (b0.X - a0.X)) / (b.X * a.Y - b.Y * a.X);
            else if ((b.Y * a.Z - b.Z * a.Y) != 0)
                k = (a.Y * (b0.Z - a0.Z) - a.Z * (b0.Y - a0.Y)) / (b.Y * a.Z - b.Z * a.Y);
            else
                return false;
            Vector3 c = b0 + k * b;
            Vector3 tv = c - a0;
            float sb = Vector3.FindDistance(b0, b1);
            if ((Vector3.FindDistance(c, a1) <= Vector3.FindDistance(c, a0)) && (k>=0))
                return true;
            else
                return false;
        }
        public static bool AreLineCollinear(Vector3 a, Vector3 b)
        {
            float k = 0;
            bool t = false;
            for(int i = 0; i < 3; i++)
            {
                if(b[i]==0)
                {
                    if (a[i] != 0)
                    {
                        t = false;
                        break;
                    }
                }
                else
                {
                    if (!t)
                    {
                        k = a[i] / b[i];
                        t = true;
                    }
                    else
                    {
                        if ((a[i] / b[i]) != k)
                        {
                            t = false;
                            break;
                        }
                    }
                }
            }
            return t;
        }
        public static bool  IsPointOnTheLine(Vector3 a0, Vector3 b0, Vector3 b)
        {
            Vector3 v = b0 - a0;
            return (AreLineCollinear(v, b));
        }
    }
}
