using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logic_1_1
{
    public class Class2
    {
        public string FileName { get; set; }
        public double[] Numbers { get; set; }
        public Class2(string inputFile)
        {
            FileName = inputFile;
            string str = File.ReadAllText(inputFile);
            string[] tr = str.Split(new char[] { ' ', '.' }, StringSplitOptions.RemoveEmptyEntries);
            double[] lul = new double[tr.Length]; 
            for(int i = 0; i < tr.Length; i++)
            {
                lul[i] = Double.Parse(tr[i]);
            }
            Numbers = lul;
        }

        public int[] CountExtremums()
        {
            int[] yayness = new int[2];
            yayness[0] = 0;
            yayness[1] = 0;
            for (int i = 1; i< Numbers.Length-1; i++)
            {
                if((Numbers[i-1] > Numbers[i])&&(Numbers[i + 1] > Numbers[i]))
                    yayness[0]++;
                if ((Numbers[i - 1] < Numbers[i]) && (Numbers[i + 1] < Numbers[i]))
                    yayness[1]++;
            }
            return yayness;
        }
    }
}
