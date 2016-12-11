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
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ctrl_GraphWindow;

namespace CANStream
{
    public partial class Ctrl_DataFileInformation : UserControl
    {
        #region Public properties

        /// <summary>
        /// GW_DataFile object showed in the control
        /// </summary>
        public GW_DataFile DataFile
        {
            get
            {
                return (oDataFile);
            }

            set
            {
                oDataFile = value;
                Show_DataFileInformation();
            }
        }

        #endregion

        #region Private members

        private GW_DataFile oDataFile;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public Ctrl_DataFileInformation()
        {
            InitializeComponent();

            oDataFile = null;
        }

        #region Control events

        #region cCL_FileChannelList

        private void cCL_FileChannelList_DataChannelClicked(object sender, ChannelClickEventArgs e)
        {
            Show_DataChannelProperties(e.ChannelName);
        }

        private void cCL_FileChannelList_DataChannelSelectionChanged(object sender, ChannelSelectionChangedEventArgs e)
        {
            Show_DataChannelProperties(e.ChannelName);
        }

        #endregion

        #endregion

        #region Private methodes

        /// <summary>
        /// Show the GW_DataFile object inforamtion into the current Ctrl_DataFileInformation control
        /// </summary>
        private void Show_DataFileInformation()
        {
            //File information
            Txt_FileStartTime.Text = oDataFile.DataStartTime.ToLongDateString() + " " 
                                     + oDataFile.DataStartTime.ToLongTimeString();

            Txt_FileComment.Text = oDataFile.UserComment;

            //File custom properties
            CS_RecordUserInfoCollection oFileCustomProperties = new CS_RecordUserInfoCollection();

            foreach (GW_XmlDataFileCustomProperty oProp in oDataFile.XmlDataFileCustomProperties)
            {
                CS_RecordUserInfo sProp = Convert_XmlDataFileProperty_To_RecordUserInfo(oProp);

                if(!(sProp.Title.Equals("")))
                {
                    oFileCustomProperties.Informations.Add(sProp);
                }
            }

            cRUI_FileCustomProperties.Set_UserInformations(oFileCustomProperties);

            //Channels properties
            cCL_FileChannelList.Clear_ChannelList();
            
            foreach(GW_DataChannel oChan in oDataFile.Channels)
            {
                cCL_FileChannelList.Add_ChannelNameWithDescription(oChan.Name, oChan.Description);
            }

            cCL_FileChannelList.Show_ChannelList();

        }

        /// <summary>
        /// Convert a GW_XmlDataFileCustomProperty object into a CS_RecordUserInfo structure
        /// </summary>
        /// <param name="oXmlProp">GW_XmlDataFileCustomProperty to be converted</param>
        /// <returns>CS_RecordUserInfo created from the GW_XmlDataFileCustomProperty given as argument</returns>
        private CS_RecordUserInfo Convert_XmlDataFileProperty_To_RecordUserInfo(GW_XmlDataFileCustomProperty oXmlProp)
        {
            CS_RecordUserInfo sRecordUserInfo = new CS_RecordUserInfo();

            sRecordUserInfo.Title = "";
            sRecordUserInfo.Value = "";

            if (!(oXmlProp == null))
            {
                sRecordUserInfo.Title = oXmlProp.Name;
                sRecordUserInfo.Value = oXmlProp.PropertyValue.ToString();
            }

            return (sRecordUserInfo);
        }

        /// <summary>
        /// Show the properties of a data channel into the channel properties grid
        /// </summary>
        /// <param name="ChannelName">Name of the channel to show</param>
        private void Show_DataChannelProperties(string ChannelName)
        {

        }

        #endregion
    }
}
