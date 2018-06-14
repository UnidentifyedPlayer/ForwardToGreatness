using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class GList
    {
        public GNode head { get; set; } 
        public int count { get; set; } 
        public GList()
        {
            head = null;
            count = 0;
        }
        public void Add(int inf) // Add
        {
            GNode p = new GNode(inf, head);
            head = p;
            count++;
        }
        public bool FindNode(int val) 
        {
            GNode p = head;
            bool ok = false;
            while ((p != null) && !ok)
            {
                ok = (p.D == val);
                if (!ok)
                    p = p.Next;
            }
            return ok;
        }
        public void Delete(int val)
        {
                GNode p = head;
            while (p.Next.D!=val)
                p = p.Next;
            if (p == head)
                head = p.Next;
            else
            p.Next = p.Next.Next;
        }
    }
}
