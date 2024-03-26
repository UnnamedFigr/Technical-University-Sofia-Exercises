namespace WindowsFormsApp1
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.btnFilterShapeType = new System.Windows.Forms.Button();
            this.btnClearFilter = new System.Windows.Forms.Button();
            this.timerShapeActions = new System.Windows.Forms.Timer(this.components);
            this.timerFile = new System.Windows.Forms.Timer(this.components);
            this.Scene = new System.Windows.Forms.PictureBox();
            this.surfaceAreaLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRedo = new System.Windows.Forms.Button();
            this.btnUndo = new System.Windows.Forms.Button();
            this.initPointCoord = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRmvAll = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAddShape = new System.Windows.Forms.Button();
            this.btnShapeDropDown = new System.Windows.Forms.Button();
            this.pnlShapeActionsDropD = new System.Windows.Forms.Panel();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnFileDropDown = new System.Windows.Forms.Button();
            this.pnlFileDropDown = new System.Windows.Forms.Panel();
            this.btnFilterShapes = new System.Windows.Forms.Button();
            this.pnlFilterShapes = new System.Windows.Forms.Panel();
            this.btnFilterColors = new System.Windows.Forms.Button();
            this.timerFilter = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).BeginInit();
            this.pnlShapeActionsDropD.SuspendLayout();
            this.pnlFileDropDown.SuspendLayout();
            this.pnlFilterShapes.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnFilterShapeType
            // 
            this.btnFilterShapeType.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnFilterShapeType.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFilterShapeType.FlatAppearance.BorderSize = 0;
            this.btnFilterShapeType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterShapeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterShapeType.Location = new System.Drawing.Point(0, 37);
            this.btnFilterShapeType.Margin = new System.Windows.Forms.Padding(0);
            this.btnFilterShapeType.Name = "btnFilterShapeType";
            this.btnFilterShapeType.Size = new System.Drawing.Size(199, 38);
            this.btnFilterShapeType.TabIndex = 16;
            this.btnFilterShapeType.Text = "Show same type shapes";
            this.btnFilterShapeType.UseVisualStyleBackColor = false;
            this.btnFilterShapeType.Click += new System.EventHandler(this.btnFilterShapeType_Click);
            // 
            // btnClearFilter
            // 
            this.btnClearFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnClearFilter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnClearFilter.FlatAppearance.BorderSize = 0;
            this.btnClearFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearFilter.Location = new System.Drawing.Point(0, -2);
            this.btnClearFilter.Margin = new System.Windows.Forms.Padding(0);
            this.btnClearFilter.Name = "btnClearFilter";
            this.btnClearFilter.Size = new System.Drawing.Size(199, 40);
            this.btnClearFilter.TabIndex = 17;
            this.btnClearFilter.Text = "Clear filter";
            this.btnClearFilter.UseVisualStyleBackColor = false;
            this.btnClearFilter.Click += new System.EventHandler(this.clearFilter_Click);
            // 
            // timerShapeActions
            // 
            this.timerShapeActions.Interval = 15;
            this.timerShapeActions.Tick += new System.EventHandler(this.timerShapeActions_Tick);
            // 
            // timerFile
            // 
            this.timerFile.Interval = 15;
            this.timerFile.Tick += new System.EventHandler(this.timerFile_Tick);
            // 
            // Scene
            // 
            this.Scene.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Scene.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Scene.Cursor = System.Windows.Forms.Cursors.Cross;
            this.Scene.Location = new System.Drawing.Point(11, 72);
            this.Scene.Margin = new System.Windows.Forms.Padding(2);
            this.Scene.Name = "Scene";
            this.Scene.Size = new System.Drawing.Size(1012, 600);
            this.Scene.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.Scene.TabIndex = 3;
            this.Scene.TabStop = false;
            this.Scene.Paint += new System.Windows.Forms.PaintEventHandler(this.Scene_Paint);
            this.Scene.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseClick);
            this.Scene.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseDown);
            this.Scene.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseMove);
            this.Scene.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Scene_MouseUp);
            // 
            // surfaceAreaLabel
            // 
            this.surfaceAreaLabel.AutoEllipsis = true;
            this.surfaceAreaLabel.AutoSize = true;
            this.surfaceAreaLabel.Location = new System.Drawing.Point(548, 11);
            this.surfaceAreaLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.surfaceAreaLabel.Name = "surfaceAreaLabel";
            this.surfaceAreaLabel.Size = new System.Drawing.Size(88, 15);
            this.surfaceAreaLabel.TabIndex = 4;
            this.surfaceAreaLabel.Text = "Select a shape";
            // 
            // label1
            // 
            this.label1.AutoEllipsis = true;
            this.label1.Location = new System.Drawing.Point(445, 11);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Surface area: ";
            // 
            // btnRedo
            // 
            this.btnRedo.Image = global::WindowsFormsApp1.Properties.Resources.redoIcon;
            this.btnRedo.Location = new System.Drawing.Point(185, 12);
            this.btnRedo.Margin = new System.Windows.Forms.Padding(2);
            this.btnRedo.Name = "btnRedo";
            this.btnRedo.Size = new System.Drawing.Size(38, 30);
            this.btnRedo.TabIndex = 7;
            this.btnRedo.UseVisualStyleBackColor = true;
            this.btnRedo.Click += new System.EventHandler(this.btnRedo_Click);
            // 
            // btnUndo
            // 
            this.btnUndo.Image = global::WindowsFormsApp1.Properties.Resources.undoIconResized1;
            this.btnUndo.Location = new System.Drawing.Point(143, 12);
            this.btnUndo.Margin = new System.Windows.Forms.Padding(2);
            this.btnUndo.Name = "btnUndo";
            this.btnUndo.Size = new System.Drawing.Size(38, 30);
            this.btnUndo.TabIndex = 8;
            this.btnUndo.UseVisualStyleBackColor = true;
            this.btnUndo.Click += new System.EventHandler(this.btnUndo_Click);
            // 
            // initPointCoord
            // 
            this.initPointCoord.AutoSize = true;
            this.initPointCoord.Location = new System.Drawing.Point(548, 34);
            this.initPointCoord.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.initPointCoord.Name = "initPointCoord";
            this.initPointCoord.Size = new System.Drawing.Size(106, 15);
            this.initPointCoord.TabIndex = 11;
            this.initPointCoord.Text = "Click on the scene";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(445, 34);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Initial Point (X,Y):";
            // 
            // btnRmvAll
            // 
            this.btnRmvAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRmvAll.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRmvAll.FlatAppearance.BorderSize = 0;
            this.btnRmvAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRmvAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRmvAll.Location = new System.Drawing.Point(0, 148);
            this.btnRmvAll.Margin = new System.Windows.Forms.Padding(0);
            this.btnRmvAll.Name = "btnRmvAll";
            this.btnRmvAll.Size = new System.Drawing.Size(162, 43);
            this.btnRmvAll.TabIndex = 15;
            this.btnRmvAll.Text = "Remove all shapes";
            this.btnRmvAll.UseVisualStyleBackColor = false;
            this.btnRmvAll.Click += new System.EventHandler(this.btnRmvAll_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnRemove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnRemove.FlatAppearance.BorderSize = 0;
            this.btnRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(0, 111);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(0);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(162, 37);
            this.btnRemove.TabIndex = 9;
            this.btnRemove.Text = "Remove shape";
            this.btnRemove.UseVisualStyleBackColor = false;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnEdit.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(0, 74);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(0);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(162, 37);
            this.btnEdit.TabIndex = 10;
            this.btnEdit.Text = "Edit selected shape";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAddShape
            // 
            this.btnAddShape.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddShape.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnAddShape.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnAddShape.FlatAppearance.BorderSize = 0;
            this.btnAddShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddShape.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddShape.Location = new System.Drawing.Point(0, 37);
            this.btnAddShape.Margin = new System.Windows.Forms.Padding(0);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Size = new System.Drawing.Size(162, 37);
            this.btnAddShape.TabIndex = 6;
            this.btnAddShape.Text = "Add shape";
            this.btnAddShape.UseVisualStyleBackColor = false;
            this.btnAddShape.Click += new System.EventHandler(this.btnAddShape_Click);
            // 
            // btnShapeDropDown
            // 
            this.btnShapeDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnShapeDropDown.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnShapeDropDown.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnShapeDropDown.FlatAppearance.BorderSize = 0;
            this.btnShapeDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShapeDropDown.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShapeDropDown.Location = new System.Drawing.Point(0, 0);
            this.btnShapeDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnShapeDropDown.Name = "btnShapeDropDown";
            this.btnShapeDropDown.Size = new System.Drawing.Size(162, 38);
            this.btnShapeDropDown.TabIndex = 21;
            this.btnShapeDropDown.Text = "Shape Actions";
            this.btnShapeDropDown.UseVisualStyleBackColor = false;
            this.btnShapeDropDown.Click += new System.EventHandler(this.btnShapeDropDown_Click);
            // 
            // pnlShapeActionsDropD
            // 
            this.pnlShapeActionsDropD.Controls.Add(this.btnShapeDropDown);
            this.pnlShapeActionsDropD.Controls.Add(this.btnAddShape);
            this.pnlShapeActionsDropD.Controls.Add(this.btnEdit);
            this.pnlShapeActionsDropD.Controls.Add(this.btnRemove);
            this.pnlShapeActionsDropD.Controls.Add(this.btnRmvAll);
            this.pnlShapeActionsDropD.Location = new System.Drawing.Point(278, 12);
            this.pnlShapeActionsDropD.MaximumSize = new System.Drawing.Size(162, 187);
            this.pnlShapeActionsDropD.MinimumSize = new System.Drawing.Size(162, 38);
            this.pnlShapeActionsDropD.Name = "pnlShapeActionsDropD";
            this.pnlShapeActionsDropD.Size = new System.Drawing.Size(162, 38);
            this.pnlShapeActionsDropD.TabIndex = 20;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(0, 120);
            this.btnImport.Margin = new System.Windows.Forms.Padding(0);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(117, 30);
            this.btnImport.TabIndex = 14;
            this.btnImport.Text = "Import image";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(0, 30);
            this.btnSave.Margin = new System.Windows.Forms.Padding(0);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(117, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Save File";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnExport
            // 
            this.btnExport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Location = new System.Drawing.Point(0, 90);
            this.btnExport.Margin = new System.Windows.Forms.Padding(0);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 30);
            this.btnExport.TabIndex = 13;
            this.btnExport.Text = "Export image";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoad.Location = new System.Drawing.Point(0, 60);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(0);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(117, 30);
            this.btnLoad.TabIndex = 19;
            this.btnLoad.Text = "Load File";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnFileDropDown
            // 
            this.btnFileDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.btnFileDropDown.FlatAppearance.BorderSize = 0;
            this.btnFileDropDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFileDropDown.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileDropDown.Location = new System.Drawing.Point(0, 0);
            this.btnFileDropDown.Margin = new System.Windows.Forms.Padding(0);
            this.btnFileDropDown.Name = "btnFileDropDown";
            this.btnFileDropDown.Size = new System.Drawing.Size(117, 30);
            this.btnFileDropDown.TabIndex = 22;
            this.btnFileDropDown.Text = "File";
            this.btnFileDropDown.UseVisualStyleBackColor = false;
            this.btnFileDropDown.Click += new System.EventHandler(this.btnFileDropDown_Click);
            // 
            // pnlFileDropDown
            // 
            this.pnlFileDropDown.Controls.Add(this.btnFileDropDown);
            this.pnlFileDropDown.Controls.Add(this.btnLoad);
            this.pnlFileDropDown.Controls.Add(this.btnExport);
            this.pnlFileDropDown.Controls.Add(this.btnSave);
            this.pnlFileDropDown.Controls.Add(this.btnImport);
            this.pnlFileDropDown.Location = new System.Drawing.Point(12, 12);
            this.pnlFileDropDown.MaximumSize = new System.Drawing.Size(117, 152);
            this.pnlFileDropDown.MinimumSize = new System.Drawing.Size(117, 30);
            this.pnlFileDropDown.Name = "pnlFileDropDown";
            this.pnlFileDropDown.Size = new System.Drawing.Size(117, 30);
            this.pnlFileDropDown.TabIndex = 21;
            // 
            // btnFilterShapes
            // 
            this.btnFilterShapes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFilterShapes.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnFilterShapes.FlatAppearance.BorderSize = 0;
            this.btnFilterShapes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterShapes.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterShapes.Location = new System.Drawing.Point(0, 0);
            this.btnFilterShapes.Margin = new System.Windows.Forms.Padding(0);
            this.btnFilterShapes.Name = "btnFilterShapes";
            this.btnFilterShapes.Size = new System.Drawing.Size(199, 38);
            this.btnFilterShapes.TabIndex = 22;
            this.btnFilterShapes.Text = "Filter Shapes";
            this.btnFilterShapes.UseVisualStyleBackColor = false;
            this.btnFilterShapes.Click += new System.EventHandler(this.btnFilterShapes_Click);
            // 
            // pnlFilterShapes
            // 
            this.pnlFilterShapes.Controls.Add(this.btnFilterColors);
            this.pnlFilterShapes.Controls.Add(this.btnFilterShapes);
            this.pnlFilterShapes.Controls.Add(this.btnFilterShapeType);
            this.pnlFilterShapes.Controls.Add(this.btnClearFilter);
            this.pnlFilterShapes.Location = new System.Drawing.Point(707, 12);
            this.pnlFilterShapes.MaximumSize = new System.Drawing.Size(199, 150);
            this.pnlFilterShapes.MinimumSize = new System.Drawing.Size(199, 38);
            this.pnlFilterShapes.Name = "pnlFilterShapes";
            this.pnlFilterShapes.Size = new System.Drawing.Size(199, 38);
            this.pnlFilterShapes.TabIndex = 23;
            // 
            // btnFilterColors
            // 
            this.btnFilterColors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnFilterColors.FlatAppearance.BorderSize = 0;
            this.btnFilterColors.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilterColors.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilterColors.Location = new System.Drawing.Point(0, 75);
            this.btnFilterColors.Margin = new System.Windows.Forms.Padding(0);
            this.btnFilterColors.Name = "btnFilterColors";
            this.btnFilterColors.Size = new System.Drawing.Size(199, 38);
            this.btnFilterColors.TabIndex = 25;
            this.btnFilterColors.Text = "Show same color shape";
            this.btnFilterColors.UseVisualStyleBackColor = false;
            this.btnFilterColors.Click += new System.EventHandler(this.btnFilterColors_Click);
            // 
            // timerFilter
            // 
            this.timerFilter.Interval = 15;
            this.timerFilter.Tick += new System.EventHandler(this.timerFilter_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 683);
            this.Controls.Add(this.pnlFilterShapes);
            this.Controls.Add(this.pnlFileDropDown);
            this.Controls.Add(this.pnlShapeActionsDropD);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.initPointCoord);
            this.Controls.Add(this.btnUndo);
            this.Controls.Add(this.btnRedo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.surfaceAreaLabel);
            this.Controls.Add(this.Scene);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(1052, 730);
            this.Name = "MainForm";
            this.Text = "Graphics app";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.MainForm_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.Scene)).EndInit();
            this.pnlShapeActionsDropD.ResumeLayout(false);
            this.pnlFileDropDown.ResumeLayout(false);
            this.pnlFilterShapes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox Scene;
        private System.Windows.Forms.Button btnFilterShapeType;
        private System.Windows.Forms.Button btnClearFilter;
        private System.Windows.Forms.Timer timerShapeActions;
        private System.Windows.Forms.Timer timerFile;
        private System.Windows.Forms.Label surfaceAreaLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRedo;
        private System.Windows.Forms.Button btnUndo;
        private System.Windows.Forms.Label initPointCoord;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRmvAll;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAddShape;
        private System.Windows.Forms.Button btnShapeDropDown;
        private System.Windows.Forms.Panel pnlShapeActionsDropD;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnFileDropDown;
        private System.Windows.Forms.Panel pnlFileDropDown;
        private System.Windows.Forms.Button btnFilterShapes;
        private System.Windows.Forms.Panel pnlFilterShapes;
        private System.Windows.Forms.Button btnFilterColors;
        private System.Windows.Forms.Timer timerFilter;
    }
}

