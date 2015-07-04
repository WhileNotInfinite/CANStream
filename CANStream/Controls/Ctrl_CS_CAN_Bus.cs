/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/13/2014
 * Time: 14:45 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text; //StringBuilder
using System.Xml;
using System.Windows.Forms;

using ChartDirector;

//PCANBasic includes
using Peak.Can.Basic;
using TPCANHandle = System.Byte;
//

using NumberBaseConversion;

namespace CANStream
{
	#region Enums
	
	public enum CANControllerGrid
	{
		Grid_Manual    = 1,
		Grid_SpyRaw    = 2,
		Grid_SpyEng    = 3,
		Grid_Cycle_Raw = 4,
		Grid_Cycle_Eng = 5,
	}
	
	public enum Manual_Grid_Columns
	{
		None			  = 0x0000,
		Column_ID         = 0x0001,
		Column_RxTx       = 0x0002,
		Column_Period     = 0x0004,
		Column_MuxValue   = 0x0008,
		Column_Start      = 0x0010,
		Column_Length     = 0x0020,
		Column_Endianess  = 0x0040,
		Column_Signedness = 0x0080,
		Column_Gain       = 0x0100,
		Column_Zero       = 0x0200,
		Column_Unit       = 0x0400,
		Column_Comment    = 0x0800,
		All				  = 0x0FFF, //Update value 'All' in case of change
		Default 		  = (Column_ID | Column_RxTx | Column_Period | Column_Unit | Column_Comment),
	}
	
	public enum SpyRaw_Grid_Columns
	{
		None		  = 0x00,
		Column_DLC    = 0x01,
		Column_Data   = 0x02,
		Column_Period = 0x04,
		Column_Count  = 0x08,
		All			  = 0x0F, //Update value 'All' in case of change
		Default       = (Column_Data | Column_Period | Column_Count),
	}
	
	public enum SpyEngineering_Grid_Columns
	{
		None			= 0x00,
		Column_ID       = 0x01,
		Column_Value    = 0x02,
		Column_RawValue = 0x04,
		Column_Min      = 0x08,
		Column_Max      = 0x10,
		Column_Unit     = 0x20,
		Column_Comment  = 0x40,
		All				= 0x7F, //Update value 'All' in case of change
		Default			= (Column_Value | Column_Min | Column_Max | Column_Unit | Column_Comment),
	}
	
	public enum RecordingMode
	{
		Manual  = 0,
		Auto    = 1,
		Trigger = 2,
	}
	
	#endregion
	
	/// <summary>
	/// Description of Ctrl_CAN_Bus.
	/// </summary>
	public partial class Ctrl_CS_CAN_Bus : UserControl
	{
		#region Private enums
		
		private enum SpyCANRxMode
		{
			Manual         = 0,
			Event          = 1,
			Periodic_1ms   = 2,
			Periodic_2ms   = 3,
			Periodic_5ms   = 4,
			Periodic_10ms  = 5,
			Periodic_20ms  = 6,
			Periodic_50ms  = 7,
			Periodic_100ms = 8,
			Periodic_200ms = 9,
			Periodic_500ms = 10,
			Periodic_1sec  = 11,
		}
		
		#endregion
		
		#region private constants
		
		private const int T_MSG_CNT_UPDATE_PERIOD=500; //ms
		private const int SPY_GRID_UPDATE_PERIOD=100;
		private const int SPY_GRAPH_UPDATE_PERIOD=100;
		private Color GRID_BACK_COLOR=Color.LightBlue;
		private const int GRID_MANUAL_VALUE_COL = 11;
		private const int GRID_MANUAL_NAME_COL = 4;
		private const int GRID_MANUAL_COMMENT_COL = 13;
		private const int GRID_MAX_COL_WIDTH = 60;							
		private const int GRID_ENG_MANUAL_FILLER_COL = 13;	//Column 'Comment'
		private const int GRID_RAW_MANUAL_FILLER_COL = 0;	//Column 'ID'
        private const int GRID_RAW_COL_TX_PERIOD = 2;
		private const int GRID_RAW_COL_TX_BTN = 4;		
		private const int GRID_RAW_COL_1ST_BYTE = 5;
        
		#endregion
		
		#region Private members
		
		#region CANStream members
		
		private MainForm HostForm;
		
		private CANStreamCycle oCycle;
		private CANMessagesConfiguration oCanConfig;
		
		private bool bCANConnected;
		private bool bCycleRunning;
		private bool bManualRunning;
		private bool bSpyRunning;
		
		private Manual_Grid_Columns ManualGridColumnsVisible;
		private Ctrl_SpyDataViewer CurrentSpyViewer;
		
		//Cycle control
		private bool bPauseCycle;
		private int iLoopInitial;
		private int iLoopCurrent;
		private int LoopCnt;
		private int iTimeEventInitial;
		private int iTimeEventCurrent;
		private long TCycleStart;
		private long TCycleEnd;
		private long TimeInCycle;
		private bool bCycleStartSet;
		private bool bCycleEndSet;
		private bool bCycleStartEndTxtSetting;
		private double TCycleStart_Old;
		private double TCycleEnd_Old;
		
		//Spy control
		private SpyCANRxMode SpyMsgRxMode;
		private int SpyRxPeriod;
		private bool RxEventInitialized;
		private List<CANMessageDecoded> DecodedMessages;
		private int DecodedMessageCount;
		private DateTime TLastSpyGridUpdate;
		private DateTime TStartSpy;
		private DateTime TLastSpyGraphUpdate;
		private RT_GraphicSeries SpyGraphSeries;
		private bool bSpyGraphEnabled;
		private bool bSpyGraphFrozen;
		private double SpyGraphYMin;
		private double SpyGraphYMax;
		private bool SpyGraphAutoScale;
		private bool SpyGraphRestarted;
		private bool bClearSpyGrids;
		private Int16 SpyMsgIdFilterMin;
		private Int16 SpyMsgIdFilterMax;
        private bool bDataHistoryFrozen;
        private List<string> SpyGraphChannelList;

		//Manual control
		private List<CANMessageEncoded> TxEngMessages;
		private long SentMsgCounter;
		private bool bRawMsgGridEdition;
		private int NextRawMessageKeyId;
		private CAN_RawMessageList TxRawMessages;
		private bool bVirtualParamTx;
        private bool bRawMsgSending;
		
		//CAN trace record
		private bool bRecording;
		private CS_RecordEvent oRecordEvent;
		
		//Virtual channels
		private CS_VCLibrariesCollection VCLibCollection;
		
		private XYChart Graph;
		
		#endregion
		
		#region PCANBasic members
		
		/// <summary>
		/// Handles of the current available PCAN-Hardware
		/// </summary>
		private TPCANHandle[] m_HandlesArray;
		
		/// <summary>
		/// Saves the handle of a PCAN hardware
		/// </summary>
		private TPCANHandle m_PcanHandle;
		
		/// <summary>
		/// Saves the baudrate register for a conenction
		/// </summary>
		private TPCANBaudrate m_Baudrate;
		
		/// <summary>
		/// Stores the status of received messages for its display
		/// </summary>
		private System.Collections.ArrayList m_LastMsgsList;
		
		/// <summary>
		/// Receive-Event
		/// </summary>
		private System.Threading.AutoResetEvent m_ReceiveEvent;
		
		#endregion
		
		#endregion
		
		#region Public events
		
		public event EventHandler<ControllerModeChangedEventArgs> ControllerModeChanged;
		
		public event EventHandler<ControllerCANConfigChangedEventArgs> ControllerCanConfigChanged;
		
		public event EventHandler<ControllerConnectionStatusChangedEventArgs> ControllerConnectionStatusChanged;
		
		public event EventHandler<EventArgs> ControllerCycleLoaded;
		
		public event EventHandler<ControllerRunningChangedEventArgs> ControllerCycleRunningChanged;
		
		public event EventHandler<ControllerRunningChangedEventArgs> ControllerManualRunningChanged;
		
		public event EventHandler<ControllerRunningChangedEventArgs> ControllerSpyRunningChanged;
		
		public event EventHandler<ControllerCycleStartEndSettingEventArgs> ControllerCycleStartEndSetting;
				
		public event EventHandler<ControllerLayoutChangedEventArgs> ControllerLayoutChanged;
		
		public event EventHandler<ControllerGridColumnsChangedEventArgs> ControllerGridColumnsChanged;
		
		public event EventHandler<ControllerDiagChangedEventArgs> ControllerDiagChanged;
		
		#endregion
		
		#region Public properties
		
		public int ControllerActiveMode {get; private set;}
		
		#endregion
		
		#region Public members
		
		//CAN trace record
		public bool bRecordingAuto; //HACK: Remove [acquisition trigger]
		public bool bConversionAuto;
		public RecordingMode RecordMode;
		public CS_AcquisitionTrigger RecordTrigger;
		
		public string ManualCanConfigFilePath;
		
		#endregion
		
		public Ctrl_CS_CAN_Bus(MainForm FrmParent, CS_RecordEvent oCurrentEvent)
		{
			InitializeComponent();
			
			HostForm = FrmParent;
			
			ManualCanConfigFilePath = "";
			
			Cmb_SpyCANRxMode.Items.Clear();
			Cmb_SpyCANRxMode.Items.AddRange(Enum.GetNames(typeof(SpyCANRxMode)));
			
			CurrentSpyViewer = Manual_SpyDataViewer;
			
			Set_ManualGridColumnsVisible(Manual_Grid_Columns.Default);
			Set_SpyRawGridColumnsVisible(SpyRaw_Grid_Columns.Default);
			Set_SpyEngGridColumnsVisible(SpyEngineering_Grid_Columns.Default);
			
			//Initialization of cycle control management
			iLoopInitial=0;
			iTimeEventInitial=0;
			TimeInCycle = 0;
			Timer_CycleGraph.Enabled = false;
			bCycleStartSet = false;
			bCycleEndSet = false;
			bCycleStartEndTxtSetting = false;
			
			//Initialization of CAN spy control
			SpyMsgRxMode = SpyCANRxMode.Event;
			DecodedMessages=new List<CANMessageDecoded>();
			TLastSpyGridUpdate=DateTime.Now;
			TLastSpyGraphUpdate=DateTime.Now;
			SpyGraphSeries=new RT_GraphicSeries();
			SpyGraphSeries.BufferSize=(int)(30000/SPY_GRID_UPDATE_PERIOD);
			bSpyGraphEnabled=true;
			bSpyGraphFrozen=false;
			SpyGraphYMin=0;
			SpyGraphYMax=0;
			SpyGraphAutoScale=true;
			SpyGraphRestarted=false;
            bDataHistoryFrozen = false;
            TSTxt_IdFilterFrom.Tag = 0x0;
            TSTxt_IdFilterTo.Tag = 0x7ff;
			
			Cmb_SpyCANRate.SelectedIndex = 1; //1000 kBit/s
			Cmb_SpyCANRxMode.Text = SpyCANRxMode.Event.ToString();
			
			SpyGraphChannelList = new List<string>();
			ChkLst_ChannelSel.Tag = "";
			
			//Initialization of manual control management
			SentMsgCounter = 0;
			bRawMsgGridEdition = false;
			NextRawMessageKeyId = 0;
			TxRawMessages = null;
			bVirtualParamTx = false;
            bRawMsgSending = false;
			
			//Trace recording init
			RecordMode = RecordingMode.Manual;
			RecordTrigger = new CS_AcquisitionTrigger();
			RecordTrigger.TriggerStatusChanged += new EventHandler<TriggerChangedEventArg>(RecordTrigger_TriggerStatusChanged);
			
			// Creates the list for received messages
			m_LastMsgsList = new System.Collections.ArrayList();
			
			// Creates the event used for signalize incomming messages
			m_ReceiveEvent = new System.Threading.AutoResetEvent(false);
			
			//Initialize CAN Peak dll
			m_HandlesArray = new TPCANHandle[] //Plug&Play UBS device handling only
			{
				PCANBasic.PCAN_USBBUS1,
				PCANBasic.PCAN_USBBUS2,
				PCANBasic.PCAN_USBBUS3,
				PCANBasic.PCAN_USBBUS4,
				PCANBasic.PCAN_USBBUS5,
				PCANBasic.PCAN_USBBUS6,
				PCANBasic.PCAN_USBBUS7,
				PCANBasic.PCAN_USBBUS8
			};
			
			RefreshCANUSBDevicesList();
						
			//Virtual channels initialization
			Load_VC_LibrariesCollection();
			
			oRecordEvent = oCurrentEvent;
		}
		
		#region Control events
		
		#region Control
								
		private void Timer_CheckDeviceTick(object sender, EventArgs e)
		{
			CheckActiveCANUSBDevice();
		}
		
		#endregion
		
		#region CtrlMain_ToolStrip
		
		private void TSB_Refresh_USB_CAN_DeviceClick(object sender, EventArgs e)
		{
			RefreshCANUSBDevicesList();
		}
		
		private void TS_Cmb_PCAN_USB_DevicesSelectedIndexChanged(object sender, EventArgs e)
		{
			string strTemp;

			// Get the handle fromt he text being shown
			//
			strTemp = TS_Cmb_PCAN_USB_Devices.Text;
			strTemp = strTemp.Substring(strTemp.IndexOf('(')+1, 2);

			// Determines if the handle belong to a No Plug&Play hardware
			//
			m_PcanHandle = Convert.ToByte(strTemp,16);
			
			//CAN Communiction init
			if(!(m_Baudrate==0))
			{
				InitCANCommunication();
			}
		}
		
		private void TSB_CAN_LinkOffClick(object sender, EventArgs e)
		{
			if(m_PcanHandle!=0 & m_Baudrate!=0)
			{
				InitCANCommunication();
			}
		}
		
		private void TSB_CAN_LinkOnClick(object sender, EventArgs e)
		{
			if(BGWrk_Cycle.IsBusy)
			{
				bPauseCycle=false;
				StopCycle();
			}
			
			if(BGWrk_Manual.IsBusy)
			{
				StopManualControl();
			}
			
			ReleaseCANCommunication();
		}
		
		private void TSB_StartCANTraceRecordingClick(object sender, EventArgs e)
		{
			StartRecording();
		}
		
		private void TSB_StopCANTraceRecordingClick(object sender, EventArgs e)
		{
			StopRecording();
		}
		
		#region TSSB_View
		
		#region TSMI_SpyManual
		
		private void TSMI_TxMessagesClick(object sender, EventArgs e)
		{
			Switch_Manual_Tx_Panel();
		}
		
		#region TSMI_TxMessages
		
		private void TSMI_TxMessages_EngClick(object sender, EventArgs e)
		{
			Switch_Manual_Tx_Eng_Panel();
		}
		
		private void TSMI_TxMessages_RawClick(object sender, EventArgs e)
		{
			Switch_Manual_Tx_Raw_Panel();
		}
		
		#endregion
		
		private void TSMI_RxMessagesClick(object sender, EventArgs e)
		{
			Switch_Manual_Rx_Panel();
		}
		
		#region TSMI_RxMessages
		
		private void TSMI_RxMessages_DataClick(object sender, EventArgs e)
		{
			Switch_Manual_Rx_Data_Panel();
		}
		
		#region TSMI_RxMessages_Data
		
		private void TSMI_RxMsg_Data_EngClick(object sender, EventArgs e)
		{
			Switch_Manual_Rx_Data_Eng_Panel();
		}
		
		private void TSMI_RxMsg_Data_RawClick(object sender, EventArgs e)
		{
			Switch_Manual_Rx_Data_Raw_Panel();
		}
		
		#endregion
		
		private void TSMI_RxMessages_GraphClick(object sender, EventArgs e)
		{
			Switch_Manual_Rx_Graph_Panel();
		}
		
		#endregion
		
		#endregion
		
		#region TSMI_CyclePlayer
		
		private void TSMI_CyclePlayer_DataClick(object sender, EventArgs e)
		{
			TSMI_CyclePlayer_Data.Checked = !TSMI_CyclePlayer_Data.Checked;
			Split_Cycle_VirtualSig_Graph.Panel1Collapsed = !TSMI_CyclePlayer_Data.Checked;
			TSMI_CyclePlayer_Graph.Checked = !Split_Cycle_VirtualSig_Graph.Panel2Collapsed;
		}
		
		#region TSMI_CyclePlayer_Data
		
		private void TSMI_CyclePlayer_Data_EngClick(object sender, EventArgs e)
		{
			TSMI_CyclePlayer_Data_Eng.Checked = !TSMI_CyclePlayer_Data_Eng.Checked;
			Cycle_SpyDataViewer.EngDataGridVisible = TSMI_CyclePlayer_Data_Eng.Checked;
			TSMI_CyclePlayer_Data_Raw.Checked = Cycle_SpyDataViewer.RawDataGridVisible;
		}
		
		private void TSMI_CyclePlayer_Data_RawClick(object sender, EventArgs e)
		{
			TSMI_CyclePlayer_Data_Raw.Checked = !TSMI_CyclePlayer_Data_Raw.Checked;
			Cycle_SpyDataViewer.RawDataGridVisible = TSMI_CyclePlayer_Data_Raw.Checked;
			TSMI_CyclePlayer_Data_Eng.Checked = Cycle_SpyDataViewer.EngDataGridVisible;
		}
		
		#endregion
		
		private void TSMI_CyclePlayer_GraphClick(object sender, EventArgs e)
		{
			TSMI_CyclePlayer_Graph.Checked = !TSMI_CyclePlayer_Graph.Checked;
			Split_Cycle_VirtualSig_Graph.Panel2Collapsed = !TSMI_CyclePlayer_Graph.Checked;
			TSMI_CyclePlayer_Data.Checked = !Split_Cycle_VirtualSig_Graph.Panel1Collapsed;
		}
		
		#endregion
		
		private void TSMI_ResetLayoutClick(object sender, EventArgs e)
		{
			ResetControllerLayout();
		}
		
		#endregion
		
		#endregion
		
		#region Spy control
		
		private void Cmd_StartSpyClick(object sender, EventArgs e)
		{
			StartSpy();
			StartManualControl();
		}
		
		private void Cmd_StopSpyClick(object sender, EventArgs e)
		{
			StopSpy();
			StopManualControl();
		}
		
		private void Cmb_SpyCANRateSelectedIndexChanged(object sender, EventArgs e)
		{
			switch(Cmb_SpyCANRate.SelectedIndex)
        	{
        		case 0: //500 kBit/s
        			m_Baudrate= TPCANBaudrate.PCAN_BAUD_500K;
        			break;
        		case 1: //1000 kBit/s
        			m_Baudrate= TPCANBaudrate.PCAN_BAUD_1M;
        			break;
        	}
		}
		
		private void Cmb_SpyCANRxModeSelectedIndexChanged(object sender, EventArgs e)
		{
			SpyMsgRxMode = (SpyCANRxMode)Enum.Parse(typeof(SpyCANRxMode), Cmb_SpyCANRxMode.Text);
			
			switch (SpyMsgRxMode)
			{
				case SpyCANRxMode.Manual:
					
					SpyRxPeriod=0;
					break;
					
				case SpyCANRxMode.Event:
					
					SpyRxPeriod=0;
					break;
					
				case SpyCANRxMode.Periodic_1ms:
					
					SpyRxPeriod=1;
					break;
					
				case SpyCANRxMode.Periodic_2ms:
					
					SpyRxPeriod=2;
					break;
					
				case SpyCANRxMode.Periodic_5ms:
					
					SpyRxPeriod=5;
					break;
					
				case SpyCANRxMode.Periodic_10ms:
					
					SpyRxPeriod=10;
					break;
					
				case SpyCANRxMode.Periodic_20ms:
					
					SpyRxPeriod=20;
					break;
					
				case SpyCANRxMode.Periodic_50ms:
					
					SpyRxPeriod=50;
					break;
					
				case SpyCANRxMode.Periodic_100ms:
					
					SpyRxPeriod=100;
					break;
					
				case SpyCANRxMode.Periodic_200ms:
					
					SpyRxPeriod=200;
					break;
					
				case SpyCANRxMode.Periodic_500ms:
					
					SpyRxPeriod=500;
					break;
					
				case SpyCANRxMode.Periodic_1sec:
					
					SpyRxPeriod=1000;
					break;
			}
		}
		
		#region Manual_SpyDataViewer
		
		private void Manual_SpyDataViewerEngGridColumnsVisibleChanged(object sender, EngGridColVisibleChangedEventArgs e)
		{
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_SpyEng, e.ColumnsVisible);
		}
		
