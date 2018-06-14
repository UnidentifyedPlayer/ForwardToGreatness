using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class Class2
    {
        public static string[] FileToString(string pathFileInput)
        {
            string s = File.ReadAllText(pathFileInput);
            string[] t = s.Split(new char[] { ',', '.', ' ', '!', '?', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            return t;
        }
        public static string GListToStr(GList list)
        {
            string s;
            s = Convert.ToString(list.head.inf)+ " - " + Convert.ToString(list.head.count);
            GNode n = list.head.next;
            while (n != null)
            {
                s += "\r\n" + Convert.ToString(n.inf) + " - " + Convert.ToString(n.count);
                n = n.next;
            }
            return s;
        }
        public static GList Sort(string[] t, string pathFileInput)
        {
            GList git = new GList();
            string[] s = FileToString(pathFileInput);
           for (int i = 0; i <= s.Length - 1; i++)
                git.AddSort(s[i]);
            return git;
        }


    }
}
