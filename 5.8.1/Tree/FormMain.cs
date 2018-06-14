using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpaceTree
{
    public partial class FormMain : Form
    {
        bool drawing = false;
        Graphics g;
        MyTree myTree; 
        
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            int left;
            int right;
            int L = textBox1.Lines.Count();
            for (int i = 0; i < L; i++)
            {
                if (textBox1.Lines[i] != "")
                {
                    string[] s = textBox1.Lines[i].Split(',');
                    if (s[1] != ".")
                        left = Convert.ToInt32(s[1]);
                    else
                        left = -1;
                    if (s[2] != ".")
                        right = Convert.ToInt32(s[2]);
                    else
                        right = -1;
                    int k = Convert.ToInt32(s[0]);
                    myTree.Insert(ref myTree.top, k, left, right, 200, 40);
                }
            }
            MyDraw();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            g = this.CreateGraphics();
            myTree = new MyTree();
            MyTree.bitmap = new Bitmap(ClientRectangle.Width, ClientRectangle.Height);
        }

        public void MyDraw()
        {
            if (MyTree.bitmap != null)
            {
                myTree.Draw();
                g.DrawImage(MyTree.bitmap, ClientRectangle);
            }
        }
        private void FormMain_Paint(object sender, PaintEventArgs e)
        {
            MyDraw();
        }

        private void FormMain_MouseDown(object sender, MouseEventArgs e)
        {
            myTree.DeSelect(myTree.top);
            myTree.selectNode = myTree.FindNode(myTree.top, e.X, e.Y);
            drawing = myTree.selectNode != null;
            if (drawing)
                myTree.selectNode.visit = true;
        }

        private void FormMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (drawing)
                myTree.Delta(myTree.selectNode, myTree.selectNode.x - e.X, myTree.selectNode.y - e.Y);
            else
            {
                myTree.DeSelect(myTree.top);
                myTree.selectNode = myTree.FindNode(myTree.top, e.X, e.Y);
                if (myTree.selectNode != null)
                    myTree.selectNode.visit = true;
            }
            MyDraw();
        }

        private void FormMain_MouseUp(object sender, MouseEventArgs e)
        {
            drawing = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = Convert.ToString(myTree.FindMinLeaf(myTree.top));
        }
    }
}
