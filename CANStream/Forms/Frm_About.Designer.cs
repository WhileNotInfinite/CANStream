/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 7/17/2013
 * Time: 12:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.Cmd_LicenceRequest = new System.Windows.Forms.Button();
			this.Txt_LicenceDaysRemaining = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Txt_LicenceExpiryDate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Txt_LicenceValid = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.groupBox1.SuspendLayout();
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
			this.Cmd_OK.Location = new System.Drawing.Point(313, 207);
			this.Cmd_OK.Name = "Cmd_OK";
			this.Cmd_OK.Size = new System.Drawing.Size(75, 23);
			this.Cmd_OK.TabIndex = 4;
			this.Cmd_OK.Text = "OK";
			this.Cmd_OK.UseVisualStyleBackColor = true;
			this.Cmd_OK.Click += new System.EventHandler(this.Cmd_OKClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.Cmd_LicenceRequest);
			this.groupBox1.Controls.Add(this.Txt_LicenceDaysRemaining);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.Txt_LicenceExpiryDate);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.Txt_LicenceValid);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 115);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(376, 86);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Licence information";
			// 
			// Cmd_LicenceRequest
			// 
			this.Cmd_LicenceRequest.Enabled = false;
			this.Cmd_LicenceRequest.Location = new System.Drawing.Point(281, 25);
			this.Cmd_LicenceRequest.Name = "Cmd_LicenceRequest";
			this.Cmd_LicenceRequest.Size = new System.Drawing.Size(75, 51);
			this.Cmd_LicenceRequest.TabIndex = 7;
			this.Cmd_LicenceRequest.Text = "Request a licence";
			this.Cmd_LicenceRequest.UseVisualStyleBackColor = true;
			this.Cmd_LicenceRequest.Click += new System.EventHandler(this.Cmd_LicenceRequestClick);
			// 
			// Txt_LicenceDaysRemaining
			// 
			this.Txt_LicenceDaysRemaining.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Txt_LicenceDaysRemaining.Location = new System.Drawing.Point(100, 63);
			this.Txt_LicenceDaysRemaining.Name = "Txt_LicenceDaysRemaining";
			this.Txt_LicenceDaysRemaining.ReadOnly = true;
			this.Txt_LicenceDaysRemaining.Size = new System.Drawing.Size(163, 13);
			this.Txt_LicenceDaysRemaining.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 63);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(78, 15);
			this.label3.TabIndex = 5;
			this.label3.Text = "Remaining";
			// 
			// Txt_LicenceExpiryDate
			// 
			this.Txt_LicenceExpiryDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Txt_LicenceExpiryDate.Location = new System.Drawing.Point(100, 44);
			this.Txt_LicenceExpiryDate.Name = "Txt_LicenceExpiryDate";
			this.Txt_LicenceExpiryDate.ReadOnly = true;
			this.Txt_LicenceExpiryDate.Size = new System.Drawing.Size(163, 13);
			this.Txt_LicenceExpiryDate.TabIndex = 4;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 44);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(78, 15);
			this.label2.TabIndex = 3;
			this.label2.Text = "Expiry date";
			// 
			// Txt_LicenceValid
			// 
			this.Txt_LicenceValid.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Txt_LicenceValid.Location = new System.Drawing.Point(100, 25);
			this.Txt_LicenceValid.Name = "Txt_LicenceValid";
			this.Txt_LicenceValid.ReadOnly = true;
			this.Txt_LicenceValid.Size = new System.Drawing.Size(163, 13);
			this.Txt_LicenceValid.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(16, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Licence valid";
			// 
			// Frm_About
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(398, 236);
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
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Button Cmd_LicenceRequest;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Txt_LicenceValid;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Txt_LicenceExpiryDate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Txt_LicenceDaysRemaining;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button Cmd_OK;
		private System.Windows.Forms.TextBox Txt_Company;
		private System.Windows.Forms.TextBox Txt_Release;
		private System.Windows.Forms.TextBox Txt_Product;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}
