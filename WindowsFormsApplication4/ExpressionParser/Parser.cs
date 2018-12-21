using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using ExpressionTreeClasses;

namespace ExpressionParser
{
    public class ParsedExp
    {
        private int l;
        private string expression;

        private const string digits = @"^\s*-?\d+\,?\d*";
        private const string cos = @"^\s*cos\s*\(";
        private const string sin = @"^\s*sin\s*\(";
        private const string tangent = @"^\s*tg\s*\(";
        private const string multipl = @"^\s*\*";
        private const string divide = @"^\s*\/";
        private const string plus = @"^\s*\+";
        private const string minus = @"^\s*\-";
        private const string openingbracket = @"^\s*\(\s*";
        private const string closingbracket = @"^\s*\)\s*";
        private const string power = @"^\s*\^\s*";
        private const string e = @"^\s*e\s*";
        private const string pi = @"^\s*pi\s*";
        private const string t = @"^\s*t\s*";
        public ParsedExp()
        {
            l = 0;
        }

        public void InsertExpression(string expression)
        {
            this.expression = expression;
        }
        public OperationClass ExpTree()
        {
            l = 0;
            OperationClass a = new Minus();
            return Parse(ref a);
        }
        public OperationClass Parse(ref OperationClass a)
        { 
            bool isExpressionNotEnded = true;
            while ((l < expression.Length)&&isExpressionNotEnded)
            {
                ParseNextPart(ref a, ref isExpressionNotEnded);
                    }
                return a;
        }
        private void ParseNextPart(ref OperationClass a, ref bool isExpressionNotEnded)
        {
            if (l < expression.Length)
            {
                string s = expression.Substring(l);
                if (Regex.IsMatch(s, digits, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, digits, RegexOptions.IgnoreCase);
                    s = s.Substring(0, digit.Length);
                    a = new Value(float.Parse(s));
                    l += digit.Length;
                }
            else if (Regex.IsMatch(s, cos, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, cos, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    OperationClass b = new Value(0);
                    Parse(ref b);
                    a = new Cosinus(b);
                }
                else if (Regex.IsMatch(s, sin, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, sin, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    OperationClass b = new Value(0);
                    Parse(ref b);
                    a = new Sinus(b);
                }
                else if (Regex.IsMatch(s, tangent, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, tangent, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    OperationClass b = new Value(0);
                    Parse(ref b);
                    a = new Tangent(b);
                }
                else if (Regex.IsMatch(s, plus, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, plus, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    Plus b = new Plus();
                    b.FirstOperand = a;
                    ParseNextPart(ref b.SecondOperand, ref isExpressionNotEnded);
                    a = b;
                }
                else if (Regex.IsMatch(s, minus, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, minus, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    Minus b = new Minus();
                    b.FirstOperand = a;
                    ParseNextPart( ref b.SecondOperand, ref isExpressionNotEnded);
                    a = b;
                }
                else if (Regex.IsMatch(s, multipl, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, multipl, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    Multiplication b = new Multiplication();
                    ParseNextPart(ref b.SecondOperand, ref isExpressionNotEnded);
                    if (a.Priority > 2)
                    {
                        BasicOperations buff = a as BasicOperations;
                        b.FirstOperand = buff.SecondOperand;
                        buff.SecondOperand = b;
                        a = buff;
                    }
                    else
                    {
                        b.FirstOperand = a;
                        a = b;
                    }
                }
                else if (Regex.IsMatch(s, divide, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, divide, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    Division b = new Division();
                    ParseNextPart(ref b.SecondOperand, ref isExpressionNotEnded);
                    if (a.Priority > 2)
                    {
                        BasicOperations buff = a as BasicOperations;
                        b.FirstOperand = buff.SecondOperand;
                        buff.SecondOperand = b;
                        a = buff;
                    }
                    else
                    {
                        b.FirstOperand = a;
                        a = b;
                    }
                }
                else if(Regex.IsMatch(s, power, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, power, RegexOptions.IgnoreCase);
                        l += digit.Length;
                    Power b = new Power();
                    ParseNextPart(ref b.SecondOperand, ref isExpressionNotEnded);
                    if (a.Priority == -3)
                    {
                        b.FirstOperand = a;
                        a = b;
                    }
                    //BasicOperations buff = a as BasicOperations;
                    //b.FirstOperand = buff.SecondOperand;
                    //buff.SecondOperand = b;
                    //a = buff;
                }
                else if(Regex.IsMatch(s, e, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, e, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    a = new E();
                }
                else if (Regex.IsMatch(s, pi, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, pi, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    a = new PI();
                }
                else if(Regex.IsMatch(s, openingbracket, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, openingbracket, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    Parse(ref a);
                }
                else if (Regex.IsMatch(s, closingbracket, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, closingbracket, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    if(Regex.IsMatch(s, power, RegexOptions.IgnoreCase))
                    {
                        digit = Regex.Match(s, power, RegexOptions.IgnoreCase);
                        l += digit.Length;
                        Power b = new Power();
                        ParseNextPart(ref b.SecondOperand, ref isExpressionNotEnded);
                        b.FirstOperand = a;
                        a = b;
                    }
                    isExpressionNotEnded = false;
                }
                else if (Regex.IsMatch(s, t, RegexOptions.IgnoreCase))
                {
                    Match digit = Regex.Match(s, t, RegexOptions.IgnoreCase);
                    l += digit.Length;
                    a = new Tparam();
                }
            }
            else
            {
                isExpressionNotEnded = false;
            }
        }

        //public static int IsThereAMatch(string expression, ref OperationClass a)
        //{
        //    if (Regex.IsMatch(expression, digits, RegexOptions.IgnoreCase))
        //    {

        //    }
        //        return 1;
        //    else if (Regex.IsMatch(expression, cos, RegexOptions.IgnoreCase))
        //        return 2;
        //    else if (Regex.IsMatch(expression, cos, RegexOptions.IgnoreCase))
        //        return 3;
        //}
    }
}
