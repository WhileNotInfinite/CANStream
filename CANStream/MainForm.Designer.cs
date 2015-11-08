/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 4/29/2013
 * Time: 8:03 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class MainForm
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
            this.FrmMain_MenuStrip = new System.Windows.Forms.MenuStrip();
            this.cANConfigurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CANConfig_newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CANConfig_openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CANConfig_editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.importDBCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rawMessagesTxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.delMessageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMessagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.saveMessageListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMessageListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cycleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_new_EasyCreation_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_new_AdvancedCreation_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_new_RecordReplay_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_SetStartEndPoints_ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_SetStartPoint_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_SetEndPoint_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_ConfirmStartEndPoints_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Cycle_CancelStartEndPoint_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCycledataAssociationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCycledataAssociationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.startRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticRecordingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordingTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTriggerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.recordingEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRecordingEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRecordingEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRecordingEventDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.recordingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newRecordingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRecordingSessionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editRecordingSessionDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.convertRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertAllRecordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectRecordsToConvertToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopRecordConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.automaticRecordsConversionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools_TSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.virtualChannelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.builtinSignalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools_DataViewer_TSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools_DataViewer_New_TSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tools_DataViewer_Open_TSMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_HideSelectedRows = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_ShowHiddenRows = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Layout = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Manual = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Manual_Tx = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Manual_Tx_Eng = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Manual_Tx_Raw = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Manual_Rx = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Manual_Rx_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Manual_Rx_Graph = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Cycle = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Cycle_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Layout_Cycle_Graph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Layout_Reset = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_ShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_HideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Columns_Manual_Tx_ID = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_RxTx = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Period = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Mux = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Length = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Endianess = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Signedness = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Gain = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Zero = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Unit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Tx_Comment = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_ShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_HideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Columns_Manual_Rx_Eng_ID = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Value = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_RawVal = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Min = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Max = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Unit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Period = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Count = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_DLC = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Comment = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_ShowAll = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_HideAll = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_Columns_Cycle_Eng_ID = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Value = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_RawVal = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Min = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Max = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Unit = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Period = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Count = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_DLC = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Comment = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpTopicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.TS_Lbl_CanCfgTitle = new System.Windows.Forms.ToolStripLabel();
            this.TS_Lbl_CanCfg = new System.Windows.Forms.ToolStripLabel();
            this.TS_Lbl_CanCfgDesc = new System.Windows.Forms.ToolStripLabel();
            this.SS_TS_Lbl_RecordEvent = new System.Windows.Forms.ToolStripStatusLabel();
            this.SS_TS_Lbl_RecordSession = new System.Windows.Forms.ToolStripStatusLabel();
            this.TS_Lbl_ConversionProgress = new System.Windows.Forms.ToolStripLabel();
            this.TS_PB_Conversion = new System.Windows.Forms.ToolStripProgressBar();
            this.TSSL_StopConversion = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_Lbl_PCAN_Diag_Title = new System.Windows.Forms.ToolStripStatusLabel();
            this.TSS_Lbl_PCAN_Diag_Text = new System.Windows.Forms.ToolStripStatusLabel();
            this.Tab_CAN_Controllers = new System.Windows.Forms.TabControl();
            this.TabPage_NewController = new System.Windows.Forms.TabPage();
            this.Context_TabControllers = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.closeCANBusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.BGWrk_RecordConversion = new System.ComponentModel.BackgroundWorker();
            this.TSMI_Columns_Manual_Rx_Eng_RxTx = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Length = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Endianess = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Signed = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Gain = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Manual_Rx_Eng_Zero = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_RxTx = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Start = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Length = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Endianess = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Signedness = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Gain = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Columns_Cycle_Eng_Zero = new System.Windows.Forms.ToolStripMenuItem();
            this.FrmMain_MenuStrip.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.Tab_CAN_Controllers.SuspendLayout();
            this.Context_TabControllers.SuspendLayout();
            this.SuspendLayout();
            // 
            // FrmMain_MenuStrip
            // 
            this.FrmMain_MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cANConfigurationToolStripMenuItem,
            this.cycleToolStripMenuItem,
            this.toolStripMenuItem2,
            this.Tools_TSMenuItem,
            this.ViewtoolStripMenuItem,
            this.helpToolStripMenuItem});
            this.FrmMain_MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.FrmMain_MenuStrip.Name = "FrmMain_MenuStrip";
            this.FrmMain_MenuStrip.Size = new System.Drawing.Size(962, 24);
            this.FrmMain_MenuStrip.TabIndex = 0;
            this.FrmMain_MenuStrip.Text = "menuStrip1";
            // 
            // cANConfigurationToolStripMenuItem
            // 
            this.cANConfigurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CANConfig_newToolStripMenuItem,
            this.CANConfig_openToolStripMenuItem,
            this.CANConfig_editToolStripMenuItem,
            this.toolStripMenuItem5,
            this.importDBCToolStripMenuItem,
            this.rawMessagesTxToolStripMenuItem});
            this.cANConfigurationToolStripMenuItem.Name = "cANConfigurationToolStripMenuItem";
            this.cANConfigurationToolStripMenuItem.Size = new System.Drawing.Size(121, 20);
            this.cANConfigurationToolStripMenuItem.Text = "CAN Configuration";
            // 
            // CANConfig_newToolStripMenuItem
            // 
            this.CANConfig_newToolStripMenuItem.Image = global::CANStream.Icones.File_New_16;
            this.CANConfig_newToolStripMenuItem.Name = "CANConfig_newToolStripMenuItem";
            this.CANConfig_newToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.CANConfig_newToolStripMenuItem.Text = "New";
            this.CANConfig_newToolStripMenuItem.Click += new System.EventHandler(this.CANConfig_newToolStripMenuItem_Click);
            // 
            // CANConfig_openToolStripMenuItem
            // 
            this.CANConfig_openToolStripMenuItem.Image = global::CANStream.Icones.File_Open_16;
            this.CANConfig_openToolStripMenuItem.Name = "CANConfig_openToolStripMenuItem";
            this.CANConfig_openToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.CANConfig_openToolStripMenuItem.Text = "Open";
            this.CANConfig_openToolStripMenuItem.Click += new System.EventHandler(this.CANConfig_openToolStripMenuItemClick);
            // 
            // CANConfig_editToolStripMenuItem
            // 
            this.CANConfig_editToolStripMenuItem.Image = global::CANStream.Icones.Edit_16;
            this.CANConfig_editToolStripMenuItem.Name = "CANConfig_editToolStripMenuItem";
            this.CANConfig_editToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.CANConfig_editToolStripMenuItem.Text = "Edit";
            this.CANConfig_editToolStripMenuItem.Click += new System.EventHandler(this.CANConfig_editToolStripMenuItemClick);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(161, 6);
            // 
            // importDBCToolStripMenuItem
            // 
            this.importDBCToolStripMenuItem.Image = global::CANStream.Icones.DBC_Import_16;
            this.importDBCToolStripMenuItem.Name = "importDBCToolStripMenuItem";
            this.importDBCToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.importDBCToolStripMenuItem.Text = "Import DBC";
            this.importDBCToolStripMenuItem.Click += new System.EventHandler(this.ImportDBCToolStripMenuItemClick);
            // 
            // rawMessagesTxToolStripMenuItem
            // 
            this.rawMessagesTxToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addMessageToolStripMenuItem,
            this.delMessageToolStripMenuItem,
            this.clearMessagesToolStripMenuItem,
            this.toolStripMenuItem8,
            this.saveMessageListToolStripMenuItem,
            this.openMessageListToolStripMenuItem});
            this.rawMessagesTxToolStripMenuItem.Image = global::CANStream.Icones.Raw_Data;
            this.rawMessagesTxToolStripMenuItem.Name = "rawMessagesTxToolStripMenuItem";
            this.rawMessagesTxToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rawMessagesTxToolStripMenuItem.Text = "Raw messages Tx";
            // 
            // addMessageToolStripMenuItem
            // 
            this.addMessageToolStripMenuItem.Image = global::CANStream.Icones.Item_Add_16;
            this.addMessageToolStripMenuItem.Name = "addMessageToolStripMenuItem";
            this.addMessageToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.addMessageToolStripMenuItem.Text = "Add message";
            this.addMessageToolStripMenuItem.Click += new System.EventHandler(this.AddMessageToolStripMenuItemClick);
            // 
            // delMessageToolStripMenuItem
            // 
            this.delMessageToolStripMenuItem.Image = global::CANStream.Icones.Item_Del_16;
            this.delMessageToolStripMenuItem.Name = "delMessageToolStripMenuItem";
            this.delMessageToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.delMessageToolStripMenuItem.Text = "Del message";
            this.delMessageToolStripMenuItem.Click += new System.EventHandler(this.DelMessageToolStripMenuItemClick);
            // 
            // clearMessagesToolStripMenuItem
            // 
            this.clearMessagesToolStripMenuItem.Image = global::CANStream.Icones.Item_Clear_16;
            this.clearMessagesToolStripMenuItem.Name = "clearMessagesToolStripMenuItem";
            this.clearMessagesToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.clearMessagesToolStripMenuItem.Text = "Clear messages";
            this.clearMessagesToolStripMenuItem.Click += new System.EventHandler(this.ClearMessagesToolStripMenuItemClick);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(167, 6);
            // 
            // saveMessageListToolStripMenuItem
            // 
            this.saveMessageListToolStripMenuItem.Image = global::CANStream.Icones.File_Save_16;
            this.saveMessageListToolStripMenuItem.Name = "saveMessageListToolStripMenuItem";
            this.saveMessageListToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.saveMessageListToolStripMenuItem.Text = "Save message list";
            this.saveMessageListToolStripMenuItem.Click += new System.EventHandler(this.SaveMessageListToolStripMenuItemClick);
            // 
            // openMessageListToolStripMenuItem
            // 
            this.openMessageListToolStripMenuItem.Image = global::CANStream.Icones.File_Open_16;
            this.openMessageListToolStripMenuItem.Name = "openMessageListToolStripMenuItem";
            this.openMessageListToolStripMenuItem.Size = new System.Drawing.Size(170, 22);
            this.openMessageListToolStripMenuItem.Text = "Open message list";
            this.openMessageListToolStripMenuItem.Click += new System.EventHandler(this.OpenMessageListToolStripMenuItemClick);
            // 
            // cycleToolStripMenuItem
            // 
            this.cycleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cycle_newToolStripMenuItem,
            this.Cycle_openToolStripMenuItem,
            this.Cycle_SetStartEndPoints_ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolsToolStripMenuItem});
            this.cycleToolStripMenuItem.Name = "cycleToolStripMenuItem";
            this.cycleToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.cycleToolStripMenuItem.Text = "Cycle";
            // 
            // Cycle_newToolStripMenuItem
            // 
            this.Cycle_newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cycle_new_EasyCreation_ToolStripMenuItem,
            this.Cycle_new_AdvancedCreation_ToolStripMenuItem,
            this.Cycle_new_RecordReplay_ToolStripMenuItem});
            this.Cycle_newToolStripMenuItem.Image = global::CANStream.Icones.File_New_16;
            this.Cycle_newToolStripMenuItem.Name = "Cycle_newToolStripMenuItem";
            this.Cycle_newToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.Cycle_newToolStripMenuItem.Text = "New";
            // 
            // Cycle_new_EasyCreation_ToolStripMenuItem
            // 
            this.Cycle_new_EasyCreation_ToolStripMenuItem.Image = global::CANStream.Icones.CANStream_Cycle_16;
            this.Cycle_new_EasyCreation_ToolStripMenuItem.Name = "Cycle_new_EasyCreation_ToolStripMenuItem";
            this.Cycle_new_EasyCreation_ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.Cycle_new_EasyCreation_ToolStripMenuItem.Text = "Easy cycle creation";
            this.Cycle_new_EasyCreation_ToolStripMenuItem.Click += new System.EventHandler(this.Cycle_new_EasyCreation_ToolStripMenuItemClick);
            // 
            // Cycle_new_AdvancedCreation_ToolStripMenuItem
            // 
            this.Cycle_new_AdvancedCreation_ToolStripMenuItem.Image = global::CANStream.Icones.CANStream_Cycle_Creation_16;
            this.Cycle_new_AdvancedCreation_ToolStripMenuItem.Name = "Cycle_new_AdvancedCreation_ToolStripMenuItem";
            this.Cycle_new_AdvancedCreation_ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.Cycle_new_AdvancedCreation_ToolStripMenuItem.Text = "Advanced cycle creation";
            this.Cycle_new_AdvancedCreation_ToolStripMenuItem.Click += new System.EventHandler(this.Cycle_new_AdvancedCreation_ToolStripMenuItemClick);
            // 
            // Cycle_new_RecordReplay_ToolStripMenuItem
            // 
            this.Cycle_new_RecordReplay_ToolStripMenuItem.Image = global::CANStream.Icones.CANStream_PCANTrace_16;
            this.Cycle_new_RecordReplay_ToolStripMenuItem.Name = "Cycle_new_RecordReplay_ToolStripMenuItem";
            this.Cycle_new_RecordReplay_ToolStripMenuItem.Size = new System.Drawing.Size(203, 22);
            this.Cycle_new_RecordReplay_ToolStripMenuItem.Text = "Record replay";
            this.Cycle_new_RecordReplay_ToolStripMenuItem.Click += new System.EventHandler(this.Cycle_new_RecordReplay_ToolStripMenuItemClick);
            // 
            // Cycle_openToolStripMenuItem
            // 
            this.Cycle_openToolStripMenuItem.Image = global::CANStream.Icones.File_Open_16;
            this.Cycle_openToolStripMenuItem.Name = "Cycle_openToolStripMenuItem";
            this.Cycle_openToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.Cycle_openToolStripMenuItem.Text = "Open";
            this.Cycle_openToolStripMenuItem.Click += new System.EventHandler(this.Cycle_openToolStripMenuItemClick);
            // 
            // Cycle_SetStartEndPoints_ToolStripMenuItem
            // 
            this.Cycle_SetStartEndPoints_ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Cycle_SetStartPoint_TSMI,
            this.Cycle_SetEndPoint_TSMI,
            this.Cycle_ConfirmStartEndPoints_TSMI,
            this.Cycle_CancelStartEndPoint_TSMI});
            this.Cycle_SetStartEndPoints_ToolStripMenuItem.Enabled = false;
            this.Cycle_SetStartEndPoints_ToolStripMenuItem.Image = global::CANStream.Icones.Edit_16;
            this.Cycle_SetStartEndPoints_ToolStripMenuItem.Name = "Cycle_SetStartEndPoints_ToolStripMenuItem";
            this.Cycle_SetStartEndPoints_ToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.Cycle_SetStartEndPoints_ToolStripMenuItem.Text = "Set start/end points";
            // 
            // Cycle_SetStartPoint_TSMI
            // 
            this.Cycle_SetStartPoint_TSMI.Image = global::CANStream.Icones.Cycle_Start_16;
            this.Cycle_SetStartPoint_TSMI.Name = "Cycle_SetStartPoint_TSMI";
            this.Cycle_SetStartPoint_TSMI.Size = new System.Drawing.Size(236, 22);
            this.Cycle_SetStartPoint_TSMI.Text = "Set starting point";
            this.Cycle_SetStartPoint_TSMI.Click += new System.EventHandler(this.Cycle_SetStartPoint_TSMIClick);
            // 
            // Cycle_SetEndPoint_TSMI
            // 
            this.Cycle_SetEndPoint_TSMI.Image = global::CANStream.Icones.Cycle_End_16;
            this.Cycle_SetEndPoint_TSMI.Name = "Cycle_SetEndPoint_TSMI";
            this.Cycle_SetEndPoint_TSMI.Size = new System.Drawing.Size(236, 22);
            this.Cycle_SetEndPoint_TSMI.Text = "Set ending point";
            this.Cycle_SetEndPoint_TSMI.Click += new System.EventHandler(this.Cycle_SetEndPoint_TSMIClick);
            // 
            // Cycle_ConfirmStartEndPoints_TSMI
            // 
            this.Cycle_ConfirmStartEndPoints_TSMI.Image = global::CANStream.Icones.Apply_16;
            this.Cycle_ConfirmStartEndPoints_TSMI.Name = "Cycle_ConfirmStartEndPoints_TSMI";
            this.Cycle_ConfirmStartEndPoints_TSMI.Size = new System.Drawing.Size(236, 22);
            this.Cycle_ConfirmStartEndPoints_TSMI.Text = "Confirm start/end points";
            this.Cycle_ConfirmStartEndPoints_TSMI.Visible = false;
            this.Cycle_ConfirmStartEndPoints_TSMI.Click += new System.EventHandler(this.Cycle_ConfirmStartEndPoints_TSMIClick);
            // 
            // Cycle_CancelStartEndPoint_TSMI
            // 
            this.Cycle_CancelStartEndPoint_TSMI.Image = global::CANStream.Icones.Cancel_16;
            this.Cycle_CancelStartEndPoint_TSMI.Name = "Cycle_CancelStartEndPoint_TSMI";
            this.Cycle_CancelStartEndPoint_TSMI.Size = new System.Drawing.Size(236, 22);
            this.Cycle_CancelStartEndPoint_TSMI.Text = "Cancel start/end points setting";
            this.Cycle_CancelStartEndPoint_TSMI.Visible = false;
            this.Cycle_CancelStartEndPoint_TSMI.Click += new System.EventHandler(this.Cycle_CancelStartEndPoint_TSMIClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(174, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCycledataAssociationToolStripMenuItem,
            this.openCycledataAssociationToolStripMenuItem});
            this.toolsToolStripMenuItem.Image = global::CANStream.Icones.Tools;
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // newCycledataAssociationToolStripMenuItem
            // 
            this.newCycledataAssociationToolStripMenuItem.Image = global::CANStream.Icones.CANStream_CycleDataAssociation;
            this.newCycledataAssociationToolStripMenuItem.Name = "newCycledataAssociationToolStripMenuItem";
            this.newCycledataAssociationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.newCycledataAssociationToolStripMenuItem.Text = "New cycle/data association";
            this.newCycledataAssociationToolStripMenuItem.Click += new System.EventHandler(this.newCycledataAssociationToolStripMenuItem_Click);
            // 
            // openCycledataAssociationToolStripMenuItem
            // 
            this.openCycledataAssociationToolStripMenuItem.Image = global::CANStream.Icones.File_Open_16;
            this.openCycledataAssociationToolStripMenuItem.Name = "openCycledataAssociationToolStripMenuItem";
            this.openCycledataAssociationToolStripMenuItem.Size = new System.Drawing.Size(223, 22);
            this.openCycledataAssociationToolStripMenuItem.Text = "Open cycle/data association";
            this.openCycledataAssociationToolStripMenuItem.Click += new System.EventHandler(this.OpenCycledataAssociationToolStripMenuItemClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startRecordingToolStripMenuItem,
            this.stopRecordingToolStripMenuItem,
            this.automaticRecordingToolStripMenuItem,
            this.recordingTriggerToolStripMenuItem,
            this.toolStripMenuItem3,
            this.recordingEventToolStripMenuItem,
            this.recordingSessionToolStripMenuItem,
            this.toolStripMenuItem4,
            this.convertRecordsToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(73, 20);
            this.toolStripMenuItem2.Text = "Recording";
            // 
            // startRecordingToolStripMenuItem
            // 
            this.startRecordingToolStripMenuItem.Enabled = false;
            this.startRecordingToolStripMenuItem.Image = global::CANStream.Icones.Start_Record;
            this.startRecordingToolStripMenuItem.Name = "startRecordingToolStripMenuItem";
            this.startRecordingToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.startRecordingToolStripMenuItem.Text = "Start recording";
            this.startRecordingToolStripMenuItem.Click += new System.EventHandler(this.StartRecordingToolStripMenuItemClick);
            // 
            // stopRecordingToolStripMenuItem
            // 
            this.stopRecordingToolStripMenuItem.Enabled = false;
            this.stopRecordingToolStripMenuItem.Image = global::CANStream.Icones.Stop_Recording;
            this.stopRecordingToolStripMenuItem.Name = "stopRecordingToolStripMenuItem";
            this.stopRecordingToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.stopRecordingToolStripMenuItem.Text = "Stop recording";
            this.stopRecordingToolStripMenuItem.Click += new System.EventHandler(this.StopRecordingToolStripMenuItemClick);
            // 
            // automaticRecordingToolStripMenuItem
            // 
            this.automaticRecordingToolStripMenuItem.Image = global::CANStream.Icones.Auto_16;
            this.automaticRecordingToolStripMenuItem.Name = "automaticRecordingToolStripMenuItem";
            this.automaticRecordingToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.automaticRecordingToolStripMenuItem.Text = "Automatic recording";
            this.automaticRecordingToolStripMenuItem.Click += new System.EventHandler(this.AutomaticRecordingToolStripMenuItemClick);
            // 
            // recordingTriggerToolStripMenuItem
            // 
            this.recordingTriggerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTriggerToolStripMenuItem,
            this.toolStripMenuItem10});
            this.recordingTriggerToolStripMenuItem.Image = global::CANStream.Icones.Record_Trigger_16;
            this.recordingTriggerToolStripMenuItem.Name = "recordingTriggerToolStripMenuItem";
            this.recordingTriggerToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.recordingTriggerToolStripMenuItem.Text = "Recording trigger";
            // 
            // newTriggerToolStripMenuItem
            // 
            this.newTriggerToolStripMenuItem.Image = global::CANStream.Icones.Record_Trigger_16;
            this.newTriggerToolStripMenuItem.Name = "newTriggerToolStripMenuItem";
            this.newTriggerToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.newTriggerToolStripMenuItem.Text = "New trigger";
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Size = new System.Drawing.Size(133, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(181, 6);
            // 
            // recordingEventToolStripMenuItem
            // 
            this.recordingEventToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRecordingEventToolStripMenuItem,
            this.selectRecordingEventToolStripMenuItem,
            this.editRecordingEventDetailsToolStripMenuItem});
            this.recordingEventToolStripMenuItem.Image = global::CANStream.Icones.Record_Event_16;
            this.recordingEventToolStripMenuItem.Name = "recordingEventToolStripMenuItem";
            this.recordingEventToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.recordingEventToolStripMenuItem.Text = "Recording event";
            // 
            // newRecordingEventToolStripMenuItem
            // 
            this.newRecordingEventToolStripMenuItem.Image = global::CANStream.Icones.Record_Event_16;
            this.newRecordingEventToolStripMenuItem.Name = "newRecordingEventToolStripMenuItem";
            this.newRecordingEventToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.newRecordingEventToolStripMenuItem.Text = "New recording event";
            this.newRecordingEventToolStripMenuItem.Click += new System.EventHandler(this.NewRecordingEventToolStripMenuItemClick);
            // 
            // selectRecordingEventToolStripMenuItem
            // 
            this.selectRecordingEventToolStripMenuItem.Image = global::CANStream.Icones.User_Selection_16;
            this.selectRecordingEventToolStripMenuItem.Name = "selectRecordingEventToolStripMenuItem";
            this.selectRecordingEventToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.selectRecordingEventToolStripMenuItem.Text = "Select recording event";
            this.selectRecordingEventToolStripMenuItem.Click += new System.EventHandler(this.SelectRecordingEventToolStripMenuItemClick);
            // 
            // editRecordingEventDetailsToolStripMenuItem
            // 
            this.editRecordingEventDetailsToolStripMenuItem.Image = global::CANStream.Icones.Edit_16;
            this.editRecordingEventDetailsToolStripMenuItem.Name = "editRecordingEventDetailsToolStripMenuItem";
            this.editRecordingEventDetailsToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.editRecordingEventDetailsToolStripMenuItem.Text = "Edit recording event details";
            this.editRecordingEventDetailsToolStripMenuItem.Click += new System.EventHandler(this.EditRecordingEventDetailsToolStripMenuItemClick);
            // 
            // recordingSessionToolStripMenuItem
            // 
            this.recordingSessionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newRecordingSessionToolStripMenuItem,
            this.selectRecordingSessionToolStripMenuItem,
            this.editRecordingSessionDetailsToolStripMenuItem});
            this.recordingSessionToolStripMenuItem.Image = global::CANStream.Icones.Record_Session_16;
            this.recordingSessionToolStripMenuItem.Name = "recordingSessionToolStripMenuItem";
            this.recordingSessionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.recordingSessionToolStripMenuItem.Text = "Recording session";
            // 
            // newRecordingSessionToolStripMenuItem
            // 
            this.newRecordingSessionToolStripMenuItem.Image = global::CANStream.Icones.Record_Session_16;
            this.newRecordingSessionToolStripMenuItem.Name = "newRecordingSessionToolStripMenuItem";
            this.newRecordingSessionToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.newRecordingSessionToolStripMenuItem.Text = "New recording session";
            this.newRecordingSessionToolStripMenuItem.Click += new System.EventHandler(this.NewRecordingSessionToolStripMenuItemClick);
            // 
            // selectRecordingSessionToolStripMenuItem
            // 
            this.selectRecordingSessionToolStripMenuItem.Image = global::CANStream.Icones.User_Selection_16;
            this.selectRecordingSessionToolStripMenuItem.Name = "selectRecordingSessionToolStripMenuItem";
            this.selectRecordingSessionToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.selectRecordingSessionToolStripMenuItem.Text = "Select recording session";
            this.selectRecordingSessionToolStripMenuItem.Click += new System.EventHandler(this.SelectRecordingSessionToolStripMenuItemClick);
            // 
            // editRecordingSessionDetailsToolStripMenuItem
            // 
            this.editRecordingSessionDetailsToolStripMenuItem.Image = global::CANStream.Icones.Edit_16;
            this.editRecordingSessionDetailsToolStripMenuItem.Name = "editRecordingSessionDetailsToolStripMenuItem";
            this.editRecordingSessionDetailsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.editRecordingSessionDetailsToolStripMenuItem.Text = "Edit recording session details";
            this.editRecordingSessionDetailsToolStripMenuItem.Click += new System.EventHandler(this.EditRecordingSessionDetailsToolStripMenuItemClick);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(181, 6);
            // 
            // convertRecordsToolStripMenuItem
            // 
            this.convertRecordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.convertAllRecordsToolStripMenuItem,
            this.selectRecordsToConvertToolStripMenuItem,
            this.stopRecordConversionToolStripMenuItem,
            this.automaticRecordsConversionToolStripMenuItem});
            this.convertRecordsToolStripMenuItem.Image = global::CANStream.Icones.Run_Process_16;
            this.convertRecordsToolStripMenuItem.Name = "convertRecordsToolStripMenuItem";
            this.convertRecordsToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.convertRecordsToolStripMenuItem.Text = "Records convsersion";
            // 
            // convertAllRecordsToolStripMenuItem
            // 
            this.convertAllRecordsToolStripMenuItem.Image = global::CANStream.Icones.Run_Process_16;
            this.convertAllRecordsToolStripMenuItem.Name = "convertAllRecordsToolStripMenuItem";
            this.convertAllRecordsToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.convertAllRecordsToolStripMenuItem.Text = "Convert all records";
            this.convertAllRecordsToolStripMenuItem.Click += new System.EventHandler(this.ConvertAllRecordsToolStripMenuItemClick);
            // 
            // selectRecordsToConvertToolStripMenuItem
            // 
            this.selectRecordsToConvertToolStripMenuItem.Image = global::CANStream.Icones.User_Selection_16;
            this.selectRecordsToConvertToolStripMenuItem.Name = "selectRecordsToConvertToolStripMenuItem";
            this.selectRecordsToConvertToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.selectRecordsToConvertToolStripMenuItem.Text = "Select records to convert";
            this.selectRecordsToConvertToolStripMenuItem.Click += new System.EventHandler(this.SelectRecordsToConvertToolStripMenuItemClick);
            // 
            // stopRecordConversionToolStripMenuItem
            // 
            this.stopRecordConversionToolStripMenuItem.Image = global::CANStream.Icones.Stop_Process_16;
            this.stopRecordConversionToolStripMenuItem.Name = "stopRecordConversionToolStripMenuItem";
            this.stopRecordConversionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.stopRecordConversionToolStripMenuItem.Text = "Stop records conversion";
            this.stopRecordConversionToolStripMenuItem.Click += new System.EventHandler(this.StopRecordConversionToolStripMenuItemClick);
            // 
            // automaticRecordsConversionToolStripMenuItem
            // 
            this.automaticRecordsConversionToolStripMenuItem.Image = global::CANStream.Icones.Auto_16;
            this.automaticRecordsConversionToolStripMenuItem.Name = "automaticRecordsConversionToolStripMenuItem";
            this.automaticRecordsConversionToolStripMenuItem.Size = new System.Drawing.Size(233, 22);
            this.automaticRecordsConversionToolStripMenuItem.Text = "Automatic records conversion";
            this.automaticRecordsConversionToolStripMenuItem.Click += new System.EventHandler(this.AutomaticRecordsConversionToolStripMenuItemClick);
            // 
            // Tools_TSMenuItem
            // 
            this.Tools_TSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.virtualChannelsToolStripMenuItem,
            this.builtinSignalsToolStripMenuItem,
            this.Tools_DataViewer_TSMenuItem});
            this.Tools_TSMenuItem.Name = "Tools_TSMenuItem";
            this.Tools_TSMenuItem.Size = new System.Drawing.Size(47, 20);
            this.Tools_TSMenuItem.Text = "Tools";
            // 
            // virtualChannelsToolStripMenuItem
            // 
            this.virtualChannelsToolStripMenuItem.Image = global::CANStream.Icones.Virtual_Channel_16;
            this.virtualChannelsToolStripMenuItem.Name = "virtualChannelsToolStripMenuItem";
            this.virtualChannelsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.virtualChannelsToolStripMenuItem.Text = "Virtual Channels";
            this.virtualChannelsToolStripMenuItem.Click += new System.EventHandler(this.VirtualChannelsToolStripMenuItemClick);
            // 
            // builtinSignalsToolStripMenuItem
            // 
            this.builtinSignalsToolStripMenuItem.Image = global::CANStream.Icones.BuiltIn_Signal_16;
            this.builtinSignalsToolStripMenuItem.Name = "builtinSignalsToolStripMenuItem";
            this.builtinSignalsToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.builtinSignalsToolStripMenuItem.Text = "Built-in Signals";
            this.builtinSignalsToolStripMenuItem.Click += new System.EventHandler(this.BuiltinSignalsToolStripMenuItemClick);
            // 
            // Tools_DataViewer_TSMenuItem
            // 
            this.Tools_DataViewer_TSMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tools_DataViewer_New_TSMenuItem,
            this.Tools_DataViewer_Open_TSMenuItem});
            this.Tools_DataViewer_TSMenuItem.Image = global::CANStream.Icones.CANStream_DataViewer_16;
            this.Tools_DataViewer_TSMenuItem.Name = "Tools_DataViewer_TSMenuItem";
            this.Tools_DataViewer_TSMenuItem.Size = new System.Drawing.Size(160, 22);
            this.Tools_DataViewer_TSMenuItem.Text = "Data Viewer";
            // 
            // Tools_DataViewer_New_TSMenuItem
            // 
            this.Tools_DataViewer_New_TSMenuItem.Image = global::CANStream.Icones.CANStream_DataViewer_16;
            this.Tools_DataViewer_New_TSMenuItem.Name = "Tools_DataViewer_New_TSMenuItem";
            this.Tools_DataViewer_New_TSMenuItem.Size = new System.Drawing.Size(103, 22);
            this.Tools_DataViewer_New_TSMenuItem.Text = "New";
            this.Tools_DataViewer_New_TSMenuItem.Click += new System.EventHandler(this.Tools_DataViewer_New_TSMenuItemClick);
            // 
            // Tools_DataViewer_Open_TSMenuItem
            // 
            this.Tools_DataViewer_Open_TSMenuItem.Image = global::CANStream.Icones.File_Open_16;
            this.Tools_DataViewer_Open_TSMenuItem.Name = "Tools_DataViewer_Open_TSMenuItem";
            this.Tools_DataViewer_Open_TSMenuItem.Size = new System.Drawing.Size(103, 22);
            this.Tools_DataViewer_Open_TSMenuItem.Text = "Open";
            this.Tools_DataViewer_Open_TSMenuItem.Click += new System.EventHandler(this.Tools_DataViewer_Open_TSMenuItemClick);
            // 
            // ViewtoolStripMenuItem
            // 
            this.ViewtoolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_HideSelectedRows,
            this.TSMI_ShowHiddenRows,
            this.toolStripMenuItem7,
            this.TSMI_Layout,
            this.TSMI_Columns});
            this.ViewtoolStripMenuItem.Name = "ViewtoolStripMenuItem";
            this.ViewtoolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.ViewtoolStripMenuItem.Text = "View";
            // 
            // TSMI_HideSelectedRows
            // 
            this.TSMI_HideSelectedRows.Image = global::CANStream.Icones.Row_Hide_16;
            this.TSMI_HideSelectedRows.Name = "TSMI_HideSelectedRows";
            this.TSMI_HideSelectedRows.Size = new System.Drawing.Size(173, 22);
            this.TSMI_HideSelectedRows.Text = "Hide selected rows";
            this.TSMI_HideSelectedRows.Click += new System.EventHandler(this.TSMI_HideSelectedRowsClick);
            // 
            // TSMI_ShowHiddenRows
            // 
            this.TSMI_ShowHiddenRows.Image = global::CANStream.Icones.Row_Show_16;
            this.TSMI_ShowHiddenRows.Name = "TSMI_ShowHiddenRows";
            this.TSMI_ShowHiddenRows.Size = new System.Drawing.Size(173, 22);
            this.TSMI_ShowHiddenRows.Text = "Show hidden rows";
            this.TSMI_ShowHiddenRows.Click += new System.EventHandler(this.TSMI_ShowHiddenRowsClick);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(170, 6);
            // 
            // TSMI_Layout
            // 
            this.TSMI_Layout.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Layout_Manual,
            this.TSMI_Layout_Cycle,
            this.toolStripMenuItem6,
            this.TSMI_Layout_Reset});
            this.TSMI_Layout.Image = global::CANStream.Icones.Controller_Layout;
            this.TSMI_Layout.Name = "TSMI_Layout";
            this.TSMI_Layout.Size = new System.Drawing.Size(173, 22);
            this.TSMI_Layout.Text = "Layout";
            // 
            // TSMI_Layout_Manual
            // 
            this.TSMI_Layout_Manual.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Layout_Manual_Tx,
            this.TSMI_Layout_Manual_Rx});
            this.TSMI_Layout_Manual.Image = global::CANStream.Icones.Spy_and_Manual_16;
            this.TSMI_Layout_Manual.Name = "TSMI_Layout_Manual";
            this.TSMI_Layout_Manual.Size = new System.Drawing.Size(159, 22);
            this.TSMI_Layout_Manual.Text = "Spy and Manual";
            // 
            // TSMI_Layout_Manual_Tx
            // 
            this.TSMI_Layout_Manual_Tx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Layout_Manual_Tx_Eng,
            this.TSMI_Layout_Manual_Tx_Raw});
            this.TSMI_Layout_Manual_Tx.Image = global::CANStream.Icones.Message_Tx;
            this.TSMI_Layout_Manual_Tx.Name = "TSMI_Layout_Manual_Tx";
            this.TSMI_Layout_Manual_Tx.Size = new System.Drawing.Size(140, 22);
            this.TSMI_Layout_Manual_Tx.Text = "Messages Tx";
            this.TSMI_Layout_Manual_Tx.Click += new System.EventHandler(this.TSMI_Layout_Manual_TxClick);
            // 
            // TSMI_Layout_Manual_Tx_Eng
            // 
            this.TSMI_Layout_Manual_Tx_Eng.Image = global::CANStream.Icones.Engineering_Data;
            this.TSMI_Layout_Manual_Tx_Eng.Name = "TSMI_Layout_Manual_Tx_Eng";
            this.TSMI_Layout_Manual_Tx_Eng.Size = new System.Drawing.Size(191, 22);
            this.TSMI_Layout_Manual_Tx_Eng.Text = "Engineering messages";
            this.TSMI_Layout_Manual_Tx_Eng.Click += new System.EventHandler(this.TSMI_Layout_Manual_Tx_EngClick);
            // 
            // TSMI_Layout_Manual_Tx_Raw
            // 
            this.TSMI_Layout_Manual_Tx_Raw.Image = global::CANStream.Icones.Raw_Data;
            this.TSMI_Layout_Manual_Tx_Raw.Name = "TSMI_Layout_Manual_Tx_Raw";
            this.TSMI_Layout_Manual_Tx_Raw.Size = new System.Drawing.Size(191, 22);
            this.TSMI_Layout_Manual_Tx_Raw.Text = "Raw messages";
            this.TSMI_Layout_Manual_Tx_Raw.Click += new System.EventHandler(this.TSMI_Layout_Manual_Tx_RawClick);
            // 
            // TSMI_Layout_Manual_Rx
            // 
            this.TSMI_Layout_Manual_Rx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Layout_Manual_Rx_Data,
            this.TSMI_Layout_Manual_Rx_Graph});
            this.TSMI_Layout_Manual_Rx.Image = global::CANStream.Icones.Message_Rx;
            this.TSMI_Layout_Manual_Rx.Name = "TSMI_Layout_Manual_Rx";
            this.TSMI_Layout_Manual_Rx.Size = new System.Drawing.Size(140, 22);
            this.TSMI_Layout_Manual_Rx.Text = "Messages Rx";
            this.TSMI_Layout_Manual_Rx.Click += new System.EventHandler(this.TSMI_Layout_Manual_RxClick);
            // 
            // TSMI_Layout_Manual_Rx_Data
            // 
            this.TSMI_Layout_Manual_Rx_Data.Image = global::CANStream.Icones.Message_Rx;
            this.TSMI_Layout_Manual_Rx_Data.Name = "TSMI_Layout_Manual_Rx_Data";
            this.TSMI_Layout_Manual_Rx_Data.Size = new System.Drawing.Size(106, 22);
            this.TSMI_Layout_Manual_Rx_Data.Text = "Data";
            this.TSMI_Layout_Manual_Rx_Data.Click += new System.EventHandler(this.TSMI_Layout_Manual_Rx_DataClick);
            // 
            // TSMI_Layout_Manual_Rx_Graph
            // 
            this.TSMI_Layout_Manual_Rx_Graph.Image = global::CANStream.Icones.Graph;
            this.TSMI_Layout_Manual_Rx_Graph.Name = "TSMI_Layout_Manual_Rx_Graph";
            this.TSMI_Layout_Manual_Rx_Graph.Size = new System.Drawing.Size(106, 22);
            this.TSMI_Layout_Manual_Rx_Graph.Text = "Graph";
            this.TSMI_Layout_Manual_Rx_Graph.Click += new System.EventHandler(this.TSMI_Layout_Manual_Rx_GraphClick);
            // 
            // TSMI_Layout_Cycle
            // 
            this.TSMI_Layout_Cycle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Layout_Cycle_Data,
            this.TSMI_Layout_Cycle_Graph});
            this.TSMI_Layout_Cycle.Image = global::CANStream.Icones.Cycle_16;
            this.TSMI_Layout_Cycle.Name = "TSMI_Layout_Cycle";
            this.TSMI_Layout_Cycle.Size = new System.Drawing.Size(159, 22);
            this.TSMI_Layout_Cycle.Text = "Cycle player";
            // 
            // TSMI_Layout_Cycle_Data
            // 
            this.TSMI_Layout_Cycle_Data.Image = global::CANStream.Icones.Message_Rx;
            this.TSMI_Layout_Cycle_Data.Name = "TSMI_Layout_Cycle_Data";
            this.TSMI_Layout_Cycle_Data.Size = new System.Drawing.Size(106, 22);
            this.TSMI_Layout_Cycle_Data.Text = "Data";
            this.TSMI_Layout_Cycle_Data.Click += new System.EventHandler(this.TSMI_Layout_Cycle_DataClick);
            // 
            // TSMI_Layout_Cycle_Graph
            // 
            this.TSMI_Layout_Cycle_Graph.Image = global::CANStream.Icones.Graph;
            this.TSMI_Layout_Cycle_Graph.Name = "TSMI_Layout_Cycle_Graph";
            this.TSMI_Layout_Cycle_Graph.Size = new System.Drawing.Size(106, 22);
            this.TSMI_Layout_Cycle_Graph.Text = "Graph";
            this.TSMI_Layout_Cycle_Graph.Click += new System.EventHandler(this.TSMI_Layout_Cycle_GraphClick);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(156, 6);
            // 
            // TSMI_Layout_Reset
            // 
            this.TSMI_Layout_Reset.Image = global::CANStream.Icones.Controller_Layout;
            this.TSMI_Layout_Reset.Name = "TSMI_Layout_Reset";
            this.TSMI_Layout_Reset.Size = new System.Drawing.Size(159, 22);
            this.TSMI_Layout_Reset.Text = "Reset";
            this.TSMI_Layout_Reset.Click += new System.EventHandler(this.TSMI_Layout_ResetClick);
            // 
            // TSMI_Columns
            // 
            this.TSMI_Columns.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Columns_Manual,
            this.TSMI_Columns_Cycle});
            this.TSMI_Columns.Image = global::CANStream.Icones.Columns_16;
            this.TSMI_Columns.Name = "TSMI_Columns";
            this.TSMI_Columns.Size = new System.Drawing.Size(173, 22);
            this.TSMI_Columns.Text = "Tables columns";
            // 
            // TSMI_Columns_Manual
            // 
            this.TSMI_Columns_Manual.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Columns_Manual_Tx,
            this.TSMI_Columns_Manual_Rx});
            this.TSMI_Columns_Manual.Image = global::CANStream.Icones.Spy_and_Manual_16;
            this.TSMI_Columns_Manual.Name = "TSMI_Columns_Manual";
            this.TSMI_Columns_Manual.Size = new System.Drawing.Size(159, 22);
            this.TSMI_Columns_Manual.Text = "Spy and Manual";
            // 
            // TSMI_Columns_Manual_Tx
            // 
            this.TSMI_Columns_Manual_Tx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Columns_Manual_Tx_ShowAll,
            this.TSMI_Columns_Manual_Tx_HideAll,
            this.toolStripSeparator1,
            this.TSMI_Columns_Manual_Tx_ID,
            this.TSMI_Columns_Manual_Tx_RxTx,
            this.TSMI_Columns_Manual_Tx_Period,
            this.TSMI_Columns_Manual_Tx_Mux,
            this.TSMI_Columns_Manual_Tx_Start,
            this.TSMI_Columns_Manual_Tx_Length,
            this.TSMI_Columns_Manual_Tx_Endianess,
            this.TSMI_Columns_Manual_Tx_Signedness,
            this.TSMI_Columns_Manual_Tx_Gain,
            this.TSMI_Columns_Manual_Tx_Zero,
            this.TSMI_Columns_Manual_Tx_Unit,
            this.TSMI_Columns_Manual_Tx_Comment});
            this.TSMI_Columns_Manual_Tx.Image = global::CANStream.Icones.Message_Tx;
            this.TSMI_Columns_Manual_Tx.Name = "TSMI_Columns_Manual_Tx";
            this.TSMI_Columns_Manual_Tx.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx.Text = "Manual Tx";
            // 
            // TSMI_Columns_Manual_Tx_ShowAll
            // 
            this.TSMI_Columns_Manual_Tx_ShowAll.Name = "TSMI_Columns_Manual_Tx_ShowAll";
            this.TSMI_Columns_Manual_Tx_ShowAll.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_ShowAll.Text = "Show All";
            this.TSMI_Columns_Manual_Tx_ShowAll.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_ShowAllClick);
            // 
            // TSMI_Columns_Manual_Tx_HideAll
            // 
            this.TSMI_Columns_Manual_Tx_HideAll.Name = "TSMI_Columns_Manual_Tx_HideAll";
            this.TSMI_Columns_Manual_Tx_HideAll.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_HideAll.Text = "Hide All";
            this.TSMI_Columns_Manual_Tx_HideAll.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_HideAllClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // TSMI_Columns_Manual_Tx_ID
            // 
            this.TSMI_Columns_Manual_Tx_ID.Name = "TSMI_Columns_Manual_Tx_ID";
            this.TSMI_Columns_Manual_Tx_ID.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_ID.Text = "ID";
            this.TSMI_Columns_Manual_Tx_ID.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_IDClick);
            // 
            // TSMI_Columns_Manual_Tx_RxTx
            // 
            this.TSMI_Columns_Manual_Tx_RxTx.Name = "TSMI_Columns_Manual_Tx_RxTx";
            this.TSMI_Columns_Manual_Tx_RxTx.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_RxTx.Text = "RxTx";
            this.TSMI_Columns_Manual_Tx_RxTx.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_RxTxClick);
            // 
            // TSMI_Columns_Manual_Tx_Period
            // 
            this.TSMI_Columns_Manual_Tx_Period.Name = "TSMI_Columns_Manual_Tx_Period";
            this.TSMI_Columns_Manual_Tx_Period.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Period.Text = "Period";
            this.TSMI_Columns_Manual_Tx_Period.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_PeriodClick);
            // 
            // TSMI_Columns_Manual_Tx_Mux
            // 
            this.TSMI_Columns_Manual_Tx_Mux.Name = "TSMI_Columns_Manual_Tx_Mux";
            this.TSMI_Columns_Manual_Tx_Mux.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Mux.Text = "Mux value";
            this.TSMI_Columns_Manual_Tx_Mux.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_MuxValClick);
            // 
            // TSMI_Columns_Manual_Tx_Start
            // 
            this.TSMI_Columns_Manual_Tx_Start.Name = "TSMI_Columns_Manual_Tx_Start";
            this.TSMI_Columns_Manual_Tx_Start.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Start.Text = "Start";
            this.TSMI_Columns_Manual_Tx_Start.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_StartClick);
            // 
            // TSMI_Columns_Manual_Tx_Length
            // 
            this.TSMI_Columns_Manual_Tx_Length.Name = "TSMI_Columns_Manual_Tx_Length";
            this.TSMI_Columns_Manual_Tx_Length.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Length.Text = "Length";
            this.TSMI_Columns_Manual_Tx_Length.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_LengthClick);
            // 
            // TSMI_Columns_Manual_Tx_Endianess
            // 
            this.TSMI_Columns_Manual_Tx_Endianess.Name = "TSMI_Columns_Manual_Tx_Endianess";
            this.TSMI_Columns_Manual_Tx_Endianess.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Endianess.Text = "Endianess";
            this.TSMI_Columns_Manual_Tx_Endianess.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_EndianessClick);
            // 
            // TSMI_Columns_Manual_Tx_Signedness
            // 
            this.TSMI_Columns_Manual_Tx_Signedness.Name = "TSMI_Columns_Manual_Tx_Signedness";
            this.TSMI_Columns_Manual_Tx_Signedness.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Signedness.Text = "Signedness";
            this.TSMI_Columns_Manual_Tx_Signedness.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_SignednessClick);
            // 
            // TSMI_Columns_Manual_Tx_Gain
            // 
            this.TSMI_Columns_Manual_Tx_Gain.Name = "TSMI_Columns_Manual_Tx_Gain";
            this.TSMI_Columns_Manual_Tx_Gain.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Gain.Text = "Gain";
            this.TSMI_Columns_Manual_Tx_Gain.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_GainClick);
            // 
            // TSMI_Columns_Manual_Tx_Zero
            // 
            this.TSMI_Columns_Manual_Tx_Zero.Name = "TSMI_Columns_Manual_Tx_Zero";
            this.TSMI_Columns_Manual_Tx_Zero.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Zero.Text = "Zero";
            this.TSMI_Columns_Manual_Tx_Zero.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_ZeroClick);
            // 
            // TSMI_Columns_Manual_Tx_Unit
            // 
            this.TSMI_Columns_Manual_Tx_Unit.Name = "TSMI_Columns_Manual_Tx_Unit";
            this.TSMI_Columns_Manual_Tx_Unit.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Unit.Text = "Unit";
            this.TSMI_Columns_Manual_Tx_Unit.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_UnitClick);
            // 
            // TSMI_Columns_Manual_Tx_Comment
            // 
            this.TSMI_Columns_Manual_Tx_Comment.Name = "TSMI_Columns_Manual_Tx_Comment";
            this.TSMI_Columns_Manual_Tx_Comment.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Tx_Comment.Text = "Comment";
            this.TSMI_Columns_Manual_Tx_Comment.Click += new System.EventHandler(this.TSMI_Columns_Manual_Tx_CommentClick);
            // 
            // TSMI_Columns_Manual_Rx
            // 
            this.TSMI_Columns_Manual_Rx.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Columns_Manual_Rx_Eng_ShowAll,
            this.TSMI_Columns_Manual_Rx_Eng_HideAll,
            this.toolStripSeparator3,
            this.TSMI_Columns_Manual_Rx_Eng_ID,
            this.TSMI_Columns_Manual_Rx_Eng_RxTx,
            this.TSMI_Columns_Manual_Rx_Eng_Value,
            this.TSMI_Columns_Manual_Rx_Eng_RawVal,
            this.TSMI_Columns_Manual_Rx_Eng_Min,
            this.TSMI_Columns_Manual_Rx_Eng_Max,
            this.TSMI_Columns_Manual_Rx_Eng_Unit,
            this.TSMI_Columns_Manual_Rx_Eng_Period,
            this.TSMI_Columns_Manual_Rx_Eng_Start,
            this.TSMI_Columns_Manual_Rx_Eng_Length,
            this.TSMI_Columns_Manual_Rx_Eng_Endianess,
            this.TSMI_Columns_Manual_Rx_Eng_Signed,
            this.TSMI_Columns_Manual_Rx_Eng_Gain,
            this.TSMI_Columns_Manual_Rx_Eng_Zero,
            this.TSMI_Columns_Manual_Rx_Eng_Count,
            this.TSMI_Columns_Manual_Rx_Eng_DLC,
            this.TSMI_Columns_Manual_Rx_Eng_Comment});
            this.TSMI_Columns_Manual_Rx.Image = global::CANStream.Icones.Message_Rx;
            this.TSMI_Columns_Manual_Rx.Name = "TSMI_Columns_Manual_Rx";
            this.TSMI_Columns_Manual_Rx.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx.Text = "Manual Rx";
            // 
            // TSMI_Columns_Manual_Rx_Eng_ShowAll
            // 
            this.TSMI_Columns_Manual_Rx_Eng_ShowAll.Name = "TSMI_Columns_Manual_Rx_Eng_ShowAll";
            this.TSMI_Columns_Manual_Rx_Eng_ShowAll.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_ShowAll.Text = "Show All";
            this.TSMI_Columns_Manual_Rx_Eng_ShowAll.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_ShowAllClick);
            // 
            // TSMI_Columns_Manual_Rx_Eng_HideAll
            // 
            this.TSMI_Columns_Manual_Rx_Eng_HideAll.Name = "TSMI_Columns_Manual_Rx_Eng_HideAll";
            this.TSMI_Columns_Manual_Rx_Eng_HideAll.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_HideAll.Text = "Hide All";
            this.TSMI_Columns_Manual_Rx_Eng_HideAll.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_HideAllClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(149, 6);
            // 
            // TSMI_Columns_Manual_Rx_Eng_ID
            // 
            this.TSMI_Columns_Manual_Rx_Eng_ID.Name = "TSMI_Columns_Manual_Rx_Eng_ID";
            this.TSMI_Columns_Manual_Rx_Eng_ID.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_ID.Text = "ID";
            this.TSMI_Columns_Manual_Rx_Eng_ID.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_IDClick);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Value
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Value.Name = "TSMI_Columns_Manual_Rx_Eng_Value";
            this.TSMI_Columns_Manual_Rx_Eng_Value.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Value.Text = "Value";
            this.TSMI_Columns_Manual_Rx_Eng_Value.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_ValueClick);
            // 
            // TSMI_Columns_Manual_Rx_Eng_RawVal
            // 
            this.TSMI_Columns_Manual_Rx_Eng_RawVal.Name = "TSMI_Columns_Manual_Rx_Eng_RawVal";
            this.TSMI_Columns_Manual_Rx_Eng_RawVal.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_RawVal.Text = "Raw value";
            this.TSMI_Columns_Manual_Rx_Eng_RawVal.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_RawValClick);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Min
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Min.Name = "TSMI_Columns_Manual_Rx_Eng_Min";
            this.TSMI_Columns_Manual_Rx_Eng_Min.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Min.Text = "Min";
            this.TSMI_Columns_Manual_Rx_Eng_Min.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_MinClick);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Max
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Max.Name = "TSMI_Columns_Manual_Rx_Eng_Max";
            this.TSMI_Columns_Manual_Rx_Eng_Max.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Max.Text = "Max";
            this.TSMI_Columns_Manual_Rx_Eng_Max.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_MaxClick);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Unit
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Unit.Name = "TSMI_Columns_Manual_Rx_Eng_Unit";
            this.TSMI_Columns_Manual_Rx_Eng_Unit.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Unit.Text = "Unit";
            this.TSMI_Columns_Manual_Rx_Eng_Unit.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_UnitClick);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Period
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Period.Name = "TSMI_Columns_Manual_Rx_Eng_Period";
            this.TSMI_Columns_Manual_Rx_Eng_Period.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Period.Text = "Period";
            this.TSMI_Columns_Manual_Rx_Eng_Period.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Period_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Count
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Count.Name = "TSMI_Columns_Manual_Rx_Eng_Count";
            this.TSMI_Columns_Manual_Rx_Eng_Count.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Count.Text = "Count";
            this.TSMI_Columns_Manual_Rx_Eng_Count.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Count_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_DLC
            // 
            this.TSMI_Columns_Manual_Rx_Eng_DLC.Name = "TSMI_Columns_Manual_Rx_Eng_DLC";
            this.TSMI_Columns_Manual_Rx_Eng_DLC.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_DLC.Text = "DLC";
            this.TSMI_Columns_Manual_Rx_Eng_DLC.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_DLC_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Comment
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Comment.Name = "TSMI_Columns_Manual_Rx_Eng_Comment";
            this.TSMI_Columns_Manual_Rx_Eng_Comment.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Comment.Text = "Comment";
            this.TSMI_Columns_Manual_Rx_Eng_Comment.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_CommentClick);
            // 
            // TSMI_Columns_Cycle
            // 
            this.TSMI_Columns_Cycle.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Columns_Cycle_Eng_ShowAll,
            this.TSMI_Columns_Cycle_Eng_HideAll,
            this.toolStripSeparator4,
            this.TSMI_Columns_Cycle_Eng_ID,
            this.TSMI_Columns_Cycle_Eng_RxTx,
            this.TSMI_Columns_Cycle_Eng_Value,
            this.TSMI_Columns_Cycle_Eng_RawVal,
            this.TSMI_Columns_Cycle_Eng_Min,
            this.TSMI_Columns_Cycle_Eng_Max,
            this.TSMI_Columns_Cycle_Eng_Unit,
            this.TSMI_Columns_Cycle_Eng_Period,
            this.TSMI_Columns_Cycle_Eng_Start,
            this.TSMI_Columns_Cycle_Eng_Length,
            this.TSMI_Columns_Cycle_Eng_Endianess,
            this.TSMI_Columns_Cycle_Eng_Signedness,
            this.TSMI_Columns_Cycle_Eng_Gain,
            this.TSMI_Columns_Cycle_Eng_Zero,
            this.TSMI_Columns_Cycle_Eng_Count,
            this.TSMI_Columns_Cycle_Eng_DLC,
            this.TSMI_Columns_Cycle_Eng_Comment});
            this.TSMI_Columns_Cycle.Image = global::CANStream.Icones.Cycle_16;
            this.TSMI_Columns_Cycle.Name = "TSMI_Columns_Cycle";
            this.TSMI_Columns_Cycle.Size = new System.Drawing.Size(159, 22);
            this.TSMI_Columns_Cycle.Text = "Cycle player";
            // 
            // TSMI_Columns_Cycle_Eng_ShowAll
            // 
            this.TSMI_Columns_Cycle_Eng_ShowAll.Name = "TSMI_Columns_Cycle_Eng_ShowAll";
            this.TSMI_Columns_Cycle_Eng_ShowAll.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_ShowAll.Text = "Show All";
            this.TSMI_Columns_Cycle_Eng_ShowAll.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_ShowAllClick);
            // 
            // TSMI_Columns_Cycle_Eng_HideAll
            // 
            this.TSMI_Columns_Cycle_Eng_HideAll.Name = "TSMI_Columns_Cycle_Eng_HideAll";
            this.TSMI_Columns_Cycle_Eng_HideAll.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_HideAll.Text = "Hide All";
            this.TSMI_Columns_Cycle_Eng_HideAll.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_HideAllClick);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(149, 6);
            // 
            // TSMI_Columns_Cycle_Eng_ID
            // 
            this.TSMI_Columns_Cycle_Eng_ID.Name = "TSMI_Columns_Cycle_Eng_ID";
            this.TSMI_Columns_Cycle_Eng_ID.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_ID.Text = "ID";
            this.TSMI_Columns_Cycle_Eng_ID.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_IDClick);
            // 
            // TSMI_Columns_Cycle_Eng_Value
            // 
            this.TSMI_Columns_Cycle_Eng_Value.Name = "TSMI_Columns_Cycle_Eng_Value";
            this.TSMI_Columns_Cycle_Eng_Value.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Value.Text = "Value";
            this.TSMI_Columns_Cycle_Eng_Value.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_ValueClick);
            // 
            // TSMI_Columns_Cycle_Eng_RawVal
            // 
            this.TSMI_Columns_Cycle_Eng_RawVal.Name = "TSMI_Columns_Cycle_Eng_RawVal";
            this.TSMI_Columns_Cycle_Eng_RawVal.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_RawVal.Text = "Raw value";
            this.TSMI_Columns_Cycle_Eng_RawVal.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_RawValClick);
            // 
            // TSMI_Columns_Cycle_Eng_Min
            // 
            this.TSMI_Columns_Cycle_Eng_Min.Name = "TSMI_Columns_Cycle_Eng_Min";
            this.TSMI_Columns_Cycle_Eng_Min.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Min.Text = "Min";
            this.TSMI_Columns_Cycle_Eng_Min.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_MinClick);
            // 
            // TSMI_Columns_Cycle_Eng_Max
            // 
            this.TSMI_Columns_Cycle_Eng_Max.Name = "TSMI_Columns_Cycle_Eng_Max";
            this.TSMI_Columns_Cycle_Eng_Max.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Max.Text = "Max";
            this.TSMI_Columns_Cycle_Eng_Max.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_MaxClick);
            // 
            // TSMI_Columns_Cycle_Eng_Unit
            // 
            this.TSMI_Columns_Cycle_Eng_Unit.Name = "TSMI_Columns_Cycle_Eng_Unit";
            this.TSMI_Columns_Cycle_Eng_Unit.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Unit.Text = "Unit";
            this.TSMI_Columns_Cycle_Eng_Unit.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_UnitClick);
            // 
            // TSMI_Columns_Cycle_Eng_Period
            // 
            this.TSMI_Columns_Cycle_Eng_Period.Name = "TSMI_Columns_Cycle_Eng_Period";
            this.TSMI_Columns_Cycle_Eng_Period.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Period.Text = "Period";
            this.TSMI_Columns_Cycle_Eng_Period.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Period_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Count
            // 
            this.TSMI_Columns_Cycle_Eng_Count.Name = "TSMI_Columns_Cycle_Eng_Count";
            this.TSMI_Columns_Cycle_Eng_Count.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Count.Text = "Count";
            this.TSMI_Columns_Cycle_Eng_Count.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Count_Click);
            // 
            // TSMI_Columns_Cycle_Eng_DLC
            // 
            this.TSMI_Columns_Cycle_Eng_DLC.Name = "TSMI_Columns_Cycle_Eng_DLC";
            this.TSMI_Columns_Cycle_Eng_DLC.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_DLC.Text = "DLC";
            this.TSMI_Columns_Cycle_Eng_DLC.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_DLC_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Comment
            // 
            this.TSMI_Columns_Cycle_Eng_Comment.Name = "TSMI_Columns_Cycle_Eng_Comment";
            this.TSMI_Columns_Cycle_Eng_Comment.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Comment.Text = "Comment";
            this.TSMI_Columns_Cycle_Eng_Comment.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_CommentClick);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpTopicsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // helpTopicsToolStripMenuItem
            // 
            this.helpTopicsToolStripMenuItem.Image = global::CANStream.Icones.Help_16;
            this.helpTopicsToolStripMenuItem.Name = "helpTopicsToolStripMenuItem";
            this.helpTopicsToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.helpTopicsToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.helpTopicsToolStripMenuItem.Text = "Help topics";
            this.helpTopicsToolStripMenuItem.Click += new System.EventHandler(this.HelpTopicsToolStripMenuItemClick);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Image = global::CANStream.Icones.CANStream_16;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TS_Lbl_CanCfgTitle,
            this.TS_Lbl_CanCfg,
            this.TS_Lbl_CanCfgDesc,
            this.SS_TS_Lbl_RecordEvent,
            this.SS_TS_Lbl_RecordSession,
            this.TS_Lbl_ConversionProgress,
            this.TS_PB_Conversion,
            this.TSSL_StopConversion,
            this.TSS_Lbl_PCAN_Diag_Title,
            this.TSS_Lbl_PCAN_Diag_Text});
            this.statusStrip1.Location = new System.Drawing.Point(0, 605);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(962, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "FrmMain_StatusStrip";
            // 
            // TS_Lbl_CanCfgTitle
            // 
            this.TS_Lbl_CanCfgTitle.Name = "TS_Lbl_CanCfgTitle";
            this.TS_Lbl_CanCfgTitle.Size = new System.Drawing.Size(77, 26);
            this.TS_Lbl_CanCfgTitle.Text = "CAN Config :";
            this.TS_Lbl_CanCfgTitle.Visible = false;
            // 
            // TS_Lbl_CanCfg
            // 
            this.TS_Lbl_CanCfg.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TS_Lbl_CanCfg.Name = "TS_Lbl_CanCfg";
            this.TS_Lbl_CanCfg.Size = new System.Drawing.Size(22, 26);
            this.TS_Lbl_CanCfg.Text = "xxx";
            this.TS_Lbl_CanCfg.Visible = false;
            // 
            // TS_Lbl_CanCfgDesc
            // 
            this.TS_Lbl_CanCfgDesc.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.TS_Lbl_CanCfgDesc.Name = "TS_Lbl_CanCfgDesc";
            this.TS_Lbl_CanCfgDesc.Size = new System.Drawing.Size(22, 26);
            this.TS_Lbl_CanCfgDesc.Text = "xxx";
            this.TS_Lbl_CanCfgDesc.Visible = false;
            // 
            // SS_TS_Lbl_RecordEvent
            // 
            this.SS_TS_Lbl_RecordEvent.Name = "SS_TS_Lbl_RecordEvent";
            this.SS_TS_Lbl_RecordEvent.Size = new System.Drawing.Size(22, 17);
            this.SS_TS_Lbl_RecordEvent.Text = "xxx";
            // 
            // SS_TS_Lbl_RecordSession
            // 
            this.SS_TS_Lbl_RecordSession.Name = "SS_TS_Lbl_RecordSession";
            this.SS_TS_Lbl_RecordSession.Size = new System.Drawing.Size(22, 17);
            this.SS_TS_Lbl_RecordSession.Text = "xxx";
            // 
            // TS_Lbl_ConversionProgress
            // 
            this.TS_Lbl_ConversionProgress.Name = "TS_Lbl_ConversionProgress";
            this.TS_Lbl_ConversionProgress.Size = new System.Drawing.Size(115, 26);
            this.TS_Lbl_ConversionProgress.Text = "Conversion progress";
            this.TS_Lbl_ConversionProgress.Visible = false;
            // 
            // TS_PB_Conversion
            // 
            this.TS_PB_Conversion.Name = "TS_PB_Conversion";
            this.TS_PB_Conversion.Size = new System.Drawing.Size(100, 22);
            this.TS_PB_Conversion.Visible = false;
            // 
            // TSSL_StopConversion
            // 
            this.TSSL_StopConversion.AutoSize = false;
            this.TSSL_StopConversion.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TSSL_StopConversion.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.TSSL_StopConversion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSSL_StopConversion.Image = global::CANStream.Icones.Stop_Process_16;
            this.TSSL_StopConversion.Name = "TSSL_StopConversion";
            this.TSSL_StopConversion.Size = new System.Drawing.Size(23, 23);
            this.TSSL_StopConversion.Visible = false;
            this.TSSL_StopConversion.Click += new System.EventHandler(this.TSSL_StopConversionClick);
            // 
            // TSS_Lbl_PCAN_Diag_Title
            // 
            this.TSS_Lbl_PCAN_Diag_Title.ForeColor = System.Drawing.Color.Red;
            this.TSS_Lbl_PCAN_Diag_Title.Name = "TSS_Lbl_PCAN_Diag_Title";
            this.TSS_Lbl_PCAN_Diag_Title.Size = new System.Drawing.Size(22, 17);
            this.TSS_Lbl_PCAN_Diag_Title.Text = "xxx";
            this.TSS_Lbl_PCAN_Diag_Title.Visible = false;
            // 
            // TSS_Lbl_PCAN_Diag_Text
            // 
            this.TSS_Lbl_PCAN_Diag_Text.Name = "TSS_Lbl_PCAN_Diag_Text";
            this.TSS_Lbl_PCAN_Diag_Text.Size = new System.Drawing.Size(22, 17);
            this.TSS_Lbl_PCAN_Diag_Text.Text = "xxx";
            this.TSS_Lbl_PCAN_Diag_Text.Visible = false;
            // 
            // Tab_CAN_Controllers
            // 
            this.Tab_CAN_Controllers.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.Tab_CAN_Controllers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_CAN_Controllers.Controls.Add(this.TabPage_NewController);
            this.Tab_CAN_Controllers.ItemSize = new System.Drawing.Size(19, 19);
            this.Tab_CAN_Controllers.Location = new System.Drawing.Point(0, 27);
            this.Tab_CAN_Controllers.Multiline = true;
            this.Tab_CAN_Controllers.Name = "Tab_CAN_Controllers";
            this.Tab_CAN_Controllers.SelectedIndex = 0;
            this.Tab_CAN_Controllers.Size = new System.Drawing.Size(962, 575);
            this.Tab_CAN_Controllers.TabIndex = 6;
            this.Tab_CAN_Controllers.SelectedIndexChanged += new System.EventHandler(this.Tab_CAN_ControllersSelectedIndexChanged);
            this.Tab_CAN_Controllers.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tab_CAN_ControllersMouseClick);
            // 
            // TabPage_NewController
            // 
            this.TabPage_NewController.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.TabPage_NewController.Location = new System.Drawing.Point(23, 4);
            this.TabPage_NewController.Name = "TabPage_NewController";
            this.TabPage_NewController.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_NewController.Size = new System.Drawing.Size(935, 567);
            this.TabPage_NewController.TabIndex = 0;
            this.TabPage_NewController.Text = "+";
            this.TabPage_NewController.ToolTipText = "New CAN Controller";
            // 
            // Context_TabControllers
            // 
            this.Context_TabControllers.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeCANBusToolStripMenuItem});
            this.Context_TabControllers.Name = "Context_TabControllers";
            this.Context_TabControllers.Size = new System.Drawing.Size(154, 26);
            // 
            // closeCANBusToolStripMenuItem
            // 
            this.closeCANBusToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
            this.closeCANBusToolStripMenuItem.Name = "closeCANBusToolStripMenuItem";
            this.closeCANBusToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.closeCANBusToolStripMenuItem.Text = "Close CAN Bus";
            this.closeCANBusToolStripMenuItem.Click += new System.EventHandler(this.CloseCANBusToolStripMenuItemClick);
            // 
            // BGWrk_RecordConversion
            // 
            this.BGWrk_RecordConversion.WorkerReportsProgress = true;
            this.BGWrk_RecordConversion.WorkerSupportsCancellation = true;
            this.BGWrk_RecordConversion.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWrk_RecordConversionDoWork);
            this.BGWrk_RecordConversion.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWrk_RecordConversionProgressChanged);
            this.BGWrk_RecordConversion.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWrk_RecordConversionRunWorkerCompleted);
            // 
            // TSMI_Columns_Manual_Rx_Eng_RxTx
            // 
            this.TSMI_Columns_Manual_Rx_Eng_RxTx.Name = "TSMI_Columns_Manual_Rx_Eng_RxTx";
            this.TSMI_Columns_Manual_Rx_Eng_RxTx.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_RxTx.Text = "RxTx";
            this.TSMI_Columns_Manual_Rx_Eng_RxTx.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_RxTx_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Start
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Start.Name = "TSMI_Columns_Manual_Rx_Eng_Start";
            this.TSMI_Columns_Manual_Rx_Eng_Start.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Start.Text = "Start";
            this.TSMI_Columns_Manual_Rx_Eng_Start.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Start_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Length
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Length.Name = "TSMI_Columns_Manual_Rx_Eng_Length";
            this.TSMI_Columns_Manual_Rx_Eng_Length.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Length.Text = "Length";
            this.TSMI_Columns_Manual_Rx_Eng_Length.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Length_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Endianess
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Endianess.Name = "TSMI_Columns_Manual_Rx_Eng_Endianess";
            this.TSMI_Columns_Manual_Rx_Eng_Endianess.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Endianess.Text = "Endianess";
            this.TSMI_Columns_Manual_Rx_Eng_Endianess.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Endianess_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Signed
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Signed.Name = "TSMI_Columns_Manual_Rx_Eng_Signed";
            this.TSMI_Columns_Manual_Rx_Eng_Signed.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Signed.Text = "Signedness";
            this.TSMI_Columns_Manual_Rx_Eng_Signed.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Signed_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Gain
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Gain.Name = "TSMI_Columns_Manual_Rx_Eng_Gain";
            this.TSMI_Columns_Manual_Rx_Eng_Gain.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Gain.Text = "Gain";
            this.TSMI_Columns_Manual_Rx_Eng_Gain.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Gain_Click);
            // 
            // TSMI_Columns_Manual_Rx_Eng_Zero
            // 
            this.TSMI_Columns_Manual_Rx_Eng_Zero.Name = "TSMI_Columns_Manual_Rx_Eng_Zero";
            this.TSMI_Columns_Manual_Rx_Eng_Zero.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Manual_Rx_Eng_Zero.Text = "Zero";
            this.TSMI_Columns_Manual_Rx_Eng_Zero.Click += new System.EventHandler(this.TSMI_Columns_Manual_Rx_Eng_Zero_Click);
            // 
            // TSMI_Columns_Cycle_Eng_RxTx
            // 
            this.TSMI_Columns_Cycle_Eng_RxTx.Name = "TSMI_Columns_Cycle_Eng_RxTx";
            this.TSMI_Columns_Cycle_Eng_RxTx.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_RxTx.Text = "RxTx";
            this.TSMI_Columns_Cycle_Eng_RxTx.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_RxTx_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Start
            // 
            this.TSMI_Columns_Cycle_Eng_Start.Name = "TSMI_Columns_Cycle_Eng_Start";
            this.TSMI_Columns_Cycle_Eng_Start.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Start.Text = "Start";
            this.TSMI_Columns_Cycle_Eng_Start.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Start_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Length
            // 
            this.TSMI_Columns_Cycle_Eng_Length.Name = "TSMI_Columns_Cycle_Eng_Length";
            this.TSMI_Columns_Cycle_Eng_Length.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Length.Text = "Length";
            this.TSMI_Columns_Cycle_Eng_Length.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Length_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Endianess
            // 
            this.TSMI_Columns_Cycle_Eng_Endianess.Name = "TSMI_Columns_Cycle_Eng_Endianess";
            this.TSMI_Columns_Cycle_Eng_Endianess.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Endianess.Text = "Endianess";
            this.TSMI_Columns_Cycle_Eng_Endianess.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Endianess_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Signedness
            // 
            this.TSMI_Columns_Cycle_Eng_Signedness.Name = "TSMI_Columns_Cycle_Eng_Signedness";
            this.TSMI_Columns_Cycle_Eng_Signedness.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Signedness.Text = "Signedness";
            this.TSMI_Columns_Cycle_Eng_Signedness.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Signedness_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Gain
            // 
            this.TSMI_Columns_Cycle_Eng_Gain.Name = "TSMI_Columns_Cycle_Eng_Gain";
            this.TSMI_Columns_Cycle_Eng_Gain.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Gain.Text = "Gain";
            this.TSMI_Columns_Cycle_Eng_Gain.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Gain_Click);
            // 
            // TSMI_Columns_Cycle_Eng_Zero
            // 
            this.TSMI_Columns_Cycle_Eng_Zero.Name = "TSMI_Columns_Cycle_Eng_Zero";
            this.TSMI_Columns_Cycle_Eng_Zero.Size = new System.Drawing.Size(152, 22);
            this.TSMI_Columns_Cycle_Eng_Zero.Text = "Zero";
            this.TSMI_Columns_Cycle_Eng_Zero.Click += new System.EventHandler(this.TSMI_Columns_Cycle_Eng_Zero_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(962, 627);
            this.Controls.Add(this.Tab_CAN_Controllers);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.FrmMain_MenuStrip);
            this.Icon = global::CANStream.Icones.CANStream_Icone;
            this.MainMenuStrip = this.FrmMain_MenuStrip;
            this.Name = "MainForm";
            this.Text = "CANStream";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormFormClosing);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.Shown += new System.EventHandler(this.MainFormShown);
            this.FrmMain_MenuStrip.ResumeLayout(false);
            this.FrmMain_MenuStrip.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.Tab_CAN_Controllers.ResumeLayout(false);
            this.Context_TabControllers.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem newTriggerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recordingTriggerToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openMessageListToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem saveMessageListToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem clearMessagesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem delMessageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem addMessageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem rawMessagesTxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Manual_Rx_Graph;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Manual_Rx_Data;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Manual_Tx_Raw;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Manual_Tx_Eng;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Manual_Rx;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Manual_Tx;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Cycle_Graph;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Cycle_Data;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Reset;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Cycle;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Layout_Manual;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Layout;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Comment;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Unit;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Max;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Min;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_RawVal;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Value;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_ID;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_HideAll;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_ShowAll;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual;
		private System.Windows.Forms.ToolStripMenuItem helpTopicsToolStripMenuItem;
		private System.Windows.Forms.ToolStripStatusLabel TSS_Lbl_PCAN_Diag_Text;
		private System.Windows.Forms.ToolStripStatusLabel TSS_Lbl_PCAN_Diag_Title;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_HideAll;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_ShowAll;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_HideAll;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_ShowAll;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_ID;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Signedness;
		private System.Windows.Forms.ToolStripMenuItem Cycle_new_RecordReplay_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripLabel TS_Lbl_CanCfgDesc;
		private System.Windows.Forms.ToolStripStatusLabel TSSL_StopConversion;
		private System.Windows.Forms.ToolStripProgressBar TS_PB_Conversion;
		private System.Windows.Forms.ToolStripLabel TS_Lbl_ConversionProgress;
		private System.ComponentModel.BackgroundWorker BGWrk_RecordConversion;
		private System.Windows.Forms.ToolStripMenuItem closeCANBusToolStripMenuItem;
		private System.Windows.Forms.ContextMenuStrip Context_TabControllers;
		private System.Windows.Forms.TabPage TabPage_NewController;
		private System.Windows.Forms.TabControl Tab_CAN_Controllers;
		private System.Windows.Forms.ToolStripStatusLabel SS_TS_Lbl_RecordSession;
		private System.Windows.Forms.ToolStripStatusLabel SS_TS_Lbl_RecordEvent;
		private System.Windows.Forms.ToolStripMenuItem editRecordingSessionDetailsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectRecordingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newRecordingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recordingSessionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem editRecordingEventDetailsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectRecordingEventToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem newRecordingEventToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem recordingEventToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cycle_CancelStartEndPoint_TSMI;
		private System.Windows.Forms.ToolStripMenuItem Cycle_ConfirmStartEndPoints_TSMI;
		private System.Windows.Forms.ToolStripMenuItem Cycle_SetEndPoint_TSMI;
		private System.Windows.Forms.ToolStripMenuItem Cycle_SetStartPoint_TSMI;
		private System.Windows.Forms.ToolStripMenuItem Cycle_SetStartEndPoints_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Tools_DataViewer_Open_TSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Tools_DataViewer_New_TSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Tools_DataViewer_TSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cycle_new_AdvancedCreation_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Cycle_new_EasyCreation_ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Comment;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Unit;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Max;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Min;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_RawVal;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Value;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_ID;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Mux;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Comment;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Unit;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Zero;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Gain;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Endianess;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Length;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Start;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_Period;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx_RxTx;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Tx;
		private System.Windows.Forms.ToolStripMenuItem TSMI_Columns;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem builtinSignalsToolStripMenuItem;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.ToolStripLabel TS_Lbl_CanCfg;
		private System.Windows.Forms.ToolStripLabel TS_Lbl_CanCfgTitle;
		private System.Windows.Forms.ToolStripMenuItem virtualChannelsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem Tools_TSMenuItem;
		private System.Windows.Forms.ToolStripMenuItem TSMI_ShowHiddenRows;
		private System.Windows.Forms.ToolStripMenuItem TSMI_HideSelectedRows;
		private System.Windows.Forms.ToolStripMenuItem ViewtoolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem importDBCToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem stopRecordConversionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem automaticRecordsConversionToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectRecordsToConvertToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem convertAllRecordsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem convertRecordsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem automaticRecordingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem stopRecordingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem startRecordingToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;

        private System.Windows.Forms.MenuStrip FrmMain_MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem cANConfigurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CANConfig_newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CANConfig_openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CANConfig_editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cycleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cycle_newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Cycle_openToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCycledataAssociationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCycledataAssociationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Period;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Count;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_DLC;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Period;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Count;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_DLC;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_RxTx;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Start;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Length;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Endianess;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Signed;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Gain;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Manual_Rx_Eng_Zero;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_RxTx;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Start;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Length;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Endianess;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Signedness;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Gain;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Columns_Cycle_Eng_Zero;
    }
}
