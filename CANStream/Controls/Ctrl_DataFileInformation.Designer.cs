namespace CANStream
{
    partial class Ctrl_DataFileInformation
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Grp_FileInfo = new System.Windows.Forms.GroupBox();
            this.Txt_FileComment = new System.Windows.Forms.TextBox();
            this.Txt_FileStartTime = new System.Windows.Forms.TextBox();
            this.Lbl_FileComment = new System.Windows.Forms.Label();
            this.Lbl_FileStartTime = new System.Windows.Forms.Label();
            this.Grp_File_CustomProperties = new System.Windows.Forms.GroupBox();
            this.cRUI_FileCustomProperties = new CANStream.Ctrl_RecordUserInformations();
            this.Grp_FileChannels = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cCL_FileChannelList = new Ctrl_GraphWindow.Ctrl_GW_ChannelList();
            this.GV_DataChannelProperties = new System.Windows.Forms.DataGridView();
            this.Col_ChannelProp_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_ChannelProp_Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grp_FileInfo.SuspendLayout();
            this.Grp_File_CustomProperties.SuspendLayout();
            this.Grp_FileChannels.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GV_DataChannelProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // Grp_FileInfo
            // 
            this.Grp_FileInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_FileInfo.Controls.Add(this.Txt_FileComment);
            this.Grp_FileInfo.Controls.Add(this.Txt_FileStartTime);
            this.Grp_FileInfo.Controls.Add(this.Lbl_FileComment);
            this.Grp_FileInfo.Controls.Add(this.Lbl_FileStartTime);
            this.Grp_FileInfo.Location = new System.Drawing.Point(3, 3);
            this.Grp_FileInfo.Name = "Grp_FileInfo";
            this.Grp_FileInfo.Size = new System.Drawing.Size(409, 118);
            this.Grp_FileInfo.TabIndex = 0;
            this.Grp_FileInfo.TabStop = false;
            this.Grp_FileInfo.Text = "File information";
            // 
            // Txt_FileComment
            // 
            this.Txt_FileComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_FileComment.Location = new System.Drawing.Point(63, 51);
            this.Txt_FileComment.Multiline = true;
            this.Txt_FileComment.Name = "Txt_FileComment";
            this.Txt_FileComment.Size = new System.Drawing.Size(340, 58);
            this.Txt_FileComment.TabIndex = 4;
            // 
            // Txt_FileStartTime
            // 
            this.Txt_FileStartTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_FileStartTime.Location = new System.Drawing.Point(63, 19);
            this.Txt_FileStartTime.Name = "Txt_FileStartTime";
            this.Txt_FileStartTime.ReadOnly = true;
            this.Txt_FileStartTime.Size = new System.Drawing.Size(340, 20);
            this.Txt_FileStartTime.TabIndex = 3;
            // 
            // Lbl_FileComment
            // 
            this.Lbl_FileComment.AutoSize = true;
            this.Lbl_FileComment.Location = new System.Drawing.Point(3, 51);
            this.Lbl_FileComment.Name = "Lbl_FileComment";
            this.Lbl_FileComment.Size = new System.Drawing.Size(51, 13);
            this.Lbl_FileComment.TabIndex = 2;
            this.Lbl_FileComment.Text = "Comment";
            // 
            // Lbl_FileStartTime
            // 
            this.Lbl_FileStartTime.AutoSize = true;
            this.Lbl_FileStartTime.Location = new System.Drawing.Point(3, 22);
            this.Lbl_FileStartTime.Name = "Lbl_FileStartTime";
            this.Lbl_FileStartTime.Size = new System.Drawing.Size(51, 13);
            this.Lbl_FileStartTime.TabIndex = 1;
            this.Lbl_FileStartTime.Text = "Start time";
            // 
            // Grp_File_CustomProperties
            // 
            this.Grp_File_CustomProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_File_CustomProperties.Controls.Add(this.cRUI_FileCustomProperties);
            this.Grp_File_CustomProperties.Location = new System.Drawing.Point(3, 127);
            this.Grp_File_CustomProperties.Name = "Grp_File_CustomProperties";
            this.Grp_File_CustomProperties.Size = new System.Drawing.Size(409, 187);
            this.Grp_File_CustomProperties.TabIndex = 1;
            this.Grp_File_CustomProperties.TabStop = false;
            this.Grp_File_CustomProperties.Text = "File custom properties";
            // 
            // cRUI_FileCustomProperties
            // 
            this.cRUI_FileCustomProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cRUI_FileCustomProperties.Location = new System.Drawing.Point(6, 19);
            this.cRUI_FileCustomProperties.Name = "cRUI_FileCustomProperties";
            this.cRUI_FileCustomProperties.Size = new System.Drawing.Size(397, 162);
            this.cRUI_FileCustomProperties.TabIndex = 0;
            // 
            // Grp_FileChannels
            // 
            this.Grp_FileChannels.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_FileChannels.Controls.Add(this.splitContainer1);
            this.Grp_FileChannels.Location = new System.Drawing.Point(3, 320);
            this.Grp_FileChannels.Name = "Grp_FileChannels";
            this.Grp_FileChannels.Size = new System.Drawing.Size(409, 282);
            this.Grp_FileChannels.TabIndex = 2;
            this.Grp_FileChannels.TabStop = false;
            this.Grp_FileChannels.Text = "File channels";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(6, 19);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cCL_FileChannelList);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.GV_DataChannelProperties);
            this.splitContainer1.Size = new System.Drawing.Size(397, 257);
            this.splitContainer1.SplitterDistance = 115;
            this.splitContainer1.TabIndex = 0;
            // 
            // cCL_FileChannelList
            // 
            this.cCL_FileChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cCL_FileChannelList.Location = new System.Drawing.Point(3, 3);
            this.cCL_FileChannelList.Name = "cCL_FileChannelList";
            this.cCL_FileChannelList.Size = new System.Drawing.Size(109, 251);
            this.cCL_FileChannelList.TabIndex = 0;
            this.cCL_FileChannelList.DataChannelClicked += new System.EventHandler<Ctrl_GraphWindow.ChannelClickEventArgs>(this.cCL_FileChannelList_DataChannelClicked);
            this.cCL_FileChannelList.DataChannelSelectionChanged += new System.EventHandler<Ctrl_GraphWindow.ChannelSelectionChangedEventArgs>(this.cCL_FileChannelList_DataChannelSelectionChanged);
            // 
            // GV_DataChannelProperties
            // 
            this.GV_DataChannelProperties.AllowUserToAddRows = false;
            this.GV_DataChannelProperties.AllowUserToDeleteRows = false;
            this.GV_DataChannelProperties.AllowUserToResizeRows = false;
            this.GV_DataChannelProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GV_DataChannelProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GV_DataChannelProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_ChannelProp_Name,
            this.Col_ChannelProp_Value});
            this.GV_DataChannelProperties.Location = new System.Drawing.Point(3, 6);
            this.GV_DataChannelProperties.Name = "GV_DataChannelProperties";
            this.GV_DataChannelProperties.RowHeadersVisible = false;
            this.GV_DataChannelProperties.Size = new System.Drawing.Size(272, 245);
            this.GV_DataChannelProperties.TabIndex = 0;
            this.GV_DataChannelProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_DataChannelProperties_CellClick);
            this.GV_DataChannelProperties.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.GV_DataChannelProperties_CellLeave);
            // 
            // Col_ChannelProp_Name
            // 
            this.Col_ChannelProp_Name.HeaderText = "Property";
            this.Col_ChannelProp_Name.Name = "Col_ChannelProp_Name";
            this.Col_ChannelProp_Name.ReadOnly = true;
            this.Col_ChannelProp_Name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Col_ChannelProp_Value
            // 
            this.Col_ChannelProp_Value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Col_ChannelProp_Value.HeaderText = "Value";
            this.Col_ChannelProp_Value.Name = "Col_ChannelProp_Value";
            this.Col_ChannelProp_Value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ctrl_DataFileInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Grp_FileChannels);
            this.Controls.Add(this.Grp_File_CustomProperties);
            this.Controls.Add(this.Grp_FileInfo);
            this.Name = "Ctrl_DataFileInformation";
            this.Size = new System.Drawing.Size(418, 605);
            this.Grp_FileInfo.ResumeLayout(false);
            this.Grp_FileInfo.PerformLayout();
            this.Grp_File_CustomProperties.ResumeLayout(false);
            this.Grp_FileChannels.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.GV_DataChannelProperties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grp_FileInfo;
        private System.Windows.Forms.GroupBox Grp_File_CustomProperties;
        private System.Windows.Forms.GroupBox Grp_FileChannels;
        private System.Windows.Forms.Label Lbl_FileStartTime;
        private System.Windows.Forms.Label Lbl_FileComment;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Ctrl_GraphWindow.Ctrl_GW_ChannelList cCL_FileChannelList;
        private System.Windows.Forms.TextBox Txt_FileComment;
        private System.Windows.Forms.TextBox Txt_FileStartTime;
        private Ctrl_RecordUserInformations cRUI_FileCustomProperties;
        private System.Windows.Forms.DataGridView GV_DataChannelProperties;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_ChannelProp_Name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_ChannelProp_Value;
    }
}
