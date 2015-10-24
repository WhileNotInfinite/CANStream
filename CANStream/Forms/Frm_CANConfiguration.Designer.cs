namespace CANStream
{
    partial class Frm_CANConfiguration
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_CANConfiguration));
            this.Split_Tree_Props = new System.Windows.Forms.SplitContainer();
            this.Grp_Filter = new System.Windows.Forms.GroupBox();
            this.Cmb_Filter = new System.Windows.Forms.ComboBox();
            this.TV_Messages = new System.Windows.Forms.TreeView();
            this.Context_TV_Messages = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddCanControllertoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewParameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewVirtualParameterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.ControllerConfigToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Import_ControllerCfg_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Export_ControllerCfg_TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportDBCtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.expandAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.collapseAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Img_TV_Messages = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Txt_ConfigName = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.Txt_MsgLength = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.Cmb_BusRate = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.Frame_MsgMap = new System.Windows.Forms.GroupBox();
            this.Lbl_MuxName = new System.Windows.Forms.Label();
            this.Lbl_Mux = new System.Windows.Forms.Label();
            this.NumUpDown_MuxValue = new System.Windows.Forms.NumericUpDown();
            this.Lbl_MuxValue = new System.Windows.Forms.Label();
            this.Grid_MsgMap = new System.Windows.Forms.DataGridView();
            this.Bit7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bit6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bit5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bit4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bit3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bit2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bit1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Bit0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Tab_Controller = new System.Windows.Forms.TabPage();
            this.Grp_ControllerForm = new System.Windows.Forms.GroupBox();
            this.Cmd_ControllerChange = new System.Windows.Forms.Button();
            this.Txt_ControllerDescription = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.Txt_ControllerName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.Tab_Message = new System.Windows.Forms.TabPage();
            this.Grp_MessageForm = new System.Windows.Forms.GroupBox();
            this.Txt_MsgComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.Cmd_CancelNewMessage = new System.Windows.Forms.Button();
            this.Cmd_CreateMessage = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Txt_MsgPeriod = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Radio_Tx = new System.Windows.Forms.RadioButton();
            this.Radio_Rx = new System.Windows.Forms.RadioButton();
            this.Txt_MsgIdentifier = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Txt_MsgName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Tab_Parameter = new System.Windows.Forms.TabPage();
            this.Grp_ParameterForm = new System.Windows.Forms.GroupBox();
            this.Lbl_ParamMinMax = new System.Windows.Forms.Label();
            this.Grp_Alarms = new System.Windows.Forms.GroupBox();
            this.Pic_AlarmMax_Forecolor = new System.Windows.Forms.PictureBox();
            this.Pic_AlarmMax_Backcolor = new System.Windows.Forms.PictureBox();
            this.Pic_AlarmMin_Forecolor = new System.Windows.Forms.PictureBox();
            this.Pic_AlarmMin_Backcolor = new System.Windows.Forms.PictureBox();
            this.Pic_WarningMax_Forecolor = new System.Windows.Forms.PictureBox();
            this.Pic_WarningMax_Backcolor = new System.Windows.Forms.PictureBox();
            this.Chk_AlarmMax = new System.Windows.Forms.CheckBox();
            this.Chk_AlarmMin = new System.Windows.Forms.CheckBox();
            this.Chk_WarningMax = new System.Windows.Forms.CheckBox();
            this.Txt_AlarmMax = new System.Windows.Forms.TextBox();
            this.Txt_AlarmMin = new System.Windows.Forms.TextBox();
            this.Txt_WarningMax = new System.Windows.Forms.TextBox();
            this.Lbl_Alarms_Forecolor = new System.Windows.Forms.Label();
            this.Pic_WarningMin_Forecolor = new System.Windows.Forms.PictureBox();
            this.Chk_WarningMin = new System.Windows.Forms.CheckBox();
            this.Chk_AlarmsEnabled = new System.Windows.Forms.CheckBox();
            this.Pic_WarningMin_Backcolor = new System.Windows.Forms.PictureBox();
            this.Lbl_Alarms_Backcolor = new System.Windows.Forms.Label();
            this.Txt_WarningMin = new System.Windows.Forms.TextBox();
            this.Cmd_EnumDefinition = new System.Windows.Forms.Button();
            this.Txt_Decimals = new System.Windows.Forms.TextBox();
            this.Lbl_Decimals = new System.Windows.Forms.Label();
            this.Cmb_ValueFormat = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.Cmd_VirtualRef = new System.Windows.Forms.Button();
            this.Txt_VirtualRef = new System.Windows.Forms.TextBox();
            this.Lbl_VirtualRef = new System.Windows.Forms.Label();
            this.Chk_Signed = new System.Windows.Forms.CheckBox();
            this.Lbl_LinearizationInfo_2 = new System.Windows.Forms.Label();
            this.Lbl_LinearizationInfo_1 = new System.Windows.Forms.Label();
            this.Txt_ParamComment = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.Txt_ParamUnit = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.Cmb_ParamEndianess = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Chk_MuxParameter = new System.Windows.Forms.CheckBox();
            this.Cmd_CancelNewParam = new System.Windows.Forms.Button();
            this.Cmd_CreateParameter = new System.Windows.Forms.Button();
            this.Grp_ParamMultiplexer = new System.Windows.Forms.GroupBox();
            this.Cmb_ParamMultiplexerValue = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Cmb_ParamMultiplexerName = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.Txt_ParamZero = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.Txt_ParamGain = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.Txt_ParamLength = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.Txt_ParamStartBit = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Txt_ParamName = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_New = new System.Windows.Forms.ToolStripButton();
            this.TSB_Open = new System.Windows.Forms.ToolStripButton();
            this.TSB_Save = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_Cut = new System.Windows.Forms.ToolStripButton();
            this.TSB_Copy = new System.Windows.Forms.ToolStripButton();
            this.TSB_Paste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_ImportDBC = new System.Windows.Forms.ToolStripButton();
            this.TSB_NewController = new System.Windows.Forms.ToolStripButton();
            this.TSB_NewMessage = new System.Windows.Forms.ToolStripButton();
            this.TSB_NewParameter = new System.Windows.Forms.ToolStripButton();
            this.TSB_NewVirtualParameter = new System.Windows.Forms.ToolStripButton();
            this.TSB_Delete = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.ToolTip_Commands = new System.Windows.Forms.ToolTip(this.components);
            this.Dlg_SelectColor = new System.Windows.Forms.ColorDialog();
            ((System.ComponentModel.ISupportInitialize)(this.Split_Tree_Props)).BeginInit();
            this.Split_Tree_Props.Panel1.SuspendLayout();
            this.Split_Tree_Props.Panel2.SuspendLayout();
            this.Split_Tree_Props.SuspendLayout();
            this.Grp_Filter.SuspendLayout();
            this.Context_TV_Messages.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Frame_MsgMap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_MuxValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_MsgMap)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.Tab_Controller.SuspendLayout();
            this.Grp_ControllerForm.SuspendLayout();
            this.Tab_Message.SuspendLayout();
            this.Grp_MessageForm.SuspendLayout();
            this.Tab_Parameter.SuspendLayout();
            this.Grp_ParameterForm.SuspendLayout();
            this.Grp_Alarms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Backcolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Backcolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Backcolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Forecolor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Backcolor)).BeginInit();
            this.Grp_ParamMultiplexer.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Split_Tree_Props
            // 
            this.Split_Tree_Props.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Split_Tree_Props.Location = new System.Drawing.Point(0, 39);
            this.Split_Tree_Props.Name = "Split_Tree_Props";
            // 
            // Split_Tree_Props.Panel1
            // 
            this.Split_Tree_Props.Panel1.Controls.Add(this.Grp_Filter);
            this.Split_Tree_Props.Panel1.Controls.Add(this.TV_Messages);
            this.Split_Tree_Props.Panel1MinSize = 100;
            // 
            // Split_Tree_Props.Panel2
            // 
            this.Split_Tree_Props.Panel2.Controls.Add(this.groupBox1);
            this.Split_Tree_Props.Panel2.Controls.Add(this.Frame_MsgMap);
            this.Split_Tree_Props.Panel2.Controls.Add(this.tabControl1);
            this.Split_Tree_Props.Panel2MinSize = 700;
            this.Split_Tree_Props.Size = new System.Drawing.Size(1181, 642);
            this.Split_Tree_Props.SplitterDistance = 381;
            this.Split_Tree_Props.TabIndex = 0;
            // 
            // Grp_Filter
            // 
            this.Grp_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Filter.Controls.Add(this.Cmb_Filter);
            this.Grp_Filter.Location = new System.Drawing.Point(3, 591);
            this.Grp_Filter.Name = "Grp_Filter";
            this.Grp_Filter.Size = new System.Drawing.Size(375, 48);
            this.Grp_Filter.TabIndex = 1;
            this.Grp_Filter.TabStop = false;
            this.Grp_Filter.Text = "Filter";
            // 
            // Cmb_Filter
            // 
            this.Cmb_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Filter.FormattingEnabled = true;
            this.Cmb_Filter.Location = new System.Drawing.Point(9, 19);
            this.Cmb_Filter.Name = "Cmb_Filter";
            this.Cmb_Filter.Size = new System.Drawing.Size(360, 21);
            this.Cmb_Filter.TabIndex = 1;
            this.Cmb_Filter.SelectedIndexChanged += new System.EventHandler(this.Cmb_FilterSelectedIndexChanged);
            this.Cmb_Filter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Cmb_FilterKeyDown);
            // 
            // TV_Messages
            // 
            this.TV_Messages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TV_Messages.ContextMenuStrip = this.Context_TV_Messages;
            this.TV_Messages.ImageIndex = 0;
            this.TV_Messages.ImageList = this.Img_TV_Messages;
            this.TV_Messages.Location = new System.Drawing.Point(3, 3);
            this.TV_Messages.Name = "TV_Messages";
            this.TV_Messages.SelectedImageIndex = 0;
            this.TV_Messages.Size = new System.Drawing.Size(375, 582);
            this.TV_Messages.TabIndex = 0;
            this.TV_Messages.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_Messages_NodeMouseClick);
            this.TV_Messages.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TV_Messages_KeyDown);
            // 
            // Context_TV_Messages
            // 
            this.Context_TV_Messages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddCanControllertoolStripMenuItem,
            this.messageToolStripMenuItem,
            this.createNewParameterToolStripMenuItem,
            this.createNewVirtualParameterToolStripMenuItem,
            this.toolStripMenuItem1,
            this.ControllerConfigToolStripMenuItem,
            this.ImportDBCtoolStripMenuItem,
            this.toolStripSeparator3,
            this.cutToolStripMenuItem,
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripMenuItem2,
            this.deleteToolStripMenuItem,
            this.toolStripMenuItem3,
            this.expandAllToolStripMenuItem,
            this.collapseAllToolStripMenuItem});
            this.Context_TV_Messages.Name = "Context_TV_Messages";
            this.Context_TV_Messages.Size = new System.Drawing.Size(227, 292);
            this.Context_TV_Messages.Opening += new System.ComponentModel.CancelEventHandler(this.Context_TV_MessagesOpening);
            // 
            // AddCanControllertoolStripMenuItem
            // 
            this.AddCanControllertoolStripMenuItem.Image = global::CANStream.Icones.CAN_Bus_16;
            this.AddCanControllertoolStripMenuItem.Name = "AddCanControllertoolStripMenuItem";
            this.AddCanControllertoolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.AddCanControllertoolStripMenuItem.Text = "Add CAN bus controller";
            this.AddCanControllertoolStripMenuItem.Click += new System.EventHandler(this.AddCanControllertoolStripMenuItemClick);
            // 
            // messageToolStripMenuItem
            // 
            this.messageToolStripMenuItem.Image = global::CANStream.Icones.New_CAN_Message_16;
            this.messageToolStripMenuItem.Name = "messageToolStripMenuItem";
            this.messageToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.messageToolStripMenuItem.Text = "Create new message";
            this.messageToolStripMenuItem.Click += new System.EventHandler(this.messageToolStripMenuItem_Click);
            // 
            // createNewParameterToolStripMenuItem
            // 
            this.createNewParameterToolStripMenuItem.Image = global::CANStream.Icones.CAN_Parameter_16;
            this.createNewParameterToolStripMenuItem.Name = "createNewParameterToolStripMenuItem";
            this.createNewParameterToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.createNewParameterToolStripMenuItem.Text = "Create new parameter";
            this.createNewParameterToolStripMenuItem.Click += new System.EventHandler(this.createNewParameterToolStripMenuItem_Click);
            // 
            // createNewVirtualParameterToolStripMenuItem
            // 
            this.createNewVirtualParameterToolStripMenuItem.Image = global::CANStream.Icones.Virtual_Channel_16;
            this.createNewVirtualParameterToolStripMenuItem.Name = "createNewVirtualParameterToolStripMenuItem";
            this.createNewVirtualParameterToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.createNewVirtualParameterToolStripMenuItem.Text = "Create new virtual parameter";
            this.createNewVirtualParameterToolStripMenuItem.Click += new System.EventHandler(this.CreateNewVirtualParameterToolStripMenuItemClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(223, 6);
            // 
            // ControllerConfigToolStripMenuItem
            // 
            this.ControllerConfigToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Import_ControllerCfg_TSMI,
            this.Export_ControllerCfg_TSMI});
            this.ControllerConfigToolStripMenuItem.Enabled = false;
            this.ControllerConfigToolStripMenuItem.Image = global::CANStream.Icones.CANStream_16;
            this.ControllerConfigToolStripMenuItem.Name = "ControllerConfigToolStripMenuItem";
            this.ControllerConfigToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ControllerConfigToolStripMenuItem.Text = "Controller configuration";
            // 
            // Import_ControllerCfg_TSMI
            // 
            this.Import_ControllerCfg_TSMI.Image = global::CANStream.Icones.Import_File_16;
            this.Import_ControllerCfg_TSMI.Name = "Import_ControllerCfg_TSMI";
            this.Import_ControllerCfg_TSMI.Size = new System.Drawing.Size(110, 22);
            this.Import_ControllerCfg_TSMI.Text = "Import";
            this.Import_ControllerCfg_TSMI.Click += new System.EventHandler(this.Import_ControllerCfg_TSMIClick);
            // 
            // Export_ControllerCfg_TSMI
            // 
            this.Export_ControllerCfg_TSMI.Image = global::CANStream.Icones.Export_File_16;
            this.Export_ControllerCfg_TSMI.Name = "Export_ControllerCfg_TSMI";
            this.Export_ControllerCfg_TSMI.Size = new System.Drawing.Size(110, 22);
            this.Export_ControllerCfg_TSMI.Text = "Export";
            this.Export_ControllerCfg_TSMI.Click += new System.EventHandler(this.Export_ControllerCfg_TSMIClick);
            // 
            // ImportDBCtoolStripMenuItem
            // 
            this.ImportDBCtoolStripMenuItem.Image = global::CANStream.Icones.DBC_Import_16;
            this.ImportDBCtoolStripMenuItem.Name = "ImportDBCtoolStripMenuItem";
            this.ImportDBCtoolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.ImportDBCtoolStripMenuItem.Text = "Import DBC";
            this.ImportDBCtoolStripMenuItem.Click += new System.EventHandler(this.ImportDBCtoolStripMenuItemClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(223, 6);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Image = global::CANStream.Icones.Cut_16;
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Image = global::CANStream.Icones.Copy_16;
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Image = global::CANStream.Icones.Paste_16;
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(223, 6);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::CANStream.Icones.Delete_16;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(223, 6);
            // 
            // expandAllToolStripMenuItem
            // 
            this.expandAllToolStripMenuItem.Name = "expandAllToolStripMenuItem";
            this.expandAllToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.expandAllToolStripMenuItem.Text = "Expand all";
            this.expandAllToolStripMenuItem.Click += new System.EventHandler(this.ExpandAllToolStripMenuItemClick);
            // 
            // collapseAllToolStripMenuItem
            // 
            this.collapseAllToolStripMenuItem.Name = "collapseAllToolStripMenuItem";
            this.collapseAllToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.collapseAllToolStripMenuItem.Text = "Collapse all";
            this.collapseAllToolStripMenuItem.Click += new System.EventHandler(this.CollapseAllToolStripMenuItemClick);
            // 
            // Img_TV_Messages
            // 
            this.Img_TV_Messages.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_TV_Messages.ImageStream")));
            this.Img_TV_Messages.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_TV_Messages.Images.SetKeyName(0, "brown-envelope-letter-message-icone-8951-16.png");
            this.Img_TV_Messages.Images.SetKeyName(1, "parametres-theme-icone-3702-16.png");
            this.Img_TV_Messages.Images.SetKeyName(2, "hardware-icone-4788-16.png");
            this.Img_TV_Messages.Images.SetKeyName(3, "edu-des-mathematiques-icone-4069-16.png");
            this.Img_TV_Messages.Images.SetKeyName(4, "address-book-icone-9846-16.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Txt_ConfigName);
            this.groupBox1.Controls.Add(this.label22);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.Txt_MsgLength);
            this.groupBox1.Controls.Add(this.label17);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.Cmb_BusRate);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(784, 57);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bus properties";
            // 
            // Txt_ConfigName
            // 
            this.Txt_ConfigName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_ConfigName.Location = new System.Drawing.Point(482, 28);
            this.Txt_ConfigName.Name = "Txt_ConfigName";
            this.Txt_ConfigName.Size = new System.Drawing.Size(296, 20);
            this.Txt_ConfigName.TabIndex = 4;
            this.Txt_ConfigName.TextChanged += new System.EventHandler(this.Txt_ConfigNameTextChanged);
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(376, 31);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(100, 13);
            this.label22.TabIndex = 6;
            this.label22.Text = "Configuration Name";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(338, 31);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(24, 13);
            this.label18.TabIndex = 5;
            this.label18.Text = "Bits";
            // 
            // Txt_MsgLength
            // 
            this.Txt_MsgLength.Location = new System.Drawing.Point(271, 28);
            this.Txt_MsgLength.Name = "Txt_MsgLength";
            this.Txt_MsgLength.Size = new System.Drawing.Size(61, 20);
            this.Txt_MsgLength.TabIndex = 3;
            this.Txt_MsgLength.TextChanged += new System.EventHandler(this.Txt_MsgLength_TextChanged);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(187, 31);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(82, 13);
            this.label17.TabIndex = 3;
            this.label17.Text = "Message length";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(115, 31);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(35, 13);
            this.label16.TabIndex = 2;
            this.label16.Text = "kBit/s";
            // 
            // Cmb_BusRate
            // 
            this.Cmb_BusRate.FormattingEnabled = true;
            this.Cmb_BusRate.Items.AddRange(new object[] {
            "500",
            "1000"});
            this.Cmb_BusRate.Location = new System.Drawing.Point(42, 28);
            this.Cmb_BusRate.Name = "Cmb_BusRate";
            this.Cmb_BusRate.Size = new System.Drawing.Size(67, 21);
            this.Cmb_BusRate.TabIndex = 2;
            this.Cmb_BusRate.SelectedIndexChanged += new System.EventHandler(this.Cmb_BusRate_SelectedIndexChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(30, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Rate";
            // 
            // Frame_MsgMap
            // 
            this.Frame_MsgMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Frame_MsgMap.Controls.Add(this.Lbl_MuxName);
            this.Frame_MsgMap.Controls.Add(this.Lbl_Mux);
            this.Frame_MsgMap.Controls.Add(this.NumUpDown_MuxValue);
            this.Frame_MsgMap.Controls.Add(this.Lbl_MuxValue);
            this.Frame_MsgMap.Controls.Add(this.Grid_MsgMap);
            this.Frame_MsgMap.Location = new System.Drawing.Point(379, 66);
            this.Frame_MsgMap.Name = "Frame_MsgMap";
            this.Frame_MsgMap.Size = new System.Drawing.Size(414, 573);
            this.Frame_MsgMap.TabIndex = 5;
            this.Frame_MsgMap.TabStop = false;
            this.Frame_MsgMap.Text = "Message Map";
            // 
            // Lbl_MuxName
            // 
            this.Lbl_MuxName.Enabled = false;
            this.Lbl_MuxName.Location = new System.Drawing.Point(72, 20);
            this.Lbl_MuxName.Name = "Lbl_MuxName";
            this.Lbl_MuxName.Size = new System.Drawing.Size(175, 18);
            this.Lbl_MuxName.TabIndex = 4;
            // 
            // Lbl_Mux
            // 
            this.Lbl_Mux.Enabled = false;
            this.Lbl_Mux.Location = new System.Drawing.Point(6, 20);
            this.Lbl_Mux.Name = "Lbl_Mux";
            this.Lbl_Mux.Size = new System.Drawing.Size(60, 18);
            this.Lbl_Mux.TabIndex = 3;
            this.Lbl_Mux.Text = "Multiplexer:";
            // 
            // NumUpDown_MuxValue
            // 
            this.NumUpDown_MuxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NumUpDown_MuxValue.Enabled = false;
            this.NumUpDown_MuxValue.Location = new System.Drawing.Point(349, 20);
            this.NumUpDown_MuxValue.Name = "NumUpDown_MuxValue";
            this.NumUpDown_MuxValue.Size = new System.Drawing.Size(56, 20);
            this.NumUpDown_MuxValue.TabIndex = 45;
            this.NumUpDown_MuxValue.ValueChanged += new System.EventHandler(this.NumUpDown_MuxValueValueChanged);
            // 
            // Lbl_MuxValue
            // 
            this.Lbl_MuxValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Lbl_MuxValue.Enabled = false;
            this.Lbl_MuxValue.Location = new System.Drawing.Point(253, 20);
            this.Lbl_MuxValue.Name = "Lbl_MuxValue";
            this.Lbl_MuxValue.Size = new System.Drawing.Size(90, 18);
            this.Lbl_MuxValue.TabIndex = 1;
            this.Lbl_MuxValue.Text = "Multiplexer value:";
            // 
            // Grid_MsgMap
            // 
            this.Grid_MsgMap.AllowUserToAddRows = false;
            this.Grid_MsgMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_MsgMap.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_MsgMap.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Bit7,
            this.Bit6,
            this.Bit5,
            this.Bit4,
            this.Bit3,
            this.Bit2,
            this.Bit1,
            this.Bit0});
            this.Grid_MsgMap.Location = new System.Drawing.Point(6, 46);
            this.Grid_MsgMap.Name = "Grid_MsgMap";
            this.Grid_MsgMap.RowHeadersWidth = 71;
            this.Grid_MsgMap.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.Grid_MsgMap.Size = new System.Drawing.Size(399, 523);
            this.Grid_MsgMap.TabIndex = 44;
            this.Grid_MsgMap.SizeChanged += new System.EventHandler(this.Grid_MsgMapSizeChanged);
            // 
            // Bit7
            // 
            this.Bit7.HeaderText = "Bit 7";
            this.Bit7.Name = "Bit7";
            this.Bit7.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit7.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit7.Width = 41;
            // 
            // Bit6
            // 
            this.Bit6.HeaderText = "Bit 6";
            this.Bit6.Name = "Bit6";
            this.Bit6.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit6.Width = 41;
            // 
            // Bit5
            // 
            this.Bit5.HeaderText = "Bit 5";
            this.Bit5.Name = "Bit5";
            this.Bit5.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit5.Width = 41;
            // 
            // Bit4
            // 
            this.Bit4.HeaderText = "Bit 4";
            this.Bit4.Name = "Bit4";
            this.Bit4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit4.Width = 41;
            // 
            // Bit3
            // 
            this.Bit3.HeaderText = "Bit 3";
            this.Bit3.Name = "Bit3";
            this.Bit3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit3.Width = 41;
            // 
            // Bit2
            // 
            this.Bit2.HeaderText = "Bit 2";
            this.Bit2.Name = "Bit2";
            this.Bit2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit2.Width = 41;
            // 
            // Bit1
            // 
            this.Bit1.HeaderText = "Bit 1";
            this.Bit1.Name = "Bit1";
            this.Bit1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit1.Width = 41;
            // 
            // Bit0
            // 
            this.Bit0.HeaderText = "Bit 0";
            this.Bit0.Name = "Bit0";
            this.Bit0.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Bit0.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Bit0.Width = 41;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl1.Controls.Add(this.Tab_Controller);
            this.tabControl1.Controls.Add(this.Tab_Message);
            this.tabControl1.Controls.Add(this.Tab_Parameter);
            this.tabControl1.Location = new System.Drawing.Point(3, 66);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(370, 573);
            this.tabControl1.TabIndex = 2;
            // 
            // Tab_Controller
            // 
            this.Tab_Controller.BackColor = System.Drawing.SystemColors.Control;
            this.Tab_Controller.Controls.Add(this.Grp_ControllerForm);
            this.Tab_Controller.Location = new System.Drawing.Point(4, 22);
            this.Tab_Controller.Name = "Tab_Controller";
            this.Tab_Controller.Size = new System.Drawing.Size(362, 547);
            this.Tab_Controller.TabIndex = 2;
            this.Tab_Controller.Text = "Bus controller";
            // 
            // Grp_ControllerForm
            // 
            this.Grp_ControllerForm.Controls.Add(this.Cmd_ControllerChange);
            this.Grp_ControllerForm.Controls.Add(this.Txt_ControllerDescription);
            this.Grp_ControllerForm.Controls.Add(this.label24);
            this.Grp_ControllerForm.Controls.Add(this.Txt_ControllerName);
            this.Grp_ControllerForm.Controls.Add(this.label23);
            this.Grp_ControllerForm.Enabled = false;
            this.Grp_ControllerForm.Location = new System.Drawing.Point(6, 6);
            this.Grp_ControllerForm.Name = "Grp_ControllerForm";
            this.Grp_ControllerForm.Size = new System.Drawing.Size(348, 362);
            this.Grp_ControllerForm.TabIndex = 0;
            this.Grp_ControllerForm.TabStop = false;
            // 
            // Cmd_ControllerChange
            // 
            this.Cmd_ControllerChange.Location = new System.Drawing.Point(267, 333);
            this.Cmd_ControllerChange.Name = "Cmd_ControllerChange";
            this.Cmd_ControllerChange.Size = new System.Drawing.Size(75, 23);
            this.Cmd_ControllerChange.TabIndex = 7;
            this.Cmd_ControllerChange.Text = "Change";
            this.Cmd_ControllerChange.UseVisualStyleBackColor = true;
            this.Cmd_ControllerChange.Click += new System.EventHandler(this.Cmd_ControllerChangeClick);
            // 
            // Txt_ControllerDescription
            // 
            this.Txt_ControllerDescription.Location = new System.Drawing.Point(78, 39);
            this.Txt_ControllerDescription.Multiline = true;
            this.Txt_ControllerDescription.Name = "Txt_ControllerDescription";
            this.Txt_ControllerDescription.Size = new System.Drawing.Size(264, 73);
            this.Txt_ControllerDescription.TabIndex = 6;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(18, 42);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(60, 13);
            this.label24.TabIndex = 33;
            this.label24.Text = "Description";
            // 
            // Txt_ControllerName
            // 
            this.Txt_ControllerName.Location = new System.Drawing.Point(78, 13);
            this.Txt_ControllerName.Name = "Txt_ControllerName";
            this.Txt_ControllerName.Size = new System.Drawing.Size(264, 20);
            this.Txt_ControllerName.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(18, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(35, 13);
            this.label23.TabIndex = 17;
            this.label23.Text = "Name";
            // 
            // Tab_Message
            // 
            this.Tab_Message.BackColor = System.Drawing.SystemColors.Control;
            this.Tab_Message.Controls.Add(this.Grp_MessageForm);
            this.Tab_Message.Location = new System.Drawing.Point(4, 22);
            this.Tab_Message.Name = "Tab_Message";
            this.Tab_Message.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Message.Size = new System.Drawing.Size(362, 547);
            this.Tab_Message.TabIndex = 0;
            this.Tab_Message.Text = "Message";
            // 
            // Grp_MessageForm
            // 
            this.Grp_MessageForm.Controls.Add(this.Txt_MsgComment);
            this.Grp_MessageForm.Controls.Add(this.label8);
            this.Grp_MessageForm.Controls.Add(this.Cmd_CancelNewMessage);
            this.Grp_MessageForm.Controls.Add(this.Cmd_CreateMessage);
            this.Grp_MessageForm.Controls.Add(this.label5);
            this.Grp_MessageForm.Controls.Add(this.label4);
            this.Grp_MessageForm.Controls.Add(this.Txt_MsgPeriod);
            this.Grp_MessageForm.Controls.Add(this.label3);
            this.Grp_MessageForm.Controls.Add(this.Radio_Tx);
            this.Grp_MessageForm.Controls.Add(this.Radio_Rx);
            this.Grp_MessageForm.Controls.Add(this.Txt_MsgIdentifier);
            this.Grp_MessageForm.Controls.Add(this.label2);
            this.Grp_MessageForm.Controls.Add(this.Txt_MsgName);
            this.Grp_MessageForm.Controls.Add(this.label1);
            this.Grp_MessageForm.Enabled = false;
            this.Grp_MessageForm.Location = new System.Drawing.Point(6, 6);
            this.Grp_MessageForm.Name = "Grp_MessageForm";
            this.Grp_MessageForm.Size = new System.Drawing.Size(348, 360);
            this.Grp_MessageForm.TabIndex = 15;
            this.Grp_MessageForm.TabStop = false;
            // 
            // Txt_MsgComment
            // 
            this.Txt_MsgComment.Location = new System.Drawing.Point(78, 102);
            this.Txt_MsgComment.Multiline = true;
            this.Txt_MsgComment.Name = "Txt_MsgComment";
            this.Txt_MsgComment.Size = new System.Drawing.Size(264, 73);
            this.Txt_MsgComment.TabIndex = 13;
            this.Txt_MsgComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_MessageTextBoxKeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Comment";
            // 
            // Cmd_CancelNewMessage
            // 
            this.Cmd_CancelNewMessage.Location = new System.Drawing.Point(186, 331);
            this.Cmd_CancelNewMessage.Name = "Cmd_CancelNewMessage";
            this.Cmd_CancelNewMessage.Size = new System.Drawing.Size(75, 23);
            this.Cmd_CancelNewMessage.TabIndex = 15;
            this.Cmd_CancelNewMessage.Text = "Cancel";
            this.Cmd_CancelNewMessage.UseVisualStyleBackColor = true;
            this.Cmd_CancelNewMessage.Click += new System.EventHandler(this.Cmd_CancelNewMessage_Click);
            // 
            // Cmd_CreateMessage
            // 
            this.Cmd_CreateMessage.Location = new System.Drawing.Point(267, 331);
            this.Cmd_CreateMessage.Name = "Cmd_CreateMessage";
            this.Cmd_CreateMessage.Size = new System.Drawing.Size(75, 23);
            this.Cmd_CreateMessage.TabIndex = 14;
            this.Cmd_CreateMessage.Text = "Create";
            this.Cmd_CreateMessage.UseVisualStyleBackColor = true;
            this.Cmd_CreateMessage.Click += new System.EventHandler(this.Cmd_CreateMessage_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(75, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "0x";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(185, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "ms";
            // 
            // Txt_MsgPeriod
            // 
            this.Txt_MsgPeriod.Location = new System.Drawing.Point(78, 68);
            this.Txt_MsgPeriod.Name = "Txt_MsgPeriod";
            this.Txt_MsgPeriod.Size = new System.Drawing.Size(101, 20);
            this.Txt_MsgPeriod.TabIndex = 12;
            this.Txt_MsgPeriod.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_MessageTextBoxKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Period";
            // 
            // Radio_Tx
            // 
            this.Radio_Tx.AutoSize = true;
            this.Radio_Tx.Checked = true;
            this.Radio_Tx.Location = new System.Drawing.Point(247, 40);
            this.Radio_Tx.Name = "Radio_Tx";
            this.Radio_Tx.Size = new System.Drawing.Size(37, 17);
            this.Radio_Tx.TabIndex = 11;
            this.Radio_Tx.TabStop = true;
            this.Radio_Tx.Text = "Tx";
            this.Radio_Tx.UseVisualStyleBackColor = true;
            // 
            // Radio_Rx
            // 
            this.Radio_Rx.AutoSize = true;
            this.Radio_Rx.Location = new System.Drawing.Point(203, 40);
            this.Radio_Rx.Name = "Radio_Rx";
            this.Radio_Rx.Size = new System.Drawing.Size(38, 17);
            this.Radio_Rx.TabIndex = 10;
            this.Radio_Rx.TabStop = true;
            this.Radio_Rx.Text = "Rx";
            this.Radio_Rx.UseVisualStyleBackColor = true;
            // 
            // Txt_MsgIdentifier
            // 
            this.Txt_MsgIdentifier.Location = new System.Drawing.Point(99, 39);
            this.Txt_MsgIdentifier.Name = "Txt_MsgIdentifier";
            this.Txt_MsgIdentifier.Size = new System.Drawing.Size(79, 20);
            this.Txt_MsgIdentifier.TabIndex = 9;
            this.Txt_MsgIdentifier.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_MessageTextBoxKeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Identifier";
            // 
            // Txt_MsgName
            // 
            this.Txt_MsgName.Location = new System.Drawing.Point(78, 13);
            this.Txt_MsgName.Name = "Txt_MsgName";
            this.Txt_MsgName.Size = new System.Drawing.Size(264, 20);
            this.Txt_MsgName.TabIndex = 8;
            this.Txt_MsgName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_MessageTextBoxKeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // Tab_Parameter
            // 
            this.Tab_Parameter.BackColor = System.Drawing.SystemColors.Control;
            this.Tab_Parameter.Controls.Add(this.Grp_ParameterForm);
            this.Tab_Parameter.Location = new System.Drawing.Point(4, 22);
            this.Tab_Parameter.Name = "Tab_Parameter";
            this.Tab_Parameter.Padding = new System.Windows.Forms.Padding(3);
            this.Tab_Parameter.Size = new System.Drawing.Size(362, 547);
            this.Tab_Parameter.TabIndex = 1;
            this.Tab_Parameter.Text = "Parameter";
            // 
            // Grp_ParameterForm
            // 
            this.Grp_ParameterForm.Controls.Add(this.Lbl_ParamMinMax);
            this.Grp_ParameterForm.Controls.Add(this.Grp_Alarms);
            this.Grp_ParameterForm.Controls.Add(this.Cmd_EnumDefinition);
            this.Grp_ParameterForm.Controls.Add(this.Txt_Decimals);
            this.Grp_ParameterForm.Controls.Add(this.Lbl_Decimals);
            this.Grp_ParameterForm.Controls.Add(this.Cmb_ValueFormat);
            this.Grp_ParameterForm.Controls.Add(this.label21);
            this.Grp_ParameterForm.Controls.Add(this.Cmd_VirtualRef);
            this.Grp_ParameterForm.Controls.Add(this.Txt_VirtualRef);
            this.Grp_ParameterForm.Controls.Add(this.Lbl_VirtualRef);
            this.Grp_ParameterForm.Controls.Add(this.Chk_Signed);
            this.Grp_ParameterForm.Controls.Add(this.Lbl_LinearizationInfo_2);
            this.Grp_ParameterForm.Controls.Add(this.Lbl_LinearizationInfo_1);
            this.Grp_ParameterForm.Controls.Add(this.Txt_ParamComment);
            this.Grp_ParameterForm.Controls.Add(this.label20);
            this.Grp_ParameterForm.Controls.Add(this.Txt_ParamUnit);
            this.Grp_ParameterForm.Controls.Add(this.label19);
            this.Grp_ParameterForm.Controls.Add(this.Cmb_ParamEndianess);
            this.Grp_ParameterForm.Controls.Add(this.label7);
            this.Grp_ParameterForm.Controls.Add(this.Chk_MuxParameter);
            this.Grp_ParameterForm.Controls.Add(this.Cmd_CancelNewParam);
            this.Grp_ParameterForm.Controls.Add(this.Cmd_CreateParameter);
            this.Grp_ParameterForm.Controls.Add(this.Grp_ParamMultiplexer);
            this.Grp_ParameterForm.Controls.Add(this.Txt_ParamZero);
            this.Grp_ParameterForm.Controls.Add(this.label12);
            this.Grp_ParameterForm.Controls.Add(this.Txt_ParamGain);
            this.Grp_ParameterForm.Controls.Add(this.label13);
            this.Grp_ParameterForm.Controls.Add(this.Txt_ParamLength);
            this.Grp_ParameterForm.Controls.Add(this.label11);
            this.Grp_ParameterForm.Controls.Add(this.Txt_ParamStartBit);
            this.Grp_ParameterForm.Controls.Add(this.label10);
            this.Grp_ParameterForm.Controls.Add(this.Txt_ParamName);
            this.Grp_ParameterForm.Controls.Add(this.label9);
            this.Grp_ParameterForm.Enabled = false;
            this.Grp_ParameterForm.Location = new System.Drawing.Point(6, 6);
            this.Grp_ParameterForm.Name = "Grp_ParameterForm";
            this.Grp_ParameterForm.Size = new System.Drawing.Size(348, 542);
            this.Grp_ParameterForm.TabIndex = 16;
            this.Grp_ParameterForm.TabStop = false;
            // 
            // Lbl_ParamMinMax
            // 
            this.Lbl_ParamMinMax.AutoSize = true;
            this.Lbl_ParamMinMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_ParamMinMax.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Lbl_ParamMinMax.Location = new System.Drawing.Point(159, 154);
            this.Lbl_ParamMinMax.Name = "Lbl_ParamMinMax";
            this.Lbl_ParamMinMax.Size = new System.Drawing.Size(61, 13);
            this.Lbl_ParamMinMax.TabIndex = 51;
            this.Lbl_ParamMinMax.Text = "Min: / Max:";
            // 
            // Grp_Alarms
            // 
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMax_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMax_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMin_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_AlarmMin_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMax_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMax_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Chk_AlarmMax);
            this.Grp_Alarms.Controls.Add(this.Chk_AlarmMin);
            this.Grp_Alarms.Controls.Add(this.Chk_WarningMax);
            this.Grp_Alarms.Controls.Add(this.Txt_AlarmMax);
            this.Grp_Alarms.Controls.Add(this.Txt_AlarmMin);
            this.Grp_Alarms.Controls.Add(this.Txt_WarningMax);
            this.Grp_Alarms.Controls.Add(this.Lbl_Alarms_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMin_Forecolor);
            this.Grp_Alarms.Controls.Add(this.Chk_WarningMin);
            this.Grp_Alarms.Controls.Add(this.Chk_AlarmsEnabled);
            this.Grp_Alarms.Controls.Add(this.Pic_WarningMin_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Lbl_Alarms_Backcolor);
            this.Grp_Alarms.Controls.Add(this.Txt_WarningMin);
            this.Grp_Alarms.Location = new System.Drawing.Point(12, 363);
            this.Grp_Alarms.Name = "Grp_Alarms";
            this.Grp_Alarms.Size = new System.Drawing.Size(330, 144);
            this.Grp_Alarms.TabIndex = 33;
            this.Grp_Alarms.TabStop = false;
            this.Grp_Alarms.Text = "Warnings and alarms";
            // 
            // Pic_AlarmMax_Forecolor
            // 
            this.Pic_AlarmMax_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMax_Forecolor.Enabled = false;
            this.Pic_AlarmMax_Forecolor.Location = new System.Drawing.Point(269, 117);
            this.Pic_AlarmMax_Forecolor.Name = "Pic_AlarmMax_Forecolor";
            this.Pic_AlarmMax_Forecolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_AlarmMax_Forecolor.TabIndex = 73;
            this.Pic_AlarmMax_Forecolor.TabStop = false;
            this.Pic_AlarmMax_Forecolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMax_Forecolor_DoubleClick);
            // 
            // Pic_AlarmMax_Backcolor
            // 
            this.Pic_AlarmMax_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMax_Backcolor.Enabled = false;
            this.Pic_AlarmMax_Backcolor.Location = new System.Drawing.Point(206, 117);
            this.Pic_AlarmMax_Backcolor.Name = "Pic_AlarmMax_Backcolor";
            this.Pic_AlarmMax_Backcolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_AlarmMax_Backcolor.TabIndex = 72;
            this.Pic_AlarmMax_Backcolor.TabStop = false;
            this.Pic_AlarmMax_Backcolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMax_Backcolor_DoubleClick);
            // 
            // Pic_AlarmMin_Forecolor
            // 
            this.Pic_AlarmMin_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMin_Forecolor.Enabled = false;
            this.Pic_AlarmMin_Forecolor.Location = new System.Drawing.Point(269, 39);
            this.Pic_AlarmMin_Forecolor.Name = "Pic_AlarmMin_Forecolor";
            this.Pic_AlarmMin_Forecolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_AlarmMin_Forecolor.TabIndex = 71;
            this.Pic_AlarmMin_Forecolor.TabStop = false;
            this.Pic_AlarmMin_Forecolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMin_Forecolor_DoubleClick);
            // 
            // Pic_AlarmMin_Backcolor
            // 
            this.Pic_AlarmMin_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_AlarmMin_Backcolor.Enabled = false;
            this.Pic_AlarmMin_Backcolor.Location = new System.Drawing.Point(206, 39);
            this.Pic_AlarmMin_Backcolor.Name = "Pic_AlarmMin_Backcolor";
            this.Pic_AlarmMin_Backcolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_AlarmMin_Backcolor.TabIndex = 70;
            this.Pic_AlarmMin_Backcolor.TabStop = false;
            this.Pic_AlarmMin_Backcolor.DoubleClick += new System.EventHandler(this.Pic_AlarmMin_Backcolor_DoubleClick);
            // 
            // Pic_WarningMax_Forecolor
            // 
            this.Pic_WarningMax_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMax_Forecolor.Enabled = false;
            this.Pic_WarningMax_Forecolor.Location = new System.Drawing.Point(269, 90);
            this.Pic_WarningMax_Forecolor.Name = "Pic_WarningMax_Forecolor";
            this.Pic_WarningMax_Forecolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_WarningMax_Forecolor.TabIndex = 69;
            this.Pic_WarningMax_Forecolor.TabStop = false;
            this.Pic_WarningMax_Forecolor.DoubleClick += new System.EventHandler(this.Pic_WarningMax_Forecolor_DoubleClick);
            // 
            // Pic_WarningMax_Backcolor
            // 
            this.Pic_WarningMax_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMax_Backcolor.Enabled = false;
            this.Pic_WarningMax_Backcolor.Location = new System.Drawing.Point(206, 90);
            this.Pic_WarningMax_Backcolor.Name = "Pic_WarningMax_Backcolor";
            this.Pic_WarningMax_Backcolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_WarningMax_Backcolor.TabIndex = 68;
            this.Pic_WarningMax_Backcolor.TabStop = false;
            this.Pic_WarningMax_Backcolor.DoubleClick += new System.EventHandler(this.Pic_WarningMax_Backcolor_DoubleClick);
            // 
            // Chk_AlarmMax
            // 
            this.Chk_AlarmMax.AutoSize = true;
            this.Chk_AlarmMax.Enabled = false;
            this.Chk_AlarmMax.Location = new System.Drawing.Point(13, 120);
            this.Chk_AlarmMax.Name = "Chk_AlarmMax";
            this.Chk_AlarmMax.Size = new System.Drawing.Size(94, 17);
            this.Chk_AlarmMax.TabIndex = 41;
            this.Chk_AlarmMax.Text = "Alarm limit max";
            this.Chk_AlarmMax.UseVisualStyleBackColor = true;
            this.Chk_AlarmMax.CheckedChanged += new System.EventHandler(this.Chk_AlarmMax_CheckedChanged);
            // 
            // Chk_AlarmMin
            // 
            this.Chk_AlarmMin.AutoSize = true;
            this.Chk_AlarmMin.Enabled = false;
            this.Chk_AlarmMin.Location = new System.Drawing.Point(13, 41);
            this.Chk_AlarmMin.Name = "Chk_AlarmMin";
            this.Chk_AlarmMin.Size = new System.Drawing.Size(91, 17);
            this.Chk_AlarmMin.TabIndex = 35;
            this.Chk_AlarmMin.Text = "Alarm limit min";
            this.Chk_AlarmMin.UseVisualStyleBackColor = true;
            this.Chk_AlarmMin.CheckedChanged += new System.EventHandler(this.Chk_AlarmMin_CheckedChanged);
            // 
            // Chk_WarningMax
            // 
            this.Chk_WarningMax.AutoSize = true;
            this.Chk_WarningMax.Enabled = false;
            this.Chk_WarningMax.Location = new System.Drawing.Point(13, 92);
            this.Chk_WarningMax.Name = "Chk_WarningMax";
            this.Chk_WarningMax.Size = new System.Drawing.Size(108, 17);
            this.Chk_WarningMax.TabIndex = 39;
            this.Chk_WarningMax.Text = "Warning limit max";
            this.Chk_WarningMax.UseVisualStyleBackColor = true;
            this.Chk_WarningMax.CheckedChanged += new System.EventHandler(this.Chk_WarningMax_CheckedChanged);
            // 
            // Txt_AlarmMax
            // 
            this.Txt_AlarmMax.Enabled = false;
            this.Txt_AlarmMax.Location = new System.Drawing.Point(124, 117);
            this.Txt_AlarmMax.Name = "Txt_AlarmMax";
            this.Txt_AlarmMax.Size = new System.Drawing.Size(76, 20);
            this.Txt_AlarmMax.TabIndex = 42;
            // 
            // Txt_AlarmMin
            // 
            this.Txt_AlarmMin.Enabled = false;
            this.Txt_AlarmMin.Location = new System.Drawing.Point(124, 39);
            this.Txt_AlarmMin.Name = "Txt_AlarmMin";
            this.Txt_AlarmMin.Size = new System.Drawing.Size(76, 20);
            this.Txt_AlarmMin.TabIndex = 36;
            // 
            // Txt_WarningMax
            // 
            this.Txt_WarningMax.Enabled = false;
            this.Txt_WarningMax.Location = new System.Drawing.Point(124, 90);
            this.Txt_WarningMax.Name = "Txt_WarningMax";
            this.Txt_WarningMax.Size = new System.Drawing.Size(76, 20);
            this.Txt_WarningMax.TabIndex = 40;
            // 
            // Lbl_Alarms_Forecolor
            // 
            this.Lbl_Alarms_Forecolor.Enabled = false;
            this.Lbl_Alarms_Forecolor.Location = new System.Drawing.Point(269, 19);
            this.Lbl_Alarms_Forecolor.Name = "Lbl_Alarms_Forecolor";
            this.Lbl_Alarms_Forecolor.Size = new System.Drawing.Size(55, 13);
            this.Lbl_Alarms_Forecolor.TabIndex = 61;
            this.Lbl_Alarms_Forecolor.Text = "Forecolor";
            this.Lbl_Alarms_Forecolor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Pic_WarningMin_Forecolor
            // 
            this.Pic_WarningMin_Forecolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMin_Forecolor.Enabled = false;
            this.Pic_WarningMin_Forecolor.Location = new System.Drawing.Point(269, 65);
            this.Pic_WarningMin_Forecolor.Name = "Pic_WarningMin_Forecolor";
            this.Pic_WarningMin_Forecolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_WarningMin_Forecolor.TabIndex = 60;
            this.Pic_WarningMin_Forecolor.TabStop = false;
            this.Pic_WarningMin_Forecolor.DoubleClick += new System.EventHandler(this.Pic_WarningMin_Forecolor_DoubleClick);
            // 
            // Chk_WarningMin
            // 
            this.Chk_WarningMin.AutoSize = true;
            this.Chk_WarningMin.Enabled = false;
            this.Chk_WarningMin.Location = new System.Drawing.Point(13, 67);
            this.Chk_WarningMin.Name = "Chk_WarningMin";
            this.Chk_WarningMin.Size = new System.Drawing.Size(105, 17);
            this.Chk_WarningMin.TabIndex = 37;
            this.Chk_WarningMin.Text = "Warning limit min";
            this.Chk_WarningMin.UseVisualStyleBackColor = true;
            this.Chk_WarningMin.CheckedChanged += new System.EventHandler(this.Chk_WarningMin_CheckedChanged);
            // 
            // Chk_AlarmsEnabled
            // 
            this.Chk_AlarmsEnabled.AutoSize = true;
            this.Chk_AlarmsEnabled.Location = new System.Drawing.Point(6, 19);
            this.Chk_AlarmsEnabled.Name = "Chk_AlarmsEnabled";
            this.Chk_AlarmsEnabled.Size = new System.Drawing.Size(158, 17);
            this.Chk_AlarmsEnabled.TabIndex = 34;
            this.Chk_AlarmsEnabled.Text = "Enable warnings and alarms";
            this.Chk_AlarmsEnabled.UseVisualStyleBackColor = true;
            this.Chk_AlarmsEnabled.CheckedChanged += new System.EventHandler(this.Chk_AlarmsEnabled_CheckedChanged);
            // 
            // Pic_WarningMin_Backcolor
            // 
            this.Pic_WarningMin_Backcolor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_WarningMin_Backcolor.Enabled = false;
            this.Pic_WarningMin_Backcolor.Location = new System.Drawing.Point(206, 65);
            this.Pic_WarningMin_Backcolor.Name = "Pic_WarningMin_Backcolor";
            this.Pic_WarningMin_Backcolor.Size = new System.Drawing.Size(55, 20);
            this.Pic_WarningMin_Backcolor.TabIndex = 52;
            this.Pic_WarningMin_Backcolor.TabStop = false;
            this.Pic_WarningMin_Backcolor.DoubleClick += new System.EventHandler(this.Pic_WarningMin_Backcolor_DoubleClick);
            // 
            // Lbl_Alarms_Backcolor
            // 
            this.Lbl_Alarms_Backcolor.Enabled = false;
            this.Lbl_Alarms_Backcolor.Location = new System.Drawing.Point(205, 19);
            this.Lbl_Alarms_Backcolor.Name = "Lbl_Alarms_Backcolor";
            this.Lbl_Alarms_Backcolor.Size = new System.Drawing.Size(55, 13);
            this.Lbl_Alarms_Backcolor.TabIndex = 50;
            this.Lbl_Alarms_Backcolor.Text = "Backcolor";
            this.Lbl_Alarms_Backcolor.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Txt_WarningMin
            // 
            this.Txt_WarningMin.Enabled = false;
            this.Txt_WarningMin.Location = new System.Drawing.Point(124, 65);
            this.Txt_WarningMin.Name = "Txt_WarningMin";
            this.Txt_WarningMin.Size = new System.Drawing.Size(76, 20);
            this.Txt_WarningMin.TabIndex = 38;
            // 
            // Cmd_EnumDefinition
            // 
            this.Cmd_EnumDefinition.Enabled = false;
            this.Cmd_EnumDefinition.Image = global::CANStream.Icones.Enumeration_Edit_16;
            this.Cmd_EnumDefinition.Location = new System.Drawing.Point(311, 332);
            this.Cmd_EnumDefinition.Name = "Cmd_EnumDefinition";
            this.Cmd_EnumDefinition.Size = new System.Drawing.Size(25, 25);
            this.Cmd_EnumDefinition.TabIndex = 32;
            this.ToolTip_Commands.SetToolTip(this.Cmd_EnumDefinition, "Edit enumeration");
            this.Cmd_EnumDefinition.UseVisualStyleBackColor = true;
            this.Cmd_EnumDefinition.Click += new System.EventHandler(this.Cmd_EnumDefinition_Click);
            // 
            // Txt_Decimals
            // 
            this.Txt_Decimals.Enabled = false;
            this.Txt_Decimals.Location = new System.Drawing.Point(260, 335);
            this.Txt_Decimals.Name = "Txt_Decimals";
            this.Txt_Decimals.Size = new System.Drawing.Size(45, 20);
            this.Txt_Decimals.TabIndex = 31;
            // 
            // Lbl_Decimals
            // 
            this.Lbl_Decimals.AutoSize = true;
            this.Lbl_Decimals.Enabled = false;
            this.Lbl_Decimals.Location = new System.Drawing.Point(204, 338);
            this.Lbl_Decimals.Name = "Lbl_Decimals";
            this.Lbl_Decimals.Size = new System.Drawing.Size(50, 13);
            this.Lbl_Decimals.TabIndex = 47;
            this.Lbl_Decimals.Text = "Decimals";
            // 
            // Cmb_ValueFormat
            // 
            this.Cmb_ValueFormat.FormattingEnabled = true;
            this.Cmb_ValueFormat.Items.AddRange(new object[] {
            "MSBFirst",
            "LSBFirst"});
            this.Cmb_ValueFormat.Location = new System.Drawing.Point(81, 335);
            this.Cmb_ValueFormat.Name = "Cmb_ValueFormat";
            this.Cmb_ValueFormat.Size = new System.Drawing.Size(117, 21);
            this.Cmb_ValueFormat.TabIndex = 30;
            this.Cmb_ValueFormat.SelectedValueChanged += new System.EventHandler(this.Cmb_ValueFormat_SelectedValueChanged);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(12, 338);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 13);
            this.label21.TabIndex = 45;
            this.label21.Text = "Format";
            // 
            // Cmd_VirtualRef
            // 
            this.Cmd_VirtualRef.Image = global::CANStream.Icones.Virtual_Channel_16;
            this.Cmd_VirtualRef.Location = new System.Drawing.Point(313, 218);
            this.Cmd_VirtualRef.Name = "Cmd_VirtualRef";
            this.Cmd_VirtualRef.Size = new System.Drawing.Size(25, 25);
            this.Cmd_VirtualRef.TabIndex = 25;
            this.ToolTip_Commands.SetToolTip(this.Cmd_VirtualRef, "Select virtual channel");
            this.Cmd_VirtualRef.UseVisualStyleBackColor = true;
            this.Cmd_VirtualRef.Visible = false;
            this.Cmd_VirtualRef.Click += new System.EventHandler(this.Cmd_VirtualRefClick);
            // 
            // Txt_VirtualRef
            // 
            this.Txt_VirtualRef.Location = new System.Drawing.Point(81, 221);
            this.Txt_VirtualRef.Name = "Txt_VirtualRef";
            this.Txt_VirtualRef.ReadOnly = true;
            this.Txt_VirtualRef.Size = new System.Drawing.Size(226, 20);
            this.Txt_VirtualRef.TabIndex = 43;
            this.Txt_VirtualRef.Visible = false;
            // 
            // Lbl_VirtualRef
            // 
            this.Lbl_VirtualRef.AutoSize = true;
            this.Lbl_VirtualRef.Location = new System.Drawing.Point(12, 224);
            this.Lbl_VirtualRef.Name = "Lbl_VirtualRef";
            this.Lbl_VirtualRef.Size = new System.Drawing.Size(63, 13);
            this.Lbl_VirtualRef.TabIndex = 42;
            this.Lbl_VirtualRef.Text = "Virtual chan";
            this.Lbl_VirtualRef.Visible = false;
            // 
            // Chk_Signed
            // 
            this.Chk_Signed.Location = new System.Drawing.Point(169, 67);
            this.Chk_Signed.Name = "Chk_Signed";
            this.Chk_Signed.Size = new System.Drawing.Size(104, 20);
            this.Chk_Signed.TabIndex = 20;
            this.Chk_Signed.Text = "Signed";
            this.Chk_Signed.UseVisualStyleBackColor = true;
            this.Chk_Signed.CheckedChanged += new System.EventHandler(this.Chk_Signed_CheckedChanged);
            // 
            // Lbl_LinearizationInfo_2
            // 
            this.Lbl_LinearizationInfo_2.AutoSize = true;
            this.Lbl_LinearizationInfo_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LinearizationInfo_2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Lbl_LinearizationInfo_2.Location = new System.Drawing.Point(81, 130);
            this.Lbl_LinearizationInfo_2.Name = "Lbl_LinearizationInfo_2";
            this.Lbl_LinearizationInfo_2.Size = new System.Drawing.Size(127, 13);
            this.Lbl_LinearizationInfo_2.TabIndex = 40;
            this.Lbl_LinearizationInfo_2.Text = "Eng = Raw x Gain + Zero";
            // 
            // Lbl_LinearizationInfo_1
            // 
            this.Lbl_LinearizationInfo_1.AutoSize = true;
            this.Lbl_LinearizationInfo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_LinearizationInfo_1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.Lbl_LinearizationInfo_1.Location = new System.Drawing.Point(81, 117);
            this.Lbl_LinearizationInfo_1.Name = "Lbl_LinearizationInfo_1";
            this.Lbl_LinearizationInfo_1.Size = new System.Drawing.Size(208, 13);
            this.Lbl_LinearizationInfo_1.TabIndex = 39;
            this.Lbl_LinearizationInfo_1.Text = "Linearization from raw to engineering value";
            // 
            // Txt_ParamComment
            // 
            this.Txt_ParamComment.Location = new System.Drawing.Point(81, 177);
            this.Txt_ParamComment.Multiline = true;
            this.Txt_ParamComment.Name = "Txt_ParamComment";
            this.Txt_ParamComment.Size = new System.Drawing.Size(255, 38);
            this.Txt_ParamComment.TabIndex = 24;
            this.Txt_ParamComment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(12, 177);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(51, 13);
            this.label20.TabIndex = 37;
            this.label20.Text = "Comment";
            // 
            // Txt_ParamUnit
            // 
            this.Txt_ParamUnit.Location = new System.Drawing.Point(81, 151);
            this.Txt_ParamUnit.Name = "Txt_ParamUnit";
            this.Txt_ParamUnit.Size = new System.Drawing.Size(72, 20);
            this.Txt_ParamUnit.TabIndex = 23;
            this.Txt_ParamUnit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(12, 154);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(26, 13);
            this.label19.TabIndex = 35;
            this.label19.Text = "Unit";
            // 
            // Cmb_ParamEndianess
            // 
            this.Cmb_ParamEndianess.FormattingEnabled = true;
            this.Cmb_ParamEndianess.Items.AddRange(new object[] {
            "MSBFirst",
            "LSBFirst"});
            this.Cmb_ParamEndianess.Location = new System.Drawing.Point(81, 67);
            this.Cmb_ParamEndianess.Name = "Cmb_ParamEndianess";
            this.Cmb_ParamEndianess.Size = new System.Drawing.Size(72, 21);
            this.Cmb_ParamEndianess.TabIndex = 19;
            this.Cmb_ParamEndianess.SelectedIndexChanged += new System.EventHandler(this.Cmb_ParamEndianessSelectedIndexChanged);
            this.Cmb_ParamEndianess.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 70);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 13);
            this.label7.TabIndex = 33;
            this.label7.Text = "Endianess";
            // 
            // Chk_MuxParameter
            // 
            this.Chk_MuxParameter.Location = new System.Drawing.Point(12, 242);
            this.Chk_MuxParameter.Name = "Chk_MuxParameter";
            this.Chk_MuxParameter.Size = new System.Drawing.Size(133, 24);
            this.Chk_MuxParameter.TabIndex = 26;
            this.Chk_MuxParameter.Text = "Multiplexed parameter";
            this.Chk_MuxParameter.UseVisualStyleBackColor = true;
            this.Chk_MuxParameter.CheckedChanged += new System.EventHandler(this.Chk_MuxParameterCheckedChanged);
            // 
            // Cmd_CancelNewParam
            // 
            this.Cmd_CancelNewParam.Location = new System.Drawing.Point(186, 513);
            this.Cmd_CancelNewParam.Name = "Cmd_CancelNewParam";
            this.Cmd_CancelNewParam.Size = new System.Drawing.Size(75, 23);
            this.Cmd_CancelNewParam.TabIndex = 44;
            this.Cmd_CancelNewParam.Text = "Cancel";
            this.Cmd_CancelNewParam.UseVisualStyleBackColor = true;
            this.Cmd_CancelNewParam.Click += new System.EventHandler(this.Cmd_CancelNewParam_Click);
            // 
            // Cmd_CreateParameter
            // 
            this.Cmd_CreateParameter.Location = new System.Drawing.Point(267, 513);
            this.Cmd_CreateParameter.Name = "Cmd_CreateParameter";
            this.Cmd_CreateParameter.Size = new System.Drawing.Size(75, 23);
            this.Cmd_CreateParameter.TabIndex = 43;
            this.Cmd_CreateParameter.Text = "Create";
            this.Cmd_CreateParameter.UseVisualStyleBackColor = true;
            this.Cmd_CreateParameter.Click += new System.EventHandler(this.Cmd_CreateParameter_Click);
            // 
            // Grp_ParamMultiplexer
            // 
            this.Grp_ParamMultiplexer.Controls.Add(this.Cmb_ParamMultiplexerValue);
            this.Grp_ParamMultiplexer.Controls.Add(this.label6);
            this.Grp_ParamMultiplexer.Controls.Add(this.Cmb_ParamMultiplexerName);
            this.Grp_ParamMultiplexer.Controls.Add(this.label14);
            this.Grp_ParamMultiplexer.Enabled = false;
            this.Grp_ParamMultiplexer.Location = new System.Drawing.Point(12, 261);
            this.Grp_ParamMultiplexer.Name = "Grp_ParamMultiplexer";
            this.Grp_ParamMultiplexer.Size = new System.Drawing.Size(330, 64);
            this.Grp_ParamMultiplexer.TabIndex = 27;
            this.Grp_ParamMultiplexer.TabStop = false;
            // 
            // Cmb_ParamMultiplexerValue
            // 
            this.Cmb_ParamMultiplexerValue.FormattingEnabled = true;
            this.Cmb_ParamMultiplexerValue.Location = new System.Drawing.Point(124, 38);
            this.Cmb_ParamMultiplexerValue.Name = "Cmb_ParamMultiplexerValue";
            this.Cmb_ParamMultiplexerValue.Size = new System.Drawing.Size(200, 21);
            this.Cmb_ParamMultiplexerValue.TabIndex = 29;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Multiplexer Value";
            // 
            // Cmb_ParamMultiplexerName
            // 
            this.Cmb_ParamMultiplexerName.FormattingEnabled = true;
            this.Cmb_ParamMultiplexerName.Location = new System.Drawing.Point(124, 11);
            this.Cmb_ParamMultiplexerName.Name = "Cmb_ParamMultiplexerName";
            this.Cmb_ParamMultiplexerName.Size = new System.Drawing.Size(200, 21);
            this.Cmb_ParamMultiplexerName.TabIndex = 28;
            this.Cmb_ParamMultiplexerName.SelectedIndexChanged += new System.EventHandler(this.Cmb_ParamMultiplexerNameSelectedIndexChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(11, 14);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(107, 13);
            this.label14.TabIndex = 9;
            this.label14.Text = "Multiplexer parameter";
            // 
            // Txt_ParamZero
            // 
            this.Txt_ParamZero.Location = new System.Drawing.Point(218, 94);
            this.Txt_ParamZero.Name = "Txt_ParamZero";
            this.Txt_ParamZero.Size = new System.Drawing.Size(72, 20);
            this.Txt_ParamZero.TabIndex = 22;
            this.Txt_ParamZero.TextChanged += new System.EventHandler(this.Txt_ParamZero_TextChanged);
            this.Txt_ParamZero.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(169, 97);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(29, 13);
            this.label12.TabIndex = 24;
            this.label12.Text = "Zero";
            // 
            // Txt_ParamGain
            // 
            this.Txt_ParamGain.Location = new System.Drawing.Point(81, 94);
            this.Txt_ParamGain.Name = "Txt_ParamGain";
            this.Txt_ParamGain.Size = new System.Drawing.Size(72, 20);
            this.Txt_ParamGain.TabIndex = 21;
            this.Txt_ParamGain.TextChanged += new System.EventHandler(this.Txt_ParamGain_TextChanged);
            this.Txt_ParamGain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(12, 97);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(29, 13);
            this.label13.TabIndex = 22;
            this.label13.Text = "Gain";
            // 
            // Txt_ParamLength
            // 
            this.Txt_ParamLength.Location = new System.Drawing.Point(218, 39);
            this.Txt_ParamLength.Name = "Txt_ParamLength";
            this.Txt_ParamLength.Size = new System.Drawing.Size(72, 20);
            this.Txt_ParamLength.TabIndex = 18;
            this.Txt_ParamLength.TextChanged += new System.EventHandler(this.Txt_ParamLength_TextChanged);
            this.Txt_ParamLength.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 42);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Length";
            // 
            // Txt_ParamStartBit
            // 
            this.Txt_ParamStartBit.Location = new System.Drawing.Point(81, 39);
            this.Txt_ParamStartBit.Name = "Txt_ParamStartBit";
            this.Txt_ParamStartBit.Size = new System.Drawing.Size(72, 20);
            this.Txt_ParamStartBit.TabIndex = 17;
            this.Txt_ParamStartBit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 42);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Start bit";
            // 
            // Txt_ParamName
            // 
            this.Txt_ParamName.Location = new System.Drawing.Point(81, 13);
            this.Txt_ParamName.Name = "Txt_ParamName";
            this.Txt_ParamName.Size = new System.Drawing.Size(255, 20);
            this.Txt_ParamName.TabIndex = 16;
            this.Txt_ParamName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Generic_ParameterTextBoxKeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Name";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_New,
            this.TSB_Open,
            this.TSB_Save,
            this.toolStripSeparator1,
            this.TSB_Cut,
            this.TSB_Copy,
            this.TSB_Paste,
            this.toolStripSeparator2,
            this.TSB_ImportDBC,
            this.TSB_NewController,
            this.TSB_NewMessage,
            this.TSB_NewParameter,
            this.TSB_NewVirtualParameter,
            this.TSB_Delete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1181, 39);
            this.toolStrip1.TabIndex = 3;
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
            this.TSB_New.ToolTipText = "New CAN Configuration";
            this.TSB_New.Click += new System.EventHandler(this.TSB_New_Click);
            // 
            // TSB_Open
            // 
            this.TSB_Open.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Open.Image = global::CANStream.Icones.File_Open_32;
            this.TSB_Open.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Open.Name = "TSB_Open";
            this.TSB_Open.Size = new System.Drawing.Size(36, 36);
            this.TSB_Open.Text = "toolStripButton2";
            this.TSB_Open.ToolTipText = "Open CAN Configuration";
            this.TSB_Open.Click += new System.EventHandler(this.TSB_Open_Click);
            // 
            // TSB_Save
            // 
            this.TSB_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Save.Image = global::CANStream.Icones.File_Save_32;
            this.TSB_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Save.Name = "TSB_Save";
            this.TSB_Save.Size = new System.Drawing.Size(36, 36);
            this.TSB_Save.Text = "toolStripButton3";
            this.TSB_Save.ToolTipText = "Save CAN Configuration";
            this.TSB_Save.Click += new System.EventHandler(this.TSB_Save_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_Cut
            // 
            this.TSB_Cut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Cut.Image = global::CANStream.Icones.Cut_32;
            this.TSB_Cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Cut.Name = "TSB_Cut";
            this.TSB_Cut.Size = new System.Drawing.Size(36, 36);
            this.TSB_Cut.Text = "toolStripButton1";
            this.TSB_Cut.ToolTipText = "Cut";
            this.TSB_Cut.Click += new System.EventHandler(this.TSB_Cut_Click);
            // 
            // TSB_Copy
            // 
            this.TSB_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Copy.Image = global::CANStream.Icones.Copy_32;
            this.TSB_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Copy.Name = "TSB_Copy";
            this.TSB_Copy.Size = new System.Drawing.Size(36, 36);
            this.TSB_Copy.Text = "toolStripButton2";
            this.TSB_Copy.ToolTipText = "Copy";
            this.TSB_Copy.Click += new System.EventHandler(this.TSB_Copy_Click);
            // 
            // TSB_Paste
            // 
            this.TSB_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Paste.Image = global::CANStream.Icones.Paste_32;
            this.TSB_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Paste.Name = "TSB_Paste";
            this.TSB_Paste.Size = new System.Drawing.Size(36, 36);
            this.TSB_Paste.Text = "toolStripButton3";
            this.TSB_Paste.ToolTipText = "Paste";
            this.TSB_Paste.Click += new System.EventHandler(this.TSB_Paste_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // TSB_ImportDBC
            // 
            this.TSB_ImportDBC.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_ImportDBC.Image = global::CANStream.Icones.DBC_Import_32;
            this.TSB_ImportDBC.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_ImportDBC.Name = "TSB_ImportDBC";
            this.TSB_ImportDBC.Size = new System.Drawing.Size(36, 36);
            this.TSB_ImportDBC.Text = "toolStripButton1";
            this.TSB_ImportDBC.ToolTipText = "Import DBC";
            this.TSB_ImportDBC.Click += new System.EventHandler(this.TSB_ImportDBCClick);
            // 
            // TSB_NewController
            // 
            this.TSB_NewController.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewController.Image = global::CANStream.Icones.CAN_Bus_32;
            this.TSB_NewController.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewController.Name = "TSB_NewController";
            this.TSB_NewController.Size = new System.Drawing.Size(36, 36);
            this.TSB_NewController.Text = "TSB_NewController";
            this.TSB_NewController.ToolTipText = "New CAN bus controller";
            this.TSB_NewController.Click += new System.EventHandler(this.TSB_NewControllerClick);
            // 
            // TSB_NewMessage
            // 
            this.TSB_NewMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewMessage.Image = global::CANStream.Icones.New_CAN_Message_32;
            this.TSB_NewMessage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewMessage.Name = "TSB_NewMessage";
            this.TSB_NewMessage.Size = new System.Drawing.Size(36, 36);
            this.TSB_NewMessage.Text = "toolStripButton1";
            this.TSB_NewMessage.ToolTipText = "New message";
            this.TSB_NewMessage.Click += new System.EventHandler(this.TSB_NewMessage_Click);
            // 
            // TSB_NewParameter
            // 
            this.TSB_NewParameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewParameter.Image = global::CANStream.Icones.CAN_Parameter_32;
            this.TSB_NewParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewParameter.Name = "TSB_NewParameter";
            this.TSB_NewParameter.Size = new System.Drawing.Size(36, 36);
            this.TSB_NewParameter.Text = "toolStripButton2";
            this.TSB_NewParameter.ToolTipText = "New parameter";
            this.TSB_NewParameter.Click += new System.EventHandler(this.TSB_NewParameter_Click);
            // 
            // TSB_NewVirtualParameter
            // 
            this.TSB_NewVirtualParameter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_NewVirtualParameter.Image = global::CANStream.Icones.Virtual_Channel_32;
            this.TSB_NewVirtualParameter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_NewVirtualParameter.Name = "TSB_NewVirtualParameter";
            this.TSB_NewVirtualParameter.Size = new System.Drawing.Size(36, 36);
            this.TSB_NewVirtualParameter.Text = "toolStripButton1";
            this.TSB_NewVirtualParameter.ToolTipText = "New virtual parameter";
            this.TSB_NewVirtualParameter.Click += new System.EventHandler(this.TSB_NewVirtualParameterClick);
            // 
            // TSB_Delete
            // 
            this.TSB_Delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Delete.Image = global::CANStream.Icones.Delete_32;
            this.TSB_Delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Delete.Name = "TSB_Delete";
            this.TSB_Delete.Size = new System.Drawing.Size(36, 36);
            this.TSB_Delete.Text = "toolStripButton3";
            this.TSB_Delete.ToolTipText = "Delete selection";
            this.TSB_Delete.Click += new System.EventHandler(this.TSB_Delete_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Frm_CANConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1181, 681);
            this.Controls.Add(this.Split_Tree_Props);
            this.Controls.Add(this.toolStrip1);
            this.Icon = global::CANStream.Icones.CANStream_Icone;
            this.MinimumSize = new System.Drawing.Size(900, 470);
            this.Name = "Frm_CANConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CAN Messages Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_CANConfiguration_FormClosing);
            this.Load += new System.EventHandler(this.Frm_CANConfiguration_Load);
            this.Split_Tree_Props.Panel1.ResumeLayout(false);
            this.Split_Tree_Props.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Split_Tree_Props)).EndInit();
            this.Split_Tree_Props.ResumeLayout(false);
            this.Grp_Filter.ResumeLayout(false);
            this.Context_TV_Messages.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Frame_MsgMap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumUpDown_MuxValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_MsgMap)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.Tab_Controller.ResumeLayout(false);
            this.Grp_ControllerForm.ResumeLayout(false);
            this.Grp_ControllerForm.PerformLayout();
            this.Tab_Message.ResumeLayout(false);
            this.Grp_MessageForm.ResumeLayout(false);
            this.Grp_MessageForm.PerformLayout();
            this.Tab_Parameter.ResumeLayout(false);
            this.Grp_ParameterForm.ResumeLayout(false);
            this.Grp_ParameterForm.PerformLayout();
            this.Grp_Alarms.ResumeLayout(false);
            this.Grp_Alarms.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMax_Backcolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_AlarmMin_Backcolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMax_Backcolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Forecolor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_WarningMin_Backcolor)).EndInit();
            this.Grp_ParamMultiplexer.ResumeLayout(false);
            this.Grp_ParamMultiplexer.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ComboBox Cmb_Filter;
        private System.Windows.Forms.GroupBox Grp_Filter;
        private System.Windows.Forms.Label Lbl_VirtualRef;
        private System.Windows.Forms.TextBox Txt_VirtualRef;
        private System.Windows.Forms.Button Cmd_VirtualRef;
        private System.Windows.Forms.ToolStripMenuItem createNewVirtualParameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TSB_NewVirtualParameter;
        private System.Windows.Forms.CheckBox Chk_Signed;
        private System.Windows.Forms.ToolStripMenuItem ImportDBCtoolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TSB_ImportDBC;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem Export_ControllerCfg_TSMI;
        private System.Windows.Forms.ToolStripMenuItem Import_ControllerCfg_TSMI;
        private System.Windows.Forms.ToolStripMenuItem ControllerConfigToolStripMenuItem;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox Txt_ControllerName;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.TextBox Txt_ControllerDescription;
        private System.Windows.Forms.Button Cmd_ControllerChange;
        private System.Windows.Forms.GroupBox Grp_ControllerForm;
        private System.Windows.Forms.TabPage Tab_Parameter;
        private System.Windows.Forms.TabPage Tab_Message;
        private System.Windows.Forms.TabPage Tab_Controller;
        private System.Windows.Forms.ToolStripMenuItem AddCanControllertoolStripMenuItem;
        private System.Windows.Forms.ToolStripButton TSB_NewController;
        private System.Windows.Forms.Label Lbl_MuxName;
        private System.Windows.Forms.Label Lbl_MuxValue;
        private System.Windows.Forms.NumericUpDown NumUpDown_MuxValue;
        private System.Windows.Forms.Label Lbl_Mux;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox Txt_ConfigName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit0;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Bit7;
        private System.Windows.Forms.DataGridView Grid_MsgMap;
        private System.Windows.Forms.GroupBox Frame_MsgMap;
        private System.Windows.Forms.Label Lbl_LinearizationInfo_1;
        private System.Windows.Forms.Label Lbl_LinearizationInfo_2;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox Txt_ParamUnit;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox Txt_ParamComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox Txt_MsgComment;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox Cmb_ParamEndianess;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox Cmb_ParamMultiplexerValue;
        private System.Windows.Forms.CheckBox Chk_MuxParameter;
        private System.Windows.Forms.ToolStripMenuItem collapseAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem expandAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;

        #endregion

        private System.Windows.Forms.SplitContainer Split_Tree_Props;
        private System.Windows.Forms.TreeView TV_Messages;
        private System.Windows.Forms.ImageList Img_TV_Messages;
        private System.Windows.Forms.ContextMenuStrip Context_TV_Messages;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSB_New;
        private System.Windows.Forms.ToolStripButton TSB_Open;
        private System.Windows.Forms.ToolStripButton TSB_Save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_Cut;
        private System.Windows.Forms.ToolStripButton TSB_Copy;
        private System.Windows.Forms.ToolStripButton TSB_Paste;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton TSB_NewMessage;
        private System.Windows.Forms.ToolStripButton TSB_NewParameter;
        private System.Windows.Forms.ToolStripButton TSB_Delete;
        private System.Windows.Forms.ToolStripMenuItem messageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewParameterToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.GroupBox Grp_MessageForm;
        private System.Windows.Forms.Button Cmd_CreateMessage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_MsgPeriod;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton Radio_Tx;
        private System.Windows.Forms.RadioButton Radio_Rx;
        private System.Windows.Forms.TextBox Txt_MsgIdentifier;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Txt_MsgName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox Grp_ParameterForm;
        private System.Windows.Forms.Button Cmd_CreateParameter;
        private System.Windows.Forms.GroupBox Grp_ParamMultiplexer;
        private System.Windows.Forms.ComboBox Cmb_ParamMultiplexerName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox Txt_ParamZero;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox Txt_ParamGain;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox Txt_ParamLength;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox Txt_ParamStartBit;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox Txt_ParamName;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button Cmd_CancelNewMessage;
        private System.Windows.Forms.Button Cmd_CancelNewParam;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox Txt_MsgLength;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox Cmb_BusRate;
        private System.Windows.Forms.Button Cmd_EnumDefinition;
        private System.Windows.Forms.TextBox Txt_Decimals;
        private System.Windows.Forms.Label Lbl_Decimals;
        private System.Windows.Forms.ComboBox Cmb_ValueFormat;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.GroupBox Grp_Alarms;
        private System.Windows.Forms.CheckBox Chk_WarningMin;
        private System.Windows.Forms.CheckBox Chk_AlarmsEnabled;
        private System.Windows.Forms.PictureBox Pic_WarningMin_Backcolor;
        private System.Windows.Forms.Label Lbl_Alarms_Backcolor;
        private System.Windows.Forms.TextBox Txt_WarningMin;
        private System.Windows.Forms.ToolTip ToolTip_Commands;
        private System.Windows.Forms.CheckBox Chk_AlarmMin;
        private System.Windows.Forms.CheckBox Chk_WarningMax;
        private System.Windows.Forms.TextBox Txt_AlarmMax;
        private System.Windows.Forms.TextBox Txt_AlarmMin;
        private System.Windows.Forms.TextBox Txt_WarningMax;
        private System.Windows.Forms.Label Lbl_Alarms_Forecolor;
        private System.Windows.Forms.PictureBox Pic_WarningMin_Forecolor;
        private System.Windows.Forms.PictureBox Pic_AlarmMax_Forecolor;
        private System.Windows.Forms.PictureBox Pic_AlarmMax_Backcolor;
        private System.Windows.Forms.PictureBox Pic_AlarmMin_Forecolor;
        private System.Windows.Forms.PictureBox Pic_AlarmMin_Backcolor;
        private System.Windows.Forms.PictureBox Pic_WarningMax_Forecolor;
        private System.Windows.Forms.PictureBox Pic_WarningMax_Backcolor;
        private System.Windows.Forms.CheckBox Chk_AlarmMax;
        private System.Windows.Forms.ColorDialog Dlg_SelectColor;
        private System.Windows.Forms.Label Lbl_ParamMinMax;
    }
}