		private void Manual_SpyDataViewerRawGridColumnsVisibleChanged(object sender, RawGridColVisibleChangedEventArgs e)
		{
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_SpyRaw, e.ColumnsVisible);
		}
		
		#endregion
		
		#region Spy graph panel
		
		private void ChkLst_ChannelSelItemCheck(object sender, ItemCheckEventArgs e)
		{
			SpyGraphSeries.SetSerieVisible(ChkLst_ChannelSel.Items[e.Index].ToString(),e.NewValue.Equals(CheckState.Checked));
			
			if(!bSpyRunning)
			{
				Update_SpyGraph();
			}
		}
		
		private void Cmd_GraphSpyRecClick(object sender, EventArgs e)
		{
			bSpyGraphEnabled=!bSpyGraphEnabled;	
			
			if(bSpyGraphEnabled)
			{
				Cmd_GraphSpyRec.ImageIndex=0;
				SpyGraphRestarted=true;
			}
			else
			{
				Cmd_GraphSpyRec.ImageIndex=1;
				SpyGraphSeries.RTSeries.Clear();
			}
			
			Cmd_GraphSpyPause.Enabled=bSpyGraphEnabled;
		}
		
		private void Cmd_GraphSpyPauseClick(object sender, EventArgs e)
		{
			bSpyGraphFrozen=!bSpyGraphFrozen;
			
			if(bSpyGraphFrozen)
			{
				Cmd_GraphSpyPause.ImageIndex=1;
			}
			else
			{
				Cmd_GraphSpyPause.ImageIndex=0;
			}
		}
		
		private void Txt_SpyGraphYMinKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode.Equals(Keys.Enter))
			{
				double Val=0;
				if(Double.TryParse(Txt_SpyGraphYMin.Text,out Val))
				{
					SpyGraphYMin=Val;
					
					if(!(Txt_SpyGraphYMax.Text.Equals("")))
					{
						Update_SpyGraph();						
					}
				}
			}
		}
		
		private void Txt_SpyGraphYMaxKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode.Equals(Keys.Enter))
			{
				double Val=0;
				if(Double.TryParse(Txt_SpyGraphYMax.Text,out Val))
				{
					SpyGraphYMax=Val;
					
					if(!(Txt_SpyGraphYMin.Text.Equals("")))
					{
						Update_SpyGraph();
					}
				}
			}
		}
		
		private void Txt_SpyGraphTimeWindowKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode.Equals(Keys.Enter))
			{
				double Val=0;
				if(Double.TryParse(Txt_SpyGraphTimeWindow.Text,out Val))
				{
					bSpyGraphEnabled=false;
					
					SpyGraphSeries.RTSeries.Clear();
					SpyGraphSeries.BufferSize=(int)((Val*1000)/SPY_GRID_UPDATE_PERIOD);
					
					SpyGraphRestarted=true;
					bSpyGraphEnabled=true;
				}
			}
		}
		
		private void Chk_SpyGraphAutoScaleCheckedChanged(object sender, EventArgs e)
		{
			Txt_SpyGraphYMin.Enabled=!Chk_SpyGraphAutoScale.Checked;
			Txt_SpyGraphYMax.Enabled=!Chk_SpyGraphAutoScale.Checked;
			SpyGraphAutoScale=Chk_SpyGraphAutoScale.Checked;
			Update_SpyGraph();
		}
		
		#endregion

        #region Spy data history panel

        #region TS_SpyDataHistory

        private void TSB_FreezeHistory_Click(object sender, EventArgs e)
        {
            FreezeSpyDataHistory();
        }

        private void TSB_ResumeHistory_Click(object sender, EventArgs e)
        {
            ResumeSpyDataHistory();
        }

        private void TSB_ClearHistory_Click(object sender, EventArgs e)
        {
            ClearSpyDataHistory();
        }

        private void TSB_ExportHistory_Click(object sender, EventArgs e)
        {
            ExprtSpyDataHistory();
        }

        private void TSTxt_IdFilterFrom_TextChanged(object sender, EventArgs e)
        {
            CheckIdFilter(TSTxt_IdFilterFrom);
        }

        private void TSTxt_IdFilterTo_TextChanged(object sender, EventArgs e)
        {
            CheckIdFilter(TSTxt_IdFilterTo);
        }

        #endregion

        #endregion

        #region Context_SpyGraphChannels

        private void CheckAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			for(int i=0;i<ChkLst_ChannelSel.Items.Count;i++)
			{
				ChkLst_ChannelSel.SetItemChecked(i,true);
			}
		}
		
		private void UncheckAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			for(int i=0;i<ChkLst_ChannelSel.Items.Count;i++)
			{
				ChkLst_ChannelSel.SetItemChecked(i,false);
			}
		}	
		
		private void Context_SpyGraph_Filter_TSCmbKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Enter))
			{
				if (!(Context_SpyGraph_Filter_TSCmb.Text.Equals("")))
				{
					if (!(Context_SpyGraph_Filter_TSCmb.Items.Contains(Context_SpyGraph_Filter_TSCmb.Text)))
					{
						//FIFO
						if (Context_SpyGraph_Filter_TSCmb.Items.Count == 10)
						{
							Context_SpyGraph_Filter_TSCmb.Items.RemoveAt(9);
						}
						
						Context_SpyGraph_Filter_TSCmb.Items.Insert(0, ManualGrid_Filter_Combo_TSMI.Text);
					}
				}
				
				ChkLst_ChannelSel.Tag = Context_SpyGraph_Filter_TSCmb.Text;
				FilterSpyGraphSeries();
			}
		}
		
		private void Context_SpyGraph_Filter_TSCmbSelectedIndexChanged(object sender, EventArgs e)
		{
			ChkLst_ChannelSel.Tag = Context_SpyGraph_Filter_TSCmb.Text;
			FilterSpyGraphSeries();
		}
		
		#endregion
		
		#region BGWrk_Spy
        
        private void BGWrk_SpyDoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker Worker=sender as BackgroundWorker;
			RunSpy(Worker);
		}
		
		private void BGWrk_SpyProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			DisplayMessages();
		}
		
		private void BGWrk_SpyRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			
		}
        
        #endregion
        
        #region Record trigger
        
        private void RecordTrigger_TriggerStatusChanged(object sender, TriggerChangedEventArg e)
        {
        	if (RecordMode.Equals(RecordingMode.Trigger))
        	{
        		if (e.Status)
        		{
        			StartRecording();
        		}
        		else
        		{
        			StopRecording();
        		}
        	}
        }
        
        #endregion
		
		#endregion
		
		#region Manual control
		
		private void Chk_VirtualParamTxEnabledCheckedChanged(object sender, EventArgs e)
		{
			bVirtualParamTx = Chk_VirtualParamTxEnabled.Checked;
			
			if (Grid_CANData.Rows.Count > 0)
			{
				for (int iRow = 0; iRow < Grid_CANData.Rows.Count; iRow++)
				{
					if (Grid_CANData.Rows[iRow].Cells[GRID_MANUAL_VALUE_COL].ReadOnly) //If cell 'Value' of a vitual parameter is read-only
					{
						Grid_CANData.Rows[iRow].Visible = bVirtualParamTx;
					}
				}
			}
		}
		
		#region Context_ManualGrid
		
		private void HideRowToolStripMenuItemClick(object sender, EventArgs e)
		{
			HideActiveRow();
		}
		
		private void ShowHiddenRowsToolStripMenuItemClick(object sender, EventArgs e)
		{
			ShowHiddenRows();
		}
		
		private void ManualGrid_Filter_Combo_TSMIKeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Enter))
			{
				if (!(ManualGrid_Filter_Combo_TSMI.Text.Equals("")))
				{
					if (!(ManualGrid_Filter_Combo_TSMI.Items.Contains(ManualGrid_Filter_Combo_TSMI.Text)))
					{
						//FIFO
						if (ManualGrid_Filter_Combo_TSMI.Items.Count == 10)
						{
							ManualGrid_Filter_Combo_TSMI.Items.RemoveAt(9);
						}
						
						ManualGrid_Filter_Combo_TSMI.Items.Insert(0, ManualGrid_Filter_Combo_TSMI.Text);
					}
				}
				
				FilterManualCanConfig(ManualGrid_Filter_Combo_TSMI.Text);
			}
		}
		
		private void ManualGrid_Filter_Combo_TSMISelectedIndexChanged(object sender, EventArgs e)
		{
			FilterManualCanConfig(ManualGrid_Filter_Combo_TSMI.Text);
		}
		
		#region Columns
		
		private void Context_Manual_showAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			Set_ManualGridColumnsVisible(Manual_Grid_Columns.All);
		}
		
		private void Context_Manual_hideAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			Set_ManualGridColumnsVisible(Manual_Grid_Columns.None);
		}
		
		private void Context_Manual_iDToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_iDToolStripMenuItem.Checked = !Context_Manual_iDToolStripMenuItem.Checked;
			
			if (Context_Manual_iDToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_ID);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_ID));
			}			
		}
		
		private void Context_Manual_rxTxToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_rxTxToolStripMenuItem.Checked = !Context_Manual_rxTxToolStripMenuItem.Checked;
			
			if (Context_Manual_rxTxToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_RxTx);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_RxTx));
			}
		}
		
		private void Context_Manual_periodToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_periodToolStripMenuItem.Checked = !Context_Manual_periodToolStripMenuItem.Checked;
			
			if (Context_Manual_periodToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Period);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Period));
			}
		}
		
		private void Context_Manual_muxValueToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_muxValueToolStripMenuItem.Checked = !Context_Manual_muxValueToolStripMenuItem.Checked;
			
			if (Context_Manual_muxValueToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_MuxValue);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_MuxValue));
			}
		}
		
		private void Context_Manual_startToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_startToolStripMenuItem.Checked = !Context_Manual_startToolStripMenuItem.Checked;
			
			if (Context_Manual_startToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Start);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Start));
			}
		}
		
		private void Context_Manual_lengthToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_lengthToolStripMenuItem.Checked = !Context_Manual_lengthToolStripMenuItem.Checked;
			
			if (Context_Manual_lengthToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Length);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Length));
			}
		}
		
		private void Context_Manual_endianessToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_endianessToolStripMenuItem.Checked = !Context_Manual_endianessToolStripMenuItem.Checked;
			
			if (Context_Manual_endianessToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Endianess);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Endianess));
			}
		}
		
		private void Context_Manual_signedToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_signedToolStripMenuItem.Checked = !Context_Manual_signedToolStripMenuItem.Checked;
			
			if (Context_Manual_signedToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Signedness);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Signedness));
			}
		}
		
		private void Context_Manual_gainToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_gainToolStripMenuItem.Checked = !Context_Manual_gainToolStripMenuItem.Checked;
			
			if (Context_Manual_gainToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Gain);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Gain));
			}
		}
		
		private void Context_Manual_zeroToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_zeroToolStripMenuItem.Checked = !Context_Manual_zeroToolStripMenuItem.Checked;
			
			if (Context_Manual_zeroToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Zero);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Zero));
			}
		}
		
		private void Context_Manual_unitToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_unitToolStripMenuItem.Checked = !Context_Manual_unitToolStripMenuItem.Checked;
			
			if (Context_Manual_unitToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Unit);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Unit));
			}
		}
		
		private void Context_Manual_commentToolStripMenuItemClick(object sender, EventArgs e)
		{
			Context_Manual_commentToolStripMenuItem.Checked = !Context_Manual_commentToolStripMenuItem.Checked;
			
			if (Context_Manual_commentToolStripMenuItem.Checked)
			{
				Set_ManualGridColumnsVisible(ManualGridColumnsVisible | Manual_Grid_Columns.Column_Comment);
			}
			else
			{
				Set_ManualGridColumnsVisible((Manual_Grid_Columns)(ManualGridColumnsVisible - Manual_Grid_Columns.Column_Comment));
			}
		}
		
		#endregion
		
		#endregion
		
		#region Context_ManualRawGrid
		
		private void Ctxt_TxRaw_Add_TSMIClick(object sender, EventArgs e)
		{
			Add_RawMessage();
		}
		
		private void Ctxt_TxRaw_Del_TSMIClick(object sender, EventArgs e)
		{
			Del_RawMessage();
		}
		
		private void Ctxt_TxRaw_Clear_TSMIClick(object sender, EventArgs e)
		{
			Clear_RawMessages();
		}
		
		private void Ctxt_TxRaw_Save_TSMIClick(object sender, EventArgs e)
		{
			Save_RawMessages();
		}
		
		private void Ctxt_TxRaw_Open_TSMIClick(object sender, EventArgs e)
		{
			Open_RawMessages();
		}
		
		#endregion
		
		#region DataGrid Manual CAN Config
        
        private void Grid_CANDataCellEndEdit(object sender, DataGridViewCellEventArgs e)
		{
        	UpdateManualControlMessagesData();
		}
        
        private void Grid_CANDataSizeChanged(object sender, EventArgs e)
		{
        	ResizeGridColumns(Grid_CANData, GRID_ENG_MANUAL_FILLER_COL);
		}
        
        #endregion
		
        #region Grid_CANRawData
        
        private void Grid_CANRawDataCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{
			if (!((e.RowIndex == -1) || bRawMsgGridEdition))
			{
				string sTmp = Grid_CANRawData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
				
				if (!(sTmp.Equals("")))
				{
					bRawMsgGridEdition = true;
					
					#region Data validation
					
					switch (e.ColumnIndex)
					{
						case 0: //ID
							
							try
							{
								UInt32 iTmp = UInt32.Parse(sTmp, NumberStyles.HexNumber);
								
								if (iTmp >= 0 && iTmp <= 0x7FF)
								{
									Grid_CANRawData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:x3}", iTmp).ToUpper();
								}
								else
								{
									MessageBox.Show("ID value must be contained between 0x00 and 0x7FF !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		        					goto End;
								}
							}
							catch
							{
								MessageBox.Show("Invalid ID value format !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	        					goto End;
							}
							
							break;
							
						case 1: //DLC
							
							try
							{
								int iTmp = int.Parse(sTmp);
								
								if (iTmp < 0 || iTmp > 8)
		        				{
		        					MessageBox.Show("DLC value must be contained between 1 and 8 !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		        					goto End;
		        				}
							}
							catch
							{
								MessageBox.Show("Invalid DLC value format !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		        				goto End;
							}
							
							break;
							
						case 2: //Period
							
							try
		        			{
		        				int iTmp = int.Parse(sTmp);
		        				
		        				if (iTmp == 0)
		        				{
		        					Grid_CANRawData.Rows[e.RowIndex].Cells[GRID_RAW_COL_TX_BTN].Value = "Tx";
		        				}
		        				else
		        				{
		        					Grid_CANRawData.Rows[e.RowIndex].Cells[GRID_RAW_COL_TX_BTN].Value = "";
		        				}
		        			}
		        			catch
		        			{
		        				MessageBox.Show("Invalid period value format !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		        				goto End;
		        			}
							
							break;
							
						case 3: //Sent
							
							break;
						
						case 4: //Tx button
							
							break;
							
						default: //Values
							
							try
							{
								byte iTmp = byte.Parse(sTmp, NumberStyles.HexNumber);
		        				Grid_CANRawData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:x2}", iTmp).ToUpper();
							}
							catch
							{
								MessageBox.Show("Invalid byte value format !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								Grid_CANRawData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:x2}", 0).ToUpper();
		        				goto End;
							}
							
							break;
					}
					
					#endregion
					
					Set_RawMessageFromGridRow(e.RowIndex);
		
		End:
					bRawMsgGridEdition = false;
				}
			}
		}
        
        private void Grid_CANRawDataSizeChanged(object sender, EventArgs e)
		{
        	ResizeGridColumns(Grid_CANRawData, GRID_RAW_MANUAL_FILLER_COL);
		}
        
        private void Grid_CANRawDataCellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (!((e.RowIndex == -1) || bRawMsgGridEdition))
			{
				if (e.ColumnIndex == GRID_RAW_COL_TX_BTN)
				{
					User_RawMessage_Tx(e.RowIndex);
				}
			}
		}

        private void Grid_CANRawData_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                bRawMsgSending = true;

                if (Grid_CANRawData.SelectedCells.Count > 0)
                {
                    int iRow = Grid_CANRawData.SelectedCells[0].RowIndex;

                    if (iRow >= 0)
                    {
                        if (Grid_CANRawData.Rows[iRow].Cells[GRID_RAW_COL_TX_PERIOD].Value.Equals("0"))
                        {
                            User_RawMessage_Tx(iRow);
                        }
                    }
                }
            }
        }

        private void Grid_CANRawData_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            if (bRawMsgSending)
            {
                e.Cancel = true;
                bRawMsgSending = false;
            }
        }

        #endregion
        
        #region Manual BackgroundWorker
        
        private void BGWrk_ManualDoWork(object sender, DoWorkEventArgs e)
		{
			BackgroundWorker Worker=sender as BackgroundWorker;
			RunManualControl(Worker,e);
		}
		
		private void BGWrk_ManualProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			SentMsgCounter += e.ProgressPercentage;
			Txt_MsgCounter.Text = SentMsgCounter.ToString();

            if (TxEngMessages != null)
            {
                foreach (CANMessageEncoded oMsgEncod in TxEngMessages)
                {
                    if (oMsgEncod.HasVirtualParameters)
                    {
                        foreach (CANParameter oParam in oMsgEncod.Parameters)
                        {
                            if (oParam.IsVirtual)
                            {
                                if (int.Parse(tabControl1.SelectedTab.Tag.ToString()) == 1)
                                {
                                    int iRow = GetParameterRowIndex(oParam.Name);

                                    if (iRow != -1)
                                    {
                                        Grid_CANData.Rows[iRow].Cells[GRID_MANUAL_VALUE_COL].Value = oParam.DecodedValue.ToString();
                                    }
                                }
                                else
                                {
                                    Set_CycleVirtualSignalValue(oParam.Name, oParam.DecodedValue.ToString(), oParam.VirtualChannelReference);
                                }
                            }
                        }
                    }
                }
            }
		}
        
        #endregion
        
		#endregion
		
		#region Cycle control
		
		private void Cmd_PlayCycleClick(object sender, EventArgs e)
		{
			Txt_CurrentCycleNum.Text="1";
        	PlayCycle();
        	StartSpy();
        	StartManualControl();
		}
		
		private void Cmd_BreakCycleClick(object sender, EventArgs e)
		{
			bPauseCycle=true;
        	StopCycle();
        	
        	iLoopInitial=iLoopCurrent;
        	iTimeEventInitial=iTimeEventCurrent;
		}
		
		private void Cmd_StopCycleClick(object sender, EventArgs e)
		{
			bPauseCycle=false;
        	StopCycle();
        	StopSpy();
        	StopManualControl();
        	
        	iLoopInitial=0;
			iTimeEventInitial=0;
		}
		
		private void Chk_InfinitePlayCheckedChanged(object sender, EventArgs e)
		{
			Lbl_CycleCount.Enabled = !Chk_InfinitePlay.Checked;
			NumUpDown_CycleCount.Enabled = !Chk_InfinitePlay.Checked;
		}
		
		private void Txt_CycleStartTextChanged(object sender, EventArgs e)
		{
			if (!bCycleStartEndTxtSetting)
        	{
        		Set_CycleStartEndCursorsFromTextBox();
        	}
		}
		
		private void Txt_CycleEndTextChanged(object sender, EventArgs e)
		{
			if (!bCycleStartEndTxtSetting)
        	{
        		Set_CycleStartEndCursorsFromTextBox();
        	}
		}
		
		private void Timer_CycleGraphTick(object sender, EventArgs e)
		{
			double TimeCurrent  = ((double)TimeInCycle ) / 1000;
        	double dTStartCycle = ((double) TCycleStart) / 1000;
        	double dTEndCycle   = ((double) TCycleEnd  ) / 1000;
        		
        	PlotCycle(true, TimeCurrent, dTStartCycle, dTEndCycle);
		}
		
		private void Chk_CycleVirtualParamTxEnabledCheckedChanged(object sender, EventArgs e)
		{
			bVirtualParamTx = Chk_CycleVirtualParamTxEnabled.Checked;
		}
		
		#region Cycle_SpyDataViewer
		
		private void Cycle_SpyDataViewerEngGridColumnsVisibleChanged(object sender, EngGridColVisibleChangedEventArgs e)
		{
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_Cycle_Eng, e.ColumnsVisible);
		}
		
		private void Cycle_SpyDataViewerRawGridColumnsVisibleChanged(object sender, RawGridColVisibleChangedEventArgs e)
		{
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_Cycle_Raw, e.ColumnsVisible);
		}
		
		#endregion
		
		#region Context_CycleGraph
        
        private void Context_CycleGraphItemSetStart_Click(object sender, EventArgs e)
        {
        	Set_CycleStartingPoint();
        }
        
        private void Context_CycleGraphItemSetEnd_Click(object sender, EventArgs e)
        {
        	Set_CycleEndingPoint();
        }
        
        private void Context_CycleGraphItemSetConfirm_Click(object sender, EventArgs e)
        {
        	Confirm_CycleStartEndPoints();
        }
        
        private void Context_CycleGraphItemSetCancel_Click(object sender, EventArgs e)
        {
        	Cancel_CycleStartEndPoints();
        }
        
        private void Context_CycleGraphMenuItem_Click(object sender, EventArgs e)
        {
        	ToolStripMenuItem Item = (ToolStripMenuItem) sender;
        	Item.Checked=!Item.Checked;
        	
        	oCycle.GraphSeries.SetFormatedSerieVisible(Item.Text,Item.Checked);
        	
        	PlotCycle();
        }
        
        #endregion
		
        #region Graph_Cycle
        
        private void Graph_CycleMouseClick(object sender, MouseEventArgs e)
		{
        	//Cycle starting point setting
        	if (bCycleStartSet)
        	{
        		double dStartPos = GetTimeValueAtPosition(e.Location.X);
        		
        		double dEndPos = 0;
        		if (!(double.TryParse(Txt_CycleEnd.Text, out dEndPos)))
        		{
        			dEndPos = (double)(oCycle.TimeEvents[oCycle.TimeEvents.Count - 1].TimeEvent) / 1000;
        		}
        		
        		if (dStartPos < dEndPos)
        		{
        			bCycleStartEndTxtSetting = true;
        			Txt_CycleStart.Text = Math.Round(dStartPos, 3).ToString();
        			bCycleStartEndTxtSetting = false;
        			
        			PlotCycle(true, -1, dStartPos, dEndPos);
        		}
        	}
        	
        	//Cycle ending point setting
        	if (bCycleEndSet)
        	{
        		double dEndPos = GetTimeValueAtPosition(e.Location.X);
        		
        		double dStartPos = 0;
        		if (!(double.TryParse(Txt_CycleStart.Text, out dStartPos)))
        		{
        			dStartPos = (double)(oCycle.TimeEvents[0].TimeEvent) / 1000;
        		}
        		
        		if (dStartPos < dEndPos)
        		{
        			bCycleStartEndTxtSetting = true;
        			Txt_CycleEnd.Text = Math.Round(dEndPos, 3).ToString();
        			bCycleStartEndTxtSetting = false;
        			
        			PlotCycle(true, -1, dStartPos, dEndPos);
        		}
        	}
		}
        
        private void Graph_CyclePreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
		{
        	if (bCycleStartSet | bCycleEndSet) //Start/end points setting ?
        	{
        		switch (e.KeyCode) //Confirm or cancel ?
        		{
        			case Keys.Enter: //Confirm
        				
        				Confirm_CycleStartEndPoints();
        				break;
        				
        			case Keys.Escape: //Cancel
        				
        				Cancel_CycleStartEndPoints();
        				break;
        		}
        	}
		}
        
        private void Split_Cycle_VirtualSig_GraphSplitterMoved(object sender, SplitterEventArgs e)
		{
        	if (!(oCycle == null)) PlotCycle();
		}
        
        #endregion
        
        #region Cycle BackgroundWorker
        
        private void BGWrk_CycleDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker Worker=sender as BackgroundWorker;
			
			if (e.Argument.GetType().Equals(typeof(bool)))
			{
				RunCycle(2,true,Worker,e);
			}
			else
			{
				RunCycle((int)e.Argument,false,Worker,e);
			}
			
			//RunCycle((int)e.Argument,Worker,e);
		}
        
        private void BGWrk_CycleRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
        	//Timer for graphic update disabling
        	Timer_CycleGraph.Enabled = false;
        	
        	if(!bPauseCycle)
        	{
	        	iLoopInitial=0;
				iLoopCurrent=0;
				LoopCnt = 0;
	        	iTimeEventInitial=0;
	        	iTimeEventCurrent=0;
				
	        	Lbl_CurrentCycleNum.Visible=false;
				Txt_CurrentCycleNum.Text="";
	    		Txt_CurrentCycleNum.Visible=false;
	    		Lbl_CurrentProgress.Visible=false;
	    		Lbl_TotalProgress.Visible=false;
	    		PB_CurrentProgress.Visible=false;
	    		PB_CurrentProgress.Value = 0;
	    		PB_TotalProgress.Visible=false;
	    		PB_TotalProgress.Value = 0;
	    		
	    		Cmd_BreakCycle.Enabled=false;
	    		Cmd_StopCycle.Enabled=false;
	    		
	    		Cmd_PlayCycle.Enabled=true;
	    		Lbl_CycleStart.Enabled = true;
        		Lbl_CycleEnd.Enabled = true;
        		Txt_CycleStart.Enabled = true;
        		Txt_CycleEnd.Enabled = true;
	    		Chk_InfinitePlay.Enabled = true;
	    		
	    		if (!Chk_InfinitePlay.Checked)
	    		{
	    			Lbl_CycleCount.Enabled=true;
	    			NumUpDown_CycleCount.Enabled=true;
	    		}
	    			    		
	    		bCycleRunning=false;
	    		
	    		StopManualControl();
	    		StopSpy();
	    		
	    		FireControllerCycleRunningChangedEvent(bCycleRunning);
	    		
	    		//Automatic trace recording //HACK: Remove [acquisition trigger]
        		if(bRecordingAuto & bRecording)
        		{
        			StopRecording();
        		}
        		
        		double dTStartCycle = ((double) TCycleStart) / 1000;
        		double dTEndCycle   = ((double) TCycleEnd  ) / 1000;
        		
        		PlotCycle(true, -1, dTStartCycle, dTEndCycle);
        	}
		}
        
        private void BGWrk_CycleProgressChanged(object sender, ProgressChangedEventArgs e)
		{
        	int CurrentProgress = 0;
        	
        	if (Chk_InfinitePlay.Checked)
        	{
        		CurrentProgress = e.ProgressPercentage;
        	}
        	else
        	{
        		CurrentProgress = e.ProgressPercentage*(int)NumUpDown_CycleCount.Value;
        	}
        	
        	while(CurrentProgress>100)
        	{
				CurrentProgress=CurrentProgress-100;        		
        	}
        	
        	if(CurrentProgress<PB_CurrentProgress.Value)
        	{
        		LoopCnt++;
        		Txt_CurrentCycleNum.Text = (LoopCnt +1).ToString();
        	}
        	
        	PB_CurrentProgress.Value = CurrentProgress;
        	PB_TotalProgress.Value   = e.ProgressPercentage;
		}
        
        #endregion
        
		#endregion
				
		#region TabControl
        
        private void TabControl1SelectedIndexChanged(object sender, EventArgs e)
		{
        	if(bCANConnected)
        	{
        		ReleaseCANCommunication(); //If CAN Com running, end of communication
        	}
        	
        	int iTabTag = Convert.ToInt16(tabControl1.SelectedTab.Tag);
        	ControllerActiveMode = iTabTag;
        	
        	switch (iTabTag)
        	{
        		case 1: //Spy & Manual
        								
					if (!(ManualCanConfigFilePath.Equals("")))
					{
						if (oCanConfig.ReadCANConfigurationFile(ManualCanConfigFilePath))
						{
							UpDateCANConfig(oCanConfig);
						}
					}
					else
					{
						ResetManualSpyGrids();
						FireCanConfigChangedEvent(false);
					}
        			
					TSMI_SpyManual.Enabled = true;
					TSMI_CyclePlayer.Enabled = false;
					
					bVirtualParamTx = Chk_VirtualParamTxEnabled.Checked;
					CurrentSpyViewer = Manual_SpyDataViewer;
					
        			break;
        			
        		case 2: //Cycle
        								
					//Loading of cycle CAN config if known
					if (!(oCycle == null))
					{
						if (!(oCycle.oCanNodesMap == null))
						{
							UpDateCANConfig(oCycle.oCanNodesMap);
						}
					}
					
					TSMI_SpyManual.Enabled = false;
					TSMI_CyclePlayer.Enabled = true;
					
					bVirtualParamTx = Chk_CycleVirtualParamTxEnabled.Checked;
					CurrentSpyViewer = Cycle_SpyDataViewer;
					
        			break;
        	}
        	        	
        	//ControllerModeChanged event firing
        	ControllerModeChangedEventArgs Args = new ControllerModeChangedEventArgs();
        	Args.CurrentMode = iTabTag;
        	OnControllerModeChanged(Args);
		}
        
        private void TabControl1Deselecting(object sender, TabControlCancelEventArgs e)
		{
        	if(bCycleRunning|bManualRunning|bSpyRunning)
        	{
        		e.Cancel=true;
        	}
		}
        
        #endregion
		
		#endregion
		
		#region Private methodes
		
		#region CAN Com management
        
        private bool UpDateCANConfig(CANMessagesConfiguration oNewCanConf)
        {
        	if (!(oNewCanConf == null))
        	{
        		oCanConfig = oNewCanConf;
        		
        		SetActiveCANConfig();
        		ShowManualCanConfig();
        		
        	}
        	else
        	{
        		FireCanConfigChangedEvent(false);
        		return(false);
        	}
        	
        	return(true);
        }
		
        private void SetActiveCANConfig()
        {
        	if(bCANConnected) //Release CAN Communiction if already established
    		{
    			ReleaseCANCommunication();
    		}
    		
    		if(oCanConfig.CanRate==1000)
			{
				m_Baudrate= TPCANBaudrate.PCAN_BAUD_1M;
			}
			else if(oCanConfig.CanRate==500)
			{
				m_Baudrate= TPCANBaudrate.PCAN_BAUD_500K;
			}
			else //Default
			{
				m_Baudrate= TPCANBaudrate.PCAN_BAUD_1M;
			}
			
			//CAN Communiction init
			if(!(m_PcanHandle==0))
			{
				InitCANCommunication();
			}
        }
        
		private void RefreshCANUSBDevicesList()
		{
			TS_Cmb_PCAN_USB_Devices.Items.Clear();
			
			UInt32 iBuffer;
			TPCANStatus stsResult;
			
			TS_Cmb_PCAN_USB_Devices.Enabled=true;
			
			try
			{
				for(int i=0;i<m_HandlesArray.Length;i++)
				{
					// Checks for a Plug&Play Handle and, according with the return value, includes it
					// into the list of available hardware channels.
					//
					stsResult = PCANBasic.GetValue(m_HandlesArray[i], TPCANParameter.PCAN_CHANNEL_CONDITION, out iBuffer, sizeof(UInt32));
					if ((stsResult == TPCANStatus.PCAN_ERROR_OK) && (iBuffer == PCANBasic.PCAN_CHANNEL_AVAILABLE))
					{
						TS_Cmb_PCAN_USB_Devices.Items.Add(FormatChannelName(m_HandlesArray[i]));
					}
				}
			}
			catch(DllNotFoundException)
			{
				MessageBox.Show("Unable to find the library: PCANBasic.dll !","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
				return;
			}
			
			if(TS_Cmb_PCAN_USB_Devices.Items.Count==0)
			{
				TS_Cmb_PCAN_USB_Devices.Enabled=false;
				MessageBox.Show("No PCAN USB device found !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else
			{
				if(TS_Cmb_PCAN_USB_Devices.Items.Count==1)
				{
					TS_Cmb_PCAN_USB_Devices.SelectedIndex=0;
				}
			}
		}
		
		private void CheckActiveCANUSBDevice()
		{
			UInt32 iBuffer;
			TPCANStatus stsResult;
			
			if(!(TS_Cmb_PCAN_USB_Devices.Text.Equals("")))
			{
				TPCANHandle Handle=GetChannelHandle(TS_Cmb_PCAN_USB_Devices.Text);
				
				if(!(Handle==0))
				{
					stsResult = PCANBasic.GetValue(Handle, TPCANParameter.PCAN_5VOLTS_POWER, out iBuffer, sizeof(UInt32));
					if ((stsResult == TPCANStatus.PCAN_ERROR_ILLHW))
					{
						FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
						ReleaseCANCommunication();
						RefreshCANUSBDevicesList();
					}
				}
			}
		}
		
		private void ReleaseCANCommunication()
		{
			PCANBasic.Uninitialize(m_PcanHandle);
			bCANConnected=false;
			Timer_CheckDevice.Enabled=false;
			UpDateConnectionStatus();
		}
		
		private void UpDateConnectionStatus()
		{
			TSB_CAN_LinkOff.Visible=!bCANConnected;
			TSB_CAN_LinkOn.Visible=bCANConnected;
			TSB_Refresh_USB_CAN_Device.Enabled=!bCANConnected;
			TS_Cmb_PCAN_USB_Devices.Enabled=!bCANConnected;
			TSB_StartCANTraceRecording.Enabled=bCANConnected;
						
			ControllerConnectionStatusChangedEventArgs Args = new ControllerConnectionStatusChangedEventArgs();
			Args.Connected = bCANConnected;
			OnControllerConnectionStatusChanged(Args);
				
			if(bCANConnected)
			{
				//Toolstrip infos
				TS_Lbl_CanSpeed.Enabled=true;
				
				if(!(oCanConfig==null)) // CAN speed defined within the CAN Configuration
				{
					TS_Lbl_CanSpeed.Text="CAN Baud rate: " + oCanConfig.CanRate.ToString() + " kBit/s";
				}
				else // CAN speed defined manually in the spy tab control
				{
					TS_Lbl_CanSpeed.Text="CAN Baud rate: "+Cmb_SpyCANRate.Text;
				}
				
				//Cycle control panel
				if(oCycle!=null)
				{
					Cmd_PlayCycle.Enabled=true;
					Lbl_CycleCount.Enabled=true;
					NumUpDown_CycleCount.Enabled=true;
					Chk_InfinitePlay.Enabled=true;
					Lbl_CycleStart.Enabled = true;
					Lbl_CycleEnd.Enabled = true;
					Txt_CycleStart.Enabled = true;
					Txt_CycleEnd.Enabled = true;
					Chk_CycleVirtualParamTxEnabled.Enabled = true;
					Chk_CycleVirtualParamTxEnabled.Checked = true;
				}
				
				//Spy & Manual control panel
				Cmd_StartSpy.Enabled=true;
			}
			else
			{
				//Toolstrip infos
				TS_Lbl_CanSpeed.Text="CAN Baud rate:";
				TS_Lbl_CanSpeed.Enabled=false;
				
				//Cycle control panel
				Cmd_PlayCycle.Enabled=false;
				Cmd_BreakCycle.Enabled=false;
				Cmd_StopCycle.Enabled=false;
				Lbl_CycleCount.Enabled=false;
				NumUpDown_CycleCount.Enabled=false;
				Chk_InfinitePlay.Enabled=false;
								
				//Spy & Manual control panel
				Cmd_StartSpy.Enabled=false;
				Cmd_StopSpy.Enabled=false;
			}
		}
		
		private void InitCANCommunication()
		{
			TPCANStatus stsResult;

			// Connects a selected PCAN-Basic channel
			stsResult=PCANBasic.Initialize(m_PcanHandle,m_Baudrate);
			
			if (stsResult != TPCANStatus.PCAN_ERROR_OK)
			{
				FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
				MessageBox.Show(GetFormatedError(stsResult),Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			else
			{
				bCANConnected=true;
				Timer_CheckDevice.Enabled=true;
				
				UpDateConnectionStatus();
				
				// Prepares the PCAN-Basic's PCAN-Trace file
				ConfigureTraceFile();
			}
		}
		
		private bool SendMessage(CANMessageData MsgData)
        {
        	TPCANMsg CANMsg;
        	
        	// We create a TPCANMsg message structure 
        	CANMsg = new TPCANMsg();
            
            CANMsg.ID=MsgData.uMessageId;
            CANMsg.LEN=(byte)MsgData.byteMessageData.Length;
            CANMsg.MSGTYPE= TPCANMessageType.PCAN_MESSAGE_STANDARD;
            CANMsg.DATA = MsgData.byteMessageData;
            
            return(SendMessage(CANMsg));            
        }
		
		private bool SendMessage(TPCANMsg CANMsg)
		{
			TPCANStatus stsResult;
			
			stsResult = PCANBasic.Write(m_PcanHandle, ref CANMsg);
            
            if (!(stsResult == TPCANStatus.PCAN_ERROR_OK))
            {
            	FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
            	return(false);
            }
            
            if (HostForm.bDiagActive)
            {
            	FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
            }
            
            return(true);
		}
		
		private void ReadMessagesOnce()
        {
        	TPCANMsg CANMsg;
            TPCANTimestamp CANTimeStamp;
            TPCANStatus stsResult;
            
            // We read at least one time the queue looking for messages.
            // If a message is found, we look again trying to find more.
            // If the queue is empty or an error occurr, we get out from
            // the dowhile statement.
            //			
            do
            {
                // We execute the "Read" function of the PCANBasic                
                //
                stsResult = PCANBasic.Read(m_PcanHandle, out CANMsg, out CANTimeStamp);

                // A message was received
                // We process the message(s)
                //
                if (stsResult == TPCANStatus.PCAN_ERROR_OK)
                {
                	if(CANMsg.ID>=SpyMsgIdFilterMin & CANMsg.ID<=SpyMsgIdFilterMax)
                	{
                		ProcessMessage(CANMsg, CANTimeStamp);
                	}
                	
                	if (HostForm.bDiagActive)
                	{
                		FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
                	}
                }
                else
                {
                	if (!(stsResult.Equals(TPCANStatus.PCAN_ERROR_QRCVEMPTY)))
                	{
                		FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
                	}
                }

            } while (!Convert.ToBoolean(stsResult & TPCANStatus.PCAN_ERROR_QRCVEMPTY));

        }
		
		private void FireCanConfigChangedEvent(bool bConfigLoaded)
		{
			ControllerCANConfigChangedEventArgs Args = new ControllerCANConfigChangedEventArgs();
			Args.ConfigurationLoaded = bConfigLoaded;
			OnControllerCanConfigChanged(Args);
		}
		
		private void FireControllerDiagChangedEvent(TPCANStatus Error, int BusId)
		{
			ControllerDiagChangedEventArgs Args = new ControllerDiagChangedEventArgs();
			Args.Diag = Error;
			Args.BusIndex = BusId;
			OnControllerDiagChanged(Args);
		}
		
		#region PCANBasic functions
		
		/// <summary>
		/// Gets the formated text for a CPAN-Basic channel handle
		/// </summary>
		/// <param name="handle">PCAN-Basic Handle to format</param>
		/// <returns>The formatted text for a channel</returns>
		private string FormatChannelName(TPCANHandle handle)
		{
			TPCANDevice devDevice;
			byte byChannel;

			// Gets the owner device and channel for a
			// PCAN-Basic handle
			//
			devDevice = (TPCANDevice)(handle >> 4);
			byChannel = (byte)(handle & 0xF);

			// Constructs the PCAN-Basic Channel name and return it
			//
			return string.Format("{0} {1} ({2:X2}h)", devDevice, byChannel, handle);
		}
		
		/// <summary>
		/// Gets the CPAN-Basic channel handle from the formated channel handle name
		/// </summary>
		/// <param name="ChannelName">Formated channel handle name</param>
		/// <returns>CPAN-Basic channel handle</returns>
		private TPCANHandle GetChannelHandle(string ChannelName)
		{
			int i=ChannelName.IndexOf("(");
			string Channel=ChannelName.Substring(0,i-1);
			
			if(Channel.Equals("PCAN_USB 1"))
			{
				return(PCANBasic.PCAN_USBBUS1);
			}
			else if(Channel.Equals("PCAN_USB 2"))
			{
				return(PCANBasic.PCAN_USBBUS2);
			}
			else if(Channel.Equals("PCAN_USB 3"))
			{
				return(PCANBasic.PCAN_USBBUS3);
			}
			else if(Channel.Equals("PCAN_USB 4"))
			{
				return(PCANBasic.PCAN_USBBUS4);
			}
			else if(Channel.Equals("PCAN_USB 5"))
			{
				return(PCANBasic.PCAN_USBBUS5);
			}
			else if(Channel.Equals("PCAN_USB 6"))
			{
				return(PCANBasic.PCAN_USBBUS6);
			}
			else if(Channel.Equals("PCAN_USB 7"))
			{
				return(PCANBasic.PCAN_USBBUS7);
			}
			else if(Channel.Equals("PCAN_USB 8"))
			{
				return(PCANBasic.PCAN_USBBUS8);
			}
			
			return(0);
		}
		
		/// <summary>
		/// Help Function used to get an error as text
		/// </summary>
		/// <param name="error">Error code to be translated</param>
		/// <returns>A text with the translated error</returns>
		private string GetFormatedError(TPCANStatus error)
		{
			StringBuilder strTemp;

			// Creates a buffer big enough for a error-text
			//
			strTemp = new StringBuilder(256);
			// Gets the text using the GetErrorText API function
			// If the function success, the translated error is returned. If it fails,
			// a text describing the current error is returned.
			//
			if (PCANBasic.GetErrorText(error, 0, strTemp) != TPCANStatus.PCAN_ERROR_OK)
				return string.Format("An error occurred. Error-code's text ({0:X}) couldn't be retrieved", error);
			else
				return strTemp.ToString();
		}
		
		/// <summary>
		/// Configures the PCAN-Trace file for a PCAN-Basic Channel
		/// </summary>
		private void ConfigureTraceFile()
		{
			UInt32 iBuffer;
			TPCANStatus stsResult;

			// Configure the maximum size of a trace file to 100 megabytes
			//
			iBuffer = 100;
			stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_SIZE, ref iBuffer, sizeof(UInt32));
			if (stsResult != TPCANStatus.PCAN_ERROR_OK)
			{
				MessageBox.Show(GetFormatedError(stsResult),Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			
			// Configure the location of a trace file
			string LogPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			stsResult = PCANBasic.SetValue(m_PcanHandle,TPCANParameter.PCAN_TRACE_LOCATION,LogPath,(uint)LogPath.Length);
			if (stsResult != TPCANStatus.PCAN_ERROR_OK)
			{
				MessageBox.Show(GetFormatedError(stsResult),Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
			
			
			// Configure the way how trace files are created:
			// * Standard name is used
			// * Existing file is ovewritten,
			// * Only one file is created.
			// * Recording stopts when the file size reaches 100 megabytes.
			//
			iBuffer=PCANBasic.TRACE_FILE_SEGMENTED|PCANBasic.TRACE_FILE_DATE|PCANBasic.TRACE_FILE_TIME;
			stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_TRACE_CONFIGURE, ref iBuffer, sizeof(UInt32));
			if (stsResult != TPCANStatus.PCAN_ERROR_OK)
			{
				MessageBox.Show(GetFormatedError(stsResult),Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
			}
		}
		
		/// <summary>
        /// Processes a received message, in order to show it in the Message-ListView
        /// </summary>
        /// <param name="theMsg">The received PCAN-Basic message</param>
        /// <returns>True if the message must be created, false if it must be modified</returns>
        private void ProcessMessage(TPCANMsg theMsg, TPCANTimestamp itsTimeStamp)
        {            
            // We search if a message (Same ID and Type) is 
            // already received or if this is a new message
            //
            lock (m_LastMsgsList.SyncRoot)
            {
                foreach (MessageStatus msg in m_LastMsgsList)
                {
                    if ((msg.CANMsg.ID == theMsg.ID) && (msg.CANMsg.MSGTYPE == theMsg.MSGTYPE))
                    {
                        // Modify the message and exit
                        //
                        msg.Update(theMsg, itsTimeStamp);
                        return;
                    }
                }
                // Message not found. It will created
                //
                InsertMsgEntry(theMsg, itsTimeStamp); //New message => Create new entry in the array
            }
        }
		
        /// <summary>
        /// Return the PCAN-BUS Handle definition name corresponding to the handle value given as argument
        /// </summary>
        /// <param name="handle">PCAN-Basic Handle to format</param>
        /// <returns>PCAN-BUS Handle definition name</returns>
        private string GetPCAN_BusName(TPCANHandle handle)
        {
        	switch (handle)
        	{
        		case PCANBasic.PCAN_USBBUS1:
        			return("PCAN_USBBUS1");
        		case PCANBasic.PCAN_USBBUS2:
        			return("PCAN_USBBUS2");
        		case PCANBasic.PCAN_USBBUS3:
        			return("PCAN_USBBUS3");
        		case PCANBasic.PCAN_USBBUS4:
        			return("PCAN_USBBUS4");
        		case PCANBasic.PCAN_USBBUS5:
        			return("PCAN_USBBUS5");
        		case PCANBasic.PCAN_USBBUS6:
        			return("PCAN_USBBUS6");
        		case PCANBasic.PCAN_USBBUS7:
        			return("PCAN_USBBUS7");
        		case PCANBasic.PCAN_USBBUS8:
        			return("PCAN_USBBUS8");
        	}
        	
        	return("");
        }
        
		#endregion
		
		#endregion
		
		#region Cycle management
		
		private void PlayCycle()
        {
        	#region Pre-checks
        	double TVal = 0;
        	
        	if (!(double.TryParse(Txt_CycleStart.Text, out TVal)))
        	{
        		MessageBox.Show("Cycle start time must be a numeric value !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		bCycleStartEndTxtSetting = true;
        		Txt_CycleStart.Text = Math.Round((double)(oCycle.TimeEvents[0].TimeEvent) / 1000,3).ToString();
        		bCycleStartEndTxtSetting = false;
        		
        		return;
        	}
        	
        	TCycleStart = (long)(TVal * 1000);
        	if (TCycleStart < oCycle.TimeEvents[0].TimeEvent | TCycleStart > oCycle.TimeEvents[oCycle.TimeEvents.Count - 1].TimeEvent)
        	{
        		MessageBox.Show("Start time defined is not contained in the cycle !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		bCycleStartEndTxtSetting = true;
        		Txt_CycleStart.Text = Math.Round((double)(oCycle.TimeEvents[0].TimeEvent) / 1000,3).ToString();
        		bCycleStartEndTxtSetting = false;
        		
        		return;
        	}
        		
        	if (!(double.TryParse(Txt_CycleEnd.Text, out TVal)))
        	{
        		MessageBox.Show("Cycle end time must be a numeric value !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		bCycleStartEndTxtSetting = true;
        		Txt_CycleEnd.Text = Math.Round((double)(oCycle.TimeEvents[oCycle.TimeEvents.Count - 1].TimeEvent) / 1000,3).ToString();
        		bCycleStartEndTxtSetting = false;
        		
        		return;
        	}
        	
        	TCycleEnd = (long)(TVal *1000);
        	if (TCycleEnd > oCycle.TimeEvents[oCycle.TimeEvents.Count - 1].TimeEvent | TCycleEnd < oCycle.TimeEvents[0].TimeEvent)
        	{
        		MessageBox.Show("End time defined is not contained in the cycle !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		bCycleStartEndTxtSetting = true;
        		Txt_CycleEnd.Text = Math.Round((double)(oCycle.TimeEvents[oCycle.TimeEvents.Count - 1].TimeEvent) / 1000,3).ToString();
        		bCycleStartEndTxtSetting = false;
        		
        		return;
        	}
        	
        	if (TCycleStart >= TCycleEnd)
        	{
        		MessageBox.Show("End time must be greater than start time !", Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        		
        		bCycleStartEndTxtSetting = true;
        		Txt_CycleStart.Text = Math.Round((double)(oCycle.TimeEvents[0].TimeEvent) / 1000,3).ToString();
        		Txt_CycleEnd.Text = Math.Round((double)(oCycle.TimeEvents[oCycle.TimeEvents.Count - 1].TimeEvent) / 1000,3).ToString();
        		bCycleStartEndTxtSetting = false;
        		
        		return;
        	}
        	#endregion
        	
        	if(NumUpDown_CycleCount.Value>0 | Chk_InfinitePlay.Checked)
        	{
        		Lbl_CurrentCycleNum.Visible=true;
	    		Txt_CurrentCycleNum.Visible=true;
	    		Lbl_CurrentProgress.Visible=true;
	    		Lbl_TotalProgress.Visible=true;
	    		PB_CurrentProgress.Visible=true;
	    		PB_TotalProgress.Visible=true;
	    		
	    		Cmd_BreakCycle.Enabled=true;
	    		Cmd_StopCycle.Enabled=true;
	    		
	    		Cmd_PlayCycle.Enabled=false;
	    		Lbl_CycleCount.Enabled=false;
	    		NumUpDown_CycleCount.Enabled=false;
	    		Chk_InfinitePlay.Enabled = false;
	    		Lbl_CycleStart.Enabled = false;
        		Lbl_CycleEnd.Enabled = false;
        		Txt_CycleStart.Enabled = false;
        		Txt_CycleEnd.Enabled = false;
	    		
	    		Txt_CurrentCycleNum.Text=(LoopCnt+1).ToString();
	    			    		
	    		bCycleRunning=true;
	    		
	    		FireControllerCycleRunningChangedEvent(bCycleRunning);
	    		
	    		if (TxEngMessages.Count > 0)
	    		{
	    			Split_Cycle_VirtualSig_Graph.Panel1Collapsed = false;
	    		}
	    		
	    		if (Chk_InfinitePlay.Checked)
	    		{
	    			BGWrk_Cycle.RunWorkerAsync((bool)true);
	    		}
	    		else
	    		{
	    			BGWrk_Cycle.RunWorkerAsync((int)NumUpDown_CycleCount.Value);
	    		}
        		
        		//Automatic trace recording //HACK: Remove [acquisition trigger]
        		if(bRecordingAuto & !bRecording)
        		{
        			StartRecording();
        		}
        		
        		//Timer for graphic update enabling
        		Timer_CycleGraph.Enabled = true;
        	}
        }
		
		private void StopCycle()
		{
			BGWrk_Cycle.CancelAsync();
			
			Cmd_PlayCycle.Enabled=true;
			Cmd_BreakCycle.Enabled=false;
			
			//Timer for graphic update disabling
			Timer_CycleGraph.Enabled = false;
			
			if(!bPauseCycle)
			{
				Lbl_CurrentCycleNum.Visible=false;
				Txt_CurrentCycleNum.Visible=false;
				Lbl_CurrentProgress.Visible=false;
				Lbl_TotalProgress.Visible=false;
				PB_CurrentProgress.Value=0;
				PB_CurrentProgress.Visible=false;
				PB_TotalProgress.Value=0;
				PB_TotalProgress.Visible=false;
				
				Cmd_StopCycle.Enabled=false;
				
				//Lbl_CycleCount.Enabled=true;
				//NumUpDown_CycleCount.Enabled=true;
				Lbl_CycleStart.Enabled = true;
				Lbl_CycleEnd.Enabled = true;
				Txt_CycleStart.Enabled = true;
				Txt_CycleEnd.Enabled = true;
				Chk_InfinitePlay.Enabled=true;
				
				if (!Chk_InfinitePlay.Checked)
				{
					Lbl_CycleCount.Enabled=true;
					NumUpDown_CycleCount.Enabled=true;
				}
				
				bCycleRunning=false;
				
				FireControllerCycleRunningChangedEvent(bCycleRunning);
				
				//Automatic trace recording
				if(bRecordingAuto & bRecording) //HACK: Remove [acquisition trigger]
				{
					StopRecording();
				}
			}
		}
		
		private void RunCycle(int LoopNumber, bool InfinitePlay, BackgroundWorker Worker, System.ComponentModel.DoWorkEventArgs e)
        {
        	int LoopIterationCount = (int)oCycle.GetTimeEventCountBetweenTimes(TCycleStart,TCycleEnd);
        	int TotalInterationCount = LoopIterationCount;
        	int Progress=0;
        	int ProgressPrec=0;
        	
        	if (!InfinitePlay)
        	{
        		TotalInterationCount = LoopIterationCount * LoopNumber;
        	}
        	
        	for(iLoopCurrent=iLoopInitial;iLoopCurrent<LoopNumber;iLoopCurrent++)
        	{
	        	int IterationCount = 0;
        		
	        	iTimeEventCurrent =  oCycle.GetTimeEventIndex(TCycleStart);
	        	if (iTimeEventCurrent == -1) return;
	        	
	        	//long AbsTime = TCycleStart;
	        	TimeInCycle = TCycleStart;
	        	
	        	if (iTimeEventInitial > 0)
	        	{
	        		iTimeEventCurrent = iTimeEventInitial;
	        		//AbsTime = oCycle.TimeEvents[iTimeEventInitial].TimeEvent;
	        		TimeInCycle = oCycle.TimeEvents[iTimeEventInitial].TimeEvent;
	        	}
	        	
	        	long EndTime =  TCycleEnd;
	        	
	        	//Debug
    			//DateTime Tic=DateTime.Now;
	        	
	        	//while(AbsTime<=EndTime)
	        	while(TimeInCycle<=EndTime)
	        	{
	        		//if(AbsTime == oCycle.TimeEvents[iTimeEventCurrent].TimeEvent) //It's time to send a message
	        		if(TimeInCycle == oCycle.TimeEvents[iTimeEventCurrent].TimeEvent) //It's time to send a message
	        		{
	        			//Debug
	        			//DateTime Tic=DateTime.Now;
	        			
	        			foreach(CANMessageData MsgData in oCycle.TimeEvents[iTimeEventCurrent].MessagesData)
	        			{
	        				SendMessage(MsgData);
	        			}
	        			
	        			iTimeEventCurrent++;
	        			IterationCount++;
	        			
	        			if (InfinitePlay)
	        			{
	        				Progress=(int)(IterationCount*100/TotalInterationCount);
	        			}
	        			else
	        			{
	        				Progress=(int)(iLoopCurrent*LoopIterationCount+IterationCount)*100/TotalInterationCount;
	        			}
	        			
	        			if(Progress!=ProgressPrec)
	        			{
	        				Worker.ReportProgress(Progress);
	        				ProgressPrec=Progress;
	        			}
	        			
	        			//Debug
	        			//DateTime Toc=DateTime.Now;
	        			//TimeSpan TExec=Toc.Subtract(Tic);
	        			//int Msec=TExec.Milliseconds;
	        		}
	        		
	        		System.Threading.Thread.Sleep(1); //Wait 1ms
	        		//AbsTime++;
	        		TimeInCycle++;
	        		
	        		if(Worker.CancellationPending)
	        		{
	        			return;
	        		}
	        	}
	        	
	        	iTimeEventInitial = 0;
	        	
	        	if (InfinitePlay)
	        	{
	        		iLoopCurrent = 0;
	        	}
	        	
	        	//Debug
    			//DateTime Toc=DateTime.Now;
    			//TimeSpan TExec=Toc.Subtract(Tic);
    			//int Msec=TExec.Milliseconds;
        	}
        	
        	bPauseCycle=false;
        }
		
		private void PlotCycle()
        {
        	PlotCycle(false, -1, -1, -1);
        }
        
        private void PlotCycle(bool bRefreshing, double TimeCursorPosition)
        {
        	PlotCycle(bRefreshing,TimeCursorPosition, -1, -1);
        }
        
        private void PlotCycle(bool bRefreshing, double TimeCursorPosition, double StartPosistion, double EndPosition)
        {
        	if (oCycle.GraphSeries.FormatedSeries.Count > 0)
        	{
        		if (!bRefreshing)
        		{
        			if (Split_Cycle_VirtualSig_Graph.Panel1Collapsed)
        			{
        				Graph_Cycle.Width = Split_Cycle_VirtualSig_Graph.Width - 12;
        			}
        			else
        			{
        				Graph_Cycle.Width = Split_Cycle_VirtualSig_Graph.Width - Split_Cycle_VirtualSig_Graph.SplitterDistance - 12;
        			}
        			
        			Graph_Cycle.Height = Split_Cycle_VirtualSig_Graph.Height - 2;
		        	
		        	Context_CycleGraph.Items.Clear();
		        	
		        	ToolStripMenuItem ItemSetStart = (ToolStripMenuItem) Context_CycleGraph.Items.Add("Set cycle starting point");
		        	ItemSetStart.Click += new EventHandler(Context_CycleGraphItemSetStart_Click);
		        	
		        	ToolStripMenuItem ItemSetEnd = (ToolStripMenuItem) Context_CycleGraph.Items.Add("Set cycle ending point");
		        	ItemSetEnd.Click += new EventHandler(Context_CycleGraphItemSetEnd_Click);
		        	
		        	ToolStripMenuItem ItemSetConfirm = (ToolStripMenuItem) Context_CycleGraph.Items.Add("Confirm cycle start/end points setting");
		        	ItemSetConfirm.Click += new EventHandler(Context_CycleGraphItemSetConfirm_Click);
		        	ItemSetConfirm.Visible = false;
		        	
		        	ToolStripMenuItem ItemSetCancel = (ToolStripMenuItem) Context_CycleGraph.Items.Add("Cancel cycle start/end points setting");
		        	ItemSetCancel.Click += new EventHandler(Context_CycleGraphItemSetCancel_Click);
		        	ItemSetCancel.Visible = false;
		        	
		        	ToolStripSeparator Sep = new ToolStripSeparator();
		        	Context_CycleGraph.Items.Add(Sep);
        		}
        		
	        	CANStreamTools.Draw_CycleGraph(oCycle, Graph_Cycle, TimeCursorPosition, StartPosistion, EndPosition);
	        	
	        	if (!bRefreshing)
	        	{
		        	foreach(FormatedGraphSerie oSerie in oCycle.GraphSeries.FormatedSeries)
		        	{
		        		ToolStripMenuItem SerieMenuItem = (ToolStripMenuItem) Context_CycleGraph.Items.Add(oSerie.Name);
		        		SerieMenuItem.Checked=oSerie.Visible;
						SerieMenuItem.Click += new System.EventHandler(Context_CycleGraphMenuItem_Click);
		        	}
	        	}
        	}
        }
        
        private void Set_OldCycleStartEndPoint()
        {
        	if (!(double.TryParse(Txt_CycleStart.Text, out TCycleStart_Old)))
        	{
        		TCycleStart_Old = (double)(oCycle.TimeEvents[0].TimeEvent) / 1000;
        	}
        	
        	if (!(double.TryParse(Txt_CycleEnd.Text, out TCycleEnd_Old)))
        	{
        		TCycleEnd_Old = (double)(oCycle.TimeEvents[oCycle.TimeEvents.Count -1].TimeEvent) / 1000;
        	}
        }
        
		private void Set_CycleStartEndCursorsFromTextBox()
        {
        	double dTCycleStart = 0;
        	double dTCycleEnd   = 0;
        	
        	if (!(double.TryParse(Txt_CycleStart.Text, out dTCycleStart)))
        	{
        		dTCycleStart = (double)(oCycle.TimeEvents[0].TimeEvent) / 1000;
        	}
        	
        	if (!(double.TryParse(Txt_CycleEnd.Text, out dTCycleEnd)))
        	{
        		dTCycleEnd = (double)(oCycle.TimeEvents[oCycle.TimeEvents.Count -1].TimeEvent) / 1000;
        	}
        	
        	if (dTCycleStart < dTCycleEnd)
        	{
        		PlotCycle(true, -1, dTCycleStart, dTCycleEnd);
        	}
        }
		
		private double GetTimeValueAtPosition(int Position)
        {
        	double X = (double) Position;
        	double X1 = (double) CANStreamConstants.CycleGraphPlotAreaLeft;
        	double X2 = X1 + ((double)(Graph_Cycle.Width - CANStreamConstants.CycleGraphPlotAreaWidthOffset));
        	double Y1 = oCycle.GraphSeries.AxisProperties.AxisX.MinValue;
        	double Y2 = oCycle.GraphSeries.AxisProperties.AxisX.MaxValue;
        	
        	double a = (Y2 - Y1) / (X2 - X1);
        	double b = Y2 - a * X2;
        	
        	return(a * X + b);
        }
		
		private void Set_CycleVirtualSignalValue(string Name, string sValue, VirtualParameter VirtualRef)
		{
			
		}
		
		private void FireControllerCycleStartEndSettingEvent(int State)
		{
			ControllerCycleStartEndSettingEventArgs Args = new ControllerCycleStartEndSettingEventArgs();
			Args.SettingState = State;
			OnControllerCycleStartEndSetting(Args);
		}
		
		private void FireControllerCycleRunningChangedEvent(bool bRunning)
		{
			ControllerRunningChangedEventArgs Args = new ControllerRunningChangedEventArgs();
			Args.Running = bRunning;
			OnControllerCycleRunningChanged(Args);
		}
		
		#endregion
		
		#region Manual control management
		
		private void ShowManualCanConfig()
        {
        	Chk_CycleMux.Enabled = false;
			Chk_CycleMux.Checked = false;
        	
			Chk_VirtualParamTxEnabled.Enabled = false;
			Chk_VirtualParamTxEnabled.Checked = false;
			
        	if(!(oCanConfig==null))
        	{
        		Grid_CANData.Rows.Clear();
        		int RowsCnt = oCanConfig.GetTxParameterCount();
        		
        		if (RowsCnt > 0) Grid_CANData.Rows.Add(RowsCnt);
        		else			 return;
        			
        		int iRow=0;
        		
        		foreach(CANMessage oMsg in oCanConfig.Messages)
        		{
        			if(oMsg.RxTx.Equals(CanMsgRxTx.Tx))
        			{
	        			foreach(CANParameter oParam in oMsg.Parameters)
	        			{
	        				//Cells value
	        				Grid_CANData.Rows[iRow].HeaderCell.Value=oMsg.Identifier;          			
	        				
	        				Grid_CANData.Rows[iRow].Cells[0].Value =  oMsg.Identifier;						//Identifier
	        				Grid_CANData.Rows[iRow].Cells[1].Value = oMsg.RxTx.ToString();       			//RxTx
	        				Grid_CANData.Rows[iRow].Cells[2].Value = oMsg.Period.ToString();     			//Period
	        				
	        				Grid_CANData.Rows[iRow].Cells[3].Value = oParam.MultiplexerValue.ToString();	//Mux value
	        				Grid_CANData.Rows[iRow].Cells[4].Value = oParam.Name;                			//Parameter name
	        				Grid_CANData.Rows[iRow].Cells[5].Value = oParam.StartBit.ToString(); 			//Parameter start bit
	        				Grid_CANData.Rows[iRow].Cells[6].Value = oParam.Length.ToString();   			//Parameter bit length
	        				Grid_CANData.Rows[iRow].Cells[7].Value = oParam.Endianess.ToString(); 			//Parameter endianess
	        				
	        				if (oParam.Signed) Grid_CANData.Rows[iRow].Cells[8].Value = "Signed";			//Parameter signedness
	        				else Grid_CANData.Rows[iRow].Cells[8].Value = "Unsigned";
	        				
	        				Grid_CANData.Rows[iRow].Cells[9].Value = oParam.Gain.ToString();     			//Linearization gain
	        				Grid_CANData.Rows[iRow].Cells[10].Value = oParam.Zero.ToString();     			//Linearization zero
	        				Grid_CANData.Rows[iRow].Cells[11].Value = "0";                        			//Initial value
	        				Grid_CANData.Rows[iRow].Cells[12].Value = oParam.Unit;							//Parameter unit
	        				Grid_CANData.Rows[iRow].Cells[13].Value = oParam.Comment;						//Parameter comment
	        				
	        				//Cells backcolor
                            Color InfoBackColor = Color.Empty;
	        				if (oParam.IsVirtual) InfoBackColor=Color.LightGreen;
	        				else				  InfoBackColor=Color.LightBlue;
	        				
	        				for (int iCol=0; iCol<Grid_CANData.Rows[iRow].Cells.Count; iCol++)
	        				{
	        					//Alignment
	        					if (!(iCol == GRID_MANUAL_NAME_COL || iCol == GRID_MANUAL_COMMENT_COL))
	        					{    
	        						Grid_CANData.Rows[iRow].Cells[iCol].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	        					}
	        					
	        					//BackColor
	        					if (!(iCol == GRID_MANUAL_NAME_COL || iCol == GRID_MANUAL_VALUE_COL) || oParam.IsVirtual)
	        					{
	        						Grid_CANData.Rows[iRow].Cells[iCol].Style.BackColor=InfoBackColor;
	        					}
	        				}

	        				if (oParam.IsVirtual)
    						{
	        					Grid_CANData.Rows[iRow].Cells[GRID_MANUAL_VALUE_COL].ReadOnly = true;
	        					Grid_CANData.Rows[iRow].Cells[GRID_MANUAL_VALUE_COL].ToolTipText = VCLibCollection.GetVirtualChannelExpression(oParam.VirtualChannelReference.LibraryName, oParam.VirtualChannelReference.ChannelName);
	        					
	        					Chk_VirtualParamTxEnabled.Enabled = true;
								Chk_VirtualParamTxEnabled.Checked = true;
    						}
	        				
	        				iRow++;
	        				
	        				Grid_CANData.AutoResizeColumns();
	        			}
	        			
	        			if ((!oMsg.MultiplexerName.Equals("") && !Chk_CycleMux.Enabled))
	        			{
	        				Chk_CycleMux.Enabled = true;
	        				Chk_CycleMux.Checked = true;
	        			}
        			}
        		}
        		
        		InitManualControlMessagesData();
        		
        		FireCanConfigChangedEvent(true);
        	}
        }
		
		private void FilterManualCanConfig(string sFilter)
		{
			foreach (DataGridViewRow oRow in Grid_CANData.Rows)
			{
				if ((sFilter.Equals("")) ||(oRow.Cells[GRID_MANUAL_NAME_COL].Value.ToString().ToLower().Contains(sFilter.ToLower())))
				{
					oRow.Visible = true;
				}
				else
				{
					oRow.Visible = false;
				}
			}
		}
		
        private void InitManualControlMessagesData()
        {
        	TxEngMessages=new List<CANMessageEncoded>();
        	
        	foreach(CANMessage oMsgCfg in oCanConfig.Messages)
        	{
        		if(oMsgCfg.RxTx.Equals(CanMsgRxTx.Tx))
        		{
        			CANMessageEncoded oEncodMsg=new CANMessageEncoded(oMsgCfg,oCanConfig.MessageLength/8);
        			
        			if (!(TxRawMessages == null))
        			{
        				if (!(TxRawMessages.ContainsMessageId(oEncodMsg.uMessageId)))
        				{
        					TxEngMessages.Add(oEncodMsg);
        				}
        				else
        				{
        					MessageBox.Show("Message identifier 0x" + string.Format("{0:x3}", oEncodMsg.uMessageId) + " is already present in the raw messages", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        					Hide_MessageParametersRows(oEncodMsg);
        				}
        			}
        			else
        			{
        				TxEngMessages.Add(oEncodMsg);
        			}
        		}
        	}
        	
        	UpdateManualControlMessagesData();
        }
        
        private void UpdateManualControlMessagesData()
        {
        	foreach(CANMessageEncoded oMsgEncod in TxEngMessages)
        	{
        		//Get engineering value of each parameter
        		foreach(CANParameter oParam in oMsgEncod.Parameters)
        		{
        			if (!(oParam.IsVirtual))
        			{
	        			int iParamRow=GetParameterRowIndex(oParam.Name);
	        			
	        			if(iParamRow!=-1)
	    				{
	    					double EngValue=0;
	    					if(double.TryParse(Grid_CANData.Rows[iParamRow].Cells[GRID_MANUAL_VALUE_COL].Value.ToString(),out EngValue))
	    					{
	    						oParam.DecodedValue = EngValue;
	    					}
	    					else
	    					{
	    						MessageBox.Show("Value for " + oParam.Name + " must be a numeric decimal value !",
	    						                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
	    						                
	    					}
	    				}
        			}
        		}
        		
        		//Message raw data creation
        		oMsgEncod.EncodeMessage();
        	}
        }
        
        private int GetParameterRowIndex(string ParameterName)
        {
        	for(int iRow=0;iRow<Grid_CANData.Rows.Count;iRow++)
        	{
        		if(Grid_CANData.Rows[iRow].Cells[GRID_MANUAL_NAME_COL].Value.Equals(ParameterName))
        		{
        			return(iRow);
        		}
        	}
        	
        	return(-1);
        }
        
        private void StartManualControl()
        {
        	SentMsgCounter=0;
        	
        	Lbl_MsgCounter.Visible=true;
        	Txt_MsgCounter.Visible=true;
        	Txt_MsgCounter.Text=SentMsgCounter.ToString();
        	
			bManualRunning=true;
			
			FireControllerManualRunningChangedEvent(bManualRunning);
			
        	BGWrk_Manual.RunWorkerAsync();
        }
        
		private void StopManualControl()
		{
			BGWrk_Manual.CancelAsync();
			
			bManualRunning=false;
			
			FireControllerManualRunningChangedEvent(bManualRunning);
			
			Lbl_MsgCounter.Visible=false;
			Txt_MsgCounter.Visible=false;
		}
		
		private void RunManualControl(BackgroundWorker Worker, System.ComponentModel.DoWorkEventArgs e)
        {
        	int iTime=0;
        	int TimeRem=0;
        	
        	int MsgCount=0;        	
        	DateTime TLastMsgCntUpdate= new DateTime();
        	
        	while(!(Worker.CancellationPending))
        	{
        		//Engineering Messages sending
        		if (!(TxEngMessages == null))
        		{
	        		foreach(CANMessageEncoded oMsgEncod in TxEngMessages)
	        		{        			
	        			Math.DivRem(iTime,oMsgEncod.Period,out TimeRem);
	        			
	        			if(TimeRem==0) //It's time to send the message
	        			{
	        				if (oMsgEncod.HasVirtualParameters)
	        				{
	        					foreach (CANParameter oParam in oMsgEncod.Parameters)
	        					{
	        						if (oParam.IsVirtual)
	        						{
	        							oParam.DecodedValue = VCLibCollection.GetLastCANTxChannelValue(oParam.VirtualChannelReference.LibraryName,
	        							                                                               oParam.VirtualChannelReference.ChannelName);
	        						}
	        					}
	        					
	        					oMsgEncod.EncodeMessage();
	        				}
	        				
	        				if ((!oMsgEncod.HasVirtualParameters) || (oMsgEncod.HasVirtualParameters && bVirtualParamTx))
	        				{
		        				if (SendMessage(oMsgEncod.GetPCANMessage()))
		        				{
		        					MsgCount++;
		        					
		        					if (Chk_CycleMux.Checked)
		        					{
		        						oMsgEncod.SetMultiplexer();
		        					}
		        				}
	        				}
	        			}
	        		}
        		}
        		
        		//Raw Message sending
        		if (!(TxRawMessages == null))
        		{
	        		foreach (CAN_RawMessageData oRawMsg in TxRawMessages.Messages)
	        		{
	        			if (oRawMsg.Send && oRawMsg.Period > 0)
	        			{
	        				Math.DivRem(iTime,oRawMsg.Period,out TimeRem);
	        				
	        				if(TimeRem==0) //It's time to send the message
	        				{
	        					if (SendMessage(oRawMsg.GetPCANMessage()))
	        					{
	        						MsgCount++;
	        					}
	        				}
	        			}
	        		}
        		}
        		
        		//Time index increment
        		if(!(iTime==int.MaxValue)) //int overflow ?
        		{
        			iTime++;	
        		}
        		else
        		{
        			iTime=1; //Reset
        		}
        		
        		//Report progress if needed
        		TimeSpan TSinceLastUpdate = DateTime.Now.Subtract(TLastMsgCntUpdate);
        		if (TSinceLastUpdate.TotalMilliseconds >= T_MSG_CNT_UPDATE_PERIOD)
        		{
        			TLastMsgCntUpdate = DateTime.Now;
        			Worker.ReportProgress(MsgCount);
        			MsgCount = 0;
        		}
        	        		
        		//Wait for 1 ms
        		System.Threading.Thread.Sleep(1);
        	}
        }
		
		private bool TxEngMessagesContainsId(UInt32 Id)
		{
			if (!(TxEngMessages == null))
			{
				foreach (CANMessageEncoded oMsg in TxEngMessages)
				{
					if (oMsg.uMessageId == Id)
					{
						return(true);
					}
				}
			}
			
			return(false);
		}
		
		private void Hide_MessageParametersRows(CANMessageEncoded oMsg)
		{
			for (int iRow = 0; iRow < Grid_CANData.Rows.Count; iRow++)
			{
				if (oMsg.GetCANParameterIndex(Grid_CANData.Rows[iRow].Cells[GRID_MANUAL_NAME_COL].Value.ToString(), ParameterResearchOption.Name) != -1)
				{
					Grid_CANData.Rows[iRow].Visible = false;
				}
			}
		}
		
		private void Show_MessageParametersRows(string sMsgId)
		{
			if (!(oCanConfig == null) && Grid_CANData.Rows.Count > 0)
			{
				CANMessage oMsg = oCanConfig.GetCANMessage(sMsgId, MessageResearchOption.Identifier);
				
				if (!(oMsg == null))
				{
					if (oMsg.RxTx.Equals(CanMsgRxTx.Tx))
					{						
						for (int iRow = 0; iRow < Grid_CANData.Rows.Count; iRow++)
						{							
							if (oMsg.GetCANParameterIndex(Grid_CANData.Rows[iRow].Cells[GRID_MANUAL_NAME_COL].Value.ToString(), ParameterResearchOption.Name) != -1)
							{
								Grid_CANData.Rows[iRow].Visible = true;
							}
						}
						
						InitManualControlMessagesData();
					}
				}
			}
		}
		
		private void Update_VirtualParameterTxValue(string ParameterName, double Value)
		{
		}
		
		private void FireControllerManualRunningChangedEvent(bool bRunning)
		{
			ControllerRunningChangedEventArgs Args = new ControllerRunningChangedEventArgs();
			Args.Running = bRunning;
			OnControllerManualRunningChanged(Args);
		}
		
		#region Manual raw messages
		
		private void Show_RawMessage(CAN_RawMessageData oRawMsg, int RowIndex)
		{
			if (!(oRawMsg == null || (RowIndex < 0 || RowIndex >= Grid_CANRawData.Rows.Count)))
			{
				bRawMsgGridEdition = true;
				
				Grid_CANRawData.Rows[RowIndex].Tag = oRawMsg.KeyId;
				
				Grid_CANRawData.Rows[RowIndex].Cells[0].Value = string.Format("{0:x3}", oRawMsg.MessageId).ToUpper();
				Grid_CANRawData.Rows[RowIndex].Cells[1].Value = oRawMsg.DLC.ToString();
				Grid_CANRawData.Rows[RowIndex].Cells[2].Value = oRawMsg.Period.ToString();
				Grid_CANRawData.Rows[RowIndex].Cells[3].Value = oRawMsg.Send;
				
				if (oRawMsg.Period == 0) Grid_CANRawData.Rows[RowIndex].Cells[4].Value = "Tx";
				else Grid_CANRawData.Rows[RowIndex].Cells[4].Value = "";
				
				
				int iCell = GRID_RAW_COL_1ST_BYTE;
				foreach (byte Val in oRawMsg.MsgData)
				{
					Grid_CANRawData.Rows[RowIndex].Cells[iCell].Value = string.Format("{0:x2}", Val).ToUpper();
					iCell++;
				}
				
				while (iCell < GRID_RAW_COL_1ST_BYTE + 5)
				{
					Grid_CANRawData.Rows[RowIndex].Cells[iCell].Value = "00";
					iCell++;
				}
				
				foreach (DataGridViewCell oCell in Grid_CANRawData.Rows[RowIndex].Cells)
				{
					oCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
				}
				
				bRawMsgGridEdition = false;
			}
		}
		
		private void Set_RawMessageFromGridRow(int RowIndex)
		{
			if (!(RowIndex < 0 || RowIndex >= Grid_CANRawData.Rows.Count || TxRawMessages == null))
			{
				DataGridViewRow oRow = Grid_CANRawData.Rows[RowIndex];
				CAN_RawMessageData oMsg = TxRawMessages.Get_RawMessageAtKeyId((int)oRow.Tag);
				
				if (!(oMsg == null))
				{
					try
					{						
						UInt32 MsgId = UInt32.Parse(oRow.Cells[0].Value.ToString(), NumberStyles.HexNumber);
						
						if (oMsg.MessageId != MsgId)
						{
							if (!(TxEngMessagesContainsId(MsgId) || TxRawMessages.ContainsMessageId(MsgId)))
							{
								oMsg.MessageId = MsgId;
							}
							else
							{
								MessageBox.Show("Message identifier 0x" + string.Format("{0:x3}", MsgId) + " is already present !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
								oRow.Cells[0].Value = string.Format("{0:x3}", oMsg.MessageId);
								return;
							}
						}
						
						oMsg.DLC = int.Parse(oRow.Cells[1].Value.ToString());
						oMsg.Period = int.Parse(oRow.Cells[2].Value.ToString());
						oMsg.Send = bool.Parse(oRow.Cells[3].Value.ToString());
						
						if (oMsg.DLC > 0)
						{
							oMsg.MsgData = new byte[oMsg.DLC];
							
							int iCell = GRID_RAW_COL_1ST_BYTE;
							for (int i=0; i<oMsg.DLC; i++)
							{
								oMsg.MsgData[i] = byte.Parse(oRow.Cells[iCell].Value.ToString(), NumberStyles.HexNumber);
								iCell++;
							}
						}
					}
					catch
					{
						MessageBox.Show("Raw message " + (RowIndex + 1).ToString() + " configuration error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}
		
		private void User_RawMessage_Tx(int RowIndex)
		{
			if(Grid_CANRawData.Rows[RowIndex].Cells[GRID_RAW_COL_TX_BTN].Value.Equals("Tx"))
			{
				if(bManualRunning)
				{
					SendMessage(TxRawMessages.Messages[RowIndex].GetPCANMessage());
				}
			}
		}
		
		#endregion
		
		#endregion
		
		#region Spy Management
		
		private void StartSpy()
        {
        	if(bCANConnected)
        	{
        		//Id filter check
        		if(!(Txt_SpyIdFilterMin.Text.Equals("") | Txt_SpyIdFilterMax.Text.Equals("")))
        		{
        			SpyMsgIdFilterMin=(short)NumberBaseConverter.Hex2Dec(Txt_SpyIdFilterMin.Text);
        			SpyMsgIdFilterMax=(short)NumberBaseConverter.Hex2Dec(Txt_SpyIdFilterMax.Text);
        		}
        		else
        		{
        			MessageBox.Show("Message Id filter error !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Hand);
        			return;
        		}
        		
        		//Value grids init
        		if(bClearSpyGrids)
        		{
        			Manual_SpyDataViewer.Clear_RawGrid();
        			Manual_SpyDataViewer.Clear_EngGrid();
        			
        			SpyGraphChannelList.Clear();
        			SpyGraphSeries.RTSeries.Clear();
        			
        			bClearSpyGrids=false;
        		}
        		
        		//Gaphic window init
        		if(!(oCanConfig==null) && ChkLst_ChannelSel.Visible==false)
        		{
        			ChkLst_ChannelSel.Visible = true;
        			Cmd_GraphSpyRec.Visible = true;
        			Cmd_GraphSpyPause.Visible = true;
        			Grp_GraphProperties.Visible = true;
        			Graph_Spy.Visible = true;
        		}
        		
        		//Spy init
        		m_LastMsgsList.Clear();
        		TStartSpy=DateTime.Now;
        		
        		//Spy start
        		if(SpyMsgRxMode.Equals(SpyCANRxMode.Manual))
        		{	
        			if (!(VCLibCollection.bLibrariesInitialized))
        			{
        				VCLibCollection.InitLibrariesComputation();
        			}
        			
        			ReadMessagesOnce();
        			DisplayMessages();
        		}
        		else
        		{
        			//Control enabling/disabling
	        		Cmb_SpyCANRate.Enabled=false;
	        		Cmb_SpyCANRxMode.Enabled=false;
	        		Txt_SpyIdFilterMin.Enabled=false;
	        		Txt_SpyIdFilterMax.Enabled=false;
        			Cmd_StartSpy.Enabled=false;
        			Cmd_StopSpy.Enabled=true;
        			
        			if(!(oCanConfig==null))
        			{
        				ChkLst_ChannelSel.Visible=true;
        			}
        			
        			//Compile virtual channels
        			VCLibCollection.InitLibrariesComputation();
        			
        			bSpyRunning=true;
        			
        			FireControllerSpyRunningChangedEvent(bSpyRunning);
        			
        			//Launch spy thread
        			BGWrk_Spy.RunWorkerAsync();
        			
        			//Lauch CAN trace record
        			if(bRecordingAuto & !bRecording) //HACK: Remove [acquisition trigger]
		        	//if (RecordMode.Equals(RecordingMode.Auto) && !bRecording) //HACK: Implement acquisition trigger
        			{
		        		StartRecording();
		        	}
        		}
        	}
        }
		
		private void StopSpy()
        {
        	//Stop spy thread
        	BGWrk_Spy.CancelAsync();
        	
        	bSpyRunning=false;
        	
        	//Control enabling/disabling
    		Cmb_SpyCANRate.Enabled=true;
    		Cmb_SpyCANRxMode.Enabled=true;
    		Txt_SpyIdFilterMin.Enabled=true;
    		Txt_SpyIdFilterMax.Enabled=true;
			Cmd_StopSpy.Enabled=false;
			Cmd_StartSpy.Enabled=true;
			
			FireControllerSpyRunningChangedEvent(bSpyRunning);
			
			RxEventInitialized=false;	

			bClearSpyGrids=true;

			//Automatic trace recording
    		if(bRecordingAuto & bRecording) //HACK: Remove [acquisition trigger]
    		//if (RecordMode.Equals(RecordingMode.Auto) && bRecording) //HACK: Implement acquisition trigger
    		{
    			StopRecording();
    		}			
        }
		
		private void RunSpy(BackgroundWorker Worker)
        {
        	while(!Worker.CancellationPending)
        	{
        		if(SpyMsgRxMode.Equals(SpyCANRxMode.Event)) //Read messages on Rx event
        		{
        			if(!RxEventInitialized)
        			{
        				UInt32 iBuffer;
			            TPCANStatus stsResult;
			
			            iBuffer = Convert.ToUInt32(m_ReceiveEvent.SafeWaitHandle.DangerousGetHandle().ToInt32());
			            // Sets the handle of the Receive-Event.
			            //
			            stsResult = PCANBasic.SetValue(m_PcanHandle, TPCANParameter.PCAN_RECEIVE_EVENT, ref iBuffer, sizeof(UInt32));
			
			            if(stsResult != TPCANStatus.PCAN_ERROR_OK)
					    {
						    FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
			            	MessageBox.Show(GetFormatedError(stsResult),"Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);
						    return;
					    }
        				
        				RxEventInitialized=true;
        			}
        			
        			if (m_ReceiveEvent.WaitOne(50))
        			{
        				ReadMessagesOnce();
        				Worker.ReportProgress(100);
        			}
        		}
        		else
        		{
        			if(!(SpyMsgRxMode.Equals(SpyCANRxMode.Manual))) //If not manual, read messages each x ms 
        			{
        				ReadMessagesOnce();
        				Worker.ReportProgress(100);
        				
        				System.Threading.Thread.Sleep(SpyRxPeriod);
        			}
        		}
        	}
        }
		
		private void InsertMsgEntry(TPCANMsg newMsg, TPCANTimestamp timeStamp)
        {
            MessageStatus msgStsCurrentMsg;

            lock (m_LastMsgsList.SyncRoot)
            {
                // We add this status in the last message list
                //
                msgStsCurrentMsg = new MessageStatus(newMsg, timeStamp, Manual_SpyDataViewer.Get_RawMessageCount() - 1);
                m_LastMsgsList.Add(msgStsCurrentMsg);
                
                if(!(oCanConfig == null))
                {
                	string sMsgId=msgStsCurrentMsg.IdString.Substring(0,msgStsCurrentMsg.IdString.Length-1);
                	CANMessage oMsgCfg=oCanConfig.GetCANMessage(sMsgId, MessageResearchOption.Identifier);
                	
                	if(!(oMsgCfg == null))
                	{
                		CANMessageDecoded oMsgDecoded =new CANMessageDecoded(oMsgCfg,msgStsCurrentMsg.CANMsg);
                		DecodedMessages.Add(oMsgDecoded);
                	}
                }
            }
        }
		
		private void DisplayMessages()
        {
        	TimeSpan TSinceLastUpdate=DateTime.Now.Subtract(TLastSpyGridUpdate);
        	if(!(TSinceLastUpdate.TotalMilliseconds > SPY_GRID_UPDATE_PERIOD))
        	{
        		return;
        	}
        	
        	lock (m_LastMsgsList.SyncRoot)
        	{
        		TLastSpyGridUpdate=DateTime.Now;
        		DecodedMessageCount=0;
        		
        		foreach(MessageStatus msgStatus in m_LastMsgsList)
        		{
        			if(msgStatus.MarkedAsUpdated)
        			{
        				msgStatus.MarkedAsUpdated=false;
        				
        				string[] RawMsgData = {
        										msgStatus.IdString,
        										msgStatus.CANMsg.LEN.ToString(),
        										msgStatus.DataString,
        										msgStatus.TimeString,
        										msgStatus.Count.ToString(),
        									  };
        				
        				CurrentSpyViewer.Update_RawGridRow(RawMsgData);

                        int MsgIndex = -1;

		                if(DecodedMessages.Count>0)
		                {
		                	MsgIndex=FindDecodedMessageIndex(msgStatus.IdString);
		                	
		                	if(!(MsgIndex == -1))
		                	{
		                		DecodedMessages[MsgIndex].UpdateRawMsgBytes(msgStatus.CANMsg.DATA);
		                		
		                		if(DecodedMessages[MsgIndex].bMessageDecoded)
		                		{
		                			foreach(CANParameter oParam in DecodedMessages[MsgIndex].Parameters)
		                			{
		                				string[] EngParamData = {
		                											DecodedMessages[MsgIndex].Identifier.ToString(),
		                											oParam.Name,
		                											oParam.RawValue,
		                											oParam.DecodedValue.ToString(),
		                											oParam.Unit,
		                											oParam.Comment,
		                										};
		                				
		                				CurrentSpyViewer.Update_EngGridRow(EngParamData);
		                				
		                				if (!(ChkLst_ChannelSel.Items.Contains(oParam.Name)))
		                				{
		                					SpyGraphChannelList.Add(oParam.Name);
		                				}
		                				
										//Add Spy graphic sample
										if(bSpyGraphEnabled)
										{
											TimeSpan TSample=DateTime.Now.Subtract(TStartSpy);
											SpyGraphSeries.AddSerieSamples(oParam.Name,TSample.TotalSeconds,oParam.DecodedValue);
										}
										
										//Set param value in virtual channel variable element table
										VCLibCollection.UpDateVariableElement(oParam.Name,oParam.DecodedValue);
		                			}
		                			
		                			FilterSpyGraphSeries();
		                		}
		                	}
		                }

                        //Update Spy data history
                        if (Tab_SpyHistory.SelectedTab.Tag.Equals("Data"))
                        {
                            if (!bDataHistoryFrozen)
                            {
                                //Frame Id filtering
                                if (msgStatus.CANMsg.ID >= (uint)TSTxt_IdFilterFrom.Tag && msgStatus.CANMsg.ID <= (uint)TSTxt_IdFilterTo.Tag)
                                {
                                    Lst_SpyDataHistory.Items.Insert(0, DateTime.Now.ToString("HH:mm:ss.ffff")
                                                                    + " : " + msgStatus.TimeString
                                                                    + " : " + msgStatus.IdString
                                                                    + " : " + msgStatus.DataString);

                                    if (!(MsgIndex == -1))
                                    {
                                        if (DecodedMessages[MsgIndex].bMessageDecoded)
                                        {
                                            for (int iParam = 0; iParam < DecodedMessages[MsgIndex].Parameters.Count; iParam++)
                                            {
                                                Lst_SpyDataHistory.Items.Insert(iParam + 1,
                                                                                "  " + DecodedMessages[MsgIndex].Parameters[iParam].Name
                                                                                + " : " + DecodedMessages[MsgIndex].Parameters[iParam].DecodedValue.ToString()
                                                                                + " " + DecodedMessages[MsgIndex].Parameters[iParam].Unit);
                                            }
                                        }
                                    }
                                }
                            }
                        }
        			}

                    DecodedMessageCount++;
        		}
        		
        		//Update virtual channels
        		VCLibCollection.ComputeLibraries();
        		ShowVirtualChannelValues();
        		
        		//Acquisition trigger status update
        		if (RecordMode.Equals(RecordingMode.Trigger))
        		{
        			if (RecordTrigger.Available)
        			{
        				//Trigger is firing its 'Trigger status changed' event if the status changed
        				//Event is caugth and handled thus, record starts or stops
        				RecordTrigger.UpdateTriggerStatus();
        			}
        		}
        		
        		//Update graph window
                if (Tab_SpyHistory.SelectedTab.Tag.Equals("Graph"))
                {
                    Update_SpyGraph();
                }
        	}
        }
		
		private int FindDecodedMessageIndex(string MsgId)
        {
        	for(int i=0;i<DecodedMessages.Count;i++)
        	{
        		if(DecodedMessages[i].Identifier.Equals(MsgId))
        		{
        			return(i);
        		}
        	}
        	
        	return(-1);
        }
		
		private void Update_SpyGraph()
        {
        	if((bSpyGraphEnabled == true & bSpyGraphFrozen == false))
        	{
	        	if(SpyGraphSeries.RTSeries.Count>0)
	        	{
	        		TimeSpan TGraphUpdate=DateTime.Now.Subtract(TLastSpyGraphUpdate);
	        		
	        		if(TGraphUpdate.TotalMilliseconds > SPY_GRAPH_UPDATE_PERIOD)
	        		{
	        			if(SpyGraphRestarted)
	        			{
	        				SetSpyGraphSeriesVisibility();
	        				SpyGraphRestarted=false;
	        			}
	        			
	        			CANStreamTools.ResetRandomColor();
	        			
	        			//Size graph control
			        	Graph_Spy.Width = Split_Rx_DataGraph.Panel2.Width - 161;
			        	Graph_Spy.Height = Split_Rx_DataGraph.Panel2.Height - 10;
			        	
			        	//Create graphic
			        	Graph=new XYChart(Graph_Spy.Width,
				                          	Graph_Spy.Height,
				                         	CANStreamTools.GetRGBColor(Color.Black),
				                         	CANStreamTools.GetRGBColor(Color.White),
				                         	0);
			        	
			        	//Create plotting area
			    		Graph.setPlotArea(40,20,
			    		                  Graph_Spy.Width-150,
			    		                  Graph_Spy.Height-70,
			    		                  CANStreamTools.GetRGBColor(Color.Black),-1,
			    		                  CANStreamTools.GetRGBColor(Color.LightGray),
			    		                  CANStreamTools.GetRGBColor(Color.LightGray),
			    		                  CANStreamTools.GetRGBColor(Color.LightGray));
			        	

			        	//Create legend
			        	//Graph.addLegend(Graph_Spy.Width-185,20,true,"Arial",10).setBackground(Chart.Transparent);
			        	LegendBox Legend =Graph.addLegend(Graph_Spy.Width-100,20,true,"Arial",8);
			        	Legend.setBackground(Chart.Transparent);
			        	Legend.setFontColor(CANStreamTools.GetRGBColor(Color.White));
			        	Legend.setMaxWidth(100);
			        	
	        			//Create X axis
	        			double TMin = Math.Round(SpyGraphSeries.GetMinTimeSampleOverAll(), 1);
	        			double TMax = Math.Round(SpyGraphSeries.GetMaxTimeSampleOverAll(), 1);
	        			
	        			if((TMax-TMin)<(SpyGraphSeries.BufferSize*SPY_GRID_UPDATE_PERIOD)/1000)
	        			{
	        				TMax=TMin+((SpyGraphSeries.BufferSize*SPY_GRID_UPDATE_PERIOD)/1000);
	        			}
	        			
	        			double TStep=(TMax-TMin)/10;
	        			
		        		Axis AxeX=Graph.xAxis();
		        		AxeX.setLinearScale(TMin,TMax,TStep);
		        		AxeX.setRounding(true, true);
		        		AxeX.setColors(CANStreamTools.GetRGBColor(Color.White),
		        		               CANStreamTools.GetRGBColor(Color.White),
		        		               CANStreamTools.GetRGBColor(Color.White),
		        		               CANStreamTools.GetRGBColor(Color.White));
		        		
		        		
		        		
		        		//Set Y Axis
		        		Axis AxeY=Graph.yAxis();
		        		AxeY.setColors(CANStreamTools.GetRGBColor(Color.White),
		        		               CANStreamTools.GetRGBColor(Color.White),
		        		               CANStreamTools.GetRGBColor(Color.White),
		        		               CANStreamTools.GetRGBColor(Color.White));
		        		
		        		if(!SpyGraphAutoScale)
		        		{
		        			if(SpyGraphYMin < SpyGraphYMax)
		        			{
		        				double YStep=(SpyGraphYMax-SpyGraphYMin)/10;
		        				AxeY.setLinearScale(SpyGraphYMin,SpyGraphYMax,YStep);
		        			}
		        		}
		        		
		        		//Create series
		        		foreach(RT_FormatedGraphSerie oSerie in SpyGraphSeries.RTSeries)
		        		{
		        			if(oSerie.Visible)
		        			{
		        				LineLayer Layer=Graph.addLineLayer();
		        				
		        				Layer.addDataSet(oSerie.Get_PlotBuffer(RT_FormatedGraphSerie.BufferName.YValue)
		        				                 ,CANStreamTools.GetRandomColor()
		        				                 ,oSerie.Name);
		        				
		        				Layer.setXData(oSerie.Get_PlotBuffer(RT_FormatedGraphSerie.BufferName.XValue));
	        					Layer.setLineWidth(2);
		        			}
		        		}
		        		
		        		Graph_Spy.Image=Graph.makeImage();
	        		}
	        	}
        	}
        }
		
		private void SetSpyGraphSeriesVisibility()
        {
        	for(int i=0; i<ChkLst_ChannelSel.Items.Count;i++)
        	{
        		if(ChkLst_ChannelSel.GetItemChecked(i))
        		{
        			SpyGraphSeries.SetSerieVisible(ChkLst_ChannelSel.Items[i].ToString(),true);
        		}
        	}
        }
		
		private void FilterSpyGraphSeries()
		{
			string sFilter = (string)ChkLst_ChannelSel.Tag;
			
			ChkLst_ChannelSel.Items.Clear();
			
			foreach (string sChan in SpyGraphChannelList)
			{
				if ((sFilter.Equals("")) || (sChan.ToLower().Contains(sFilter.ToLower())))
				{
					ChkLst_ChannelSel.Items.Add(sChan, false);
				}
			}
		}
		
		private void FireControllerSpyRunningChangedEvent(bool bRunning)
		{
			ControllerRunningChangedEventArgs Args = new ControllerRunningChangedEventArgs();
			Args.Running = bRunning;
			OnControllerSpyRunningChanged(Args);
		}

        #region Spy data history

        private void FreezeSpyDataHistory()
        {
            bDataHistoryFrozen = true;

            TSB_ResumeHistory.Visible = true;
            TSB_FreezeHistory.Visible = false;
        }

        private void ResumeSpyDataHistory()
        {
            bDataHistoryFrozen = false;
            
            TSB_ResumeHistory.Visible = false;
            TSB_FreezeHistory.Visible = true;
        }

        private void ClearSpyDataHistory()
        {
            DialogResult Rep = MessageBox.Show("Do you really want clear the message history ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (Rep == DialogResult.Yes)
            {
                Lst_SpyDataHistory.Items.Clear();
            }
        }

        private void ExprtSpyDataHistory()
        {
            if (Lst_SpyDataHistory.Items.Count > 0)
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Text file|*.txt";
                saveFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Records";

                if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
                {
                    if (File.Exists(saveFileDialog1.FileName)) File.Delete(saveFileDialog1.FileName);

                    StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);

                    for (int i = 0; i < Lst_SpyDataHistory.Items.Count; i++)
                    {
                        sw.WriteLine(Lst_SpyDataHistory.Items[i].ToString());
                    }
                    
                    sw.Close();
                    sw.Dispose();
                }
            }
        }

        private void CheckIdFilter(ToolStripTextBox TxtBox)
        {
            uint Id = 0;
            bool NoErr = true;

            if (uint.TryParse(TxtBox.Text, out Id))
            {
                if (Id >= 0x0 && Id <= 0x3ff)
                {
                    if (TxtBox.Equals(TSTxt_IdFilterFrom))
                    {
                        if (!(Id < Convert.ToUInt32(TSTxt_IdFilterTo.Tag)))
                        {
                            MessageBox.Show("Identifier value must be smaller than upper bound identifier !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            NoErr = false;
                        }
                    }
                    else if (TxtBox.Equals(TSTxt_IdFilterTo))
                    {
                        if (!(Id > (uint)TSTxt_IdFilterFrom.Tag))
                        {
                            MessageBox.Show("Identifier value must be smaller than upper bound identifier !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            NoErr = false;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Identifier value must be contained between 0x000 and 0x3FF !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    NoErr = false;
                }
            }
            else
            {
                MessageBox.Show("Identifier value must be a hexadecimal value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                NoErr = false;
            }

            if (NoErr)
            {
                TxtBox.Tag = Id;
            }
            else
            {
                TxtBox.Text = string.Format("{0:x3}", TxtBox.Tag).ToUpper();
            }
        }

        #endregion

        #endregion

        #region Common Manual & Spy

        private void ResetManualSpyGrids()
        {
        	Grid_CANData.Rows.Clear();
        	Manual_SpyDataViewer.Clear_RawGrid();
        	Manual_SpyDataViewer.Clear_EngGrid();
        }
        
		#endregion
		
		#region CAN Trace recording management
		
		private void MoveTrcFiles()
        {
			//Move the PCAN trace file from the recording folder (exe path) to the stack folder (...\User\Records\Stack)
        	
			string ControllerName = GetPCAN_BusName(m_PcanHandle);
			
        	//Check if ...\User\Record\Stack folder exist, if no create the missing part of structure
        	CANStreamTools.CreateFolderIfItDoesNotExist(CANStreamTools.MyDocumentPath + CANStreamConstants.StackDirectory);
        	
        	//Create Event/Session folders if they doesn't exist and update Event/Session informations xml files
        	string DestFolder = CreateRecordSessionFolder(CreateRecordEventFolder(CANStreamTools.MyDocumentPath + CANStreamConstants.StackDirectory));
        	
        	//Move all *.trc files into \User\Record\Stack folder
        	DirectoryInfo oMyDocFolder = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
        	FileInfo[] oTrcFiles = oMyDocFolder.GetFiles("*.trc");
        	
        	if(oTrcFiles.Length>0)
        	{
        		for(int iTrc=0;iTrc<oTrcFiles.Length;iTrc++)
        		{
        			if (oTrcFiles[iTrc].Name.Contains(ControllerName)) //Move only trc files of the current controller
        			{
        				oTrcFiles[iTrc].MoveTo(DestFolder + "\\" + oTrcFiles[iTrc].Name);
        			}
        		}
        	}
        	
        	//Convert records if automatic conversion enabled
        	if (bConversionAuto & !HostForm.IsTraceConversionRunning())
        	{
        		CANStreamTools.TraceConversionOptions.TrcFileList = null;
        		CANStreamTools.TraceConversionOptions.CanConfiguration = oCanConfig;
        		HostForm.LaunchConvertRecords();
        	}
        }
				
		#region Recording Event/Session management
		
		#region Recording Events
		
		private string CreateRecordEventFolder(string RootFolder)
        {
        	string EventDirectoryPath = RootFolder + "\\" + oRecordEvent.Name;
        	string EventInfoFilePath = EventDirectoryPath + "\\EventDetails.xml";
        	
        	if (!(Directory.Exists(EventDirectoryPath))) Directory.CreateDirectory(EventDirectoryPath);
        	if (File.Exists(EventInfoFilePath)) File.Delete(EventInfoFilePath);
        	
        	oRecordEvent.Write_RecordEventInformationFile(EventInfoFilePath);
        	
        	return(EventDirectoryPath);
        }
		
		#endregion
		
		#region Recording Sessions
		
		private string CreateRecordSessionFolder(string RootFolder)
        {
        	string SessionDirectoryPath = RootFolder + "\\" + oRecordEvent.CurrentSession.Name;
        	string SessionInfoFilePath = SessionDirectoryPath + "\\SessionDetails.xml";
        	
        	if (!(Directory.Exists(SessionDirectoryPath))) Directory.CreateDirectory(SessionDirectoryPath);
        	if (File.Exists(SessionInfoFilePath)) File.Delete(SessionInfoFilePath);
        	
        	oRecordEvent.CurrentSession.Write_RecordSessionInformationFile(SessionInfoFilePath);
        	
        	return(SessionDirectoryPath);
        }
		
		#endregion
		
		#endregion
		
		#endregion
		
		#region Virtual channel management
        
        private void ShowVirtualChannelValues()
        {
        	foreach(CS_VirtualChannelsLibrary oLib in VCLibCollection.Libraries)
        	{
        		foreach(CS_VirtualChannel oChan in oLib.Channels)
        		{
        			if (oChan.bNewValue && oChan.bComputed)
        			{
	        			oChan.bNewValue=false;
	        			
	        			string[] ChanData = {
	        									"Virtual",
	        									oChan.Name,
	        									oChan.Expression,
	        									oChan.Value.ToString(),
	        									oChan.Unit,
	        									oChan.Comment,
	        								};
	        			
	        			CurrentSpyViewer.Update_VirtualChannelValue(ChanData);
	        			
	        			if (!(ChkLst_ChannelSel.Items.Contains(oChan.Name)))
        				{
	        				SpyGraphChannelList.Add(oChan.Name);
        				}
        			}
        			
        			//Add Spy graphic sample
        			if (!oChan.InError)
        			{
    					if(bSpyGraphEnabled & oChan.Value.GetType().Equals(typeof(double)))
						{
							TimeSpan TSample=DateTime.Now.Subtract(TStartSpy);
							SpyGraphSeries.AddSerieSamples(oChan.Name,TSample.TotalSeconds,oChan.Value);
						}
        			}
        		}
        		
        		FilterSpyGraphSeries();
        	}
        }
        
        #endregion
		
		#region Misc
				
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
		
		private string Get_ConfigBackupFileName()
		{
			string FinalName = "";
			string BaseName = CANStreamTools.CsDataPath + "\\CanConfigBackUp_";
			int Index = 1;
			
			do
			{
				FinalName = BaseName + Index.ToString("D2") + ".xcc";
				Index++;
			}
			while (File.Exists(FinalName));
			
			return(FinalName);
		}
		
		private void FireLayoutChangedEvent()
		{
			ControllerLayoutChangedEventArgs Args = new ControllerLayoutChangedEventArgs();
			
			Args.Manual_Tx_Panel_Visible = !Split_RxTx.Panel1Collapsed;
			
				Args.Manual_Tx_Panel_Eng_Visible = !Split_Tx_EngRaw.Panel1Collapsed;
				Args.Manual_Tx_Panel_Raw_Visible = !Split_Tx_EngRaw.Panel2Collapsed;
			
			Args.Manual_Rx_Panel_Visible = !Split_RxTx.Panel2Collapsed;
			
				Args.Manual_Rx_Panel_Data_Visible = !Split_Rx_DataGraph.Panel1Collapsed;
				
					Args.Manual_Rx_Panel_Data_Eng_Visible = Manual_SpyDataViewer.EngDataGridVisible;
					Args.Manual_Rx_Panel_Data_Raw_Visible = Manual_SpyDataViewer.RawDataGridVisible;
				
				Args.Manual_Rx_Panel_Graph_Visible = !Split_Rx_DataGraph.Panel2Collapsed;
				
			Args.Cycle_Panel_Data_Visible = !Split_Cycle_VirtualSig_Graph.Panel1Collapsed;
			
				Args.Cycle_Panel_Data_Eng_Visible = Cycle_SpyDataViewer.EngDataGridVisible;
				Args.Cycle_Panel_Data_Raw_Visible = Cycle_SpyDataViewer.RawDataGridVisible;
			
			Args.Cycle_Panel_Graph_Visible = !Split_Cycle_VirtualSig_Graph.Panel2Collapsed;
			
			OnControllerLayoutChanged(Args);
		}
		
		private void FireControllerGridColumnsChangedEvent(CANControllerGrid CurrentGrid, object ColsVisible)
		{
			ControllerGridColumnsChangedEventArgs Args = new ControllerGridColumnsChangedEventArgs();
			Args.Grid = CurrentGrid;
			Args.ColumnsVisible = ColsVisible;
			OnControllerGridColumnsChanged(Args);
		}
		
		#endregion
		
		#endregion
		
		#region Events handling methods
		
		protected virtual void OnControllerModeChanged(ControllerModeChangedEventArgs e)
		{
			EventHandler<ControllerModeChangedEventArgs> Handler = ControllerModeChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerCanConfigChanged(ControllerCANConfigChangedEventArgs e)
		{
			EventHandler<ControllerCANConfigChangedEventArgs> Handler = ControllerCanConfigChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerConnectionStatusChanged(ControllerConnectionStatusChangedEventArgs e)
		{
			EventHandler<ControllerConnectionStatusChangedEventArgs> Handler = ControllerConnectionStatusChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerCycleLoaded(EventArgs e)
		{
			EventHandler<EventArgs> Handler = ControllerCycleLoaded;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerCycleStartEndSetting(ControllerCycleStartEndSettingEventArgs e)
		{
			EventHandler<ControllerCycleStartEndSettingEventArgs> Hander = ControllerCycleStartEndSetting;
			if (Hander != null)
			{
				Hander(this, e);
			}
		}
		
		protected virtual void OnControllerCycleRunningChanged(ControllerRunningChangedEventArgs e)
		{
			EventHandler<ControllerRunningChangedEventArgs> Handler = ControllerCycleRunningChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerManualRunningChanged(ControllerRunningChangedEventArgs e)
		{
			EventHandler<ControllerRunningChangedEventArgs> Handler = ControllerManualRunningChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerSpyRunningChanged(ControllerRunningChangedEventArgs e)
		{
			EventHandler<ControllerRunningChangedEventArgs> Handler = ControllerSpyRunningChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
				
		protected virtual void OnControllerLayoutChanged(ControllerLayoutChangedEventArgs e)
		{
			EventHandler<ControllerLayoutChangedEventArgs> Handler = ControllerLayoutChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerGridColumnsChanged(ControllerGridColumnsChangedEventArgs e)
		{
			EventHandler<ControllerGridColumnsChangedEventArgs> Handler = ControllerGridColumnsChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		protected virtual void OnControllerDiagChanged(ControllerDiagChangedEventArgs e)
		{
			EventHandler<ControllerDiagChangedEventArgs> Handler = ControllerDiagChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		#endregion
		
		#region Public methodes
		
		#region CAN Configuration
		
		public CANMessagesConfiguration Get_BusCANConfiguration()
		{
			return(oCanConfig);
		}
		
		public void Set_BusCANConfiguration(CANMessagesConfiguration oCANCfg)
		{
			if (!(oCANCfg == null))
			{
				UpDateCANConfig(oCANCfg);
				UpDateConnectionStatus();
				
				string TmpBackUpConfigPath = Get_ConfigBackupFileName();
				oCANCfg.WriteCANConfigurationFile(TmpBackUpConfigPath, false);
				
				ManualCanConfigFilePath = TmpBackUpConfigPath;
			}
		}
		
		#endregion
		
		#region Cycle Management
		
		public void Set_Cycle(CANStreamCycle CycleToSet)
		{
			if (!(CycleToSet == null))
			{
				oCycle = CycleToSet;
				
				Lbl_CycleFile.Text="Cycle file: " + oCycle.Name;
				rTxt_CycleComments.Text=oCycle.Comment;
				
				if (!(oCycle.oCanNodesMap == null))
				{
					if (UpDateCANConfig(oCycle.oCanNodesMap))
					{
						Lbl_CanConfig.Text = "CAN Configuration: " + oCycle.oCanNodesMap.Name;
        				
						//Create virtual parmaters messages list
						TxEngMessages = new List<CANMessageEncoded>();
						foreach (CANMessage oMsg in oCycle.oCanNodesMap.Messages)
						{
							if (oMsg.RxTx.Equals(CanMsgRxTx.Tx) && oMsg.ContainsVirtualParameters())
							{
								CANMessageEncoded oEncodMsg = new CANMessageEncoded(oMsg.Clone(), oCycle.oCanNodesMap.MessageLength/8);
								oEncodMsg.Parameters.Clear();
								
								foreach (CANParameter oParam in oMsg.Parameters)
								{
									if (oParam.IsVirtual)
									{
										oEncodMsg.Parameters.Add(oParam.Clone());
									}
								}
								
								TxEngMessages.Add(oEncodMsg);
							}
						}
						
						oCycle.CreateGraphicSeries();
						if (oCycle.GraphSeries.Series.Count > 0)
						{
							PlotCycle();
						}
						else
						{
							MessageBox.Show("Cycle does contain data but they cannot be plotted since no cycle message identifier match with the embedded CAN configuration identifiers.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
						}
							
						bCycleStartEndTxtSetting = true;
						Txt_CycleStart.Text = Math.Round((double)(oCycle.TimeEvents[0].TimeEvent) / 1000,3).ToString();
						Txt_CycleEnd.Text = Math.Round((double)(oCycle.TimeEvents[oCycle.TimeEvents.Count - 1].TimeEvent) / 1000,3).ToString();
						bCycleStartEndTxtSetting = false;
						
						//HostForm.ActiveControllerCycleLoaded();
						
						//ControllerCycleLoaded event firing
						OnControllerCycleLoaded(new EventArgs());
							
					}
				}
				else
				{
					MessageBox.Show("No CAN mapping embedded into the cycle ! Cycle loading abort.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
		}
		
		public void Set_CycleStartingPoint()
        {
        	bCycleStartSet=true;
        	Set_OldCycleStartEndPoint();
        	
        	//Menu strip item status updating
        	FireControllerCycleStartEndSettingEvent(0);
        	
        	//Context_CycleGraph items status updating
        	Context_CycleGraph.Items[0].Visible = false;		//Set starting point
        	Context_CycleGraph.Items[1].Visible = false;		//Set ending point
        	Context_CycleGraph.Items[2].Visible = true;			//Confirm start/end points
        	Context_CycleGraph.Items[3].Visible = true;			//Cancel start/end points
        }
        
        public void Set_CycleEndingPoint()
        {
        	bCycleEndSet = true;
        	Set_OldCycleStartEndPoint();

        	//Menu strip item status updating
        	FireControllerCycleStartEndSettingEvent(0);
        	
        	//Context_CycleGraph items status updating
        	Context_CycleGraph.Items[0].Visible = false;		//Set starting point
        	Context_CycleGraph.Items[1].Visible = false;		//Set ending point
        	Context_CycleGraph.Items[2].Visible = true;			//Confirm start/end points
        	Context_CycleGraph.Items[3].Visible = true;			//Cancel start/end points
        }
        
        public void Confirm_CycleStartEndPoints()
        {
        	bCycleStartSet = false;
        	bCycleEndSet = false;
        	
        	//Menu strip item status updating
        	FireControllerCycleStartEndSettingEvent(1);
        	
        	//Context_CycleGraph items status updating
        	Context_CycleGraph.Items[0].Visible = true;			//Set starting point
        	Context_CycleGraph.Items[1].Visible = true;			//Set ending point
        	Context_CycleGraph.Items[2].Visible = false;		//Confirm start/end points
        	Context_CycleGraph.Items[3].Visible = false;		//Cancel start/end points
        }
        
        public void Cancel_CycleStartEndPoints()
        {
        	bCycleStartSet = false;
        	bCycleEndSet = false;
        	
        	bCycleStartEndTxtSetting = true;
        	Txt_CycleStart.Text = Math.Round(TCycleStart_Old, 3).ToString();
        	Txt_CycleEnd.Text = Math.Round(TCycleEnd_Old, 3).ToString();
        	bCycleStartEndTxtSetting = false;
        	
        	PlotCycle(false, -1, TCycleStart_Old, TCycleEnd_Old);
        	
        	//Menu strip item status updating
        	FireControllerCycleStartEndSettingEvent(1);
        	
        	//Context_CycleGraph items status updating
        	Context_CycleGraph.Items[0].Visible = true;			//Set starting point
        	Context_CycleGraph.Items[1].Visible = true;			//Set ending point
        	Context_CycleGraph.Items[2].Visible = false;		//Confirm start/end points
        	Context_CycleGraph.Items[3].Visible = false;		//Cancel start/end points
        }
		
        public bool IsCycleWorkerBusy()
        {
        	return(BGWrk_Cycle.IsBusy);
        }
        
		#endregion
		
		#region Manual control management
		
		public int Get_Grid_CANDataRowsCount()
		{
			return (Grid_CANData.Rows.Count);
		}
		
		public bool IsManualWorkerBusy()
		{
			return(BGWrk_Manual.IsBusy);
		}
		
		#region Manual raw messages
		
		public void Add_RawMessage()
		{
			CAN_RawMessageData oMsg = new CAN_RawMessageData();
			
			oMsg.KeyId = NextRawMessageKeyId;
			NextRawMessageKeyId++;
			
			if (TxRawMessages == null) TxRawMessages = new CAN_RawMessageList();
			TxRawMessages.Messages.Add(oMsg);
			
			Grid_CANRawData.Rows.Add();
			
			Show_RawMessage(oMsg, Grid_CANRawData.Rows.Count - 1);
		}
		
		public void Del_RawMessage()
		{
			if (!(Grid_CANRawData.SelectedCells == null))
			{
				if (!(TxRawMessages == null))
				{
					int Key = (int)Grid_CANRawData.Rows[Grid_CANRawData.SelectedCells[0].RowIndex].Tag;
					CAN_RawMessageData oMsg = TxRawMessages.Get_RawMessageAtKeyId(Key);
					
					if (!(oMsg == null))
					{
						UInt32 MsgId = oMsg.MessageId;
						TxRawMessages.Messages.Remove(oMsg);
						Show_MessageParametersRows (string.Format("{0:x}", MsgId));
					}
				}
				
				Grid_CANRawData.Rows.RemoveAt(Grid_CANRawData.SelectedCells[0].RowIndex);
			}
		}
		
		public void Clear_RawMessages()
		{
			DialogResult Rep = MessageBox.Show("Do you really want to delete all raw messages ?", Application.ProductName,MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			
			if (Rep.Equals(DialogResult.Yes))
			{
				Grid_CANRawData.Rows.Clear();
				TxRawMessages = null;
				NextRawMessageKeyId = 0;
				ShowManualCanConfig();
			}
		}
		
		public void Save_RawMessages()
		{
			if (!(TxRawMessages == null))
			{
				if (TxRawMessages.Messages.Count > 0)
				{
					saveFileDialog1.FileName = "";
					saveFileDialog1.Filter = "Raw message data file|*.rmd";
					saveFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
					
					if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
					{
						TxRawMessages.Save_RawMessagesList(saveFileDialog1.FileName);
					}
				}
			}
		}
		
		public void Open_RawMessages()
		{
			openFileDialog1.FileName = "";
			openFileDialog1.Filter = "Raw message data file|*.rmd";
			openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
			
			if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
			{
				TxRawMessages = new CAN_RawMessageList();
				NextRawMessageKeyId = 0;
				
				Grid_CANRawData.Rows.Clear();
				
				if (TxRawMessages.Load_RawMessagesList(openFileDialog1.FileName))
				{
					foreach (CAN_RawMessageData oRawMsg in TxRawMessages.Messages)
					{
						if (!(TxEngMessagesContainsId(oRawMsg.MessageId)))
						{
							oRawMsg.KeyId = NextRawMessageKeyId;
							NextRawMessageKeyId++;
							
							Grid_CANRawData.Rows.Add();
							Show_RawMessage(oRawMsg, Grid_CANRawData.Rows.Count - 1);
						}
						else
						{
							oRawMsg.Send = false;
							MessageBox.Show("Message identifier 0x" + string.Format("{0:x3}", oRawMsg.MessageId) + " is already present in the CAN configuration loaded !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
				}
				else
				{
					MessageBox.Show("Raw message data file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		
		#endregion
		
		#endregion
		
		#region Spy control management
		
		public bool IsSpyWorkerBusy()
		{
			return(BGWrk_Spy.IsBusy);
		}
		
		#endregion
		
		#region Common Manual & Spy
		
		public void HideActiveRow()
        {
			if (Manual_SpyDataViewer.ContainsFocus)
			{
				Manual_SpyDataViewer.HideActiveRow();
			}
			else if (Cycle_SpyDataViewer.ContainsFocus)
			{
				Cycle_SpyDataViewer.HideActiveRow();
			}
			else if (Grid_CANData.ContainsFocus)
			{
				if (Grid_CANData.CurrentCell != null)
				{
					Grid_CANData.Rows[Grid_CANData.CurrentCell.RowIndex].Visible = false;
				}
			}
        }
		
		public void ShowHiddenRows()
        {
			if (Manual_SpyDataViewer.ContainsFocus)
			{
				Manual_SpyDataViewer.ShowHiddenRows();
			}
			else if (Cycle_SpyDataViewer.ContainsFocus)
			{
				Cycle_SpyDataViewer.ShowHiddenRows();
			}
			else if (Grid_CANData.ContainsFocus)
			{
				foreach (DataGridViewRow oRow in Grid_CANData.Rows)
				{
					if (!oRow.Visible)
					{
						oRow.Visible = true;
					}
				}
			}
        }
		
		#endregion
		
		#region CAN Trace recording management
		
		public void StartRecording()
        {
        	UInt32 iBuffer=(uint)PCANBasic.PCAN_PARAMETER_ON;
        	TPCANStatus stsResult=PCANBasic.SetValue(m_PcanHandle,TPCANParameter.PCAN_TRACE_STATUS,ref iBuffer,sizeof(UInt32));
        	
        	if(stsResult==TPCANStatus.PCAN_ERROR_OK)
        	{
	        	bRecording=true;
        		
        		TSB_StartCANTraceRecording.Enabled=false;
	        	TSB_StopCANTraceRecording.Enabled=true;
        	}
        	else
        	{
        		FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
        		MessageBox.Show("PCANBasic error during the stream recording activation !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
        	}
        }
		
		public void StopRecording()
		{
			UInt32 iBuffer=(uint)PCANBasic.PCAN_PARAMETER_OFF;
			TPCANStatus stsResult=PCANBasic.SetValue(m_PcanHandle,TPCANParameter.PCAN_TRACE_STATUS,ref iBuffer,sizeof(UInt32));
			
			if(stsResult==TPCANStatus.PCAN_ERROR_OK)
			{
				bRecording=false;
				
				TSB_StartCANTraceRecording.Enabled=true;
				TSB_StopCANTraceRecording.Enabled=false;
				
				MoveTrcFiles();
			}
			else
			{
				FireControllerDiagChangedEvent(stsResult, (int)this.Tag);
				MessageBox.Show("PCANBasic error during the stream recording desactivation !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
		}
		
		#endregion
		
		#region Virtual channel management
		
		public void Load_VC_LibrariesCollection()
		{
			VCLibCollection = new CS_VCLibrariesCollection();
			
			if (File.Exists(CANStreamTools.CsDataPath + "\\Libraries.xml"))
			{
				//VCLibCollection = new CS_VCLibrariesCollection();
				VCLibCollection.LoadLibrariesList(CANStreamTools.CsDataPath + "\\Libraries.xml");
			}
		}
		
		#endregion
		
		#region Layout control
		
		#region Grid columns
		
		public Manual_Grid_Columns Get_ManualGridColumnsVisible()
		{
			return(ManualGridColumnsVisible);
		}
		
		public void Set_ManualGridColumnsVisible(Manual_Grid_Columns eColumnsVisible)
		{
			ManualGridColumnsVisible = eColumnsVisible;
			
			Grid_CANData.Columns[0].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_ID);
			Grid_CANData.Columns[1].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_RxTx);
			Grid_CANData.Columns[2].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Period);
			Grid_CANData.Columns[3].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_MuxValue);
			//Column 4:  Parameter name => Always visible
			Grid_CANData.Columns[5].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Start);
			Grid_CANData.Columns[6].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Length);
			Grid_CANData.Columns[7].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Endianess);
			Grid_CANData.Columns[8].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Signedness);
			Grid_CANData.Columns[9].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Gain);
			Grid_CANData.Columns[10].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Zero);
			//Column 11: Parameter value => Always visible
			Grid_CANData.Columns[12].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Unit);
			Grid_CANData.Columns[13].Visible =  ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Comment);
			
			ResizeGridColumns(Grid_CANData, GRID_ENG_MANUAL_FILLER_COL);
			
			Context_Manual_iDToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_ID);
			Context_Manual_rxTxToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_RxTx);
			Context_Manual_periodToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Period);
			Context_Manual_muxValueToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_MuxValue);
			Context_Manual_startToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Start);
			Context_Manual_lengthToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Length);
			Context_Manual_endianessToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Endianess);
			Context_Manual_signedToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Signedness);
			Context_Manual_gainToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Gain);
			Context_Manual_zeroToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Zero);
			Context_Manual_unitToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Unit);
			Context_Manual_commentToolStripMenuItem.Checked = ManualGridColumnsVisible.HasFlag(Manual_Grid_Columns.Column_Comment);
			
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_Manual, (object)ManualGridColumnsVisible);
		}
		
		public SpyRaw_Grid_Columns Get_SpyRawGridColumnsVisible()
		{
			return(Manual_SpyDataViewer.RawGridColumnsVisible);
		}
		
		public void Set_SpyRawGridColumnsVisible(SpyRaw_Grid_Columns eColumnsVisible)
		{
			Manual_SpyDataViewer.RawGridColumnsVisible = eColumnsVisible;
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_SpyRaw, (object)eColumnsVisible);
		}
		
		public SpyEngineering_Grid_Columns Get_SpyEngGridColumnsVisible()
		{
			return(Manual_SpyDataViewer.EngineeringGridColumnsVisible);
		}
		
		public void Set_SpyEngGridColumnsVisible(SpyEngineering_Grid_Columns eColumnsVisible)
		{
			Manual_SpyDataViewer.EngineeringGridColumnsVisible = eColumnsVisible;
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_SpyEng, (object)eColumnsVisible);
		}
		
		public SpyRaw_Grid_Columns Get_CycleRawGridColumnsVisible()
		{
			return(Cycle_SpyDataViewer.RawGridColumnsVisible);
		}
		
		public void Set_CycleRawGridColumnsVisible(SpyRaw_Grid_Columns eColumnsVisible)
		{
			Cycle_SpyDataViewer.RawGridColumnsVisible = eColumnsVisible;
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_Cycle_Raw, (object)eColumnsVisible);
		}
		
		public SpyEngineering_Grid_Columns Get_CycleEngGridColumnsVisible()
		{
			return(Cycle_SpyDataViewer.EngineeringGridColumnsVisible);
		}
		
		public void Set_CycleEngGridColumnsVisible(SpyEngineering_Grid_Columns eColumnsVisible)
		{
			Cycle_SpyDataViewer.EngineeringGridColumnsVisible = eColumnsVisible;
			FireControllerGridColumnsChangedEvent(CANControllerGrid.Grid_Cycle_Eng, (object)eColumnsVisible);
		}
		
		#endregion
		
		#region View
		
		#region Manual and spy
		
		public void Switch_Manual_Tx_Panel()
		{
			Split_RxTx.Panel1Collapsed = !Split_RxTx.Panel1Collapsed;
			TSMI_TxMessages.Checked  = !Split_RxTx.Panel1Collapsed;
			TSMI_RxMessages.Checked = !Split_RxTx.Panel2Collapsed;
			FireLayoutChangedEvent();
		}
		
		#region Messages Tx
		
		public void Switch_Manual_Tx_Eng_Panel()
		{
			Split_Tx_EngRaw.Panel1Collapsed = !Split_Tx_EngRaw.Panel1Collapsed;
			TSMI_TxMessages_Eng.Checked = !Split_Tx_EngRaw.Panel1Collapsed;
			TSMI_TxMessages_Raw.Checked = !Split_Tx_EngRaw.Panel2Collapsed;
			FireLayoutChangedEvent();
		}
		
		public void Switch_Manual_Tx_Raw_Panel()
		{
			Split_Tx_EngRaw.Panel2Collapsed = !Split_Tx_EngRaw.Panel2Collapsed;
			TSMI_TxMessages_Raw.Checked = !Split_Tx_EngRaw.Panel2Collapsed;
			TSMI_TxMessages_Eng.Checked = !Split_Tx_EngRaw.Panel1Collapsed;
			FireLayoutChangedEvent();
		}
		
		#endregion
		
		public void Switch_Manual_Rx_Panel()
		{
			Split_RxTx.Panel2Collapsed = !Split_RxTx.Panel2Collapsed;
			TSMI_TxMessages.Checked  = !Split_RxTx.Panel1Collapsed;
			TSMI_RxMessages.Checked = !Split_RxTx.Panel2Collapsed;
			FireLayoutChangedEvent();
		}
		
		#region Messages Rx
		
		public void Switch_Manual_Rx_Data_Panel()
		{
			Split_Rx_DataGraph.Panel1Collapsed = !Split_Rx_DataGraph.Panel1Collapsed;
			TSMI_RxMessages_Data.Checked = !Split_Rx_DataGraph.Panel1Collapsed;
			TSMI_RxMessages_Graph.Checked = !Split_Rx_DataGraph.Panel2Collapsed;
			FireLayoutChangedEvent();
		}
		
		#region Message Rx Data
		
		public void Switch_Manual_Rx_Data_Eng_Panel()
		{
			Manual_SpyDataViewer.EngDataGridVisible = !Manual_SpyDataViewer.EngDataGridVisible;
			TSMI_RxMsg_Data_Eng.Checked = Manual_SpyDataViewer.EngDataGridVisible;
			TSMI_RxMsg_Data_Raw.Checked = Manual_SpyDataViewer.RawDataGridVisible;
			FireLayoutChangedEvent();
		}
		
		public void Switch_Manual_Rx_Data_Raw_Panel()
		{
			Manual_SpyDataViewer.RawDataGridVisible = !Manual_SpyDataViewer.RawDataGridVisible;
			TSMI_RxMsg_Data_Raw.Checked = Manual_SpyDataViewer.RawDataGridVisible;
			TSMI_RxMsg_Data_Eng.Checked = Manual_SpyDataViewer.EngDataGridVisible;
			FireLayoutChangedEvent();
		}
		
		#endregion
		
		public void Switch_Manual_Rx_Graph_Panel()
		{
			Split_Rx_DataGraph.Panel2Collapsed = !Split_Rx_DataGraph.Panel2Collapsed;
			TSMI_RxMessages_Graph.Checked = !Split_Rx_DataGraph.Panel2Collapsed;
			TSMI_RxMessages_Data.Checked = !Split_Rx_DataGraph.Panel1Collapsed;
			FireLayoutChangedEvent();
		}
		
		#endregion
		
		#endregion
		
		#region Cycle
		
		public void Switch_Cycle_Data_Panel()
		{
			Split_Cycle_VirtualSig_Graph.Panel1Collapsed = !Split_Cycle_VirtualSig_Graph.Panel1Collapsed;
			TSMI_CyclePlayer_Data.Checked = !Split_Cycle_VirtualSig_Graph.Panel1Collapsed;
			TSMI_CyclePlayer_Graph.Checked = !Split_Cycle_VirtualSig_Graph.Panel2Collapsed;
			FireLayoutChangedEvent();
		}
		
		#region Cycle data
		
		public void Switch_Cycle_Data_Eng_Panel()
		{
			Cycle_SpyDataViewer.EngDataGridVisible =  !Cycle_SpyDataViewer.EngDataGridVisible;
			TSMI_CyclePlayer_Data_Eng.Checked = Cycle_SpyDataViewer.EngDataGridVisible;
			TSMI_CyclePlayer_Data_Raw.Checked = Cycle_SpyDataViewer.RawDataGridVisible;
			FireLayoutChangedEvent();
		}
		
		public void Switch_Cycle_Data_Raw_Panel()
		{
			Cycle_SpyDataViewer.RawDataGridVisible = !Cycle_SpyDataViewer.RawDataGridVisible;
			TSMI_CyclePlayer_Data_Raw.Checked = Cycle_SpyDataViewer.RawDataGridVisible;
			TSMI_CyclePlayer_Data_Eng.Checked = Cycle_SpyDataViewer.EngDataGridVisible;
			FireLayoutChangedEvent();
		}
		
		#endregion
		
		public void Switch_Cycle_Graph_Panel()
		{
			Split_Cycle_VirtualSig_Graph.Panel2Collapsed = !Split_Cycle_VirtualSig_Graph.Panel2Collapsed;
			TSMI_CyclePlayer_Graph.Checked = !Split_Cycle_VirtualSig_Graph.Panel2Collapsed;
			TSMI_CyclePlayer_Data.Checked = !Split_Cycle_VirtualSig_Graph.Panel1Collapsed;
			FireLayoutChangedEvent();
		}
		
		#endregion
				
		#endregion
		
		public void SetControllerLayout(Ctrl_CS_CAN_Bus_Layout oLayout)
		{
			Split_RxTx.Panel1Collapsed = !oLayout.TxPanelVisible;
			Split_Tx_EngRaw.Panel1Collapsed = !oLayout.EngDataTxPanelVisible;
			Split_Tx_EngRaw.Panel2Collapsed = !oLayout.RawDataTxPanelVisible;
			Set_ManualGridColumnsVisible(oLayout.eEngDataTxColumns);
			
			Split_RxTx.Panel2Collapsed = !oLayout.RxPanelVisible;
			Split_Rx_DataGraph.Panel1Collapsed = !oLayout.DataRxPanelVisible;
			Manual_SpyDataViewer.RawDataGridVisible = oLayout.RawDataRxPanelVisible;
			Manual_SpyDataViewer.EngDataGridVisible = oLayout.EngDataRxPanelVisible;
			Split_Rx_DataGraph.Panel2Collapsed = !oLayout.GraphRxPanelVisible;
			Set_SpyRawGridColumnsVisible(oLayout.eRawDataRxColumns);
			Set_SpyEngGridColumnsVisible(oLayout.eEngDataRxColumns);
						
			Split_Cycle_VirtualSig_Graph.Panel1Collapsed = !oLayout.Cycle_DataPanelVisible;
			Split_Cycle_VirtualSig_Graph.Panel2Collapsed = !oLayout.Cycle_GraphPanelVisible;
			Cycle_SpyDataViewer.RawDataGridVisible = oLayout.Cycle_RawDataPanelVisible;
			Cycle_SpyDataViewer.EngDataGridVisible = oLayout.Cycle_EngDataPanelVisible;
			Set_CycleRawGridColumnsVisible(oLayout.eCycleRawDataColumns);
			Set_CycleEngGridColumnsVisible(oLayout.eCycleEngDataColumns);
			
			Split_RxTx.SplitterDistance = oLayout.Pos_Split_RxTx;
			Split_Tx_EngRaw.SplitterDistance = oLayout.Pos_Split_Tx_EngRaw;
			Split_Rx_DataGraph.SplitterDistance = oLayout.Pos_Split_Rx_DataGraph;
			Manual_SpyDataViewer.GridSplitterDistance = oLayout.Pos_Split_RxData_RawEng;
			
			tabControl1.SelectedIndex = 1;
			
			Split_Cycle_VirtualSig_Graph.SplitterDistance = oLayout.Pos_Split_CycleDataGraph;
			Cycle_SpyDataViewer.GridSplitterDistance = oLayout.Pos_Split_CycleData_RawEng;
			
			tabControl1.SelectedIndex = 0;
			
			TSMI_TxMessages.Checked = oLayout.TxPanelVisible;
			TSMI_TxMessages_Eng.Checked = oLayout.EngDataTxPanelVisible;
			TSMI_TxMessages_Raw.Checked = oLayout.RawDataTxPanelVisible;
			TSMI_RxMessages.Checked = oLayout.RxPanelVisible;
			TSMI_RxMessages_Data.Checked = oLayout.DataRxPanelVisible;
			TSMI_RxMsg_Data_Raw.Checked = oLayout.RawDataRxPanelVisible;
			TSMI_RxMsg_Data_Eng.Checked = oLayout.EngDataRxPanelVisible;
			TSMI_RxMessages_Graph.Checked = oLayout.GraphRxPanelVisible;
			TSMI_CyclePlayer_Data.Checked = oLayout.Cycle_DataPanelVisible;
			TSMI_CyclePlayer_Graph.Checked = oLayout.Cycle_GraphPanelVisible;
			TSMI_CyclePlayer_Data_Raw.Checked = oLayout.Cycle_RawDataPanelVisible;
			TSMI_CyclePlayer_Data_Eng.Checked = oLayout.Cycle_EngDataPanelVisible;
			
			FireLayoutChangedEvent();
		}
		
		public Ctrl_CS_CAN_Bus_Layout GetControllerLayout()
		{
			Ctrl_CS_CAN_Bus_Layout oLayout = new Ctrl_CS_CAN_Bus_Layout();
			
			oLayout.TxPanelVisible = !Split_RxTx.Panel1Collapsed;
			oLayout.EngDataTxPanelVisible = !Split_Tx_EngRaw.Panel1Collapsed;
			oLayout.RawDataTxPanelVisible = !Split_Tx_EngRaw.Panel2Collapsed;
			oLayout.eEngDataTxColumns = ManualGridColumnsVisible;
			
			oLayout.RxPanelVisible = !Split_RxTx.Panel2Collapsed;
			oLayout.DataRxPanelVisible = !Split_Rx_DataGraph.Panel1Collapsed;
			oLayout.RawDataRxPanelVisible = Manual_SpyDataViewer.RawDataGridVisible;
			oLayout.EngDataRxPanelVisible = Manual_SpyDataViewer.EngDataGridVisible;
			oLayout.GraphRxPanelVisible = !Split_Rx_DataGraph.Panel2Collapsed;
			oLayout.eRawDataRxColumns = Manual_SpyDataViewer.RawGridColumnsVisible;
			oLayout.eEngDataRxColumns = Manual_SpyDataViewer.EngineeringGridColumnsVisible;
			
			oLayout.Cycle_DataPanelVisible = !Split_Cycle_VirtualSig_Graph.Panel1Collapsed;
			oLayout.Cycle_GraphPanelVisible = !Split_Cycle_VirtualSig_Graph.Panel2Collapsed;
			oLayout.Cycle_RawDataPanelVisible = Cycle_SpyDataViewer.RawDataGridVisible;
			oLayout.Cycle_EngDataPanelVisible = Cycle_SpyDataViewer.EngDataGridVisible;
			oLayout.eCycleRawDataColumns = Cycle_SpyDataViewer.RawGridColumnsVisible;
			oLayout.eCycleEngDataColumns = Cycle_SpyDataViewer.EngineeringGridColumnsVisible;
			
			oLayout.Pos_Split_RxTx = Split_RxTx.SplitterDistance;
			oLayout.Pos_Split_Tx_EngRaw = Split_Tx_EngRaw.SplitterDistance;
			oLayout.Pos_Split_Rx_DataGraph = Split_Rx_DataGraph.SplitterDistance;
			oLayout.Pos_Split_RxData_RawEng = Manual_SpyDataViewer.GridSplitterDistance;
			oLayout.Pos_Split_CycleDataGraph = Split_Cycle_VirtualSig_Graph.SplitterDistance;
			oLayout.Pos_Split_CycleData_RawEng = Cycle_SpyDataViewer.GridSplitterDistance;
			
			return (oLayout);
		}
		
		public void ResetControllerLayout()
		{
			SetControllerLayout(new Ctrl_CS_CAN_Bus_Layout());
		}
		
		#endregion
		
		#region Misc
		
		public void Release_CAN_Adapter()
		{
			ReleaseCANCommunication();
		}
		
		public int Get_ActiveTabIndex()
		{
			return(int.Parse(tabControl1.SelectedTab.Tag.ToString()));
		}
		
		public void Set_ActiveTabIndex(int iTab)
		{
			if (iTab < tabControl1.TabPages.Count)
			{
				tabControl1.SelectedTab = tabControl1.TabPages[iTab];
			}
		}
		
		public void Set_CurrentRecordEvent(CS_RecordEvent oRecEvent)
		{
			if (!(oRecEvent == null))
			{
				oRecordEvent = oRecEvent;
			}
		}
		
		#endregion

		#endregion
	}
	
	#region Control custom events arguments
	
	public class ControllerModeChangedEventArgs : EventArgs
	{
		public int CurrentMode {get; set;}
	}
	
	public class ControllerCANConfigChangedEventArgs : EventArgs
	{
		public bool ConfigurationLoaded {get; set;}
	}
	
	public class ControllerConnectionStatusChangedEventArgs : EventArgs
	{
		public bool Connected {get; set;}
	}
	
	public class ControllerCycleStartEndSettingEventArgs : EventArgs
	{
		public int SettingState {get; set;}
	}
	
	public class ControllerRunningChangedEventArgs : EventArgs
	{
		public bool Running {get; set;}
	}
		
	public class ControllerLayoutChangedEventArgs : EventArgs
	{
		#region public members
		
		public bool Manual_Tx_Panel_Visible {get; set;}
		
		public bool Manual_Tx_Panel_Eng_Visible {get; set;}
		
		public bool Manual_Tx_Panel_Raw_Visible {get; set;}
		
		public bool Manual_Rx_Panel_Visible {get; set;}
		
		public bool Manual_Rx_Panel_Data_Visible {get; set;}
		
		public bool Manual_Rx_Panel_Data_Eng_Visible {get; set;}
		
		public bool Manual_Rx_Panel_Data_Raw_Visible {get; set;}
		
		public bool Manual_Rx_Panel_Graph_Visible {get; set;}
		
		public bool Cycle_Panel_Data_Visible {get; set;}
		
		public bool Cycle_Panel_Data_Eng_Visible {get; set;}
		
		public bool Cycle_Panel_Data_Raw_Visible {get; set;}
		
		public bool Cycle_Panel_Graph_Visible {get; set;}
		
		#endregion
	}
	
	public class ControllerGridColumnsChangedEventArgs : EventArgs
	{
		public CANControllerGrid Grid {get; set;}
		public object ColumnsVisible {get; set;}
	}
	
	public class ControllerDiagChangedEventArgs : EventArgs
	{
		public TPCANStatus Diag {get; set;}
		public int BusIndex {get; set;}
	}
	
	#endregion	
	
	#region Other classes
	
	public class Ctrl_CS_CAN_Bus_Layout
	{
		#region Public members
		
		public bool TxPanelVisible;
		public bool EngDataTxPanelVisible;
		public bool RawDataTxPanelVisible;
		public Manual_Grid_Columns eEngDataTxColumns;
		
		public bool RxPanelVisible;
		public bool GraphRxPanelVisible;
		public bool DataRxPanelVisible;
		public bool EngDataRxPanelVisible;
		public bool RawDataRxPanelVisible;
		public SpyRaw_Grid_Columns eRawDataRxColumns;
		public SpyEngineering_Grid_Columns eEngDataRxColumns;
		
		public bool Cycle_DataPanelVisible;
		public bool Cycle_GraphPanelVisible;
		public bool Cycle_RawDataPanelVisible;
		public bool Cycle_EngDataPanelVisible;
		public SpyRaw_Grid_Columns eCycleRawDataColumns;
		public SpyEngineering_Grid_Columns eCycleEngDataColumns;
		
		public int Pos_Split_RxTx;
		public int Pos_Split_Tx_EngRaw;
		public int Pos_Split_Rx_DataGraph;
		public int Pos_Split_RxData_RawEng;
		public int Pos_Split_CycleDataGraph;
		public int Pos_Split_CycleData_RawEng;
		
		#endregion
		
		public Ctrl_CS_CAN_Bus_Layout()
		{
			TxPanelVisible = true;
			EngDataTxPanelVisible = true;
			RawDataTxPanelVisible = true;
			eEngDataTxColumns = Manual_Grid_Columns.Default;
			
			RxPanelVisible = true;
			GraphRxPanelVisible = true;
			DataRxPanelVisible = true;
			EngDataRxPanelVisible = true;
			RawDataRxPanelVisible = true;
			eRawDataRxColumns = SpyRaw_Grid_Columns.Default;
			eEngDataRxColumns = SpyEngineering_Grid_Columns.Default;
			
			Cycle_DataPanelVisible = true;
			Cycle_GraphPanelVisible = true;
			Cycle_RawDataPanelVisible = true;
			Cycle_EngDataPanelVisible = true;
			eCycleRawDataColumns = SpyRaw_Grid_Columns.Default;
			eCycleEngDataColumns = SpyEngineering_Grid_Columns.Default;
			
			Pos_Split_RxTx = 290;
			Pos_Split_Tx_EngRaw = 411;
			Pos_Split_Rx_DataGraph = 277;
			Pos_Split_RxData_RawEng = 360;
			Pos_Split_CycleDataGraph = 302;
			Pos_Split_CycleData_RawEng = 143;
			
		}
	}
	
	public class CAN_Controller_Layouts
	{
		#region Public members
		
		public List<Ctrl_CS_CAN_Bus_Layout> Layouts;
		
		#endregion
		
		public CAN_Controller_Layouts()
		{
			Layouts = new List<Ctrl_CS_CAN_Bus_Layout>();
		}
		
		#region Public methods
		
		public void Save_Controller_Layouts(string fPath)
		{
			if (Layouts.Count > 0)
			{
				XmlDocument oXDoc = new XmlDocument();
				
				XmlElement xLayouts = oXDoc.CreateElement("ControllerLayouts");
				oXDoc.AppendChild(xLayouts);
				
				XmlElement xProp = null;
				
				for (int i=0; i<Layouts.Count; i++)
				{
					XmlElement xCtrlLayout = oXDoc.CreateElement("Layout");
					xLayouts.AppendChild(xCtrlLayout);
					
						XmlAttribute xAtrCtrlId = oXDoc.CreateAttribute("ControllerId");
						xAtrCtrlId.Value = i.ToString();
						xCtrlLayout.Attributes.Append(xAtrCtrlId);
						
						xProp = oXDoc.CreateElement("TxPanelVisible");
						xProp.InnerText = Layouts[i].TxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("EngDataTxPanelVisible");
						xProp.InnerText = Layouts[i].EngDataTxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("RawDataTxPanelVisible");
						xProp.InnerText = Layouts[i].RawDataTxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("eEngDataTxColumns");
						xProp.InnerText = Layouts[i].eEngDataTxColumns.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("RxPanelVisible");
						xProp.InnerText = Layouts[i].RxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("GraphRxPanelVisible");
						xProp.InnerText = Layouts[i].GraphRxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("DataRxPanelVisible");
						xProp.InnerText = Layouts[i].DataRxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("EngDataRxPanelVisible");
						xProp.InnerText = Layouts[i].EngDataRxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("RawDataRxPanelVisible");
						xProp.InnerText = Layouts[i].RawDataRxPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("eRawDataRxColumns");
						xProp.InnerText = Layouts[i].eRawDataRxColumns.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("eEngDataRxColumns");
						xProp.InnerText = Layouts[i].eEngDataRxColumns.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Cycle_DataPanelVisible");
						xProp.InnerText = Layouts[i].Cycle_DataPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Cycle_GraphPanelVisible");
						xProp.InnerText = Layouts[i].Cycle_GraphPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Cycle_RawDataPanelVisible");
						xProp.InnerText = Layouts[i].Cycle_RawDataPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Cycle_EngDataPanelVisible");
						xProp.InnerText = Layouts[i].Cycle_EngDataPanelVisible.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("eCycleRawDataColumns");
						xProp.InnerText = Layouts[i].eCycleRawDataColumns.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("eCycleEngDataColumns");
						xProp.InnerText = Layouts[i].eCycleEngDataColumns.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Pos_Split_RxTx");
						xProp.InnerText = Layouts[i].Pos_Split_RxTx.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Pos_Split_Tx_EngRaw");
						xProp.InnerText = Layouts[i].Pos_Split_Tx_EngRaw.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Pos_Split_Rx_DataGraph");
						xProp.InnerText = Layouts[i].Pos_Split_Rx_DataGraph.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Pos_Split_RxData_RawEng");
						xProp.InnerText = Layouts[i].Pos_Split_RxData_RawEng.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						//
						xProp = oXDoc.CreateElement("Pos_Split_CycleDataGraph");
						xProp.InnerText = Layouts[i].Pos_Split_CycleDataGraph.ToString();
						xCtrlLayout.AppendChild(xProp);
						
						xProp = oXDoc.CreateElement("Pos_Split_CycleData_RawEng");
						xProp.InnerText = Layouts[i].Pos_Split_CycleData_RawEng.ToString();
						xCtrlLayout.AppendChild(xProp);
						//
						
				}
				
				oXDoc.Save(fPath);
			}
		}
		
		public bool Load_Controller_Layouts(string fPath)
		{
			try
			{
				XmlDocument oXDoc = new XmlDocument();
				oXDoc.Load(fPath);
				
				Layouts = new List<Ctrl_CS_CAN_Bus_Layout>();
				
				XmlNode xLayouts = oXDoc.SelectSingleNode("ControllerLayouts");
				
				XmlNode xProp = null;
				
				foreach (XmlNode xCtrlLayout in xLayouts.ChildNodes)
				{
					if (xCtrlLayout.Name.Equals("Layout"))
					{
						Ctrl_CS_CAN_Bus_Layout oLayout = new Ctrl_CS_CAN_Bus_Layout();
						
						int CtrlId = int.Parse(xCtrlLayout.Attributes["ControllerId"].Value);
						
							xProp = xCtrlLayout.SelectSingleNode("TxPanelVisible");
							oLayout.TxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("EngDataTxPanelVisible");
							oLayout.EngDataTxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("RawDataTxPanelVisible");
							oLayout.RawDataTxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("eEngDataTxColumns");
							oLayout.eEngDataTxColumns = (Manual_Grid_Columns)Enum.Parse(typeof(Manual_Grid_Columns), xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("RxPanelVisible");
							oLayout.RxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("GraphRxPanelVisible");
							oLayout.GraphRxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("DataRxPanelVisible");
							oLayout.DataRxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("EngDataRxPanelVisible");
							oLayout.EngDataRxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("RawDataRxPanelVisible");
							oLayout.RawDataRxPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("eRawDataRxColumns");
							oLayout.eRawDataRxColumns = (SpyRaw_Grid_Columns)Enum.Parse(typeof(SpyRaw_Grid_Columns), xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("eEngDataRxColumns");
							oLayout.eEngDataRxColumns = (SpyEngineering_Grid_Columns)Enum.Parse(typeof(SpyEngineering_Grid_Columns), xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Cycle_DataPanelVisible");
							oLayout.Cycle_DataPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Cycle_GraphPanelVisible");
							oLayout.Cycle_GraphPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Cycle_RawDataPanelVisible");
							oLayout.Cycle_RawDataPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Cycle_EngDataPanelVisible");
							oLayout.Cycle_EngDataPanelVisible = bool.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("eCycleRawDataColumns");
							oLayout.eCycleRawDataColumns = (SpyRaw_Grid_Columns)Enum.Parse(typeof(SpyRaw_Grid_Columns), xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("eCycleEngDataColumns");
							oLayout.eCycleEngDataColumns = (SpyEngineering_Grid_Columns)Enum.Parse(typeof(SpyEngineering_Grid_Columns), xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Pos_Split_RxTx");
							oLayout.Pos_Split_RxTx = int.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Pos_Split_Tx_EngRaw");
							oLayout.Pos_Split_Tx_EngRaw = int.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Pos_Split_Rx_DataGraph");
							oLayout.Pos_Split_Rx_DataGraph = int.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Pos_Split_RxData_RawEng");
							oLayout.Pos_Split_RxData_RawEng = int.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Pos_Split_CycleDataGraph");
							oLayout.Pos_Split_CycleDataGraph = int.Parse(xProp.InnerText);
							
							xProp = xCtrlLayout.SelectSingleNode("Pos_Split_CycleData_RawEng");
							oLayout.Pos_Split_CycleData_RawEng = int.Parse(xProp.InnerText);
														
						Layouts.Insert(CtrlId, oLayout);
					}
				}
			}
			catch
			{
				return(false);
			}
			
			return(true);
		}
		
		#endregion
	}
	
	#endregion
}
