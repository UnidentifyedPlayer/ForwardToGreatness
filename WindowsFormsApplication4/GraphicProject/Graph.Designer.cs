namespace WindowsFormsApplication4
{
    partial class Graph
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.graphwidth = new System.Windows.Forms.Label();
            this.iter = new System.Windows.Forms.Label();
            this.heightnum = new System.Windows.Forms.Label();
            this.widthnum = new System.Windows.Forms.Label();
            this.heightlabel = new System.Windows.Forms.Label();
            this.widthlabel = new System.Windows.Forms.Label();
            this.Axiscolor = new System.Windows.Forms.Label();
            this.Backgroundcolor = new System.Windows.Forms.Label();
            this.Graphcolor = new System.Windows.Forms.Label();
            this.Axiscolshow = new System.Windows.Forms.Button();
            this.Backcolshow = new System.Windows.Forms.Button();
            this.Graphcolshow = new System.Windows.Forms.Button();
            this.ChangeAxiscol = new System.Windows.Forms.Button();
            this.ChangeBackcol = new System.Windows.Forms.Button();
            this.ChangeGraphcol = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.yctextBox2 = new System.Windows.Forms.TextBox();
            this.xctextBox1 = new System.Windows.Forms.TextBox();
            this.yclabel = new System.Windows.Forms.Label();
            this.xclabel = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.upperTbound = new System.Windows.Forms.Label();
            this.lowerTbound = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.upperTboundTextBox = new System.Windows.Forms.TextBox();
            this.lowerTboundTextBox = new System.Windows.Forms.TextBox();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // xTextBox
            // 
            this.xTextBox.Location = new System.Drawing.Point(43, 9);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(100, 20);
            this.xTextBox.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(160, 108);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "x(t) =";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(576, 471);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ExampleForm_MouseWheel);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Pink;
            this.panel1.Controls.Add(this.numericUpDown2);
            this.panel1.Controls.Add(this.graphwidth);
            this.panel1.Controls.Add(this.iter);
            this.panel1.Controls.Add(this.heightnum);
            this.panel1.Controls.Add(this.widthnum);
            this.panel1.Controls.Add(this.heightlabel);
            this.panel1.Controls.Add(this.widthlabel);
            this.panel1.Controls.Add(this.Axiscolor);
            this.panel1.Controls.Add(this.Backgroundcolor);
            this.panel1.Controls.Add(this.Graphcolor);
            this.panel1.Controls.Add(this.Axiscolshow);
            this.panel1.Controls.Add(this.Backcolshow);
            this.panel1.Controls.Add(this.Graphcolshow);
            this.panel1.Controls.Add(this.ChangeAxiscol);
            this.panel1.Controls.Add(this.ChangeBackcol);
            this.panel1.Controls.Add(this.ChangeGraphcol);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.yctextBox2);
            this.panel1.Controls.Add(this.xctextBox1);
            this.panel1.Controls.Add(this.yclabel);
            this.panel1.Controls.Add(this.xclabel);
            this.panel1.Controls.Add(this.radioButton3);
            this.panel1.Controls.Add(this.radioButton2);
            this.panel1.Controls.Add(this.radioButton1);
            this.panel1.Controls.Add(this.numericUpDown1);
            this.panel1.Controls.Add(this.upperTbound);
            this.panel1.Controls.Add(this.lowerTbound);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.upperTboundTextBox);
            this.panel1.Controls.Add(this.lowerTboundTextBox);
            this.panel1.Controls.Add(this.yTextBox);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.xTextBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(576, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(306, 471);
            this.panel1.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(6, 265);
            this.numericUpDown2.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.numericUpDown2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown2.TabIndex = 43;
            this.numericUpDown2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown2.ValueChanged += new System.EventHandler(this.numericUpDown2_ValueChanged);
            // 
            // graphwidth
            // 
            this.graphwidth.AutoSize = true;
            this.graphwidth.Location = new System.Drawing.Point(2, 245);
            this.graphwidth.Name = "graphwidth";
            this.graphwidth.Size = new System.Drawing.Size(74, 13);
            this.graphwidth.TabIndex = 42;
            this.graphwidth.Text = "Graph\'s width:";
            // 
            // iter
            // 
            this.iter.AutoSize = true;
            this.iter.Location = new System.Drawing.Point(3, 210);
            this.iter.Name = "iter";
            this.iter.Size = new System.Drawing.Size(35, 13);
            this.iter.TabIndex = 41;
            this.iter.Text = "label6";
            // 
            // heightnum
            // 
            this.heightnum.AutoSize = true;
            this.heightnum.Location = new System.Drawing.Point(50, 448);
            this.heightnum.Name = "heightnum";
            this.heightnum.Size = new System.Drawing.Size(35, 13);
            this.heightnum.TabIndex = 40;
            this.heightnum.Text = "label7";
            // 
            // widthnum
            // 
            this.widthnum.AutoSize = true;
            this.widthnum.Location = new System.Drawing.Point(50, 426);
            this.widthnum.Name = "widthnum";
            this.widthnum.Size = new System.Drawing.Size(49, 13);
            this.widthnum.TabIndex = 39;
            this.widthnum.Text = "wifthnum";
            // 
            // heightlabel
            // 
            this.heightlabel.AutoSize = true;
            this.heightlabel.Location = new System.Drawing.Point(6, 448);
            this.heightlabel.Name = "heightlabel";
            this.heightlabel.Size = new System.Drawing.Size(41, 13);
            this.heightlabel.TabIndex = 38;
            this.heightlabel.Text = "Height:";
            this.heightlabel.Click += new System.EventHandler(this.heightlabel_Click);
            // 
            // widthlabel
            // 
            this.widthlabel.AutoSize = true;
            this.widthlabel.Location = new System.Drawing.Point(6, 426);
            this.widthlabel.Name = "widthlabel";
            this.widthlabel.Size = new System.Drawing.Size(38, 13);
            this.widthlabel.TabIndex = 37;
            this.widthlabel.Text = "Width:";
            // 
            // Axiscolor
            // 
            this.Axiscolor.AutoSize = true;
            this.Axiscolor.Location = new System.Drawing.Point(128, 379);
            this.Axiscolor.Name = "Axiscolor";
            this.Axiscolor.Size = new System.Drawing.Size(53, 13);
            this.Axiscolor.TabIndex = 36;
            this.Axiscolor.Text = "Axis Color";
            // 
            // Backgroundcolor
            // 
            this.Backgroundcolor.AutoSize = true;
            this.Backgroundcolor.Location = new System.Drawing.Point(89, 353);
            this.Backgroundcolor.Name = "Backgroundcolor";
            this.Backgroundcolor.Size = new System.Drawing.Size(92, 13);
            this.Backgroundcolor.TabIndex = 35;
            this.Backgroundcolor.Text = "Background Color";
            // 
            // Graphcolor
            // 
            this.Graphcolor.AutoSize = true;
            this.Graphcolor.Location = new System.Drawing.Point(118, 325);
            this.Graphcolor.Name = "Graphcolor";
            this.Graphcolor.Size = new System.Drawing.Size(63, 13);
            this.Graphcolor.TabIndex = 34;
            this.Graphcolor.Text = "Graph Color";
            // 
            // Axiscolshow
            // 
            this.Axiscolshow.Enabled = false;
            this.Axiscolshow.Location = new System.Drawing.Point(187, 374);
            this.Axiscolshow.Name = "Axiscolshow";
            this.Axiscolshow.Size = new System.Drawing.Size(25, 23);
            this.Axiscolshow.TabIndex = 33;
            this.Axiscolshow.UseVisualStyleBackColor = true;
            // 
            // Backcolshow
            // 
            this.Backcolshow.Enabled = false;
            this.Backcolshow.Location = new System.Drawing.Point(187, 348);
            this.Backcolshow.Name = "Backcolshow";
            this.Backcolshow.Size = new System.Drawing.Size(25, 23);
            this.Backcolshow.TabIndex = 31;
            this.Backcolshow.UseVisualStyleBackColor = true;
            // 
            // Graphcolshow
            // 
            this.Graphcolshow.Enabled = false;
            this.Graphcolshow.Location = new System.Drawing.Point(187, 320);
            this.Graphcolshow.Name = "Graphcolshow";
            this.Graphcolshow.Size = new System.Drawing.Size(25, 23);
            this.Graphcolshow.TabIndex = 28;
            this.Graphcolshow.UseVisualStyleBackColor = true;
            // 
            // ChangeAxiscol
            // 
            this.ChangeAxiscol.Location = new System.Drawing.Point(218, 374);
            this.ChangeAxiscol.Name = "ChangeAxiscol";
            this.ChangeAxiscol.Size = new System.Drawing.Size(75, 23);
            this.ChangeAxiscol.TabIndex = 27;
            this.ChangeAxiscol.Text = "Change";
            this.ChangeAxiscol.UseVisualStyleBackColor = true;
            this.ChangeAxiscol.Click += new System.EventHandler(this.button4_Click);
            // 
            // ChangeBackcol
            // 
            this.ChangeBackcol.Location = new System.Drawing.Point(218, 348);
            this.ChangeBackcol.Name = "ChangeBackcol";
            this.ChangeBackcol.Size = new System.Drawing.Size(75, 23);
            this.ChangeBackcol.TabIndex = 26;
            this.ChangeBackcol.Text = "Cahnge";
            this.ChangeBackcol.UseVisualStyleBackColor = true;
            this.ChangeBackcol.Click += new System.EventHandler(this.button3_Click);
            // 
            // ChangeGraphcol
            // 
            this.ChangeGraphcol.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ChangeGraphcol.Location = new System.Drawing.Point(218, 320);
            this.ChangeGraphcol.Name = "ChangeGraphcol";
            this.ChangeGraphcol.Size = new System.Drawing.Size(75, 23);
            this.ChangeGraphcol.TabIndex = 22;
            this.ChangeGraphcol.Text = "Change";
            this.ChangeGraphcol.UseVisualStyleBackColor = false;
            this.ChangeGraphcol.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(43, 62);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 20);
            this.textBox3.TabIndex = 21;
            this.textBox3.Text = "3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "z(x,y)";
            // 
            // yctextBox2
            // 
            this.yctextBox2.Location = new System.Drawing.Point(43, 168);
            this.yctextBox2.Name = "yctextBox2";
            this.yctextBox2.Size = new System.Drawing.Size(104, 20);
            this.yctextBox2.TabIndex = 19;
            this.yctextBox2.Text = "20";
            // 
            // xctextBox1
            // 
            this.xctextBox1.Location = new System.Drawing.Point(43, 145);
            this.xctextBox1.Name = "xctextBox1";
            this.xctextBox1.Size = new System.Drawing.Size(104, 20);
            this.xctextBox1.TabIndex = 18;
            this.xctextBox1.Text = "10";
            // 
            // yclabel
            // 
            this.yclabel.AutoSize = true;
            this.yclabel.Location = new System.Drawing.Point(6, 171);
            this.yclabel.Name = "yclabel";
            this.yclabel.Size = new System.Drawing.Size(35, 13);
            this.yclabel.TabIndex = 17;
            this.yclabel.Text = "label4";
            // 
            // xclabel
            // 
            this.xclabel.AutoSize = true;
            this.xclabel.Location = new System.Drawing.Point(6, 148);
            this.xclabel.Name = "xclabel";
            this.xclabel.Size = new System.Drawing.Size(35, 13);
            this.xclabel.TabIndex = 16;
            this.xclabel.Text = "label3";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(194, 268);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(85, 17);
            this.radioButton3.TabIndex = 15;
            this.radioButton3.TabStop = true;
            this.radioButton3.Tag = 3;
            this.radioButton3.Text = "radioButton3";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(194, 245);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(80, 17);
            this.radioButton2.TabIndex = 14;
            this.radioButton2.TabStop = true;
            this.radioButton2.Tag = 2;
            this.radioButton2.Text = "f(z) = z^2+c";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(194, 221);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(93, 17);
            this.radioButton1.TabIndex = 13;
            this.radioButton1.TabStop = true;
            this.radioButton1.Tag = 1;
            this.radioButton1.Text = "x = x(t); y = y(t)";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(43, 208);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(100, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // upperTbound
            // 
            this.upperTbound.AutoSize = true;
            this.upperTbound.Location = new System.Drawing.Point(6, 113);
            this.upperTbound.Name = "upperTbound";
            this.upperTbound.Size = new System.Drawing.Size(35, 13);
            this.upperTbound.TabIndex = 8;
            this.upperTbound.Text = "label4";
            // 
            // lowerTbound
            // 
            this.lowerTbound.AutoSize = true;
            this.lowerTbound.Location = new System.Drawing.Point(6, 91);
            this.lowerTbound.Name = "lowerTbound";
            this.lowerTbound.Size = new System.Drawing.Size(35, 13);
            this.lowerTbound.TabIndex = 7;
            this.lowerTbound.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "y(t)";
            // 
            // upperTboundTextBox
            // 
            this.upperTboundTextBox.Location = new System.Drawing.Point(43, 111);
            this.upperTboundTextBox.Name = "upperTboundTextBox";
            this.upperTboundTextBox.Size = new System.Drawing.Size(100, 20);
            this.upperTboundTextBox.TabIndex = 5;
            this.upperTboundTextBox.Text = "20";
            // 
            // lowerTboundTextBox
            // 
            this.lowerTboundTextBox.Location = new System.Drawing.Point(43, 88);
            this.lowerTboundTextBox.Name = "lowerTboundTextBox";
            this.lowerTboundTextBox.Size = new System.Drawing.Size(100, 20);
            this.lowerTboundTextBox.TabIndex = 4;
            this.lowerTboundTextBox.Text = "10";
            // 
            // yTextBox
            // 
            this.yTextBox.Location = new System.Drawing.Point(43, 35);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(100, 20);
            this.yTextBox.TabIndex = 3;
            // 
            // colorDialog1
            // 
            this.colorDialog1.AnyColor = true;
            this.colorDialog1.FullOpen = true;
            this.colorDialog1.ShowHelp = true;
            // 
            // Graph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 470);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Name = "Graph";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Graph_Load);
            this.ResizeEnd += new System.EventHandler(this.Graph_ResizeEnd);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Graph_MouseMove);
            this.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.ExampleForm_MouseWheel);
            this.Resize += new System.EventHandler(this.Graph_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox upperTboundTextBox;
        private System.Windows.Forms.TextBox lowerTboundTextBox;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.Label upperTbound;
        private System.Windows.Forms.Label lowerTbound;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox yctextBox2;
        private System.Windows.Forms.TextBox xctextBox1;
        private System.Windows.Forms.Label yclabel;
        private System.Windows.Forms.Label xclabel;
        private System.Windows.Forms.Button Graphcolshow;
        private System.Windows.Forms.Button ChangeAxiscol;
        private System.Windows.Forms.Button ChangeBackcol;
        private System.Windows.Forms.Button ChangeGraphcol;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button Axiscolshow;
        private System.Windows.Forms.Button Backcolshow;
        private System.Windows.Forms.Label Axiscolor;
        private System.Windows.Forms.Label Backgroundcolor;
        private System.Windows.Forms.Label Graphcolor;
        private System.Windows.Forms.Label heightlabel;
        private System.Windows.Forms.Label widthlabel;
        private System.Windows.Forms.Label iter;
        private System.Windows.Forms.Label heightnum;
        private System.Windows.Forms.Label widthnum;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.Label graphwidth;
    }
}

