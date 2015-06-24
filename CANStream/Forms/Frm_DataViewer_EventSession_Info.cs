/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/13/2014
 * Time: 12:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
