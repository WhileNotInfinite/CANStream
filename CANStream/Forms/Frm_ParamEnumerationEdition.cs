using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CANStream
{
    public partial class Frm_ParamEnumerationEdition : Form
    {
        #region Private members

        private SignalFormatProperties oRefFormat;
        private SignalFormatProperties oCurrentFormat;

        private int NextEnumValue;
        private bool FrmClosing;
        
        #endregion

        public Frm_ParamEnumerationEdition(SignalFormatProperties oFormat)
        {
            InitializeComponent();

            oRefFormat = oFormat;
            oCurrentFormat = oRefFormat.Get_Clone();

            NextEnumValue = 0;
            FrmClosing = false;

            Show_EnumValues();
        }

        #region Control events

        private void Frm_ParamEnumerationEdition_FormClosing(object sender, FormClosingEventArgs e)
        {
            FrmClosing = true;
        }

        private void Frm_ParamEnumerationEdition_Deactivate(object sender, EventArgs e)
        {
            if (!(FrmClosing))
            {
                MessageBox.Show("Please apply or cancel changes prior to switch to another window.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Activate();
            }
        }

        #region Toolbar

        private void TSB_Apply_Click(object sender, EventArgs e)
        {
            if (Set_EnumValues())
            {
                oRefFormat.Enums.Clear();

                foreach (EnumerationValue sEnum in oCurrentFormat.Enums)
                {
                    oRefFormat.Enums.Add(sEnum);
                }

                this.Close();
            }
        }

        private void TSB_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TSB_Add_Eum_Click(object sender, EventArgs e)
        {
            Add_EnumValue();
        }

        private void TSB_Del_Enum_Click(object sender, EventArgs e)
        {
            Del_EnumValues();
        }

        private void TSB_Clear_Enum_Click(object sender, EventArgs e)
        {
            Clear_EnumValues();
        }

        #endregion

        #region Context_Grid

        private void TSMI_Add_Value_Click(object sender, EventArgs e)
        {
            Add_EnumValue();
        }

        private void TSMI_Del_Value_Click(object sender, EventArgs e)
        {
            Del_EnumValues();
        }

        private void TSMI_Clear_Value_Click(object sender, EventArgs e)
        {
            Clear_EnumValues();
        }

        #endregion

        #endregion

        #region Private methodes
        
        private void Show_EnumValues()
        {
            Grid_Enum.Rows.Clear();

            foreach (EnumerationValue sEnum in oCurrentFormat.Enums)
            {
                Grid_Enum.Rows.Add();
                DataGridViewRow oRow = Grid_Enum.Rows[Grid_Enum.Rows.Count - 1];

                oRow.Cells[0].Value = sEnum.Value.ToString();
                oRow.Cells[1].Value = sEnum.Text;

                NextEnumValue++;
            }
        }

        private bool Set_EnumValues()
        {
            SignalFormatProperties oBackupFormat = oCurrentFormat.Get_Clone();
            oCurrentFormat.Enums.Clear();

            foreach (DataGridViewRow oRow in Grid_Enum.Rows)
            {
                EnumerationValue sEnum = new EnumerationValue();

                int EnumVal;
                if (!(oRow.Cells[0].Value == null))
                {
                    if (int.TryParse(oRow.Cells[0].Value.ToString(), out EnumVal))
                    {
                        if (!(EnumValueExists(EnumVal)))
                        {
                            sEnum.Value = EnumVal;
                        }
                        else
                        {
                            oCurrentFormat = oBackupFormat.Get_Clone();
                            MessageBox.Show("Enumeration value '" + EnumVal.ToString() + "' is defined twice !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            return (false);
                        }
                    }
                    else
                    {
                        oCurrentFormat = oBackupFormat.Get_Clone();
                        MessageBox.Show("An enumeration value must be a numerical value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return (false);
                    }
                }
                else
                {
                    oCurrentFormat = oBackupFormat.Get_Clone();
                    MessageBox.Show("An enumeration value cannot be empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }


                string EnumTxt;
                if (!(oRow.Cells[1].Value == null))
                {
                    EnumTxt = oRow.Cells[1].Value.ToString();
                    if (!(EnumTextExists(EnumTxt)))
                    {
                        sEnum.Text = EnumTxt;
                    }
                    else
                    {
                        oCurrentFormat = oBackupFormat.Get_Clone();
                        MessageBox.Show("Enumeration text '" + EnumTxt + "' is defined twice !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return (false);
                    }
                }
                else
                {
                    oCurrentFormat = oBackupFormat.Get_Clone();
                    MessageBox.Show("An enumeration text cannot be empty !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return (false);
                }

                oCurrentFormat.Enums.Add(sEnum);
            }

            return (true);
        }

        private void Add_EnumValue()
        {
            Grid_Enum.Rows.Add();
            DataGridViewRow oRow = Grid_Enum.Rows[Grid_Enum.Rows.Count - 1];

            oRow.Cells[0].Value = NextEnumValue.ToString();
            oRow.Cells[1].Value = "Value " + NextEnumValue.ToString();

            NextEnumValue++;
        }

        private void Del_EnumValues()
        {
            if (!(Grid_Enum.SelectedCells == null))
            {
                if (Grid_Enum.SelectedCells.Count > 0)
                {
                    foreach (DataGridViewCell oCell in Grid_Enum.SelectedCells)
                    {
                        if (!(oCell.RowIndex == -1))
                        {
                            Grid_Enum.Rows.RemoveAt(oCell.RowIndex);
                        }
                    }
                }
            }
        }

        private void Clear_EnumValues()
        {
            if (MessageBox.Show("Do you really want clear all values of the enumeration ?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                oCurrentFormat.Enums = new List<EnumerationValue>();
                Grid_Enum.Rows.Clear();
                NextEnumValue = 0;
            }
        }

        private bool EnumValueExists(int EnumValue)
        {

            foreach (EnumerationValue sEnum in oCurrentFormat.Enums)
            {
                if (sEnum.Value == EnumValue)
                {
                    return (true);
                }
            }

            return (false);
        }

        private bool EnumTextExists(string EnumText)
        {
            foreach (EnumerationValue sEnum in oCurrentFormat.Enums)
            {
                if (sEnum.Text.Equals(EnumText))
                {
                    return (true);
                }
            }

            return (false);
        }

        #endregion
    }
}
