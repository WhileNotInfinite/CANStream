/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 11/21/2014
 * Time: 4:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Ctrl_SpyDataViewer
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
            this.Split_RawEng_Data = new System.Windows.Forms.SplitContainer();
            this.label3 = new System.Windows.Forms.Label();
            this.Grid_SpyRaw = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Context_SpyRawGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextSpyRaw_ResetTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyRaw_HideSelectedRowsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyRaw_ShowHiddenRowsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyRaw_columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyRaw_showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyRaw_hideAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyRaw_dLCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyRaw_dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyRaw_periodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyRaw_countToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label12 = new System.Windows.Forms.Label();
            this.Grid_SpyEngineering = new System.Windows.Forms.DataGridView();
            this.Grid_Eng_Collapse_State = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpyEng_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_DLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpyEng_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Context_SpyEngGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextSpyEng_ResetTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyEng_HideSelectedRowsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_ShowHiddenRowsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_FilterTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_FiltetTSComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyEng_columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_hideAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyEng_iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_valueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_rawValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_maxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_commentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.Split_RawEng_Data)).BeginInit();
            this.Split_RawEng_Data.Panel1.SuspendLayout();
            this.Split_RawEng_Data.Panel2.SuspendLayout();
            this.Split_RawEng_Data.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SpyRaw)).BeginInit();
            this.Context_SpyRawGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SpyEngineering)).BeginInit();
            this.Context_SpyEngGrid.SuspendLayout();
            this.SuspendLayout();
            // 
            // Split_RawEng_Data
            // 
            this.Split_RawEng_Data.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split_RawEng_Data.Location = new System.Drawing.Point(0, 0);
            this.Split_RawEng_Data.Name = "Split_RawEng_Data";
            // 
            // Split_RawEng_Data.Panel1
            // 
            this.Split_RawEng_Data.Panel1.Controls.Add(this.label3);
            this.Split_RawEng_Data.Panel1.Controls.Add(this.Grid_SpyRaw);
            this.Split_RawEng_Data.Panel1MinSize = 0;
            // 
            // Split_RawEng_Data.Panel2
            // 
            this.Split_RawEng_Data.Panel2.Controls.Add(this.label12);
            this.Split_RawEng_Data.Panel2.Controls.Add(this.Grid_SpyEngineering);
            this.Split_RawEng_Data.Panel2MinSize = 0;
            this.Split_RawEng_Data.Size = new System.Drawing.Size(799, 362);
            this.Split_RawEng_Data.SplitterDistance = 157;
            this.Split_RawEng_Data.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "Raw data received";
            // 
            // Grid_SpyRaw
            // 
            this.Grid_SpyRaw.AllowUserToAddRows = false;
            this.Grid_SpyRaw.AllowUserToDeleteRows = false;
            this.Grid_SpyRaw.AllowUserToResizeColumns = false;
            this.Grid_SpyRaw.AllowUserToResizeRows = false;
            this.Grid_SpyRaw.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_SpyRaw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grid_SpyRaw.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column5});
            this.Grid_SpyRaw.ContextMenuStrip = this.Context_SpyRawGrid;
            this.Grid_SpyRaw.Location = new System.Drawing.Point(0, 17);
            this.Grid_SpyRaw.Margin = new System.Windows.Forms.Padding(1);
            this.Grid_SpyRaw.Name = "Grid_SpyRaw";
            this.Grid_SpyRaw.RowHeadersVisible = false;
            this.Grid_SpyRaw.Size = new System.Drawing.Size(156, 345);
            this.Grid_SpyRaw.TabIndex = 11;
            this.Grid_SpyRaw.SizeChanged += new System.EventHandler(this.Grid_SpyRawSizeChanged);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.MinimumWidth = 30;
            this.ID.Name = "ID";
            this.ID.Width = 40;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "DLC";
            this.Column1.MinimumWidth = 30;
            this.Column1.Name = "Column1";
            this.Column1.Width = 40;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Data";
            this.Column2.MinimumWidth = 140;
            this.Column2.Name = "Column2";
            this.Column2.Width = 140;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Period";
            this.Column3.MinimumWidth = 30;
            this.Column3.Name = "Column3";
            this.Column3.Width = 50;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Count";
            this.Column5.MinimumWidth = 30;
            this.Column5.Name = "Column5";
            this.Column5.Width = 50;
            // 
            // Context_SpyRawGrid
            // 
            this.Context_SpyRawGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyRaw_ResetTSMenuItem,
            this.toolStripSeparator3,
            this.ContextSpyRaw_HideSelectedRowsTSMenuItem,
            this.ContextSpyRaw_ShowHiddenRowsTSMenuItem,
            this.toolStripMenuItem10,
            this.ContextSpyRaw_columnsToolStripMenuItem});
            this.Context_SpyRawGrid.Name = "Context_SpyRawGrid";
            this.Context_SpyRawGrid.Size = new System.Drawing.Size(174, 104);
            // 
            // ContextSpyRaw_ResetTSMenuItem
            // 
            this.ContextSpyRaw_ResetTSMenuItem.Image = global::CANStream.Icones.Refresh_CAN_Controllers;
            this.ContextSpyRaw_ResetTSMenuItem.Name = "ContextSpyRaw_ResetTSMenuItem";
            this.ContextSpyRaw_ResetTSMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyRaw_ResetTSMenuItem.Text = "Reset";
            this.ContextSpyRaw_ResetTSMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_ResetTSMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(170, 6);
            // 
            // ContextSpyRaw_HideSelectedRowsTSMenuItem
            // 
            this.ContextSpyRaw_HideSelectedRowsTSMenuItem.Image = global::CANStream.Icones.Row_Hide_16;
            this.ContextSpyRaw_HideSelectedRowsTSMenuItem.Name = "ContextSpyRaw_HideSelectedRowsTSMenuItem";
            this.ContextSpyRaw_HideSelectedRowsTSMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyRaw_HideSelectedRowsTSMenuItem.Text = "Hide selected rows";
            this.ContextSpyRaw_HideSelectedRowsTSMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_HideSelectedRowsTSMenuItemClick);
            // 
            // ContextSpyRaw_ShowHiddenRowsTSMenuItem
            // 
            this.ContextSpyRaw_ShowHiddenRowsTSMenuItem.Image = global::CANStream.Icones.Row_Show_16;
            this.ContextSpyRaw_ShowHiddenRowsTSMenuItem.Name = "ContextSpyRaw_ShowHiddenRowsTSMenuItem";
            this.ContextSpyRaw_ShowHiddenRowsTSMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyRaw_ShowHiddenRowsTSMenuItem.Text = "Show hidden rows";
            this.ContextSpyRaw_ShowHiddenRowsTSMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_ShowHiddenRowsTSMenuItemClick);
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(170, 6);
            // 
            // ContextSpyRaw_columnsToolStripMenuItem
            // 
            this.ContextSpyRaw_columnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyRaw_showAllToolStripMenuItem,
            this.ContextSpyRaw_hideAllToolStripMenuItem,
            this.toolStripSeparator6,
            this.ContextSpyRaw_dLCToolStripMenuItem,
            this.ContextSpyRaw_dataToolStripMenuItem,
            this.ContextSpyRaw_periodToolStripMenuItem,
            this.ContextSpyRaw_countToolStripMenuItem});
            this.ContextSpyRaw_columnsToolStripMenuItem.Image = global::CANStream.Icones.Columns_16;
            this.ContextSpyRaw_columnsToolStripMenuItem.Name = "ContextSpyRaw_columnsToolStripMenuItem";
            this.ContextSpyRaw_columnsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyRaw_columnsToolStripMenuItem.Text = "Columns";
            // 
            // ContextSpyRaw_showAllToolStripMenuItem
            // 
            this.ContextSpyRaw_showAllToolStripMenuItem.Name = "ContextSpyRaw_showAllToolStripMenuItem";
            this.ContextSpyRaw_showAllToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ContextSpyRaw_showAllToolStripMenuItem.Text = "Show All";
            this.ContextSpyRaw_showAllToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_showAllToolStripMenuItemClick);
            // 
            // ContextSpyRaw_hideAllToolStripMenuItem
            // 
            this.ContextSpyRaw_hideAllToolStripMenuItem.Name = "ContextSpyRaw_hideAllToolStripMenuItem";
            this.ContextSpyRaw_hideAllToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ContextSpyRaw_hideAllToolStripMenuItem.Text = "Hide All";
            this.ContextSpyRaw_hideAllToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_hideAllToolStripMenuItemClick);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(117, 6);
            // 
            // ContextSpyRaw_dLCToolStripMenuItem
            // 
            this.ContextSpyRaw_dLCToolStripMenuItem.Name = "ContextSpyRaw_dLCToolStripMenuItem";
            this.ContextSpyRaw_dLCToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ContextSpyRaw_dLCToolStripMenuItem.Text = "DLC";
            this.ContextSpyRaw_dLCToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_dLCToolStripMenuItemClick);
            // 
            // ContextSpyRaw_dataToolStripMenuItem
            // 
            this.ContextSpyRaw_dataToolStripMenuItem.Name = "ContextSpyRaw_dataToolStripMenuItem";
            this.ContextSpyRaw_dataToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ContextSpyRaw_dataToolStripMenuItem.Text = "Data";
            this.ContextSpyRaw_dataToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_dataToolStripMenuItemClick);
            // 
            // ContextSpyRaw_periodToolStripMenuItem
            // 
            this.ContextSpyRaw_periodToolStripMenuItem.Name = "ContextSpyRaw_periodToolStripMenuItem";
            this.ContextSpyRaw_periodToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ContextSpyRaw_periodToolStripMenuItem.Text = "Period";
            this.ContextSpyRaw_periodToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_periodToolStripMenuItemClick);
            // 
            // ContextSpyRaw_countToolStripMenuItem
            // 
            this.ContextSpyRaw_countToolStripMenuItem.Name = "ContextSpyRaw_countToolStripMenuItem";
            this.ContextSpyRaw_countToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.ContextSpyRaw_countToolStripMenuItem.Text = "Count";
            this.ContextSpyRaw_countToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyRaw_countToolStripMenuItemClick);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.label12.Location = new System.Drawing.Point(0, 0);
            this.label12.Margin = new System.Windows.Forms.Padding(0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(139, 14);
            this.label12.TabIndex = 13;
            this.label12.Text = "Engineering data received";
            // 
            // Grid_SpyEngineering
            // 
            this.Grid_SpyEngineering.AllowUserToAddRows = false;
            this.Grid_SpyEngineering.AllowUserToDeleteRows = false;
            this.Grid_SpyEngineering.AllowUserToResizeColumns = false;
            this.Grid_SpyEngineering.AllowUserToResizeRows = false;
            this.Grid_SpyEngineering.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_SpyEngineering.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.Grid_SpyEngineering.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Grid_Eng_Collapse_State,
            this.Column6,
            this.Column7,
            this.RawValue,
            this.Column8,
            this.Column9,
            this.Column10,
            this.SpyEng_Unit,
            this.Grid_Eng_Period,
            this.Grid_Eng_Count,
            this.Grid_Eng_DLC,
            this.SpyEng_Comment});
            this.Grid_SpyEngineering.ContextMenuStrip = this.Context_SpyEngGrid;
            this.Grid_SpyEngineering.Location = new System.Drawing.Point(1, 17);
            this.Grid_SpyEngineering.Margin = new System.Windows.Forms.Padding(1);
            this.Grid_SpyEngineering.Name = "Grid_SpyEngineering";
            this.Grid_SpyEngineering.RowHeadersVisible = false;
            this.Grid_SpyEngineering.Size = new System.Drawing.Size(637, 345);
            this.Grid_SpyEngineering.TabIndex = 12;
            this.Grid_SpyEngineering.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_SpyEngineering_CellDoubleClick);
            this.Grid_SpyEngineering.SizeChanged += new System.EventHandler(this.Grid_SpyEngineeringSizeChanged);
            // 
            // Grid_Eng_Collapse_State
            // 
            this.Grid_Eng_Collapse_State.HeaderText = "";
            this.Grid_Eng_Collapse_State.Name = "Grid_Eng_Collapse_State";
            this.Grid_Eng_Collapse_State.Width = 20;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "ID";
            this.Column6.MinimumWidth = 30;
            this.Column6.Name = "Column6";
            this.Column6.Width = 40;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Parameter";
            this.Column7.MinimumWidth = 150;
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
            // 
            // RawValue
            // 
            this.RawValue.HeaderText = "Raw value";
            this.RawValue.MinimumWidth = 30;
            this.RawValue.Name = "RawValue";
            this.RawValue.ReadOnly = true;
            this.RawValue.Visible = false;
            this.RawValue.Width = 50;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Value";
            this.Column8.MinimumWidth = 40;
            this.Column8.Name = "Column8";
            this.Column8.Width = 50;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Min";
            this.Column9.MinimumWidth = 40;
            this.Column9.Name = "Column9";
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Max";
            this.Column10.MinimumWidth = 40;
            this.Column10.Name = "Column10";
            this.Column10.Width = 50;
            // 
            // SpyEng_Unit
            // 
            this.SpyEng_Unit.HeaderText = "Unit";
            this.SpyEng_Unit.MinimumWidth = 20;
            this.SpyEng_Unit.Name = "SpyEng_Unit";
            this.SpyEng_Unit.ReadOnly = true;
            this.SpyEng_Unit.Width = 40;
            // 
            // Grid_Eng_Period
            // 
            this.Grid_Eng_Period.HeaderText = "Period";
            this.Grid_Eng_Period.Name = "Grid_Eng_Period";
            this.Grid_Eng_Period.Width = 50;
            // 
            // Grid_Eng_Count
            // 
            this.Grid_Eng_Count.HeaderText = "Count";
            this.Grid_Eng_Count.Name = "Grid_Eng_Count";
            this.Grid_Eng_Count.Width = 50;
            // 
            // Grid_Eng_DLC
            // 
            this.Grid_Eng_DLC.HeaderText = "DLC";
            this.Grid_Eng_DLC.Name = "Grid_Eng_DLC";
            this.Grid_Eng_DLC.Width = 40;
            // 
            // SpyEng_Comment
            // 
            this.SpyEng_Comment.HeaderText = "Comment";
            this.SpyEng_Comment.Name = "SpyEng_Comment";
            this.SpyEng_Comment.ReadOnly = true;
            // 
            // Context_SpyEngGrid
            // 
            this.Context_SpyEngGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyEng_ResetTSMenuItem,
            this.toolStripSeparator4,
            this.ContextSpyEng_HideSelectedRowsTSMenuItem,
            this.ContextSpyEng_ShowHiddenRowsTSMenuItem,
            this.ContextSpyEng_FilterTSMenuItem,
            this.toolStripMenuItem11,
            this.ContextSpyEng_columnsToolStripMenuItem});
            this.Context_SpyEngGrid.Name = "Context_SpyEngGrid";
            this.Context_SpyEngGrid.Size = new System.Drawing.Size(174, 126);
            // 
            // ContextSpyEng_ResetTSMenuItem
            // 
            this.ContextSpyEng_ResetTSMenuItem.Image = global::CANStream.Icones.Refresh_CAN_Controllers;
            this.ContextSpyEng_ResetTSMenuItem.Name = "ContextSpyEng_ResetTSMenuItem";
            this.ContextSpyEng_ResetTSMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyEng_ResetTSMenuItem.Text = "Reset";
            this.ContextSpyEng_ResetTSMenuItem.Click += new System.EventHandler(this.ContextSpyEng_ResetTSMenuItemClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(170, 6);
            // 
            // ContextSpyEng_HideSelectedRowsTSMenuItem
            // 
            this.ContextSpyEng_HideSelectedRowsTSMenuItem.Image = global::CANStream.Icones.Row_Hide_16;
            this.ContextSpyEng_HideSelectedRowsTSMenuItem.Name = "ContextSpyEng_HideSelectedRowsTSMenuItem";
            this.ContextSpyEng_HideSelectedRowsTSMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyEng_HideSelectedRowsTSMenuItem.Text = "Hide selected rows";
            this.ContextSpyEng_HideSelectedRowsTSMenuItem.Click += new System.EventHandler(this.ContextSpyEng_HideSelectedRowsTSMenuItemClick);
            // 
            // ContextSpyEng_ShowHiddenRowsTSMenuItem
            // 
            this.ContextSpyEng_ShowHiddenRowsTSMenuItem.Image = global::CANStream.Icones.Row_Show_16;
            this.ContextSpyEng_ShowHiddenRowsTSMenuItem.Name = "ContextSpyEng_ShowHiddenRowsTSMenuItem";
            this.ContextSpyEng_ShowHiddenRowsTSMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyEng_ShowHiddenRowsTSMenuItem.Text = "Show hidden rows";
            this.ContextSpyEng_ShowHiddenRowsTSMenuItem.Click += new System.EventHandler(this.ContextSpyEng_ShowHiddenRowsTSMenuItemClick);
            // 
            // ContextSpyEng_FilterTSMenuItem
            // 
            this.ContextSpyEng_FilterTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyEng_FiltetTSComboBox});
            this.ContextSpyEng_FilterTSMenuItem.Name = "ContextSpyEng_FilterTSMenuItem";
            this.ContextSpyEng_FilterTSMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyEng_FilterTSMenuItem.Text = "Filter";
            // 
            // ContextSpyEng_FiltetTSComboBox
            // 
            this.ContextSpyEng_FiltetTSComboBox.Name = "ContextSpyEng_FiltetTSComboBox";
            this.ContextSpyEng_FiltetTSComboBox.Size = new System.Drawing.Size(121, 23);
            this.ContextSpyEng_FiltetTSComboBox.SelectedIndexChanged += new System.EventHandler(this.ContextSpyEng_FiltetTSComboBoxSelectedIndexChanged);
            this.ContextSpyEng_FiltetTSComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ContextSpyEng_FiltetTSComboBoxKeyDown);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(170, 6);
            // 
            // ContextSpyEng_columnsToolStripMenuItem
            // 
            this.ContextSpyEng_columnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyEng_showAllToolStripMenuItem,
            this.ContextSpyEng_hideAllToolStripMenuItem,
            this.toolStripSeparator7,
            this.ContextSpyEng_iDToolStripMenuItem,
            this.ContextSpyEng_valueToolStripMenuItem,
            this.ContextSpyEng_rawValueToolStripMenuItem,
            this.ContextSpyEng_minToolStripMenuItem,
            this.ContextSpyEng_maxToolStripMenuItem,
            this.ContextSpyEng_unitToolStripMenuItem,
            this.ContextSpyEng_commentToolStripMenuItem});
            this.ContextSpyEng_columnsToolStripMenuItem.Image = global::CANStream.Icones.Columns_16;
            this.ContextSpyEng_columnsToolStripMenuItem.Name = "ContextSpyEng_columnsToolStripMenuItem";
            this.ContextSpyEng_columnsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.ContextSpyEng_columnsToolStripMenuItem.Text = "Columns";
            // 
            // ContextSpyEng_showAllToolStripMenuItem
            // 
            this.ContextSpyEng_showAllToolStripMenuItem.Name = "ContextSpyEng_showAllToolStripMenuItem";
            this.ContextSpyEng_showAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_showAllToolStripMenuItem.Text = "Show All";
            this.ContextSpyEng_showAllToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_showAllToolStripMenuItemClick);
            // 
            // ContextSpyEng_hideAllToolStripMenuItem
            // 
            this.ContextSpyEng_hideAllToolStripMenuItem.Name = "ContextSpyEng_hideAllToolStripMenuItem";
            this.ContextSpyEng_hideAllToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_hideAllToolStripMenuItem.Text = "Hide All";
            this.ContextSpyEng_hideAllToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_hideAllToolStripMenuItemClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(125, 6);
            // 
            // ContextSpyEng_iDToolStripMenuItem
            // 
            this.ContextSpyEng_iDToolStripMenuItem.Name = "ContextSpyEng_iDToolStripMenuItem";
            this.ContextSpyEng_iDToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_iDToolStripMenuItem.Text = "ID";
            this.ContextSpyEng_iDToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_iDToolStripMenuItemClick);
            // 
            // ContextSpyEng_valueToolStripMenuItem
            // 
            this.ContextSpyEng_valueToolStripMenuItem.Name = "ContextSpyEng_valueToolStripMenuItem";
            this.ContextSpyEng_valueToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_valueToolStripMenuItem.Text = "Value";
            this.ContextSpyEng_valueToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_valueToolStripMenuItemClick);
            // 
            // ContextSpyEng_rawValueToolStripMenuItem
            // 
            this.ContextSpyEng_rawValueToolStripMenuItem.Name = "ContextSpyEng_rawValueToolStripMenuItem";
            this.ContextSpyEng_rawValueToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_rawValueToolStripMenuItem.Text = "Raw value";
            this.ContextSpyEng_rawValueToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_rawValueToolStripMenuItemClick);
            // 
            // ContextSpyEng_minToolStripMenuItem
            // 
            this.ContextSpyEng_minToolStripMenuItem.Name = "ContextSpyEng_minToolStripMenuItem";
            this.ContextSpyEng_minToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_minToolStripMenuItem.Text = "Min";
            this.ContextSpyEng_minToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_minToolStripMenuItemClick);
            // 
            // ContextSpyEng_maxToolStripMenuItem
            // 
            this.ContextSpyEng_maxToolStripMenuItem.Name = "ContextSpyEng_maxToolStripMenuItem";
            this.ContextSpyEng_maxToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_maxToolStripMenuItem.Text = "Max";
            this.ContextSpyEng_maxToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_maxToolStripMenuItemClick);
            // 
            // ContextSpyEng_unitToolStripMenuItem
            // 
            this.ContextSpyEng_unitToolStripMenuItem.Name = "ContextSpyEng_unitToolStripMenuItem";
            this.ContextSpyEng_unitToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_unitToolStripMenuItem.Text = "Unit";
            this.ContextSpyEng_unitToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_unitToolStripMenuItemClick);
            // 
            // ContextSpyEng_commentToolStripMenuItem
            // 
            this.ContextSpyEng_commentToolStripMenuItem.Name = "ContextSpyEng_commentToolStripMenuItem";
            this.ContextSpyEng_commentToolStripMenuItem.Size = new System.Drawing.Size(128, 22);
            this.ContextSpyEng_commentToolStripMenuItem.Text = "Comment";
            this.ContextSpyEng_commentToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_commentToolStripMenuItemClick);
            // 
            // Ctrl_SpyDataViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Split_RawEng_Data);
            this.Name = "Ctrl_SpyDataViewer";
            this.Size = new System.Drawing.Size(799, 362);
            this.Split_RawEng_Data.Panel1.ResumeLayout(false);
            this.Split_RawEng_Data.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split_RawEng_Data)).EndInit();
            this.Split_RawEng_Data.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SpyRaw)).EndInit();
            this.Context_SpyRawGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SpyEngineering)).EndInit();
            this.Context_SpyEngGrid.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolStripComboBox ContextSpyEng_FiltetTSComboBox;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_FilterTSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_countToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_periodToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_dataToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_dLCToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_hideAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_showAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_columnsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_ShowHiddenRowsTSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_HideSelectedRowsTSMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyRaw_ResetTSMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_SpyRawGrid;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_commentToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_unitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_maxToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_minToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_rawValueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_valueToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_iDToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_hideAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_showAllToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_columnsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem11;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_ShowHiddenRowsTSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_HideSelectedRowsTSMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_ResetTSMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_SpyEngGrid;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.DataGridView Grid_SpyEngineering;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.DataGridViewTextBoxColumn ID;
		private System.Windows.Forms.DataGridView Grid_SpyRaw;
		private System.Windows.Forms.SplitContainer Split_RawEng_Data;
        private System.Windows.Forms.DataGridViewImageColumn Grid_Eng_Collapse_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn RawValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpyEng_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_DLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpyEng_Comment;
    }
}
