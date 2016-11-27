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

            CGrid_Channels.Columns[GRID_COL_NAME].Width = 150;
            CGrid_Channels.Columns[GRID_COL_LOG_MODE].Width = 150;
            CGrid_Channels.Columns[GRID_COL_LOG_FREQ].Width = 150;
            CGrid_Channels.Columns[GRID_COL_COMMENT].Width = CGrid_Channels.Width - 500;

            CGrid_Channels.Columns[GRID_COL_LOG_MODE].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CGrid_Channels.Columns[GRID_COL_LOG_FREQ].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CGrid_Channels.Columns[GRID_COL_LOG_MODE].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CGrid_Channels.Columns[GRID_COL_LOG_FREQ].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
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

        }

        private void TSB_Paste_Click(object sender, EventArgs e)
        {

        }

        private void TSB_Delete_Click(object sender, EventArgs e)
        {

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

        #endregion

        #region CGrid_Channels

        private void Grid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > 0)
            {
                LoggingChannelConfiguration oLogChanCfg = (LoggingChannelConfiguration)CGrid_Channels.Grid.Rows[e.RowIndex].Tag;

                switch (e.ColumnIndex)
                {
                    case GRID_COL_LOG_MODE:
                        {
                            if (!(oLogChanCfg == null))
                            {
                                CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;

                                ChannelLoggingMode eLogMode = (ChannelLoggingMode)(Enum.Parse(typeof(ChannelLoggingMode),
                                    CGrid_Channels.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString()));

                                switch (eLogMode)
                                {
                                    case ChannelLoggingMode.CustomFrequency:

                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_FREQ].Value = oLogChanCfg.LoggingFrequency.ToString();
                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_FREQ].ReadOnly = false;
                                        break;

                                    case ChannelLoggingMode.NotLogged:

                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_FREQ].Value = "0";
                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_FREQ].ReadOnly = true;
                                        break;

                                    default: //ChannelLoggingMode.DefaultFrequency:

                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_FREQ].Value = oLogChanCfg.DefaultFrequency.ToString();
                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[GRID_COL_LOG_FREQ].ReadOnly = true;
                                        break;
                                }

                                oLogChanCfg.LoggingMode = eLogMode;
                                bConfigModified = true;

                                CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
                            }
                        }
                        break;

                    case GRID_COL_LOG_FREQ:
                        {
                            if (!(oLogChanCfg == null))
                            {
                                CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;

                                double FreqSet = 0;

                                string sFreqSet = CGrid_Channels.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                                if (double.TryParse(sFreqSet, out FreqSet))
                                {
                                    if (FreqSet >= 0 && FreqSet <= 1000)
                                    {
                                        oLogChanCfg.LoggingFrequency = Math.Round(FreqSet, 0);
                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oLogChanCfg.LoggingFrequency.ToString();
                                        bConfigModified = true;

                                        if (oLogChanCfg.LoggingFrequency!= FreqSet)
                                        {
                                            MessageBox.Show("Logging frequency has been rounded to " + oLogChanCfg.LoggingFrequency.ToString(), 
                                                            Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Logging frequency must be contained between 0 Hz and 1000 Hz !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        CGrid_Channels.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oLogChanCfg.LoggingFrequency.ToString();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Logging frequency value should be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    CGrid_Channels.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = oLogChanCfg.LoggingFrequency.ToString();
                                }

                                CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
                            }
                        }
                        break;

                    case GRID_COL_COMMENT:

                        {
                            if (!(oLogChanCfg == null))
                            {
                                oLogChanCfg.Comment = CGrid_Channels.Grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                                bConfigModified = true;
                            }
                        }
                        break;

                    default:

                        //Nothing to do
                        break;
                }
            }
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

        private void Show_LoggingChannelConfig()
        {
            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;

            //CGrid_Channels.Rows.Clear();

            foreach (LoggingChannelGroup oChanGrp in oLoggingConfig.Groups)
            {
                CollapsableGridRow oGroupRow = CGrid_Channels.Rows.Add();
                oGroupRow.ThisRow.Cells[GRID_COL_NAME].Value = oChanGrp.Name;
                oGroupRow.ThisRow.Cells[GRID_COL_COMMENT].Value = oChanGrp.Comment;
                oGroupRow.ThisRow.ReadOnly = true;

                Color_GridRow(oGroupRow.ThisRow, Color.MidnightBlue, Color.White);

                //Channels of the group
                int iChan = 0;
                foreach (LoggingChannelConfiguration oChan in oChanGrp.LoggingChannels)
                {
                    CollapsableGridRow oChanRow = oGroupRow.Children.Add();
                    Set_LoggingModeCells(oChanRow.ThisRow);

                    oChanRow.ThisRow.Tag = oChan;

                    oChanRow.ThisRow.Cells[GRID_COL_NAME].Value = oChan.Name;
                    oChanRow.ThisRow.Cells[GRID_COL_NAME].ReadOnly = true;

                    oChanRow.ThisRow.Cells[GRID_COL_LOG_MODE].Value = oChan.LoggingMode.ToString();
                    oChanRow.ThisRow.Cells[GRID_COL_LOG_MODE].ReadOnly = false;

                    oChanRow.ThisRow.Cells[GRID_COL_LOG_FREQ].Value = oChan.LoggingFrequency.ToString();
                    oChanRow.ThisRow.Cells[GRID_COL_LOG_FREQ].ReadOnly = !(oChan.LoggingMode == ChannelLoggingMode.CustomFrequency);

                    oChanRow.ThisRow.Cells[GRID_COL_COMMENT].Value = oChan.Comment;
                    oChanRow.ThisRow.Cells[GRID_COL_NAME].ReadOnly = false;

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
                    oSubGroupRow.ThisRow.Cells[GRID_COL_NAME].Value = oSubGroup.Name;
                    oSubGroupRow.ThisRow.ReadOnly = true;

                    Color_GridRow(oSubGroupRow.ThisRow, Color.LightSkyBlue, Color.Black);

                    int iSubChan = 0;
                    foreach (LoggingChannelConfiguration oSubGroupChan in oSubGroup.LoggingChannels)
                    {
                        CollapsableGridRow oSubChanRow = oSubGroupRow.Children.Add();
                        Set_LoggingModeCells(oSubChanRow.ThisRow);

                        oSubChanRow.ThisRow.Cells[GRID_COL_NAME].Value = oSubGroupChan.Name;
                        oSubChanRow.ThisRow.Cells[GRID_COL_NAME].ReadOnly = true;

                        oSubChanRow.ThisRow.Cells[GRID_COL_LOG_MODE].Value = oSubGroupChan.LoggingMode.ToString();
                        oSubChanRow.ThisRow.Cells[GRID_COL_LOG_MODE].ReadOnly = false;

                        oSubChanRow.ThisRow.Cells[GRID_COL_LOG_FREQ].Value = oSubGroupChan.LoggingFrequency.ToString();
                        oSubChanRow.ThisRow.Cells[GRID_COL_LOG_FREQ].ReadOnly = !(oSubGroupChan.LoggingMode == ChannelLoggingMode.CustomFrequency);

                        oSubChanRow.ThisRow.Cells[GRID_COL_COMMENT].Value = oSubGroupChan.Comment;
                        oSubChanRow.ThisRow.Cells[GRID_COL_NAME].ReadOnly = false;

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

        private void Clear_LoggingChannelConfig()
        {
            CGrid_Channels.Grid.CellValueChanged -= Grid_CellValueChanged;
            CGrid_Channels.Rows.Clear();
            CGrid_Channels.Grid.CellValueChanged += Grid_CellValueChanged;
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
                                oChanCfg.DefaultFrequency = 1 / ((double)oMsg.Period / 1000);
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

        #endregion
    }
}
