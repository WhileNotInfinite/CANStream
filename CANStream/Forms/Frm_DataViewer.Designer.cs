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
	partial class Frm_DataViewer
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
			this.Tab_Viewers = new System.Windows.Forms.TabControl();
			this.Tab_NewViewer = new System.Windows.Forms.TabPage();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.TSB_DataBrowser = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_NewViewerBook = new System.Windows.Forms.ToolStripButton();
			this.TSB_OpenViewerBook = new System.Windows.Forms.ToolStripButton();
			this.TSB_SaveViewerBook = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_NewViewerPage = new System.Windows.Forms.ToolStripButton();
			this.TSB_OpenViewerPage = new System.Windows.Forms.ToolStripButton();
			this.TSB_SaveViewerPage = new System.Windows.Forms.ToolStripButton();
			this.TSB_SaveAllViewerPages = new System.Windows.Forms.ToolStripButton();
			this.TSB_CloseViewerPage = new System.Windows.Forms.ToolStripButton();
			this.TSB_CopyViewerPage = new System.Windows.Forms.ToolStripButton();
			this.TSB_PastViewerPage = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_VirtualChannels = new System.Windows.Forms.ToolStripButton();
			this.TSB_EventSessionInfo = new System.Windows.Forms.ToolStripButton();
			this.Dlg_OpenViewerPage = new System.Windows.Forms.OpenFileDialog();
			this.Dlg_SaveViewerPage = new System.Windows.Forms.SaveFileDialog();
			this.Dlg_OpenViewerBook = new System.Windows.Forms.OpenFileDialog();
			this.Dlg_SaveViewerBook = new System.Windows.Forms.SaveFileDialog();
			this.Context_TabViewers = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.TSMI_CtxtTab_Rename = new System.Windows.Forms.ToolStripMenuItem();
			this.TSMI_CtxtTab_Close = new System.Windows.Forms.ToolStripMenuItem();
			this.TSMI_CtxtTab_MoveLeft = new System.Windows.Forms.ToolStripMenuItem();
			this.TSMI_CtxtTab_MoveRight = new System.Windows.Forms.ToolStripMenuItem();
			this.TSMI_CtxtTab_Copy = new System.Windows.Forms.ToolStripMenuItem();
			this.TSMI_CtxtTab_Past = new System.Windows.Forms.ToolStripMenuItem();
			this.Tab_Viewers.SuspendLayout();
			this.toolStrip1.SuspendLayout();
			this.Context_TabViewers.SuspendLayout();
			this.SuspendLayout();
			// 
			// Tab_Viewers
			// 
			this.Tab_Viewers.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.Tab_Viewers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Tab_Viewers.Controls.Add(this.Tab_NewViewer);
			this.Tab_Viewers.ItemSize = new System.Drawing.Size(50, 18);
			this.Tab_Viewers.Location = new System.Drawing.Point(0, 28);
			this.Tab_Viewers.Name = "Tab_Viewers";
			this.Tab_Viewers.SelectedIndex = 0;
			this.Tab_Viewers.ShowToolTips = true;
			this.Tab_Viewers.Size = new System.Drawing.Size(697, 364);
			this.Tab_Viewers.TabIndex = 0;
			this.Tab_Viewers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_ViewersMouseClick);
			// 
			// Tab_NewViewer
			// 
			this.Tab_NewViewer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
			this.Tab_NewViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.Tab_NewViewer.Location = new System.Drawing.Point(4, 4);
			this.Tab_NewViewer.Margin = new System.Windows.Forms.Padding(0);
			this.Tab_NewViewer.Name = "Tab_NewViewer";
			this.Tab_NewViewer.Padding = new System.Windows.Forms.Padding(3);
			this.Tab_NewViewer.Size = new System.Drawing.Size(689, 338);
			this.Tab_NewViewer.TabIndex = 0;
			this.Tab_NewViewer.Text = "+";
			this.Tab_NewViewer.ToolTipText = "Create a new viewer page";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSB_DataBrowser,
									this.toolStripSeparator2,
									this.TSB_NewViewerBook,
									this.TSB_OpenViewerBook,
									this.TSB_SaveViewerBook,
									this.toolStripSeparator1,
									this.TSB_NewViewerPage,
									this.TSB_OpenViewerPage,
									this.TSB_SaveViewerPage,
									this.TSB_SaveAllViewerPages,
									this.TSB_CloseViewerPage,
									this.TSB_CopyViewerPage,
									this.TSB_PastViewerPage,
									this.toolStripSeparator3,
									this.TSB_VirtualChannels,
									this.TSB_EventSessionInfo});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(698, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// TSB_DataBrowser
			// 
			this.TSB_DataBrowser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_DataBrowser.Image = global::CANStream.Icones.Data_Browser_16;
			this.TSB_DataBrowser.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_DataBrowser.Name = "TSB_DataBrowser";
			this.TSB_DataBrowser.Size = new System.Drawing.Size(23, 22);
			this.TSB_DataBrowser.Text = "toolStripButton1";
			this.TSB_DataBrowser.ToolTipText = "Open data browser";
			this.TSB_DataBrowser.Click += new System.EventHandler(this.TSB_DataBrowserClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// TSB_NewViewerBook
			// 
			this.TSB_NewViewerBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_NewViewerBook.Image = global::CANStream.Icones.File_New_16;
			this.TSB_NewViewerBook.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_NewViewerBook.Name = "TSB_NewViewerBook";
			this.TSB_NewViewerBook.Size = new System.Drawing.Size(23, 22);
			this.TSB_NewViewerBook.Text = "toolStripButton1";
			this.TSB_NewViewerBook.ToolTipText = "Create new data viewer book";
			this.TSB_NewViewerBook.Click += new System.EventHandler(this.TSB_NewViewerBookClick);
			// 
			// TSB_OpenViewerBook
			// 
			this.TSB_OpenViewerBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_OpenViewerBook.Image = global::CANStream.Icones.File_Open_16;
			this.TSB_OpenViewerBook.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_OpenViewerBook.Name = "TSB_OpenViewerBook";
			this.TSB_OpenViewerBook.Size = new System.Drawing.Size(23, 22);
			this.TSB_OpenViewerBook.Text = "toolStripButton2";
			this.TSB_OpenViewerBook.ToolTipText = "Open data viewer book";
			this.TSB_OpenViewerBook.Click += new System.EventHandler(this.TSB_OpenViewerBookClick);
			// 
			// TSB_SaveViewerBook
			// 
			this.TSB_SaveViewerBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_SaveViewerBook.Image = global::CANStream.Icones.File_Save_2_16;
			this.TSB_SaveViewerBook.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_SaveViewerBook.Name = "TSB_SaveViewerBook";
			this.TSB_SaveViewerBook.Size = new System.Drawing.Size(23, 22);
			this.TSB_SaveViewerBook.Text = "toolStripButton1";
			this.TSB_SaveViewerBook.ToolTipText = "Save data viewer book";
			this.TSB_SaveViewerBook.Click += new System.EventHandler(this.TSB_SaveViewerBookClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// TSB_NewViewerPage
			// 
			this.TSB_NewViewerPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_NewViewerPage.Image = global::CANStream.Icones.Tab_New_16;
			this.TSB_NewViewerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_NewViewerPage.Name = "TSB_NewViewerPage";
			this.TSB_NewViewerPage.Size = new System.Drawing.Size(23, 22);
			this.TSB_NewViewerPage.Text = "toolStripButton1";
			this.TSB_NewViewerPage.ToolTipText = "New data viewer page";
			this.TSB_NewViewerPage.Click += new System.EventHandler(this.TSB_NewViewerPageClick);
			// 
			// TSB_OpenViewerPage
			// 
			this.TSB_OpenViewerPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_OpenViewerPage.Image = global::CANStream.Icones.Tab_Open_16;
			this.TSB_OpenViewerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_OpenViewerPage.Name = "TSB_OpenViewerPage";
			this.TSB_OpenViewerPage.Size = new System.Drawing.Size(23, 22);
			this.TSB_OpenViewerPage.Text = "toolStripButton2";
			this.TSB_OpenViewerPage.ToolTipText = "Open data viewer page";
			this.TSB_OpenViewerPage.Click += new System.EventHandler(this.TSB_OpenViewerPageClick);
			// 
			// TSB_SaveViewerPage
			// 
			this.TSB_SaveViewerPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_SaveViewerPage.Image = global::CANStream.Icones.File_Save_16;
			this.TSB_SaveViewerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_SaveViewerPage.Name = "TSB_SaveViewerPage";
			this.TSB_SaveViewerPage.Size = new System.Drawing.Size(23, 22);
			this.TSB_SaveViewerPage.Text = "toolStripButton3";
			this.TSB_SaveViewerPage.ToolTipText = "Save data viewer page";
			this.TSB_SaveViewerPage.Click += new System.EventHandler(this.TSB_SaveViewerPageClick);
			// 
			// TSB_SaveAllViewerPages
			// 
			this.TSB_SaveAllViewerPages.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_SaveAllViewerPages.Image = global::CANStream.Icones.File_SaveAll_16;
			this.TSB_SaveAllViewerPages.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_SaveAllViewerPages.Name = "TSB_SaveAllViewerPages";
			this.TSB_SaveAllViewerPages.Size = new System.Drawing.Size(23, 22);
			this.TSB_SaveAllViewerPages.Text = "toolStripButton4";
			this.TSB_SaveAllViewerPages.ToolTipText = "Save all data viewer pages";
			this.TSB_SaveAllViewerPages.Click += new System.EventHandler(this.TSB_SaveAllViewerPagesClick);
			// 
			// TSB_CloseViewerPage
			// 
			this.TSB_CloseViewerPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_CloseViewerPage.Image = global::CANStream.Icones.Stop_Process_16;
			this.TSB_CloseViewerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_CloseViewerPage.Name = "TSB_CloseViewerPage";
			this.TSB_CloseViewerPage.Size = new System.Drawing.Size(23, 22);
			this.TSB_CloseViewerPage.Text = "toolStripButton5";
			this.TSB_CloseViewerPage.ToolTipText = "Close data viewer page";
			this.TSB_CloseViewerPage.Click += new System.EventHandler(this.TSB_CloseViewerPageClick);
			// 
			// TSB_CopyViewerPage
			// 
			this.TSB_CopyViewerPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_CopyViewerPage.Image = global::CANStream.Icones.Copy_16;
			this.TSB_CopyViewerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_CopyViewerPage.Name = "TSB_CopyViewerPage";
			this.TSB_CopyViewerPage.Size = new System.Drawing.Size(23, 22);
			this.TSB_CopyViewerPage.Text = "toolStripButton1";
			this.TSB_CopyViewerPage.ToolTipText = "Copy data viewer page";
			this.TSB_CopyViewerPage.Click += new System.EventHandler(this.TSB_CopyViewerPage_Click);
			// 
			// TSB_PastViewerPage
			// 
			this.TSB_PastViewerPage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_PastViewerPage.Enabled = false;
			this.TSB_PastViewerPage.Image = global::CANStream.Icones.Paste_16;
			this.TSB_PastViewerPage.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_PastViewerPage.Name = "TSB_PastViewerPage";
			this.TSB_PastViewerPage.Size = new System.Drawing.Size(23, 22);
			this.TSB_PastViewerPage.Text = "toolStripButton2";
			this.TSB_PastViewerPage.ToolTipText = "Past data viewer page";
			this.TSB_PastViewerPage.Click += new System.EventHandler(this.TSB_PastViewerPage_Click);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			// 
			// TSB_VirtualChannels
			// 
			this.TSB_VirtualChannels.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_VirtualChannels.Image = global::CANStream.Icones.Virtual_Channel_16;
			this.TSB_VirtualChannels.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_VirtualChannels.Name = "TSB_VirtualChannels";
			this.TSB_VirtualChannels.Size = new System.Drawing.Size(23, 22);
			this.TSB_VirtualChannels.Text = "toolStripButton1";
			this.TSB_VirtualChannels.ToolTipText = "Edit virtual channels libraries";
			this.TSB_VirtualChannels.Click += new System.EventHandler(this.TSB_VirtualChannelsClick);
			// 
			// TSB_EventSessionInfo
			// 
			this.TSB_EventSessionInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_EventSessionInfo.Image = global::CANStream.Icones.Information_16;
			this.TSB_EventSessionInfo.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_EventSessionInfo.Name = "TSB_EventSessionInfo";
			this.TSB_EventSessionInfo.Size = new System.Drawing.Size(23, 22);
			this.TSB_EventSessionInfo.Text = "toolStripButton1";
			this.TSB_EventSessionInfo.ToolTipText = "Show event/session information";
			this.TSB_EventSessionInfo.Click += new System.EventHandler(this.TSB_EventSessionInfoClick);
			// 
			// Dlg_OpenViewerPage
			// 
			this.Dlg_OpenViewerPage.Filter = "Data viewer page|*.xgw";
			// 
			// Dlg_SaveViewerPage
			// 
			this.Dlg_SaveViewerPage.Filter = "Data viewer page|*.xgw";
			// 
			// Dlg_OpenViewerBook
			// 
			this.Dlg_OpenViewerBook.Filter = "Data viewer book|*.dvb";
			// 
			// Dlg_SaveViewerBook
			// 
			this.Dlg_SaveViewerBook.Filter = "Data viewer book|*.dvb";
			// 
			// Context_TabViewers
			// 
			this.Context_TabViewers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSMI_CtxtTab_Rename,
									this.TSMI_CtxtTab_Close,
									this.TSMI_CtxtTab_MoveLeft,
									this.TSMI_CtxtTab_MoveRight,
									this.TSMI_CtxtTab_Copy,
									this.TSMI_CtxtTab_Past});
			this.Context_TabViewers.Name = "Context_TabViewers";
			this.Context_TabViewers.Size = new System.Drawing.Size(133, 136);
			// 
			// TSMI_CtxtTab_Rename
			// 
			this.TSMI_CtxtTab_Rename.Image = global::CANStream.Icones.Rename_16;
			this.TSMI_CtxtTab_Rename.Name = "TSMI_CtxtTab_Rename";
			this.TSMI_CtxtTab_Rename.Size = new System.Drawing.Size(132, 22);
			this.TSMI_CtxtTab_Rename.Text = "Rename";
			this.TSMI_CtxtTab_Rename.Click += new System.EventHandler(this.TSMI_CtxtTab_RenameClick);
			// 
			// TSMI_CtxtTab_Close
			// 
			this.TSMI_CtxtTab_Close.Image = global::CANStream.Icones.Delete_16;
			this.TSMI_CtxtTab_Close.Name = "TSMI_CtxtTab_Close";
			this.TSMI_CtxtTab_Close.Size = new System.Drawing.Size(132, 22);
			this.TSMI_CtxtTab_Close.Text = "Close page";
			this.TSMI_CtxtTab_Close.Click += new System.EventHandler(this.TSMI_CtxtTab_CloseClick);
			// 
			// TSMI_CtxtTab_MoveLeft
			// 
			this.TSMI_CtxtTab_MoveLeft.Image = global::CANStream.Icones.Move_Left_16;
			this.TSMI_CtxtTab_MoveLeft.Name = "TSMI_CtxtTab_MoveLeft";
			this.TSMI_CtxtTab_MoveLeft.Size = new System.Drawing.Size(132, 22);
			this.TSMI_CtxtTab_MoveLeft.Text = "Move left";
			this.TSMI_CtxtTab_MoveLeft.Click += new System.EventHandler(this.TSMI_CtxtTab_MoveLeftClick);
			// 
			// TSMI_CtxtTab_MoveRight
			// 
			this.TSMI_CtxtTab_MoveRight.Image = global::CANStream.Icones.Move_Right_16;
			this.TSMI_CtxtTab_MoveRight.Name = "TSMI_CtxtTab_MoveRight";
			this.TSMI_CtxtTab_MoveRight.Size = new System.Drawing.Size(132, 22);
			this.TSMI_CtxtTab_MoveRight.Text = "Move right";
			this.TSMI_CtxtTab_MoveRight.Click += new System.EventHandler(this.TSMI_CtxtTab_MoveRightClick);
			// 
			// TSMI_CtxtTab_Copy
			// 
			this.TSMI_CtxtTab_Copy.Image = global::CANStream.Icones.Copy_16;
			this.TSMI_CtxtTab_Copy.Name = "TSMI_CtxtTab_Copy";
			this.TSMI_CtxtTab_Copy.Size = new System.Drawing.Size(132, 22);
			this.TSMI_CtxtTab_Copy.Text = "Copy";
			this.TSMI_CtxtTab_Copy.Click += new System.EventHandler(this.TSMI_CtxtTab_Copy_Click);
			// 
			// TSMI_CtxtTab_Past
			// 
			this.TSMI_CtxtTab_Past.Enabled = false;
			this.TSMI_CtxtTab_Past.Image = global::CANStream.Icones.Paste_16;
			this.TSMI_CtxtTab_Past.Name = "TSMI_CtxtTab_Past";
			this.TSMI_CtxtTab_Past.Size = new System.Drawing.Size(132, 22);
			this.TSMI_CtxtTab_Past.Text = "Past";
			this.TSMI_CtxtTab_Past.Click += new System.EventHandler(this.TSMI_CtxtTab_Past_Click);
			// 
			// Frm_DataViewer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(698, 393);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.Tab_Viewers);
			this.Icon = global::CANStream.Icones.CANStream_Icone;
			this.Name = "Frm_DataViewer";
			this.Text = "Data Viewer";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Tab_Viewers.ResumeLayout(false);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.Context_TabViewers.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton TSB_VirtualChannels;
		private System.Windows.Forms.ToolStripButton TSB_EventSessionInfo;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem TSMI_CtxtTab_Rename;
		private System.Windows.Forms.ToolStripMenuItem TSMI_CtxtTab_MoveRight;
		private System.Windows.Forms.ToolStripMenuItem TSMI_CtxtTab_MoveLeft;
		private System.Windows.Forms.ToolStripMenuItem TSMI_CtxtTab_Close;
		private System.Windows.Forms.ContextMenuStrip Context_TabViewers;
		private System.Windows.Forms.SaveFileDialog Dlg_SaveViewerBook;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenViewerBook;
		private System.Windows.Forms.SaveFileDialog Dlg_SaveViewerPage;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenViewerPage;
		private System.Windows.Forms.ToolStripButton TSB_DataBrowser;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton TSB_CloseViewerPage;
		private System.Windows.Forms.ToolStripButton TSB_SaveAllViewerPages;
		private System.Windows.Forms.ToolStripButton TSB_SaveViewerPage;
		private System.Windows.Forms.ToolStripButton TSB_OpenViewerPage;
		private System.Windows.Forms.ToolStripButton TSB_NewViewerPage;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton TSB_SaveViewerBook;
		private System.Windows.Forms.ToolStripButton TSB_OpenViewerBook;
		private System.Windows.Forms.ToolStripButton TSB_NewViewerBook;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.TabPage Tab_NewViewer;
		private System.Windows.Forms.TabControl Tab_Viewers;
        private System.Windows.Forms.ToolStripMenuItem TSMI_CtxtTab_Copy;
        private System.Windows.Forms.ToolStripMenuItem TSMI_CtxtTab_Past;
        private System.Windows.Forms.ToolStripButton TSB_CopyViewerPage;
        private System.Windows.Forms.ToolStripButton TSB_PastViewerPage;
	}
}
