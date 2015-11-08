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
    public partial class Ctrl_SpyDataViewer : UserControl
	{
        #region Private constants

        private const int GRID_SPYENG_COLLAPSE  = 0;
        private const int GRID_SPYENG_MSG_ID    = 1;
        private const int GRID_SPYENG_NAME      = 2;
        private const int GRID_SPYENG_RAW_VALUE = 3;
        private const int GRID_SPYENG_ENG_VALUE = 4;
        private const int GRID_SPYENG_MIN_VALUE = 5;
        private const int GRID_SPYENG_MAX_VALUE = 6;
        private const int GRID_SPYENG_UNIT      = 7;
        private const int GRID_SPYENG_PERIOD    = 8;
        private const int GRID_SPYENG_COUNT     = 9;
        private const int GRID_SPYENG_DLC       = 10;
        private const int GRID_SPYENG_COMMENT   = 11;

        private const int GRID_MAX_COL_WIDTH = 60;
		private const int GRID_ENG_SPY_FILLER_COL = GRID_SPYENG_COMMENT;	//Column 'Comment' 		
		
		#endregion
		
		#region Public events
		
		[Browsable(true), Description("Occurs when a column of the engineering data grid column is hidden or shown")]
		public event EventHandler<EngGridColVisibleChangedEventArgs> EngGridColumnsVisibleChanged;

        [Browsable(true), Description("Occurs when the CAN data grid is reset")]
        public event EventHandler<EventArgs> GridDataReseted;

		#endregion
		
		#region Control properties
		
		[Category("Appearance"), Browsable(true), Description("Engineering data grid columns visible")]
		public SpyEngineering_Grid_Columns EngineeringGridColumnsVisible
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
			
		#endregion
		
		#region Private members

		private SpyEngineering_Grid_Columns SpyEngGridColumnsVisible;
        private GridSortingMode eItemsSortingMode;
        private GridSortingDirection eItemsSortingDirection;
        
        private int VirtualChannelsRowIndex;
		
		#endregion
		
		public Ctrl_SpyDataViewer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			EngineeringGridColumnsVisible = SpyEngineering_Grid_Columns.Default;
            eItemsSortingMode = GridSortingMode.Default;
            eItemsSortingDirection = GridSortingDirection.Default;

            VirtualChannelsRowIndex = -1;
			
		}
		
		#region Control events
		
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
			Set_SpyEngGridColumnsVisible(SpyEngineering_Grid_Columns.All);
		}
		
		private void ContextSpyEng_hideAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			Set_SpyEngGridColumnsVisible(SpyEngineering_Grid_Columns.None);
		}
		
		private void ContextSpyEng_iDToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyEng_iDToolStripMenuItem.Checked = !ContextSpyEng_iDToolStripMenuItem.Checked;
			
			if (ContextSpyEng_iDToolStripMenuItem.Checked)
			{
				Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_ID);
			}
			else
			{
				Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_ID));
			}
		}
		
		private void ContextSpyEng_valueToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyEng_valueToolStripMenuItem.Checked = !ContextSpyEng_valueToolStripMenuItem.Checked;
			
			if (ContextSpyEng_valueToolStripMenuItem.Checked)
			{
				Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_Value);
			}
			else
			{
				Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_Value));
			}
		}
		
		private void ContextSpyEng_rawValueToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyEng_rawValueToolStripMenuItem.Checked = !ContextSpyEng_rawValueToolStripMenuItem.Checked;
			
			if (ContextSpyEng_rawValueToolStripMenuItem.Checked)
			{
				Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_RawValue);
			}
			else
			{
				Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_RawValue));
			}
		}
		
		private void ContextSpyEng_minToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyEng_minToolStripMenuItem.Checked = !ContextSpyEng_minToolStripMenuItem.Checked;
			
			if (ContextSpyEng_minToolStripMenuItem.Checked)
			{
				Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_Min);
			}
			else
			{
				Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_Min));
			}
		}
		
		private void ContextSpyEng_maxToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyEng_maxToolStripMenuItem.Checked = !ContextSpyEng_maxToolStripMenuItem.Checked;
			
			if (ContextSpyEng_maxToolStripMenuItem.Checked)
			{
				Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_Max);
			}
			else
			{
				Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_Max));
			}
		}
		
		private void ContextSpyEng_unitToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyEng_unitToolStripMenuItem.Checked = !ContextSpyEng_unitToolStripMenuItem.Checked;
			
			if (ContextSpyEng_unitToolStripMenuItem.Checked)
			{
				Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_Unit);
			}
			else
			{
				Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_Unit));
			}
		}

        private void ContextSpyEng_periodToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextSpyEng_periodToolStripMenuItem.Checked = !ContextSpyEng_periodToolStripMenuItem.Checked;

            if (ContextSpyEng_periodToolStripMenuItem.Checked)
            {
                Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_Period);
            }
            else
            {
                Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_Period));
            }
        }

        private void ContextSpyEng_countToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextSpyEng_countToolStripMenuItem.Checked = !ContextSpyEng_countToolStripMenuItem.Checked;

            if (ContextSpyEng_countToolStripMenuItem.Checked)
            {
                Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_Count);
            }
            else
            {
                Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_Count));
            }
        }

        private void ContextSpyEng_dlcToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ContextSpyEng_dlcToolStripMenuItem.Checked = !ContextSpyEng_dlcToolStripMenuItem.Checked;

            if (ContextSpyEng_dlcToolStripMenuItem.Checked)
            {
                Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_DLC);
            }
            else
            {
                Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_DLC));
            }
        }

		private void ContextSpyEng_commentToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyEng_commentToolStripMenuItem.Checked = !ContextSpyEng_commentToolStripMenuItem.Checked;
			
			if (ContextSpyEng_commentToolStripMenuItem.Checked)
			{
				Set_SpyEngGridColumnsVisible(SpyEngGridColumnsVisible | SpyEngineering_Grid_Columns.Column_Comment);
			}
			else
			{
				Set_SpyEngGridColumnsVisible((SpyEngineering_Grid_Columns)(SpyEngGridColumnsVisible - SpyEngineering_Grid_Columns.Column_Comment));
			}
		}
		
		#endregion
		
		#endregion
		
		#region Grid_SpyEngineering
		
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
		
		private void Set_SpyEngGridColumnsVisible(SpyEngineering_Grid_Columns eColumnsVisible)
		{
			SpyEngGridColumnsVisible = eColumnsVisible;

            Grid_SpyEngineering.Columns[GRID_SPYENG_MSG_ID].Visible     = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_ID);
            Grid_SpyEngineering.Columns[GRID_SPYENG_RAW_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_RawValue);
            Grid_SpyEngineering.Columns[GRID_SPYENG_ENG_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Value);
            Grid_SpyEngineering.Columns[GRID_SPYENG_MIN_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Min);
            Grid_SpyEngineering.Columns[GRID_SPYENG_MAX_VALUE].Visible  = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Max);
            Grid_SpyEngineering.Columns[GRID_SPYENG_UNIT].Visible       = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Unit);
            Grid_SpyEngineering.Columns[GRID_SPYENG_PERIOD].Visible     = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Period);
            Grid_SpyEngineering.Columns[GRID_SPYENG_COUNT].Visible      = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Count);
            Grid_SpyEngineering.Columns[GRID_SPYENG_DLC].Visible        = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_DLC);
            Grid_SpyEngineering.Columns[GRID_SPYENG_COMMENT].Visible    = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Comment);
			
			ResizeGridColumns(Grid_SpyEngineering, GRID_ENG_SPY_FILLER_COL);
			
			ContextSpyEng_iDToolStripMenuItem.Checked       = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_ID);
			ContextSpyEng_valueToolStripMenuItem.Checked    = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Value);
			ContextSpyEng_rawValueToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_RawValue);
			ContextSpyEng_minToolStripMenuItem.Checked      = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Min);
			ContextSpyEng_maxToolStripMenuItem.Checked      = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Max);
			ContextSpyEng_unitToolStripMenuItem.Checked     = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Unit);
            ContextSpyEng_periodToolStripMenuItem.Checked   = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Period);
            ContextSpyEng_countToolStripMenuItem.Checked    = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Count);
            ContextSpyEng_dlcToolStripMenuItem.Checked      = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_DLC);
			ContextSpyEng_commentToolStripMenuItem.Checked  = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Comment);
			
			//Event EngGridColumnsVisibleChanged firing
			EngGridColVisibleChangedEventArgs Arg = new EngGridColVisibleChangedEventArgs();
			Arg.ColumnsVisible = SpyEngGridColumnsVisible;
			OnEngGridColumnsVisibleChanged(Arg);
		}

        #region Collapsable grid functions

        private DataGridViewRow Add_RawDataRow(MessageStatus oRawMsg)
        {
            //Add the row to the grid
            Grid_SpyEngineering.Rows.Add();
            DataGridViewRow oRow = Grid_SpyEngineering.Rows[Grid_SpyEngineering.Rows.Count - 1];

            //Fill fixed data
            oRow.Cells[GRID_SPYENG_COLLAPSE].Value = Icones.Grid_Collapse;
            oRow.Cells[GRID_SPYENG_MSG_ID].Value = oRawMsg.IdString;
            oRow.Cells[GRID_SPYENG_DLC].Value = oRawMsg.CANMsg.LEN.ToString();

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
            oRow.Cells[GRID_SPYENG_COMMENT].Value = oEngParam.Comment;

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

        #endregion

        #endregion

        #region Public methods

        #region Collapsable grid functions

        public void Update_SpyGridRawData(MessageStatus RawMsg)
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

        public void Update_SpyGridEngData(string RawMsgId, CANMessageDecoded oEngMsg)
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

        public void Update_SpyGridVirtualChannel(string LibName, CS_VirtualChannel oVirtualChan)
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
		
		protected virtual void OnEngGridColumnsVisibleChanged(EngGridColVisibleChangedEventArgs e)
		{
			EventHandler<EngGridColVisibleChangedEventArgs> Handler = EngGridColumnsVisibleChanged;
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

        #endregion
    }

    #region Grids columns visible changed event argument
	
	public class EngGridColVisibleChangedEventArgs : EventArgs
	{
		public SpyEngineering_Grid_Columns ColumnsVisible {get; set;}
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

        #endregion
    }
    #endregion
}
