/*
 * Created by SharpDevelop.
 * User: vbrault
 * Date: 3/7/2014
 * Time: 16:12 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_TrcFileSelection
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
			this.LV_TrcFiles = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.Context_LV_TrcFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.unselectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Cmd_Convert = new System.Windows.Forms.Button();
			this.Cmd_Cancel = new System.Windows.Forms.Button();
			this.Context_LV_TrcFiles.SuspendLayout();
			this.SuspendLayout();
			// 
			// LV_TrcFiles
			// 
			this.LV_TrcFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.LV_TrcFiles.CheckBoxes = true;
			this.LV_TrcFiles.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1,
									this.columnHeader2,
									this.columnHeader3});
			this.LV_TrcFiles.ContextMenuStrip = this.Context_LV_TrcFiles;
			this.LV_TrcFiles.FullRowSelect = true;
			this.LV_TrcFiles.GridLines = true;
			this.LV_TrcFiles.Location = new System.Drawing.Point(12, 12);
			this.LV_TrcFiles.Name = "LV_TrcFiles";
			this.LV_TrcFiles.Size = new System.Drawing.Size(506, 209);
			this.LV_TrcFiles.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.LV_TrcFiles.TabIndex = 0;
			this.LV_TrcFiles.UseCompatibleStateImageBehavior = false;
			this.LV_TrcFiles.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 306;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Record date";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 117;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "Size";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// Context_LV_TrcFiles
			// 
			this.Context_LV_TrcFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.selectAllToolStripMenuItem,
									this.unselectAllToolStripMenuItem,
									this.invertSelectionToolStripMenuItem});
			this.Context_LV_TrcFiles.Name = "Context_LV_TrcFiles";
			this.Context_LV_TrcFiles.Size = new System.Drawing.Size(156, 70);
			// 
			// selectAllToolStripMenuItem
			// 
			this.selectAllToolStripMenuItem.Image = global::CANStream.Icones.User_Selection_16;
			this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
			this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.selectAllToolStripMenuItem.Text = "Select All";
			this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.SelectAllToolStripMenuItemClick);
			// 
			// unselectAllToolStripMenuItem
			// 
			this.unselectAllToolStripMenuItem.Image = global::CANStream.Icones.User_Selection_Off_16;
			this.unselectAllToolStripMenuItem.Name = "unselectAllToolStripMenuItem";
			this.unselectAllToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.unselectAllToolStripMenuItem.Text = "Unselect All";
			this.unselectAllToolStripMenuItem.Click += new System.EventHandler(this.UnselectAllToolStripMenuItemClick);
			// 
			// invertSelectionToolStripMenuItem
			// 
			this.invertSelectionToolStripMenuItem.Image = global::CANStream.Icones.User_Selection_Invert_16;
			this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
			this.invertSelectionToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
			this.invertSelectionToolStripMenuItem.Text = "Invert Selection";
			this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.InvertSelectionToolStripMenuItemClick);
			// 
			// Cmd_Convert
			// 
			this.Cmd_Convert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_Convert.Location = new System.Drawing.Point(443, 227);
			this.Cmd_Convert.Name = "Cmd_Convert";
			this.Cmd_Convert.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Convert.TabIndex = 1;
			this.Cmd_Convert.Text = "Convert";
			this.Cmd_Convert.UseVisualStyleBackColor = true;
			this.Cmd_Convert.Click += new System.EventHandler(this.Cmd_ConvertClick);
			// 
			// Cmd_Cancel
			// 
			this.Cmd_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_Cancel.Location = new System.Drawing.Point(362, 227);
			this.Cmd_Cancel.Name = "Cmd_Cancel";
			this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Cancel.TabIndex = 2;
			this.Cmd_Cancel.Text = "Cancel";
			this.Cmd_Cancel.UseVisualStyleBackColor = true;
			this.Cmd_Cancel.Click += new System.EventHandler(this.Cmd_CancelClick);
			// 
			// Frm_TrcFileSelection
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(530, 257);
			this.Controls.Add(this.Cmd_Cancel);
			this.Controls.Add(this.Cmd_Convert);
			this.Controls.Add(this.LV_TrcFiles);
			this.Icon = global::CANStream.Icones.CANStream_Icone;
			this.Name = "Frm_TrcFileSelection";
			this.Text = "Records selection";
			this.Context_LV_TrcFiles.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem unselectAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_LV_TrcFiles;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.Button Cmd_Cancel;
		private System.Windows.Forms.Button Cmd_Convert;
		private System.Windows.Forms.ListView LV_TrcFiles;
	}
}
