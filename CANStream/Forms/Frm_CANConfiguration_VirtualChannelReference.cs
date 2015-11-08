/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/31/2014
 * Time: 15:20 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Frm_CANConfiguration_VirtualChannelReference.
	/// </summary>
	public partial class Frm_CANConfiguration_VirtualChannelReference : Form
	{
		#region Private members
		
		CS_VCLibrariesCollection oVCLibCollection;
		Frm_CANConfiguration FrmCaller;
		
		#endregion
		
		public Frm_CANConfiguration_VirtualChannelReference(Frm_CANConfiguration Caller)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			FrmCaller = Caller;
			
			if (File.Exists(CANStreamTools.CsDataPath + "\\Libraries.xml"))
			{
				oVCLibCollection = new CS_VCLibrariesCollection();
				TV_VirtualChannels.Nodes.Clear();
				
				if (oVCLibCollection.LoadLibrariesList(CANStreamTools.CsDataPath + "\\Libraries.xml"))
				{
					foreach(CS_VirtualChannelsLibrary oLib in oVCLibCollection.Libraries)
					{
						TreeNode nLib = TV_VirtualChannels.Nodes.Add(oLib.Name, oLib.Name, 0, 0);
						nLib.Tag = "Library";
						
						foreach (CS_VirtualChannel oChan in oLib.Channels)
						{
							TreeNode nChan = nLib.Nodes.Add(oChan.Name, oChan.Name, 1, 1);
							nChan.Tag = "Channel";
							nChan.ToolTipText = oChan.Expression;
						}
					}
					
					TV_VirtualChannels.ExpandAll();
				}
			}
		}
		
		#region Control events
		
		private void Cmd_CancelClick(object sender, EventArgs e)
		{
			this.Close();
		}
		
		private void Cmd_OKClick(object sender, EventArgs e)
		{
			SetVirtualReference();
		}
		
		private void TV_VirtualChannelsNodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
		{
			SetVirtualReference();
		}
		
		#endregion
		
		#region Private methods
		
		private void SetVirtualReference()
		{
			if (!(TV_VirtualChannels.SelectedNode == null))
			{
				if (TV_VirtualChannels.SelectedNode.Tag.ToString() == "Channel")
				{
					VirtualParameter sReference = new VirtualParameter();
					sReference.LibraryName = TV_VirtualChannels.SelectedNode.Parent.Text;
					sReference.ChannelName = TV_VirtualChannels.SelectedNode.Text;
					
					CS_VirtualChannel oVirtual = oVCLibCollection.GetVirtualChannel(sReference.LibraryName, sReference.ChannelName);
					
					FrmCaller.SetVirtualChannelReference(sReference, oVirtual);
					this.Close();
				}
				else
				{
					MessageBox.Show("You current selection is a library not a virtual channel !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else
			{
				MessageBox.Show("You must select a virtual channel !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		
		#endregion
	}
}
