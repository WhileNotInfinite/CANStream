using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using NumberBaseConversion;

namespace CANStream
{
    public partial class Frm_CANConfiguration : Form
    {
    	#region Private structures
        
    	private struct GridCellCoords
        {
        	public int Row;
        	public int Column;
        }
    	
    	#endregion
    	
    	#region Private Enum
        
        private enum ConfigurationItemType
        {
        	Controller = 0,
        	Message    = 1,
        	Parameter  = 2,
        }
        
        #endregion
        
        #region Protected classes
        
        [Serializable]
        protected class CANConfigClipboardObject
        {
        	#region Public members
        	
        	public object ClipboardObject;
        	
        	public bool ClipBoardCutOption;
        	public int ClipboardObjectCANCfgSrcIndex;
        	public string ParamClipBoardParentMessageName;
        	public int ClipboardObjectSourceFormIndex;
        	
        	#endregion
        	
        	public CANConfigClipboardObject()
        	{
        		ClipboardObject = null;
        		
        		ClipBoardCutOption = false;
        		ClipboardObjectCANCfgSrcIndex = -1;
        		ParamClipBoardParentMessageName =  "";
        		ClipboardObjectSourceFormIndex = -1;
        	}
        }
        
        #endregion
    	
    	#region Private members

        private CANMessagesConfiguration oCANConfig;
        private MultipleContollerCANConfiguration oMultipleControllersCfg;
        
        private TreeNode nController;
        private TreeNode nMessage;
        
		private CANMessage oActiveMessage;        
        private CANParameter oActiveParameter;

        private bool bParameterEdition;
        private bool ConfigurationModified;

        private bool ReloadMainFormCanCfg;
        private int CanControllerId;
        private MainForm FrmParent;
        
        private int CellColorId;
        
        #endregion
        
        //Constructer 1
        public Frm_CANConfiguration()
        {
            InitializeComponent();

            oCANConfig = new CANMessagesConfiguration();
            oMultipleControllersCfg =  null;
            ConfigurationModified = false;
            bParameterEdition = false;
            
            ReloadMainFormCanCfg =  false;
            CanControllerId = -1;
            FrmParent =  null;
            
            tabControl1.TabPages.Remove(Tab_Controller);
        }
        
        //Constructer 2
        public Frm_CANConfiguration(bool CurrentConfig, int ControllerId, MainForm FrmMain)
        {
        	InitializeComponent();

            oCANConfig = new CANMessagesConfiguration();
            oMultipleControllersCfg =  null;
            ConfigurationModified = false;
			bParameterEdition = false;
            
            ReloadMainFormCanCfg=CurrentConfig;
            CanControllerId = ControllerId;
            FrmParent=FrmMain;
            
            tabControl1.TabPages.Remove(Tab_Controller);
        }

        #region Control events
		
        #region Form
        
        private void Frm_CANConfiguration_Load(object sender, EventArgs e)
        {
            Cmb_ValueFormat.Items.Clear();
            Cmb_ValueFormat.Items.AddRange(Enum.GetNames(typeof(CanParameterValueFormat)));

            ShowConfiguration();
        }
        
        private void Frm_CANConfiguration_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ConfigurationModified)
            {
                DialogResult Rep = MessageBox.Show("The configuration has been modified. Do you want save it ?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (Rep)
                {
                    case DialogResult.Yes:

                        SaveConfiguration();
                        break;

                    case DialogResult.No:

                        //Nothing
                        break;

                    case DialogResult.Cancel:

                        e.Cancel = true;
                        break;
                }
            }
        }
        
        #endregion
        
        #region ToolBar

        private void TSB_New_Click(object sender, EventArgs e)
        {
            NewConfiguration();
        }

        private void TSB_Open_Click(object sender, EventArgs e)
        {
            OpenConfiguration();
        }

        private void TSB_Save_Click(object sender, EventArgs e)
        {
            SaveConfiguration();
        }

        private void TSB_Cut_Click(object sender, EventArgs e)
        {
            CopyItem(true);
        }

        private void TSB_Copy_Click(object sender, EventArgs e)
        {
            CopyItem(false);
        }

        private void TSB_Paste_Click(object sender, EventArgs e)
        {
            PasteItem();
        }
		
        private void TSB_ImportDBCClick(object sender, EventArgs e)
        {
        	Import_DBC_File();
        }
        
        private void TSB_NewControllerClick(object sender, EventArgs e)
        {
        	AddCanBusController();
        }
        
        private void TSB_NewMessage_Click(object sender, EventArgs e)
        {
            CreateNewMessage();
        }

        private void TSB_NewParameter_Click(object sender, EventArgs e)
        {
            CreateNewParameter(false);
        }
		
        private void TSB_NewVirtualParameterClick(object sender, EventArgs e)
        {
        	CreateNewParameter(true);
        }
        
