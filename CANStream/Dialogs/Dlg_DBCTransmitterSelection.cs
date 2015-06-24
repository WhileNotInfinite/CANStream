/*
 * Created by SharpDevelop.
 * User: Vincent
 * Date: 13/03/2015
 * Time: 15:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// DBC transmitter/receiver selection dialog box class
	/// </summary>
	public partial class Dlg_DBCTransmitterSelection : Form
	{
		#region Public members
		
		public string SelectedDevice;
		
		#endregion
		
		#region Private members
		
		private static Dlg_DBCTransmitterSelection MsgBox;
		
		#endregion
		
		public Dlg_DBCTransmitterSelection()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			SelectedDevice = "";
		}
		
		#region Control events
		
		private void Cmd_OKClick(object sender, EventArgs e)
		{
			SelectedDevice = Cmb_Devices.SelectedItem.ToString();
			MsgBox.Close();
		}
		
		private void Cmd_CancelClick(object sender, EventArgs e)
		{
			MsgBox.Close();
		}
		
		#endregion
		
		#region Public methods
		
		public static string Show(string Title, string Text, string[] Devices)
		{
			MsgBox = new Dlg_DBCTransmitterSelection();
			
			MsgBox.Text = Title;
			MsgBox.Lbl_Text.Text = Text;
			
			MsgBox.Cmb_Devices.Items.Clear();
			MsgBox.Cmb_Devices.Items.AddRange(Devices);
			MsgBox.Cmb_Devices.Items.Add("None");
			MsgBox.Cmb_Devices.SelectedIndex = 0;
			
			MsgBox.ShowDialog();
			return(MsgBox.SelectedDevice);
		}
		
		#endregion
	}
}
