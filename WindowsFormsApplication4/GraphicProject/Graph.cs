using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpressionParser;
using ExpressionTreeClasses;

namespace WindowsFormsApplication4
{
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
            pictureBox1.Invalidate();
            drawfuncset = false;
            pictureBox1.Image =
                new Bitmap(pictureBox1.Width,
                    pictureBox1.Height);
            DrawMan = new TheDrawer();
            camera = new Camera();
            DrawMode = 1;
            Graphcolshow.BackColor = Color.Black;
            Backcolshow.BackColor = Color.White;
            Axiscolshow.BackColor = Color.Black;
            radioButton1.Checked = true;
        }
        Transition Transitor = new Transition(new RectangleF(-2f, 1f, 3f, 2f));
        Point LastPosition = new Point();
        Graphics g;
        TheDrawer DrawMan;
        Camera camera;
        Bitmap Bitt;
        int DrawMode;
        bool drawfuncset;
        bool gel;
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DoubleBuffered = true;
            if (drawfuncset)
            {
                Bitt = new Bitmap(pictureBox1.Width, pictureBox1.Height);
                DrawMan.Draw(Transitor, camera, Graphics.FromImage(Bitt));
                pictureBox1.Image = Bitt;
            }
            //DoubleBuffered = true;
            //Transitor.WindowChange(pictureBox1.Size);
            //pictureBox1.Image =
            //        new Bitmap(pictureBox1.Width,
            //            pictureBox1.Height);
            //if (drawfuncset)
            //{
            //    DrawMan.DrawTwoDimensionalFunc(Transitor, Graphics.FromImage(pictureBox1.Image));
            //}
            //else
            //{
            //    //Bitmap btm = TheDrawer.DrawMandelbrot(Transitor);
            //    g = pictureBox1.CreateGraphics();
            //    g.Clear(Color.White);
            //    g.DrawEllipse(Pens.Black, new RectangleF((float)Transitor.Wx(-1f), (float)Transitor.Wy(-1f), (float)(Transitor.Wx(1f) - Transitor.Wx(-1f)), (float)(Transitor.Wy(1f) - Transitor.Wy(-1f))));
            //    // e.Graphics.DrawImage(btm, 0, 0);
            //    //btm.Dispose();
            //}
        }

        private void Graph_ResizeEnd(object sender, EventArgs e)
        {
            Transitor.WindowChange(pictureBox1.Size);
            Invalidate();
        }
        private void ExampleForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
                Transitor.ZoomIn(e.X, e.Y);
            else
                Transitor.ZoomOut(e.X, e.Y);
            widthnum.Text = Transitor.Region.Width.ToString();
            heightnum.Text = Transitor.Region.Height.ToString();
            Invalidate();
        }

        private void Graph_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Right) && drawfuncset && (DrawMode == 1))
            {
                Bitt = new Bitmap(pictureBox1.Image);
                    if (true)
                {
                    //DrawMan.FindCorrelation(e.X,e.Y, Transitor, Graphics.FromImage(pictureBox1.Image));
                    DrawMan.FindCorrelation(e.X, e.Y, Transitor, ref Bitt);
                    pictureBox1.Image = Bitt;
                    //col.A == DrawMan.GraphColor.A && col.R == DrawMan.GraphColor.R && col.G == DrawMan.GraphColor.G && col.A == DrawMan.GraphColor.B
                }
            }
            LastPosition = e.Location;
        }

        private void Graph_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && !LastPosition.IsEmpty)
            {
                Point Delta = new Point(e.X - LastPosition.X, e.Y - LastPosition.Y);
                Transitor.PaperMoved(Delta);
                LastPosition = e.Location;
                Invalidate();
            }
            if (e.Button.HasFlag(MouseButtons.Right) && drawfuncset&&(DrawMode == 1))
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawfuncset = true;
            switch (DrawMode)
            {
                case 1:
                    DrawMan.SetTwoDimenDrawer(xTextBox.Text, yTextBox.Text, lowerTboundTextBox.Text, upperTboundTextBox.Text);
                    break;
                case 2:
                    DrawMan.SetTwoDimenComplexDrawer(xTextBox.Text, yTextBox.Text, xctextBox1.Text, yctextBox2.Text);
                    break;
                case 3:
                    DrawMan.SetThreeDimenDrawer(textBox3.Text, lowerTboundTextBox.Text, upperTboundTextBox.Text, xctextBox1.Text, yctextBox2.Text);
                    break;
            }
            Invalidate();
        }

        private void Graph_Resize(object sender, EventArgs e)
        {
            panel1.Location = new Point(Size.Width - panel1.Width - 7, 0);
            panel1.Height = Size.Height-40;
            pictureBox1.Size = new Size(Size.Width - panel1.Width - 7, Size.Height - 38);
            Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void Graph_Load(object sender, EventArgs e)
        {

            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton but = (RadioButton)sender;
            if (but.Checked)
            {
                int newm = Convert.ToInt32(but.Tag);
                    if (DrawMode == 3)
                    {
                        textBox3.Visible = false;
                        label5.Visible = false;
                        yctextBox2.Visible = false;
                        yclabel.Visible = false;
                        xctextBox1.Visible = false;
                        xclabel.Visible = false;
                    }
                    if(DrawMode == 1)
                {
                    upperTbound.Visible = false;
                    lowerTbound.Visible = false;

                }
                    if (newm == 2)
                {
                    xclabel.Visible = true;
                    yclabel.Visible = true;
                    label1.Text = "x0";
                    label2.Text = "y0";
                    xclabel.Text = "xc";
                    yclabel.Text = "yc";
                    numericUpDown1.Maximum = 200;
                    numericUpDown1.Value = 50;
                }
                    if(newm == 1)
                {
                    label1.Text = "x(t)";
                    label2.Text = "y(t)";
                    xclabel.Visible = false;
                    yclabel.Visible = false;
                    upperTbound.Visible = true;
                    lowerTbound.Visible = true;
                    numericUpDown1.Maximum = 500;
                    numericUpDown1.Value = 200;
                }
                DrawMode = newm;
                DrawMan.SetDrawMode(Convert.ToInt32(but.Tag));
            }
            drawfuncset = false;

            }
            //drawfuncset = false;

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Graphcolshow.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Graphcolshow.BackColor = colorDialog1.Color;
                DrawMan.SetGraphColor(colorDialog1.Color);
                Invalidate();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Backcolshow.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Backcolshow.BackColor = colorDialog1.Color;
                DrawMan.SetBackgroundColor(colorDialog1.Color);
                Invalidate();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colorDialog1.Color = Axiscolshow.BackColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Axiscolshow.BackColor = colorDialog1.Color;
                DrawMan.SetAxisColor(colorDialog1.Color);
                Invalidate();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            switch (DrawMode)
            {
                case 2:
                    DrawMan.SetIterations(numericUpDown1.Value);
                    break;
                case 1:
                    DrawMan.SetFragmentation(numericUpDown1.Value);
                    break;
            }
            Invalidate();
        }

        private void heightlabel_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            DrawMan.SetPenWidth((int)numericUpDown2.Value);
            Invalidate();
        }
    }
}
