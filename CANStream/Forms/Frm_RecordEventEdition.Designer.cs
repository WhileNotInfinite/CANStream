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
	partial class Frm_RecordEventEdition
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
            this.TSB_Main = new System.Windows.Forms.ToolStrip();
            this.TSB_Apply = new System.Windows.Forms.ToolStripButton();
            this.TSB_Cancel = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DP_EventDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.rTxt_EventComment = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_EventName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Ctrl_UserInfo = new CANStream.Ctrl_RecordUserInformations();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.LV_Sessions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TSB_Sessions = new System.Windows.Forms.ToolStrip();
            this.TSB_NewRecordSession = new System.Windows.Forms.ToolStripButton();
            this.TSB_DelRecordSession = new System.Windows.Forms.ToolStripButton();
            this.TSB_EditRecordSession = new System.Windows.Forms.ToolStripButton();
            this.TSB_Main.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.TSB_Sessions.SuspendLayout();
            this.SuspendLayout();
            // 
            // TSB_Main
            // 
            this.TSB_Main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TSB_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_Apply,
            this.TSB_Cancel});
            this.TSB_Main.Location = new System.Drawing.Point(0, 0);
            this.TSB_Main.Name = "TSB_Main";
            this.TSB_Main.Size = new System.Drawing.Size(668, 27);
            this.TSB_Main.TabIndex = 0;
            this.TSB_Main.Text = "toolStrip1";
            // 
            // TSB_Apply
            // 
            this.TSB_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Apply.Image = global::CANStream.Icones.Apply_16;
            this.TSB_Apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Apply.Name = "TSB_Apply";
            this.TSB_Apply.Size = new System.Drawing.Size(24, 24);
            this.TSB_Apply.Text = "toolStripButton1";
            this.TSB_Apply.ToolTipText = "Apply";
            this.TSB_Apply.Click += new System.EventHandler(this.TSB_ApplyClick);
            // 
            // TSB_Cancel
            // 
            this.TSB_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Cancel.Image = global::CANStream.Icones.Cancel_16;
            this.TSB_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Cancel.Name = "TSB_Cancel";
            this.TSB_Cancel.Size = new System.Drawing.Size(24, 24);
            this.TSB_Cancel.Text = "toolStripButton2";
            this.TSB_Cancel.ToolTipText = "Cancel";
            this.TSB_Cancel.Click += new System.EventHandler(this.TSB_CancelClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.DP_EventDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.rTxt_EventComment);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.Txt_EventName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(16, 34);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(636, 178);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Event details";
            // 
            // DP_EventDate
            // 
            this.DP_EventDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DP_EventDate.Location = new System.Drawing.Point(79, 60);
            this.DP_EventDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DP_EventDate.Name = "DP_EventDate";
            this.DP_EventDate.Size = new System.Drawing.Size(125, 22);
            this.DP_EventDate.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 68);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date";
            // 
            // rTxt_EventComment
            // 
            this.rTxt_EventComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxt_EventComment.Location = new System.Drawing.Point(79, 98);
            this.rTxt_EventComment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rTxt_EventComment.Name = "rTxt_EventComment";
            this.rTxt_EventComment.Size = new System.Drawing.Size(548, 69);
            this.rTxt_EventComment.TabIndex = 3;
            this.rTxt_EventComment.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 98);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comment";
            // 
            // Txt_EventName
            // 
            this.Txt_EventName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_EventName.Location = new System.Drawing.Point(79, 28);
            this.Txt_EventName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_EventName.Name = "Txt_EventName";
            this.Txt_EventName.Size = new System.Drawing.Size(548, 22);
            this.Txt_EventName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(16, 220);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(636, 267);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.Ctrl_UserInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(628, 238);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Event user informations";
            // 
            // Ctrl_UserInfo
            // 
            this.Ctrl_UserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Ctrl_UserInfo.Location = new System.Drawing.Point(0, 0);
            this.Ctrl_UserInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Ctrl_UserInfo.Name = "Ctrl_UserInfo";
            this.Ctrl_UserInfo.Size = new System.Drawing.Size(628, 238);
            this.Ctrl_UserInfo.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.LV_Sessions);
            this.tabPage2.Controls.Add(this.TSB_Sessions);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(628, 238);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Record sessions";
            // 
            // LV_Sessions
            // 
            this.LV_Sessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV_Sessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.LV_Sessions.FullRowSelect = true;
            this.LV_Sessions.GridLines = true;
            this.LV_Sessions.Location = new System.Drawing.Point(8, 38);
            this.LV_Sessions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.LV_Sessions.MultiSelect = false;
            this.LV_Sessions.Name = "LV_Sessions";
            this.LV_Sessions.Size = new System.Drawing.Size(612, 189);
            this.LV_Sessions.TabIndex = 1;
            this.LV_Sessions.UseCompatibleStateImageBehavior = false;
            this.LV_Sessions.View = System.Windows.Forms.View.Details;
            this.LV_Sessions.DoubleClick += new System.EventHandler(this.LV_SessionsDoubleClick);
            this.LV_Sessions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_SessionsKeyDown);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Session";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            // 
            // TSB_Sessions
            // 
            this.TSB_Sessions.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TSB_Sessions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_NewRecordSession,
            this.TSB_DelRecordSession,
            this.TSB_EditRecordSession});
            this.TSB_Sessions.Location = new System.Drawing.Point(4, 4);
            this.TSB_Sessions.Name = "TSB_Sessions";
            this.TSB_Sessions.Size = new System.Drawing.Size(620, 27);
            this.TSB_Sessions.TabIndex = 0;
            this.TSB_Sessions.Text = "toolStrip1";
            // 
            // TSB_NewRecordSession
            // 
            this.TSB_NewRecordSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewRecordSession.Image = global::CANStream.Icones.File_New_16;
            this.TSB_NewRecordSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewRecordSession.Name = "TSB_NewRecordSession";
            this.TSB_NewRecordSession.Size = new System.Drawing.Size(24, 24);
            this.TSB_NewRecordSession.Text = "toolStripButton6";
            this.TSB_NewRecordSession.ToolTipText = "Create new record session";
            this.TSB_NewRecordSession.Click += new System.EventHandler(this.TSB_NewRecordSessionClick);
            // 
            // TSB_DelRecordSession
            // 
            this.TSB_DelRecordSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_DelRecordSession.Image = global::CANStream.Icones.Delete_16;
            this.TSB_DelRecordSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_DelRecordSession.Name = "TSB_DelRecordSession";
            this.TSB_DelRecordSession.Size = new System.Drawing.Size(24, 24);
            this.TSB_DelRecordSession.Text = "toolStripButton7";
            this.TSB_DelRecordSession.ToolTipText = "Delete record session";
            this.TSB_DelRecordSession.Click += new System.EventHandler(this.TSB_DelRecordSessionClick);
            // 
            // TSB_EditRecordSession
            // 
            this.TSB_EditRecordSession.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_EditRecordSession.Image = global::CANStream.Icones.Edit_16;
            this.TSB_EditRecordSession.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_EditRecordSession.Name = "TSB_EditRecordSession";
            this.TSB_EditRecordSession.Size = new System.Drawing.Size(24, 24);
            this.TSB_EditRecordSession.Text = "toolStripButton8";
            this.TSB_EditRecordSession.ToolTipText = "Edit record session";
            this.TSB_EditRecordSession.Click += new System.EventHandler(this.TSB_EditRecordSessionClick);
            // 
            // Frm_RecordEventEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 495);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TSB_Main);
            this.Icon = global::CANStream.Icones.CANStream_Icone;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Frm_RecordEventEdition";
            this.Text = "Record Event Edition";
            this.TSB_Main.ResumeLayout(false);
            this.TSB_Main.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.TSB_Sessions.ResumeLayout(false);
            this.TSB_Sessions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private CANStream.Ctrl_RecordUserInformations Ctrl_UserInfo;
		private System.Windows.Forms.ToolStripButton TSB_EditRecordSession;
		private System.Windows.Forms.ToolStripButton TSB_DelRecordSession;
		private System.Windows.Forms.ToolStripButton TSB_NewRecordSession;
		private System.Windows.Forms.ToolStrip TSB_Sessions;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView LV_Sessions;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox rTxt_EventComment;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DateTimePicker DP_EventDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Txt_EventName;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ToolStripButton TSB_Cancel;
		private System.Windows.Forms.ToolStripButton TSB_Apply;
		private System.Windows.Forms.ToolStrip TSB_Main;
	}
}
