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
	partial class Ctrl_CANDataGrid
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Grid_SpyEngineering = new System.Windows.Forms.DataGridView();
            this.Grid_Eng_Collapse_State = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_RxTx = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpyEng_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Length = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Endianess = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Signed = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Gain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Zero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Grid_Eng_DLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SpyEng_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Context_SpyEngGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ContextSpyEng_ResetTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyEng_CollapseRowsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_ExpandRowsTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyEng_FilterTSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_FiltetTSComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyEng_columnsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_showAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_hideAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ContextSpyEng_iDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_RxTxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_valueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_rawValueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_minToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_maxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_unitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_periodToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_StartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_LengthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_EndianessToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_SignedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_GainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_ZeroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_countToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_dlcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContextSpyEng_commentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Lbl_GridTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SpyEngineering)).BeginInit();
            this.Context_SpyEngGrid.SuspendLayout();
            this.SuspendLayout();
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
            this.Grid_Eng_RxTx,
            this.Column7,
            this.RawValue,
            this.Column8,
            this.Column9,
            this.Column10,
            this.SpyEng_Unit,
            this.Grid_Eng_Period,
            this.Grid_Eng_Start,
            this.Grid_Eng_Length,
            this.Grid_Eng_Endianess,
            this.Grid_Eng_Signed,
            this.Grid_Eng_Gain,
            this.Grid_Eng_Zero,
            this.Grid_Eng_Count,
            this.Grid_Eng_DLC,
            this.SpyEng_Comment});
            this.Grid_SpyEngineering.ContextMenuStrip = this.Context_SpyEngGrid;
            this.Grid_SpyEngineering.Location = new System.Drawing.Point(1, 17);
            this.Grid_SpyEngineering.Margin = new System.Windows.Forms.Padding(1);
            this.Grid_SpyEngineering.Name = "Grid_SpyEngineering";
            this.Grid_SpyEngineering.RowHeadersVisible = false;
            this.Grid_SpyEngineering.Size = new System.Drawing.Size(746, 300);
            this.Grid_SpyEngineering.TabIndex = 12;
            this.Grid_SpyEngineering.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Grid_SpyEngineering_CellBeginEdit);
            this.Grid_SpyEngineering.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_SpyEngineering_CellDoubleClick);
            this.Grid_SpyEngineering.SizeChanged += new System.EventHandler(this.Grid_SpyEngineeringSizeChanged);
            // 
            // Grid_Eng_Collapse_State
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = "System.Drawing.Bitmap";
            this.Grid_Eng_Collapse_State.DefaultCellStyle = dataGridViewCellStyle1;
            this.Grid_Eng_Collapse_State.HeaderText = "";
            this.Grid_Eng_Collapse_State.Name = "Grid_Eng_Collapse_State";
            this.Grid_Eng_Collapse_State.ReadOnly = true;
            this.Grid_Eng_Collapse_State.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Grid_Eng_Collapse_State.Width = 20;
            // 
            // Column6
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column6.HeaderText = "ID";
            this.Column6.MinimumWidth = 30;
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 40;
            // 
            // Grid_Eng_RxTx
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_RxTx.DefaultCellStyle = dataGridViewCellStyle3;
            this.Grid_Eng_RxTx.HeaderText = "RxTx";
            this.Grid_Eng_RxTx.MinimumWidth = 40;
            this.Grid_Eng_RxTx.Name = "Grid_Eng_RxTx";
            this.Grid_Eng_RxTx.ReadOnly = true;
            this.Grid_Eng_RxTx.Width = 40;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Parameter";
            this.Column7.MinimumWidth = 150;
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 150;
            // 
            // RawValue
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.RawValue.DefaultCellStyle = dataGridViewCellStyle4;
            this.RawValue.HeaderText = "Raw value";
            this.RawValue.MinimumWidth = 30;
            this.RawValue.Name = "RawValue";
            this.RawValue.ReadOnly = true;
            this.RawValue.Visible = false;
            this.RawValue.Width = 50;
            // 
            // Column8
            // 
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column8.DefaultCellStyle = dataGridViewCellStyle5;
            this.Column8.HeaderText = "Value";
            this.Column8.MinimumWidth = 150;
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 150;
            // 
            // Column9
            // 
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column9.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column9.HeaderText = "Min";
            this.Column9.MinimumWidth = 40;
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 50;
            // 
            // Column10
            // 
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Column10.DefaultCellStyle = dataGridViewCellStyle7;
            this.Column10.HeaderText = "Max";
            this.Column10.MinimumWidth = 40;
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 50;
            // 
            // SpyEng_Unit
            // 
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SpyEng_Unit.DefaultCellStyle = dataGridViewCellStyle8;
            this.SpyEng_Unit.HeaderText = "Unit";
            this.SpyEng_Unit.MinimumWidth = 20;
            this.SpyEng_Unit.Name = "SpyEng_Unit";
            this.SpyEng_Unit.ReadOnly = true;
            this.SpyEng_Unit.Width = 40;
            // 
            // Grid_Eng_Period
            // 
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Period.DefaultCellStyle = dataGridViewCellStyle9;
            this.Grid_Eng_Period.HeaderText = "Period";
            this.Grid_Eng_Period.Name = "Grid_Eng_Period";
            this.Grid_Eng_Period.ReadOnly = true;
            this.Grid_Eng_Period.Width = 50;
            // 
            // Grid_Eng_Start
            // 
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Start.DefaultCellStyle = dataGridViewCellStyle10;
            this.Grid_Eng_Start.HeaderText = "Start";
            this.Grid_Eng_Start.MinimumWidth = 40;
            this.Grid_Eng_Start.Name = "Grid_Eng_Start";
            this.Grid_Eng_Start.ReadOnly = true;
            this.Grid_Eng_Start.Width = 50;
            // 
            // Grid_Eng_Length
            // 
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Length.DefaultCellStyle = dataGridViewCellStyle11;
            this.Grid_Eng_Length.HeaderText = "Length";
            this.Grid_Eng_Length.MinimumWidth = 40;
            this.Grid_Eng_Length.Name = "Grid_Eng_Length";
            this.Grid_Eng_Length.ReadOnly = true;
            this.Grid_Eng_Length.Width = 50;
            // 
            // Grid_Eng_Endianess
            // 
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Endianess.DefaultCellStyle = dataGridViewCellStyle12;
            this.Grid_Eng_Endianess.HeaderText = "Endianess";
            this.Grid_Eng_Endianess.MinimumWidth = 40;
            this.Grid_Eng_Endianess.Name = "Grid_Eng_Endianess";
            this.Grid_Eng_Endianess.ReadOnly = true;
            this.Grid_Eng_Endianess.Width = 50;
            // 
            // Grid_Eng_Signed
            // 
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Signed.DefaultCellStyle = dataGridViewCellStyle13;
            this.Grid_Eng_Signed.HeaderText = "Signed";
            this.Grid_Eng_Signed.MinimumWidth = 40;
            this.Grid_Eng_Signed.Name = "Grid_Eng_Signed";
            this.Grid_Eng_Signed.ReadOnly = true;
            this.Grid_Eng_Signed.Width = 50;
            // 
            // Grid_Eng_Gain
            // 
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Gain.DefaultCellStyle = dataGridViewCellStyle14;
            this.Grid_Eng_Gain.HeaderText = "Gain";
            this.Grid_Eng_Gain.MinimumWidth = 40;
            this.Grid_Eng_Gain.Name = "Grid_Eng_Gain";
            this.Grid_Eng_Gain.ReadOnly = true;
            this.Grid_Eng_Gain.Width = 50;
            // 
            // Grid_Eng_Zero
            // 
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Zero.DefaultCellStyle = dataGridViewCellStyle15;
            this.Grid_Eng_Zero.HeaderText = "Zero";
            this.Grid_Eng_Zero.MinimumWidth = 40;
            this.Grid_Eng_Zero.Name = "Grid_Eng_Zero";
            this.Grid_Eng_Zero.ReadOnly = true;
            this.Grid_Eng_Zero.Width = 50;
            // 
            // Grid_Eng_Count
            // 
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_Count.DefaultCellStyle = dataGridViewCellStyle16;
            this.Grid_Eng_Count.HeaderText = "Count";
            this.Grid_Eng_Count.MinimumWidth = 40;
            this.Grid_Eng_Count.Name = "Grid_Eng_Count";
            this.Grid_Eng_Count.ReadOnly = true;
            this.Grid_Eng_Count.Width = 50;
            // 
            // Grid_Eng_DLC
            // 
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.Grid_Eng_DLC.DefaultCellStyle = dataGridViewCellStyle17;
            this.Grid_Eng_DLC.HeaderText = "DLC";
            this.Grid_Eng_DLC.MinimumWidth = 30;
            this.Grid_Eng_DLC.Name = "Grid_Eng_DLC";
            this.Grid_Eng_DLC.ReadOnly = true;
            this.Grid_Eng_DLC.Width = 40;
            // 
            // SpyEng_Comment
            // 
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.SpyEng_Comment.DefaultCellStyle = dataGridViewCellStyle18;
            this.SpyEng_Comment.HeaderText = "Comment";
            this.SpyEng_Comment.MinimumWidth = 20;
            this.SpyEng_Comment.Name = "SpyEng_Comment";
            this.SpyEng_Comment.ReadOnly = true;
            // 
            // Context_SpyEngGrid
            // 
            this.Context_SpyEngGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyEng_ResetTSMenuItem,
            this.toolStripSeparator1,
            this.ContextSpyEng_CollapseRowsTSMenuItem,
            this.ContextSpyEng_ExpandRowsTSMenuItem,
            this.toolStripSeparator2,
            this.ContextSpyEng_FilterTSMenuItem,
            this.toolStripMenuItem11,
            this.ContextSpyEng_columnsToolStripMenuItem});
            this.Context_SpyEngGrid.Name = "Context_SpyEngGrid";
            this.Context_SpyEngGrid.Size = new System.Drawing.Size(163, 132);
            // 
            // ContextSpyEng_ResetTSMenuItem
            // 
            this.ContextSpyEng_ResetTSMenuItem.Image = global::CANStream.Icones.Refresh_CAN_Controllers;
            this.ContextSpyEng_ResetTSMenuItem.Name = "ContextSpyEng_ResetTSMenuItem";
            this.ContextSpyEng_ResetTSMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ContextSpyEng_ResetTSMenuItem.Text = "Reset";
            this.ContextSpyEng_ResetTSMenuItem.Click += new System.EventHandler(this.ContextSpyEng_ResetTSMenuItemClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(159, 6);
            // 
            // ContextSpyEng_CollapseRowsTSMenuItem
            // 
            this.ContextSpyEng_CollapseRowsTSMenuItem.Image = global::CANStream.Icones.Collapse_16;
            this.ContextSpyEng_CollapseRowsTSMenuItem.Name = "ContextSpyEng_CollapseRowsTSMenuItem";
            this.ContextSpyEng_CollapseRowsTSMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ContextSpyEng_CollapseRowsTSMenuItem.Text = "Collapse all rows";
            this.ContextSpyEng_CollapseRowsTSMenuItem.Click += new System.EventHandler(this.ContextSpyEng_CollapseRowsTSMenuItem_Click);
            // 
            // ContextSpyEng_ExpandRowsTSMenuItem
            // 
            this.ContextSpyEng_ExpandRowsTSMenuItem.Image = global::CANStream.Icones.Expand_16;
            this.ContextSpyEng_ExpandRowsTSMenuItem.Name = "ContextSpyEng_ExpandRowsTSMenuItem";
            this.ContextSpyEng_ExpandRowsTSMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ContextSpyEng_ExpandRowsTSMenuItem.Text = "Expand all rows";
            this.ContextSpyEng_ExpandRowsTSMenuItem.Click += new System.EventHandler(this.ContextSpyEng_ExpandRowsTSMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(159, 6);
            // 
            // ContextSpyEng_FilterTSMenuItem
            // 
            this.ContextSpyEng_FilterTSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyEng_FiltetTSComboBox});
            this.ContextSpyEng_FilterTSMenuItem.Image = global::CANStream.Icones.Filter_16;
            this.ContextSpyEng_FilterTSMenuItem.Name = "ContextSpyEng_FilterTSMenuItem";
            this.ContextSpyEng_FilterTSMenuItem.Size = new System.Drawing.Size(162, 22);
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
            this.toolStripMenuItem11.Size = new System.Drawing.Size(159, 6);
            // 
            // ContextSpyEng_columnsToolStripMenuItem
            // 
            this.ContextSpyEng_columnsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ContextSpyEng_showAllToolStripMenuItem,
            this.ContextSpyEng_hideAllToolStripMenuItem,
            this.toolStripSeparator7,
            this.ContextSpyEng_iDToolStripMenuItem,
            this.ContextSpyEng_RxTxToolStripMenuItem,
            this.ContextSpyEng_valueToolStripMenuItem,
            this.ContextSpyEng_rawValueToolStripMenuItem,
            this.ContextSpyEng_minToolStripMenuItem,
            this.ContextSpyEng_maxToolStripMenuItem,
            this.ContextSpyEng_unitToolStripMenuItem,
            this.ContextSpyEng_periodToolStripMenuItem,
            this.ContextSpyEng_StartToolStripMenuItem,
            this.ContextSpyEng_LengthToolStripMenuItem,
            this.ContextSpyEng_EndianessToolStripMenuItem,
            this.ContextSpyEng_SignedToolStripMenuItem,
            this.ContextSpyEng_GainToolStripMenuItem,
            this.ContextSpyEng_ZeroToolStripMenuItem,
            this.ContextSpyEng_countToolStripMenuItem,
            this.ContextSpyEng_dlcToolStripMenuItem,
            this.ContextSpyEng_commentToolStripMenuItem});
            this.ContextSpyEng_columnsToolStripMenuItem.Image = global::CANStream.Icones.Columns_16;
            this.ContextSpyEng_columnsToolStripMenuItem.Name = "ContextSpyEng_columnsToolStripMenuItem";
            this.ContextSpyEng_columnsToolStripMenuItem.Size = new System.Drawing.Size(162, 22);
            this.ContextSpyEng_columnsToolStripMenuItem.Text = "Columns";
            // 
            // ContextSpyEng_showAllToolStripMenuItem
            // 
            this.ContextSpyEng_showAllToolStripMenuItem.Name = "ContextSpyEng_showAllToolStripMenuItem";
            this.ContextSpyEng_showAllToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_showAllToolStripMenuItem.Text = "Show All";
            this.ContextSpyEng_showAllToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_showAllToolStripMenuItemClick);
            // 
            // ContextSpyEng_hideAllToolStripMenuItem
            // 
            this.ContextSpyEng_hideAllToolStripMenuItem.Name = "ContextSpyEng_hideAllToolStripMenuItem";
            this.ContextSpyEng_hideAllToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_hideAllToolStripMenuItem.Text = "Hide All";
            this.ContextSpyEng_hideAllToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_hideAllToolStripMenuItemClick);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(130, 6);
            // 
            // ContextSpyEng_iDToolStripMenuItem
            // 
            this.ContextSpyEng_iDToolStripMenuItem.Name = "ContextSpyEng_iDToolStripMenuItem";
            this.ContextSpyEng_iDToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_iDToolStripMenuItem.Text = "ID";
            this.ContextSpyEng_iDToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_iDToolStripMenuItemClick);
            // 
            // ContextSpyEng_RxTxToolStripMenuItem
            // 
            this.ContextSpyEng_RxTxToolStripMenuItem.Name = "ContextSpyEng_RxTxToolStripMenuItem";
            this.ContextSpyEng_RxTxToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_RxTxToolStripMenuItem.Text = "RxTx";
            this.ContextSpyEng_RxTxToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_RxTxToolStripMenuItem_Click);
            // 
            // ContextSpyEng_valueToolStripMenuItem
            // 
            this.ContextSpyEng_valueToolStripMenuItem.Name = "ContextSpyEng_valueToolStripMenuItem";
            this.ContextSpyEng_valueToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_valueToolStripMenuItem.Text = "Value";
            this.ContextSpyEng_valueToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_valueToolStripMenuItemClick);
            // 
            // ContextSpyEng_rawValueToolStripMenuItem
            // 
            this.ContextSpyEng_rawValueToolStripMenuItem.Name = "ContextSpyEng_rawValueToolStripMenuItem";
            this.ContextSpyEng_rawValueToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_rawValueToolStripMenuItem.Text = "Raw value";
            this.ContextSpyEng_rawValueToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_rawValueToolStripMenuItemClick);
            // 
            // ContextSpyEng_minToolStripMenuItem
            // 
            this.ContextSpyEng_minToolStripMenuItem.Name = "ContextSpyEng_minToolStripMenuItem";
            this.ContextSpyEng_minToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_minToolStripMenuItem.Text = "Min";
            this.ContextSpyEng_minToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_minToolStripMenuItemClick);
            // 
            // ContextSpyEng_maxToolStripMenuItem
            // 
            this.ContextSpyEng_maxToolStripMenuItem.Name = "ContextSpyEng_maxToolStripMenuItem";
            this.ContextSpyEng_maxToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_maxToolStripMenuItem.Text = "Max";
            this.ContextSpyEng_maxToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_maxToolStripMenuItemClick);
            // 
            // ContextSpyEng_unitToolStripMenuItem
            // 
            this.ContextSpyEng_unitToolStripMenuItem.Name = "ContextSpyEng_unitToolStripMenuItem";
            this.ContextSpyEng_unitToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_unitToolStripMenuItem.Text = "Unit";
            this.ContextSpyEng_unitToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_unitToolStripMenuItemClick);
            // 
            // ContextSpyEng_periodToolStripMenuItem
            // 
            this.ContextSpyEng_periodToolStripMenuItem.Name = "ContextSpyEng_periodToolStripMenuItem";
            this.ContextSpyEng_periodToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_periodToolStripMenuItem.Text = "Period";
            this.ContextSpyEng_periodToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_periodToolStripMenuItem_Click);
            // 
            // ContextSpyEng_StartToolStripMenuItem
            // 
            this.ContextSpyEng_StartToolStripMenuItem.Name = "ContextSpyEng_StartToolStripMenuItem";
            this.ContextSpyEng_StartToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_StartToolStripMenuItem.Text = "Start";
            this.ContextSpyEng_StartToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_StartToolStripMenuItem_Click);
            // 
            // ContextSpyEng_LengthToolStripMenuItem
            // 
            this.ContextSpyEng_LengthToolStripMenuItem.Name = "ContextSpyEng_LengthToolStripMenuItem";
            this.ContextSpyEng_LengthToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_LengthToolStripMenuItem.Text = "Length";
            this.ContextSpyEng_LengthToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_LengthToolStripMenuItem_Click);
            // 
            // ContextSpyEng_EndianessToolStripMenuItem
            // 
            this.ContextSpyEng_EndianessToolStripMenuItem.Name = "ContextSpyEng_EndianessToolStripMenuItem";
            this.ContextSpyEng_EndianessToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_EndianessToolStripMenuItem.Text = "Endianess";
            this.ContextSpyEng_EndianessToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_EndianessToolStripMenuItem_Click);
            // 
            // ContextSpyEng_SignedToolStripMenuItem
            // 
            this.ContextSpyEng_SignedToolStripMenuItem.Name = "ContextSpyEng_SignedToolStripMenuItem";
            this.ContextSpyEng_SignedToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_SignedToolStripMenuItem.Text = "Signedness";
            this.ContextSpyEng_SignedToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_SignedToolStripMenuItem_Click);
            // 
            // ContextSpyEng_GainToolStripMenuItem
            // 
            this.ContextSpyEng_GainToolStripMenuItem.Name = "ContextSpyEng_GainToolStripMenuItem";
            this.ContextSpyEng_GainToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_GainToolStripMenuItem.Text = "Gain";
            this.ContextSpyEng_GainToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_GainToolStripMenuItem_Click);
            // 
            // ContextSpyEng_ZeroToolStripMenuItem
            // 
            this.ContextSpyEng_ZeroToolStripMenuItem.Name = "ContextSpyEng_ZeroToolStripMenuItem";
            this.ContextSpyEng_ZeroToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_ZeroToolStripMenuItem.Text = "Zero";
            this.ContextSpyEng_ZeroToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_ZeroToolStripMenuItem_Click);
            // 
            // ContextSpyEng_countToolStripMenuItem
            // 
            this.ContextSpyEng_countToolStripMenuItem.Name = "ContextSpyEng_countToolStripMenuItem";
            this.ContextSpyEng_countToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_countToolStripMenuItem.Text = "Count";
            this.ContextSpyEng_countToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_countToolStripMenuItem_Click);
            // 
            // ContextSpyEng_dlcToolStripMenuItem
            // 
            this.ContextSpyEng_dlcToolStripMenuItem.Name = "ContextSpyEng_dlcToolStripMenuItem";
            this.ContextSpyEng_dlcToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_dlcToolStripMenuItem.Text = "DLC";
            this.ContextSpyEng_dlcToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_dlcToolStripMenuItem_Click);
            // 
            // ContextSpyEng_commentToolStripMenuItem
            // 
            this.ContextSpyEng_commentToolStripMenuItem.Name = "ContextSpyEng_commentToolStripMenuItem";
            this.ContextSpyEng_commentToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.ContextSpyEng_commentToolStripMenuItem.Text = "Comment";
            this.ContextSpyEng_commentToolStripMenuItem.Click += new System.EventHandler(this.ContextSpyEng_commentToolStripMenuItemClick);
            // 
            // Lbl_GridTitle
            // 
            this.Lbl_GridTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_GridTitle.ForeColor = System.Drawing.Color.Blue;
            this.Lbl_GridTitle.Location = new System.Drawing.Point(0, 0);
            this.Lbl_GridTitle.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_GridTitle.Name = "Lbl_GridTitle";
            this.Lbl_GridTitle.Size = new System.Drawing.Size(100, 14);
            this.Lbl_GridTitle.TabIndex = 13;
            this.Lbl_GridTitle.Text = "Data Received";
            // 
            // Ctrl_CANDataGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lbl_GridTitle);
            this.Controls.Add(this.Grid_SpyEngineering);
            this.Name = "Ctrl_CANDataGrid";
            this.Size = new System.Drawing.Size(748, 318);
            this.Load += new System.EventHandler(this.Ctrl_CANDataGrid_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_SpyEngineering)).EndInit();
            this.Context_SpyEngGrid.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ToolStripComboBox ContextSpyEng_FiltetTSComboBox;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_FilterTSMenuItem;
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
		private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_ResetTSMenuItem;
        private System.Windows.Forms.ContextMenuStrip Context_SpyEngGrid;
        private System.Windows.Forms.DataGridView Grid_SpyEngineering;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_CollapseRowsTSMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_ExpandRowsTSMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_periodToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_countToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_dlcToolStripMenuItem;
        private System.Windows.Forms.Label Lbl_GridTitle;
        private System.Windows.Forms.DataGridViewImageColumn Grid_Eng_Collapse_State;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_RxTx;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn RawValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpyEng_Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Period;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Length;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Endianess;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Signed;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Gain;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Zero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Grid_Eng_DLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn SpyEng_Comment;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_RxTxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_StartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_LengthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_EndianessToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_SignedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_GainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContextSpyEng_ZeroToolStripMenuItem;
    }
}
