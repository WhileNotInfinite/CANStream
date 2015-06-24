/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 5/9/2014
 * Time: 14:25 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CANStream
{
	#region Enums
	
	public enum CS_BuiltInSignalType
	{
		None     = 0, //No signal
		Sinusoid = 1, //Sinusoidal signal      : Frequency, Magnitude, Offset, Phase
		Pulse    = 2, //Pulses (PWM) signal    : Frequency, Width
		Triangle = 3, //Triangle signal        : Frequency, Magnitude, Offset, Phase
		Slopes   = 4, //Repeating ramps signal : Frequency, StartValue, EndValue, 
		Ramp     = 5, //Single ramp signal     : Slope, StartValue, StartTime
		Step     = 6, //Single step signal     : StartValue, EndValue, StartTime
		Random   = 7, //Random value signal    : MinValue, MaxValue
	}
	
	#endregion
	
	/// <summary>
	/// CANStream Built-in signal properties class
	/// </summary>
	public class CS_BuiltInSignalProperties
	{
		#region Public members
		
		/// <summary>
		/// Periodic signal frequency
		/// </summary>
		public double Frequency;
		
		/// <summary>
		/// Signal peak to peak amplitude
		/// </summary>
		public double Magnitude;
		
		/// <summary>
		/// Signal offset with respect to zero
		/// </summary>
		public double Offset;
		
		/// <summary>
		/// Periodic signal phase offset
		/// </summary>
		public double Phase;
		
		/// <summary>
		/// Pulse width ratio
		/// </summary>
		public double Width;
		
		/// <summary>
		/// Signal start value
		/// </summary>
		public double StartValue;
		
		/// <summary>
		/// Signal end value
		/// </summary>
		public double EndValue;
		
		/// <summary>
		/// Ramp signal slope
		/// </summary>
		public double Slope;
		
		/// <summary>
		/// Ramp & Step signal start time
		/// </summary>
		public double StartTime;
		
		/// <summary>
		/// Random signal min value
		/// </summary>
		public double MinValue;
		
		/// <summary>
		/// Random signal max value
		/// </summary>
		public double MaxValue;
	
		#endregion
		
		public CS_BuiltInSignalProperties()
		{
			Frequency = 0;
			Magnitude = 0;
			Offset = 0;
			Phase = 0;
			Width = 0;
			StartValue = 0;
			EndValue = 0;
			Slope = 0;
			StartTime = 0;
			MinValue = 0;
			MaxValue = 0;
		}
	}
	
	/// <summary>
	/// CANStream Built-in signal class
	/// </summary>
	public class CS_BuiltInSignal
	{
		#region Public members
		
		/// <summary>
		/// Signal name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Signal type (Sinusoid, triangle, step, etc...)
		/// </summary>
		public CS_BuiltInSignalType Type;
		
		/// <summary>
		/// Signal description
		/// </summary>
		public string Description;
		
		/// <summary>
		/// Signal unit
		/// </summary>
		public string Unit;
		
		/// <summary>
		/// Signal properties (Frequency, Magnitude, StartTime, etc...)
		/// </summary>
		public CS_BuiltInSignalProperties Properties;
		
		/// <summary>
		/// Signal number decimal digit
		/// </summary>
		public int Decimals;
		
		/// <summary>
		/// Parent library reference of the signal
		/// </summary>
		public CS_BuiltInSignalLibrary ParentLibrary;
		
		#endregion
		
		#region Private members
		
		private Random oRandNumGen;
		
		#endregion
		
		public CS_BuiltInSignal()
		{
			Name = "";
			Type = CS_BuiltInSignalType.None;
			Description = "";
			Unit = "";
			Properties = new CS_BuiltInSignalProperties();
			Decimals = 1;
			
			ParentLibrary = null;
			
			oRandNumGen = new Random();
		}
		
		#region Private methodes
		#endregion
		
		#region Public methodes
		
		/// <summary>
		/// Return the signal value for the time given as argument
		/// </summary>
		/// <param name="TimeValue">Time value for signal value computation</param>
		/// <returns>Value of the signal at the time given</returns>
		public double GetSignalValueAtTime(double TimeValue)
		{
			TimeValue = TimeValue/1000;
			
			switch (Type)
			{
				case CS_BuiltInSignalType.Sinusoid:
					
					return((Properties.Magnitude * Math.Sin(2*Math.PI*Properties.Frequency * (TimeValue + Properties.Phase))) + Properties.Offset);
					
				case CS_BuiltInSignalType.Pulse:
					
					double Pwm = Properties.Width / (1/Properties.Frequency);
					
					if ((Math.Atan(Math.Tan(Math.PI*Properties.Frequency*TimeValue-Math.PI/2))+Math.PI/2)/Math.PI > Pwm)
					{
						return(0);
					}
					else
					{
						return(Properties.Magnitude);
					}
						
				case CS_BuiltInSignalType.Triangle:
					
					return(((2*Math.Asin(Math.Cos(2*Math.PI*Properties.Frequency*((TimeValue)+Properties.Phase)))/Math.PI)*Properties.Magnitude)+Properties.Offset);

					
				case CS_BuiltInSignalType.Slopes:
					
					return((((Math.Atan(Math.Tan(Math.PI*Properties.Frequency*(TimeValue)-Math.PI/2))+Math.PI/2)/Math.PI)*(Properties.EndValue-Properties.StartValue))+Properties.StartValue);
					
				case CS_BuiltInSignalType.Ramp:
					
					if (TimeValue >= Properties.StartTime)
					{
						return(Properties.StartValue + ((TimeValue - Properties.StartTime) * Properties.Slope));
					}
					else
					{
						return(Properties.StartValue);
					}
					
				case CS_BuiltInSignalType.Step:
					
					if (TimeValue >= Properties.StartTime)
					{
						return(Properties.EndValue);
					}
					else
					{
						return(Properties.StartValue);
					}
					
				case CS_BuiltInSignalType.Random:
					
					double Amplitude = Properties.MaxValue - Properties.MinValue;
					
					if (!(Amplitude == 0))
					{
						double RanNum= oRandNumGen.NextDouble() * Amplitude;
						while (!(RanNum >= Properties.MinValue & RanNum <= Properties.MaxValue))
						{
							RanNum= oRandNumGen.NextDouble();
						}
						
						return(RanNum);
					}
					
					return(0);
					
				default:
					
					return(0);
			}
		}
		
		#endregion
	}
	
	/// <summary>
	/// CANStream Built-in signal library class
	/// </summary>
	public class CS_BuiltInSignalLibrary
	{
		#region Public members
		
		/// <summary>
		/// Signal library name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Signal library comment
		/// </summary>
		public string Comment;
		
		/// <summary>
		/// Signal library read only protection flag
		/// </summary>
		public bool ReadOnly;
		
		/// <summary>
		/// Library signals collection
		/// </summary>
		public List<CS_BuiltInSignal> Signals;
		
		/// <summary>
		/// Signal library xml file path
		/// </summary>
		public string FilePath;
		
		/// <summary>
		/// Signal library modified flag
		/// </summary>
		public bool bModified;
		
		/// <summary>
		/// Libraries collection parent of the library
		/// </summary>
		public CS_BuiltInSignalLibCollection CollectionParent;
		
		#endregion
		
		#region Private members
		#endregion
		
		public CS_BuiltInSignalLibrary()
		{
			Name = "";
			Comment = "";
			ReadOnly = false;
			Signals =  new List<CS_BuiltInSignal>();
			
			FilePath = "";
			bModified = false;
			CollectionParent = null;			
		}
		
		#region Private methodes
		#endregion
		
		#region Public methodes
		
		#region Old functions
		/*
		/// <summary>
		/// Library file writing function
		/// </summary>
		/// <param name="LibPath">Library file path</param>
		public void WriteLibraryFile(string LibPath)
		{
			XmlDocument oXmlLib = new XmlDocument();
			
			XmlElement xLibrary = oXmlLib.CreateElement("CS_BuiltInSignalsLibrary");
			oXmlLib.AppendChild(xLibrary);
			
			XmlAttribute xAtrLibName = oXmlLib.CreateAttribute("Name");
			xAtrLibName.Value = Name;
			xLibrary.Attributes.Append(xAtrLibName);
			
			XmlAttribute xAtrReadOnly = oXmlLib.CreateAttribute("ReadOnly");
			xAtrReadOnly.Value = ReadOnly.ToString();
			xLibrary.Attributes.Append(xAtrReadOnly);
			
			XmlElement xLibComment = oXmlLib.CreateElement("LibraryComment");
			xLibComment.InnerText =  Comment;
			xLibrary.AppendChild(xLibComment);
			
			XmlElement xLibSignals =  oXmlLib.CreateElement("Signals");
			xLibrary.AppendChild(xLibSignals);
			
			foreach (CS_BuiltInSignal oSignal in Signals)
			{
				XmlElement xSignal = oXmlLib.CreateElement("Signal");
				xLibSignals.AppendChild(xSignal);
				
				XmlAttribute xAtrSigName =  oXmlLib.CreateAttribute("Name");
				xAtrSigName.Value = oSignal.Name;
				xSignal.Attributes.Append(xAtrSigName);
				
				XmlAttribute xAtrSigType =  oXmlLib.CreateAttribute("Type");
				xAtrSigType.Value = oSignal.Type.ToString();
				xSignal.Attributes.Append(xAtrSigType);
				
				XmlAttribute xAtrSigUnit = oXmlLib.CreateAttribute("Unit");
				xAtrSigUnit.Value = oSignal.Unit;
				xSignal.Attributes.Append(xAtrSigUnit);
				
				XmlAttribute xAtrChanDec = oXmlLib.CreateAttribute("Decimal");
				xAtrChanDec.Value = oSignal.Decimals.ToString();
				xSignal.Attributes.Append(xAtrChanDec);
				
					XmlElement xSigComment =  oXmlLib.CreateElement("Description");
					xSigComment.InnerText =  oSignal.Description;
					xSignal.AppendChild(xSigComment);
					
					XmlElement xSigProperties =  oXmlLib.CreateElement("Properties");
					xSignal.AppendChild(xSigProperties);
					
						XmlElement xProp = null;
						
						xProp = oXmlLib.CreateElement("Frequency");
						xProp.InnerText = oSignal.Properties.Frequency.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Magnitude");
						xProp.InnerText = oSignal.Properties.Magnitude.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Offset");
						xProp.InnerText = oSignal.Properties.Offset.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Phase");
						xProp.InnerText = oSignal.Properties.Phase.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Width");
						xProp.InnerText = oSignal.Properties.Width.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("StartValue");
						xProp.InnerText = oSignal.Properties.StartValue.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("EndValue");
						xProp.InnerText = oSignal.Properties.EndValue.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Slope");
						xProp.InnerText = oSignal.Properties.Slope.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("StartTime");
						xProp.InnerText = oSignal.Properties.StartTime.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("MinValue");
						xProp.InnerText = oSignal.Properties.MinValue.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("MaxValue");
						xProp.InnerText = oSignal.Properties.MaxValue.ToString();
						xSigProperties.AppendChild(xProp);
			}
			
			oXmlLib.Save(LibPath);
			
			FilePath = LibPath;
			bModified =  false;
		}
		
		/// <summary>
		/// Library file reading function
		/// </summary>
		/// <param name="LibPath">Library file path</param>
		/// <returns>Reading error flag: True = No error / False = Error</returns>
		public bool ReadLibraryFile(string LibPath)
		{
			try
			{
				XmlDocument oXmlLib = new XmlDocument();
				
				oXmlLib.Load(LibPath);
				FilePath = LibPath;
				
				XmlNode xLibrary = oXmlLib.FirstChild;
				
				if (xLibrary.Name.Equals("CS_BuiltInSignalsLibrary"))
				{
					Name = xLibrary.Attributes["Name"].Value;
					ReadOnly = Convert.ToBoolean(xLibrary.Attributes["ReadOnly"].Value);
					
					XmlNode xComment = xLibrary.SelectSingleNode("LibraryComment");
					if (!(xComment == null))
					{
						Comment = xComment.InnerText;
					}
					
					XmlNode xSignals = xLibrary.SelectSingleNode("Signals");
					if (!(xSignals == null))
					{
						Signals = new List<CS_BuiltInSignal>();
						
						foreach (XmlNode xSignal in xSignals.ChildNodes)
						{
							CS_BuiltInSignal oSignal = new CS_BuiltInSignal();
							
							oSignal.Name = xSignal.Attributes["Name"].Value;
							
							CS_BuiltInSignalType SigType = CS_BuiltInSignalType.None;
							if (Enum.TryParse(xSignal.Attributes["Type"].Value, out SigType))
							{
								oSignal.Type = SigType;
							}
							  
							
							int dec = 0;
							if (int.TryParse(xSignal.Attributes["Decimal"].Value, out dec))
							{
								oSignal.Decimals =  dec;
							}
							
							oSignal.Unit = xSignal.Attributes["Unit"].Value;
							
							XmlNode xSigComment =  xSignal.SelectSingleNode("Description");
							if (!(xSigComment == null))
							{
								oSignal.Description = xSigComment.InnerText;
							}
							
							XmlNode xSigProperties =  xSignal.SelectSingleNode("Properties");
							if (!(xSigProperties == null))
							{
								double Val = 0;
								XmlNode xSigProp = null;
								
								xSigProp = xSigProperties.SelectSingleNode("Frequency");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Frequency = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Magnitude");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Magnitude = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Offset");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Offset = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Phase");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Phase = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Width");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Width = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("StartValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.StartValue = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("EndValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.EndValue = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Slope");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Slope = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("StartTime");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.StartTime = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("MinValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.MinValue = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("MaxValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.MaxValue = Val;
									}
								}
							}

							oSignal.ParentLibrary = this;
							Signals.Add(oSignal);
						}
					}
					else
					{
						return(false);
					}
				}
				else
				{
					return(false);
				}
			}
			catch
			{
				return(false);
			}
			
			return(true);
		}
		*/
		#endregion
		
		/// <summary>
		/// Library file writing function
		/// </summary>
		/// <param name="LibPath">Library file path</param>
		public void WriteLibraryFile(string LibPath)
		{
			XmlDocument oXmlLib = new XmlDocument();
	
			XmlElement xLibrary = oXmlLib.CreateElement("CS_BuiltInSignalsLibrary");
			oXmlLib.AppendChild(xLibrary);
			
			CreateLibraryXmlNode(oXmlLib);
			
			oXmlLib.Save(LibPath);
	
			FilePath = LibPath;
			bModified =  false;
		}
		
		/// <summary>
		/// Create the built-in signal library XML node
		/// </summary>
		/// <param name="oXmlLib">XmlDocument class reference creating the node</param>
		public void CreateLibraryXmlNode(XmlDocument oXmlLib)
		{
			XmlNode xLibrary = null;
			
			if (oXmlLib.FirstChild.Name.Equals("CS_BuiltInSignalsLibrary")) //Making built-in signal library node for a built-in signal library file
			{
				xLibrary =  oXmlLib.FirstChild;
			}
			else //Making built-in signal library node for embeded library file
			{	
				/*
				 * If destination container of the node contains multiple instance of CS_BuiltInSignalsLibrary node
				 * Loop until finding the empty one (latest created)
				*/
				
				xLibrary = oXmlLib.FirstChild.SelectSingleNode("CS_BuiltInSignalsLibrary");
				while (xLibrary.HasChildNodes)
				{
					xLibrary = xLibrary.NextSibling;
				}
			}
			
			if (xLibrary == null) //To avoid crash, just in case...
			{
				return;
			}
			
			XmlAttribute xAtrLibName = oXmlLib.CreateAttribute("Name");
			xAtrLibName.Value = Name;
			xLibrary.Attributes.Append(xAtrLibName);
			
			XmlAttribute xAtrReadOnly = oXmlLib.CreateAttribute("ReadOnly");
			xAtrReadOnly.Value = ReadOnly.ToString();
			xLibrary.Attributes.Append(xAtrReadOnly);
			
			XmlElement xLibComment = oXmlLib.CreateElement("LibraryComment");
			xLibComment.InnerText =  Comment;
			xLibrary.AppendChild(xLibComment);
			
			XmlElement xLibSignals =  oXmlLib.CreateElement("Signals");
			xLibrary.AppendChild(xLibSignals);
			
			foreach (CS_BuiltInSignal oSignal in Signals)
			{
				XmlElement xSignal = oXmlLib.CreateElement("Signal");
				xLibSignals.AppendChild(xSignal);
				
				XmlAttribute xAtrSigName =  oXmlLib.CreateAttribute("Name");
				xAtrSigName.Value = oSignal.Name;
				xSignal.Attributes.Append(xAtrSigName);
				
				XmlAttribute xAtrSigType =  oXmlLib.CreateAttribute("Type");
				xAtrSigType.Value = oSignal.Type.ToString();
				xSignal.Attributes.Append(xAtrSigType);
				
				XmlAttribute xAtrSigUnit = oXmlLib.CreateAttribute("Unit");
				xAtrSigUnit.Value = oSignal.Unit;
				xSignal.Attributes.Append(xAtrSigUnit);
				
				XmlAttribute xAtrChanDec = oXmlLib.CreateAttribute("Decimal");
				xAtrChanDec.Value = oSignal.Decimals.ToString();
				xSignal.Attributes.Append(xAtrChanDec);
				
					XmlElement xSigComment =  oXmlLib.CreateElement("Description");
					xSigComment.InnerText =  oSignal.Description;
					xSignal.AppendChild(xSigComment);
					
					XmlElement xSigProperties =  oXmlLib.CreateElement("Properties");
					xSignal.AppendChild(xSigProperties);
					
						XmlElement xProp = null;
						
						xProp = oXmlLib.CreateElement("Frequency");
						xProp.InnerText = oSignal.Properties.Frequency.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Magnitude");
						xProp.InnerText = oSignal.Properties.Magnitude.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Offset");
						xProp.InnerText = oSignal.Properties.Offset.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Phase");
						xProp.InnerText = oSignal.Properties.Phase.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Width");
						xProp.InnerText = oSignal.Properties.Width.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("StartValue");
						xProp.InnerText = oSignal.Properties.StartValue.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("EndValue");
						xProp.InnerText = oSignal.Properties.EndValue.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("Slope");
						xProp.InnerText = oSignal.Properties.Slope.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("StartTime");
						xProp.InnerText = oSignal.Properties.StartTime.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("MinValue");
						xProp.InnerText = oSignal.Properties.MinValue.ToString();
						xSigProperties.AppendChild(xProp);
						
						xProp = oXmlLib.CreateElement("MaxValue");
						xProp.InnerText = oSignal.Properties.MaxValue.ToString();
						xSigProperties.AppendChild(xProp);
			}
		}
		
		/// <summary>
		/// Library file reading function
		/// </summary>
		/// <param name="LibPath">Library file path</param>
		/// <returns>Reading error flag: True = No error / False = Error</returns>
		public bool ReadLibraryFile(string LibPath)
		{
			XmlDocument oXmlLib = new XmlDocument();
			oXmlLib.Load(LibPath);
			
			if (ReadLibraryXmlNode(oXmlLib.FirstChild))
			{
				FilePath = LibPath;
				bModified = false;
				return(true);
			}
			else
			{
				return(false);
			}
		}
		
		/// <summary>
		/// Read the built-in signal library object XML node
		/// </summary>
		/// <param name="xLibrary">XML Node to read</param>
		/// <returns>Reading error flag: True = No error / False = Error</returns>
		public bool ReadLibraryXmlNode(XmlNode xLibrary)
		{
			try
			{
				if (xLibrary.Name.Equals("CS_BuiltInSignalsLibrary"))
				{
					Name = xLibrary.Attributes["Name"].Value;
					ReadOnly = Convert.ToBoolean(xLibrary.Attributes["ReadOnly"].Value);
					
					XmlNode xComment = xLibrary.SelectSingleNode("LibraryComment");
					if (!(xComment == null))
					{
						Comment = xComment.InnerText;
					}
					
					XmlNode xSignals = xLibrary.SelectSingleNode("Signals");
					if (!(xSignals == null))
					{
						Signals = new List<CS_BuiltInSignal>();
						
						foreach (XmlNode xSignal in xSignals.ChildNodes)
						{
							CS_BuiltInSignal oSignal = new CS_BuiltInSignal();
							
							oSignal.Name = xSignal.Attributes["Name"].Value;
							
							CS_BuiltInSignalType SigType = CS_BuiltInSignalType.None;
							if (Enum.TryParse(xSignal.Attributes["Type"].Value, out SigType))
							{
								oSignal.Type = SigType;
							}
							  
							
							int dec = 0;
							if (int.TryParse(xSignal.Attributes["Decimal"].Value, out dec))
							{
								oSignal.Decimals =  dec;
							}
							
							oSignal.Unit = xSignal.Attributes["Unit"].Value;
							
							XmlNode xSigComment =  xSignal.SelectSingleNode("Description");
							if (!(xSigComment == null))
							{
								oSignal.Description = xSigComment.InnerText;
							}
							
							XmlNode xSigProperties =  xSignal.SelectSingleNode("Properties");
							if (!(xSigProperties == null))
							{
								double Val = 0;
								XmlNode xSigProp = null;
								
								xSigProp = xSigProperties.SelectSingleNode("Frequency");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Frequency = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Magnitude");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Magnitude = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Offset");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Offset = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Phase");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Phase = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Width");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Width = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("StartValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.StartValue = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("EndValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.EndValue = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("Slope");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.Slope = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("StartTime");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.StartTime = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("MinValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.MinValue = Val;
									}
								}
								
								xSigProp = xSigProperties.SelectSingleNode("MaxValue");
								if (!(xSigProp == null))
								{
									if (double.TryParse(xSigProp.InnerText, out Val))
									{
										oSignal.Properties.MaxValue = Val;
									}
								}
							}
		
							oSignal.ParentLibrary = this;
							Signals.Add(oSignal);
						}
					}
					else
					{
						return(false);
					}
				}
				else
				{
					return(false);
				}
			}
			catch
			{
				return(false);
			}
			
			return(true);
		}
		
		/// <summary>
		///  Return the CS_BuiltInSignal corresponding to the name given as argument
		/// </summary>
		/// <param name="Name">Name of signal to return</param>
		/// <returns>Built-in signal, null if not found</returns>
		public CS_BuiltInSignal GetSignal(string Name)
		{
			foreach (CS_BuiltInSignal oSignal in Signals)
			{
				if (oSignal.Name.Equals(Name))
				{
					return(oSignal);
				}
			}
			
			return(null);
		}
		
		/// <summary>
		/// Return a flag indicating whether the signal name given as argument exists in the library
		/// </summary>
		/// <param name="Name">Name of the channel</param>
		/// <returns>True: Channel exists / False: doesn't exist</returns>
		public bool SignalExists(string Name)
		{
			foreach (CS_BuiltInSignal oSignal in Signals)
			{
				if (oSignal.Name.Equals(Name))
				{
					return(true);
				}
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return the index of the signal into the library corresponding to the signal name given as argument
		/// </summary>
		/// <param name="Name">Name of the signal</param>
		/// <returns>Index of the signal in the library, -1 if not found</returns>
		public int GetSignalIndex(string Name)
		{
			for (int iSignal=0; iSignal<Signals.Count; iSignal++)
			{
				if (Signals[iSignal].Name.Equals(Name))
				{
					return(iSignal);
				}
			}
			
			return(-1);
		}
		
		/// <summary>
		/// Clone the built-in signal given as argument
		/// </summary>
		/// <param name="OrigialChannel">Built-in signal to be cloned</param>
		/// <returns>Clone of the original built-in signal</returns>
		public CS_BuiltInSignal CloneSignal(CS_BuiltInSignal OriginalSignal)
		{
			if (!(OriginalSignal == null))
			{
				CS_BuiltInSignal CloneSig = new CS_BuiltInSignal();
				
				CloneSig.Name = OriginalSignal.Name;
				CloneSig.Type = OriginalSignal.Type;
				CloneSig.Unit = OriginalSignal.Unit;
				CloneSig.Decimals = OriginalSignal.Decimals;
				CloneSig.Description = OriginalSignal.Description;
				
				CloneSig.Properties.EndValue = OriginalSignal.Properties.EndValue;
				CloneSig.Properties.Frequency = OriginalSignal.Properties.Frequency;
				CloneSig.Properties.Magnitude = OriginalSignal.Properties.Magnitude;
				CloneSig.Properties.MaxValue = OriginalSignal.Properties.MaxValue;
				CloneSig.Properties.MinValue = OriginalSignal.Properties.MinValue;
				CloneSig.Properties.Offset = OriginalSignal.Properties.Offset;
				CloneSig.Properties.Phase = OriginalSignal.Properties.Phase;
				CloneSig.Properties.Slope = OriginalSignal.Properties.Slope;
				CloneSig.Properties.StartTime = OriginalSignal.Properties.StartTime;
				CloneSig.Properties.StartValue = OriginalSignal.Properties.StartValue;
				CloneSig.Properties.Width = OriginalSignal.Properties.Width;
				
				return(CloneSig);
			}
			
			return(null);
		}
		
		/// <summary>
		///  Return the value of signal given for the time given as arguments
		/// </summary>
		/// <param name="SignalName">Name of signal to be computed</param>
		/// <param name="TimeValue">Time value for signal value computation</param>
		/// <returns>Value of the signal given at the time given</returns>
		public double GetSignalValueAtTime(string SignalName, double TimeValue)
		{
			CS_BuiltInSignal oSignal = GetSignal(SignalName);
			
			if (!(oSignal == null))
			{
				return(oSignal.GetSignalValueAtTime(TimeValue));
			}
			
			return(0);
		}
		
		#endregion
	}
	
	/// <summary>
	/// CANStream Built-in signal libraries collection
	/// </summary>
	public class CS_BuiltInSignalLibCollection
	{
		#region Public members
		
		/// <summary>
		/// Built-in signal libraries collection
		/// </summary>
		public List<CS_BuiltInSignalLibrary> Libraries;
		
		#endregion
		
		#region Private members
		#endregion
		
		public CS_BuiltInSignalLibCollection()
		{
			Libraries = new List<CS_BuiltInSignalLibrary>();
		}
		
		#region Private methodes
		#endregion
		
		#region Public methodes
		
		/// <summary>
		/// Save the libraries collection in a XML file
		/// </summary>
		/// <param name="FilePath">Path of the file to create</param>
		public void SaveLibrariesList(string FilePath)
		{
			XmlDocument oXLibList =  new XmlDocument();
				
			XmlElement xList = oXLibList.CreateElement("SignalsLibrariesList");
			oXLibList.AppendChild(xList);
			
			foreach (CS_BuiltInSignalLibrary oLib in Libraries)
			{
				if (!(oLib.FilePath.Equals("")))
				{
					XmlElement xLib = oXLibList.CreateElement("Library");
					xLib.InnerText =  oLib.FilePath;
					xList.AppendChild(xLib);
				}
			}
			
			oXLibList.Save(FilePath);
		}
		
		/// <summary>
		/// Load a libraries collection from a XML file
		/// </summary>
		/// <param name="FilePath">Path of the file to read</param>
		/// <returns>Error flag: True =  No Error / False =  Error</returns>
		public bool LoadLibrariesList(string FilePath)
		{
			try
			{
				XmlDocument oXLibList =  new XmlDocument();
				oXLibList.Load(FilePath);
				
				XmlNode xLibs = oXLibList.FirstChild;
				if (xLibs.Name.Equals("SignalsLibrariesList"))
				{
					Libraries = new List<CS_BuiltInSignalLibrary>();
					
					foreach (XmlNode xLib in xLibs.ChildNodes)
					{
						if (File.Exists(xLib.InnerText))
						{
							CS_BuiltInSignalLibrary oLib = new CS_BuiltInSignalLibrary();
							
							if (oLib.ReadLibraryFile(xLib.InnerText))
							{
								oLib.CollectionParent = this;
								Libraries.Add(oLib);
							}
						}
					}
					
					return(true);
				}
				
				oXLibList = null;
			}
			catch
			{
				return(false);
			}
			
			return(false);
		}
		
		/// <summary>
		/// Add a built-in signal library into the collection
		/// </summary>
		/// <param name="oLibrary">Built-in signal library to add</param>
		public void AddLibrary(CS_BuiltInSignalLibrary oLibrary)
		{
			if (!(oLibrary == null))
			{
				oLibrary.CollectionParent = this;
				Libraries.Add(oLibrary);
			}
		}
		
		/// <summary>
		/// Return a flag indicating whether the library name given exists in the collection
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <returns>Exist flag: True = Exist / False = Doesn't exist</returns>
		public bool LibraryExists(string LibName)
		{
			foreach (CS_BuiltInSignalLibrary oLib in Libraries)
			{
				if (oLib.Name.Equals(LibName))
				{
					return(true);
				}
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return a flag indicating whether the signal name given exists in the library name given
		/// </summary>
		/// <param name="LibName">Name of the library to search<</param>
		/// <param name="SignalName">Name of the signal to search<</param>
		/// <returns>Exist flag: True = Exist / False = Doesn't exist</returns>
		public bool SignalExistsInLibrary(string LibName, string SignalName)
		{
			foreach (CS_BuiltInSignalLibrary oLib in Libraries)
			{
				if (oLib.Name.Equals(LibName))
				{
					return(oLib.SignalExists(SignalName));
				}
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return the built-in signal library corresponding to the name given as argument
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <returns>Built-in signal library, null if not found</returns>
		public CS_BuiltInSignalLibrary GetLibrary(string LibName)
		{
			foreach (CS_BuiltInSignalLibrary oLib in Libraries)
			{
				if (oLib.Name.Equals(LibName))
				{
					return(oLib);
				}
			}
			
			return(null);
		}
		
		/// <summary>
		/// Returm the index in the collection of the library name given as argument
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <returns>Index of the library in the collection, -1 if not found</returns>
		public  int GetLibraryIndex(string LibName)
		{
			for (int iLib=0; iLib<Libraries.Count; iLib++)
			{
				if (Libraries[iLib].Name.Equals(LibName))
				{
					return (iLib);
				}
			}
			
			return(-1);
		}
		
		/// <summary>
		///  Return the value of signal given of the library given for the time given as arguments
		/// </summary>
		/// <param name="LibraryName">Name of library containing signal to be computed</param>
		/// <param name="SignalName">Name of signal to be computed</param>
		/// <param name="TimeValue">Time value for signal value computation</param>
		/// <returns>Value of the signal given of library given at the time given</returns>
		public double GetSignalValueAtTime(string LibraryName, string SignalName, double TimeValue)
		{
			CS_BuiltInSignalLibrary oLib = GetLibrary(LibraryName);
			
			if (!(oLib == null))
			{
				return(oLib.GetSignalValueAtTime(SignalName,TimeValue));
			}
			
			return(0);
		}
		
		#endregion
	}
}
