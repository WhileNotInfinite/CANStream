/*
 * Created by SharpDevelop.
 * User: Vincent
 * Date: 04/07/2015
 * Time: 14:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Xml;

namespace CANStream
{
	#region Public structures
	
	/// <summary>
	/// Logging channel CAN signal reference structure
	/// </summary>
	[Serializable]
	public struct LoggingChannelCANSignalReference
	{
		/// <summary>CAN Parameter signal name</summary>
		public string SignalName;
		
		/// <summary>Name CAN Frame hosting signal reference</summary>
		public string FrameName;
	}
	
	/// <summary>
	/// Logging channel logging frequency for a specific trigger
	/// </summary>
	[Serializable]
	public struct LoggingChannelTriggerFrequency
	{
		/// <summary>Name of the logging trigger</summary>
		public string TriggerName;
		
		/// <summary>Logging frequency for the trigger</summary>
		public int Frequency;
		
		/// <summary>Logging channel logged flag</summary>
		/// <remarks>True = Channel logged / False = Channel not logged</remarks>
		public bool Logged;
	}
	
	#endregion
	
	/// <summary>
	/// CANStream logging channel class
	/// </summary>
	[Serializable]
	public class CS_LoggingChannel
	{
		#region Public members
		
		/// <summary>
		/// Logging channel name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Logging channel unit
		/// </summary>
		public string Unit;
		
		/// <summary>
		/// Logging channel comment
		/// </summary>
		public string Comment;
		
		/// <summary>
		/// Logging channel CAN signal reference
		/// </summary>
		public LoggingChannelCANSignalReference oCANSignalReference;
		
		/// <summary>
		/// Channel group hosting the channel
		/// </summary>
		public CS_LoggingChannelsGroup ParentGroup;
		
		/// <summary>
		/// Logging channel logging frequencies for each acquisition trigger
		/// </summary>
		public List<LoggingChannelTriggerFrequency> LoggingFrequencies;
		
		#endregion
		
		/// <summary>
		/// Default constructor
		/// </summary>
		public CS_LoggingChannel()
		{
			Name = "";
			Unit = "";
			Comment = "";
			oCANSignalReference = new LoggingChannelCANSignalReference();
			ParentGroup = null;
			LoggingFrequencies = new List<LoggingChannelTriggerFrequency>();
		}
	}
	
	/// <summary>
	/// CANStream logging channels group class
	/// </summary>
	[Serializable]
	public class CS_LoggingChannelsGroup
	{
		#region Public members
		
		/// <summary>Logging channels group name</summary>
		public string Name;
		
		/// <summary>Logging channels group comment</summary>
		public string Comment;
		
		/// <summary>Logging chanels list of the current group</summary>
		public List<CS_LoggingChannel> Channels;
		
		#endregion
		
		/// <summary>
		/// Default constructor
		/// </summary>
		public CS_LoggingChannelsGroup()
		{
			Name = "";
			Comment = "";
			Channels = new List<CS_LoggingChannel>();
		}
	}
	
	/// <summary>
	/// CANStream logging configuration classe
	/// </summary>
	public class CS_LoggingConfig
	{
		#region Public members
		
		/// <summary>Logging chanels groups of the current logging configuration</summary>
		public List<CS_LoggingChannelsGroup> Groups;
		
		/// <summary>CAN configuration of the current logging configuration</summary>
		public CANMessagesConfiguration oCANConfig;
		
		/// <summary>Acquisition triggers list of the current logging configuration</summary>
		public List<CS_AcquisitionTrigger> Triggers;
		
		/// <summary>Name of the current logging configuration</summary>
		public string Name;
		
		/// <summary>Comment of the current logging configuration</summary>
		public string Comment;
		
		#endregion
		
		//Default constructor
		public CS_LoggingConfig()
		{
			Groups = new List<CS_LoggingChannelsGroup>();
			oCANConfig = null;
			Triggers = new List<CS_AcquisitionTrigger>();
			Name = "";
			Comment = "";
		}
		
		#region Public methodes
		
		public void WriteLoggingConfigFile(string fPath)
		{
			XmlNode xData = null;
			
			if (!(fPath.Equals("")))
			{
				XmlDocument oXDoc = new XmlDocument();
				
				XmlElement xLogCfg = oXDoc.CreateElement("LoggingConfiguration");
				oXDoc.AppendChild(xLogCfg);
				
					xData = oXDoc.CreateElement("LogCfgName");
					xData.InnerText = Name;
					xLogCfg.AppendChild(xData);
					
					xData = oXDoc.CreateElement("LogCfgComment");
					xData.InnerText = Comment
					xLogCfg.AppendChild(xData);
					
					XmlElement xCanCfg = oCANConfig.CreateCANConfigurationXmlNode(oXDoc, "LogCfgCANCfg");
					xLogCfg.AppendChild(xCanCfg);
					
					XmlElement xTriggers = oXDoc.CreateElement("LoggingTriggers");
					xLogCfg.AppendChild(xTriggers);
					
					foreach (CS_AcquisitionTrigger oTrigger in Triggers)
					{
						XmlNode xTrig = oXDoc.CreateElement("AcqusitionTrigger");
						xTriggers.AppendChild(xTrig);
					}
					
					XmlElement xGroups = oXDoc.CreateElement("ChannelGroups");
					xLogCfg.AppendChild(xGroups);
					
					foreach (CS_LoggingChannelsGroup oGrp in Groups)
					{
						XmlNode xGrp = oXDoc.CreateElement("Group");
						xGrp.AppendChild(xGrp);
						
							xData = oXDoc.CreateElement("Name");
							xData.InnerText =  oGrp.Name;
							xGrp.AppendChild(xData);
							
							xData = oXDoc.CreateElement("Comment");
							xData.InnerText =  oGrp.Comment;
							xGrp.AppendChild(xData);
							
							XmlElement xChannels = oXDoc.CreateElement("LoggingChannels");
							xGrp.AppendChild(xChannels);
							
							foreach (CS_LoggingChannel oChan in oGrp.Channels)
							{
								XmlNode xChan = oXDoc.CreateElement("Channel");
								xChannels.AppendChild(xChan);
								
									xData = oXDoc.CreateElement("Name");
									xData.InnerText = oChan.Name;
									xChan.AppendChild(xData);
									
									xData = oXDoc.CreateElement("Comment");
									xData.InnerText = oChan.Comment;
									xChan.AppendChild(xData);
									
									xData = oXDoc.CreateElement("Unit");
									xData.InnerText = oChan.Unit;
									xChan.AppendChild(xData);
									
									XmlElement xCANSig = oXDoc.CreateElement("CANSignalReference");
									xChan.AppendChild(xCANSig);
									
										xData = oXDoc.CreateElement("SignalName");
										xData.InnerText = oChan.oCANSignalReference.SignalName;
										xCANSig.AppendChild(xData);
										
										xData = oXDoc.CreateElement("FrameName");
										xData.InnerText = oChan.oCANSignalReference.FrameName;
										xCANSig.AppendChild(xData);
										
									XmlElement xFrequencies = oXDoc.CreateElement("LoggingFrequencies");
									xChan.AppendChild(xFrequencies);
									
									foreach (LoggingChannelTriggerFrequency oFreq in oChan.LoggingFrequencies)
									{
										XmlElement xFreq = oXDoc.CreateElement("TriggerFrequency");
										xFrequencies.AppendChild(xFreq);
										
											xData = oXDoc.CreateElement("TriggerName");
											xData.InnerText = oFreq.TriggerName;
											xFreq.AppendChild(xData);
											
											xData = oXDoc.CreateElement("Frequency");
											xData.InnerText = oFreq.Frequency.ToString();
											xFreq.AppendChild(xData);
											
											xData = oXDoc.CreateElement("Logged");
											xData.InnerText = oFreq.Logged.ToString();
											xFreq.AppendChild(xData);
									}
							}
					}
					
				oXDoc.Save(fPath);
			}
		}
		
		public bool ReadLoggingConfigFile(string fPath)
		{
			XmlNode xData = null;
			
			if (!(fPath.Equals("")))
			{
				try
				{
					XmlDocument oXDoc = new XmlDocument();
					oXDoc.Load(fPath);
					
					XmlNode xLogCfg = oXDoc.SelectSingleNode("LoggingConfiguration");
					
						xData = xLogCfg.SelectSingleNode("LogCfgName");
						Name = xData.InnerText;
						
						xData = xLogCfg.SelectSingleNode("LogCfgComment");
						Comment = xData.InnerText;
						
						XmlNode xCanCfg = xLogCfg.SelectSingleNode("LogCfgCANCfg");
						if (!(oCANConfig.ReadCANConfigurationXmlNode(xCanCfg))) return(false);
						
						XmlNode xTriggers = xLogCfg.SelectSingleNode("LoggingTriggers");
						Triggers = new List<CS_AcquisitionTrigger>();
						
						foreach (XmlNode xTrig in xTriggers.ChildNodes)
						{
							CS_AcquisitionTrigger oTrig = new CS_AcquisitionTrigger();
							
							Triggers.Add(oTrig);
						}
						
						XmlNode xGroups = xLogCfg.SelectSingleNode("ChannelGroups");
						Groups = new List<CS_LoggingChannelsGroup>();
						
						foreach (XmlNode xGrp in xGroups.ChildNodes)
						{
							CS_LoggingChannelsGroup oGrp = new CS_LoggingChannelsGroup();
							
								xData = xGrp.SelectSingleNode("Name");
								oGrp.Name = xData.InnerText;
								
								xData = xGrp.SelectSingleNode("Comment");
								oGrp.Comment = xData.InnerText;
								
								XmlNode xChannels = xGrp.SelectSingleNode("LoggingChannels");
								oGrp.Channels = new List<CS_LoggingChannel>();
								
								foreach (XmlNode xChan in xChannels.ChildNodes)
								{
									CS_LoggingChannel oChan = new CS_LoggingChannel();
									
										xData = xChan.SelectSingleNode("Name");
										oChan.Name = xData.InnerText;
										
										xData = xChan.SelectSingleNode("Comment");
										oChan.Name = xData.InnerText;
										
										xData = xChan.SelectSingleNode("Unit");
										oChan.Name = xData.InnerText;
										
										XmlNode xCANSig = xChan.SelectSingleNode("CANSignalReference");
										
											xData = xCANSig.SelectSingleNode("SignalName");
											oChan.oCANSignalReference.SignalName = xData.InnerText;
											
											xData = xCANSig.SelectSingleNode("FrameName");
											oChan.oCANSignalReference.FrameName = xData.InnerText;
											
										XmlNode xFrequencies = xChan.SelectSingleNode("LoggingFrequencies");
										oChan.LoggingFrequencies = new List<LoggingChannelTriggerFrequency>();
										
										foreach (XmlNode xFreq in xFrequencies.ChildNodes)
										{
											LoggingChannelTriggerFrequency oFreq = new LoggingChannelTriggerFrequency();
											
												xData = xFreq.SelectSingleNode("TriggerName");
												oFreq.TriggerName = xData.InnerText;
											
												xData = xFreq.SelectSingleNode("Frequency");
												oFreq.Frequency = int.Parse(xData.InnerText);
												
												xData = xFreq.SelectSingleNode("Logged");
												oFreq.Logged = bool.Parse(xData.InnerText);
											
											oChan.LoggingFrequencies.Add(oFreq);
										}
									
									
									oGrp.Channels.Add(oChan);
								}
							
							Groups.Add(oGrp);
						}					
				}
				catch
				{
					return(false)
				}
				
				return(true);
			}
			
			return(false);
		}
		
		#endregion
	}
}
