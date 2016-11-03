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
	partial class Ctrl_RecordEventInformation
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
			this.Grp_GeneralInfos = new System.Windows.Forms.GroupBox();
			this.Txt_EventComment = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Txt_EventDate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Txt_EventName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Grp_UserInfo = new System.Windows.Forms.GroupBox();
			this.LV_EventUserInfo = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.Grp_Sessions = new System.Windows.Forms.GroupBox();
			this.TabCtrl_Sessions = new System.Windows.Forms.TabControl();
			this.Grp_GeneralInfos.SuspendLayout();
			this.Grp_UserInfo.SuspendLayout();
			this.Grp_Sessions.SuspendLayout();
			this.SuspendLayout();
			// 
			// Grp_GeneralInfos
			// 
			this.Grp_GeneralInfos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Grp_GeneralInfos.Controls.Add(this.Txt_EventComment);
			this.Grp_GeneralInfos.Controls.Add(this.label3);
			this.Grp_GeneralInfos.Controls.Add(this.Txt_EventDate);
			this.Grp_GeneralInfos.Controls.Add(this.label2);
			this.Grp_GeneralInfos.Controls.Add(this.Txt_EventName);
			this.Grp_GeneralInfos.Controls.Add(this.label1);
			this.Grp_GeneralInfos.Location = new System.Drawing.Point(3, 3);
			this.Grp_GeneralInfos.Name = "Grp_GeneralInfos";
			this.Grp_GeneralInfos.Size = new System.Drawing.Size(402, 136);
			this.Grp_GeneralInfos.TabIndex = 0;
			this.Grp_GeneralInfos.TabStop = false;
			this.Grp_GeneralInfos.Text = "General";
			// 
			// Txt_EventComment
			// 
			this.Txt_EventComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Txt_EventComment.Location = new System.Drawing.Point(83, 74);
			this.Txt_EventComment.Multiline = true;
			this.Txt_EventComment.Name = "Txt_EventComment";
			this.Txt_EventComment.ReadOnly = true;
			this.Txt_EventComment.Size = new System.Drawing.Size(313, 56);
			this.Txt_EventComment.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 77);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(71, 16);
			this.label3.TabIndex = 4;
			this.label3.Text = "Comment";
			// 
			// Txt_EventDate
			// 
			this.Txt_EventDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Txt_EventDate.Location = new System.Drawing.Point(83, 48);
			this.Txt_EventDate.Name = "Txt_EventDate";
			this.Txt_EventDate.ReadOnly = true;
			this.Txt_EventDate.Size = new System.Drawing.Size(313, 20);
			this.Txt_EventDate.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 51);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(71, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Starting date";
			// 
			// Txt_EventName
			// 
			this.Txt_EventName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Txt_EventName.Location = new System.Drawing.Point(83, 22);
			this.Txt_EventName.Name = "Txt_EventName";
			this.Txt_EventName.ReadOnly = true;
			this.Txt_EventName.Size = new System.Drawing.Size(313, 20);
			this.Txt_EventName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// Grp_UserInfo
			// 
			this.Grp_UserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Grp_UserInfo.Controls.Add(this.LV_EventUserInfo);
			this.Grp_UserInfo.Location = new System.Drawing.Point(3, 145);
			this.Grp_UserInfo.Name = "Grp_UserInfo";
			this.Grp_UserInfo.Size = new System.Drawing.Size(402, 121);
			this.Grp_UserInfo.TabIndex = 1;
			this.Grp_UserInfo.TabStop = false;
			this.Grp_UserInfo.Text = "User information";
			// 
			// LV_EventUserInfo
			// 
			this.LV_EventUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.LV_EventUserInfo.BackColor = System.Drawing.SystemColors.Control;
			this.LV_EventUserInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LV_EventUserInfo.GridLines = true;
			this.LV_EventUserInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.LV_EventUserInfo.Location = new System.Drawing.Point(6, 19);
			this.LV_EventUserInfo.Name = "LV_EventUserInfo";
			this.LV_EventUserInfo.Size = new System.Drawing.Size(390, 96);
			this.LV_EventUserInfo.TabIndex = 0;
			this.LV_EventUserInfo.UseCompatibleStateImageBehavior = false;
			this.LV_EventUserInfo.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			this.columnHeader1.Width = 150;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 235;
			// 
			// Grp_Sessions
			// 
			this.Grp_Sessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Grp_Sessions.Controls.Add(this.TabCtrl_Sessions);
			this.Grp_Sessions.Location = new System.Drawing.Point(3, 272);
			this.Grp_Sessions.Name = "Grp_Sessions";
			this.Grp_Sessions.Size = new System.Drawing.Size(402, 254);
			this.Grp_Sessions.TabIndex = 2;
			this.Grp_Sessions.TabStop = false;
			this.Grp_Sessions.Text = "Event sessions";
			// 
			// TabCtrl_Sessions
			// 
			this.TabCtrl_Sessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TabCtrl_Sessions.Location = new System.Drawing.Point(6, 19);
			this.TabCtrl_Sessions.Name = "TabCtrl_Sessions";
			this.TabCtrl_Sessions.SelectedIndex = 0;
			this.TabCtrl_Sessions.Size = new System.Drawing.Size(390, 229);
			this.TabCtrl_Sessions.TabIndex = 0;
			// 
			// Ctrl_RecordEventInformation
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.Grp_Sessions);
			this.Controls.Add(this.Grp_UserInfo);
			this.Controls.Add(this.Grp_GeneralInfos);
			this.Name = "Ctrl_RecordEventInformation";
			this.Size = new System.Drawing.Size(408, 529);
			this.Grp_GeneralInfos.ResumeLayout(false);
			this.Grp_GeneralInfos.PerformLayout();
			this.Grp_UserInfo.ResumeLayout(false);
			this.Grp_Sessions.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TabControl TabCtrl_Sessions;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView LV_EventUserInfo;
		private System.Windows.Forms.TextBox Txt_EventName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Txt_EventDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Txt_EventComment;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox Grp_Sessions;
		private System.Windows.Forms.GroupBox Grp_UserInfo;
		private System.Windows.Forms.GroupBox Grp_GeneralInfos;
	}
}
