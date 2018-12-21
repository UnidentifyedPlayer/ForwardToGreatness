using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeClasses
{
    public enum Operation
    {
        Value = 0,
        Variable = 1,
        Plus = 2,
        Minus = 3,
        Multiplication = 4,
        Division = 5,
        Sinus = 6,
        Cosinus = 7,
        Tangent = 8,
    }
    public abstract class OperationClass
    {
        public int Priority { get;protected set;}
        abstract public double Cacluate(ref double t);
        abstract public double Cacluate(ref double x, ref double y);
    }
}
