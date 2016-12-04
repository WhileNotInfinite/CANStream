using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANStream
{
    public partial class Frm_LogginChannelConfig : Form
    {
        #region Private constants

        private const int GRID_COL_NAME = 1;
        private const int GRID_COL_LOG_MODE = 2;
        private const int GRID_COL_LOG_FREQ = 3;
        private const int GRID_COL_COMMENT = 4;

        #endregion

        #region Private members

        private CS_RecordLoggingConfiguration oLoggingConfig;

        private bool bConfigModified;
        private bool bGroupModification;

        #endregion

        public Frm_LogginChannelConfig(string LoggingChannelConfigFile)
        {
            InitializeComponent();

            oLoggingConfig = new CS_RecordLoggingConfiguration();
            bConfigModified = false;

            CGrid_Channels.Columns[GRID_COL_NAME].HeaderText = "Channel Name";
            CGrid_Channels.Columns.Add("oCol_LoggingMode", "Logging Mode");
            CGrid_Channels.Columns.Add("oCol_LoggingFreq", "Logging Frequency");
            CGrid_Channels.Columns.Add("oCol_Comment", "Comment");

            CGrid_Channels.Columns[GRID_COL_NAME].ReadOnly = true;

            CGrid_Channels.Columns[GRID_COL_NAME].Width = 150;
            CGrid_Channels.Columns[GRID_COL_LOG_MODE].Width = 150;
            CGrid_Channels.Columns[GRID_COL_LOG_FREQ].Width = 150;
            CGrid_Channels.Columns[GRID_COL_COMMENT].Width = CGrid_Channels.Width - 500;

            CGrid_Channels.Columns[GRID_COL_LOG_MODE].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CGrid_Channels.Columns[GRID_COL_LOG_FREQ].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CGrid_Channels.Columns[GRID_COL_LOG_MODE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CGrid_Channels.Columns[GRID_COL_LOG_FREQ].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;

            bGroupModification = false;
        }

        #region Control events

        #region TS_Main

        private void TSB_New_Click(object sender, EventArgs e)
        {
            New_LoggingChannelConfig();
        }

        private void TSB_Open_Click(object sender, EventArgs e)
        {
            Open_LoggingChannelCondig();
        }

        private void TSB_Save_Click(object sender, EventArgs e)
        {
            Save_LoggingChannelConfig();
        }

        private void TSB_Copy_Click(object sender, EventArgs e)
        {
            Copy_LoggingItemProperties();
        }

        private void TSB_Paste_Click(object sender, EventArgs e)
        {
            Paste_LoggingItemProperties();
        }

        private void TSB_Delete_Click(object sender, EventArgs e)
        {
            Delete_GridRow();
        }

        private void TSB_CanConfig_Click(object sender, EventArgs e)
        {
            Import_CanConfig();
        }

        private void TSB_VirtualChan_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Context_Grid

        private void Context_Grid_CollapseAll_Click(object sender, EventArgs e)
        {
            CollapseAllGridRows();
        }

        private void Context_Grid_ExpandAll_Click(object sender, EventArgs e)
        {
            ExpandAllGridRows();
        }

        private void Context_Grid_Copy_Click(object sender, EventArgs e)
        {
            Copy_LoggingItemProperties();
        }

        private void Context_Grid_Paste_Click(object sender, EventArgs e)
        {
            Paste_LoggingItemProperties();
        }

        private void Context_Grid_Delete_Click(object sender, EventArgs e)
        {
            Delete_GridRow();
        }

        #endregion

        #region CGrid_Channels

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;

            if (e.RowIndex > 0 && e.ColumnIndex > GRID_COL_NAME && bGroupModification == false)
            {
                if (CGrid_Channels.Grid.Rows[e.RowIndex].Tag.GetType() == typeof(LoggingChannelConfiguration))
                {
                    LoggingChannelConfiguration oLogChanCfg = (LoggingChannelConfiguration)CGrid_Channels.Grid.Rows[e.RowIndex].Tag;

                    Set_LoggingItemProperties(CGrid_Channels.Grid.Rows[e.RowIndex], e.ColumnIndex, oLogChanCfg);
                }
                else if (CGrid_Channels.Grid.Rows[e.RowIndex].Tag.GetType() == typeof(LoggingChannelGroup))
                {
                    bGroupModification = true;

                    LoggingChannelGroup oLogChanGrp = (LoggingChannelGroup)CGrid_Channels.Grid.Rows[e.RowIndex].Tag;
                    Set_LoggingItemProperties(CGrid_Channels.Grid.Rows[e.RowIndex], e.ColumnIndex, oLogChanGrp);

                    if (e.ColumnIndex == GRID_COL_LOG_MODE || e.ColumnIndex == GRID_COL_LOG_FREQ)
                    {
                        CollapsableGridRow oCRow = CGrid_Channels.Rows.GetCollapsableRowAtGridRowIndex(e.RowIndex);

                        if (!(oCRow == null))
                        {
                            string sLogMode = CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_MODE].Value.ToString();
                            string sLogFreq = CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_FREQ].Value.ToString();

                            foreach (CollapsableGridRow oChildRow in oCRow.Children)
                            {
                                bool ret = Set_LoggingItemProperties(
                                                                        oChildRow.ThisRow,
                                                                        e.ColumnIndex,
                                                                        oChildRow.ThisRow.Tag,
                                                                        sLogMode,
                                                                        sLogFreq,
                                                                        ""
                                                                     );

                                bGroupModification = false;
                                if (ret == false) return;

                                if (oChildRow.Children.Count > 0)
                                {
                                    foreach (CollapsableGridRow oGranChildRow in oChildRow.Children)
                                    {
                                        bool ret2 = Set_LoggingItemProperties(
                                                                               oChildRow.ThisRow,
                                                                               e.ColumnIndex,
                                                                               oChildRow.ThisRow.Tag,
                                                                               sLogMode,
                                                                               sLogFreq,
                                                                               ""
                                                                            );

                                        bGroupModification = false;
                                        if (ret2 == false) return;
                                    }
                                }
                            }

                            CGrid_Channels.SaveRowsCollapsingContext();
                            Show_LoggingChannelConfig();
                            CGrid_Channels.RestoreRowsCollapsingContext();
                        }
                    }

                    bGroupModification = false;
                }
            }

            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
        }

        #endregion

        #endregion

        #region Private methodes

        private void New_LoggingChannelConfig()
        {
            if (!(Verify_ConfigurationModified())) return;

            oLoggingConfig = new CS_RecordLoggingConfiguration();
            Clear_LoggingChannelConfig();
            bConfigModified = false;
        }

        private void Save_LoggingChannelConfig()
        {
            Dlg_SaveFile.FileName = "";
            Dlg_SaveFile.Filter = "Logging Channels Configuration file|*.lcc";
            Dlg_SaveFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Logging Channels Configuration";

            if (this.Dlg_SaveFile.ShowDialog() == DialogResult.OK)
            {
                oLoggingConfig.Write_LoggingConfigurationFile(Dlg_SaveFile.FileName);
                bConfigModified = false;
            }
        }

        private void Open_LoggingChannelCondig()
        {
            if (!(Verify_ConfigurationModified())) return;

            Dlg_OpenFile.FileName = "";
            Dlg_OpenFile.Filter = "Logging Channels Configuration file|*.lcc";
            Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Logging Channels Configuration";

            if (this.Dlg_OpenFile.ShowDialog()==DialogResult.OK)
            {
                oLoggingConfig = new CS_RecordLoggingConfiguration();

                if(oLoggingConfig.Read_LoggingConfigurationFile(Dlg_OpenFile.FileName))
                {
                    Show_LoggingChannelConfig();
                }
                else
                {
                    MessageBox.Show("An occured while reading the logging channel configuration file !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Clear_LoggingChannelConfig();
                }

                bConfigModified = false;
            }
        }

        private void Clear_LoggingChannelConfig()
        {
            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;
            CGrid_Channels.Rows.Clear();
            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
        }

        private void Show_LoggingChannelConfig()
        {
            CGrid_Channels.Rows.Clear();

            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;

            foreach (LoggingChannelGroup oChanGrp in oLoggingConfig.Groups)
            {
                CollapsableGridRow oGroupRow = CGrid_Channels.Rows.Add();
                Set_LoggingModeCells(oGroupRow.ThisRow);

                oGroupRow.ThisRow.Tag = oChanGrp;

                Show_LoggingConfigurationItem(
                                                oGroupRow.ThisRow,
                                                oChanGrp.Name,
                                                oChanGrp.GroupLoggingMode,
                                                oChanGrp.GroupLoggingFrequency,
                                                oChanGrp.GroupDefaultFrequency,
                                                oChanGrp.Comment
                                              );

                Color_GridRow(oGroupRow.ThisRow, Color.MidnightBlue, Color.White);

                //Channels of the group
                int iChan = 0;
                foreach (LoggingChannelConfiguration oChan in oChanGrp.LoggingChannels)
                {
                    CollapsableGridRow oChanRow = oGroupRow.Children.Add();
                    Set_LoggingModeCells(oChanRow.ThisRow);

                    oChanRow.ThisRow.Tag = oChan;

                    Show_LoggingConfigurationItem(
                                                    oChanRow.ThisRow,
                                                    oChan.Name,
                                                    oChan.LoggingMode,
                                                    oChan.LoggingFrequency,
                                                    oChan.DefaultFrequency,
                                                    oChan.Comment
                                                  );

                    if (iChan % 2 != 0)
                    {
                        Color_GridRow(oChanRow.ThisRow, Color.LightCyan, Color.Black);
                    }

                    iChan++;
                }

                //Sub groups of the group
                foreach(LoggingChannelGroup oSubGroup in oChanGrp.SubGroups)
                {
                    CollapsableGridRow oSubGroupRow = oGroupRow.Children.Add();
                    Set_LoggingModeCells(oSubGroupRow.ThisRow);

                    oSubGroupRow.ThisRow.Tag = oSubGroup;

                    Show_LoggingConfigurationItem(
                                                    oSubGroupRow.ThisRow,
                                                    oSubGroup.Name,
                                                    oSubGroup.GroupLoggingMode,
                                                    oSubGroup.GroupLoggingFrequency,
                                                    oSubGroup.GroupDefaultFrequency,
                                                    oSubGroup.Comment
                                                 );

                    Color_GridRow(oSubGroupRow.ThisRow, Color.LightSkyBlue, Color.Black);

                    int iSubChan = 0;
                    foreach (LoggingChannelConfiguration oSubGroupChan in oSubGroup.LoggingChannels)
                    {
                        CollapsableGridRow oSubChanRow = oSubGroupRow.Children.Add();
                        Set_LoggingModeCells(oSubChanRow.ThisRow);

                        oSubChanRow.ThisRow.Tag = oSubGroupChan;

                        Show_LoggingConfigurationItem(
                                                        oSubChanRow.ThisRow,
                                                        oSubGroupChan.Name,
                                                        oSubGroupChan.LoggingMode,
                                                        oSubGroupChan.LoggingFrequency,
                                                        oSubGroupChan.DefaultFrequency,
                                                        oSubGroupChan.Comment
                                                     );

                        if (iSubChan % 2 != 0)
                        {
                            Color_GridRow(oSubChanRow.ThisRow, Color.LightCyan, Color.Black);
                        }

                        iSubChan++;
                    }
                }
            }

            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
        }

        private void Show_LoggingConfigurationItem(DataGridViewRow oRow, string ItemName, ChannelLoggingMode ItemLoggingMode, double ItemLoggingFreq, double ItemDefaultFreq, string ItemComment)
        {
            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;

            oRow.Cells[GRID_COL_NAME].Value = ItemName;
            oRow.Cells[GRID_COL_LOG_MODE].Value = ItemLoggingMode.ToString();

            switch(ItemLoggingMode)
            {
                case ChannelLoggingMode.CustomFrequency:

                    oRow.Cells[GRID_COL_LOG_FREQ].Value = ItemLoggingFreq.ToString();
                    break;

                case ChannelLoggingMode.NotLogged:

                    oRow.Cells[GRID_COL_LOG_FREQ].Value = "0";
                    break;

                default: //ChannelLoggingMode.DefaultFrequency

                    oRow.Cells[GRID_COL_LOG_FREQ].Value = ItemDefaultFreq.ToString();
                    break;
            }

            oRow.Cells[GRID_COL_COMMENT].Value = ItemComment;

            oRow.Cells[GRID_COL_LOG_FREQ].ReadOnly = !(ItemLoggingMode == ChannelLoggingMode.CustomFrequency);
        }

        private void Set_LoggingModeCells(DataGridViewRow oRow)
        {
            oRow.Cells[GRID_COL_LOG_MODE] = new DataGridViewComboBoxCell();
            DataGridViewComboBoxCell oCmbCell = oRow.Cells[GRID_COL_LOG_MODE] as DataGridViewComboBoxCell;

            oCmbCell.Items.Clear();
            oCmbCell.Items.AddRange(Enum.GetNames(typeof(ChannelLoggingMode)));
        }

        private void Color_GridRow(DataGridViewRow oRow, Color BackColor,Color ForeColor)
        {
            for (int i = 1; i < oRow.Cells.Count; i++)
            {
                oRow.Cells[i].Style.BackColor = BackColor;
                oRow.Cells[i].Style.ForeColor = ForeColor;
            }
        }

        private void Import_CanConfig()
        {
            if (!(Verify_ConfigurationModified())) return;

            Dlg_OpenFile.FileName = "";
            Dlg_OpenFile.Filter = "CAN Configuration|*.xcc"; //"CAN Configuration|*.xcc|Multiple CAN bus Configuration|*.mcb"
            Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";

            if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
            {
                CANMessagesConfiguration oCanCfg = new CANMessagesConfiguration();

                if (oCanCfg.ReadCANConfigurationFile(Dlg_OpenFile.FileName))
                {
                    Set_CanConfiguration(oCanCfg);
                    Show_LoggingChannelConfig();
                    bConfigModified = true;
                }
                else
                {
                    MessageBox.Show("CAN Configuration file read error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Set_CanConfiguration(CANMessagesConfiguration oCanConfig)
        {
            if (!(oCanConfig == null))
            {
                oLoggingConfig = new CS_RecordLoggingConfiguration();

                foreach (CANMessage oMsg in oCanConfig.Messages)
                {
                    string ChannelGroupName = "Msg [0x" + oMsg.Identifier + "] " + oMsg.Name;
                    oLoggingConfig.Add_LoggingChannelGroup(ChannelGroupName);

                    LoggingChannelGroup oMsgGroup = oLoggingConfig.Get_LoggingChannelGroup(ChannelGroupName);

                    oMsgGroup.GroupLoggingMode = ChannelLoggingMode.DefaultFrequency;
                    oMsgGroup.GroupLoggingFrequency = Math.Round(1 / ((double)oMsg.Period / 1000), 0);
                    oMsgGroup.GroupDefaultFrequency = Math.Round(1 / ((double)oMsg.Period / 1000), 0);

                    if (!(oMsgGroup == null))
                    {
                        oMsgGroup.Comment = oMsg.Comment;

                        foreach (CANParameter oParam in oMsg.Parameters)
                        {
                            LoggingChannelConfiguration oChanCfg = new LoggingChannelConfiguration();

                            oChanCfg.Name = oParam.Name;
                            oChanCfg.Comment = oParam.Comment;
                            oChanCfg.LoggingMode = ChannelLoggingMode.DefaultFrequency;

                            if (oMsg.Period != 0)
                            {
                                oChanCfg.DefaultFrequency = Math.Round(1 / ((double)oMsg.Period / 1000), 0);
                            }
                            else
                            {
                                oChanCfg.LoggingFrequency = 1;
                            }

                            oChanCfg.LoggingFrequency = oChanCfg.DefaultFrequency;

                            if (oParam.IsMultiplexed)
                            {
                                string MuxName = "Mux: " + oMsg.MultiplexerName + " = " + oParam.MultiplexerValue.ToString();
                                LoggingChannelGroup oMuxGroup = oLoggingConfig.Get_LoggingChannelGroup(MuxName);

                                if (oMuxGroup == null)
                                {
                                    oLoggingConfig.Add_LoggingChannelGroup(MuxName, oMsgGroup);
                                    oMuxGroup = oLoggingConfig.Get_LoggingChannelGroup(MuxName);

                                    oMuxGroup.GroupLoggingMode = ChannelLoggingMode.DefaultFrequency;
                                    oMuxGroup.GroupLoggingFrequency = Math.Round(1 / ((double)oMsg.Period / 1000), 0);
                                    oMuxGroup.GroupDefaultFrequency = Math.Round(1 / ((double)oMsg.Period / 1000), 0);
                                }

                                if(!(oMuxGroup==null))
                                {
                                    oLoggingConfig.Add_LoggingChannel(oChanCfg, oMuxGroup);
                                }

                            }
                            else
                            {
                                oLoggingConfig.Add_LoggingChannel(oChanCfg, oMsgGroup);
                            }
                        }
                    }
                }
            }
        }

        private bool Set_LoggingItemProperties(DataGridViewRow oRow, int ModifiedColId, object oLogItem)
        {
            bool Ret = false;

            if (!(oRow.Cells[GRID_COL_LOG_MODE].Value == null ||
                  oRow.Cells[GRID_COL_LOG_FREQ].Value == null ||
                  oRow.Cells[GRID_COL_COMMENT].Value == null))
            {
                Ret = Set_LoggingItemProperties(
                                                oRow,
                                                ModifiedColId,
                                                oLogItem,
                                                oRow.Cells[GRID_COL_LOG_MODE].Value.ToString(),
                                                oRow.Cells[GRID_COL_LOG_FREQ].Value.ToString(),
                                                oRow.Cells[GRID_COL_COMMENT].Value.ToString()
                                                );
            }

            return (Ret);
        }

        private bool Set_LoggingItemProperties(DataGridViewRow oRow, int ModifiedColId, object oLogItem, string LoggingMode, string sLoggingFreq, string Comment)
        {
            switch (ModifiedColId)
            {
                case GRID_COL_LOG_MODE:
                    {
                        if (!(oLogItem == null))
                        {
                            ChannelLoggingMode eLogMode = (ChannelLoggingMode)(Enum.Parse(typeof(ChannelLoggingMode), LoggingMode));

                            switch (eLogMode)
                            {
                                case ChannelLoggingMode.CustomFrequency:
                                    {
                                        double LogFreq = 0;

                                        if (oLogItem.GetType() == typeof(LoggingChannelConfiguration))
                                        {
                                            LogFreq = ((LoggingChannelConfiguration)oLogItem).LoggingFrequency;
                                        }
                                        else if (oLogItem.GetType() == typeof(LoggingChannelGroup))
                                        {
                                            LogFreq = ((LoggingChannelGroup)oLogItem).GroupLoggingFrequency;
                                        }
                                        
                                        oRow.Cells[GRID_COL_LOG_FREQ].Value = LogFreq.ToString();
                                        oRow.Cells[GRID_COL_LOG_FREQ].ReadOnly = false;
                                    }
                                    break;

                                case ChannelLoggingMode.NotLogged:
                                    {
                                        oRow.Cells[GRID_COL_LOG_FREQ].Value = "0";
                                        oRow.Cells[GRID_COL_LOG_FREQ].ReadOnly = true;
                                    }
                                    break;

                                default: //ChannelLoggingMode.DefaultFrequency:
                                    {
                                        double LogFreq = 0;

                                        if (oLogItem.GetType() == typeof(LoggingChannelConfiguration))
                                        {
                                            LogFreq = ((LoggingChannelConfiguration)oLogItem).DefaultFrequency;
                                        }
                                        else if (oLogItem.GetType() == typeof(LoggingChannelGroup))
                                        {
                                            LogFreq = ((LoggingChannelGroup)oLogItem).GroupDefaultFrequency;
                                        }

                                        oRow.Cells[GRID_COL_LOG_FREQ].Value = LogFreq.ToString();

                                        oRow.Cells[GRID_COL_LOG_FREQ].ReadOnly = true;
                                    }
                                    break;
                            }

                            if (oLogItem.GetType() == typeof(LoggingChannelConfiguration))
                            {
                                ((LoggingChannelConfiguration)oLogItem).LoggingMode = eLogMode;
                            }
                            else if (oLogItem.GetType() == typeof(LoggingChannelGroup))
                            {
                                ((LoggingChannelGroup)oLogItem).GroupLoggingMode = eLogMode;
                            }
                            else
                            {
                                //Not supposed to happen
                            }

                            bConfigModified = true;
                        }
                    }
                    break;

                case GRID_COL_LOG_FREQ:
                    {
                        if (!(oLogItem == null))
                        {
                            double FreqSet = 0;
                            double RoundedFreqSet = 0;

                            if (double.TryParse(sLoggingFreq, out FreqSet))
                            {
                                if (FreqSet >= 0 && FreqSet <= 1000)
                                {
                                    RoundedFreqSet = Math.Round(FreqSet, 0);

                                    if (oLogItem.GetType() == typeof(LoggingChannelConfiguration))
                                    {
                                        ((LoggingChannelConfiguration)oLogItem).LoggingFrequency = RoundedFreqSet;
                                    }
                                    else if (oLogItem.GetType() == typeof(LoggingChannelGroup))
                                    {
                                        ((LoggingChannelGroup)oLogItem).GroupLoggingFrequency = RoundedFreqSet;
                                    }
                                    else
                                    {
                                        //Not supposed to happen
                                    }

                                    oRow.Cells[GRID_COL_LOG_FREQ].Value = RoundedFreqSet.ToString();
                                    bConfigModified = true;

                                    if (RoundedFreqSet != FreqSet)
                                    {
                                        MessageBox.Show("Logging frequency has been rounded to " + RoundedFreqSet.ToString() + " Hz",
                                                        Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Logging frequency must be contained between 0 Hz and 1000 Hz !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                    if (oLogItem.GetType() == typeof(LoggingChannelConfiguration))
                                    {
                                        oRow.Cells[GRID_COL_LOG_FREQ].Value = ((LoggingChannelConfiguration)oLogItem).LoggingFrequency.ToString();
                                    }
                                    else if (oLogItem.GetType() == typeof(LoggingChannelGroup))
                                    {
                                        oRow.Cells[GRID_COL_LOG_FREQ].Value = ((LoggingChannelGroup)oLogItem).GroupLoggingFrequency.ToString();
                                    }
                                    else
                                    {
                                        //Not supposed to happen
                                    }

                                    return (false);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Logging frequency value should be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);

                                if (oLogItem.GetType() == typeof(LoggingChannelConfiguration))
                                {
                                    oRow.Cells[GRID_COL_LOG_FREQ].Value = ((LoggingChannelConfiguration)oLogItem).LoggingFrequency.ToString();
                                }
                                else if (oLogItem.GetType() == typeof(LoggingChannelGroup))
                                {
                                    oRow.Cells[GRID_COL_LOG_FREQ].Value = ((LoggingChannelGroup)oLogItem).GroupLoggingFrequency.ToString();
                                }
                                else
                                {
                                    //Not supposed to happen
                                }

                                return (false);
                            }
                        }
                    }
                    break;

                case GRID_COL_COMMENT:

                    {
                        if (!(oLogItem == null))
                        {
                            if (oLogItem.GetType() == typeof(LoggingChannelConfiguration))
                            {
                                ((LoggingChannelConfiguration)oLogItem).Comment = Comment;
                            }
                            else if (oLogItem.GetType() == typeof(LoggingChannelGroup))
                            {
                                ((LoggingChannelGroup)oLogItem).Comment = Comment;
                            }
                            else
                            {
                                //Not supposed to happen
                            }

                            bConfigModified = true;
                        }
                    }
                    break;

                default:

                    //Nothing to do
                    break;
            }

            return (true);
        }

        private void CollapseAllGridRows()
        {
            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;
            CGrid_Channels.CollapseAllRows();
            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
        }

        private void ExpandAllGridRows()
        {
            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;
            CGrid_Channels.ExpandAllRows();
            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
        }

        private bool Verify_ConfigurationModified()
        {
            if (bConfigModified)
            {
                DialogResult Rep = MessageBox.Show("The current logging channels configuration has been modified.\nDo you want save changes ?",
                                                    Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (Rep)
                {
                    case DialogResult.Yes:

                        Save_LoggingChannelConfig();
                        return (true);

                    case DialogResult.Cancel:

                        return (false);

                    default:

                        break;
                }

                return (true);
            }

            return (true);
        }

        private void Copy_LoggingItemProperties()
        {
            DataFormats.Format oFormat;
            IDataObject ClipDataObj;

            if (!(CGrid_Channels.Grid.SelectedCells == null))
            {
                int iSelectedRow = CGrid_Channels.Grid.SelectedCells[0].RowIndex;

                if (!(CGrid_Channels.Grid.Rows[iSelectedRow].Tag == null))
                {
                    object oSelectedObject = CGrid_Channels.Grid.Rows[iSelectedRow].Tag;

                    if(oSelectedObject.GetType()==typeof(LoggingChannelConfiguration))
                    {
                        oFormat = DataFormats.GetFormat(typeof(LoggingChannelConfiguration).FullName);
                        ClipDataObj = new DataObject();
                        ClipDataObj.SetData(oFormat.Name, false, oSelectedObject as LoggingChannelConfiguration);
                        Clipboard.SetDataObject(ClipDataObj, false);
                    }
                    else if (oSelectedObject.GetType() == typeof(LoggingChannelGroup))
                    {
                        oFormat = DataFormats.GetFormat(typeof(LoggingChannelGroup).FullName);
                        ClipDataObj = new DataObject();
                        ClipDataObj.SetData(oFormat.Name, false, oSelectedObject as LoggingChannelGroup);
                        Clipboard.SetDataObject(ClipDataObj, false);
                    }
                    else
                    {
                        Clipboard.Clear();
                    }
                }
            }
        }

        private void Paste_LoggingItemProperties()
        {
            if (!(CGrid_Channels.Grid.SelectedCells == null))
            {
                object oClipObject = null;
                IDataObject ClipDataObj = Clipboard.GetDataObject();

                string sChannelFormat = typeof(LoggingChannelConfiguration).FullName;
                string sGroupFormat = typeof(LoggingChannelGroup).FullName;

                if (ClipDataObj.GetDataPresent(sChannelFormat))
                {
                    oClipObject = ClipDataObj.GetData(sChannelFormat);

                    if (!(oClipObject == null))
                    {
                        Set_LoggingItemPropertiesFromClipboard(oClipObject);
                    }
                }
                else if (ClipDataObj.GetDataPresent(sGroupFormat))
                {
                    oClipObject = ClipDataObj.GetData(sGroupFormat);

                    if (!(oClipObject == null))
                    {
                        Set_LoggingItemPropertiesFromClipboard(oClipObject);
                    }
                }
                else
                {
                    MessageBox.Show("Clipboard does not contain any logging channel configuration object !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Set_LoggingItemPropertiesFromClipboard(object oClipboardObject)
        {
            ChannelLoggingMode eClipObjLoggingMode;
            double ClipObjLoggingFrequency;

            if (oClipboardObject.GetType() == typeof(LoggingChannelConfiguration))
            {
                eClipObjLoggingMode = ((LoggingChannelConfiguration)oClipboardObject).LoggingMode;
                ClipObjLoggingFrequency = ((LoggingChannelConfiguration)oClipboardObject).LoggingFrequency;
            }
            else if (oClipboardObject.GetType() == typeof(LoggingChannelGroup))
            {
                eClipObjLoggingMode = ((LoggingChannelGroup)oClipboardObject).GroupLoggingMode;
                ClipObjLoggingFrequency = ((LoggingChannelGroup)oClipboardObject).GroupLoggingFrequency;
            }
            else
            {
                return;
            }

            int iPrevRowId = -1;
            foreach (DataGridViewCell oCell in CGrid_Channels.Grid.SelectedCells)
            {
                if (oCell.RowIndex != iPrevRowId)
                {
                    iPrevRowId = oCell.RowIndex;

                    if (CGrid_Channels.Grid.Rows[oCell.RowIndex].Tag.GetType() == typeof(LoggingChannelConfiguration))
                    {
                        ((LoggingChannelConfiguration)CGrid_Channels.Grid.Rows[oCell.RowIndex].Tag).LoggingMode = eClipObjLoggingMode;
                        ((LoggingChannelConfiguration)CGrid_Channels.Grid.Rows[oCell.RowIndex].Tag).LoggingFrequency = ClipObjLoggingFrequency;
                    }
                    else if (CGrid_Channels.Grid.Rows[oCell.RowIndex].Tag.GetType() == typeof(LoggingChannelGroup))
                    {
                        ((LoggingChannelGroup)CGrid_Channels.Grid.Rows[oCell.RowIndex].Tag).GroupLoggingMode = eClipObjLoggingMode;
                        ((LoggingChannelGroup)CGrid_Channels.Grid.Rows[oCell.RowIndex].Tag).GroupLoggingFrequency = ClipObjLoggingFrequency;
                    }
                }
            }

            CGrid_Channels.SaveRowsCollapsingContext();
            Show_LoggingChannelConfig();
            CGrid_Channels.RestoreRowsCollapsingContext();
        }

        private void Delete_GridRow()
        {
            if (!(CGrid_Channels.Grid.SelectedCells == null))
            {
                int iPrevRow = -1;

                foreach (DataGridViewCell oCell in CGrid_Channels.Grid.SelectedCells)
                {
                    if (oCell.RowIndex != iPrevRow && oCell.RowIndex != -1)
                    {
                        iPrevRow = oCell.RowIndex;

                        object oRowTag = CGrid_Channels.Grid.Rows[oCell.RowIndex].Tag;

                        if (oRowTag.GetType() == typeof(LoggingChannelConfiguration))
                        {
                            oLoggingConfig.Delete_LoggingChannel(((LoggingChannelConfiguration)oRowTag).Path,
                                                                 ((LoggingChannelConfiguration)oRowTag).Name);
                        }
                        else if (oRowTag.GetType() == typeof(LoggingChannelGroup))
                        {
                            oLoggingConfig.Delete_LoggingChannelGroup(((LoggingChannelGroup)oRowTag).FullPath,
                                                                      ((LoggingChannelGroup)oRowTag).Name);
                        }

                        CGrid_Channels.Rows.Delete(oCell.RowIndex);
                    }
                }
            }
        }

        #endregion
    }
}
