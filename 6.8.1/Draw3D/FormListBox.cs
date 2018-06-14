using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Draw3D
{
    public partial class FormListBox : Form
    {
        public int fl_proc = 0;
        public FormListBox()
        {
            InitializeComponent();
        }

        long Fact(int n)
        {
            long res = 1;
            for (int i = 1; i <= n; i++)
                res *= i;
            return res;
        }

        private void FormListBox_Activated(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            switch (fl_proc)
            {
                case 0:
                    Text = "";
                    long n, m, k = Fact(Graph.Nodes.Length);
                    progressBar1.Maximum = (int)k;

                    n = DateTime.Now.Ticks;

                    Lib.graph.Gamilton(listBox1.Items);

                    int min = int.MaxValue;
                    for (int i = 0; i < Lib.pathsGam.Count; i++)
                        if (min > Lib.pathsGam[i].sum)
                            min = Lib.pathsGam[i].sum;
                    m = DateTime.Now.Ticks;
                    int d = (int)((m - n) / 1); //00000);

                    Text = "min = " + min + " Time = " + d.ToString() + " n = " + listBox1.Items.Count;
                    break;
                case 1:
                    Text = "Минимальные расстояния";
                    Lib.graph.MinDist0(0);
                    for (int v = 0; v < Graph.Nodes.Length; v++)
                        listBox1.Items.Add("0 => " + Convert.ToString(v) + ':' +
                            Convert.ToString(Graph.Nodes[v].dist));
                    break;
                case 2:
                    Text = "Минимальные расстояния Форда-Беллмана";
                    Lib.graph.Bellmann(0);
                    int N = Graph.Nodes.Length;
                    string s;
                    for (int i = 0; i < N; i++)
                    {
                        if (Graph.Nodes[i].dist == 0xFFFFFF)
                            s = "No path";
                        else
                            s = Convert.ToString(Graph.Nodes[i].dist);
                        s = Convert.ToString(i) + " " + s;
                        listBox1.Items.Add(s);
                    }
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
