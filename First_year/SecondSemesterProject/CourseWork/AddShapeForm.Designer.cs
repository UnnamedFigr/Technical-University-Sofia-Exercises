namespace WindowsFormsApp1
{
    partial class addShapeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBoxShapeType = new System.Windows.Forms.ComboBox();
            this.panelRectangle = new System.Windows.Forms.Panel();
            this.pnlRectBordCol = new System.Windows.Forms.Panel();
            this.pnlRectFillCol = new System.Windows.Forms.Panel();
            this.rectBordCol = new System.Windows.Forms.Button();
            this.rectFillCol = new System.Windows.Forms.Button();
            this.txtRectBordThick = new System.Windows.Forms.TextBox();
            this.txtRectHeight = new System.Windows.Forms.TextBox();
            this.txtRectWidth = new System.Windows.Forms.TextBox();
            this.txtRectPosY = new System.Windows.Forms.TextBox();
            this.txtRectPosX = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lableWidth = new System.Windows.Forms.Label();
            this.panelCircle = new System.Windows.Forms.Panel();
            this.pnlCircleBordCol = new System.Windows.Forms.Panel();
            this.pnlCircleFillCol = new System.Windows.Forms.Panel();
            this.CircleBordCol = new System.Windows.Forms.Button();
            this.CircleFillCol = new System.Windows.Forms.Button();
            this.txtCircleBordThick = new System.Windows.Forms.TextBox();
            this.txtCircleRadius = new System.Windows.Forms.TextBox();
            this.txtCirclePosY = new System.Windows.Forms.TextBox();
            this.txtCirclePosX = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panelSquare = new System.Windows.Forms.Panel();
            this.pnlSqrBordCol = new System.Windows.Forms.Panel();
            this.pnlSqrFillCol = new System.Windows.Forms.Panel();
            this.sqrBordColr = new System.Windows.Forms.Button();
            this.sqrFillCol = new System.Windows.Forms.Button();
            this.txtSquareBordThick = new System.Windows.Forms.TextBox();
            this.txtSquareSide = new System.Windows.Forms.TextBox();
            this.txtSquarePosY = new System.Windows.Forms.TextBox();
            this.txtSquarePosX = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.panelRectangle.SuspendLayout();
            this.panelCircle.SuspendLayout();
            this.panelSquare.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBoxShapeType
            // 
            this.comboBoxShapeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxShapeType.FormattingEnabled = true;
            this.comboBoxShapeType.Location = new System.Drawing.Point(121, 10);
            this.comboBoxShapeType.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comboBoxShapeType.Name = "comboBoxShapeType";
            this.comboBoxShapeType.Size = new System.Drawing.Size(150, 21);
            this.comboBoxShapeType.TabIndex = 0;
            this.comboBoxShapeType.SelectedIndexChanged += new System.EventHandler(this.comboBoxShapeType_SelectedIndexChanged);
            // 
            // panelRectangle
            // 
            this.panelRectangle.Controls.Add(this.pnlRectBordCol);
            this.panelRectangle.Controls.Add(this.pnlRectFillCol);
            this.panelRectangle.Controls.Add(this.rectBordCol);
            this.panelRectangle.Controls.Add(this.rectFillCol);
            this.panelRectangle.Controls.Add(this.txtRectBordThick);
            this.panelRectangle.Controls.Add(this.txtRectHeight);
            this.panelRectangle.Controls.Add(this.txtRectWidth);
            this.panelRectangle.Controls.Add(this.txtRectPosY);
            this.panelRectangle.Controls.Add(this.txtRectPosX);
            this.panelRectangle.Controls.Add(this.label7);
            this.panelRectangle.Controls.Add(this.label6);
            this.panelRectangle.Controls.Add(this.label5);
            this.panelRectangle.Controls.Add(this.label4);
            this.panelRectangle.Controls.Add(this.label3);
            this.panelRectangle.Controls.Add(this.label2);
            this.panelRectangle.Controls.Add(this.label1);
            this.panelRectangle.Controls.Add(this.lableWidth);
            this.panelRectangle.Location = new System.Drawing.Point(48, 41);
            this.panelRectangle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelRectangle.Name = "panelRectangle";
            this.panelRectangle.Size = new System.Drawing.Size(297, 180);
            this.panelRectangle.TabIndex = 1;
            this.panelRectangle.Visible = false;
            // 
            // pnlRectBordCol
            // 
            this.pnlRectBordCol.Location = new System.Drawing.Point(179, 124);
            this.pnlRectBordCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlRectBordCol.Name = "pnlRectBordCol";
            this.pnlRectBordCol.Size = new System.Drawing.Size(19, 18);
            this.pnlRectBordCol.TabIndex = 19;
            // 
            // pnlRectFillCol
            // 
            this.pnlRectFillCol.Location = new System.Drawing.Point(156, 100);
            this.pnlRectFillCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlRectFillCol.Name = "pnlRectFillCol";
            this.pnlRectFillCol.Size = new System.Drawing.Size(19, 18);
            this.pnlRectFillCol.TabIndex = 18;
            // 
            // rectBordCol
            // 
            this.rectBordCol.Location = new System.Drawing.Point(86, 124);
            this.rectBordCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rectBordCol.Name = "rectBordCol";
            this.rectBordCol.Size = new System.Drawing.Size(89, 19);
            this.rectBordCol.TabIndex = 17;
            this.rectBordCol.Text = "Select a color";
            this.rectBordCol.UseVisualStyleBackColor = true;
            this.rectBordCol.Click += new System.EventHandler(this.rectBordCol_Click);
            // 
            // rectFillCol
            // 
            this.rectFillCol.Location = new System.Drawing.Point(67, 98);
            this.rectFillCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rectFillCol.Name = "rectFillCol";
            this.rectFillCol.Size = new System.Drawing.Size(84, 19);
            this.rectFillCol.TabIndex = 16;
            this.rectFillCol.Text = "Select a color";
            this.rectFillCol.UseVisualStyleBackColor = true;
            this.rectFillCol.Click += new System.EventHandler(this.rectFillCol_Click);
            // 
            // txtRectBordThick
            // 
            this.txtRectBordThick.Location = new System.Drawing.Point(102, 147);
            this.txtRectBordThick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRectBordThick.Name = "txtRectBordThick";
            this.txtRectBordThick.Size = new System.Drawing.Size(66, 20);
            this.txtRectBordThick.TabIndex = 13;
            this.txtRectBordThick.Text = "1";
            // 
            // txtRectHeight
            // 
            this.txtRectHeight.Location = new System.Drawing.Point(58, 72);
            this.txtRectHeight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRectHeight.Name = "txtRectHeight";
            this.txtRectHeight.Size = new System.Drawing.Size(66, 20);
            this.txtRectHeight.TabIndex = 11;
            // 
            // txtRectWidth
            // 
            this.txtRectWidth.Location = new System.Drawing.Point(58, 46);
            this.txtRectWidth.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRectWidth.Name = "txtRectWidth";
            this.txtRectWidth.Size = new System.Drawing.Size(66, 20);
            this.txtRectWidth.TabIndex = 10;
            // 
            // txtRectPosY
            // 
            this.txtRectPosY.Location = new System.Drawing.Point(170, 25);
            this.txtRectPosY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRectPosY.Name = "txtRectPosY";
            this.txtRectPosY.Size = new System.Drawing.Size(50, 20);
            this.txtRectPosY.TabIndex = 9;
            this.txtRectPosY.Text = "0";
            // 
            // txtRectPosX
            // 
            this.txtRectPosX.Location = new System.Drawing.Point(93, 23);
            this.txtRectPosX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtRectPosX.Name = "txtRectPosX";
            this.txtRectPosX.Size = new System.Drawing.Size(50, 20);
            this.txtRectPosX.TabIndex = 8;
            this.txtRectPosX.Text = "0";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(154, 25);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(14, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Y";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(77, 25);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "X";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 25);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 15);
            this.label5.TabIndex = 5;
            this.label5.Text = "Coordinates";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 150);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 15);
            this.label4.TabIndex = 4;
            this.label4.Text = "Border Thickness";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 124);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Border Color";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 100);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fill Color";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Height";
            // 
            // lableWidth
            // 
            this.lableWidth.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lableWidth.AutoSize = true;
            this.lableWidth.Location = new System.Drawing.Point(13, 48);
            this.lableWidth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lableWidth.Name = "lableWidth";
            this.lableWidth.Size = new System.Drawing.Size(38, 15);
            this.lableWidth.TabIndex = 0;
            this.lableWidth.Text = "Width";
            // 
            // panelCircle
            // 
            this.panelCircle.Controls.Add(this.pnlCircleBordCol);
            this.panelCircle.Controls.Add(this.pnlCircleFillCol);
            this.panelCircle.Controls.Add(this.CircleBordCol);
            this.panelCircle.Controls.Add(this.CircleFillCol);
            this.panelCircle.Controls.Add(this.txtCircleBordThick);
            this.panelCircle.Controls.Add(this.txtCircleRadius);
            this.panelCircle.Controls.Add(this.txtCirclePosY);
            this.panelCircle.Controls.Add(this.txtCirclePosX);
            this.panelCircle.Controls.Add(this.label8);
            this.panelCircle.Controls.Add(this.label9);
            this.panelCircle.Controls.Add(this.label10);
            this.panelCircle.Controls.Add(this.label11);
            this.panelCircle.Controls.Add(this.label12);
            this.panelCircle.Controls.Add(this.label13);
            this.panelCircle.Controls.Add(this.label15);
            this.panelCircle.Location = new System.Drawing.Point(46, 38);
            this.panelCircle.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelCircle.Name = "panelCircle";
            this.panelCircle.Size = new System.Drawing.Size(297, 180);
            this.panelCircle.TabIndex = 14;
            this.panelCircle.Visible = false;
            // 
            // pnlCircleBordCol
            // 
            this.pnlCircleBordCol.Location = new System.Drawing.Point(170, 93);
            this.pnlCircleBordCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlCircleBordCol.Name = "pnlCircleBordCol";
            this.pnlCircleBordCol.Size = new System.Drawing.Size(19, 18);
            this.pnlCircleBordCol.TabIndex = 20;
            // 
            // pnlCircleFillCol
            // 
            this.pnlCircleFillCol.Location = new System.Drawing.Point(148, 71);
            this.pnlCircleFillCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlCircleFillCol.Name = "pnlCircleFillCol";
            this.pnlCircleFillCol.Size = new System.Drawing.Size(19, 18);
            this.pnlCircleFillCol.TabIndex = 19;
            // 
            // CircleBordCol
            // 
            this.CircleBordCol.Location = new System.Drawing.Point(80, 92);
            this.CircleBordCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CircleBordCol.Name = "CircleBordCol";
            this.CircleBordCol.Size = new System.Drawing.Size(86, 19);
            this.CircleBordCol.TabIndex = 17;
            this.CircleBordCol.Text = "Select a color";
            this.CircleBordCol.UseVisualStyleBackColor = true;
            this.CircleBordCol.Click += new System.EventHandler(this.CircleBordCol_Click);
            // 
            // CircleFillCol
            // 
            this.CircleFillCol.Location = new System.Drawing.Point(62, 68);
            this.CircleFillCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CircleFillCol.Name = "CircleFillCol";
            this.CircleFillCol.Size = new System.Drawing.Size(82, 19);
            this.CircleFillCol.TabIndex = 16;
            this.CircleFillCol.Text = "Select a color";
            this.CircleFillCol.UseVisualStyleBackColor = true;
            this.CircleFillCol.Click += new System.EventHandler(this.CircleFillCol_Click);
            // 
            // txtCircleBordThick
            // 
            this.txtCircleBordThick.Location = new System.Drawing.Point(102, 118);
            this.txtCircleBordThick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCircleBordThick.Name = "txtCircleBordThick";
            this.txtCircleBordThick.Size = new System.Drawing.Size(66, 20);
            this.txtCircleBordThick.TabIndex = 13;
            this.txtCircleBordThick.Text = "1";
            // 
            // txtCircleRadius
            // 
            this.txtCircleRadius.Location = new System.Drawing.Point(58, 46);
            this.txtCircleRadius.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCircleRadius.Name = "txtCircleRadius";
            this.txtCircleRadius.Size = new System.Drawing.Size(66, 20);
            this.txtCircleRadius.TabIndex = 10;
            // 
            // txtCirclePosY
            // 
            this.txtCirclePosY.Location = new System.Drawing.Point(170, 25);
            this.txtCirclePosY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCirclePosY.Name = "txtCirclePosY";
            this.txtCirclePosY.Size = new System.Drawing.Size(50, 20);
            this.txtCirclePosY.TabIndex = 9;
            this.txtCirclePosY.Text = "0";
            // 
            // txtCirclePosX
            // 
            this.txtCirclePosX.Location = new System.Drawing.Point(93, 23);
            this.txtCirclePosX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtCirclePosX.Name = "txtCirclePosX";
            this.txtCirclePosX.Size = new System.Drawing.Size(50, 20);
            this.txtCirclePosX.TabIndex = 8;
            this.txtCirclePosX.Text = "0";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(154, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 15);
            this.label8.TabIndex = 7;
            this.label8.Text = "Y";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(77, 25);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 15);
            this.label9.TabIndex = 6;
            this.label9.Text = "X";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 25);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 15);
            this.label10.TabIndex = 5;
            this.label10.Text = "Coordinates";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 120);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(102, 15);
            this.label11.TabIndex = 4;
            this.label11.Text = "Border Thickness";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 94);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 15);
            this.label12.TabIndex = 3;
            this.label12.Text = "Border Color";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(13, 71);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(55, 15);
            this.label13.TabIndex = 2;
            this.label13.Text = "Fill Color";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(13, 48);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Radius";
            // 
            // panelSquare
            // 
            this.panelSquare.Controls.Add(this.pnlSqrBordCol);
            this.panelSquare.Controls.Add(this.pnlSqrFillCol);
            this.panelSquare.Controls.Add(this.sqrBordColr);
            this.panelSquare.Controls.Add(this.sqrFillCol);
            this.panelSquare.Controls.Add(this.txtSquareBordThick);
            this.panelSquare.Controls.Add(this.txtSquareSide);
            this.panelSquare.Controls.Add(this.txtSquarePosY);
            this.panelSquare.Controls.Add(this.txtSquarePosX);
            this.panelSquare.Controls.Add(this.label14);
            this.panelSquare.Controls.Add(this.label16);
            this.panelSquare.Controls.Add(this.label17);
            this.panelSquare.Controls.Add(this.label18);
            this.panelSquare.Controls.Add(this.label19);
            this.panelSquare.Controls.Add(this.label20);
            this.panelSquare.Controls.Add(this.label21);
            this.panelSquare.Location = new System.Drawing.Point(46, 41);
            this.panelSquare.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelSquare.Name = "panelSquare";
            this.panelSquare.Size = new System.Drawing.Size(297, 180);
            this.panelSquare.TabIndex = 15;
            this.panelSquare.Visible = false;
            // 
            // pnlSqrBordCol
            // 
            this.pnlSqrBordCol.Location = new System.Drawing.Point(170, 98);
            this.pnlSqrBordCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSqrBordCol.Name = "pnlSqrBordCol";
            this.pnlSqrBordCol.Size = new System.Drawing.Size(19, 18);
            this.pnlSqrBordCol.TabIndex = 19;
            // 
            // pnlSqrFillCol
            // 
            this.pnlSqrFillCol.Location = new System.Drawing.Point(146, 72);
            this.pnlSqrFillCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlSqrFillCol.Name = "pnlSqrFillCol";
            this.pnlSqrFillCol.Size = new System.Drawing.Size(19, 18);
            this.pnlSqrFillCol.TabIndex = 20;
            // 
            // sqrBordColr
            // 
            this.sqrBordColr.Location = new System.Drawing.Point(80, 94);
            this.sqrBordColr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sqrBordColr.Name = "sqrBordColr";
            this.sqrBordColr.Size = new System.Drawing.Size(86, 19);
            this.sqrBordColr.TabIndex = 15;
            this.sqrBordColr.Text = "Select a color";
            this.sqrBordColr.UseVisualStyleBackColor = true;
            this.sqrBordColr.Click += new System.EventHandler(this.sqrBordColr_Click);
            // 
            // sqrFillCol
            // 
            this.sqrFillCol.Location = new System.Drawing.Point(62, 71);
            this.sqrFillCol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sqrFillCol.Name = "sqrFillCol";
            this.sqrFillCol.Size = new System.Drawing.Size(80, 19);
            this.sqrFillCol.TabIndex = 13;
            this.sqrFillCol.Text = "Select a color";
            this.sqrFillCol.UseVisualStyleBackColor = true;
            this.sqrFillCol.Click += new System.EventHandler(this.sqrFillCol_Click);
            // 
            // txtSquareBordThick
            // 
            this.txtSquareBordThick.Location = new System.Drawing.Point(102, 118);
            this.txtSquareBordThick.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSquareBordThick.Name = "txtSquareBordThick";
            this.txtSquareBordThick.Size = new System.Drawing.Size(66, 20);
            this.txtSquareBordThick.TabIndex = 16;
            this.txtSquareBordThick.Text = "1";
            // 
            // txtSquareSide
            // 
            this.txtSquareSide.Location = new System.Drawing.Point(49, 48);
            this.txtSquareSide.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSquareSide.Name = "txtSquareSide";
            this.txtSquareSide.Size = new System.Drawing.Size(66, 20);
            this.txtSquareSide.TabIndex = 10;
            // 
            // txtSquarePosY
            // 
            this.txtSquarePosY.Location = new System.Drawing.Point(170, 25);
            this.txtSquarePosY.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSquarePosY.Name = "txtSquarePosY";
            this.txtSquarePosY.Size = new System.Drawing.Size(50, 20);
            this.txtSquarePosY.TabIndex = 9;
            this.txtSquarePosY.Text = "0";
            // 
            // txtSquarePosX
            // 
            this.txtSquarePosX.Location = new System.Drawing.Point(93, 23);
            this.txtSquarePosX.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSquarePosX.Name = "txtSquarePosX";
            this.txtSquarePosX.Size = new System.Drawing.Size(50, 20);
            this.txtSquarePosX.TabIndex = 8;
            this.txtSquarePosX.Text = "0";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(154, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 15);
            this.label14.TabIndex = 7;
            this.label14.Text = "Y";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(77, 25);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(15, 15);
            this.label16.TabIndex = 6;
            this.label16.Text = "X";
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(13, 25);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 15);
            this.label17.TabIndex = 5;
            this.label17.Text = "Coordinates";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(13, 120);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(102, 15);
            this.label18.TabIndex = 4;
            this.label18.Text = "Border Thickness";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(13, 94);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(76, 15);
            this.label19.TabIndex = 3;
            this.label19.Text = "Border Color";
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(13, 71);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(55, 15);
            this.label20.TabIndex = 2;
            this.label20.Text = "Fill Color";
            // 
            // label21
            // 
            this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(13, 48);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(32, 15);
            this.label21.TabIndex = 0;
            this.label21.Text = "Side";
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(63, 261);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(90, 19);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "Add shape";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(272, 261);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(56, 19);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // addShapeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 293);
            this.Controls.Add(this.panelSquare);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.panelCircle);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelRectangle);
            this.Controls.Add(this.comboBoxShapeType);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "addShapeForm";
            this.Text = "Create a shape";
            this.Load += new System.EventHandler(this.addShapeForm_Load);
            this.panelRectangle.ResumeLayout(false);
            this.panelRectangle.PerformLayout();
            this.panelCircle.ResumeLayout(false);
            this.panelCircle.PerformLayout();
            this.panelSquare.ResumeLayout(false);
            this.panelSquare.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxShapeType;
        private System.Windows.Forms.Panel panelRectangle;
        private System.Windows.Forms.Label lableWidth;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelCircle;
        private System.Windows.Forms.Panel panelSquare;
        private System.Windows.Forms.TextBox txtSquareBordThick;
        private System.Windows.Forms.TextBox txtSquareSide;
        private System.Windows.Forms.TextBox txtSquarePosY;
        private System.Windows.Forms.TextBox txtSquarePosX;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtCircleBordThick;
        private System.Windows.Forms.TextBox txtCircleRadius;
        private System.Windows.Forms.TextBox txtCirclePosY;
        private System.Windows.Forms.TextBox txtCirclePosX;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRectBordThick;
        private System.Windows.Forms.TextBox txtRectHeight;
        private System.Windows.Forms.TextBox txtRectWidth;
        private System.Windows.Forms.TextBox txtRectPosY;
        private System.Windows.Forms.TextBox txtRectPosX;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button rectBordCol;
        private System.Windows.Forms.Button rectFillCol;
        private System.Windows.Forms.Button CircleBordCol;
        private System.Windows.Forms.Button CircleFillCol;
        private System.Windows.Forms.Button sqrBordColr;
        private System.Windows.Forms.Button sqrFillCol;
        private System.Windows.Forms.Panel pnlRectBordCol;
        private System.Windows.Forms.Panel pnlRectFillCol;
        private System.Windows.Forms.Panel pnlCircleBordCol;
        private System.Windows.Forms.Panel pnlCircleFillCol;
        private System.Windows.Forms.Panel pnlSqrBordCol;
        private System.Windows.Forms.Panel pnlSqrFillCol;
    }
}