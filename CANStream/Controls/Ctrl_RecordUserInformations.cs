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
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Ctrl_RecordUserInformations.
	/// </summary>
	public partial class Ctrl_RecordUserInformations : UserControl
	{
		#region Public members
		
		/// <summary>
		/// Record user informations collection
		/// </summary>
		public CS_RecordUserInfoCollection UserInformations;
		
		#endregion
		
		#region Private members
		
		private CS_RecordUserInfoCollection oUserInfoClipBoard;
		
		#endregion
		
		public Ctrl_RecordUserInformations()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			UserInformations = new CS_RecordUserInfoCollection();
			oUserInfoClipBoard = null;
		}
		
		#region Control events
			
		#region Control
		
		private void Ctrl_RecordUserInformationsLoad(object sender, EventArgs e)
		{
			Resize_GridColumns();
		}
		
		private void Ctrl_RecordUserInformationsSizeChanged(object sender, EventArgs e)
		{
			Resize_GridColumns();
		}
		
		#endregion
		
		#region TSB_UserInfos
		
		private void TSB_NewUserInfoClick(object sender, EventArgs e)
		{
			Add_UserInfo();
		}
		
		private void TSB_DelUserInfoClick(object sender, EventArgs e)
		{
			Delete_UserInfo();
		}
		
		private void TSB_CopyUserInfoClick(object sender, EventArgs e)
		{
			Copy_UserInfo();
		}
		
		private void TSB_PasteInformationClick(object sender, EventArgs e)
		{
			Paste_UserInfo();
		}
		
		private void TSB_ImportUserInfoClick(object sender, EventArgs e)
		{
			Import_UserInfo();
		}
		
		private void TSB_ExportUserInfoClick(object sender, EventArgs e)
		{
			Export_UserInfo();
		}
		
		#endregion
		
		#region Grid_UserInfos
		
		private void Grid_UserInfosKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Delete:
					
					Delete_UserInfo();
					break;
					
				case Keys.C:
					
					if (e.Control)
					{
						Copy_UserInfo();
					}
					
					break;
					
				case Keys.V:
					
					if (e.Control)
					{
						Paste_UserInfo();
					}
					
					break;
			}
		}
		
		#endregion
		
		#endregion
		
		#region Private methodes
		
		private void Add_UserInfo()
		{
			Grid_UserInfos.Rows.Add();
			
			DataGridViewRow oRow = Grid_UserInfos.Rows[Grid_UserInfos.Rows.Count-2];
			oRow.Cells[0].Value = "User info " + (Grid_UserInfos.Rows.Count - 1).ToString();
		}
		
		private void Delete_UserInfo()
		{
			if (!(Grid_UserInfos.SelectedRows == null))
			{
				foreach(DataGridViewRow oRow in Grid_UserInfos.SelectedRows)
				{
					Grid_UserInfos.Rows.Remove(oRow);
				}
			}
		}
		
		private void Copy_UserInfo()
		{
			if (!(Grid_UserInfos.SelectedCells == null))
			{
				oUserInfoClipBoard = new CS_RecordUserInfoCollection();
				
				foreach (DataGridViewRow oRow in Grid_UserInfos.SelectedRows)
				{
					if (!(oRow.Cells[0].Value == null))
					{
						CS_RecordUserInfo sInfo = new CS_RecordUserInfo();
						sInfo.Title = oRow.Cells[0].Value.ToString();
						
						if (!(oRow.Cells[1].Value == null))
						{
							sInfo.Value = oRow.Cells[1].Value.ToString();
						}
						
						oUserInfoClipBoard.Informations.Add(sInfo);
					}
				}
			}
		}
		
		private void Paste_UserInfo()
		{
			if (!(oUserInfoClipBoard == null))
			{
				foreach(CS_RecordUserInfo sInfo in oUserInfoClipBoard.Informations)
				{
					Grid_UserInfos.Rows.Add();
					
					DataGridViewRow oRow = Grid_UserInfos.Rows[Grid_UserInfos.Rows.Count-2];
					oRow.Cells[0].Value = sInfo.Title;
					oRow.Cells[1].Value = sInfo.Value;
				}
				
				oUserInfoClipBoard = null;
			}
		}
		
		private void Import_UserInfo()
		{
			Dlg_OpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CANStream\\Record User Information";
			
			if (Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
			{
				CS_RecordUserInfoCollection  oInfoCollection = new CS_RecordUserInfoCollection();
				
				if (oInfoCollection.Load_UserInfoCollection(Dlg_OpenFile.FileName))
				{
					Grid_UserInfos.Rows.Clear();
					
					foreach(CS_RecordUserInfo sInfo in oInfoCollection.Informations)
					{
						Grid_UserInfos.Rows.Add();
						DataGridViewRow oRow = Grid_UserInfos.Rows[Grid_UserInfos.Rows.Count - 2];
						oRow.Cells[0].Value = sInfo.Title;
						oRow.Cells[1].Value = sInfo.Value;
					}
				}
				else
				{
					MessageBox.Show("User information file reading error !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
		}
		
		private void Export_UserInfo()
		{
			Dlg_SaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\CANStream\\Record User Information";
			
			if (Dlg_SaveFile.ShowDialog().Equals(DialogResult.OK))
			{
				CS_RecordUserInfoCollection  oInfoCollection = new CS_RecordUserInfoCollection();
				
				foreach (DataGridViewRow oRow in Grid_UserInfos.Rows)
				{
					if (!(oRow.Cells[0].Value == null))
					{
						CS_RecordUserInfo sInfo = new CS_RecordUserInfo();
						sInfo.Title = oRow.Cells[0].Value.ToString();
						
						if (!(oRow.Cells[1].Value == null))
						{
							sInfo.Value = oRow.Cells[1].Value.ToString();
						}
						
						oInfoCollection.Informations.Add(sInfo);
					}
						
				}

				oInfoCollection.Write_UserInfoCollection(Dlg_SaveFile.FileName);
			}
		}
		
		private void Resize_GridColumns()
		{
			Grid_UserInfos.Columns[0].Width = (int)((Grid_UserInfos.Width - Grid_UserInfos.RowHeadersWidth) * 0.2) - 1;
			Grid_UserInfos.Columns[1].Width = (int)((Grid_UserInfos.Width - Grid_UserInfos.RowHeadersWidth) * 0.8) - 1;
		}
		
		#endregion
		
		#region Public methodes
		
		/// <summary>
		/// Return the user inforamtions collection hosted by the control
		/// </summary>
		/// <returns>User inforamtions collection hosted by the control</returns>
		public CS_RecordUserInfoCollection Get_UserInformations()
		{
			UserInformations = new CS_RecordUserInfoCollection();
			
			foreach(DataGridViewRow oRow in Grid_UserInfos.Rows)
			{
				if (!(oRow.Cells[0].Value == null))
				{
					CS_RecordUserInfo sInfo = new CS_RecordUserInfo();
					sInfo.Title = oRow.Cells[0].Value.ToString();
					
					if (!(oRow.Cells[1].Value == null))
					{
						sInfo.Value = oRow.Cells[1].Value.ToString();
					}
					
					UserInformations.Informations.Add(sInfo);
				}
			}
			
			return(UserInformations);
		}
		
		/// <summary>
		/// Set the user inforamtions collection to be  hosted by the control
		/// </summary>
		/// <param name="oInformations">User inforamtions collection to be  hosted by the control</param>
		public void Set_UserInformations(CS_RecordUserInfoCollection oInformations)
		{
			Grid_UserInfos.Rows.Clear();
			
			if (!(oInformations == null))
			{
				UserInformations = oInformations;
				
				foreach (CS_RecordUserInfo sInfo in UserInformations.Informations)
				{
					if (!(sInfo.Title.Equals("")))
					{
						Grid_UserInfos.Rows.Add();
						DataGridViewRow oRow = Grid_UserInfos.Rows[Grid_UserInfos.Rows.Count - 2];
						
						oRow.Cells[0].Value = sInfo.Title;
						oRow.Cells[1].Value = sInfo.Value;
					}
					
				}
			}
		}
		
		#endregion
	}
}
