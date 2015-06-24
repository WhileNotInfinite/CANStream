/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 7/21/2014
 * Time: 15:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Xml;

namespace CANStream
{
	#region Enums declaration
	
	/// <summary>
	/// Enumeration of all possible data source used in a cycle
	/// </summary>
	public enum CycleDataSource
	{
		None           = 0,
		Default        = 1,
		Constant       = 2,
		BuiltSignal    = 3,
		VirtualChannel = 4,
		AcqData        = 5,
	}
	
	/// <summary>
	/// Enumeration of cycle parts (pre/in/post cycle)
	/// </summary>
	public enum CyclePart
	{
		None      = 0,
		PreCycle  = 1,
		InCycle   = 2,
		PostCycle = 3,
	}
	
	#endregion
	
	/// <summary>
	/// Cycle part properties class
	/// </summary>
	public class CyclePartProperties
	{
		#region Public members
		
		/// <summary>
		/// Time length of the cycle part
		/// </summary>
		public double TimeLength;
		
		/// <summary>
		/// Data file used in the cycle part
		/// </summary>
		public string DataFile;
		
		#endregion
		
		public CyclePartProperties()
		{
			TimeLength = 0;
			DataFile = "None";
		}
	}
	
	/// <summary>
	/// Partial cycle data class of a single cycle parameter
	/// </summary>
	public class CycleDataPart
	{
		#region Public members
		
		/// <summary>
		/// Data source of the cycle part
		/// </summary>
		public CycleDataSource Source;
		
		/// <summary>
		/// Data of the cycle part
		/// </summary>
		public string Data;
		
		/// <summary>
		/// Library containing the data used in the cycle part
		/// </summary>
		public string Library;
		
		#endregion
		
		public CycleDataPart()
		{
			Source = CycleDataSource.None;
			Data = "0";
			Library = "None";
		}
	}
	
	/// <summary>
	/// Cycle parameter class
	/// </summary>
	public class CycleParameter
	{
		#region Public members
		
		/// <summary>
		/// Name of the parameter
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Identifier of the message containing the parameter
		/// </summary>
		public string MsgId;
		
		/// <summary>
		/// Pre-cycle partial cycle data of the cycle parameter
		/// </summary>
		public CycleDataPart PreCycle;
		
		/// <summary>
		/// In cycle partial cycle data of the cycle parameter
		/// </summary>
		public CycleDataPart InCycle;
		
		/// <summary>
		/// Post-cycle partial cycle data of the cycle parameter
		/// </summary>
		public CycleDataPart PostCycle;
		
		#endregion
		
		public CycleParameter()
		{
			Name  = "";
			MsgId = "";
			PreCycle  = new CycleDataPart();
			InCycle   = new CycleDataPart();
			PostCycle = new CycleDataPart();
		}
		
		#region Public methode
		
		/// <summary>
		/// Return the cycle data part object corresponding to the part given as argument
		/// </summary>
		/// <param name="ePart">Cycle data part to get</param>
		/// <returns>Cycle data part, null if not found</returns>
		public CycleDataPart GetDataParameterDataPart(CyclePart ePart)
		{
			switch (ePart)
			{
				case CyclePart.PreCycle:
					return(PreCycle);
				case CyclePart.InCycle:
					return(InCycle);
				case CyclePart.PostCycle:
					return(PostCycle);
				default:
					return(null);
			}
		}
		
		#endregion
	}
	
	/// <summary>
	/// Cycle edition configuration classe
	/// </summary>
	public class CycleEditionConfiguration
	{
		#region Public members
		
		#region Saved members
		
		/// <summary>
		/// List of parameters played in the cycle
		/// </summary>
		public List<CycleParameter> Parameters;
		
		/// <summary>
		/// Pre-cycle part properties
		/// </summary>
		public CyclePartProperties PreCycleProperties;
		
		/// <summary>
		/// In-cycle part properties
		/// </summary>
		public CyclePartProperties InCycleProperties;
		
		/// <summary>
		/// Post-cycle part properties
		/// </summary>
		public CyclePartProperties PostCycleProperties;
		
		/// <summary>
		/// CAN Message configuration used in the cycle editor
		/// </summary>
		public CANMessagesConfiguration CanConfiguration;
		
