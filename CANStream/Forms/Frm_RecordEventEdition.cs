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
	public partial class Frm_RecordEventEdition : Form
	{
		#region Private members
		
		private CS_RecordEvent oRecordEvent;
		private Form FrmParent;
		private bool bNewEvent;
		
		private string OriginalEventName;
		private DateTime OriginalEventDate;
		
		#endregion
		
		public Frm_RecordEventEdition(CS_RecordEvent RecEvent, Form Caller, bool NewEvent)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			oRecordEvent = RecEvent;
			FrmParent = Caller;
			bNewEvent = NewEvent;
			
			OriginalEventName = oRecordEvent.Name;
			OriginalEventDate = oRecordEvent.StartingDate;
			
			Show_EventProperties();
		}
		
		#region Control events
		
		#region TSB_Main
		
		private void TSB_ApplyClick(object sender, EventArgs e)
		{
			if (Set_EventProperties())
			{
				if (FrmParent.GetType().Equals(typeof(MainForm)))
				{
					((MainForm)FrmParent).UpDate_RecordEventSession();
				}
				
				this.Close();
			}
		}
		
		private void TSB_CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		#endregion
		
		#region TSB_Sessions
		
		private void TSB_NewRecordSessionClick(object sender, EventArgs e)
		{
			Create_NewSession();
		}
		
		private void TSB_DelRecordSessionClick(object sender, EventArgs e)
		{
			Delete_Session();
		}
		
		private void TSB_EditRecordSessionClick(object sender, EventArgs e)
		{
			Edit_RecordSession();
		}
		
		#endregion
		
		#region LV_Sessions
		
		private void LV_SessionsDoubleClick(object sender, EventArgs e)
		{
			Edit_RecordSession();
		}
		
		private void LV_SessionsKeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Enter:
					
					Edit_RecordSession();
					break;
					
				case Keys.Delete:
					
					Delete_Session();
					break;
			}
		}
		
		#endregion
		
		#endregion
		
		#region Private methodes
		
		private void Show_EventProperties()
		{
			//General properties
			Txt_EventName.Text = oRecordEvent.Name;
			DP_EventDate.Value = oRecordEvent.StartingDate;
			rTxt_EventComment.Text = oRecordEvent.Comment;
			
			//User info
			Ctrl_UserInfo.Set_UserInformations(oRecordEvent.UserInfos);
			
			//Record sessions
			Update_SessionList();
		}
		
		private bool Set_EventProperties()
		{
			if (!(Txt_EventName.Text.Equals("")))
			{
				oRecordEvent.Name = Txt_EventName.Text;
			}
			else
			{
				MessageBox.Show("Name of the record event cannot be empty !",Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				return(false);
			}
			
			oRecordEvent.StartingDate = DP_EventDate.Value;
			oRecordEvent.Comment = rTxt_EventComment.Text;
			
			//User infos
			oRecordEvent.UserInfos = Ctrl_UserInfo.Get_UserInformations();
			
			//Record session created in the event on the fly
			
			//Update application event list if new event
			string AppEventsFile = CANStreamTools.CsDataPath + "\\RecordEvents.xml";
			CS_RecordEventsCollection oAppEvents = new CS_RecordEventsCollection();
			
			if (File.Exists(AppEventsFile))
			{
				oAppEvents.Read_EventsCollectionFile(AppEventsFile);
			}
			
			if (bNewEvent)
			{
				oAppEvents.Events.Insert(0, oRecordEvent);
			}
			else
			{
				int EventId = oAppEvents.Get_RecordEventIndex(OriginalEventName, OriginalEventDate);
				
				if (EventId != -1)
				{
					oAppEvents.Events[EventId] = oRecordEvent;
				}
				else
				{
					oAppEvents.Events.Insert(0, oRecordEvent);
				}
			}
			
			oAppEvents.Write_EventsCollectionFile(AppEventsFile);
			
			return(true);
		}
		
		#region Event session
		
		private void Create_NewSession()
		{
			CS_RecordSession oSession = new CS_RecordSession();
			
			Frm_RecordSessionEdition FrmSession = new Frm_RecordSessionEdition(oRecordEvent,
			                                                                   oSession,
			                                                                   this as Form, true);
			
			FrmSession.Show();
		}
		
		private void Edit_RecordSession()
		{
			if (!(LV_Sessions.SelectedItems == null))
			{
				CS_RecordSession oSession = oRecordEvent.Get_RecordSession(LV_Sessions.SelectedItems[0].Text);
				
				if (!(oSession == null))
				{
					Frm_RecordSessionEdition FrmSession = new Frm_RecordSessionEdition(oRecordEvent,oSession, this as Form, false);
					FrmSession.Show();
				}
			}
		}
		
		private void Delete_Session()
		{
			if (!(LV_Sessions.SelectedItems == null))
			{
				int iSession = oRecordEvent.Get_SessionIndex(LV_Sessions.SelectedItems[0].Text);
				
				if (iSession >= 0)
				{
					DialogResult Rep = MessageBox.Show("Are you sure that you want delete the session: "
					                    + LV_Sessions.SelectedItems[0].Text + " ?", 
					                    Application.ProductName,
					                    MessageBoxButtons.YesNo,
					                    MessageBoxIcon.Question);
					
					if (Rep.Equals(DialogResult.Yes))
					{
						oRecordEvent.Sessions.RemoveAt(iSession);
						LV_Sessions.Items.Remove(LV_Sessions.SelectedItems[0]);
						Update_SessionList();
					}
				}
					
			}
		}
		
		#endregion
		
		#endregion
		
		#region Public methodes
		
		public void Update_SessionList()
		{
			LV_Sessions.Items.Clear();
			LV_Sessions.Columns.Clear();
			
			LV_Sessions.Columns.Add("Name");
			LV_Sessions.Columns.Add("Date");
			
			foreach (CS_RecordSession oSession in oRecordEvent.Sessions)
			{
				ListViewItem It = LV_Sessions.Items.Add(oSession.Name);
				
				It.SubItems.Add(oSession.SessionDate.ToShortDateString());
				
				for (int iInfo = 0; iInfo < oSession.UserInfos.Informations.Count; iInfo++)
				{
					if (LV_Sessions.Columns.Count < (iInfo + 3))
					{
						LV_Sessions.Columns.Add("Info #" + (iInfo + 1).ToString());
					}
					
					It.SubItems.Add(oSession.UserInfos.Informations[iInfo].Value);
				}
				
				int i = 0;
				if (Math.DivRem(LV_Sessions.Items.Count, 2, out i) == 1)
				{
					It.BackColor = SystemColors.GradientInactiveCaption;
				}
			}
			
			LV_Sessions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}
		
		#endregion
	}
}
