/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/10/2014
 * Time: 17:02 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
