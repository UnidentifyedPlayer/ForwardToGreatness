using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class GNode
    {
        public double D { get; set; }
        public GNode Next { get; set; }
   
        public GNode(double d, GNode next)    // Конструктор
        {
            this.D = d;
            this.Next = next;
        }
       

    }
}
