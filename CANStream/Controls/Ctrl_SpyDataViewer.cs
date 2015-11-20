/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 11/21/2014
 * Time: 4:40 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

//PCANBasic includes
using Peak.Can.Basic;
using TPCANHandle = System.Byte;

namespace CANStream
{
    #region Public enums

    public enum GridCANData_ColumnsEnum
    {
        None = 0x00000000,
        Column_ID = 0x00000001,
        Column_RxTx = 0x00000002,
        Column_Value = 0x00000004,
        Column_RawValue = 0x00000008,
        Column_Min = 0x00000010,
        Column_Max = 0x00000020,
        Column_Unit = 0x00000040,
        Column_Period = 0x00000080,
        Column_Start = 0x00000100,
        Column_Length = 0x00000200,
        Column_Endianess = 0x00000400,
        Column_Signedness = 0x00000800,
        Column_Gain = 0x00001000,
        Column_Zero = 0x00002000,
        Column_Count = 0x00004000,
        Column_DLC = 0x00008000,
        Column_Comment = 0x00010000,

        All = 0x0001FFFF, //Update value 'All' in case of change
        Default = (Column_Value | Column_Min | Column_Max | Column_Unit | Column_Comment),
    }

    public enum GridDataMode
    {
        DataRx = 0,
        DataTx = 1,
    }

    /// <summary>
    /// Grid row data type enumeration
    /// </summary>
    public enum GridRowDataType
    {
        None            = 0,    /// <summary>Grid row does not contain data</summary>
        RawData         = 1,    /// <summary>Grid row contains Raw CAN message data</summary>
        EngineeringData = 2,    /// <summary>Grid row contains Engineering CAN message data</summary>
        Multiplexer     = 3,    /// <summary>Grid row contains a CAN message multiplexer data</summary>
        RootGroup       = 4,    /// <summary>Grid row contains a CAN message multiplexer data</summary>
        VirtualData     = 5,    /// <summary>Grid row contains virtual channels data</summary>
        VirtualLibrary  = 6,    /// <summary>Grid row contains virtual channel library</summary>
        VirtualChannel  = 7,    /// <summary>Grid row contains virtual channel</summary>
    }

    /// <summary>
    /// Collapsable grid row state enumeration
    /// </summary>
    public enum GridRowCollapsedStatus
    {
        Collasped = 0,  /// <summary>Grid row is collapsed</summary>
        Expanded  = 1,  /// <summary>Grid row is extended</summary>
    }

    /// <summary>
    /// Grid items sorting mode enumeration
    /// </summary>
    public enum GridSortingMode
    {
        FrameId   = 0,          /// <summary>Grid items sorted by frame Id</summary>
        FrameName = 1,          /// <summary>Grid items sorted by frame name</summary>
        Default   = FrameName,  /// <summary>Defaut grid item sorting mode</summary>
    }

    /// <summary>
    /// Grid items sorting direction enumeration
    /// </summary>
    public enum GridSortingDirection
    {
        Ascending   = 0,            /// <summary>Ascending grid items sorting (from A to Z)</summary>
        Descending  = 1,            /// <summary>Descending grid items sorting (from Z to A)</summary>
        Default     = Ascending,    /// <summary>Default grid items sorting direction</summary>
    }

    #endregion

    /// <summary>
    /// Description of Ctrl_SpyDataViewer.
    /// </summary>
    public partial class Ctrl_CANDataGrid : UserControl
	{
        #region Private constants

        private const int GRID_SPYENG_COLLAPSE      = 0;
        private const int GRID_SPYENG_MSG_ID        = 1;
        private const int GRID_SPYENG_MSG_RXTX      = 2;
        private const int GRID_SPYENG_NAME          = 3;
        private const int GRID_SPYENG_RAW_VALUE     = 4;
        private const int GRID_SPYENG_ENG_VALUE     = 5;
        private const int GRID_SPYENG_MIN_VALUE     = 6;
        private const int GRID_SPYENG_MAX_VALUE     = 7;
        private const int GRID_SPYENG_UNIT          = 8;
        private const int GRID_SPYENG_PERIOD        = 9;
        private const int GRID_SPYENG_START         = 10;
        private const int GRID_SPYENG_LENGTH        = 11;
        private const int GRID_SPYENG_ENDIANESS     = 12;
        private const int GRID_SPYENG_SIGNEDNESS    = 13;
        private const int GRID_SPYENG_GAIN          = 14;
        private const int GRID_SPYENG_ZERO          = 15;
        private const int GRID_SPYENG_COUNT         = 16;
        private const int GRID_SPYENG_DLC           = 17;
        private const int GRID_SPYENG_COMMENT       = 18;

        private const int GRID_MAX_COL_WIDTH = 60;
		private const int GRID_ENG_SPY_FILLER_COL = GRID_SPYENG_COMMENT;	//Column 'Comment' 		
		
		#endregion
	    
		#region Public events
		
		[Category("Appearance"), Browsable(true), Description("Occurs when a column of the engineering data grid column is hidden or shown")]
		public event EventHandler<GridColVisibleChangedEventArgs> GridColumnsVisibleChanged;

        [Category("Appearance"), Browsable(true), Description("Occurs when the CAN data grid is reset")]
        public event EventHandler<EventArgs> GridDataReseted;

        [Category("Action"), Browsable(true), Description("Occurs when content a Tx CAN parameter value is changed")]
        public event EventHandler<GridTxParameterValueChangedEventArgs> GridTxParameterValueChanged;

        #endregion

        #region Control properties

        [Category("Appearance"), Browsable(true), Description("Data grid columns visible")]
		public GridCANData_ColumnsEnum eGridColumnsVisible
		{
			get
			{
				return this.SpyEngGridColumnsVisible;
			}
			
			set
			{
				Set_SpyEngGridColumnsVisible(value);
			}
		}

        [Category("Appearance"), Browsable(true), Description("Set false to hide virtual channels grid row")]
        public bool VirtualChannelsVisible
        {
            get
            {
                return this.bVirtualChannelsRowVisible;
            }

            set
            {
                ShowHide_VirtualChannel(value);
            }
        }

        [Category("Data"), Browsable(true), Description("Data Rx/Tx mode grid")]
        public GridDataMode DataMode { get; set; }

        #endregion

        #region Private members

        private GridCANData_ColumnsEnum SpyEngGridColumnsVisible;
        private GridSortingMode eItemsSortingMode;
        private GridSortingDirection eItemsSortingDirection;
        
        private int VirtualChannelsRowIndex;
        private bool bVirtualChannelsRowVisible;

        private bool bCellValueChangedEventEnabled;

		#endregion
		
		public Ctrl_CANDataGrid()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			eGridColumnsVisible = GridCANData_ColumnsEnum.Default;
            eItemsSortingMode = GridSortingMode.Default;
            eItemsSortingDirection = GridSortingDirection.Default;

            VirtualChannelsRowIndex = -1;
            ShowHide_VirtualChannel(true);

            bCellValueChangedEventEnabled = true;
        }

        #region Control events

