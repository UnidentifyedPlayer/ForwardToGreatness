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

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GList g = Class3.StrToMyList(textBox2.Text);
            int k = Convert.ToInt32(textBox1.Text);
            if (g.FindNode(k))
            {
                g.Delete(k);
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    Class3.WriteToFileAll(saveFileDialog1.FileName, Class3.MyListToStr(g));
                }
            }
            else
                MessageBox.Show("Такого элемента нет в списке");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string s = Class3.FileToString(openFileDialog1.FileName);
                GList g = Class3.StrToMyList(s);
                textBox2.Text = s;
                openFileDialog1.Dispose();
            }
        }
    }
}