		/// <summary>
		/// Virtual channels libraries collection used in the cycle editor
		/// </summary>
		public CS_VCLibrariesCollection VirtualChannelLibCollection;
		
		/// <summary>
		/// Built-in signals libraries collection used in the cycle editor
		/// </summary>
		public CS_BuiltInSignalLibCollection BuiltInSignalLibCollection;
		
		#endregion
		
		#region Non saved members
		
		/// <summary>
		/// Cycle configuration modified flag
		/// </summary>
		public bool bModified;
		
		/// <summary>
		/// Cycle configuration file path
		/// </summary>
		public string FilePath;
		
		#endregion
		
		#endregion
		
		#region Private members
		#endregion
		
		public CycleEditionConfiguration()
		{
			Parameters = new List<CycleParameter>();
			PreCycleProperties  = new CyclePartProperties();
			InCycleProperties   = new CyclePartProperties();
			PostCycleProperties = new CyclePartProperties();
			CanConfiguration = null;
			VirtualChannelLibCollection = null;
			BuiltInSignalLibCollection = null;
			
			bModified = false;
			FilePath = "";
		}
		
		#region Public methodes
		
		/// <summary>
		/// Save the cycle configuration in a XML file
		/// </summary>
		/// <param name="fPath">Path of destination file</param>
		public void Save_CycleConfiguration(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oCycleConfig = new XmlDocument();
				
				//Root node
				XmlElement xCycleCfg =  oCycleConfig.CreateElement("CycleConfiguration");
				oCycleConfig.AppendChild(xCycleCfg);
				
				//CAN Message configuration
				XmlElement xCanCfg = null;
				
				if (!(CanConfiguration == null))
				{
					xCanCfg = CanConfiguration.CreateCANConfigurationXmlNode(oCycleConfig, "CANConfiguration");
				}
				else
				{
					xCanCfg = oCycleConfig.CreateElement("CANConfiguration");
				}
				
				xCycleCfg.AppendChild(xCanCfg);
								
				//Virtual channels libraries
				if (!(VirtualChannelLibCollection ==  null))
				{
					foreach (CS_VirtualChannelsLibrary oLib in VirtualChannelLibCollection.Libraries)
					{
						XmlElement xVirtualLib = oCycleConfig.CreateElement("CS_VirtualChannelsLibrary");
						xCycleCfg.AppendChild(xVirtualLib);
						oLib.CreateLibraryXmlNode(oCycleConfig);
					}
				}
				
				//Built-In signals libraries
				if (!(BuiltInSignalLibCollection == null))
				{
					foreach (CS_BuiltInSignalLibrary oLib in BuiltInSignalLibCollection.Libraries)
					{
						XmlElement xSignalLib = oCycleConfig.CreateElement("CS_BuiltInSignalsLibrary");
						xCycleCfg.AppendChild(xSignalLib);
						oLib.CreateLibraryXmlNode(oCycleConfig);
					}
				}
				
				//Cycle parts properties
				XmlElement xPartProps = oCycleConfig.CreateElement("CyclePartsProperties");
				xCycleCfg.AppendChild(xPartProps);
				
				XmlAttribute xAtrLen, xAtrDataFile;
				
					//Pre-cycle
					XmlElement xPreCycleProps = oCycleConfig.CreateElement("PreCycleProperties");
					
						xAtrLen = oCycleConfig.CreateAttribute("TimeLength");
						xAtrLen.Value = PreCycleProperties.TimeLength.ToString();
						xPreCycleProps.Attributes.Append(xAtrLen);
						
						xAtrDataFile = oCycleConfig.CreateAttribute("DataFile");
						xAtrDataFile.Value = PreCycleProperties.DataFile;
						xPreCycleProps.Attributes.Append(xAtrDataFile);
						
					xPartProps.AppendChild(xPreCycleProps);
					
					//In-cycle
					XmlElement xInCycleProps = oCycleConfig.CreateElement("InCycleProperties");
					
						xAtrLen = oCycleConfig.CreateAttribute("TimeLength");
						xAtrLen.Value = InCycleProperties.TimeLength.ToString();
						xInCycleProps.Attributes.Append(xAtrLen);
						
						xAtrDataFile = oCycleConfig.CreateAttribute("DataFile");
						xAtrDataFile.Value = InCycleProperties.DataFile;
						xInCycleProps.Attributes.Append(xAtrDataFile);
					
					xPartProps.AppendChild(xInCycleProps);
					
					//Post-cycle
					XmlElement xPostCycleProps = oCycleConfig.CreateElement("PostCycleProperties");
					
						xAtrLen = oCycleConfig.CreateAttribute("TimeLength");
						xAtrLen.Value = PostCycleProperties.TimeLength.ToString();
						xPostCycleProps.Attributes.Append(xAtrLen);
						
						xAtrDataFile = oCycleConfig.CreateAttribute("DataFile");
						xAtrDataFile.Value = PostCycleProperties.DataFile;
						xPostCycleProps.Attributes.Append(xAtrDataFile);
					
					xPartProps.AppendChild(xPostCycleProps);
					
				//Cycle parameters
				XmlElement xCycleParameters = oCycleConfig.CreateElement("CycleParameters");
				xCycleCfg.AppendChild(xCycleParameters);
				
				foreach (CycleParameter oCycleParam in Parameters)
				{
					XmlAttribute xAtrSrc, xAtrData, xAtrLib;
					
					//Parameter properties
					XmlElement xParam = oCycleConfig.CreateElement("Parameter");
					
						XmlAttribute xAtrName = oCycleConfig.CreateAttribute("Name");
						xAtrName.Value =  oCycleParam.Name;
						xParam.Attributes.Append(xAtrName);
						
						XmlAttribute xAtrMsg = oCycleConfig.CreateAttribute("MessageId");
						xAtrMsg.Value = oCycleParam.MsgId;
						xParam.Attributes.Append(xAtrMsg);
					
					//Paramter Pre-Cycle data properties
					XmlElement xPreCycleData = oCycleConfig.CreateElement("PreCycleData");
					xParam.AppendChild(xPreCycleData);
					
						xAtrSrc = oCycleConfig.CreateAttribute("Source");
						xAtrSrc.Value = oCycleParam.PreCycle.Source.ToString();
						xPreCycleData.Attributes.Append(xAtrSrc);
						
						xAtrData = oCycleConfig.CreateAttribute("Data");
						xAtrData.Value = oCycleParam.PreCycle.Data;
						xPreCycleData.Attributes.Append(xAtrData);
						
						xAtrLib = oCycleConfig.CreateAttribute("Library");
						xAtrLib.Value = oCycleParam.PreCycle.Library;
						xPreCycleData.Attributes.Append(xAtrLib);
						
					//Paramter In-Cycle data properties
					XmlElement xInCycleData = oCycleConfig.CreateElement("InCycleData");
					xParam.AppendChild(xInCycleData);
					
						xAtrSrc = oCycleConfig.CreateAttribute("Source");
						xAtrSrc.Value = oCycleParam.InCycle.Source.ToString();
						xInCycleData.Attributes.Append(xAtrSrc);
						
						xAtrData = oCycleConfig.CreateAttribute("Data");
						xAtrData.Value = oCycleParam.InCycle.Data;
						xInCycleData.Attributes.Append(xAtrData);
						
						xAtrLib = oCycleConfig.CreateAttribute("Library");
						xAtrLib.Value = oCycleParam.InCycle.Library;
						xInCycleData.Attributes.Append(xAtrLib);
						
					//Paramter Post-Cycle data properties
					XmlElement xPostCycleData = oCycleConfig.CreateElement("PostCycleData");
					xParam.AppendChild(xPostCycleData);
					
						xAtrSrc = oCycleConfig.CreateAttribute("Source");
						xAtrSrc.Value = oCycleParam.PostCycle.Source.ToString();
						xPostCycleData.Attributes.Append(xAtrSrc);
						
						xAtrData = oCycleConfig.CreateAttribute("Data");
						xAtrData.Value = oCycleParam.PostCycle.Data;
						xPostCycleData.Attributes.Append(xAtrData);
						
						xAtrLib = oCycleConfig.CreateAttribute("Library");
						xAtrLib.Value = oCycleParam.PostCycle.Library;
						xPostCycleData.Attributes.Append(xAtrLib);
						
					xCycleParameters.AppendChild(xParam);
				}
				
				oCycleConfig.Save(fPath);
				FilePath = fPath;
				bModified = false;
			}
		}
		
