/*
 *	This file is part of CANStream.
 *
 *	CANStream program is free software: you can redistribute it and/or modify
 *	it under the terms of the GNU General Public License as published by
 *	the Free Software Foundation, either version 3 of the License, or
 *	(at your option) any later version.
 *
 *	This program is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *	GNU General Public License for more details.
 *
 *	You should have received a copy of the GNU General Public License
 *	along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 *	CANStream Copyright © 2013-2016 whilenotinfinite@gmail.com
 */

namespace CANStream
{
	partial class Ctrl_CS_CAN_Bus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ctrl_CS_CAN_Bus));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.CtrlMain_ToolStrip = new System.Windows.Forms.ToolStrip();
            this.TSB_Refresh_USB_CAN_Device = new System.Windows.Forms.ToolStripButton();
            this.TS_Cmb_PCAN_USB_Devices = new System.Windows.Forms.ToolStripComboBox();
            this.TS_Lbl_CanSpeed = new System.Windows.Forms.ToolStripLabel();
            this.TSB_CAN_LinkOff = new System.Windows.Forms.ToolStripButton();
            this.TSB_CAN_LinkOn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_StartCANTraceRecording = new System.Windows.Forms.ToolStripButton();
            this.TSB_StopCANTraceRecording = new System.Windows.Forms.ToolStripButton();
            this.TSB_RecordSelection = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSSB_View = new System.Windows.Forms.ToolStripSplitButton();
            this.TSMI_SpyManual = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_TxMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_TxMessages_Eng = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_TxMessages_Raw = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_RxMessages = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_RxMessages_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_RxMessages_Graph = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_CyclePlayer = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_CyclePlayer_Data = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_CyclePlayer_Graph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSMI_ResetLayout = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TabPg_SpyAndManual = new System.Windows.Forms.TabPage();
            this.Split_RxTx = new System.Windows.Forms.SplitContainer();
            this.Split_Tx_EngRaw = new System.Windows.Forms.SplitContainer();
            this.Grid_CANRawData = new System.Windows.Forms.DataGridView();
            this.GridCol_Raw_Tx_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_DLC = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_Period = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_Sent = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.GridCol_Raw_Tx_BtnTx = new System.Windows.Forms.DataGridViewButtonColumn();
            this.GridCol_Raw_Tx_Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GridCol_Raw_Tx_B7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Context_ManualRawGrid = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Ctxt_TxRaw_Add_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctxt_TxRaw_Del_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctxt_TxRaw_Clear_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.Ctxt_TxRaw_Save_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Ctxt_TxRaw_Open_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Cmd_RxOnly = new System.Windows.Forms.Button();
            this.Pic_ManualRunning = new System.Windows.Forms.PictureBox();
            this.Chk_VirtualParamTxEnabled = new System.Windows.Forms.CheckBox();
            this.Chk_CycleMux = new System.Windows.Forms.CheckBox();
            this.Cmb_SpyCANRate = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Txt_SpyIdFilterMax = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Txt_SpyIdFilterMin = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Cmb_SpyCANRxMode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Cmd_StopSpy = new System.Windows.Forms.Button();
            this.Cmd_StartSpy = new System.Windows.Forms.Button();
            this.TabPg_Cycle = new System.Windows.Forms.TabPage();
            this.Panel_Cycle = new System.Windows.Forms.Panel();
            this.Split_Cycle_VirtualSig_Graph = new System.Windows.Forms.SplitContainer();
            this.Context_CycleGraph = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Chk_CycleVirtualParamTxEnabled = new System.Windows.Forms.CheckBox();
            this.Txt_CycleEnd = new System.Windows.Forms.TextBox();
            this.Txt_CycleStart = new System.Windows.Forms.TextBox();
            this.Lbl_CycleEnd = new System.Windows.Forms.Label();
            this.Lbl_CycleStart = new System.Windows.Forms.Label();
            this.Chk_InfinitePlay = new System.Windows.Forms.CheckBox();
            this.Lbl_TotalProgress = new System.Windows.Forms.Label();
            this.Txt_CurrentCycleNum = new System.Windows.Forms.TextBox();
            this.Lbl_CurrentCycleNum = new System.Windows.Forms.Label();
            this.PB_TotalProgress = new System.Windows.Forms.ProgressBar();
            this.PB_CurrentProgress = new System.Windows.Forms.ProgressBar();
            this.Lbl_CurrentProgress = new System.Windows.Forms.Label();
            this.Lbl_CycleCount = new System.Windows.Forms.Label();
            this.NumUpDown_CycleCount = new System.Windows.Forms.NumericUpDown();
            this.Cmd_StopCycle = new System.Windows.Forms.Button();
            this.Cmd_BreakCycle = new System.Windows.Forms.Button();
            this.Cmd_PlayCycle = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rTxt_CycleComments = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Lbl_CanConfig = new System.Windows.Forms.Label();
            this.Lbl_CycleFile = new System.Windows.Forms.Label();
            this.Img_TabControl = new System.Windows.Forms.ImageList(this.components);
            this.Timer_CheckDevice = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.BGWrk_Spy = new System.ComponentModel.BackgroundWorker();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.Timer_NoRx = new System.Windows.Forms.Timer(this.components);
            this.ToolTip_CmdRxOnly = new System.Windows.Forms.ToolTip(this.components);
            this.Split_Rx_DataGraph = new System.Windows.Forms.SplitContainer();
            this.Tab_SpyHistory = new System.Windows.Forms.TabControl();
            this.Tab_SpyHistory_Graph = new System.Windows.Forms.TabPage();
            this.Tab_SpyHistory_Data = new System.Windows.Forms.TabPage();
            this.Lst_SpyDataHistory = new System.Windows.Forms.ListBox();
            this.TS_SpyDataHistory = new System.Windows.Forms.ToolStrip();
            this.TSB_FreezeHistory = new System.Windows.Forms.ToolStripButton();
            this.TSB_ResumeHistory = new System.Windows.Forms.ToolStripButton();
            this.TSB_ClearHistory = new System.Windows.Forms.ToolStripButton();
            this.TSB_ExportHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TSLbl_IdFilterFrom = new System.Windows.Forms.ToolStripLabel();
            this.TSTxt_IdFilterFrom = new System.Windows.Forms.ToolStripTextBox();
            this.TSLbl_IdFilterTo = new System.Windows.Forms.ToolStripLabel();
            this.TSTxt_IdFilterTo = new System.Windows.Forms.ToolStripTextBox();
            this.Grid_ManualDataWriter = new CANStream.Ctrl_CANDataGrid();
            this.Grid_ManualDataViewer = new CANStream.Ctrl_CANDataGrid();
            this.Graph_SpyData = new Ctrl_GraphWindow.Ctrl_WaveForm();
            this.Cycle_SpyDataViewer = new CANStream.Ctrl_CANDataGrid();
            this.Graph_Cycle = new Ctrl_GraphWindow.Ctrl_WaveForm();
            this.CtrlMain_ToolStrip.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TabPg_SpyAndManual.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split_RxTx)).BeginInit();
            this.Split_RxTx.Panel1.SuspendLayout();
            this.Split_RxTx.Panel2.SuspendLayout();
            this.Split_RxTx.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split_Tx_EngRaw)).BeginInit();
            this.Split_Tx_EngRaw.Panel1.SuspendLayout();
            this.Split_Tx_EngRaw.Panel2.SuspendLayout();
            this.Split_Tx_EngRaw.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_CANRawData)).BeginInit();
            this.Context_ManualRawGrid.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_ManualRunning)).BeginInit();
            this.TabPg_Cycle.SuspendLayout();
            this.Panel_Cycle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split_Cycle_VirtualSig_Graph)).BeginInit();
            this.Split_Cycle_VirtualSig_Graph.Panel1.SuspendLayout();
            this.Split_Cycle_VirtualSig_Graph.Panel2.SuspendLayout();
            this.Split_Cycle_VirtualSig_Graph.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_CycleCount)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Split_Rx_DataGraph)).BeginInit();
            this.Split_Rx_DataGraph.Panel1.SuspendLayout();
            this.Split_Rx_DataGraph.Panel2.SuspendLayout();
            this.Split_Rx_DataGraph.SuspendLayout();
            this.Tab_SpyHistory.SuspendLayout();
            this.Tab_SpyHistory_Graph.SuspendLayout();
            this.Tab_SpyHistory_Data.SuspendLayout();
            this.TS_SpyDataHistory.SuspendLayout();
            this.SuspendLayout();
            // 
            // CtrlMain_ToolStrip
            // 
            this.CtrlMain_ToolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.CtrlMain_ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_Refresh_USB_CAN_Device,
            this.TS_Cmb_PCAN_USB_Devices,
            this.TS_Lbl_CanSpeed,
            this.TSB_CAN_LinkOff,
            this.TSB_CAN_LinkOn,
            this.toolStripSeparator2,
            this.TSB_StartCANTraceRecording,
            this.TSB_StopCANTraceRecording,
            this.TSB_RecordSelection,
            this.toolStripSeparator1,
            this.TSSB_View});
            this.CtrlMain_ToolStrip.Location = new System.Drawing.Point(0, 0);
            this.CtrlMain_ToolStrip.Name = "CtrlMain_ToolStrip";
            this.CtrlMain_ToolStrip.Size = new System.Drawing.Size(1304, 28);
            this.CtrlMain_ToolStrip.TabIndex = 7;
            this.CtrlMain_ToolStrip.Text = "toolStrip1";
            // 
            // TSB_Refresh_USB_CAN_Device
            // 
            this.TSB_Refresh_USB_CAN_Device.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Refresh_USB_CAN_Device.Image = global::CANStream.Icones.Refresh_CAN_Controllers;
            this.TSB_Refresh_USB_CAN_Device.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Refresh_USB_CAN_Device.Name = "TSB_Refresh_USB_CAN_Device";
            this.TSB_Refresh_USB_CAN_Device.Size = new System.Drawing.Size(24, 25);
            this.TSB_Refresh_USB_CAN_Device.Text = "toolStripButton4";
            this.TSB_Refresh_USB_CAN_Device.ToolTipText = "Refresh PCAN USB Devices list";
            this.TSB_Refresh_USB_CAN_Device.Click += new System.EventHandler(this.TSB_Refresh_USB_CAN_DeviceClick);
            // 
            // TS_Cmb_PCAN_USB_Devices
            // 
            this.TS_Cmb_PCAN_USB_Devices.BackColor = System.Drawing.SystemColors.Control;
            this.TS_Cmb_PCAN_USB_Devices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TS_Cmb_PCAN_USB_Devices.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.TS_Cmb_PCAN_USB_Devices.Name = "TS_Cmb_PCAN_USB_Devices";
            this.TS_Cmb_PCAN_USB_Devices.Size = new System.Drawing.Size(160, 28);
            this.TS_Cmb_PCAN_USB_Devices.SelectedIndexChanged += new System.EventHandler(this.TS_Cmb_PCAN_USB_DevicesSelectedIndexChanged);
            // 
            // TS_Lbl_CanSpeed
            // 
            this.TS_Lbl_CanSpeed.Enabled = false;
            this.TS_Lbl_CanSpeed.Name = "TS_Lbl_CanSpeed";
            this.TS_Lbl_CanSpeed.Size = new System.Drawing.Size(110, 25);
            this.TS_Lbl_CanSpeed.Text = "CAN Baud rate:";
            // 
            // TSB_CAN_LinkOff
            // 
            this.TSB_CAN_LinkOff.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_CAN_LinkOff.Image = global::CANStream.Icones.CAN_Link_Off;
            this.TSB_CAN_LinkOff.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_CAN_LinkOff.Name = "TSB_CAN_LinkOff";
            this.TSB_CAN_LinkOff.Size = new System.Drawing.Size(24, 25);
            this.TSB_CAN_LinkOff.Text = "toolStripButton4";
            this.TSB_CAN_LinkOff.ToolTipText = "Start connection";
            this.TSB_CAN_LinkOff.Click += new System.EventHandler(this.TSB_CAN_LinkOffClick);
            // 
            // TSB_CAN_LinkOn
            // 
            this.TSB_CAN_LinkOn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_CAN_LinkOn.Image = global::CANStream.Icones.CAN_Link_On;
            this.TSB_CAN_LinkOn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_CAN_LinkOn.Name = "TSB_CAN_LinkOn";
            this.TSB_CAN_LinkOn.Size = new System.Drawing.Size(24, 25);
            this.TSB_CAN_LinkOn.Text = "toolStripButton5";
            this.TSB_CAN_LinkOn.ToolTipText = "Stop connection";
            this.TSB_CAN_LinkOn.Visible = false;
            this.TSB_CAN_LinkOn.Click += new System.EventHandler(this.TSB_CAN_LinkOnClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 28);
            // 
            // TSB_StartCANTraceRecording
            // 
            this.TSB_StartCANTraceRecording.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_StartCANTraceRecording.Enabled = false;
            this.TSB_StartCANTraceRecording.Image = global::CANStream.Icones.Start_Record;
            this.TSB_StartCANTraceRecording.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_StartCANTraceRecording.Name = "TSB_StartCANTraceRecording";
            this.TSB_StartCANTraceRecording.Size = new System.Drawing.Size(24, 25);
            this.TSB_StartCANTraceRecording.Text = "toolStripButton4";
            this.TSB_StartCANTraceRecording.ToolTipText = "Start stream recording";
            this.TSB_StartCANTraceRecording.Click += new System.EventHandler(this.TSB_StartCANTraceRecordingClick);
            // 
            // TSB_StopCANTraceRecording
            // 
            this.TSB_StopCANTraceRecording.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_StopCANTraceRecording.Enabled = false;
            this.TSB_StopCANTraceRecording.Image = global::CANStream.Icones.Stop_Recording;
            this.TSB_StopCANTraceRecording.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_StopCANTraceRecording.Name = "TSB_StopCANTraceRecording";
            this.TSB_StopCANTraceRecording.Size = new System.Drawing.Size(24, 25);
            this.TSB_StopCANTraceRecording.Text = "toolStripButton5";
            this.TSB_StopCANTraceRecording.ToolTipText = "Stop stream recording";
            this.TSB_StopCANTraceRecording.Click += new System.EventHandler(this.TSB_StopCANTraceRecordingClick);
            // 
            // TSB_RecordSelection
            // 
            this.TSB_RecordSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_RecordSelection.Image = global::CANStream.Icones.Run_Process_16;
            this.TSB_RecordSelection.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_RecordSelection.Name = "TSB_RecordSelection";
            this.TSB_RecordSelection.Size = new System.Drawing.Size(24, 25);
            this.TSB_RecordSelection.Text = "TSB_RecordSelection";
            this.TSB_RecordSelection.ToolTipText = "Select record to convert";
            this.TSB_RecordSelection.Click += new System.EventHandler(this.TSB_RecordSelection_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 28);
            // 
            // TSSB_View
            // 
            this.TSSB_View.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSSB_View.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_SpyManual,
            this.TSMI_CyclePlayer,
            this.toolStripMenuItem2,
            this.TSMI_ResetLayout});
            this.TSSB_View.Image = global::CANStream.Icones.Controller_Layout;
            this.TSSB_View.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSSB_View.Name = "TSSB_View";
            this.TSSB_View.Size = new System.Drawing.Size(39, 25);
            this.TSSB_View.Text = "toolStripSplitButton1";
            this.TSSB_View.ToolTipText = "View";
            // 
            // TSMI_SpyManual
            // 
            this.TSMI_SpyManual.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_TxMessages,
            this.TSMI_RxMessages});
            this.TSMI_SpyManual.Image = ((System.Drawing.Image)(resources.GetObject("TSMI_SpyManual.Image")));
            this.TSMI_SpyManual.Name = "TSMI_SpyManual";
            this.TSMI_SpyManual.Size = new System.Drawing.Size(190, 26);
            this.TSMI_SpyManual.Text = "Spy and Manual";
            // 
            // TSMI_TxMessages
            // 
            this.TSMI_TxMessages.Checked = true;
            this.TSMI_TxMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_TxMessages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_TxMessages_Eng,
            this.TSMI_TxMessages_Raw});
            this.TSMI_TxMessages.Image = global::CANStream.Icones.Message_Tx;
            this.TSMI_TxMessages.Name = "TSMI_TxMessages";
            this.TSMI_TxMessages.Size = new System.Drawing.Size(168, 26);
            this.TSMI_TxMessages.Text = "Messages Tx";
            this.TSMI_TxMessages.ToolTipText = "Show/Hide CAN Transmission control";
            this.TSMI_TxMessages.Click += new System.EventHandler(this.TSMI_TxMessagesClick);
            // 
            // TSMI_TxMessages_Eng
            // 
            this.TSMI_TxMessages_Eng.Checked = true;
            this.TSMI_TxMessages_Eng.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_TxMessages_Eng.Image = global::CANStream.Icones.Engineering_Data;
            this.TSMI_TxMessages_Eng.Name = "TSMI_TxMessages_Eng";
            this.TSMI_TxMessages_Eng.Size = new System.Drawing.Size(231, 26);
            this.TSMI_TxMessages_Eng.Text = "Engineering messages";
            this.TSMI_TxMessages_Eng.Click += new System.EventHandler(this.TSMI_TxMessages_EngClick);
            // 
            // TSMI_TxMessages_Raw
            // 
            this.TSMI_TxMessages_Raw.Checked = true;
            this.TSMI_TxMessages_Raw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_TxMessages_Raw.Image = global::CANStream.Icones.Raw_Data;
            this.TSMI_TxMessages_Raw.Name = "TSMI_TxMessages_Raw";
            this.TSMI_TxMessages_Raw.Size = new System.Drawing.Size(231, 26);
            this.TSMI_TxMessages_Raw.Text = "Raw messages";
            this.TSMI_TxMessages_Raw.Click += new System.EventHandler(this.TSMI_TxMessages_RawClick);
            // 
            // TSMI_RxMessages
            // 
            this.TSMI_RxMessages.Checked = true;
            this.TSMI_RxMessages.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_RxMessages.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_RxMessages_Data,
            this.TSMI_RxMessages_Graph});
            this.TSMI_RxMessages.Image = global::CANStream.Icones.Message_Rx;
            this.TSMI_RxMessages.Name = "TSMI_RxMessages";
            this.TSMI_RxMessages.Size = new System.Drawing.Size(168, 26);
            this.TSMI_RxMessages.Text = "Messages Rx";
            this.TSMI_RxMessages.ToolTipText = "Show/Hide CAN Spy control";
            this.TSMI_RxMessages.Click += new System.EventHandler(this.TSMI_RxMessagesClick);
            // 
            // TSMI_RxMessages_Data
            // 
            this.TSMI_RxMessages_Data.Checked = true;
            this.TSMI_RxMessages_Data.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_RxMessages_Data.Image = global::CANStream.Icones.Message_Rx;
            this.TSMI_RxMessages_Data.Name = "TSMI_RxMessages_Data";
            this.TSMI_RxMessages_Data.Size = new System.Drawing.Size(124, 26);
            this.TSMI_RxMessages_Data.Text = "Data";
            this.TSMI_RxMessages_Data.ToolTipText = "Show/Hide CAN Spy control data";
            this.TSMI_RxMessages_Data.Click += new System.EventHandler(this.TSMI_RxMessages_DataClick);
            // 
            // TSMI_RxMessages_Graph
            // 
            this.TSMI_RxMessages_Graph.Checked = true;
            this.TSMI_RxMessages_Graph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_RxMessages_Graph.Image = global::CANStream.Icones.Graph;
            this.TSMI_RxMessages_Graph.Name = "TSMI_RxMessages_Graph";
            this.TSMI_RxMessages_Graph.Size = new System.Drawing.Size(124, 26);
            this.TSMI_RxMessages_Graph.Text = "Graph";
            this.TSMI_RxMessages_Graph.ToolTipText = "Show/Hide CAN Spy control graph";
            this.TSMI_RxMessages_Graph.Click += new System.EventHandler(this.TSMI_RxMessages_GraphClick);
            // 
            // TSMI_CyclePlayer
            // 
            this.TSMI_CyclePlayer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_CyclePlayer_Data,
            this.TSMI_CyclePlayer_Graph});
            this.TSMI_CyclePlayer.Enabled = false;
            this.TSMI_CyclePlayer.Image = global::CANStream.Icones.Cycle_16;
            this.TSMI_CyclePlayer.Name = "TSMI_CyclePlayer";
            this.TSMI_CyclePlayer.Size = new System.Drawing.Size(190, 26);
            this.TSMI_CyclePlayer.Text = "Cycle player";
            // 
            // TSMI_CyclePlayer_Data
            // 
            this.TSMI_CyclePlayer_Data.Checked = true;
            this.TSMI_CyclePlayer_Data.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_CyclePlayer_Data.Image = global::CANStream.Icones.Message_Rx;
            this.TSMI_CyclePlayer_Data.Name = "TSMI_CyclePlayer_Data";
            this.TSMI_CyclePlayer_Data.Size = new System.Drawing.Size(124, 26);
            this.TSMI_CyclePlayer_Data.Text = "Data";
            this.TSMI_CyclePlayer_Data.Click += new System.EventHandler(this.TSMI_CyclePlayer_DataClick);
            // 
            // TSMI_CyclePlayer_Graph
            // 
            this.TSMI_CyclePlayer_Graph.Checked = true;
            this.TSMI_CyclePlayer_Graph.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TSMI_CyclePlayer_Graph.Image = global::CANStream.Icones.Graph;
            this.TSMI_CyclePlayer_Graph.Name = "TSMI_CyclePlayer_Graph";
            this.TSMI_CyclePlayer_Graph.Size = new System.Drawing.Size(124, 26);
            this.TSMI_CyclePlayer_Graph.Text = "Graph";
            this.TSMI_CyclePlayer_Graph.Click += new System.EventHandler(this.TSMI_CyclePlayer_GraphClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(187, 6);
            // 
            // TSMI_ResetLayout
            // 
            this.TSMI_ResetLayout.Image = global::CANStream.Icones.Controller_Layout;
            this.TSMI_ResetLayout.Name = "TSMI_ResetLayout";
            this.TSMI_ResetLayout.Size = new System.Drawing.Size(190, 26);
            this.TSMI_ResetLayout.Text = "Reset";
            this.TSMI_ResetLayout.ToolTipText = "Reset layout to default";
            this.TSMI_ResetLayout.Click += new System.EventHandler(this.TSMI_ResetLayoutClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.TabPg_SpyAndManual);
            this.tabControl1.Controls.Add(this.TabPg_Cycle);
            this.tabControl1.ImageList = this.Img_TabControl;
            this.tabControl1.Location = new System.Drawing.Point(0, 34);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1300, 784);
            this.tabControl1.TabIndex = 8;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.TabControl1SelectedIndexChanged);
            this.tabControl1.Deselecting += new System.Windows.Forms.TabControlCancelEventHandler(this.TabControl1Deselecting);
            // 
            // TabPg_SpyAndManual
            // 
            this.TabPg_SpyAndManual.BackColor = System.Drawing.SystemColors.Control;
            this.TabPg_SpyAndManual.Controls.Add(this.Split_RxTx);
            this.TabPg_SpyAndManual.Controls.Add(this.groupBox4);
            this.TabPg_SpyAndManual.ImageIndex = 0;
            this.TabPg_SpyAndManual.Location = new System.Drawing.Point(4, 25);
            this.TabPg_SpyAndManual.Margin = new System.Windows.Forms.Padding(4);
            this.TabPg_SpyAndManual.Name = "TabPg_SpyAndManual";
            this.TabPg_SpyAndManual.Size = new System.Drawing.Size(1292, 755);
            this.TabPg_SpyAndManual.TabIndex = 4;
            this.TabPg_SpyAndManual.Tag = "1";
            this.TabPg_SpyAndManual.Text = "Spy & Manual";
            // 
            // Split_RxTx
            // 
            this.Split_RxTx.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Split_RxTx.Location = new System.Drawing.Point(0, 89);
            this.Split_RxTx.Margin = new System.Windows.Forms.Padding(4);
            this.Split_RxTx.Name = "Split_RxTx";
            // 
            // Split_RxTx.Panel1
            // 
            this.Split_RxTx.Panel1.Controls.Add(this.Split_Tx_EngRaw);
            // 
            // Split_RxTx.Panel2
            // 
            this.Split_RxTx.Panel2.Controls.Add(this.Split_Rx_DataGraph);
            this.Split_RxTx.Size = new System.Drawing.Size(1289, 662);
            this.Split_RxTx.SplitterDistance = 598;
            this.Split_RxTx.SplitterWidth = 5;
            this.Split_RxTx.TabIndex = 3;
            // 
            // Split_Tx_EngRaw
            // 
            this.Split_Tx_EngRaw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split_Tx_EngRaw.Location = new System.Drawing.Point(0, 0);
            this.Split_Tx_EngRaw.Margin = new System.Windows.Forms.Padding(4);
            this.Split_Tx_EngRaw.Name = "Split_Tx_EngRaw";
            this.Split_Tx_EngRaw.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Split_Tx_EngRaw.Panel1
            // 
            this.Split_Tx_EngRaw.Panel1.Controls.Add(this.Grid_ManualDataWriter);
            // 
            // Split_Tx_EngRaw.Panel2
            // 
            this.Split_Tx_EngRaw.Panel2.Controls.Add(this.Grid_CANRawData);
            this.Split_Tx_EngRaw.Size = new System.Drawing.Size(598, 662);
            this.Split_Tx_EngRaw.SplitterDistance = 504;
            this.Split_Tx_EngRaw.SplitterWidth = 5;
            this.Split_Tx_EngRaw.TabIndex = 0;
            // 
            // Grid_CANRawData
            // 
            this.Grid_CANRawData.AllowUserToAddRows = false;
            this.Grid_CANRawData.AllowUserToDeleteRows = false;
            this.Grid_CANRawData.AllowUserToResizeColumns = false;
            this.Grid_CANRawData.AllowUserToResizeRows = false;
            this.Grid_CANRawData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_CANRawData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_CANRawData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GridCol_Raw_Tx_Id,
            this.GridCol_Raw_Tx_DLC,
            this.GridCol_Raw_Tx_Period,
            this.GridCol_Raw_Tx_Sent,
            this.GridCol_Raw_Tx_BtnTx,
            this.GridCol_Raw_Tx_Count,
            this.GridCol_Raw_Tx_B0,
            this.GridCol_Raw_Tx_B1,
            this.GridCol_Raw_Tx_B2,
            this.GridCol_Raw_Tx_B3,
            this.GridCol_Raw_Tx_B4,
            this.GridCol_Raw_Tx_B5,
            this.GridCol_Raw_Tx_B6,
            this.GridCol_Raw_Tx_B7});
            this.Grid_CANRawData.ContextMenuStrip = this.Context_ManualRawGrid;
            this.Grid_CANRawData.Location = new System.Drawing.Point(4, 0);
            this.Grid_CANRawData.Margin = new System.Windows.Forms.Padding(4);
            this.Grid_CANRawData.Name = "Grid_CANRawData";
            this.Grid_CANRawData.RowHeadersVisible = false;
            this.Grid_CANRawData.RowHeadersWidth = 40;
            this.Grid_CANRawData.Size = new System.Drawing.Size(594, 152);
            this.Grid_CANRawData.TabIndex = 8;
            this.Grid_CANRawData.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.Grid_CANRawData_CellBeginEdit);
            this.Grid_CANRawData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CANRawDataCellClick);
            this.Grid_CANRawData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CANRawDataCellValueChanged);
            this.Grid_CANRawData.SizeChanged += new System.EventHandler(this.Grid_CANRawDataSizeChanged);
            this.Grid_CANRawData.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.Grid_CANRawData_PreviewKeyDown);
            // 
            // GridCol_Raw_Tx_Id
            // 
            this.GridCol_Raw_Tx_Id.HeaderText = "ID";
            this.GridCol_Raw_Tx_Id.MinimumWidth = 40;
            this.GridCol_Raw_Tx_Id.Name = "GridCol_Raw_Tx_Id";
            this.GridCol_Raw_Tx_Id.Width = 50;
            // 
            // GridCol_Raw_Tx_DLC
            // 
            this.GridCol_Raw_Tx_DLC.HeaderText = "DLC";
            this.GridCol_Raw_Tx_DLC.MinimumWidth = 20;
            this.GridCol_Raw_Tx_DLC.Name = "GridCol_Raw_Tx_DLC";
            this.GridCol_Raw_Tx_DLC.Width = 40;
            // 
            // GridCol_Raw_Tx_Period
            // 
            this.GridCol_Raw_Tx_Period.HeaderText = "Period";
            this.GridCol_Raw_Tx_Period.MinimumWidth = 20;
            this.GridCol_Raw_Tx_Period.Name = "GridCol_Raw_Tx_Period";
            this.GridCol_Raw_Tx_Period.Width = 40;
            // 
            // GridCol_Raw_Tx_Sent
            // 
            this.GridCol_Raw_Tx_Sent.HeaderText = "Send";
            this.GridCol_Raw_Tx_Sent.MinimumWidth = 30;
            this.GridCol_Raw_Tx_Sent.Name = "GridCol_Raw_Tx_Sent";
            this.GridCol_Raw_Tx_Sent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GridCol_Raw_Tx_Sent.Width = 40;
            // 
            // GridCol_Raw_Tx_BtnTx
            // 
            this.GridCol_Raw_Tx_BtnTx.HeaderText = "Tx";
            this.GridCol_Raw_Tx_BtnTx.Name = "GridCol_Raw_Tx_BtnTx";
            this.GridCol_Raw_Tx_BtnTx.Text = "Tx";
            this.GridCol_Raw_Tx_BtnTx.ToolTipText = "Send frame now";
            // 
            // GridCol_Raw_Tx_Count
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.GridCol_Raw_Tx_Count.DefaultCellStyle = dataGridViewCellStyle1;
            this.GridCol_Raw_Tx_Count.HeaderText = "Count";
            this.GridCol_Raw_Tx_Count.MinimumWidth = 20;
            this.GridCol_Raw_Tx_Count.Name = "GridCol_Raw_Tx_Count";
            this.GridCol_Raw_Tx_Count.ReadOnly = true;
            this.GridCol_Raw_Tx_Count.Width = 40;
            // 
            // GridCol_Raw_Tx_B0
            // 
            this.GridCol_Raw_Tx_B0.HeaderText = "B0";
            this.GridCol_Raw_Tx_B0.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B0.Name = "GridCol_Raw_Tx_B0";
            this.GridCol_Raw_Tx_B0.Width = 30;
            // 
            // GridCol_Raw_Tx_B1
            // 
            this.GridCol_Raw_Tx_B1.HeaderText = "B1";
            this.GridCol_Raw_Tx_B1.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B1.Name = "GridCol_Raw_Tx_B1";
            this.GridCol_Raw_Tx_B1.Width = 30;
            // 
            // GridCol_Raw_Tx_B2
            // 
            this.GridCol_Raw_Tx_B2.HeaderText = "B2";
            this.GridCol_Raw_Tx_B2.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B2.Name = "GridCol_Raw_Tx_B2";
            this.GridCol_Raw_Tx_B2.Width = 30;
            // 
            // GridCol_Raw_Tx_B3
            // 
            this.GridCol_Raw_Tx_B3.HeaderText = "B3";
            this.GridCol_Raw_Tx_B3.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B3.Name = "GridCol_Raw_Tx_B3";
            this.GridCol_Raw_Tx_B3.Width = 30;
            // 
            // GridCol_Raw_Tx_B4
            // 
            this.GridCol_Raw_Tx_B4.HeaderText = "B4";
            this.GridCol_Raw_Tx_B4.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B4.Name = "GridCol_Raw_Tx_B4";
            this.GridCol_Raw_Tx_B4.Width = 30;
            // 
            // GridCol_Raw_Tx_B5
            // 
            this.GridCol_Raw_Tx_B5.HeaderText = "B5";
            this.GridCol_Raw_Tx_B5.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B5.Name = "GridCol_Raw_Tx_B5";
            this.GridCol_Raw_Tx_B5.Width = 30;
            // 
            // GridCol_Raw_Tx_B6
            // 
            this.GridCol_Raw_Tx_B6.HeaderText = "B6";
            this.GridCol_Raw_Tx_B6.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B6.Name = "GridCol_Raw_Tx_B6";
            this.GridCol_Raw_Tx_B6.Width = 30;
            // 
            // GridCol_Raw_Tx_B7
            // 
            this.GridCol_Raw_Tx_B7.HeaderText = "B7";
            this.GridCol_Raw_Tx_B7.MinimumWidth = 30;
            this.GridCol_Raw_Tx_B7.Name = "GridCol_Raw_Tx_B7";
            this.GridCol_Raw_Tx_B7.Width = 30;
            // 
            // Context_ManualRawGrid
            // 
            this.Context_ManualRawGrid.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Context_ManualRawGrid.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Ctxt_TxRaw_Add_TSMI,
            this.Ctxt_TxRaw_Del_TSMI,
            this.Ctxt_TxRaw_Clear_TSMI,
            this.toolStripMenuItem1,
            this.Ctxt_TxRaw_Save_TSMI,
            this.Ctxt_TxRaw_Open_TSMI});
            this.Context_ManualRawGrid.Name = "Context_ManualRawGrid";
            this.Context_ManualRawGrid.Size = new System.Drawing.Size(206, 140);
            // 
            // Ctxt_TxRaw_Add_TSMI
            // 
            this.Ctxt_TxRaw_Add_TSMI.Image = global::CANStream.Icones.Item_Add_16;
            this.Ctxt_TxRaw_Add_TSMI.Name = "Ctxt_TxRaw_Add_TSMI";
            this.Ctxt_TxRaw_Add_TSMI.Size = new System.Drawing.Size(205, 26);
            this.Ctxt_TxRaw_Add_TSMI.Text = "Add message";
            this.Ctxt_TxRaw_Add_TSMI.Click += new System.EventHandler(this.Ctxt_TxRaw_Add_TSMIClick);
            // 
            // Ctxt_TxRaw_Del_TSMI
            // 
            this.Ctxt_TxRaw_Del_TSMI.Image = global::CANStream.Icones.Item_Del_16;
            this.Ctxt_TxRaw_Del_TSMI.Name = "Ctxt_TxRaw_Del_TSMI";
            this.Ctxt_TxRaw_Del_TSMI.Size = new System.Drawing.Size(205, 26);
            this.Ctxt_TxRaw_Del_TSMI.Text = "Del message";
            this.Ctxt_TxRaw_Del_TSMI.Click += new System.EventHandler(this.Ctxt_TxRaw_Del_TSMIClick);
            // 
            // Ctxt_TxRaw_Clear_TSMI
            // 
            this.Ctxt_TxRaw_Clear_TSMI.Image = global::CANStream.Icones.Item_Clear_16;
            this.Ctxt_TxRaw_Clear_TSMI.Name = "Ctxt_TxRaw_Clear_TSMI";
            this.Ctxt_TxRaw_Clear_TSMI.Size = new System.Drawing.Size(205, 26);
            this.Ctxt_TxRaw_Clear_TSMI.Text = "Clear messages";
            this.Ctxt_TxRaw_Clear_TSMI.Click += new System.EventHandler(this.Ctxt_TxRaw_Clear_TSMIClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(202, 6);
            // 
            // Ctxt_TxRaw_Save_TSMI
            // 
            this.Ctxt_TxRaw_Save_TSMI.Image = global::CANStream.Icones.File_Save_16;
            this.Ctxt_TxRaw_Save_TSMI.Name = "Ctxt_TxRaw_Save_TSMI";
            this.Ctxt_TxRaw_Save_TSMI.Size = new System.Drawing.Size(205, 26);
            this.Ctxt_TxRaw_Save_TSMI.Text = "Save message list";
            this.Ctxt_TxRaw_Save_TSMI.Click += new System.EventHandler(this.Ctxt_TxRaw_Save_TSMIClick);
            // 
            // Ctxt_TxRaw_Open_TSMI
            // 
            this.Ctxt_TxRaw_Open_TSMI.Image = global::CANStream.Icones.File_Open_16;
            this.Ctxt_TxRaw_Open_TSMI.Name = "Ctxt_TxRaw_Open_TSMI";
            this.Ctxt_TxRaw_Open_TSMI.Size = new System.Drawing.Size(205, 26);
            this.Ctxt_TxRaw_Open_TSMI.Text = "Open message list";
            this.Ctxt_TxRaw_Open_TSMI.Click += new System.EventHandler(this.Ctxt_TxRaw_Open_TSMIClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.Cmd_RxOnly);
            this.groupBox4.Controls.Add(this.Pic_ManualRunning);
            this.groupBox4.Controls.Add(this.Chk_VirtualParamTxEnabled);
            this.groupBox4.Controls.Add(this.Chk_CycleMux);
            this.groupBox4.Controls.Add(this.Cmb_SpyCANRate);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.Txt_SpyIdFilterMax);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.Txt_SpyIdFilterMin);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.Cmb_SpyCANRxMode);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.Cmd_StopSpy);
            this.groupBox4.Controls.Add(this.Cmd_StartSpy);
            this.groupBox4.Location = new System.Drawing.Point(4, 4);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(1281, 80);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            // 
            // Cmd_RxOnly
            // 
            this.Cmd_RxOnly.Enabled = false;
            this.Cmd_RxOnly.Image = global::CANStream.Icones.RXTX_32;
            this.Cmd_RxOnly.Location = new System.Drawing.Point(780, 17);
            this.Cmd_RxOnly.Margin = new System.Windows.Forms.Padding(4);
            this.Cmd_RxOnly.Name = "Cmd_RxOnly";
            this.Cmd_RxOnly.Size = new System.Drawing.Size(60, 55);
            this.Cmd_RxOnly.TabIndex = 23;
            this.Cmd_RxOnly.UseVisualStyleBackColor = true;
            this.Cmd_RxOnly.Click += new System.EventHandler(this.Cmd_RxOnly_Click);
            // 
            // Pic_ManualRunning
            // 
            this.Pic_ManualRunning.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Pic_ManualRunning.Location = new System.Drawing.Point(1209, 12);
            this.Pic_ManualRunning.Margin = new System.Windows.Forms.Padding(4);
            this.Pic_ManualRunning.Name = "Pic_ManualRunning";
            this.Pic_ManualRunning.Size = new System.Drawing.Size(64, 59);
            this.Pic_ManualRunning.TabIndex = 22;
            this.Pic_ManualRunning.TabStop = false;
            this.Pic_ManualRunning.Visible = false;
            // 
            // Chk_VirtualParamTxEnabled
            // 
            this.Chk_VirtualParamTxEnabled.Enabled = false;
            this.Chk_VirtualParamTxEnabled.Location = new System.Drawing.Point(601, 44);
            this.Chk_VirtualParamTxEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.Chk_VirtualParamTxEnabled.Name = "Chk_VirtualParamTxEnabled";
            this.Chk_VirtualParamTxEnabled.Size = new System.Drawing.Size(171, 27);
            this.Chk_VirtualParamTxEnabled.TabIndex = 21;
            this.Chk_VirtualParamTxEnabled.Text = "Virtual parameters Tx";
            this.Chk_VirtualParamTxEnabled.UseVisualStyleBackColor = true;
            this.Chk_VirtualParamTxEnabled.CheckedChanged += new System.EventHandler(this.Chk_VirtualParamTxEnabledCheckedChanged);
            // 
            // Chk_CycleMux
            // 
            this.Chk_CycleMux.Enabled = false;
            this.Chk_CycleMux.Location = new System.Drawing.Point(601, 17);
            this.Chk_CycleMux.Margin = new System.Windows.Forms.Padding(4);
            this.Chk_CycleMux.Name = "Chk_CycleMux";
            this.Chk_CycleMux.Size = new System.Drawing.Size(149, 27);
            this.Chk_CycleMux.TabIndex = 20;
            this.Chk_CycleMux.Text = "Cycle Multiplexers";
            this.Chk_CycleMux.UseVisualStyleBackColor = true;
            // 
            // Cmb_SpyCANRate
            // 
            this.Cmb_SpyCANRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_SpyCANRate.FormattingEnabled = true;
            this.Cmb_SpyCANRate.Items.AddRange(new object[] {
            "500 kBit/s",
            "1000 kBit/s"});
            this.Cmb_SpyCANRate.Location = new System.Drawing.Point(144, 39);
            this.Cmb_SpyCANRate.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_SpyCANRate.Name = "Cmb_SpyCANRate";
            this.Cmb_SpyCANRate.Size = new System.Drawing.Size(105, 24);
            this.Cmb_SpyCANRate.TabIndex = 17;
            this.Cmb_SpyCANRate.SelectedIndexChanged += new System.EventHandler(this.Cmb_SpyCANRateSelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(144, 17);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 20);
            this.label8.TabIndex = 16;
            this.label8.Text = "CAN Rate";
            // 
            // Txt_SpyIdFilterMax
            // 
            this.Txt_SpyIdFilterMax.Location = new System.Drawing.Point(528, 39);
            this.Txt_SpyIdFilterMax.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_SpyIdFilterMax.Name = "Txt_SpyIdFilterMax";
            this.Txt_SpyIdFilterMax.Size = new System.Drawing.Size(52, 22);
            this.Txt_SpyIdFilterMax.TabIndex = 15;
            this.Txt_SpyIdFilterMax.Text = "7FF";
            this.Txt_SpyIdFilterMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(493, 43);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "To";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(384, 43);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "From";
            // 
            // Txt_SpyIdFilterMin
            // 
            this.Txt_SpyIdFilterMin.Location = new System.Drawing.Point(432, 39);
            this.Txt_SpyIdFilterMin.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_SpyIdFilterMin.Name = "Txt_SpyIdFilterMin";
            this.Txt_SpyIdFilterMin.Size = new System.Drawing.Size(52, 22);
            this.Txt_SpyIdFilterMin.TabIndex = 12;
            this.Txt_SpyIdFilterMin.Text = "000";
            this.Txt_SpyIdFilterMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(447, 15);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 20);
            this.label5.TabIndex = 11;
            this.label5.Text = "CAN Id filter (hex)";
            // 
            // Cmb_SpyCANRxMode
            // 
            this.Cmb_SpyCANRxMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cmb_SpyCANRxMode.FormattingEnabled = true;
            this.Cmb_SpyCANRxMode.Location = new System.Drawing.Point(264, 39);
            this.Cmb_SpyCANRxMode.Margin = new System.Windows.Forms.Padding(4);
            this.Cmb_SpyCANRxMode.Name = "Cmb_SpyCANRxMode";
            this.Cmb_SpyCANRxMode.Size = new System.Drawing.Size(105, 24);
            this.Cmb_SpyCANRxMode.TabIndex = 9;
            this.Cmb_SpyCANRxMode.SelectedIndexChanged += new System.EventHandler(this.Cmb_SpyCANRxModeSelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(264, 15);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "CAN Rx mode";
            // 
            // Cmd_StopSpy
            // 
            this.Cmd_StopSpy.Enabled = false;
            this.Cmd_StopSpy.Image = global::CANStream.Icones.Stop_32;
            this.Cmd_StopSpy.Location = new System.Drawing.Point(76, 17);
            this.Cmd_StopSpy.Margin = new System.Windows.Forms.Padding(4);
            this.Cmd_StopSpy.Name = "Cmd_StopSpy";
            this.Cmd_StopSpy.Size = new System.Drawing.Size(60, 55);
            this.Cmd_StopSpy.TabIndex = 1;
            this.Cmd_StopSpy.UseVisualStyleBackColor = true;
            this.Cmd_StopSpy.Click += new System.EventHandler(this.Cmd_StopSpyClick);
            // 
            // Cmd_StartSpy
            // 
            this.Cmd_StartSpy.Enabled = false;
            this.Cmd_StartSpy.Image = global::CANStream.Icones.Play_32;
            this.Cmd_StartSpy.Location = new System.Drawing.Point(8, 17);
            this.Cmd_StartSpy.Margin = new System.Windows.Forms.Padding(4);
            this.Cmd_StartSpy.Name = "Cmd_StartSpy";
            this.Cmd_StartSpy.Size = new System.Drawing.Size(60, 55);
            this.Cmd_StartSpy.TabIndex = 0;
            this.Cmd_StartSpy.UseVisualStyleBackColor = true;
            this.Cmd_StartSpy.Click += new System.EventHandler(this.Cmd_StartSpyClick);
            // 
            // TabPg_Cycle
            // 
            this.TabPg_Cycle.BackColor = System.Drawing.SystemColors.Control;
            this.TabPg_Cycle.Controls.Add(this.Panel_Cycle);
            this.TabPg_Cycle.Controls.Add(this.groupBox2);
            this.TabPg_Cycle.Controls.Add(this.groupBox1);
            this.TabPg_Cycle.ImageIndex = 1;
            this.TabPg_Cycle.Location = new System.Drawing.Point(4, 25);
            this.TabPg_Cycle.Margin = new System.Windows.Forms.Padding(4);
            this.TabPg_Cycle.Name = "TabPg_Cycle";
            this.TabPg_Cycle.Padding = new System.Windows.Forms.Padding(4);
            this.TabPg_Cycle.Size = new System.Drawing.Size(1292, 755);
            this.TabPg_Cycle.TabIndex = 0;
            this.TabPg_Cycle.Tag = "2";
            this.TabPg_Cycle.Text = "Cycle";
            // 
            // Panel_Cycle
            // 
            this.Panel_Cycle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel_Cycle.Controls.Add(this.Split_Cycle_VirtualSig_Graph);
            this.Panel_Cycle.Location = new System.Drawing.Point(8, 101);
            this.Panel_Cycle.Margin = new System.Windows.Forms.Padding(4);
            this.Panel_Cycle.Name = "Panel_Cycle";
            this.Panel_Cycle.Size = new System.Drawing.Size(1281, 540);
            this.Panel_Cycle.TabIndex = 3;
            // 
            // Split_Cycle_VirtualSig_Graph
            // 
            this.Split_Cycle_VirtualSig_Graph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split_Cycle_VirtualSig_Graph.Location = new System.Drawing.Point(0, 0);
            this.Split_Cycle_VirtualSig_Graph.Margin = new System.Windows.Forms.Padding(4);
            this.Split_Cycle_VirtualSig_Graph.Name = "Split_Cycle_VirtualSig_Graph";
            // 
            // Split_Cycle_VirtualSig_Graph.Panel1
            // 
            this.Split_Cycle_VirtualSig_Graph.Panel1.Controls.Add(this.Cycle_SpyDataViewer);
            // 
            // Split_Cycle_VirtualSig_Graph.Panel2
            // 
            this.Split_Cycle_VirtualSig_Graph.Panel2.Controls.Add(this.Graph_Cycle);
            this.Split_Cycle_VirtualSig_Graph.Size = new System.Drawing.Size(1281, 540);
            this.Split_Cycle_VirtualSig_Graph.SplitterDistance = 402;
            this.Split_Cycle_VirtualSig_Graph.SplitterWidth = 5;
            this.Split_Cycle_VirtualSig_Graph.TabIndex = 0;
            // 
            // Context_CycleGraph
            // 
            this.Context_CycleGraph.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.Context_CycleGraph.Name = "Context_CycleGraph";
            this.Context_CycleGraph.Size = new System.Drawing.Size(67, 4);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Chk_CycleVirtualParamTxEnabled);
            this.groupBox2.Controls.Add(this.Txt_CycleEnd);
            this.groupBox2.Controls.Add(this.Txt_CycleStart);
            this.groupBox2.Controls.Add(this.Lbl_CycleEnd);
            this.groupBox2.Controls.Add(this.Lbl_CycleStart);
            this.groupBox2.Controls.Add(this.Chk_InfinitePlay);
            this.groupBox2.Controls.Add(this.Lbl_TotalProgress);
            this.groupBox2.Controls.Add(this.Txt_CurrentCycleNum);
            this.groupBox2.Controls.Add(this.Lbl_CurrentCycleNum);
            this.groupBox2.Controls.Add(this.PB_TotalProgress);
            this.groupBox2.Controls.Add(this.PB_CurrentProgress);
            this.groupBox2.Controls.Add(this.Lbl_CurrentProgress);
            this.groupBox2.Controls.Add(this.Lbl_CycleCount);
            this.groupBox2.Controls.Add(this.NumUpDown_CycleCount);
            this.groupBox2.Controls.Add(this.Cmd_StopCycle);
            this.groupBox2.Controls.Add(this.Cmd_BreakCycle);
            this.groupBox2.Controls.Add(this.Cmd_PlayCycle);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(1273, 86);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Cycle control";
            // 
            // Chk_CycleVirtualParamTxEnabled
            // 
            this.Chk_CycleVirtualParamTxEnabled.Enabled = false;
            this.Chk_CycleVirtualParamTxEnabled.Location = new System.Drawing.Point(409, 49);
            this.Chk_CycleVirtualParamTxEnabled.Margin = new System.Windows.Forms.Padding(4);
            this.Chk_CycleVirtualParamTxEnabled.Name = "Chk_CycleVirtualParamTxEnabled";
            this.Chk_CycleVirtualParamTxEnabled.Size = new System.Drawing.Size(172, 27);
            this.Chk_CycleVirtualParamTxEnabled.TabIndex = 22;
            this.Chk_CycleVirtualParamTxEnabled.Text = "Virtual parameters Tx";
            this.Chk_CycleVirtualParamTxEnabled.UseVisualStyleBackColor = true;
            this.Chk_CycleVirtualParamTxEnabled.CheckedChanged += new System.EventHandler(this.Chk_CycleVirtualParamTxEnabledCheckedChanged);
            // 
            // Txt_CycleEnd
            // 
            this.Txt_CycleEnd.Enabled = false;
            this.Txt_CycleEnd.Location = new System.Drawing.Point(631, 53);
            this.Txt_CycleEnd.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_CycleEnd.Name = "Txt_CycleEnd";
            this.Txt_CycleEnd.Size = new System.Drawing.Size(61, 22);
            this.Txt_CycleEnd.TabIndex = 16;
            this.Txt_CycleEnd.TextChanged += new System.EventHandler(this.Txt_CycleEndTextChanged);
            // 
            // Txt_CycleStart
            // 
            this.Txt_CycleStart.Enabled = false;
            this.Txt_CycleStart.Location = new System.Drawing.Point(631, 21);
            this.Txt_CycleStart.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_CycleStart.Name = "Txt_CycleStart";
            this.Txt_CycleStart.Size = new System.Drawing.Size(61, 22);
            this.Txt_CycleStart.TabIndex = 15;
            this.Txt_CycleStart.TextChanged += new System.EventHandler(this.Txt_CycleStartTextChanged);
            // 
            // Lbl_CycleEnd
            // 
            this.Lbl_CycleEnd.Enabled = false;
            this.Lbl_CycleEnd.Location = new System.Drawing.Point(581, 57);
            this.Lbl_CycleEnd.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_CycleEnd.Name = "Lbl_CycleEnd";
            this.Lbl_CycleEnd.Size = new System.Drawing.Size(41, 18);
            this.Lbl_CycleEnd.TabIndex = 14;
            this.Lbl_CycleEnd.Text = "End";
            // 
            // Lbl_CycleStart
            // 
            this.Lbl_CycleStart.Enabled = false;
            this.Lbl_CycleStart.Location = new System.Drawing.Point(581, 25);
            this.Lbl_CycleStart.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_CycleStart.Name = "Lbl_CycleStart";
            this.Lbl_CycleStart.Size = new System.Drawing.Size(41, 21);
            this.Lbl_CycleStart.TabIndex = 13;
            this.Lbl_CycleStart.Text = "Start";
            // 
            // Chk_InfinitePlay
            // 
            this.Chk_InfinitePlay.Enabled = false;
            this.Chk_InfinitePlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chk_InfinitePlay.Location = new System.Drawing.Point(409, 17);
            this.Chk_InfinitePlay.Margin = new System.Windows.Forms.Padding(4);
            this.Chk_InfinitePlay.Name = "Chk_InfinitePlay";
            this.Chk_InfinitePlay.Size = new System.Drawing.Size(207, 34);
            this.Chk_InfinitePlay.TabIndex = 11;
            this.Chk_InfinitePlay.Text = "Infinite play";
            this.Chk_InfinitePlay.UseVisualStyleBackColor = true;
            this.Chk_InfinitePlay.CheckedChanged += new System.EventHandler(this.Chk_InfinitePlayCheckedChanged);
            // 
            // Lbl_TotalProgress
            // 
            this.Lbl_TotalProgress.Location = new System.Drawing.Point(955, 48);
            this.Lbl_TotalProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_TotalProgress.Name = "Lbl_TotalProgress";
            this.Lbl_TotalProgress.Size = new System.Drawing.Size(85, 28);
            this.Lbl_TotalProgress.TabIndex = 9;
            this.Lbl_TotalProgress.Text = "Total";
            this.Lbl_TotalProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_TotalProgress.Visible = false;
            // 
            // Txt_CurrentCycleNum
            // 
            this.Txt_CurrentCycleNum.BackColor = System.Drawing.SystemColors.Control;
            this.Txt_CurrentCycleNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_CurrentCycleNum.Location = new System.Drawing.Point(832, 23);
            this.Txt_CurrentCycleNum.Margin = new System.Windows.Forms.Padding(4);
            this.Txt_CurrentCycleNum.Name = "Txt_CurrentCycleNum";
            this.Txt_CurrentCycleNum.ReadOnly = true;
            this.Txt_CurrentCycleNum.Size = new System.Drawing.Size(115, 53);
            this.Txt_CurrentCycleNum.TabIndex = 8;
            this.Txt_CurrentCycleNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Txt_CurrentCycleNum.Visible = false;
            // 
            // Lbl_CurrentCycleNum
            // 
            this.Lbl_CurrentCycleNum.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CurrentCycleNum.Location = new System.Drawing.Point(701, 23);
            this.Lbl_CurrentCycleNum.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_CurrentCycleNum.Name = "Lbl_CurrentCycleNum";
            this.Lbl_CurrentCycleNum.Size = new System.Drawing.Size(123, 54);
            this.Lbl_CurrentCycleNum.TabIndex = 7;
            this.Lbl_CurrentCycleNum.Text = "Cycle #";
            this.Lbl_CurrentCycleNum.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_CurrentCycleNum.Visible = false;
            // 
            // PB_TotalProgress
            // 
            this.PB_TotalProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_TotalProgress.Location = new System.Drawing.Point(1063, 50);
            this.PB_TotalProgress.Margin = new System.Windows.Forms.Padding(4);
            this.PB_TotalProgress.Name = "PB_TotalProgress";
            this.PB_TotalProgress.Size = new System.Drawing.Size(203, 28);
            this.PB_TotalProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PB_TotalProgress.TabIndex = 6;
            this.PB_TotalProgress.Visible = false;
            // 
            // PB_CurrentProgress
            // 
            this.PB_CurrentProgress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PB_CurrentProgress.Location = new System.Drawing.Point(1063, 20);
            this.PB_CurrentProgress.Margin = new System.Windows.Forms.Padding(4);
            this.PB_CurrentProgress.Name = "PB_CurrentProgress";
            this.PB_CurrentProgress.Size = new System.Drawing.Size(203, 28);
            this.PB_CurrentProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.PB_CurrentProgress.TabIndex = 2;
            this.PB_CurrentProgress.Visible = false;
            // 
            // Lbl_CurrentProgress
            // 
            this.Lbl_CurrentProgress.Location = new System.Drawing.Point(955, 20);
            this.Lbl_CurrentProgress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_CurrentProgress.Name = "Lbl_CurrentProgress";
            this.Lbl_CurrentProgress.Size = new System.Drawing.Size(100, 28);
            this.Lbl_CurrentProgress.TabIndex = 5;
            this.Lbl_CurrentProgress.Text = "Current cycle";
            this.Lbl_CurrentProgress.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lbl_CurrentProgress.Visible = false;
            // 
            // Lbl_CycleCount
            // 
            this.Lbl_CycleCount.Enabled = false;
            this.Lbl_CycleCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_CycleCount.Location = new System.Drawing.Point(212, 25);
            this.Lbl_CycleCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_CycleCount.Name = "Lbl_CycleCount";
            this.Lbl_CycleCount.Size = new System.Drawing.Size(108, 54);
            this.Lbl_CycleCount.TabIndex = 4;
            this.Lbl_CycleCount.Text = "Count";
            this.Lbl_CycleCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NumUpDown_CycleCount
            // 
            this.NumUpDown_CycleCount.Enabled = false;
            this.NumUpDown_CycleCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumUpDown_CycleCount.Location = new System.Drawing.Point(328, 25);
            this.NumUpDown_CycleCount.Margin = new System.Windows.Forms.Padding(4);
            this.NumUpDown_CycleCount.Name = "NumUpDown_CycleCount";
            this.NumUpDown_CycleCount.Size = new System.Drawing.Size(73, 53);
            this.NumUpDown_CycleCount.TabIndex = 3;
            this.NumUpDown_CycleCount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Cmd_StopCycle
            // 
            this.Cmd_StopCycle.Enabled = false;
            this.Cmd_StopCycle.Image = global::CANStream.Icones.Stop_32;
            this.Cmd_StopCycle.Location = new System.Drawing.Point(144, 23);
            this.Cmd_StopCycle.Margin = new System.Windows.Forms.Padding(4);
            this.Cmd_StopCycle.Name = "Cmd_StopCycle";
            this.Cmd_StopCycle.Size = new System.Drawing.Size(60, 55);
            this.Cmd_StopCycle.TabIndex = 2;
            this.Cmd_StopCycle.UseVisualStyleBackColor = true;
            this.Cmd_StopCycle.Click += new System.EventHandler(this.Cmd_StopCycleClick);
            // 
            // Cmd_BreakCycle
            // 
            this.Cmd_BreakCycle.Enabled = false;
            this.Cmd_BreakCycle.Image = global::CANStream.Icones.Pause_32;
            this.Cmd_BreakCycle.Location = new System.Drawing.Point(76, 23);
            this.Cmd_BreakCycle.Margin = new System.Windows.Forms.Padding(4);
            this.Cmd_BreakCycle.Name = "Cmd_BreakCycle";
            this.Cmd_BreakCycle.Size = new System.Drawing.Size(60, 55);
            this.Cmd_BreakCycle.TabIndex = 1;
            this.Cmd_BreakCycle.UseVisualStyleBackColor = true;
            this.Cmd_BreakCycle.Click += new System.EventHandler(this.Cmd_BreakCycleClick);
            // 
            // Cmd_PlayCycle
            // 
            this.Cmd_PlayCycle.Enabled = false;
            this.Cmd_PlayCycle.Image = global::CANStream.Icones.Play_32;
            this.Cmd_PlayCycle.Location = new System.Drawing.Point(8, 23);
            this.Cmd_PlayCycle.Margin = new System.Windows.Forms.Padding(4);
            this.Cmd_PlayCycle.Name = "Cmd_PlayCycle";
            this.Cmd_PlayCycle.Size = new System.Drawing.Size(60, 55);
            this.Cmd_PlayCycle.TabIndex = 0;
            this.Cmd_PlayCycle.UseVisualStyleBackColor = true;
            this.Cmd_PlayCycle.Click += new System.EventHandler(this.Cmd_PlayCycleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.rTxt_CycleComments);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.Lbl_CanConfig);
            this.groupBox1.Controls.Add(this.Lbl_CycleFile);
            this.groupBox1.Location = new System.Drawing.Point(8, 642);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(1273, 105);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rTxt_CycleComments
            // 
            this.rTxt_CycleComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxt_CycleComments.BackColor = System.Drawing.SystemColors.Control;
            this.rTxt_CycleComments.Location = new System.Drawing.Point(115, 57);
            this.rTxt_CycleComments.Margin = new System.Windows.Forms.Padding(4);
            this.rTxt_CycleComments.Name = "rTxt_CycleComments";
            this.rTxt_CycleComments.ReadOnly = true;
            this.rTxt_CycleComments.Size = new System.Drawing.Size(1149, 40);
            this.rTxt_CycleComments.TabIndex = 3;
            this.rTxt_CycleComments.Text = "";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(37, 57);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(592, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Comments:";
            // 
            // Lbl_CanConfig
            // 
            this.Lbl_CanConfig.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_CanConfig.Location = new System.Drawing.Point(37, 34);
            this.Lbl_CanConfig.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_CanConfig.Name = "Lbl_CanConfig";
            this.Lbl_CanConfig.Size = new System.Drawing.Size(1228, 22);
            this.Lbl_CanConfig.TabIndex = 1;
            this.Lbl_CanConfig.Text = "CAN Configuration:";
            // 
            // Lbl_CycleFile
            // 
            this.Lbl_CycleFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_CycleFile.Location = new System.Drawing.Point(37, 15);
            this.Lbl_CycleFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Lbl_CycleFile.Name = "Lbl_CycleFile";
            this.Lbl_CycleFile.Size = new System.Drawing.Size(1228, 18);
            this.Lbl_CycleFile.TabIndex = 0;
            this.Lbl_CycleFile.Text = "Cycle file:";
            // 
            // Img_TabControl
            // 
            this.Img_TabControl.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_TabControl.ImageStream")));
            this.Img_TabControl.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_TabControl.Images.SetKeyName(0, "personal.png");
            this.Img_TabControl.Images.SetKeyName(1, "windows-movie-maker-icone-8672-16.png");
            // 
            // Timer_CheckDevice
            // 
            this.Timer_CheckDevice.Interval = 5000;
            this.Timer_CheckDevice.Tick += new System.EventHandler(this.Timer_CheckDeviceTick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // BGWrk_Spy
            // 
            this.BGWrk_Spy.WorkerReportsProgress = true;
            this.BGWrk_Spy.WorkerSupportsCancellation = true;
            this.BGWrk_Spy.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWrk_SpyDoWork);
            this.BGWrk_Spy.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWrk_SpyProgressChanged);
            this.BGWrk_Spy.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWrk_SpyRunWorkerCompleted);
            // 
            // Timer_NoRx
            // 
            this.Timer_NoRx.Interval = 200;
            this.Timer_NoRx.Tick += new System.EventHandler(this.Timer_NoRx_Tick);
            // 
            // Split_Rx_DataGraph
            // 
            this.Split_Rx_DataGraph.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split_Rx_DataGraph.Location = new System.Drawing.Point(0, 0);
            this.Split_Rx_DataGraph.Margin = new System.Windows.Forms.Padding(4);
            this.Split_Rx_DataGraph.Name = "Split_Rx_DataGraph";
            this.Split_Rx_DataGraph.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // Split_Rx_DataGraph.Panel1
            // 
            this.Split_Rx_DataGraph.Panel1.Controls.Add(this.Grid_ManualDataViewer);
            // 
            // Split_Rx_DataGraph.Panel2
            // 
            this.Split_Rx_DataGraph.Panel2.Controls.Add(this.Tab_SpyHistory);
            this.Split_Rx_DataGraph.Size = new System.Drawing.Size(686, 662);
            this.Split_Rx_DataGraph.SplitterDistance = 264;
            this.Split_Rx_DataGraph.SplitterWidth = 5;
            this.Split_Rx_DataGraph.TabIndex = 0;
            // 
            // Tab_SpyHistory
            // 
            this.Tab_SpyHistory.Alignment = System.Windows.Forms.TabAlignment.Right;
            this.Tab_SpyHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tab_SpyHistory.Controls.Add(this.Tab_SpyHistory_Graph);
            this.Tab_SpyHistory.Controls.Add(this.Tab_SpyHistory_Data);
            this.Tab_SpyHistory.Location = new System.Drawing.Point(3, 4);
            this.Tab_SpyHistory.Margin = new System.Windows.Forms.Padding(4);
            this.Tab_SpyHistory.Multiline = true;
            this.Tab_SpyHistory.Name = "Tab_SpyHistory";
            this.Tab_SpyHistory.SelectedIndex = 0;
            this.Tab_SpyHistory.Size = new System.Drawing.Size(684, 388);
            this.Tab_SpyHistory.TabIndex = 10;
            this.Tab_SpyHistory.SelectedIndexChanged += new System.EventHandler(this.Tab_SpyHistory_SelectedIndexChanged);
            // 
            // Tab_SpyHistory_Graph
            // 
            this.Tab_SpyHistory_Graph.BackColor = System.Drawing.SystemColors.Control;
            this.Tab_SpyHistory_Graph.Controls.Add(this.Graph_SpyData);
            this.Tab_SpyHistory_Graph.Location = new System.Drawing.Point(4, 4);
            this.Tab_SpyHistory_Graph.Margin = new System.Windows.Forms.Padding(4);
            this.Tab_SpyHistory_Graph.Name = "Tab_SpyHistory_Graph";
            this.Tab_SpyHistory_Graph.Padding = new System.Windows.Forms.Padding(4);
            this.Tab_SpyHistory_Graph.Size = new System.Drawing.Size(655, 380);
            this.Tab_SpyHistory_Graph.TabIndex = 0;
            this.Tab_SpyHistory_Graph.Tag = "Graph";
            this.Tab_SpyHistory_Graph.Text = "Graphic";
            // 
            // Tab_SpyHistory_Data
            // 
            this.Tab_SpyHistory_Data.BackColor = System.Drawing.SystemColors.Control;
            this.Tab_SpyHistory_Data.Controls.Add(this.Lst_SpyDataHistory);
            this.Tab_SpyHistory_Data.Controls.Add(this.TS_SpyDataHistory);
            this.Tab_SpyHistory_Data.Location = new System.Drawing.Point(4, 4);
            this.Tab_SpyHistory_Data.Margin = new System.Windows.Forms.Padding(4);
            this.Tab_SpyHistory_Data.Name = "Tab_SpyHistory_Data";
            this.Tab_SpyHistory_Data.Padding = new System.Windows.Forms.Padding(4);
            this.Tab_SpyHistory_Data.Size = new System.Drawing.Size(655, 380);
            this.Tab_SpyHistory_Data.TabIndex = 1;
            this.Tab_SpyHistory_Data.Tag = "Data";
            this.Tab_SpyHistory_Data.Text = "Data";
            // 
            // Lst_SpyDataHistory
            // 
            this.Lst_SpyDataHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Lst_SpyDataHistory.FormattingEnabled = true;
            this.Lst_SpyDataHistory.ItemHeight = 16;
            this.Lst_SpyDataHistory.Location = new System.Drawing.Point(4, 38);
            this.Lst_SpyDataHistory.Margin = new System.Windows.Forms.Padding(4);
            this.Lst_SpyDataHistory.Name = "Lst_SpyDataHistory";
            this.Lst_SpyDataHistory.Size = new System.Drawing.Size(636, 340);
            this.Lst_SpyDataHistory.TabIndex = 1;
            // 
            // TS_SpyDataHistory
            // 
            this.TS_SpyDataHistory.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.TS_SpyDataHistory.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_FreezeHistory,
            this.TSB_ResumeHistory,
            this.TSB_ClearHistory,
            this.TSB_ExportHistory,
            this.toolStripSeparator3,
            this.TSLbl_IdFilterFrom,
            this.TSTxt_IdFilterFrom,
            this.TSLbl_IdFilterTo,
            this.TSTxt_IdFilterTo});
            this.TS_SpyDataHistory.Location = new System.Drawing.Point(4, 4);
            this.TS_SpyDataHistory.Name = "TS_SpyDataHistory";
            this.TS_SpyDataHistory.Size = new System.Drawing.Size(647, 27);
            this.TS_SpyDataHistory.TabIndex = 0;
            this.TS_SpyDataHistory.Text = "toolStrip1";
            // 
            // TSB_FreezeHistory
            // 
            this.TSB_FreezeHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_FreezeHistory.Image = global::CANStream.Icones.Pause_16;
            this.TSB_FreezeHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_FreezeHistory.Name = "TSB_FreezeHistory";
            this.TSB_FreezeHistory.Size = new System.Drawing.Size(24, 24);
            this.TSB_FreezeHistory.Text = "toolStripButton1";
            this.TSB_FreezeHistory.ToolTipText = "Freeze";
            this.TSB_FreezeHistory.Click += new System.EventHandler(this.TSB_FreezeHistory_Click);
            // 
            // TSB_ResumeHistory
            // 
            this.TSB_ResumeHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ResumeHistory.Image = global::CANStream.Icones.Play_16;
            this.TSB_ResumeHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ResumeHistory.Name = "TSB_ResumeHistory";
            this.TSB_ResumeHistory.Size = new System.Drawing.Size(24, 24);
            this.TSB_ResumeHistory.Text = "toolStripButton2";
            this.TSB_ResumeHistory.ToolTipText = "Resume";
            this.TSB_ResumeHistory.Visible = false;
            this.TSB_ResumeHistory.Click += new System.EventHandler(this.TSB_ResumeHistory_Click);
            // 
            // TSB_ClearHistory
            // 
            this.TSB_ClearHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ClearHistory.Image = global::CANStream.Icones.Delete_16;
            this.TSB_ClearHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ClearHistory.Name = "TSB_ClearHistory";
            this.TSB_ClearHistory.Size = new System.Drawing.Size(24, 24);
            this.TSB_ClearHistory.Text = "toolStripButton3";
            this.TSB_ClearHistory.ToolTipText = "Clear history";
            this.TSB_ClearHistory.Click += new System.EventHandler(this.TSB_ClearHistory_Click);
            // 
            // TSB_ExportHistory
            // 
            this.TSB_ExportHistory.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ExportHistory.Image = global::CANStream.Icones.Export_File_16;
            this.TSB_ExportHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ExportHistory.Name = "TSB_ExportHistory";
            this.TSB_ExportHistory.Size = new System.Drawing.Size(24, 24);
            this.TSB_ExportHistory.Text = "toolStripButton4";
            this.TSB_ExportHistory.ToolTipText = "Export history";
            this.TSB_ExportHistory.Click += new System.EventHandler(this.TSB_ExportHistory_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // TSLbl_IdFilterFrom
            // 
            this.TSLbl_IdFilterFrom.Name = "TSLbl_IdFilterFrom";
            this.TSLbl_IdFilterFrom.Size = new System.Drawing.Size(132, 24);
            this.TSLbl_IdFilterFrom.Text = "CAN Id filter: From";
            // 
            // TSTxt_IdFilterFrom
            // 
            this.TSTxt_IdFilterFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TSTxt_IdFilterFrom.Name = "TSTxt_IdFilterFrom";
            this.TSTxt_IdFilterFrom.Size = new System.Drawing.Size(66, 27);
            this.TSTxt_IdFilterFrom.Text = "000";
            this.TSTxt_IdFilterFrom.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TSTxt_IdFilterFrom.TextChanged += new System.EventHandler(this.TSTxt_IdFilterFrom_TextChanged);
            // 
            // TSLbl_IdFilterTo
            // 
            this.TSLbl_IdFilterTo.Name = "TSLbl_IdFilterTo";
            this.TSLbl_IdFilterTo.Size = new System.Drawing.Size(26, 24);
            this.TSLbl_IdFilterTo.Text = "To";
            // 
            // TSTxt_IdFilterTo
            // 
            this.TSTxt_IdFilterTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TSTxt_IdFilterTo.Name = "TSTxt_IdFilterTo";
            this.TSTxt_IdFilterTo.Size = new System.Drawing.Size(66, 27);
            this.TSTxt_IdFilterTo.Text = "7FF";
            this.TSTxt_IdFilterTo.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TSTxt_IdFilterTo.TextChanged += new System.EventHandler(this.TSTxt_IdFilterTo_TextChanged);
            // 
            // Grid_ManualDataWriter
            // 
            this.Grid_ManualDataWriter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_ManualDataWriter.DataMode = CANStream.GridDataMode.DataTx;
            this.Grid_ManualDataWriter.eGridColumnsVisible = CANStream.GridCANData_ColumnsEnum.Default;
            this.Grid_ManualDataWriter.Location = new System.Drawing.Point(1, 0);
            this.Grid_ManualDataWriter.Margin = new System.Windows.Forms.Padding(5);
            this.Grid_ManualDataWriter.Name = "Grid_ManualDataWriter";
            this.Grid_ManualDataWriter.Size = new System.Drawing.Size(596, 506);
            this.Grid_ManualDataWriter.TabIndex = 9;
            this.Grid_ManualDataWriter.VirtualChannelsVisible = true;
            this.Grid_ManualDataWriter.GridColumnsVisibleChanged += new System.EventHandler<CANStream.GridColVisibleChangedEventArgs>(this.Grid_ManualDataWriter_GridColumnsVisibleChanged);
            this.Grid_ManualDataWriter.GridDataReseted += new System.EventHandler<System.EventArgs>(this.Grid_ManualDataWriter_GridDataReseted);
            this.Grid_ManualDataWriter.GridTxParameterValueChanged += new System.EventHandler<CANStream.GridTxParameterValueChangedEventArgs>(this.Grid_ManualDataWriter_GridTxParameterValueChanged);
            // 
            // Grid_ManualDataViewer
            // 
            this.Grid_ManualDataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_ManualDataViewer.DataMode = CANStream.GridDataMode.DataRx;
            this.Grid_ManualDataViewer.eGridColumnsVisible = CANStream.GridCANData_ColumnsEnum.Default;
            this.Grid_ManualDataViewer.Location = new System.Drawing.Point(0, 0);
            this.Grid_ManualDataViewer.Margin = new System.Windows.Forms.Padding(5);
            this.Grid_ManualDataViewer.Name = "Grid_ManualDataViewer";
            this.Grid_ManualDataViewer.Size = new System.Drawing.Size(682, 264);
            this.Grid_ManualDataViewer.TabIndex = 0;
            this.Grid_ManualDataViewer.VirtualChannelsVisible = true;
            this.Grid_ManualDataViewer.GridColumnsVisibleChanged += new System.EventHandler<CANStream.GridColVisibleChangedEventArgs>(this.Manual_SpyDataViewerEngGridColumnsVisibleChanged);
            this.Grid_ManualDataViewer.GridDataReseted += new System.EventHandler<System.EventArgs>(this.Manual_SpyDataViewer_GridDataReseted);
            // 
            // Graph_SpyData
            // 
            this.Graph_SpyData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Graph_SpyData.ChannelListEnabled = true;
            this.Graph_SpyData.CursorEnabled = false;
            this.Graph_SpyData.EditGraphicConfigurationEnable = false;
            this.Graph_SpyData.LegendEnabled = false;
            this.Graph_SpyData.Location = new System.Drawing.Point(0, 0);
            this.Graph_SpyData.Margin = new System.Windows.Forms.Padding(5);
            this.Graph_SpyData.Name = "Graph_SpyData";
            this.Graph_SpyData.OpenFileVisible = false;
            this.Graph_SpyData.PrintEnabled = false;
            this.Graph_SpyData.RealTimeGraphic = true;
            this.Graph_SpyData.ShortcutKeysEnabled = false;
            this.Graph_SpyData.Size = new System.Drawing.Size(655, 380);
            this.Graph_SpyData.SnapShotEnabled = false;
            this.Graph_SpyData.TabIndex = 0;
            this.Graph_SpyData.ToolBarVisible = true;
            this.Graph_SpyData.ZoomEnabled = false;
            // 
            // Cycle_SpyDataViewer
            // 
            this.Cycle_SpyDataViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cycle_SpyDataViewer.DataMode = CANStream.GridDataMode.DataRx;
            this.Cycle_SpyDataViewer.eGridColumnsVisible = CANStream.GridCANData_ColumnsEnum.Default;
            this.Cycle_SpyDataViewer.Location = new System.Drawing.Point(0, 1);
            this.Cycle_SpyDataViewer.Margin = new System.Windows.Forms.Padding(1);
            this.Cycle_SpyDataViewer.Name = "Cycle_SpyDataViewer";
            this.Cycle_SpyDataViewer.Size = new System.Drawing.Size(400, 539);
            this.Cycle_SpyDataViewer.TabIndex = 0;
            this.Cycle_SpyDataViewer.VirtualChannelsVisible = true;
            this.Cycle_SpyDataViewer.GridColumnsVisibleChanged += new System.EventHandler<CANStream.GridColVisibleChangedEventArgs>(this.Cycle_SpyDataViewerEngGridColumnsVisibleChanged);
            // 
            // Graph_Cycle
            // 
            this.Graph_Cycle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Graph_Cycle.ChannelListEnabled = false;
            this.Graph_Cycle.ContextMenuStrip = this.Context_CycleGraph;
            this.Graph_Cycle.CursorEnabled = true;
            this.Graph_Cycle.EditGraphicConfigurationEnable = false;
            this.Graph_Cycle.LegendEnabled = false;
            this.Graph_Cycle.Location = new System.Drawing.Point(4, 4);
            this.Graph_Cycle.Margin = new System.Windows.Forms.Padding(5);
            this.Graph_Cycle.Name = "Graph_Cycle";
            this.Graph_Cycle.OpenFileVisible = false;
            this.Graph_Cycle.PrintEnabled = false;
            this.Graph_Cycle.RealTimeGraphic = false;
            this.Graph_Cycle.ShortcutKeysEnabled = false;
            this.Graph_Cycle.Size = new System.Drawing.Size(861, 536);
            this.Graph_Cycle.SnapShotEnabled = false;
            this.Graph_Cycle.TabIndex = 0;
            this.Graph_Cycle.ToolBarVisible = false;
            this.Graph_Cycle.ZoomEnabled = false;
            this.Graph_Cycle.ControlPreviewKeyDown += new System.EventHandler<System.Windows.Forms.PreviewKeyDownEventArgs>(this.Graph_Cycle_ControlPreviewKeyDown);
            // 
            // Ctrl_CS_CAN_Bus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.CtrlMain_ToolStrip);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Ctrl_CS_CAN_Bus";
            this.Size = new System.Drawing.Size(1304, 818);
            this.CtrlMain_ToolStrip.ResumeLayout(false);
            this.CtrlMain_ToolStrip.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.TabPg_SpyAndManual.ResumeLayout(false);
            this.Split_RxTx.Panel1.ResumeLayout(false);
            this.Split_RxTx.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split_RxTx)).EndInit();
            this.Split_RxTx.ResumeLayout(false);
            this.Split_Tx_EngRaw.Panel1.ResumeLayout(false);
            this.Split_Tx_EngRaw.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split_Tx_EngRaw)).EndInit();
            this.Split_Tx_EngRaw.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_CANRawData)).EndInit();
            this.Context_ManualRawGrid.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_ManualRunning)).EndInit();
            this.TabPg_Cycle.ResumeLayout(false);
            this.Panel_Cycle.ResumeLayout(false);
            this.Split_Cycle_VirtualSig_Graph.Panel1.ResumeLayout(false);
            this.Split_Cycle_VirtualSig_Graph.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split_Cycle_VirtualSig_Graph)).EndInit();
            this.Split_Cycle_VirtualSig_Graph.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_CycleCount)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.Split_Rx_DataGraph.Panel1.ResumeLayout(false);
            this.Split_Rx_DataGraph.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split_Rx_DataGraph)).EndInit();
            this.Split_Rx_DataGraph.ResumeLayout(false);
            this.Tab_SpyHistory.ResumeLayout(false);
            this.Tab_SpyHistory_Graph.ResumeLayout(false);
            this.Tab_SpyHistory_Data.ResumeLayout(false);
            this.Tab_SpyHistory_Data.PerformLayout();
            this.TS_SpyDataHistory.ResumeLayout(false);
            this.TS_SpyDataHistory.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ImageList Img_TabControl;
		private System.Windows.Forms.ToolStripMenuItem TSMI_SpyManual;
		private System.Windows.Forms.ToolStripMenuItem TSMI_CyclePlayer_Graph;
		private System.Windows.Forms.ToolStripMenuItem TSMI_CyclePlayer_Data;
		private System.Windows.Forms.ToolStripMenuItem TSMI_CyclePlayer;
		private CANStream.Ctrl_CANDataGrid Cycle_SpyDataViewer;
		private CANStream.Ctrl_CANDataGrid Grid_ManualDataViewer;
		private System.Windows.Forms.Panel Panel_Cycle;
		private System.Windows.Forms.SplitContainer Split_Cycle_VirtualSig_Graph;
		private System.Windows.Forms.ToolStripMenuItem TSMI_ResetLayout;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
		private System.Windows.Forms.CheckBox Chk_CycleVirtualParamTxEnabled;
        private System.Windows.Forms.CheckBox Chk_VirtualParamTxEnabled;
		private System.Windows.Forms.SplitContainer Split_Rx_DataGraph;
		private System.Windows.Forms.SplitContainer Split_Tx_EngRaw;
		private System.Windows.Forms.SplitContainer Split_RxTx;
		private System.Windows.Forms.TabPage TabPg_SpyAndManual;
		private System.Windows.Forms.ToolStripMenuItem TSMI_TxMessages_Raw;
		private System.Windows.Forms.ToolStripMenuItem TSMI_TxMessages_Eng;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.ToolStripMenuItem Ctxt_TxRaw_Open_TSMI;
		private System.Windows.Forms.ToolStripMenuItem Ctxt_TxRaw_Save_TSMI;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem Ctxt_TxRaw_Clear_TSMI;
		private System.Windows.Forms.ToolStripMenuItem Ctxt_TxRaw_Del_TSMI;
		private System.Windows.Forms.ToolStripMenuItem Ctxt_TxRaw_Add_TSMI;
		private System.Windows.Forms.ContextMenuStrip Context_ManualRawGrid;
		private System.Windows.Forms.DataGridView Grid_CANRawData;
		private System.Windows.Forms.ToolStripMenuItem TSMI_RxMessages_Graph;
		private System.Windows.Forms.ToolStripMenuItem TSMI_RxMessages_Data;
		private System.Windows.Forms.ToolStripMenuItem TSMI_RxMessages;
		private System.Windows.Forms.ToolStripMenuItem TSMI_TxMessages;
		private System.Windows.Forms.ToolStripSplitButton TSSB_View;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.CheckBox Chk_CycleMux;
		private System.Windows.Forms.ContextMenuStrip Context_CycleGraph;
		private System.ComponentModel.BackgroundWorker BGWrk_Spy;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Timer Timer_CheckDevice;
		private System.Windows.Forms.Label Lbl_CycleFile;
		private System.Windows.Forms.Label Lbl_CanConfig;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.RichTextBox rTxt_CycleComments;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button Cmd_PlayCycle;
		private System.Windows.Forms.Button Cmd_BreakCycle;
		private System.Windows.Forms.Button Cmd_StopCycle;
		private System.Windows.Forms.NumericUpDown NumUpDown_CycleCount;
		private System.Windows.Forms.Label Lbl_CycleCount;
		private System.Windows.Forms.Label Lbl_CurrentProgress;
		private System.Windows.Forms.ProgressBar PB_CurrentProgress;
		private System.Windows.Forms.ProgressBar PB_TotalProgress;
		private System.Windows.Forms.Label Lbl_CurrentCycleNum;
		private System.Windows.Forms.TextBox Txt_CurrentCycleNum;
		private System.Windows.Forms.Label Lbl_TotalProgress;
		private System.Windows.Forms.CheckBox Chk_InfinitePlay;
		private System.Windows.Forms.Label Lbl_CycleStart;
		private System.Windows.Forms.Label Lbl_CycleEnd;
		private System.Windows.Forms.TextBox Txt_CycleStart;
		private System.Windows.Forms.TextBox Txt_CycleEnd;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabPage TabPg_Cycle;
		private System.Windows.Forms.Button Cmd_StartSpy;
		private System.Windows.Forms.Button Cmd_StopSpy;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox Cmb_SpyCANRxMode;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox Txt_SpyIdFilterMin;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox Txt_SpyIdFilterMax;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox Cmb_SpyCANRate;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ToolStripButton TSB_StopCANTraceRecording;
		private System.Windows.Forms.ToolStripButton TSB_StartCANTraceRecording;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton TSB_CAN_LinkOn;
		private System.Windows.Forms.ToolStripButton TSB_CAN_LinkOff;
		private System.Windows.Forms.ToolStripLabel TS_Lbl_CanSpeed;
		private System.Windows.Forms.ToolStripComboBox TS_Cmb_PCAN_USB_Devices;
		private System.Windows.Forms.ToolStripButton TSB_Refresh_USB_CAN_Device;
		private System.Windows.Forms.ToolStrip CtrlMain_ToolStrip;
        private System.Windows.Forms.TabControl Tab_SpyHistory;
        private System.Windows.Forms.TabPage Tab_SpyHistory_Graph;
        private System.Windows.Forms.TabPage Tab_SpyHistory_Data;
        private System.Windows.Forms.ListBox Lst_SpyDataHistory;
        private System.Windows.Forms.ToolStrip TS_SpyDataHistory;
        private System.Windows.Forms.ToolStripButton TSB_FreezeHistory;
        private System.Windows.Forms.ToolStripButton TSB_ResumeHistory;
        private System.Windows.Forms.ToolStripButton TSB_ClearHistory;
        private System.Windows.Forms.ToolStripButton TSB_ExportHistory;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel TSLbl_IdFilterFrom;
        private System.Windows.Forms.ToolStripTextBox TSTxt_IdFilterFrom;
        private System.Windows.Forms.ToolStripLabel TSLbl_IdFilterTo;
        private System.Windows.Forms.ToolStripTextBox TSTxt_IdFilterTo;
        private System.Windows.Forms.ToolStripButton TSB_RecordSelection;
        private Ctrl_CANDataGrid Grid_ManualDataWriter;
        private System.Windows.Forms.Timer Timer_NoRx;
        private System.Windows.Forms.PictureBox Pic_ManualRunning;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_DLC;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_Period;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GridCol_Raw_Tx_Sent;
        private System.Windows.Forms.DataGridViewButtonColumn GridCol_Raw_Tx_BtnTx;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B0;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B1;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B2;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B3;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B4;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B5;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B6;
        private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Raw_Tx_B7;
        private Ctrl_GraphWindow.Ctrl_WaveForm Graph_Cycle;
        private Ctrl_GraphWindow.Ctrl_WaveForm Graph_SpyData;
        private System.Windows.Forms.Button Cmd_RxOnly;
        private System.Windows.Forms.ToolTip ToolTip_CmdRxOnly;
    }
}
