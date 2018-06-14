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
    public partial class FormMyCustomDialog : Form
    {
        public FormMyCustomDialog()
        {
            InitializeComponent();
        }
        private void FormMyCustomDialog_Activated(object sender, EventArgs e)
        {

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            Lib.NumNode = 0;
            textBox1.Text = "Node 4,Node 7";
            int L = Graph.Nodes.Length;
            for (int i = 0; i < L; i++)
            {
                comboBox1.Items.Add(Graph.Nodes[i].name);
                comboBox2.Items.Add(Graph.Nodes[i].name);
            }
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            //int L = checkedListBox1.CheckedItems.Count;
            //string[] s = new string[L];
            //for (int i = 0; i > L; i++)
            //{
            //  s[i] = checkedListBox1.CheckedItems[i].ToString();
            //}
            string[] s = textBox1.Text.Split(',');
            Lib.strictNodes = s;
            Lib.NumNode0 = comboBox1.SelectedIndex;
            Lib.NumNode = comboBox2.SelectedIndex;
        }
    }
}
