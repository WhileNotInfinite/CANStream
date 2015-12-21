/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 7/21/2014
 * Time: 12:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_CycleEdition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CycleEdition));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_New = new System.Windows.Forms.ToolStripButton();
            this.TSB_Open = new System.Windows.Forms.ToolStripButton();
            this.TSB_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_LoadCanConfig = new System.Windows.Forms.ToolStripButton();
            this.TSB_ReLoad_VirtualLibraries = new System.Windows.Forms.ToolStripButton();
            this.TSB_ReLoad_SignalLibraries = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_MakeCycle = new System.Windows.Forms.ToolStripButton();
            this.TSB_StopMakeCycle = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLbl_ActionCaption = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusLbl_Action = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Grp_Elements = new System.Windows.Forms.GroupBox();
            this.Lbl_PropDataFile = new System.Windows.Forms.Label();
            this.Lbl_PropTimeLen = new System.Windows.Forms.Label();
            this.Lbl_PostCycle = new System.Windows.Forms.Label();
            this.Lbl_Cycle = new System.Windows.Forms.Label();
            this.Lbl_PreCycle = new System.Windows.Forms.Label();
            this.Grid_PostCycleProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_CycleProperties = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_PreCycleProperties = new System.Windows.Forms.DataGridView();
            this.Value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_CycleElements = new System.Windows.Forms.DataGridView();
            this.PreCycle_Source = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PreCycle_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cycle_Source = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Cycle_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PostCycle_Source = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.PostCycle_Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grp_Graph = new System.Windows.Forms.GroupBox();
            this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.Img_GrdElement_TreeView = new System.Windows.Forms.ImageList(this.components);
            this.BGWrk_CycleMake = new System.ComponentModel.BackgroundWorker();
            this.CycleGraphicCtrl = new Ctrl_GraphWindow.Ctrl_WaveForm();
            this.Context_Graph = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.Grp_Elements.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_PostCycleProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_CycleProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_PreCycleProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_CycleElements)).BeginInit();
            this.Grp_Graph.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_New,
            this.TSB_Open,
            this.TSB_Save,
            this.toolStripSeparator1,
            this.TSB_LoadCanConfig,
            this.TSB_ReLoad_VirtualLibraries,
            this.TSB_ReLoad_SignalLibraries,
            this.toolStripSeparator2,
            this.TSB_MakeCycle,
            this.TSB_StopMakeCycle});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(849, 39);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSB_New
            // 
            this.TSB_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_New.Image = global::CANStream.Icones.File_New_32;
            this.TSB_New.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_New.Name = "TSB_New";
            this.TSB_New.Size = new System.Drawing.Size(36, 36);
            this.TSB_New.Text = "toolStripButton1";
            this.TSB_New.ToolTipText = "Create new cycle configuration";
            this.TSB_New.Click += new System.EventHandler(this.TSB_NewClick);
            // 
            // TSB_Open
            // 
            this.TSB_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Open.Image = global::CANStream.Icones.File_Open_32;
            this.TSB_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Open.Name = "TSB_Open";
            this.TSB_Open.Size = new System.Drawing.Size(36, 36);
            this.TSB_Open.Text = "toolStripButton2";
            this.TSB_Open.ToolTipText = "Open cycle configuration";
            this.TSB_Open.Click += new System.EventHandler(this.TSB_OpenClick);
            // 
            // TSB_Save
            // 
            this.TSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Save.Image = global::CANStream.Icones.File_Save_32;
            this.TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Save.Name = "TSB_Save";
            this.TSB_Save.Size = new System.Drawing.Size(36, 36);
            this.TSB_Save.Text = "toolStripButton3";
            this.TSB_Save.ToolTipText = "Save cycle configuration";
            this.TSB_Save.Click += new System.EventHandler(this.TSB_SaveClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_LoadCanConfig
            // 
            this.TSB_LoadCanConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_LoadCanConfig.Image = global::CANStream.Icones.CANStream_32;
            this.TSB_LoadCanConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_LoadCanConfig.Name = "TSB_LoadCanConfig";
            this.TSB_LoadCanConfig.Size = new System.Drawing.Size(36, 36);
            this.TSB_LoadCanConfig.Text = "toolStripButton1";
            this.TSB_LoadCanConfig.ToolTipText = "Load a CAN Configuration file";
            this.TSB_LoadCanConfig.Click += new System.EventHandler(this.TSB_LoadCanConfigClick);
            // 
            // TSB_ReLoad_VirtualLibraries
            // 
            this.TSB_ReLoad_VirtualLibraries.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ReLoad_VirtualLibraries.Image = global::CANStream.Icones.Virtual_Channel_32;
            this.TSB_ReLoad_VirtualLibraries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ReLoad_VirtualLibraries.Name = "TSB_ReLoad_VirtualLibraries";
            this.TSB_ReLoad_VirtualLibraries.Size = new System.Drawing.Size(36, 36);
            this.TSB_ReLoad_VirtualLibraries.Text = "toolStripButton1";
            this.TSB_ReLoad_VirtualLibraries.ToolTipText = "Re-load virtual channel libraries";
            this.TSB_ReLoad_VirtualLibraries.Click += new System.EventHandler(this.TSB_ReLoad_VirtualLibrariesClick);
            // 
            // TSB_ReLoad_SignalLibraries
            // 
            this.TSB_ReLoad_SignalLibraries.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ReLoad_SignalLibraries.Image = global::CANStream.Icones.BuiltIn_Signal_32;
            this.TSB_ReLoad_SignalLibraries.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ReLoad_SignalLibraries.Name = "TSB_ReLoad_SignalLibraries";
            this.TSB_ReLoad_SignalLibraries.Size = new System.Drawing.Size(36, 36);
            this.TSB_ReLoad_SignalLibraries.Text = "toolStripButton2";
            this.TSB_ReLoad_SignalLibraries.ToolTipText = "Re-load built-in signals libraries";
            this.TSB_ReLoad_SignalLibraries.Click += new System.EventHandler(this.TSB_ReLoad_SignalLibrariesClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_MakeCycle
            // 
            this.TSB_MakeCycle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_MakeCycle.Image = global::CANStream.Icones.Run_Process_32;
            this.TSB_MakeCycle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_MakeCycle.Name = "TSB_MakeCycle";
            this.TSB_MakeCycle.Size = new System.Drawing.Size(36, 36);
            this.TSB_MakeCycle.Text = "toolStripButton1";
            this.TSB_MakeCycle.ToolTipText = "Build cycle";
            this.TSB_MakeCycle.Click += new System.EventHandler(this.TSB_MakeCycleClick);
            // 
            // TSB_StopMakeCycle
            // 
            this.TSB_StopMakeCycle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_StopMakeCycle.Image = global::CANStream.Icones.Stop_Process_32;
            this.TSB_StopMakeCycle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_StopMakeCycle.Name = "TSB_StopMakeCycle";
            this.TSB_StopMakeCycle.Size = new System.Drawing.Size(36, 36);
            this.TSB_StopMakeCycle.Text = "toolStripButton1";
            this.TSB_StopMakeCycle.ToolTipText = "Stop cycle building process";
            this.TSB_StopMakeCycle.Visible = false;
            this.TSB_StopMakeCycle.Click += new System.EventHandler(this.TSB_StopMakeCycleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLbl_ActionCaption,
            this.StatusLbl_Action,
            this.Status_Progress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 462);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(849, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLbl_ActionCaption
            // 
            this.StatusLbl_ActionCaption.Name = "StatusLbl_ActionCaption";
            this.StatusLbl_ActionCaption.Size = new System.Drawing.Size(60, 17);
            this.StatusLbl_ActionCaption.Text = "Operation";
            this.StatusLbl_ActionCaption.Visible = false;
            // 
            // StatusLbl_Action
            // 
            this.StatusLbl_Action.Name = "StatusLbl_Action";
            this.StatusLbl_Action.Size = new System.Drawing.Size(22, 17);
            this.StatusLbl_Action.Text = "xxx";
            this.StatusLbl_Action.Visible = false;
            // 
            // Status_Progress
            // 
            this.Status_Progress.Name = "Status_Progress";
            this.Status_Progress.Size = new System.Drawing.Size(500, 16);
            this.Status_Progress.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 39);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.Grp_Elements);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Grp_Graph);
            this.splitContainer1.Size = new System.Drawing.Size(849, 423);
            this.splitContainer1.SplitterDistance = 406;
            this.splitContainer1.TabIndex = 2;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.SplitContainer1SplitterMoved);
            // 
            // Grp_Elements
            // 
            this.Grp_Elements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Elements.Controls.Add(this.Lbl_PropDataFile);
            this.Grp_Elements.Controls.Add(this.Lbl_PropTimeLen);
            this.Grp_Elements.Controls.Add(this.Lbl_PostCycle);
            this.Grp_Elements.Controls.Add(this.Lbl_Cycle);
            this.Grp_Elements.Controls.Add(this.Lbl_PreCycle);
            this.Grp_Elements.Controls.Add(this.Grid_PostCycleProperties);
            this.Grp_Elements.Controls.Add(this.Grid_CycleProperties);
            this.Grp_Elements.Controls.Add(this.Grid_PreCycleProperties);
            this.Grp_Elements.Controls.Add(this.Grid_CycleElements);
            this.Grp_Elements.Location = new System.Drawing.Point(3, 3);
            this.Grp_Elements.Name = "Grp_Elements";
            this.Grp_Elements.Size = new System.Drawing.Size(400, 417);
            this.Grp_Elements.TabIndex = 0;
            this.Grp_Elements.TabStop = false;
            this.Grp_Elements.Text = "Cycle elements";
            // 
            // Lbl_PropDataFile
            // 
            this.Lbl_PropDataFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_PropDataFile.Location = new System.Drawing.Point(6, 60);
            this.Lbl_PropDataFile.Name = "Lbl_PropDataFile";
            this.Lbl_PropDataFile.Size = new System.Drawing.Size(47, 25);
            this.Lbl_PropDataFile.TabIndex = 8;
            this.Lbl_PropDataFile.Text = "Data file";
            this.Lbl_PropDataFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_PropTimeLen
            // 
            this.Lbl_PropTimeLen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_PropTimeLen.Location = new System.Drawing.Point(6, 37);
            this.Lbl_PropTimeLen.Name = "Lbl_PropTimeLen";
            this.Lbl_PropTimeLen.Size = new System.Drawing.Size(47, 25);
            this.Lbl_PropTimeLen.TabIndex = 7;
            this.Lbl_PropTimeLen.Text = "Time length";
            this.Lbl_PropTimeLen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Lbl_PostCycle
            // 
            this.Lbl_PostCycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_PostCycle.Location = new System.Drawing.Point(389, 16);
            this.Lbl_PostCycle.Name = "Lbl_PostCycle";
            this.Lbl_PostCycle.Size = new System.Drawing.Size(171, 18);
            this.Lbl_PostCycle.TabIndex = 6;
            this.Lbl_PostCycle.Text = "Post Cycle";
            this.Lbl_PostCycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_Cycle
            // 
            this.Lbl_Cycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Cycle.Location = new System.Drawing.Point(221, 16);
            this.Lbl_Cycle.Name = "Lbl_Cycle";
            this.Lbl_Cycle.Size = new System.Drawing.Size(171, 18);
            this.Lbl_Cycle.TabIndex = 5;
            this.Lbl_Cycle.Text = "Cycle";
            this.Lbl_Cycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_PreCycle
            // 
            this.Lbl_PreCycle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_PreCycle.Location = new System.Drawing.Point(54, 16);
            this.Lbl_PreCycle.Name = "Lbl_PreCycle";
            this.Lbl_PreCycle.Size = new System.Drawing.Size(171, 18);
            this.Lbl_PreCycle.TabIndex = 4;
            this.Lbl_PreCycle.Text = "Pre Cycle";
            this.Lbl_PreCycle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Grid_PostCycleProperties
            // 
            this.Grid_PostCycleProperties.AllowUserToAddRows = false;
            this.Grid_PostCycleProperties.AllowUserToResizeColumns = false;
            this.Grid_PostCycleProperties.AllowUserToResizeRows = false;
            this.Grid_PostCycleProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_PostCycleProperties.ColumnHeadersVisible = false;
            this.Grid_PostCycleProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2});
            this.Grid_PostCycleProperties.Location = new System.Drawing.Point(389, 37);
            this.Grid_PostCycleProperties.Name = "Grid_PostCycleProperties";
            this.Grid_PostCycleProperties.RowHeadersVisible = false;
            this.Grid_PostCycleProperties.Size = new System.Drawing.Size(171, 48);
            this.Grid_PostCycleProperties.TabIndex = 3;
            this.Grid_PostCycleProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_PostCyclePropertiesCellClick);
            this.Grid_PostCycleProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_PostCyclePropertiesCellValueChanged);
            this.Grid_PostCycleProperties.Leave += new System.EventHandler(this.Grid_PostCyclePropertiesLeave);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Value";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Grid_CycleProperties
            // 
            this.Grid_CycleProperties.AllowUserToAddRows = false;
            this.Grid_CycleProperties.AllowUserToResizeColumns = false;
            this.Grid_CycleProperties.AllowUserToResizeRows = false;
            this.Grid_CycleProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_CycleProperties.ColumnHeadersVisible = false;
            this.Grid_CycleProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.Grid_CycleProperties.Location = new System.Drawing.Point(221, 37);
            this.Grid_CycleProperties.Name = "Grid_CycleProperties";
            this.Grid_CycleProperties.RowHeadersVisible = false;
            this.Grid_CycleProperties.Size = new System.Drawing.Size(171, 48);
            this.Grid_CycleProperties.TabIndex = 2;
            this.Grid_CycleProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CyclePropertiesCellClick);
            this.Grid_CycleProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CyclePropertiesCellValueChanged);
            this.Grid_CycleProperties.Leave += new System.EventHandler(this.Grid_CyclePropertiesLeave);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Value";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // Grid_PreCycleProperties
            // 
            this.Grid_PreCycleProperties.AllowUserToAddRows = false;
            this.Grid_PreCycleProperties.AllowUserToResizeColumns = false;
            this.Grid_PreCycleProperties.AllowUserToResizeRows = false;
            this.Grid_PreCycleProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_PreCycleProperties.ColumnHeadersVisible = false;
            this.Grid_PreCycleProperties.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Value});
            this.Grid_PreCycleProperties.Location = new System.Drawing.Point(54, 37);
            this.Grid_PreCycleProperties.Name = "Grid_PreCycleProperties";
            this.Grid_PreCycleProperties.RowHeadersVisible = false;
            this.Grid_PreCycleProperties.Size = new System.Drawing.Size(171, 48);
            this.Grid_PreCycleProperties.TabIndex = 1;
            this.Grid_PreCycleProperties.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_PreCyclePropertiesCellClick);
            this.Grid_PreCycleProperties.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_PreCyclePropertiesCellValueChanged);
            this.Grid_PreCycleProperties.Leave += new System.EventHandler(this.Grid_PreCyclePropertiesLeave);
            // 
            // Value
            // 
            this.Value.HeaderText = "Value";
            this.Value.Name = "Value";
            // 
            // Grid_CycleElements
            // 
            this.Grid_CycleElements.AllowUserToAddRows = false;
            this.Grid_CycleElements.AllowUserToDeleteRows = false;
            this.Grid_CycleElements.AllowUserToResizeColumns = false;
            this.Grid_CycleElements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_CycleElements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_CycleElements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PreCycle_Source,
            this.PreCycle_Data,
            this.Cycle_Source,
            this.Cycle_Data,
            this.PostCycle_Source,
            this.PostCycle_Data});
            this.Grid_CycleElements.Location = new System.Drawing.Point(6, 91);
            this.Grid_CycleElements.Name = "Grid_CycleElements";
            this.Grid_CycleElements.Size = new System.Drawing.Size(388, 320);
            this.Grid_CycleElements.TabIndex = 0;
            this.Grid_CycleElements.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CycleElementsCellClick);
            this.Grid_CycleElements.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CycleElementsCellValueChanged);
            // 
            // PreCycle_Source
            // 
            this.PreCycle_Source.HeaderText = "Source";
            this.PreCycle_Source.Name = "PreCycle_Source";
            this.PreCycle_Source.Width = 70;
            // 
            // PreCycle_Data
            // 
            this.PreCycle_Data.HeaderText = "Data";
            this.PreCycle_Data.Name = "PreCycle_Data";
            this.PreCycle_Data.ReadOnly = true;
            // 
            // Cycle_Source
            // 
            this.Cycle_Source.HeaderText = "Source";
            this.Cycle_Source.Name = "Cycle_Source";
            this.Cycle_Source.Width = 70;
            // 
            // Cycle_Data
            // 
            this.Cycle_Data.HeaderText = "Data";
            this.Cycle_Data.Name = "Cycle_Data";
            this.Cycle_Data.ReadOnly = true;
            // 
            // PostCycle_Source
            // 
            this.PostCycle_Source.HeaderText = "Source";
            this.PostCycle_Source.Name = "PostCycle_Source";
            this.PostCycle_Source.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.PostCycle_Source.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.PostCycle_Source.Width = 70;
            // 
            // PostCycle_Data
            // 
            this.PostCycle_Data.HeaderText = "Data";
            this.PostCycle_Data.Name = "PostCycle_Data";
            this.PostCycle_Data.ReadOnly = true;
            // 
            // Grp_Graph
            // 
            this.Grp_Graph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Graph.Controls.Add(this.CycleGraphicCtrl);
            this.Grp_Graph.Location = new System.Drawing.Point(3, 3);
            this.Grp_Graph.Name = "Grp_Graph";
            this.Grp_Graph.Size = new System.Drawing.Size(433, 417);
            this.Grp_Graph.TabIndex = 0;
            this.Grp_Graph.TabStop = false;
            this.Grp_Graph.Text = "Graph";
            // 
            // Img_GrdElement_TreeView
            // 
            this.Img_GrdElement_TreeView.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_GrdElement_TreeView.ImageStream")));
            this.Img_GrdElement_TreeView.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_GrdElement_TreeView.Images.SetKeyName(0, "library-books-icone-5837-16.png");
            this.Img_GrdElement_TreeView.Images.SetKeyName(1, "gear-wheel-system-package-icone-9540-16.png");
            this.Img_GrdElement_TreeView.Images.SetKeyName(2, "edu-des-mathematiques-icone-4069-16.png");
            // 
            // BGWrk_CycleMake
            // 
            this.BGWrk_CycleMake.WorkerReportsProgress = true;
            this.BGWrk_CycleMake.WorkerSupportsCancellation = true;
            this.BGWrk_CycleMake.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWrk_CycleMakeDoWork);
            this.BGWrk_CycleMake.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWrk_CycleMakeProgressChanged);
            this.BGWrk_CycleMake.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWrk_CycleMakeRunWorkerCompleted);
            // 
            // CycleGraphicCtrl
            // 
            this.CycleGraphicCtrl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CycleGraphicCtrl.ChannelListEnabled = false;
            this.CycleGraphicCtrl.CursorEnabled = true;
            this.CycleGraphicCtrl.EditGraphicConfigurationEnable = false;
            this.CycleGraphicCtrl.LegendEnabled = true;
            this.CycleGraphicCtrl.Location = new System.Drawing.Point(6, 19);
            this.CycleGraphicCtrl.Name = "CycleGraphicCtrl";
            this.CycleGraphicCtrl.OpenFileVisible = false;
            this.CycleGraphicCtrl.PrintEnabled = false;
            this.CycleGraphicCtrl.Size = new System.Drawing.Size(417, 392);
            this.CycleGraphicCtrl.SnapShotEnabled = false;
            this.CycleGraphicCtrl.TabIndex = 0;
            this.CycleGraphicCtrl.ToolBarVisible = false;
            this.CycleGraphicCtrl.ZoomEnabled = true;
            // 
            // Context_Graph
            // 
            this.Context_Graph.Name = "Context_Graph";
            this.Context_Graph.Size = new System.Drawing.Size(61, 4);
            // 
            // Frm_CycleEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 484);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Icon = global::CANStream.Icones.CANStream_Icone;
            this.Name = "Frm_CycleEdition";
            this.Text = "Cycle edition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_CycleEditionFormClosing);
            this.Load += new System.EventHandler(this.Frm_CycleEditionLoad);
            this.Shown += new System.EventHandler(this.Frm_CycleEditionShown);
            this.Resize += new System.EventHandler(this.Frm_CycleEditionResize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.Grp_Elements.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_PostCycleProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_CycleProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_PreCycleProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_CycleElements)).EndInit();
            this.Grp_Graph.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripButton TSB_StopMakeCycle;
		private System.ComponentModel.BackgroundWorker BGWrk_CycleMake;
		private System.Windows.Forms.ToolStripButton TSB_ReLoad_SignalLibraries;
		private System.Windows.Forms.ToolStripButton TSB_ReLoad_VirtualLibraries;
		private System.Windows.Forms.ImageList Img_GrdElement_TreeView;
		private System.Windows.Forms.SaveFileDialog Dlg_SaveFile;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton TSB_LoadCanConfig;
		private System.Windows.Forms.Label Lbl_PropDataFile;
		private System.Windows.Forms.Label Lbl_PropTimeLen;
		private System.Windows.Forms.DataGridViewTextBoxColumn Value;
		private System.Windows.Forms.DataGridView Grid_PreCycleProperties;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridView Grid_CycleProperties;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridView Grid_PostCycleProperties;
		private System.Windows.Forms.Label Lbl_PreCycle;
		private System.Windows.Forms.Label Lbl_Cycle;
		private System.Windows.Forms.Label Lbl_PostCycle;
		private System.Windows.Forms.DataGridViewTextBoxColumn PostCycle_Data;
		private System.Windows.Forms.DataGridViewComboBoxColumn PostCycle_Source;
		private System.Windows.Forms.DataGridViewTextBoxColumn Cycle_Data;
		private System.Windows.Forms.DataGridViewComboBoxColumn Cycle_Source;
		private System.Windows.Forms.DataGridViewTextBoxColumn PreCycle_Data;
		private System.Windows.Forms.DataGridViewComboBoxColumn PreCycle_Source;
		private System.Windows.Forms.DataGridView Grid_CycleElements;
		private System.Windows.Forms.ToolStripButton TSB_MakeCycle;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.GroupBox Grp_Graph;
		private System.Windows.Forms.GroupBox Grp_Elements;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripProgressBar Status_Progress;
		private System.Windows.Forms.ToolStripStatusLabel StatusLbl_Action;
		private System.Windows.Forms.ToolStripStatusLabel StatusLbl_ActionCaption;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripButton TSB_Save;
		private System.Windows.Forms.ToolStripButton TSB_Open;
		private System.Windows.Forms.ToolStripButton TSB_New;
		private System.Windows.Forms.ToolStrip toolStrip1;
        private Ctrl_GraphWindow.Ctrl_WaveForm CycleGraphicCtrl;
        private System.Windows.Forms.ContextMenuStrip Context_Graph;
    }
}
