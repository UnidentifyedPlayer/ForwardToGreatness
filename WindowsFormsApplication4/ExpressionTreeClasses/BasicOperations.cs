using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionTreeClasses
{
    public class BasicOperations : OperationClass
    {
        public OperationClass FirstOperand;
        public OperationClass SecondOperand;
        public override double Cacluate(ref double t)
        {
            return 0;
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return 0;
        }
    }
    public class Plus: BasicOperations
    {
        public Plus()
        {
            Priority = 3;
        }
        public override double Cacluate(ref double t)
        {
            return FirstOperand.Cacluate(ref t) + SecondOperand.Cacluate(ref t);
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return FirstOperand.Cacluate(ref x , ref y) + SecondOperand.Cacluate(ref x, ref y);
        }
    }
    public class Minus : BasicOperations
    {
        public Minus()
        {
            Priority = 3;
        }
        public override double Cacluate(ref double t)
        {
            return FirstOperand.Cacluate(ref t) - SecondOperand.Cacluate(ref t);
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return FirstOperand.Cacluate(ref x, ref y) - SecondOperand.Cacluate(ref x, ref y);
        }
    }
    public class Multiplication : BasicOperations
    {
        public Multiplication()
        {
            Priority = 2;
        }
        public override double Cacluate(ref double t)
        {
            return FirstOperand.Cacluate(ref t)* SecondOperand.Cacluate(ref t);
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return FirstOperand.Cacluate(ref x, ref y) * SecondOperand.Cacluate(ref x, ref y);
        }
    }
    public class Division : BasicOperations
    {
        public Division()
        {
            Priority = 2;
        }
        public override double Cacluate(ref double t)
        {
            return FirstOperand.Cacluate(ref t)/ SecondOperand.Cacluate(ref t);
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return FirstOperand.Cacluate(ref x, ref y)/ SecondOperand.Cacluate(ref x, ref y);
        }
    }
    public class Power : BasicOperations
    {
        public Power()
        {
            Priority = 0;
        }
        public override double Cacluate(ref double t)
        {
            return Math.Pow(FirstOperand.Cacluate(ref t), SecondOperand.Cacluate(ref t));
        }
        public override double Cacluate(ref double x, ref double y)
        {
            return Math.Pow(FirstOperand.Cacluate(ref x, ref y),SecondOperand.Cacluate(ref x, ref y));
        }
    }
}
