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
    public partial class FormProperty : Form
    {
        public FormProperty()
        {
            InitializeComponent();
        }

        private void FormProperty_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Name", "Name");
            dataGridView1.Columns["Name"].Width = 130;

            dataGridView1.Columns.Add("Вес", "Вес");
            dataGridView1.Columns["Вес"].Width = 50;

            dataGridView1.AllowUserToAddRows = false; //нет новой строки
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            int L = Graph.SelectNode.Edge.Length;
            for (int i = 0; i < L; i++)
                Graph.SelectNode.Edge[i].A = Convert.ToInt32(dataGridView1[1, i].Value);
            Graph.SelectNode.name = textBox1.Text;
        }

        private void FormProperty_Activated(object sender, EventArgs e)
        {
            int L = Graph.SelectNode.Edge.Length;
            dataGridView1.RowCount = L;
            for (int i = 0; i < L; i++)
            {
                dataGridView1[0, i].Value = Graph.Nodes[Graph.SelectNode.Edge[i].numNode].name;
                dataGridView1[1, i].Value = Graph.SelectNode.Edge[i].A;
            }
            textBox1.Text = Graph.SelectNode.name;
        }
    }
}
