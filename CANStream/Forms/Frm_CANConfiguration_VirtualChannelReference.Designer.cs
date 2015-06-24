/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/31/2014
 * Time: 15:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_CANConfiguration_VirtualChannelReference
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CANConfiguration_VirtualChannelReference));
			this.label1 = new System.Windows.Forms.Label();
			this.TV_VirtualChannels = new System.Windows.Forms.TreeView();
			this.Img_TVLibraries = new System.Windows.Forms.ImageList(this.components);
			this.Cmd_OK = new System.Windows.Forms.Button();
			this.Cmd_Cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(2, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(295, 19);
			this.label1.TabIndex = 0;
			this.label1.Text = "Select the reference virtual channel for the CAN parameter";
			// 
			// TV_VirtualChannels
			// 
			this.TV_VirtualChannels.ImageIndex = 0;
			this.TV_VirtualChannels.ImageList = this.Img_TVLibraries;
			this.TV_VirtualChannels.Location = new System.Drawing.Point(2, 39);
			this.TV_VirtualChannels.Name = "TV_VirtualChannels";
			this.TV_VirtualChannels.SelectedImageIndex = 0;
			this.TV_VirtualChannels.ShowNodeToolTips = true;
			this.TV_VirtualChannels.Size = new System.Drawing.Size(295, 346);
			this.TV_VirtualChannels.TabIndex = 1;
			this.TV_VirtualChannels.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_VirtualChannelsNodeMouseDoubleClick);
			// 
			// Img_TVLibraries
			// 
			this.Img_TVLibraries.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_TVLibraries.ImageStream")));
			this.Img_TVLibraries.TransparentColor = System.Drawing.Color.Transparent;
			this.Img_TVLibraries.Images.SetKeyName(0, "library-books-icone-5837-16.png");
			this.Img_TVLibraries.Images.SetKeyName(1, "edu-des-mathematiques-icone-4069-16.png");
			// 
			// Cmd_OK
			// 
			this.Cmd_OK.Location = new System.Drawing.Point(222, 391);
			this.Cmd_OK.Name = "Cmd_OK";
			this.Cmd_OK.Size = new System.Drawing.Size(75, 23);
			this.Cmd_OK.TabIndex = 2;
			this.Cmd_OK.Text = "OK";
			this.Cmd_OK.UseVisualStyleBackColor = true;
			this.Cmd_OK.Click += new System.EventHandler(this.Cmd_OKClick);
			// 
			// Cmd_Cancel
			// 
			this.Cmd_Cancel.Location = new System.Drawing.Point(141, 391);
			this.Cmd_Cancel.Name = "Cmd_Cancel";
			this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Cancel.TabIndex = 3;
			this.Cmd_Cancel.Text = "Cancel";
			this.Cmd_Cancel.UseVisualStyleBackColor = true;
			this.Cmd_Cancel.Click += new System.EventHandler(this.Cmd_CancelClick);
			// 
			// Frm_CANConfiguration_VirtualChannelReference
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(299, 422);
			this.Controls.Add(this.Cmd_Cancel);
			this.Controls.Add(this.Cmd_OK);
			this.Controls.Add(this.TV_VirtualChannels);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_CANConfiguration_VirtualChannelReference";
			this.ShowInTaskbar = false;
			this.Text = "Virtual channel reference";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ImageList Img_TVLibraries;
		private System.Windows.Forms.Button Cmd_Cancel;
		private System.Windows.Forms.Button Cmd_OK;
		private System.Windows.Forms.TreeView TV_VirtualChannels;
		private System.Windows.Forms.Label label1;
	}
}
