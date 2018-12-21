using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeClasses
{
    public class Value:OperationClass
    {
        public double Val { get; private set; }
        public Value(double value)
        {
            Val = value;
            Priority = -3;
        }
        public override double Cacluate(ref double t)
        {
            return Val;
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return Val;
        }

    }
    public class E : OperationClass
    {
        public E()
        {
            Priority = -3;
        }
        public override double Cacluate(ref double t)
        {
            return Math.E;
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return Math.E;
        }
    }
    public class PI : OperationClass
    {
        public PI()
        {
            Priority = -3;
        }
        public override double Cacluate(ref double t)
        {
            return Math.PI;
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return Math.PI;
        }
    }
    public class Tparam : OperationClass
    {
        public Tparam()
        {
            Priority = -3;
        }
        public override double Cacluate(ref double t)
        {
            return t;
        }

        public override double Cacluate(ref double x, ref double y)
        {
            throw new NotImplementedException();
        }
    }

}
