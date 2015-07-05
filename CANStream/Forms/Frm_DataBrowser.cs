/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 7/28/2014
 * Time: 13:29 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
 
using Microsoft.Win32;

using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Frm_DataBrowser.
	/// </summary>
	public partial class Frm_DataBrowser : Form
	{
		#region Private members
	
		private Frm_DataViewer ParentViewer;
		
		private string RootPath;
		private string IntialFolder;
		
		#endregion
		
		public Frm_DataBrowser(Frm_DataViewer FrmCaller)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			ParentViewer = FrmCaller;
			RootPath = "";
		}
		
		public Frm_DataBrowser(Frm_DataViewer FrmCaller, string InitialPath)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			ParentViewer = FrmCaller;
			RootPath = "";
			IntialFolder = InitialPath;
		}
		
		#region Control events
		
		#region Form
		
		private void Frm_DataBrowserLoad(object sender, EventArgs e)
		{
			object PathRegKey = Registry.GetValue(CANStreamConstants.CS_REG_KEY + "\\DataViewer", "Folders", "");
			
			if (!(PathRegKey == null))
			{
				string PathList = PathRegKey.ToString();
				
				if (!(PathList.Equals("")))
				{
					string[] Pathes = PathList.Split('|');
					Cmb_RootFolder.Items.Clear();
					
					for (int i=0; i<Pathes.Length; i++)
					{
						if (!(Pathes[i].Equals("")))
						{
							//Cmb_RootFolder.Items.Insert(0, Pathes[i]);
							Cmb_RootFolder.Items.Add(Pathes[i]);
						}
					}
					
					Cmb_RootFolder.SelectedIndex = 0;
				}
			}
			
			if (!(IntialFolder.Equals("")))
			{
				Refresh_Browser(IntialFolder);
			}
		}
		
		private void Frm_DataBrowserFormClosing(object sender, FormClosingEventArgs e)
		{
			if (Cmb_RootFolder.Items.Count > 0)
			{
				string PathRegKey = CANStreamConstants.CS_REG_KEY + "\\DataViewer";
				int i = 0;
				string PathList = "";
				
				while (i < 10 && i < Cmb_RootFolder.Items.Count)
				{
					PathList = PathList + Cmb_RootFolder.Items[i].ToString() + "|";
					i++;
				}
				
				Registry.SetValue(PathRegKey, "Folders", PathList);
			}
		}
		
		#endregion
		
		private void Cmd_RootFolderClick(object sender, EventArgs e)
		{
			Dlg_FolderBrowser.SelectedPath = CANStreamTools.MyDocumentPath + "\\CANStream\\Records\\Data";
			
			if (Dlg_FolderBrowser.ShowDialog().Equals(DialogResult.OK))
			{				
				Cmb_RootFolder.Items.Insert(0, Dlg_FolderBrowser.SelectedPath);
				Cmb_RootFolder.SelectedIndex = 0;
			}
		}
		
		private void Cmb_RootFolderSelectedIndexChanged(object sender, EventArgs e)
		{
			RootPath = Cmb_RootFolder.Text;
			UpDate_FolderTree(RootPath);
		}
		
		#region TV_Folders
		
		private void TV_FoldersNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			Set_CurrentEvent(e.Node);
		}
		
		private void TV_FoldersKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					
					Set_CurrentEvent(TV_Folders.SelectedNode);
					break;
					
				case Keys.Delete:
					
					Delete_Item();
					break;
			}
		}
		
		#endregion
		
		#region LV_Session
		
		private void LV_SessionsMouseClick(object sender, MouseEventArgs e)
		{
			Set_CurrentSession();
		}
		
		private void LV_SessionsKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					
					Set_CurrentSession();
					break;
					
				case Keys.Delete:
					
					Delete_Item();
					break;
			}
		}
		
		#endregion
		
		#region LV_Files
		
		private void LV_FilesMouseDoubleClick(object sender, MouseEventArgs e)
		{
			Set_ViewerFileList();
		}
		
		private void LV_FilesKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					
					Set_ViewerFileList();
					break;
					
				case Keys.Delete:
					
					Delete_Item();
					break;
			}
		}
		
		#endregion
		
		#region Context TV_Folders
		
		private void DeleteEventToolStripMenuItemClick(object sender, EventArgs e)
		{
			Delete_Item();
		}
		
		#endregion
		
		#region Context_LV_Sessions
		
		private void EventDetailsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(LV_Sessions.SelectedItems.Count == 0))
			{
				if (!(LV_Sessions.SelectedItems[0].Group == null))
				{
					object[] ItemTag = (object[])LV_Sessions.SelectedItems[0].Tag;
					Frm_EventDetails Frm = new Frm_EventDetails(ItemTag[2]);
					Frm.Show();
				}
			}
		}
		
		private void DeleteSessionToolStripMenuItemClick(object sender, EventArgs e)
		{
			Delete_Item();
		}
		
		#endregion
		
		#region Context_LV_Files
		
		private void SessionDetailsToolStripMenuItemClick(object sender, EventArgs e)
		{
			if (!(LV_Files.SelectedItems.Count == 0))
			{
				object[] FileTag = (object[])LV_Files.SelectedItems[0].Tag;
				
				if (!(FileTag[1] == null))
				{
					Frm_EventDetails Frm = new Frm_EventDetails(FileTag[1]);
					Frm.Show();
				}
			}
		}
		
		private void DeleteToolStripMenuItemClick(object sender, EventArgs e)
		{
			Delete_Item();
		}
		
		#endregion
		
		#region Toolbar
		
		private void TSB_RefreshClick(object sender, EventArgs e)
		{
			Refresh_Browser();
		}
		
		private void TSB_LoadClick(object sender, EventArgs e)
		{
			Set_ViewerFileList();
		}
		
		private void TSB_DelFileClick(object sender, EventArgs e)
		{
			Delete_Item();
		}
		
		#endregion
		
		#endregion
		
		#region Private methodes
		
		private void UpDate_FolderTree(string fPath)
		{
			TV_Folders.Nodes.Clear();
			
			if (!(fPath.Equals("")))
			{
				DirectoryInfo oDirInfo = new DirectoryInfo(fPath);
				
				if (!(oDirInfo == null))
				{
					DirectoryInfo[] oSubDirInfos = oDirInfo.GetDirectories();
					
					if (!(oSubDirInfos == null))
					{
						foreach (DirectoryInfo oSubDir in oSubDirInfos)
						{
							TreeNode nDir = TV_Folders.Nodes.Add(oSubDir.Name, oSubDir.Name, 0, 1);
							nDir.Tag = oSubDir.FullName;
						}
					}
					
					UpDate_FileList(oDirInfo.FullName, null, null);
				}
			}
		}
		
		private void Extend_FolderNode(TreeNode nFolder)
		{
			if (!(nFolder == null))
			{
				DirectoryInfo oDirInfo = new DirectoryInfo(nFolder.Tag.ToString());
				
				if (!(oDirInfo == null))
				{
					DirectoryInfo[] oSubDirs = oDirInfo.GetDirectories();
					
					if (!(oSubDirs == null))
					{
						if (!(File.Exists(oDirInfo.FullName + "\\EventDetails.xml")))
						{
							foreach (DirectoryInfo oDir in oSubDirs)
							{
								TreeNode nSubDir = nFolder.Nodes.Add(oDir.Name, oDir.Name, 0 ,1);
								nSubDir.Tag = oDir.FullName;
							}
						}
						nFolder.Expand();
					}
				}
			}
		}
		
		private void Set_CurrentEvent(TreeNode EventNode)
		{
			if (!(EventNode == null))
			{
				if (EventNode.Nodes.Count == 0)
				{
					Extend_FolderNode(EventNode);
				}
				
				LV_Files.Items.Clear();
				UpDate_FileList(EventNode.Tag.ToString(), null, null);
				
				Update_SessionList(EventNode);
			}
		}
		
		private void Set_CurrentSession()
		{
			if (!(LV_Sessions.SelectedItems == null))
			{
				if (LV_Sessions.SelectedItems.Count > 0)
				{
					LV_Files.Items.Clear();
					
					object[] SessionTag = (object[])LV_Sessions.SelectedItems[0].Tag;
					
					if (!(SessionTag == null))
					{
						UpDate_FileList(SessionTag[0].ToString(), (CS_RecordSession)SessionTag[1], (CS_RecordEvent)SessionTag[2]);
					}
				}
			}
		}
		
		private void UpDate_FileList(string fPath, CS_RecordSession oSession, CS_RecordEvent oEvent)
		{
			ListViewGroup oSessionGrp = null;
			
			if (!(fPath.Equals("")))
			{
				DirectoryInfo oDirInfo = new DirectoryInfo(fPath);
				
				if (!(oSession == null))
				{
					oSessionGrp = new ListViewGroup("Session: " + oSession.Name);
					LV_Files.Groups.Add(oSessionGrp);
				}
				
				if (!(oDirInfo == null))
				{
					FileInfo[] oDirFiles = oDirInfo.GetFiles();
					LV_Files.Tag = fPath;
					
					if (!(oDirFiles == null))
					{
						foreach (FileInfo oFile in oDirFiles)
						{
							int iIcone = 0;
							
							if (oFile.Extension.Equals(".csv")) //Converted record file
							{
								iIcone = 2;
							}
							else if (oFile.Extension.Equals(".trc")) //Raw record file
							{
								iIcone = 3;
							}
							
							if (!(iIcone == 0))
							{
								ListViewItem ItFile = LV_Files.Items.Add(oFile.Name, iIcone);
								ItFile.SubItems.Add(oFile.LastWriteTime.ToShortDateString() + " " + oFile.LastWriteTime.ToShortTimeString());
								ItFile.SubItems.Add(CANStreamTools.GetScaledFileSize(oFile.Length));
								
								object[] FileTag = new object[3];
								FileTag[0] = oFile.FullName;
								FileTag[1] = oSession;
								FileTag[2] = oEvent;
								
								ItFile.Tag = FileTag;
								
								if (!(oSessionGrp == null)) ItFile.Group = oSessionGrp;
							}
						}
						
						Color_FileItems();
						
						LV_Files.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
					}
				}
			}
		}
		
		private void Color_FileItems()
		{
			int iItem = 0;
			
			foreach(ListViewItem It in LV_Files.Items)
			{
				int Rem = 0;
				Math.DivRem(iItem, 2, out Rem);
				iItem++;
				
				if (Rem == 0)
				{
					object[] ItTags = (object[])It.Tag;
					string FileExt = Path.GetExtension(ItTags[0].ToString());
					
					if (FileExt.Equals(".csv"))
					{
						It.BackColor = Color.PaleGreen;
					}
					else
					{
						It.BackColor = Color.LightPink;
					}
				}
				else
				{
					It.BackColor = LV_Files.BackColor;
				}
			}
		}
		
		private void Refresh_Browser()
		{
			Refresh_Browser("");
		}
		
		private void Refresh_Browser(string InitPath)
		{
			string ActivePath = InitPath;
			if (ActivePath.Equals("")) ActivePath = LV_Files.Tag.ToString();
			
			string[] ActivePathFolders = ActivePath.Split('\\');
			int iFolder = Cmb_RootFolder.Text.Split('\\').Length;
			
			UpDate_FolderTree(RootPath);
			
			if (iFolder < ActivePathFolders.Length -1)
			{
				TreeNode nFolder = TV_Folders.Nodes[ActivePathFolders[iFolder]];
				
				while (iFolder < ActivePathFolders.Length)
				{
					Extend_FolderNode(nFolder);
					iFolder++;
					
					if (iFolder < ActivePathFolders.Length)
					{
						nFolder = nFolder.Nodes[ActivePathFolders[iFolder]];
					}
				}
			}
			
			CS_RecordEvent oEvent = null;
			CS_RecordSession oSession =  null;
			
			if (File.Exists(ActivePath + "\\SessionDetails.xml"))
			{
				oSession = new CS_RecordSession();
				if (oSession.Load_RecordSessionInformationFile(ActivePath + "\\SessionDetails.xml"))
				{					
					if (File.Exists(Path.GetDirectoryName(ActivePath) + "\\EventDetails.xml"))
					{
						oEvent = new CS_RecordEvent();
						if (!(oEvent.Load_RecordEventInformationFile(Path.GetDirectoryName(ActivePath) + "\\EventDetails.xml")))
						{
							oEvent = null;
							oSession = null;
						}
					}
				}
				else
				{
					oSession = null;
				}
			}
			
			if (!(oEvent ==  null))
			{
				TreeNode nEvent = FindEventNode(Path.GetDirectoryName(ActivePath));
				
				if (!(nEvent ==  null))
				{
					Set_CurrentEvent(nEvent);
				}
			}
			
			LV_Files.Items.Clear();
			UpDate_FileList(ActivePath, oSession, oEvent);
		}
		
		private TreeNode FindEventNode(string EventPath)
		{
			foreach (TreeNode nFolder in TV_Folders.Nodes)
			{
				if (nFolder.Tag.ToString().Equals(EventPath))
				{
					return(nFolder);
				}
				else
				{
					if (nFolder.Nodes.Count > 0)
					{
						TreeNode nSubFolder = FindEventNode(EventPath);
						
						if (!(nSubFolder == null))
						{
							return(nSubFolder);
						}
					}
				}
			}
			
			return(null);
		}
		
		private void Set_ViewerFileList()
		{
			if (!(LV_Files.SelectedItems == null))
			{
				long TotalFilesSize = 0;
				int FilesLoadedCount = 0;
				
				ParentViewer.Reset_FileList(LV_Files.SelectedItems.Count);
				
				for (int iFile=0; iFile < LV_Files.SelectedItems.Count; iFile++)
				{
					object[] FileTag = (object[])LV_Files.SelectedItems[iFile].Tag;
					
					FileInfo oFile = new FileInfo(FileTag[0].ToString());
					TotalFilesSize += oFile.Length;
					
					if (TotalFilesSize <= CANStreamConstants.TextRecordDataFileSizeMax)
					{
						ParentViewer.Set_DataFilePath(FileTag[0].ToString(), iFile, (CS_RecordSession)FileTag[1], (CS_RecordEvent)FileTag[2]);
						FilesLoadedCount++;
					}
					else
					{
						MessageBox.Show("Maximum data size exceeded, file " + Path.GetFileName(FileTag[0].ToString()) + " cannot be loaded.", 
						                Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
						
						break;                
					}
				}
				
				if (FilesLoadedCount > 0)
				{
					Cursor = Cursors.WaitCursor;
					ParentViewer.Show_Data();
					Cursor = Cursors.Default;
					this.Close();
				}
				else
				{
					MessageBox.Show("No file loaded due to the maximum size limit.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}
		
		private void Update_SessionList(TreeNode nFolder)
		{
			LV_Sessions.Items.Clear();
			LV_Sessions.Groups.Clear();
			
			
			LV_Sessions.Columns.Clear();
			LV_Sessions.Columns.Add("Session");
			
			//LV_Files.Items.Clear();
			
			if (!(nFolder == null))
			{
				DirectoryInfo oDirInfo = new DirectoryInfo(nFolder.Tag.ToString());
				
				if (File.Exists(nFolder.Tag.ToString() + "\\EventDetails.xml")) //Folder is an event folder
				{
					Add_EventToSessionListView(nFolder.Tag.ToString());
				}
				else
				{
					if (!(oDirInfo == null))
					{
						DirectoryInfo[] oSubDirs = oDirInfo.GetDirectories();
						
						if (!(oSubDirs == null))
						{
							foreach (DirectoryInfo oDir in oSubDirs)
							{
								if (File.Exists(oDir.FullName + "\\EventDetails.xml"))
								{
									Add_EventToSessionListView(oDir.FullName);
								}
							}
						}
					}
				}
			}
		}
		
		private void Add_EventToSessionListView(string FolderPath)
		{
			CS_RecordEvent oEvent = new CS_RecordEvent();
			
			if (oEvent.Load_RecordEventInformationFile(FolderPath + "\\EventDetails.xml"))
			{
				ListViewGroup oEventGrp = new ListViewGroup(oEvent.Name + ": " + oEvent.StartingDate.ToShortDateString());
				LV_Sessions.Groups.Add(oEventGrp);
				
				DirectoryInfo oEventDir = new DirectoryInfo(FolderPath);
				DirectoryInfo[] oEventSubDirs = oEventDir.GetDirectories();
				
				foreach (DirectoryInfo oSessionDir in oEventSubDirs)
				{
					if (File.Exists(oSessionDir.FullName + "\\SessionDetails.xml"))
					{
						CS_RecordSession oSession = new CS_RecordSession();
						oSession.Load_RecordSessionInformationFile(oSessionDir.FullName + "\\SessionDetails.xml");
						
						ListViewItem oSessionItem = LV_Sessions.Items.Add(oSession.Name);
						
						foreach (CS_RecordUserInfo sInfo in oSession.UserInfos.Informations)
						{
							if (LV_Sessions.Columns.Count == oSessionItem.SubItems.Count)
							{
								LV_Sessions.Columns.Add("User info #" + oSessionItem.SubItems.Count.ToString());
							}
							
							oSessionItem.SubItems.Add(sInfo.Title + ": " + sInfo.Value);
						}
						
						object[] SessionTag = new object[3];
						SessionTag[0] = oSessionDir.FullName;
						SessionTag[1] = oSession;
						SessionTag[2] = oEvent;
							
						oSessionItem.Tag = SessionTag;
						oSessionItem.Group = oEventGrp;
						
						UpDate_FileList(oSessionDir.FullName, oSession, oEvent);
					}
				}
				
				LV_Sessions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
			}
		}
		
		private void Delete_Item()
		{
			DialogResult Rep;
			
			if (TV_Folders.Focused)
			{
				if (!(TV_Folders.SelectedNode == null))
				{
					Rep = MessageBox.Show("Do you really want remove selected record event from the disk ?",
					                      Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					
					if (Rep.Equals(DialogResult.Yes))
					{	
						Directory.Delete(TV_Folders.SelectedNode.Tag.ToString(), true);
						
						while (Directory.Exists(TV_Folders.SelectedNode.Tag.ToString()))
						{
							System.Threading.Thread.Sleep(1);
						}
						
						TV_Folders.Nodes.Remove(TV_Folders.SelectedNode);
						UpDate_FolderTree(RootPath);
					}
				}
			}
			else if (LV_Sessions.Focused)
			{
				if (LV_Sessions.SelectedItems.Count > 0)
				{
					Rep = MessageBox.Show("Do you really want remove selected record sessions from the disk ?",
					                      Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					
					if (Rep.Equals(DialogResult.Yes))
					{
						foreach (ListViewItem It in LV_Sessions.SelectedItems)
						{
							object[] ItTags = (object[])It.Tag;
							Directory.Delete(ItTags[0].ToString(), true);
							LV_Sessions.Items.Remove(It);
						}
						
						UpDate_FolderTree(RootPath);
					}
				}
			}
			else if (LV_Files.Focused)
			{
				if (LV_Files.SelectedItems.Count > 0)
				{
					Rep = MessageBox.Show("Do you really want remove selected files from the disk ?",
					                      Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					
					if (Rep.Equals(DialogResult.Yes))
					{
						foreach (ListViewItem It in LV_Files.SelectedItems)
						{
							object[] ItTags = (object[])It.Tag;
							File.Delete(ItTags[0].ToString());
							LV_Files.Items.Remove(It);
						}
						
						Color_FileItems();
					}
				}
			}
		}
		
		#endregion
	}
}
