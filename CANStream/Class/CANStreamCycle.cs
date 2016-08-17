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
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

using NumberBaseConversion;

//PCANBasic includes
using Peak.Can.Basic;
using TPCANHandle = System.Byte;

using Ctrl_GraphWindow;

namespace CANStream
{
    /// <summary>
    /// Message data class
    /// </summary>
    public class CANMessageData
    {
        #region Public members

        /// <summary>
        /// Message identifier
        /// </summary>
        public UInt32 uMessageId;
		
        /// <summary>
        /// Message sending period in ms (for manual control only, not saved in xml)
        /// </summary>
        public int Period;
        
        /// <summary>
        /// Message data in row format (FF FF FF FF FF FF FF FF)
        /// </summary>
        public byte[] byteMessageData;

        #endregion

        public CANMessageData()
        {
            uMessageId=0;
            byteMessageData = null;
        }
    }

    /// <summary>
    /// Class of the collection of messages to be sent at a particular time event
    /// </summary>
    public class CycleTimeEvent
    {
        #region Public members

        /// <summary>
        /// Time of event
        /// </summary>
        public long TimeEvent;

        /// <summary>
        /// List of message data
        /// </summary>
        public List<CANMessageData> MessagesData;

        #endregion

        public CycleTimeEvent()
        {
            TimeEvent = -1;
            MessagesData = new List<CANMessageData>();
        }
    }
    
    /// <summary>
    /// Pre-defined data cycle class
    /// </summary>
    public class CANStreamCycle
    {
        #region Public members

        /// <summary>
        /// Cycle name
        /// </summary>
        public string Name;

        /// <summary>
        /// Comments attached to the cycle
        /// </summary>
        public string Comment;
        
        /// <summary>
        /// List of time events of the cycle
        /// </summary>
        public List<CycleTimeEvent> TimeEvents;
		
        /// <summary>
        /// CAN Nodes mapping
        /// </summary>
        public CANMessagesConfiguration oCanNodesMap;
        
        #endregion

        public CANStreamCycle()
        {
            Name = "";
            Comment = "";
            oCanNodesMap = null;
            TimeEvents = new List<CycleTimeEvent>();
        }

        #region Public methods

        /// <summary>
        /// Write the data cycle into a XML file
        /// </summary>
        /// <param name="FilePath">Name and path of file to be created</param>
        public void WriteStreamCycle(string FilePath)
        {
        	XmlDocument oXmlCycle = new XmlDocument();

            XmlElement nCycle = oXmlCycle.CreateElement("CANStreamCycle");
            oXmlCycle.AppendChild(nCycle);

            XmlElement nHeader = oXmlCycle.CreateElement("Header");
            nCycle.AppendChild(nHeader);

                XmlElement nName = oXmlCycle.CreateElement("CycleName");
                nName.InnerText = Name;
                nHeader.AppendChild(nName);

                XmlElement nComment = oXmlCycle.CreateElement("Comment");
                nComment.InnerText = Comment;
                nHeader.AppendChild(nComment);
            
			XmlElement nCanMap = oCanNodesMap.CreateCANConfigurationXmlNode(oXmlCycle, "CANConfiguration");
			nCycle.AppendChild(nCanMap);
            
			XmlElement nEvents = oXmlCycle.CreateElement("TimeEvents");
            nCycle.AppendChild(nEvents);

            foreach (CycleTimeEvent oEvent in TimeEvents)
            {
                XmlElement nSingleEvent = oXmlCycle.CreateElement("Event");

                XmlAttribute nAtrTime = oXmlCycle.CreateAttribute("TimeValue");
                nAtrTime.Value = oEvent.TimeEvent.ToString();
                nSingleEvent.Attributes.Append(nAtrTime);

                foreach (CANMessageData oMessage in oEvent.MessagesData)
                {
                    XmlElement nMessage = oXmlCycle.CreateElement("MessageData");

                    XmlAttribute nAtrMsgId = oXmlCycle.CreateAttribute("Identifier");
                    nAtrMsgId.Value = oMessage.uMessageId.ToString();
                    nMessage.Attributes.Append(nAtrMsgId);
                    
                    for(int iByte=0;iByte<oMessage.byteMessageData.Length;iByte++)
                    {
                    	XmlElement nByte=oXmlCycle.CreateElement("Byte");
                    	
                    	XmlAttribute nAtrByteId=oXmlCycle.CreateAttribute("ByteIndex");
                    	nAtrByteId.Value=(oMessage.byteMessageData.Length-1-iByte).ToString();
                    	nByte.Attributes.Append(nAtrByteId);
                    	
                    	nByte.InnerText=oMessage.byteMessageData[iByte].ToString();
                    	nMessage.AppendChild(nByte);
                    }

                    nSingleEvent.AppendChild(nMessage);
                }

                nEvents.AppendChild(nSingleEvent);
            }

            oXmlCycle.Save(FilePath);

        }

