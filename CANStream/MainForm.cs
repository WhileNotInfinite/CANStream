/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 4/29/2013
 * Time: 8:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel; //BackgroundWorker
using System.Drawing;
using System.IO;
using System.Text; //StringBuilder
using System.Windows.Forms;

using Microsoft.Win32;

using SD_AppLicence;

//PCANBasic includes
using Peak.Can.Basic;
using TPCANHandle = System.Byte;
//

using NumberBaseConversion;

namespace CANStream
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
        #region Private enums

        private enum HistoryElements
        {
            None                = 0,
            CanConfiguration    = 1,
            Cycle               = 2,
            DataViewer          = 3,
        }

        #endregion

        #region Private contants

#if DEMO
		private const int CANSTREAM_APPID = 151;	
#else
        private const int CANSTREAM_APPID = 148;
		#endif

        private const int NB_CAN_CONTROLLER_MAX = 8;

        private const int ELEMENTS_HISTORY_DEPTH = 10;
		
		#endregion
		
		#region Private members
		
		#region CANStream members
		
		private int CanControllerCount;
		private Ctrl_CS_CAN_Bus ActiveCanBus;

		private CS_RecordEvent oRecordEvent;

		private bool bConverting;
		private DateTime TLastDiag;
		
		private string ShellArgument;
		
		#endregion
		        
		#endregion
		
		#region Public members
		
		public bool bDiagActive;
		
		#endregion
		
		public MainForm(string[] Args)
		{
			InitializeComponent();
			
			CanControllerCount = 0;
			ActiveCanBus = null;
			
			CANStreamTools.MyDocumentPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			CANStreamTools.CsDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CANStream";

            ShowElementsistory(LoadElementsHistory(HistoryElements.CanConfiguration), HistoryElements.CanConfiguration);
            ShowElementsistory(LoadElementsHistory(HistoryElements.Cycle), HistoryElements.Cycle);
            ShowElementsistory(LoadElementsHistory(HistoryElements.DataViewer), HistoryElements.DataViewer);

            //Initial controls enabling/disabling
            Cycle_openToolStripMenuItem.Enabled=false;
			CANConfig_openToolStripMenuItem.Enabled=true;
			CANConfig_editToolStripMenuItem.Enabled=false;
			importDBCToolStripMenuItem.Enabled=true;
										        	        	
        	//Record event intialization
        	Get_LastRecordEventSession();
        	
        	//PCAN Trace file conversion option initialization
        	CANStreamTools.Init_RecordConversionOption(CANStreamTools.MyDocumentPath);
        	
        	TabPage_NewController.TabIndex = 9;
        	
        	bConverting = false;
        	TLastDiag = new DateTime();
        	bDiagActive = false;
        	
        	//Misc

			#if DEMO
        	this.Text = Application.ProductName + " DEMO version";
			#else
        	this.Text = Application.ProductName;
			#endif
        	
        	Check_CANStreamFolders();
        	
        	ShellArgument = "";
        	if (Args.Length > 0)
			{
        		ShellArgument = Args[0];
			}
        }

        #region Control events
        
        #region FrmMain
        
		private void MainFormLoad(object sender, EventArgs e)
		{
			#if NO_LIC
			Add_CANController();
			#else
			if (CheckLicence())
			{
				Add_CANController();
			}
			else
			{
				FrmMain_MenuStrip.Enabled = false;
				Tab_CAN_Controllers.Enabled = false;
			}
			#endif
		}
        
		private void MainFormShown(object sender, EventArgs e)
		{
			//Try to load the file passed in argument if any
			if (!(ShellArgument.Equals("")))
			{
			    Load_ArgumentFile(ShellArgument);
			    ShellArgument = "";
			}
		}
		
        private void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			//If any of background workers of any control is running, the application closing is canceled. Otherwise the application crashes...
        	
        	foreach (TabPage oTab in Tab_CAN_Controllers.TabPages)
			{
				if (!(oTab.Equals(TabPage_NewController)))
				{
					Ctrl_CS_CAN_Bus oController = (Ctrl_CS_CAN_Bus)oTab.Controls[0];

                    if (oController.IsCycleWorkerBusy())
					{
						e.Cancel=true;
						
						MessageBox.Show("Cycle mode is currently running on the " + oTab.Text + "!\nApplication closing abort !\nStop the cycle prior to close the application.",
						                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}

                    if (oController.IsManualWorkerBusy())
					{
						e.Cancel=true;
						
						MessageBox.Show("Manual & Spy mode is currently running on the " + oTab.Text + "!\nApplication closing abort !\nStop transmission prior to close the application",
						                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
									}
			}
			
			if(BGWrk_RecordConversion.IsBusy)
			{
				e.Cancel=true;
				
				MessageBox.Show("A record file is currently being converted! Application closing abort !\nStop conversion prior to close the application",
				                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			
			if (!e.Cancel)
			{
				Save_ControllerLayout();
				Delete_AllControllerTmpBackUpFile();
				Set_RegisterRecordEventSession();
			}
		}
                
        #endregion

        #region FrmMain_MenuStrip

        #region CAN Configuration

        private void CANConfig_newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewCanConfiguration();
        }
		
        private void CANConfig_openToolStripMenuItemClick(object sender, EventArgs e)
		{
        	LoadCANConfiguration();
		}

        private void CanConfigHistoryItem_Click(object sender, EventArgs e)
        {
            if (ActiveCanBus != null)
            {
                CANMessagesConfiguration oNewCfg = new CANMessagesConfiguration();

                if (oNewCfg.ReadCANConfigurationFile(((ToolStripItem)sender).Tag.ToString()))
                {
                    ActiveCanBus.Set_BusCANConfiguration(oNewCfg);
                    UpdateElementsHistory(((ToolStripItem)sender).Tag.ToString(), HistoryElements.CanConfiguration);
                }
                else
                {
                    MessageBox.Show("CAN Configuration file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CANConfig_editToolStripMenuItemClick(object sender, EventArgs e)
		{
        	EditCurrentCanConfiguration();
		}
        
        private void ImportDBCToolStripMenuItemClick(object sender, EventArgs e)
		{
        	ImportDBCFile();
		}
        
        #region Raw message Tx

        private void AddMessageToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(ActiveCanBus == null))
        	{
        		ActiveCanBus.Add_RawMessage();
        	}
		}
		
		private void DelMessageToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
        	{
        		ActiveCanBus.Del_RawMessage();
        	}
		}
		
		private void ClearMessagesToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
        	{
        		ActiveCanBus.Clear_RawMessages();
        	}
		}
		
		private void SaveMessageListToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
        	{
        		ActiveCanBus.Save_RawMessages();
        	}
		}
		
		private void OpenMessageListToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
        	{
        		ActiveCanBus.Open_RawMessages();
        	}
		}
        
        #endregion
        
        #endregion
		
        #region Cycle
		
       	#region New
       	
       	private void Cycle_new_EasyCreation_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateCycle();
		}
		
		private void Cycle_new_AdvancedCreation_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			NewCycleEditor();
		}
       	
		private void Cycle_new_RecordReplay_ToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateCycleFromRecord();
		}
		
		#endregion       	
        
        private void Cycle_openToolStripMenuItemClick(object sender, EventArgs e)
		{
        	LoadCycle();
		}
        
        private void CycleHistoryItem_Click(object sender, EventArgs e)
        {
            if (ActiveCanBus != null)
            {
                CANStreamCycle oCycle = new CANStreamCycle();

                if (oCycle.ReadStreamCycle(((ToolStripItem)sender).Tag.ToString()))
                {
                    ActiveCanBus.Set_Cycle(oCycle);
                    UpdateElementsHistory(((ToolStripItem)sender).Tag.ToString(), HistoryElements.Cycle);
                }
                else
                {
                    MessageBox.Show("Cycle file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                    
            }
        }

        #region Set start/end points

        private void Cycle_SetStartPoint_TSMIClick(object sender, EventArgs e)
		{
        	if (!(ActiveCanBus == null)) ActiveCanBus.Set_CycleStartingPoint();
		}
		
		private void Cycle_SetEndPoint_TSMIClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null)) ActiveCanBus.Set_CycleEndingPoint();
		}
		
		private void Cycle_ConfirmStartEndPoints_TSMIClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null)) ActiveCanBus.Confirm_CycleStartEndPoints();
		}
		
		private void Cycle_CancelStartEndPoint_TSMIClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null)) ActiveCanBus.Cancel_CycleStartEndPoints();
		}
        
        #endregion
		
        #region Tools
        
        private void newCycledataAssociationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCycleDataAssociation();
        }
        
        private void OpenCycledataAssociationToolStripMenuItemClick(object sender, EventArgs e)
		{
        	OpenCycelDataAssociation();
		}
		
        #endregion
        
        #endregion
        
        #region Recording
        
        private void StartRecordingToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(ActiveCanBus == null)) ActiveCanBus.StartRecording();
		}
        
        private void StopRecordingToolStripMenuItemClick(object sender, EventArgs e)
		{
        	if (!(ActiveCanBus == null)) ActiveCanBus.StopRecording();
		}
        
        private void AutomaticRecordingToolStripMenuItemClick(object sender, EventArgs e)
		{
        	automaticRecordingToolStripMenuItem.Checked=!automaticRecordingToolStripMenuItem.Checked;
			
        	//RecordingMode NewRecMode = RecordingMode.Manual; //HACK: Implement acquisition trigger
//        	if (automaticRecordingToolStripMenuItem.Checked)
//        	{
//        		NewRecMode = RecordingMode.Auto;
//        	}
        	
        	foreach (TabPage oTab in Tab_CAN_Controllers.TabPages)
        	{
        		if (!(oTab.Equals(TabPage_NewController)))
        		{
        			((Ctrl_CS_CAN_Bus)oTab.Controls[0]).bRecordingAuto = automaticRecordingToolStripMenuItem.Checked; //HACK: Remove [acquisition trigger]
        			//((Ctrl_CS_CAN_Bus)oTab.Controls[0]).RecordMode = NewRecMode; //HACK: Implement acquisition trigger
        		}
        	}
		}
        
        #region Recording event
        
        private void NewRecordingEventToolStripMenuItemClick(object sender, EventArgs e)
		{
        	CreateNewRecordEvent();
		}
		
		private void SelectRecordingEventToolStripMenuItemClick(object sender, EventArgs e)
		{
			SelectRecordEvent();
		}
		
		private void EditRecordingEventDetailsToolStripMenuItemClick(object sender, EventArgs e)
		{
			EditRecordEvent();
		}
		
		#endregion
		
		#region Recording session
		
		private void NewRecordingSessionToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateNewRecordSession();
		}
		
		private void SelectRecordingSessionToolStripMenuItemClick(object sender, EventArgs e)
		{
			SelectRecordSession();
		}
		
		private void EditRecordingSessionDetailsToolStripMenuItemClick(object sender, EventArgs e)
		{
			EditRecordSession();
		}
        
		#endregion
		
        #region Convert records
        
        private void ConvertAllRecordsToolStripMenuItemClick(object sender, EventArgs e)
		{
        	CANStreamTools.TraceConversionOptions.TrcFileList = null;
        	LaunchConvertRecords();
		}
        
        private void SelectRecordsToConvertToolStripMenuItemClick(object sender, EventArgs e)
		{
        	RecordConversionSelection();
		}
        
        private void StopRecordConversionToolStripMenuItemClick(object sender, EventArgs e)
		{
        	StopRecordsConversion();
		}
        
        private void AutomaticRecordsConversionToolStripMenuItemClick(object sender, EventArgs e)
		{
        	automaticRecordsConversionToolStripMenuItem.Checked=!automaticRecordsConversionToolStripMenuItem.Checked;
			
        	foreach (TabPage oTab in Tab_CAN_Controllers.TabPages)
        	{
        		if (!(oTab.Equals(TabPage_NewController)))
        		{
        			((Ctrl_CS_CAN_Bus)oTab.Controls[0]).bConversionAuto = automaticRecordsConversionToolStripMenuItem.Checked;
        		}
        	}
		}
        
        #endregion
        
        #endregion
        
        #region Tools
        
        private void VirtualChannelsToolStripMenuItemClick(object sender, EventArgs e)
		{
        	EditVirtualChannels(null);
		}
        
        private void BuiltinSignalsToolStripMenuItemClick(object sender, EventArgs e)
		{
        	EditBuiltInSignals(null);
		}
        
        #region Data Viewer
        
        private void Tools_DataViewer_New_TSMenuItemClick(object sender, EventArgs e)
		{
        	NewDataViewer();
		}
		
		private void Tools_DataViewer_Open_TSMenuItemClick(object sender, EventArgs e)
		{
			LoadDataViewer();

		}
        
        private void DataViewerHistoryItem_Click(object sender, EventArgs e)
        {
            OpenDataViewer(((ToolStripItem)sender).Tag.ToString());
            UpdateElementsHistory(((ToolStripItem)sender).Tag.ToString(), HistoryElements.DataViewer);
        }

        #endregion
        
        #endregion
        
        #region View
		
		#region Controller layout
		
		#region Spy and manual
		
		private void TSMI_Layout_Manual_TxClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Manual_Tx_Panel();
			}
		}
		
		#region Message Tx
		
		private void TSMI_Layout_Manual_Tx_EngClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Manual_Tx_Eng_Panel();
			}
		}
		
		private void TSMI_Layout_Manual_Tx_RawClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Manual_Tx_Raw_Panel();
			}
		}
		
		#endregion
		
		private void TSMI_Layout_Manual_RxClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Manual_Rx_Panel();
			}
		}
		
		#region Message Rx
		
		private void TSMI_Layout_Manual_Rx_DataClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Manual_Rx_Data_Panel();
			}
		}
		
		private void TSMI_Layout_Manual_Rx_GraphClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Manual_Rx_Graph_Panel();
			}
		}
		
		#endregion
		
		#endregion
		
		#region Cycle player
		
		private void TSMI_Layout_Cycle_DataClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Cycle_Data_Panel();
			}
		}
		
		private void TSMI_Layout_Cycle_GraphClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.Switch_Cycle_Graph_Panel();
			}
		}
		
		#endregion
		
		private void TSMI_Layout_ResetClick(object sender, EventArgs e)
		{
			if (!(ActiveCanBus == null))
			{
				ActiveCanBus.ResetControllerLayout();
			}
		}
		
		#endregion
		
		#region Grids columns visibility
		
		#region Spy and Manual
		
		#region Manual Tx
		
		private void TSMI_Columns_Manual_Tx_ShowAllClick(object sender, EventArgs e)
		{
			ActiveCanBus.Set_TxGridColumnsVisible(GridCANData_ColumnsEnum.All);
		}
		
		private void TSMI_Columns_Manual_Tx_HideAllClick(object sender, EventArgs e)
		{
			ActiveCanBus.Set_TxGridColumnsVisible(GridCANData_ColumnsEnum.None);
		}
		
		private void TSMI_Columns_Manual_Tx_IDClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_ID);
        }
		
		private void TSMI_Columns_Manual_Tx_RxTxClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RxTx);
        }

        private void TSMI_Columns_Manual_Tx_Value_Click(object sender, EventArgs e)
        {
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Value);
        }

        private void TSMI_Columns_Manual_Tx_RawValue_Click(object sender, EventArgs e)
        {
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RawValue);
        }

        private void TSMI_Columns_Manual_Tx_Min_Click(object sender, EventArgs e)
        {
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Min);
        }

        private void TSMI_Columns_Manual_Tx_Max_Click(object sender, EventArgs e)
        {
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Max);
        }

        private void TSMI_Columns_Manual_Tx_UnitClick(object sender, EventArgs e)
        {
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Unit);
        }

        private void TSMI_Columns_Manual_Tx_PeriodClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Period);
        }
				
		private void TSMI_Columns_Manual_Tx_StartClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Start);
        }
		
		private void TSMI_Columns_Manual_Tx_LengthClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Length);
        }
		
		private void TSMI_Columns_Manual_Tx_EndianessClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Endianess);
        }
		
		private void TSMI_Columns_Manual_Tx_SignednessClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Signedness);
        }
		
		private void TSMI_Columns_Manual_Tx_GainClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Gain);
        }
		
		private void TSMI_Columns_Manual_Tx_ZeroClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Zero);
        }

        private void TSMI_Columns_Manual_Tx_Count_Click(object sender, EventArgs e)
        {
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Count);
        }

        private void TSMI_Columns_Manual_Tx_DLC_Click(object sender, EventArgs e)
        {
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_DLC);
        }

        private void TSMI_Columns_Manual_Tx_CommentClick(object sender, EventArgs e)
		{
            ManualTxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Comment);
        }

        #endregion

        #region Manual Rx

        private void TSMI_Columns_Manual_Rx_Eng_ShowAllClick(object sender, EventArgs e)
		{
			ActiveCanBus.Set_RxGridColumnsVisible(GridCANData_ColumnsEnum.All);
		}
		
		private void TSMI_Columns_Manual_Rx_Eng_HideAllClick(object sender, EventArgs e)
		{
			ActiveCanBus.Set_RxGridColumnsVisible(GridCANData_ColumnsEnum.None);
		}
		
		private void TSMI_Columns_Manual_Rx_Eng_IDClick(object sender, EventArgs e)
		{
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_ID);
        }

        private void TSMI_Columns_Manual_Rx_Eng_RxTx_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RxTx);
        }

        private void TSMI_Columns_Manual_Rx_Eng_ValueClick(object sender, EventArgs e)
		{
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Value);
        }
		
		private void TSMI_Columns_Manual_Rx_Eng_RawValClick(object sender, EventArgs e)
		{
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RawValue);
        }
		
		private void TSMI_Columns_Manual_Rx_Eng_MinClick(object sender, EventArgs e)
		{
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Min);
        }
		
		private void TSMI_Columns_Manual_Rx_Eng_MaxClick(object sender, EventArgs e)
		{
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Max);
        }
		
		private void TSMI_Columns_Manual_Rx_Eng_UnitClick(object sender, EventArgs e)
		{
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Unit);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Period_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Period);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Start_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Start);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Length_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Length);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Endianess_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Endianess);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Signed_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Signedness);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Gain_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Gain);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Zero_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Zero);
        }

        private void TSMI_Columns_Manual_Rx_Eng_Count_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Count);
        }

        private void TSMI_Columns_Manual_Rx_Eng_DLC_Click(object sender, EventArgs e)
        {
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_DLC);
        }

		private void TSMI_Columns_Manual_Rx_Eng_CommentClick(object sender, EventArgs e)
		{
            ManualRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Comment);
        }
			
		#endregion
		
		#endregion
		
		#region Cycle player
		
		#region Engineering data
		
		private void TSMI_Columns_Cycle_Eng_ShowAllClick(object sender, EventArgs e)
		{
			ActiveCanBus.Set_CycleEngGridColumnsVisible(GridCANData_ColumnsEnum.All);
		}
		
		private void TSMI_Columns_Cycle_Eng_HideAllClick(object sender, EventArgs e)
		{
			ActiveCanBus.Set_CycleEngGridColumnsVisible(GridCANData_ColumnsEnum.None);
		}
		
		private void TSMI_Columns_Cycle_Eng_IDClick(object sender, EventArgs e)
		{
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_ID);
        }

        private void TSMI_Columns_Cycle_Eng_RxTx_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RxTx);
        }

        private void TSMI_Columns_Cycle_Eng_ValueClick(object sender, EventArgs e)
		{
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Value);
        }
		
		private void TSMI_Columns_Cycle_Eng_RawValClick(object sender, EventArgs e)
		{
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_RawValue);
        }
		
		private void TSMI_Columns_Cycle_Eng_MinClick(object sender, EventArgs e)
		{
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Min);
        }
		
		private void TSMI_Columns_Cycle_Eng_MaxClick(object sender, EventArgs e)
		{
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Max);
        }
		
		private void TSMI_Columns_Cycle_Eng_UnitClick(object sender, EventArgs e)
		{
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Unit);
        }

        private void TSMI_Columns_Cycle_Eng_Period_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Period);
        }

        private void TSMI_Columns_Cycle_Eng_Start_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Start);
        }

        private void TSMI_Columns_Cycle_Eng_Length_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Length);
        }

        private void TSMI_Columns_Cycle_Eng_Endianess_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Endianess);
        }

        private void TSMI_Columns_Cycle_Eng_Signedness_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Signedness);
        }

        private void TSMI_Columns_Cycle_Eng_Gain_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Gain);
        }

        private void TSMI_Columns_Cycle_Eng_Zero_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Zero);
        }

        private void TSMI_Columns_Cycle_Eng_Count_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Count);
        }

        private void TSMI_Columns_Cycle_Eng_DLC_Click(object sender, EventArgs e)
        {
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_DLC);
        }
		
		private void TSMI_Columns_Cycle_Eng_CommentClick(object sender, EventArgs e)
		{
            CycleRxColumnTSMIChanged((ToolStripMenuItem)sender, GridCANData_ColumnsEnum.Column_Comment);
        }
		
		#endregion
		
		#endregion
		
		#endregion
		
        #endregion
        
        #region Help
        
        private void HelpTopicsToolStripMenuItemClick(object sender, EventArgs e)
		{
			Help.ShowHelp(this, Application.StartupPath + "\\CANStream user guide.chm");
		}
        
        private void AboutToolStripMenuItemClick(object sender, EventArgs e)
		{
        	Frm_About Frm=new Frm_About(CANSTREAM_APPID);
        	Frm.Show();
		}
        
        #endregion
        
        #endregion
        
        #region FrmMain_StatusStrip
        
        private void TSSL_StopConversionClick(object sender, EventArgs e)
		{
        	StopRecordsConversion();
		}
        
        #endregion
        
		#region Tab_CAN_Controllers
		
		private void Tab_CAN_ControllersMouseClick(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left:
					
					if (Tab_CAN_Controllers.SelectedTab.Equals(TabPage_NewController))
					{
						Add_CANController();
					}
					
					break;
					
				case MouseButtons.Right:
					
					TabPage ContextTab = Get_TabPageAtPosition(e.Location);
					
					if (!(ContextTab == null))
					{
						if (!(ContextTab.Equals(TabPage_NewController)))
						{
							Context_TabControllers.Tag = ContextTab.TabIndex;
							Context_TabControllers.Show(Tab_CAN_Controllers.PointToScreen(e.Location));
						}
						else
						{
							Context_TabControllers.Tag = -1 ;
						}
					}
					
					break;
			}
		}
		
		private void Tab_CAN_ControllersSelectedIndexChanged(object sender, EventArgs e)
		{
			if (!(Tab_CAN_Controllers.SelectedTab.Equals(TabPage_NewController)))
			{
				ActiveCanBus = (Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.SelectedTab.Controls[0];
				ActiveCanBus.Tag = Tab_CAN_Controllers.SelectedTab.TabIndex;
				TLastDiag = new DateTime();
			}
			else
			{
				ActiveCanBus = null;
			}
			
			Switch_ActiveCanBus();
		}
		
		#region Context_TabControllers
		
		private void CloseCANBusToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(Context_TabControllers.Tag == null))
			{				
				Close_CANController((int) Context_TabControllers.Tag);
			}
		}
		
		#endregion
		
		#endregion
        
		#region Conversion BackgroundWorker
        
        private void BGWrk_RecordConversionDoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker Worker = sender as BackgroundWorker;
			ConvertRecords(Worker);
		}
		
		private void BGWrk_RecordConversionProgressChanged(object sender, ProgressChangedEventArgs e)
		{
            TS_PB_Conversion.Value=e.ProgressPercentage;
            
            if (!(e.UserState == null))
            {
                MessageBox.Show("An error occured while converting " + e.UserState.ToString() + " trace file !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }			
		}
		
		private void BGWrk_RecordConversionRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			bConverting=false;
			TS_Lbl_ConversionProgress.Visible=false;
			TS_PB_Conversion.Visible=false;	
			TSSL_StopConversion.Visible=false;			
		}
        
        #endregion
		
        #region CanController
        
        private void ActiveBusController_ControllerModeChanged(object sender, ControllerModeChangedEventArgs e)
        {
        	Switch_ActiveCanBus();
        }
        
        private void ActiveBusController_ControllerCanConfigChanged(object sender, ControllerCANConfigChangedEventArgs e)
        {
        	if (ActiveCanBus.ControllerActiveMode == 1)
        	{
        		CANConfig_editToolStripMenuItem.Enabled = e.ConfigurationLoaded;
        		
        		if (e.ConfigurationLoaded)
        		{
        			CANMessagesConfiguration oActiveCanCfg = ActiveCanBus.Get_BusCANConfiguration();
        			
        			if (!(oActiveCanCfg == null))
        			{
        				TS_Lbl_CanCfgTitle.Visible = true;
        				TS_Lbl_CanCfg.Visible = true;
        				TS_Lbl_CanCfg.Text = oActiveCanCfg.Name;
        			}
        			else
        			{
        				TS_Lbl_CanCfgTitle.Visible = false;
        				TS_Lbl_CanCfg.Visible = false;
        			}
        		}
        	}
        	else
        	{
        		CANConfig_editToolStripMenuItem.Enabled = false;
        		
        		TS_Lbl_CanCfgTitle.Visible = false;
        		TS_Lbl_CanCfg.Visible = false;
        	}
        }
        
        private void ActiveBusController_ControllerConnectionStatusChanged(object sender, ControllerConnectionStatusChangedEventArgs e)
        {
        	startRecordingToolStripMenuItem.Enabled = e.Connected;
        }
        
        private void ActiveBusController_ControllerCycleLoaded(object sender, EventArgs e)
        {
        	Cycle_SetStartEndPoints_ToolStripMenuItem.Enabled = true;
        }
        
        private void ActiveBusController_ControllerCycleStartEndSetting(object sender, ControllerCycleStartEndSettingEventArgs e)
        {
        	switch (e.SettingState)
        	{
        		case 0: //Currently setting start or end point
        			
        			Cycle_SetStartPoint_TSMI.Visible = false;
        			Cycle_SetEndPoint_TSMI.Visible = false;
        			Cycle_ConfirmStartEndPoints_TSMI.Visible = true;
        			Cycle_CancelStartEndPoint_TSMI.Visible = true;
        			break;
        			
        		case 1: //Start or end point confirmed or not set
        			
        			Cycle_SetStartPoint_TSMI.Visible = true;
        			Cycle_SetEndPoint_TSMI.Visible = true;
        			Cycle_ConfirmStartEndPoints_TSMI.Visible = false;
        			Cycle_CancelStartEndPoint_TSMI.Visible = false;
        			break;
        	}
        }
        
        private void ActiveBusController_ControllerCycleRunningChanged(object sender, ControllerRunningChangedEventArgs e)
        {
            SetCANControlsRunningCommands(e.Running);

            if (e.Running)
        	{
        		TSS_Lbl_PCAN_Diag_Title.Visible = false;
        		TSS_Lbl_PCAN_Diag_Text.Visible = false;
        	}
        }
        
        private void ActiveBusController_ControllerManualRunningChanged(object sender, ControllerRunningChangedEventArgs e)
        {
            SetCANControlsRunningCommands(e.Running);

            if (e.Running)
        	{
        		TSS_Lbl_PCAN_Diag_Title.Visible = false;
        		TSS_Lbl_PCAN_Diag_Text.Visible = false;
        	}
        }
        
        private void ActiveBusController_ControllerSpyRunningChanged(object sender, ControllerRunningChangedEventArgs e)
        {
            SetCANControlsRunningCommands(e.Running);

            if (e.Running)
        	{
        		TSS_Lbl_PCAN_Diag_Title.Visible = false;
        		TSS_Lbl_PCAN_Diag_Text.Visible = false;
        	}
        }
        
        private void ActiveBusController_LayoutChanged(object sender, ControllerLayoutChangedEventArgs e)
        {
        	TSMI_Layout_Manual_Tx.Checked = e.Manual_Tx_Panel_Visible;
        	
        		TSMI_Layout_Manual_Tx_Eng.Checked = e.Manual_Tx_Panel_Eng_Visible;
        		TSMI_Layout_Manual_Tx_Raw.Checked = e.Manual_Tx_Panel_Raw_Visible;
        	
        	TSMI_Layout_Manual_Rx.Checked = e.Manual_Rx_Panel_Visible;
        	
        		TSMI_Layout_Manual_Rx_Data.Checked = e.Manual_Rx_Panel_Data_Visible;        		
        		TSMI_Layout_Manual_Rx_Graph.Checked = e.Manual_Rx_Panel_Graph_Visible;
        	
        	TSMI_Layout_Cycle_Data.Checked = e.Cycle_Panel_Data_Visible;
        	        	
        	TSMI_Layout_Cycle_Graph.Checked = e.Cycle_Panel_Graph_Visible;
        }
        
        private void ActiveBusController_ControllerGridColumnsChanged(object sender, ControllerGridColumnsChangedEventArgs e)
        {
        	UpdateGridsColumnsStates(e.Grid, e.ColumnsVisible);
        }
        
        private void ActiveBusController_ControllerDiagChanged(object sender, ControllerDiagChangedEventArgs e)
        {
        	if (!(e.BusIndex == (int)ActiveCanBus.Tag))
        	{
        		return;
        	}
        	
        	TimeSpan TSinceLastDiag = DateTime.Now.Subtract(TLastDiag);
        	
        	if (TSinceLastDiag.TotalSeconds < 10)
        	{
        		return;
        	}
        	
        	TLastDiag = DateTime.Now;
        	
        	TSS_Lbl_PCAN_Diag_Title.Visible = true;
        	TSS_Lbl_PCAN_Diag_Text.Visible = true;
        	bDiagActive = true;
        	
        	switch (e.Diag)
        	{
        		case TPCANStatus.PCAN_ERROR_OK: //No error
        			
        			TSS_Lbl_PCAN_Diag_Title.Visible = false;
        			TSS_Lbl_PCAN_Diag_Text.Visible = false;
        			bDiagActive = false;
        			break;
        		
        		case TPCANStatus.PCAN_ERROR_XMTFULL:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "XMTFULL";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Transmit buffer in CAN controller is full";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_OVERRUN:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "OVERRUN";
        			TSS_Lbl_PCAN_Diag_Text.Text = "CAN controller was read too late";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_BUSLIGHT:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "BUSLIGHT";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Bus error: an error counter reached the 'light' limit";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_BUSHEAVY:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "BUSHEAVY";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Bus error: an error counter reached the 'heavy' limit";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_BUSOFF:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "BUSOFF";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Bus error: the CAN controller is in bus-off state";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ANYBUSERR:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ANYBUSERR";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Bus error: BUSLIGHT or BUSHEAVY or BUSOFF";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_QRCVEMPTY:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "QRCVEMPTY";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Receive queue is empty";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_QOVERRUN:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "QOVERRUN";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Receive queue was read too late";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_QXMTFULL:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "QXMTFULL";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Transmit queue is full";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_REGTEST:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "REGTEST";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Test of the CAN controller hardware registers failed (no hardware found)";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_NODRIVER:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "NODRIVER";
        			TSS_Lbl_PCAN_Diag_Text.Text = "USB PCAN Driver not loaded";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_HWINUSE:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "HWINUSE";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Hardware already in use by a Net";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_NETINUSE:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "NETINUSE";
        			TSS_Lbl_PCAN_Diag_Text.Text = "A Client is already connected to the Net";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ILLHW:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLHW";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Hardware handle is invalid";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ILLNET:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLNET";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Net handle is invalid";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ILLCLIENT:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLCLIENT";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Client handle is invalid";
        			break;
        			
//        		case TPCANStatus.PCAN_ERROR_ILLHANDLE:
//        			
//        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLHANDLE";
//        			TSS_Lbl_PCAN_Diag_Text.Text = "handle errors: ILLHW or ILLNET or ILLCLIENT";
//        			break;
        			
        		case TPCANStatus.PCAN_ERROR_RESOURCE:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "RESOURCE";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Resource (FIFO, Client, timeout) cannot be created";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ILLPARAMTYPE:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLPARAMTYPE";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Invalid parameter";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ILLPARAMVAL:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLPARAMVAL";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Invalid parameter value";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_UNKNOWN:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "UNKNOWN";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Unknow error";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ILLDATA:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLDATA";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Invalid data, function, or action";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_INITIALIZE:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "INITIALIZE";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Channel is not initialized";
        			break;
        			
        		case TPCANStatus.PCAN_ERROR_ILLOPERATION:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "ILLOPERATION";
        			TSS_Lbl_PCAN_Diag_Text.Text = "Invalid operation";
        			break;
        			
        		default:
        			
        			TSS_Lbl_PCAN_Diag_Title.Text = "???";
        			TSS_Lbl_PCAN_Diag_Text.Text = "???";
        			break;
        			
        	}
        }
        
        #endregion
        
        #endregion

        #region Private methodes
        
        #region Application
        
        private void Load_ArgumentFile(string fPath)
        {
        	try
        	{
        		string fExt = Path.GetExtension(fPath);
        		
        		if (fExt.Equals(".cbs")) //Built-in signals library
        		{
        			CS_BuiltInSignalLibrary oLib = new CS_BuiltInSignalLibrary();
        			
        			if (oLib.ReadLibraryFile(fPath))
        			{
        				EditBuiltInSignals(oLib);
        			}
        		}
        		else if (fExt.Equals(".xcc")) //CAN Configuration
        		{
        			CANMessagesConfiguration oCfg = new CANMessagesConfiguration();
        			
        			if (oCfg.ReadCANConfigurationFile(fPath))
        			{
        				ActiveCanBus.Set_BusCANConfiguration(oCfg);
        			}
        		}
        		else if (fExt.Equals(".csc")) //Cycle
        		{
        			CANStreamCycle oCycle = new CANStreamCycle();
        			
        			if (oCycle.ReadStreamCycle(fPath))
        			{
        				ActiveCanBus.Set_Cycle(oCycle);
        				ActiveCanBus.Set_ActiveTabIndex(1);
        			}
        		}
        		else if (fExt.Equals(".x3c")) //Cycle creation configuration
        		{
        			CycleEditionConfiguration oCfg = new CycleEditionConfiguration();
        			
        			if (oCfg.Read_CycleConfiguration(fPath))
        			{
        				Frm_CycleEdition Frm = new Frm_CycleEdition(oCfg);
        				Frm.Show();
        			}
        		}
        		else if (fExt.Equals(".cda")) //Cycle data association
        		{
        			Frm_CycleDataAssociation Frm=new Frm_CycleDataAssociation();
            		Frm.LoadAssociationFile(fPath);
            		Frm.Show();
        		}
        		else if (fExt.Equals(".dvb")) //Data viewer book
        		{
        			OpenDataViewer(fPath);
        		}
        		else if (fExt.Equals(".mcb")) //Multiple bus CAN configuration
        		{
        			Load_ControllersConfiguration(fPath);
        		}
        		else if (fExt.Equals(".cvl")) //Virtual channel library
        		{
        			CS_VirtualChannelsLibrary oLib = new CS_VirtualChannelsLibrary();
        			
        			if (oLib.ReadLibraryFile(fPath))
        			{
        				EditVirtualChannels(oLib);
        			}
        		}
        	}
        	catch
        	{
        		MessageBox.Show("File you tried to open is not a CANStream file or is corrupted !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        	}
        }
        
        private bool CheckLicence()
        {
        	AppLicenceObject oLicence = new AppLicenceObject(Application.StartupPath, CANSTREAM_APPID, Application.ProductVersion, TextRessouces.LicenseRequestEmail, true);
        	
        	if (oLicence.LicenseValid)
        	{
        		if (oLicence.ValidityDaysRemaining < 30)
        		{
        			MessageBox.Show("Your licence will expire in " 
        			                + oLicence.ValidityDaysRemaining.ToString()
        			                + " days (" + DateTime.Now.AddDays(oLicence.ValidityDaysRemaining).ToShortDateString()
        			                + ")\nCheck the 'About' menu to request a new licence.",
        			                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        		}
        	}
        	
        	return(oLicence.LicenseValid);
        }

        #region CAN Config, Cycle & Data Viewers history

        private List<string> LoadElementsHistory(HistoryElements eHistoryItem)
        {
            object ElementsHistoryRegKey = null;
            int ElementIndex = 1;

            List<string> ElementsHistory = new List<string>();

            string HistoryRegKey = "";

            switch(eHistoryItem)
            {
                case HistoryElements.CanConfiguration:

                    HistoryRegKey = "\\Can Configuration history";
                    break;

                case HistoryElements.Cycle:

                    HistoryRegKey = "\\Cycle history";
                    break;

                case HistoryElements.DataViewer:

                    HistoryRegKey = "\\DataViewer history";
                    break;

                default:
                    return (null);
            }

            do
            {
                ElementsHistoryRegKey = Registry.GetValue(CANStreamConstants.CS_REG_KEY + HistoryRegKey, ElementIndex.ToString(), null);

                if (ElementsHistoryRegKey != null)
                {
                    ElementsHistory.Add(ElementsHistoryRegKey.ToString());
                    ElementIndex++;
                }
            }
            while (ElementsHistoryRegKey != null);

            return (ElementsHistory);
        }

        private void WriteElementsHistory(List<string> ElementsHistory, HistoryElements eHistoryItem)
        {
            if (ElementsHistory.Count > 0)
            {
                string HistoryRegKey = "";

                switch (eHistoryItem)
                {
                    case HistoryElements.CanConfiguration:

                        HistoryRegKey = "\\Can Configuration history";
                        break;

                    case HistoryElements.Cycle:

                        HistoryRegKey = "\\Cycle history";
                        break;

                    case HistoryElements.DataViewer:

                        HistoryRegKey = "\\DataViewer history";
                        break;

                    default:
                        return;
                }

                int ElementIndex = 1;

                foreach (string sElement in ElementsHistory)
                {
                    Registry.SetValue(CANStreamConstants.CS_REG_KEY + HistoryRegKey, ElementIndex.ToString(), sElement);
                    ElementIndex++;
                }
            }
        }

        private void UpdateElementsHistory(string ElementPath, HistoryElements eHistoryItem)
        {
            List<string> ElementsHistory = LoadElementsHistory(eHistoryItem);

            if (ElementsHistory.Contains(ElementPath))
            {
                ElementsHistory.Remove(ElementPath);
            }

            ElementsHistory.Insert(0, ElementPath);

            if (ElementsHistory.Count > ELEMENTS_HISTORY_DEPTH)
            {
                ElementsHistory.RemoveAt(ELEMENTS_HISTORY_DEPTH);
            }

            ShowElementsistory(ElementsHistory, eHistoryItem);
            WriteElementsHistory(ElementsHistory, eHistoryItem);
        }

        private void ShowElementsistory(List<string> ElementsHistory, HistoryElements eHistoryItem)
        {
            ToolStripMenuItem HistoryMenuItem = null;

            switch (eHistoryItem)
            {
                case HistoryElements.CanConfiguration:

                    HistoryMenuItem = CANConfig_recentToolStripMenuItem;
                    break;

                case HistoryElements.Cycle:

                    HistoryMenuItem = Cycle_recentToolStripMenuItem;
                    break;

                case HistoryElements.DataViewer:

                    HistoryMenuItem = Tools_DataViewer_Recent_TSMenuItem;
                    break;

                default:
                    return;
            }

            HistoryMenuItem.DropDownItems.Clear();

            foreach (string sElement in ElementsHistory)
            {
                if (File.Exists(sElement))
                {
                    ToolStripItem oItem = HistoryMenuItem.DropDownItems.Add(Path.GetFileName(sElement));
                    oItem.Tag = sElement;

                    switch (eHistoryItem)
                    {
                        case HistoryElements.CanConfiguration:

                            oItem.Click += new EventHandler(CanConfigHistoryItem_Click);
                            break;

                        case HistoryElements.Cycle:

                            oItem.Click += new EventHandler(CycleHistoryItem_Click);
                            break;

                        case HistoryElements.DataViewer:

                            oItem.Click += new EventHandler(DataViewerHistoryItem_Click);
                            break;

                    }
                }
            }
        }

        #endregion

        #endregion

        #region CAN Controllers

        private void Add_CANController()
        {
        	if (CanControllerCount < NB_CAN_CONTROLLER_MAX)
        	{
        		Create_ControllerTab(null);
        	}
        	else
        	{
        		MessageBox.Show("Sorry, maximum number of CAN Controller is " + NB_CAN_CONTROLLER_MAX.ToString() + " !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        	}
        }
        
        private void Load_ControllersConfiguration(string fPath)
        {
        	MultipleContollerCANConfiguration oControllersCfg = new MultipleContollerCANConfiguration();
        	
        	if (oControllersCfg.ReadControllersConfiguaration(fPath))
        	{
        		if (Close_AllControllerTabs())
        		{
        			foreach (CANBusContoller oCtrl in oControllersCfg.Controllers)
        			{
        				Create_ControllerTab(oCtrl);
        			}
        		}
        	}
        	else
        	{
        		MessageBox.Show("Multiple CAN bus configuration file loading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        	}
        }
        
        private void Create_ControllerTab(CANBusContoller oCtrlCfg)
        {
        	TabPage TabNewCtrl = new TabPage();
        	
        	if (oCtrlCfg == null)
        	{
        		TabNewCtrl.Text = "CAN Bus " + (CanControllerCount + 1).ToString();
        	}
        	else
        	{
        		TabNewCtrl.Text = oCtrlCfg.ControllerName;
        		TabNewCtrl.ToolTipText = oCtrlCfg.Description;
        	}
        	
        	TabNewCtrl.TabIndex = CanControllerCount;
        	
    		Ctrl_CS_CAN_Bus CtrlCanBus = new Ctrl_CS_CAN_Bus(this, oRecordEvent);
    		TabNewCtrl.Controls.Add(CtrlCanBus);   		
    		
    		CtrlCanBus.Location = new Point(0, 0);
    		CtrlCanBus.Size = new Size(TabNewCtrl.Width, TabNewCtrl.Height);
    		CtrlCanBus.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
    		CtrlCanBus.Tag = CanControllerCount;
    		
    		//Events handlers
    		CtrlCanBus.ControllerModeChanged += new EventHandler<ControllerModeChangedEventArgs>(ActiveBusController_ControllerModeChanged);
    		CtrlCanBus.ControllerCanConfigChanged += new EventHandler<ControllerCANConfigChangedEventArgs>(ActiveBusController_ControllerCanConfigChanged);
    		CtrlCanBus.ControllerConnectionStatusChanged += new EventHandler<ControllerConnectionStatusChangedEventArgs>(ActiveBusController_ControllerConnectionStatusChanged);
    		CtrlCanBus.ControllerCycleLoaded += new EventHandler<EventArgs>(ActiveBusController_ControllerCycleLoaded);
    		CtrlCanBus.ControllerCycleStartEndSetting += new EventHandler<ControllerCycleStartEndSettingEventArgs>(ActiveBusController_ControllerCycleStartEndSetting);
    		CtrlCanBus.ControllerCycleRunningChanged += new EventHandler<ControllerRunningChangedEventArgs>(ActiveBusController_ControllerCycleRunningChanged);
    		CtrlCanBus.ControllerManualRunningChanged += new EventHandler<ControllerRunningChangedEventArgs>(ActiveBusController_ControllerManualRunningChanged);
    		CtrlCanBus.ControllerSpyRunningChanged += new EventHandler<ControllerRunningChangedEventArgs>(ActiveBusController_ControllerSpyRunningChanged);
    		CtrlCanBus.ControllerLayoutChanged += new EventHandler<ControllerLayoutChangedEventArgs>(ActiveBusController_LayoutChanged);
    		CtrlCanBus.ControllerGridColumnsChanged += new EventHandler<ControllerGridColumnsChangedEventArgs>(ActiveBusController_ControllerGridColumnsChanged);
    		CtrlCanBus.ControllerDiagChanged += new EventHandler<ControllerDiagChangedEventArgs>(ActiveBusController_ControllerDiagChanged);
    		
    		if (!(oCtrlCfg == null))
    		{
    			ActiveCanBus = CtrlCanBus;
    			CtrlCanBus.Set_BusCANConfiguration(oCtrlCfg);
    		}
    		
    		Tab_CAN_Controllers.TabPages.Insert(CanControllerCount, TabNewCtrl);
    		Tab_CAN_Controllers.SelectedTab = TabNewCtrl;
    		
    		//Layout
    		string LayoutsPath = CANStreamTools.CsDataPath + "\\Layouts.xml";
        	CAN_Controller_Layouts CtrlLayouts = new CAN_Controller_Layouts();
        	if (CtrlLayouts.Load_Controller_Layouts(LayoutsPath))
        	{
        		if (CanControllerCount < CtrlLayouts.Layouts.Count)
        		{
        			CtrlCanBus.SetControllerLayout(CtrlLayouts.Layouts[CanControllerCount]);
        		}
        		else
        		{
        			CtrlCanBus.SetControllerLayout(new Ctrl_CS_CAN_Bus_Layout(CtrlCanBus.Size));
        		}
        	}
        	else
    		{
    			CtrlCanBus.SetControllerLayout(new Ctrl_CS_CAN_Bus_Layout(CtrlCanBus.Size));
    		}
        	
    		CanControllerCount++;
        }
        
        private void Close_CANController(int iTab)
        {
        	if (iTab >= 0)
        	{        		
        		if (Tab_CAN_Controllers.TabPages.Count > 2)
        		{
        			if (CanCloseControllerTab(iTab))
        			{
        				Save_ControllerLayout();
        				Delete_ControllerTmpBackUpFile(((Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[iTab].Controls[0]).ManualCanConfigFilePath);
        				
        				((Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[iTab].Controls[0]).Release_CAN_Adapter();
        				Tab_CAN_Controllers.TabPages.RemoveAt(iTab);
        				
        				for (int i = 0; i < Tab_CAN_Controllers.TabPages.Count; i++)
        				{
        					if (!(Tab_CAN_Controllers.TabPages[i].Equals(TabPage_NewController)))
        					{
        						Tab_CAN_Controllers.TabPages[i].Text = "CAN Bus " + (i + 1).ToString();
        						Tab_CAN_Controllers.TabPages[i].TabIndex = i;
        					}
        				}
        				
        				CanControllerCount--;
        			}
        		}
        		else
        		{
        			MessageBox.Show("You must have at least one CAN Bus !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        		}
        	}
        }
        
        private bool Close_AllControllerTabs()
        {
        	//Verify that nothing is running on any controller
        	for (int iTab=0; iTab < Tab_CAN_Controllers.TabPages.Count - 1; iTab++)
        	{
        		if (!(Tab_CAN_Controllers.TabPages[iTab].Equals(TabPage_NewController)))
        		{
        			if (!(CanCloseControllerTab(iTab)))
        			{
        				return(false);
        			}
        		}
        	}
        	
        	Save_ControllerLayout();
        	
        	//Close all contollers
        	while (Tab_CAN_Controllers.TabPages.Count > 1)
        	{
        		((Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[0].Controls[0]).Release_CAN_Adapter();
        		Tab_CAN_Controllers.TabPages.RemoveAt(0);
        	}
        	
        	CanControllerCount = 0;
        	
        	return(true);
        }
        
        private bool CanCloseControllerTab(int iTab)
        {
        	Ctrl_CS_CAN_Bus oController = (Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[iTab].Controls[0];
        	
        	if (oController.IsCycleWorkerBusy())
        	{
        		MessageBox.Show("A cycle is currently running on the bus " + Tab_CAN_Controllers.TabPages[iTab].Text + "! Bus closing abort !\nStop the cycle prior to close it.",
        		                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		return(false);
        	}
        	
        	if (oController.IsManualWorkerBusy())
        	{
        		MessageBox.Show("Manual frames are currently being sent on the bus" + Tab_CAN_Controllers.TabPages[iTab].Text + "! Bus closing abort !\nStop transmission prior to close it.",
        		                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		return(false);
        	}
        	
        	if (oController.IsSpyWorkerBusy())
        	{
        		MessageBox.Show("The spy is currently running on the bus" + Tab_CAN_Controllers.TabPages[iTab].Text + "! Bus closing abort !\nStop the spy prior to close it.",
        		                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		return(false);
        	}
        	
        	return(true);
        }
        
        private void Switch_ActiveCanBus()
        {
        	if (!(ActiveCanBus == null))
        	{
        		int CtrlActiveTab = ActiveCanBus.ControllerActiveMode;
        		
        		TS_Lbl_CanCfgTitle.Visible = false;
        		TS_Lbl_CanCfg.Visible = false;
        		TS_Lbl_CanCfgDesc.Visible = false;
        		
        		switch (CtrlActiveTab)
        		{
        			case 1: //Manual and Spy
        				
        				//cycleToolStripMenuItem
        				Cycle_openToolStripMenuItem.Enabled=false;
                        Cycle_recentToolStripMenuItem.Enabled = false;

                        //cANConfigurationToolStripMenuItem
                        CANConfig_openToolStripMenuItem.Enabled=true;
						importDBCToolStripMenuItem.Enabled=true;
						CANConfig_editToolStripMenuItem.Enabled = false;
						
						//ViewtoolStripMenuItem
						TSMI_Layout_Manual.Enabled = true;
						TSMI_Layout_Cycle.Enabled = false;
						TSMI_Columns_Manual.Enabled = true;
						TSMI_Columns_Cycle.Enabled = false;
						
						UpdateGridsColumnsStates(CANControllerGrid.Grid_Manual, ActiveCanBus.Get_TxGridColumnsVisible());
						UpdateGridsColumnsStates(CANControllerGrid.Grid_SpyEng, ActiveCanBus.Get_RxGridColumnsVisible());
						
						CANMessagesConfiguration oActiveCanCfg = ActiveCanBus.Get_BusCANConfiguration();
						
						if (!(oActiveCanCfg == null))
						{
							TS_Lbl_CanCfgTitle.Visible = true;
        					TS_Lbl_CanCfg.Visible = true;
        					TS_Lbl_CanCfg.Text = oActiveCanCfg.Name;
        					
        					if (!(Tab_CAN_Controllers.SelectedTab.ToolTipText.Equals("")))
        					{
        						TS_Lbl_CanCfgDesc.Visible = true;
        						TS_Lbl_CanCfgDesc.Text = Tab_CAN_Controllers.SelectedTab.ToolTipText;
        					}
        					
        					CANConfig_editToolStripMenuItem.Enabled = true;
						}
						
						break;
        				
        			case 2: //Cycle
        				
        				//cycleToolStripMenuItem
        				Cycle_openToolStripMenuItem.Enabled=true;
                        Cycle_recentToolStripMenuItem.Enabled = true;

                        //cANConfigurationToolStripMenuItem
                        CANConfig_openToolStripMenuItem.Enabled=false;
						CANConfig_editToolStripMenuItem.Enabled=false;
						importDBCToolStripMenuItem.Enabled=false;
        				
						//ViewtoolStripMenuItem management
						TSMI_Layout_Manual.Enabled = false;
						TSMI_Layout_Cycle.Enabled = true;
						TSMI_Columns_Manual.Enabled = false;
						TSMI_Columns_Cycle.Enabled = true;
						
						UpdateGridsColumnsStates(CANControllerGrid.Grid_Cycle_Eng, ActiveCanBus.Get_CycleEngGridColumnsVisible());
						
        				break;
        		}
        		
				FrmMain_MenuStrip.Enabled = !(ActiveCanBus.IsCycleWorkerBusy() || ActiveCanBus.IsManualWorkerBusy() || ActiveCanBus.IsSpyWorkerBusy());
        	}
        	//else not supposed to happen...
        }
        
        private TabPage Get_TabPageAtPosition(Point Position)
        {
        	Position = this.PointToScreen(Position);
        	
        	for (int i=0; i<Tab_CAN_Controllers.TabPages.Count; i++)
        	{
        		Rectangle TabRec = Tab_CAN_Controllers.GetTabRect(i);
        		TabRec.Location = this.PointToScreen(TabRec.Location);
        		
        		if ((Position.X >= TabRec.Left && Position.X < TabRec.Left + TabRec.Width)
				    && (Position.Y >= TabRec.Top && Position.Y < TabRec.Top + TabRec.Height))
        		{
        			return(Tab_CAN_Controllers.TabPages[i]);
        		}
        	}
        	
        	return(null);
        }

        private void ManualTxColumnTSMIChanged(ToolStripMenuItem oMenuItem, GridCANData_ColumnsEnum eTSMIColumn)
        {
            if (!(ActiveCanBus == null))
            {
                oMenuItem.Checked = !oMenuItem.Checked;
                GridCANData_ColumnsEnum eColumns = ActiveCanBus.Get_TxGridColumnsVisible();

                if (oMenuItem.Checked)
                {
                    eColumns |= eTSMIColumn;
                }
                else
                {
                    eColumns -= eTSMIColumn;
                }

                ActiveCanBus.Set_TxGridColumnsVisible(eColumns);
            }
        }

        private void ManualRxColumnTSMIChanged(ToolStripMenuItem oMenuItem, GridCANData_ColumnsEnum eTSMIColumn)
        {
            if (!(ActiveCanBus == null))
            {
                oMenuItem.Checked = !oMenuItem.Checked;
                GridCANData_ColumnsEnum eColumns = ActiveCanBus.Get_RxGridColumnsVisible();

                if (oMenuItem.Checked)
                {
                    eColumns |= eTSMIColumn;
                }
                else
                {
                    eColumns -= eTSMIColumn;
                }

                ActiveCanBus.Set_RxGridColumnsVisible(eColumns);
            }
        }

        private void CycleRxColumnTSMIChanged(ToolStripMenuItem oMenuItem, GridCANData_ColumnsEnum eTSMIColumn)
        {
            if (!(ActiveCanBus == null))
            {
                oMenuItem.Checked = !oMenuItem.Checked;
                GridCANData_ColumnsEnum eColumns = ActiveCanBus.Get_CycleEngGridColumnsVisible();

                if (oMenuItem.Checked)
                {
                    eColumns |= eTSMIColumn;
                }
                else
                {
                    eColumns -= eTSMIColumn;
                }

                ActiveCanBus.Set_CycleEngGridColumnsVisible(eColumns);
            }
        }

        private void Save_ControllerLayout()
        {
        	string LayoutsPath = CANStreamTools.CsDataPath + "\\Layouts.xml";
        	
        	CAN_Controller_Layouts CtrlLayouts = new CAN_Controller_Layouts();
        	
        	if (!CtrlLayouts.Load_Controller_Layouts(LayoutsPath))
        	{
        		CtrlLayouts.Layouts =  new List<Ctrl_CS_CAN_Bus_Layout>();
        	}
        	
        	for (int i=0; i<Tab_CAN_Controllers.TabPages.Count; i++)
        	{
        		if (!(Tab_CAN_Controllers.TabPages[i].Equals(TabPage_NewController)))
        		{
        			Ctrl_CS_CAN_Bus_Layout oLayout = ((Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[i].Controls[0]).GetControllerLayout();
        			
        			if (i < CtrlLayouts.Layouts.Count)
        			{
        				CtrlLayouts.Layouts[i] = oLayout;
        			}
        			else
        			{
        				CtrlLayouts.Layouts.Add(oLayout);
        			}
        		}
        	}
        	
        	if (CtrlLayouts.Layouts.Count > 0)
        	{
        		CtrlLayouts.Save_Controller_Layouts(LayoutsPath);
        	}
        }
        
        private void Delete_ControllerTmpBackUpFile(string BackUpFile)
        {
        	if (File.Exists(BackUpFile))
        	{
        		File.Delete(BackUpFile);
        	}
        }
        
        private void Delete_AllControllerTmpBackUpFile()
        {
        	DirectoryInfo oDir = new DirectoryInfo(CANStreamTools.CsDataPath);
        	FileInfo[] BackupFiles = oDir.GetFiles("*.xcc");
        	
        	if (BackupFiles.Length > 0)
        	{
        		foreach (FileInfo oFile in BackupFiles)
        		{
        			File.Delete(oFile.FullName);
        		}
        	}
        }
        
        private DateTime Get_ControllerLastCANConfigChange(string ControllerName)
        {
            if (!(ControllerName.Equals("")))
            {
                for (int iController=0; iController< CanControllerCount; iController++)
                {
                    Ctrl_CS_CAN_Bus oController = (Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[iController].Controls[0];

                    if (oController.ControllerChannelName.Equals(ControllerName))
                    {
                        return (oController.TimeOfLastCANConfigChange);
                    }
                }
            }

            return (DateTime.MaxValue);
        }

        private CANMessagesConfiguration Get_ControllerChannelCANConfiguration(string ControllerName)
        {
            if (!(ControllerName.Equals("")))
            {
                for (int iController = 0; iController < CanControllerCount; iController++)
                {
                    Ctrl_CS_CAN_Bus oController = (Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[iController].Controls[0];

                    if (oController.ControllerChannelName.Equals(ControllerName))
                    {
                        return (oController.Get_BusCANConfiguration());
                    }
                }
            }

            return (null);
        }

        #endregion
        
        #region Active BUS CAN Configuration
        
        private void LoadCANConfiguration()
        {
        	if (!(ActiveCanBus == null))
        	{
        		openFileDialog1.FileName = "";
        		openFileDialog1.Filter = "CAN Configuration|*.xcc|Multiple CAN bus Configuration|*.mcb";
        		openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";

        		if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
        		{
        			if (Path.GetExtension(openFileDialog1.FileName).Equals(".xcc"))
        			{
	        			CANMessagesConfiguration oNewCfg = new CANMessagesConfiguration();
	        			
	        			if (oNewCfg.ReadCANConfigurationFile(openFileDialog1.FileName))
	        			{
	        				ActiveCanBus.Set_BusCANConfiguration(oNewCfg);
	        			}
	        			else
	        			{
	        				MessageBox.Show("CAN Configuration file reading error !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
	        			}
        			}
        			else if (Path.GetExtension(openFileDialog1.FileName).Equals(".mcb"))
        			{
        				Load_ControllersConfiguration(openFileDialog1.FileName);
        			}

                    UpdateElementsHistory(openFileDialog1.FileName, HistoryElements.CanConfiguration);
        		}
        	}
        }
        
        private void CreateNewCanConfiguration()
        {
            Frm_CANConfiguration Frm = new Frm_CANConfiguration();
            Frm.Show();
        }
		
        private void EditCurrentCanConfiguration()
        {        	
        	if (!(ActiveCanBus == null))
        	{
        		CANMessagesConfiguration oBusCanCfg = ActiveCanBus.Get_BusCANConfiguration();
        		
        		if (!(oBusCanCfg == null))
        		{
        			Frm_CANConfiguration Frm=new Frm_CANConfiguration(true, (int)ActiveCanBus.Tag, this);
        			Frm.SetCurrentCanConfiguration(oBusCanCfg);
        			Frm.Show();
        		}
        	}
        }
        
        private void ImportDBCFile()
        {
        	if (!(ActiveCanBus == null))
        	{
        		openFileDialog1.FileName = "";
        		openFileDialog1.Filter = "Vector DBC file|*.dbc";
        		openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
        		
        		if(openFileDialog1.ShowDialog().Equals(DialogResult.OK))
        		{
        			CanDBCFile oDBC = new CanDBCFile();
        			
        			if(oDBC.ReadDBC(openFileDialog1.FileName))
        			{
        				string SrcDevice = Dlg_DBCTransmitterSelection.Show("CAN Device selection", "Select the CAN device to emulate.", oDBC.BusComponents);
        				ActiveCanBus.Set_BusCANConfiguration(oDBC.Convert_DBC_to_XCC(1000, SrcDevice)); // Baud rate 1 MBit/sec by default;
        			}
        			else
        			{
        				MessageBox.Show("DBC file reading error !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
        				return;
        			}
        			
        			MessageBox.Show("DBC Succesfully imported !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
        		}
        	}
        }
        
        #endregion
        		
        #region Cycle management
        
        private void CreateCycle()
        {
            Frm_CycleCreation Frm = new Frm_CycleCreation();
            Frm.Show();
        }
        
        private void NewCycleEditor()
        {
        	if (!(ActiveCanBus == null))
        	{
        		Frm_CycleEdition Frm = new Frm_CycleEdition(ActiveCanBus.Get_BusCANConfiguration());
        		Frm.Show();
        	}
        }
        
        private void LoadCycle()
        {        	
        	if (!(ActiveCanBus == null))
        	{
        		openFileDialog1.FileName="";
        		openFileDialog1.Filter="CAN Strem cycle|*.csc";
        		openFileDialog1.InitialDirectory= CANStreamTools.MyDocumentPath + "\\CANStream\\Cycles";
        		
        		if(openFileDialog1.ShowDialog().Equals(DialogResult.OK))
        		{
        			CANStreamCycle oCycle=new CANStreamCycle();
        			
        			if(oCycle.ReadStreamCycle(openFileDialog1.FileName))
        			{
        				ActiveCanBus.Set_Cycle(oCycle);
                        UpdateElementsHistory(openFileDialog1.FileName, HistoryElements.Cycle);
                    }
        			else
        			{
        				MessageBox.Show("Cycle file reading error !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
        			}
        		}
        	}
        }
        
        private void EditCycleDataAssociation()
        {
            Frm_CycleDataAssociation Frm = new Frm_CycleDataAssociation();
            Frm.Show();
        }
        
        private void OpenCycelDataAssociation()
        {
        	openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Cycle Data Association|*.cda";
			openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle Data Association";
			
            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
            	Frm_CycleDataAssociation Frm=new Frm_CycleDataAssociation();
            	Frm.LoadAssociationFile(openFileDialog1.FileName);
            	Frm.Show();
            }
        }
        
        private void CreateCycleFromRecord()
        {
        	Frm_CycleRecordImport Frm = new Frm_CycleRecordImport();
        	Frm.Show();
        }
        
        #endregion
                        
        #region CAN Trace recording management
                
        private void RecordConversionSelection()
        {        	
        	Frm_TrcFileSelection Frm = new Frm_TrcFileSelection(CANStreamTools.TraceConversionOptions.SourceFileFolder, this);
        	Frm.Show();
        }
        
        private void StopRecordsConversion()
        {
        	if(BGWrk_RecordConversion.IsBusy)
        	{
        		BGWrk_RecordConversion.CancelAsync();
        	}
        }
        
        private void ConvertRecords(BackgroundWorker Worker)
        {
        	//Check if the output foder and backup folder exist, if not we create those missing
        	if(!(CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.TraceConversionOptions.OutputFileFolder)
        	     & CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.TraceConversionOptions.SourceFileBackUpFolder)))
        	{
        		MessageBox.Show("The output directory or the backup directory (or both) is missing and it is not possible to create it !"
        		                ,Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		return;
        	}

            //Convert all files of the list
            if (CANStreamTools.TraceConversionOptions.TrcFileList.Length>0)
        	{
        		string VCLibCollectionFilePath = "";
        		if (File.Exists(CANStreamTools.CsDataPath + "\\Libraries.xml"))
        		{
        			VCLibCollectionFilePath = CANStreamTools.CsDataPath + "\\Libraries.xml";
        		}
        		
        		int Progress=0;
        		
        		for(int iFile=0;iFile< CANStreamTools.TraceConversionOptions.TrcFileList.Length;iFile++)
        		{
        			if(Worker.CancellationPending) //Exit converion process if cancellation is requested by the user
        			{
        				break;
        			}

                    //PCAN Trace file reading
                    RecordDataFile oRecord = new RecordDataFile(CANStreamTools.TraceConversionOptions.TrcFileList[iFile], VCLibCollectionFilePath);

                    //Trace file conversion
                    object ErrorFile = null;
        			bool bConversionOK= oRecord.ConvertTrcFile(CANStreamTools.TraceConversionOptions.OutputFileFolder,
        			                                           CANStreamTools.TraceConversionOptions.OutputFileFormat);
        			
        			if(bConversionOK)
        			{
        				//Move the trace file from stack folder to backup folder
        				MoveTrcFileToBackUpFolder(CANStreamTools.TraceConversionOptions.TrcFileList[iFile], CANStreamTools.TraceConversionOptions.SourceFileBackUpFolder);
        			}
        			else
        			{
                        ErrorFile = CANStreamTools.TraceConversionOptions.TrcFileList[iFile].TrcFileInfo.Name;
                    }
        				
        			//Update progression
        			Progress=(int)((iFile + 1) * 100 / CANStreamTools.TraceConversionOptions.TrcFileList.Length);
        			Worker.ReportProgress(Progress, ErrorFile);
        		}
        	}
        }
        
        private void MoveTrcFileToBackUpFolder(PcanTrcFileInfo oTrcFile, string BackUpFolder)
        {
			if (!(oTrcFile == null || BackUpFolder.Equals("")))
        	{        		
        		if (!(oTrcFile.TrcFileEvent == null || oTrcFile.TrcFileSession == null))
        		{
        			if (!(Directory.Exists(BackUpFolder + "\\" + oTrcFile.TrcFileEvent.Name)))
        			{
        				Directory.CreateDirectory(BackUpFolder + "\\" + oTrcFile.TrcFileEvent.Name);
        				oTrcFile.TrcFileEvent.Write_RecordEventInformationFile(BackUpFolder + "\\" + oTrcFile.TrcFileEvent.Name + "\\EventDetails.xml");
        			}
        			
        			BackUpFolder += ("\\" + oTrcFile.TrcFileEvent.Name);
        			
        			if (!(Directory.Exists(BackUpFolder + "\\" + oTrcFile.TrcFileSession.Name)))
        			{
        				Directory.CreateDirectory(BackUpFolder + "\\" + oTrcFile.TrcFileSession.Name);
        				oTrcFile.TrcFileSession.Write_RecordSessionInformationFile(BackUpFolder + "\\" + oTrcFile.TrcFileSession.Name + "\\SessionDetails.xml");
        			}
        			
        			BackUpFolder += ("\\" + oTrcFile.TrcFileSession.Name);
        		}

                try
                {
                    File.Move(oTrcFile.TrcFileInfo.FullName, BackUpFolder + "\\" + Path.GetFileName(oTrcFile.TrcFileInfo.FullName));
                }
                catch
                {
                    MessageBox.Show("Error while moving trace file " + oTrcFile.TrcFileInfo.Name + " to the raw data folder.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

        		//Delete session and event folders of the "Stack" folder if they is no trace file anymore
        		DirectoryInfo oStackSessionDirInfo = new DirectoryInfo(Path.GetDirectoryName(oTrcFile.TrcFileInfo.FullName));
        		
        		if (oStackSessionDirInfo.GetFiles().Length == 1 && oStackSessionDirInfo.GetDirectories().Length == 0) //If only one file left and no sub folders
        		{
        			if (File.Exists(oStackSessionDirInfo.FullName + "\\SessionDetails.xml")) //If the remaining file is SessionDetails.xml
        			{
        				DirectoryInfo oStackEventDirInfo = new DirectoryInfo(Path.GetDirectoryName(oStackSessionDirInfo.FullName));
        				
        				Directory.Delete(oStackSessionDirInfo.FullName, true); //Stack Session directory deleting
        				
        				if (oStackEventDirInfo.GetFiles().Length == 1 && oStackEventDirInfo.GetDirectories().Length == 0) //If only one file left and no sub folders
        				{
        					if (File.Exists(oStackEventDirInfo.FullName + "\\EventDetails.xml")) //If the remaining file is EventDetails.xml
        					{
        						Directory.Delete(oStackEventDirInfo.FullName, true); //Stack Event directory deleting
        					}
        				}
        			}
        		}
        	}
        }
        
        private CANMessagesConfiguration LoadConversionCanConfiguration()
        {
        	openFileDialog1.FileName = "";
    		openFileDialog1.Filter = "CAN Configuration|*.xcc";
			openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
    		
    		if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
    		{
    			CANMessagesConfiguration oCanCfg = new CANMessagesConfiguration();
    			
    			if (oCanCfg.ReadCANConfigurationFile(openFileDialog1.FileName))
    			{
    				return(oCanCfg);
    			}
                else
                {
                    MessageBox.Show("An error occured while loading the CAN configuration file !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
    		}
    		
    		return(null);
        }
        
        #region Recording Event/Session management
        
        private void Set_RegisterRecordEventSession()
        {
        	if (!(oRecordEvent == null))
        	{
        		string RecordEventRegKey = CANStreamConstants.CS_REG_KEY + "\\RecordEventSession\\Event";
        	
        		Registry.SetValue(RecordEventRegKey, "Name", oRecordEvent.Name);
        		Registry.SetValue(RecordEventRegKey, "Date", oRecordEvent.StartingDate.ToString());
        		
        		if (!(oRecordEvent.CurrentSession == null))
        		{
        			string RecordSessionRegKey = CANStreamConstants.CS_REG_KEY + "\\RecordEventSession\\Session";
        	
        			Registry.SetValue(RecordSessionRegKey, "Name", oRecordEvent.CurrentSession.Name);
        		}
        	}
        }
        
        private void Get_LastRecordEventSession()
        {
        	oRecordEvent = new CS_RecordEvent();
        	string AppEventsFile = CANStreamTools.CsDataPath + "\\RecordEvents.xml";
        	
        	if (File.Exists(AppEventsFile))
        	{
        		CS_RecordEventsCollection oEvents = new CS_RecordEventsCollection();
        		
        		if (oEvents.Read_EventsCollectionFile(AppEventsFile))
        		{
        			object EventNameRegKey = Registry.GetValue(CANStreamConstants.CS_REG_KEY + "\\RecordEventSession\\Event", "Name", "");
        			object EventDateRegKey = Registry.GetValue(CANStreamConstants.CS_REG_KEY + "\\RecordEventSession\\Event", "Date", "");
        			
        			if ((EventNameRegKey != null) && (EventDateRegKey != null))
        			{
        				int iEvent = oEvents.Get_RecordEventIndex(EventNameRegKey.ToString(), DateTime.Parse(EventDateRegKey.ToString()));
        				
        				if (iEvent >= 0)
        				{
        					oRecordEvent = oEvents.Events[iEvent];
        					
        					object SessionNameRegKey = Registry.GetValue(CANStreamConstants.CS_REG_KEY + "\\RecordEventSession\\Session", "Name", "");
        					
        					if (SessionNameRegKey != null)
        					{
        						int iSession = oRecordEvent.Get_SessionIndex(SessionNameRegKey.ToString());
        						
        						if (iSession >= 0)
        						{
        							oRecordEvent.CurrentSession = oRecordEvent.Sessions[iSession];
        						}
        					}
        				}
        				else
        				{
        					oRecordEvent = oEvents.Events[0];
        				}
        			}
        			else
        			{
        				oRecordEvent = oEvents.Events[0];
        			}
        		}
        	}
        	
        	UpDate_RecordEventSession();
        }
        
        #region Recording Events
        
        private void CreateNewRecordEvent()
        {
        	oRecordEvent = new CS_RecordEvent();
        	Frm_RecordEventEdition Frm = new Frm_RecordEventEdition(oRecordEvent, this as Form, true);
        	Frm.Show();
        }
        
        private void SelectRecordEvent()
        {
        	string AppEventsFile = CANStreamTools.CsDataPath + "\\RecordEvents.xml";
        	
        	if (File.Exists(AppEventsFile))
        	{
        		CS_RecordEventsCollection oEventCollection = new CS_RecordEventsCollection();
        		
        		if (oEventCollection.Read_EventsCollectionFile(AppEventsFile))
        		{
        			Frm_RecordEventSessionSelection Frm = new Frm_RecordEventSessionSelection((object)oEventCollection, this, RecordObjectSelectionMode.Event);
        			Frm.Show();
        		}
        		else
        		{
        			MessageBox.Show("Record events collection file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        		}
        	}
        	else
        	{
        		MessageBox.Show("No record event created yet !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        	}
        }
        
        private void EditRecordEvent()
        {
        	Frm_RecordEventEdition Frm = new Frm_RecordEventEdition(oRecordEvent, this as Form, false);
        	Frm.Show();
        }
        
        private string CreateRecordEventFolder(string RootFolder)
        {
        	string EventDirectoryPath = RootFolder + "\\" + oRecordEvent.Name;
        	string EventInfoFilePath = EventDirectoryPath + "\\EventDetails.xml";
        	
        	if (!(Directory.Exists(EventDirectoryPath))) Directory.CreateDirectory(EventDirectoryPath);
        	if (File.Exists(EventInfoFilePath)) File.Delete(EventInfoFilePath);
        	
        	oRecordEvent.Write_RecordEventInformationFile(EventInfoFilePath);
        	
        	return(EventDirectoryPath);
        } //Done
        
        #endregion
        
        #region Recording Sessions
        
        private void CreateNewRecordSession()
        {
        	CS_RecordSession oNewSession = new CS_RecordSession();
        	oRecordEvent.Sessions.Add(oNewSession);
        	
        	Frm_RecordSessionEdition Frm = new Frm_RecordSessionEdition(oRecordEvent,oNewSession,this, false);
        	Frm.Show();
        }
        
        private void SelectRecordSession()
        {
        	Frm_RecordEventSessionSelection Frm = new Frm_RecordEventSessionSelection((object)oRecordEvent, this, RecordObjectSelectionMode.Session);
        	Frm.Show();
        }
        
        private void EditRecordSession()
        {
        	Frm_RecordSessionEdition Frm = new Frm_RecordSessionEdition(oRecordEvent,oRecordEvent.CurrentSession,this,false);
        	Frm.Show();
        }
        
        private string CreateRecordSessionFolder(string RootFolder)
        {
        	string SessionDirectoryPath = RootFolder + "\\" + oRecordEvent.CurrentSession.Name;
        	string SessionInfoFilePath = SessionDirectoryPath + "\\SessionDetails.xml";
        	
        	if (!(Directory.Exists(SessionDirectoryPath))) Directory.CreateDirectory(SessionDirectoryPath);
        	if (File.Exists(SessionInfoFilePath)) File.Delete(SessionInfoFilePath);
        	
        	oRecordEvent.CurrentSession.Write_RecordSessionInformationFile(SessionInfoFilePath);
        	
        	return(SessionDirectoryPath);
        } //Done
        
        #endregion
        
        #endregion
        
        #endregion
        
        #region Virtual Channels & Built-In Signals
        
        private void EditVirtualChannels(CS_VirtualChannelsLibrary UserLib)
        {
        	Frm_VirtualChannel Frm = new Frm_VirtualChannel(this);
        	Frm.Show();
        	
        	if (!(UserLib == null))
        	{
        		Frm.Set_UserLibrary(UserLib);
        	}        	
        }
        
        private void EditBuiltInSignals(CS_BuiltInSignalLibrary UserLib)
        {
        	Frm_BuiltInSignal Frm = new Frm_BuiltInSignal(this);
        	Frm.Show();
        	
        	if (!(UserLib == null))
        	{
        		Frm.Set_UserLibrary(UserLib);
        	}
        }
        
        #endregion
        
        #region Data Viewer
        
        private void NewDataViewer()
        {
        	string VCLibCollectionFilePath = "";
    		if (File.Exists(CANStreamTools.CsDataPath + "\\Libraries.xml"))
    		{
    			VCLibCollectionFilePath = CANStreamTools.CsDataPath + "\\Libraries.xml";
    		}
        	
        	Frm_DataViewer Frm = new Frm_DataViewer(VCLibCollectionFilePath);
        	Frm.Show();
        }
        
        private void LoadDataViewer()
        {        	
        	openFileDialog1.FileName = "";
    		openFileDialog1.Filter = "Data viewer book|*.dvb";
			openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Data Viewers";
    		
    		if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
    		{
    			OpenDataViewer(openFileDialog1.FileName);
                UpdateElementsHistory(openFileDialog1.FileName, HistoryElements.DataViewer);
            }
        }
        
        private void OpenDataViewer(string fPath)
        {
        	string VCLibCollectionFilePath = "";
    		if (File.Exists(CANStreamTools.CsDataPath + "\\Libraries.xml"))
    		{
    			VCLibCollectionFilePath = CANStreamTools.CsDataPath + "\\Libraries.xml";
    		}
    		
    		Frm_DataViewer Frm = new Frm_DataViewer(VCLibCollectionFilePath);
    		Frm.Show();
    		
    		if (!(Frm.Set_ViewBook(fPath)))
    		{
    			Frm.Close();
    		}
        }
        
        #endregion
        
        #region Misc
        
        private void Check_CANStreamFolders()
        {
        	CANStreamTools.CreateFolderIfItDoesNotExist(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\CANStream");
        	CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream");
        	
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle Data Association");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Cycles");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle creation Configuration");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Records\\Stack");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Records\\Data");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Records\\Raw");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Virtual Channels libraries");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Built-In Signals libraries");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Data Viewers");
        		CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + "\\CANStream\\Record User Information");
        }
        
        private void UpdateGridsColumnsStates(CANControllerGrid eGrid, GridCANData_ColumnsEnum eColVisible)
        {
            switch (eGrid)
        	{
        		case CANControllerGrid.Grid_Manual:
        			
        			{
                        TSMI_Columns_Manual_Tx_ID.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_ID);
                        TSMI_Columns_Manual_Tx_RxTx.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_RxTx);
                        TSMI_Columns_Manual_Tx_Value.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Value);
                        TSMI_Columns_Manual_Tx_RawValue.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_RawValue);
                        TSMI_Columns_Manual_Tx_Min.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Min);
                        TSMI_Columns_Manual_Tx_Max.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Max);
                        TSMI_Columns_Manual_Tx_Unit.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Unit);
                        TSMI_Columns_Manual_Tx_Period.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Period);
                        TSMI_Columns_Manual_Tx_Start.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Start);
                        TSMI_Columns_Manual_Tx_Length.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Length);
                        TSMI_Columns_Manual_Tx_Endianess.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Endianess);
                        TSMI_Columns_Manual_Tx_Signedness.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Signedness);
                        TSMI_Columns_Manual_Tx_Gain.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Gain);
                        TSMI_Columns_Manual_Tx_Zero.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Zero);
                        TSMI_Columns_Manual_Tx_Count.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Count);
                        TSMI_Columns_Manual_Tx_DLC.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_DLC);
			        	TSMI_Columns_Manual_Tx_Comment.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Comment);
                    }
        			
        			break;
        			
        		case CANControllerGrid.Grid_SpyEng:
        			
        			{        				
        				TSMI_Columns_Manual_Rx_Eng_ID.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_ID);
                        TSMI_Columns_Manual_Rx_Eng_RxTx.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_RxTx);
                        TSMI_Columns_Manual_Rx_Eng_Value.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Value);
			        	TSMI_Columns_Manual_Rx_Eng_RawVal.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_RawValue);
			        	TSMI_Columns_Manual_Rx_Eng_Min.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Min);
			        	TSMI_Columns_Manual_Rx_Eng_Max.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Max);
			        	TSMI_Columns_Manual_Rx_Eng_Unit.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Unit);
                        TSMI_Columns_Manual_Rx_Eng_Period.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Period);
                        TSMI_Columns_Manual_Rx_Eng_Start.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Start);
                        TSMI_Columns_Manual_Rx_Eng_Length.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Length);
                        TSMI_Columns_Manual_Rx_Eng_Endianess.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Endianess);
                        TSMI_Columns_Manual_Rx_Eng_Signed.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Signedness);
                        TSMI_Columns_Manual_Rx_Eng_Gain.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Gain);
                        TSMI_Columns_Manual_Rx_Eng_Zero.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Zero);
                        TSMI_Columns_Manual_Rx_Eng_Count.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Count);
                        TSMI_Columns_Manual_Rx_Eng_DLC.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_DLC);
			        	TSMI_Columns_Manual_Rx_Eng_Comment.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Comment);	
        			}
        			
        			break;
        			
        		case CANControllerGrid.Grid_Cycle_Eng:
        			
        			{        				
        				TSMI_Columns_Cycle_Eng_ID.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_ID);
                        TSMI_Columns_Cycle_Eng_RxTx.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_RxTx);
                        TSMI_Columns_Cycle_Eng_Value.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Value);
			        	TSMI_Columns_Cycle_Eng_RawVal.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_RawValue);
			        	TSMI_Columns_Cycle_Eng_Min.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Min);
			        	TSMI_Columns_Cycle_Eng_Max.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Max);
			        	TSMI_Columns_Cycle_Eng_Unit.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Unit);
                        TSMI_Columns_Cycle_Eng_Period.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Period);
                        TSMI_Columns_Cycle_Eng_Start.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Start);
                        TSMI_Columns_Cycle_Eng_Length.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Length);
                        TSMI_Columns_Cycle_Eng_Endianess.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Endianess);
                        TSMI_Columns_Cycle_Eng_Signedness.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Signedness);
                        TSMI_Columns_Cycle_Eng_Gain.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Gain);
                        TSMI_Columns_Cycle_Eng_Zero.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Zero);
                        TSMI_Columns_Cycle_Eng_Count.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Count);
                        TSMI_Columns_Cycle_Eng_DLC.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_DLC);
			        	TSMI_Columns_Cycle_Eng_Comment.Checked = eColVisible.HasFlag(GridCANData_ColumnsEnum.Column_Comment);
        			}
        			
        			break;
        	}
        }
        
        private void SetCANControlsRunningCommands(bool bRunning)
        {
            cANConfigurationToolStripMenuItem.Enabled = !bRunning;
            cycleToolStripMenuItem.Enabled = !bRunning;

            //Recording menuitem
            automaticRecordingToolStripMenuItem.Enabled = !bRunning;
            recordingTriggerToolStripMenuItem.Enabled = !bRunning;
            recordingEventToolStripMenuItem.Enabled = !bRunning;
            recordingSessionToolStripMenuItem.Enabled = !bRunning;

            //Tools menuitem
            virtualChannelsToolStripMenuItem.Enabled = !bRunning;
            builtinSignalsToolStripMenuItem.Enabled = !bRunning;

        }

        #endregion
        
        #endregion
        
        #region Public methodes
        
        #region CAN Configuration
       
        public void ReloadCanConfig(string CfgPath, int ControllerId)
        {
        	CANMessagesConfiguration oCanCfg = new CANMessagesConfiguration();
        	
        	if (oCanCfg.ReadCANConfigurationFile(CfgPath))
        	{
        		try
        		{
        			Ctrl_CS_CAN_Bus oContoller = (Ctrl_CS_CAN_Bus)Tab_CAN_Controllers.TabPages[ControllerId].Controls[0];
        			oContoller.Set_BusCANConfiguration(oCanCfg);
        		}
        		catch
        		{
        			MessageBox.Show("Original controller has been closed !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        		}
        	}
        }
       	
        public void ReloadControllerConfig(string CfgPath)
        {
        	if (!(CfgPath.Equals("")))
        	{
        		if (Close_AllControllerTabs())
        		{
        			Load_ControllersConfiguration(CfgPath);
        		}
        	}
        }
        
        #endregion
        
        #region CAN Trace recording management
        
        public void LaunchConvertRecords()
        {
            CANMessagesConfiguration oConversionCanCfg = null;
            bool bAllTracesUseSameCanCfg = false;

            //Creation of trc files list to convert
            if (CANStreamTools.TraceConversionOptions.TrcFileList == null) //List of Trc files to convert is empty in case of automatic conversion
            {
                CANStreamTools.GetTrcFileInfoList(CANStreamTools.TraceConversionOptions.SourceFileFolder);
            }

            //Set conversion CAN Configuration for each trace file
            if (!(CANStreamTools.TraceConversionOptions.TrcFileList==null))
            {
                List<PcanTrcFileInfo> oFileList = new List<PcanTrcFileInfo>();
                oFileList.AddRange(CANStreamTools.TraceConversionOptions.TrcFileList);

                for (int iTrcFile = 0; iTrcFile < oFileList.Count; iTrcFile++)
                {
                    PcanTrcFileInfo oTrcInfo = oFileList[iTrcFile];
                    PcanTrcFile oTrcFile = new PcanTrcFile();

                    if (oTrcFile.ReadTrcFile(oTrcInfo.TrcFileInfo.FullName, true))
                    {
                        if (oTrcFile.AbsDTStartTime.CompareTo(Get_ControllerLastCANConfigChange(oTrcFile.PCAN_Channel)) >= 0)
                        {
                            //Trace file is poseterior to last CAN Config change of the controller
                            //Get current CAN configuration of the controller
                            oTrcInfo.TrcCanConfig = Get_ControllerChannelCANConfiguration(oTrcFile.PCAN_Channel);
                        }

                        if (oTrcInfo.TrcCanConfig == null)
                        {
                            //Trace file is anterior to last CAN Config change of the controller
                            //OR controller currently doesn't exist
                            //OR controller currently exists has no CAN config set

                            if ((oConversionCanCfg != null) && (bAllTracesUseSameCanCfg))
                            {
                                oTrcInfo.TrcCanConfig = oConversionCanCfg;
                            }
                            else
                            {
                                DialogResult Rep = MessageBox.Show("No CAN configuration found for trace file " + oTrcInfo.TrcFileInfo.Name + " conversion !\nDo you want set a CAN configuration and resume the conversion process ?",
                                                                    Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                                switch (Rep)
                                {
                                    case DialogResult.Yes:

                                        oConversionCanCfg = LoadConversionCanConfiguration();

                                        if (!(oConversionCanCfg == null))
                                        {
                                            oTrcInfo.TrcCanConfig = oConversionCanCfg;

                                            if (iTrcFile < oFileList.Count - 1)
                                            {
                                                bAllTracesUseSameCanCfg = (MessageBox.Show("Do you want to use this configuration for all other trace files that will have an unknown conversion CAN configuration?",
                                                                            Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes));
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }

                                        break;

                                    case DialogResult.No:

                                        oFileList.Remove(oTrcInfo);
                                        iTrcFile--;
                                        break;

                                    case DialogResult.Cancel:

                                        return;
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("An error occured while loading " + oTrcInfo.TrcFileInfo.Name + " trace file!", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        oFileList.Remove(oTrcInfo);
                        iTrcFile--;
                    }

                    if (oFileList.Count == 0)
                    {
                        MessageBox.Show("Conversion file queue is empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                CANStreamTools.TraceConversionOptions.TrcFileList = oFileList.ToArray();
                oFileList = null;

                //Start conversion
                TS_Lbl_ConversionProgress.Visible = true;
                TS_PB_Conversion.Value = 0;
                TS_PB_Conversion.Visible = true;
                TSSL_StopConversion.Visible = true;

                bConverting = true;

                BGWrk_RecordConversion.RunWorkerAsync();
            }
            else
            {
                MessageBox.Show("Conversion file queue is empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        
        public void SetRecordConversionList(PcanTrcFileInfo[] TrcList, Frm_TrcFileSelection SelectionForm)
        {
			CANStreamTools.TraceConversionOptions.TrcFileList = TrcList;
			SelectionForm.Close();
			LaunchConvertRecords();
        }
        
        public bool IsTraceConversionRunning()
        {
        	return(bConverting);
        }
        
        #endregion
        
        #region Virtual channel management
        
        public void Load_VirtualChannelsInControllers()
        {
        	foreach (TabPage oTab in Tab_CAN_Controllers.TabPages)
        	{
        		if (!(oTab.Equals(TabPage_NewController)))
        		{
        			((Ctrl_CS_CAN_Bus)oTab.Controls[0]).Load_VC_LibrariesCollection();
        		}
        	}
        }
        
        #endregion
        
        #region Built-in signal management
        
        public void Load_BS_LibrariesCollection()
        {
        }
        
        #endregion
        
        #region Record event/session
        
        public void Set_ActiveRecordEvent(CS_RecordEvent oEvent)
        {
        	if (!(oEvent == null))
        	{
        		oRecordEvent = oEvent;
        		UpDate_RecordEventSession();
        	}
        }
        
        public void UpDate_RecordEventSession()
        {
        	SS_TS_Lbl_RecordEvent.Text = "Record event: " + oRecordEvent.Name;
        	SS_TS_Lbl_RecordSession.Text = "Record session: " + oRecordEvent.CurrentSession.Name;
        	
        	foreach (TabPage oTab in Tab_CAN_Controllers.TabPages)
        	{
        		if (!(oTab.Equals(TabPage_NewController)))
        		{
        			((Ctrl_CS_CAN_Bus)oTab.Controls[0]).Set_CurrentRecordEvent(oRecordEvent);
        		}
        	}
        }

        #endregion

        #endregion
    }
}
