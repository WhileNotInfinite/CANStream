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
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace CANStream
{
    #region Public enums

    public enum SpecialPasteObjectType
    {
        Unknown     = 0,
        Message     = 1,
        Parameter   = 2,
    }

    public enum SpecialPasteItems
    {
        None            = 0x0000,
        All             = 0xFFFF,

        RxTx            = 0x0001,
        DLC             = 0x0002,
        Period          = 0x0004,
        NoRxTimeout     = 0x0008,
        Comment         = 0x0010,
        Endianess       = 0x0020,
        Signedness      = 0x0040,
        Linearization   = 0x0080,
        VirtualChannel  = 0x0100,
        Unit            = 0x0200,
        Format          = 0x0400,
        Alarms          = 0x0800,
    }

    #endregion

    public partial class Frm_CANConfiguration_SpecialPaste : Form
    {
        #region Private members

        SpecialPasteObjectType ePastObjType;
        Frm_CANConfiguration CallerForm;

        #endregion

        public Frm_CANConfiguration_SpecialPaste(SpecialPasteObjectType PastObjectType, Frm_CANConfiguration Caller)
        {
            InitializeComponent();

            ePastObjType = PastObjectType;
            CallerForm = Caller;
        }

        #region Control events

        private void Frm_CANConfiguration_SpecialPaste_Load(object sender, EventArgs e)
        {
            switch (ePastObjType)
            {
                case SpecialPasteObjectType.Message:

                    Lbl_CANParameter.Enabled = false;

                    Radio_Param_Alarms.Enabled = false;
                    Radio_Param_Comment.Enabled = false;
                    Radio_Param_Endianess.Enabled = false;
                    Radio_Param_Format.Enabled = false;
                    Radio_Param_Linearization.Enabled = false;
                    Radio_Param_Signedness.Enabled = false;
                    Radio_Param_Unit.Enabled = false;
                    Radio_Param_VirtualChan.Enabled = false;

                    Radio_Msg_RxTx.Checked = true;

                    break;

                case SpecialPasteObjectType.Parameter:

                    Lbl_CANMessage.Enabled = false;

                    Radio_Msg_Comment.Enabled = false;
                    Radio_Msg_DLC.Enabled = false;
                    Radio_Msg_Period.Enabled = false;
                    Radio_Msg_RxTx.Enabled = false;
                    Radio_Msg_Timeout.Enabled = false;

                    Radio_Param_Endianess.Checked = true;

                    break;

                default:

                    MessageBox.Show("Object present in the clipboard does not support special paste !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    this.Close();

                    break;
            }
        }

        private void Frm_CANConfiguration_SpecialPaste_Deactivate(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Cmd_Apply_Click(object sender, EventArgs e)
        {
            SpecialPasteItems ePastItem = SpecialPasteItems.None;
            
            switch (ePastObjType)
            {
                case SpecialPasteObjectType.Message:

                    if (Radio_Msg_Comment.Checked)
                    {
                        ePastItem = SpecialPasteItems.Comment;
                    }
                    else if (Radio_Msg_DLC.Checked)
                    {
                        ePastItem = SpecialPasteItems.DLC;
                    }
                    else if (Radio_Msg_Period.Checked)
                    {
                        ePastItem = SpecialPasteItems.Period;
                    }
                    else if (Radio_Msg_RxTx.Checked)
                    {
                        ePastItem = SpecialPasteItems.RxTx;
                    }
                    else if (Radio_Msg_Timeout.Checked)
                    {
                        ePastItem = SpecialPasteItems.NoRxTimeout;
                    }

                    break;

                case SpecialPasteObjectType.Parameter:

                    if (Radio_Param_Alarms.Checked)
                    {
                        ePastItem = SpecialPasteItems.Alarms;
                    }
                    else if (Radio_Param_Comment.Checked)
                    {
                        ePastItem = SpecialPasteItems.Comment;
                    }
                    else if (Radio_Param_Endianess.Checked)
                    {
                        ePastItem = SpecialPasteItems.Endianess;
                    }
                    else if (Radio_Param_Format.Checked)
                    {
                        ePastItem = SpecialPasteItems.Format;
                    }
                    else if (Radio_Param_Linearization.Checked)
                    {
                        ePastItem = SpecialPasteItems.Linearization;
                    }
                    else if (Radio_Param_Signedness.Checked)
                    {
                        ePastItem = SpecialPasteItems.Signedness;
                    }
                    else if (Radio_Param_Unit.Checked)
                    {
                        ePastItem = SpecialPasteItems.Unit;
                    }
                    else if (Radio_Param_VirtualChan.Checked)
                    {
                        ePastItem = SpecialPasteItems.VirtualChannel;
                    }

                    break;

                default:

                    //Nothing to do
                    break;
            }

            if (ePastItem != SpecialPasteItems.None)
            {
                CallerForm.MakeSpecialPaste(ePastItem);
            }

            this.Close();
        }

        private void Cmd_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