		/// <summary>
		/// Read the cycle configuration in a XML file
		/// </summary>
		/// <param name="fPath">Path of the file to read</param>
		/// <returns>Reading error flag: True = No Error / False = Error</returns>
		public bool Read_CycleConfiguration(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oCycleConfig = new XmlDocument();
				oCycleConfig.Load(fPath);
				
				XmlNode xCycleCfg = oCycleConfig.SelectSingleNode("CycleConfiguration");
				
				if (!(xCycleCfg == null))
				{
					//CAN Configuration
					XmlNode xCanCfg = xCycleCfg.SelectSingleNode("CANConfiguration");
					
					if (!(xCanCfg == null))
					{
						CanConfiguration = new CANMessagesConfiguration();
						
						if (!(CanConfiguration.ReadCANConfigurationXmlNode(xCanCfg)))
						{
							return(false);
						}
					}
					else
					{
						return(false); //Node CANConfiguration not found
					}
					
					//Virtual channels libraries
					XmlNode xVirtualLib = xCanCfg.NextSibling;
					
					if (xVirtualLib.Name.Equals("CS_VirtualChannelsLibrary"))
					{
						VirtualChannelLibCollection = new CS_VCLibrariesCollection();
						
						while (xVirtualLib.Name.Equals("CS_VirtualChannelsLibrary"))
						{
							CS_VirtualChannelsLibrary oLib = new CS_VirtualChannelsLibrary();
							oLib.ReadLibraryXmlNode(xVirtualLib);
							VirtualChannelLibCollection.AddLibrary(oLib);
							
							xVirtualLib = xVirtualLib.NextSibling;
						}
					}
					
					//Built-In signals libraries
					XmlNode xSignalLib = xVirtualLib;
					
					if (xSignalLib.Name.Equals("CS_BuiltInSignalsLibrary"))
					{
						BuiltInSignalLibCollection = new CS_BuiltInSignalLibCollection();
						
						while(xSignalLib.Name.Equals("CS_BuiltInSignalsLibrary"))
						{
							CS_BuiltInSignalLibrary oLib = new CS_BuiltInSignalLibrary();
							oLib.ReadLibraryXmlNode(xSignalLib);
							BuiltInSignalLibCollection.AddLibrary(oLib);
							
							xSignalLib = xSignalLib.NextSibling;
						}
					}
					
					//Cycle parts properties
					XmlNode xPartProps = xCycleCfg.SelectSingleNode("CyclePartsProperties");
					if (!(xPartProps == null))
					{
						//Pre-cycle
						XmlNode xPreCycleProps = xPartProps.SelectSingleNode("PreCycleProperties");
						if (!(xPreCycleProps == null))
						{
							XmlAttribute xAtr;
							
							xAtr=xPreCycleProps.Attributes["TimeLength"];
							if (!(xAtr == null))
							{
								double t=0;
								if (double.TryParse(xAtr.Value, out t))
								{
									PreCycleProperties.TimeLength = t;
								}
								else
								{
									return(false); //Value of attribute TimeLength is not a number
								}
							}
							else
							{
								return(false); //Attribute TimeLength not found in node PreCycleProperties
							}
							
							xAtr=xPreCycleProps.Attributes["DataFile"];
							if (!(xAtr == null))
							{
								PreCycleProperties.DataFile = xAtr.Value;
							}
							else
							{
								return(false); //Attribute DataFile not found in node PreCycleProperties
							}
						}
						else
						{
							return(false); //Node PreCycleProperties not found
						}
						
						//In-Cycle
						XmlNode xInCycleProps = xPartProps.SelectSingleNode("InCycleProperties");
						if (!(xInCycleProps == null))
						{
							XmlAttribute xAtr;
							
							xAtr=xInCycleProps.Attributes["TimeLength"];
							if (!(xAtr == null))
							{
								double t=0;
								if (double.TryParse(xAtr.Value,out t))
								{
									InCycleProperties.TimeLength = t;
								}
								else
								{
									return(false); //Value of attribute TimeLength is not a number
								}
							}
							else
							{
								return(false); //Attribute TimeLength not found in node InCycleProperties
							}
							
							xAtr=xInCycleProps.Attributes["DataFile"];
							if (!(xAtr == null))
							{
								InCycleProperties.DataFile = xAtr.Value;
							}
							else
							{
								return(false); //Attribute DataFile not found in node InCycleProperties
							}
						}
						else
						{
							return(false); //Node InCycleProperties not found
						}
						
						//Post-Cycle
						XmlNode xPostCycleProps = xPartProps.SelectSingleNode("PostCycleProperties");
						if (!(xPostCycleProps == null))
						{
							XmlAttribute xAtr;
							
							xAtr=xPostCycleProps.Attributes["TimeLength"];
							if (!(xAtr == null))
							{
								double t=0;
								if (double.TryParse(xAtr.Value,out t))
								{
									PostCycleProperties.TimeLength = t;
								}
								else
								{
									return(false); //Value of attribute TimeLength is not a number
								}
							}
							else
							{
								return(false); //Attribute TimeLength not found in node PostCycleProperties
							}
							
							xAtr=xPostCycleProps.Attributes["DataFile"];
							if (!(xAtr == null))
							{
								PostCycleProperties.DataFile = xAtr.Value;
							}
							else
							{
								return(false); //Attribute DataFile not found in node PostCycleProperties
							}
						}
						else
						{
							return(false); //Node PostCycleProperties not found
						}
					}
					else
					{
						return(false); //Node CyclePartsProperties not found
					}
					
					//Cycle parameters
					XmlNode xCycleParams = xCycleCfg.SelectSingleNode("CycleParameters");
					if (!(xCycleParams == null))
					{
						Parameters = new List<CycleParameter>();
						
						foreach (XmlNode xParam in xCycleParams.ChildNodes)
						{
							CycleParameter oParam = new CycleParameter();
							
							XmlAttribute xAtr;
							XmlNode xData;
							
							//Parameter Name
							xAtr=xParam.Attributes["Name"];
							if (!(xAtr == null))
							{
								if (!(xAtr.Value.Equals("")))
								{
									oParam.Name = xAtr.Value;
								}
								else
								{
									return(false); //Value of attribute Name is empty
								}
							}
							else
							{
								return(false); //Attribute Name not found in node xParam
							}
							
							//Parameter Message Id
							xAtr=xParam.Attributes["MessageId"];
							if (!(xAtr == null))
							{
								if (!(xAtr.Value.Equals("")))
								{
									oParam.MsgId = xAtr.Value;
								}
								else
								{
									return(false); //Value of attribute MessageId is empty
								}
							}
							else
							{
								return(false); //Attribute MessageId not found in node xParam
							}
							
							//Pre-Cycle data
							xData = xParam.SelectSingleNode("PreCycleData");
							if (!(xData == null))
							{
								//Source
								xAtr = xData.Attributes["Source"];
								if (!(xAtr == null))
								{
									CycleDataSource Src = CycleDataSource.None;
									
									if (Enum.TryParse(xAtr.Value, out Src))
									{
										oParam.PreCycle.Source = Src;
									}
									else
									{
										return(false); //Value of attribute Source is not part of enumeration
									}
								}
								else
								{
									return(false); //Attribute Source not found in node PreCycleData
								}
								
								//Data
								xAtr = xData.Attributes["Data"];
								if (!(xAtr == null))
								{
									if (!(xAtr.Value.Equals("")))
									{
										oParam.PreCycle.Data = xAtr.Value;
									}
									else
									{
										return(false); //Value of attribute Data is empty
									}
								}
								else
								{
									return(false); //Attribute Data not found in node PreCycleData
								}
								
								//Library
								xAtr = xData.Attributes["Library"];
								if (!(xAtr == null))
								{
									if (!(xAtr.Value.Equals("")))
									{
										oParam.PreCycle.Library = xAtr.Value;
									}
									else
									{
										return(false); //Value of attribute Library is empty
									}
								}
								else
								{
									return(false); //Attribute Library not found in node PreCycleData
								}
							}
							else
							{
								return(false); //Node PreCycleData not found
							}
							
							//In-cycle data
							xData = xParam.SelectSingleNode("InCycleData");
							if (!(xData == null))
							{
								//Source
								xAtr = xData.Attributes["Source"];
								if (!(xAtr == null))
								{
									CycleDataSource Src = CycleDataSource.None;
									
									if (Enum.TryParse(xAtr.Value, out Src))
									{
										oParam.InCycle.Source = Src;
									}
									else
									{
										return(false); //Value of attribute Source is not part of enumeration
									}
								}
								else
								{
									return(false); //Attribute Source not found in node InCycleData
								}
								
								//Data
								xAtr = xData.Attributes["Data"];
								if (!(xAtr == null))
								{
									if (!(xAtr.Value.Equals("")))
									{
										oParam.InCycle.Data = xAtr.Value;
									}
									else
									{
										return(false); //Value of attribute Data is empty
									}
								}
								else
								{
									return(false); //Attribute Data not found in node InCycleData
								}
								
								//Library
								xAtr = xData.Attributes["Library"];
								if (!(xAtr == null))
								{
									if (!(xAtr.Value.Equals("")))
									{
										oParam.InCycle.Library = xAtr.Value;
									}
									else
									{
										return(false); //Value of attribute Library is empty
									}
								}
								else
								{
									return(false); //Attribute Library not found in node InCycleData
								}
							}
							else
							{
								return(false); //Node InCycleData not found
							}
							
							xData = xParam.SelectSingleNode("PostCycleData");
							if (!(xData == null))
							{
								//Source
								xAtr = xData.Attributes["Source"];
								if (!(xAtr == null))
								{
									CycleDataSource Src = CycleDataSource.None;
									
									if (Enum.TryParse(xAtr.Value, out Src))
									{
										oParam.PostCycle.Source = Src;
									}
									else
									{
										return(false); //Value of attribute Source is not part of enumeration
									}
								}
								else
								{
									return(false); //Attribute Source not found in node PostCycleData
								}
								
								//Data
								xAtr = xData.Attributes["Data"];
								if (!(xAtr == null))
								{
									if (!(xAtr.Value.Equals("")))
									{
										oParam.PostCycle.Data = xAtr.Value;
									}
									else
									{
										return(false); //Value of attribute Data is empty
									}
								}
								else
								{
									return(false); //Attribute Data not found in node PostCycleData
								}
								
								//Library
								xAtr = xData.Attributes["Library"];
								if (!(xAtr == null))
								{
									if (!(xAtr.Value.Equals("")))
									{
										oParam.PostCycle.Library = xAtr.Value;
									}
									else
									{
										return(false); //Value of attribute Library is empty
									}
								}
								else
								{
									return(false); //Attribute Library not found in node PostCycleData
								}
							}
							else
							{
								return(false); //Node PostCycleData not found
							}
							
							Parameters.Add(oParam);
						}
					}
					else
					{
						return(false); //Node CycleParameters not found
					}
				}
				else
				{
					return(false); //Node CycleConfiguration not found
				}
			}
			else
			{
				return(false); //Path empty
			}
			
