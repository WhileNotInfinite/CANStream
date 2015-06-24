/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 7/21/2014
 * Time: 12:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.ComponentModel; //BackgroundWorker
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Advanced cycle edition form
	/// </summary>
	public partial class Frm_CycleEdition : Form
	{
		#region Private sub-classes
		
		private class VirtualVariable
		{
			#region Enums
			
			public enum VariableSource
			{
				None       = 0,
				AcqChannel = 1,
				Signal     = 2,
			}
			
			#endregion
			
			#region public members
			
			public VariableSource Source;
			public object ParentItem;
			public string Name;
			
			#endregion
			
			public VirtualVariable()
			{
				Source = VariableSource.None;
				ParentItem = null;
				Name = "";
			}
		}
		
		#endregion
		
		#region Private members
		
		//Objects
		private CycleEditionConfiguration oCycleCfg;
		
		private CANStreamCycle oCycle;
		
		private ImportDataFile PreCycleDataFile;
		private ImportDataFile InCycleDataFile;
		private ImportDataFile PostCycleDataFile;
		private ImportDataFile CurrentDataFile;
		
		//Flying Grid cycle element controls
		private ComboBox GrdElement_CmbBox;
		private TreeView GrdElement_TreeView;
		
		//Variables
		private bool bFormInit;
		private List<VirtualVariable> VirtualVariablesTable;
		string sCyclePath;
		private int ParameterCnt;
		
		#endregion
		
		public Frm_CycleEdition(CANMessagesConfiguration CanCfg)
		{
			InitializeComponent();
			
			//Form objects initialization
			oCycleCfg = new CycleEditionConfiguration();
			oCycleCfg.CanConfiguration = CanCfg;
			
			oCycle = null;
			
			Load_VirtualLibraries();
			Load_SignalLibraries();
			
			PreCycleDataFile  = new ImportDataFile();
			InCycleDataFile   = new ImportDataFile();
			PostCycleDataFile = new ImportDataFile();
			CurrentDataFile = null;
			
			VirtualVariablesTable = null;
			sCyclePath = "";
		}
		
		public Frm_CycleEdition(CycleEditionConfiguration oCfg)
		{
			InitializeComponent();
			
			//Form objects initialization
			if (!(oCfg == null))
			{
				oCycleCfg = oCfg;
			}
			else
			{
				oCycleCfg = new CycleEditionConfiguration();
				oCycleCfg.CanConfiguration = null;
				
				Load_VirtualLibraries();
				Load_SignalLibraries();
				
				PreCycleDataFile  = new ImportDataFile();
				InCycleDataFile   = new ImportDataFile();
				PostCycleDataFile = new ImportDataFile();
			}
			
			oCycle = null;
		
			CurrentDataFile = null;
			
			VirtualVariablesTable = null;
			sCyclePath = "";
		}
		
		#region Control events
		
		#region Form
		
		private void Frm_CycleEditionLoad(object sender, EventArgs e)
		{
			//Form controls initialization
			InitForm();
		}
		
		private void Frm_CycleEditionShown(object sender, EventArgs e)
		{
			SetControlsInForm();
			this.WindowState = FormWindowState.Maximized;
			
			if (!(oCycleCfg == null))
			{
				Show_CycleConfiguration();
			}
		}
		
		private void Frm_CycleEditionResize(object sender, EventArgs e)
		{
			SetControlsInForm();
		}
		
		private void SplitContainer1SplitterMoved(object sender, SplitterEventArgs e)
		{
			SetControlsInForm();
			Plot_Cycle();
		}
		
		private void Frm_CycleEditionFormClosing(object sender, FormClosingEventArgs e)
		{
			//Cycle creation configuration saving
			if (oCycleCfg.bModified)
			{
				DialogResult Rep = MessageBox.Show("The current cycle configuration has been modified, do you want save changes ?", Application.ProductName,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				
				switch (Rep)
				{
					case DialogResult.Yes:
						
						Save_CycleConfiguration();
						break;
						
					case DialogResult.No:
						
						break;
						
					case DialogResult.Cancel:
						
						return;
				}
			}
		}
		
		#endregion
		
		#region ToolStrip
		
		private void TSB_NewClick(object sender, EventArgs e)
		{
			New_CycleConfiguration();
		}
		
		private void TSB_OpenClick(object sender, EventArgs e)
		{
			Load_CycleConfiguration();
		}
		
		private void TSB_SaveClick(object sender, EventArgs e)
		{
			Save_CycleConfiguration();
		}
		
		private void TSB_LoadCanConfigClick(object sender, EventArgs e)
		{
			Load_CanConfiguration();
		}
		
		private void TSB_ReLoad_VirtualLibrariesClick(object sender, EventArgs e)
		{
			Load_VirtualLibraries();
		}
		
		private void TSB_ReLoad_SignalLibrariesClick(object sender, EventArgs e)
		{
			Load_SignalLibraries();
		}
		
		private void TSB_MakeCycleClick(object sender, EventArgs e)
		{
			Launch_Cycle_Creation();
		}
		
		private void TSB_StopMakeCycleClick(object sender, EventArgs e)
		{
			BGWrk_CycleMake.CancelAsync();
		}
		
		#endregion
		
		#region Properties grids
		
		private void CmdFileBrowserClick(object sender, EventArgs e)
		{
			DataGridView GridOwner = (sender as Control).Parent as DataGridView;
				
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.InitialDirectory = "";
			Dlg_OpenFile.Filter = CANStreamConstants.DataFileFilter;
			Dlg_OpenFile.FilterIndex = CANStreamConstants.DataFileFilterIndex;
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				GridOwner.Rows[1].Cells[0].Value = Path.GetFileName(Dlg_OpenFile.FileName);
				
				if (GridOwner.Name.Equals(Grid_PreCycleProperties.Name))
				{
					Load_DataFile(Dlg_OpenFile.FileName, CyclePart.PreCycle);
				}
				else if (GridOwner.Name.Equals(Grid_CycleProperties.Name))
				{
					Load_DataFile(Dlg_OpenFile.FileName, CyclePart.InCycle);
				}
				else if (GridOwner.Name.Equals(Grid_PostCycleProperties.Name))
				{
					Load_DataFile(Dlg_OpenFile.FileName, CyclePart.PostCycle);
				}
			}
		}
		
		#region Grid_PreCycleProperties
		
		private void Grid_PreCyclePropertiesCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (bFormInit || e.RowIndex != 0) return;
			
			Set_CyclePartTimeValue(Grid_PreCycleProperties.Rows[0].Cells[0].Value.ToString(), CyclePart.PreCycle);
		}
		
		private void Grid_PreCyclePropertiesCellClick(object sender, DataGridViewCellEventArgs e)
		{
			SetFileBrowserCommand(Grid_PreCycleProperties, e.RowIndex);
		}
		
		private void Grid_PreCyclePropertiesLeave(object sender, EventArgs e)
		{
			Grid_PreCycleProperties.Controls[2].Visible = false;
		}
		
		#endregion
		
		#region Grid_CycleProperties
		
		private void Grid_CyclePropertiesCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (bFormInit || e.RowIndex != 0) return;
			
			Set_CyclePartTimeValue(Grid_CycleProperties.Rows[0].Cells[0].Value.ToString(), CyclePart.InCycle);
		}
		
		private void Grid_CyclePropertiesCellClick(object sender, DataGridViewCellEventArgs e)
		{
			SetFileBrowserCommand(Grid_CycleProperties, e.RowIndex);
		}
		
		private void Grid_CyclePropertiesLeave(object sender, EventArgs e)
		{
			Grid_CycleProperties.Controls[2].Visible = false;
		}
		
		#endregion
		
		#region Grid_PostCycleProperties
		
		private void Grid_PostCyclePropertiesCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (bFormInit || e.RowIndex != 0) return;
			
			Set_CyclePartTimeValue(Grid_PostCycleProperties.Rows[0].Cells[0].Value.ToString(), CyclePart.PostCycle);
		}
		
		private void Grid_PostCyclePropertiesCellClick(object sender, DataGridViewCellEventArgs e)
		{
			SetFileBrowserCommand(Grid_PostCycleProperties, e.RowIndex);
		}
		
		private void Grid_PostCyclePropertiesLeave(object sender, EventArgs e)
		{
			Grid_PostCycleProperties.Controls[2].Visible = false;
		}
		
		#endregion
		
		#endregion
		
		#region Grid Cycle elements
		
		private void Grid_CycleElementsCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (bFormInit || e.RowIndex == -1) return;
			
			if (e.ColumnIndex == 0 || e.ColumnIndex == 2 || e.ColumnIndex == 4) //Data source changed
			{
				CyclePart ePart;
				
				CycleDataSource eSource = (CycleDataSource)Enum.Parse(typeof(CycleDataSource),
                                          Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
				
				CycleParameter oCycleParam = oCycleCfg.GetCycleParameter(Grid_CycleElements.Rows[e.RowIndex].HeaderCell.Tag.ToString(),
				                                                         Grid_CycleElements.Rows[e.RowIndex].HeaderCell.Value.ToString());
				
				if (oCycleParam == null)
				{
					return;
				}
				
				switch (e.ColumnIndex)
				{
					case 0:
						ePart = CyclePart.PreCycle;
						break;
					case 2:
						ePart = CyclePart.InCycle;
						break;
					case 4:
						ePart = CyclePart.PostCycle;
						break;
					default:
						return;
				}
				
				CycleDataPart DataPart = oCycleParam.GetDataParameterDataPart(ePart);
				
				//Default data value
				switch (eSource)
				{
					case CycleDataSource.None:
						
						DataPart.Source = eSource;
						DataPart.Library = "None";
						DataPart.Data = "0";
						
						Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "0";
						Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = true;
						break;
						
					case CycleDataSource.Default:
						
						DataPart.Source = eSource;
						DataPart.Library = "None";
						DataPart.Data = "0";
						
						Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "0";
						Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = true;
						break;
						
					case CycleDataSource.Constant:
						
						DataPart.Source = eSource;
						DataPart.Library = "None";
						DataPart.Data = "0";
						
						Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = "0";
						Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = false;
						break;
						
					case CycleDataSource.VirtualChannel:
						
						if (!(oCycleCfg.VirtualChannelLibCollection == null))
						{
							if (!(oCycleCfg.VirtualChannelLibCollection.Libraries.Count == 0))
							{
								//First non-empty library searching
								int iLib = 0;
								foreach (CS_VirtualChannelsLibrary oLib in oCycleCfg.VirtualChannelLibCollection.Libraries)
								{
									if (oLib.Channels.Count > 0)
									{
										break;
									}
									else
									{
										iLib++;
									}
								}
								
								if (iLib < oCycleCfg.VirtualChannelLibCollection.Libraries.Count)
								{
									DataPart.Source  = eSource;
									DataPart.Library = oCycleCfg.VirtualChannelLibCollection.Libraries[iLib].Name;
									DataPart.Data    = oCycleCfg.VirtualChannelLibCollection.Libraries[iLib].Channels[0].Name;
									
									Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = oCycleCfg.VirtualChannelLibCollection.Libraries[iLib].Channels[0].Name;
									Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = true;
								}
								else
								{
									MessageBox.Show("No virtual channel available ! None of the libraries loaded contains a valid channel", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
								}
							}
							else
							{
								MessageBox.Show("No virtual channel library loaded !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							}
						}
						else
						{
							MessageBox.Show("No virtual channel library loaded !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						}
						
						break;
						
					case CycleDataSource.BuiltSignal:
						
						if (!(oCycleCfg.BuiltInSignalLibCollection == null))
						{
							if (!(oCycleCfg.BuiltInSignalLibCollection.Libraries.Count == 0))
							{
								//First non-empty library searching
								int iLib = 0;
								foreach (CS_BuiltInSignalLibrary oLib in oCycleCfg.BuiltInSignalLibCollection.Libraries)
								{
									if (oLib.Signals.Count > 0)
									{
										break;
									}
									else
									{
										iLib++;
									}
								}
								
								if (iLib < oCycleCfg.BuiltInSignalLibCollection.Libraries.Count)
								{
									DataPart.Source  = eSource;
									DataPart.Library = oCycleCfg.BuiltInSignalLibCollection.Libraries[iLib].Name;
									DataPart.Data    =  oCycleCfg.BuiltInSignalLibCollection.Libraries[iLib].Signals[0].Name;
										
									Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = oCycleCfg.BuiltInSignalLibCollection.Libraries[iLib].Signals[0].Name;
									Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = true;
								}
								else
								{
									MessageBox.Show("No built-in signal available ! None of the libraries loaded contains a valid signal", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
								}
							}
							else
							{
								MessageBox.Show("No built-in signal library loaded !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							}
						}
						else
						{
							MessageBox.Show("No built-in signal library loaded !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						}
						
						break;
						
					case CycleDataSource.AcqData:
						
						switch (ePart)
						{
							case CyclePart.PreCycle:
								
								if (!(PreCycleDataFile == null))
								{
									if (PreCycleDataFile.Channels.Count > 0)
									{
										DataPart.Source  = eSource;
										DataPart.Library = "File";
										DataPart.Data    = PreCycleDataFile.Channels[0].ChannelName;
										
										Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = PreCycleDataFile.Channels[0].ChannelName;
										Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = true;
									}
									else
									{
										MessageBox.Show("The data file loaded for the pre-cycle part doesn't contain any data channel", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
									}
								}
								else
								{
									MessageBox.Show("No data file loaded for the pre-cycle part !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
								}
								
								break;
								
							case CyclePart.InCycle:
								
								if (!(InCycleDataFile == null))
								{
									if (InCycleDataFile.Channels.Count > 0)
									{
										DataPart.Source  = eSource;
										DataPart.Library = "File";
										DataPart.Data    = InCycleDataFile.Channels[0].ChannelName;
										
										Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = InCycleDataFile.Channels[0].ChannelName;
										Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = true;
									}
									else
									{
										MessageBox.Show("The data file loaded for the in-cycle part doesn't contain any data channel", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
									}
								}
								else
								{
									MessageBox.Show("No data file loaded for the in-cycle part !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
								}
								
								break;
								
							case CyclePart.PostCycle:
								
								if (!(PostCycleDataFile == null))
								{
									if (InCycleDataFile.Channels.Count > 0)
									{
										DataPart.Source  = eSource;
										DataPart.Library = "File";
										DataPart.Data    = PostCycleDataFile.Channels[0].ChannelName;
										
										Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = PostCycleDataFile.Channels[0].ChannelName;
										Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].ReadOnly = true;
									}
									else
									{
										MessageBox.Show("The data file loaded for the post-cycle part doesn't contain any data channel", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
									}
								}
								else
								{
									MessageBox.Show("No data file loaded for the post-cycle part !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
								}
								
								break;
						}
						
						break;
				}
			}
			else //Constant data value changed
			{
				CycleDataSource eSource = (CycleDataSource)Enum.Parse(typeof(CycleDataSource),
				                           Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex -1].Value.ToString());
				
				if (eSource.Equals(CycleDataSource.Constant))
				{
					string sValue = Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
					
					if (!(sValue.Equals("")))
					{
						double Val = 0;
						
						if (double.TryParse(sValue, out Val))
						{
						
							string CtrlTag = e.ColumnIndex.ToString() + "," + e.RowIndex.ToString();
							Set_DataValue (CtrlTag, "None", sValue);
						}
						else
						{
							MessageBox.Show("The value must be a number !", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
						}
					}
					else
					{
						MessageBox.Show("The value is empty !", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
					}
				}
			}
		}
		
		private void Grid_CycleElementsCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex == -1) return;
			
			if (e.ColumnIndex == 1 || e.ColumnIndex == 3 || e.ColumnIndex == 5)
			{
				CyclePart ePart;
				
				CycleDataSource eSource = (CycleDataSource)Enum.Parse(typeof(CycleDataSource),
                                          Grid_CycleElements.Rows[e.RowIndex].Cells[e.ColumnIndex -1].Value.ToString());
				
				switch (e.ColumnIndex)
				{
					case 1:
						ePart = CyclePart.PreCycle;
						break;
					case 3:
						ePart = CyclePart.InCycle;
						break;
					case 5:
						ePart = CyclePart.PostCycle;
						break;
					default:
						return;
				}
				
				Rectangle Cell = Grid_CycleElements.GetCellDisplayRectangle(e.ColumnIndex,e.RowIndex,true);
				
				switch (eSource)
				{
					case CycleDataSource.AcqData:
						
						GrdElement_TreeView.Visible = false;
						
						GrdElement_CmbBox.Top    = Cell.Top;
						GrdElement_CmbBox.Left   = Cell.Left;
						GrdElement_CmbBox.Height = Cell.Height;
						GrdElement_CmbBox.Width  = Cell.Width;
						
						switch (ePart)
						{
							case CyclePart.PreCycle:
								
								Fill_GrdElement_CmbBox(PreCycleDataFile);
								break;
								
							case CyclePart.InCycle:
								
								Fill_GrdElement_CmbBox(InCycleDataFile);
								break;
								
							case CyclePart.PostCycle:
								
								Fill_GrdElement_CmbBox(PostCycleDataFile);
								break;
						}
						
						GrdElement_CmbBox.Tag = e.ColumnIndex.ToString() + "," + e.RowIndex.ToString();
						GrdElement_CmbBox.Visible = true;
						
						break;
						
					case CycleDataSource.BuiltSignal:
						
						GrdElement_CmbBox.Visible = false;
						
						GrdElement_TreeView.Top    = Cell.Top;
						GrdElement_TreeView.Left   = Cell.Left;
						GrdElement_TreeView.Width  = Cell.Width;
						GrdElement_TreeView.Height = Grid_CycleElements.Height - Cell.Top - 50;
						
						Fill_GrdElement_TreeView((object)oCycleCfg.BuiltInSignalLibCollection);
						
						GrdElement_TreeView.Tag = e.ColumnIndex.ToString() + "," + e.RowIndex.ToString();
						GrdElement_TreeView.Visible = true;
						GrdElement_TreeView.Focus();
						
						break;
						
					case CycleDataSource.VirtualChannel:
						
						GrdElement_CmbBox.Visible = false;
						
						GrdElement_TreeView.Top    = Cell.Top;
						GrdElement_TreeView.Left   = Cell.Left;
						GrdElement_TreeView.Width  = Cell.Width;
						GrdElement_TreeView.Height = Grid_CycleElements.Height - Cell.Top - 50;
						
						Fill_GrdElement_TreeView((object)oCycleCfg.VirtualChannelLibCollection);
						
						GrdElement_TreeView.Tag = e.ColumnIndex.ToString() + "," + e.RowIndex.ToString();
						GrdElement_TreeView.Visible = true;
						GrdElement_TreeView.Focus();
						
						break;
					default:
						
						GrdElement_CmbBox.Visible = false;
						GrdElement_TreeView.Visible = false;
						break;
				}
			}
		}
		
		#endregion
		
		#region GrdElement_CmbBox
		
		private void GrdElement_CmbBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(GrdElement_CmbBox.SelectedIndex == -1))
			{
				Set_DataValue(GrdElement_CmbBox.Tag.ToString(),
				              "File",
				              GrdElement_CmbBox.Text);
				
				GrdElement_CmbBox.Visible = false;
			}
		}
		
		private void GrdElement_CmbBox_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyData.Equals(Keys.Escape))
			{
				GrdElement_CmbBox.Visible = false;
			}
		}
		
		private void GrdElement_CmbBox_LostFocus(object sender, EventArgs e)
		{
			GrdElement_CmbBox.Visible = false;
		}
		
		#endregion
		
		#region GrdElement_TreeView
		
		private void GrdElement_TreeView_NodeMouseDoubleClick(object sender, EventArgs e)
		{
			if (GrdElement_TreeView.SelectedNode.Level == 1)
			{
			
				Set_DataValue(GrdElement_TreeView.Tag.ToString(),
			              	GrdElement_TreeView.SelectedNode.Parent.Name, 
			              	GrdElement_TreeView.SelectedNode.Name);
				
				GrdElement_TreeView.Visible = false;
			}
		}
		
		private void GrdElement_TreeView_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData)
			{
				case Keys.Escape:
					
					GrdElement_TreeView.Visible = false;
					break;
					
				case Keys.Enter:
					
					if (!(GrdElement_TreeView.SelectedNode == null))
					{
						if (GrdElement_TreeView.SelectedNode.Level == 1)
						{
							Set_DataValue(GrdElement_TreeView.Tag.ToString(),
					              	GrdElement_TreeView.SelectedNode.Parent.Name, 
					              	GrdElement_TreeView.SelectedNode.Name);
						
							GrdElement_TreeView.Visible = false;
						}
					}
					
					break;
			}
		}
		
		private void GrdElement_TreeView_LostFocus(object sender, EventArgs e)
		{
			GrdElement_TreeView.Visible = false;
		}
		
		#endregion
		
		#region BGWrk_CycleMake
		
		private void BGWrk_CycleMakeDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker Worker = sender as BackgroundWorker;
			Make_Cycle(Worker, e.Argument.ToString());
		}
		
		private void BGWrk_CycleMakeProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage >= 0 && e.ProgressPercentage <= 100)
			{
				Status_Progress.Value = e.ProgressPercentage;
				
				if (!(StatusLbl_Action.Text.Equals(e.UserState.ToString())))
				{
					StatusLbl_Action.Text = e.UserState.ToString();
				}
			}
		}
		
		private void BGWrk_CycleMakeRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			TSB_MakeCycle.Enabled = true;
			TSB_StopMakeCycle.Visible = false;
			StatusLbl_ActionCaption.Visible = false;
			StatusLbl_Action.Visible = false;;
			Status_Progress.Visible = false;
			
			if (!e.Cancelled)
			{
				MessageBox.Show("Cycle created !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				
				//Update cycle graph
				if (!(oCycle ==  null))
				{
					oCycle.CreateGraphicSeries();
					
					if (!(oCycle.GraphSeries.FormatedSeries == null))
					{
						Plot_Cycle();
					}
					else
					{
						MessageBox.Show("The cycle doesn't contain any data to plot !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
		}
		
		#endregion
		
		#region Context_Graph
		
		private void Context_GraphMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem Item = (ToolStripMenuItem) sender;
        	Item.Checked=!Item.Checked;
        	
        	oCycle.GraphSeries.SetFormatedSerieVisible(Item.Text,Item.Checked);
        	
        	Plot_Cycle();
		}
		
		#endregion
		
		#endregion
		
		#region Private methodes
		
		#region Form's controls position and size managment
		
		private void InitForm()
		{
			bFormInit = true;
			
			if (!(oCycleCfg.CanConfiguration == null))
			{
				Show_CanParameters(true);
			}
			else
			{
				DialogResult Rep = MessageBox.Show("No CAN configuration loaded !\nWould you like to load one ?",
				                                   Application.ProductName,
				                                   MessageBoxButtons.YesNoCancel,
				                                   MessageBoxIcon.Exclamation);
				
				switch (Rep)
				{
					case DialogResult.Yes: //Load a CAN Configuration file
						Load_CanConfiguration();
						break;
					case DialogResult.No: //No action
						break;
					case DialogResult.Cancel: //Close the form
						this.Close();
						break;
				}
			}
			
			//Properties grids init
			InitGridProperties(Grid_PreCycleProperties);
			InitGridProperties(Grid_CycleProperties);
			InitGridProperties(Grid_PostCycleProperties);
			
			//Create Grid Cycle element flying combo box
			GrdElement_CmbBox = new ComboBox();
			
			GrdElement_CmbBox.Visible = false;
			
			GrdElement_CmbBox.SelectedIndexChanged += new EventHandler(GrdElement_CmbBox_SelectedIndexChanged);
			GrdElement_CmbBox.KeyDown              += new KeyEventHandler(GrdElement_CmbBox_KeyDown);
			GrdElement_CmbBox.LostFocus            += new EventHandler(GrdElement_CmbBox_LostFocus);
			
			Grid_CycleElements.Controls.Add(GrdElement_CmbBox);
			
			//Create Grid Cycle element flying treeview
			GrdElement_TreeView = new TreeView();
			
			GrdElement_TreeView.Visible = false;
			GrdElement_TreeView.ImageList = Img_GrdElement_TreeView;
			
			GrdElement_TreeView.NodeMouseDoubleClick += new TreeNodeMouseClickEventHandler(GrdElement_TreeView_NodeMouseDoubleClick);
			GrdElement_TreeView.KeyDown              += new KeyEventHandler(GrdElement_TreeView_KeyDown);
			GrdElement_TreeView.LostFocus            += new EventHandler(GrdElement_TreeView_LostFocus);
			
			Grid_CycleElements.Controls.Add(GrdElement_TreeView);
			
			bFormInit = false;	
		}
		
		private void InitGridProperties(DataGridView oGrid)
		{
			oGrid.Rows.Clear();
			oGrid.Rows.Add(2);
			
			oGrid.Rows[0].Cells[0].Value = "0";		//Default time length
			oGrid.Rows[0].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleRight;
			
			oGrid.Rows[1].Cells[0].Value = "None";	//Default data file
			oGrid.Rows[1].Cells[0].ReadOnly = true;
			oGrid.Rows[1].Cells[0].Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
			
			
			//File browser command button creation
			Button CmdFileBrower = new Button();
			CmdFileBrower.Name = "CmdFileBrower_" + oGrid.Name;
			CmdFileBrower.Text = "...";
			CmdFileBrower.Width = 24;
			CmdFileBrower.Height = 24;
			CmdFileBrower.Visible = false;
			CmdFileBrower.Click +=new EventHandler(CmdFileBrowserClick);
			
			oGrid.Controls.Add(CmdFileBrower);
		}
		
		private void SetControlsInForm()
		{
			const int PosOffset = 5;
			Rectangle Cell1, Cell2;
			
			//Resize Grid_CycleElements columns
			Grid_CycleElements.RowHeadersWidth  = (int)(Grid_CycleElements.Width * 0.16); //Parameter name
			Grid_CycleElements.Columns[0].Width = (int)(Grid_CycleElements.Width * 0.10); //Precycle source
			Grid_CycleElements.Columns[1].Width = (int)(Grid_CycleElements.Width * 0.18); //Precyle data
			Grid_CycleElements.Columns[2].Width = (int)(Grid_CycleElements.Width * 0.10); //Cycle source
			Grid_CycleElements.Columns[3].Width = (int)(Grid_CycleElements.Width * 0.18); //Cyle data
			Grid_CycleElements.Columns[4].Width = (int)(Grid_CycleElements.Width * 0.10); //Postcycle source
			Grid_CycleElements.Columns[5].Width = (int)(Grid_CycleElements.Width * 0.18); //Postcyle data
			
			//Set Pre-cycle grid properties and label
			Cell1 = Grid_CycleElements.GetColumnDisplayRectangle(0,true);
			Cell2 = Grid_CycleElements.GetColumnDisplayRectangle(1,true);
			
			Grid_PreCycleProperties.Left = Cell1.Left + PosOffset;
			Grid_PreCycleProperties.Width = Cell1.Width + Cell2.Width;
			Lbl_PreCycle.Left = Cell1.Left + PosOffset;
			Lbl_PreCycle.Width = Cell1.Width + Cell2.Width;
			SetGridProperties(Grid_PreCycleProperties);
			
			Lbl_PropTimeLen.Width = Cell1.Left -5;
			Lbl_PropDataFile.Width = Cell1.Left -5;
			
			//Set Cycle grid properties and label
			Cell1 = Grid_CycleElements.GetColumnDisplayRectangle(2,true);
			Cell2 = Grid_CycleElements.GetColumnDisplayRectangle(3,true);
			
			Grid_CycleProperties.Left = Cell1.Left + PosOffset;
			Grid_CycleProperties.Width = Cell1.Width + Cell2.Width;
			Lbl_Cycle.Left = Cell1.Left + PosOffset;
			Lbl_Cycle.Width = Cell1.Width + Cell2.Width;
			SetGridProperties(Grid_CycleProperties);
			
			//Set Post-cycle grid properties and label
			Cell1 = Grid_CycleElements.GetColumnDisplayRectangle(4,true);
			Cell2 = Grid_CycleElements.GetColumnDisplayRectangle(5,true);
			
			Grid_PostCycleProperties.Left = Cell1.Left + PosOffset;
			Grid_PostCycleProperties.Width = Cell1.Width + Cell2.Width;
			Lbl_PostCycle.Left = Cell1.Left + PosOffset;
			Lbl_PostCycle.Width = Cell1.Width + Cell2.Width;
			SetGridProperties(Grid_PostCycleProperties);
		}
		
		private void SetGridProperties(DataGridView oGrid)
		{
			oGrid.Columns[0].Width = oGrid.Width - 3;
			oGrid.Controls[2].Visible = false;
		}
		
		private void SetFileBrowserCommand(DataGridView oGrid, int iRow)
		{
			//Display or not the file browser command button
			
			Button CmdFileBrowser = oGrid.Controls[2] as Button;
			
			if (iRow == 1)
			{
				Rectangle Cell = oGrid.GetCellDisplayRectangle(0, 1, true);
				
				CmdFileBrowser.Left = Cell.Width - CmdFileBrowser.Width + 3;
				CmdFileBrowser.Top = Cell.Top - 1;
				CmdFileBrowser.Visible = true;
			}
			else
			{
				CmdFileBrowser.Visible = false;
			}
		}
		
		private void Fill_GrdElement_CmbBox(ImportDataFile oDataFile)
		{
			GrdElement_CmbBox.Items.Clear();
			
			if (!(oDataFile == null))
			{
				foreach (ImportDataChannel oChan in oDataFile.Channels)
				{
					GrdElement_CmbBox.Items.Add(oChan.ChannelName);
				}
			}
		}
		
		private void Fill_GrdElement_TreeView(object oLibCollection)
		{
			CS_BuiltInSignalLibCollection oSigLibs = null;
			CS_VCLibrariesCollection oVirtualLibs = null;
			
			TreeNode nLib;
			
			GrdElement_TreeView.Nodes.Clear();
			
			if (!(oLibCollection == null))
			{
			
				if (oLibCollection.GetType().Equals(typeof(CS_BuiltInSignalLibCollection)))
				{
					oSigLibs = oLibCollection as CS_BuiltInSignalLibCollection;
					
					foreach (CS_BuiltInSignalLibrary oLib in oSigLibs.Libraries)
					{
						nLib = GrdElement_TreeView.Nodes.Add(oLib.Name,oLib.Name,0,0);
						
						foreach (CS_BuiltInSignal oSig in oLib.Signals)
						{
							nLib.Nodes.Add(oSig.Name, oSig.Name, 1,1);
						}
					}
				}
				else if (oLibCollection.GetType().Equals(typeof(CS_VCLibrariesCollection)))
				{
					oVirtualLibs = oLibCollection as CS_VCLibrariesCollection;
					
					foreach (CS_VirtualChannelsLibrary oLib in oVirtualLibs.Libraries)
					{
						nLib = GrdElement_TreeView.Nodes.Add(oLib.Name, oLib.Name, 0,0);
						
						foreach (CS_VirtualChannel oChan in oLib.Channels)
						{
							nLib.Nodes.Add(oChan.Name,oChan.Name,2,2);
						}
					}
				}
				
				GrdElement_TreeView.ExpandAll();
			}
		}
		
		#endregion
		
		#region CAN Configuration
		
		private void Load_CanConfiguration()
		{
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.Filter = "CAN Configuration|*.xcc";
			Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{	
				oCycleCfg.CanConfiguration = new CANMessagesConfiguration();
				
				oCycleCfg.bModified = true;
				oCycleCfg.Parameters = new System.Collections.Generic.List<CycleParameter>();
				
				if (oCycleCfg.CanConfiguration.ReadCANConfigurationFile(Dlg_OpenFile.FileName))
				{
					bFormInit = true;
					Show_CanParameters(true);
					bFormInit = false;
				}
				else
				{
					MessageBox.Show("CAN Configuration file reading error !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
		}
		
		private void Show_CanParameters(bool CreateCycleParameters)
		{
			Grid_CycleElements.Rows.Clear();
			
			int TxParamCnt = oCycleCfg.CanConfiguration.GetTxParameterCount(false);
			
			if (TxParamCnt > 0)
			{
				int iRow = 0;
				ParameterCnt = 0;
				
				foreach (CANMessage oMsg in oCycleCfg.CanConfiguration.Messages)
				{
					if (oMsg.RxTx.Equals(CanMsgRxTx.Tx) && (!oMsg.ContainsVirtualParameters()))
					{
						foreach (CANParameter oParam in oMsg.Parameters)
						{
							Grid_CycleElements.Rows.Add();
							
							CycleParameter oCycleParam = new CycleParameter();
							
							oCycleParam.Name = oParam.Name;
							oCycleParam.MsgId = oMsg.Identifier;
							
							if (CreateCycleParameters) //In case of cycle configuration loading, parameters are already presents
							{
								oCycleCfg.Parameters.Add(oCycleParam);
							}
							
							Grid_CycleElements.Rows[iRow].HeaderCell.Value = oParam.Name;
							Grid_CycleElements.Rows[iRow].HeaderCell.Tag = oMsg.Identifier;
							
							FillDataSourceCell(Grid_CycleElements.Rows[iRow].Cells[0]);
							FillDataSourceCell(Grid_CycleElements.Rows[iRow].Cells[2]);
							FillDataSourceCell(Grid_CycleElements.Rows[iRow].Cells[4]);
							
							Grid_CycleElements.Rows[iRow].Cells[1].Value = "0";
							Grid_CycleElements.Rows[iRow].Cells[3].Value = "0";
							Grid_CycleElements.Rows[iRow].Cells[5].Value = "0";
							
							iRow++;
							ParameterCnt++;
						}
					}
				}
			}
			else
			{
				MessageBox.Show("The current CAN configuration doesn't contain any Tx message !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			
			//Is there any paramater in the cycle
			if (ParameterCnt == 0)
			{
				MessageBox.Show("The current CAN configuration doesn't contain any valid Tx CAN parameter !\nMake sure that cycle parameters are not part of messages containing virtual CAN signals.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}
		
		private void FillDataSourceCell(DataGridViewCell oCell)
		{
			DataGridViewComboBoxCell oCmbCell = oCell as DataGridViewComboBoxCell;
			string[] SrcList = Enum.GetNames(typeof(CycleDataSource));
			
			oCmbCell.Items.Clear();
			
			foreach (string Src in SrcList)
			{
				oCmbCell.Items.Add(Src);
			}
			
			oCmbCell.Value = SrcList[1];
		}
		
		#endregion
		
		#region Data file
		
		private void Load_DataFile(string fPath, CyclePart DestinationPart)
		{
			int iColCheck = -1;
			
			if (!(File.Exists(fPath)))
			{
				MessageBox.Show("Data file " + Path.GetFileName(fPath) + " doesn't exist !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			ImportDataFile oDataFile = new ImportDataFile();
			
			StatusLbl_ActionCaption.Text = "Loading data file...";
			StatusLbl_Action.Text = Path.GetFileName(fPath);
			StatusLbl_ActionCaption.Visible = true;
			StatusLbl_Action.Visible = true;
			Cursor = Cursors.WaitCursor;
			
			if (oDataFile.ReadDataFile(fPath))
			{
				StatusLbl_ActionCaption.Visible = false;
				StatusLbl_Action.Visible = false;
				Cursor = Cursors.Default;
				
				DataGridView oGrid = null;
				CyclePartProperties CyclePartProps =  null;
				double DataTimeLen = oDataFile.Time[oDataFile.Time.Count - 1];
				
				switch (DestinationPart)
				{
					case CyclePart.PreCycle:
						
						PreCycleDataFile =  oDataFile;
						CyclePartProps = oCycleCfg.PreCycleProperties;
						oGrid = Grid_PreCycleProperties;
						iColCheck = 0;
						break;
						
					case CyclePart.InCycle:
						
						InCycleDataFile = oDataFile;
						CyclePartProps = oCycleCfg.InCycleProperties;
						oGrid = Grid_CycleProperties;
						iColCheck = 2;
						break;
						
					case CyclePart.PostCycle:
						
						PostCycleDataFile = oDataFile;
						CyclePartProps = oCycleCfg.PostCycleProperties;
						oGrid = Grid_PostCycleProperties;
						iColCheck = 4;
						break;
				}
				
				if (oGrid.Rows[0].Cells[0].Value.Equals("0"))
				{
					oGrid.Rows[0].Cells[0].Value = DataTimeLen.ToString();
				}
				else
				{
					if (!(oGrid.Rows[0].Cells[0].Value.ToString().Equals(DataTimeLen.ToString())))
					{
						DialogResult Rep = MessageBox.Show("Data file time length is different than the cycle part time length set already.\nDo you want update the cycle part time length ?",
						                                   Application.ProductName,MessageBoxButtons.YesNo,MessageBoxIcon.Question);
						
						if (Rep.Equals(DialogResult.Yes))
						{
							oGrid.Rows[0].Cells[0].Value = DataTimeLen.ToString();
						}
						else
						{
							DataTimeLen = double.Parse(oGrid.Rows[0].Cells[0].Value.ToString());
						}
					}
				}
				
				CyclePartProps.DataFile = fPath;
				CyclePartProps.TimeLength = DataTimeLen;
				oCycleCfg.bModified = true;
				
				//Check if data file contains parameters expected in the cycle part
				foreach (DataGridViewRow oRow in Grid_CycleElements.Rows)
				{
					if (oRow.Cells[iColCheck].Value.ToString().Equals(CycleDataSource.AcqData.ToString()))
					{
						if (!(oDataFile.ChannelExists(oRow.Cells[iColCheck + 1].Value.ToString())))
						{
							Set_CycleParamDataToDefault(oRow.Index, DestinationPart);
						}
					}
				}
			}
			else
			{
				StatusLbl_ActionCaption.Visible = false;
				StatusLbl_Action.Visible = false;
				Cursor = Cursors.Default;
				
				MessageBox.Show("Data file reading error !",Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		#endregion
		
		#region Virtual channels
		
		private void Load_VirtualLibraries()
		{
			if (File.Exists(CANStreamTools.CsDataPath + "\\Libraries.xml"))
        	{
        		oCycleCfg.VirtualChannelLibCollection = new CS_VCLibrariesCollection();
        		oCycleCfg.VirtualChannelLibCollection.LoadLibrariesList(CANStreamTools.CsDataPath + "\\Libraries.xml");
        		
        		if (Grid_CycleElements.Rows.Count > 0)
        		{
        			Check_VirtualChannels();
        		}
        	}
		}
		
		private void Check_VirtualChannels()
		{
			foreach (CycleParameter oCycleParam in oCycleCfg.Parameters)
			{
				CyclePart ePart = CyclePart.PreCycle;
				
				while (!(ePart.Equals(CyclePart.None)))
				{
					CycleDataPart oDataPart = oCycleParam.GetDataParameterDataPart(ePart);
					
					if (oDataPart.Source.Equals(CycleDataSource.VirtualChannel))
					{
						if (!(oCycleCfg.VirtualChannelLibCollection.ChannelExistsInLibrary(oDataPart.Library, oDataPart.Data)))
						{
							Set_CycleParamDataToDefault(oCycleParam, ePart);
						}
					}
					
					//Next cycle part
					switch (ePart)
					{
						case CyclePart.PreCycle:
							ePart = CyclePart.InCycle;
							break;
						case CyclePart.InCycle:
							ePart = CyclePart.PostCycle;
							break;
						case CyclePart.PostCycle:
							ePart = CyclePart.None;
							break;
					}
				}
			}
		}
		
		#endregion
		
		#region Built-in signals
		
		private void Load_SignalLibraries()
		{
			if (File.Exists(CANStreamTools.CsDataPath + "\\BuiltInSignals.xml"))
			{
				oCycleCfg.BuiltInSignalLibCollection = new CS_BuiltInSignalLibCollection();
				oCycleCfg.BuiltInSignalLibCollection.LoadLibrariesList(CANStreamTools.CsDataPath + "\\BuiltInSignals.xml");
				
				if (Grid_CycleElements.Rows.Count > 0)
				{
					Check_BuiltInSignals();
				}
			}
		}
		
		private void Check_BuiltInSignals()
		{
			foreach (CycleParameter oCycleParam in oCycleCfg.Parameters)
			{
				CyclePart ePart = CyclePart.PreCycle;
				
				while (!(ePart.Equals(CyclePart.None)))
				{
					CycleDataPart oDataPart = oCycleParam.GetDataParameterDataPart(ePart);
					
					if (oDataPart.Source.Equals(CycleDataSource.BuiltSignal))
					{
						if (!(oCycleCfg.BuiltInSignalLibCollection.SignalExistsInLibrary(oDataPart.Library, oDataPart.Data)))
						{
							Set_CycleParamDataToDefault(oCycleParam, ePart);
						}
					}
					
					//Next cycle part
					switch (ePart)
					{
						case CyclePart.PreCycle:
							ePart = CyclePart.InCycle;
							break;
						case CyclePart.InCycle:
							ePart = CyclePart.PostCycle;
							break;
						case CyclePart.PostCycle:
							ePart = CyclePart.None;
							break;
					}
				}
			}
		}
		
		#endregion
		
		#region CycleConfiguration
		
		private void Set_CyclePartTimeValue(string sValue, CyclePart ePart)
		{
			DataGridView oGrid =  null;
			CyclePartProperties oPartProps = null;
			
			switch (ePart)
			{
				case CyclePart.PreCycle:
					
					oGrid = Grid_PreCycleProperties;
					oPartProps = oCycleCfg.PreCycleProperties;
					break;
					
				case CyclePart.InCycle:
					
					oGrid = Grid_CycleProperties;
					oPartProps = oCycleCfg.InCycleProperties;
					break;
					
				case CyclePart.PostCycle:
					
					oGrid = Grid_PostCycleProperties;
					oPartProps = oCycleCfg.PostCycleProperties;
					break;
			}
			
			if (!(sValue.Equals("")))
			{
				double Val = 0;
				if (double.TryParse(sValue, out Val))
				{
					oPartProps.TimeLength = Val;
					oCycleCfg.bModified = true;
				}
				else
				{
					MessageBox.Show("Value must be a number !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					oGrid.Rows[0].Cells[0].Value = "0";
				}
			}
			else
			{
				MessageBox.Show("Value is empty !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				oGrid.Rows[0].Cells[0].Value = "0";
			}
		}
		
		private void Set_DataValue(string CtrlTag, string Library, string Data)
		{
			object[] ParamInfo = Get_ParamInfoFromCtrlTag(CtrlTag);
			
			if (!(ParamInfo == null))
			{
				CycleParameter oCycleParam = oCycleCfg.GetCycleParameter((string)ParamInfo[1], (string)ParamInfo[0]);
				
				if (!(oCycleParam == null))
				{
					CyclePart ePart = (CyclePart)ParamInfo[2];
					
					switch (ePart)
					{
						case CyclePart.PreCycle:
							
							oCycleParam.PreCycle.Data = Data;
							oCycleParam.PreCycle.Library = Library;
							break;
							
						case CyclePart.InCycle:
							
							oCycleParam.InCycle.Data = Data;
							oCycleParam.InCycle.Library = Library;
							break;
							
						case CyclePart.PostCycle:
							
							oCycleParam.PostCycle.Data = Data;
							oCycleParam.PostCycle.Library = Library;
							break;
					}
					
					int[] CellAdr = Get_CellAddrFromCtrlTag(CtrlTag);
					Grid_CycleElements.Rows[CellAdr[1]].Cells[CellAdr[0]].Value = Data;
				}
			}
		}
		
		private object[] Get_ParamInfoFromCtrlTag(string CtrlTag)
		{
			object[] Info = null;
			
			if (!(CtrlTag.Equals("")))
			{
				int[] CellAdr = Get_CellAddrFromCtrlTag(CtrlTag);
				
				if (!(CellAdr == null))
				{
					Info = new object[3];
					Info[0] = Grid_CycleElements.Rows[CellAdr[1]].HeaderCell.Value.ToString();
					Info[1] = Grid_CycleElements.Rows[CellAdr[1]].HeaderCell.Tag.ToString();
					
					switch (CellAdr[0])
					{
						case 1:
							Info[2] =  CyclePart.PreCycle;
							break;
						case 3:
							Info[2] =  CyclePart.InCycle;
							break;
						case 5:
							Info[2] =  CyclePart.PostCycle;
							break;
					}
				}
			}
			
			return(Info);
		}
		
		private int[] Get_CellAddrFromCtrlTag(string CtrlTag)
		{
			int[] CellAdr =  null;
			
			if (!(CtrlTag.Equals("")))
			{
				int iCol, iRow;
				string[] sCellAdr = CtrlTag.Split(',');
				
				if (int.TryParse(sCellAdr[0], out iCol) && int.TryParse(sCellAdr[1], out iRow))
				{
					CellAdr = new int[2];
					CellAdr[0] = iCol;
					CellAdr[1] = iRow;
				}
			}
			
			return(CellAdr);
		}
		
		private void Save_CycleConfiguration()
		{
			if (oCycleCfg.FilePath.Equals(""))
			{
				Dlg_SaveFile.FileName = "";
				Dlg_SaveFile.Filter = "Cycle creation Configuration|*.x3c";
				Dlg_SaveFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle creation Configuration";
				
				if (Dlg_SaveFile.ShowDialog().Equals(DialogResult.OK))
				{
					oCycleCfg.Save_CycleConfiguration(Dlg_SaveFile.FileName);
				}
			}
			else
			{
				oCycleCfg.Save_CycleConfiguration(oCycleCfg.FilePath);
			}
		}
		
		private void Load_CycleConfiguration()
		{
			if (oCycleCfg.bModified)
			{
				DialogResult Rep = MessageBox.Show("The current cycle configuration has been modified, do you want save changes before to open a new configuration ?", Application.ProductName,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				
				switch (Rep)
				{
					case DialogResult.Yes:
						
						Save_CycleConfiguration();
						break;
						
					case DialogResult.No:
						
						break;
						
					case DialogResult.Cancel:
						
						return;
				}
			}
			
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.Filter = "Cycle creation Configuration|*.x3c";
			Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle creation Configuration";
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				oCycleCfg = new CycleEditionConfiguration();
				
				if(oCycleCfg.Read_CycleConfiguration(Dlg_OpenFile.FileName))
				{
					Show_CycleConfiguration();
				}
				else
				{
					MessageBox.Show("Cycle creation configuration file reading error !", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
				}
			}
		}
		
		private void Show_CycleConfiguration()
		{
			bFormInit = true;
			
			//Cycle part properties
			Show_CyclePartProperties(oCycleCfg.PreCycleProperties , CyclePart.PreCycle);
			Show_CyclePartProperties(oCycleCfg.InCycleProperties  , CyclePart.InCycle);
			Show_CyclePartProperties(oCycleCfg.PostCycleProperties, CyclePart.PostCycle);
			
			//Can configuration
			if (!(oCycleCfg.CanConfiguration == null))
			{
				Show_CanParameters(false);
			}
			else
			{
				Grid_CycleElements.Rows.Clear();
			}
			
			//Cycle parameters
			foreach (CycleParameter oParam in oCycleCfg.Parameters)
			{
				int iRow = Get_ParameterRow(oParam.MsgId, oParam.Name);
				
				if (!(iRow == -1))
				{
					Grid_CycleElements.Rows[iRow].Cells[0].Value = oParam.PreCycle.Source.ToString();
					Grid_CycleElements.Rows[iRow].Cells[1].Value = oParam.PreCycle.Data;
					
					if (Grid_CycleElements.Rows[iRow].Cells[0].Value.ToString().Equals(CycleDataSource.Constant.ToString()))
					{
						Grid_CycleElements.Rows[iRow].Cells[1].ReadOnly = false;
					}
					
					Grid_CycleElements.Rows[iRow].Cells[2].Value = oParam.InCycle.Source.ToString();
					Grid_CycleElements.Rows[iRow].Cells[3].Value = oParam.InCycle.Data;
					
					if (Grid_CycleElements.Rows[iRow].Cells[2].Value.ToString().Equals(CycleDataSource.Constant.ToString()))
					{
						Grid_CycleElements.Rows[iRow].Cells[3].ReadOnly = false;
					}
					
					Grid_CycleElements.Rows[iRow].Cells[4].Value = oParam.PostCycle.Source.ToString();
					Grid_CycleElements.Rows[iRow].Cells[5].Value = oParam.PostCycle.Data;
					
					if (Grid_CycleElements.Rows[iRow].Cells[4].Value.ToString().Equals(CycleDataSource.Constant.ToString()))
					{
						Grid_CycleElements.Rows[iRow].Cells[5].ReadOnly = false;
					}
				}
			}
			
			//Check whether some data files are set into cycle parts properties and load them if the user wants to
			Check_CyclePartPropDataFile(CyclePart.PreCycle);
			Check_CyclePartPropDataFile(CyclePart.InCycle);
			Check_CyclePartPropDataFile(CyclePart.PostCycle);
			
			bFormInit = false;
		}
		
		private void Show_CyclePartProperties(CyclePartProperties oProps, CyclePart ePart)
		{
			DataGridView oGrid = null;
			
			switch (ePart)
			{
				case CyclePart.PreCycle:
					oGrid = Grid_PreCycleProperties;
					break;
				case CyclePart.InCycle:
					oGrid = Grid_CycleProperties;
					break;
				case CyclePart.PostCycle:
					oGrid = Grid_PostCycleProperties;
					break;
			}
			
			oGrid.Rows[0].Cells[0].Value = oProps.TimeLength.ToString();
			
			if (!(oProps.DataFile.Equals("None")))
			{
				oGrid.Rows[1].Cells[0].Value = Path.GetFileName(oProps.DataFile);                          
			}
			else
			{
				oGrid.Rows[1].Cells[0].Value = "None";
			}
		}
		
		private int Get_ParameterRow(string MsgId, string Name)
		{
			for (int i=0; i<Grid_CycleElements.Rows.Count; i++)
			{
				if (Grid_CycleElements.Rows[i].HeaderCell.Tag.ToString().Equals(MsgId)
				    && Grid_CycleElements.Rows[i].HeaderCell.Value.ToString().Equals(Name))
				{
					return(i);
				}
			}
			
			return(-1);
		}
		
		private void Check_CyclePartPropDataFile(CyclePart ePart)
		{
			DataGridView oGrid = null;
			ImportDataFile oDataFile = null;
			CyclePartProperties oProps = null;
			string sCyclePart = "";
			
			switch (ePart)
			{
				case CyclePart.PreCycle:
					
					oGrid = Grid_PreCycleProperties;
					oDataFile = PreCycleDataFile;
					oProps = oCycleCfg.PreCycleProperties;
					sCyclePart = "Pre-cycle";
					break;
					
				case CyclePart.InCycle:
					
					oGrid = Grid_CycleProperties;
					oDataFile = InCycleDataFile;
					oProps = oCycleCfg.InCycleProperties;
					sCyclePart = "In-cycle";
					break;
					
				case CyclePart.PostCycle:
					
					oGrid = Grid_PostCycleProperties;
					oDataFile = PostCycleDataFile;
					oProps = oCycleCfg.PostCycleProperties;
					sCyclePart = "Post-cycle";
					break;
			}
			
			if (!(oGrid.Rows[1].Cells[0].Value.ToString().Equals("None")))
			{
				DialogResult Rep = MessageBox.Show(sCyclePart + " part is using a data file, do you want load this data file right now ?",
				                                   Application.ProductName,MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				
				if (Rep.Equals(DialogResult.Yes))
				{
					Load_DataFile(oProps.DataFile,ePart);
				}     
			} 
		}
		
		private void New_CycleConfiguration()
		{
			if (oCycleCfg.bModified)
			{
				DialogResult Rep = MessageBox.Show("The current cycle configuration has been modified, do you want save changes before to create a new configuration ?", Application.ProductName,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				
				switch (Rep)
				{
					case DialogResult.Yes:
						
						Save_CycleConfiguration();
						break;
						
					case DialogResult.No:
						
						break;
						
					case DialogResult.Cancel:
						
						return;
				}
			}
			
			oCycleCfg = new CycleEditionConfiguration();
			Show_CycleConfiguration();
		}
		
		private void Set_CycleParamDataToDefault(int GridRowIndex, CyclePart ePart)
		{
			CycleParameter oParam = oCycleCfg.GetCycleParameter(Grid_CycleElements.Rows[GridRowIndex].HeaderCell.Tag.ToString(),
			                                                    Grid_CycleElements.Rows[GridRowIndex].HeaderCell.Value.ToString());
			
			Set_CycleParamDataToDefault(oParam, ePart);
		}
		
		private void Set_CycleParamDataToDefault(CycleParameter oCycleParam, CyclePart ePart)
		{
			int iRow = Get_ParameterRow(oCycleParam.MsgId, oCycleParam.Name);
			
			int iCol = -1;
			string sCyclePart = "";
			string sItemType = "";
			string sLibType = "";
			string sOldData = "";
			
			CycleDataPart oDataPart = oCycleParam.GetDataParameterDataPart(ePart);
			
			switch (ePart)
			{
				case CyclePart.PreCycle:
					
					iCol = 0;
					sCyclePart = "Pre-cycle";
					sOldData = oCycleParam.PreCycle.Data;
					break;
					
				case CyclePart.InCycle:
					
					iCol = 2;
					sCyclePart = "In-cycle";
					sOldData = oCycleParam.InCycle.Data;
					break;
					
				case CyclePart.PostCycle:
					
					iCol = 4;
					sCyclePart = "Post-cycle";
					sOldData = oCycleParam.PostCycle.Data;
					break;
			}
			
			switch (oDataPart.Source)
			{
				case CycleDataSource.AcqData:
					
					sItemType = "acquistion channel";
					sLibType = "data file";
					break;
					
				case CycleDataSource.VirtualChannel:
					
					sItemType = "virtual channel";
					sLibType = "virtual channel libraries";
					break;
					
				case CycleDataSource.BuiltSignal:
					
					sItemType = "built-in signal";
					sLibType = "built-in signal libraries";
					break;
					
				default:
					
					break;
			}
			
			oDataPart.Source = CycleDataSource.Default;
			oDataPart.Library = "None";
			oDataPart.Data = "0";
			oCycleCfg.bModified = true;
			
			Grid_CycleElements.Rows[iRow].Cells[iCol].Value = CycleDataSource.Default.ToString();
			Grid_CycleElements.Rows[iRow].Cells[iCol + 1].Value = "0";
			
			if (!(sItemType.Equals("")))
			{
				MessageBox.Show(sCyclePart + " part of parameter "
				                + Grid_CycleElements.Rows[iRow].HeaderCell.Value.ToString()
				                + " has been set to default as "
				                + sItemType + " " + sOldData
				                + " doesn't exist in "
				                + sLibType + " loaded",
				                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		
		#endregion
		
		#region Cycle Creation
		
		private void Launch_Cycle_Creation()
		{			
			//Cycle total time check
			double TotalTime = oCycleCfg.PreCycleProperties.TimeLength
								+ oCycleCfg.InCycleProperties.TimeLength
								+ oCycleCfg.PostCycleProperties.TimeLength;
			
			if (TotalTime == 0)
			{
				MessageBox.Show("The complete cycle time length is zero !\nSet some time lengthes prior to start the creation procees.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			
			//Is there any paramater in the cycle
			if (ParameterCnt == 0)
			{
				MessageBox.Show("The current CAN configuration doesn't contain any valid Tx CAN parameter !\nMake sure that cycle parameters are not part of messages containing virtual CAN signals.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return;
			}
			
			//Data file loading
			if (!(oCycleCfg.PreCycleProperties.DataFile.Equals("None")))
			{
				if (!PreCycleDataFile.FileLoaded)
				{
					Load_DataFile(oCycleCfg.PreCycleProperties.DataFile, CyclePart.PreCycle);
				}
			}
			
			if (!(oCycleCfg.InCycleProperties.DataFile.Equals("None")))
			{
				if (!InCycleDataFile.FileLoaded)
				{
					Load_DataFile(oCycleCfg.InCycleProperties.DataFile, CyclePart.InCycle);
				}
			}
			
			if (!(oCycleCfg.PostCycleProperties.DataFile.Equals("None")))
			{
				if (!PostCycleDataFile.FileLoaded)
				{
					Load_DataFile(oCycleCfg.PostCycleProperties.DataFile, CyclePart.PostCycle);
				}
			}
			
			//Virtual channels initialization
			if (oCycleCfg.IsCycleUsingVirtualChannel())
			{
				oCycleCfg.VirtualChannelLibCollection.InitLibrariesComputation();
			}
			
			//Get cycle file path
			if (sCyclePath.Equals(""))
			{
				Dlg_SaveFile.FileName = "";
				Dlg_SaveFile.Filter = "CAN Strem cycle|*.csc";
				Dlg_SaveFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycles";
				
				if (Dlg_SaveFile.ShowDialog().Equals(DialogResult.OK))
				{
					sCyclePath = Dlg_SaveFile.FileName;
				}
				else
				{
					return;
				}
			}
			
			//Form's controls
			TSB_MakeCycle.Enabled = false;
			TSB_StopMakeCycle.Visible = true;
			StatusLbl_ActionCaption.Text = "Cycle creation...";
			StatusLbl_ActionCaption.Visible = true;
			StatusLbl_Action.Text = "";
			StatusLbl_Action.Visible = true;
			Status_Progress.Value = 0;
			Status_Progress.Visible = true;
			
			//Background worker launch
			BGWrk_CycleMake.RunWorkerAsync(sCyclePath);
		}
		
		private void Make_Cycle(BackgroundWorker worker, string CyclePath)
		{
			oCycle = new CANStreamCycle();
			
			oCycle.oCanNodesMap = oCycleCfg.CanConfiguration;
			
			CyclePart ePart = CyclePart.None;
			CyclePart ePartPrec = CyclePart.None;
			
			long TotalTime = (long)((oCycleCfg.PreCycleProperties.TimeLength
			                        + oCycleCfg.InCycleProperties.TimeLength
			                        + oCycleCfg.PostCycleProperties.TimeLength) * 1000);
			
			long iPartTime = 0;
			int Progress = 0;
			
			for (long iTime = 0; iTime < TotalTime; iTime++)
			{
				if (worker.CancellationPending) return;
				
				//Active cycle part
				if (iTime < (long)(oCycleCfg.PreCycleProperties.TimeLength * 1000))
				{
					ePart = CyclePart.PreCycle;
				}
				else if (iTime < (long)((oCycleCfg.PreCycleProperties.TimeLength + oCycleCfg.InCycleProperties.TimeLength) * 1000))
				{
					ePart = CyclePart.InCycle;
				}
				else
				{
					ePart = CyclePart.PostCycle;
				}
				
				//Cycle part change ?
				if (!(ePart.Equals(ePartPrec)))
				{
					//Partial time reset
					iPartTime = 0;
					
					//Current data file update
					switch (ePart)
					{
						case CyclePart.PreCycle:
							CurrentDataFile = PreCycleDataFile;
							break;
						case CyclePart.InCycle:
							CurrentDataFile = InCycleDataFile;
							break;
						case CyclePart.PostCycle:
							CurrentDataFile = PostCycleDataFile;
							break;
					}
					
					//Virtual channels variables init
					Init_VirtualVariablesTable();
				}
				else
				{
					iPartTime++;
				}
				
				ePartPrec = ePart;
				
				//Create messages for the current time
				List<string> TimeEventMessageIds = GetMessagesForTimeEvent(iTime);
				
				if (TimeEventMessageIds.Count > 0)
				{
					Update_VirtualVariablesTable(iTime, iPartTime); //Update virtual channel variable element table
					
					if (oCycleCfg.VirtualChannelLibCollection.bLibrariesInitialized)
					{
						oCycleCfg.VirtualChannelLibCollection.ComputeLibraries(); //Compute virtual channels values
					}
					
					CycleTimeEvent oTimeEvent = new CycleTimeEvent();
                    oTimeEvent.TimeEvent = iTime;
                    
                    foreach (string sMsgId in TimeEventMessageIds)
                    {
                    	CANMessageData oMessageData = new CANMessageData();
                        oMessageData = BuildCANMessageData(sMsgId, iTime, iPartTime, ePart);
                        
                        if (!(oMessageData == null))
                        {
                            oTimeEvent.MessagesData.Add(oMessageData);
                        }
                        else
                        {
                        	return;
                        }
                    }
                    
                    if (oTimeEvent.MessagesData.Count > 0)
                    {
                        oCycle.TimeEvents.Add(oTimeEvent);
                    }
				}
				
				//Progress report
				Progress = (int)(iTime * 100 / TotalTime);
				worker.ReportProgress(Progress, ePart.ToString());
			}
			
			oCycle.WriteStreamCycle(CyclePath);
		}
		
		private List<string> GetMessagesForTimeEvent(long TimeValue)
        {
            List<string> IdList = new List<string>();

            foreach (CANMessage oMessage in oCycleCfg.CanConfiguration.Messages)
            {
            	if (oMessage.RxTx.Equals(CanMsgRxTx.Tx) && (!(oMessage.Period == 0)) && (!oMessage.ContainsVirtualParameters()))
                {
                    long Rem = -1;
                    Math.DivRem(TimeValue, (long)oMessage.Period, out Rem);

                    if (Rem == 0)
                    {
                        IdList.Add(oMessage.Identifier);
                    }
                }
            }

            return (IdList);
        }
		
		private CANMessageData BuildCANMessageData(string MsgIdentifier, long TimeValue, long PartialTime, CyclePart ePart)
		{
			CANMessage oMsgDef = oCycleCfg.CanConfiguration.GetCANMessage(MsgIdentifier, MessageResearchOption.Identifier);
			
			//Get engeneering value for each parameter of the message
        	foreach (CANParameter oParamDef in oMsgDef.Parameters)
        	{
        		if (!oParamDef.IsVirtual)
        		{
	        		CycleParameter oCycleParam = oCycleCfg.GetCycleParameter(MsgIdentifier, oParamDef.Name);
	        		
	        		if (!(oCycleParam == null))
	        		{
	        			CycleDataPart oDataPart = oCycleParam.GetDataParameterDataPart(ePart);
	        			
	        			if (!(oDataPart == null))
	        			{
	        				double DataValue = 0;
	        				
	        				switch (oDataPart.Source)
	        				{
	        					case CycleDataSource.None:
	        						
	        						DataValue = 0;
	        						break;
	        						
	        					case CycleDataSource.Default:
	        						
	        						DataValue = 0;
	        						break;
	        						
	        					case CycleDataSource.Constant:
	        						
	        						DataValue = double.Parse(oDataPart.Data);
	        						break;
	        						
	        					case CycleDataSource.AcqData:
	        						
	        						if (!(CurrentDataFile.GetValueAtTime(oDataPart.Data, PartialTime, out DataValue)))
	        						{
	        							return(null);
	        						}
	        						
	        						break;
	        						
	        					case CycleDataSource.BuiltSignal:
	        						
	        						DataValue = oCycleCfg.BuiltInSignalLibCollection.GetSignalValueAtTime(oDataPart.Library, oDataPart.Data, PartialTime);
	        						break;
	        						
	        					case CycleDataSource.VirtualChannel:
	        						
	        						DataValue = oCycleCfg.VirtualChannelLibCollection.GetLastChannelValue(oDataPart.Library, oDataPart.Data);
	        						break;
	        				}
	        				
	        				oParamDef.DecodedValue = DataValue;
	        			}
	        		}
        		}
        	}
        	
        	//Encode the message
        	CANMessageEncoded oMsgEncoded=new CANMessageEncoded(oMsgDef, oCycleCfg.CanConfiguration.MessageLength/8);
        	oMsgEncoded.EncodeMessage();
        	
        	return(oMsgEncoded.GetCANMessageData());
			
		}
		
		private void Update_VirtualVariablesTable(long TimeValue, long PartialTime)
		{
			foreach (VirtualVariable oVar in VirtualVariablesTable)
			{
				switch (oVar.Source)
				{
					case VirtualVariable.VariableSource.AcqChannel:
						
						ImportDataFile oData = oVar.ParentItem as ImportDataFile;
						
						double Val = 0;
						if (oData.GetValueAtTime(oVar.Name, PartialTime, out Val))
						{
							oCycleCfg.VirtualChannelLibCollection.UpDateVariableElement(oVar.Name, Val);
						}
						else
						{
							oCycleCfg.VirtualChannelLibCollection.UpDateVariableElement(oVar.Name, 0);
						}
						break;
						
					case VirtualVariable.VariableSource.Signal:
						
						CS_BuiltInSignalLibrary oLib = oVar.ParentItem as CS_BuiltInSignalLibrary;
						oCycleCfg.VirtualChannelLibCollection.UpDateVariableElement(oVar.Name, oLib.GetSignalValueAtTime(oVar.Name, TimeValue));
						break;
				}
			}
		}
		
		private void Init_VirtualVariablesTable()
		{
			/*
			 * Try to find all variables used by virtual channels
			 * if variable is not found, variable might be another virtual channel, otherwise it will use 0 as default value anyway.
			 * if a variable is found more than once, we use the first item found and raise a warning
			*/
			
			VirtualVariablesTable = new List<Frm_CycleEdition.VirtualVariable>();
			int VirtualVarCnt = oCycleCfg.VirtualChannelLibCollection.GetVariableElementCount();
			
			if (VirtualVarCnt > 0) //If virtual channel are using variables
			{
				for (int iVar=0; iVar<VirtualVarCnt; iVar++)
				{
					CS_VC_Variable oVar = oCycleCfg.VirtualChannelLibCollection.GetVariableAtIndex(iVar);
					
					bool bVarFoundMultipleTimes = false;
					VirtualVariable oVirtualVar = null;
					
					//Look for the variable in the current data file
					foreach (ImportDataChannel oChan in CurrentDataFile.Channels)
					{
						if (oChan.ChannelName.Equals(oVar.Name))
						{
							if (oVirtualVar == null)
							{
								oVirtualVar = new Frm_CycleEdition.VirtualVariable();
								oVirtualVar.Source = VirtualVariable.VariableSource.AcqChannel;
								oVirtualVar.ParentItem = (object) CurrentDataFile;
								oVirtualVar.Name = oVar.Name;
							}
							else
							{
								bVarFoundMultipleTimes = true;
							}
						}
					}
					
					//Look for the variable in the signal library
					foreach (CS_BuiltInSignalLibrary oSigLib in oCycleCfg.BuiltInSignalLibCollection.Libraries)
					{
						foreach (CS_BuiltInSignal oSig in oSigLib.Signals)
						{
							if (oSig.Name.Equals(oVar.Name))
							{
								if (oVirtualVar == null)
								{
									oVirtualVar = new Frm_CycleEdition.VirtualVariable();
									oVirtualVar.Source = VirtualVariable.VariableSource.Signal;
									oVirtualVar.ParentItem = (object) oSig.ParentLibrary;
									oVirtualVar.Name = oVar.Name;
								}
								else
								{
									bVarFoundMultipleTimes = true;
								}
							}
						}
					}
					
					if (!(oVirtualVar == null))
					{
						VirtualVariablesTable.Add(oVirtualVar);
					}
					
					if (bVarFoundMultipleTimes)
					{
						MessageBox.Show("One of the virtual channels loaded is using parameter " 
						                + oVar.Name + " as internal variable.\n" 
						                + "More than one instance of that parameter exist in either in aqusition data and/or built-in signal libraries.\n"
						                + "Final result might not be what you expect !", 
						                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
			}
		}
		
		#endregion
		
		#region Cycle graph
		
		private void Plot_Cycle()
		{
			if (!(oCycle ==  null))
			{
				if (oCycle.GraphSeries.FormatedSeries.Count > 0)
				{
					Chart_Cycle.Width = Grp_Graph.Width - 10;
					Chart_Cycle.Height = Grp_Graph.Height -25;
					Context_Graph.Items.Clear();
					
					CANStreamTools.Draw_CycleGraph(oCycle, Chart_Cycle);
					
					foreach (FormatedGraphSerie oSerie in oCycle.GraphSeries.FormatedSeries)
					{
						ToolStripMenuItem SerieMenuItem = (ToolStripMenuItem) Context_Graph.Items.Add(oSerie.Name);
						SerieMenuItem.Checked=oSerie.Visible;
						SerieMenuItem.Click += new System.EventHandler(Context_GraphMenuItem_Click);
					}
				}
			}
		}
		
		#endregion
		
		#endregion
	}
}
