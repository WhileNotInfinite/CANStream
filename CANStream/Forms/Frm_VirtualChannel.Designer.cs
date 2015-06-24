/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 1/29/2014
 * Time: 11:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
			this.Cmd_LibCancel = new System.Windows.Forms.Button();
			this.Cmd_LibCreate = new System.Windows.Forms.Button();
			this.Chk_LibReadOnly = new System.Windows.Forms.CheckBox();
			this.rTxt_LibComment = new System.Windows.Forms.RichTextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Txt_LibName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.Tab_ChannelProperties = new System.Windows.Forms.TabPage();
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
			this.Txt_ChanDecimal = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.Txt_ChanUnit = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.Txt_ChanName = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.ToolTip_CmdChannelList = new System.Windows.Forms.ToolTip(this.components);
			this.ToolTip_CmdFunctions = new System.Windows.Forms.ToolTip(this.components);
			this.ToolTip_CmdOperators = new System.Windows.Forms.ToolTip(this.components);
			this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.Context_TVLibraries.SuspendLayout();
			this.TabCtrl_PropertiesEdit.SuspendLayout();
			this.Tab_LibProperties.SuspendLayout();
			this.Tab_ChannelProperties.SuspendLayout();
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
			this.toolStrip1.Size = new System.Drawing.Size(544, 39);
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
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.TV_Libraries);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.TabCtrl_PropertiesEdit);
			this.splitContainer1.Size = new System.Drawing.Size(544, 337);
			this.splitContainer1.SplitterDistance = 181;
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
			this.TV_Libraries.Location = new System.Drawing.Point(3, 3);
			this.TV_Libraries.Name = "TV_Libraries";
			this.TV_Libraries.SelectedImageIndex = 0;
			this.TV_Libraries.Size = new System.Drawing.Size(175, 331);
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
			this.newLibraryToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.newLibraryToolStripMenuItem.Text = "New";
			// 
			// libraryToolStripMenuItem
			// 
			this.libraryToolStripMenuItem.Image = global::CANStream.Icones.library_16;
			this.libraryToolStripMenuItem.Name = "libraryToolStripMenuItem";
			this.libraryToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.libraryToolStripMenuItem.Text = "Library";
			this.libraryToolStripMenuItem.Click += new System.EventHandler(this.LibraryToolStripMenuItemClick);
			// 
			// virtualChannelToolStripMenuItem
			// 
			this.virtualChannelToolStripMenuItem.Image = global::CANStream.Icones.Virtual_Channel_16;
			this.virtualChannelToolStripMenuItem.Name = "virtualChannelToolStripMenuItem";
			this.virtualChannelToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
			this.virtualChannelToolStripMenuItem.Text = "Virtual channel";
			this.virtualChannelToolStripMenuItem.Click += new System.EventHandler(this.VirtualChannelToolStripMenuItemClick);
			// 
			// openToolStripMenuItem
			// 
			this.openToolStripMenuItem.Image = global::CANStream.Icones.File_Open_16;
			this.openToolStripMenuItem.Name = "openToolStripMenuItem";
			this.openToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.openToolStripMenuItem.Text = "Open";
			this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
			// 
			// saveToolStripMenuItem
			// 
			this.saveToolStripMenuItem.Image = global::CANStream.Icones.File_Save_16;
			this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
			this.saveToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.saveToolStripMenuItem.Text = "Save";
			this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItemClick);
			// 
			// saveAllToolStripMenuItem
			// 
			this.saveAllToolStripMenuItem.Image = global::CANStream.Icones.File_SaveAll_16;
			this.saveAllToolStripMenuItem.Name = "saveAllToolStripMenuItem";
			this.saveAllToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.saveAllToolStripMenuItem.Text = "Save all";
			this.saveAllToolStripMenuItem.Click += new System.EventHandler(this.SaveAllToolStripMenuItemClick);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(131, 6);
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
			this.toolStripMenuItem2.Size = new System.Drawing.Size(131, 6);
			// 
			// deleteToolStripMenuItem
			// 
			this.deleteToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
			this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
			this.deleteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.deleteToolStripMenuItem.Text = "Delete";
			this.deleteToolStripMenuItem.Click += new System.EventHandler(this.DeleteToolStripMenuItemClick);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(131, 6);
			// 
			// expandAllToolStripMenuItem
			// 
			this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
			this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.expandAllToolStripMenuItem.Text = "Expand all";
			this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItemClick);
			// 
			// collapseAllToolStripMenuItem
			// 
			this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
			this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
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
			this.TabCtrl_PropertiesEdit.Location = new System.Drawing.Point(3, 3);
			this.TabCtrl_PropertiesEdit.Name = "TabCtrl_PropertiesEdit";
			this.TabCtrl_PropertiesEdit.SelectedIndex = 0;
			this.TabCtrl_PropertiesEdit.Size = new System.Drawing.Size(353, 331);
			this.TabCtrl_PropertiesEdit.TabIndex = 0;
			// 
			// Tab_LibProperties
			// 
			this.Tab_LibProperties.BackColor = System.Drawing.SystemColors.Control;
			this.Tab_LibProperties.Controls.Add(this.Cmd_LibCancel);
			this.Tab_LibProperties.Controls.Add(this.Cmd_LibCreate);
			this.Tab_LibProperties.Controls.Add(this.Chk_LibReadOnly);
			this.Tab_LibProperties.Controls.Add(this.rTxt_LibComment);
			this.Tab_LibProperties.Controls.Add(this.label2);
			this.Tab_LibProperties.Controls.Add(this.Txt_LibName);
			this.Tab_LibProperties.Controls.Add(this.label1);
			this.Tab_LibProperties.Location = new System.Drawing.Point(4, 22);
			this.Tab_LibProperties.Name = "Tab_LibProperties";
			this.Tab_LibProperties.Padding = new System.Windows.Forms.Padding(3);
			this.Tab_LibProperties.Size = new System.Drawing.Size(345, 305);
			this.Tab_LibProperties.TabIndex = 0;
			this.Tab_LibProperties.Text = "Library properties";
			// 
			// Cmd_LibCancel
			// 
			this.Cmd_LibCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_LibCancel.Location = new System.Drawing.Point(182, 260);
			this.Cmd_LibCancel.Name = "Cmd_LibCancel";
			this.Cmd_LibCancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_LibCancel.TabIndex = 16;
			this.Cmd_LibCancel.Text = "Cancel";
			this.Cmd_LibCancel.UseVisualStyleBackColor = true;
			this.Cmd_LibCancel.Click += new System.EventHandler(this.Cmd_LibCancelClick);
			// 
			// Cmd_LibCreate
			// 
			this.Cmd_LibCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_LibCreate.Location = new System.Drawing.Point(265, 260);
			this.Cmd_LibCreate.Name = "Cmd_LibCreate";
			this.Cmd_LibCreate.Size = new System.Drawing.Size(75, 23);
			this.Cmd_LibCreate.TabIndex = 15;
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
			this.rTxt_LibComment.Location = new System.Drawing.Point(6, 81);
			this.rTxt_LibComment.Name = "rTxt_LibComment";
			this.rTxt_LibComment.Size = new System.Drawing.Size(333, 96);
			this.rTxt_LibComment.TabIndex = 3;
			this.rTxt_LibComment.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(6, 63);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "Comment";
			// 
			// Txt_LibName
			// 
			this.Txt_LibName.Location = new System.Drawing.Point(6, 31);
			this.Txt_LibName.Name = "Txt_LibName";
			this.Txt_LibName.Size = new System.Drawing.Size(333, 20);
			this.Txt_LibName.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(6, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Library name";
			// 
			// Tab_ChannelProperties
			// 
			this.Tab_ChannelProperties.BackColor = System.Drawing.SystemColors.Control;
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
			this.Tab_ChannelProperties.Controls.Add(this.Txt_ChanDecimal);
			this.Tab_ChannelProperties.Controls.Add(this.label5);
			this.Tab_ChannelProperties.Controls.Add(this.Txt_ChanUnit);
			this.Tab_ChannelProperties.Controls.Add(this.label4);
			this.Tab_ChannelProperties.Controls.Add(this.Txt_ChanName);
			this.Tab_ChannelProperties.Controls.Add(this.label3);
			this.Tab_ChannelProperties.Location = new System.Drawing.Point(4, 22);
			this.Tab_ChannelProperties.Name = "Tab_ChannelProperties";
			this.Tab_ChannelProperties.Padding = new System.Windows.Forms.Padding(3);
			this.Tab_ChannelProperties.Size = new System.Drawing.Size(345, 305);
			this.Tab_ChannelProperties.TabIndex = 1;
			this.Tab_ChannelProperties.Text = "Channel properties";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(145, 66);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(75, 18);
			this.label9.TabIndex = 19;
			this.label9.Text = "(For CAN Tx)";
			// 
			// Chk_ChanComputationEnabled
			// 
			this.Chk_ChanComputationEnabled.Location = new System.Drawing.Point(274, 34);
			this.Chk_ChanComputationEnabled.Name = "Chk_ChanComputationEnabled";
			this.Chk_ChanComputationEnabled.Size = new System.Drawing.Size(66, 24);
			this.Chk_ChanComputationEnabled.TabIndex = 18;
			this.Chk_ChanComputationEnabled.Text = "Enabled";
			this.Chk_ChanComputationEnabled.UseVisualStyleBackColor = true;
			// 
			// Txt_ChanValDef
			// 
			this.Txt_ChanValDef.Location = new System.Drawing.Point(78, 63);
			this.Txt_ChanValDef.Name = "Txt_ChanValDef";
			this.Txt_ChanValDef.Size = new System.Drawing.Size(61, 20);
			this.Txt_ChanValDef.TabIndex = 17;
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(6, 66);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(75, 18);
			this.label8.TabIndex = 16;
			this.label8.Text = "Default value:";
			// 
			// Cmd_ChannelTest
			// 
			this.Cmd_ChannelTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.Cmd_ChannelTest.Location = new System.Drawing.Point(6, 279);
			this.Cmd_ChannelTest.Name = "Cmd_ChannelTest";
			this.Cmd_ChannelTest.Size = new System.Drawing.Size(75, 23);
			this.Cmd_ChannelTest.TabIndex = 15;
			this.Cmd_ChannelTest.Text = "Test";
			this.Cmd_ChannelTest.UseVisualStyleBackColor = true;
			this.Cmd_ChannelTest.Click += new System.EventHandler(this.Cmd_ChannelTestClick);
			// 
			// Cmd_ChanCancel
			// 
			this.Cmd_ChanCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_ChanCancel.Location = new System.Drawing.Point(182, 279);
			this.Cmd_ChanCancel.Name = "Cmd_ChanCancel";
			this.Cmd_ChanCancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_ChanCancel.TabIndex = 14;
			this.Cmd_ChanCancel.Text = "Cancel";
			this.Cmd_ChanCancel.UseVisualStyleBackColor = true;
			this.Cmd_ChanCancel.Click += new System.EventHandler(this.Cmd_ChanCancelClick);
			// 
			// Cmd_ChanCreate
			// 
			this.Cmd_ChanCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_ChanCreate.Location = new System.Drawing.Point(265, 279);
			this.Cmd_ChanCreate.Name = "Cmd_ChanCreate";
			this.Cmd_ChanCreate.Size = new System.Drawing.Size(75, 23);
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
			this.Cmd_ChannelList.Location = new System.Drawing.Point(273, 238);
			this.Cmd_ChannelList.Name = "Cmd_ChannelList";
			this.Cmd_ChannelList.Size = new System.Drawing.Size(22, 22);
			this.Cmd_ChannelList.TabIndex = 12;
			this.Cmd_ChannelList.UseVisualStyleBackColor = true;
			this.Cmd_ChannelList.Click += new System.EventHandler(this.Cmd_ChannelListClick);
			// 
			// Cmd_Functions
			// 
			this.Cmd_Functions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_Functions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Cmd_Functions.Image = global::CANStream.Icones.Virtual_Channel_Function_16;
			this.Cmd_Functions.Location = new System.Drawing.Point(295, 238);
			this.Cmd_Functions.Name = "Cmd_Functions";
			this.Cmd_Functions.Size = new System.Drawing.Size(22, 22);
			this.Cmd_Functions.TabIndex = 11;
			this.Cmd_Functions.UseVisualStyleBackColor = true;
			this.Cmd_Functions.Click += new System.EventHandler(this.Cmd_FunctionsClick);
			// 
			// Cmd_Operators
			// 
			this.Cmd_Operators.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.Cmd_Operators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.Cmd_Operators.Image = global::CANStream.Icones.Virtual_Channel_Operator_16;
			this.Cmd_Operators.Location = new System.Drawing.Point(317, 238);
			this.Cmd_Operators.Name = "Cmd_Operators";
			this.Cmd_Operators.Size = new System.Drawing.Size(22, 22);
			this.Cmd_Operators.TabIndex = 10;
			this.Cmd_Operators.UseVisualStyleBackColor = true;
			this.Cmd_Operators.Click += new System.EventHandler(this.Cmd_OperatorsClick);
			// 
			// rTxt_ChanExpression
			// 
			this.rTxt_ChanExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rTxt_ChanExpression.Location = new System.Drawing.Point(6, 171);
			this.rTxt_ChanExpression.Name = "rTxt_ChanExpression";
			this.rTxt_ChanExpression.Size = new System.Drawing.Size(334, 68);
			this.rTxt_ChanExpression.TabIndex = 9;
			this.rTxt_ChanExpression.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(6, 150);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 18);
			this.label7.TabIndex = 8;
			this.label7.Text = "Expression";
			// 
			// rTxt_ChanComment
			// 
			this.rTxt_ChanComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.rTxt_ChanComment.Location = new System.Drawing.Point(75, 101);
			this.rTxt_ChanComment.Name = "rTxt_ChanComment";
			this.rTxt_ChanComment.Size = new System.Drawing.Size(265, 46);
			this.rTxt_ChanComment.TabIndex = 7;
			this.rTxt_ChanComment.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(3, 101);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 18);
			this.label6.TabIndex = 6;
			this.label6.Text = "Comment:";
			// 
			// Txt_ChanDecimal
			// 
			this.Txt_ChanDecimal.Location = new System.Drawing.Point(207, 36);
			this.Txt_ChanDecimal.Name = "Txt_ChanDecimal";
			this.Txt_ChanDecimal.Size = new System.Drawing.Size(61, 20);
			this.Txt_ChanDecimal.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(145, 39);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(56, 18);
			this.label5.TabIndex = 4;
			this.label5.Text = "Decimals:";
			// 
			// Txt_ChanUnit
			// 
			this.Txt_ChanUnit.Location = new System.Drawing.Point(78, 36);
			this.Txt_ChanUnit.Name = "Txt_ChanUnit";
			this.Txt_ChanUnit.Size = new System.Drawing.Size(61, 20);
			this.Txt_ChanUnit.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(6, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(39, 18);
			this.label4.TabIndex = 2;
			this.label4.Text = "Unit:";
			// 
			// Txt_ChanName
			// 
			this.Txt_ChanName.Location = new System.Drawing.Point(78, 11);
			this.Txt_ChanName.Name = "Txt_ChanName";
			this.Txt_ChanName.Size = new System.Drawing.Size(262, 20);
			this.Txt_ChanName.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(6, 13);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(39, 18);
			this.label3.TabIndex = 0;
			this.label3.Text = "Name:";
			// 
			// Frm_VirtualChannel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(544, 376);
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Icon = global::CANStream.Icones.CANStream_Icone;
			this.MinimumSize = new System.Drawing.Size(560, 414);
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
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox Txt_ChanDecimal;
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
	}
}
