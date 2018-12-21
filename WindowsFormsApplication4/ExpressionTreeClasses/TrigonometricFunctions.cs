using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeClasses
{
    public class Sinus:OperationClass
    {
        public OperationClass Argument;
        public override double Cacluate(ref double t)
        {
            return Math.Sin(Argument.Cacluate(ref t));
        }
        public override double Cacluate(ref double x , ref double y)
        {
            return Math.Sin(Argument.Cacluate(ref x, ref y));
        }
        public Sinus(OperationClass a)
        {
            Priority = 1;
            Argument = a;
        }
    }
    public class Cosinus : OperationClass
    {
        public OperationClass Argument;
        public override double Cacluate(ref double t)
        {
            return Math.Cos(Argument.Cacluate(ref t));
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return Math.Cos(Argument.Cacluate(ref x, ref y));
        }
        public Cosinus(OperationClass a)
        {
            Priority = 1;
            Argument = a;
        }
    }
    public class Tangent : OperationClass
    {
        public OperationClass Argument;
        public override double Cacluate(ref  double t)
        {
            return Math.Tan(Argument.Cacluate(ref t));
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return Math.Tan(Argument.Cacluate(ref x, ref y));
        }
        public Tangent(OperationClass a)
        {
            Priority = 1;
            Argument = a;
        }
    }

}
