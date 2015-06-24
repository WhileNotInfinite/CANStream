namespace CANStream
{
    partial class Frm_CycleDataAssociation
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
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.TSB_New = new System.Windows.Forms.ToolStripButton();
        	this.TSB_Open = new System.Windows.Forms.ToolStripButton();
        	this.TSB_Save = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.Cmd_DataFile = new System.Windows.Forms.Button();
        	this.Txt_DataFile = new System.Windows.Forms.TextBox();
        	this.Lbl_DataFile = new System.Windows.Forms.Label();
        	this.Cmd_CANConfig = new System.Windows.Forms.Button();
        	this.Txt_CANConfig = new System.Windows.Forms.TextBox();
        	this.Lbl_CanConfig = new System.Windows.Forms.Label();
        	this.Grid_Association = new System.Windows.Forms.DataGridView();
        	this.CANParameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.Column1 = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.DataChannel = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.Column2 = new System.Windows.Forms.DataGridViewComboBoxColumn();
        	this.DefaultValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        	this.toolStrip1.SuspendLayout();
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.Grid_Association)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// toolStrip1
        	// 
        	this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
        	this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.TSB_New,
        	        	        	this.TSB_Open,
        	        	        	this.TSB_Save,
        	        	        	this.toolStripSeparator1});
        	this.toolStrip1.Location = new System.Drawing.Point(0, 0);
        	this.toolStrip1.Name = "toolStrip1";
        	this.toolStrip1.Size = new System.Drawing.Size(719, 39);
        	this.toolStrip1.TabIndex = 0;
        	this.toolStrip1.Text = "toolStrip1";
        	// 
        	// TSB_New
        	// 
        	this.TSB_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.TSB_New.Image = global::CANStream.Icones.File_New_32;
        	this.TSB_New.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.TSB_New.Name = "TSB_New";
        	this.TSB_New.Size = new System.Drawing.Size(36, 36);
        	this.TSB_New.Text = "toolStripButton1";
        	this.TSB_New.ToolTipText = "New association";
        	this.TSB_New.Click += new System.EventHandler(this.TSB_New_Click);
        	// 
        	// TSB_Open
        	// 
        	this.TSB_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.TSB_Open.Image = global::CANStream.Icones.File_Open_32;
        	this.TSB_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.TSB_Open.Name = "TSB_Open";
        	this.TSB_Open.Size = new System.Drawing.Size(36, 36);
        	this.TSB_Open.Text = "toolStripButton2";
        	this.TSB_Open.ToolTipText = "Open association";
        	this.TSB_Open.Click += new System.EventHandler(this.TSB_Open_Click);
        	// 
        	// TSB_Save
        	// 
        	this.TSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
        	this.TSB_Save.Image = global::CANStream.Icones.File_Save_32;
        	this.TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.TSB_Save.Name = "TSB_Save";
        	this.TSB_Save.Size = new System.Drawing.Size(36, 36);
        	this.TSB_Save.Text = "toolStripButton3";
        	this.TSB_Save.ToolTipText = "Save association";
        	this.TSB_Save.Click += new System.EventHandler(this.TSB_Save_Click);
        	// 
        	// toolStripSeparator1
        	// 
        	this.toolStripSeparator1.Name = "toolStripSeparator1";
        	this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.Cmd_DataFile);
        	this.groupBox1.Controls.Add(this.Txt_DataFile);
        	this.groupBox1.Controls.Add(this.Lbl_DataFile);
        	this.groupBox1.Controls.Add(this.Cmd_CANConfig);
        	this.groupBox1.Controls.Add(this.Txt_CANConfig);
        	this.groupBox1.Controls.Add(this.Lbl_CanConfig);
        	this.groupBox1.Location = new System.Drawing.Point(12, 42);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(695, 114);
        	this.groupBox1.TabIndex = 1;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "Files";
        	// 
        	// Cmd_DataFile
        	// 
        	this.Cmd_DataFile.Enabled = false;
        	this.Cmd_DataFile.Image = global::CANStream.Icones.File_Open_16;
        	this.Cmd_DataFile.Location = new System.Drawing.Point(664, 85);
        	this.Cmd_DataFile.Name = "Cmd_DataFile";
        	this.Cmd_DataFile.Size = new System.Drawing.Size(25, 25);
        	this.Cmd_DataFile.TabIndex = 7;
        	this.Cmd_DataFile.UseVisualStyleBackColor = true;
        	this.Cmd_DataFile.Click += new System.EventHandler(this.Cmd_DataFile_Click);
        	// 
        	// Txt_DataFile
        	// 
        	this.Txt_DataFile.Enabled = false;
        	this.Txt_DataFile.Location = new System.Drawing.Point(6, 88);
        	this.Txt_DataFile.Name = "Txt_DataFile";
        	this.Txt_DataFile.Size = new System.Drawing.Size(652, 20);
        	this.Txt_DataFile.TabIndex = 6;
        	// 
        	// Lbl_DataFile
        	// 
        	this.Lbl_DataFile.AutoSize = true;
        	this.Lbl_DataFile.Enabled = false;
        	this.Lbl_DataFile.Location = new System.Drawing.Point(6, 68);
        	this.Lbl_DataFile.Name = "Lbl_DataFile";
        	this.Lbl_DataFile.Size = new System.Drawing.Size(89, 13);
        	this.Lbl_DataFile.TabIndex = 5;
        	this.Lbl_DataFile.Text = "Data file template";
        	// 
        	// Cmd_CANConfig
        	// 
        	this.Cmd_CANConfig.Image = global::CANStream.Icones.File_Open_16;
        	this.Cmd_CANConfig.Location = new System.Drawing.Point(664, 42);
        	this.Cmd_CANConfig.Name = "Cmd_CANConfig";
        	this.Cmd_CANConfig.Size = new System.Drawing.Size(25, 25);
        	this.Cmd_CANConfig.TabIndex = 4;
        	this.Cmd_CANConfig.UseVisualStyleBackColor = true;
        	this.Cmd_CANConfig.Click += new System.EventHandler(this.Cmd_CANConfig_Click);
        	// 
        	// Txt_CANConfig
        	// 
        	this.Txt_CANConfig.Location = new System.Drawing.Point(9, 45);
        	this.Txt_CANConfig.Name = "Txt_CANConfig";
        	this.Txt_CANConfig.Size = new System.Drawing.Size(649, 20);
        	this.Txt_CANConfig.TabIndex = 3;
        	// 
        	// Lbl_CanConfig
        	// 
        	this.Lbl_CanConfig.AutoSize = true;
        	this.Lbl_CanConfig.Location = new System.Drawing.Point(6, 29);
        	this.Lbl_CanConfig.Name = "Lbl_CanConfig";
        	this.Lbl_CanConfig.Size = new System.Drawing.Size(94, 13);
        	this.Lbl_CanConfig.TabIndex = 2;
        	this.Lbl_CanConfig.Text = "CAN Configuration";
        	// 
        	// Grid_Association
        	// 
        	this.Grid_Association.AllowUserToAddRows = false;
        	this.Grid_Association.AllowUserToDeleteRows = false;
        	this.Grid_Association.AllowUserToResizeColumns = false;
        	this.Grid_Association.AllowUserToResizeRows = false;
        	this.Grid_Association.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        	this.Grid_Association.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
        	        	        	this.CANParameter,
        	        	        	this.Column1,
        	        	        	this.DataChannel,
        	        	        	this.Column2,
        	        	        	this.DefaultValue});
        	this.Grid_Association.Enabled = false;
        	this.Grid_Association.Location = new System.Drawing.Point(12, 162);
        	this.Grid_Association.Name = "Grid_Association";
        	this.Grid_Association.RowHeadersWidth = 60;
        	this.Grid_Association.Size = new System.Drawing.Size(695, 345);
        	this.Grid_Association.TabIndex = 2;
        	this.Grid_Association.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_Association_CellValueChanged);
        	// 
        	// CANParameter
        	// 
        	this.CANParameter.HeaderText = "CAN Parameter";
        	this.CANParameter.Name = "CANParameter";
        	this.CANParameter.Width = 150;
        	// 
        	// Column1
        	// 
        	this.Column1.HeaderText = "Association type";
        	this.Column1.Name = "Column1";
        	// 
        	// DataChannel
        	// 
        	this.DataChannel.HeaderText = "Data channel";
        	this.DataChannel.Name = "DataChannel";
        	this.DataChannel.Width = 140;
        	// 
        	// Column2
        	// 
        	this.Column2.HeaderText = "Built-in signal";
        	this.Column2.Name = "Column2";
        	this.Column2.Width = 140;
        	// 
        	// DefaultValue
        	// 
        	this.DefaultValue.HeaderText = "Default Value";
        	this.DefaultValue.Name = "DefaultValue";
        	// 
        	// openFileDialog1
        	// 
        	this.openFileDialog1.FileName = "openFileDialog1";
        	// 
        	// Frm_CycleDataAssociation
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(719, 519);
        	this.Controls.Add(this.Grid_Association);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.toolStrip1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = global::CANStream.Icones.CANStream_Icone;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Frm_CycleDataAssociation";
        	this.Text = "Cycle/Data Association";
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.Grid_Association)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.DataGridViewComboBoxColumn Column2;
        private System.Windows.Forms.DataGridViewComboBoxColumn Column1;

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSB_New;
        private System.Windows.Forms.ToolStripButton TSB_Open;
        private System.Windows.Forms.ToolStripButton TSB_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Cmd_DataFile;
        private System.Windows.Forms.TextBox Txt_DataFile;
        private System.Windows.Forms.Label Lbl_DataFile;
        private System.Windows.Forms.Button Cmd_CANConfig;
        private System.Windows.Forms.TextBox Txt_CANConfig;
        private System.Windows.Forms.Label Lbl_CanConfig;
        private System.Windows.Forms.DataGridView Grid_Association;
        private System.Windows.Forms.DataGridViewTextBoxColumn CANParameter;
        private System.Windows.Forms.DataGridViewComboBoxColumn DataChannel;
        private System.Windows.Forms.DataGridViewTextBoxColumn DefaultValue;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}