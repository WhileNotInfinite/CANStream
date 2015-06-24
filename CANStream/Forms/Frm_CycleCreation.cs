using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;
using NumberBaseConversion;

namespace CANStream
{
    public partial class Frm_CycleCreation : Form
    {
        #region Private Members

        CANStreamCycle oCycle;

        CANMessagesConfiguration oCanConfig;
        CycleDataAssociation oAssociations;
        ImportDataFile oDataFile;
        CS_BuiltInSignalLibCollection oSignalLibCollection;

        #endregion

        public Frm_CycleCreation()
        {
            InitializeComponent();

            oCycle = null;
            oCanConfig = null;
            oAssociations = null;
            oDataFile = null;
            
            oSignalLibCollection = new CS_BuiltInSignalLibCollection();
            if (File.Exists(CANStreamTools.CsDataPath + "\\BuiltInSignals.xml"))
            {
            	oSignalLibCollection.LoadLibrariesList(CANStreamTools.CsDataPath + "\\BuiltInSignals.xml");
            }
        }

        #region Control events

        private void Frm_CycleCreation_Load(object sender, EventArgs e)
        {
            if (Directory.Exists(CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle Data Association"))
            {
                Cmb_Association.Items.Clear();

                DirectoryInfo AssociationDir = new DirectoryInfo(CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle Data Association");
                FileInfo[] AssociationFiles = AssociationDir.GetFiles("*.cda");

                if (AssociationFiles.Length > 0)
                {
                    for (int i = 0; i < AssociationFiles.Length; i++)
                    {
                        Cmb_Association.Items.Add(AssociationFiles[i].FullName);
                    }
                }
                
            }
        }

        private void Cmd_OpenDataFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = CANStreamConstants.DataFileFilter;
            openFileDialog1.FilterIndex=CANStreamConstants.DataFileFilterIndex;
            openFileDialog1.InitialDirectory = "";

            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                Txt_DataFile.Text = openFileDialog1.FileName;
            }
        }

        private void Cmd_OpenAssociation_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Cycle Data Association|*.cda";
			openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle Data Association";
            
            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                Cmb_Association.Items.Add(openFileDialog1.FileName);
                Cmb_Association.SelectedIndex = Cmb_Association.Items.Count - 1;
            }
        }

