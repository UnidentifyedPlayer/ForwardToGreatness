using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ClassLibrary1
{
    public class Class3
    {
        public static GList StrToMyList(string str)
        {
            GList list = new GList();
            string[] arr = str.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                list.Add(Convert.ToInt32(arr[i]));
            }
            return list;
        }
        public static string MyListToStr(GList list)
        {
            string s;
            s = Convert.ToString(list.head.D);
            GNode n = list.head.Next;
            while (n != null)
            {
                s += "\r\n" + Convert.ToString(n.D);
                n = n.Next;
            }
            return s;
        }
        public static string FileToString(string pathFileInput)
        {
            string s = File.ReadAllText(pathFileInput);
            return s;
        }
        public static void WriteToFileAll(string name_file, string s)
        {
            File.WriteAllText(name_file, s);
        }
    }
}
