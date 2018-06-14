using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Logic_1_1
{
    public class Program1
    {
        public string InputFile { get; set; }
        public string[] Lines { get; set; }
        public Program1(string inputFile)
        {
            InputFile = inputFile;
            Lines = File.ReadAllLines(inputFile, Encoding.Default);
        }
        public static void WriteToFileAllLines(string name_file, string[] lines)
        {
            File.WriteAllLines(name_file, lines);
        }
        public List<string> ChangeLines(int k)
        {
            
            List<string> resuitsLines = new List<string>(Lines);
            int y = resuitsLines.Count;
            for (int i = 0; i < y - k; i++)
            {
                resuitsLines.Remove(resuitsLines[0]);
            }
            return resuitsLines;
        }
    }
}
