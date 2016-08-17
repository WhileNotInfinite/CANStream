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
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Frm_About.
	/// </summary>
	public partial class Frm_About : Form
	{
		#region Private members
		
		private int ApplicationId;
		
		#endregion
		
		public Frm_About(int AppId)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			ApplicationId = AppId;
			
			this.Text = "About " + Application.ProductName;

            Txt_Product.Text = Application.ProductName;
            Txt_Release.Text = Application.ProductVersion;
			Txt_Company.Text = Application.CompanyName;
		}
		
		#region Control events
		
		private void Cmd_OKClick(object sender, EventArgs e)
		{
			this.Close();
		}

        private void LkLbl_HomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "http://canstream.hebergratuit.net/wp/";
            p.Start();
        }

        private void LkLbl_GitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process p = new Process();
            p.StartInfo.FileName = "https://github.com/WhileNotInfinite/CANStream";
            p.Start();
        }

        #endregion
    }
}
