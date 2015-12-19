/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 1/29/2014
 * Time: 11:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml;

namespace CANStream
{
	#region Public Enums
	
	public enum ExpressionElementType
	{
		Channel = 0,
		Function = 1,
		Operator = 2,
	}
	
	public enum ExpressionElementChannelSource
	{
		CAN_Paramater   = 0,
		VirtualChannel = 1,
		BuiltInSignal  = 2,
		DataChannel    = 3,
	}

    #endregion

    #region Public Structures

    public struct ExpressionElementItem
    {
        public string Name;
        public ExpressionElementChannelSource Source;
    }

    public struct ExpressionFunctionInfo
    {
        public string Name;
        public int ArgumentCount;
    }

    #endregion

    /// <summary>
    /// Description of Frm_VirtualChannel.
    /// </summary>
    public partial class Frm_VirtualChannel : Form
	{
		#region Private members
		
		CS_VCLibrariesCollection oVCLibCollection;
		
		private CS_VirtualChannelsLibrary oActiveLibrary;
		private CS_VirtualChannel oActiveChannel;
		
		private object oClipBoardItem;
		private bool bCutOption;
		
		ExpressionElementItem[] ObjectNames;
        ExpressionFunctionInfo[] Fonctions;
        string[] Operators = { "+", "-", "x", "/", "(", ")", ";", };
		
		private Form FrmParent;
		private bool bFrmMain_ReloadLibraries;
		
		#endregion
		
		public Frm_VirtualChannel(Form ParentFrm)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//Library collection init
			oVCLibCollection = new CS_VCLibrariesCollection();
			
			oActiveLibrary = null;
			oActiveChannel = null;
			
			oClipBoardItem = null;
			bCutOption = false;
			
			FrmParent = ParentFrm;
			bFrmMain_ReloadLibraries =  false;
			
			ObjectNames = null;
			Fonctions =  Create_VC_FunctionList();
			
			//ToolTip controls init
			ToolTip_CmdChannelList.SetToolTip((Control)Cmd_ChannelList, "Channel list");
			ToolTip_CmdFunctions.SetToolTip((Control)Cmd_Functions, "Functions");
			ToolTip_CmdOperators.SetToolTip((Control)Cmd_Operators, "Operators");
		}
		
		#region Control events
		
		#region Form
		
		private void Frm_VirtualChannelLoad(object sender, EventArgs e)
		{
            Cmb_ValueFormat.Items.Clear();
            Cmb_ValueFormat.Items.AddRange(Enum.GetNames(typeof(SignalValueFormat)));

            if (File.Exists(CANStreamTools.CsDataPath+ "\\Libraries.xml"))
			{
				if (oVCLibCollection.LoadLibrariesList(CANStreamTools.CsDataPath + "\\Libraries.xml"))
				{
					foreach(CS_VirtualChannelsLibrary oLib in oVCLibCollection.Libraries)
					{
						AddLibrary(oLib);
					}
				}
			}
		}
		
		private void Frm_VirtualChannelFormClosing(object sender, FormClosingEventArgs e)
		{	
			//Save all new or modified libraries and create the library list
			foreach (CS_VirtualChannelsLibrary oLib in oVCLibCollection.Libraries)
			{
				if (oLib.bModified)
				{
					DialogResult Rep = MessageBox.Show("Library " + oLib.Name + " has been modified. Do you want save the modification ?",
					                                   Application.ProductName,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
					
					switch (Rep)
					{
						case DialogResult.Yes:
							
							if (!(oLib.FilePath.Equals("")))
							{
								oLib.WriteLibraryFile(oLib.FilePath);
							}
							else
							{
								string FilePath = SetLibraryFilePath();
								
								if (!(FilePath.Equals("")))
								{
									oLib.WriteLibraryFile(FilePath);
								}
							}
							
							break;
							
						case DialogResult.No:
							
							break;
							
						case DialogResult.Cancel:
							
							e.Cancel = true;
							return;
					}                                  
				}
			}
			
			//Save the library list file
			oVCLibCollection.SaveLibrariesList(CANStreamTools.CsDataPath + "\\Libraries.xml");
			
			//Reloading of libraries by the main form or the data viewer if needed
			if (bFrmMain_ReloadLibraries)
			{
				if (FrmParent.GetType().Equals(typeof(MainForm)))
				{
					((MainForm)FrmParent).Load_VirtualChannelsInControllers();
				}
				else if (FrmParent.GetType().Equals(typeof(Frm_DataViewer)))
				{
					((Frm_DataViewer)FrmParent).Reset_VirtualChannels();
				}
			}
		}
		
		#endregion
		
		#region Toolbar
		
		private void TSB_NewLibraryClick(object sender, EventArgs e)
		{
			CreateNewLibrary();
		}
		
		private void TSB_NewChannelClick(object sender, EventArgs e)
		{
			CreateNewChannel();
		}
		
		private void TSB_OpenLibClick(object sender, EventArgs e)
		{
			OpenLibrary();
		}
		
		private void TSB_SaveLibClick(object sender, EventArgs e)
		{
			SaveLibrary();
		}
		
		private void TSB_SaveAllLibClick(object sender, EventArgs e)
		{
			SaveAllLibraries();
		}
		
		private void TSB_CutClick(object sender, EventArgs e)
		{
			CopyItem(true);
		}
		
		private void TSB_CopyClick(object sender, EventArgs e)
		{
			CopyItem(false);
		}
		
		private void TSB_PasteClick(object sender, EventArgs e)
		{
			PasteItem();
		}
		
		private void TSB_DeleteClick(object sender, EventArgs e)
		{
			DeleteItem(null,false);
		}
		
		private void TSB_LoadObjectFileClick(object sender, EventArgs e)
		{
			LoadObjectFile();
		}
		
		#endregion
		
		#region Context_TVLibraries
		
		private void LibraryToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateNewLibrary();	
		}
		
