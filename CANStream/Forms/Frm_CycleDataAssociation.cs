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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CANStream
{
    public partial class Frm_CycleDataAssociation : Form
    {
        #region Private members

        private CycleDataAssociation oAssociations;

        private CANMessagesConfiguration oCanConfig;
        private ImportDataFile oDataFile;
		
        private CS_BuiltInSignalLibCollection oSigLibCollection;
        
        private bool GridEdition;
        private bool ConfigModified;
        
        #endregion

        public Frm_CycleDataAssociation()
        {
            InitializeComponent();

            oAssociations = new CycleDataAssociation();
            oCanConfig = null;
            oDataFile = null;
			
            oSigLibCollection = new CS_BuiltInSignalLibCollection();
            
            string SigLibCollectionFile = CANStreamTools.CsDataPath + "\\BuiltInSignals.xml";
            if (File.Exists(SigLibCollectionFile))
            {
            	oSigLibCollection.LoadLibrariesList(SigLibCollectionFile);
            }
            
            GridEdition = false;
            ConfigModified = false;
        }

        #region Control events

        #region ToolBar

        private void TSB_New_Click(object sender, EventArgs e)
        {
            NewAssociationConfiguration();
        }

        private void TSB_Open_Click(object sender, EventArgs e)
        {
            OpenAssociationConfiguration();
        }

        private void TSB_Save_Click(object sender, EventArgs e)
        {
            SaveAssociationConfiguration();
        }

        #endregion

        #region DataGridView

        private void Grid_Association_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (!(GridEdition))
            {
                ConfigModified = true;
            }
        }

        #endregion

        #region Misc
        
        private void Cmd_CANConfig_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CAN Configuration|*.xcc";
            openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";

            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                oCanConfig = new CANMessagesConfiguration();

                if (oCanConfig.ReadCANConfigurationFile(openFileDialog1.FileName))
                {
                    GridEdition = true;

                    int RowsCount = oCanConfig.GetTxParameterCount(false);

                    if (RowsCount > 0)
                    {
                        Grid_Association.Enabled = true;
                        Grid_Association.Rows.Clear();
                        Grid_Association.Rows.Add(RowsCount);
                        int iRow = 0;
                        
                        string[] sAssoTypes = Enum.GetNames(typeof(CS_DataAssociationType));

                        foreach (CANMessage oMessage in oCanConfig.Messages)
                        {
                        	if (oMessage.RxTx.Equals(CanMsgRxTx.Tx) && (!oMessage.ContainsVirtualParameters()))
                            {
                                foreach (CANParameter oParam in oMessage.Parameters)
                                {
                                    Grid_Association.Rows[iRow].HeaderCell.Value = oMessage.Identifier;
                                    Grid_Association.Rows[iRow].Cells[0].Value = oParam.Name;
                                    
                                    //Association types list creation
                                    DataGridViewComboBoxCell AssoCell = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[1];
                                    AssoCell.Items.Clear();
                                    
                                    foreach (string sAsso in sAssoTypes)
                                    {
                                    	AssoCell.Items.Add(sAsso);
                                    }
                                    
                                    //Built-in Signals list creation
                                    DataGridViewComboBoxCell SignalCell = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[3];
                                    SignalCell.Items.Clear();
                                    
                                    foreach(CS_BuiltInSignalLibrary oSigLib in oSigLibCollection.Libraries)
                                    {
                                    	foreach(CS_BuiltInSignal oSignal in oSigLib.Signals)
                                    	{
                                    		SignalCell.Items.Add(oSigLib.Name + ":" + oSignal.Name);
                                    	}
                                    }
                                    
                                    iRow++;
                                }
                            }
                        }

                        Txt_CANConfig.Text = openFileDialog1.FileName;
                        Lbl_DataFile.Enabled = true;
                        Txt_DataFile.Enabled = true;
                        Cmd_DataFile.Enabled = true;
                    }
                    else
                    {
                        MessageBox.Show("The CAN configuration selected contains only Rx messages !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    GridEdition = false;
                }
                else
                {
                    MessageBox.Show("CAN configuration file loading error !\nCheck the file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Cmd_DataFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = CANStreamConstants.DataFileFilter;
            openFileDialog1.FilterIndex=CANStreamConstants.DataFileFilterIndex;
            openFileDialog1.InitialDirectory = "";

            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
                oDataFile = new ImportDataFile();
                Cursor = Cursors.WaitCursor;
                
                if (oDataFile.ReadDataFile(openFileDialog1.FileName,true))
                {
                	Cursor = Cursors.Default;
                	GridEdition = true;
                    
                    for (int i = 0; i < Grid_Association.Rows.Count; i++)
                    {
                        DataGridViewComboBoxCell CmbCell = (DataGridViewComboBoxCell)Grid_Association.Rows[i].Cells[2];

                        CmbCell.Items.Clear();
                        foreach (ImportDataChannel oChan in oDataFile.Channels)
                        {
                            CmbCell.Items.Add(oChan.ChannelName);
                        }
                    }

                    GridEdition = false;

                    Txt_DataFile.Text = openFileDialog1.FileName;
                }
                else
                {
                    Cursor = Cursors.Default;
                	MessageBox.Show(CANStreamConstants.DataFileReadingErrorText, Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #endregion

        #region Private methodes

        private bool CheckAssociationConfiguration()
        {
            for (int iRow = 0; iRow < Grid_Association.Rows.Count; iRow++)
            {
                DataGridViewTextBoxCell  CanParam         = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[0];
                DataGridViewComboBoxCell TypeAssociation  = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[1];
                DataGridViewComboBoxCell ChannelCell      = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[2];
                DataGridViewComboBoxCell SignalCell       = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[3];
                DataGridViewTextBoxCell  DefaultValCell   = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[4];
            	
                CS_DataAssociationType eAsso = (CS_DataAssociationType)Enum.Parse(typeof(CS_DataAssociationType),TypeAssociation.EditedFormattedValue.ToString());
                
                switch (eAsso)
                {
                	case CS_DataAssociationType.AcqData:
                		
                		if (ChannelCell.EditedFormattedValue.Equals(""))
                		{
                			MessageBox.Show("No data channel selected for CAN Parameter " + CanParam.Value.ToString() + "."
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                       		return (false);
                		}
                		
                		break;
                		
                	case CS_DataAssociationType.BuiltSignal:
                		
                		if (SignalCell.EditedFormattedValue.Equals(""))
                		{
                			MessageBox.Show("No built-in signal selected for CAN Parameter " + CanParam.Value.ToString() + "."
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                       		return (false);
                		}
                		
                		break;
                		
                	case CS_DataAssociationType.FixedValue:
                		
                		if (DefaultValCell.EditedFormattedValue.Equals(""))
                		{
                			MessageBox.Show("No default value defined for CAN Parameter " + CanParam.Value.ToString() + "."
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                       		return (false);
                		}
                		else
                		{
                			double ValTest = 0;
                			if (!double.TryParse(DefaultValCell.EditedFormattedValue.ToString(),out ValTest))
                			{
                				MessageBox.Show("Default value for CAN Parameter " + CanParam.Value.ToString() + " must be a numeric value"
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                				
                				return (false);
                			}
                		}
                		
                		break;
                		
                	default:
                		
                		if (!(ChannelCell.EditedFormattedValue.Equals("") & SignalCell.EditedFormattedValue.Equals("") & DefaultValCell.EditedFormattedValue.Equals("")))
                		{
                			MessageBox.Show("No association type selected for " + CanParam.Value.ToString() + "."
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                			
                			return (false);
                		}
                		
                		break;
                }
                	    
            	#region Old version
            	/*
            	DataGridViewTextBoxCell CanParam = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[0];
                DataGridViewComboBoxCell ChannelCell = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[1];
                DataGridViewCheckBoxCell UseDefaultCell = (DataGridViewCheckBoxCell)Grid_Association.Rows[iRow].Cells[2];
                DataGridViewTextBoxCell DefaultValCell = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[3];

                if (ChannelCell.EditedFormattedValue.Equals("")) //No Data channel selected
                {
                    if (UseDefaultCell.EditedFormattedValue.Equals(false)) //Flag use default not checked
                    {
                        MessageBox.Show("No source selected for CAN Parameter " + CanParam.Value.ToString() + " (Data channel or default value)"
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return (false);
                    }

                    if (DefaultValCell.FormattedValue.Equals("")) //Default value not defined
                    {
                        MessageBox.Show("No default value defined for CAN Parameter " + CanParam.Value.ToString()
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return (false);
                    }

                    double DefVal = 0;
                    if (double.TryParse(DefaultValCell.Value.ToString(), out DefVal) == false)
                    {
                        MessageBox.Show("Default value for CAN Parameter " + CanParam.Value.ToString() + " is not a number"
                                        , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                        return (false);
                    }
                }
                else
                {
                    if (!(DefaultValCell.FormattedValue.Equals("")))
                    {
                        double DefVal = 0;
                        if (double.TryParse(DefaultValCell.FormattedValue.ToString(), out DefVal) == false)
                        {
                            MessageBox.Show("Default value for CAN Parameter " + CanParam.Value.ToString() + " is not a number"
                                            , Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);

                            return (false);
                        }
                    }
                }
                */
               #endregion
            }

            return (true);
        }

        private void NewAssociationConfiguration()
        {
            if (ConfigModified)
            {
                DialogResult Rep = MessageBox.Show("The association configuration has been modified. Do you want save it ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Rep.Equals(DialogResult.Yes))
                {
                    SaveAssociationConfiguration();
                }
            }

            oCanConfig = null;
            Txt_CANConfig.Text = "";

            oDataFile = null;
            Txt_DataFile.Text = "";

            Lbl_DataFile.Enabled = false;
            Txt_DataFile.Enabled = false;
            Cmd_DataFile.Enabled = false;

            oAssociations = new CycleDataAssociation();
            Grid_Association.Rows.Clear();

            ConfigModified = false;
        }

        private void OpenAssociationConfiguration()
        {
            if (ConfigModified)
            {
                DialogResult Rep = MessageBox.Show("The association configuration has been modified. Do you want save it ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Rep.Equals(DialogResult.Yes))
                {
                    SaveAssociationConfiguration();
                }
            }

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Cycle Data Association|*.cda";
			openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle Data Association";
            
            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
            	LoadAssociationFile(openFileDialog1.FileName);
            }
        }

        private void SaveAssociationConfiguration()
        {
            if (Grid_Association.Rows.Count == 0)
            {
                return;
            }

            if (CheckAssociationConfiguration())
            {
                saveFileDialog1.FileName = "";
                saveFileDialog1.Filter = "Cycle Data Association|*.cda";
                saveFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycle Data Association";

                if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
                {
                    oAssociations = new CycleDataAssociation();
                    oAssociations.CANConfigFile = Txt_CANConfig.Text;
                    oAssociations.DataFileTemplate = Txt_DataFile.Text;

                    for (int iRow = 0; iRow < Grid_Association.Rows.Count; iRow++)
                    {
                        DataAssociation oAsso = new DataAssociation();
                        
                        DataGridViewTextBoxCell  CanParam         = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[0];
		                DataGridViewComboBoxCell TypeAssociation  = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[1];
		                DataGridViewComboBoxCell ChannelCell      = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[2];
		                DataGridViewComboBoxCell SignalCell       = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[3];
		                DataGridViewTextBoxCell  DefaultValCell   = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[4];
		            	
		                oAsso.CANParameterName = CanParam.Value.ToString();
                        oAsso.CANParameterMessageIdentifier = Grid_Association.Rows[iRow].HeaderCell.Value.ToString();
                        oAsso.AssociationType = (CS_DataAssociationType)Enum.Parse(typeof(CS_DataAssociationType),TypeAssociation.EditedFormattedValue.ToString());
		                
		                switch (oAsso.AssociationType)
		                {
		                	case CS_DataAssociationType.AcqData:
		                		
		                		oAsso.DataColumnTitle = ChannelCell.EditedFormattedValue.ToString();
		                		oAsso.SignalName = "";
		                		oAsso.SignalLibrary = "";
		                		oAsso.DefaultValue = 0;
		                		break;
		                		
		                	case CS_DataAssociationType.BuiltSignal:
		                		
		                		string[] SignalProps= SignalCell.EditedFormattedValue.ToString().Split(':');
		                		
		                		oAsso.DataColumnTitle = "";
		                		oAsso.SignalName = SignalProps[1];
		                		oAsso.SignalLibrary = SignalProps[0];
		                		oAsso.DefaultValue = Convert.ToDouble(DefaultValCell.Value);;
		                		break;
		                		
		                	case CS_DataAssociationType.FixedValue:
		                		
		                		oAsso.DataColumnTitle = "";
		                		oAsso.SignalName = "";
		                		oAsso.SignalLibrary = "";
		                		oAsso.DefaultValue = Convert.ToDouble(DefaultValCell.Value);
		                		break;
		                		
		                	default:
		                		
		                		oAsso.DataColumnTitle = "";
		                		oAsso.SignalName = "";
		                		oAsso.SignalLibrary = "";
		                		oAsso.DefaultValue = 0;
		                		break;
		                			
		                }
		                
                    	#region Old version
                    	/*
                        DataGridViewTextBoxCell CanParam = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[0];
                        DataGridViewComboBoxCell ChannelCell = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[1];
                        DataGridViewCheckBoxCell UseDefaultCell = (DataGridViewCheckBoxCell)Grid_Association.Rows[iRow].Cells[2];
                        DataGridViewTextBoxCell DefaultValCell = (DataGridViewTextBoxCell)Grid_Association.Rows[iRow].Cells[3];

                        oAsso.CANParameterName = CanParam.Value.ToString();
                        oAsso.CANParameterMessageIdentifier = Grid_Association.Rows[iRow].HeaderCell.Value.ToString();
                        oAsso.DataColumnTitle = ChannelCell.EditedFormattedValue.ToString();
                        oAsso.UseDefaultValue = (bool)UseDefaultCell.EditedFormattedValue;

                        if (!(DefaultValCell.Value == null))
                        {
                            oAsso.DefaultValue = Convert.ToDouble(DefaultValCell.Value);
                        }
                        else
                        {
                            oAsso.DefaultValue = 0;
                        }
                        */
                        #endregion

                        oAssociations.Associations.Add(oAsso);
                    }

                    oAssociations.WriteCycleDataAssociation(saveFileDialog1.FileName);
                    ConfigModified = false;
                    
                    MessageBox.Show("Association saved !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }
        }

        private void ShowAssociationConfiguration()
        {
            FileInfo oFile = null;
            //bool bCanCfgOK = false;
            bool bDataFileOK = false;

            oFile = new FileInfo(oAssociations.CANConfigFile);
            Txt_CANConfig.Text = oFile.FullName;

            if (oFile.Exists)
            {
                oCanConfig = new CANMessagesConfiguration();
                if (!(oCanConfig.ReadCANConfigurationFile(oAssociations.CANConfigFile)))
                {
                    MessageBox.Show("CAN Configuration file reading error !\nLoad a new file in order to modify the association configuration", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //bCanCfgOK = true;
            }
            else
            {
                MessageBox.Show("CAN Configuration file " + oFile.Name + " no longer exists.\nLoad a new file in order to modify the association configuration.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            Lbl_DataFile.Enabled = true;
            Txt_DataFile.Enabled = true;
            Cmd_DataFile.Enabled = true;

            oFile = new FileInfo(oAssociations.DataFileTemplate);
            Txt_DataFile.Text = oFile.FullName;

            if (oFile.Exists)
            {
                oDataFile = new ImportDataFile();
                if (!(oDataFile.ReadDataFile(oAssociations.DataFileTemplate,true)))
                {
                    MessageBox.Show("Data file template reading error !\nLoad a new file in order to modify the association configuration", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                bDataFileOK = true;
            }
            else
            {
                MessageBox.Show("Data file template " + oFile.Name + " no longer exists.\nLoad a new file in order to modify the association configuration.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            GridEdition = true;

            Grid_Association.Rows.Clear();
            Grid_Association.Rows.Add(oAssociations.Associations.Count);

            for (int iRow = 0; iRow < Grid_Association.Rows.Count; iRow++)
            {
                Grid_Association.Rows[iRow].HeaderCell.Value = oAssociations.Associations[iRow].CANParameterMessageIdentifier;
                Grid_Association.Rows[iRow].Cells[0].Value = oAssociations.Associations[iRow].CANParameterName;
                
                //Association types list
                DataGridViewComboBoxCell CmbCellTypeAsso = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[1];
                CmbCellTypeAsso.Items.Clear();
                
                string[] AssoTypes = CS_DataAssociationType.GetNames(typeof(CS_DataAssociationType));
                for (int i=0; i<AssoTypes.Length;i++)
                {
                	CmbCellTypeAsso.Items.Add(AssoTypes[i]);
                }
                
                CmbCellTypeAsso.Value = oAssociations.Associations[iRow].AssociationType.ToString();
                
                //Data channels list
                DataGridViewComboBoxCell CmbCellChannel = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[2];
                CmbCellChannel.Items.Clear();
                
                if (bDataFileOK)
                {
                    for (int i = 0; i < oDataFile.Channels.Count; i++)
                    {
                        CmbCellChannel.Items.Add(oDataFile.Channels[i].ChannelName);
                    }   
                }
                else
                {
                    CmbCellChannel.Items.Add(oAssociations.Associations[iRow].DataColumnTitle);
                }
                
                //Built-in signals list
                DataGridViewComboBoxCell CmbCellSignal = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[3];
                CmbCellSignal.Items.Clear();
                
                foreach (CS_BuiltInSignalLibrary oSigLib in oSigLibCollection.Libraries)
                {
                	foreach (CS_BuiltInSignal oSignal in oSigLib.Signals)
                	{
                		CmbCellSignal.Items.Add(oSigLib.Name + ":" + oSignal.Name);
                	}
                }
                
                switch (oAssociations.Associations[iRow].AssociationType)
                {
                	case CS_DataAssociationType.AcqData:
                		
                		CmbCellChannel.Value = oAssociations.Associations[iRow].DataColumnTitle;
                		break;
                		
                	case CS_DataAssociationType.BuiltSignal:
                		
                		if (oSigLibCollection.SignalExistsInLibrary(oAssociations.Associations[iRow].SignalLibrary,
                	                                            oAssociations.Associations[iRow].SignalName))
		                {
		                	CmbCellSignal.Value = oAssociations.Associations[iRow].SignalLibrary 
		                							+ ":" + oAssociations.Associations[iRow].SignalName;
		                }
		                else
		                {
		                	MessageBox.Show("Built-in signal " + oAssociations.Associations[iRow].SignalName
		                	                + " or signal library " + oAssociations.Associations[iRow].SignalLibrary
		                	                + " doesn't exist anymore !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
		                }
		                
                		break;
                		
                	case CS_DataAssociationType.FixedValue:
                		
                		Grid_Association.Rows[iRow].Cells[4].Value = oAssociations.Associations[iRow].DefaultValue.ToString();
                		break;
                		
                	default:
                		break;
                }
                
            	#region Old version
            	/*
            	Grid_Association.Rows[iRow].HeaderCell.Value = oAssociations.Associations[iRow].CANParameterMessageIdentifier;
                Grid_Association.Rows[iRow].Cells[0].Value = oAssociations.Associations[iRow].CANParameterName;
                Grid_Association.Rows[iRow].Cells[2].Value = oAssociations.Associations[iRow].UseDefaultValue;
                Grid_Association.Rows[iRow].Cells[3].Value = oAssociations.Associations[iRow].DefaultValue.ToString();
                
                DataGridViewComboBoxCell CmbCell = (DataGridViewComboBoxCell)Grid_Association.Rows[iRow].Cells[1];
                CmbCell.Items.Clear();

                if (bDataFileOK)
                {
                    for (int i = 0; i < oDataFile.Channels.Count; i++)
                    {
                        CmbCell.Items.Add(oDataFile.Channels[i].ChannelName);
                    }   
                }
                else
                {
                    CmbCell.Items.Add(oAssociations.Associations[iRow].DataColumnTitle);
                }

                Grid_Association.Rows[iRow].Cells[1].Value = oAssociations.Associations[iRow].DataColumnTitle;
                */
                #endregion
            }

            Grid_Association.Enabled = true;

            GridEdition = false;
        }

        #endregion
        
        #region Public methods
        
        public void LoadAssociationFile(string FilePath)
        {
        	if(!(FilePath.Equals("")))
        	{
        		if(File.Exists(FilePath))
        		{
	        		oAssociations = new CycleDataAssociation();
		
		            if (oAssociations.ReadCycleDataAssociation(FilePath))
		            {
		                ShowAssociationConfiguration();
		            }
		            else
		            {
		                MessageBox.Show("Association configuration file reading error !\nCheck the file", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
		            }
		
		            ConfigModified = false;
        		}
        		else
        		{
        			MessageBox.Show("Association file no longer exists !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        		}
        	}
        }
        
        #endregion
    }
}
