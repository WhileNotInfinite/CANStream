/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/13/2014
 * Time: 12:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_DataViewer_EventSession_Info
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
			this.TabCtrl_Events = new System.Windows.Forms.TabControl();
			this.SuspendLayout();
			// 
			// TabCtrl_Events
			// 
			this.TabCtrl_Events.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TabCtrl_Events.Location = new System.Drawing.Point(1, 3);
			this.TabCtrl_Events.Name = "TabCtrl_Events";
			this.TabCtrl_Events.SelectedIndex = 0;
			this.TabCtrl_Events.Size = new System.Drawing.Size(426, 666);
			this.TabCtrl_Events.TabIndex = 0;
			// 
			// Frm_DataViewer_EventSession_Info
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(429, 668);
			this.Controls.Add(this.TabCtrl_Events);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_DataViewer_EventSession_Info";
			this.ShowInTaskbar = false;
			this.Text = "Event/Sessions information";
			this.TopMost = true;
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.TabControl TabCtrl_Events;
	}
}
