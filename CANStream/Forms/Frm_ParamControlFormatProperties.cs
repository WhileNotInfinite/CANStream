using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANStream
{
    public partial class Frm_ParamControlFormatProperties : Form
    {
        #region Private members

        private SignalFormatProperties oRefFormat;

        private bool FrmClosing;

        #endregion

        public Frm_ParamControlFormatProperties(SignalFormatProperties oFormat, SignalValueFormat SelectedFormat)
        {
            string DefaultText = "";

            InitializeComponent();

            switch(SelectedFormat)
            {
                case SignalValueFormat.Button:

                    Lbl_CtrlOnValue.Text = "Control ON Value (Pressed)";
                    Lbl_CtrlOffValue.Text = "Control OFF Value (Released)";

                    DefaultText = "Button";

                    break;

                case SignalValueFormat.Checkbox:

                    Lbl_CtrlOnValue.Text = "Control ON Value (Checked)";
                    Lbl_CtrlOffValue.Text = "Control OFF Value (Unchecked)";

                    DefaultText = "Checkbox";

                    break;

                default:

                    Lbl_CtrlText.Enabled = false;
                    Txt_CtrlText.Enabled = false;

                    Lbl_CtrlOnValue.Enabled = false;
                    Txt_CtrlOnValue.Enabled = false;

                    Lbl_CtrlOffValue.Enabled = false;
                    Txt_CtrlOffValue.Enabled = false;

                    Cmd_OK.Enabled = false;

                    break;
            }

            oRefFormat = oFormat;

            FrmClosing = false;

            if(oFormat.sControlProperties.HasValue)
            {
                Txt_CtrlText.Text = oFormat.sControlProperties.Value.Text;
                Txt_CtrlOnValue.Text = oFormat.sControlProperties.Value.On_Value.ToString();
                Txt_CtrlOffValue.Text = oFormat.sControlProperties.Value.Off_Value.ToString();
            }
            else
            {
                Txt_CtrlText.Text = DefaultText;
                Txt_CtrlOnValue.Text = "1";
                Txt_CtrlOffValue.Text = "0";
            }
        }

        #region Control events

        #region Form

        private void Frm_ParamControlFormatProperties_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmClosing = true;
        }

        private void Frm_ParamControlFormatProperties_Deactivate(object sender, EventArgs e)
        {
            if (!(FrmClosing))
            {
                MessageBox.Show("Please apply or cancel changes prior to switch to another window.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }
        }

        #endregion

        #region Command buttons

        private void Cmd_OK_Click(object sender, EventArgs e)
        {
            SignalControlFormatProperties sCtrlProps = new SignalControlFormatProperties();

            int Val = 0;

            sCtrlProps.Text = Txt_CtrlText.Text;

            if(!(Txt_CtrlOnValue.Text.Equals("")))
            {
                if(int.TryParse(Txt_CtrlOnValue.Text,out Val))
                {
                    sCtrlProps.On_Value = Val;
                }
                else
                {
                    MessageBox.Show("Field 'On value' should be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Field 'On value' is empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            

            if (!(Txt_CtrlOffValue.Text.Equals("")))
            {
                if (int.TryParse(Txt_CtrlOffValue.Text, out Val))
                {
                    sCtrlProps.Off_Value = Val;
                }
                else
                {
                    MessageBox.Show("Field 'Off value' should be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            else
            {
                MessageBox.Show("Field 'Off value' is empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            oRefFormat.sControlProperties = sCtrlProps;
            this.Close();
        }

        private void Cmd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #endregion
    }
}
