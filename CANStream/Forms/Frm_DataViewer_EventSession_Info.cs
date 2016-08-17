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
	/// <summary>
	/// Description of Frm_DataViewer_EventSession_Info.
	/// </summary>
	public partial class Frm_DataViewer_EventSession_Info : Form
	{
		public Frm_DataViewer_EventSession_Info(List<CS_RecordEvent> EventList)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			TabCtrl_Events.TabPages.Clear();
			
			if (!(EventList == null))
			{
				foreach (CS_RecordEvent oEvent in EventList)
				{
					TabPage TabEvent = new TabPage(oEvent.Name);
					TabCtrl_Events.TabPages.Add(TabEvent);
					
					Ctrl_RecordEventInformation CtrlEvent = new Ctrl_RecordEventInformation(oEvent);
					
					TabEvent.Controls.Add(CtrlEvent);
					CtrlEvent.Location = new Point(0, 0);
					CtrlEvent.Size = new Size(TabEvent.Width, TabEvent.Height);
					CtrlEvent.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right);
				}
			}
		}
	}
}
