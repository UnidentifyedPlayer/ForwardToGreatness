using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logic_1_1;

namespace WindowsFormsApplication2
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
                    if (openFileDialog1.OpenFile() != null)
                    {
                        Class2 i = new Class2(openFileDialog1.FileName);
                        int[] u = i.CountExtremums();
                        textBox1.Text = "Кол-во локальных минимумов: " + u[0].ToString() + "\nКол-во локальных максимумов: "
                            + u[1].ToString() + "\nКол-во локальных экстремумов" + (u[1] + u[0]).ToString();

                    }
            }
        }
    }
}
