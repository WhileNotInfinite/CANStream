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
	partial class Frm_BuiltInSignal
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_BuiltInSignal));
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.TSB_NewLibrary = new System.Windows.Forms.ToolStripButton();
			this.TSB_NewSignal = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_OpenLibrary = new System.Windows.Forms.ToolStripButton();
			this.TSB_SaveLibrary = new System.Windows.Forms.ToolStripButton();
			this.TSB_SaveAllLibraries = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_Cut = new System.Windows.Forms.ToolStripButton();
			this.TSB_Copy = new System.Windows.Forms.ToolStripButton();
			this.TSB_Paste = new System.Windows.Forms.ToolStripButton();
			this.TSB_Delete = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.TV_Libraries = new System.Windows.Forms.TreeView();
			this.Context_TVLibraries = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.newLibraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.libraryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.virtualChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
			this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.Img_TV = new System.Windows.Forms.ImageList(this.components);
			this.TabCtrl_PropertiesEdit = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.Cmd_LibCancel = new System.Windows.Forms.Button();
			this.Cmd_LibCreate = new System.Windows.Forms.Button();
			this.Chk_LibReadOnly = new System.Windows.Forms.CheckBox();
			this.rTxt_LibComment = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Txt_LibName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.Cmd_SigCancel = new System.Windows.Forms.Button();
			this.Cmd_SigCreate = new System.Windows.Forms.Button();
			this.label8 = new System.Windows.Forms.Label();
			this.Grid_SignalProperties = new System.Windows.Forms.DataGridView();
			this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Cmb_SigType = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.rTxt_SigComment = new System.Windows.Forms.RichTextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.Txt_SigDecimal = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.Txt_SigUnit = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Txt_SigName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.Context_TVLibraries.SuspendLayout();
			this.TabCtrl_PropertiesEdit.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid_SignalProperties)).BeginInit();
			this.SuspendLayout();
			// 
			// toolStrip1
			// 
			this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSB_NewLibrary,
									this.TSB_NewSignal,
									this.toolStripSeparator1,
									this.TSB_OpenLibrary,
									this.TSB_SaveLibrary,
									this.TSB_SaveAllLibraries,
									this.toolStripSeparator2,
									this.TSB_Cut,
									this.TSB_Copy,
									this.TSB_Paste,
									this.TSB_Delete});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(562, 39);
			this.toolStrip1.TabIndex = 0;
			this.toolStrip1.Text = "toolStrip1";
			// 
			// TSB_NewLibrary
			// 
			this.TSB_NewLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_NewLibrary.Image = global::CANStream.Icones.library_32;
			this.TSB_NewLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_NewLibrary.Name = "TSB_NewLibrary";
			this.TSB_NewLibrary.Size = new System.Drawing.Size(36, 36);
			this.TSB_NewLibrary.Text = "toolStripButton1";
			this.TSB_NewLibrary.ToolTipText = "Create new signals library";
			this.TSB_NewLibrary.Click += new System.EventHandler(this.TSB_NewLibraryClick);
			// 
			// TSB_NewSignal
			// 
			this.TSB_NewSignal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_NewSignal.Image = global::CANStream.Icones.BuiltIn_Signal_32;
			this.TSB_NewSignal.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_NewSignal.Name = "TSB_NewSignal";
			this.TSB_NewSignal.Size = new System.Drawing.Size(36, 36);
			this.TSB_NewSignal.Text = "TSB_NewSignal";
			this.TSB_NewSignal.ToolTipText = "Create new signal";
			this.TSB_NewSignal.Click += new System.EventHandler(this.TSB_NewSignalClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// TSB_OpenLibrary
			// 
			this.TSB_OpenLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_OpenLibrary.Image = global::CANStream.Icones.File_Open_32;
			this.TSB_OpenLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_OpenLibrary.Name = "TSB_OpenLibrary";
			this.TSB_OpenLibrary.Size = new System.Drawing.Size(36, 36);
			this.TSB_OpenLibrary.Text = "TSB_Open";
			this.TSB_OpenLibrary.ToolTipText = "Open signals library";
			this.TSB_OpenLibrary.Click += new System.EventHandler(this.TSB_OpenLibraryClick);
			// 
			// TSB_SaveLibrary
			// 
			this.TSB_SaveLibrary.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_SaveLibrary.Image = global::CANStream.Icones.File_Save_32;
			this.TSB_SaveLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_SaveLibrary.Name = "TSB_SaveLibrary";
			this.TSB_SaveLibrary.Size = new System.Drawing.Size(36, 36);
			this.TSB_SaveLibrary.Text = "TSB_Save";
			this.TSB_SaveLibrary.ToolTipText = "Save current signals library";
			this.TSB_SaveLibrary.Click += new System.EventHandler(this.TSB_SaveLibraryClick);
			// 
			// TSB_SaveAllLibraries
			// 
			this.TSB_SaveAllLibraries.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_SaveAllLibraries.Image = global::CANStream.Icones.File_SaveAll_32;
			this.TSB_SaveAllLibraries.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_SaveAllLibraries.Name = "TSB_SaveAllLibraries";
			this.TSB_SaveAllLibraries.Size = new System.Drawing.Size(36, 36);
			this.TSB_SaveAllLibraries.Text = "TSB_SaveAll";
			this.TSB_SaveAllLibraries.ToolTipText = "Save all libraries";
			this.TSB_SaveAllLibraries.Click += new System.EventHandler(this.TSB_SaveAllLibrariesClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			// 
			// TSB_Cut
			// 
			this.TSB_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Cut.Image = global::CANStream.Icones.Cut_32;
			this.TSB_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Cut.Name = "TSB_Cut";
			this.TSB_Cut.Size = new System.Drawing.Size(36, 36);
			this.TSB_Cut.Text = "TSB_Cut";
			this.TSB_Cut.ToolTipText = "Cut";
			this.TSB_Cut.Click += new System.EventHandler(this.TSB_CutClick);
			// 
			// TSB_Copy
			// 
			this.TSB_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Copy.Image = global::CANStream.Icones.Copy_32;
			this.TSB_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Copy.Name = "TSB_Copy";
			this.TSB_Copy.Size = new System.Drawing.Size(36, 36);
			this.TSB_Copy.Text = "TSB_Copy";
			this.TSB_Copy.ToolTipText = "Copy";
			this.TSB_Copy.Click += new System.EventHandler(this.TSB_CopyClick);
			// 
			// TSB_Paste
			// 
			this.TSB_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Paste.Image = global::CANStream.Icones.Paste_32;
			this.TSB_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Paste.Name = "TSB_Paste";
			this.TSB_Paste.Size = new System.Drawing.Size(36, 36);
			this.TSB_Paste.Text = "TSB_Paste";
			this.TSB_Paste.ToolTipText = "Paste";
			this.TSB_Paste.Click += new System.EventHandler(this.TSB_PasteClick);
			// 
			// TSB_Delete
			// 
			this.TSB_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Delete.Image = global::CANStream.Icones.Delete_32;
			this.TSB_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Delete.Name = "TSB_Delete";
			this.TSB_Delete.Size = new System.Drawing.Size(36, 36);
			this.TSB_Delete.Text = "TSB_Delete";
			this.TSB_Delete.ToolTipText = "Delete";
			this.TSB_Delete.Click += new System.EventHandler(this.TSB_DeleteClick);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 39);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.TV_Libraries);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.TabCtrl_PropertiesEdit);
			this.splitContainer1.Size = new System.Drawing.Size(562, 380);
			this.splitContainer1.SplitterDistance = 197;
			this.splitContainer1.TabIndex = 1;
			// 
			// TV_Libraries
			// 
			this.TV_Libraries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TV_Libraries.ContextMenuStrip = this.Context_TVLibraries;
			this.TV_Libraries.ImageIndex = 0;
			this.TV_Libraries.ImageList = this.Img_TV;
			this.TV_Libraries.Location = new System.Drawing.Point(3, 3);
			this.TV_Libraries.Name = "TV_Libraries";
			this.TV_Libraries.SelectedImageIndex = 0;
			this.TV_Libraries.Size = new System.Drawing.Size(191, 374);
			this.TV_Libraries.TabIndex = 0;
			this.TV_Libraries.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_LibrariesAfterSelect);
			this.TV_Libraries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TV_LibrariesKeyDown);
			// 
			// Context_TVLibraries
			// 
			this.Context_TVLibraries.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.newLibraryToolStripMenuItem,
									this.openToolStripMenuItem,
									this.saveToolStripMenuItem,
									this.saveAllToolStripMenuItem,
									this.toolStripMenuItem1,
									this.cutToolStripMenuItem,
									this.copyToolStripMenuItem,
									this.pasteToolStripMenuItem,
									this.toolStripMenuItem2,
									this.deleteToolStripMenuItem,
									this.toolStripMenuItem3,
									this.expandAllToolStripMenuItem,
									this.collapseAllToolStripMenuItem});
			this.Context_TVLibraries.Name = "Ne";
			this.Context_TVLibraries.Size = new System.Drawing.Size(135, 242);
			// 
			// newLibraryToolStripMenuItem
			// 
			this.newLibraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.libraryToolStripMenuItem,
									this.virtualChannelToolStripMenuItem});
			this.newLibraryToolStripMenuItem.Image = global::CANStream.Icones.Item_Add_16;
			this.newLibraryToolStripMenuItem.Name = "newLibraryToolStripMenuItem";
			this.newLibraryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.newLibraryToolStripMenuItem.Text = "New";
			// 
			// libraryToolStripMenuItem
			// 
			this.libraryToolStripMenuItem.Image = global::CANStream.Icones.library_16;
			this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
			this.libraryToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.libraryToolStripMenuItem.Text = "Library";
			this.libraryToolStripMenuItem.Click += new System.EventHandler(this.LibraryToolStripMenuItemClick);
			// 
			// virtualChannelToolStripMenuItem
			// 
			this.virtualChannelToolStripMenuItem.Image = global::CANStream.Icones.BuiltIn_Signal_16;
			this.virtualChannelToolStripMenuItem.Name = "virtualChannelToolStripMenuItem";
			this.virtualChannelToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.virtualChannelToolStripMenuItem.Text = "Built-in Signal";
			this.virtualChannelToolStripMenuItem.Click += new System.EventHandler(this.BuiltInSignallToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = global::CANStream.Icones.File_Open_16;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = global::CANStream.Icones.File_Save_16;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// saveAllToolStripMenuItem
			// 
			this.saveAllToolStripMenuItem.Image = global::CANStream.Icones.File_SaveAll_16;
			this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
			this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.saveAllToolStripMenuItem.Text = "Save all";
			this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
			// 
			// cutToolStripMenuItem
			// 
			this.cutToolStripMenuItem.Image = global::CANStream.Icones.Cut_16;
			this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
			this.cutToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.cutToolStripMenuItem.Text = "Cut";
			this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItemClick);
			// 
			// copyToolStripMenuItem
			// 
			this.copyToolStripMenuItem.Image = global::CANStream.Icones.Copy_16;
			this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			this.copyToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.copyToolStripMenuItem.Text = "Copy";
			this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
			// 
			// pasteToolStripMenuItem
			// 
			this.pasteToolStripMenuItem.Image = global::CANStream.Icones.Paste_16;
			this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
			this.pasteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.pasteToolStripMenuItem.Text = "Paste";
			this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItemClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(149, 6);
			// 
			// expandAllToolStripMenuItem
			// 
			this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
			this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.expandAllToolStripMenuItem.Text = "Expand all";
			this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItemClick);
			// 
			// collapseAllToolStripMenuItem
			// 
			this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
			this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.collapseAllToolStripMenuItem.Text = "Collapse all";
			this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItemClick);
			// 
			// Img_TV
			// 
			this.Img_TV.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_TV.ImageStream")));
			this.Img_TV.TransparentColor = System.Drawing.Color.Transparent;
			this.Img_TV.Images.SetKeyName(0, "library-books-icone-5837-16.png");
			this.Img_TV.Images.SetKeyName(1, "gear-wheel-system-package-icone-9540-16.png");
			// 
			// TabCtrl_PropertiesEdit
			// 
			this.TabCtrl_PropertiesEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.TabCtrl_PropertiesEdit.Controls.Add(this.tabPage1);
			this.TabCtrl_PropertiesEdit.Controls.Add(this.tabPage2);
			this.TabCtrl_PropertiesEdit.Location = new System.Drawing.Point(3, 3);
			this.TabCtrl_PropertiesEdit.Name = "TabCtrl_PropertiesEdit";
			this.TabCtrl_PropertiesEdit.SelectedIndex = 0;
			this.TabCtrl_PropertiesEdit.Size = new System.Drawing.Size(358, 374);
			this.TabCtrl_PropertiesEdit.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage1.Controls.Add(this.Cmd_LibCancel);
			this.tabPage1.Controls.Add(this.Cmd_LibCreate);
			this.tabPage1.Controls.Add(this.Chk_LibReadOnly);
			this.tabPage1.Controls.Add(this.rTxt_LibComment);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.Txt_LibName);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(350, 348);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Library properties";
			// 
			// Cmd_LibCancel
			// 
			this.Cmd_LibCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_LibCancel.Location = new System.Drawing.Point(186, 319);
			this.Cmd_LibCancel.Name = "Cmd_LibCancel";
			this.Cmd_LibCancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_LibCancel.TabIndex = 18;
			this.Cmd_LibCancel.Text = "Cancel";
			this.Cmd_LibCancel.UseVisualStyleBackColor = true;
			this.Cmd_LibCancel.Click += new System.EventHandler(this.Cmd_LibCancelClick);
			// 
			// Cmd_LibCreate
			// 
			this.Cmd_LibCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_LibCreate.Location = new System.Drawing.Point(269, 319);
			this.Cmd_LibCreate.Name = "Cmd_LibCreate";
			this.Cmd_LibCreate.Size = new System.Drawing.Size(75, 23);
			this.Cmd_LibCreate.TabIndex = 17;
			this.Cmd_LibCreate.Text = "Create";
			this.Cmd_LibCreate.UseVisualStyleBackColor = true;
			this.Cmd_LibCreate.Click += new System.EventHandler(this.Cmd_LibCreateClick);
			// 
			// Chk_LibReadOnly
			// 
			this.Chk_LibReadOnly.Location = new System.Drawing.Point(6, 183);
			this.Chk_LibReadOnly.Name = "Chk_LibReadOnly";
			this.Chk_LibReadOnly.Size = new System.Drawing.Size(104, 24);
			this.Chk_LibReadOnly.TabIndex = 4;
			this.Chk_LibReadOnly.Text = "Read only";
			this.Chk_LibReadOnly.UseVisualStyleBackColor = true;
			// 
			// rTxt_LibComment
			// 
			this.rTxt_LibComment.Location = new System.Drawing.Point(6, 82);
			this.rTxt_LibComment.Name = "rTxt_LibComment";
			this.rTxt_LibComment.Size = new System.Drawing.Size(338, 96);
			this.rTxt_LibComment.TabIndex = 3;
			this.rTxt_LibComment.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 16);
			this.label2.TabIndex = 2;
			this.label2.Text = "Comment";
			// 
			// Txt_LibName
			// 
			this.Txt_LibName.Location = new System.Drawing.Point(6, 32);
			this.Txt_LibName.Name = "Txt_LibName";
			this.Txt_LibName.Size = new System.Drawing.Size(338, 20);
			this.Txt_LibName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Library name";
			// 
			// tabPage2
			// 
			this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
			this.tabPage2.Controls.Add(this.Cmd_SigCancel);
			this.tabPage2.Controls.Add(this.Cmd_SigCreate);
			this.tabPage2.Controls.Add(this.label8);
			this.tabPage2.Controls.Add(this.Grid_SignalProperties);
			this.tabPage2.Controls.Add(this.Cmb_SigType);
			this.tabPage2.Controls.Add(this.label7);
			this.tabPage2.Controls.Add(this.rTxt_SigComment);
			this.tabPage2.Controls.Add(this.label6);
			this.tabPage2.Controls.Add(this.Txt_SigDecimal);
			this.tabPage2.Controls.Add(this.label5);
			this.tabPage2.Controls.Add(this.Txt_SigUnit);
			this.tabPage2.Controls.Add(this.label4);
			this.tabPage2.Controls.Add(this.Txt_SigName);
			this.tabPage2.Controls.Add(this.label3);
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(350, 348);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Signal properties";
			// 
			// Cmd_SigCancel
			// 
			this.Cmd_SigCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_SigCancel.Location = new System.Drawing.Point(189, 319);
			this.Cmd_SigCancel.Name = "Cmd_SigCancel";
			this.Cmd_SigCancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_SigCancel.TabIndex = 21;
			this.Cmd_SigCancel.Text = "Cancel";
			this.Cmd_SigCancel.UseVisualStyleBackColor = true;
			this.Cmd_SigCancel.Click += new System.EventHandler(this.Cmd_SigCancelClick);
			// 
			// Cmd_SigCreate
			// 
			this.Cmd_SigCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_SigCreate.Location = new System.Drawing.Point(272, 319);
			this.Cmd_SigCreate.Name = "Cmd_SigCreate";
			this.Cmd_SigCreate.Size = new System.Drawing.Size(75, 23);
			this.Cmd_SigCreate.TabIndex = 20;
			this.Cmd_SigCreate.Text = "Create";
			this.Cmd_SigCreate.UseVisualStyleBackColor = true;
			this.Cmd_SigCreate.Click += new System.EventHandler(this.Cmd_SigCreateClick);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 141);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 18);
			this.label8.TabIndex = 19;
			this.label8.Text = "Signal properties";
			// 
			// Grid_SignalProperties
			// 
			this.Grid_SignalProperties.AllowUserToAddRows = false;
			this.Grid_SignalProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Grid_SignalProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Grid_SignalProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.Value});
			this.Grid_SignalProperties.Location = new System.Drawing.Point(9, 162);
			this.Grid_SignalProperties.Name = "Grid_SignalProperties";
			this.Grid_SignalProperties.RowHeadersWidth = 120;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.Grid_SignalProperties.RowsDefaultCellStyle = dataGridViewCellStyle2;
			this.Grid_SignalProperties.Size = new System.Drawing.Size(338, 141);
			this.Grid_SignalProperties.TabIndex = 18;
			// 
			// Value
			// 
			this.Value.HeaderText = "Value";
			this.Value.Name = "Value";
			// 
			// Cmb_SigType
			// 
			this.Cmb_SigType.FormattingEnabled = true;
			this.Cmb_SigType.Location = new System.Drawing.Point(60, 39);
			this.Cmb_SigType.Name = "Cmb_SigType";
			this.Cmb_SigType.Size = new System.Drawing.Size(287, 21);
			this.Cmb_SigType.TabIndex = 17;
			this.Cmb_SigType.SelectedIndexChanged += new System.EventHandler(this.Cmb_SigTypeSelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 42);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(39, 18);
			this.label7.TabIndex = 16;
			this.label7.Text = "Type:";
			// 
			// rTxt_SigComment
			// 
			this.rTxt_SigComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rTxt_SigComment.Location = new System.Drawing.Point(60, 92);
			this.rTxt_SigComment.Name = "rTxt_SigComment";
			this.rTxt_SigComment.Size = new System.Drawing.Size(287, 46);
			this.rTxt_SigComment.TabIndex = 15;
			this.rTxt_SigComment.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(6, 92);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 18);
			this.label6.TabIndex = 14;
			this.label6.Text = "Comment:";
			// 
			// Txt_SigDecimal
			// 
			this.Txt_SigDecimal.Location = new System.Drawing.Point(207, 66);
			this.Txt_SigDecimal.Name = "Txt_SigDecimal";
			this.Txt_SigDecimal.Size = new System.Drawing.Size(61, 20);
			this.Txt_SigDecimal.TabIndex = 13;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(145, 69);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 18);
			this.label5.TabIndex = 12;
			this.label5.Text = "Decimals:";
			// 
			// Txt_SigUnit
			// 
			this.Txt_SigUnit.Location = new System.Drawing.Point(60, 68);
			this.Txt_SigUnit.Name = "Txt_SigUnit";
			this.Txt_SigUnit.Size = new System.Drawing.Size(61, 20);
			this.Txt_SigUnit.TabIndex = 11;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 70);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 18);
			this.label4.TabIndex = 10;
			this.label4.Text = "Unit:";
			// 
			// Txt_SigName
			// 
			this.Txt_SigName.Location = new System.Drawing.Point(60, 13);
			this.Txt_SigName.Name = "Txt_SigName";
			this.Txt_SigName.Size = new System.Drawing.Size(287, 20);
			this.Txt_SigName.TabIndex = 9;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 15);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 18);
			this.label3.TabIndex = 8;
			this.label3.Text = "Name:";
			// 
			// Frm_BuiltInSignal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(562, 419);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = global::CANStream.Icones.CANStream_Icone;
			this.Name = "Frm_BuiltInSignal";
			this.Text = "Built-in Signal editor";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_BuiltInSignalFormClosing);
			this.Load += new System.EventHandler(this.Frm_BuiltInSignalLoad);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.Context_TVLibraries.ResumeLayout(false);
			this.TabCtrl_PropertiesEdit.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid_SignalProperties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem saveAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem virtualChannelToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem libraryToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newLibraryToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_TVLibraries;
		private System.Windows.Forms.SaveFileDialog Dlg_SaveFile;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenFile;
		private System.Windows.Forms.ImageList Img_TV;
		private System.Windows.Forms.Button Cmd_SigCreate;
		private System.Windows.Forms.Button Cmd_SigCancel;
		private System.Windows.Forms.Button Cmd_LibCreate;
		private System.Windows.Forms.Button Cmd_LibCancel;
		private System.Windows.Forms.DataGridView Grid_SignalProperties;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox Cmb_SigType;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Txt_SigName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox Txt_SigUnit;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox Txt_SigDecimal;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RichTextBox rTxt_SigComment;
		private System.Windows.Forms.CheckBox Chk_LibReadOnly;
		private System.Windows.Forms.RichTextBox rTxt_LibComment;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox Txt_LibName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl TabCtrl_PropertiesEdit;
		private System.Windows.Forms.TreeView TV_Libraries;
		private System.Windows.Forms.ToolStripButton TSB_Delete;
		private System.Windows.Forms.ToolStripButton TSB_Paste;
		private System.Windows.Forms.ToolStripButton TSB_Copy;
		private System.Windows.Forms.ToolStripButton TSB_Cut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton TSB_SaveAllLibraries;
		private System.Windows.Forms.ToolStripButton TSB_SaveLibrary;
		private System.Windows.Forms.ToolStripButton TSB_OpenLibrary;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton TSB_NewSignal;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripButton TSB_NewLibrary;
		private System.Windows.Forms.ToolStrip toolStrip1;
	}
}
