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
	partial class Dlg_DBCTransmitterSelection
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
			this.Lbl_Text = new System.Windows.Forms.Label();
			this.Lbl_Devices = new System.Windows.Forms.Label();
			this.Cmb_Devices = new System.Windows.Forms.ComboBox();
			this.Cmd_OK = new System.Windows.Forms.Button();
			this.Cmd_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// Lbl_Text
			// 
			this.Lbl_Text.Location = new System.Drawing.Point(12, 9);
			this.Lbl_Text.Name = "Lbl_Text";
			this.Lbl_Text.Size = new System.Drawing.Size(315, 18);
			this.Lbl_Text.TabIndex = 0;
			this.Lbl_Text.Text = "Text";
			// 
			// Lbl_Devices
			// 
			this.Lbl_Devices.Location = new System.Drawing.Point(12, 38);
			this.Lbl_Devices.Name = "Lbl_Devices";
			this.Lbl_Devices.Size = new System.Drawing.Size(79, 18);
			this.Lbl_Devices.TabIndex = 1;
			this.Lbl_Devices.Text = "List of devices";
			// 
			// Cmb_Devices
			// 
			this.Cmb_Devices.FormattingEnabled = true;
			this.Cmb_Devices.Location = new System.Drawing.Point(97, 35);
			this.Cmb_Devices.Name = "Cmb_Devices";
			this.Cmb_Devices.Size = new System.Drawing.Size(230, 21);
			this.Cmb_Devices.TabIndex = 2;
			// 
			// Cmd_OK
			// 
			this.Cmd_OK.Location = new System.Drawing.Point(171, 78);
			this.Cmd_OK.Name = "Cmd_OK";
			this.Cmd_OK.Size = new System.Drawing.Size(75, 23);
			this.Cmd_OK.TabIndex = 3;
			this.Cmd_OK.Text = "OK";
			this.Cmd_OK.UseVisualStyleBackColor = true;
			this.Cmd_OK.Click += new System.EventHandler(this.Cmd_OKClick);
			// 
			// Cmd_Cancel
			// 
			this.Cmd_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cmd_Cancel.Location = new System.Drawing.Point(252, 78);
			this.Cmd_Cancel.Name = "Cmd_Cancel";
			this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Cancel.TabIndex = 4;
			this.Cmd_Cancel.Text = "Cancel";
			this.Cmd_Cancel.UseVisualStyleBackColor = true;
			this.Cmd_Cancel.Click += new System.EventHandler(this.Cmd_CancelClick);
			// 
			// Dlg_DBCTransmitterSelection
			// 
			this.AcceptButton = this.Cmd_OK;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.CancelButton = this.Cmd_Cancel;
			this.ClientSize = new System.Drawing.Size(339, 113);
			this.Controls.Add(this.Cmd_Cancel);
			this.Controls.Add(this.Cmd_OK);
			this.Controls.Add(this.Cmb_Devices);
			this.Controls.Add(this.Lbl_Devices);
			this.Controls.Add(this.Lbl_Text);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Dlg_DBCTransmitterSelection";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Dlg_DBCTransmitterSelection";
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Button Cmd_Cancel;
		private System.Windows.Forms.Button Cmd_OK;
		private System.Windows.Forms.ComboBox Cmb_Devices;
		private System.Windows.Forms.Label Lbl_Devices;
		private System.Windows.Forms.Label Lbl_Text;
	}
}
