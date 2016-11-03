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
	partial class Frm_EventDetails
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
			this.label1 = new System.Windows.Forms.Label();
			this.Txt_Name = new System.Windows.Forms.TextBox();
			this.Txt_Date = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.rTxt_Comment = new System.Windows.Forms.RichTextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.LV_Info = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(45, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name";
			// 
			// Txt_Name
			// 
			this.Txt_Name.Location = new System.Drawing.Point(87, 6);
			this.Txt_Name.Name = "Txt_Name";
			this.Txt_Name.ReadOnly = true;
			this.Txt_Name.Size = new System.Drawing.Size(181, 20);
			this.Txt_Name.TabIndex = 1;
			// 
			// Txt_Date
			// 
			this.Txt_Date.Location = new System.Drawing.Point(87, 32);
			this.Txt_Date.Name = "Txt_Date";
			this.Txt_Date.ReadOnly = true;
			this.Txt_Date.Size = new System.Drawing.Size(181, 20);
			this.Txt_Date.TabIndex = 3;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 17);
			this.label2.TabIndex = 2;
			this.label2.Text = "Starting date";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(69, 17);
			this.label3.TabIndex = 4;
			this.label3.Text = "Comment";
			// 
			// rTxt_Comment
			// 
			this.rTxt_Comment.Location = new System.Drawing.Point(87, 58);
			this.rTxt_Comment.Name = "rTxt_Comment";
			this.rTxt_Comment.ReadOnly = true;
			this.rTxt_Comment.Size = new System.Drawing.Size(181, 96);
			this.rTxt_Comment.TabIndex = 6;
			this.rTxt_Comment.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(12, 162);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(69, 17);
			this.label4.TabIndex = 7;
			this.label4.Text = "Information";
			// 
			// LV_Info
			// 
			this.LV_Info.BackColor = System.Drawing.SystemColors.Control;
			this.LV_Info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2});
			this.LV_Info.GridLines = true;
			this.LV_Info.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
			this.LV_Info.Location = new System.Drawing.Point(12, 182);
			this.LV_Info.Name = "LV_Info";
			this.LV_Info.Size = new System.Drawing.Size(256, 122);
			this.LV_Info.TabIndex = 8;
			this.LV_Info.UseCompatibleStateImageBehavior = false;
			this.LV_Info.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Title";
			this.columnHeader1.Width = 80;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Value";
			this.columnHeader2.Width = 170;
			// 
			// Frm_EventDetails
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(280, 316);
			this.Controls.Add(this.LV_Info);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.rTxt_Comment);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Txt_Date);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Txt_Name);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_EventDetails";
			this.ShowInTaskbar = false;
			this.Text = "Frm_EventDetails";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView LV_Info;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.RichTextBox rTxt_Comment;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Txt_Date;
		private System.Windows.Forms.TextBox Txt_Name;
		private System.Windows.Forms.Label label1;
	}
}
