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
	partial class Frm_RecordEventSessionSelection
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
			this.Lbl_Info = new System.Windows.Forms.Label();
			this.LV_Sessions = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.Cmd_Select = new System.Windows.Forms.Button();
			this.Cmd_Cancel = new System.Windows.Forms.Button();
			this.Cmd_CreateNew = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Lbl_Info
			// 
			this.Lbl_Info.Location = new System.Drawing.Point(12, 9);
			this.Lbl_Info.Name = "Lbl_Info";
			this.Lbl_Info.Size = new System.Drawing.Size(100, 15);
			this.Lbl_Info.TabIndex = 0;
			this.Lbl_Info.Text = "Record sessions list";
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
			this.LV_Sessions.Location = new System.Drawing.Point(12, 27);
			this.LV_Sessions.MultiSelect = false;
			this.LV_Sessions.Name = "LV_Sessions";
			this.LV_Sessions.Size = new System.Drawing.Size(494, 229);
			this.LV_Sessions.TabIndex = 2;
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
			// Cmd_Select
			// 
			this.Cmd_Select.Location = new System.Drawing.Point(431, 263);
			this.Cmd_Select.Name = "Cmd_Select";
			this.Cmd_Select.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Select.TabIndex = 3;
			this.Cmd_Select.Text = "Select";
			this.Cmd_Select.UseVisualStyleBackColor = true;
			this.Cmd_Select.Click += new System.EventHandler(this.Cmd_SelectClick);
			// 
			// Cmd_Cancel
			// 
			this.Cmd_Cancel.Location = new System.Drawing.Point(350, 263);
			this.Cmd_Cancel.Name = "Cmd_Cancel";
			this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Cancel.TabIndex = 4;
			this.Cmd_Cancel.Text = "Cancel";
			this.Cmd_Cancel.UseVisualStyleBackColor = true;
			this.Cmd_Cancel.Click += new System.EventHandler(this.Cmd_CancelClick);
			// 
			// Cmd_CreateNew
			// 
			this.Cmd_CreateNew.Location = new System.Drawing.Point(12, 263);
			this.Cmd_CreateNew.Name = "Cmd_CreateNew";
			this.Cmd_CreateNew.Size = new System.Drawing.Size(75, 23);
			this.Cmd_CreateNew.TabIndex = 5;
			this.Cmd_CreateNew.Text = "New session";
			this.Cmd_CreateNew.UseVisualStyleBackColor = true;
			this.Cmd_CreateNew.Click += new System.EventHandler(this.Cmd_CreateNewClick);
			// 
			// Frm_RecordEventSessionSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(518, 298);
			this.Controls.Add(this.Cmd_CreateNew);
			this.Controls.Add(this.Cmd_Cancel);
			this.Controls.Add(this.Cmd_Select);
			this.Controls.Add(this.LV_Sessions);
			this.Controls.Add(this.Lbl_Info);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::CANStream.Icones.CANStream_Icone;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_RecordEventSessionSelection";
			this.Text = "Record session selection";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button Cmd_CreateNew;
		private System.Windows.Forms.Button Cmd_Cancel;
		private System.Windows.Forms.Button Cmd_Select;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView LV_Sessions;
		private System.Windows.Forms.Label Lbl_Info;
	}
}