        private void Cmb_Association_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cmb_Association.SelectedIndex != -1)
            {
                oAssociations = new CycleDataAssociation();
                Txt_CanConfig.Text = "";
				                
                if (File.Exists(Cmb_Association.Text))
                {
                    if (oAssociations.ReadCycleDataAssociation(Cmb_Association.Text))
                    {
                        if (File.Exists(oAssociations.CANConfigFile))
                        {
                            oCanConfig = new CANMessagesConfiguration();
                            if (oCanConfig.ReadCANConfigurationFile(oAssociations.CANConfigFile))
                            {
                                Txt_CanConfig.Text = oAssociations.CANConfigFile;
                            }
                            else
                            {
                                Cmb_Association.SelectedIndex = -1;
                                MessageBox.Show("CAN Configuration file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            Cmb_Association.SelectedIndex = -1;
                            MessageBox.Show("The CAN configuration file attached to the Cycle/Data association no longer exists.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else
                    {
                        Cmb_Association.SelectedIndex = -1;
                        MessageBox.Show("Cycle/Data file reading error !\nCheck the file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    Cmb_Association.SelectedIndex = -1;
                    MessageBox.Show("The selected cycle/data association file no longer exists !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Cmd_SaveCycle_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.Filter = "CAN Strem cycle|*.csc";
            saveFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycles";

            if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                Txt_CycleFile.Text = saveFileDialog1.FileName;
            }
        }

        private void Cmd_CreateCycle_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
        	CreateCycle();
        	Cursor = Cursors.Default;
        	
        }

        #endregion

        #region Private Methodes

        private void CreateCycle()
        {
            #region Pre-checks

            if (!(Txt_DataFile.Text.Equals("")))
            {
                oDataFile = new ImportDataFile();
                if (!(oDataFile.ReadDataFile(Txt_DataFile.Text)))
                {
                    MessageBox.Show(CANStreamConstants.DataFileReadingErrorText, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No data file selected !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Cmb_Association.Text.Equals(""))
            {
                MessageBox.Show("No Cycle/Data association file selected !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Txt_CanConfig.Text.Equals(""))
            {
                MessageBox.Show("The CAN configuation file is missing !\nPlease select a new Cycle/Data association file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            if (Txt_CycleFile.Text.Equals(""))
            {
                MessageBox.Show("Cycle destination file not defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            #endregion

            oCycle = new CANStreamCycle();

            ProgressBar.Value = 0;
            ProgressBar.Visible = true;

            for (long iTime = (long)(oDataFile.Time[0] * 1000); iTime < (long)(oDataFile.Time[oDataFile.Time.Count - 1] * 1000); iTime++)
            {
                List<string> TimeEventMessageIds = GetMessagesForTimeEvent(iTime);

                if (TimeEventMessageIds.Count > 0)
                {
                    CycleTimeEvent oTimeEvent = new CycleTimeEvent();
                    oTimeEvent.TimeEvent = iTime;

                    foreach (string sMsgId in TimeEventMessageIds)
                    {
                        CANMessageData oMessageData = new CANMessageData();
                        oMessageData = BuildCANMessageData(sMsgId, iTime);

                        if (!(oMessageData == null))
                        {
                            oTimeEvent.MessagesData.Add(oMessageData);
                        }
                        else
                        {
                        	ProgressBar.Visible = false;
                        	return;
                        }
                    }

                    if (oTimeEvent.MessagesData.Count > 0)
                    {
                        oCycle.TimeEvents.Add(oTimeEvent);
                    }
                }

                int Progress = (int)(iTime * 100 / oDataFile.Time.Count);

                if (Progress <= 100)
                {
                    ProgressBar.Value = Progress;
                }
            }

            //oCycle.CANConfigurationFilePath=Txt_CanConfig.Text;
            oCycle.oCanNodesMap = oCanConfig;
            oCycle.Comment=rTxt_Comments.Text;
            
            oCycle.WriteStreamCycle(Txt_CycleFile.Text);

            MessageBox.Show("Cycle created !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            ProgressBar.Visible = false;
        }

        private List<string> GetMessagesForTimeEvent(long TimeValue)
        {
            List<string> IdList = new List<string>();

            foreach (CANMessage oMessage in oCanConfig.Messages)
            {
            	if (oMessage.RxTx.Equals(CanMsgRxTx.Tx) && (!oMessage.ContainsVirtualParameters()))
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

        private CANMessageData BuildCANMessageData(string MsgIdentifier, long TimeValue)
        {
        	CANMessage oMsgDef = oCanConfig.GetCANMessage(MsgIdentifier, MessageResearchOption.Identifier);
        	
        	//Get engeneering value for each parameter of the message
        	foreach (CANParameter oParamDef in oMsgDef.Parameters)
        	{
        		DataAssociation oParamAssociation = oAssociations.GetAssociation(MsgIdentifier, oParamDef.Name);
        		
        		double DataValue = 0;
        		
        		//Retrieve formated value
        		if (!(oParamAssociation == null))
        		{
        			switch (oParamAssociation.AssociationType)
	        		{
	        			case CS_DataAssociationType.AcqData:
	        				
	        				if (!(oDataFile.GetValueAtTime(oParamAssociation.DataColumnTitle, TimeValue, out DataValue)))
	                    	{
	                        	return (null);
	                    	}
	        				break;
	        				
	        			case CS_DataAssociationType.BuiltSignal:
	        				
	        				DataValue = oSignalLibCollection.GetSignalValueAtTime(oParamAssociation.SignalLibrary,oParamAssociation.SignalName,TimeValue);
	        				break;
	        				
	        			case CS_DataAssociationType.FixedValue:
	        				
	        				DataValue = oParamAssociation.DefaultValue;
	        				break;
	        				
	        			default:
	        				
	        				DataValue = 0;
	        				break;
	        		}
        		}
        		else
        		{
        			if (TimeValue == 0)
        			{
        				DialogResult Rep = MessageBox.Show("No association found for CAN parameter " + oParamDef.Name 
        				                                   + " of message ID " + MsgIdentifier
        				                                   + "\nDo you want to continue cycle creation anyway ?",
        				                                   Application.ProductName,MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
        				
        				if (Rep.Equals(DialogResult.No))
        				{
        					MessageBox.Show("Cycle creation abort !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
        					return(null);
        				}
        			}
        		}
                
                oParamDef.DecodedValue=DataValue;
        	}
        	
        	//Encode the message
        	CANMessageEncoded oMsgEncoded=new CANMessageEncoded(oMsgDef,oCanConfig.MessageLength/8);
        	oMsgEncoded.EncodeMessage();
        	
        	return(oMsgEncoded.GetCANMessageData());
        }

        #endregion
    }
}
