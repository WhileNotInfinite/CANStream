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
	/// Description of Ctrl_EventInformation.
	/// </summary>
	public partial class Ctrl_RecordEventInformation : UserControl
	{
		public Ctrl_RecordEventInformation(CS_RecordEvent oEvent)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if  (!(oEvent == null))
			{
				Txt_EventName.Text = oEvent.Name;
				Txt_EventDate.Text = oEvent.StartingDate.ToLongDateString();
				Txt_EventComment.Text = oEvent.Comment;
				
				LV_EventUserInfo.Items.Clear();
				foreach (CS_RecordUserInfo sInfo in oEvent.UserInfos.Informations)
				{
					ListViewItem It = LV_EventUserInfo.Items.Add(sInfo.Title);
					It.SubItems.Add(sInfo.Value);
				}
				
				TabCtrl_Sessions.TabPages.Clear();
				foreach (CS_RecordSession oSession in oEvent.Sessions)
				{
					TabPage SessionTab = new TabPage(oSession.Name);
					TabCtrl_Sessions.TabPages.Add(SessionTab);
					
					Ctrl_RecordSessionInfo SessionInfoCtrl = new Ctrl_RecordSessionInfo(oSession);
					
					SessionTab.Controls.Add(SessionInfoCtrl);
					SessionInfoCtrl.Location = new Point(0, 0);
					SessionInfoCtrl.Size = new Size(SessionTab.Width, SessionTab.Height);
					SessionInfoCtrl.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
				}
			}
		}
	}
}
