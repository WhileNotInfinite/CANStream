/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 2/13/2014
 * Time: 14:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;

namespace CANStream
{
	/// <summary>
	/// Description of Frm_VirtualChannelTest.
	/// </summary>
	public partial class Frm_VirtualChannelTest : Form
	{
		#region private members
		
		private Frm_VirtualChannel FormParent;
		
		private CS_VirtualChannel oChannel;
		private CS_VirtualChannelsLibrary oTestLibrary;
		private CS_VCLibrariesCollection oTestLibCollection;
		
		private bool bInit;
		private bool bExprModified;
		
		private string ChannelRefLibName;
		
		#endregion
		
		public Frm_VirtualChannelTest(Frm_VirtualChannel FrmParent, CS_VirtualChannel TestChannel)
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			FormParent = FrmParent;
			bExprModified = false;
			
			if (!(TestChannel == null))
			{
				oChannel = TestChannel;
				ChannelRefLibName = oChannel.ParentLibrary.Name;
				
				oTestLibrary = new CS_VirtualChannelsLibrary();
				oChannel.ParentLibrary = oTestLibrary;
				oTestLibrary.Channels.Add(oChannel);
				
				oTestLibCollection = new CS_VCLibrariesCollection();
				oTestLibCollection.AddLibrary(oTestLibrary);
			}
		}
		
		#region Control events
		
		#region Form
		
		private void Frm_VirtualChannelTestLoad(object sender, EventArgs e)
		{
			if (!(oChannel ==  null))
			{
				bInit = true;
				
				this.Text = "Test " + oChannel.Name;
				rTxt_ChannelExpression.Text = oChannel.Expression;
				EvaluateChannel();
				ShowVariableList();
				
				bInit = false;
			}
		}
		
		private void Frm_VirtualChannelTestFormClosing(object sender, FormClosingEventArgs e)
		{
			if (bExprModified & rTxt_ChannelExpression.BackColor.Equals(Color.LightGreen))
			{
				DialogResult Rep = MessageBox.Show("Expression has been modified, do you want set the new expression to the virtual channel ?",Application.ProductName,MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
				
				switch (Rep)
				{
					case DialogResult.Yes:
						SetChannelExpression();
						break;
					case DialogResult.No:
						e.Cancel=false;
						break;
					case DialogResult.Cancel:
						e.Cancel=true;
						break;
				}
			}
		}
		
		#endregion
		
		#region Grid_VariableValues
		
		private void Grid_VariableValuesCellValueChanged(object sender, DataGridViewCellEventArgs e)
		{			
			if (!bInit & e.RowIndex >=0)
			{
				if (!(Grid_VariableValues.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Equals("")))
				{
					double Val = 0;
					if (double.TryParse(Grid_VariableValues.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(),out Val))
					{
						if (oChannel.ComputationReady)
						{
							oTestLibCollection.SetVariableElement(Grid_VariableValues.Rows[e.RowIndex].Cells[e.ColumnIndex-1].Value.ToString(),Val);
							CalculateChannel();
						}
					}
				}
			}
		}
		
		#endregion
		
		#region rTxt_ChannelExpression
		
		private void RTxt_ChannelExpressionTextChanged(object sender, EventArgs e)
		{
			if (!bInit)
			{
				bExprModified = true;
				rTxt_ChannelExpression.BackColor = Color.LightPink;
			}
		}
		
		#endregion
		
		#region Buttons
		
		private void Cmd_TestClick(object sender, EventArgs e)
		{
			if (!(rTxt_ChannelExpression.Text.Equals("")))
			{
				oChannel.Expression = rTxt_ChannelExpression.Text;
				EvaluateChannel();
				ShowVariableList();
				
				if (bExprModified & oChannel.ComputationReady & !oChannel.InError)
				{
					rTxt_ChannelExpression.BackColor = Color.LightGreen;
				}
			}
		}
		
		private void Cmd_QuitClick(object sender, EventArgs e)
		{	
			this.Close();
		}
		
		private void Cmd_SetChanExprClick(object sender, EventArgs e)
		{
			SetChannelExpression();
		}

        #endregion

        private void Chk_FormatedResult_CheckedChanged(object sender, EventArgs e)
        {
            EvaluateChannel();
        }

        #endregion

        #region Private methods

        private void EvaluateChannel()
		{
			if (!(oChannel == null))
			{
				oChannel.InterpreteExpression();
				oChannel.bForceComputation = true;
				
				if (oChannel.ComputationReady)
				{
					CalculateChannel();
				}
				else
				{
					Txt_Result.Text = "ERROR !";
					rTxt_ErrorLog.Text = oChannel.ErrorMsg;
					rTxt_ErrorLog.BackColor = Color.Tomato;
				}
			}
		}
		
		private void CalculateChannel()
		{
			if (!(oChannel == null))
			{
				oChannel.ComputeChannelValue();
						
				if (!(oChannel.InError))
				{
                    if (Chk_FormatedResult.Checked)
                    {
                        Txt_Result.Text = oChannel.ValueFormat.GetSignalFormatedValue(oChannel.Value);

                        //Process parameter alarms
                        Nullable<SignalAlarmValue> sAlarm = oChannel.Alarms.GetAlarmProperties(oChannel.Alarms.ProcessAlarms(oChannel.Value));

                        if (sAlarm.HasValue) //Apply alarm style
                        {
                            Txt_Result.BackColor = sAlarm.Value.BackColor;
                            Txt_Result.ForeColor = sAlarm.Value.ForeColor;
                        }
                        else //Apply default style if no alarm
                        {
                            Txt_Result.BackColor = SystemColors.HotTrack;
                            Txt_Result.ForeColor = SystemColors.Info;
                        }
                    }
                    else
                    {
                        Txt_Result.Text = oChannel.Value.ToString();

                        Txt_Result.BackColor = SystemColors.HotTrack;
                        Txt_Result.ForeColor = SystemColors.Info;
                    }

                    rTxt_ErrorLog.Text = "";
					rTxt_ErrorLog.BackColor = SystemColors.Control;
				}
				else
				{
					Txt_Result.Text = "ERROR !";
					rTxt_ErrorLog.Text = oChannel.ErrorMsg;
					rTxt_ErrorLog.BackColor = Color.Tomato;
				}
			}
		}
		
		private void ShowVariableList()
		{
			Grid_VariableValues.Rows.Clear();
			
			int VarCnt = oTestLibCollection.GetVariableElementCount();
			
			if (VarCnt > 0)
			{
				for (int iVar=0; iVar<VarCnt; iVar++)
				{
					CS_VC_Variable oVar = oTestLibCollection.GetVariableAtIndex(iVar);
					
					if (!(oVar == null))
					{
						Grid_VariableValues.Rows.Add();
						Grid_VariableValues.Rows[iVar].Cells[0].Value = oVar.Name;
						Grid_VariableValues.Rows[iVar].Cells[1].Value = oVar.Value;
					}
				}
			}
		}
		
		private void SetChannelExpression()
		{
			if (!(FormParent.SetVirtualChannelExpression(ChannelRefLibName,oChannel.Name,oChannel.Expression)))
			{
				MessageBox.Show("Expression update error !\nChannel " + oChannel.Name 
				                + " or its host library " + ChannelRefLibName 
				                + " may have been modified or they may not exist anymore.",
				                Application.ProductName,MessageBoxButtons.OK,MessageBoxIcon.Error);
			}
			
			bExprModified =  false;
		}

        #endregion
    }
}
