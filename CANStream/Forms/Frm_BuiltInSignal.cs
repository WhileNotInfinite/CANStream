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
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Frm_BuiltInSignal.
	/// </summary>
	public partial class Frm_BuiltInSignal : Form
	{
		#region Private members
		
		private CS_BuiltInSignalLibCollection oBSLibCollection;
		
		private CS_BuiltInSignalLibrary oActiveLibrary;
		private CS_BuiltInSignal oActiveSignal;
		
		private object oClipBoardItem;
		private bool bCutOption;
		
		private MainForm FrmParent;
		private bool bFrmMain_ReloadLibraries;
		
		#endregion
		
		public Frm_BuiltInSignal(MainForm FrmMain)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			
			//Library collection init
			oBSLibCollection = new CS_BuiltInSignalLibCollection();
			
			if (File.Exists(CANStreamTools.CsDataPath + "\\BuiltInSignals.xml"))
			{
				if (oBSLibCollection.LoadLibrariesList(CANStreamTools.CsDataPath + "\\\\BuiltInSignals.xml"))
				{
					foreach (CS_BuiltInSignalLibrary oLib in oBSLibCollection.Libraries)
					{
						AddLibrary(oLib);
					}
				}
			}
			
			oActiveLibrary = null;
			oActiveSignal = null;
			
			oClipBoardItem = null;
			bCutOption = false;
			
			FrmParent = FrmMain;
			bFrmMain_ReloadLibraries =  false;
			
			Cmb_SigType.Items.Clear();
			string[] SigTypes = Enum.GetNames(typeof(CS_BuiltInSignalType));
			
			foreach (string sSigTyp in SigTypes)
			{
				Cmb_SigType.Items.Add(sSigTyp);
			}
		}
		
		#region Control events
		
		#region Form
		
		private void Frm_BuiltInSignalLoad(object sender, EventArgs e)
		{
		}
		
		private void Frm_BuiltInSignalFormClosing(object sender, FormClosingEventArgs e)
		{
			//Save all new or modified libraries and create the library list
			foreach (CS_BuiltInSignalLibrary oLib in oBSLibCollection.Libraries)
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
			oBSLibCollection.SaveLibrariesList(CANStreamTools.CsDataPath + "\\BuiltInSignals.xml");
			
			//Reloading of libraries by the main form if needed
			if (bFrmMain_ReloadLibraries)
			{
				FrmParent.Load_BS_LibrariesCollection();
			}
		}
		
		#endregion
		
		#region Toolbar
		
		private void TSB_NewLibraryClick(object sender, EventArgs e)
		{
			CreateNewLibrary();
		}
		
		private void TSB_NewSignalClick(object sender, EventArgs e)
		{
			CreateNewSignal();
		}
		
		private void TSB_OpenLibraryClick(object sender, EventArgs e)
		{
			OpenLibrary();
		}
		
		private void TSB_SaveLibraryClick(object sender, EventArgs e)
		{
			SaveLibrary();
		}
		
		private void TSB_SaveAllLibrariesClick(object sender, EventArgs e)
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
		
		#endregion
		
		#region Context_TVLibraries
		
		private void LibraryToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateNewLibrary();
		}
		
		private void BuiltInSignallToolStripMenuItemClick(object sender, EventArgs e)
		{
			CreateNewSignal();
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
					if (!(oBSLibCollection.LibraryExists(Txt_LibName.Text)))
					{
						oActiveLibrary = new CS_BuiltInSignalLibrary();
						
						//Create the new library and add it to the library collection
						if (!(Txt_LibName.Text.Equals("")))
						{
							if (!(Txt_LibName.Text.Contains(":"))) //":" Is used as separator between library & signal name for signal list in Cycle/Data Association form
							{
								oActiveLibrary.Name = Txt_LibName.Text;
							}
							else
							{
								MessageBox.Show("Signal library name cannot contains ':' !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
								return;
							}
							
						}
						else
						{
							MessageBox.Show("Signal library must have a name !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							return;
						}
						
						
						oActiveLibrary.Comment = rTxt_LibComment.Text;
						oActiveLibrary.ReadOnly = Chk_LibReadOnly.Checked;
						
						oBSLibCollection.AddLibrary(oActiveLibrary);
						
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
					int LibIndex = oBSLibCollection.GetLibraryIndex(oActiveLibrary.Name);
					TreeNode nLib =  GetLibraryNode(oActiveLibrary.Name);
					
					bool bExists = false;
					for (int i=0; i<oBSLibCollection.Libraries.Count; i++)
					{
						if (!(i==LibIndex))
						{
							if (oBSLibCollection.Libraries[i].Name.Equals(Txt_LibName.Text))
							{
								bExists =  true;
								break;
							}
						}
					}
					
					if (!bExists)
					{
						//Update library instance
						if (!(Txt_LibName.Text.Equals("")))
						{
							if (!(Txt_LibName.Text.Contains(":"))) //":" Is used as separator between library & signal name for signal list in Cycle/Data Association form
							{
								oActiveLibrary.Name = Txt_LibName.Text;
							}
							else
							{
								MessageBox.Show("Signal library name cannot contains ':' !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
								return;
							}
							
						}
						else
						{
							MessageBox.Show("Signal library must have a name !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
							return;
						}
						
						oActiveLibrary.Comment = rTxt_LibComment.Text;
						oActiveLibrary.ReadOnly = Chk_LibReadOnly.Checked;
						
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
		
		#region Tab Signal
		
		private void Cmd_SigCancelClick(object sender, EventArgs e)
		{
			ResetSignalForm();
		}
		
		private void Cmd_SigCreateClick(object sender, EventArgs e)
		{
			if (!(Txt_SigName.Text.Equals("")))
			{
				if (Cmd_SigCreate.Text.Equals("Create")) //Creation of a new signal
				{
					if (!oActiveLibrary.SignalExists(Txt_SigName.Text))
					{
						oActiveSignal = new CS_BuiltInSignal();
						
						if (SetActiveSignal())
						{
							//Add the channel into the active library
							oActiveSignal.ParentLibrary = oActiveLibrary;
							oActiveLibrary.Signals.Add(oActiveSignal);
							oActiveLibrary.bModified =  true;
							
							//Set flag to make the main form reloading libraries
							bFrmMain_ReloadLibraries = true;
							
							//Add the channel node to the library node
							TreeNode nLib = GetLibraryNode(oActiveLibrary.Name);
							if (!(nLib == null))
							{
								nLib.Nodes.Add(oActiveSignal.Name,oActiveSignal.Name,1,1);
								nLib.Expand();
							}
						}
						
					}
					else
					{
						MessageBox.Show("Signal " + Txt_SigName.Text + " already exists in the library " + oActiveLibrary.Name + " !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
				}
				else //Modification of an existing channel
				{
					int ChanIndex =  oActiveLibrary.GetSignalIndex(oActiveSignal.Name);
					TreeNode ChanNode = GetChannelNode(oActiveLibrary.Name,oActiveSignal.Name);
					
					bool bExist =  false;
					for (int iChan=0; iChan<oActiveLibrary.Signals.Count; iChan++)
					{
						if (!(iChan == ChanIndex))
						{
							if (oActiveLibrary.Signals[iChan].Name.Equals(Txt_SigName.Text))
							{
								bExist = true;
								break;
							}
						}
					}
					
					if (!bExist)
					{
						if (SetActiveSignal())
						{
							oActiveLibrary.bModified =  true;
							ChanNode.Text = oActiveSignal.Name;
							
							//Set flag to make the main form reloading libraries
							bFrmMain_ReloadLibraries = true;
						}
					}
					else
					{
						MessageBox.Show("Signal " + Txt_SigName.Text + " already exists in the library " + oActiveLibrary.Name + " !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					}
				}
			}
			else
			{
				MessageBox.Show("Signal must have a name !",Application.ProductName,MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		private void Cmb_SigTypeSelectedIndexChanged(object sender, EventArgs e)
		{	
			Grid_SignalProperties.Rows.Clear();
			
			switch (Cmb_SigType.SelectedIndex)
			{
				case 1: //Sinusoidal signal      : Frequency, Magnitude, Offset, Phase
					
					CreateSignalPropertyRow("Frequency");
					CreateSignalPropertyRow("Magnitude");
					CreateSignalPropertyRow("Offset");
					CreateSignalPropertyRow("Phase");
					break;
				
				case 2: //Pulses (PWM) signal    : Frequency, Width
					
					CreateSignalPropertyRow("Frequency");
					CreateSignalPropertyRow("Width");
					CreateSignalPropertyRow("Magnitude");
					break;
					
				case 3: //Triangle signal        : Frequency, Magnitude, Offset, Phase
					
					CreateSignalPropertyRow("Frequency");
					CreateSignalPropertyRow("Magnitude");
					CreateSignalPropertyRow("Offset");
					CreateSignalPropertyRow("Phase");
					break;
				
				case 4: //Repeating ramps signal : Frequency, StartValue, EndValue, 
					
					CreateSignalPropertyRow("Frequency");
					CreateSignalPropertyRow("StartValue");
					CreateSignalPropertyRow("EndValue");
					break;
					
				case 5: //Single ramp signal     : Slope, StartValue, StartTime
					
					CreateSignalPropertyRow("Slope");
					CreateSignalPropertyRow("StartValue");
					CreateSignalPropertyRow("StartTime");
					break;
				
				case 6: //Single step signal     : StartValue, EndValue, StartTime
					
					CreateSignalPropertyRow("StartValue");
					CreateSignalPropertyRow("EndValue");
					CreateSignalPropertyRow("StartTime");
					break;
					
				case 7: //Random value signal    : MinValue, MaxValue
					
					CreateSignalPropertyRow("MinValue");
					CreateSignalPropertyRow("MaxValue");
					break;
			}
			
			if (Grid_SignalProperties.Rows.Count > 0)
			{
				Grid_SignalProperties.AutoResizeRowHeadersWidth(1,DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader);
			}
		}
		
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
		
		#region Private methodes
		
		#region Library Management
		
		private void CreateNewLibrary()
		{
			ResetLibraryForm();
			Cmd_LibCreate.Text = "Create";
			TabCtrl_PropertiesEdit.SelectedIndex = 0;
		}
		
		private void OpenLibrary()
		{
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.Filter = "CANStream Built-in Signals | *.cbs";
			Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Built-In Signals libraries";
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				oActiveLibrary =  new CS_BuiltInSignalLibrary();
				
				if (oActiveLibrary.ReadLibraryFile(Dlg_OpenFile.FileName))
				{
					oBSLibCollection.AddLibrary(oActiveLibrary);
					AddLibrary(oActiveLibrary);
					bFrmMain_ReloadLibraries =  true;
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
				}
			}
		}
		
		private void SaveAllLibraries()
		{
			foreach (CS_BuiltInSignalLibrary olib in oBSLibCollection.Libraries)
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
			Dlg_SaveFile.FileName = oActiveLibrary.Name + ".cbs";
			Dlg_SaveFile.Filter = "CANStream Built-in Signals | *.cbs";
			Dlg_SaveFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Built-In Signals libraries";
			
			if (Dlg_SaveFile.ShowDialog().Equals(DialogResult.OK))
			{
				return(Dlg_SaveFile.FileName);
			}

			return("");
		}
		
		private void AddLibrary(CS_BuiltInSignalLibrary oNewLib)
		{
			if (!(oNewLib == null))
			{
				TreeNode nLib = TV_Libraries.Nodes.Add(oNewLib.Name,oNewLib.Name,0,0);
				
				foreach (CS_BuiltInSignal oSignal in oNewLib.Signals)
				{
					nLib.Nodes.Add(oSignal.Name,oSignal.Name,1,1);
				}
				
				nLib.Expand();
			}
		}
		
		private void ResetLibraryForm()
		{
			Txt_LibName.Text = "";
			rTxt_LibComment.Text = "";
			Chk_LibReadOnly.Checked = false;
		}
		
		private void ShowActiveLibrary()
		{
			if(!(oActiveLibrary == null))
			{
				Txt_LibName.Text = oActiveLibrary.Name;
				rTxt_LibComment.Text = oActiveLibrary.Comment;
				Chk_LibReadOnly.Checked = oActiveLibrary.ReadOnly;
				
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
		
		private CS_BuiltInSignalLibrary CloneLibrary(CS_BuiltInSignalLibrary OriginalLib)
		{
			if (!(OriginalLib == null))
			{
				CS_BuiltInSignalLibrary CloneLib = new CS_BuiltInSignalLibrary();
				
				CloneLib.Name = OriginalLib.Name;
				CloneLib.Comment = OriginalLib.Comment;
				CloneLib.ReadOnly = OriginalLib.ReadOnly;
				
				foreach (CS_BuiltInSignal oSignal in OriginalLib.Signals)
				{
					CloneLib.Signals.Add(OriginalLib.CloneSignal(oSignal));
				}
				
				return(CloneLib);
			}
			
			return(null);
		}
		
		#endregion
		
		#region Signal Management
		
		private void CreateNewSignal()
		{
			if(!(oActiveLibrary == null))
			{
				if (!(oActiveLibrary.ReadOnly))
				{
					ResetSignalForm();
					Cmd_SigCreate.Text =  "Create";
					
					TabCtrl_PropertiesEdit.SelectedIndex = 1;
				}
				else
				{
					MessageBox.Show("The active library " + oActiveLibrary.Name + " is currently protected (Read Only).\n Remove the protection or select another library.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
				}
			}
			else
			{
				MessageBox.Show("No built-in signals library selected !\n Select or create a library prior to create a new signal.",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Information);
				                
			}
		}
		
		private void ResetSignalForm()
		{
			Txt_SigName.Text = "";
			Cmb_SigType.SelectedIndex=0;
			Txt_SigUnit.Text = "";
			Txt_SigDecimal.Text = "2";
			rTxt_SigComment.Text = "";
			Grid_SignalProperties.Rows.Clear();
		}
		
		private bool SetActiveSignal()
		{
			if (oActiveSignal == null)
			{
				oActiveSignal = new CS_BuiltInSignal();
			}
			
			if (!(Txt_SigName.Text.Equals("")))
			{
				if (!(Txt_SigName.Text.Contains(":"))) //":" Is used as separator between library & signal name for signal list in Cycle/Data Association form
				{
					oActiveSignal.Name =  Txt_SigName.Text;
				}
				else
				{
					MessageBox.Show("Signal name cannot contains ':' !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return(false);
				}
			}
			else
			{
				MessageBox.Show("Signal must have a name !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return(false);
			}
			
			
			oActiveSignal.Unit = Txt_SigUnit.Text;
			oActiveSignal.Description = rTxt_SigComment.Text;
			
			if (Cmb_SigType.SelectedIndex > 0)
			{
				oActiveSignal.Type = (CS_BuiltInSignalType)Enum.Parse(typeof(CS_BuiltInSignalType),Cmb_SigType.Text);
			}
			else
			{
				MessageBox.Show("Signal must have a type !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return(false);
			}
			
			if (!(Txt_SigDecimal.Text.Equals("")))
			{
				int dec = 0;
				if (int.TryParse(Txt_SigDecimal.Text,out dec))
				{
					oActiveSignal.Decimals = dec;
				}
				else
				{
					MessageBox.Show("Decimals of the signal must be a number !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return(false);
				}
			}
			else
			{
				oActiveSignal.Decimals = 0;
			}
			
			oActiveSignal.Properties = new CS_BuiltInSignalProperties();
			
			foreach (DataGridViewRow GridRow in Grid_SignalProperties.Rows)
			{
				double dec = 0;
				if (double.TryParse(GridRow.Cells[0].Value.ToString(), out dec))
				{
					if (GridRow.HeaderCell.Value.ToString().Equals("Frequency"))
					{
						oActiveSignal.Properties.Frequency = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("Magnitude"))
					{
						oActiveSignal.Properties.Magnitude = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("Offset"))
					{
						oActiveSignal.Properties.Offset = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("Phase"))
					{
						oActiveSignal.Properties.Phase = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("Width"))
					{
						oActiveSignal.Properties.Width = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("StartValue"))
					{
						oActiveSignal.Properties.StartValue = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("EndValue"))
					{
						oActiveSignal.Properties.EndValue = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("Slope"))
					{
						oActiveSignal.Properties.Slope = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("StartTime"))
					{
						oActiveSignal.Properties.StartTime = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("MinValue"))
					{
						oActiveSignal.Properties.MinValue = dec;
					}
					else if (GridRow.HeaderCell.Value.ToString().Equals("MaxValue"))
					{
						oActiveSignal.Properties.MaxValue = dec;
					}
					else //Unknown properties...
					{
						MessageBox.Show("Unknown property " + GridRow.HeaderCell.Value.ToString() + " !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
						return(false);
					}
					
				}
				else
				{
					MessageBox.Show("Property " + GridRow.HeaderCell.Value.ToString() + " of the signal must be a number !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					return(false);
				}
			}
			
			return(true);
		}
		
		private void ShowSignal(string SignalName)
		{
			if (!(oActiveLibrary == null))
			{
				oActiveSignal = oActiveLibrary.GetSignal(SignalName);
				
				if (!(oActiveSignal == null))
				{
					Txt_SigName.Text = oActiveSignal.Name;
					Cmb_SigType.Text = oActiveSignal.Type.ToString();
					Txt_SigDecimal.Text = oActiveSignal.Decimals.ToString();
					Txt_SigUnit.Text = oActiveSignal.Unit;
					rTxt_SigComment.Text = oActiveSignal.Description;
					
					foreach (DataGridViewRow GridRow in Grid_SignalProperties.Rows)
					{
						if (GridRow.HeaderCell.Value.ToString().Equals("Frequency"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.Frequency;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("Magnitude"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.Magnitude;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("Offset"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.Offset;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("Phase"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.Phase;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("Width"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.Width;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("StartValue"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.StartValue;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("EndValue"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.EndValue;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("Slope"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.Slope;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("StartTime"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.StartTime;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("MinValue"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.MinValue;
						}
						else if (GridRow.HeaderCell.Value.ToString().Equals("MaxValue"))
						{
							GridRow.Cells[0].Value = oActiveSignal.Properties.MaxValue;
						}
					}
					
					TabCtrl_PropertiesEdit.SelectedIndex = 1;
					
					Cmd_SigCreate.Text =  "Modify";
				}
			}
		}
		
		private TreeNode GetChannelNode(string LibName, string SigName)
		{
			foreach (TreeNode nLib in TV_Libraries.Nodes)
			{
				if (nLib.Text.Equals(LibName))
				{
					foreach (TreeNode nSig in nLib.Nodes)
					{
						if (nSig.Text.Equals(SigName))
						{
							return(nSig);
						}
					}
				}
			}
			
			return(null);
		}
		
		private void CreateSignalPropertyRow(string PropName)
		{
			if (!(PropName.Equals("")))
			{
				DataGridViewRow GridRow = null;
				
				Grid_SignalProperties.Rows.Add();
				GridRow = Grid_SignalProperties.Rows[Grid_SignalProperties.Rows.Count - 1];
				
				GridRow.HeaderCell.Value = PropName;
				GridRow.Cells[0].Value = "0";
			}
		}
		
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
				if (oClipBoardItem.GetType().Equals(typeof(CS_BuiltInSignalLibrary))) //Paste of a library
				{
					oActiveLibrary = CloneLibrary((CS_BuiltInSignalLibrary)oClipBoardItem);
					
					//Rename library
					if (oBSLibCollection.LibraryExists(oActiveLibrary.Name))
					{
						int i = 1;
						
						while (oBSLibCollection.LibraryExists(oActiveLibrary.Name + "_" + i.ToString("D2")))
						{
							i++;
						}
						
						oActiveLibrary.Name = oActiveLibrary.Name + "_" + i.ToString("D2");
					}
					
					oActiveLibrary.CollectionParent = oBSLibCollection;
					oBSLibCollection.AddLibrary(oActiveLibrary);
					AddLibrary(oActiveLibrary);
					
					//Set flag to make the main form reloading libraries
					bFrmMain_ReloadLibraries = true;
					
					if(bCutOption)
					{
						DeleteItem(oClipBoardItem,true);
						bCutOption = false;
					}
				}
				
				if (oClipBoardItem.GetType().Equals(typeof(CS_BuiltInSignal))) //Paste of a signal
				{
					if (!(oActiveLibrary == null))
					{
						oActiveSignal = oActiveLibrary.CloneSignal((CS_BuiltInSignal)oClipBoardItem);
						
						//Rename channel (if needed)
						if (oActiveLibrary.SignalExists(oActiveSignal.Name))
						{
							int i = 1;
							
							while (oActiveLibrary.SignalExists(oActiveSignal.Name + "_" + i.ToString("D2")))
							{
								i++;
							}
							
							oActiveSignal.Name = oActiveSignal.Name + "_" + i.ToString("D2");
						}
						
						oActiveSignal.ParentLibrary = oActiveLibrary;
						oActiveLibrary.Signals.Add(oActiveSignal);
						
						//Set flag to make the main form reloading libraries
						bFrmMain_ReloadLibraries = true;
						
						TreeNode nLib = GetLibraryNode(oActiveLibrary.Name);
						if (!(nLib == null))
						{
							nLib.Nodes.Add(oActiveSignal.Name,oActiveSignal.Name,1,1);
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
				if (Item.GetType().Equals(typeof(CS_BuiltInSignalLibrary)))
				{
					CS_BuiltInSignalLibrary oLib = (CS_BuiltInSignalLibrary)Item;
					
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
						oBSLibCollection.Libraries.Remove(oLib);
						
						//Set flag to make the main form reloading libraries
						bFrmMain_ReloadLibraries = true;
					}
					
				}
				
				if (Item.GetType().Equals(typeof(CS_BuiltInSignal)))
				{
					CS_BuiltInSignal oSignal = (CS_BuiltInSignal) Item;
					
					if (!(oSignal.ParentLibrary == null))
					{
						CS_BuiltInSignalLibrary oLib = oSignal.ParentLibrary;
						
						//Remove node from the treeview
						TreeNode nLib = GetLibraryNode(oLib.Name);
						
						if (!(nLib == null))
						{
							foreach (TreeNode nSignal in nLib.Nodes)
							{
								if (nSignal.Text.Equals(oSignal.Name))
								{
									nLib.Nodes.Remove(nSignal);
									break;
								}
							}
						}
						
						//Remove channel from the library
						oLib.Signals.Remove(oSignal);
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
						return((object)oActiveSignal);
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
					oActiveLibrary = oBSLibCollection.GetLibrary(ActiveNode.Text);
					ShowActiveLibrary();
				}
				else if (ActiveNode.Level == 1)
				{
					oActiveLibrary = oBSLibCollection.GetLibrary(ActiveNode.Parent.Text);
					ShowSignal(ActiveNode.Text);
				}
			}
		}
		
		#endregion
		
		#endregion
		
		#region Public methods
		
		public void Set_UserLibrary(CS_BuiltInSignalLibrary UserLib)
		{
			foreach (CS_BuiltInSignalLibrary oLib in oBSLibCollection.Libraries)
			{
				if (oLib.Name.Equals(UserLib.Name))
				{
					return; //Library is already part of active libraries (BuiltInSignals.xml)
				}
			}
			
			oBSLibCollection.Libraries.Add(UserLib);
			AddLibrary(UserLib);
		}
		
		#endregion
	}
}