		private void VirtualChannelToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateNewChannel();
		}
		
		private void OpenToolStripMenuItemClick(object sender, EventArgs e)
		{
			OpenLibrary();
		}
		
		private void SaveToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveLibrary();
		}
		
		private void SaveAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			SaveAllLibraries();
		}
		
		private void CutToolStripMenuItemClick(object sender, EventArgs e)
		{
			CopyItem(true);
		}
		
		private void CopyToolStripMenuItemClick(object sender, EventArgs e)
		{
			CopyItem(false);
		}
		
		private void PasteToolStripMenuItemClick(object sender, EventArgs e)
		{
			PasteItem();
		}
		
		private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			DeleteItem(null,false);
		}
		
		private void ExpandAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			TV_Libraries.ExpandAll();
		}
		
		private void CollapseAllToolStripMenuItemClick(object sender, EventArgs e)
		{
			TV_Libraries.CollapseAll();
		}
		
		#endregion
		
		#region Tab Library
		
		private void Cmd_LibCancelClick(object sender, EventArgs e)
		{
			ResetLibraryForm();
		}
		
		private void Cmd_LibCreateClick(object sender, EventArgs e)
		{
			if (!(Txt_LibName.Text.Equals("")))
			{
				if (Cmd_LibCreate.Text.Equals("Create")) //Creation of a new library
				{
					if (!(oVCLibCollection.LibraryExists(Txt_LibName.Text)))
					{
						oActiveLibrary = new CS_VirtualChannelsLibrary();
						
						//Create the new library and add it to the library collection
						oActiveLibrary.Name = Txt_LibName.Text;
						oActiveLibrary.Comment = rTxt_LibComment.Text;
						oActiveLibrary.ReadOnly = Chk_LibReadOnly.Checked;
                        oActiveLibrary.Enabled = Chk_LibEnabled.Checked;
						
						oVCLibCollection.AddLibrary(oActiveLibrary);
						
						//Set flag to make the main form reloading libraries
						bFrmMain_ReloadLibraries = true;
						
						//Show the library in the treeview
						TreeNode nLib = TV_Libraries.Nodes.Add(oActiveLibrary.Name,oActiveLibrary.Name,0);
					}
					else
					{
						MessageBox.Show("Library " + Txt_LibName.Text +" already exists !",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				else //Modification of an existing library
				{
					int LibIndex = oVCLibCollection.GetLibraryIndex(oActiveLibrary.Name);
					TreeNode nLib =  GetLibraryNode(oActiveLibrary.Name);
					
					bool bExists = false;
					for (int i=0; i<oVCLibCollection.Libraries.Count; i++)
					{
						if (!(i==LibIndex))
						{
							if (oVCLibCollection.Libraries[i].Name.Equals(Txt_LibName.Text))
							{
								bExists =  true;
								break;
							}
						}
					}
					
					if (!bExists)
					{
						//Update library instance
						oActiveLibrary.Name = Txt_LibName.Text;
						oActiveLibrary.Comment = rTxt_LibComment.Text;
						oActiveLibrary.ReadOnly = Chk_LibReadOnly.Checked;
                        oActiveLibrary.Enabled = Chk_LibEnabled.Checked;
						
						oActiveLibrary.bModified =  true;

						//Update library node in the treeview
						nLib.Text =  Txt_LibName.Text;						
					}
					else
					{
						MessageBox.Show("Library " + Txt_LibName.Text +" already exists !",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
			}
			else
			{
				MessageBox.Show("Library must have a name !",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		#endregion
		
		#region Tab Channel
		
		private void Cmd_ChanCancelClick(object sender, EventArgs e)
		{
			ResetChannelForm();
		}
		
		private void Cmd_ChanCreateClick(object sender, EventArgs e)
		{
			MakeChannel();
		}
		
		private void Cmd_ChannelListClick(object sender, EventArgs e)
		{
			if (!(ObjectNames == null))
			{
				CloseAllContextualLists();
				
				Frm_ContextualList CtxtList = new Frm_ContextualList((Form)this,ObjectNames, ExpressionElementType.Channel);
				
				CtxtList.Location = Cursor.Position;
				CtxtList.Show();
			}
			else
			{
				MessageBox.Show("No objects loaded! Load an object file to retrieve an objects collection.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
		}
		
		private void Cmd_FunctionsClick(object sender, EventArgs e)
		{
			CloseAllContextualLists();
			
			Frm_ContextualList CtxtList = new Frm_ContextualList((Form)this,Fonctions, ExpressionElementType.Function);
				
			CtxtList.Location = Cursor.Position;
			CtxtList.Show();
		}
		
		private void Cmd_OperatorsClick(object sender, EventArgs e)
		{
			CloseAllContextualLists();
			
			Frm_ContextualList CtxtList = new Frm_ContextualList((Form)this,Operators, ExpressionElementType.Operator);
				
			CtxtList.Location = Cursor.Position;
			CtxtList.Show();
		}
		
		private void Cmd_ChannelTestClick(object sender, EventArgs e)
		{
			TestChannel();
		}

        #region Value format

        private void Cmb_ValueFormat_SelectedValueChanged(object sender, EventArgs e)
        {
            SignalValueFormat eFormat;

            if (Enum.TryParse(Cmb_ValueFormat.Text, out eFormat))
            {
                switch (eFormat)
                {
                    case SignalValueFormat.Decimal:

                        Lbl_Decimals.Enabled = true;
                        Txt_Decimals.Enabled = true;
                        Txt_Decimals.Text = "3";
                        Cmd_EnumDefinition.Enabled = false;

                        break;

                    case SignalValueFormat.Enum:

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

        private void Cmd_EnumDefinition_Click(object sender, EventArgs e)
        {
            Frm_ParamEnumerationEdition Frm = new Frm_ParamEnumerationEdition(oActiveChannel.ValueFormat);
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

        private void Chk_AlarmMin_CheckedChanged(object sender, EventArgs e)
        {
            SetAlarmMinControls(Chk_AlarmMin.Checked);
        }

        private void Chk_WarningMin_CheckedChanged(object sender, EventArgs e)
        {
            SetWarningMinControls(Chk_WarningMin.Checked);
        }

        private void Chk_WarningMax_CheckedChanged(object sender, EventArgs e)
        {
            SetWarningMaxControls(Chk_WarningMax.Checked);
        }

        private void Chk_AlarmMax_CheckedChanged(object sender, EventArgs e)
        {
            SetAlarmMaxControls(Chk_AlarmMax.Checked);
        }

        private void Pic_AlarmMin_Backcolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMin_Backcolor);
        }

        private void Pic_AlarmMin_Forecolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMin_Forecolor);
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

        private void Pic_AlarmMax_Backcolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMax_Backcolor);
        }

        private void Pic_AlarmMax_Forecolor_DoubleClick(object sender, EventArgs e)
        {
            GetAlarmColor(Pic_AlarmMax_Forecolor);
        }

        #endregion

        #endregion

        #region TV_Libraries

        private void TV_LibrariesAfterSelect(object sender, TreeViewEventArgs e)
		{
			UpDateActiveObjects(e.Node);
			TV_Libraries.Focus();
		}
		
		private void TV_LibrariesKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Control)
			{
				switch (e.KeyCode)
				{
					case Keys.C: //Copy
						CopyItem(false);
						break;
					case Keys.X: //Cut
						CopyItem(true);
						break;
					case Keys.V: //Paste
						PasteItem();
						break;
				}
			}
			else
			{
				if (e.KeyCode.Equals(Keys.Delete))
				{
					DeleteItem(null,false);
				}
			}
		}
		
		#endregion
		
		#endregion
		
		#region Private methods
		
		#region Library management
		
		private void CreateNewLibrary()
		{
			ResetLibraryForm();
			Cmd_LibCreate.Text = "Create";
			
			TabCtrl_PropertiesEdit.SelectedIndex = 0;
		}
		
		private void OpenLibrary()
		{
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.Filter = "CANStream Virtual channel library | *.cvl";
			Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Virtual Channels libraries";
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				oActiveLibrary =  new CS_VirtualChannelsLibrary();
				
				if (oActiveLibrary.ReadLibraryFile(Dlg_OpenFile.FileName))
				{
					oVCLibCollection.AddLibrary(oActiveLibrary);
					AddLibrary(oActiveLibrary);
					bFrmMain_ReloadLibraries =  true;
				}
                else
                {
                    MessageBox.Show("An error occured while loading the virtual channels library !\nThe file might be corrupted or written by a later version of CANStream.",
                                    Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
			}
		}
		
		private void SaveLibrary()
		{
			if (!(oActiveLibrary == null))
			{
				string FilePath = SetLibraryFilePath();
				
				if (!(FilePath.Equals("")))
				{
					oActiveLibrary.WriteLibraryFile(FilePath);

                    //Set flag to make the main form reloading libraries
                    bFrmMain_ReloadLibraries = true;
                }
			}
		}
		
		private void SaveAllLibraries()
		{
			foreach (CS_VirtualChannelsLibrary olib in oVCLibCollection.Libraries)
			{
				if (olib.FilePath.Equals("")) //New lib
				{
					string FilePath = SetLibraryFilePath();
				
					if (!(FilePath.Equals("")))
					{
						olib.WriteLibraryFile(Dlg_SaveFile.FileName);
					}
				}
				else
				{
					if (olib.bModified)
					{
						olib.WriteLibraryFile(olib.FilePath);
					}
				}
			}
		}
		
		private string SetLibraryFilePath()
		{
			Dlg_SaveFile.FileName = oActiveLibrary.Name + ".cvl";
			Dlg_SaveFile.Filter = "CANStream Virtual channel library | *.cvl";
			Dlg_SaveFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Virtual Channels libraries";
			
			if (Dlg_SaveFile.ShowDialog().Equals(DialogResult.OK))
			{
				return(Dlg_SaveFile.FileName);
			}

			return("");
		}
		
		private void AddLibrary(CS_VirtualChannelsLibrary oNewLib)
		{
			if (!(oNewLib == null))
			{				
				TreeNode nLib = TV_Libraries.Nodes.Add(oNewLib.Name,oNewLib.Name,0,0);
				
				foreach (CS_VirtualChannel oChan in oNewLib.Channels)
				{
					nLib.Nodes.Add(oChan.Name,oChan.Name,1,1);
				}
				
				nLib.Expand();
			}
		}
		
		private void ResetLibraryForm()
		{
			Txt_LibName.Text = "";
			rTxt_LibComment.Text = "";
			Chk_LibReadOnly.Checked =  false;
            Chk_LibEnabled.Checked = true;
		}
		
		private void ShowActiveLibrary()
		{
			if(!(oActiveLibrary == null))
			{
				Txt_LibName.Text = oActiveLibrary.Name;
				rTxt_LibComment.Text = oActiveLibrary.Comment;
				Chk_LibReadOnly.Checked = oActiveLibrary.ReadOnly;
                Chk_LibEnabled.Checked = oActiveLibrary.Enabled;

				TabCtrl_PropertiesEdit.SelectedIndex = 0;
				
				Cmd_LibCreate.Text = "Modify";
			}
			else
			{
				ResetLibraryForm();
			}	
		}
		
		private TreeNode GetLibraryNode(string LibName)
		{
			foreach (TreeNode n in TV_Libraries.Nodes)
			{
				if (n.Level == 0 & n.Text.Equals(LibName))
				{
					return(n);
				}
			}
			
			return(null);
		}
		
		private CS_VirtualChannelsLibrary CloneLibrary(CS_VirtualChannelsLibrary OriginalLib)
		{
			if (!(OriginalLib == null))
			{
				CS_VirtualChannelsLibrary CloneLib = new CS_VirtualChannelsLibrary();
				
				CloneLib.Name = OriginalLib.Name;
				CloneLib.Comment = OriginalLib.Comment;
				CloneLib.ReadOnly = OriginalLib.ReadOnly;
				
				foreach (CS_VirtualChannel oChan in OriginalLib.Channels)
				{
					CloneLib.Channels.Add(OriginalLib.CloneVirtualChannel(oChan));
				}
				
				return(CloneLib);
			}
			
			return(null);
		}
		
		#endregion
		
		#region Virtual channel management
		
		private void CreateNewChannel()
		{
			if(!(oActiveLibrary == null))
			{
				if (!(oActiveLibrary.ReadOnly))
				{
					ResetChannelForm();
					Cmd_ChanCreate.Text =  "Create";

                    oActiveChannel = new CS_VirtualChannel();

					TabCtrl_PropertiesEdit.SelectedIndex = 1;
				}
				else
				{
					MessageBox.Show("The active library " + oActiveLibrary.Name + " is currently protected (Read Only).\n Remove the protection or select another library.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show("No virtual channel library selected !\n Select or create a library prior to create a new virtual channel.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
				                
			}
		}
		
		private void ResetChannelForm()
		{
			Txt_ChanName.Text = "";
			Txt_ChanUnit.Text = "";
			Chk_ChanComputationEnabled.Checked = true;
			Txt_ChanValDef.Text = "0";
			rTxt_ChanComment.Text = "";
			rTxt_ChanExpression.Text = "";
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
		
		private bool SetActiveChannel()
		{
            EnumerationValue[] EnumList = null;

            if (oActiveChannel.ValueFormat.Enums.Count > 0)
            {
                EnumList = oActiveChannel.ValueFormat.Enums.ToArray(); //Save enumeration if defined prior to destroy the oActiveParameter object
            }

            if (oActiveChannel == null)
			{
				oActiveChannel = new CS_VirtualChannel();
			}
			
			oActiveChannel.Name =  Txt_ChanName.Text;
			oActiveChannel.Unit = Txt_ChanUnit.Text;
			oActiveChannel.Comment = rTxt_ChanComment.Text;
			oActiveChannel.Enabled = Chk_ChanComputationEnabled.Checked;

			if (!(Txt_ChanValDef.Text.Equals("")))
			{
				double ValDef = 0;
				if (double.TryParse(Txt_ChanValDef.Text,out ValDef))
				{
					oActiveChannel.DefaultValue = ValDef;
				}
				else
				{
					MessageBox.Show("Virtual channel default value must be a number !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return(false);
				}
			}
			else
			{
				oActiveChannel.DefaultValue = 0;
			}
			
			if (!(rTxt_ChanExpression.Text.Equals("")))
			{
				oActiveChannel.Expression = rTxt_ChanExpression.Text;
			}
			else
			{
				MessageBox.Show("The virtual channel expression must be defined !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return(false);
			}

            //Format
            if (!(Cmb_ValueFormat.SelectedIndex == -1))
            {
                if (Enum.TryParse(Cmb_ValueFormat.Text, out oActiveChannel.ValueFormat.FormatType))
                {
                    switch (oActiveChannel.ValueFormat.FormatType)
                    {
                        case SignalValueFormat.Decimal:

                            if (!(Txt_Decimals.Text.Equals("")))
                            {
                                if (!(int.TryParse(Txt_Decimals.Text, out oActiveChannel.ValueFormat.Decimals)))
                                {
                                    MessageBox.Show("Number of decimal digits must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return(false);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please set the number of decimal digits !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return(false);
                            }

                            break;

                        case SignalValueFormat.Enum:

                            if (!(EnumList == null))
                            {
                                oActiveChannel.ValueFormat.Enums.Clear();
                                oActiveChannel.ValueFormat.Enums.AddRange(EnumList);
                            }
                            else
                            {
                                MessageBox.Show("Enumeration hasn't been defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return(false);
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
                    return(false);
                }
            }
            else
            {
                MessageBox.Show("No parameter value format defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return(false);
            }

            //Warnings and alarms
            if (Chk_AlarmsEnabled.Checked)
            {
                oActiveChannel.Alarms.Enabled = true;

                oActiveChannel.Alarms.WarningLimitMin.Enabled = Chk_WarningMin.Checked;
                oActiveChannel.Alarms.WarningLimitMax.Enabled = Chk_WarningMax.Checked;
                oActiveChannel.Alarms.AlarmLimitMin.Enabled = Chk_AlarmMin.Checked;
                oActiveChannel.Alarms.AlarmLimitMax.Enabled = Chk_AlarmMax.Checked;

                if (oActiveChannel.Alarms.WarningLimitMin.Enabled)
                {
                    if (!(Txt_WarningMin.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_WarningMin.Text, out oActiveChannel.Alarms.WarningLimitMin.Value)))
                        {
                            MessageBox.Show("Warning limit min threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Warning limit min isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }

                    oActiveChannel.Alarms.WarningLimitMin.BackColor = Pic_WarningMin_Backcolor.BackColor;
                    oActiveChannel.Alarms.WarningLimitMin.ForeColor = Pic_WarningMin_Forecolor.BackColor;
                }

                if (oActiveChannel.Alarms.WarningLimitMax.Enabled)
                {
                    if (!(Txt_WarningMax.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_WarningMax.Text, out oActiveChannel.Alarms.WarningLimitMax.Value)))
                        {
                            MessageBox.Show("Warning limit max threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Warning limit max isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }

                    oActiveChannel.Alarms.WarningLimitMax.BackColor = Pic_WarningMax_Backcolor.BackColor;
                    oActiveChannel.Alarms.WarningLimitMax.ForeColor = Pic_WarningMax_Forecolor.BackColor;
                }

                //Warning limits consistency check
                if (oActiveChannel.Alarms.WarningLimitMin.Enabled && oActiveChannel.Alarms.WarningLimitMax.Enabled)
                {
                    if (oActiveChannel.Alarms.WarningLimitMin.Value >= oActiveChannel.Alarms.WarningLimitMax.Value)
                    {
                        MessageBox.Show("Warning limit max must be greater than warning limit min !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }

                if (oActiveChannel.Alarms.AlarmLimitMin.Enabled)
                {
                    if (!(Txt_AlarmMin.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_AlarmMin.Text, out oActiveChannel.Alarms.AlarmLimitMin.Value)))
                        {
                            MessageBox.Show("Alarm limit min threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alarm limit min isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }

                    oActiveChannel.Alarms.AlarmLimitMin.BackColor = Pic_AlarmMin_Backcolor.BackColor;
                    oActiveChannel.Alarms.AlarmLimitMin.ForeColor = Pic_AlarmMin_Forecolor.BackColor;
                }

                if (oActiveChannel.Alarms.AlarmLimitMax.Enabled)
                {
                    if (!(Txt_AlarmMax.Text.Equals("")))
                    {
                        if (!(double.TryParse(Txt_AlarmMax.Text, out oActiveChannel.Alarms.AlarmLimitMax.Value)))
                        {
                            MessageBox.Show("Alarm limit max threshold must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return(false);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Alarm limit max isn't defined !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }

                    oActiveChannel.Alarms.AlarmLimitMax.BackColor = Pic_AlarmMax_Backcolor.BackColor;
                    oActiveChannel.Alarms.AlarmLimitMax.ForeColor = Pic_AlarmMax_Forecolor.BackColor;
                }

                //Alarm limits consistency check
                if (oActiveChannel.Alarms.AlarmLimitMin.Enabled && oActiveChannel.Alarms.AlarmLimitMax.Enabled)
                {
                    if (oActiveChannel.Alarms.AlarmLimitMin.Value >= oActiveChannel.Alarms.AlarmLimitMax.Value)
                    {
                        MessageBox.Show("Alarm limit max must be greater than warning limit min !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return(false);
                    }
                }
            }

            return (true);
		}
		
		private bool MakeChannel()
		{
			if (!(Txt_ChanName.Text.Equals("")))
			{
				if (Cmd_ChanCreate.Text.Equals("Create")) //Creation of a new channel
				{
					if (!oActiveLibrary.ChannelExists(Txt_ChanName.Text))
					{
						if (SetActiveChannel())
						{
							//Add the channel into the active library
							oActiveChannel.ParentLibrary = oActiveLibrary;
							oActiveLibrary.Channels.Add(oActiveChannel);
							oActiveLibrary.bModified =  true;
							
							//Set flag to make the main form reloading libraries
							bFrmMain_ReloadLibraries = true;
							
							//Add the channel node to the library node
							TreeNode nLib = GetLibraryNode(oActiveLibrary.Name);
							if (!(nLib == null))
							{
								nLib.Nodes.Add(oActiveChannel.Name,oActiveChannel.Name,1,1);
								nLib.Expand();
							}
							
							return(true);
						}
					}
					else
					{
						MessageBox.Show("Virtual channel " + Txt_ChanName.Text + " already exists in the library " + oActiveLibrary.Name + " !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
				}
				else //Modification of an existing channel
				{
					int ChanIndex =  oActiveLibrary.GetChannelIndex(oActiveChannel.Name);
					TreeNode ChanNode = GetChannelNode(oActiveLibrary.Name,oActiveChannel.Name);
					
					bool bExist =  false;
					for (int iChan=0; iChan<oActiveLibrary.Channels.Count; iChan++)
					{
						if (!(iChan == ChanIndex))
						{
							if (oActiveLibrary.Channels[iChan].Name.Equals(Txt_ChanName.Text))
							{
								bExist = true;
								break;
							}
						}
					}
					
					if (!bExist)
					{
						if (SetActiveChannel())
						{
							oActiveLibrary.bModified =  true;
							ChanNode.Text = oActiveChannel.Name;
							
							//Set flag to make the main form reloading libraries
							bFrmMain_ReloadLibraries = true;
							
							return(true);
						}
					}
					else
					{
						MessageBox.Show("Virtual channel " + Txt_ChanName.Text + " already exists in the library " + oActiveLibrary.Name + " !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
				}
			}
			else
			{
				MessageBox.Show("Virtual channel must have a name !",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			
			return(false);
		}
		
		private void ShowChannel(string ChanName)
		{
			if (!(oActiveLibrary == null))
			{
				oActiveChannel = oActiveLibrary.GetVirtualChannel(ChanName);
				
				if (!(oActiveChannel == null))
				{
					//oActiveChannel.ParentLibraryName = oActiveLibrary.Name;
					
					Txt_ChanName.Text = oActiveChannel.Name;
					Txt_ChanUnit.Text = oActiveChannel.Unit;
					Chk_ChanComputationEnabled.Checked = oActiveChannel.Enabled;
					Txt_ChanValDef.Text = oActiveChannel.DefaultValue.ToString();
					rTxt_ChanComment.Text = oActiveChannel.Comment;
					rTxt_ChanExpression.Text = oActiveChannel.Expression;

                    Cmb_ValueFormat.SelectedIndex = (int)oActiveChannel.ValueFormat.FormatType;

                    if (oActiveChannel.ValueFormat.FormatType.Equals(SignalValueFormat.Decimal))
                    {
                        Txt_Decimals.Enabled = true;
                        Txt_Decimals.Text = oActiveChannel.ValueFormat.Decimals.ToString();
                    }

                    if (oActiveChannel.ValueFormat.FormatType.Equals(SignalValueFormat.Enum))
                    {
                        Cmd_EnumDefinition.Enabled = true;
                    }

                    Chk_AlarmsEnabled.Checked = oActiveChannel.Alarms.Enabled;
                    Chk_WarningMin.Checked = oActiveChannel.Alarms.WarningLimitMin.Enabled;
                    Chk_WarningMax.Checked = oActiveChannel.Alarms.WarningLimitMax.Enabled;
                    Chk_AlarmMin.Checked = oActiveChannel.Alarms.AlarmLimitMin.Enabled;
                    Chk_AlarmMax.Checked = oActiveChannel.Alarms.AlarmLimitMax.Enabled;

                    TabCtrl_PropertiesEdit.SelectedIndex = 1;
					
					Cmd_ChanCreate.Text = "Modify";
				}
			}
		}
		
		private TreeNode GetChannelNode(string LibName, string ChanName)
		{
			foreach (TreeNode nLib in TV_Libraries.Nodes)
			{
				if (nLib.Text.Equals(LibName))
				{
					foreach (TreeNode nChan in nLib.Nodes)
					{
						if (nChan.Text.Equals(ChanName))
						{
							return(nChan);
						}
					}
				}
			}
			
			return(null);
		}
		
		private void LoadObjectFile()
		{
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream";
			Dlg_OpenFile.Filter = "CAN Configuration|*.xcc" +
								  	"|CANStream Virtual channel library | *.cvl" +
									"|CANStream Built-in Signals | *.cbs" +
									"|Converted record data file| *.csv";
			
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				List<ExpressionElementItem> TmpList = new List<ExpressionElementItem>();
				
				if (!(ObjectNames == null))
				{
					foreach(ExpressionElementItem Item in ObjectNames)
					{
						TmpList.Add(Item);
					}
				}
				
				string FileExt = Path.GetExtension(Dlg_OpenFile.FileName);
				
				if (FileExt.Equals(".xcc")) //Can configuration file
				{
					CANMessagesConfiguration oCanCfg = new CANMessagesConfiguration();
					
					if (oCanCfg.ReadCANConfigurationFile(Dlg_OpenFile.FileName))
					{
						foreach (CANMessage oMsg in oCanCfg.Messages)
						{
							foreach (CANParameter oParam in oMsg.Parameters)
							{
								ExpressionElementItem Item = new ExpressionElementItem();
								Item.Name = oParam.Name;
								Item.Source = ExpressionElementChannelSource.CAN_Paramater;
								
								TmpList.Add(Item);
							}
						}
					}
				}
				else if (FileExt.Equals(".cvl")) //Virtual channels library
				{
					CS_VirtualChannelsLibrary oChanLib = new CS_VirtualChannelsLibrary();
					
					if (oChanLib.ReadLibraryFile(Dlg_OpenFile.FileName))
					{
						foreach(CS_VirtualChannel oChan in oChanLib.Channels)
						{
							ExpressionElementItem Item = new ExpressionElementItem();
							Item.Name = oChan.Name;
							Item.Source = ExpressionElementChannelSource.VirtualChannel;
							
							TmpList.Add(Item);
						}
					}
				}
				else if (FileExt.Equals(".cbs")) //Built-in signals library
				{
					CS_BuiltInSignalLibrary oSigLib = new CS_BuiltInSignalLibrary();
					
					if (oSigLib.ReadLibraryFile(Dlg_OpenFile.FileName))
					{
						foreach (CS_BuiltInSignal oSig in oSigLib.Signals)
						{
							ExpressionElementItem Item = new ExpressionElementItem();
							Item.Name = oSig.Name;
							Item.Source = ExpressionElementChannelSource.BuiltInSignal;
							
							TmpList.Add(Item);
						}
					}
				}
				else if (FileExt.Equals(".csv")) //Data file
				{
					Ctrl_GraphWindow.GW_DataFile oData = new Ctrl_GraphWindow.GW_DataFile();
					
					if (oData.Load_DataFile(Dlg_OpenFile.FileName))
					{
						foreach (Ctrl_GraphWindow.GW_DataChannel oChan in oData.Channels)
						{
							ExpressionElementItem Item = new ExpressionElementItem();
							Item.Name = oChan.Name;
							Item.Source = ExpressionElementChannelSource.DataChannel;
							
							TmpList.Add(Item);
						}
					}
				}
				
				ObjectNames = TmpList.ToArray();
				TmpList = null;
			}
		}
		
		private void CloseAllContextualLists()
		{	
			for (int i=0; i<Application.OpenForms.Count; i++)
			{
				if (Application.OpenForms[i].GetType().Equals(typeof(Frm_ContextualList)))
				{
					Application.OpenForms[i].Close();
					i--;
				}
			}
		}
		
		private void TestChannel()
		{
			if (MakeChannel())
			{
				Cmd_ChanCreate.Text = "Modify";
				
				CS_VirtualChannel ChanTest = oActiveLibrary.CloneVirtualChannel(oActiveChannel);
				ChanTest.ParentLibrary = oActiveLibrary;
				
				Frm_VirtualChannelTest Frm = new Frm_VirtualChannelTest(this,ChanTest);
				Frm.Show();
			}
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
                Pic_WarningMin_Backcolor.Enabled = true;
                Pic_WarningMin_Forecolor.Enabled = true;

                if (!(oActiveChannel==null))
                {
                    Txt_WarningMin.Text = oActiveChannel.Alarms.WarningLimitMin.Value.ToString();
                    Pic_WarningMin_Backcolor.BackColor = oActiveChannel.Alarms.WarningLimitMin.BackColor;
                    Pic_WarningMin_Forecolor.BackColor = oActiveChannel.Alarms.WarningLimitMin.ForeColor;
                }
                else
                {
                    Txt_WarningMin.Text = "";
                    Pic_WarningMin_Backcolor.BackColor = Color.Yellow;
                    Pic_WarningMin_Forecolor.BackColor = Color.Black;
                }
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
                Pic_WarningMax_Backcolor.Enabled = true;
                Pic_WarningMax_Forecolor.Enabled = true;
                
                if (!(oActiveChannel == null))
                {
                    Txt_WarningMax.Text = oActiveChannel.Alarms.WarningLimitMax.Value.ToString();
                    Pic_WarningMax_Backcolor.BackColor = oActiveChannel.Alarms.WarningLimitMax.BackColor;
                    Pic_WarningMax_Forecolor.BackColor = oActiveChannel.Alarms.WarningLimitMax.ForeColor;
                }
                else
                {
                    Txt_WarningMax.Text = "";
                    Pic_WarningMax_Backcolor.BackColor = Color.Yellow;
                    Pic_WarningMax_Forecolor.BackColor = Color.Black;
                }
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
                Pic_AlarmMin_Backcolor.Enabled = true;
                Pic_AlarmMin_Forecolor.Enabled = true;
                
                if (!(oActiveChannel == null))
                {
                    Txt_AlarmMin.Text = oActiveChannel.Alarms.AlarmLimitMin.Value.ToString();
                    Pic_AlarmMin_Backcolor.BackColor = oActiveChannel.Alarms.AlarmLimitMin.BackColor;
                    Pic_AlarmMin_Forecolor.BackColor = oActiveChannel.Alarms.AlarmLimitMin.ForeColor;
                }
                else
                {
                    Txt_AlarmMin.Text = "";
                    Pic_AlarmMin_Backcolor.BackColor = Color.Red;
                    Pic_AlarmMin_Forecolor.BackColor = Color.White;
                }
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
                Pic_AlarmMax_Backcolor.Enabled = true;
                Pic_AlarmMax_Forecolor.Enabled = true;
                

                if (!(oActiveChannel == null))
                {
                    Txt_AlarmMax.Text = oActiveChannel.Alarms.AlarmLimitMax.Value.ToString();
                    Pic_AlarmMax_Backcolor.BackColor = oActiveChannel.Alarms.AlarmLimitMax.BackColor;
                    Pic_AlarmMax_Forecolor.BackColor = oActiveChannel.Alarms.AlarmLimitMax.ForeColor;
                }
                else
                {
                    Txt_AlarmMax.Text = "";
                    Pic_AlarmMax_Backcolor.BackColor = Color.Red;
                    Pic_AlarmMax_Forecolor.BackColor = Color.White;
                }
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

        #region Common

        private void CopyItem(bool bCut)
		{
			oClipBoardItem = GetActiveItem();
			bCutOption = bCut;	
		}
		
		private void PasteItem()
		{
			if (!(oClipBoardItem == null))
			{
				if (oClipBoardItem.GetType().Equals(typeof(CS_VirtualChannelsLibrary))) //Paste of a library
				{
					oActiveLibrary = CloneLibrary((CS_VirtualChannelsLibrary)oClipBoardItem);
					
					//Rename library
					if (oVCLibCollection.LibraryExists(oActiveLibrary.Name))
					{
						int i = 1;
						
						while (oVCLibCollection.LibraryExists(oActiveLibrary.Name + "_" + i.ToString("D2")))
						{
							i++;
						}
						
						oActiveLibrary.Name = oActiveLibrary.Name + "_" + i.ToString("D2");
					}
					
					oActiveLibrary.CollectionParent = oVCLibCollection;
					oVCLibCollection.AddLibrary(oActiveLibrary);
					AddLibrary(oActiveLibrary);
					
					//Set flag to make the main form reloading libraries
					bFrmMain_ReloadLibraries = true;
					
					if(bCutOption)
					{
						DeleteItem(oClipBoardItem,true);
						bCutOption = false;
					}
				}
				
				if (oClipBoardItem.GetType().Equals(typeof(CS_VirtualChannel))) //Paste of a virtual channel
				{
					if (!(oActiveLibrary == null))
					{
						oActiveChannel = oActiveLibrary.CloneVirtualChannel((CS_VirtualChannel)oClipBoardItem);
						
						//Rename channel (if needed)
						if (oActiveLibrary.ChannelExists(oActiveChannel.Name))
						{
							int i = 1;
							
							while (oActiveLibrary.ChannelExists(oActiveChannel.Name + "_" + i.ToString("D2")))
							{
								i++;
							}
							
							oActiveChannel.Name = oActiveChannel.Name + "_" + i.ToString("D2");
						}
						
						oActiveChannel.ParentLibrary = oActiveLibrary;
						oActiveLibrary.Channels.Add(oActiveChannel);
						
						//Set flag to make the main form reloading libraries
						bFrmMain_ReloadLibraries = true;
						
						TreeNode nLib = GetLibraryNode(oActiveLibrary.Name);
						if (!(nLib == null))
						{
							nLib.Nodes.Add(oActiveChannel.Name,oActiveChannel.Name,1,1);
						}
						
						if (bCutOption)
						{
							DeleteItem(oClipBoardItem,true);
							bCutOption = false;
						}
					}
				}
			}
		}
		
		private void DeleteItem(object Item, bool bForced)
		{
			if (Item == null)
			{
				Item = GetActiveItem();
			}
			
			if (!(Item == null))
			{
				if (Item.GetType().Equals(typeof(CS_VirtualChannelsLibrary)))
				{
					CS_VirtualChannelsLibrary oLib = (CS_VirtualChannelsLibrary)Item;
					
					bool bConfirmed =  true;

					if (!bForced)
					{
						bConfirmed = MessageBox.Show("Do you really want to remove the library " + oLib.Name + " ?",
						                             Application.ProductName,MessageBoxButtons.YesNo,MessageBoxIcon.Question)
													.Equals(DialogResult.Yes);
					}
					
					if (bConfirmed)
					{
						TV_Libraries.Nodes.Remove(GetLibraryNode(oLib.Name));
						oVCLibCollection.Libraries.Remove(oLib);
						
						//Set flag to make the main form reloading libraries
						bFrmMain_ReloadLibraries = true;
					}
					
				}
				
				if (Item.GetType().Equals(typeof(CS_VirtualChannel)))
				{
					CS_VirtualChannel oChan = (CS_VirtualChannel) Item;
					
					if (!(oChan.ParentLibrary == null))
					{
						CS_VirtualChannelsLibrary oLib = oChan.ParentLibrary;
						
						//Remove node from the treeview
						TreeNode nLib = GetLibraryNode(oLib.Name);
						
						if (!(nLib == null))
						{
							foreach (TreeNode nChan in nLib.Nodes)
							{
								if (nChan.Text.Equals(oChan.Name))
								{
									nLib.Nodes.Remove(nChan);
									break;
								}
							}
						}
						
						//Remove signal from the library
						oLib.Channels.Remove(oChan);
						oLib.bModified =  true;
						
						//Set flag to make the main form reloading libraries
						bFrmMain_ReloadLibraries = true;
					}
				}
			}
		}
		
		private object GetActiveItem()
		{
			if (!(TV_Libraries.SelectedNode == null))
			{
				switch (TV_Libraries.SelectedNode.Level)
				{
					case 0: //Library
						return((object)oActiveLibrary);
					case 1: //Channel
						return((object)oActiveChannel);
				}
			}
			
			return(null);
		}
		
		private void UpDateActiveObjects(TreeNode ActiveNode)
		{
			if (!(ActiveNode == null))
			{
				if (ActiveNode.Level == 0)
				{
					oActiveLibrary = oVCLibCollection.GetLibrary(ActiveNode.Text);
					ShowActiveLibrary();
				}
				else if (ActiveNode.Level == 1)
				{
					oActiveLibrary = oVCLibCollection.GetLibrary(ActiveNode.Parent.Text);
					ShowChannel(ActiveNode.Text);
				}
			}
		}
		
		private ExpressionFunctionInfo[] Create_VC_FunctionList()
		{
			List<ExpressionFunctionInfo> Funcs = new List<ExpressionFunctionInfo>();
			
			Type t = typeof(Math);
			System.Reflection.MethodInfo[] MethodsInfo =  t.GetMethods();
			
			foreach(System.Reflection.MethodInfo mInfo in MethodsInfo)
			{
                ExpressionFunctionInfo sFuncInfo = new ExpressionFunctionInfo();

                sFuncInfo.Name = mInfo.Name;
                sFuncInfo.ArgumentCount = mInfo.GetParameters().Length;

                if (!(Funcs.Contains(sFuncInfo)))
				{
					Funcs.Add(sFuncInfo);
				}
			}
			
			t = typeof(CS_BuiltIn_Func);
			MethodsInfo = t.GetMethods();
			
			foreach(System.Reflection.MethodInfo mInfo in MethodsInfo)
			{
                ExpressionFunctionInfo sFuncInfo = new ExpressionFunctionInfo();

                sFuncInfo.Name = mInfo.Name;
                sFuncInfo.ArgumentCount = mInfo.GetParameters().Length;

                if (!(Funcs.Contains(sFuncInfo)))
				{
					Funcs.Add(sFuncInfo);
				}
			}

            Funcs.Sort(delegate (ExpressionFunctionInfo a1, ExpressionFunctionInfo a2) { return string.Compare(a1.Name, a2.Name); });
			
			return(Funcs.ToArray());
			
		}

        

        #endregion

        #endregion

        #region Public methods

        public void AddElementFromContextualList(string Element)
		{
			if (!(Element == null))
			{	
				rTxt_ChanExpression.Text = rTxt_ChanExpression.Text.Insert(rTxt_ChanExpression.SelectionStart,Element + " ");
			}
		}
		
		public bool SetVirtualChannelExpression(string LibName, string ChanName, string Expression)
		{
			if (!(LibName ==  null | ChanName == null | Expression == null))
			{
				CS_VirtualChannelsLibrary oLib = oVCLibCollection.GetLibrary(LibName);
				
				if (!(oLib == null))
				{
					CS_VirtualChannel oChan = oLib.GetVirtualChannel(ChanName);
					
					if (!(oChan == null))
					{
						if (!(oChan.Expression.Equals(Expression)))
						{
							oChan.Expression = Expression;
							rTxt_ChanExpression.Text = oChan.Expression;
							
							oLib.bModified = true;
						}
						
						return(true);
					}
				}
			}
			
			return(false);
		}
		
		public void Set_UserLibrary(CS_VirtualChannelsLibrary UserLib)
		{
			foreach (CS_VirtualChannelsLibrary oLib in oVCLibCollection.Libraries)
			{
				if (oLib.Name.Equals(UserLib.Name))
				{
					return; //Library is already part of active libraries (Libraries.xml)
				}
			}
			
			oVCLibCollection.Libraries.Add(UserLib);
			AddLibrary(UserLib);
		}

        #endregion
    }
}
