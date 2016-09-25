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
using System.Drawing;
using System.IO;
using System.Windows.Forms;

using Ctrl_GraphWindow;

namespace CANStream
{
	/// <summary>
	/// Data viewer form class
	/// </summary>
	public partial class Frm_DataViewer : Form
	{
		#region Private members
		
		private string[] DataFilePathes;
		private string LastFilePath;
		
		private GW_DataFile oConcatData;
		private CS_DataViewerBook ViewerBook;
		
		private string VCLibCollectionPath;
		private CS_VCLibrariesCollection VCLibraries;
		
		private int NextViewerPageKeyId;
		
		private TabPage ContextTabPage;
		
		private List<CS_RecordEvent> RecordEvents;
		
		#endregion
		
		public Frm_DataViewer(string VCLibsFile)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			DataFilePathes = null;
			LastFilePath = "";
			oConcatData = null;
			RecordEvents = new List<CS_RecordEvent>();
			
			ViewerBook = new CS_DataViewerBook();
			
			VCLibCollectionPath = VCLibsFile;
			VCLibraries = null;
			
			if (!(VCLibCollectionPath.Equals("")))
			{
				VCLibraries = new CS_VCLibrariesCollection();
				VCLibraries.LoadLibrariesList(VCLibCollectionPath);
			}
			
			NextViewerPageKeyId = 1;
			ContextTabPage = null;
			
			Dlg_OpenViewerBook.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Data Viewers";
			Dlg_OpenViewerPage.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Data Viewers";
			Dlg_SaveViewerBook.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Data Viewers";
			Dlg_SaveViewerPage.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\Data Viewers";
		}
		
		#region Control events
		
		#region Tab_Viewers
		
		private void Tab_ViewersMouseClick(object sender, MouseEventArgs e)
		{
			switch (e.Button)
			{
				case MouseButtons.Left:
					
					if (Tab_Viewers.SelectedTab.Equals(Tab_NewViewer))
					{
						NewViewerPage(-1, "", null);
					}
					
					break;
					
				case MouseButtons.Right:
					
					ContextTabPage = GetTabPageAtPosition(e.Location);
					
					if (!(ContextTabPage == null))
					{
						if (!(ContextTabPage.Equals(Tab_NewViewer)))
						{
							Context_TabViewers.Show(e.Location);
						}
						else
						{
							ContextTabPage = null;
						}
					}
					
					break;
			}
		}
		
		#endregion
		
		#region ToolBar
		
		private void TSB_DataBrowserClick(object sender, EventArgs e)
		{
			Open_DataBrowser();
		}
		
		private void TSB_NewViewerBookClick(object sender, EventArgs e)
		{
			New_DataViewerBook();
		}
		
		private void TSB_OpenViewerBookClick(object sender, EventArgs e)
		{
			Load_DataViewerBook();
		}
		
		private void TSB_SaveViewerBookClick(object sender, EventArgs e)
		{
			Save_DataViewerBook(true);
		}
		
		private void TSB_NewViewerPageClick(object sender, EventArgs e)
		{
			NewViewerPage(-1, "", null);
		}
		
		private void TSB_OpenViewerPageClick(object sender, EventArgs e)
		{
			OpenViewerPage();
		}
		
		private void TSB_SaveViewerPageClick(object sender, EventArgs e)
		{
			SaveViewerPage();
		}
		
		private void TSB_SaveAllViewerPagesClick(object sender, EventArgs e)
		{
			SaveAllViewerPages();
		}
		
		private void TSB_CloseViewerPageClick(object sender, EventArgs e)
		{
			DeleteViewerPage();
		}

        private void TSB_CopyViewerPage_Click(object sender, EventArgs e)
        {
            if (!(Tab_Viewers.SelectedTab.Equals(Tab_NewViewer)))
            {
                CopyPage(Tab_Viewers.SelectedTab);
            }
        }

        private void TSB_PastViewerPage_Click(object sender, EventArgs e)
        {
            PastPage();
        }
		
        private void TSB_VirtualChannelsClick(object sender, EventArgs e)
		{
        	Edit_VirtualChannels();
		}
        
