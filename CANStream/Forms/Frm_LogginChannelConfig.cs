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
        #region Private members

        private CS_RecordLoggingConfiguration oLoggingConfig;

        private bool bConfigModified;

        #endregion

        public Frm_LogginChannelConfig(string LoggingChannelConfigFile)
        {
            InitializeComponent();

            oLoggingConfig = new CS_RecordLoggingConfiguration();

            bConfigModified = false;
        }

        #region Control events

        #region TS_Main

        private void TSB_New_Click(object sender, EventArgs e)
        {

        }

        private void TSB_Open_Click(object sender, EventArgs e)
        {

        }

        private void TSB_Save_Click(object sender, EventArgs e)
        {

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

        #endregion

        #region Private methodes

        private void Save_LoggingChannelConfig()
        {

        }

        private void Show_LoggingChannelConfig()
        {
            CGrid_Channels.Rows.Clear();

            foreach (LoggingChannelGroup oChanGrp in oLoggingConfig.Groups)
            {
                CollapsableGridRow oGroupRow = CGrid_Channels.Rows.Add();
                oGroupRow.ThisRow.Cells[1].Value = oChanGrp.Name;

                foreach(LoggingChannelConfiguration oChan in oChanGrp.LoggingChannels)
                {
                    CollapsableGridRow oChanRow = oGroupRow.Children.Add();
                    //oChanRow.Cells[1].Value = oChan.Name;
                }
            }
        }

        private void Import_CanConfig()
        {
            if (bConfigModified)
            {
                DialogResult Rep = MessageBox.Show("The current logging channels configuration has been modified.\nDo you want save changes ?",
                                                    Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch(Rep)
                {
                    case DialogResult.Yes:

                        Save_LoggingChannelConfig();
                        break;

                    case DialogResult.Cancel:

                        return;

                    default:

                        break;
                }

            }

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
                        foreach (CANParameter oParam in oMsg.Parameters)
                        {
                            LoggingChannelConfiguration oChanCfg = new LoggingChannelConfiguration();

                            oChanCfg.Name = oParam.Name;
                            oChanCfg.LoggingMode = ChannelLoggingMode.DefaultFrequency;

                            if (oMsg.Period != 0)
                            {
                                oChanCfg.LoggingFrequency = 1 / ((double)oMsg.Period / 1000);
                            }
                            else
                            {
                                oChanCfg.LoggingFrequency = 1;
                            }

                            if(oParam.IsMultiplexed)
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

        #endregion
    }
}
