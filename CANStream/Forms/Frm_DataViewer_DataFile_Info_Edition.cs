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
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ctrl_GraphWindow;

namespace CANStream
{
    public partial class Frm_DataViewer_DataFile_Info_Edition : Form
    {
        public Frm_DataViewer_DataFile_Info_Edition(string[] FilePathes)
        {
            InitializeComponent();

            if (!(FilePathes == null))
            {
                foreach (string sFilePath in FilePathes)
                {
                    if (Path.GetExtension(sFilePath).Equals(".xrdf"))
                    {
                        Add_FileTab(sFilePath);
                    }
                }
            }
        }

        #region Control events
        #endregion

        #region Private methodes

        private void Add_FileTab(string FileName)
        {
            GW_DataFile oDataFile = new GW_DataFile();

            if (oDataFile.Load_XmlDataFile(FileName, false))
            {
                Tabs_DataFiles.TabPages.Add(Path.GetFileNameWithoutExtension(FileName));
                TabPage oFileTab = Tabs_DataFiles.TabPages[Tabs_DataFiles.TabPages.Count - 1];

                Ctrl_DataFileInformation cDataFileInfo = new Ctrl_DataFileInformation();
                oFileTab.Controls.Add(cDataFileInfo);

                cDataFileInfo.Width = oFileTab.Width - 6;
                cDataFileInfo.Height = oFileTab.Height - 6;
                cDataFileInfo.Location = new Point(3, 3);
                cDataFileInfo.Anchor = (AnchorStyles)(AnchorStyles.Left  |
                                                      AnchorStyles.Right |
                                                      AnchorStyles.Top   |
                                                      AnchorStyles.Bottom);

                cDataFileInfo.DataFile = oDataFile;
            }
        }

        #endregion
    }
}
