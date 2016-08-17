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
using System.Xml;

namespace CANStream
{
	/// <summary>
	/// Enum of the type of element associated to a CAN Parameter
	/// </summary>
	public enum CS_DataAssociationType
	{
		None        = 0,
		AcqData     = 1,
		BuiltSignal = 2,
		FixedValue  = 3,
	}
	
	/// <summary>
	/// Single CAN Parameter/element association class
	/// </summary>
	public class DataAssociation
	{
		#region Public members
		
		/// <summary>
		/// Association type: data channel, built-in signal, default value
		/// </summary>
		public CS_DataAssociationType AssociationType;	//New version 1.3
		
		/// <summary>
		/// CAN Parameter name associated
		/// </summary>
		public string CANParameterName;
		
		/// <summary>
		/// Message identifier containing of the CAN Parameter associated
		/// </summary>
        public string CANParameterMessageIdentifier;
        	
        //public bool UseDefaultValue;
        
        /// <summary>
		/// Data channel name associated to the CAN Parameter
		/// </summary>
		public string DataColumnTitle;
        
        /// <summary>
        /// Built-in signal name associated to the CAN Parameter
        /// </summary>
        public string SignalName;						//New version 1.3
        
        /// <summary>
        /// Signal library containing the signal associated to the CAN Parameter
        /// </summary>
		public string SignalLibrary;					//New version 1.3
		
		/// <summary>
		/// Default (Fixed) value used to feed the CAN Parameter
		/// </summary>
		public double DefaultValue;
		
		#endregion
		
		public DataAssociation()
		{
			DataColumnTitle="";
			CANParameterName="";
			//UseDefaultValue=false;
			DefaultValue=0;
			AssociationType = CS_DataAssociationType.None;
			SignalLibrary = "";
			SignalName = "";
		}
	}
	
	/// <summary>
	/// CAN Parameter/element asssociation collection class
	/// </summary>
	public class CycleDataAssociation
	{
		#region Public members
		
		/// <summary>
		/// Collection of associations
		/// </summary>
		public List<DataAssociation> Associations;
		
		/// <summary>
		/// CAN configurarion file
		/// </summary>
        public string CANConfigFile;
        
        /// <summary>
        /// Date file template
        /// </summary>
        public string DataFileTemplate;

		#endregion
		
		public CycleDataAssociation()
		{
			Associations=new List<DataAssociation>();

            CANConfigFile = "";
            DataFileTemplate = "";
		}
		
		#region Public methodes
		
		/// <summary>
		/// Write CycleDataAssociation file
		/// </summary>
		/// <param name="FilePath">Path of the file to write</param>
		public void WriteCycleDataAssociation(string FilePath)
		{
			XmlDocument oXmlAssociation=new XmlDocument();
			
			XmlElement xAssociations=oXmlAssociation.CreateElement("CycleDataAssociation");
			oXmlAssociation.AppendChild(xAssociations);

            XmlElement xCanConfig = oXmlAssociation.CreateElement("CANConfigFile");
            xCanConfig.InnerText = CANConfigFile;
            xAssociations.AppendChild(xCanConfig);

            XmlElement xDataFile = oXmlAssociation.CreateElement("DataFileTemplate");
            xDataFile.InnerText = DataFileTemplate;
            xAssociations.AppendChild(xDataFile);

            XmlElement xAssociationsCollection = oXmlAssociation.CreateElement("Associations");
            xAssociations.AppendChild(xAssociationsCollection);

			foreach(DataAssociation oAssociation in Associations)
			{
				XmlElement xAssociation=oXmlAssociation.CreateElement("Association");
				
				XmlElement xColTitle=oXmlAssociation.CreateElement("DataColumnTitle");
				xColTitle.InnerText=oAssociation.DataColumnTitle;
				xAssociation.AppendChild(xColTitle);
				
				XmlElement xCANParam=oXmlAssociation.CreateElement("CANParameterName");
				xCANParam.InnerText=oAssociation.CANParameterName;
				xAssociation.AppendChild(xCANParam);

                XmlElement xCANParamMsgId = oXmlAssociation.CreateElement("CANParameterMessageIdentifier");
                xCANParamMsgId.InnerText = oAssociation.CANParameterMessageIdentifier;
                xAssociation.AppendChild(xCANParamMsgId);
				
//				XmlElement xUseDefault=oXmlAssociation.CreateElement("UseDefaultValue");
//				xUseDefault.InnerText=oAssociation.UseDefaultValue.ToString();
//				xAssociation.AppendChild(xUseDefault);
				
				XmlElement xDefaultValue=oXmlAssociation.CreateElement("DefaultValue");
				xDefaultValue.InnerText=oAssociation.DefaultValue.ToString();
				xAssociation.AppendChild(xDefaultValue);
				
				XmlElement xAssociationType=oXmlAssociation.CreateElement("AssociationType");
				xAssociationType.InnerText=oAssociation.AssociationType.ToString();
				xAssociation.AppendChild(xAssociationType);
				
				XmlElement xSigLib=oXmlAssociation.CreateElement("BuiltInSignal_Library");
				xSigLib.InnerText=oAssociation.SignalLibrary;
				xAssociation.AppendChild(xSigLib);
				
				XmlElement xSigName=oXmlAssociation.CreateElement("BuiltInSignal_Name");
				xSigName.InnerText=oAssociation.SignalName;
				xAssociation.AppendChild(xSigName);

                xAssociationsCollection.AppendChild(xAssociation);
			}
			
			oXmlAssociation.Save(FilePath);
		}
		
