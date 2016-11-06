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
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using NumberBaseConversion;

namespace CANStream
{
	/// <summary>
	/// Description of Frm_CycleRecordImport.
	/// </summary>
	public partial class Frm_CycleRecordImport : Form
	{
		#region Private constants
		
		private const int FRM_HEIGHT_NO_PROGRESS = 290;
		private const int FRM_HEIGHT_PROGRESS = 401;
		private const int CMD_TOP_NO_PROGRESS = 230;
		private const int CMD_TOP_PROGRESS = 338;
		
		#endregion
		
		#region Private members
		
		private int FileProcessedCnt;
		
		#endregion
		
		public Frm_CycleRecordImport()
		{
			InitializeComponent();
			
			Cmd_Create.Top = CMD_TOP_NO_PROGRESS;
			Cmd_Cancel.Top = CMD_TOP_NO_PROGRESS;
			this.Height = FRM_HEIGHT_NO_PROGRESS;
			
			//Set tooltips to their corresponding controls
			TT_Cmd_AddTrcFiles.SetToolTip((Control)Cmd_AddTrcFiles, "Add trace record files");
			TT_Cmd_DelTrcFiles.SetToolTip((Control)Cmd_DelTrcFiles, "Remove trace record files");
			TT_Cmd_ClearTrcFiles.SetToolTip((Control)Cmd_ClearTrcFiles, "Clear trace record files");
			TT_Cmd_OpenCanCfg.SetToolTip((Control)Cmd_OpenCanCfg, "Set cycle CAN configuration");
			TT_Cmd_CycleOutFile.SetToolTip((Control)Cmd_CycleOutFile, "Set output cycle file name");
			
		}
		
		#region Control events
		
		#region Command buttons
		
		private void Cmd_AddTrcFilesClick(object sender, EventArgs e)
		{
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.Filter = "PCAN Trace record file|*.trc";
			Dlg_OpenFile.Multiselect = true;
			Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Records\\Raw";
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				foreach(string fPath in Dlg_OpenFile.FileNames)
				{
					Lst_TrcFiles.Items.Add(fPath);
				}
			}
		}
		
		private void Cmd_DelTrcFilesClick(object sender, EventArgs e)
		{
			if (!(Lst_TrcFiles.SelectedItems == null))
			{
				while (Lst_TrcFiles.SelectedItems.Count > 0)
				{
					Lst_TrcFiles.Items.Remove(Lst_TrcFiles.SelectedItems[0]);
				}
			}
		}
		
		private void Cmd_ClearTrcFilesClick(object sender, EventArgs e)
		{
			if (MessageBox.Show("Do you really want to remove all trace record files ?", 
			                    Application.ProductName, MessageBoxButtons.YesNo,
			                    MessageBoxIcon.Question).Equals(DialogResult.Yes))
			{
				Lst_TrcFiles.Items.Clear();
			}
		}
		