        private void TSB_Delete_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }

        #endregion

        #region Context_TV_Messages
		
        private void AddCanControllertoolStripMenuItemClick(object sender, EventArgs e)
        {
        	AddCanBusController();
        }
        
        private void messageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewMessage();
        }

        private void createNewParameterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewParameter(false);
        }
		
        private void CreateNewVirtualParameterToolStripMenuItemClick(object sender, EventArgs e)
        {
        	CreateNewParameter(true);
        }
        
        #region Controller configuration
        
        private void Import_ControllerCfg_TSMIClick(object sender, EventArgs e)
        {
        	ImportControllerConfiguration();
        }
        
        private void Export_ControllerCfg_TSMIClick(object sender, EventArgs e)
        {
        	ExportControllerConfiguration();
        }
        
        #endregion
        
        private void ImportDBCtoolStripMenuItemClick(object sender, EventArgs e)
        {
        	Import_DBC_File();
        }
        
        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyItem(true);
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyItem(false);
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteItem();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteItem();
        }
        
        private void ExpandAllToolStripMenuItemClick(object sender, EventArgs e)
        {
        	TV_Messages.ExpandAll();
        }
        
        private void CollapseAllToolStripMenuItemClick(object sender, EventArgs e)
        {
        	TV_Messages.CollapseAll();
        }
		
        private void Context_TV_MessagesOpening(object sender, CancelEventArgs e)
        {
        	if (!(TV_Messages.SelectedNode == null))
        	{
        		ControllerConfigToolStripMenuItem.Enabled = ((ConfigurationItemType)TV_Messages.SelectedNode.Tag).Equals(ConfigurationItemType.Controller);
        	}
        	else
        	{
        		ControllerConfigToolStripMenuItem.Enabled = false;
        	}
        	//ControllerConfigToolStripMenuItem.Enabled
        }
        
        #endregion
		
        #region TV_Messages
        
        private void TV_Messages_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            ShowConfigurationItem(e.Node);
        }

        private void TV_Messages_KeyDown(object sender, KeyEventArgs e)
        {
            //Cut, Copy, Paste
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.X: //Cut
                        CopyItem(true);
                        break;
                    case Keys.C: //Copy
                        CopyItem(false);
                        break;
                    case Keys.V: //Paste
                        PasteItem();
                        break;
                }
            }

            //Delete
            if (e.KeyCode.Equals(Keys.Delete))
            {
                DeleteItem();
            }
        }
        
        #endregion
        
        #region Cmb_Filter
        
        private void Cmb_FilterSelectedIndexChanged(object sender, EventArgs e)
        {
        	if (!(oMultipleControllersCfg == null))
        	{
        		ShowMultipleControllersConfiguration(Cmb_Filter.Text);
        	}
        	else
        	{
        		ShowConfiguration(Cmb_Filter.Text);
        	}
        }
        
        private void Cmb_FilterKeyDown(object sender, KeyEventArgs e)
        {
        	if (e.KeyCode.Equals(Keys.Enter))
        	{
        		if (!(Cmb_Filter.Text.Equals("")))
        		{
        			if (!(Cmb_Filter.Items.Contains(Cmb_Filter.Text)))
        			{
        				//FIFO 10 items
        				if (Cmb_Filter.Items.Count == 10)
        				{
        					Cmb_Filter.Items.RemoveAt(9);
        				}
        				
        				Cmb_Filter.Items.Insert(0, Cmb_Filter.Text);
        			}
        		}
        		
        		if (!(oMultipleControllersCfg == null))
		    	{
		    		ShowMultipleControllersConfiguration(Cmb_Filter.Text);
		    	}
		    	else
		    	{
		    		ShowConfiguration(Cmb_Filter.Text);
		    	}
        	}
        }
        
        #endregion
        
        #region Controller control
        
        private void Cmd_ControllerChangeClick(object sender, EventArgs e)
        {
        	if (!(Txt_ControllerName.Text.Equals("")))
        	{
	        	CANBusContoller oCtrl = oMultipleControllersCfg.Get_BusController(TV_Messages.SelectedNode.Text);
	        	
	        	oCtrl.ControllerName = Txt_ControllerName.Text;
	        	oCtrl.Description = Txt_ControllerDescription.Text;
	        	
	        	TV_Messages.SelectedNode.Text = Txt_ControllerName.Text;
        	}
        	else
        	{
        		MessageBox.Show("Controller name cannot be empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        	}
        }
        
        #endregion
        
        #region Message control
        
        private void Cmd_CreateMessage_Click(object sender, EventArgs e)
        {
        	MakeMessage();
        }

        private void Cmd_CancelNewMessage_Click(object sender, EventArgs e)
        {
            ResetMessageForm();
        }
        
        private void Generic_MessageTextBoxKeyDown(object sender, KeyEventArgs e)
        {
        	if (e.KeyCode.Equals(Keys.Enter))
        	{
        		MakeMessage();
        	}
        }
        
        #endregion
        
        #region Parameter control
        
        private void Cmd_CreateParameter_Click(object sender, EventArgs e)
        {
        	MakeParameter();
        }

        private void Cmd_CancelNewParam_Click(object sender, EventArgs e)
        {
            ResetParameterForm();
        }
        
        private void Chk_MuxParameterCheckedChanged(object sender, EventArgs e)
        {
        	if(Chk_MuxParameter.Checked)
        	{
        		Grp_ParamMultiplexer.Enabled=true;
        		CreatMultiplexerIdList(oActiveMessage);
        		
        		
        		if(oActiveMessage.MultiplexerName.Equals(""))
        		{
        			Cmb_ParamMultiplexerName.SelectedIndex=-1;
        		}
        		else
        		{
        			Cmb_ParamMultiplexerName.Text =oActiveMessage.MultiplexerName;
        		}
        		
        		Cmb_ParamMultiplexerValue.SelectedIndex=-1;
        	}
        	else
        	{
        		Cmb_ParamMultiplexerName.Items.Clear();
        		Cmb_ParamMultiplexerValue.Items.Clear();
        		Grp_ParamMultiplexer.Enabled=false;
        	}
        }
        
        private void Cmb_ParamMultiplexerNameSelectedIndexChanged(object sender, EventArgs e)
        {
        	Cmb_ParamMultiplexerValue.Items.Clear();
        	
        	if(!(Cmb_ParamMultiplexerName.Text.Equals("")))
        	{
        		//Multpiplexer values list creation
        		CANParameter oMuxParam=oActiveMessage.GetCANParameter(Cmb_ParamMultiplexerName.Text, ParameterResearchOption.Name);
        		
        		if(!(oMuxParam==null))
        		{
        			long MaxValue=(long)Math.Pow(2,(double)oMuxParam.Length)+1;
        			
        			for(int i=0;i<MaxValue;i++)
        			{
        				Cmb_ParamMultiplexerValue.Items.Add(i.ToString());
        			}
        		}
        	}
        }
        
        private void Generic_ParameterTextBoxKeyDown(object sender, KeyEventArgs e)
        {
        	if (e.KeyCode.Equals(Keys.Enter))
        	{
        		MakeParameter();
        	}
        }
        
        private void Cmb_ParamEndianessSelectedIndexChanged(object sender, EventArgs e)
        {
        	if (!bParameterEdition)
        	{
        		SwitchParameterEndianess();
        	}
        }
        
        private void Cmd_VirtualRefClick(object sender, EventArgs e)
        {
        	SelectVirtualChannelReference();
        }

        #region Value format

        private void Cmb_ValueFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            if (!(bParameterEdition))
            {
                CanParameterValueFormat eFormat;

                if (Enum.TryParse(Cmb_ValueFormat.Text, out eFormat))
                {
                    switch (eFormat)
                    {
                        case CanParameterValueFormat.Decimal:

                            Lbl_Decimals.Enabled = true;
                            Txt_Decimals.Enabled = true;
                            Txt_Decimals.Text = "3";
                            Cmd_EnumDefinition.Enabled = false;

                            break;

                        case CanParameterValueFormat.Enum:

                            Lbl_Decimals.Enabled = false;
                            Txt_Decimals.Text = "";
                            Txt_Decimals.Enabled = false;
                            Cmd_EnumDefinition.Enabled = true;

                            break;

                        default:

                            Lbl_Decimals.Enabled = false;
                            Txt_Decimals.Text = "";
                            Txt_Decimals.Enabled = false;
                            Cmd_EnumDefinition.Enabled = false;

                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid value format !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void Cmd_EnumDefinition_Click(object sender, EventArgs e)
        {
            Frm_ParamEnumerationEdition Frm = new Frm_ParamEnumerationEdition(oActiveParameter.ValueFormat);
            Frm.Show();
        }

        #endregion

        #region Warnings and alarms

        private void Chk_AlarmsEnabled_CheckedChanged(object sender, EventArgs e)
        {
            if (Chk_AlarmsEnabled.Checked)
            {
                Lbl_Alarms_Backcolor.Enabled = true;
                Lbl_Alarms_Forecolor.Enabled = true;

                Chk_WarningMin.Enabled = true;
                Chk_WarningMax.Enabled = true;
                Chk_AlarmMin.Enabled = true;
                Chk_AlarmMax.Enabled = true;

                SetWarningMinControls(Chk_WarningMin.Checked);
                SetWarningMaxControls(Chk_WarningMax.Checked);
                SetAlarmMinControls(Chk_AlarmMin.Checked);
                SetAlarmMaxControls(Chk_AlarmMax.Checked);
            }
            else
            {
                Lbl_Alarms_Backcolor.Enabled = false;
                Lbl_Alarms_Forecolor.Enabled = false;

                Chk_WarningMin.Enabled = false;
                Chk_WarningMax.Enabled = false;
                Chk_AlarmMin.Enabled = false;
                Chk_AlarmMax.Enabled = false;

                SetWarningMinControls(false);
                SetWarningMaxControls(false);
                SetAlarmMinControls(false);
                SetAlarmMaxControls(false);
            }
        }

        private void Chk_WarningMin_CheckedChanged(object sender, EventArgs e)
        {
            SetWarningMinControls(Chk_WarningMin.Checked);
        }

        private void Chk_WarningMax_CheckedChanged(object sender, EventArgs e)
        {
            SetWarningMaxControls(Chk_WarningMax.Checked);
        }

        private void Chk_AlarmMin_CheckedChanged(object sender, EventArgs e)
        {
            SetAlarmMinControls(Chk_AlarmMin.Checked);
        }

        private void Chk_AlarmMax_CheckedChanged(object sender, EventArgs e)
        {
            SetAlarmMaxControls(Chk_AlarmMax.Checked);
        }

        private void Pic_WarningMin_Backcolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_WarningMin_Backcolor);
        }

        private void Pic_WarningMin_Forecolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_WarningMin_Forecolor);
        }

        private void Pic_WarningMax_Backcolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_WarningMax_Backcolor);
        }

        private void Pic_WarningMax_Forecolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_WarningMax_Forecolor);
        }

        private void Pic_AlarmMin_Backcolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMin_Backcolor);
        }

        private void Pic_AlarmMin_Forecolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMin_Forecolor);
        }

        private void Pic_AlarmMax_Backcolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMax_Backcolor);
        }

        private void Pic_AlarmMax_Forecolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMax_Forecolor);
        }

        #endregion

        #region Parameter min max updates

        private void Txt_ParamLength_TextChanged(object sender, EventArgs e)
        {
            ShowParameterMinMax();
        }

        private void Txt_ParamGain_TextChanged(object sender, EventArgs e)
        {
            ShowParameterMinMax();
        }

        private void Txt_ParamZero_TextChanged(object sender, EventArgs e)
        {
            ShowParameterMinMax();
        }

        private void Chk_Signed_CheckedChanged(object sender, EventArgs e)
        {
            ShowParameterMinMax();
        }

        #endregion

        #endregion

        #region Misc

        private void Cmb_BusRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            oCANConfig.CanRate = int.Parse(Cmb_BusRate.Text);
        }

        private void Txt_MsgLength_TextChanged(object sender, EventArgs e)
        {
            if (!(Txt_MsgLength.Text.Equals("")))
            {
                int Len = 0;
                if (int.TryParse(Txt_MsgLength.Text, out Len))
                {
                	int Rem8=0;
                	Math.DivRem(Len,8,out Rem8);
                	
                	if(Rem8==0)
                	{
                		if(Len<=64)
                		{
                			oCANConfig.MessageLength = Len;
                		}
                		else
                		{
                			MessageBox.Show("The maximum message length is 64 bits (8 bytes) !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                		}
                	}
                	else
                	{
                		MessageBox.Show("The message length must be a multiple of 8 !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                	}
                }
                else
                {
                    MessageBox.Show("The message length must be a number !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }
        
        private void Txt_ConfigNameTextChanged(object sender, EventArgs e)
        {
        	oCANConfig.Name = Txt_ConfigName.Text;
        }
		
        private void MessageMapCell_Click(object sender, EventArgs e)
        {
        	Label oLbl = (Label) sender;
        	TV_Messages.SelectedNode = TV_Messages.Nodes.Find(oLbl.Tag.ToString(), true)[0];
        	ShowConfigurationItem(FindCanParameterNode(oLbl.Tag.ToString()));
        }
        
        private void NumUpDown_MuxValueValueChanged(object sender, EventArgs e)
        {
        	Show_MsgMap(oActiveMessage);
        }
        
        private void Grid_MsgMapSizeChanged(object sender, EventArgs e)
        {
        	Grid_MsgMap.SuspendLayout();
        	
        	int ColWidth = (int)((Grid_MsgMap.Width - Grid_MsgMap.RowHeadersWidth) / 8);
        	
        	foreach (DataGridViewColumn oCol in Grid_MsgMap.Columns)
        	{
        		oCol.Width = ColWidth;
        	}   	
        	
        	Grid_MsgMap.ResumeLayout(true);
        	
        	if (!(oActiveMessage == null)) Show_MsgMap(oActiveMessage);     
        }
        
        #endregion

        #endregion

        #region Private methodes
		
        #region Configuration
        
        private void NewConfiguration()
        {
        	if (ConfigurationModified)
            {
                DialogResult Rep = MessageBox.Show("The configuration has been modified. Do you want save it ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Rep.Equals(DialogResult.Yes))
                {
                    SaveConfiguration();
                }
            }

            oCANConfig = new CANMessagesConfiguration();
            oMultipleControllersCfg = null;
            ClearGridParam();
            ShowConfiguration();
            ConfigurationModified = false;
            tabControl1.TabPages.Remove(Tab_Controller);
        }

        private void OpenConfiguration()
        {
            if (ConfigurationModified)
            {
                DialogResult Rep = MessageBox.Show("The configuration has been modified. Do you want save it ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (Rep.Equals(DialogResult.Yes))
                {
                    SaveConfiguration();
                }
            }

            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "CAN Configuration|*.xcc|Multiple CAN bus Configuration|*.mcb";
            openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";

            if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
            	if (Path.GetExtension(openFileDialog1.FileName).Equals(".xcc"))
            	{
	            	oMultipleControllersCfg = null;
            		oCANConfig = new CANMessagesConfiguration();
	            	
	                if (oCANConfig.ReadCANConfigurationFile(openFileDialog1.FileName))
	                {
	                    ShowConfiguration();
	                    ConfigurationModified = false;
	                }
	                else
	                {
	                    MessageBox.Show("CAN configuration file loading error !\nCheck the file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
	                }
            	}
            	else if (Path.GetExtension(openFileDialog1.FileName).Equals(".mcb"))
            	{
            		oMultipleControllersCfg = new MultipleContollerCANConfiguration();
            		oCANConfig = null;
            		
            		if (oMultipleControllersCfg.ReadControllersConfiguaration(openFileDialog1.FileName))
            		{
            			ShowMultipleControllersConfiguration();
            			ConfigurationModified = false;
            		}
            		else
            		{
	                    MessageBox.Show("Multiple CAN bus Configuration file loading error !\nCheck the file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            		}
            	}
            }
        }

        private void SaveConfiguration()
        {
            saveFileDialog1.FileName = "";
            saveFileDialog1.InitialDirectory =  CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
			
            if (oMultipleControllersCfg == null) //Standard configuration: Single controller
            {
            	saveFileDialog1.Filter = "CAN Configuration|*.xcc";
            }
            else //Multiple controllers configuration
            {
            	if (oMultipleControllersCfg.Controllers.Count > 1) //At least two controllers => Multiple controllers file 
            	{
            		saveFileDialog1.Filter = "Multiple CAN bus Configuration|*.mcb";
            	}
            	else //Only one controller => Standard Can config file 
            	{
            		saveFileDialog1.Filter = "CAN Configuration|*.xcc";
            	}
            }
            
            if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
            {
            	if (Path.GetExtension(saveFileDialog1.FileName).Equals(".xcc"))
            	{
            		oCANConfig.WriteCANConfigurationFile(saveFileDialog1.FileName);
            	}
            	else if (Path.GetExtension(saveFileDialog1.FileName).Equals(".mcb"))
            	{
            		oMultipleControllersCfg.WriteControllersConfiguration(saveFileDialog1.FileName);
            	}
                
                ConfigurationModified = false;
                
               	//Main form CAN Configuration reloading if specified
               	if(ReloadMainFormCanCfg & !(FrmParent==null))
               	{
               		if (oMultipleControllersCfg == null)
               		{
               			FrmParent.ReloadCanConfig(saveFileDialog1.FileName, CanControllerId);
               		}
               		else
               		{
               			FrmParent.ReloadControllerConfig(saveFileDialog1.FileName);
               		}
           		}
            }
        }
		
        private void ShowConfiguration()
        {
        	ShowConfiguration("");
        }
        
        private void ShowConfiguration(string sFilter)
        {
            ResetMessageForm();
            ResetParameterForm();
            ResetControllerForm();

            Cmb_BusRate.Text = oCANConfig.CanRate.ToString();
            Txt_MsgLength.Text = oCANConfig.MessageLength.ToString();
			Txt_ConfigName.Text = oCANConfig.Name;
            
			TV_Messages.SuspendLayout();
			
            TV_Messages.Nodes.Clear();

            foreach (CANMessage oMsg in oCANConfig.Messages)
            {
                TreeNode nMsg = TV_Messages.Nodes.Add(oMsg.Name, oMsg.Name + " [0x" + oMsg.Identifier.ToString() + "]", 0, 0);
                nMsg.Tag = ConfigurationItemType.Message;

                foreach (CANParameter oParam in oMsg.Parameters)
                {
                	if ((sFilter.Equals("")) || (oParam.Name.ToLower().Contains(sFilter.ToLower())))
                	{
                		TreeNode nParam = null;
                		
                		if (!(oParam.IsVirtual))
                		{
                			nParam = nMsg.Nodes.Add(oParam.Name, oParam.Name, 1, 1);
                		}
                		else
                		{
                			nParam = nMsg.Nodes.Add(oParam.Name, oParam.Name, 3, 3);
                		}
                		
                		nParam.Tag = ConfigurationItemType.Parameter;
                	}
                }
                
                if (!(sFilter.Equals(""))) //If a filter is set
                {
                	//If message node has no child and its name isn't matching the filter
                	if ((nMsg.Nodes.Count == 0) && (!(nMsg.Text.ToLower().Contains(sFilter.ToLower()))))
                	{
                		TV_Messages.Nodes.Remove(nMsg); //Message node removed
                	}
                }
            }
            
            TV_Messages.ExpandAll();
            
            TV_Messages.ResumeLayout(true);
            
            if (oCANConfig.Messages.Count > 0 && TV_Messages.Nodes.Count > 0)
            {
            	oActiveMessage=oCANConfig.Messages[0];
            	Show_MsgMap(oActiveMessage);
            }
        }
        
        private void ShowMultipleControllersConfiguration()
        {
        	ShowMultipleControllersConfiguration("");
        }
        
        private void ShowMultipleControllersConfiguration(string sFilter)
        {
        	ResetMessageForm();
            ResetParameterForm();
            ResetControllerForm();

            Cmb_BusRate.Text = oMultipleControllersCfg.Controllers[0].CanRate.ToString();
            Txt_MsgLength.Text = oMultipleControllersCfg.Controllers[0].MessageLength.ToString();
            
            TV_Messages.SuspendLayout();
            
            TV_Messages.Nodes.Clear();
            
            foreach (CANBusContoller oCtrl in oMultipleControllersCfg.Controllers)
            {
            	TreeNode nCtrl = TV_Messages.Nodes.Add(oCtrl.ControllerName, oCtrl.ControllerName, 2, 2);
            	nCtrl.Tag = ConfigurationItemType.Controller;
            	
            	foreach(CANMessage oMsg in oCtrl.Messages)
            	{
            		TreeNode nMsg = nCtrl.Nodes.Add(oMsg.Name, oMsg.Name + " [0x" + oMsg.Identifier.ToString() + "]", 0, 0);
                	nMsg.Tag = ConfigurationItemType.Message;
                	
                	foreach (CANParameter oParam in oMsg.Parameters)
                	{
                		if ((sFilter.Equals("")) || (oParam.Name.ToLower().Contains(sFilter.ToLower())))
                		{
                			TreeNode nParam = null;
                			
                			if (!(oParam.IsVirtual))
                			{
                				nParam = nMsg.Nodes.Add(oParam.Name, oParam.Name, 1, 1);
                			}
                			else
                			{
                				nParam = nMsg.Nodes.Add(oParam.Name, oParam.Name, 3, 3);
                			}
                			
                			nParam.Tag = ConfigurationItemType.Parameter;
                		}
                	}
                	
                	if (!(sFilter.Equals(""))) //If a filter is set
	                {
	                	//If message node has no child and its name isn't matching the filter
	                	if ((nMsg.Nodes.Count == 0) && (!(nMsg.Text.ToLower().Contains(sFilter.ToLower()))))
	                	{
	                		TV_Messages.Nodes.Remove(nMsg); //Message node removed
	                	}
	                }
            	}
            	
            	if (!(sFilter.Equals(""))) //If a filter is set
                {
                	//If message node has no child and its name isn't matching the filter
                	if ((nCtrl.Nodes.Count == 0) && (!(nCtrl.Text.ToLower().Contains(sFilter.ToLower()))))
                	{
                		TV_Messages.Nodes.Remove(nCtrl); //Message node removed
                	}
                }
            }
            
            if (TV_Messages.Nodes.Count > 0)
            {
            	nController = TV_Messages.Nodes[0];
            }
            else
            {
            	nController = null;
            }
            	
            oCANConfig = oMultipleControllersCfg.Controllers[0];
            
            Cmb_BusRate.Text = oCANConfig.CanRate.ToString();
            Txt_MsgLength.Text = oCANConfig.MessageLength.ToString();
			Txt_ConfigName.Text = oCANConfig.Name;
            
			foreach (TreeNode n in TV_Messages.Nodes)
			{
				n.Expand();
			}
            
			TV_Messages.ResumeLayout(true);
			
            if (oCANConfig.Messages.Count > 0)
            {
            	oActiveMessage = oCANConfig.Messages[0];
            	Show_MsgMap(oActiveMessage);
            }
            
            if (!(tabControl1.TabPages.Contains(Tab_Controller)))
            {
            	tabControl1.TabPages.Insert(0, Tab_Controller);
            }
        }
        
        private void ShowConfigurationItem(TreeNode nItem)
        {
            ResetMessageForm();
			ResetParameterForm();
			ResetControllerForm();
        	
        	if (!(nItem == null))
            {
            	string MsgName = "";
            	
            	switch ((ConfigurationItemType) nItem.Tag)
            	{
            		case ConfigurationItemType.Controller:
            			
            			CANBusContoller oCtrl = oMultipleControllersCfg.Get_BusController(nItem.Text);
            			
            			tabControl1.SelectedTab = Tab_Controller;
            			Grp_ControllerForm.Enabled = true;
            			
            			Txt_ControllerName.Text = oCtrl.ControllerName;
            			Txt_ControllerDescription.Text = oCtrl.Description;
            			
            			oCANConfig = oCtrl;
            			ShowCANBusProperties();
            			
            			if (oCANConfig.Messages.Count > 0)
            			{
            				oActiveMessage = oCANConfig.Messages[oCANConfig.Messages.Count -1];
            			}
            			else
            			{
            				oActiveMessage = null;
            			}
            			
            			break;
            			
            		case ConfigurationItemType.Message:
            			
            			MsgName = nItem.Text.Substring(0, nItem.Text.IndexOf("[") - 1);
            			
            			if (!(oMultipleControllersCfg == null))
            			{
            				oCANConfig = oMultipleControllersCfg.Get_BusController(nItem.Parent.Text);
            			}
            			
            			if (!(oCANConfig == null))
            			{
            				ShowCANBusProperties();
            				
            				oActiveMessage = oCANConfig.GetCANMessage(MsgName, MessageResearchOption.Name);

            				if (!(oActiveMessage == null))
            				{
            					tabControl1.SelectedTab = Tab_Message;
            					Grp_MessageForm.Enabled = true;

            					Txt_MsgName.Text = oActiveMessage.Name;
            					Txt_MsgIdentifier.Text = oActiveMessage.Identifier;
            					Txt_MsgPeriod.Text = oActiveMessage.Period.ToString();
            					Txt_MsgComment.Text = oActiveMessage.Comment;

            					if (oActiveMessage.RxTx.Equals(CanMsgRxTx.Rx))
            					{
            						Radio_Rx.Checked = true;
            					}
            					else
            					{
            						Radio_Tx.Checked = true;
            					}

            					Cmd_CreateMessage.Text = "Modify";
            				}
            			}
            			
            			break;
            			
            		case ConfigurationItemType.Parameter:
            			
            			MsgName = nItem.Parent.Text.Substring(0, nItem.Parent.Text.IndexOf("[") - 1);
            			
            			if (!(oMultipleControllersCfg == null))
            			{
            				oCANConfig = oMultipleControllersCfg.Get_BusController(nItem.Parent.Parent.Text);
            			}
            			
            			if (!(oCANConfig == null))
            			{
            				ShowCANBusProperties();
            				
            				oActiveMessage = oCANConfig.GetCANMessage(MsgName, MessageResearchOption.Name);
            				
            				if (!(oActiveMessage == null))
            				{
            					oActiveParameter = oActiveMessage.GetCANParameter(nItem.Text, ParameterResearchOption.Name);

            					if (!(oActiveParameter == null))
            					{
            						bParameterEdition = true;
            						
            						tabControl1.SelectedTab = Tab_Parameter;
            						Grp_ParameterForm.Enabled = true;

            						Txt_ParamName.Text = oActiveParameter.Name;
            						Txt_ParamStartBit.Text = oActiveParameter.StartBit.ToString();
            						Txt_ParamLength.Text = oActiveParameter.Length.ToString();
            						Cmb_ParamEndianess.Text = oActiveParameter.Endianess.ToString();
            						Chk_Signed.Checked = oActiveParameter.Signed;
            						Txt_ParamUnit.Text = oActiveParameter.Unit;
            						Txt_ParamGain.Text = oActiveParameter.Gain.ToString();
            						Txt_ParamZero.Text = oActiveParameter.Zero.ToString();
            						Txt_ParamComment.Text=oActiveParameter.Comment;

            						if (oActiveParameter.IsMultiplexed)
            						{
            							CreatMultiplexerIdList(oActiveMessage);
            							Chk_MuxParameter.Checked=true;
            							Cmb_ParamMultiplexerName.Text = oActiveMessage.MultiplexerName;
            							Cmb_ParamMultiplexerValue.Text = oActiveParameter.MultiplexerValue.ToString();
            						}
            						else
            						{
            							Grp_ParamMultiplexer.Enabled = false;
            						}
									
            						if (oActiveParameter.IsVirtual)
            						{
            							Lbl_VirtualRef.Visible = true;
            							Txt_VirtualRef.Visible = true;
            							Cmd_VirtualRef.Visible = true;
            							
            							Txt_VirtualRef.Text = oActiveParameter.VirtualChannelReference.LibraryName + "::" + oActiveParameter.VirtualChannelReference.ChannelName;
            							Txt_VirtualRef.Tag = oActiveParameter.VirtualChannelReference;
            						}

                                    Cmb_ValueFormat.SelectedIndex = (int)oActiveParameter.ValueFormat.FormatType;

                                    if (oActiveParameter.ValueFormat.FormatType.Equals(CanParameterValueFormat.Decimal))
                                    {
                                        Txt_Decimals.Enabled = true;
                                        Txt_Decimals.Text = oActiveParameter.ValueFormat.Decimals.ToString();
                                    }

                                    if (oActiveParameter.ValueFormat.FormatType.Equals(CanParameterValueFormat.Enum))
                                    {
                                        Cmd_EnumDefinition.Enabled = true;
                                    }

                                    Chk_AlarmsEnabled.Checked = oActiveParameter.Alarms.Enabled;
                                    Chk_WarningMin.Checked = oActiveParameter.Alarms.WarningLimitMin.Enabled;
                                    Chk_WarningMax.Checked = oActiveParameter.Alarms.WarningLimitMax.Enabled;
                                    Chk_AlarmMin.Checked = oActiveParameter.Alarms.AlarmLimitMin.Enabled;
                                    Chk_AlarmMax.Checked = oActiveParameter.Alarms.AlarmLimitMax.Enabled;

                                    ShowParameterMinMax();
                                    Cmd_CreateParameter.Text = "Modify";
            						
            						bParameterEdition = false;
            					}
            				}
            			}
            			
            			break;
            	}
                
                Show_MsgMap(oActiveMessage);
            }
        }
		
        private void ShowCANBusProperties()
        {
        	Cmb_BusRate.Text = oCANConfig.CanRate.ToString();
            Txt_MsgLength.Text = oCANConfig.MessageLength.ToString();
			Txt_ConfigName.Text = oCANConfig.Name;
        }
        
        #endregion
        
        #region Generic methodes
        
        private void DeleteItem()
        {
            TreeNode nItem = TV_Messages.SelectedNode;

            if (!(nItem == null))
            {
            	switch ((ConfigurationItemType) nItem.Tag)
            	{
            		case ConfigurationItemType.Controller:
            			
            			DelteteController(nItem.Text);
            			ClearGridParam();
            			break;
            			
            		case ConfigurationItemType.Message:
            			
            			DeleteMessage(nItem.Text.Substring(0, nItem.Text.IndexOf("[") - 1));
                   		ClearGridParam();
            			break;
            			
            		case ConfigurationItemType.Parameter:
            			
            			string MsgName = nItem.Parent.Text.Substring(0, nItem.Parent.Text.IndexOf("[") - 1);
	                    DeleteParameter(MsgName, nItem.Text);
	                    Show_MsgMap(oActiveMessage);
            			break;
            	}

                ConfigurationModified = true;
            }
        }
		
        private void CopyItem(bool bCut)
        {			
            if (!(TV_Messages.SelectedNode == null))
            {
            	CANConfigClipboardObject oClipObject = new CANConfigClipboardObject();
            	
            	oClipObject.ClipBoardCutOption = bCut;
            	oClipObject.ClipboardObjectSourceFormIndex = GetFormIndex();
            	
            	switch ((ConfigurationItemType)TV_Messages.SelectedNode.Tag)
            	{
            		case ConfigurationItemType.Controller:
            			
            			oClipObject.ClipboardObject = oMultipleControllersCfg.Get_BusController(TV_Messages.SelectedNode.Text).Clone();
            			break;
            			
            		case ConfigurationItemType.Message:
            			
            			oClipObject.ClipboardObject = oActiveMessage.Clone();
            				
            			if (!(oMultipleControllersCfg == null))
            			{
            				oClipObject.ClipboardObjectCANCfgSrcIndex = oMultipleControllersCfg.Get_BusControllerId(TV_Messages.SelectedNode.Parent.Text);
            			}
            			
            			break;
            			
            		case ConfigurationItemType.Parameter:
            			
            			oClipObject.ClipboardObject = oActiveParameter.Clone();
            		
            			if (!(oMultipleControllersCfg == null))
            			{
            				oClipObject.ClipboardObjectCANCfgSrcIndex = oMultipleControllersCfg.Get_BusControllerId(TV_Messages.SelectedNode.Parent.Parent.Text);
            			}
            			
                		oClipObject.ParamClipBoardParentMessageName = oActiveMessage.Name;
            			break;
            	}
            	
            	if (!(oClipObject.ClipboardObject == null))
            	{
            		DataFormats.Format oFormat = DataFormats.GetFormat(typeof(CANConfigClipboardObject).FullName);
            		IDataObject ClipDataObj = new DataObject();
                	ClipDataObj.SetData(oFormat.Name, false, oClipObject);
                	Clipboard.SetDataObject(ClipDataObj, false);
            	}
            }
        }
        
        private void PasteItem()
        {
        	CANConfigClipboardObject oClipObject = null;
        	IDataObject ClipDataObj = Clipboard.GetDataObject();
            string sFormat = typeof(CANConfigClipboardObject).FullName;
        	
            if (ClipDataObj.GetDataPresent(sFormat))
            {
            	oClipObject = ClipDataObj.GetData(sFormat) as CANConfigClipboardObject;
            	
            	if (!(oClipObject == null))
            	{
            		if (oClipObject.ClipboardObject.GetType().Equals(typeof(CANBusContoller)))
            		{
            			CANBusContoller oCtrlClip = (CANBusContoller)oClipObject.ClipboardObject;
            			
            			if (oMultipleControllersCfg == null)
            			{
            				oMultipleControllersCfg = new MultipleContollerCANConfiguration();
            			}
            			
            			if (oMultipleControllersCfg.Controllers.Count <= 8)
            			{
            				string ControllerOriginalName = oCtrlClip.ControllerName;
            				
            				if (oMultipleControllersCfg.ControllerExists(oCtrlClip.ControllerName))
            				{
            					int i = 2;
            					while (oMultipleControllersCfg.ControllerExists(oCtrlClip.ControllerName + " " + i.ToString()))
            					{
            						i++;
            					}
            					
            					oCtrlClip.ControllerName = oCtrlClip.ControllerName + " " + i.ToString();
            				}
            				
            				oMultipleControllersCfg.Controllers.Add(oCtrlClip);
            					
        					if ((oClipObject.ClipBoardCutOption) && (!(oClipObject.ClipboardObjectSourceFormIndex == -1)))
        					{        						
        						Frm_CANConfiguration oClipObjectSrcFrm = GetFormAtIndex(oClipObject.ClipboardObjectSourceFormIndex);
            				
	            				if (!(oClipObjectSrcFrm == null))
	            				{
	            					oCtrlClip.Name = ControllerOriginalName;
	            					
	            					try
	            					{
	            						/*
	            						 * Not 100% sure ClipboardObjectSourceFormIndex
	            						 * is still pointing to the actual source form...
	            						 * If source form has been closed and a new form has been opened between cut and past operation
	            						 * ClipboardObjectSourceFormIndex is pointing on the wrong form which even might no be a Frm_CANConfiguration class instance
	            						 */
	            						oClipObjectSrcFrm.CutPastCallBack(oClipObject);
	            					}
	            					catch
	            					{
	            					}
	            				}
        					}
            			}
            			else
            			{
            				MessageBox.Show("Maximum number of CAN bus controller is 8 !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            			}
            		}
            		else if (oClipObject.ClipboardObject.GetType().Equals(typeof(CANMessage)))
            		{
            			CANMessage oMsgClip = (CANMessage)oClipObject.ClipboardObject;
            			
            			string OriginalMsgName = oMsgClip.Name;
            			
            			if (!(oCANConfig.IsFreeIdentifier(oMsgClip.Identifier, null)))
            			{
            				oMsgClip.Identifier = "0";
            			}

            			if (!(oCANConfig.IsFreeMessageName(oMsgClip.Name, null)))
            			{
            				int i = 2;
            				while (oCANConfig.IsFreeMessageName(oMsgClip.Name + " " + i.ToString(), null) == false)
            				{
            					i++;
            				}
            				
            				oMsgClip.Name = OriginalMsgName + " " + i.ToString();
            			}

            			oCANConfig.Messages.Add(oMsgClip);

            			if ((oClipObject.ClipBoardCutOption) && (!(oClipObject.ClipboardObjectSourceFormIndex == -1)))
            			{            				
            				Frm_CANConfiguration oClipObjectSrcFrm = GetFormAtIndex(oClipObject.ClipboardObjectSourceFormIndex);
            				
            				if (!(oClipObjectSrcFrm == null))
            				{
            					oMsgClip.Name = OriginalMsgName;
            					
            					try
            					{
            						/*
            						 * Not 100% sure ClipboardObjectSourceFormIndex
            						 * is still pointing to the actual source form...
            						 * If source form has been closed and a new form has been opened between cut and past operation
            						 * ClipboardObjectSourceFormIndex is pointing on the wrong form which even might no be a Frm_CANConfiguration class instance
            						 */
            						oClipObjectSrcFrm.CutPastCallBack(oClipObject);
            					}
            					catch
            					{
            					}
            				}
            			}
            		}
            		else if (oClipObject.ClipboardObject.GetType().Equals(typeof(CANParameter)))
            		{
            			CANParameter oParamClip = (CANParameter)oClipObject.ClipboardObject;
            			
            			string OriginalParameterName = oParamClip.Name;

            			if (!(oActiveMessage.IsFreeParameterName(oParamClip.Name, null)))
            			{
            				int i = 2;
            				while (oActiveMessage.IsFreeParameterName(oParamClip.Name + " " + i.ToString(), null) == false)
            				{
            					i++;
            				}
            				
            				oParamClip.Name = OriginalParameterName + " " + i.ToString();
            			}

            			if (oActiveMessage.IsParameterSlotFree(oParamClip) == false)
            			{
            				MessageBox.Show("Bits range defined for the current parameter is already used by another parameter !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            				return;
            			}

            			oActiveMessage.Parameters.Add(oParamClip);
            			
            			if ((oClipObject.ClipBoardCutOption) && (!(oClipObject.ClipboardObjectSourceFormIndex == -1)))
            			{            				
            				Frm_CANConfiguration oClipObjectSrcFrm = GetFormAtIndex(oClipObject.ClipboardObjectSourceFormIndex);
            				
            				if (!(oClipObjectSrcFrm == null))
            				{
            					oParamClip.Name = OriginalParameterName;
            					
            					try
            					{
            						/*
            						 * Not 100% sure ClipboardObjectSourceFormIndex
            						 * is still pointing to the actual source form...
            						 * If source form has been closed and a new form has been opened between cut and past operation
            						 * ClipboardObjectSourceFormIndex is pointing on the wrong form which even might no be a Frm_CANConfiguration class instance
            						 */
            						oClipObjectSrcFrm.CutPastCallBack(oClipObject);
            					}
            					catch
            					{
            					}
            				}
            			}
            		}
            		
            		ConfigurationModified = true;
            		
            		if (oMultipleControllersCfg == null)
            		{
            			ShowConfiguration();
            		}
            		else
            		{
            			ShowMultipleControllersConfiguration();
            		}
            		
            		Show_MsgMap(oActiveMessage);
            	}
            }
        }
        
        private TreeNode FindCanParameterNode(string ParamName)
        {
        	foreach (TreeNode n in TV_Messages.Nodes)
        	{
        		foreach (TreeNode n1 in n.Nodes)
    			{
    				if (n1.Text.Equals(ParamName))
    				{
    					return(n1);
    				}
    			}
        	}
        	
        	return(null);
        }
        
        private int GetFormIndex()
        {
        	for (int i=0; i<Application.OpenForms.Count; i++)
        	{
        		if (Application.OpenForms[i].Equals((Form)this))
        		{
        			return (i);
        		}
        	}
        	
        	return (-1);
        }
        
        private Frm_CANConfiguration GetFormAtIndex(int FormIndex)
        {
        	if ((FormIndex >= 0) && (FormIndex < Application.OpenForms.Count))
        	{
        		if (Application.OpenForms[FormIndex].GetType().Equals(typeof(Frm_CANConfiguration)))
        		{
        			return(Application.OpenForms[FormIndex] as Frm_CANConfiguration);
        		}
        	}
        	
        	return null;
        }
        
        #endregion
        
        #region Controllers
        
        private void AddCanBusController()
        {
        	if (oMultipleControllersCfg == null) //There is only one controller so far, so the CANMessagesConfiguration 'oCANConfig' was used 
        	{
        		oMultipleControllersCfg = new MultipleContollerCANConfiguration();
        		
        		if (oCANConfig.Messages.Count == 0) //No message set yet
        		{
        			//Create the first controller
	        		CANBusContoller  oCtrl1 = new CANBusContoller();
	        		oCtrl1.ControllerName = oCtrl1.Name = "CAN Bus 1";
	        		oMultipleControllersCfg.Controllers.Add(oCtrl1);
	        		
	        		oCANConfig = oMultipleControllersCfg.Controllers[0];
        		}
        		else //At least one message is present
        		{
        			//Create the first controller with the existing CANMessagesConfiguration
	        		CANBusContoller  oCtrl1 = new CANBusContoller(oCANConfig);
	        		oCtrl1.ControllerName = oCtrl1.Name = "CAN Bus 1";
	        		oMultipleControllersCfg.Controllers.Add(oCtrl1);
	        		
	        		//Create the second controller empty
	        		CANBusContoller  oCtrl2 = new CANBusContoller();
	        		oCtrl2.ControllerName = oCtrl2.Name = "CAN Bus 2";
	        		oMultipleControllersCfg.Controllers.Add(oCtrl2);
	        		
	        		oCANConfig = oMultipleControllersCfg.Controllers[1];
        		}
        	}
        	else //There is already multiple controllers in the configuration
        	{
        		if (oMultipleControllersCfg.Controllers.Count <= 8)
        		{
        			CANBusContoller oNewCtrl = new CANBusContoller();
        			oNewCtrl.ControllerName = oNewCtrl.Name = "CAN Bus " + (oMultipleControllersCfg.Controllers.Count + 1).ToString();
        			oMultipleControllersCfg.Controllers.Add(oNewCtrl);
        			
        			oCANConfig = oMultipleControllersCfg.Controllers[oMultipleControllersCfg.Controllers.Count -1];
        		}
        		else
        		{
        			MessageBox.Show("Maximum number of CAN bus controller is 8 !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        			return;
        		}
        	}
        	
        	ShowCANBusProperties();
        	ShowMultipleControllersConfiguration();
        	ConfigurationModified = true;
        }
        
        private void DelteteController(string ControllerName)
        {
        	oMultipleControllersCfg.Controllers.RemoveAt(oMultipleControllersCfg.Get_BusControllerId(ControllerName));
        	TV_Messages.Nodes.Remove(TV_Messages.SelectedNode);
        	ConfigurationModified = true;
        	
        	if (oMultipleControllersCfg.Controllers.Count == 0)
        	{
        		oCANConfig = new CANMessagesConfiguration();
        		oMultipleControllersCfg = null;
        	}
        }
        
        private void ResetControllerForm()
        {
        	Txt_ControllerName.Text = "";
        	Txt_ControllerDescription.Text = "";
        	Grp_ControllerForm.Enabled = false;
        }
        
        private void ImportControllerConfiguration()
        {
        	if (!(TV_Messages.SelectedNode == null))
        	{
        		if (((ConfigurationItemType)TV_Messages.SelectedNode.Tag).Equals(ConfigurationItemType.Controller))
        		{
        			CANBusContoller oCtrl = oMultipleControllersCfg.Get_BusController(TV_Messages.SelectedNode.Text);
        			
        			if (!(oCtrl == null))
        			{
        				openFileDialog1.FileName = "";
            			openFileDialog1.Filter = "CAN Configuration|*.xcc";
            			openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
            			
            			if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
            			{
            				CANMessagesConfiguration oNewCfg = new CANMessagesConfiguration();
            				
            				if (oNewCfg.ReadCANConfigurationFile(openFileDialog1.FileName))
            				{
            					oCtrl.Set_ControllerCanConfiguration(oNewCfg);
            					ShowMultipleControllersConfiguration();
            					ConfigurationModified = true;
            				}
            				else
            				{
            					MessageBox.Show("CAN configuration file loading error !\nCheck the file.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            				}
            			}
        			}
        		}
        	}
        }
        
        private void ExportControllerConfiguration()
        {
        	if (!(TV_Messages.SelectedNode == null))
        	{
        		if (((ConfigurationItemType)TV_Messages.SelectedNode.Tag).Equals(ConfigurationItemType.Controller))
        		{
        			CANBusContoller oCtrl = oMultipleControllersCfg.Get_BusController(TV_Messages.SelectedNode.Text);
        			
        			if (!(oCtrl == null))
        			{
        				saveFileDialog1.FileName = "";
            			saveFileDialog1.InitialDirectory =  CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
            			saveFileDialog1.Filter = "CAN Configuration|*.xcc";
            			
            			if (saveFileDialog1.ShowDialog().Equals(DialogResult.OK))
            			{
            				oCtrl.WriteCANConfigurationFile(saveFileDialog1.FileName);
            			}
        			}
        		}
        	}
        }
        
        #endregion
        
        #region Messages
        
        private void CreateNewMessage()
        {
            tabControl1.SelectedTab = Tab_Message;
            Cmd_CreateMessage.Text = "Create";

            Grp_MessageForm.Enabled = true;

            Txt_MsgName.Text = "Message " + (oCANConfig.Messages.Count + 1).ToString();
            Txt_MsgIdentifier.Text = "";
            Txt_MsgPeriod.Text = "1000";
            Radio_Tx.Checked = true;
            
            if (oMultipleControllersCfg == null) //Standard configuration: single controller
            {
            	nController = null;
            }
            else //Multiple controller configuration
            {
            	if (TV_Messages.SelectedNode == null) //No node selected, use the last controller
            	{
            		nController = TV_Messages.Nodes[TV_Messages.Nodes.Count - 1];
            	}
            	else //A node is selected, get its controller
            	{
            		switch ((ConfigurationItemType)TV_Messages.SelectedNode.Tag)
            		{
            			case ConfigurationItemType.Controller:
            				
            				nController = TV_Messages.SelectedNode;
            				break;
            				
            			case ConfigurationItemType.Message:
            				
            				nController = TV_Messages.SelectedNode.Parent;
            				break;
            				
            			case ConfigurationItemType.Parameter:
            				
            				nController = TV_Messages.SelectedNode.Parent.Parent;
            				break;
            		}
            	}
            }
        }
		
        private void MakeMessage()
        {        	
        	bool bNewMessage = false;

            if (Cmd_CreateMessage.Text.Equals("Create"))
            {
                bNewMessage = true;
                oActiveMessage = null;
            }

            CANMessage oMessage = null;

            if (bNewMessage)
            {
                oMessage = new CANMessage();
            }
            else
            {
                oMessage = oActiveMessage;
            }

            //Message name
            if (!(Txt_MsgName.Text.Equals("")))
            {
                if (oCANConfig.IsFreeMessageName(Txt_MsgName.Text, oActiveMessage))
                {
                    oMessage.Name = Txt_MsgName.Text;
                }
                else
                {
                    MessageBox.Show("Another message already use the same name !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("The message must have a name !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Message identifier
            if (!(Txt_MsgIdentifier.Text.Equals("")))
            {
                try
                {
                    Int32 Identifier = Int32.Parse(Txt_MsgIdentifier.Text, System.Globalization.NumberStyles.HexNumber);

                    if (!(Identifier > 0 & Identifier <= 2047)) //0x7FF = 2047
                    {
                        MessageBox.Show("The message identifier must be contained between 0 & 7FF !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (oCANConfig.IsFreeIdentifier(Txt_MsgIdentifier.Text, oActiveMessage))
                    {
                        oMessage.Identifier = Txt_MsgIdentifier.Text.ToUpper();
                    }
                    else
                    {
                        MessageBox.Show("Another message already use the same identifier !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                catch
                {
                    MessageBox.Show("The message identifier must be a hexadecimal number !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("The message must have an identifier !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //RxTx
            if (Radio_Rx.Checked)
            {
                oMessage.RxTx = CanMsgRxTx.Rx;
            }

            if (Radio_Tx.Checked)
            {
                oMessage.RxTx = CanMsgRxTx.Tx;
            }

            //Period
            if (!(Txt_MsgPeriod.Text.Equals("")))
            {
                int Period = 0;
                if (int.TryParse(Txt_MsgPeriod.Text, out Period))
                {
                    if (Period < 1)
                    {
                        MessageBox.Show("The message minimal message period is 1 ms !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oMessage.Period = Period;
                }
                else
                {
                    MessageBox.Show("The message period must be a number !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("The message period must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Comment
            oMessage.Comment=Txt_MsgComment.Text;

            if (bNewMessage)
            {
                //Add message to the messages collection
                oCANConfig.Messages.Add(oMessage);

                //Create message node into the treeview
                if (nController == null) //Standard configuration: single controller
                {
                	nMessage = TV_Messages.Nodes.Add(oMessage.Name, oMessage.Name + " [ 0x" + oMessage.Identifier.ToString() + "]", 0, 0);
                }
                else //Multiple controller
                {
                	nMessage = nController.Nodes.Add(oMessage.Name, oMessage.Name + " [ 0x" + oMessage.Identifier.ToString() + "]", 0, 0);
                	nController.Expand();
                }
                
                nMessage.Tag = ConfigurationItemType.Message;
                
                //TV_Messages.Nodes.Add(oMessage.Name, oMessage.Name + " [ 0x" + oMessage.Identifier.ToString() + "]", 0, 0);
            }
            else
            {
                TV_Messages.SelectedNode.Text = oMessage.Name + " [ 0x" + oMessage.Identifier.ToString() + "]";
            }

            ConfigurationModified = true;
            ResetMessageForm();
            Show_MsgMap(oActiveMessage);
        }
        
        private void DeleteMessage(string MessageName)
        {
            oCANConfig.Messages.RemoveAt(oCANConfig.GetCANMessageIndex(MessageName, MessageResearchOption.Name));
            TV_Messages.Nodes.Remove(TV_Messages.SelectedNode);
        }
        
        private void ResetMessageForm()
        {
            Txt_MsgName.Text = "";
            Txt_MsgIdentifier.Text = "";
            Radio_Tx.Checked = true;
            Txt_MsgPeriod.Text = "";
            Txt_MsgComment.Text = "";
            Grp_MessageForm.Enabled = false;
            Cmd_CreateMessage.Text = "Create";
        }
		
        private void Import_DBC_File()
        {
        	const int DEFAULT_CAN_RATE = 1000;
        	
        	openFileDialog1.FileName = "";
    		openFileDialog1.Filter = "Vector DBC file|*.dbc";
    		openFileDialog1.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
    		
    		if (openFileDialog1.ShowDialog().Equals(DialogResult.OK))
    		{
    			CanDBCFile oDBC = new CanDBCFile();
    			
    			if(oDBC.ReadDBC(openFileDialog1.FileName))
    			{
    				bool bAutoMCB = false; //Multiple CAN Buses configuration creation from scratch flag
    				
    				if (oDBC.BusComponents.Length > 1)
    				{
    					bAutoMCB = (MessageBox.Show("More than one node is defined in the DBC, do you want create a multiple CAN buses configuration ?",
    					                            Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
    				}	
    				
    				if (bAutoMCB) //Create a Multiple CAN Buses configuration from scratch based on the DBC (New function)
    				{
    					oMultipleControllersCfg = new MultipleContollerCANConfiguration();
    					oCANConfig = null;
    					
    					foreach (string sCanNode in oDBC.BusComponents)
    					{
    						CANBusContoller oCanNode = new CANBusContoller(oDBC.Convert_DBC_to_XCC(DEFAULT_CAN_RATE, sCanNode));
    						oCanNode.ControllerName = sCanNode;
    						
    						oMultipleControllersCfg.Controllers.Add(oCanNode);
    					}
    					
    					ShowMultipleControllersConfiguration();
    				}
    				else //Import the DBC in the current configuration of the current CAN bus (Old function)
    				{
    					string SrcDevice = Dlg_DBCTransmitterSelection.Show("CAN Device selection", "Select the transmitter CAN device to emulate.", oDBC.BusComponents);
    					CANMessagesConfiguration oDbcCanCfg = oDBC.Convert_DBC_to_XCC(DEFAULT_CAN_RATE, SrcDevice);
    					
    					if (!(oDbcCanCfg == null))
    					{
    						foreach(CANMessage oDbcMsg in oDbcCanCfg.Messages)
    						{
    							if (oCANConfig.IsFreeIdentifier(oDbcMsg.Identifier, null))
    							{
    								oCANConfig.Messages.Add(oDbcMsg);
    								ConfigurationModified = true;
    							}
    						}
    						
    						if (oMultipleControllersCfg == null)
    						{
    							ShowConfiguration();
    						}
    						else
    						{
    							ShowMultipleControllersConfiguration();
    						}
    					}
    				}
    			}
    			else
    			{
    				MessageBox.Show("DBC file reading error !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
    			}
    		}
        }
        
        #endregion
        
        #region Parameters
        
        private void CreateNewParameter(bool bVirtual)
        {
            if (oCANConfig.Messages.Count == 0)
            {
                MessageBox.Show("You must create a new CAN message first !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
			
            Grp_ParameterForm.Enabled = true;

            //Get active message node
            if (TV_Messages.SelectedNode == null)
            {
            	if (oMultipleControllersCfg == null) //Standard configuration: Single controller
            	{
            		nMessage = TV_Messages.Nodes[TV_Messages.Nodes.Count - 1];
            	}
            	else //Multiple controllers configuration
            	{
            		nController = TV_Messages.Nodes[TV_Messages.Nodes.Count - 1];
            		nMessage = nController.Nodes[nController.Nodes.Count - 1];
            	}
            }
            else
            {
            	switch ((ConfigurationItemType)TV_Messages.SelectedNode.Tag)
            	{
            		case ConfigurationItemType.Controller:
            			
            			nController = TV_Messages.SelectedNode;
            			nMessage = nController.Nodes[nController.Nodes.Count - 1];
            			
            			break;
            			
            		case ConfigurationItemType.Message:
            			
            			nMessage = TV_Messages.SelectedNode;
            			break;
            			
            		case ConfigurationItemType.Parameter:
            			
            			nMessage = TV_Messages.SelectedNode.Parent;
            			break;
            	}
            }
            
            //Set active message object 
            string MsgName = nMessage.Text.Substring(0, nMessage.Text.IndexOf("[") - 1);
            oActiveMessage = oCANConfig.GetCANMessage(MsgName, MessageResearchOption.Name);

            //Set default properties
            oActiveParameter = new CANParameter();

            bParameterEdition = true;
            
            tabControl1.SelectedTab = Tab_Parameter;
            Cmd_CreateParameter.Text = "Create";

            Txt_ParamName.Text = "Parameter " + (oActiveMessage.Parameters.Count + 1).ToString();
            Txt_ParamGain.Text = "1";
            Txt_ParamZero.Text = "0";
            Cmb_ParamEndianess.SelectedIndex=0;
            Chk_Signed.Checked = false;
            
            bParameterEdition = false;
            
            Lbl_VirtualRef.Visible = bVirtual;
            Txt_VirtualRef.Visible = bVirtual;
            Cmd_VirtualRef.Visible = bVirtual;
            if (bVirtual) SelectVirtualChannelReference();

            Cmb_ValueFormat.SelectedIndex = 0;
            Txt_Decimals.Text = "";
            Txt_Decimals.Enabled = false;
            Cmd_EnumDefinition.Enabled = false;

            Chk_AlarmsEnabled.Checked = false;
            Chk_WarningMin.Checked = false;
            Chk_WarningMax.Checked = false;
            Chk_AlarmMin.Checked = false;
            Chk_AlarmMax.Checked = false;
        }
		
        private void MakeParameter()
        {        	
        	bool bNewParameter = false;
            EnumerationValue[] EnumList = null;

            if (Cmd_CreateParameter.Text.Equals("Create"))
            {
                bNewParameter = true;
            }

            CANParameter oParameter = null;

            if (bNewParameter)
            {
                oParameter = new CANParameter();
                //oActiveParameter = null;
            }
            else
            {
                oParameter = oActiveParameter;
            }

            if (oActiveParameter.ValueFormat.Enums.Count > 0)
            {
                EnumList = oActiveParameter.ValueFormat.Enums.ToArray(); //Save enumeration if defined prior to destroy the oActiveParameter object
            }

            //Parameter name
            if (!(Txt_ParamName.Text.Equals("")))
            {
                if (oActiveMessage.IsFreeParameterName(Txt_ParamName.Text, oActiveParameter))
                {
                	if ((oParameter.Name.Equals(oActiveMessage.MultiplexerName)) && (!(oParameter.Name.Equals(""))))
                	{
                		oActiveMessage.MultiplexerName = Txt_ParamName.Text;
                	}
                	
                	oParameter.Name = Txt_ParamName.Text;
                }
                else
                {
                    MessageBox.Show("This parameter name is already used !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Parameter must have a name !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Start bit
            if (!(Txt_ParamStartBit.Text.Equals("")))
            {
                int StartBit = 0;
                if (int.TryParse(Txt_ParamStartBit.Text, out StartBit))
                {
                    if (StartBit < 0)
                    {
                        MessageBox.Show("Parameter start bit must be positive !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (StartBit >= oCANConfig.MessageLength)
                    {
                        MessageBox.Show("Parameter start bit is higher than message length !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oParameter.StartBit = StartBit;
                }
                else
                {
                    MessageBox.Show("Parameter start bit must be a decimal number !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Parameter start bit must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
			
            //Endianess
            if(!(Cmb_ParamEndianess.Text.Equals("")))
            {
            	CanParameterEndianess eEndianess= CanParameterEndianess.Unknown;
            	if(CanParameterEndianess.TryParse(Cmb_ParamEndianess.Text,out eEndianess))
            	{
            		oParameter.Endianess=eEndianess;
            	}
            	else
            	{
            		MessageBox.Show("Parameter endianess is not valid !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
               		return;	
            	}
            }
            else
            {
            	MessageBox.Show("Parameter endianess must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;	
            }
            
            //Length
            if (!(Txt_ParamLength.Text.Equals("")))
            {
                int Length = 0;
                if (int.TryParse(Txt_ParamLength.Text, out Length))
                {
                    if (Length < 0)
                    {
                        MessageBox.Show("Parameter bit length must be positive !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    if (Length > oCANConfig.MessageLength)
                    {
                        MessageBox.Show("Parameter bit length can't be bigger than message length !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
					
                    oParameter.Length = Length;
                    
                    //if (oParameter.StartBit + Length > oCANConfig.MessageLength)
                    if (oParameter.GetParameterEndBit() > oCANConfig.MessageLength)
                    {
                        MessageBox.Show("Parameter end bit is higher than the message length !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Parameter bit length must be a decimal number !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Parameter bit length must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Signedness
            oParameter.Signed = Chk_Signed.Checked;
            
            //Unit
            oParameter.Unit=Txt_ParamUnit.Text;
            
            //Gain
            if (!(Txt_ParamGain.Text.Equals("")))
            {
                double Gain = 0;
                if (double.TryParse(Txt_ParamGain.Text, out Gain))
                {
                    oParameter.Gain = Gain;
                }
                else
                {
                    MessageBox.Show("Parameter linearization gain must be a number !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Parameter linearization gain must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Zero
            if (!(Txt_ParamZero.Text.Equals("")))
            {
                double Zero = 0;
                if (double.TryParse(Txt_ParamZero.Text, out Zero))
                {
                    oParameter.Zero = Zero;
                }
                else
                {
                    MessageBox.Show("Parameter linearization zero must be a number !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Parameter linearization zero must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            //Comment
            oParameter.Comment=Txt_ParamComment.Text;

            //Multiplexer
            if(Chk_MuxParameter.Checked)
            {
            	//Multiplexer name
            	if(!(Cmb_ParamMultiplexerName.Text.Equals("")))
            	{
            		if(!(Cmb_ParamMultiplexerName.Text.Equals(oParameter.Name)))
            		{
            			
            			if(Cmb_ParamMultiplexerName.Text.Equals(oActiveMessage.MultiplexerName) | oActiveMessage.MultiplexerName.Equals(""))
            			{
            				if(oActiveMessage.MultiplexerName.Equals(""))
            				{
            					oActiveMessage.MultiplexerName = Cmb_ParamMultiplexerName.Text;
            				}
            				
            				oParameter.IsMultiplexed=true;
            			}
            			else
            			{
            				DialogResult Ans = MessageBox.Show("There must be only one multiplexer parameter within a single message !\n" +
            				                                   "Do you want change the multiplexer of all other paramaters ?",Application.ProductName,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Exclamation);
            				
            				if(Ans.Equals(DialogResult.Yes))
            				{
            					oActiveMessage.MultiplexerName = Cmb_ParamMultiplexerName.Text;
            					oParameter.IsMultiplexed=true;
            				}
            				else
            				{
            					return;
            				}
            			}
            		}
            		else
            		{
            			MessageBox.Show("A parameter can't multiplex itself !\nSelect a different parameter for multiplexing", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                		return;	
            		}
            	}
            	else
            	{
            		MessageBox.Show("Parameter multiplexer name must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                	return;	
            	}
            	            	
            	//Multiplexer value
            	if(!(Cmb_ParamMultiplexerValue.Text.Equals("")))
            	{
            		long MuxVal=-1;
            		if(long.TryParse(Cmb_ParamMultiplexerValue.Text,out MuxVal))
            		{
            			oParameter.MultiplexerValue=MuxVal;
            		}
            		else
            		{
            			MessageBox.Show("Multiplexer value must be an integer numeric value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                		return;
            		}
            	}
            	else
            	{
            		MessageBox.Show("Parameter multiplexer value must be defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                	return;	
            	}
            }
            else
            {
            	oParameter.IsMultiplexed=false;
            }
            
            //Virtual channel reference
            if (Txt_VirtualRef.Visible == true)
            {
            	if (!(Txt_VirtualRef.Tag == null))
            	{
            		oParameter.IsVirtual = true;
            		oParameter.VirtualChannelReference = (VirtualParameter)Txt_VirtualRef.Tag;
            	}
            	else
            	{
            		MessageBox.Show("No virtual channel reference defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            		return;
            	}
            }
            else
            {
            	oParameter.IsVirtual = false;
            }

            //Format
            if (!(Cmb_ValueFormat.SelectedIndex == -1))
            {
                if (Enum.TryParse(Cmb_ValueFormat.Text, out oParameter.ValueFormat.FormatType))
                {
                    switch (oParameter.ValueFormat.FormatType)
                    {
                        case CanParameterValueFormat.Decimal:

                            if (!(Txt_Decimals.Text.Equals("")))
                            {
                                if (!(int.TryParse(Txt_Decimals.Text, out oParameter.ValueFormat.Decimals)))
                                {
                                    MessageBox.Show("Number of decimal digits must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please set the number of decimal digits !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            break;

                        case CanParameterValueFormat.Enum:

                            if (!(EnumList == null))
                            {
                                oParameter.ValueFormat.Enums.Clear();
                                oParameter.ValueFormat.Enums.AddRange(EnumList);
                            }
                            else
                            {
                                MessageBox.Show("Enumeration hasn't been defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }

                            break;

                        default:

                            //Nothing
                            break;
                    }
                }
                else
                {
                    MessageBox.Show("Unknown parameter value format selected !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("No parameter value format defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            //Warnings and alarms
            if (Chk_AlarmsEnabled.Checked)
            {
                oParameter.Alarms.Enabled = true;

                oParameter.Alarms.WarningLimitMin.Enabled = Chk_WarningMin.Checked;
                oParameter.Alarms.WarningLimitMax.Enabled = Chk_WarningMax.Checked;
                oParameter.Alarms.AlarmLimitMin.Enabled = Chk_AlarmMin.Checked;
                oParameter.Alarms.AlarmLimitMax.Enabled = Chk_AlarmMax.Checked;

                if (oParameter.Alarms.WarningLimitMin.Enabled)
                {
                    if (!(Txt_WarningMin.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_WarningMin.Text, out oParameter.Alarms.WarningLimitMin.Value)))
                        {
                            MessageBox.Show("Warning limit min threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Warning limit min isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oParameter.Alarms.WarningLimitMin.BackColor = Pic_WarningMin_Backcolor.BackColor;
                    oParameter.Alarms.WarningLimitMin.ForeColor = Pic_WarningMin_Forecolor.BackColor;
                }

                if (oParameter.Alarms.WarningLimitMax.Enabled)
                {
                    if (!(Txt_WarningMax.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_WarningMax.Text, out oParameter.Alarms.WarningLimitMax.Value)))
                        {
                            MessageBox.Show("Warning limit max threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Warning limit max isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oParameter.Alarms.WarningLimitMax.BackColor = Pic_WarningMax_Backcolor.BackColor;
                    oParameter.Alarms.WarningLimitMax.ForeColor = Pic_WarningMax_Forecolor.BackColor;
                }

                //Warning limits consistency check
                if (oParameter.Alarms.WarningLimitMin.Enabled && oParameter.Alarms.WarningLimitMax.Enabled)
                {
                    if (oParameter.Alarms.WarningLimitMin.Value >= oParameter.Alarms.WarningLimitMax.Value)
                    {
                        MessageBox.Show("Warning limit max must be greater than warning limit min !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }

                if (oParameter.Alarms.AlarmLimitMin.Enabled)
                {
                    if (!(Txt_AlarmMin.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_AlarmMin.Text, out oParameter.Alarms.AlarmLimitMin.Value)))
                        {
                            MessageBox.Show("Alarm limit min threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alarm limit min isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oParameter.Alarms.AlarmLimitMin.BackColor = Pic_AlarmMin_Backcolor.BackColor;
                    oParameter.Alarms.AlarmLimitMin.ForeColor = Pic_AlarmMin_Forecolor.BackColor;
                }

                if (oParameter.Alarms.AlarmLimitMax.Enabled)
                {
                    if (!(Txt_AlarmMax.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_AlarmMax.Text, out oParameter.Alarms.AlarmLimitMax.Value)))
                        {
                            MessageBox.Show("Alarm limit max threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alarm limit max isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    oParameter.Alarms.AlarmLimitMax.BackColor = Pic_AlarmMax_Backcolor.BackColor;
                    oParameter.Alarms.AlarmLimitMax.ForeColor = Pic_AlarmMax_Forecolor.BackColor;
                }

                //Alarm limits consistency check
                if (oParameter.Alarms.AlarmLimitMin.Enabled && oParameter.Alarms.AlarmLimitMax.Enabled)
                {
                    if (oParameter.Alarms.AlarmLimitMin.Value >= oParameter.Alarms.AlarmLimitMax.Value)
                    {
                        MessageBox.Show("Alarm limit max must be greater than warning limit min !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }

            //Check if the parameter slot is free
            if (oActiveMessage.IsParameterSlotFree(oParameter))
            {
                if (bNewParameter)
                {
                    oActiveMessage.Parameters.Add(oParameter);
                    
                    TreeNode nParam = null;
                    
                    if (!(oParameter.IsVirtual))
                    {
                    	nParam = nMessage.Nodes.Add(oParameter.Name, oParameter.Name, 1, 1);
                    }
                    else
                    {
                    	nParam = nMessage.Nodes.Add(oParameter.Name, oParameter.Name, 3, 3);
                    }
                    
                    nParam.Tag = ConfigurationItemType.Parameter;
                    
                    nMessage.Expand();
                }
                else
                {
                    TV_Messages.SelectedNode.Text = oParameter.Name;
                }

                ConfigurationModified = true;
                ResetParameterForm();
                Show_MsgMap(oActiveMessage);
            }
            else
            {
                MessageBox.Show("Bits range defined for the current parameter is already used by another parameter !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
        }
        
        private void DeleteParameter(string MessageName, string ParameterName)
        {
            CANMessage oMsg = oCANConfig.GetCANMessage(MessageName, MessageResearchOption.Name);
            
            if (!(oMsg == null))
            {
            	oMsg.Parameters.RemoveAt(oMsg.GetCANParameterIndex(ParameterName, ParameterResearchOption.Name));
            	TV_Messages.Nodes.Remove(TV_Messages.SelectedNode);
            }
        }

        private void CreatMultiplexerIdList(CANMessage oMessage)
        {
            Cmb_ParamMultiplexerName.Items.Clear();

            foreach(CANParameter oParam in oMessage.Parameters)
            {
            	if(!(oParam.IsMultiplexed))
            	{
            		Cmb_ParamMultiplexerName.Items.Add(oParam.Name);
            	}
            }
        }
        
        private void ResetParameterForm()
        {
            bParameterEdition = true;
            
        	Txt_ParamName.Text = "";
            Txt_ParamStartBit.Text = "";
            Txt_ParamLength.Text = "";
            Txt_ParamGain.Text = "";
            Cmb_ParamEndianess.SelectedIndex = -1;
            Chk_Signed.Checked = false;
            Txt_ParamUnit.Text = "";
            Txt_ParamZero.Text = "";
            Txt_ParamComment.Text = "";
            Chk_MuxParameter.Checked=false;
            Cmb_ParamMultiplexerName.Text = "";
            Cmb_ParamMultiplexerValue.Text = "";
            Grp_ParameterForm.Enabled = false;
            Cmd_CreateParameter.Text = "Create";
            Lbl_VirtualRef.Visible = false;
            Txt_VirtualRef.Visible = false;
            Txt_VirtualRef.Text = "";
            Txt_VirtualRef.Tag = null;
            Cmd_VirtualRef.Visible = false;
            Cmb_ValueFormat.SelectedIndex = -1;
            Txt_Decimals.Text = "";
            Txt_Decimals.Enabled = false;
            Cmd_EnumDefinition.Enabled = false;
            Chk_AlarmsEnabled.Checked = false;
            Chk_WarningMin.Checked = false;
            Chk_WarningMax.Checked = false;
            Chk_AlarmMin.Checked = false;
            Chk_AlarmMax.Checked = false;
            Lbl_ParamMinMax.Text = "";

            bParameterEdition = false;
        }
        
        private void SwitchParameterEndianess()
        {
        	if (!(Txt_ParamStartBit.Equals("") || Txt_ParamLength.Text.Equals("")))
        	{
        		CanParameterEndianess eNewEndianess = CanParameterEndianess.Unknown;
        		if (Enum.TryParse(Cmb_ParamEndianess.Text, out eNewEndianess))
        		{
        			try
        			{
        				int Start = int.Parse(Txt_ParamStartBit.Text);
        				int length = int.Parse(Txt_ParamLength.Text);
        				
        				int ByteStart = Start / 8;
        				int StartBitInStartByte = Start - (ByteStart * 8);
        				
        				int NewStart = -1;
        				
        				switch (eNewEndianess)
	        			{
	        				case CanParameterEndianess.MSBFirst: //From LSB to MSB
	        					
        						NewStart = (ByteStart * 8) + 7 - StartBitInStartByte;
	        					break;
	        					
	        				case CanParameterEndianess.LSBFirst: //From MSB to LSB
	        					
	        					NewStart = (ByteStart * 8) + (7 - StartBitInStartByte);
	        					break;
	        			}
        				
        				if (!(NewStart < 0 || NewStart > oCANConfig.MessageLength))
        				{
        					Txt_ParamStartBit.Text = NewStart.ToString();
        				}
        			}
        			catch
        			{
        				return;
        			}
        		}
        	}
        }
        
        private void SelectVirtualChannelReference()
        {
        	Frm_CANConfiguration_VirtualChannelReference Frm = new Frm_CANConfiguration_VirtualChannelReference(this);
        	Frm.Show();
        }

        private void ShowParameterMinMax()
        {
            if (!(Txt_ParamLength.Text.Equals("")))
            {
                int BitLength = 0;

                if(int.TryParse(Txt_ParamLength.Text, out BitLength))
                {
                    double Gain = 0;
                    if (!(double.TryParse(Txt_ParamGain.Text, out Gain)))
                    {
                        Gain = 1; //Assumes 1 if not set or not correctly set
                    }

                    double Offset = 0;
                    if (!(double.TryParse(Txt_ParamZero.Text, out Offset)))
                    {
                        Offset = 0; //Assumes 0 if not set or not correctly set
                    }

                    double EngMin = 0;
                    double EngMax = 0;

                    UInt64 RawMax = (UInt64)(Math.Pow(2, BitLength) - 1);

                    if (Chk_Signed.Checked)
                    {
                        EngMin = ((double)(RawMax / 2) * Gain + Offset);
                        if (EngMin > 0) EngMin *= -1;

                        EngMax = ((double)((RawMax / 2) + 1) * Gain + Offset);
                        if (EngMax < 0) EngMax *= -1;
                    }
                    else
                    {
                        EngMin = 0 * Gain + Offset;
                        EngMax = (double)(RawMax) * Gain + Offset;
                    }

                    Lbl_ParamMinMax.Text = "Min: " + EngMin.ToString() + " \\ Max: " + EngMax.ToString();
                    return;
                }
            }

            Lbl_ParamMinMax.Text = "";
        }

        #region AlarmControls

        private void GetAlarmColor(PictureBox oPic)
        {
            if (!(oPic == null))
            {
                if (!(Dlg_SelectColor.ShowDialog().Equals(DialogResult.Cancel)))
                {
                    oPic.BackColor = Dlg_SelectColor.Color;
                }
            }
        }

        private void SetWarningMinControls(bool State)
        {
            if (State)
            {
                Txt_WarningMin.Enabled = true;
                Txt_WarningMin.Text = oActiveParameter.Alarms.WarningLimitMin.Value.ToString();

                Pic_WarningMin_Backcolor.Enabled = true;
                Pic_WarningMin_Backcolor.BackColor = oActiveParameter.Alarms.WarningLimitMin.BackColor;

                Pic_WarningMin_Forecolor.Enabled = true;
                Pic_WarningMin_Forecolor.BackColor = oActiveParameter.Alarms.WarningLimitMin.ForeColor;
            }
            else
            {
                Txt_WarningMin.Text = "";
                Txt_WarningMin.Enabled = false;

                Pic_WarningMin_Backcolor.BackColor = SystemColors.Control;
                Pic_WarningMin_Backcolor.Enabled = false;

                Pic_WarningMin_Forecolor.BackColor = SystemColors.Control;
                Pic_WarningMin_Forecolor.Enabled = false;

            }
        }

        private void SetWarningMaxControls(bool State)
        {
            if (State)
            {
                Txt_WarningMax.Enabled = true;
                Txt_WarningMax.Text = oActiveParameter.Alarms.WarningLimitMax.Value.ToString();

                Pic_WarningMax_Backcolor.Enabled = true;
                Pic_WarningMax_Backcolor.BackColor = oActiveParameter.Alarms.WarningLimitMax.BackColor;

                Pic_WarningMax_Forecolor.Enabled = true;
                Pic_WarningMax_Forecolor.BackColor = oActiveParameter.Alarms.WarningLimitMax.ForeColor;
            }
            else
            {
                Txt_WarningMax.Text = "";
                Txt_WarningMax.Enabled = false;

                Pic_WarningMax_Backcolor.BackColor = SystemColors.Control;
                Pic_WarningMax_Backcolor.Enabled = false;

                Pic_WarningMax_Forecolor.BackColor = SystemColors.Control;
                Pic_WarningMax_Forecolor.Enabled = false;

            }
        }

        private void SetAlarmMinControls(bool State)
        {
            if (State)
            {
                Txt_AlarmMin.Enabled = true;
                Txt_AlarmMin.Text = oActiveParameter.Alarms.AlarmLimitMin.Value.ToString();

                Pic_AlarmMin_Backcolor.Enabled = true;
                Pic_AlarmMin_Backcolor.BackColor = oActiveParameter.Alarms.AlarmLimitMin.BackColor;

                Pic_AlarmMin_Forecolor.Enabled = true;
                Pic_AlarmMin_Forecolor.BackColor = oActiveParameter.Alarms.AlarmLimitMin.ForeColor;
            }
            else
            {
                Txt_AlarmMin.Text = "";
                Txt_AlarmMin.Enabled = false;

                Pic_AlarmMin_Backcolor.BackColor = SystemColors.Control;
                Pic_AlarmMin_Backcolor.Enabled = false;

                Pic_AlarmMin_Forecolor.BackColor = SystemColors.Control;
                Pic_AlarmMin_Forecolor.Enabled = false;

            }
        }

        private void SetAlarmMaxControls(bool State)
        {
            if (State)
            {
                Txt_AlarmMax.Enabled = true;
                Txt_AlarmMax.Text = oActiveParameter.Alarms.AlarmLimitMax.Value.ToString();

                Pic_AlarmMax_Backcolor.Enabled = true;
                Pic_AlarmMax_Backcolor.BackColor = oActiveParameter.Alarms.AlarmLimitMax.BackColor;

                Pic_AlarmMax_Forecolor.Enabled = true;
                Pic_AlarmMax_Forecolor.BackColor = oActiveParameter.Alarms.AlarmLimitMax.ForeColor;
            }
            else
            {
                Txt_AlarmMax.Text = "";
                Txt_AlarmMax.Enabled = false;

                Pic_AlarmMax_Backcolor.BackColor = SystemColors.Control;
                Pic_AlarmMax_Backcolor.Enabled = false;

                Pic_AlarmMax_Forecolor.BackColor = SystemColors.Control;
                Pic_AlarmMax_Forecolor.Enabled = false;

            }
        }

        #endregion

        #endregion

        #region Message Map display

        private void Show_MsgMap(CANMessage oMsg)
        {
        	if (!(oMsg == null))
        	{
	        	//Grid initialization
	        	int MsgByteCnt = oCANConfig.MessageLength/8;
	        	
	        	CellColorId = 0;
	        	
	        	ClearGridParam();
	        	Grid_MsgMap.Rows.Clear();
	        	Grid_MsgMap.Rows.Add(MsgByteCnt);
	        	
	        	Frame_MsgMap.Text = "Message Map: " + oMsg.Name + " [0x" + oMsg.Identifier + "]";
	       
	        	if (!(oMsg.MultiplexerName.Equals("")))
	        	{
	        		Lbl_Mux.Enabled = true;
	        		Lbl_MuxName.Enabled = true;
	        		Lbl_MuxValue.Enabled = true;
	        		NumUpDown_MuxValue.Enabled =true;
	        		
	        		Lbl_MuxName.Text = oMsg.MultiplexerName;
	        	}
	        	else
	        	{
	        		Lbl_Mux.Enabled = false;
	        		Lbl_MuxName.Enabled = false;
	        		Lbl_MuxValue.Enabled = false;
	        		NumUpDown_MuxValue.Enabled =false;
	        		
	        		Lbl_MuxName.Text = "";
	        		NumUpDown_MuxValue.Value = 0;
	        	}
	        	
	        	int RowHeight = (int)((Grid_MsgMap.Height - 21) / MsgByteCnt);
        		
	        	for (int i=0; i<MsgByteCnt; i++)
	        	{
	        		Grid_MsgMap.Rows[i].HeaderCell.Value = "Byte " + i.ToString();
	        		Grid_MsgMap.Rows[i].Height = RowHeight;
	        		
	        		for (int j=0; j<Grid_MsgMap.Rows[i].Cells.Count; j++)
	        		{
	        			Grid_MsgMap.Rows[i].Cells[j].Style.ForeColor = Color.LightGray;
	        			Grid_MsgMap.Rows[i].Cells[j].Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
	        			Grid_MsgMap.Rows[i].Cells[j].Value = "Bit " + (8*i + (7-j)).ToString();
	        		}
	        	}
	        	
	        	//Message map displaying: Example using a 12 bits long parameter starting on bit 14
	        	foreach (CANParameter oParam in oMsg.Parameters)
	        	{
	        		long MuxVal = (long)NumUpDown_MuxValue.Value;
	        		
	        		if (!(oParam.IsMultiplexed) | (oParam.IsMultiplexed & oParam.MultiplexerValue.Equals(MuxVal)))
	        		{
	        			GridCellCoords StartCell = GetBitCellCoords(oParam.StartBit);
	        			GridCellCoords EndCell   = GetBitCellCoords(oParam.GetParameterEndBit());
	        			
	        			int BitToDisp = oParam.Length;
	        			int BitDisp = 0;
	        			Color CellColor = GetCellColor();
	        			
	        			List<Rectangle> ParamRectangles =  new List<Rectangle>();
	        			
	        			if (oParam.Endianess.Equals(CanParameterEndianess.LSBFirst))
	        			{
	        				while(StartCell.Row <= EndCell.Row)
	        				{
	        					int ColStart = StartCell.Column - BitToDisp + 1;
	        					if (ColStart < 0) ColStart = 0;
	        					BitDisp = StartCell.Column - ColStart + 1; 
	        					BitToDisp -= BitDisp;
	        					
	        					Rectangle StartCellRec = Grid_MsgMap.GetCellDisplayRectangle(ColStart, StartCell.Row, true);
		        				Rectangle EndCellRec   = Grid_MsgMap.GetCellDisplayRectangle(StartCell.Column, StartCell.Row, true);
		        				
		        				Rectangle Rect = new Rectangle(StartCellRec.Left,
		        				                               StartCellRec.Top,
		        				                               EndCellRec.Right - StartCellRec.Left,
		        				                               StartCellRec.Height);
		        				
		        				ParamRectangles.Add(Rect);
		        				
		        				StartCell.Row++;
		        				StartCell.Column = 7;
	        				}
	        			}
	        			else
	        			{
	        				while(StartCell.Row <= EndCell.Row)
	        				{
	        					int ColEnd = StartCell.Column + BitToDisp - 1;
	        					if (ColEnd > 7) ColEnd = 7;
	        					BitDisp = ColEnd - StartCell.Column + 1;
	        					BitToDisp -= BitDisp;
	        					
	        					Rectangle StartCellRec = Grid_MsgMap.GetCellDisplayRectangle(StartCell.Column, StartCell.Row, true);
		        				Rectangle EndCellRec   = Grid_MsgMap.GetCellDisplayRectangle(ColEnd, StartCell.Row, true);
		        				
		        				Rectangle Rect = new Rectangle(StartCellRec.Left,
		        				                               StartCellRec.Top,
		        				                               EndCellRec.Right - StartCellRec.Left,
		        				                               StartCellRec.Height);
		        				
		        				ParamRectangles.Add(Rect);
		        				
		        				StartCell.Row++;
		        				StartCell.Column = 0;
	        				}
	        			}
	        			
	        			foreach (Rectangle Rect in ParamRectangles)
	        			{
	        				Label Cell = new Label();
		        			
		        			Cell.Click += new EventHandler(MessageMapCell_Click);
		        			
		        			Cell.AutoSize    = false;
		        			Cell.Location    = Rect.Location;
		        			Cell.Size        = Rect.Size;
		        			
		        			Cell.BorderStyle = BorderStyle.None;
		        			Cell.BackColor   = CellColor;
		        			Cell.Cursor      = Cursors.Arrow;
		        			Cell.TextAlign   = ContentAlignment.MiddleCenter;
		        			
		        			Cell.Text = oParam.Name + " [Start bit: " 
		        						+ oParam.StartBit.ToString() 
		        						+ " Length: " + oParam.Length.ToString() 
		        						+ " " + oParam.Endianess.ToString() + "]";
		        			
		        			Cell.Tag = oParam.Name;
		        			
		        			Grid_MsgMap.Controls.Add(Cell);
	        			}
	        		}
	        	}
	        	
	        	Grid_MsgMap.Refresh();
        	}
        }
        
        private Color GetCellColor()
        {
        	CellColorId++;
        	
        	if (CellColorId > 15)
        	{
        		CellColorId = 0;
        	}
        	
        	switch (CellColorId)
        	{
        		case 0:
        			return(Color.LightCoral);
        		case 1:
        			return(Color.LightGreen);
        		case 2:
        			return(Color.LightBlue);
        		case 3:
        			return(Color.LightPink);
        		case 4:
        			return(Color.LightYellow);
        		case 5:
        			return(Color.LightSeaGreen);
        		case 6:
        			return(Color.LightGray);
        		case 7:
        			return(Color.LightSkyBlue);
        		case 8:
        			return(Color.LightGoldenrodYellow);
        		case 9:
        			return(Color.LightGray);
        		case 10:
        			return(Color.LightSteelBlue);
        		case 11:
        			return(Color.LightSalmon);
        		case 12:
        			return(Color.LightSlateGray);
        		case 13:
        			return(Color.Lime);
        		case 14:
        			return(Color.Cyan);
        		case 15:
        			return(Color.Lavender);
        		default:
        			return(Color.White);
        	}
        }
        
        private void ClearGridParam()
        {
        	int iCtrl = 0;
        	
        	while (Grid_MsgMap.Controls.Count > 2) //There are 2 scroll bar by default, consequently the minimum number of controls is 2
        	{
        		if (Grid_MsgMap.Controls[iCtrl].GetType().Equals(typeof(Label)))
        		{
        			Grid_MsgMap.Controls.RemoveAt(iCtrl);
        		}
        		else
        		{
        			iCtrl++;
        		}
        	}
        	
        	Frame_MsgMap.Text = "Message Map";
        }
        
        private GridCellCoords GetBitCellCoords(int BitNumber)
        {
        	GridCellCoords  CellCoord = new GridCellCoords();
        	
        	CellCoord.Row = -1;
        	CellCoord.Column = -1;
        	
        	if (BitNumber >= 0 && BitNumber <= 63)
        	{
        		CellCoord.Row = BitNumber / 8;
        		CellCoord.Column = 7 - (BitNumber - CellCoord.Row * 8);
        	}
        	
        	return(CellCoord);
        }
        
        #endregion

        #endregion
        
        #region Protected methods
        
        protected  void CutPastCallBack(CANConfigClipboardObject oClipObject)
        {
        	if (!(oClipObject == null))
        	{
        		if (oClipObject.ClipboardObject.GetType().Equals(typeof(CANBusContoller)))
        		{
        			CANBusContoller oCtrlClip = (CANBusContoller)oClipObject.ClipboardObject;
        			oMultipleControllersCfg.Controllers.RemoveAt(oMultipleControllersCfg.Get_BusControllerId(oCtrlClip.Name));
        		}
        		else if (oClipObject.ClipboardObject.GetType().Equals(typeof(CANMessage)))
        		{        			
        			CANMessage oMsgClip = (CANMessage)oClipObject.ClipboardObject;
        			
        			CANMessagesConfiguration oSrcCfg = GetClipboardObjectSrcCANCfg(oClipObject.ClipboardObjectCANCfgSrcIndex);
        			
        			if (!(oSrcCfg == null))
        			{
        				oSrcCfg.Messages.RemoveAt(oSrcCfg.GetCANMessageIndex(oMsgClip.Name, MessageResearchOption.Name));
        			}
        		}
        		else if (oClipObject.ClipboardObject.GetType().Equals(typeof(CANParameter)))
        		{
    				CANParameter oParamClip = (CANParameter)oClipObject.ClipboardObject;
    				
    				CANMessagesConfiguration oSrcCfg = GetClipboardObjectSrcCANCfg(oClipObject.ClipboardObjectCANCfgSrcIndex);
    				
    				if (!(oSrcCfg == null))
    				{
    					CANMessage oMsgParent = oSrcCfg.GetCANMessage(oClipObject.ParamClipBoardParentMessageName, MessageResearchOption.Name);
    					
    					if (!(oMsgParent == null))
    					{
    						oMsgParent.Parameters.RemoveAt(oMsgParent.GetCANParameterIndex(oParamClip.Name, ParameterResearchOption.Name));
    					}
    				}
        		}
        		
        		/*
        		 * Clear clipboard contents to avoid double cuts
        		 * with second cut pointing to no longer existing object
        		 * since it has been deleted after the first past
        		 */
        		Clipboard.Clear();
        		
        		if (oMultipleControllersCfg == null)
        		{
        			ShowConfiguration();
        		}
        		else
        		{
        			ShowMultipleControllersConfiguration();
        		}
        		
        		Show_MsgMap(oActiveMessage);
        	}
        }
        
        protected CANMessagesConfiguration GetClipboardObjectSrcCANCfg(int CANCfgIndex)
        {
        	if (!(CANCfgIndex == -1))
        	{
        		if (!(oMultipleControllersCfg == null))
        		{
        			if ((CANCfgIndex >= 0) && (CANCfgIndex < oMultipleControllersCfg.Controllers.Count))
	        		{
	        			return(oMultipleControllersCfg.Controllers[CANCfgIndex] as CANMessagesConfiguration);
	        		}
        		}
        		
        		return(null);
        	}
        	
        	return(oCANConfig);
        }
        
        #endregion
        
        #region Public methods
        
        public void SetCurrentCanConfiguration(CANMessagesConfiguration oNewCanConfig)
        {
        	if(!(oNewCanConfig==null))
        	{
        		oCANConfig=oNewCanConfig;
        		ShowConfiguration();
        	}
        }
        
        public void SetVirtualChannelReference(VirtualParameter sReference, string Unit, string Comment)
        {
        	Txt_VirtualRef.Text = sReference.LibraryName + "::" + sReference.ChannelName;
        	Txt_VirtualRef.Tag = sReference;
        	Txt_ParamUnit.Text = Unit;
        	Txt_ParamComment.Text = Comment;
        }

        #endregion
    }
}