		/// <summary>
		/// Read CycleDataAssociation file
		/// </summary>
		/// <param name="FilePath">Path of the file to read</param>
		/// <returns>Reading error flag: True =  No Error / False = Error</returns>
		public bool ReadCycleDataAssociation(string FilePath)
		{
			XmlDocument oXmlAssociation=new XmlDocument();
			oXmlAssociation.Load(FilePath);
			
			XmlNode xAssociations=oXmlAssociation.FirstChild;
			if(xAssociations.Name.Equals("CycleDataAssociation"))
			{

                XmlNode xCanConfig = xAssociations.SelectSingleNode("CANConfigFile");
                if (!(xCanConfig == null))
                {
                    CANConfigFile = xCanConfig.InnerText;
                }

                XmlNode xDataFile = xAssociations.SelectSingleNode("DataFileTemplate");
                if (!(xDataFile == null))
                {
                    DataFileTemplate = xDataFile.InnerText;
                }

                XmlNode xAssociationCollection = xAssociations.SelectSingleNode("Associations");
                if (!(xAssociationCollection == null))
                {
                    Associations = new List<DataAssociation>();

                    foreach (XmlNode xAssociation in xAssociationCollection.ChildNodes)
                    {
                        if (xAssociation.Name.Equals("Association"))
                        {
                            DataAssociation oAssociation = new DataAssociation();

                            //CAN Parameter name
                            XmlNode xCANParam = xAssociation.SelectSingleNode("CANParameterName");
                            if (!(xCANParam == null))
                            {
                                oAssociation.CANParameterName = xCANParam.InnerText;
                            }
                            else
                            {
                                return (false);
                            }

                            //CAN Parameter message identifier
                            XmlNode xCANParamMsgId = xAssociation.SelectSingleNode("CANParameterMessageIdentifier");
                            if (!(xCANParamMsgId == null))
                            {
                                oAssociation.CANParameterMessageIdentifier = xCANParamMsgId.InnerText;
                            }
                            else
                            {
                                return (false);
                            }
                            
                            //Data column title
                            XmlNode xColumnTitle = xAssociation.SelectSingleNode("DataColumnTitle");
                            if (!(xColumnTitle == null))
                            {
                                oAssociation.DataColumnTitle = xColumnTitle.InnerText;
                            }
                            else
                            {
                                return (false);
                            }
                            
                            //Default value
                            XmlNode xDefaultValue = xAssociation.SelectSingleNode("DefaultValue");
                            if (!(xDefaultValue == null))
                            {
                                double DefaultValue = 0;
                                if (Double.TryParse(xDefaultValue.InnerText, out DefaultValue))
                                {
                                    oAssociation.DefaultValue = DefaultValue;
                                }
                                else
                                {
                                    return (false);
                                }
                            }
                            else
                            {
                                return (false);
                            }
                            
                            XmlNode xAssociationType = xAssociation.SelectSingleNode("AssociationType");
                            
                        	CS_DataAssociationType eAsso = CS_DataAssociationType.None;
                        	if (Enum.TryParse(xAssociationType.InnerText,out eAsso))
                        	{
                        		oAssociation.AssociationType = eAsso;
                        	}
                        	else
                        	{
                        		return(false);
                        	}
                        	
                        	XmlNode xSigLib = xAssociation.SelectSingleNode("BuiltInSignal_Library");
                        	if (!(xSigLib ==  null))
                        	{
                        		oAssociation.SignalLibrary = xSigLib.InnerText;
                        	}
                        	else
                        	{
                        		return(false);
                        	}
                        	
                        	XmlNode xSigName = xAssociation.SelectSingleNode("BuiltInSignal_Name");
                        	if (!(xSigName == null))
                        	{
                        		oAssociation.SignalName = xSigName.InnerText;
                        	}
                        	else
                        	{
                        		return(false);
                        	}

                            Associations.Add(oAssociation);
                        }
                    }
                }
                else
                {
                    return (false);
                }
			}
			else
			{
				return(false);
			}
			
			return(true);
		}

        public DataAssociation GetAssociation(string CANMessageIdentifier, string CANParameterName)
        {
            foreach (DataAssociation oAssociation in Associations)
            {
                if (oAssociation.CANParameterMessageIdentifier.Equals(CANMessageIdentifier)
                    & oAssociation.CANParameterName.Equals(CANParameterName))
                {
                    return (oAssociation);
                }
            }

            return (null);
        }

		#endregion
	}
}
