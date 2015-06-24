/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 7/17/2013
 * Time: 12:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

using SD_AppLicence;

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
			
			#if DEMO
			Txt_Product.Text = Application.ProductName + " DEMO Version";
			#else
			Txt_Product.Text = Application.ProductName;
			#endif
			
			Txt_Release.Text = Application.ProductVersion;
			Txt_Company.Text = Application.CompanyName;
			
			GetLicenceInformation();
		}
		
		#region Control events
		
		private void Cmd_LicenceRequestClick(object sender, EventArgs e)
		{
			AppLicenceObject oLicence = new AppLicenceObject(Application.StartupPath, ApplicationId, Application.ProductVersion);
			oLicence.RequestLicence();
		}
		
		private void Cmd_OKClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		#endregion
		
		#region Private methods
		
		private void GetLicenceInformation()
		{
			AppLicenceObject oLicence = new AppLicenceObject(Application.StartupPath, ApplicationId, Application.ProductVersion);
			
			if (oLicence.LicenseValid)
			{
				Txt_LicenceValid.Text = "Yes";	
			}
			else
			{
				Txt_LicenceValid.Text = "No";
				Txt_LicenceValid.ForeColor = Color.Red;
			}
			
			object[] Info = oLicence.GetLicenceInfo();
			
			DateTime StartDate = (DateTime)Info[1];
			double Duration = Convert.ToDouble(Info[2]);
			
			if (Duration < 2000)
			{
				DateTime EndDate = StartDate.AddDays(Duration);
				int RemainingDays = EndDate.Subtract(DateTime.Now).Days;
				
				Txt_LicenceExpiryDate.Text = EndDate.ToShortDateString();
				Txt_LicenceDaysRemaining.Text = RemainingDays.ToString() + " days";
				
				if (RemainingDays < 30) Cmd_LicenceRequest.Enabled = true;
				
				if (EndDate.CompareTo(DateTime.Now) < 0)
				{
					Txt_LicenceExpiryDate.BackColor = Color.Tomato;
					Txt_LicenceDaysRemaining.BackColor = Color.Tomato;
				}
			}
			else
			{
				Txt_LicenceExpiryDate.Text =  "Never";
				Txt_LicenceDaysRemaining.Text = "Infinity";
			}
			
		}
		
		#endregion
	}
}