			FilePath = fPath;
			bModified = false;
			return(true); //No Error
		}
		
		/// <summary>
		/// Return the cycle paramater matching with name and message identifier given as argument
		/// </summary>
		/// <param name="MsgId">Message identifier of the cycle paramater to get</param>
		/// <param name="Name">Name of cycle parameter to get</param>
		/// <returns>Cycle paramater matching wiht name and message identifier given as argument. Return null if not found</returns>
		public CycleParameter GetCycleParameter(string MsgId, string Name)
		{
			foreach (CycleParameter oParam in Parameters)
			{
				if (oParam.MsgId.Equals(MsgId) && oParam.Name.Equals(Name))
				{
					return(oParam);
				}
			}
			
			return(null);
		}
		
		/// <summary>
		/// Return a flag indicating whether or not one or more virtual channel is used by the cycle creation configuration
		/// </summary>
		/// <returns>Virtual channel use flag: True = virtual used / False = virtual not used</returns>
		public bool IsCycleUsingVirtualChannel()
		{
			foreach (CycleParameter oParam in Parameters)
			{
				CyclePart ePart = CyclePart.PreCycle;
				
				while (!(ePart.Equals(CyclePart.None)))
				{
					CycleDataPart oDataPart = oParam.GetDataParameterDataPart(ePart);
					
					if (oDataPart.Source.Equals(CycleDataSource.VirtualChannel))
					{
						return(true);
					}
					
					switch (ePart)
					{
						case CyclePart.PreCycle:
							ePart = CyclePart.InCycle;
							break;
						case CyclePart.InCycle:
							ePart = CyclePart.PostCycle;
							break;
						case CyclePart.PostCycle:
							ePart = CyclePart.None;
							break;
					}
				}
			}
			
			return(false);
		}
		
		#endregion
		
		#region Private methodes
		#endregion
	}
}