        private void Ctrl_CANDataGrid_Load(object sender, EventArgs e)
        {
            if (DataMode == GridDataMode.DataTx)
            {
                this.Grid_SpyEngineering.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_SpyEngineering_CellValueChanged);

                Lbl_GridTitle.Text = "Data Transmitted";
                Lbl_GridTitle.ForeColor = Color.Red;
            }
        }

        #region Context_SpyEngGrid

        private void ContextSpyEng_ResetTSMenuItemClick(object sender, EventArgs e)
		{
            Clear_EngGrid();
		}
		
        private void ContextSpyEng_CollapseRowsTSMenuItem_Click(object sender, EventArgs e)
        {
            Collapse_AllRows();
        }

        private void ContextSpyEng_ExpandRowsTSMenuItem_Click(object sender, EventArgs e)
        {
            Expand_AllRows();
        }

		private void ContextSpyEng_FiltetTSComboBoxKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Enter))
			{
				if (!(ContextSpyEng_FiltetTSComboBox.Text.Equals("")))
				{
					if (!(ContextSpyEng_FiltetTSComboBox.Items.Contains(ContextSpyEng_FiltetTSComboBox.Text)))
					{
						//FIFO
						if (ContextSpyEng_FiltetTSComboBox.Items.Count == 10)
						{
							ContextSpyEng_FiltetTSComboBox.Items.RemoveAt(9);
						}
						
						ContextSpyEng_FiltetTSComboBox.Items.Insert(0, ContextSpyEng_FiltetTSComboBox.Text);
					}
				}

                Filter_GridRows(ContextSpyEng_FiltetTSComboBox.Text);
			}
		}
		
		private void ContextSpyEng_FiltetTSComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
            Filter_GridRows(ContextSpyEng_FiltetTSComboBox.Text);
		}
		
		#region Columns

		private void ContextSpyEng_showAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			Set_SpyEngGridColumnsVisible(GridCANData_ColumnsEnum.All);
		}
		
		private void ContextSpyEng_hideAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			Set_SpyEngGridColumnsVisible(GridCANData_ColumnsEnum.None);
		}
		
		private void ContextSpyEng_iDToolStripMenuItemClick(object sender, EventArgs e)
		{
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_ID);
        }

        private void ContextSpyEng_RxTxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RxTx);
        }

        private void ContextSpyEng_valueToolStripMenuItemClick(object sender, EventArgs e)
		{
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Value);
        }
		
		private void ContextSpyEng_rawValueToolStripMenuItemClick(object sender, EventArgs e)
		{
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RawValue);
        }
		
		private void ContextSpyEng_minToolStripMenuItemClick(object sender, EventArgs e)
		{
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Min);
        }
		
		private void ContextSpyEng_maxToolStripMenuItemClick(object sender, EventArgs e)
		{
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Max);
        }
		
		private void ContextSpyEng_unitToolStripMenuItemClick(object sender, EventArgs e)
		{
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Unit);
        }

        private void ContextSpyEng_periodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Period);
        }

        private void ContextSpyEng_StartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Start);
        }

        private void ContextSpyEng_LengthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Length);
        }

        private void ContextSpyEng_EndianessToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Endianess);
        }

        private void ContextSpyEng_SignedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Signedness);
        }

        private void ContextSpyEng_GainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Gain);
        }

        private void ContextSpyEng_ZeroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Zero);
        }

        private void ContextSpyEng_countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Count);
        }

        private void ContextSpyEng_dlcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_DLC);
        }

		private void ContextSpyEng_commentToolStripMenuItemClick(object sender, EventArgs e)
		{
            ContexSpyGridColumnsChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Comment);
        }

        #endregion

        #endregion

        #region Grid_SpyEngineering

        private void Grid_SpyEngineering_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == GRID_SPYENG_ENG_VALUE && e.RowIndex >= 0 && bCellValueChangedEventEnabled)
            {
                bCellValueChangedEventEnabled = false;

                DataGridViewCell oCurrentCell = Grid_SpyEngineering.Rows[e.RowIndex].Cells[e.ColumnIndex];

                if (!(oCurrentCell.Tag == null))
                {
                    CANParameter oParam = (CANParameter)oCurrentCell.Tag;

                    double EngVal = oParam.ValueFormat.SetSignalFormatedValue(oCurrentCell.Value.ToString());

                    if (!(double.IsNaN(EngVal)))
                    {
                        if (oParam.DecodedValue != EngVal)
                        {
                            oParam.DecodedValue = EngVal;

                            Nullable<SignalAlarmValue> sAlarm = oParam.Alarms.GetAlarmProperties(oParam.Alarms.ProcessAlarms(EngVal));

                            if (sAlarm.HasValue)
                            {
                                oCurrentCell.Style.BackColor = sAlarm.Value.BackColor;
                                oCurrentCell.Style.ForeColor = sAlarm.Value.ForeColor;
                            }
                            else
                            {
                                oCurrentCell.Style.BackColor = Grid_SpyEngineering.Rows[e.RowIndex].Cells[GRID_SPYENG_NAME].Style.BackColor;
                                oCurrentCell.Style.ForeColor = Grid_SpyEngineering.Rows[e.RowIndex].Cells[GRID_SPYENG_NAME].Style.ForeColor;
                            }

                            DataGridViewRow oMsgRow = ((CollapsableGridRowProperties)Grid_SpyEngineering.Rows[e.RowIndex].Tag).GetRootRow();
                            CANMessageEncoded oMsgEncoder = (CANMessageEncoded)oMsgRow.Cells[GRID_SPYENG_ENG_VALUE].Tag;
                            //CANMessageEncoded oMsgEncoder = (CANMessageEncoded)((((CollapsableGridRowProperties)Grid_SpyEngineering.Rows[e.RowIndex].Tag).GetRootRow()).Cells[GRID_SPYENG_ENG_VALUE].Tag);
                            oMsgEncoder.EncodeMessage();

                            Grid_SpyEngineering.Rows[e.RowIndex].Cells[GRID_SPYENG_RAW_VALUE].Value = oParam.RawValue;
                            oMsgRow.Cells[GRID_SPYENG_ENG_VALUE].Value = oMsgEncoder.GetMessageBytesString();

                            //GridTxParameterValueChanged event firing
                            GridTxParameterValueChangedEventArgs EvtArg = new GridTxParameterValueChangedEventArgs();

                            EvtArg.MessageId = oMsgEncoder.uMessageId;
                            EvtArg.ParameterName = oParam.Name;
                            EvtArg.ParameterValue = oParam.DecodedValue;
                            EvtArg.MultiplexerValue = oParam.MultiplexerValue;

                            OnGridTxParameterValueChanged(EvtArg);
                        }
                    }
                    else
                    {
                        MessageBox.Show(oParam.Name + " formating error !\nCheck value format properties.",
                                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    oCurrentCell.Value = oParam.ValueFormat.GetSignalFormatedValue(oParam.DecodedValue);
                }

                bCellValueChangedEventEnabled = true;
            }
        }

        private void Grid_SpyEngineeringSizeChanged(object sender, EventArgs e)
		{
			ResizeGridColumns(Grid_SpyEngineering, GRID_ENG_SPY_FILLER_COL);
		}

        private void Grid_SpyEngineering_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex== GRID_SPYENG_COLLAPSE)
            {
                CollapsableGridRowProperties oRowCollaspeProps = Grid_SpyEngineering.Rows[e.RowIndex].Tag as CollapsableGridRowProperties;

                if (oRowCollaspeProps.State == GridRowCollapsedStatus.Collasped)
                {
                    oRowCollaspeProps.ExpandChildren();
                }
                else
                {
                    oRowCollaspeProps.CollapseChildren();
                }
            }
        }

        #endregion

        #endregion

        #region Private methods

        private void ResizeGridColumns(DataGridView oGrid, int FillerColumn)
		{
			int ColCnt = GetGridColumnsVisibleCount(oGrid);
        	
			int ColWidth = (int)(oGrid.Width / ColCnt);
			if (ColWidth > GRID_MAX_COL_WIDTH) ColWidth = GRID_MAX_COL_WIDTH;
			
        	int TotalWidth = 0;
        	
        	foreach (DataGridViewColumn oCol in oGrid.Columns)
        	{
                if (oCol.Visible && oCol.Index > 0)
                {
                    if (TotalWidth + ColWidth >= oGrid.Width - 5)
                    {
                        ColWidth = oGrid.Width - TotalWidth - 5;
                    }

                    oCol.Width = ColWidth;
                    TotalWidth += oCol.Width; //May be different to ColWidth since 'minimum width' property of each column has been set
                }
        	}
        	
        	if (TotalWidth < oGrid.Width - 5)
        	{
        		oGrid.Columns[FillerColumn].Width += (oGrid.Width - TotalWidth - 5);
        	}
		}
		
		private int GetGridColumnsVisibleCount(DataGridView oGrid)
		{
			int ColVisible = 0;
			
			foreach (DataGridViewColumn oCol in oGrid.Columns)
			{
				if (oCol.Visible)
				{
					ColVisible++;
				}
			}
			
			return(ColVisible);
		}
		
        private void ContexSpyGridColumnsChanged(ToolStripMenuItem oMenuItem, GridCANData_ColumnsEnum eColumn)
        {
            oMenuItem.Checked = !oMenuItem.Checked;

            if(oMenuItem.Checked)
            {
                Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | eColumn);
            }
            else
            {
                Set_SpyEngGridColumnsVisible((GridCANData_ColumnsEnum)(SpyEngGridColumnsVisible - eColumn));
            }

        }

		private void Set_SpyEngGridColumnsVisible(GridCANData_ColumnsEnum eColumnsVisible)
		{
			SpyEngGridColumnsVisible = eColumnsVisible;

            Grid_SpyEngineering.Columns[GRID_SPYENG_MSG_ID].Visible     = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_ID);
            Grid_SpyEngineering.Columns[GRID_SPYENG_MSG_RXTX].Visible   = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_RxTx);
            Grid_SpyEngineering.Columns[GRID_SPYENG_RAW_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_RawValue);
            Grid_SpyEngineering.Columns[GRID_SPYENG_ENG_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Value);
            Grid_SpyEngineering.Columns[GRID_SPYENG_MIN_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Min);
            Grid_SpyEngineering.Columns[GRID_SPYENG_MAX_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Max);
            Grid_SpyEngineering.Columns[GRID_SPYENG_UNIT].Visible       = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Unit);
            Grid_SpyEngineering.Columns[GRID_SPYENG_PERIOD].Visible     = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Period);
            Grid_SpyEngineering.Columns[GRID_SPYENG_START].Visible      = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Start);
            Grid_SpyEngineering.Columns[GRID_SPYENG_LENGTH].Visible     = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Length);
            Grid_SpyEngineering.Columns[GRID_SPYENG_ENDIANESS].Visible  = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Endianess);
            Grid_SpyEngineering.Columns[GRID_SPYENG_SIGNEDNESS].Visible = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Signedness);
            Grid_SpyEngineering.Columns[GRID_SPYENG_GAIN].Visible       = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Gain);
            Grid_SpyEngineering.Columns[GRID_SPYENG_ZERO].Visible       = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Zero);
            Grid_SpyEngineering.Columns[GRID_SPYENG_COUNT].Visible      = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Count);
            Grid_SpyEngineering.Columns[GRID_SPYENG_DLC].Visible        = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_DLC);
            Grid_SpyEngineering.Columns[GRID_SPYENG_COMMENT].Visible    = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Comment);
			
			ResizeGridColumns(Grid_SpyEngineering, GRID_ENG_SPY_FILLER_COL);
			
			ContextSpyEng_iDToolStripMenuItem.Checked           = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_ID);
            ContextSpyEng_RxTxToolStripMenuItem.Checked         = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_RxTx);
            ContextSpyEng_valueToolStripMenuItem.Checked        = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Value);
			ContextSpyEng_rawValueToolStripMenuItem.Checked     = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_RawValue);
			ContextSpyEng_minToolStripMenuItem.Checked          = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Min);
			ContextSpyEng_maxToolStripMenuItem.Checked          = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Max);
			ContextSpyEng_unitToolStripMenuItem.Checked         = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Unit);
            ContextSpyEng_periodToolStripMenuItem.Checked       = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Period);
            ContextSpyEng_StartToolStripMenuItem.Checked        = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Start);
            ContextSpyEng_LengthToolStripMenuItem.Checked       = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Length);
            ContextSpyEng_EndianessToolStripMenuItem.Checked    = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Endianess);
            ContextSpyEng_SignedToolStripMenuItem.Checked       = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Signedness);
            ContextSpyEng_GainToolStripMenuItem.Checked         = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Gain);
            ContextSpyEng_ZeroToolStripMenuItem.Checked         = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Zero);
            ContextSpyEng_countToolStripMenuItem.Checked        = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Count);
            ContextSpyEng_dlcToolStripMenuItem.Checked          = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_DLC);
			ContextSpyEng_commentToolStripMenuItem.Checked      = SpyEngGridColumnsVisible.HasFlag(GridCANData_ColumnsEnum.Column_Comment);
			
			//Event EngGridColumnsVisibleChanged firing
			GridColVisibleChangedEventArgs Arg = new GridColVisibleChangedEventArgs();
			Arg.ColumnsVisible = SpyEngGridColumnsVisible;
			OnEngGridColumnsVisibleChanged(Arg);
		}

        #region Collapsable grid functions

        private DataGridViewRow Add_RawDataRow(CANMessage oMessage, int MessageLen)
        {
            //TODO: remove 'MessageLen' arg and use the DLC property of the CAN message instead when it will be available
            return (Add_RawDataRow(oMessage.Identifier, MessageLen.ToString(), oMessage.Name, oMessage.RxTx.ToString(), oMessage.Period.ToString(), oMessage.Comment));
        }

        private DataGridViewRow Add_RawDataRow(MessageStatus oRawMsg)
        {
            return (Add_RawDataRow(oRawMsg.IdString, oRawMsg.CANMsg.LEN.ToString(), "", "", "", ""));
        }

        private DataGridViewRow Add_RawDataRow(string MsgId, string MsgLen, string MsgName, string MsgRxTx, string MsgPeriod, string MsgComment)
        {
            //Add the row to the grid
            Grid_SpyEngineering.Rows.Add();
            DataGridViewRow oRow = Grid_SpyEngineering.Rows[Grid_SpyEngineering.Rows.Count - 1];

            //Fill fixed data
            oRow.Cells[GRID_SPYENG_COLLAPSE].Value = Icones.Grid_Collapse;
            oRow.Cells[GRID_SPYENG_MSG_ID].Value = MsgId;
            oRow.Cells[GRID_SPYENG_MSG_RXTX].Value = MsgRxTx;
            oRow.Cells[GRID_SPYENG_NAME].Value = MsgName;
            oRow.Cells[GRID_SPYENG_PERIOD].Value = MsgPeriod;
            oRow.Cells[GRID_SPYENG_DLC].Value = MsgLen;
            oRow.Cells[GRID_SPYENG_COMMENT].Value = MsgComment;

            //Color row
            Color_GridRow(oRow, Color.DarkBlue, Color.White);

            //Collapsing properties creation
            CollapsableGridRowProperties oColapsProps = new CollapsableGridRowProperties();

            oColapsProps.Row = oRow;
            oColapsProps.Parent = null;
            oColapsProps.RowDataType = GridRowDataType.RawData;
            oColapsProps.State = GridRowCollapsedStatus.Expanded;

            oRow.Tag = oColapsProps;

            //Create engineering data root group
            Grid_SpyEngineering.Rows.Add();
            DataGridViewRow oRootGrpRow = Grid_SpyEngineering.Rows[Grid_SpyEngineering.Rows.Count - 1];

            oRootGrpRow.Cells[GRID_SPYENG_ENG_VALUE].Value = "";
            oRootGrpRow.Visible = false;

            //Collapsing properties creation
            CollapsableGridRowProperties oRootColapsProps = new CollapsableGridRowProperties();

            oRootColapsProps.Row = oRootGrpRow;
            oRootColapsProps.Parent = oRow;
            oRootColapsProps.RowDataType = GridRowDataType.RootGroup;
            oRootColapsProps.State = GridRowCollapsedStatus.Expanded;

            oRootGrpRow.Tag = oRootColapsProps;
            oColapsProps.Children.Add(oRootGrpRow);

            return (oRow);
        }

        private DataGridViewRow Get_RawDataRow(string MsgId)
        {
            foreach (DataGridViewRow oRow in Grid_SpyEngineering.Rows)
            {
                if (((CollapsableGridRowProperties)oRow.Tag).RowDataType.Equals(GridRowDataType.RawData))
                {
                    if (oRow.Cells[GRID_SPYENG_MSG_ID].Value.ToString().Equals(MsgId)) //Message ID comparison
                    {
                        return (oRow);
                    }
                }
            }

            return (null);
        }

        private DataGridViewRow Add_MultiplexerRow(DataGridViewRow ParentRow, string MuxName, long MuxValue)
        {
            //Add the row to the grid
            Grid_SpyEngineering.Rows.Add();
            DataGridViewRow oRow = Grid_SpyEngineering.Rows[Grid_SpyEngineering.Rows.Count - 1];

            //Fill fixed data
            oRow.Cells[GRID_SPYENG_COLLAPSE].Value = Icones.Grid_Collapse;
            oRow.Cells[GRID_SPYENG_NAME].Value = MuxName;
            oRow.Cells[GRID_SPYENG_ENG_VALUE].Value = MuxValue.ToString();

            //Color row
            Color_GridRow(oRow, Color.Blue, Color.White);

            //Collapsing properties creation
            CollapsableGridRowProperties oColapsProps = new CollapsableGridRowProperties();

            oColapsProps.Row = oRow;
            oColapsProps.Parent = ParentRow;
            oColapsProps.RowDataType = GridRowDataType.Multiplexer;
            oColapsProps.State = GridRowCollapsedStatus.Expanded;

            oRow.Tag = oColapsProps;
            ((CollapsableGridRowProperties)ParentRow.Tag).Children.Add(oRow);

            return (oRow);
        }

        private DataGridViewRow Add_EngDataRow(DataGridViewRow ParentRow, CANParameter oEngParam)
        {
            return(Add_EngDataRow(ParentRow, oEngParam, -1));
        }

        private DataGridViewRow Add_EngDataRow(DataGridViewRow ParentRow, CANParameter oEngParam, int Index)
        {
            //Add the row to the grid
            DataGridViewRow oRow = null;
            
            if (Index == -1)
            {
                Grid_SpyEngineering.Rows.Add();
                oRow = Grid_SpyEngineering.Rows[Grid_SpyEngineering.Rows.Count - 1];
            }
            else
            {
                Grid_SpyEngineering.Rows.Insert(Index, 1);
                oRow = Grid_SpyEngineering.Rows[Index];
            }

            //Fill fixed data
            oRow.Cells[GRID_SPYENG_COLLAPSE].Value = Icones.Grid_NoAction2;
            oRow.Cells[GRID_SPYENG_NAME].Value = oEngParam.Name;
            oRow.Cells[GRID_SPYENG_UNIT].Value = oEngParam.Unit;
            oRow.Cells[GRID_SPYENG_START].Value = oEngParam.StartBit.ToString();
            oRow.Cells[GRID_SPYENG_LENGTH].Value = oEngParam.Length.ToString();
            oRow.Cells[GRID_SPYENG_ENDIANESS].Value = oEngParam.Endianess.ToString();
            oRow.Cells[GRID_SPYENG_GAIN].Value = oEngParam.Gain.ToString();
            oRow.Cells[GRID_SPYENG_ZERO].Value = oEngParam.Zero.ToString();
            oRow.Cells[GRID_SPYENG_COMMENT].Value = oEngParam.Comment;

            if (oEngParam.Signed)   oRow.Cells[GRID_SPYENG_SIGNEDNESS].Value = "Yes";
            else                    oRow.Cells[GRID_SPYENG_SIGNEDNESS].Value = "No";

            //Init Min/Max cellse
            oRow.Cells[GRID_SPYENG_MIN_VALUE].Tag = oEngParam.DecodedValue;
            oRow.Cells[GRID_SPYENG_MAX_VALUE].Tag = oEngParam.DecodedValue;

            //Color row
            if (((CollapsableGridRowProperties)ParentRow.Tag).Children.Count % 2 == 0)
            {
                Color_GridRow(oRow, Color.LightBlue, Color.Empty);
            }
            
            //Collapsing properties creation
            CollapsableGridRowProperties oColapsProps = new CollapsableGridRowProperties();

            oColapsProps.Row = oRow;
            oColapsProps.Parent = ParentRow;
            oColapsProps.RowDataType = GridRowDataType.EngineeringData;
            oColapsProps.State = GridRowCollapsedStatus.Collasped;

            oRow.Tag = oColapsProps;
            ((CollapsableGridRowProperties)ParentRow.Tag).Children.Add(oRow);

            return (oRow);
        }

        private void Color_GridRow(DataGridViewRow oRow, Color BackColor, Color ForeColor)
        {
            foreach (DataGridViewCell oCell in oRow.Cells)
            {
                if (oCell.ColumnIndex != GRID_SPYENG_COLLAPSE)
                {
                    if (BackColor != Color.Empty) oCell.Style.BackColor = BackColor;
                    if (ForeColor != Color.Empty) oCell.Style.ForeColor = ForeColor;
                }
            }
        }

        private void Collapse_AllRows()
        {
            foreach (DataGridViewRow oRow in Grid_SpyEngineering.Rows)
            {
                if (oRow.Visible)
                {
                    CollapsableGridRowProperties oRowCollaspeProps = (CollapsableGridRowProperties)oRow.Tag;

                    if (!(oRowCollaspeProps == null))
                    {
                        oRowCollaspeProps.CollapseChildren();
                    }
                }
            }
        }

        private void Expand_AllRows()
        {
            foreach (DataGridViewRow oRow in Grid_SpyEngineering.Rows)
            {
                if (oRow.Visible)
                {
                    CollapsableGridRowProperties oRowCollaspeProps = (CollapsableGridRowProperties)oRow.Tag;

                    if (!(oRowCollaspeProps == null))
                    {
                        oRowCollaspeProps.ExpandChildren();
                    }
                }
            }
        }

        private void Filter_GridRows(string sFilter)
        {
            //Filter real CAN data rows
            foreach (DataGridViewRow oRow in Grid_SpyEngineering.Rows)
            {
                CollapsableGridRowProperties oRowProps = (CollapsableGridRowProperties)oRow.Tag;

                if (!(sFilter.Equals(""))) //Filter empty ?
                {
                    if (oRowProps.RowDataType == GridRowDataType.RawData)
                    {
                        //Does the row 'Name' cell contain the string that we are looking for ?
                        if (oRow.Cells[GRID_SPYENG_NAME].Value.ToString().ToLower().Contains(sFilter.ToLower()))
                        {
                            //Yes
                            oRowProps.SetRowVisibility(true);
                        }
                        else
                        {
                            //No! Are some of children rows visible ?
                            if (oRowProps.Children.Count > 0)
                            {
                                if (Filter_GridChildrenRow(oRowProps.Children, sFilter) == 0)
                                {
                                    oRowProps.SetRowVisibility(false); //Current row does not have any visible children
                                }
                                else
                                {
                                    oRowProps.SetRowVisibility(true); //Current row does have at least one visible children
                                }
                            }
                            else
                            {
                                oRowProps.SetRowVisibility(false);
                            }
                        }
                    }
                }
                else
                {
                    //Filter is empty, all rows visible except raw CAN data root group rows

                    if (!(oRowProps.RowDataType == GridRowDataType.RootGroup)) //Root group row of raw CAN data is never visible
                    {
                        oRowProps.SetRowVisibility(true);
                    }
                }
            }

            //Filter virtual channels rows
            if (VirtualChannelsRowIndex != -1)
            {
                CollapsableGridRowProperties oRowProps = (CollapsableGridRowProperties)Grid_SpyEngineering.Rows[VirtualChannelsRowIndex].Tag;

                if (!(sFilter.Equals("")))
                {
                    if (Filter_GridChildrenRow(oRowProps.Children, sFilter) == 0)
                    {
                        oRowProps.SetRowVisibility(false);
                    }
                    else
                    {
                        oRowProps.SetRowVisibility(true);
                    }
                }
                else
                {
                    oRowProps.SetRowVisibility(true);
                    oRowProps.ExpandChildren();
                }
            }
        }

        private int Filter_GridChildrenRow(List<DataGridViewRow> ChildrenRows, string sFilter)
        {
            int VisibleRowsCnt = 0;

            foreach (DataGridViewRow oRow in ChildrenRows)
            {
                CollapsableGridRowProperties oRowProps = (CollapsableGridRowProperties)oRow.Tag;

                string RowName = "";
                
                if (!(oRowProps.RowDataType == GridRowDataType.RootGroup))
                {
                    RowName = oRow.Cells[GRID_SPYENG_NAME].Value.ToString().ToLower();
                }

                //Does the row 'Name' cell contain the string that we are looking for ?
                if (RowName.Contains(sFilter.ToLower()))
                {
                    //Yes
                    oRowProps.SetRowVisibility(true);
                    VisibleRowsCnt++;
                }
                else
                {
                    //No! Are some of children rows visible ?
                    if (oRowProps.Children.Count > 0)
                    {
                        int ChildrenVisible = Filter_GridChildrenRow(oRowProps.Children, sFilter);

                        if (ChildrenVisible > 0)
                        {
                            //Curent row has at least one visible children
                            if (!(oRowProps.RowDataType == GridRowDataType.RootGroup)) oRowProps.SetRowVisibility(true);
                            VisibleRowsCnt += ChildrenVisible;
                        }
                        else
                        {
                            //Curent row doesn't have any visible children
                            oRowProps.SetRowVisibility(false);
                        }
                    }
                    else
                    {
                        oRowProps.SetRowVisibility(false);
                    }
                }
                
            }

            return (VisibleRowsCnt);
        }

        private void Sort_GridItems()
        {
            if (Grid_SpyEngineering.Rows.Count > 0)
            {
                int iSortKey = -1;

                switch (eItemsSortingMode)
                {
                    case GridSortingMode.FrameId:

                        iSortKey = GRID_SPYENG_MSG_ID;
                        break;

                    case GridSortingMode.FrameName:

                        iSortKey = GRID_SPYENG_NAME;
                        break;
                }
                
                List<DataGridViewRow> BaseRowsList = new List<DataGridViewRow>();
                List<DataGridViewRow> SortedRowsList = new List<DataGridViewRow>();

                foreach (DataGridViewRow oRow in Grid_SpyEngineering.Rows)
                {
                    if (((CollapsableGridRowProperties)oRow.Tag).RowDataType == GridRowDataType.RawData)
                    {
                        BaseRowsList.Add(oRow);
                    }
                }

                List<string> RowsNameList = new List<string>();

                foreach (DataGridViewRow oRow in BaseRowsList)
                {
                    RowsNameList.Add(oRow.Cells[iSortKey].Value.ToString());
                }

                RowsNameList.Sort();

                if (eItemsSortingDirection == GridSortingDirection.Descending)
                {
                    RowsNameList.Reverse();
                }

                SortedRowsList = new List<DataGridViewRow>();

                foreach (string Name in RowsNameList)
                {
                    for (int i = 0; i < BaseRowsList.Count; i++)
                    {
                        if (BaseRowsList[i].Cells[iSortKey].Value.ToString().Equals(Name))
                        {
                            SortedRowsList.Add(BaseRowsList[i]);
                            BaseRowsList.RemoveAt(i);
                        }
                    }
                }
            }
        }

        private void ShowHide_VirtualChannel(bool bVisible)
        {
            bVirtualChannelsRowVisible = bVisible;

            if (VirtualChannelsRowIndex != -1)
            {
                CollapsableGridRowProperties oVirtualChanRowProps = (CollapsableGridRowProperties)Grid_SpyEngineering.Rows[VirtualChannelsRowIndex].Tag;

                if (!(oVirtualChanRowProps == null))
                {
                    if (bVirtualChannelsRowVisible)
                    {
                        oVirtualChanRowProps.SetRowVisibility(true);
                        oVirtualChanRowProps.ExpandChildren();
                    }
                    else
                    {
                        oVirtualChanRowProps.CollapseChildren();
                        oVirtualChanRowProps.SetRowVisibility(false);
                    }
                }
            }
        }

        #endregion

        #endregion

        #region Public methods

        #region Data Tx grid methodes

        public void Add_TxMessage(CANMessageEncoded oMsgEncoder, int MsgLen)
        {
            //TODO: Remove 'MsgLen' prop and use the DLC property of the CAN message instead when it will be availble

            if (!(oMsgEncoder == null))
            {
                bCellValueChangedEventEnabled = false;

                DataGridViewRow oMsgRow = Add_RawDataRow(oMsgEncoder, MsgLen);
                CollapsableGridRowProperties oMsgRowProps = (CollapsableGridRowProperties)oMsgRow.Tag;

                oMsgRow.Cells[GRID_SPYENG_ENG_VALUE].Tag = oMsgEncoder;
                oMsgEncoder.EncodeMessage();

                oMsgRow.Cells[GRID_SPYENG_ENG_VALUE].Value = oMsgEncoder.GetMessageBytesString();

                foreach (CANParameter oParam in oMsgEncoder.Parameters)
                {
                    DataGridViewRow oParamRow = null;

                    if (oParam.IsMultiplexed)
                    {
                        //Get multiplexer row
                        DataGridViewRow oMuxRow = null;

                        foreach(DataGridViewRow oChildRow in oMsgRowProps.Children)
                        {
                            if (((CollapsableGridRowProperties)oChildRow.Tag).RowDataType == GridRowDataType.Multiplexer)
                            {
                                if ((oChildRow.Cells[GRID_SPYENG_NAME].Value.ToString().Equals(oMsgEncoder.MultiplexerName))
                                        && (oChildRow.Cells[GRID_SPYENG_ENG_VALUE].Value.ToString().Equals(oParam.MultiplexerValue.ToString())))
                                {
                                    oMuxRow = oChildRow;
                                    break;
                                }
                            }
                        }

                        //Create multiplexer row if it doesn't exist
                        if (oMuxRow == null)
                        {
                            oMuxRow = Add_MultiplexerRow(oMsgRow, oMsgEncoder.MultiplexerName, oParam.MultiplexerValue);
                        }

                        int RowIndex = oMuxRow.Index + ((CollapsableGridRowProperties)oMuxRow.Tag).Children.Count + 1;

                        oParamRow = Add_EngDataRow(oMuxRow, oParam, RowIndex);
                    }
                    else //CAN Parameter is not multiplexed
                    {
                        int RowIndex = oMsgRowProps.Children[0].Index + ((CollapsableGridRowProperties)oMsgRowProps.Children[0].Tag).Children.Count + 1;
                        oParamRow = Add_EngDataRow(oMsgRowProps.Children[0], oParam, RowIndex);
                    }

                    if (oParam.IsVirtual)
                    {
                        Color_GridRow(oParamRow, Color.LightGreen, Color.Black);
                    }
                    else
                    {
                        oParamRow.Cells[GRID_SPYENG_ENG_VALUE].ReadOnly = false;
                    }

                    //Set Tx parameter min/max
                    double[] ParamMinMax = oParam.GetParameterMinMax();
                    oParamRow.Cells[GRID_SPYENG_MIN_VALUE].Value = ParamMinMax[0].ToString();
                    oParamRow.Cells[GRID_SPYENG_MAX_VALUE].Value = ParamMinMax[1].ToString();

                    //Set parameter formated and row values
                    oParamRow.Cells[GRID_SPYENG_RAW_VALUE].Value = oParam.RawValue;
                    oParamRow.Cells[GRID_SPYENG_ENG_VALUE].Value = oParam.ValueFormat.GetSignalFormatedValue(oParam.DecodedValue);

                    //Set 'Value' cell tag
                    oParamRow.Cells[GRID_SPYENG_ENG_VALUE].Tag = oParam;
                }

                bCellValueChangedEventEnabled = true;
            }
        }

        public void Update_TxVirtualParameters(string MsgId, CANParameter oParam)
        {
            DataGridViewRow oMsgRow = Get_RawDataRow(MsgId);

            if (!(oMsgRow == null))
            {
                CollapsableGridRowProperties oMsgRowProps = (CollapsableGridRowProperties)oMsgRow.Tag;

                DataGridViewRow oGrpRow = null;

                if (oParam.IsMultiplexed)
                {
                    foreach (DataGridViewRow oChildRow in oMsgRowProps.Children)
                    {
                        if(oChildRow.Cells[GRID_SPYENG_ENG_VALUE].Value.ToString().Equals(oParam.MultiplexerValue.ToString()))
                        {
                            oGrpRow = oChildRow;
                            break;
                        }
                    }
                }
                else
                {
                    oGrpRow = oMsgRowProps.Children[0];
                }

                if (!(oGrpRow == null))
                {
                    CollapsableGridRowProperties oGrpRowProps = (CollapsableGridRowProperties)oGrpRow.Tag;

                    foreach(DataGridViewRow oParamRow in oGrpRowProps.Children)
                    {
                        if (oParamRow.Cells[GRID_SPYENG_NAME].Value.ToString().Equals(oParam.Name))
                        {
                            oParamRow.Cells[GRID_SPYENG_ENG_VALUE].Value = oParam.ValueFormat.GetSignalFormatedValue(oParam.DecodedValue);
                            break;
                        }
                    }
                }
            }
        }

        public void Update_TxMessageCount()
        {
            foreach(DataGridViewRow oRow in Grid_SpyEngineering.Rows)
            {
                CollapsableGridRowProperties oRowProps = (CollapsableGridRowProperties)oRow.Tag;

                if (oRowProps.RowDataType== GridRowDataType.RawData)
                {
                    oRow.Cells[GRID_SPYENG_COUNT].Value = ((CANMessageEncoded)oRow.Cells[GRID_SPYENG_ENG_VALUE].Tag).TxCount.ToString();
                }
            }
        }

        #endregion

        #region Data Rx grid methodes

        public void Update_GridRawData(MessageStatus RawMsg)
        {
            //Find raw message grid row
            DataGridViewRow oRawDataRow = Get_RawDataRow(RawMsg.IdString);

            if (oRawDataRow == null) //Create raw data grid row if it doesn't exist
            {
                oRawDataRow = Add_RawDataRow(RawMsg);
            }

            if (!(oRawDataRow==null))
            {
                //Refresh variable fields of the raw message
                oRawDataRow.Cells[GRID_SPYENG_ENG_VALUE].Value = RawMsg.DataString;
                oRawDataRow.Cells[GRID_SPYENG_PERIOD].Value = RawMsg.TimeString;
                oRawDataRow.Cells[GRID_SPYENG_COUNT].Value = RawMsg.Count.ToString();
            }
        }

        public void Update_GridEngineeringData(string RawMsgId, CANMessageDecoded oEngMsg)
        {
            //Find raw message grid row
            DataGridViewRow oRawDataRow = Get_RawDataRow(RawMsgId);

            if (!(oRawDataRow==null))
            {
                CollapsableGridRowProperties oRawMsgCollapsProps = (CollapsableGridRowProperties)oRawDataRow.Tag;

                if (oRawMsgCollapsProps.Children.Count == 1) //Raw message row only contains the root group row
                {
                    //Update message name and comment if first message update
                    oRawDataRow.Cells[GRID_SPYENG_NAME].Value = oEngMsg.Name;
                    oRawDataRow.Cells[GRID_SPYENG_MSG_RXTX].Value = oEngMsg.RxTx.ToString();
                    oRawDataRow.Cells[GRID_SPYENG_COMMENT].Value = oEngMsg.Comment;
                }

                if (oRawMsgCollapsProps.State == GridRowCollapsedStatus.Expanded) //Save time if the parent row is collasped so children rows aren't visible
                {
                    foreach (CANParameter oParam in oEngMsg.Parameters)
                    {
                        bool BParamVisible = true;
                        
                        DataGridViewRow oMuxRow = null;
                        DataGridViewRow oEngDataRow = null;

                        //Get paramter row among raw data row children rows
                        if (oParam.IsMultiplexed)
                        {
                            //Find engineering CAN parameter multiplexer value grid row
                            foreach (DataGridViewRow oRow in oRawMsgCollapsProps.Children)
                            {
                                if (((CollapsableGridRowProperties)oRow.Tag).RowDataType.Equals(GridRowDataType.Multiplexer))
                                {
                                    if ((oRow.Cells[GRID_SPYENG_NAME].Value.ToString().Equals(oEngMsg.MultiplexerName))
                                        && (oRow.Cells[GRID_SPYENG_ENG_VALUE].Value.ToString().Equals(oParam.MultiplexerValue.ToString())))
                                    {
                                        oMuxRow = oRow;
                                        break;
                                    }
                                }
                            }

                            if (oMuxRow == null)
                            {
                                //Create multiplexer grid row
                                oMuxRow = Add_MultiplexerRow(oRawDataRow, oEngMsg.MultiplexerName, oParam.MultiplexerValue);
                            }
                            else
                            {
                                //Find engineering CAN parameter grid row
                                CollapsableGridRowProperties oMuxCollapsProps = (CollapsableGridRowProperties)oMuxRow.Tag;

                                BParamVisible = (oMuxCollapsProps.State == GridRowCollapsedStatus.Expanded);

                                if (BParamVisible)
                                {
                                    foreach (DataGridViewRow oRow in oMuxCollapsProps.Children)
                                    {
                                        if (((CollapsableGridRowProperties)oRow.Tag).RowDataType.Equals(GridRowDataType.EngineeringData))
                                        {
                                            if (oRow.Cells[GRID_SPYENG_NAME].Value.ToString().Equals(oParam.Name))
                                            {
                                                oEngDataRow = oRow;
                                                break;
                                            }
                                        }
                                    } 
                                }
                            }

                        }
                        else
                        {
                            //Find engineering CAN parameter grid row
                            foreach (DataGridViewRow oRow in ((CollapsableGridRowProperties)oRawMsgCollapsProps.Children[0].Tag).Children)
                            {
                                if (((CollapsableGridRowProperties)oRow.Tag).RowDataType.Equals(GridRowDataType.EngineeringData))
                                {
                                    if (oRow.Cells[GRID_SPYENG_NAME].Value.ToString().Equals(oParam.Name))
                                    {
                                        oEngDataRow = oRow;
                                        break;
                                    }
                                }
                            }
                        }

                        if (BParamVisible) //Save time if the parent row is collasped so children rows aren't visible
                        {
                            if (oEngDataRow == null) //Create eng data grid row if it doesn't exist
                            {
                                int iRowIndex = -1;

                                if (oParam.IsMultiplexed)
                                {
                                    CollapsableGridRowProperties oMuxCollapsProps = (CollapsableGridRowProperties)oMuxRow.Tag;

                                    if (oMuxCollapsProps.Children.Count > 0)
                                    {
                                        iRowIndex = oMuxCollapsProps.Children[oMuxCollapsProps.Children.Count - 1].Index + 1;
                                    }
                                    else
                                    {
                                        iRowIndex = oMuxRow.Index + 1;
                                    }

                                    oEngDataRow = Add_EngDataRow(oMuxRow, oParam, iRowIndex); //Create eng data grid row as a child of its multiplexer
                                }
                                else
                                {
                                    CollapsableGridRowProperties oRootCollapsProps = (CollapsableGridRowProperties)(oRawMsgCollapsProps.Children[0]).Tag;

                                    if (oRootCollapsProps.Children.Count > 0)
                                    {
                                        iRowIndex = oRootCollapsProps.Children[oRootCollapsProps.Children.Count - 1].Index + 1;
                                    }
                                    else
                                    {
                                        iRowIndex = oRawMsgCollapsProps.Children[0].Index + 1;
                                    }

                                    oEngDataRow = Add_EngDataRow(oRawMsgCollapsProps.Children[0], oParam, iRowIndex); //Create eng data grid row as a child of its raw message
                                }
                            }


                            if (!(oEngDataRow == null))
                            {
                                //Process parameter alarms
                                Nullable<SignalAlarmValue> sAlarm = oParam.Alarms.GetAlarmProperties(oParam.Alarms.ProcessAlarms(oParam.DecodedValue));

                                //Get parameter value formatted
                                string CurrentValFormated;

                                if (oParam.ValueFormat == null)
                                {
                                    CurrentValFormated = oParam.DecodedValue.ToString();
                                }
                                else
                                {
                                    CurrentValFormated = oParam.ValueFormat.GetSignalFormatedValue(oParam.DecodedValue);
                                }

                                //Refresh variable fields of the engineering data parameter
                                oEngDataRow.Cells[GRID_SPYENG_RAW_VALUE].Value = oParam.RawValue; //Parameter raw data

                                oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Value = CurrentValFormated; //Parameter formatted value

                                if (sAlarm.HasValue) //Apply alarm style
                                {
                                    oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor = sAlarm.Value.BackColor;
                                    oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor = sAlarm.Value.ForeColor;
                                }
                                else //Apply default style if no alarm
                                {
                                    oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor = oEngDataRow.Cells[GRID_SPYENG_NAME].Style.BackColor;
                                    oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor = oEngDataRow.Cells[GRID_SPYENG_NAME].Style.ForeColor;
                                }

                                if ((oParam.DecodedValue < (double)oEngDataRow.Cells[GRID_SPYENG_MIN_VALUE].Tag) //Update min value
                                    || (oEngDataRow.Cells[GRID_SPYENG_MIN_VALUE].Value == null))
                                {
                                    //Min formatted value
                                    oEngDataRow.Cells[GRID_SPYENG_MIN_VALUE].Value = oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Value;

                                    //Apply cell 'Value' style
                                    oEngDataRow.Cells[GRID_SPYENG_MIN_VALUE].Style.BackColor = oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor;
                                    oEngDataRow.Cells[GRID_SPYENG_MIN_VALUE].Style.ForeColor = oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor;

                                    oEngDataRow.Cells[GRID_SPYENG_MIN_VALUE].Tag = oParam.DecodedValue;
                                }

                                if ((oParam.DecodedValue > (double)oEngDataRow.Cells[GRID_SPYENG_MAX_VALUE].Tag) //Update max value
                                    || (oEngDataRow.Cells[GRID_SPYENG_MAX_VALUE].Value == null))
                                {
                                    //Max formatted value
                                    oEngDataRow.Cells[GRID_SPYENG_MAX_VALUE].Value = oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Value;

                                    //Apply cell 'Value' style
                                    oEngDataRow.Cells[GRID_SPYENG_MAX_VALUE].Style.BackColor = oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor;
                                    oEngDataRow.Cells[GRID_SPYENG_MAX_VALUE].Style.ForeColor = oEngDataRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor;

                                    oEngDataRow.Cells[GRID_SPYENG_MAX_VALUE].Tag = oParam.DecodedValue;
                                }
                            }
                        }
                    } 
                }
            }
            else
            {
                //Not supposed to happen since engineering message has been decoded from a previously showed raw message
            }
        }

        public void Update_GridVirtualChannel(string LibName, CS_VirtualChannel oVirtualChan)
        {
            DataGridViewRow oVirtualMotherRow = null;
            CollapsableGridRowProperties oVirtualMotherRowColapsProps = null;

            DataGridViewRow oVirtualLibRow = null;
            CollapsableGridRowProperties oLibRowColapsProps = null;

            DataGridViewRow oChannelRow = null;

            //Get virtual channels mother row
            if (VirtualChannelsRowIndex == -1) //Virtual channel mother row doesn't exist yet
            {
                //Virtual channel mother row creation
                Grid_SpyEngineering.Rows.Add();
                oVirtualMotherRow = Grid_SpyEngineering.Rows[Grid_SpyEngineering.Rows.Count - 1];
                VirtualChannelsRowIndex = oVirtualMotherRow.Index;

                //Fill fixed data
                oVirtualMotherRow.Cells[GRID_SPYENG_COLLAPSE].Value = Icones.Grid_Collapse;
                oVirtualMotherRow.Cells[GRID_SPYENG_NAME].Value = "Virtual Channels";
                
                //Color row
                Color_GridRow(oVirtualMotherRow, Color.DarkGreen, Color.White);

                //Collapsing properties creation
                oVirtualMotherRowColapsProps = new CollapsableGridRowProperties();

                oVirtualMotherRowColapsProps.Row = oVirtualMotherRow;
                oVirtualMotherRowColapsProps.Parent = null;
                oVirtualMotherRowColapsProps.RowDataType = GridRowDataType.VirtualData;
                oVirtualMotherRowColapsProps.State = GridRowCollapsedStatus.Expanded;

                oVirtualMotherRow.Tag = oVirtualMotherRowColapsProps;

            }
            else //Virtual channel mother exist already
            {
                oVirtualMotherRow = Grid_SpyEngineering.Rows[VirtualChannelsRowIndex];
                oVirtualMotherRowColapsProps = (CollapsableGridRowProperties)oVirtualMotherRow.Tag;
            }

            if (oVirtualMotherRowColapsProps.State == GridRowCollapsedStatus.Expanded) //Save time if the parent row is collasped so children rows aren't visible
            {
                //Get virtual channel library child row
                foreach (DataGridViewRow oRow in oVirtualMotherRowColapsProps.Children)
                {
                    if (oRow.Cells[GRID_SPYENG_NAME].Value.ToString().Equals(LibName))
                    {
                        oVirtualLibRow = oRow;
                        oLibRowColapsProps = (CollapsableGridRowProperties)oVirtualLibRow.Tag;
                        break;
                    }
                }

                if (oVirtualLibRow == null) //Create virtual channels library row if it doesn't exist
                {
                    //Add the row to the grid
                    Grid_SpyEngineering.Rows.Add();
                    oVirtualLibRow = Grid_SpyEngineering.Rows[Grid_SpyEngineering.Rows.Count - 1];

                    //Fill fixed data
                    oVirtualLibRow.Cells[GRID_SPYENG_COLLAPSE].Value = Icones.Grid_Collapse;
                    oVirtualLibRow.Cells[GRID_SPYENG_NAME].Value = LibName;

                    //Color row
                    Color_GridRow(oVirtualLibRow, Color.LimeGreen, Color.White);

                    //Collapsing properties creation
                    oLibRowColapsProps = new CollapsableGridRowProperties();

                    oLibRowColapsProps.Row = oVirtualLibRow;
                    oLibRowColapsProps.Parent = oVirtualMotherRow;
                    oLibRowColapsProps.RowDataType = GridRowDataType.VirtualLibrary;
                    oLibRowColapsProps.State = GridRowCollapsedStatus.Expanded;

                    oVirtualMotherRowColapsProps.Children.Add(oVirtualLibRow);

                    oVirtualLibRow.Tag = oLibRowColapsProps;
                }

                if (oLibRowColapsProps.State == GridRowCollapsedStatus.Expanded) //Save time if the parent row is collasped so children rows aren't visible
                {
                    //Get virtual channel channel child row
                    foreach (DataGridViewRow oRow in oLibRowColapsProps.Children)
                    {
                        if (oRow.Cells[GRID_SPYENG_NAME].Value.ToString().Equals(oVirtualChan.Name))
                        {
                            oChannelRow = oRow;
                            break;
                        }
                    }

                    if (oChannelRow == null) //Create virtual channel row if it doesn't exist
                    {
                        int iChanRow;

                        //Get the row index in which insert the new virtual channel row to be created
                        if (oLibRowColapsProps.Children.Count == 0) //Virtual channel library row doesn't contain any data
                        {
                            iChanRow = oVirtualLibRow.Index + 1;
                        }
                        else //Virtual channel library row already contains data
                        {
                            iChanRow = oLibRowColapsProps.Children[oLibRowColapsProps.Children.Count - 1].Index + 1;
                        }

                        //Add the row to the grid
                        Grid_SpyEngineering.Rows.Insert(iChanRow, 1);
                        oChannelRow = Grid_SpyEngineering.Rows[iChanRow];

                        //Fill fixed data
                        oChannelRow.Cells[GRID_SPYENG_COLLAPSE].Value = Icones.Grid_NoAction2;
                        oChannelRow.Cells[GRID_SPYENG_NAME].Value = oVirtualChan.Name;
                        oChannelRow.Cells[GRID_SPYENG_UNIT].Value = oVirtualChan.Unit;
                        oChannelRow.Cells[GRID_SPYENG_COMMENT].Value = oVirtualChan.Comment;

                        //Color row
                        if (oLibRowColapsProps.Children.Count % 2 != 0)
                        {
                            Color_GridRow(oChannelRow, Color.PaleGreen, Color.Black);
                        }

                        //Init Min/Max
                        oChannelRow.Cells[GRID_SPYENG_MIN_VALUE].Tag = oVirtualChan.Value;
                        oChannelRow.Cells[GRID_SPYENG_MAX_VALUE].Tag = oVirtualChan.Value;

                        //Collapsing properties creation
                        CollapsableGridRowProperties oColapsProps = new CollapsableGridRowProperties();

                        oColapsProps.Row = oChannelRow;
                        oColapsProps.Parent = oVirtualLibRow;
                        oColapsProps.RowDataType = GridRowDataType.VirtualChannel;
                        oColapsProps.State = GridRowCollapsedStatus.Expanded;

                        oLibRowColapsProps.Children.Add(oChannelRow);

                        oChannelRow.Tag = oColapsProps;
                    }

                    if (!(oChannelRow == null))
                    {
                        //Update value
                        if (oVirtualChan.ValueFormat == null)
                        {
                            oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Value = oVirtualChan.Value.ToString();
                        }
                        else
                        {
                            oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Value = oVirtualChan.ValueFormat.GetSignalFormatedValue(oVirtualChan.Value);
                        }

                        //Process parameter alarms
                        Nullable<SignalAlarmValue> sAlarm = oVirtualChan.Alarms.GetAlarmProperties(oVirtualChan.Alarms.ProcessAlarms(oVirtualChan.Value));

                        if (sAlarm.HasValue) //Apply alarm style
                        {
                            oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor = sAlarm.Value.BackColor;
                            oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor = sAlarm.Value.ForeColor;
                        }
                        else //Apply default style if no alarm
                        {
                            oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor = oChannelRow.Cells[GRID_SPYENG_NAME].Style.BackColor;
                            oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor = oChannelRow.Cells[GRID_SPYENG_NAME].Style.ForeColor;
                        }

                        //Update Min value
                        if ((oVirtualChan.Value < (double)oChannelRow.Cells[GRID_SPYENG_MIN_VALUE].Tag)
                            || (oChannelRow.Cells[GRID_SPYENG_MIN_VALUE].Value == null))
                        {
                            oChannelRow.Cells[GRID_SPYENG_MIN_VALUE].Value = oVirtualChan.Value.ToString();
                            oChannelRow.Cells[GRID_SPYENG_MIN_VALUE].Tag = oVirtualChan.Value;

                            //Apply cell 'Value' style
                            oChannelRow.Cells[GRID_SPYENG_MIN_VALUE].Style.BackColor = oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor;
                            oChannelRow.Cells[GRID_SPYENG_MIN_VALUE].Style.ForeColor = oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor;

                        }

                        //Update Max value
                        if ((oVirtualChan.Value > (double)oChannelRow.Cells[GRID_SPYENG_MAX_VALUE].Tag)
                            || (oChannelRow.Cells[GRID_SPYENG_MAX_VALUE].Value == null))
                        {
                            oChannelRow.Cells[GRID_SPYENG_MAX_VALUE].Value = oVirtualChan.Value.ToString();
                            oChannelRow.Cells[GRID_SPYENG_MAX_VALUE].Tag = oVirtualChan.Value;

                            //Apply cell 'Value' style
                            oChannelRow.Cells[GRID_SPYENG_MAX_VALUE].Style.BackColor = oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.BackColor;
                            oChannelRow.Cells[GRID_SPYENG_MAX_VALUE].Style.ForeColor = oChannelRow.Cells[GRID_SPYENG_ENG_VALUE].Style.ForeColor;
                        }
                    }
                }
            }
        }

        public int Get_RawMessageCount()
        {
            int RawMsgCnt = 0;

            foreach (DataGridViewRow oRow in Grid_SpyEngineering.Rows)
            {
                CollapsableGridRowProperties oRowProps = (CollapsableGridRowProperties)oRow.Tag;

                if (!(oRowProps == null))
                {
                    if (oRowProps.RowDataType == GridRowDataType.RawData)
                    {
                        RawMsgCnt++;
                    }
                }
            }

            return (RawMsgCnt);
        }

        #endregion
		
		public void Clear_EngGrid()
		{
			Grid_SpyEngineering.Rows.Clear();
            VirtualChannelsRowIndex = -1;

            //Event GridDataReseted firing
            EventArgs Arg = new EventArgs();
            OnGridDataReseted(Arg);
		}
		
		#endregion
		
		#region Events handling methods
		
		protected virtual void OnEngGridColumnsVisibleChanged(GridColVisibleChangedEventArgs e)
		{
			EventHandler<GridColVisibleChangedEventArgs> Handler = GridColumnsVisibleChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}

        protected virtual void OnGridDataReseted(EventArgs e)
        {
            EventHandler<EventArgs> Handler = GridDataReseted;
            if (Handler != null)
            {
                Handler(this, e);
            }
        }

        protected virtual void OnGridTxParameterValueChanged(GridTxParameterValueChangedEventArgs e)
        {
            EventHandler<GridTxParameterValueChangedEventArgs> Handler = GridTxParameterValueChanged;
            if(Handler != null)
            {
                Handler(this, e);
            }
        }

        #endregion
    }

    #region Events argument class

    public class GridColVisibleChangedEventArgs : EventArgs
	{
		public GridCANData_ColumnsEnum ColumnsVisible {get; set;}
	}

    public class GridTxParameterValueChangedEventArgs : EventArgs
    {
        public UInt32 MessageId { get; set; }
        public long MultiplexerValue { get; set; }
        public string ParameterName { get; set; }
        public double ParameterValue { get; set; }
    }

    #endregion

    #region Collapsable grid row properties class

    /// <summary>
    /// Collapsable data grid view row class
    /// </summary>
    public class CollapsableGridRowProperties
    {
        #region Public members

        /// <summary>
        /// Data type of the current row
        /// </summary>
        public GridRowDataType RowDataType;

        /// <summary>
        /// Collapsed state of the current row
        /// </summary>
        public GridRowCollapsedStatus State;

        /// <summary>
        /// Current grid row
        /// </summary>
        public DataGridViewRow Row;

        /// <summary>
        /// Parent of the current grid row
        /// </summary>
        public DataGridViewRow Parent;

        /// <summary>
        /// Children of the current grid row
        /// </summary>
        public List<DataGridViewRow> Children;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public CollapsableGridRowProperties()
        {
            RowDataType = GridRowDataType.None;
            State = GridRowCollapsedStatus.Expanded;
            Row = null;
            Parent = null;
            Children = new List<DataGridViewRow>();
        }

        #region Public methodes

        public void CollapseChildren()
        {
            if (Children.Count > 0)
            {
                foreach (DataGridViewRow oChildRow in Children)
                {
                    oChildRow.Visible = false;

                    CollapsableGridRowProperties oChildRowCollapsProps = oChildRow.Tag as CollapsableGridRowProperties;
                    oChildRowCollapsProps.CollapseChildren();
                }

                Row.Cells[0].Value = Icones.Grid_Expand;
            }

            State = GridRowCollapsedStatus.Collasped;
        }

        public void ExpandChildren()
        {
            if (Children.Count > 0)
            {
                foreach (DataGridViewRow oChildRow in Children)
                {
                    if (!(((CollapsableGridRowProperties)oChildRow.Tag).RowDataType == GridRowDataType.RootGroup))
                    {
                        oChildRow.Visible = true;
                    }
                    else
                    {
                        ((CollapsableGridRowProperties)oChildRow.Tag).ExpandChildren();
                    }
                }

                Row.Cells[0].Value = Icones.Grid_Collapse;
            }

            State = GridRowCollapsedStatus.Expanded;
        }

        public void SetRowVisibility(bool Visible)
        {
            Row.Visible = Visible;

            if (Visible)
            {
                State = GridRowCollapsedStatus.Expanded;

                if (!((RowDataType == GridRowDataType.EngineeringData) || (RowDataType == GridRowDataType.VirtualChannel)))
                {
                    Row.Cells[0].Value = Icones.Grid_Collapse;
                }
            }
            else
            {
                State = GridRowCollapsedStatus.Collasped;

                if (!((RowDataType == GridRowDataType.EngineeringData) || (RowDataType == GridRowDataType.VirtualChannel)))
                {
                    Row.Cells[0].Value = Icones.Grid_Expand;
                }
            }
        }

        public DataGridViewRow GetRootRow()
        {
            DataGridViewRow oRootRow = this.Row;

            if (this.Parent != null)
            {
                CollapsableGridRowProperties oParentRowProps = (CollapsableGridRowProperties)this.Parent.Tag;

                while (oParentRowProps.Parent != null)
                {
                    oParentRowProps = (CollapsableGridRowProperties)oParentRowProps.Parent.Tag;
                }

                oRootRow = oParentRowProps.Row;
            }

            return (oRootRow);
        }

        #endregion
    }
    #endregion
}
