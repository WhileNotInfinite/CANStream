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
using System.Drawing;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Ctrl_SpyDataViewer.
	/// </summary>
	public partial class Ctrl_SpyDataViewer : UserControl
	{
        #region Private constants

        private const int GRID_SPYENG_MSG_ID = 0;
        private const int GRID_SPYENG_NAME = 1;
		private const int GRID_SPYENG_VALUE = 3;
        private const int GRID_SPYENG_FORMAT = 6;
        private const int GRID_SPYENG_ALARM_BACKCOLOR = 7;
        private const int GRID_SPYENG_ALARM_FORECOLOR = 8;
        private const int GRID_MAX_COL_WIDTH = 60;
		private const int GRID_RAW_SPY_FILLER_COL = 2;		//Column 'Data'
		private const int GRID_ENG_SPY_FILLER_COL = 7;		//Column 'Comment' 		
		private const int GRID_RAW_KEY_COL = 0;
		
		#endregion
		
		#region Public events
		
		[Browsable(true), Description("Occurs when a column of the raw data grid column is hidden or shown")]
		public event EventHandler<RawGridColVisibleChangedEventArgs> RawGridColumnsVisibleChanged;
		
		[Browsable(true), Description("Occurs when a column of the engineering data grid column is hidden or shown")]
		public event EventHandler<EngGridColVisibleChangedEventArgs> EngGridColumnsVisibleChanged;
				
		#endregion
		
		#region Control properties
		
		[Category("Appearance"), Browsable(true), Description("Grids splitter orientation")]
		public Orientation GridOrientation
		{
			get
			{
				return this.Split_RawEng_Data.Orientation;
			}
			
			set
			{
				this.Split_RawEng_Data.Orientation = value;
			}
		}
		
		[Category("Appearance"), Browsable(true), Description("Grids splitter disance")]
		public int GridSplitterDistance
		{
			get
			{
				return this.Split_RawEng_Data.SplitterDistance;
			}
			
			set
			{
				try
				{
					this.Split_RawEng_Data.SplitterDistance = value;
				}
				catch
				{}
			}
		}
		
		[Category("Appearance"), Browsable(true), Description("Raw data grid visible")]
		public bool RawDataGridVisible
		{
			get
			{
				return !this.Split_RawEng_Data.Panel1Collapsed;
			}
			
			set
			{
				this.Split_RawEng_Data.Panel1Collapsed = !value;
			}
		}
		
		[Category("Appearance"), Browsable(true), Description("Raw data grid visible")]
		public bool EngDataGridVisible
		{
			get
			{
				return !this.Split_RawEng_Data.Panel2Collapsed;
			}
			
			set
			{
				this.Split_RawEng_Data.Panel2Collapsed = !value;
			}
		}
		
		[Category("Appearance"), Browsable(true), Description("Raw data grid columns visible")]
		public SpyRaw_Grid_Columns RawGridColumnsVisible
		{
			get
			{
				return this.SpyRawGridColumnsVisible;
			}
			
			set
			{
				Set_SpyRawGridColumnsVisible(value);
			}
		}
		
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
		
		private SpyRaw_Grid_Columns SpyRawGridColumnsVisible;
		private SpyEngineering_Grid_Columns SpyEngGridColumnsVisible;
		
		#endregion
		
		public Ctrl_SpyDataViewer()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			GridOrientation = Orientation.Horizontal;
			GridSplitterDistance = 150;
			RawDataGridVisible = true;
			EngDataGridVisible = true;
			RawGridColumnsVisible = SpyRaw_Grid_Columns.Default;
			EngineeringGridColumnsVisible = SpyEngineering_Grid_Columns.Default;
			
		}
		
		#region Control events
		
		#region Context_SpyRawGrid
		
		private void ContextSpyRaw_ResetTSMenuItemClick(object sender, EventArgs e)
		{
			Grid_SpyRaw.Rows.Clear();
		}
		
		private void ContextSpyRaw_HideSelectedRowsTSMenuItemClick(object sender, EventArgs e)
		{
			HideActiveRow();
		}
		
		private void ContextSpyRaw_ShowHiddenRowsTSMenuItemClick(object sender, EventArgs e)
		{
			ShowHiddenRows();
		}
		
		#region Columns
		
		private void ContextSpyRaw_showAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			Set_SpyRawGridColumnsVisible(SpyRaw_Grid_Columns.All);
		}
		
		private void ContextSpyRaw_hideAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			Set_SpyRawGridColumnsVisible(SpyRaw_Grid_Columns.None);
		}
		
		private void ContextSpyRaw_dLCToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyRaw_dLCToolStripMenuItem.Checked = !ContextSpyRaw_dLCToolStripMenuItem.Checked;
			
			if (ContextSpyRaw_dLCToolStripMenuItem.Checked)
			{
				Set_SpyRawGridColumnsVisible(SpyRawGridColumnsVisible | SpyRaw_Grid_Columns.Column_DLC);
			}
			else
			{
				Set_SpyRawGridColumnsVisible((SpyRaw_Grid_Columns)(SpyRawGridColumnsVisible - SpyRaw_Grid_Columns.Column_DLC));
			}
		}
		
		private void ContextSpyRaw_dataToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyRaw_dataToolStripMenuItem.Checked = !ContextSpyRaw_dataToolStripMenuItem.Checked;
			
			if (ContextSpyRaw_dataToolStripMenuItem.Checked)
			{
				Set_SpyRawGridColumnsVisible(SpyRawGridColumnsVisible | SpyRaw_Grid_Columns.Column_Data);
			}
			else
			{
				Set_SpyRawGridColumnsVisible((SpyRaw_Grid_Columns)(SpyRawGridColumnsVisible - SpyRaw_Grid_Columns.Column_Data));
			}
		}
		
		private void ContextSpyRaw_periodToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyRaw_periodToolStripMenuItem.Checked = !ContextSpyRaw_periodToolStripMenuItem.Checked;
			
			if (ContextSpyRaw_periodToolStripMenuItem.Checked)
			{
				Set_SpyRawGridColumnsVisible(SpyRawGridColumnsVisible | SpyRaw_Grid_Columns.Column_Period);
			}
			else
			{
				Set_SpyRawGridColumnsVisible((SpyRaw_Grid_Columns)(SpyRawGridColumnsVisible - SpyRaw_Grid_Columns.Column_Period));
			}
		}
		
		private void ContextSpyRaw_countToolStripMenuItemClick(object sender, EventArgs e)
		{
			ContextSpyRaw_countToolStripMenuItem.Checked = !ContextSpyRaw_countToolStripMenuItem.Checked;
			
			if (ContextSpyRaw_countToolStripMenuItem.Checked)
			{
				Set_SpyRawGridColumnsVisible(SpyRawGridColumnsVisible | SpyRaw_Grid_Columns.Column_Count);
			}
			else
			{
				Set_SpyRawGridColumnsVisible((SpyRaw_Grid_Columns)(SpyRawGridColumnsVisible - SpyRaw_Grid_Columns.Column_Count));
			}
		}
		
		#endregion
		
		#endregion
		
		#region Context_SpyEngGrid
		
		private void ContextSpyEng_ResetTSMenuItemClick(object sender, EventArgs e)
		{
			Grid_SpyEngineering.Rows.Clear();
		}
		
		private void ContextSpyEng_HideSelectedRowsTSMenuItemClick(object sender, EventArgs e)
		{
			HideActiveRow();
		}
		
		private void ContextSpyEng_ShowHiddenRowsTSMenuItemClick(object sender, EventArgs e)
		{
			ShowHiddenRows();
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
				
				Filter_EngGrid(ContextSpyEng_FiltetTSComboBox.Text);
			}
		}
		
		private void ContextSpyEng_FiltetTSComboBoxSelectedIndexChanged(object sender, EventArgs e)
		{
			Filter_EngGrid(ContextSpyEng_FiltetTSComboBox.Text);
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
		
		#region Grid_SpyRaw
		
		private void Grid_SpyRawSizeChanged(object sender, EventArgs e)
		{
			ResizeGridColumns(Grid_SpyRaw, GRID_RAW_SPY_FILLER_COL);
		}
		
		#endregion
		
		#region Grid_SpyEngineering
		
		private void Grid_SpyEngineeringSizeChanged(object sender, EventArgs e)
		{
			ResizeGridColumns(Grid_SpyEngineering, GRID_ENG_SPY_FILLER_COL);
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
        		if (oCol.Visible)
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
		
		private void Set_SpyRawGridColumnsVisible(SpyRaw_Grid_Columns eColumnsVisible)
		{
			SpyRawGridColumnsVisible = eColumnsVisible;
			
			Grid_SpyRaw.Columns[1].Visible = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_DLC);
			Grid_SpyRaw.Columns[2].Visible = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_Data);
			Grid_SpyRaw.Columns[3].Visible = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_Period);
			Grid_SpyRaw.Columns[4].Visible = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_Count);
			
			ResizeGridColumns(Grid_SpyRaw, GRID_RAW_SPY_FILLER_COL);
			
			ContextSpyRaw_dLCToolStripMenuItem.Checked = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_DLC);
			ContextSpyRaw_dataToolStripMenuItem.Checked = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_Data);
			ContextSpyRaw_periodToolStripMenuItem.Checked = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_Period);
			ContextSpyRaw_countToolStripMenuItem.Checked = SpyRawGridColumnsVisible.HasFlag(SpyRaw_Grid_Columns.Column_Count);
			
			//Event RawGridColumnsVisibleChanged firing
			RawGridColVisibleChangedEventArgs Arg = new RawGridColVisibleChangedEventArgs();
			Arg.ColumnsVisible = SpyRawGridColumnsVisible;
			OnRawGridColumnsVisibleChanged(Arg);
		}
		
		private void Set_SpyEngGridColumnsVisible(SpyEngineering_Grid_Columns eColumnsVisible)
		{
			SpyEngGridColumnsVisible = eColumnsVisible;
			
			Grid_SpyEngineering.Columns[0].Visible = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_ID);
			Grid_SpyEngineering.Columns[2].Visible = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_RawValue);
			Grid_SpyEngineering.Columns[3].Visible = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Value);
			Grid_SpyEngineering.Columns[4].Visible = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Min);
			Grid_SpyEngineering.Columns[5].Visible = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Max);
			Grid_SpyEngineering.Columns[6].Visible = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Unit);
			Grid_SpyEngineering.Columns[7].Visible = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Comment);
			
			ResizeGridColumns(Grid_SpyEngineering, GRID_ENG_SPY_FILLER_COL);
			
			ContextSpyEng_iDToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_ID);
			ContextSpyEng_valueToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Value);
			ContextSpyEng_rawValueToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_RawValue);
			ContextSpyEng_minToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Min);
			ContextSpyEng_maxToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Max);
			ContextSpyEng_unitToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Unit);
			ContextSpyEng_commentToolStripMenuItem.Checked = SpyEngGridColumnsVisible.HasFlag(SpyEngineering_Grid_Columns.Column_Comment);
			
			//Event EngGridColumnsVisibleChanged firing
			EngGridColVisibleChangedEventArgs Arg = new EngGridColVisibleChangedEventArgs();
			Arg.ColumnsVisible = SpyEngGridColumnsVisible;
			OnEngGridColumnsVisibleChanged(Arg);
		}
		
		private void Add_RawGridRow(string[] Data)
		{
			Grid_SpyRaw.Rows.Add();
			int iRow = Grid_SpyRaw.Rows.Count - 1;
			
			for (int i = 0; i< Grid_SpyRaw.Rows[iRow].Cells.Count; i++)
			{
				Grid_SpyRaw.Rows[iRow].Cells[i].Value = Data[i];
			}
			
			if ((Grid_SpyRaw.Rows.Count % 2) == 0)
			{
				for(int i=0; i < Grid_SpyRaw.Rows[iRow].Cells.Count; i++)
				{
					Grid_SpyRaw.Rows[iRow].Cells[i].Style.BackColor = Color.LightBlue;
				}
			}
		}
		
		private void Add_EngGridRow(object[] Data)
		{
			Grid_SpyEngineering.Rows.Add();
			int iRow =  Grid_SpyEngineering.Rows.Count - 1;
			
			Grid_SpyEngineering.Rows[iRow].Cells[0].Value = Data[0].ToString(); //Name
			Grid_SpyEngineering.Rows[iRow].Cells[1].Value = Data[1].ToString(); //ID
			Grid_SpyEngineering.Rows[iRow].Cells[6].Value = Data[4].ToString(); //Unit
			Grid_SpyEngineering.Rows[iRow].Cells[7].Value = Data[5].ToString(); //Comment

            Grid_SpyEngineering.Rows[iRow].Cells[4].Tag = (double)Data[3]; //Min physical value
            Grid_SpyEngineering.Rows[iRow].Cells[5].Tag = (double)Data[3]; //Max physical value

            if ((Grid_SpyEngineering.Rows.Count % 2) == 0)
			{
				for(int i=0; i < Grid_SpyEngineering.Rows[iRow].Cells.Count; i++)
				{
					Grid_SpyEngineering.Rows[iRow].Cells[i].Style.BackColor = Color.LightBlue;
				}
			}

            Update_EngGridRow(Data, false, iRow); //Update row values
        }
		
		private void Add_EngGridRowVirtual(object[] Data)
		{
			Grid_SpyEngineering.Rows.Add();
			int iRow =  Grid_SpyEngineering.Rows.Count - 1;
			
			Grid_SpyEngineering.Rows[iRow].Cells[0].Value = Data[0].ToString(); //Name
			Grid_SpyEngineering.Rows[iRow].Cells[1].Value = Data[1].ToString(); //ID
			Grid_SpyEngineering.Rows[iRow].Cells[2].Value = ""; //Raw value
			Grid_SpyEngineering.Rows[iRow].Cells[6].Value = Data[4].ToString(); //Unit
			Grid_SpyEngineering.Rows[iRow].Cells[7].Value = Data[5].ToString(); //Comment
			
			Grid_SpyEngineering.Rows[iRow].Cells[3].ToolTipText = Data[2].ToString();

            Grid_SpyEngineering.Rows[iRow].Cells[4].Tag = (double)Data[3]; //Min physical value
            Grid_SpyEngineering.Rows[iRow].Cells[5].Tag = (double)Data[3]; //Max physical value

            Color CellBackColor = Color.LightGreen;
			Color CellForeColor = Color.Black;
			
			if ((Grid_SpyEngineering.Rows.Count % 2) == 0)
			{
				CellBackColor = Color.DarkGreen;
				CellForeColor = Color.White;
			}
			
			for(int i=0; i < Grid_SpyEngineering.Rows[iRow].Cells.Count; i++)
			{
				Grid_SpyEngineering.Rows[iRow].Cells[i].Style.BackColor = CellBackColor;
				Grid_SpyEngineering.Rows[iRow].Cells[i].Style.ForeColor = CellForeColor;
			}

            Update_EngGridRow(Data, true, iRow); //Update row values
        }
		
		private void Filter_EngGrid(string sFilter)
		{
			foreach (DataGridViewRow oRow in Grid_SpyEngineering.Rows)
			{
				if ((sFilter.Equals("")) || (oRow.Cells[GRID_SPYENG_NAME].Value.ToString().ToLower().Contains(sFilter.ToLower())))
				{
					oRow.Visible = true;
				}
				else
				{
					oRow.Visible = false;
				}
			}
		}
		
		#endregion
		
		#region Public methods
		
		public void Update_RawGridRow(string[] Data)
		{
			foreach (DataGridViewRow oRow in Grid_SpyRaw.Rows)
			{
				if (oRow.Cells[GRID_RAW_KEY_COL].Value.ToString().Equals(Data[GRID_RAW_KEY_COL]))
				{
					for (int i = 2; i< oRow.Cells.Count; i++)
					{
						oRow.Cells[i].Value = Data[i];
					}
					
					return;
				}
			}
			
			Add_RawGridRow(Data);
		}
		
		public void Update_EngGridRow(object[] Data)
		{
            Update_EngGridRow(Data, false, -1);
		}
		
		public void Update_EngGridRow(object[] Data, bool Virtual, int RowIndex)
		{
            DataGridViewRow oRow = null;

            if (RowIndex != -1) //Index of the grid row to update given as argument
            {
                oRow = Grid_SpyEngineering.Rows[RowIndex]; //Go straight to that row
            }
            else //Index of the grid row to update not defined
            {
                //Search for the row having the same name as the 'Data' packet
                for (int iRow = 0; iRow < Grid_SpyEngineering.Rows.Count; iRow++)
                {
                    if ((Grid_SpyEngineering.Rows[iRow].Cells[GRID_SPYENG_MSG_ID].Value.ToString().Equals(Data[GRID_SPYENG_MSG_ID].ToString()))
                        && (Grid_SpyEngineering.Rows[iRow].Cells[GRID_SPYENG_NAME].Value.ToString().Equals(Data[GRID_SPYENG_NAME].ToString())))
                    {
                        oRow = Grid_SpyEngineering.Rows[iRow];
                        break;
                    }
                }
            }

            if (!(oRow == null)) //The row to update has been found
            {
                //Raw value
                if (!Virtual)
                {
                    oRow.Cells[GRID_SPYENG_VALUE - 1].Value = Data[GRID_SPYENG_VALUE - 1].ToString();
                }

                //Formated value
                double CurrentVal = (double)Data[GRID_SPYENG_VALUE];
                string CurrentValFormated;
                CANParameterFormat oFormat = (CANParameterFormat)Data[GRID_SPYENG_FORMAT];

                if (!(oFormat == null))
                {
                    CurrentValFormated = oFormat.GetParameterFormatedValue(CurrentVal);
                }
                else
                {
                    CurrentValFormated = CurrentVal.ToString();
                }

                oRow.Cells[GRID_SPYENG_VALUE].Value = CurrentValFormated;

                //Alarm colors application
                Color CellBackColor = (Color)Data[GRID_SPYENG_ALARM_BACKCOLOR];
                Color CellForeColor = (Color)Data[GRID_SPYENG_ALARM_FORECOLOR];

                if (CellBackColor.Equals(Color.Empty) || CellForeColor.Equals(Color.Empty))
                {
                    CellBackColor = oRow.Cells[0].Style.BackColor; //Default cell backcolor
                    CellForeColor = oRow.Cells[0].Style.ForeColor; //Default cell forecolor
                }

                oRow.Cells[GRID_SPYENG_VALUE].Style.BackColor = CellBackColor;
                oRow.Cells[GRID_SPYENG_VALUE].Style.ForeColor = CellForeColor;

                //Min / Max value update
                if ((CurrentVal < (double)oRow.Cells[GRID_SPYENG_VALUE + 1].Tag) || (oRow.Cells[GRID_SPYENG_VALUE + 1].Value == null))
                {
                    oRow.Cells[GRID_SPYENG_VALUE + 1].Value = CurrentValFormated;
                    oRow.Cells[GRID_SPYENG_VALUE + 1].Tag = CurrentVal;
                    oRow.Cells[GRID_SPYENG_VALUE + 1].Style.BackColor = CellBackColor;
                    oRow.Cells[GRID_SPYENG_VALUE + 1].Style.ForeColor = CellForeColor;
                }

                if ((CurrentVal > (double)oRow.Cells[GRID_SPYENG_VALUE + 2].Tag) || (oRow.Cells[GRID_SPYENG_VALUE + 2].Value == null))
                {
                    oRow.Cells[GRID_SPYENG_VALUE + 2].Value = CurrentValFormated;
                    oRow.Cells[GRID_SPYENG_VALUE + 2].Tag = CurrentVal;
                    oRow.Cells[GRID_SPYENG_VALUE + 2].Style.BackColor = CellBackColor;
                    oRow.Cells[GRID_SPYENG_VALUE + 2].Style.ForeColor = CellForeColor;
                }
            }
            else //The row doesn't exist yet, we have to create it
            {
                if (Virtual) Add_EngGridRowVirtual(Data);
                else Add_EngGridRow(Data);
            }
		}
		
		public void Update_VirtualChannelValue(object[] Data)
		{
            Update_EngGridRow(Data, true, -1);
		}
		
		public void HideActiveRow()
		{
			if (Grid_SpyRaw.ContainsFocus)
			{
				foreach (DataGridViewCell oCell in Grid_SpyRaw.SelectedCells)
				{
					if (Grid_SpyRaw.Rows[oCell.RowIndex].Visible)
					{
						Grid_SpyRaw.Rows[oCell.RowIndex].Visible = false;
					}
				}
			}
			else if (Grid_SpyEngineering.ContainsFocus)
			{
				foreach (DataGridViewCell oCell in Grid_SpyEngineering.SelectedCells)
				{
					if (Grid_SpyEngineering.Rows[oCell.RowIndex].Visible)
					{
						Grid_SpyEngineering.Rows[oCell.RowIndex].Visible = false;
					}
				}
			}
		}
		
		public void ShowHiddenRows()
		{
			if (Grid_SpyRaw.ContainsFocus)
			{
				foreach(DataGridViewRow oRow in Grid_SpyRaw.Rows)
        		{
					if (oRow.Visible == false)
					{
						oRow.Visible = true;
					}
        		}
			}
			else if (Grid_SpyEngineering.ContainsFocus)
			{
				foreach(DataGridViewRow oRow in Grid_SpyEngineering.Rows)
        		{
					if (oRow.Visible == false)
					{
						oRow.Visible = true;
					}
        		}
			}
		}
		
		public void Clear_RawGrid()
		{
			Grid_SpyRaw.Rows.Clear();
		}
		
		public void Clear_EngGrid()
		{
			Grid_SpyEngineering.Rows.Clear();
		}
		
		public int Get_RawMessageCount()
		{
			return(Grid_SpyRaw.Rows.Count);
		}
		
		#endregion
		
		#region Events handling methods
		
		protected virtual void OnRawGridColumnsVisibleChanged(RawGridColVisibleChangedEventArgs e)
		{
			EventHandler<RawGridColVisibleChangedEventArgs> Handler = RawGridColumnsVisibleChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnEngGridColumnsVisibleChanged(EngGridColVisibleChangedEventArgs e)
		{
			EventHandler<EngGridColVisibleChangedEventArgs> Handler = EngGridColumnsVisibleChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		#endregion
	}
	
	#region Grids columns visible changed event argument
	
	public class RawGridColVisibleChangedEventArgs : EventArgs
	{
		public SpyRaw_Grid_Columns ColumnsVisible {get; set;}
	}
	
	public class EngGridColVisibleChangedEventArgs : EventArgs
	{
		public SpyEngineering_Grid_Columns ColumnsVisible {get; set;}
	}
	
	#endregion
}