		private void TSB_EventSessionInfoClick(object sender, EventArgs e)
		{
			if (RecordEvents.Count > 0)
			{
				Frm_DataViewer_EventSession_Info Frm = new Frm_DataViewer_EventSession_Info(RecordEvents);
				Frm.Show();
			}
		}
		
		#endregion
		
		#region Context_TabViewers
		
		private void TSMI_CtxtTab_RenameClick(object sender, EventArgs e)
		{
			if (!(ContextTabPage == null))
			{
                int PageIndex = GetPageIndex(ContextTabPage);

                if (PageIndex != -1)
                {
                    Rectangle TabRec = Tab_Viewers.GetTabRect(PageIndex);

                    TextBox TxtNewName = new TextBox();
                    TxtNewName.KeyDown += new KeyEventHandler(TxtNewName_KeyDown);
                    TxtNewName.LostFocus += new EventHandler(TxtNewName_LostFocus);

                    TxtNewName.Location = this.PointToScreen(TabRec.Location);
                    TxtNewName.Size = new Size(TabRec.Width * 2, TabRec.Height);
                    TxtNewName.Text = ContextTabPage.Text;
                    TxtNewName.SelectAll();

                    this.Controls.Add(TxtNewName);
                    TxtNewName.BringToFront();
                    TxtNewName.Focus();
                }
			}
			
		}
		
		private void TSMI_CtxtTab_CloseClick(object sender, EventArgs e)
		{
			if (!(ContextTabPage == null))
			{
				DeleteViewerPage(ContextTabPage);
			}
		}
		
		private void TSMI_CtxtTab_MoveLeftClick(object sender, EventArgs e)
		{
			if (!(ContextTabPage == null))
			{
				int PageIndex =  Tab_Viewers.TabPages.IndexOf(ContextTabPage);
				
				if (!(PageIndex == 0))
				{
					NewViewerPage(PageIndex - 1, ContextTabPage.Text, ((Ctrl_WaveForm)ContextTabPage.Controls[0]).Properties);
					Tab_Viewers.TabPages.Remove(ContextTabPage);
					ContextTabPage = null;
				}
			}
		}
		
		private void TSMI_CtxtTab_MoveRightClick(object sender, EventArgs e)
		{
			if (!(ContextTabPage == null))
			{
				int PageIndex =  Tab_Viewers.TabPages.IndexOf(ContextTabPage);
				
				if (!(PageIndex == Tab_Viewers.TabPages.Count - 2))
				{
					NewViewerPage(PageIndex + 2, ContextTabPage.Text, ((Ctrl_WaveForm)ContextTabPage.Controls[0]).Properties);
					Tab_Viewers.TabPages.Remove(ContextTabPage);
					ContextTabPage = null;
				}
			}
		}

        private void TSMI_CtxtTab_Copy_Click(object sender, EventArgs e)
        {
            CopyPage(ContextTabPage);
        }

        private void TSMI_CtxtTab_Past_Click(object sender, EventArgs e)
        {
            PastPage();
        }

		#region TxtNewName
		
