using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logic_1_1;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Program1 f = new Program1(openFileDialog1.FileName);
                textBoxText.Lines = f.ChangeLines(Convert.ToInt32(textBox_k.Text)).ToArray();
                openFileDialog1.Dispose();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;
                Program1.WriteToFileAllLines(path, textBoxText.Lines);
            }
        }
    }
}
