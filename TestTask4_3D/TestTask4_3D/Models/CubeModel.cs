using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestTask4_3D.Math;
using TestTask4_3D.ThirdDimension;

namespace TestTask4_3D.Models
{
    public class CubeModel : IModel
    {
        public Vector3 TLF { get; private set; }
        public Vector3 BRN { get; private set; }
        public CubeModel(Vector3 tlf, Vector3 brn)
        {
            TLF = tlf;
            BRN = brn;
        }


        public List<PolyLine3D> GetLines()
        {
            var l = new List<PolyLine3D>();
            l.Add(new PolyLine3D(new List<Vector3>() { 
                new Vector3(TLF.X, TLF.Y, TLF.Z), new Vector3(BRN.X, TLF.Y, TLF.Z), 
                new Vector3(BRN.X, BRN.Y, TLF.Z), new Vector3(TLF.X, BRN.Y, TLF.Z) }));
            l.Add(new PolyLine3D(new List<Vector3>() { 
                new Vector3(TLF.X, TLF.Y, BRN.Z), new Vector3(BRN.X, TLF.Y, BRN.Z), 
                new Vector3(BRN.X, BRN.Y, BRN.Z), new Vector3(TLF.X, BRN.Y, BRN.Z) }));
            return l;
        }
    }
}