		private void TxtNewName_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Escape))
			{
				TextBox TxtNewName = (TextBox)sender;
				
				if (e.KeyCode.Equals(Keys.Enter))
				{
					if (!(TxtNewName.Text.Equals("")))
					{
						ContextTabPage.Text = TxtNewName.Text;
						
						CS_DataViewerPage oPage = ViewerBook.Get_DataViewerPage((int)ContextTabPage.Tag);
						
						if (!(oPage == null))
						{
							oPage.Name = TxtNewName.Text;
							ViewerBook.bModified = true;
						}
					}
				}
				
				this.Controls.Remove(TxtNewName);
				TxtNewName.Dispose();
			}
		}
		
		private void TxtNewName_LostFocus(object sender, EventArgs e)
		{
			TextBox TxtNewName = (TextBox)sender;
			this.Controls.Remove(TxtNewName);
			TxtNewName.Dispose();
		}
		
		#endregion
		
		#endregion
		
		#endregion
		
		#region Private methodes
		
		#region DataViewerBook
		
		private void New_DataViewerBook()
		{
			if (ViewerBook.bModified)
			{
				DialogResult Rep = MessageBox.Show("The current data viewer book has been modified, do you want save it prior opening a new one ?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				
				switch (Rep)
				{
					case DialogResult.Yes:
						
						Save_DataViewerBook(false);
						break;
						
					case DialogResult.No:
						
						break;
						
					case DialogResult.Cancel:
						
						return;
				}
			}
			
			Close_AllViewerPages();
			ViewerBook.Pages.Clear();
			NextViewerPageKeyId = 1;
		}
		
		private void Load_DataViewerBook()
		{
			if (ViewerBook.bModified)
			{
				DialogResult Rep = MessageBox.Show("The current data viewer book has been modified, do you want save it prior opening a new one ?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
				
				switch (Rep)
				{
					case DialogResult.Yes:
						
						Save_DataViewerBook(false);
						break;
						
					case DialogResult.No:
						
						break;
						
					case DialogResult.Cancel:
						
						return;
				}
			}
			
			if (Dlg_OpenViewerBook.ShowDialog().Equals(DialogResult.OK))
			{
				ViewerBook = new CS_DataViewerBook();
				
				if (ViewerBook.Read_BookFile(Dlg_OpenViewerBook.FileName))
				{
					Show_DataViewerBook();
				}
				else
				{
					MessageBox.Show("Data viewer book file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		
		private void Save_DataViewerBook(bool RequestPath)
		{
			if (ViewerBook.FilePath.Equals("") || RequestPath)
			{
				if (RequestPath) Dlg_SaveViewerBook.FileName = Path.GetFileName(ViewerBook.FilePath);
				
				if (Dlg_SaveViewerBook.ShowDialog().Equals(DialogResult.OK))
				{
					Write_DataViewerBook(Dlg_SaveViewerBook.FileName);
				}
			}
			else
			{
				Write_DataViewerBook(ViewerBook.FilePath);
			}
		}
		
		private void Show_DataViewerBook()
		{
			Close_AllViewerPages();
					
			for (int iPage=0; iPage<ViewerBook.Pages.Count; iPage++)
			{
				NewViewerPage(iPage, ViewerBook.Pages[iPage].Name, ViewerBook.Pages[iPage].GraphicProperties);
			}
			
			if (Tab_Viewers.TabPages.Count > 1)
			{
				Tab_Viewers.SelectedTab = Tab_Viewers.TabPages[0];
			}
		}
		
		private void Close_AllViewerPages()
		{
			while (Tab_Viewers.TabPages.Count > 1)
			{
				if (!(Tab_Viewers.TabPages[0].Equals(Tab_NewViewer)))
				{
					Tab_Viewers.TabPages.RemoveAt(0);
				}
			}
		}
		
		private void Write_DataViewerBook(string fPath)
		{
			ViewerBook.Pages.Clear();
			
			foreach (TabPage oTab in Tab_Viewers.TabPages)
			{
				if (!(oTab.Equals(Tab_NewViewer)))
				{
					CS_DataViewerPage oPage = new CS_DataViewerPage();
					
					oPage.Name = oTab.Text;
					oPage.KeyId = (int)oTab.Tag;
					oPage.GraphicProperties =  ((Ctrl_WaveForm)oTab.Controls[0]).Properties;
					
					ViewerBook.Pages.Add(oPage);
				}
			}
			
			ViewerBook.Write_BookFile(fPath);
		}
		
		#region DataViewerPages
		
		private void NewViewerPage(int PageIndex, string PageName, GraphWindowProperties WaveProps)
		{
			TabPage NewPage = new TabPage();
			
			if (PageName.Equals("")) PageName = "Page " + Tab_Viewers.TabPages.Count.ToString();
			NewPage.Text = PageName;
			NewPage.Tag = NextViewerPageKeyId;
			NextViewerPageKeyId ++;
			
			Ctrl_WaveForm oWaveDisp = new Ctrl_WaveForm();
			
			//oWaveDisp.Set_OpenFileVisible(false);
            oWaveDisp.OpenFileVisible = false;
            if (!(WaveProps == null)) oWaveDisp.Properties = WaveProps;
			oWaveDisp.Left = 0;
			oWaveDisp.Top = 0;
			oWaveDisp.Width = NewPage.Width;
			oWaveDisp.Height = NewPage.Height;
			oWaveDisp.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right | AnchorStyles.Bottom);
			
			NewPage.Controls.Add(oWaveDisp);
			
			if (PageIndex == -1) PageIndex = Tab_Viewers.TabPages.Count - 1;
			Tab_Viewers.TabPages.Insert(PageIndex, NewPage);
			Tab_Viewers.SelectedTab = NewPage;
			
			if (!(oConcatData == null))
			{
				oWaveDisp.Set_DataFile(oConcatData);
				oWaveDisp.Refresh_Graphic();
			}
			
			ViewerBook.bModified = true;
		}
		
		private void OpenViewerPage()
		{
			if (Dlg_OpenViewerPage.ShowDialog().Equals(DialogResult.OK))
			{
				GraphWindowProperties oProps = new GraphWindowProperties();
				
				if (oProps.Open_Properties(Dlg_OpenViewerPage.FileName))
				{
					NewViewerPage(-1, "", oProps);
				}
				else
				{
					MessageBox.Show("Data viewer page file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		
		private void SaveViewerPage()
		{
			if (!(Tab_Viewers.SelectedTab == null))
			{
				Ctrl_WaveForm oActiveGraphWindow = (Ctrl_WaveForm)Tab_Viewers.SelectedTab.Controls[0];
				
				if (oActiveGraphWindow.Properties.FilePath.Equals(""))
				{
					if (Dlg_SaveViewerPage.ShowDialog().Equals(DialogResult.OK))
					{
						oActiveGraphWindow.Properties.FilePath = Dlg_SaveViewerPage.FileName;
					}
					else
					{
						return;
					}
				}
				
				oActiveGraphWindow.Properties.Save_Properties(oActiveGraphWindow.Properties.FilePath);
			}
		}
		
		private void SaveAllViewerPages()
		{
			foreach (TabPage oTab in Tab_Viewers.TabPages)
			{
				if (!(oTab.Equals(Tab_NewViewer)))
				{
					Ctrl_WaveForm oWave = (Ctrl_WaveForm)oTab.Controls[0];
					
					if (oWave.Properties.FilePath.Equals(""))
					{
						if (Dlg_SaveViewerPage.ShowDialog().Equals(DialogResult.OK))
						{
							oWave.Properties.FilePath = Dlg_SaveViewerPage.FileName;
						}
					}
					
					if (!(oWave.Properties.FilePath.Equals("")))
					{
						oWave.Properties.Save_Properties(oWave.Properties.FilePath);
					}
				}
			}
		}
		
		private void DeleteViewerPage()
		{
			DeleteViewerPage(null);
		}
		
		private void DeleteViewerPage(TabPage Page)
		{
			if (Page == null)
			{
				Page = Tab_Viewers.SelectedTab;
			}
			
			if (!(Page == null))
			{
				CS_DataViewerPage oViewerPage = ViewerBook.Get_DataViewerPage((int)Page.Tag);
				
				if (!(oViewerPage == null))
				{
					if (oViewerPage.GraphicProperties.bModified)
					{
						DialogResult Rep = MessageBox.Show("Data viewer page has been modified, do you want save the modification ?", Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
						
						switch (Rep)
						{
							case DialogResult.Yes:
								
								SaveViewerPage();
								break;
								
							case DialogResult.No:
								
								break;
								
							case DialogResult.Cancel:
								
								return;
						}
					}
					
					ViewerBook.bModified = true;
				}
				//Else page has never been saved..
				
				Tab_Viewers.TabPages.Remove(Page);
			}
		}

        private void CopyPage(TabPage Page)
        {
            if (!(Page == null))
            {
                CS_DataViewerPage oClipPage = new CS_DataViewerPage();
                oClipPage.Name = Page.Text;
                oClipPage.GraphicProperties = ((Ctrl_WaveForm)Page.Controls[0]).Properties.Get_Clone();

                DataFormats.Format oFormat = DataFormats.GetFormat(typeof(CS_DataViewerPage).FullName);
                IDataObject ClipDataObj = new DataObject();
                ClipDataObj.SetData(oFormat.Name, false, oClipPage);
                Clipboard.SetDataObject(ClipDataObj, false);

                TSMI_CtxtTab_Past.Enabled = true;
                TSB_PastViewerPage.Enabled = true;
            }
        }

        private void PastPage()
        {
            CS_DataViewerPage oClipPage = null;
            IDataObject ClipDataObj = Clipboard.GetDataObject();
            string sFormat = typeof(CS_DataViewerPage).FullName;

            if (ClipDataObj.GetDataPresent(sFormat))
            {
                oClipPage = ClipDataObj.GetData(sFormat) as CS_DataViewerPage;

                if (!(oClipPage == null))
                {
                    NewViewerPage(-1, GetViewerPageCopyName(oClipPage.Name), oClipPage.GraphicProperties);
                }
            }
            else
            {
                TSMI_CtxtTab_Past.Enabled = false;
                TSB_PastViewerPage.Enabled = false;
            }
        }

        private string GetViewerPageCopyName(string BaseName)
        {
            int Indice = 0;
            bool PageExists = true;

            while (PageExists)
            {
                PageExists = false;
                Indice++;

                for (int i = 0; i < Tab_Viewers.TabPages.Count; i++)
                {
                    if (Tab_Viewers.TabPages[i].Text.Equals(BaseName + " " + Indice.ToString()))
                    {
                        PageExists = true;
                        break;
                    }
                }
            }

            return (BaseName + " " + Indice.ToString());
        }

        private int GetPageIndex(TabPage oPage)
        {
            for (int iPage = 0; iPage < Tab_Viewers.TabPages.Count; iPage++)
            {
                if (Tab_Viewers.TabPages[iPage].Equals(oPage))
                {
                    return (iPage);
                }
            }

            return (-1);
        }

		#endregion
		
		#endregion
		
		#region DataFile
		
		private void Load_DataFiles()
		{
			LastFilePath = "";
			
			if (!(DataFilePathes == null))
			{
				GW_DataFile[] oDataFiles = new GW_DataFile[DataFilePathes.Length];
                bool XmlDataFile = Path.GetExtension(DataFilePathes[0]).Equals(".xrdf");


                for (int iFile=0; iFile < DataFilePathes.Length; iFile++)
				{
					oDataFiles[iFile] = new GW_DataFile();

                    if (XmlDataFile)
                    {
                        oDataFiles[iFile].Load_XmlDataFile(DataFilePathes[iFile], false);
                    }
                    else
                    {
                        oDataFiles[iFile].Load_DataFile(DataFilePathes[iFile]);
                    }
				}

                if (XmlDataFile)
                {
                    UpDate_PagesSeries(oDataFiles[0]);
                }
                else
                {
                    UpDate_PagesSeries(Concat_DataFiles(oDataFiles));
                }

                LastFilePath = Path.GetDirectoryName(DataFilePathes[DataFilePathes.Length -1]);
			}
		}
		
		private GW_DataFile Concat_DataFiles(GW_DataFile[] oDataFiles)
		{
			bool bComputeVirtuals =  false;
			
			if (oDataFiles == null)
			{
				return(null);
			}
			
			//Virtual channels libraries initialization
			if (!(VCLibraries == null))
			{
				VCLibraries.InitLibrariesComputation();
				bComputeVirtuals = true;
			}
			
			//Complete channel list creation
			List<string> ChannelList = new List<string>();
			foreach (GW_DataFile oFile in oDataFiles)
			{
				foreach(GW_DataChannel oChan in oFile.Channels)
				{
					if (!(ChannelList.Contains(oChan.Name)))
					{
						ChannelList.Add(oChan.Name);
					}
				}
			}
			
			//Concatened data file creation
			oConcatData = new GW_DataFile();
			foreach (string sChan in ChannelList)
			{
				GW_DataChannel oChan = new GW_DataChannel();
				oChan.Name = sChan;
				oConcatData.Channels.Add(oChan);
			}
			
			//Data file concatenation
			double Concat_T = 0;
			bool bFirstSample = true;
			
			foreach (GW_DataFile oFile in oDataFiles)
			{
                if(bFirstSample)
                {
                    oConcatData.StepTimeMin = oFile.StepTimeMin;
                    oConcatData.StepTimeMax = oFile.StepTimeMax;
                }
                else
                {
                    if (oFile.StepTimeMin < oConcatData.StepTimeMin) oConcatData.StepTimeMin = oFile.StepTimeMin;
                    if (oFile.StepTimeMax > oConcatData.StepTimeMax) oConcatData.StepTimeMax = oFile.StepTimeMax;
                }

                for (int iSample = 0; iSample < oFile.Time.Values.Count; iSample++)
				{
					//Time value
					if (!bFirstSample) //Not the first sample of the concatenated data file
					{
						if (!(iSample == 0)) //Not the first sample of the file
						{
							Concat_T += (oFile.Time.Values[iSample] - oFile.Time.Values[iSample - 1]);
						}
						else //First sample of the file
						{
							Concat_T += oFile.StepTimeMin;
						}
					}
					
					oConcatData.Time.Add_ChannelValue(Concat_T);
					
					//Data
					foreach (string sChan in ChannelList)
					{
						GW_DataChannel oDataChan = oConcatData.Get_DataChannel(sChan);
						GW_DataChannel oSrcChan = oFile.Get_DataChannel(sChan);
						
						if (!(oSrcChan == null))
						{
							oDataChan.Add_ChannelValue(oSrcChan.Values[iSample]);
							
							if (bComputeVirtuals)
							{
								VCLibraries.UpDateVariableElement(oDataChan.Name, oSrcChan.Values[iSample]);
							}
						}
						else
						{
							oDataChan.Values.Add(0); //Default value if channel is missing in the current data file
							
							if (bComputeVirtuals)
							{
								VCLibraries.UpDateVariableElement(oDataChan.Name, 0);
							}
						}
					}
					
					//Virtual channels
					if (bComputeVirtuals)
					{
						VCLibraries.ComputeLibraries();
						
						foreach(CS_VirtualChannelsLibrary oLib in VCLibraries.Libraries)
						{
							foreach(CS_VirtualChannel oVirtual in oLib.Channels)
							{
								if (!(ChannelList.Contains(oVirtual.Name)))
								{
									GW_DataChannel oVirtualDataChan = oConcatData.Get_DataChannel(oVirtual.Name);
									
									if (oVirtualDataChan == null && oVirtual.bNewValue) //The virtual channel doesn't exist in the data file and it has a value
									{
										oVirtualDataChan = new GW_DataChannel(oVirtual.Name);
										
										if (oConcatData.DataChannelExists(oVirtual.Name))
										{
											oVirtualDataChan.Name = Name_VirtualChannel(oVirtual.Name);
										}
										
										oConcatData.Channels.Add(oVirtualDataChan);
									}
									
									if (!(oVirtualDataChan == null))
									{
										if (!(oVirtual.InError || double.IsNaN(oVirtual.Value)))
										{
											oVirtualDataChan.Add_ChannelValue(oVirtual.Value);
										}
										else
										{
											oVirtualDataChan.Add_ChannelValue(0);
										}
									}
								}
								
								oVirtual.bNewValue = false;
							}
						}
					}
					
					bFirstSample = false;
				}
			}
			
			oDataFiles = null; //Free up memory
			return(oConcatData);
		}
		
		private void UpDate_PagesSeries(GW_DataFile oData)
		{
			foreach (TabPage oPage in Tab_Viewers.TabPages)
			{
				if (!(oPage.Equals(Tab_NewViewer)))
				{
					Ctrl_WaveForm oWave = oPage.Controls[0] as Ctrl_WaveForm;
					
					oWave.Set_DataFile(oData);
					oWave.Refresh_Graphic();
				}
			}
		}
		
		private string Name_VirtualChannel(string BaseName)
		{
			int i = 0;
			string FinalName = "Virtual_" + BaseName;
			
			while (oConcatData.DataChannelExists(FinalName))
			{
				i++;
				FinalName = "Virtual_" + BaseName + "_" + i.ToString("00");
			}
			
			return(FinalName);
		}
		
		#endregion
		
		#region Misc
		
		private void Open_DataBrowser()
		{
			Frm_DataBrowser Frm = new Frm_DataBrowser(this, LastFilePath);
			Frm.Show();
		}
		
		private void Edit_VirtualChannels()
		{
			Frm_VirtualChannel Frm = new Frm_VirtualChannel(this);
        	Frm.Show();
		}
		
		#endregion
		
		#region Tools
		
		private TabPage GetTabPageAtPosition(Point Location)
		{
			for (int i=0; i<Tab_Viewers.TabPages.Count; i++)
			{
				Rectangle TabRec = Tab_Viewers.GetTabRect(i);
				
				if ((Location.X >= TabRec.Left && Location.X < TabRec.Left + TabRec.Width)
				    && (Location.Y >= TabRec.Top && Location.Y < TabRec.Top + TabRec.Height))
				{
					return(Tab_Viewers.TabPages[i]);
				}
			}
			
			return(null);
		}
		
		#endregion
		
		#region Event/Session
		
		private bool EventExists(string EventName)
		{
			foreach (CS_RecordEvent Evt in RecordEvents)
			{
				if (Evt.Name.Equals(EventName))
				{
					return(true);
				}
			}
			
			return(false);
		}
		
		private CS_RecordEvent GetEvent(string EventName)
		{
			foreach (CS_RecordEvent Evt in  RecordEvents)
			{
				if (Evt.Name.Equals(EventName))
				{
					return(Evt);
				}
			}
			return(null);
		}
		
		private void AddEvent(CS_RecordEvent Evt)
		{
			CS_RecordEvent oEvent = new CS_RecordEvent();
			
			oEvent.Sessions.Clear();
			
			oEvent.Name = Evt.Name;
			oEvent.StartingDate = Evt.StartingDate;
			oEvent.Comment = Evt.Comment;
			
			foreach (CS_RecordUserInfo sInfo in Evt.UserInfos.Informations)
			{
				CS_RecordUserInfo rui = new CS_RecordUserInfo();
				rui.Title = sInfo.Title;
				rui.Value = sInfo.Value;
				
				oEvent.UserInfos.Informations.Add(rui);
			}
			
			RecordEvents.Add(oEvent);
		}
		
		#endregion
		
		#endregion
		
		#region Public methodes
		
		public void Reset_FileList(int FileCount)
		{
			if (FileCount > 0)
			{
				DataFilePathes = new string[FileCount];
			}

            RecordEvents.Clear();
		}
		
		public void Set_DataFilePath(string fPath, int Index, CS_RecordSession oSession, CS_RecordEvent oEvent)
		{
			if (!(fPath.Equals("") || Index < 0 || Index >= DataFilePathes.Length))
			{
				DataFilePathes[Index] = fPath;
				
				if (!(oEvent == null || oSession == null))
				{
					CS_RecordEvent CurrentEvent = null;	
					
					if (EventExists(oEvent.Name))
					{
						CurrentEvent = GetEvent(oEvent.Name);
					}
					else
					{
						AddEvent(oEvent);
						CurrentEvent = GetEvent(oEvent.Name);
					}
					
					if (!(CurrentEvent.RecordSessionExists(oSession.Name)))
					{
						CurrentEvent.Sessions.Add(oSession.Clone());
					}
				}
			}    
		}

		public void Show_Data()
		{
			Load_DataFiles();
		}
		
		public bool Set_ViewBook(string BookFilePath)
		{
			if (!(BookFilePath.Equals("")))
			{
				ViewerBook = new CS_DataViewerBook();
				
				if (ViewerBook.Read_BookFile(BookFilePath))
				{
					Show_DataViewerBook();
					return (true);
				}
				else
				{
					MessageBox.Show("Data viewer book file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			
			return(false);
		}
		
		public void Reset_VirtualChannels()
		{
			if (!(VCLibCollectionPath.Equals("")))
			{
				VCLibraries = new CS_VCLibrariesCollection();
				
				if (VCLibraries.LoadLibrariesList(VCLibCollectionPath))
				{
					Load_DataFiles();
				}
			}
		}
		
		#endregion
	}
}
