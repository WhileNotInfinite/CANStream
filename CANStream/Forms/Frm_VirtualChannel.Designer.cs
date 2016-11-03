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
	partial class Frm_VirtualChannel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_VirtualChannel));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_NewLibrary = new System.Windows.Forms.ToolStripButton();
            this.TSB_NewChannel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_OpenLib = new System.Windows.Forms.ToolStripButton();
            this.TSB_SaveLib = new System.Windows.Forms.ToolStripButton();
            this.TSB_SaveAllLib = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_Cut = new System.Windows.Forms.ToolStripButton();
            this.TSB_Copy = new System.Windows.Forms.ToolStripButton();
            this.TSB_Paste = new System.Windows.Forms.ToolStripButton();
            this.TSB_Delete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_LoadObjectFile = new System.Windows.Forms.ToolStripButton();
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
            this.Img_TVLibraries = new System.Windows.Forms.ImageList(this.components);
            this.TabCtrl_PropertiesEdit = new System.Windows.Forms.TabControl();
            this.Tab_LibProperties = new System.Windows.Forms.TabPage();
            this.Chk_LibEnabled = new System.Windows.Forms.CheckBox();
            this.Cmd_LibCancel = new System.Windows.Forms.Button();
            this.Cmd_LibCreate = new System.Windows.Forms.Button();
            this.Chk_LibReadOnly = new System.Windows.Forms.CheckBox();
            this.rTxt_LibComment = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_LibName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab_ChannelProperties = new System.Windows.Forms.TabPage();
            this.Grp_Alarms = new System.Windows.Forms.GroupBox();
            this.Pic_AlarmMax_Forecolor = new System.Windows.Forms.PictureBox();
            this.Pic_AlarmMax_Backcolor = new System.Windows.Forms.PictureBox();
            this.Pic_AlarmMin_Forecolor = new System.Windows.Forms.PictureBox();
            this.Pic_AlarmMin_Backcolor = new System.Windows.Forms.PictureBox();
            this.Pic_WarningMax_Forecolor = new System.Windows.Forms.PictureBox();
            this.Pic_WarningMax_Backcolor = new System.Windows.Forms.PictureBox();
            this.Chk_AlarmMax = new System.Windows.Forms.CheckBox();
            this.Chk_AlarmMin = new System.Windows.Forms.CheckBox();
            this.Chk_WarningMax = new System.Windows.Forms.CheckBox();
            this.Txt_AlarmMax = new System.Windows.Forms.TextBox();
            this.Txt_AlarmMin = new System.Windows.Forms.TextBox();
            this.Txt_WarningMax = new System.Windows.Forms.TextBox();
            this.Lbl_Alarms_Forecolor = new System.Windows.Forms.Label();
            this.Pic_WarningMin_Forecolor = new System.Windows.Forms.PictureBox();
            this.Chk_WarningMin = new System.Windows.Forms.CheckBox();
            this.Chk_AlarmsEnabled = new System.Windows.Forms.CheckBox();
            this.Pic_WarningMin_Backcolor = new System.Windows.Forms.PictureBox();
            this.Lbl_Alarms_Backcolor = new System.Windows.Forms.Label();
            this.Txt_WarningMin = new System.Windows.Forms.TextBox();
            this.Cmd_EnumDefinition = new System.Windows.Forms.Button();
            this.Txt_Decimals = new System.Windows.Forms.TextBox();
            this.Lbl_Decimals = new System.Windows.Forms.Label();
            this.Cmb_ValueFormat = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Chk_ChanComputationEnabled = new System.Windows.Forms.CheckBox();
            this.Txt_ChanValDef = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Cmd_ChannelTest = new System.Windows.Forms.Button();
            this.Cmd_ChanCancel = new System.Windows.Forms.Button();
            this.Cmd_ChanCreate = new System.Windows.Forms.Button();
            this.Cmd_ChannelList = new System.Windows.Forms.Button();
            this.Cmd_Functions = new System.Windows.Forms.Button();
            this.Cmd_Operators = new System.Windows.Forms.Button();
            this.rTxt_ChanExpression = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.rTxt_ChanComment = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_ChanUnit = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_ChanName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ToolTip_CmdChannelList = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTip_CmdFunctions = new System.Windows.Forms.ToolTip(this.components);
            this.ToolTip_CmdOperators = new System.Windows.Forms.ToolTip(this.components);
            this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.Dlg_SelectColor = new System.Windows.Forms.ColorDialog();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Context_TVLibraries.SuspendLayout();
            this.TabCtrl_PropertiesEdit.SuspendLayout();
            this.Tab_LibProperties.SuspendLayout();
            this.Tab_ChannelProperties.SuspendLayout();
            this.Grp_Alarms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Backcolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Backcolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Backcolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Backcolor)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_NewLibrary,
            this.TSB_NewChannel,
            this.toolStripButton4,
            this.TSB_OpenLib,
            this.TSB_SaveLib,
            this.TSB_SaveAllLib,
            this.toolStripSeparator1,
            this.TSB_Cut,
            this.TSB_Copy,
            this.TSB_Paste,
            this.TSB_Delete,
            this.toolStripSeparator2,
            this.TSB_LoadObjectFile});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(725, 39);
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
            this.TSB_NewLibrary.ToolTipText = "Create new library";
            this.TSB_NewLibrary.Click += new System.EventHandler(this.TSB_NewLibraryClick);
            // 
            // TSB_NewChannel
            // 
            this.TSB_NewChannel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewChannel.Image = global::CANStream.Icones.Virtual_Channel_32;
            this.TSB_NewChannel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewChannel.Name = "TSB_NewChannel";
            this.TSB_NewChannel.Size = new System.Drawing.Size(36, 36);
            this.TSB_NewChannel.Text = "toolStripButton6";
            this.TSB_NewChannel.ToolTipText = "Create new virtual channel";
            this.TSB_NewChannel.Click += new System.EventHandler(this.TSB_NewChannelClick);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_OpenLib
            // 
            this.TSB_OpenLib.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_OpenLib.Image = global::CANStream.Icones.File_Open_32;
            this.TSB_OpenLib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_OpenLib.Name = "TSB_OpenLib";
            this.TSB_OpenLib.Size = new System.Drawing.Size(36, 36);
            this.TSB_OpenLib.Text = "toolStripButton2";
            this.TSB_OpenLib.ToolTipText = "Load new virtual channels library";
            this.TSB_OpenLib.Click += new System.EventHandler(this.TSB_OpenLibClick);
            // 
            // TSB_SaveLib
            // 
            this.TSB_SaveLib.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_SaveLib.Image = global::CANStream.Icones.File_Save_32;
            this.TSB_SaveLib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_SaveLib.Name = "TSB_SaveLib";
            this.TSB_SaveLib.Size = new System.Drawing.Size(36, 36);
            this.TSB_SaveLib.Text = "toolStripButton3";
            this.TSB_SaveLib.ToolTipText = "Save active virtual channels library";
            this.TSB_SaveLib.Click += new System.EventHandler(this.TSB_SaveLibClick);
            // 
            // TSB_SaveAllLib
            // 
            this.TSB_SaveAllLib.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_SaveAllLib.Image = global::CANStream.Icones.File_SaveAll_32;
            this.TSB_SaveAllLib.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_SaveAllLib.Name = "TSB_SaveAllLib";
            this.TSB_SaveAllLib.Size = new System.Drawing.Size(36, 36);
            this.TSB_SaveAllLib.Text = "toolStripButton1";
            this.TSB_SaveAllLib.ToolTipText = "Save all virtual channels libraries";
            this.TSB_SaveAllLib.Click += new System.EventHandler(this.TSB_SaveAllLibClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_Cut
            // 
            this.TSB_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Cut.Image = global::CANStream.Icones.Cut_32;
            this.TSB_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Cut.Name = "TSB_Cut";
            this.TSB_Cut.Size = new System.Drawing.Size(36, 36);
            this.TSB_Cut.Text = "toolStripButton1";
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
            this.TSB_Copy.Text = "toolStripButton2";
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
            this.TSB_Paste.Text = "toolStripButton3";
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
            this.TSB_Delete.Text = "toolStripButton5";
            this.TSB_Delete.ToolTipText = "Delete";
            this.TSB_Delete.Click += new System.EventHandler(this.TSB_DeleteClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_LoadObjectFile
            // 
            this.TSB_LoadObjectFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_LoadObjectFile.Image = global::CANStream.Icones.Virtual_Channel_Element_32;
            this.TSB_LoadObjectFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_LoadObjectFile.Name = "TSB_LoadObjectFile";
            this.TSB_LoadObjectFile.Size = new System.Drawing.Size(36, 36);
            this.TSB_LoadObjectFile.Text = "TSB_CanConfig";
            this.TSB_LoadObjectFile.ToolTipText = "Load an objects file";
            this.TSB_LoadObjectFile.Click += new System.EventHandler(this.TSB_LoadObjectFileClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.TV_Libraries);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.TabCtrl_PropertiesEdit);
            this.splitContainer1.Size = new System.Drawing.Size(725, 594);
            this.splitContainer1.SplitterDistance = 241;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // TV_Libraries
            // 
            this.TV_Libraries.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TV_Libraries.ContextMenuStrip = this.Context_TVLibraries;
            this.TV_Libraries.ImageIndex = 0;
            this.TV_Libraries.ImageList = this.Img_TVLibraries;
            this.TV_Libraries.Location = new System.Drawing.Point(4, 4);
            this.TV_Libraries.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TV_Libraries.Name = "TV_Libraries";
            this.TV_Libraries.SelectedImageIndex = 0;
            this.TV_Libraries.Size = new System.Drawing.Size(232, 585);
            this.TV_Libraries.TabIndex = 0;
            this.TV_Libraries.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_LibrariesAfterSelect);
            this.TV_Libraries.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TV_LibrariesKeyDown);
            // 
            // Context_TVLibraries
            // 
            this.Context_TVLibraries.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.Context_TVLibraries.Size = new System.Drawing.Size(162, 282);
            // 
            // newLibraryToolStripMenuItem
            // 
            this.newLibraryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.libraryToolStripMenuItem,
            this.virtualChannelToolStripMenuItem});
            this.newLibraryToolStripMenuItem.Image = global::CANStream.Icones.Item_Add_16;
            this.newLibraryToolStripMenuItem.Name = "newLibraryToolStripMenuItem";
            this.newLibraryToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.newLibraryToolStripMenuItem.Text = "New";
            // 
            // libraryToolStripMenuItem
            // 
            this.libraryToolStripMenuItem.Image = global::CANStream.Icones.library_16;
            this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
            this.libraryToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.libraryToolStripMenuItem.Text = "Library";
            this.libraryToolStripMenuItem.Click += new System.EventHandler(this.LibraryToolStripMenuItemClick);
            // 
            // virtualChannelToolStripMenuItem
            // 
            this.virtualChannelToolStripMenuItem.Image = global::CANStream.Icones.Virtual_Channel_16;
            this.virtualChannelToolStripMenuItem.Name = "virtualChannelToolStripMenuItem";
            this.virtualChannelToolStripMenuItem.Size = new System.Drawing.Size(182, 26);
            this.virtualChannelToolStripMenuItem.Text = "Virtual channel";
            this.virtualChannelToolStripMenuItem.Click += new System.EventHandler(this.VirtualChannelToolStripMenuItemClick);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Image = global::CANStream.Icones.File_Open_16;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Image = global::CANStream.Icones.File_Save_16;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
            // 
            // saveAllToolStripMenuItem
            // 
            this.saveAllToolStripMenuItem.Image = global::CANStream.Icones.File_SaveAll_16;
            this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
            this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.saveAllToolStripMenuItem.Text = "Save all";
            this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(158, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::CANStream.Icones.Cut_16;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.CutToolStripMenuItemClick);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::CANStream.Icones.Copy_16;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.CopyToolStripMenuItemClick);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::CANStream.Icones.Paste_16;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.PasteToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(158, 6);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.expandAllToolStripMenuItem.Text = "Expand all";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItemClick);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(161, 26);
            this.collapseAllToolStripMenuItem.Text = "Collapse all";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItemClick);
            // 
            // Img_TVLibraries
            // 
            this.Img_TVLibraries.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_TVLibraries.ImageStream")));
            this.Img_TVLibraries.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_TVLibraries.Images.SetKeyName(0, "library-books-icone-5837-16.png");
            this.Img_TVLibraries.Images.SetKeyName(1, "edu-des-mathematiques-icone-4069-16.png");
            // 
            // TabCtrl_PropertiesEdit
            // 
            this.TabCtrl_PropertiesEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TabCtrl_PropertiesEdit.Controls.Add(this.Tab_LibProperties);
            this.TabCtrl_PropertiesEdit.Controls.Add(this.Tab_ChannelProperties);
            this.TabCtrl_PropertiesEdit.Location = new System.Drawing.Point(4, 4);
            this.TabCtrl_PropertiesEdit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TabCtrl_PropertiesEdit.Name = "TabCtrl_PropertiesEdit";
            this.TabCtrl_PropertiesEdit.SelectedIndex = 0;
            this.TabCtrl_PropertiesEdit.Size = new System.Drawing.Size(471, 586);
            this.TabCtrl_PropertiesEdit.TabIndex = 0;
            // 
            // Tab_LibProperties
            // 
            this.Tab_LibProperties.BackColor = System.Drawing.SystemColors.Control;
            this.Tab_LibProperties.Controls.Add(this.Chk_LibEnabled);
            this.Tab_LibProperties.Controls.Add(this.Cmd_LibCancel);
            this.Tab_LibProperties.Controls.Add(this.Cmd_LibCreate);
            this.Tab_LibProperties.Controls.Add(this.Chk_LibReadOnly);
            this.Tab_LibProperties.Controls.Add(this.rTxt_LibComment);
            this.Tab_LibProperties.Controls.Add(this.label2);
            this.Tab_LibProperties.Controls.Add(this.Txt_LibName);
            this.Tab_LibProperties.Controls.Add(this.label1);
            this.Tab_LibProperties.Location = new System.Drawing.Point(4, 25);
            this.Tab_LibProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab_LibProperties.Name = "Tab_LibProperties";
            this.Tab_LibProperties.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab_LibProperties.Size = new System.Drawing.Size(463, 557);
            this.Tab_LibProperties.TabIndex = 0;
            this.Tab_LibProperties.Text = "Library properties";
            // 
            // Chk_LibEnabled
            // 
            this.Chk_LibEnabled.AutoSize = true;
            this.Chk_LibEnabled.Location = new System.Drawing.Point(12, 226);
            this.Chk_LibEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_LibEnabled.Name = "Chk_LibEnabled";
            this.Chk_LibEnabled.Size = new System.Drawing.Size(82, 21);
            this.Chk_LibEnabled.TabIndex = 17;
            this.Chk_LibEnabled.Text = "Enabled";
            this.Chk_LibEnabled.UseVisualStyleBackColor = true;
            // 
            // Cmd_LibCancel
            // 
            this.Cmd_LibCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_LibCancel.Location = new System.Drawing.Point(243, 329);
            this.Cmd_LibCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_LibCancel.Name = "Cmd_LibCancel";
            this.Cmd_LibCancel.Size = new System.Drawing.Size(100, 28);
            this.Cmd_LibCancel.TabIndex = 16;
            this.Cmd_LibCancel.Text = "Cancel";
            this.Cmd_LibCancel.UseVisualStyleBackColor = true;
            this.Cmd_LibCancel.Click += new System.EventHandler(this.Cmd_LibCancelClick);
            // 
            // Cmd_LibCreate
            // 
            this.Cmd_LibCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_LibCreate.Location = new System.Drawing.Point(353, 329);
            this.Cmd_LibCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_LibCreate.Name = "Cmd_LibCreate";
            this.Cmd_LibCreate.Size = new System.Drawing.Size(100, 28);
            this.Cmd_LibCreate.TabIndex = 15;
            this.Cmd_LibCreate.Text = "Create";
            this.Cmd_LibCreate.UseVisualStyleBackColor = true;
            this.Cmd_LibCreate.Click += new System.EventHandler(this.Cmd_LibCreateClick);
            // 
            // Chk_LibReadOnly
            // 
            this.Chk_LibReadOnly.Location = new System.Drawing.Point(107, 222);
            this.Chk_LibReadOnly.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_LibReadOnly.Name = "Chk_LibReadOnly";
            this.Chk_LibReadOnly.Size = new System.Drawing.Size(139, 30);
            this.Chk_LibReadOnly.TabIndex = 4;
            this.Chk_LibReadOnly.Text = "Read only";
            this.Chk_LibReadOnly.UseVisualStyleBackColor = true;
            // 
            // rTxt_LibComment
            // 
            this.rTxt_LibComment.Location = new System.Drawing.Point(8, 101);
            this.rTxt_LibComment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rTxt_LibComment.Name = "rTxt_LibComment";
            this.rTxt_LibComment.Size = new System.Drawing.Size(443, 117);
            this.rTxt_LibComment.TabIndex = 3;
            this.rTxt_LibComment.Text = "";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(8, 79);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Comment";
            // 
            // Txt_LibName
            // 
            this.Txt_LibName.Location = new System.Drawing.Point(8, 38);
            this.Txt_LibName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_LibName.Name = "Txt_LibName";
            this.Txt_LibName.Size = new System.Drawing.Size(443, 22);
            this.Txt_LibName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Library name";
            // 
            // Tab_ChannelProperties
            // 
            this.Tab_ChannelProperties.BackColor = System.Drawing.SystemColors.Control;
            this.Tab_ChannelProperties.Controls.Add(this.Grp_Alarms);
            this.Tab_ChannelProperties.Controls.Add(this.Cmd_EnumDefinition);
            this.Tab_ChannelProperties.Controls.Add(this.Txt_Decimals);
            this.Tab_ChannelProperties.Controls.Add(this.Lbl_Decimals);
            this.Tab_ChannelProperties.Controls.Add(this.Cmb_ValueFormat);
            this.Tab_ChannelProperties.Controls.Add(this.label21);
            this.Tab_ChannelProperties.Controls.Add(this.label9);
            this.Tab_ChannelProperties.Controls.Add(this.Chk_ChanComputationEnabled);
            this.Tab_ChannelProperties.Controls.Add(this.Txt_ChanValDef);
            this.Tab_ChannelProperties.Controls.Add(this.label8);
            this.Tab_ChannelProperties.Controls.Add(this.Cmd_ChannelTest);
            this.Tab_ChannelProperties.Controls.Add(this.Cmd_ChanCancel);
            this.Tab_ChannelProperties.Controls.Add(this.Cmd_ChanCreate);
            this.Tab_ChannelProperties.Controls.Add(this.Cmd_ChannelList);
            this.Tab_ChannelProperties.Controls.Add(this.Cmd_Functions);
            this.Tab_ChannelProperties.Controls.Add(this.Cmd_Operators);
            this.Tab_ChannelProperties.Controls.Add(this.rTxt_ChanExpression);
            this.Tab_ChannelProperties.Controls.Add(this.label7);
            this.Tab_ChannelProperties.Controls.Add(this.rTxt_ChanComment);
            this.Tab_ChannelProperties.Controls.Add(this.label6);
            this.Tab_ChannelProperties.Controls.Add(this.Txt_ChanUnit);
            this.Tab_ChannelProperties.Controls.Add(this.label4);
            this.Tab_ChannelProperties.Controls.Add(this.Txt_ChanName);
            this.Tab_ChannelProperties.Controls.Add(this.label3);
            this.Tab_ChannelProperties.Location = new System.Drawing.Point(4, 25);
            this.Tab_ChannelProperties.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab_ChannelProperties.Name = "Tab_ChannelProperties";
            this.Tab_ChannelProperties.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Tab_ChannelProperties.Size = new System.Drawing.Size(463, 557);
            this.Tab_ChannelProperties.TabIndex = 1;
            this.Tab_ChannelProperties.Text = "Channel properties";
            // 
            // Grp_Alarms
            // 
            this.Grp_Alarms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMax_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMax_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMin_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMin_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMax_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMax_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Chk_AlarmMax);
            this.Grp_Alarms.Controls.Add(this.Chk_AlarmMin);
            this.Grp_Alarms.Controls.Add(this.Chk_WarningMax);
            this.Grp_Alarms.Controls.Add(this.Txt_AlarmMax);
            this.Grp_Alarms.Controls.Add(this.Txt_AlarmMin);
            this.Grp_Alarms.Controls.Add(this.Txt_WarningMax);
            this.Grp_Alarms.Controls.Add(this.Lbl_Alarms_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMin_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Chk_WarningMin);
            this.Grp_Alarms.Controls.Add(this.Chk_AlarmsEnabled);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMin_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Lbl_Alarms_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Txt_WarningMin);
            this.Grp_Alarms.Location = new System.Drawing.Point(7, 330);
            this.Grp_Alarms.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Grp_Alarms.Name = "Grp_Alarms";
            this.Grp_Alarms.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Grp_Alarms.Size = new System.Drawing.Size(445, 177);
            this.Grp_Alarms.TabIndex = 53;
            this.Grp_Alarms.TabStop = false;
            this.Grp_Alarms.Text = "Warnings and alarms";
            // 
            // Pic_AlarmMax_Forecolor
            // 
            this.Pic_AlarmMax_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMax_Forecolor.Enabled = false;
            this.Pic_AlarmMax_Forecolor.Location = new System.Drawing.Point(359, 144);
            this.Pic_AlarmMax_Forecolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_AlarmMax_Forecolor.Name = "Pic_AlarmMax_Forecolor";
            this.Pic_AlarmMax_Forecolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_AlarmMax_Forecolor.TabIndex = 73;
            this.Pic_AlarmMax_Forecolor.TabStop = false;
            this.Pic_AlarmMax_Forecolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMax_Forecolor_DoubleClick);
            // 
            // Pic_AlarmMax_Backcolor
            // 
            this.Pic_AlarmMax_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMax_Backcolor.Enabled = false;
            this.Pic_AlarmMax_Backcolor.Location = new System.Drawing.Point(275, 144);
            this.Pic_AlarmMax_Backcolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_AlarmMax_Backcolor.Name = "Pic_AlarmMax_Backcolor";
            this.Pic_AlarmMax_Backcolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_AlarmMax_Backcolor.TabIndex = 72;
            this.Pic_AlarmMax_Backcolor.TabStop = false;
            this.Pic_AlarmMax_Backcolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMax_Backcolor_DoubleClick);
            // 
            // Pic_AlarmMin_Forecolor
            // 
            this.Pic_AlarmMin_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMin_Forecolor.Enabled = false;
            this.Pic_AlarmMin_Forecolor.Location = new System.Drawing.Point(359, 48);
            this.Pic_AlarmMin_Forecolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_AlarmMin_Forecolor.Name = "Pic_AlarmMin_Forecolor";
            this.Pic_AlarmMin_Forecolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_AlarmMin_Forecolor.TabIndex = 71;
            this.Pic_AlarmMin_Forecolor.TabStop = false;
            this.Pic_AlarmMin_Forecolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMin_Forecolor_DoubleClick);
            // 
            // Pic_AlarmMin_Backcolor
            // 
            this.Pic_AlarmMin_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMin_Backcolor.Enabled = false;
            this.Pic_AlarmMin_Backcolor.Location = new System.Drawing.Point(275, 48);
            this.Pic_AlarmMin_Backcolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_AlarmMin_Backcolor.Name = "Pic_AlarmMin_Backcolor";
            this.Pic_AlarmMin_Backcolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_AlarmMin_Backcolor.TabIndex = 70;
            this.Pic_AlarmMin_Backcolor.TabStop = false;
            this.Pic_AlarmMin_Backcolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMin_Backcolor_DoubleClick);
            // 
            // Pic_WarningMax_Forecolor
            // 
            this.Pic_WarningMax_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMax_Forecolor.Enabled = false;
            this.Pic_WarningMax_Forecolor.Location = new System.Drawing.Point(359, 111);
            this.Pic_WarningMax_Forecolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_WarningMax_Forecolor.Name = "Pic_WarningMax_Forecolor";
            this.Pic_WarningMax_Forecolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_WarningMax_Forecolor.TabIndex = 69;
            this.Pic_WarningMax_Forecolor.TabStop = false;
            this.Pic_WarningMax_Forecolor.DoubleClick += new System.EventHandler(this.Pic_WarningMax_Forecolor_DoubleClick);
            // 
            // Pic_WarningMax_Backcolor
            // 
            this.Pic_WarningMax_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMax_Backcolor.Enabled = false;
            this.Pic_WarningMax_Backcolor.Location = new System.Drawing.Point(275, 111);
            this.Pic_WarningMax_Backcolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_WarningMax_Backcolor.Name = "Pic_WarningMax_Backcolor";
            this.Pic_WarningMax_Backcolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_WarningMax_Backcolor.TabIndex = 68;
            this.Pic_WarningMax_Backcolor.TabStop = false;
            this.Pic_WarningMax_Backcolor.DoubleClick += new System.EventHandler(this.Pic_WarningMax_Backcolor_DoubleClick);
            // 
            // Chk_AlarmMax
            // 
            this.Chk_AlarmMax.AutoSize = true;
            this.Chk_AlarmMax.Enabled = false;
            this.Chk_AlarmMax.Location = new System.Drawing.Point(17, 148);
            this.Chk_AlarmMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_AlarmMax.Name = "Chk_AlarmMax";
            this.Chk_AlarmMax.Size = new System.Drawing.Size(123, 21);
            this.Chk_AlarmMax.TabIndex = 41;
            this.Chk_AlarmMax.Text = "Alarm limit max";
            this.Chk_AlarmMax.UseVisualStyleBackColor = true;
            this.Chk_AlarmMax.CheckedChanged += new System.EventHandler(this.Chk_AlarmMax_CheckedChanged);
            // 
            // Chk_AlarmMin
            // 
            this.Chk_AlarmMin.AutoSize = true;
            this.Chk_AlarmMin.Enabled = false;
            this.Chk_AlarmMin.Location = new System.Drawing.Point(17, 50);
            this.Chk_AlarmMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_AlarmMin.Name = "Chk_AlarmMin";
            this.Chk_AlarmMin.Size = new System.Drawing.Size(120, 21);
            this.Chk_AlarmMin.TabIndex = 35;
            this.Chk_AlarmMin.Text = "Alarm limit min";
            this.Chk_AlarmMin.UseVisualStyleBackColor = true;
            this.Chk_AlarmMin.CheckedChanged += new System.EventHandler(this.Chk_AlarmMin_CheckedChanged);
            // 
            // Chk_WarningMax
            // 
            this.Chk_WarningMax.AutoSize = true;
            this.Chk_WarningMax.Enabled = false;
            this.Chk_WarningMax.Location = new System.Drawing.Point(17, 113);
            this.Chk_WarningMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_WarningMax.Name = "Chk_WarningMax";
            this.Chk_WarningMax.Size = new System.Drawing.Size(140, 21);
            this.Chk_WarningMax.TabIndex = 39;
            this.Chk_WarningMax.Text = "Warning limit max";
            this.Chk_WarningMax.UseVisualStyleBackColor = true;
            this.Chk_WarningMax.CheckedChanged += new System.EventHandler(this.Chk_WarningMax_CheckedChanged);
            // 
            // Txt_AlarmMax
            // 
            this.Txt_AlarmMax.Enabled = false;
            this.Txt_AlarmMax.Location = new System.Drawing.Point(165, 144);
            this.Txt_AlarmMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_AlarmMax.Name = "Txt_AlarmMax";
            this.Txt_AlarmMax.Size = new System.Drawing.Size(100, 22);
            this.Txt_AlarmMax.TabIndex = 42;
            // 
            // Txt_AlarmMin
            // 
            this.Txt_AlarmMin.Enabled = false;
            this.Txt_AlarmMin.Location = new System.Drawing.Point(165, 48);
            this.Txt_AlarmMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_AlarmMin.Name = "Txt_AlarmMin";
            this.Txt_AlarmMin.Size = new System.Drawing.Size(100, 22);
            this.Txt_AlarmMin.TabIndex = 36;
            // 
            // Txt_WarningMax
            // 
            this.Txt_WarningMax.Enabled = false;
            this.Txt_WarningMax.Location = new System.Drawing.Point(165, 111);
            this.Txt_WarningMax.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_WarningMax.Name = "Txt_WarningMax";
            this.Txt_WarningMax.Size = new System.Drawing.Size(100, 22);
            this.Txt_WarningMax.TabIndex = 40;
            // 
            // Lbl_Alarms_Forecolor
            // 
            this.Lbl_Alarms_Forecolor.Enabled = false;
            this.Lbl_Alarms_Forecolor.Location = new System.Drawing.Point(359, 23);
            this.Lbl_Alarms_Forecolor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Alarms_Forecolor.Name = "Lbl_Alarms_Forecolor";
            this.Lbl_Alarms_Forecolor.Size = new System.Drawing.Size(73, 16);
            this.Lbl_Alarms_Forecolor.TabIndex = 61;
            this.Lbl_Alarms_Forecolor.Text = "Forecolor";
            this.Lbl_Alarms_Forecolor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Pic_WarningMin_Forecolor
            // 
            this.Pic_WarningMin_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMin_Forecolor.Enabled = false;
            this.Pic_WarningMin_Forecolor.Location = new System.Drawing.Point(359, 80);
            this.Pic_WarningMin_Forecolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_WarningMin_Forecolor.Name = "Pic_WarningMin_Forecolor";
            this.Pic_WarningMin_Forecolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_WarningMin_Forecolor.TabIndex = 60;
            this.Pic_WarningMin_Forecolor.TabStop = false;
            this.Pic_WarningMin_Forecolor.DoubleClick += new System.EventHandler(this.Pic_WarningMin_Forecolor_DoubleClick);
            // 
            // Chk_WarningMin
            // 
            this.Chk_WarningMin.AutoSize = true;
            this.Chk_WarningMin.Enabled = false;
            this.Chk_WarningMin.Location = new System.Drawing.Point(17, 82);
            this.Chk_WarningMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_WarningMin.Name = "Chk_WarningMin";
            this.Chk_WarningMin.Size = new System.Drawing.Size(137, 21);
            this.Chk_WarningMin.TabIndex = 37;
            this.Chk_WarningMin.Text = "Warning limit min";
            this.Chk_WarningMin.UseVisualStyleBackColor = true;
            this.Chk_WarningMin.CheckedChanged += new System.EventHandler(this.Chk_WarningMin_CheckedChanged);
            // 
            // Chk_AlarmsEnabled
            // 
            this.Chk_AlarmsEnabled.AutoSize = true;
            this.Chk_AlarmsEnabled.Location = new System.Drawing.Point(8, 23);
            this.Chk_AlarmsEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_AlarmsEnabled.Name = "Chk_AlarmsEnabled";
            this.Chk_AlarmsEnabled.Size = new System.Drawing.Size(208, 21);
            this.Chk_AlarmsEnabled.TabIndex = 34;
            this.Chk_AlarmsEnabled.Text = "Enable warnings and alarms";
            this.Chk_AlarmsEnabled.UseVisualStyleBackColor = true;
            this.Chk_AlarmsEnabled.CheckedChanged += new System.EventHandler(this.Chk_AlarmsEnabled_CheckedChanged);
            // 
            // Pic_WarningMin_Backcolor
            // 
            this.Pic_WarningMin_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMin_Backcolor.Enabled = false;
            this.Pic_WarningMin_Backcolor.Location = new System.Drawing.Point(275, 80);
            this.Pic_WarningMin_Backcolor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Pic_WarningMin_Backcolor.Name = "Pic_WarningMin_Backcolor";
            this.Pic_WarningMin_Backcolor.Size = new System.Drawing.Size(73, 24);
            this.Pic_WarningMin_Backcolor.TabIndex = 52;
            this.Pic_WarningMin_Backcolor.TabStop = false;
            this.Pic_WarningMin_Backcolor.DoubleClick += new System.EventHandler(this.Pic_WarningMin_Backcolor_DoubleClick);
            // 
            // Lbl_Alarms_Backcolor
            // 
            this.Lbl_Alarms_Backcolor.Enabled = false;
            this.Lbl_Alarms_Backcolor.Location = new System.Drawing.Point(273, 23);
            this.Lbl_Alarms_Backcolor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Alarms_Backcolor.Name = "Lbl_Alarms_Backcolor";
            this.Lbl_Alarms_Backcolor.Size = new System.Drawing.Size(73, 16);
            this.Lbl_Alarms_Backcolor.TabIndex = 50;
            this.Lbl_Alarms_Backcolor.Text = "Backcolor";
            this.Lbl_Alarms_Backcolor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Txt_WarningMin
            // 
            this.Txt_WarningMin.Enabled = false;
            this.Txt_WarningMin.Location = new System.Drawing.Point(165, 80);
            this.Txt_WarningMin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_WarningMin.Name = "Txt_WarningMin";
            this.Txt_WarningMin.Size = new System.Drawing.Size(100, 22);
            this.Txt_WarningMin.TabIndex = 38;
            // 
            // Cmd_EnumDefinition
            // 
            this.Cmd_EnumDefinition.Enabled = false;
            this.Cmd_EnumDefinition.Image = global::CANStream.Icones.Enumeration_Edit_16;
            this.Cmd_EnumDefinition.Location = new System.Drawing.Point(419, 108);
            this.Cmd_EnumDefinition.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_EnumDefinition.Name = "Cmd_EnumDefinition";
            this.Cmd_EnumDefinition.Size = new System.Drawing.Size(33, 31);
            this.Cmd_EnumDefinition.TabIndex = 50;
            this.Cmd_EnumDefinition.UseVisualStyleBackColor = true;
            this.Cmd_EnumDefinition.Click += new System.EventHandler(this.Cmd_EnumDefinition_Click);
            // 
            // Txt_Decimals
            // 
            this.Txt_Decimals.Enabled = false;
            this.Txt_Decimals.Location = new System.Drawing.Point(351, 108);
            this.Txt_Decimals.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_Decimals.Name = "Txt_Decimals";
            this.Txt_Decimals.Size = new System.Drawing.Size(59, 22);
            this.Txt_Decimals.TabIndex = 49;
            // 
            // Lbl_Decimals
            // 
            this.Lbl_Decimals.AutoSize = true;
            this.Lbl_Decimals.Enabled = false;
            this.Lbl_Decimals.Location = new System.Drawing.Point(276, 112);
            this.Lbl_Decimals.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_Decimals.Name = "Lbl_Decimals";
            this.Lbl_Decimals.Size = new System.Drawing.Size(65, 17);
            this.Lbl_Decimals.TabIndex = 52;
            this.Lbl_Decimals.Text = "Decimals";
            // 
            // Cmb_ValueFormat
            // 
            this.Cmb_ValueFormat.FormattingEnabled = true;
            this.Cmb_ValueFormat.Items.AddRange(new object[] {
            "MSBFirst",
            "LSBFirst"});
            this.Cmb_ValueFormat.Location = new System.Drawing.Point(104, 108);
            this.Cmb_ValueFormat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmb_ValueFormat.Name = "Cmb_ValueFormat";
            this.Cmb_ValueFormat.Size = new System.Drawing.Size(155, 24);
            this.Cmb_ValueFormat.TabIndex = 48;
            this.Cmb_ValueFormat.SelectedValueChanged += new System.EventHandler(this.Cmb_ValueFormat_SelectedValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(7, 113);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(52, 17);
            this.label21.TabIndex = 51;
            this.label21.Text = "Format";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(193, 81);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 22);
            this.label9.TabIndex = 19;
            this.label9.Text = "(For CAN Tx)";
            // 
            // Chk_ChanComputationEnabled
            // 
            this.Chk_ChanComputationEnabled.Location = new System.Drawing.Point(365, 42);
            this.Chk_ChanComputationEnabled.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Chk_ChanComputationEnabled.Name = "Chk_ChanComputationEnabled";
            this.Chk_ChanComputationEnabled.Size = new System.Drawing.Size(88, 30);
            this.Chk_ChanComputationEnabled.TabIndex = 18;
            this.Chk_ChanComputationEnabled.Text = "Enabled";
            this.Chk_ChanComputationEnabled.UseVisualStyleBackColor = true;
            // 
            // Txt_ChanValDef
            // 
            this.Txt_ChanValDef.Location = new System.Drawing.Point(104, 78);
            this.Txt_ChanValDef.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_ChanValDef.Name = "Txt_ChanValDef";
            this.Txt_ChanValDef.Size = new System.Drawing.Size(80, 22);
            this.Txt_ChanValDef.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(8, 81);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 22);
            this.label8.TabIndex = 16;
            this.label8.Text = "Default value:";
            // 
            // Cmd_ChannelTest
            // 
            this.Cmd_ChannelTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Cmd_ChannelTest.Location = new System.Drawing.Point(8, 522);
            this.Cmd_ChannelTest.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_ChannelTest.Name = "Cmd_ChannelTest";
            this.Cmd_ChannelTest.Size = new System.Drawing.Size(100, 28);
            this.Cmd_ChannelTest.TabIndex = 15;
            this.Cmd_ChannelTest.Text = "Test";
            this.Cmd_ChannelTest.UseVisualStyleBackColor = true;
            this.Cmd_ChannelTest.Click += new System.EventHandler(this.Cmd_ChannelTestClick);
            // 
            // Cmd_ChanCancel
            // 
            this.Cmd_ChanCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_ChanCancel.Location = new System.Drawing.Point(243, 522);
            this.Cmd_ChanCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_ChanCancel.Name = "Cmd_ChanCancel";
            this.Cmd_ChanCancel.Size = new System.Drawing.Size(100, 28);
            this.Cmd_ChanCancel.TabIndex = 14;
            this.Cmd_ChanCancel.Text = "Cancel";
            this.Cmd_ChanCancel.UseVisualStyleBackColor = true;
            this.Cmd_ChanCancel.Click += new System.EventHandler(this.Cmd_ChanCancelClick);
            // 
            // Cmd_ChanCreate
            // 
            this.Cmd_ChanCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_ChanCreate.Location = new System.Drawing.Point(353, 522);
            this.Cmd_ChanCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_ChanCreate.Name = "Cmd_ChanCreate";
            this.Cmd_ChanCreate.Size = new System.Drawing.Size(100, 28);
            this.Cmd_ChanCreate.TabIndex = 13;
            this.Cmd_ChanCreate.Text = "Create";
            this.Cmd_ChanCreate.UseVisualStyleBackColor = true;
            this.Cmd_ChanCreate.Click += new System.EventHandler(this.Cmd_ChanCreateClick);
            // 
            // Cmd_ChannelList
            // 
            this.Cmd_ChannelList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_ChannelList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmd_ChannelList.Image = global::CANStream.Icones.Virtual_Channel_Element_16;
            this.Cmd_ChannelList.Location = new System.Drawing.Point(364, 296);
            this.Cmd_ChannelList.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_ChannelList.Name = "Cmd_ChannelList";
            this.Cmd_ChannelList.Size = new System.Drawing.Size(29, 27);
            this.Cmd_ChannelList.TabIndex = 12;
            this.Cmd_ChannelList.UseVisualStyleBackColor = true;
            this.Cmd_ChannelList.Click += new System.EventHandler(this.Cmd_ChannelListClick);
            // 
            // Cmd_Functions
            // 
            this.Cmd_Functions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Functions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmd_Functions.Image = global::CANStream.Icones.Virtual_Channel_Function_16;
            this.Cmd_Functions.Location = new System.Drawing.Point(393, 296);
            this.Cmd_Functions.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_Functions.Name = "Cmd_Functions";
            this.Cmd_Functions.Size = new System.Drawing.Size(29, 27);
            this.Cmd_Functions.TabIndex = 11;
            this.Cmd_Functions.UseVisualStyleBackColor = true;
            this.Cmd_Functions.Click += new System.EventHandler(this.Cmd_FunctionsClick);
            // 
            // Cmd_Operators
            // 
            this.Cmd_Operators.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Operators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cmd_Operators.Image = global::CANStream.Icones.Virtual_Channel_Operator_16;
            this.Cmd_Operators.Location = new System.Drawing.Point(423, 296);
            this.Cmd_Operators.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Cmd_Operators.Name = "Cmd_Operators";
            this.Cmd_Operators.Size = new System.Drawing.Size(29, 27);
            this.Cmd_Operators.TabIndex = 10;
            this.Cmd_Operators.UseVisualStyleBackColor = true;
            this.Cmd_Operators.Click += new System.EventHandler(this.Cmd_OperatorsClick);
            // 
            // rTxt_ChanExpression
            // 
            this.rTxt_ChanExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxt_ChanExpression.Location = new System.Drawing.Point(7, 230);
            this.rTxt_ChanExpression.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rTxt_ChanExpression.Name = "rTxt_ChanExpression";
            this.rTxt_ChanExpression.Size = new System.Drawing.Size(444, 63);
            this.rTxt_ChanExpression.TabIndex = 9;
            this.rTxt_ChanExpression.Text = "";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(7, 204);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(84, 22);
            this.label7.TabIndex = 8;
            this.label7.Text = "Expression";
            // 
            // rTxt_ChanComment
            // 
            this.rTxt_ChanComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxt_ChanComment.Location = new System.Drawing.Point(104, 144);
            this.rTxt_ChanComment.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rTxt_ChanComment.Name = "rTxt_ChanComment";
            this.rTxt_ChanComment.Size = new System.Drawing.Size(347, 56);
            this.rTxt_ChanComment.TabIndex = 7;
            this.rTxt_ChanComment.Text = "";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(3, 144);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 22);
            this.label6.TabIndex = 6;
            this.label6.Text = "Comment:";
            // 
            // Txt_ChanUnit
            // 
            this.Txt_ChanUnit.Location = new System.Drawing.Point(104, 44);
            this.Txt_ChanUnit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_ChanUnit.Name = "Txt_ChanUnit";
            this.Txt_ChanUnit.Size = new System.Drawing.Size(80, 22);
            this.Txt_ChanUnit.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(8, 49);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 22);
            this.label4.TabIndex = 2;
            this.label4.Text = "Unit:";
            // 
            // Txt_ChanName
            // 
            this.Txt_ChanName.Location = new System.Drawing.Point(104, 14);
            this.Txt_ChanName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Txt_ChanName.Name = "Txt_ChanName";
            this.Txt_ChanName.Size = new System.Drawing.Size(347, 22);
            this.Txt_ChanName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(8, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 22);
            this.label3.TabIndex = 0;
            this.label3.Text = "Name:";
            // 
            // Frm_VirtualChannel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 633);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = global::CANStream.Icones.CANStream_Icone;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(741, 499);
            this.Name = "Frm_VirtualChannel";
            this.Text = "Virtual channels editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_VirtualChannelFormClosing);
            this.Load += new System.EventHandler(this.Frm_VirtualChannelLoad);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Context_TVLibraries.ResumeLayout(false);
            this.TabCtrl_PropertiesEdit.ResumeLayout(false);
            this.Tab_LibProperties.ResumeLayout(false);
            this.Tab_LibProperties.PerformLayout();
            this.Tab_ChannelProperties.ResumeLayout(false);
            this.Tab_ChannelProperties.PerformLayout();
            this.Grp_Alarms.ResumeLayout(false);
            this.Grp_Alarms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Backcolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Backcolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Backcolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Backcolor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox Txt_ChanValDef;
		private System.Windows.Forms.CheckBox Chk_ChanComputationEnabled;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ToolStripButton TSB_LoadObjectFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
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
		private System.Windows.Forms.ToolStripButton TSB_SaveAllLib;
		private System.Windows.Forms.SaveFileDialog Dlg_SaveFile;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenFile;
		private System.Windows.Forms.ImageList Img_TVLibraries;
		private System.Windows.Forms.ToolStripButton TSB_Paste;
		private System.Windows.Forms.ToolStripButton TSB_Copy;
		private System.Windows.Forms.ToolStripButton TSB_Cut;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton TSB_NewLibrary;
		private System.Windows.Forms.ToolTip ToolTip_CmdOperators;
		private System.Windows.Forms.ToolTip ToolTip_CmdFunctions;
		private System.Windows.Forms.ToolStripButton TSB_NewChannel;
		private System.Windows.Forms.ToolStripButton TSB_Delete;
		private System.Windows.Forms.ToolStripSeparator toolStripButton4;
		private System.Windows.Forms.ToolStripButton TSB_SaveLib;
		private System.Windows.Forms.ToolTip ToolTip_CmdChannelList;
		private System.Windows.Forms.Button Cmd_LibCreate;
		private System.Windows.Forms.Button Cmd_LibCancel;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox Txt_ChanUnit;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.RichTextBox rTxt_ChanComment;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.RichTextBox rTxt_ChanExpression;
		private System.Windows.Forms.Button Cmd_Operators;
		private System.Windows.Forms.Button Cmd_Functions;
		private System.Windows.Forms.Button Cmd_ChannelList;
		private System.Windows.Forms.Button Cmd_ChanCreate;
		private System.Windows.Forms.Button Cmd_ChanCancel;
		private System.Windows.Forms.Button Cmd_ChannelTest;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Txt_ChanName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Txt_LibName;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RichTextBox rTxt_LibComment;
		private System.Windows.Forms.CheckBox Chk_LibReadOnly;
		private System.Windows.Forms.TabPage Tab_ChannelProperties;
		private System.Windows.Forms.TabPage Tab_LibProperties;
		private System.Windows.Forms.TabControl TabCtrl_PropertiesEdit;
		private System.Windows.Forms.TreeView TV_Libraries;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripButton TSB_OpenLib;
		private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.CheckBox Chk_LibEnabled;
        private System.Windows.Forms.Button Cmd_EnumDefinition;
        private System.Windows.Forms.TextBox Txt_Decimals;
        private System.Windows.Forms.Label Lbl_Decimals;
        private System.Windows.Forms.ComboBox Cmb_ValueFormat;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox Grp_Alarms;
        private System.Windows.Forms.PictureBox Pic_AlarmMax_Forecolor;
        private System.Windows.Forms.PictureBox Pic_AlarmMax_Backcolor;
        private System.Windows.Forms.PictureBox Pic_AlarmMin_Forecolor;
        private System.Windows.Forms.PictureBox Pic_AlarmMin_Backcolor;
        private System.Windows.Forms.PictureBox Pic_WarningMax_Forecolor;
        private System.Windows.Forms.PictureBox Pic_WarningMax_Backcolor;
        private System.Windows.Forms.CheckBox Chk_AlarmMax;
        private System.Windows.Forms.CheckBox Chk_AlarmMin;
        private System.Windows.Forms.CheckBox Chk_WarningMax;
        private System.Windows.Forms.TextBox Txt_AlarmMax;
        private System.Windows.Forms.TextBox Txt_AlarmMin;
        private System.Windows.Forms.TextBox Txt_WarningMax;
        private System.Windows.Forms.Label Lbl_Alarms_Forecolor;
        private System.Windows.Forms.PictureBox Pic_WarningMin_Forecolor;
        private System.Windows.Forms.CheckBox Chk_WarningMin;
        private System.Windows.Forms.CheckBox Chk_AlarmsEnabled;
        private System.Windows.Forms.PictureBox Pic_WarningMin_Backcolor;
        private System.Windows.Forms.Label Lbl_Alarms_Backcolor;
        private System.Windows.Forms.TextBox Txt_WarningMin;
        private System.Windows.Forms.ColorDialog Dlg_SelectColor;
    }
}
