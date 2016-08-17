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
    partial class Frm_ParamControlFormatProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ParamControlFormatProperties));
            this.Cmd_OK = new System.Windows.Forms.Button();
            this.Cmd_Cancel = new System.Windows.Forms.Button();
            this.Lbl_CtrlText = new System.Windows.Forms.Label();
            this.Lbl_CtrlOnValue = new System.Windows.Forms.Label();
            this.Lbl_CtrlOffValue = new System.Windows.Forms.Label();
            this.Txt_CtrlText = new System.Windows.Forms.TextBox();
            this.Txt_CtrlOnValue = new System.Windows.Forms.TextBox();
            this.Txt_CtrlOffValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Cmd_OK
            // 
            this.Cmd_OK.Location = new System.Drawing.Point(209, 95);
            this.Cmd_OK.Name = "Cmd_OK";
            this.Cmd_OK.Size = new System.Drawing.Size(75, 23);
            this.Cmd_OK.TabIndex = 0;
            this.Cmd_OK.Text = "OK";
            this.Cmd_OK.UseVisualStyleBackColor = true;
            this.Cmd_OK.Click += new System.EventHandler(this.Cmd_OK_Click);
            // 
            // Cmd_Cancel
            // 
            this.Cmd_Cancel.Location = new System.Drawing.Point(128, 95);
            this.Cmd_Cancel.Name = "Cmd_Cancel";
            this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cmd_Cancel.TabIndex = 1;
            this.Cmd_Cancel.Text = "Cancel";
            this.Cmd_Cancel.UseVisualStyleBackColor = true;
            this.Cmd_Cancel.Click += new System.EventHandler(this.Cmd_Cancel_Click);
            // 
            // Lbl_CtrlText
            // 
            this.Lbl_CtrlText.AutoSize = true;
            this.Lbl_CtrlText.Location = new System.Drawing.Point(12, 9);
            this.Lbl_CtrlText.Name = "Lbl_CtrlText";
            this.Lbl_CtrlText.Size = new System.Drawing.Size(64, 13);
            this.Lbl_CtrlText.TabIndex = 2;
            this.Lbl_CtrlText.Text = "Control Text";
            // 
            // Lbl_CtrlOnValue
            // 
            this.Lbl_CtrlOnValue.AutoSize = true;
            this.Lbl_CtrlOnValue.Location = new System.Drawing.Point(12, 35);
            this.Lbl_CtrlOnValue.Name = "Lbl_CtrlOnValue";
            this.Lbl_CtrlOnValue.Size = new System.Drawing.Size(136, 13);
            this.Lbl_CtrlOnValue.TabIndex = 3;
            this.Lbl_CtrlOnValue.Text = "Control ON Value (Pressed)";
            // 
            // Lbl_CtrlOffValue
            // 
            this.Lbl_CtrlOffValue.AutoSize = true;
            this.Lbl_CtrlOffValue.Location = new System.Drawing.Point(12, 61);
            this.Lbl_CtrlOffValue.Name = "Lbl_CtrlOffValue";
            this.Lbl_CtrlOffValue.Size = new System.Drawing.Size(147, 13);
            this.Lbl_CtrlOffValue.TabIndex = 4;
            this.Lbl_CtrlOffValue.Text = "Control OFF Value (Released)";
            // 
            // Txt_CtrlText
            // 
            this.Txt_CtrlText.Location = new System.Drawing.Point(82, 6);
            this.Txt_CtrlText.Name = "Txt_CtrlText";
            this.Txt_CtrlText.Size = new System.Drawing.Size(202, 20);
            this.Txt_CtrlText.TabIndex = 5;
            // 
            // Txt_CtrlOnValue
            // 
            this.Txt_CtrlOnValue.Location = new System.Drawing.Point(180, 32);
            this.Txt_CtrlOnValue.Name = "Txt_CtrlOnValue";
            this.Txt_CtrlOnValue.Size = new System.Drawing.Size(104, 20);
            this.Txt_CtrlOnValue.TabIndex = 6;
            // 
            // Txt_CtrlOffValue
            // 
            this.Txt_CtrlOffValue.Location = new System.Drawing.Point(180, 58);
            this.Txt_CtrlOffValue.Name = "Txt_CtrlOffValue";
            this.Txt_CtrlOffValue.Size = new System.Drawing.Size(104, 20);
            this.Txt_CtrlOffValue.TabIndex = 7;
            // 
            // Frm_ParamControlFormatProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(294, 130);
            this.Controls.Add(this.Txt_CtrlOffValue);
            this.Controls.Add(this.Txt_CtrlOnValue);
            this.Controls.Add(this.Txt_CtrlText);
            this.Controls.Add(this.Lbl_CtrlOffValue);
            this.Controls.Add(this.Lbl_CtrlOnValue);
            this.Controls.Add(this.Lbl_CtrlText);
            this.Controls.Add(this.Cmd_Cancel);
            this.Controls.Add(this.Cmd_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ParamControlFormatProperties";
            this.Text = "Control format properties";
            this.Deactivate += new System.EventHandler(this.Frm_ParamControlFormatProperties_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ParamControlFormatProperties_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Cmd_OK;
        private System.Windows.Forms.Button Cmd_Cancel;
        private System.Windows.Forms.Label Lbl_CtrlText;
        private System.Windows.Forms.Label Lbl_CtrlOnValue;
        private System.Windows.Forms.Label Lbl_CtrlOffValue;
        private System.Windows.Forms.TextBox Txt_CtrlText;
        private System.Windows.Forms.TextBox Txt_CtrlOnValue;
        private System.Windows.Forms.TextBox Txt_CtrlOffValue;
    }
}