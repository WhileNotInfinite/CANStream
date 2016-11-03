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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANStream
{
    public enum RxFrameInTxListDialogResult
    {
        Ignore = 0,
        DisableTxFrame =1,
        GoRxOnly = 2,
    }

    public partial class Dlg_RxFrameInTxListWarning : Form
    {
        #region Public members

        public RxFrameInTxListDialogResult Result;

        #endregion

        #region Private members

        private static Dlg_RxFrameInTxListWarning MsgBox;

        #endregion

        public Dlg_RxFrameInTxListWarning()
        {
            InitializeComponent();
            Result = RxFrameInTxListDialogResult.Ignore;
        }

        #region Control events

        private void Cmd_Ignore_Click(object sender, EventArgs e)
        {
            Result = RxFrameInTxListDialogResult.Ignore;
            MsgBox.Close();
        }

        private void Cmd_DisableTxFrame_Click(object sender, EventArgs e)
        {
            Result = RxFrameInTxListDialogResult.DisableTxFrame;
            MsgBox.Close();
        }

        private void Cmd_GoRxOnly_Click(object sender, EventArgs e)
        {
            Result = RxFrameInTxListDialogResult.GoRxOnly;
            MsgBox.Close();
        }

        #endregion

        #region Public methodes

        public static RxFrameInTxListDialogResult Show(string Text)
        {
            MsgBox = new Dlg_RxFrameInTxListWarning();

            MsgBox.Txt_Text.Text = Text;

            MsgBox.ShowDialog();
            return (MsgBox.Result);
        }

        #endregion
    }
}
