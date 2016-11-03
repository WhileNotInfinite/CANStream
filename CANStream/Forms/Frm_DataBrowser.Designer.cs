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
	partial class Frm_DataBrowser
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DataBrowser));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.TV_Folders = new System.Windows.Forms.TreeView();
            this.Context_TV_Folders = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Img_DataBrowser = new System.Windows.Forms.ImageList(this.components);
            this.Cmd_RootFolder = new System.Windows.Forms.Button();
            this.Cmb_RootFolder = new System.Windows.Forms.ComboBox();
            this.LV_Sessions = new System.Windows.Forms.ListView();
            this.SessionName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Context_LV_Sessions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.eventDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LV_Files = new System.Windows.Forms.ListView();
            this.FileName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileLastModified = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FileSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Context_LV_Files = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.sessionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Dlg_FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.TSB_Refresh = new System.Windows.Forms.ToolStripButton();
            this.TSB_Load = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_DelFile = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.Context_TV_Folders.SuspendLayout();
            this.Context_LV_Sessions.SuspendLayout();
            this.Context_LV_Files.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.LV_Files);
            this.splitContainer1.Size = new System.Drawing.Size(647, 355);
            this.splitContainer1.SplitterDistance = 256;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.TV_Folders);
            this.splitContainer2.Panel1.Controls.Add(this.Cmd_RootFolder);
            this.splitContainer2.Panel1.Controls.Add(this.Cmb_RootFolder);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.LV_Sessions);
            this.splitContainer2.Size = new System.Drawing.Size(256, 355);
            this.splitContainer2.SplitterDistance = 150;
            this.splitContainer2.TabIndex = 0;
            // 
            // TV_Folders
            // 
            this.TV_Folders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TV_Folders.ContextMenuStrip = this.Context_TV_Folders;
            this.TV_Folders.ImageIndex = 0;
            this.TV_Folders.ImageList = this.Img_DataBrowser;
            this.TV_Folders.Location = new System.Drawing.Point(3, 34);
            this.TV_Folders.Name = "TV_Folders";
            this.TV_Folders.SelectedImageIndex = 0;
            this.TV_Folders.Size = new System.Drawing.Size(250, 113);
            this.TV_Folders.TabIndex = 2;
            this.TV_Folders.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_FoldersNodeMouseClick);
            this.TV_Folders.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TV_FoldersKeyDown);
            // 
            // Context_TV_Folders
            // 
            this.Context_TV_Folders.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteEventToolStripMenuItem});
            this.Context_TV_Folders.Name = "Context_LV_Sessions";
            this.Context_TV_Folders.Size = new System.Drawing.Size(140, 26);
            // 
            // deleteEventToolStripMenuItem
            // 
            this.deleteEventToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
            this.deleteEventToolStripMenuItem.Name = "deleteEventToolStripMenuItem";
            this.deleteEventToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.deleteEventToolStripMenuItem.Text = "Delete event";
            this.deleteEventToolStripMenuItem.Click += new System.EventHandler(this.DeleteEventToolStripMenuItemClick);
            // 
            // Img_DataBrowser
            // 
            this.Img_DataBrowser.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_DataBrowser.ImageStream")));
            this.Img_DataBrowser.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_DataBrowser.Images.SetKeyName(0, "green-file-icone-3904-16.png");
            this.Img_DataBrowser.Images.SetKeyName(1, "folder-green-open-icone-9053-16.png");
            this.Img_DataBrowser.Images.SetKeyName(2, "document-g98-green-paper-icone-6103-16.png");
            this.Img_DataBrowser.Images.SetKeyName(3, "g98-paper-red-paper-icone-7849-16.png");
            this.Img_DataBrowser.Images.SetKeyName(4, "html-icone-5065-16.png");
            // 
            // Cmd_RootFolder
            // 
            this.Cmd_RootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_RootFolder.Image = global::CANStream.Icones.File_Open_16;
            this.Cmd_RootFolder.Location = new System.Drawing.Point(227, 3);
            this.Cmd_RootFolder.Name = "Cmd_RootFolder";
            this.Cmd_RootFolder.Size = new System.Drawing.Size(26, 26);
            this.Cmd_RootFolder.TabIndex = 1;
            this.Cmd_RootFolder.UseVisualStyleBackColor = true;
            this.Cmd_RootFolder.Click += new System.EventHandler(this.Cmd_RootFolderClick);
            // 
            // Cmb_RootFolder
            // 
            this.Cmb_RootFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_RootFolder.FormattingEnabled = true;
            this.Cmb_RootFolder.Location = new System.Drawing.Point(3, 7);
            this.Cmb_RootFolder.Name = "Cmb_RootFolder";
            this.Cmb_RootFolder.Size = new System.Drawing.Size(218, 21);
            this.Cmb_RootFolder.TabIndex = 0;
            this.Cmb_RootFolder.SelectedIndexChanged += new System.EventHandler(this.Cmb_RootFolderSelectedIndexChanged);
            // 
            // LV_Sessions
            // 
            this.LV_Sessions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV_Sessions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SessionName});
            this.LV_Sessions.ContextMenuStrip = this.Context_LV_Sessions;
            this.LV_Sessions.Location = new System.Drawing.Point(3, 3);
            this.LV_Sessions.Name = "LV_Sessions";
            this.LV_Sessions.Size = new System.Drawing.Size(250, 195);
            this.LV_Sessions.TabIndex = 0;
            this.LV_Sessions.UseCompatibleStateImageBehavior = false;
            this.LV_Sessions.View = System.Windows.Forms.View.Details;
            this.LV_Sessions.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_SessionsKeyDown);
            this.LV_Sessions.MouseClick += new System.Windows.Forms.MouseEventHandler(this.LV_SessionsMouseClick);
            // 
            // SessionName
            // 
            this.SessionName.Text = "Name";
            // 
            // Context_LV_Sessions
            // 
            this.Context_LV_Sessions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.eventDetailsToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteSessionToolStripMenuItem});
            this.Context_LV_Sessions.Name = "Context_LV_Sessions";
            this.Context_LV_Sessions.Size = new System.Drawing.Size(149, 54);
            // 
            // eventDetailsToolStripMenuItem
            // 
            this.eventDetailsToolStripMenuItem.Image = global::CANStream.Icones.Record_Event_16;
            this.eventDetailsToolStripMenuItem.Name = "eventDetailsToolStripMenuItem";
            this.eventDetailsToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.eventDetailsToolStripMenuItem.Text = "Event details";
            this.eventDetailsToolStripMenuItem.Click += new System.EventHandler(this.EventDetailsToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(145, 6);
            // 
            // deleteSessionToolStripMenuItem
            // 
            this.deleteSessionToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
            this.deleteSessionToolStripMenuItem.Name = "deleteSessionToolStripMenuItem";
            this.deleteSessionToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.deleteSessionToolStripMenuItem.Text = "Delete session";
            this.deleteSessionToolStripMenuItem.Click += new System.EventHandler(this.DeleteSessionToolStripMenuItemClick);
            // 
            // LV_Files
            // 
            this.LV_Files.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV_Files.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FileName,
            this.FileLastModified,
            this.FileSize});
            this.LV_Files.ContextMenuStrip = this.Context_LV_Files;
            this.LV_Files.FullRowSelect = true;
            this.LV_Files.GridLines = true;
            this.LV_Files.Location = new System.Drawing.Point(3, 3);
            this.LV_Files.Name = "LV_Files";
            this.LV_Files.Size = new System.Drawing.Size(381, 349);
            this.LV_Files.SmallImageList = this.Img_DataBrowser;
            this.LV_Files.TabIndex = 0;
            this.LV_Files.UseCompatibleStateImageBehavior = false;
            this.LV_Files.View = System.Windows.Forms.View.Details;
            this.LV_Files.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_FilesKeyDown);
            this.LV_Files.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.LV_FilesMouseDoubleClick);
            // 
            // FileName
            // 
            this.FileName.Text = "Name";
            this.FileName.Width = 176;
            // 
            // FileLastModified
            // 
            this.FileLastModified.Text = "Last modified";
            // 
            // FileSize
            // 
            this.FileSize.Text = "Size";
            // 
            // Context_LV_Files
            // 
            this.Context_LV_Files.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sessionDetailsToolStripMenuItem,
            this.toolStripMenuItem1,
            this.deleteToolStripMenuItem});
            this.Context_LV_Files.Name = "Context_LV_Sessions";
            this.Context_LV_Files.Size = new System.Drawing.Size(151, 54);
            // 
            // sessionDetailsToolStripMenuItem
            // 
            this.sessionDetailsToolStripMenuItem.Image = global::CANStream.Icones.Record_Session_16;
            this.sessionDetailsToolStripMenuItem.Name = "sessionDetailsToolStripMenuItem";
            this.sessionDetailsToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.sessionDetailsToolStripMenuItem.Text = "Session details";
            this.sessionDetailsToolStripMenuItem.Click += new System.EventHandler(this.SessionDetailsToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(147, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // TSB_Refresh
            // 
            this.TSB_Refresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Refresh.Image = global::CANStream.Icones.Refresh_CAN_Controllers;
            this.TSB_Refresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Refresh.Name = "TSB_Refresh";
            this.TSB_Refresh.Size = new System.Drawing.Size(23, 22);
            this.TSB_Refresh.Text = "toolStripButton1";
            this.TSB_Refresh.ToolTipText = "Refresh current folder";
            this.TSB_Refresh.Click += new System.EventHandler(this.TSB_RefreshClick);
            // 
            // TSB_Load
            // 
            this.TSB_Load.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Load.Image = global::CANStream.Icones.Item_Load_16;
            this.TSB_Load.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Load.Name = "TSB_Load";
            this.TSB_Load.Size = new System.Drawing.Size(23, 22);
            this.TSB_Load.Text = "toolStripButton2";
            this.TSB_Load.ToolTipText = "Load selected files";
            this.TSB_Load.Click += new System.EventHandler(this.TSB_LoadClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_Refresh,
            this.TSB_Load,
            this.TSB_DelFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(647, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSB_DelFile
            // 
            this.TSB_DelFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_DelFile.Image = global::CANStream.Icones.Delete_16;
            this.TSB_DelFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_DelFile.Name = "TSB_DelFile";
            this.TSB_DelFile.Size = new System.Drawing.Size(23, 22);
            this.TSB_DelFile.Text = "toolStripButton1";
            this.TSB_DelFile.ToolTipText = "Deleted selected files";
            this.TSB_DelFile.Click += new System.EventHandler(this.TSB_DelFileClick);
            // 
            // Frm_DataBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(647, 380);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = global::CANStream.Icones.Databrowser_Icone;
            this.Name = "Frm_DataBrowser";
            this.Text = "Data Browser";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_DataBrowserFormClosing);
            this.Load += new System.EventHandler(this.Frm_DataBrowserLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.Context_TV_Folders.ResumeLayout(false);
            this.Context_LV_Sessions.ResumeLayout(false);
            this.Context_LV_Files.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem deleteEventToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_TV_Folders;
		private System.Windows.Forms.ToolStripMenuItem deleteSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripButton TSB_DelFile;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem sessionDetailsToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_LV_Files;
		private System.Windows.Forms.ToolStripMenuItem eventDetailsToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_LV_Sessions;
		private System.Windows.Forms.ColumnHeader SessionName;
		private System.Windows.Forms.ListView LV_Sessions;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.ColumnHeader FileSize;
		private System.Windows.Forms.ColumnHeader FileLastModified;
		private System.Windows.Forms.ColumnHeader FileName;
		private System.Windows.Forms.FolderBrowserDialog Dlg_FolderBrowser;
		private System.Windows.Forms.ImageList Img_DataBrowser;
		private System.Windows.Forms.ListView LV_Files;
		private System.Windows.Forms.ComboBox Cmb_RootFolder;
		private System.Windows.Forms.Button Cmd_RootFolder;
		private System.Windows.Forms.TreeView TV_Folders;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripButton TSB_Load;
		private System.Windows.Forms.ToolStripButton TSB_Refresh;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
