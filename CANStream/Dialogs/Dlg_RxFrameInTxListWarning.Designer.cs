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
    partial class Dlg_RxFrameInTxListWarning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Dlg_RxFrameInTxListWarning));
            this.Cmd_GoRxOnly = new System.Windows.Forms.Button();
            this.Cmd_DisableTxFrame = new System.Windows.Forms.Button();
            this.Cmd_Ignore = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Txt_Text = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Cmd_GoRxOnly
            // 
            this.Cmd_GoRxOnly.Location = new System.Drawing.Point(382, 66);
            this.Cmd_GoRxOnly.Name = "Cmd_GoRxOnly";
            this.Cmd_GoRxOnly.Size = new System.Drawing.Size(105, 23);
            this.Cmd_GoRxOnly.TabIndex = 1;
            this.Cmd_GoRxOnly.Text = "Go RX Only";
            this.Cmd_GoRxOnly.UseVisualStyleBackColor = true;
            this.Cmd_GoRxOnly.Click += new System.EventHandler(this.Cmd_GoRxOnly_Click);
            // 
            // Cmd_DisableTxFrame
            // 
            this.Cmd_DisableTxFrame.Location = new System.Drawing.Point(271, 66);
            this.Cmd_DisableTxFrame.Name = "Cmd_DisableTxFrame";
            this.Cmd_DisableTxFrame.Size = new System.Drawing.Size(105, 23);
            this.Cmd_DisableTxFrame.TabIndex = 2;
            this.Cmd_DisableTxFrame.Text = "Disable TX Frame";
            this.Cmd_DisableTxFrame.UseVisualStyleBackColor = true;
            this.Cmd_DisableTxFrame.Click += new System.EventHandler(this.Cmd_DisableTxFrame_Click);
            // 
            // Cmd_Ignore
            // 
            this.Cmd_Ignore.Location = new System.Drawing.Point(160, 66);
            this.Cmd_Ignore.Name = "Cmd_Ignore";
            this.Cmd_Ignore.Size = new System.Drawing.Size(105, 23);
            this.Cmd_Ignore.TabIndex = 3;
            this.Cmd_Ignore.Text = "Ignore";
            this.Cmd_Ignore.UseVisualStyleBackColor = true;
            this.Cmd_Ignore.Click += new System.EventHandler(this.Cmd_Ignore_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(439, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Txt_Text
            // 
            this.Txt_Text.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Text.Location = new System.Drawing.Point(12, 12);
            this.Txt_Text.Multiline = true;
            this.Txt_Text.Name = "Txt_Text";
            this.Txt_Text.ReadOnly = true;
            this.Txt_Text.Size = new System.Drawing.Size(421, 48);
            this.Txt_Text.TabIndex = 5;
            // 
            // Dlg_RxFrameInTxListWarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 99);
            this.Controls.Add(this.Txt_Text);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.Cmd_Ignore);
            this.Controls.Add(this.Cmd_DisableTxFrame);
            this.Controls.Add(this.Cmd_GoRxOnly);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dlg_RxFrameInTxListWarning";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAN Frame collusion warning";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Cmd_GoRxOnly;
        private System.Windows.Forms.Button Cmd_DisableTxFrame;
        private System.Windows.Forms.Button Cmd_Ignore;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox Txt_Text;
    }
}