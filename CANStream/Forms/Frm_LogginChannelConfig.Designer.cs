namespace CANStream
{
    partial class Frm_LogginChannelConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_LogginChannelConfig));
            this.TS_Main = new System.Windows.Forms.ToolStrip();
            this.TSB_New = new System.Windows.Forms.ToolStripButton();
            this.TSB_Open = new System.Windows.Forms.ToolStripButton();
            this.TSB_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_Copy = new System.Windows.Forms.ToolStripButton();
            this.TSB_Paste = new System.Windows.Forms.ToolStripButton();
            this.TSB_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_CanConfig = new System.Windows.Forms.ToolStripButton();
            this.TSB_VirtualChan = new System.Windows.Forms.ToolStripButton();
            this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.ctrl_CollapsableGrid1 = new CANStream.Ctrl_CollapsableGrid();
            this.TS_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // TS_Main
            // 
            this.TS_Main.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TS_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_New,
            this.TSB_Open,
            this.TSB_Save,
            this.toolStripSeparator1,
            this.TSB_Copy,
            this.TSB_Paste,
            this.TSB_Delete,
            this.toolStripSeparator2,
            this.TSB_CanConfig,
            this.TSB_VirtualChan});
            this.TS_Main.Location = new System.Drawing.Point(0, 0);
            this.TS_Main.Name = "TS_Main";
            this.TS_Main.Size = new System.Drawing.Size(791, 39);
            this.TS_Main.TabIndex = 0;
            this.TS_Main.Text = "toolStrip1";
            // 
            // TSB_New
            // 
            this.TSB_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_New.Image = global::CANStream.Icones.File_New_32;
            this.TSB_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_New.Name = "TSB_New";
            this.TSB_New.Size = new System.Drawing.Size(36, 36);
            this.TSB_New.Text = "toolStripButton1";
            this.TSB_New.ToolTipText = "New logging channels configuration";
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
            this.TSB_Open.ToolTipText = "Open a logging channels configuration";
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
            this.TSB_Save.ToolTipText = "Save current logging channels configuration";
            this.TSB_Save.Click += new System.EventHandler(this.TSB_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_Copy
            // 
            this.TSB_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Copy.Image = global::CANStream.Icones.Copy_32;
            this.TSB_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Copy.Name = "TSB_Copy";
            this.TSB_Copy.Size = new System.Drawing.Size(36, 36);
            this.TSB_Copy.Text = "toolStripButton4";
            this.TSB_Copy.ToolTipText = "Copy selected items";
            this.TSB_Copy.Click += new System.EventHandler(this.TSB_Copy_Click);
            // 
            // TSB_Paste
            // 
            this.TSB_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Paste.Image = global::CANStream.Icones.Paste_32;
            this.TSB_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Paste.Name = "TSB_Paste";
            this.TSB_Paste.Size = new System.Drawing.Size(36, 36);
            this.TSB_Paste.Text = "toolStripButton5";
            this.TSB_Paste.ToolTipText = "Paste copied items";
            this.TSB_Paste.Click += new System.EventHandler(this.TSB_Paste_Click);
            // 
            // TSB_Delete
            // 
            this.TSB_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Delete.Image = global::CANStream.Icones.Delete_32;
            this.TSB_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Delete.Name = "TSB_Delete";
            this.TSB_Delete.Size = new System.Drawing.Size(36, 36);
            this.TSB_Delete.Text = "toolStripButton1";
            this.TSB_Delete.ToolTipText = "Delete selected items";
            this.TSB_Delete.Click += new System.EventHandler(this.TSB_Delete_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_CanConfig
            // 
            this.TSB_CanConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_CanConfig.Image = global::CANStream.Icones.CANStream_32;
            this.TSB_CanConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_CanConfig.Name = "TSB_CanConfig";
            this.TSB_CanConfig.Size = new System.Drawing.Size(36, 36);
            this.TSB_CanConfig.Text = "toolStripButton6";
            this.TSB_CanConfig.ToolTipText = "Import a CAN Configuration";
            this.TSB_CanConfig.Click += new System.EventHandler(this.TSB_CanConfig_Click);
            // 
            // TSB_VirtualChan
            // 
            this.TSB_VirtualChan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_VirtualChan.Image = global::CANStream.Icones.Virtual_Channel_32;
            this.TSB_VirtualChan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_VirtualChan.Name = "TSB_VirtualChan";
            this.TSB_VirtualChan.Size = new System.Drawing.Size(36, 36);
            this.TSB_VirtualChan.Text = "toolStripButton7";
            this.TSB_VirtualChan.ToolTipText = "Import a new virtual channels library";
            this.TSB_VirtualChan.Click += new System.EventHandler(this.TSB_VirtualChan_Click);
            // 
            // Dlg_OpenFile
            // 
            this.Dlg_OpenFile.FileName = "openFileDialog1";
            // 
            // ctrl_CollapsableGrid1
            // 
            this.ctrl_CollapsableGrid1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctrl_CollapsableGrid1.Location = new System.Drawing.Point(0, 42);
            this.ctrl_CollapsableGrid1.Name = "ctrl_CollapsableGrid1";
            this.ctrl_CollapsableGrid1.Size = new System.Drawing.Size(791, 360);
            this.ctrl_CollapsableGrid1.TabIndex = 1;
            // 
            // Frm_LogginChannelConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(791, 404);
            this.Controls.Add(this.ctrl_CollapsableGrid1);
            this.Controls.Add(this.TS_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_LogginChannelConfig";
            this.Text = "Logging channels configuration";
            this.TS_Main.ResumeLayout(false);
            this.TS_Main.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TS_Main;
        private System.Windows.Forms.ToolStripButton TSB_New;
        private System.Windows.Forms.ToolStripButton TSB_Open;
        private System.Windows.Forms.ToolStripButton TSB_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_Copy;
        private System.Windows.Forms.ToolStripButton TSB_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSB_CanConfig;
        private System.Windows.Forms.ToolStripButton TSB_VirtualChan;
        private System.Windows.Forms.ToolStripButton TSB_Delete;
        private System.Windows.Forms.OpenFileDialog Dlg_OpenFile;
        private System.Windows.Forms.SaveFileDialog Dlg_SaveFile;
        private Ctrl_CollapsableGrid ctrl_CollapsableGrid1;
    }
}