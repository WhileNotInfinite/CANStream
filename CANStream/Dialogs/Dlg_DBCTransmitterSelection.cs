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
