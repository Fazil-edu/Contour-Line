namespace HillCalculation
{
    partial class Hill
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.TransportTimeDGV = new System.Windows.Forms.DataGridView();
            this.volumeWordLabel = new System.Windows.Forms.Label();
            this.volumeNumberLabel = new System.Windows.Forms.Label();
            this.textBoxFilePath = new System.Windows.Forms.TextBox();
            this.PathOfTheFile = new System.Windows.Forms.Label();
            this.measuringPointsDGV = new System.Windows.Forms.DataGridView();
            this.StripMenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectFileToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.CalculateStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.VolumeToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberOfTrucksMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.NumberOfTrucksTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.DrawToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.BarShapesToolStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.xPerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yPerspectiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            ((System.ComponentModel.ISupportInitialize)(this.TransportTimeDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.measuringPointsDGV)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TransportTimeDGV
            // 
            this.TransportTimeDGV.AllowUserToAddRows = false;
            this.TransportTimeDGV.AllowUserToDeleteRows = false;
            this.TransportTimeDGV.AllowUserToResizeColumns = false;
            this.TransportTimeDGV.AllowUserToResizeRows = false;
            this.TransportTimeDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.TransportTimeDGV.ColumnHeadersVisible = false;
            this.TransportTimeDGV.Location = new System.Drawing.Point(572, 27);
            this.TransportTimeDGV.Name = "TransportTimeDGV";
            this.TransportTimeDGV.ReadOnly = true;
            this.TransportTimeDGV.RowHeadersVisible = false;
            this.TransportTimeDGV.Size = new System.Drawing.Size(320, 312);
            this.TransportTimeDGV.TabIndex = 0;
            this.TransportTimeDGV.Visible = false;
            // 
            // volumeWordLabel
            // 
            this.volumeWordLabel.AutoSize = true;
            this.volumeWordLabel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeWordLabel.Location = new System.Drawing.Point(567, 350);
            this.volumeWordLabel.Name = "volumeWordLabel";
            this.volumeWordLabel.Size = new System.Drawing.Size(86, 25);
            this.volumeWordLabel.TabIndex = 1;
            this.volumeWordLabel.Text = "Volumen:";
            this.volumeWordLabel.Visible = false;
            // 
            // volumeNumberLabel
            // 
            this.volumeNumberLabel.AutoSize = true;
            this.volumeNumberLabel.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeNumberLabel.Location = new System.Drawing.Point(689, 352);
            this.volumeNumberLabel.Name = "volumeNumberLabel";
            this.volumeNumberLabel.Size = new System.Drawing.Size(155, 23);
            this.volumeNumberLabel.TabIndex = 1;
            this.volumeNumberLabel.Text = "volumeNumberLabel";
            this.volumeNumberLabel.Visible = false;
            // 
            // textBoxFilePath
            // 
            this.textBoxFilePath.Location = new System.Drawing.Point(141, 350);
            this.textBoxFilePath.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxFilePath.Name = "textBoxFilePath";
            this.textBoxFilePath.ReadOnly = true;
            this.textBoxFilePath.Size = new System.Drawing.Size(415, 20);
            this.textBoxFilePath.TabIndex = 12;
            this.textBoxFilePath.Visible = false;
            // 
            // PathOfTheFile
            // 
            this.PathOfTheFile.AutoSize = true;
            this.PathOfTheFile.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PathOfTheFile.Location = new System.Drawing.Point(7, 347);
            this.PathOfTheFile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PathOfTheFile.Name = "PathOfTheFile";
            this.PathOfTheFile.Size = new System.Drawing.Size(126, 25);
            this.PathOfTheFile.TabIndex = 11;
            this.PathOfTheFile.Text = "Path of the file";
            this.PathOfTheFile.Visible = false;
            // 
            // measuringPointsDGV
            // 
            this.measuringPointsDGV.AllowUserToAddRows = false;
            this.measuringPointsDGV.AllowUserToDeleteRows = false;
            this.measuringPointsDGV.AllowUserToResizeColumns = false;
            this.measuringPointsDGV.AllowUserToResizeRows = false;
            this.measuringPointsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.DisplayedCells;
            this.measuringPointsDGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
            this.measuringPointsDGV.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.measuringPointsDGV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.measuringPointsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.measuringPointsDGV.ColumnHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.measuringPointsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            this.measuringPointsDGV.Location = new System.Drawing.Point(12, 27);
            this.measuringPointsDGV.Name = "measuringPointsDGV";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.measuringPointsDGV.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.measuringPointsDGV.RowHeadersVisible = false;
            this.measuringPointsDGV.RowHeadersWidth = 55;
            this.measuringPointsDGV.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.measuringPointsDGV.Size = new System.Drawing.Size(544, 312);
            this.measuringPointsDGV.TabIndex = 0;
            this.measuringPointsDGV.Visible = false;
            // 
            // StripMenuFile
            // 
            this.StripMenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectFileToolStripMenu});
            this.StripMenuFile.Name = "StripMenuFile";
            this.StripMenuFile.Size = new System.Drawing.Size(37, 20);
            this.StripMenuFile.Text = "File";
            // 
            // SelectFileToolStripMenu
            // 
            this.SelectFileToolStripMenu.Name = "SelectFileToolStripMenu";
            this.SelectFileToolStripMenu.Size = new System.Drawing.Size(127, 22);
            this.SelectFileToolStripMenu.Text = "Select  file";
            this.SelectFileToolStripMenu.Click += new System.EventHandler(this.SelectFileToolStripMenu_Click);
            // 
            // CalculateStripMenu
            // 
            this.CalculateStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VolumeToolStripMenu,
            this.NumberOfTrucksMenu});
            this.CalculateStripMenu.Enabled = false;
            this.CalculateStripMenu.Name = "CalculateStripMenu";
            this.CalculateStripMenu.Size = new System.Drawing.Size(68, 20);
            this.CalculateStripMenu.Text = "Calculate";
            // 
            // VolumeToolStripMenu
            // 
            this.VolumeToolStripMenu.Name = "VolumeToolStripMenu";
            this.VolumeToolStripMenu.Size = new System.Drawing.Size(211, 22);
            this.VolumeToolStripMenu.Text = "Volume";
            this.VolumeToolStripMenu.Click += new System.EventHandler(this.VolumeToolStripMenu_Click);
            // 
            // NumberOfTrucksMenu
            // 
            this.NumberOfTrucksMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NumberOfTrucksTextBox});
            this.NumberOfTrucksMenu.Name = "NumberOfTrucksMenu";
            this.NumberOfTrucksMenu.Size = new System.Drawing.Size(211, 22);
            this.NumberOfTrucksMenu.Text = "Number of existing trucks";
            // 
            // NumberOfTrucksTextBox
            // 
            this.NumberOfTrucksTextBox.Name = "NumberOfTrucksTextBox";
            this.NumberOfTrucksTextBox.Size = new System.Drawing.Size(100, 23);
            this.NumberOfTrucksTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumberOfTrucksTextBox_KeyPress);
            // 
            // DrawToolStripMenu
            // 
            this.DrawToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BarShapesToolStripMenu});
            this.DrawToolStripMenu.Enabled = false;
            this.DrawToolStripMenu.Name = "DrawToolStripMenu";
            this.DrawToolStripMenu.Size = new System.Drawing.Size(46, 20);
            this.DrawToolStripMenu.Text = "Draw";
            // 
            // BarShapesToolStripMenu
            // 
            this.BarShapesToolStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.xPerspectiveToolStripMenuItem,
            this.yPerspectiveToolStripMenuItem});
            this.BarShapesToolStripMenu.Name = "BarShapesToolStripMenu";
            this.BarShapesToolStripMenu.Size = new System.Drawing.Size(130, 22);
            this.BarShapesToolStripMenu.Text = "Bar shapes";
            // 
            // xPerspectiveToolStripMenuItem
            // 
            this.xPerspectiveToolStripMenuItem.Name = "xPerspectiveToolStripMenuItem";
            this.xPerspectiveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.xPerspectiveToolStripMenuItem.Text = "x perspective";
            this.xPerspectiveToolStripMenuItem.Click += new System.EventHandler(this.XPerspectiveToolStripMenuItem_Click);
            // 
            // yPerspectiveToolStripMenuItem
            // 
            this.yPerspectiveToolStripMenuItem.Name = "yPerspectiveToolStripMenuItem";
            this.yPerspectiveToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.yPerspectiveToolStripMenuItem.Text = "y perspective";
            this.yPerspectiveToolStripMenuItem.Click += new System.EventHandler(this.YPerspectiveToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripMenuFile,
            this.CalculateStripMenu,
            this.DrawToolStripMenu});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(904, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Hill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 943);
            this.Controls.Add(this.PathOfTheFile);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.textBoxFilePath);
            this.Controls.Add(this.volumeNumberLabel);
            this.Controls.Add(this.measuringPointsDGV);
            this.Controls.Add(this.volumeWordLabel);
            this.Controls.Add(this.TransportTimeDGV);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Hill";
            this.Text = "Hill";
            ((System.ComponentModel.ISupportInitialize)(this.TransportTimeDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.measuringPointsDGV)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView TransportTimeDGV;
        private System.Windows.Forms.Label volumeWordLabel;
        private System.Windows.Forms.Label volumeNumberLabel;
        private System.Windows.Forms.TextBox textBoxFilePath;
        private System.Windows.Forms.Label PathOfTheFile;
        private System.Windows.Forms.DataGridView measuringPointsDGV;
        private System.Windows.Forms.ToolStripMenuItem StripMenuFile;
        private System.Windows.Forms.ToolStripMenuItem SelectFileToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem CalculateStripMenu;
        private System.Windows.Forms.ToolStripMenuItem VolumeToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem NumberOfTrucksMenu;
        private System.Windows.Forms.ToolStripTextBox NumberOfTrucksTextBox;
        private System.Windows.Forms.ToolStripMenuItem DrawToolStripMenu;
        private System.Windows.Forms.ToolStripMenuItem BarShapesToolStripMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem xPerspectiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yPerspectiveToolStripMenuItem;
    }
}

