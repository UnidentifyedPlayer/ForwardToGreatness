using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary1;

namespace WindowsFormsApplication4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Class1 g = new Class1(openFileDialog1.FileName);
                textBox1.Text = Class1.ToStr(g.SortBublInc());
                openFileDialog1.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Class1 g = new Class1(openFileDialog1.FileName);
                textBox1.Text = Class1.ToStr(g.SortBublDec());
                openFileDialog1.Dispose();
            }
        }
    }
}
