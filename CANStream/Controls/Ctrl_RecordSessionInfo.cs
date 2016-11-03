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
	/// Description of Ctrl_RecordSessionInfo.
	/// </summary>
	public partial class Ctrl_RecordSessionInfo : UserControl
	{
		public Ctrl_RecordSessionInfo(CS_RecordSession oSession)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			if (!(oSession == null))
			{
				Txt_SessionName.Text = oSession.Name;
				Txt_SessionDate.Text = oSession.SessionDate.ToLongDateString() + " " + oSession.SessionDate.ToShortTimeString();
				Txt_SessionComment.Text = oSession.Comment;
				
				LV_SessionUserInfo.Items.Clear();
				foreach (CS_RecordUserInfo sInfo in oSession.UserInfos.Informations)
				{
					ListViewItem It = LV_SessionUserInfo.Items.Add(sInfo.Title);
					It.SubItems.Add(sInfo.Value);
				}
				
			}
		}
	}
}
