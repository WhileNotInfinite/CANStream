/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/13/2014
 * Time: 11:46 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
