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
using System.Windows.Forms;

namespace CANStream
{
	public enum RecordObjectSelectionMode
	{
		Event = 0,
		Session = 1,
	}
	
	/// <summary>
	/// Description of Frm_RecordSessionSelection.
	/// </summary>
	public partial class Frm_RecordEventSessionSelection : Form
	{
		#region Private members
		
		private Form FrmCaller;
		private RecordObjectSelectionMode eSelectionMode;
		
		private CS_RecordEventsCollection oEventCollection;
		private CS_RecordEvent oEvent;
		
		#endregion
		
		public Frm_RecordEventSessionSelection(Object oCollection, Form Caller, RecordObjectSelectionMode eMode)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			FrmCaller = Caller;
			eSelectionMode = eMode;
			
			switch (eSelectionMode)
			{
				case RecordObjectSelectionMode.Event:
					
					oEventCollection = (CS_RecordEventsCollection)oCollection;
					oEvent = null;
					
					Show_Events();
					
					break;
					
				case RecordObjectSelectionMode.Session:
					
					oEventCollection =  null;
					oEvent = (CS_RecordEvent)oCollection;
					
					Show_Sessions();
					
					break;
			}
		}
		
		#region Control events
		
		private void LV_SessionsDoubleClick(object sender, EventArgs e)
		{
			//Set_ActiveSession();
			Set_ActiveObject();
		}
		
		private void LV_SessionsKeyDown(object sender, KeyEventArgs e)
		{
			if(e.KeyCode.Equals(Keys.Enter))
			{
				//Set_ActiveSession();
				Set_ActiveObject();
			}
		}
		
		private void Cmd_SelectClick(object sender, EventArgs e)
		{
			//Set_ActiveSession();
			Set_ActiveObject();
		}
		
		private void Cmd_CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void Cmd_CreateNewClick(object sender, EventArgs e)
		{
			switch (eSelectionMode)
			{
				case RecordObjectSelectionMode.Event:
					
					{
						CS_RecordEvent oNewEvent = new CS_RecordEvent();
						((MainForm)FrmCaller).Set_ActiveRecordEvent(oNewEvent);
						
						Frm_RecordEventEdition Frm = new Frm_RecordEventEdition(oNewEvent, FrmCaller, true);
						Frm.Show();
					}
					
					break;
					
				case RecordObjectSelectionMode.Session:
					
					{
						Frm_RecordSessionEdition Frm = new Frm_RecordSessionEdition(oEvent, new CS_RecordSession(), FrmCaller, true);
						Frm.Show();
					}
					
					break;
			}
			
			this.Close();
		}
		
		#endregion
		
		#region Private methodes
		
		private void Set_ActiveObject()
		{
			switch (eSelectionMode)
			{
				case RecordObjectSelectionMode.Event:
					
					Set_ActiveEvent();
					break;
					
				case RecordObjectSelectionMode.Session:
					
					Set_ActiveSession();
					break;
			}
		}
		
		#region Event selection
		
		private void Show_Events()
		{
			this.Text = "Record event selection";
			Lbl_Info.Text = "Record events list";
			Cmd_CreateNew.Text = "New event";
			
			LV_Sessions.Items.Clear();
			LV_Sessions.Columns.Clear();
			
			LV_Sessions.Columns.Add("Name");
			LV_Sessions.Columns.Add("Date");
			
			foreach (CS_RecordEvent oEvent in oEventCollection.Events)
			{
				ListViewItem It = LV_Sessions.Items.Add(oEvent.Name);
				It.SubItems.Add(oEvent.StartingDate.ToShortDateString());
				
				for (int iInfo = 0; iInfo < oEvent.UserInfos.Informations.Count; iInfo++)
				{
					if (LV_Sessions.Columns.Count < (iInfo + 3))
					{
						LV_Sessions.Columns.Add("Info #" + (iInfo + 1).ToString());
					}
					
					It.SubItems.Add(oEvent.UserInfos.Informations[iInfo].Value);
					
					int i = 0;
					if (Math.DivRem(LV_Sessions.Items.Count, 2, out i) == 1)
					{
						It.BackColor = SystemColors.GradientInactiveCaption;
					}
				}
			}
			
			LV_Sessions.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
		}
		
		private void Set_ActiveEvent()
		{
			if (!(LV_Sessions.SelectedItems.Count == 0))
			{
				int iEvent = oEventCollection.Get_RecordEventIndex(LV_Sessions.SelectedItems[0].Text,
				                                                   DateTime.Parse(LV_Sessions.SelectedItems[0].SubItems[1].Text));
				
				if (iEvent != -1)
				{
					((MainForm)FrmCaller).Set_ActiveRecordEvent(oEventCollection.Events[iEvent]);
				}
				
				this.Close();
			}
			else
			{
				MessageBox.Show("No record event selected !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			
		}
		
		#endregion
		
		#region Session selection
		
		private void Show_Sessions()
		{
			this.Text = "Record session selection";
			Lbl_Info.Text = "Record sessions list";
			Cmd_CreateNew.Text = "New session";
			
			LV_Sessions.Items.Clear();
			LV_Sessions.Columns.Clear();
			
			LV_Sessions.Columns.Add("Name");
			LV_Sessions.Columns.Add("Date");
			
			foreach (CS_RecordSession oSession in oEvent.Sessions)
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
		
		private void Set_ActiveSession()
		{
			if (!(LV_Sessions.SelectedItems.Count == 0))
			{
				CS_RecordSession oActiveSession = oEvent.Get_RecordSession(LV_Sessions.SelectedItems[0].Text);
				
				if (!(oActiveSession == null))
				{
					oEvent.CurrentSession=oActiveSession;
					((MainForm)FrmCaller).Set_ActiveRecordEvent(oEvent);
				}
				
				this.Close();
			}
			else
			{
				MessageBox.Show("No record session selected !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		
		#endregion
		
		#endregion
	}
}
