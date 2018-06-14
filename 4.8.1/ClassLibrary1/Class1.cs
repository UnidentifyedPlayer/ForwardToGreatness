using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class Class1
    {
        public string InputFile { get; set; }
        public double[] Numbers { get; set; }
        public Class1(string inputFile)
        {
            InputFile = inputFile;
            string str = File.ReadAllText(inputFile);
            string[] arr = str.Split(new char[] { '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            double[] a = new double[arr.Length];
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                a[i] = Convert.ToDouble(arr[i]);
            }
            Numbers = a;
        }
        public static void WriteToFileAllLines(string name_file, string[] lines)
        {
            File.WriteAllLines(name_file, lines);
        }
        public double[] SortBublInc()
        {
            double[] numbers = Numbers;
            int N = numbers.Length;
            for (int i = 1; i <= N - 1; i++)
                for (int j = N - 1; j >= i; j--)
                    if (numbers[j - 1] > numbers[j])
                    {
                        double t = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = t;
                    }
            return numbers;
        }
        public double[] SortBublDec()
        {
            double[] numbers = Numbers;
            int N = numbers.Length;
            for (int i = 1; i <= N - 1; i++)
                for (int j = N - 1; j >= i; j--)
                    if (numbers[j - 1] < numbers[j])
                    {
                        double t = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = t;
                    }
            return numbers;
        }
        public static string ToStr(double[] a)
        {
            string s = Convert.ToString(a[0]) +"\r\n";
            for(int i = 1; i<a.Length; i++)
            {
                s = s + Convert.ToString(a[i]) + "\r\n";
            }
            return s;
        }

    }
}
