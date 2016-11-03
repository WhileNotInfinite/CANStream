/*
 *	This file is part of CANStream.
 *
 *	CANStream program is free software: you can redistribute it and/or modify
 *	it under the terms of the GNU General Public License as published by
 *	the Free Software Foundation, either version 3 of the License, or
 *	(at your option) any later version.
 *
 *	This program is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *	GNU General Public License for more details.
 *
 *	You should have received a copy of the GNU General Public License
 *	along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 *	CANStream Copyright © 2013-2016 whilenotinfinite@gmail.com
 */

namespace CANStream
{
	partial class Ctrl_RecordUserInformations
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.TSB_UserInfos = new System.Windows.Forms.ToolStrip();
            this.TSB_NewUserInfo = new System.Windows.Forms.ToolStripButton();
            this.TSB_DelUserInfo = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_CopyUserInfo = new System.Windows.Forms.ToolStripButton();
            this.TSB_PasteInformation = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_ImportUserInfo = new System.Windows.Forms.ToolStripButton();
            this.TSB_ExportUserInfo = new System.Windows.Forms.ToolStripButton();
            this.Grid_UserInfos = new System.Windows.Forms.DataGridView();
            this.GridCol_EventUserInfoTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_EventUserInfoValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.TSB_UserInfos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_UserInfos)).BeginInit();
            this.SuspendLayout();
            // 
            // TSB_UserInfos
            // 
            this.TSB_UserInfos.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TSB_UserInfos.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_NewUserInfo,
            this.TSB_DelUserInfo,
            this.toolStripSeparator1,
            this.TSB_CopyUserInfo,
            this.TSB_PasteInformation,
            this.toolStripSeparator2,
            this.TSB_ImportUserInfo,
            this.TSB_ExportUserInfo});
            this.TSB_UserInfos.Location = new System.Drawing.Point(0, 0);
            this.TSB_UserInfos.Name = "TSB_UserInfos";
            this.TSB_UserInfos.Size = new System.Drawing.Size(464, 27);
            this.TSB_UserInfos.TabIndex = 1;
            this.TSB_UserInfos.Text = "toolStrip1";
            // 
            // TSB_NewUserInfo
            // 
            this.TSB_NewUserInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewUserInfo.Image = global::CANStream.Icones.File_New_16;
            this.TSB_NewUserInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewUserInfo.Name = "TSB_NewUserInfo";
            this.TSB_NewUserInfo.Size = new System.Drawing.Size(24, 24);
            this.TSB_NewUserInfo.Text = "toolStripButton3";
            this.TSB_NewUserInfo.ToolTipText = "Add new information";
            this.TSB_NewUserInfo.Click += new System.EventHandler(this.TSB_NewUserInfoClick);
            // 
            // TSB_DelUserInfo
            // 
            this.TSB_DelUserInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_DelUserInfo.Image = global::CANStream.Icones.Delete_16;
            this.TSB_DelUserInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_DelUserInfo.Name = "TSB_DelUserInfo";
            this.TSB_DelUserInfo.Size = new System.Drawing.Size(24, 24);
            this.TSB_DelUserInfo.Text = "toolStripButton4";
            this.TSB_DelUserInfo.ToolTipText = "Delete information";
            this.TSB_DelUserInfo.Click += new System.EventHandler(this.TSB_DelUserInfoClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // TSB_CopyUserInfo
            // 
            this.TSB_CopyUserInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_CopyUserInfo.Image = global::CANStream.Icones.Copy_16;
            this.TSB_CopyUserInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_CopyUserInfo.Name = "TSB_CopyUserInfo";
            this.TSB_CopyUserInfo.Size = new System.Drawing.Size(24, 24);
            this.TSB_CopyUserInfo.Text = "toolStripButton1";
            this.TSB_CopyUserInfo.ToolTipText = "Copy information";
            this.TSB_CopyUserInfo.Click += new System.EventHandler(this.TSB_CopyUserInfoClick);
            // 
            // TSB_PasteInformation
            // 
            this.TSB_PasteInformation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_PasteInformation.Image = global::CANStream.Icones.Paste_16;
            this.TSB_PasteInformation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_PasteInformation.Name = "TSB_PasteInformation";
            this.TSB_PasteInformation.Size = new System.Drawing.Size(24, 24);
            this.TSB_PasteInformation.Text = "toolStripButton2";
            this.TSB_PasteInformation.ToolTipText = "Paste information";
            this.TSB_PasteInformation.Click += new System.EventHandler(this.TSB_PasteInformationClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // TSB_ImportUserInfo
            // 
            this.TSB_ImportUserInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ImportUserInfo.Image = global::CANStream.Icones.Import_File_16;
            this.TSB_ImportUserInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ImportUserInfo.Name = "TSB_ImportUserInfo";
            this.TSB_ImportUserInfo.Size = new System.Drawing.Size(24, 24);
            this.TSB_ImportUserInfo.Text = "toolStripButton1";
            this.TSB_ImportUserInfo.ToolTipText = "Import informations";
            this.TSB_ImportUserInfo.Click += new System.EventHandler(this.TSB_ImportUserInfoClick);
            // 
            // TSB_ExportUserInfo
            // 
            this.TSB_ExportUserInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ExportUserInfo.Image = global::CANStream.Icones.Export_File_16;
            this.TSB_ExportUserInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ExportUserInfo.Name = "TSB_ExportUserInfo";
            this.TSB_ExportUserInfo.Size = new System.Drawing.Size(24, 24);
            this.TSB_ExportUserInfo.Text = "toolStripButton2";
            this.TSB_ExportUserInfo.ToolTipText = "Export informations";
            this.TSB_ExportUserInfo.Click += new System.EventHandler(this.TSB_ExportUserInfoClick);
            // 
            // Grid_UserInfos
            // 
            this.Grid_UserInfos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_UserInfos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_UserInfos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridCol_EventUserInfoTitle,
            this.GridCol_EventUserInfoValue});
            this.Grid_UserInfos.Location = new System.Drawing.Point(4, 34);
            this.Grid_UserInfos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Grid_UserInfos.Name = "Grid_UserInfos";
            this.Grid_UserInfos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid_UserInfos.Size = new System.Drawing.Size(456, 155);
            this.Grid_UserInfos.TabIndex = 2;
            this.Grid_UserInfos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Grid_UserInfosKeyDown);
            // 
            // GridCol_EventUserInfoTitle
            // 
            this.GridCol_EventUserInfoTitle.HeaderText = "Title";
            this.GridCol_EventUserInfoTitle.Name = "GridCol_EventUserInfoTitle";
            // 
            // GridCol_EventUserInfoValue
            // 
            this.GridCol_EventUserInfoValue.HeaderText = "Value";
            this.GridCol_EventUserInfoValue.Name = "GridCol_EventUserInfoValue";
            // 
            // Dlg_OpenFile
            // 
            this.Dlg_OpenFile.FileName = "openFileDialog1";
            this.Dlg_OpenFile.Filter = "User infomations file|*.xui";
            // 
            // Dlg_SaveFile
            // 
            this.Dlg_SaveFile.Filter = "User infomations file|*.xui";
            // 
            // Ctrl_RecordUserInformations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Grid_UserInfos);
            this.Controls.Add(this.TSB_UserInfos);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Ctrl_RecordUserInformations";
            this.Size = new System.Drawing.Size(464, 193);
            this.Load += new System.EventHandler(this.Ctrl_RecordUserInformationsLoad);
            this.SizeChanged += new System.EventHandler(this.Ctrl_RecordUserInformationsSizeChanged);
            this.TSB_UserInfos.ResumeLayout(false);
            this.TSB_UserInfos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_UserInfos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.SaveFileDialog Dlg_SaveFile;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenFile;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_EventUserInfoValue;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_EventUserInfoTitle;
		private System.Windows.Forms.DataGridView Grid_UserInfos;
		private System.Windows.Forms.ToolStripButton TSB_ExportUserInfo;
		private System.Windows.Forms.ToolStripButton TSB_ImportUserInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton TSB_PasteInformation;
		private System.Windows.Forms.ToolStripButton TSB_CopyUserInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton TSB_DelUserInfo;
		private System.Windows.Forms.ToolStripButton TSB_NewUserInfo;
		private System.Windows.Forms.ToolStrip TSB_UserInfos;
	}
}
