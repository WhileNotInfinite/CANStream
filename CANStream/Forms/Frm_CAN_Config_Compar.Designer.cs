namespace CANStream
{
    partial class Frm_CAN_Config_Compar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CAN_Config_Compar));
            this.TS_Main = new System.Windows.Forms.ToolStrip();
            this.TS_Lbl_FileA = new System.Windows.Forms.ToolStripLabel();
            this.TS_Btn_FileA_Open = new System.Windows.Forms.ToolStripButton();
            this.TS_Btn_FileA_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TS_Lbl_FileB = new System.Windows.Forms.ToolStripLabel();
            this.TS_Btn_FileB_Open = new System.Windows.Forms.ToolStripButton();
            this.TS_Btn_FileB_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TS_Btn_SaveAll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TS_Btn_MergeAll_B_to_A = new System.Windows.Forms.ToolStripButton();
            this.TS_Btn_Merge_B_to_A = new System.Windows.Forms.ToolStripButton();
            this.TS_Btn_Merge_A_to_B = new System.Windows.Forms.ToolStripButton();
            this.TS_Btn_MergeAll_A_to_B = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.TS_DropBtn_Filter = new System.Windows.Forms.ToolStripDropDownButton();
            this.TS_Btn_RefreshCompar = new System.Windows.Forms.ToolStripButton();
            this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBar_Lbl_FileA = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Lbl_FileB = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBar_Lbl_DiffCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBar_Lbl_MergeCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.CGrid_Comparison = new CANStream.Ctrl_CollapsableGrid();
            this.TS_Main.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TS_Main
            // 
            this.TS_Main.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TS_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Lbl_FileA,
            this.TS_Btn_FileA_Open,
            this.TS_Btn_FileA_Save,
            this.toolStripSeparator1,
            this.TS_Lbl_FileB,
            this.TS_Btn_FileB_Open,
            this.TS_Btn_FileB_Save,
            this.toolStripSeparator2,
            this.TS_Btn_SaveAll,
            this.toolStripSeparator3,
            this.TS_Btn_MergeAll_B_to_A,
            this.TS_Btn_Merge_B_to_A,
            this.TS_Btn_Merge_A_to_B,
            this.TS_Btn_MergeAll_A_to_B,
            this.toolStripSeparator6,
            this.TS_DropBtn_Filter,
            this.TS_Btn_RefreshCompar});
            this.TS_Main.Location = new System.Drawing.Point(0, 0);
            this.TS_Main.Name = "TS_Main";
            this.TS_Main.Size = new System.Drawing.Size(946, 39);
            this.TS_Main.TabIndex = 0;
            this.TS_Main.Text = "toolStrip1";
            // 
            // TS_Lbl_FileA
            // 
            this.TS_Lbl_FileA.Name = "TS_Lbl_FileA";
            this.TS_Lbl_FileA.Size = new System.Drawing.Size(36, 36);
            this.TS_Lbl_FileA.Text = "File A";
            // 
            // TS_Btn_FileA_Open
            // 
            this.TS_Btn_FileA_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_FileA_Open.Image = global::CANStream.Icones.CanCfg_Compar_FileA_Open_2_32;
            this.TS_Btn_FileA_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_FileA_Open.Name = "TS_Btn_FileA_Open";
            this.TS_Btn_FileA_Open.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_FileA_Open.Text = "toolStripButton1";
            this.TS_Btn_FileA_Open.ToolTipText = "Open comparison file A";
            this.TS_Btn_FileA_Open.Click += new System.EventHandler(this.TS_Btn_FileA_Open_Click);
            // 
            // TS_Btn_FileA_Save
            // 
            this.TS_Btn_FileA_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_FileA_Save.Image = global::CANStream.Icones.CanCfg_Compar_FileA_Save_2_32;
            this.TS_Btn_FileA_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_FileA_Save.Name = "TS_Btn_FileA_Save";
            this.TS_Btn_FileA_Save.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_FileA_Save.Text = "toolStripButton2";
            this.TS_Btn_FileA_Save.ToolTipText = "Save comparison file A";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // TS_Lbl_FileB
            // 
            this.TS_Lbl_FileB.Name = "TS_Lbl_FileB";
            this.TS_Lbl_FileB.Size = new System.Drawing.Size(35, 36);
            this.TS_Lbl_FileB.Text = "File B";
            // 
            // TS_Btn_FileB_Open
            // 
            this.TS_Btn_FileB_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_FileB_Open.Image = global::CANStream.Icones.CanCfg_Compar_FileB_Open_2_32;
            this.TS_Btn_FileB_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_FileB_Open.Name = "TS_Btn_FileB_Open";
            this.TS_Btn_FileB_Open.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_FileB_Open.Text = "toolStripButton3";
            this.TS_Btn_FileB_Open.ToolTipText = "Open comparison file B";
            this.TS_Btn_FileB_Open.Click += new System.EventHandler(this.TS_Btn_FileB_Open_Click);
            // 
            // TS_Btn_FileB_Save
            // 
            this.TS_Btn_FileB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_FileB_Save.Image = global::CANStream.Icones.CanCfg_Compar_FileB_Save_2_32;
            this.TS_Btn_FileB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_FileB_Save.Name = "TS_Btn_FileB_Save";
            this.TS_Btn_FileB_Save.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_FileB_Save.Text = "toolStripButton4";
            this.TS_Btn_FileB_Save.ToolTipText = "Save comparison file B";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // TS_Btn_SaveAll
            // 
            this.TS_Btn_SaveAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_SaveAll.Image = global::CANStream.Icones.File_SaveAll_32;
            this.TS_Btn_SaveAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_SaveAll.Name = "TS_Btn_SaveAll";
            this.TS_Btn_SaveAll.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_SaveAll.Text = "toolStripButton5";
            this.TS_Btn_SaveAll.ToolTipText = "Save both comparison files";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // TS_Btn_MergeAll_B_to_A
            // 
            this.TS_Btn_MergeAll_B_to_A.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_MergeAll_B_to_A.Image = global::CANStream.Icones.CanCfg_Compar_MergeAll_B2A_2_32;
            this.TS_Btn_MergeAll_B_to_A.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_MergeAll_B_to_A.Name = "TS_Btn_MergeAll_B_to_A";
            this.TS_Btn_MergeAll_B_to_A.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_MergeAll_B_to_A.Text = "toolStripButton6";
            this.TS_Btn_MergeAll_B_to_A.ToolTipText = "Merge all differences from file B to file A";
            // 
            // TS_Btn_Merge_B_to_A
            // 
            this.TS_Btn_Merge_B_to_A.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_Merge_B_to_A.Image = global::CANStream.Icones.CanCfg_Compar_Merge_B2A_2_32;
            this.TS_Btn_Merge_B_to_A.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_Merge_B_to_A.Name = "TS_Btn_Merge_B_to_A";
            this.TS_Btn_Merge_B_to_A.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_Merge_B_to_A.Text = "toolStripButton7";
            this.TS_Btn_Merge_B_to_A.ToolTipText = "Merge value from file B to file A";
            // 
            // TS_Btn_Merge_A_to_B
            // 
            this.TS_Btn_Merge_A_to_B.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_Merge_A_to_B.Image = global::CANStream.Icones.CanCfg_Compar_Merge_A2B_2_32;
            this.TS_Btn_Merge_A_to_B.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_Merge_A_to_B.Name = "TS_Btn_Merge_A_to_B";
            this.TS_Btn_Merge_A_to_B.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_Merge_A_to_B.Text = "toolStripButton10";
            this.TS_Btn_Merge_A_to_B.ToolTipText = "Merge value from file A to file B";
            // 
            // TS_Btn_MergeAll_A_to_B
            // 
            this.TS_Btn_MergeAll_A_to_B.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_MergeAll_A_to_B.Image = global::CANStream.Icones.CanCfg_Compar_MergeAll_A2B_2_32;
            this.TS_Btn_MergeAll_A_to_B.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_MergeAll_A_to_B.Name = "TS_Btn_MergeAll_A_to_B";
            this.TS_Btn_MergeAll_A_to_B.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_MergeAll_A_to_B.Text = "toolStripButton11";
            this.TS_Btn_MergeAll_A_to_B.ToolTipText = "Merge all differences from file A to file B";
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(6, 39);
            // 
            // TS_DropBtn_Filter
            // 
            this.TS_DropBtn_Filter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_DropBtn_Filter.Image = global::CANStream.Icones.CanCfg_Compar_Filter_2_32;
            this.TS_DropBtn_Filter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_DropBtn_Filter.Name = "TS_DropBtn_Filter";
            this.TS_DropBtn_Filter.Size = new System.Drawing.Size(45, 36);
            this.TS_DropBtn_Filter.Text = "toolStripDropDownButton1";
            this.TS_DropBtn_Filter.ToolTipText = "Properties comparison filter";
            // 
            // TS_Btn_RefreshCompar
            // 
            this.TS_Btn_RefreshCompar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TS_Btn_RefreshCompar.Image = global::CANStream.Icones.Refresh_CAN_Controllers_32_2;
            this.TS_Btn_RefreshCompar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TS_Btn_RefreshCompar.Name = "TS_Btn_RefreshCompar";
            this.TS_Btn_RefreshCompar.Size = new System.Drawing.Size(36, 36);
            this.TS_Btn_RefreshCompar.Text = "toolStripButton1";
            this.TS_Btn_RefreshCompar.ToolTipText = "Refresh comparison";
            this.TS_Btn_RefreshCompar.Click += new System.EventHandler(this.TS_Btn_RefreshCompar_Click);
            // 
            // Dlg_OpenFile
            // 
            this.Dlg_OpenFile.Filter = "CAN Configuration file|*.xcc|Multiple CAN bus configuration|*.mcb";
            // 
            // Dlg_SaveFile
            // 
            this.Dlg_SaveFile.Filter = "CAN Configuration file|*.xcc|Multiple CAN bus configuration|*.mcb";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBar_Lbl_FileA,
            this.StatusBar_Lbl_FileB,
            this.StatusBar_Lbl_DiffCount,
            this.StatusBar_Lbl_MergeCount,
            this.StatusBar_Progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 473);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(946, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusBar_Lbl_FileA
            // 
            this.StatusBar_Lbl_FileA.Name = "StatusBar_Lbl_FileA";
            this.StatusBar_Lbl_FileA.Size = new System.Drawing.Size(118, 17);
            this.StatusBar_Lbl_FileA.Text = "toolStripStatusLabel2";
            this.StatusBar_Lbl_FileA.Visible = false;
            // 
            // StatusBar_Lbl_FileB
            // 
            this.StatusBar_Lbl_FileB.Name = "StatusBar_Lbl_FileB";
            this.StatusBar_Lbl_FileB.Size = new System.Drawing.Size(118, 17);
            this.StatusBar_Lbl_FileB.Text = "toolStripStatusLabel1";
            this.StatusBar_Lbl_FileB.Visible = false;
            // 
            // StatusBar_Progress
            // 
            this.StatusBar_Progress.Name = "StatusBar_Progress";
            this.StatusBar_Progress.Size = new System.Drawing.Size(400, 16);
            this.StatusBar_Progress.Visible = false;
            // 
            // StatusBar_Lbl_DiffCount
            // 
            this.StatusBar_Lbl_DiffCount.Name = "StatusBar_Lbl_DiffCount";
            this.StatusBar_Lbl_DiffCount.Size = new System.Drawing.Size(118, 17);
            this.StatusBar_Lbl_DiffCount.Text = "toolStripStatusLabel1";
            this.StatusBar_Lbl_DiffCount.Visible = false;
            // 
            // StatusBar_Lbl_MergeCount
            // 
            this.StatusBar_Lbl_MergeCount.Name = "StatusBar_Lbl_MergeCount";
            this.StatusBar_Lbl_MergeCount.Size = new System.Drawing.Size(118, 17);
            this.StatusBar_Lbl_MergeCount.Text = "toolStripStatusLabel2";
            this.StatusBar_Lbl_MergeCount.Visible = false;
            // 
            // CGrid_Comparison
            // 
            this.CGrid_Comparison.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CGrid_Comparison.Location = new System.Drawing.Point(0, 42);
            this.CGrid_Comparison.Name = "CGrid_Comparison";
            this.CGrid_Comparison.Size = new System.Drawing.Size(946, 428);
            this.CGrid_Comparison.TabIndex = 1;
            // 
            // Frm_CAN_Config_Compar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 495);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.CGrid_Comparison);
            this.Controls.Add(this.TS_Main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_CAN_Config_Compar";
            this.Text = "CAN Configuration compare";
            this.TS_Main.ResumeLayout(false);
            this.TS_Main.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TS_Main;
        private System.Windows.Forms.ToolStripButton TS_Btn_FileA_Open;
        private System.Windows.Forms.ToolStripButton TS_Btn_FileA_Save;
        private Ctrl_CollapsableGrid CGrid_Comparison;
        private System.Windows.Forms.ToolStripLabel TS_Lbl_FileA;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel TS_Lbl_FileB;
        private System.Windows.Forms.ToolStripButton TS_Btn_FileB_Open;
        private System.Windows.Forms.ToolStripButton TS_Btn_FileB_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TS_Btn_SaveAll;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton TS_Btn_MergeAll_B_to_A;
        private System.Windows.Forms.ToolStripButton TS_Btn_Merge_B_to_A;
        private System.Windows.Forms.ToolStripButton TS_Btn_Merge_A_to_B;
        private System.Windows.Forms.ToolStripButton TS_Btn_MergeAll_A_to_B;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripDropDownButton TS_DropBtn_Filter;
        private System.Windows.Forms.OpenFileDialog Dlg_OpenFile;
        private System.Windows.Forms.SaveFileDialog Dlg_SaveFile;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Lbl_FileA;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Lbl_FileB;
        private System.Windows.Forms.ToolStripProgressBar StatusBar_Progress;
        private System.Windows.Forms.ToolStripButton TS_Btn_RefreshCompar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Lbl_DiffCount;
        private System.Windows.Forms.ToolStripStatusLabel StatusBar_Lbl_MergeCount;
    }
}