        /// <summary>
        /// Read a data cycle into a XML file
        /// </summary>
        /// <param name="FilePath">Path of the file to read</param>
        /// <returns>Success state of reading operation (true OK, false NOK)</returns>
        public bool ReadStreamCycle(string FilePath)
        {
            XmlDocument oXmlCycle = new XmlDocument();
            oXmlCycle.Load(FilePath);

            XmlNode nCycle = oXmlCycle.FirstChild;
            if (nCycle.Name.Equals("CANStreamCycle"))
            {
                TimeEvents = new List<CycleTimeEvent>();

                XmlNode nHeader = nCycle.SelectSingleNode("Header");
                if (!(nHeader == null))
                {
                    XmlNode nName = nHeader.SelectSingleNode("CycleName");
                    if (!(nName == null))
                    {
                        Name = nName.InnerText;
                    }

                    XmlNode nComment = nHeader.SelectSingleNode("Comment");
                    if (!(nComment == null))
                    {
                        Comment = nComment.InnerText;
                    }

                    /*
                    XmlNode nCANConfig = nHeader.SelectSingleNode("CANConfigurationFile");
                    if (!(nCANConfig == null))
                    {
                        CANConfigurationFilePath = nCANConfig.InnerText;
                    }
                    else
                    {
                        return (false);
                    }
                    */
                }
                else
                {
                    return (false);
                }
                
                XmlNode nCanNodeMap = nCycle.SelectSingleNode("CANConfiguration");
                if (!(nCanNodeMap == null))
                {
                	oCanNodesMap = new CANMessagesConfiguration();
                	if (!(oCanNodesMap.ReadCANConfigurationXmlNode(nCanNodeMap)))
                	{
                		return(false);
                	}
                }
                else
                {
                	return(false);
                }
                
                XmlNode nEvents = nCycle.SelectSingleNode("TimeEvents");
                if (!(nEvents == null))
                {
                    foreach (XmlNode nSingleEvent in nEvents.ChildNodes)
                    {
                        if (nSingleEvent.Name.Equals("Event"))
                        {
                            CycleTimeEvent oEvent = new CycleTimeEvent();

                            XmlAttribute nAtrTime = nSingleEvent.Attributes["TimeValue"];
                            if (!(nAtrTime == null))
                            {
                                long TimeEvent = -1;
                                if (long.TryParse(nAtrTime.Value, out TimeEvent))
                                {
                                    oEvent.TimeEvent = TimeEvent;
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

                            foreach (XmlNode nMessage in nSingleEvent.ChildNodes)
                            {
                                if (nMessage.Name.Equals("MessageData"))
                                {
                                    CANMessageData oMessage = new CANMessageData();

                                    XmlAttribute nAtrMsgId = nMessage.Attributes["Identifier"];
                                    if (!(nAtrMsgId == null))
                                    { 
                                        UInt32 MsgId = 0;
                                        if (UInt32.TryParse(nAtrMsgId.Value, out MsgId))
                                        {
                                            oMessage.uMessageId = MsgId;
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

                                    oMessage.byteMessageData=new byte[nMessage.ChildNodes.Count];
                                    
                                    for(int iByte=0;iByte<nMessage.ChildNodes.Count;iByte++)
                                    {
                                    	byte ByteValue=0;
                                    	if(byte.TryParse(nMessage.ChildNodes[iByte].InnerText,out ByteValue))
                                    	{
                                    		oMessage.byteMessageData[iByte]=ByteValue;
                                    	}
                                    	else
                                    	{
                                    		return(false);
                                    	}
                                    }

                                    oEvent.MessagesData.Add(oMessage);
                                }
                            }

                            TimeEvents.Add(oEvent);
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
                return (false);
            }

            return (true);
        }
        
        /// <summary>
        /// Create the graphic data file of the current cycle for the Ctrl_GraphWindow control
        /// </summary>
        /// <returns>Ctrl_GraphWindow data file</returns>
        public GW_DataFile CreateCycleGraphData()
        {
            GW_DataFile oGraphData = new GW_DataFile();
            oGraphData.DataSamplingMode = SamplingMode.MultipleRates;

            if (!(oCanNodesMap == null))
            {
                foreach (CycleTimeEvent TxEvent in TimeEvents)
                {
                    foreach (CANMessageData MsgData in TxEvent.MessagesData)
                    {
                        CANMessage MsgCfg = oCanNodesMap.GetCANMessage(NumberBaseConverter.Dec2Hex(MsgData.uMessageId), MessageResearchOption.Identifier);

                        if (!(MsgCfg == null))
                        {
                            TPCANMsg sTPMsg = new TPCANMsg();
                            sTPMsg.DATA = MsgData.byteMessageData;

                            CANMessageDecoded oMsgDecoded = new CANMessageDecoded(MsgCfg, sTPMsg);

                            if (oMsgDecoded.bMessageDecoded)
                            {
                                foreach (CANParameter oParam in oMsgDecoded.Parameters)
                                {
                                    GW_DataChannel oGraphChan = oGraphData.Get_DataChannel(oParam.Name);

                                    if (oGraphChan == null)
                                    {
                                        oGraphChan = new GW_DataChannel(oParam.Name, SamplingMode.MultipleRates);
                                        oGraphData.Channels.Add(oGraphChan);
                                    }

                                    SerieSample sSample = new SerieSample();
                                    sSample.SampleTime = (double)TxEvent.TimeEvent / 1000;
                                    sSample.SampleValue = oParam.DecodedValue;

                                    oGraphChan.Add_ChannelValue(sSample);
                                }
                            }
                        }
                    }
                }
            }

            return (oGraphData);
        }
        
        /// <summary>
        /// Return the number of time events between two time events given as argument
        /// </summary>
        /// <param name="TStart">Start time event</param>
        /// <param name="TEnd">End time event</param>
        /// <returns>Number of time events beetween start & end time events </returns>
        public long GetTimeEventCountBetweenTimes(long TStart, long TEnd)
        {
        	long EventCnt = 0;
        	
        	if (TStart == TimeEvents[0].TimeEvent & TEnd == TimeEvents[TimeEvents.Count - 1].TimeEvent)
        	{
        		return(TimeEvents.Count);
        	}
        	else
        	{
	        	foreach(CycleTimeEvent oEvent in TimeEvents)
	        	{
	        		if (oEvent.TimeEvent >= TStart & oEvent.TimeEvent <= TEnd)
	        		{
	        			EventCnt++;
	        		}
	        		else
	        		{
	        			if (oEvent.TimeEvent > TEnd)
	        			{
	        				return(EventCnt);
	        			}
	        		}
	        	}
        	}
        	
        	return(EventCnt);
        }
        
        /// <summary>
        /// Get index of the time event closest to the time value given as arguement
        /// </summary>
        /// <param name="TimeValue">Time value of the time event searched</param>
        /// <returns>Index of the closest time event, -1 if not found</returns>
        public int GetTimeEventIndex(long TimeValue)
        {
        	for(int iEvent = 0; iEvent<TimeEvents.Count; iEvent++)
        	{
        		if (TimeEvents[iEvent].TimeEvent>TimeValue)
        		{
        			if (!(iEvent == 0))
        			{
        				return(iEvent -1);
        			}
        		}
        	}
        	
        	return(-1);
        }
        
        /// <summary>
        /// Convert a PCAN trace record file (*.trc) into a CANStream cycle
        /// </summary>
        /// <param name="RecordPath">Path of the PCAN trace record file to convert</param>
        public void ImportTraceRecord(string RecordPath)
        {
        	
        }
        
        #endregion
    }
}
