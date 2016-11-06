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
	partial class Frm_About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_About));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Txt_Product = new System.Windows.Forms.TextBox();
            this.Txt_Release = new System.Windows.Forms.TextBox();
            this.Txt_Company = new System.Windows.Forms.TextBox();
            this.Cmd_OK = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LkLbl_GitHub = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LkLbl_HomePage = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(94, 97);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Txt_Product
            // 
            this.Txt_Product.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Product.Location = new System.Drawing.Point(123, 12);
            this.Txt_Product.Name = "Txt_Product";
            this.Txt_Product.ReadOnly = true;
            this.Txt_Product.Size = new System.Drawing.Size(265, 13);
            this.Txt_Product.TabIndex = 1;
            // 
            // Txt_Release
            // 
            this.Txt_Release.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Release.Location = new System.Drawing.Point(123, 38);
            this.Txt_Release.Name = "Txt_Release";
            this.Txt_Release.ReadOnly = true;
            this.Txt_Release.Size = new System.Drawing.Size(265, 13);
            this.Txt_Release.TabIndex = 2;
            // 
            // Txt_Company
            // 
            this.Txt_Company.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Txt_Company.Location = new System.Drawing.Point(123, 64);
            this.Txt_Company.Name = "Txt_Company";
            this.Txt_Company.ReadOnly = true;
            this.Txt_Company.Size = new System.Drawing.Size(265, 13);
            this.Txt_Company.TabIndex = 3;
            // 
            // Cmd_OK
            // 
            this.Cmd_OK.Location = new System.Drawing.Point(162, 427);
            this.Cmd_OK.Name = "Cmd_OK";
            this.Cmd_OK.Size = new System.Drawing.Size(75, 23);
            this.Cmd_OK.TabIndex = 4;
            this.Cmd_OK.Text = "OK";
            this.Cmd_OK.UseVisualStyleBackColor = true;
            this.Cmd_OK.Click += new System.EventHandler(this.Cmd_OKClick);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(6, 19);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(362, 201);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 197);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(374, 224);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "GNU General Public Licence";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.LkLbl_GitHub);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.LkLbl_HomePage);
            this.groupBox2.Location = new System.Drawing.Point(12, 115);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(374, 76);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Contacts";
            // 
            // LkLbl_GitHub
            // 
            this.LkLbl_GitHub.AutoSize = true;
            this.LkLbl_GitHub.Location = new System.Drawing.Point(92, 47);
            this.LkLbl_GitHub.Name = "LkLbl_GitHub";
            this.LkLbl_GitHub.Size = new System.Drawing.Size(235, 13);
            this.LkLbl_GitHub.TabIndex = 14;
            this.LkLbl_GitHub.TabStop = true;
            this.LkLbl_GitHub.Text = "https://github.com/WhileNotInfinite/CANStream";
            this.LkLbl_GitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LkLbl_GitHub_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Get involved:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Home page:";
            // 
            // LkLbl_HomePage
            // 
            this.LkLbl_HomePage.AutoSize = true;
            this.LkLbl_HomePage.Location = new System.Drawing.Point(92, 25);
            this.LkLbl_HomePage.Name = "LkLbl_HomePage";
            this.LkLbl_HomePage.Size = new System.Drawing.Size(188, 13);
            this.LkLbl_HomePage.TabIndex = 11;
            this.LkLbl_HomePage.TabStop = true;
            this.LkLbl_HomePage.Text = "http://canstream.hebergratuit.net/wp/";
            this.LkLbl_HomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LkLbl_HomePage_LinkClicked);
            // 
            // Frm_About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(398, 458);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Cmd_OK);
            this.Controls.Add(this.Txt_Company);
            this.Controls.Add(this.Txt_Release);
            this.Controls.Add(this.Txt_Product);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = global::CANStream.Icones.CANStream_Icone;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_About";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Button Cmd_OK;
		private System.Windows.Forms.TextBox Txt_Company;
		private System.Windows.Forms.TextBox Txt_Release;
		private System.Windows.Forms.TextBox Txt_Product;
		private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.LinkLabel LkLbl_GitHub;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LkLbl_HomePage;
    }
}
