using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class GNode
    {
        public string inf;
        public GNode next;
        public int count;
        public GNode(string inf, GNode next)
        {
            this.inf = inf;
            this.next = next;
            this.count = 1;
        }
        public void AddCount()
        { count++; }

    }
    public class GList
    {
        public GNode head;        
        public int count;         
        public GList()
        {
            head = null;
            count = 0;
        }

        public void Add(string inf)
        {
            GNode p = new GNode(inf, head);
            head = p;
            count++;
        }

        public string[] Printer()
        {
            string[] st = new string[0];
            int L = 0;
            GNode p = head;
            if (p != null)
                do
                {
                    Array.Resize<string>(ref st, ++L);
                    st[L - 1] = p.inf.ToString();
                    p = p.next;
                }
                while (p != null);
            return st;
        }

    public GNode FindNode(string val)
        {
            GNode p = head;
            bool ok = false;
            while ((p != null) && !ok)
            {
                ok = p.inf == val;
                if (!ok)
                    p = p.next;
            }
            return p;
        }

        public void Delete(int index)
        {
            if (index != 0)
            {
                GNode p = head;
                for (int i = 0; i < index - 1; i++)
                    p = p.next;
                if (p.next != null)
                    p.next = p.next.next;
            }
            else
                head = head.next;
            count--;
        }
        public void AddSort(string inf)
        {
            if (head != null)
            {
                GNode q = head;
                int k = string.CompareOrdinal(inf, q.inf);
                // -1:s1<s2 0:s1=s2 1:s1>s2
                if (k <= 0)
                    if (k == 0)
                        q.AddCount();
                    else
                    { // вставить перед головой
                        GNode p = new GNode(inf, q);
                        head = p;
                    }
                else
                {
                    GNode r; // поиск: inf >= q.inf
                    do
                    {
                        r = q;
                        q = q.next;
                        if (q != null)
                            k = string.CompareOrdinal(q.inf, inf);
                    }
                    while ((q != null) && (k < 0));

                    if (q != null)
                        if (k == 0)
                            q.AddCount();
                        else
                        {  // вставить между r и q
                            GNode p = new GNode(inf, q);
                            r.next = p;
                        }
                    else
                    {      // вставить за r
                        GNode p = new GNode(inf, null);
                        r.next = p;
                    }
                }
            }
            else  // список пуст
                head = new GNode(inf, null);
            count++;
        }

}

}