		private void Cmd_OpenCanCfgClick(object sender, EventArgs e)
		{
			Dlg_OpenFile.FileName = "";
			Dlg_OpenFile.Filter = "CAN Configuration|*.xcc";
			Dlg_OpenFile.Multiselect = false;
			Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				Txt_CanConfig.Text=Dlg_OpenFile.FileName;
			}
		}
		
		private void Cmd_CycleOutFileClick(object sender, EventArgs e)
		{
			Dlg_SaveFile.FileName = "";
			Dlg_SaveFile.Filter = "CAN Strem cycle|*.csc";
			Dlg_SaveFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Cycles";
			
			if (Dlg_SaveFile.ShowDialog().Equals(DialogResult.OK))
			{
				Txt_CycleOut.Text = Dlg_SaveFile.FileName;
			}
		}
		
		private void Cmd_CancelClick(object sender, EventArgs e)
		{
			if (BGW_TraceImport.IsBusy)
			{
				BGW_TraceImport.CancelAsync();
			}
			
			this.Close();
		}
		
		private void Cmd_CreateClick(object sender, EventArgs e)
		{
			object[] ImportOptions = new object[3];
			
			if (!(Lst_TrcFiles.Items.Count == 0))
			{
				string[] TrcFiles = new string[Lst_TrcFiles.Items.Count];
				
				for (int i=0; i<Lst_TrcFiles.Items.Count; i++)
				{
					TrcFiles[i] = Lst_TrcFiles.Items[i].ToString();
				}
				
				ImportOptions[0] = TrcFiles;
			}
			else
			{
				MessageBox.Show("Trace record file list is empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			CANMessagesConfiguration oCanCfg = new CANMessagesConfiguration();
			
			if (!(Txt_CanConfig.Text.Equals("")))
			{
				if (!(oCanCfg.ReadCANConfigurationFile(Txt_CanConfig.Text)))
				{
					MessageBox.Show("CAN configuration file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}
			}
			else
			{
				MessageBox.Show("No CAN Configuration defined, cycle will be created using default CAN bus properties", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			
			ImportOptions[1] = oCanCfg;
			
			if (!(Txt_CycleOut.Text.Equals("")))
			{
				ImportOptions[2] = Txt_CycleOut.Text;
			}
			else
			{
				MessageBox.Show("Output cycle file name is empty", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			
			this.Height = FRM_HEIGHT_PROGRESS;
			Cmd_Cancel.Top = CMD_TOP_PROGRESS;
			Cmd_Create.Top = CMD_TOP_PROGRESS;
			
			FileProcessedCnt = -1;
			Lbl_TrcFileListProgress.Visible = true;
			Lbl_TrcFileListProgress.Text = "File 0 of " + Lst_TrcFiles.Items.Count.ToString()
											+ ": " + Path.GetFileName(Lst_TrcFiles.Items[0].ToString());
			
			Lbl_TrcFileProcessingProgress.Visible = true;
			Lbl_TrcFileProcessingProgress.Text = "0 %";
			
			PB_TrcFileListProgress.Visible = true;
			PB_TrcFileListProgress.Value = 0;
			
			PB_TrcFileProcessingProgress.Visible = true;
			PB_TrcFileProcessingProgress.Value = 0;
			
			BGW_TraceImport.RunWorkerAsync(ImportOptions);
		}
		
		#endregion
		
		#region BGW_TraceImport
		
		private void BGW_TraceImportDoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorker Worker = sender as BackgroundWorker;
			ImportTrcFiles(Worker, e.Argument);
		}
		
		private void BGW_TraceImportProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			if (e.ProgressPercentage == 0)
			{
				FileProcessedCnt++;
				
				Lbl_TrcFileListProgress.Text = "File " + FileProcessedCnt.ToString() 
											+  " of " + Lst_TrcFiles.Items.Count.ToString()
											+ ": " + Path.GetFileName(Lst_TrcFiles.Items[FileProcessedCnt].ToString());
				
				PB_TrcFileListProgress.Value = (int)(FileProcessedCnt * 100 / Lst_TrcFiles.Items.Count);
			}
			
			Lbl_TrcFileProcessingProgress.Text = e.ProgressPercentage.ToString() + " %";
			PB_TrcFileProcessingProgress.Value = e.ProgressPercentage;
		}
		
		private void BGW_TraceImportRunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			this.Height = FRM_HEIGHT_NO_PROGRESS;
			Cmd_Cancel.Top = CMD_TOP_NO_PROGRESS;
			Cmd_Create.Top = CMD_TOP_NO_PROGRESS;
			
			Lbl_TrcFileListProgress.Visible = false;
			Lbl_TrcFileProcessingProgress.Visible = false;
			PB_TrcFileListProgress.Visible = false;
			PB_TrcFileProcessingProgress.Visible = false;
			
			if (!e.Cancelled)
			{
				MessageBox.Show("Cycle created !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		
		#endregion
		
		#endregion
		
		#region private methodes
		
		private void ImportTrcFiles(BackgroundWorker Worker, object ImportOptions)
		{
			if (!(ImportOptions == null))
			{
				object[] Options = (object[])ImportOptions;
				
				if (Options.Length == 3)
				{
					string[] TrcFileList = (string[])Options[0];
					CANMessagesConfiguration oCanCfg = (CANMessagesConfiguration) Options[1];
					string CyclePath = (string)Options[2];
					
					CANStreamCycle oCycle = new CANStreamCycle();
					oCycle.oCanNodesMap = oCanCfg;
					
					long CycleTime = 0;
					
					foreach (string TrcFile in TrcFileList)
					{
						PcanTrcFile oTrace = new PcanTrcFile(TrcFile);
						
						long TraceTime = 0;
						int iRecord = 0;
						
						int Progress = 0;
						Worker.ReportProgress(Progress);
						
						while (iRecord < oTrace.Records.Count)
						{
							CycleTimeEvent oCycleTxEvt = new CycleTimeEvent();
							oCycleTxEvt.TimeEvent = CycleTime;
							
							while((long)oTrace.Records[iRecord].TimeOffset == TraceTime)
							{
								CANMessageData oMsgData = new CANMessageData();
								
								oMsgData.uMessageId = (uint)(NumberBaseConverter.Hex2Dec(oTrace.Records[iRecord].MessageIdentifier));
								oMsgData.byteMessageData = oTrace.Records[iRecord].MessageData;
								
								oCycleTxEvt.MessagesData.Add(oMsgData);
								
								iRecord++;
								if (iRecord == oTrace.Records.Count) break;
							}
							
							if (oCycleTxEvt.MessagesData.Count > 0)
							{
								oCycle.TimeEvents.Add(oCycleTxEvt);
							}
							
							TraceTime++;
							CycleTime++;
							
							Progress = (int)(iRecord*100/oTrace.Records.Count);
							if (Progress > 0) Worker.ReportProgress(Progress);
						}
					}
					
					oCycle.WriteStreamCycle(CyclePath);
				}
			}
		}
		
		#endregion
	}
}
