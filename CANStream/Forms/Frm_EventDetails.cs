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
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Frm_EventDetails.
	/// </summary>
	public partial class Frm_EventDetails : Form
	{
		public Frm_EventDetails(object DetailObject)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			CS_RecordEvent oEvent = null;
			CS_RecordSession oSession = null;
			
			if (DetailObject.GetType().Equals(typeof(CS_RecordEvent)))
			{
				oEvent = (CS_RecordEvent)DetailObject;
				
				this.Text = "Event details";
				
				Txt_Name.Text = oEvent.Name;
				Txt_Date.Text = oEvent.StartingDate.ToLongDateString();
				rTxt_Comment.Text = oEvent.Comment;
				
				LV_Info.Items.Clear();
				foreach (CS_RecordUserInfo sInfo in oEvent.UserInfos.Informations)
				{
					ListViewItem It = LV_Info.Items.Add(sInfo.Title);
					It.SubItems.Add(sInfo.Value);
				}
				
			}
			else if (DetailObject.GetType().Equals(typeof(CS_RecordSession)))
			{
				oSession = (CS_RecordSession)DetailObject;
				
				this.Text = "Session details";
				
				Txt_Name.Text = oSession.Name;
				Txt_Date.Text = oSession.SessionDate.ToLongDateString();
				rTxt_Comment.Text = oSession.Comment;
				
				LV_Info.Items.Clear();
				foreach (CS_RecordUserInfo sInfo in oSession.UserInfos.Informations)
				{
					ListViewItem It = LV_Info.Items.Add(sInfo.Title);
					It.SubItems.Add(sInfo.Value);
				}
			}
			else
			{
				this.Close();
			}
		}
	}
}
