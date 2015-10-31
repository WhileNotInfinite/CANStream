/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 1/28/2014
 * Time: 15:41 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CANStream
{
	#region Virtual channel built in functions
	
	public static class CS_BuiltIn_Func
	{
		#region Public methode
		
		#region Logic functions
		
		public static double IFEQ(double A, double B)
		{
			if (A==B)
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		public static double IFNE(double A, double B)
		{
			if (A!=B)
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		public static double INRG(double A, double Min, double Max)
		{
			if (A>=Min & A<=Max)
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		public static double OOR(double A, double Min, double Max)
		{
			if (!(A>=Min & A<=Max))
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		public static double IFGT(double A, double B)
		{
			if (A>B)
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		public static double IFGE(double A, double B)
		{
			if (A>=B)
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		public static double IFLT(double A, double B)
		{
			if (A<B)
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		public static double IFLE(double A, double B)
		{
			if (A<=B)
			{
				return(1);
			}
			else
			{
				return(0);
			}
		}
		
		#endregion
		
		#region Unit conversion function
		
		#region Angle unit
		
		public static double Deg2Rad(double A)
		{
			return(A*(2*Math.PI/360));
		}
		
		public static double Deg2Grad(double A)
		{
			return(A*1.111111111111111);
		}
		
		public static double Rad2Deg(double A)
		{
			return(A*(360/2*Math.PI));
		}
		
		public static double Rad2Grad(double A)
		{
			return(A*63.66197723675814);
		}
		
		public static double Grad2Deg(double A)
		{
			return(A*0.9);
		}
		
		public static double Grad2Rad(double A)
		{
			return(A*0.015707963267949);
		}
		                      
		#endregion
		
		#region Temperature unit
		
		public static double Celcius2Fahrenheit(double A)
		{
			return(A*9/5+32);
		}
		
		public static double Celcius2Kelvin(double A)
		{
			return(A+273.15);
		}
		
		public static double Fahrenheit2Celcius(double A)
		{
			return((A-32)*5/9);
		}
		
		public static double Fahrenheit2Kelvin(double A)
		{
			return(((A-32)*5/9)+273.15);
		}
		
		public static double Kelvin2Celcius(double A)
		{
			return(A-273.15);
		}
		
		public static double Kelvin2Fahrenheit(double A)
		{
			return((A-273.15)*9/5+32);
		}
		
		#endregion
		
		#region Pressure unit
		
		public static double Bar2Psi(double A)
		{
			return(A*14.50377438972831);
		}
		
		public static double Bar2Pa(double A)
		{
			return(A*100000);
		}
		
		public static double Bar2kPa(double A)
		{
			return(A*100);
		}
		
		public static double Bar2Atm(double A)
		{
			return(A*0.9869232667160128);
		}
		
		public static double Bar2MmHg(double A)
		{
			return(A*750.1875468867217);
		}
		
		public static double Psi2Bar(double A)
		{
			return(A*0.06894757);
		}
		
		public static double Psi2Pa(double A)
		{
			return(A*6894.757);
		}
		
		public static double Psi2kPa(double A)
		{
			return(A*6.894757);
		}
		
		public static double Psi2Atm(double A)
		{
			return(A*0.068045961016531);
		}
		
		public static double Psi2MmHg(double A)
		{
			return(A*51.72360840210053);
		}
		
		public static double Pa2Bar(double A)
		{
			return(A*0.00001);
		}
		
		public static double Pa2Psi(double A)
		{
			return(A*0.0001450377438972831);
		}
		
		public static double Pa2kPa(double A)
		{
			return(A*0.001);
		}
		
		public static double Pa2Atm(double A)
		{
			return(A*0.000009869232667160128);
		}
		
		public static double Pa2MmHg(double A)
		{
			return(A*0.0075018754688672);
		}
		
		public static double kPa2Bar(double A)
		{
			return(A*0.01);
		}
		
		public static double kPa2Psi(double A)
		{
			return(A*0.1450377438972831);
		}
		
		public static double kPa2Pa(double A)
		{
			return(A*1000);
		}
		
		public static double kPa2Atm(double A)
		{
			return(A*0.0098692326671601);
		}
		
		public static double kPa2MmHg(double A)
		{
			return(A*7.501875468867217);
		}
		
		public static double Atm2Bar(double A)
		{
			return(A*1.01325);
		}
		
		public static double Atm2Psi(double A)
		{
			return(A*14.69594940039221);
		}
		
		public static double Atm2Pa(double A)
		{
			return(A*101325);
		}
		
		public static double Atm2kPa(double A)
		{
			return(A*101.325);
		}
		
		public static double Atm2MmHg(double A)
		{
			return(A*760.1275318829707);
		}
		
		public static double MmHg2Bar(double A)
		{
			return(A*0.001333);
		}
		
		public static double MmHg2Psi(double A)
		{
			return(A*0.0193335312615078);
		}
		
		public static double MmHg2Pa(double A)
		{
			return(A*133.3);
		}
		
		public static double MmHg2kPa(double A)
		{
			return(A*0.1333);
		}
		
		public static double MmHg2Atm(double A)
		{
			return(A*0.0013155687145324);
		}
		
		#endregion
		
		#region Length unit
		
		public static double Meter2Yard(double A)
		{
			return(A*1.093613298337708);
		}
		
		public static double Meter2Feet(double A)
		{
			return(A*3.280839895013123);
		}
		
		public static double Meter2Km(double A)
		{
			return(A*0.001);
		}
		
		public static double Meter2Mile(double A)
		{
			return(A*0.000621371192237334);
		}
		
		public static double Yard2Meter(double A)
		{
			return(A*0.9144);
		}
		
		public static double Yard2Feet(double A)
		{
			return(A*3);
		}
		
		public static double Yard2Km(double A)
		{
			return(A*0.0009144);
		}
		
		public static double Yard2Mile(double A)
		{
			return(A*0.0005681818181818182);
		}
		
		public static double Feet2Meter(double A)
		{
			return(A*0.3048);
		}
		
		public static double Feet2Km(double A)
		{
			return(A*0.0003048);
		}
		
		public static double Feet2Yard(double A)
		{
			return(A*1/3);
		}
		
		public static double Feet2Mile(double A)
		{
			return(A*0.0001893939393939394);
		}
		
		public static double Km2Mile(double A)
		{
			return(A*0.621371192237334);
		}
		
		public static double Km2Yard(double A)
		{
			return(A*1093.613298337708);
		}
		
		public static double Km2Meter(double A)
		{
			return(A*0.001);
		}
		
		public static double Km2Feet(double A)
		{
			return(A*3280.839895013123);
		}
		
		public static double Mile2Km(double A)
		{
			return(A*1.609344);
		}
		
		public static double Mile2Meter(double A)
		{
			return(A*1609.344);
		}
		
		public static double Mile2Yard(double A)
		{
			return(A*1760);
		}
		
		public static double Mile2Feet(double A)
		{
			return(A*5280);
		}
		
		#endregion
		
		#region Weight unit
		
		public static double Gram2Kg(double A)
		{
			return(A*0.001);
		}
		
		public static double Gram2Tonne(double A)
		{
			return(A*0.000001);
		}
		
		public static double Gram2Ounce(double A)
		{
			return(A*0.0352739619495804);
		}
		
		public static double Gram2Pound(double A)
		{
			return(A*0.0022046226218488);
		}
		
		public static double Kg2Gram(double A)
		{
			return(A*1000);
		}
		
		public static double Kg2Tonne(double A)
		{
			return(A*0.001);
		}
		
		public static double Kg2Ounce(double A)
		{
			return(A*35.27396194958041);
		}
		
		public static double Kg2Pound(double A)
		{
			return(A*2.204622621848776);
		}
		
		public static double Tonne2Gram(double A)
		{
			return(A*0.000001);
		}
		
		public static double Tonne2Kg(double A)
		{
			return(A*0.001);
		}
		
		public static double Tonne2Ounce(double A)
		{
			return(A*35273.96194958041);
		}
		
		public static double Tonne2Pound(double A)
		{
			return(A*2204.622621848776);
		}
		
		public static double Ounce2Gram(double A)
		{
			return(A*28.349523125);
		}
		
		public static double Ounce2Kg(double A)
		{
			return(A*0.028349523125);
		}
		
		public static double Ounce2Tonne(double A)
		{
			return(A*0.000028349523125);
		}
		
		public static double Ounce2Pound(double A)
		{
			return(A*0.0625);
		}
		
		public static double Pound2Gram(double A)
		{
			return(A*453.59237);
		}
		
		public static double Pound2Kg(double A)
		{
			return(A*0.45359237);
		}
		
		public static double Pound2Tonne(double A)
		{
			return(A*0.00045359237);
		}
		
		public static double Pound2Ounce(double A)
		{
			return(A*16);
		}
		
		#endregion
		
		#region Speed Unit
		
		public static double ms2kph(double A)
		{
			return(A*3.6);
		}
		
		public static double ms2mph(double A)
		{
			return(A*2.236936292054402);
		}
		
		public static double kph2ms(double A)
		{
			return(A*0.2777777777777778);
		}
		
		public static double kph2mph(double A)
		{
			return(A*0.621371192237334);
		}
		
		public static double mph2ms(double A)
		{
			return(A*0.44704);
		}
		
		public static double mph2kph(double A)
		{
			return(A*1.609344);
		}
		
		#endregion
		
		#region Energy unit
		
		public static double Joule2kJ(double A)
		{
			return(A*0.001);
		}
		
		public static double Joule2Cal(double A)
		{
			return(A*0.2388458966274959);
		}
		
		public static double Joule2KCal(double A)
		{
			return(A*0.0002388458966274959);
		}
		
		public static double Kj2Joule(double A)
		{
			return(A*1000);
		}
		
		public static double Kj2Cal(double A)
		{
			return(A*238.8458966274959);
		}
		
		public static double Kj2KCal(double A)
		{
			return(A*0.2388458966274959);
		}
		
		public static double Cal2Joule(double A)
		{
			return(A*4.1868);
		}
		
		public static double Cal2kJ(double A)
		{
			return(A*0.0041868);
		}
		
		public static double Cal2kCal(double A)
		{
			return(A*0.001);
		}
		
		public static double KCal2Joule(double A)
		{
			return(A*4186.8);
		}
		
		public static double KCal2kJ(double A)
		{
			return(A*4.1868);
		}
		
		public static double KCal2Cal(double A)
		{
			return(A*1000);
		}
		
		#endregion
		
		#endregion
		
		#endregion
	}
	
	#endregion
	
	#region Virtual channel computation classes
	
	/// <summary>
	/// Virtual channel variable element structure
	/// </summary>
	public class CS_VC_Variable
	{
		#region Public members
		
		/// <summary>
		/// Name of the variable element
		/// </summary>
		public string Name;
		
		/// <summary>
		///  Index of the variable element in the element table
		/// </summary>
		public ushort Index;
			
		/// <summary>
		/// Value of the variable element
		/// </summary>
		public double Value;
		
		#endregion
		
		public CS_VC_Variable()
		{
			Name = "";
			Index = 0;
			Value = 1;
		}
	}
	
	#endregion
	
	#region Virtual channel configuration classes
	
	/// <summary>
	/// CANStream virtual channel class
	/// </summary>
	public class CS_VirtualChannel
	{
		#region Public members
		
		/// <summary>
		/// Virtual channel name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Virtual channel description comment
		/// </summary>
		public string Comment;
		
		/// <summary>
		/// Virtual channel unit
		/// </summary>
		public string Unit;
		
		/// <summary>
		/// Virtual channel decimal rounding
		/// </summary>
		public int Decimals;
		
		/// <summary>
		/// Virtual channel computation enabled flag
		/// </summary>
		public bool Enabled;
		
		/// <summary>
		/// Virtual channel default value for CAN Tx
		/// </summary>
		public double DefaultValue;
		
		/// <summary>
		/// Virtual channel equation
		/// </summary>
		public string Expression;
		
		/// <summary>
		/// Parent library reference of the channel
		/// </summary>
		public CS_VirtualChannelsLibrary ParentLibrary;
		
		
		/// <summary>
		/// Flag indicating whether the expression is interpretable and if the channel is ready to be computed
		/// </summary>
		public bool ComputationReady;
		
		/// <summary>
		/// Virtual channel computed value
		/// </summary>
		public double Value;
		
		/// <summary>
		/// Flag indicating that channel value calculation ended to an error (division by 0 or whatever else)
		/// </summary>
		public bool InError;
		
		/// <summary>
		/// Reason of computation error message
		/// </summary>
		public string ErrorMsg;
		
		/// <summary>
		/// Flag indicating that channel got dependent channel
		/// </summary>
		public bool HasDependent;
		
		/// <summary>
		/// Flag indicating whether the channel value has changed
		/// </summary>
		public bool bNewValue;
		
		/// <summary>
		/// Flag to force channel computation even if its variables values did not change since last computation
		/// </summary>
		public bool bForceComputation;

        /// <summary>
        /// Flag to force next channel computation even if its variables values did not change since last computation
        /// </summary>
        /// <remarks>
        /// The flag is self reseted after channel computation
        /// </remarks>
        public bool bForceNextComputation;
		
		/// <summary>
		/// Flag indicating whether the channel value has been computed
		/// </summary>
		public bool bComputed;
		
		#endregion
		
		#region Private members
		
		private ExpressionContext FleeExprContext;
		private IGenericExpression<double> Flee_Expression;
		private string[] VarNameList;
		private ushort[] VarIndexList;
		
		#endregion
		
		public CS_VirtualChannel()
		{
			//Members init
			Name = "";
			Comment = "";
			Unit = "";
			Decimals = 0;
			Expression = "";
			Enabled = true;
			DefaultValue = 0;
			ParentLibrary = null;
			
			FleeExprContext = null;
			Flee_Expression = null;
			VarNameList = null;
			VarIndexList = null;
			
			ComputationReady = false;
			Value = 0;
			InError =  false;
			HasDependent = false;
			bNewValue = false;
			bForceComputation = false;
            bForceNextComputation = false;
		}
		
		#region Public methods
		
		/// <summary>
		/// Interprete channel expression to perform the channel value calculation
		/// </summary>
		public void InterpreteExpression()
		{
			bool bError = false;
			ComputationReady = false; //Computation flag reset
			
			List<string> TmpVarName = new List<string>();
			List<ushort> TmpVarIndex = new List<ushort>();
			
			FleeExprContext = new ExpressionContext();
			
			//Static class import
			FleeExprContext.Imports.AddType(typeof(Math));
			FleeExprContext.Imports.AddType(typeof(CS_BuiltIn_Func));
			
			while (!(ComputationReady | bError))
			{
				try
				{
					Flee_Expression = FleeExprContext.CompileGeneric<double>(Expression);
					ComputationReady = true;
				}
				catch (ExpressionCompileException FleeExcep)
				{
					if (FleeExcep.Reason.Equals(CompileExceptionReason.UndefinedName))
					{
						string UndefName = GetMissingElementName(FleeExcep.Message);
						
						CS_VC_Variable sVar = ParentLibrary.CollectionParent.GetVariableElement(UndefName);
						
						if (sVar == null) //Variable doesn't exist yet in the variable table of the libraries collection
						{
							ParentLibrary.CollectionParent.SetVariableElement(UndefName,1); //Create the new variable
							sVar = ParentLibrary.CollectionParent.GetVariableElement(UndefName); //Retrieve the variable newly created
						}
						
						FleeExprContext.Variables.Add(sVar.Name,sVar.Value); //Add the variable reference to the Flee expression context
						TmpVarName.Add(sVar.Name);
						TmpVarIndex.Add(sVar.Index);
					}
					else
					{
						bError = true;
						ErrorMsg = FleeExcep.Message;
					}
				}
			}
			
			if (ComputationReady)
			{
				VarNameList = TmpVarName.ToArray();
				VarIndexList = TmpVarIndex.ToArray();
				//VariableList = TmpVarList.ToArray();
			}
		}
		
		/// <summary>
		/// Calcualte the value of the channel
		/// </summary>
		public void ComputeChannelValue()
		{				
			try
			{
				bComputed = false;

                if (UpDateFleeContextVariable() | bForceComputation | bForceNextComputation)
				{
                    Value = Math.Round(Flee_Expression.Evaluate(), Decimals);
					InError = false;
					bNewValue=true;
					bComputed = true;
                    bForceNextComputation = false;
				}
			}
			catch (ExpressionCompileException FleeExcep)
			{
				InError = true;
				bNewValue=true;
                bForceNextComputation = false;
				ErrorMsg = FleeExcep.Message;
			}
		}
		
		/// <summary>
		/// Return a flag indicating whether the channel is using the variable name given as argument 
		/// </summary>
		/// <param name="Name">Name of the variable to search</param>
		/// <returns>True: Channel is using the variable / False: Channel is not using the variable</returns>
		public bool IsDependantOfChannel(string Name)
		{
			foreach (string ChanVar in VarNameList)
			{
				if (ChanVar.Equals(Name))
				{
					return(true);
				}
			}
			
			return(false);
		}
		
		#endregion
		
		#region Private methods
		
		private string GetMissingElementName(string ExceptionMessage)
		{
			//IdentifierElement: Could not find a field/property/variable with the name 'toto'
			
			if (!(ExceptionMessage == null))
			{
				int i = ExceptionMessage.IndexOf("'",0);
				int j = ExceptionMessage.IndexOf("'",i+1);
				
				if (!(i == -1 | j == -1))
				{
					return(ExceptionMessage.Substring(i+1,j-i-1));
				}
			}
			
			return(null);
		}
		
		private bool UpDateFleeContextVariable()
		{
			bool bNewValueToProcess = false;
			
			foreach (ushort VarIndex in VarIndexList)
			{
				CS_VC_Variable oVar = ParentLibrary.CollectionParent.GetVariableAtIndex(VarIndex);
				
				object CurrentValue = 0;
				if (FleeExprContext.Variables.TryGetValue(oVar.Name,ref CurrentValue))
				{
					if (!(Convert.ToDouble(CurrentValue).Equals(oVar.Value)))
					{
						FleeExprContext.Variables.TrySetValue(oVar.Name,(object)oVar.Value);
						bNewValueToProcess = true;
					}
				}
			}
			
			return(bNewValueToProcess);
		}
		
		#endregion
	}
	
	/// <summary>
	/// CANStream virtual channel library class
	/// </summary>
	public class CS_VirtualChannelsLibrary
	{
		#region Public members
		
		/// <summary>
		/// Virtual channel library name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Library description comment
		/// </summary>
		public string Comment;
		
		/// <summary>
		/// Library read only flag
		/// </summary>
		public bool ReadOnly;

        /// <summary>
        /// Library computation enabled flag
        /// </summary>
        public bool Enabled;

        /// <summary>
        /// Virtual channels collection of the library
        /// </summary>
        public List<CS_VirtualChannel> Channels;
		
		/// <summary>
		/// Flag indicating whether the library has been modified since it has been loaded into the virtual channel editor
		/// </summary>
		public bool bModified;
		
		/// <summary>
		/// File path of the library
		/// </summary>
		public string FilePath;
		
		/// <summary>
		/// Libraries collection parent of the library
		/// </summary>
		public CS_VCLibrariesCollection CollectionParent;
		
		#endregion
		
		#region Private members
		
		#endregion
		
		public CS_VirtualChannelsLibrary()
		{
			//Members init
			Name = "";
			Comment = "";
			ReadOnly =  false;
            Enabled = true;
			Channels = new List<CS_VirtualChannel>();
			
			FilePath = "";
		}
		
		#region Public methods
		
		#region Library items management
			
		/// <summary>
		/// Library file writing function
		/// </summary>
		/// <param name="LibPath">Library file path</param>
		public void WriteLibraryFile(string LibPath)
		{
			XmlDocument oXmlLib = new XmlDocument();
			
			XmlElement xLibrary = oXmlLib.CreateElement("CS_VirtualChannelsLibrary");
			oXmlLib.AppendChild(xLibrary);
			
			CreateLibraryXmlNode(oXmlLib);
			
			oXmlLib.Save(LibPath);
	
			FilePath = LibPath;
			bModified =  false;
		}
		
		/// <summary>
		/// Create the virtual channel library XML node
		/// </summary>
		/// <param name="oXmlLib">XmlDocument class reference creating the node</param>
		public void CreateLibraryXmlNode(XmlDocument oXmlLib)
		{
			XmlNode xLibrary = null;
			
			if (oXmlLib.FirstChild.Name.Equals("CS_VirtualChannelsLibrary")) //Making virtual channel library node for a virtual channel library file
			{
				xLibrary =  oXmlLib.FirstChild;
			}
			else //Making virtual channel library node for embeded library file
			{	
				/*
				 * If destination container of the node contains multiple instance of CS_VirtualChannelsLibrary node
				 * Loop until finding the empty one (latest created)
				*/
				
				xLibrary = oXmlLib.FirstChild.SelectSingleNode("CS_VirtualChannelsLibrary");
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

            XmlAttribute xAtrEnabled = oXmlLib.CreateAttribute("Enabled");
            xAtrEnabled.Value = Enabled.ToString();
            xLibrary.Attributes.Append(xAtrEnabled);

            XmlElement xLibComment = oXmlLib.CreateElement("LibraryComment");
			xLibComment.InnerText =  Comment;
			xLibrary.AppendChild(xLibComment);
			
			XmlElement xLibChannels =  oXmlLib.CreateElement("Channels");
			xLibrary.AppendChild(xLibChannels);
			
			foreach(CS_VirtualChannel oVChan in Channels)
			{
				XmlElement xVirtual = oXmlLib.CreateElement("Channel");
				xLibChannels.AppendChild(xVirtual);
				
				XmlAttribute xAtrChanName =  oXmlLib.CreateAttribute("Name");
				xAtrChanName.Value = oVChan.Name;
				xVirtual.Attributes.Append(xAtrChanName);
				
				XmlAttribute xAtrChanUnit = oXmlLib.CreateAttribute("Unit");
				xAtrChanUnit.Value = oVChan.Unit;
				xVirtual.Attributes.Append(xAtrChanUnit);
				
				XmlAttribute xAtrChanDec = oXmlLib.CreateAttribute("Decimal");
				xAtrChanDec.Value = oVChan.Decimals.ToString();
				xVirtual.Attributes.Append(xAtrChanDec);
				
				XmlAttribute xAtrChanEnabled = oXmlLib.CreateAttribute("Enabled");
				xAtrChanEnabled.Value = oVChan.Enabled.ToString();
				xVirtual.Attributes.Append(xAtrChanEnabled);
				
				XmlElement xChanComment =  oXmlLib.CreateElement("Comment");
				xChanComment.InnerText =  oVChan.Comment;
				xVirtual.AppendChild(xChanComment);
				
				XmlElement xChanValDef =  oXmlLib.CreateElement("TxDefaultValue");
				xChanValDef.InnerText =  oVChan.DefaultValue.ToString();
				xVirtual.AppendChild(xChanValDef);
				
				XmlElement xExpression =  oXmlLib.CreateElement("Expression");
				xExpression.InnerText = oVChan.Expression;
				xVirtual.AppendChild(xExpression);
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
		/// Read the virtual channel library object XML node
		/// </summary>
		/// <param name="xLibrary">XML Node to read</param>
		/// <returns>Read error flag: True = No Error / False = Error</returns>
		public bool ReadLibraryXmlNode(XmlNode xLibrary)
		{
			try
			{
				if (xLibrary.Name.Equals("CS_VirtualChannelsLibrary"))
				{
					Name = xLibrary.Attributes["Name"].Value;
					ReadOnly = Convert.ToBoolean(xLibrary.Attributes["ReadOnly"].Value);
                    Enabled = Convert.ToBoolean(xLibrary.Attributes["Enabled"].Value);

                    XmlNode xComment = xLibrary.SelectSingleNode("LibraryComment");
					if (!(xComment == null))
					{
						Comment = xComment.InnerText;
					}
					
					XmlNode xChannels = xLibrary.SelectSingleNode("Channels");
					if (!(xChannels == null))
					{
						Channels = new List<CS_VirtualChannel>();
						
						foreach (XmlNode xChannel in xChannels.ChildNodes)
						{
							CS_VirtualChannel oChannel = new CS_VirtualChannel();
							
							oChannel.Name =  xChannel.Attributes["Name"].Value;
							oChannel.Unit =  xChannel.Attributes["Unit"].Value;
							
							if (!(xChannel.Attributes.GetNamedItem("Enabled") == null))
							{
								bool bEnabled = false;
								if (Boolean.TryParse(xChannel.Attributes["Enabled"].Value, out bEnabled))
								{
									oChannel.Enabled = bEnabled;
								}
								else
								{
									oChannel.Enabled = true;
								}
							}
							else
							{
								oChannel.Enabled = true;
							}
							
							int dec = 0;
							if(int.TryParse(xChannel.Attributes["Decimal"].Value, out dec))
							{
								oChannel.Decimals =  dec;
							}
							
							XmlNode xChanComment =  xChannel.SelectSingleNode("Comment");
							if (!(xChanComment == null))
							{
								oChannel.Comment = xChanComment.InnerText;
							}
							
							XmlNode xChanValDef =  xChannel.SelectSingleNode("TxDefaultValue");
							if (!(xChanValDef == null))
							{
								double ValDef = 0;
								if (Double.TryParse(xChanValDef.InnerText,out ValDef))
								{
									oChannel.DefaultValue = ValDef;
								}
								else
								{
									oChannel.DefaultValue = 0;
								}
							}
							else
							{
								oChannel.DefaultValue = 0;
							}
							
							XmlNode xExpression =  xChannel.SelectSingleNode("Expression");
							if (!(xExpression == null))
							{
								oChannel.Expression = xExpression.InnerText;
							}
							else
							{
								return(false);
							}
							
							oChannel.ParentLibrary = this;
							Channels.Add(oChannel);
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
		/// Return the CS_VirtualChannel corresponding to the name given as argument
		/// </summary>
		/// <param name="Name">Name of virtual channel to return</param>
		/// <returns>Virtual channel, null if not found</returns>
		public CS_VirtualChannel GetVirtualChannel(string Name)
		{
			foreach (CS_VirtualChannel oVirtual in Channels)
			{
				if (oVirtual.Name.Equals(Name))
				{
					return(oVirtual);
				}
			}
			
			return(null);
		}
		
		/// <summary>
		/// Return a flag indicating whether the channel name given as argument exists in the library
		/// </summary>
		/// <param name="Name">Name of the channel</param>
		/// <returns>True: Channel exists / False: doesn't exist</returns>
		public bool ChannelExists(string Name)
		{
			foreach (CS_VirtualChannel oVirtual in Channels)
			{
				if (oVirtual.Name.Equals(Name))
				{
					return(true);
				}
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return the index of the channel into the library corresponding to the channel name given as argument
		/// </summary>
		/// <param name="Name">Name of the channel</param>
		/// <returns>Index of the channel in the library, -1 if not found</returns>
		public int GetChannelIndex(string Name)
		{
			for (int iChan=0; iChan<Channels.Count; iChan++)
			{
				if (Channels[iChan].Name.Equals(Name))
				{
					return(iChan);
				}
			}
			
			return(-1);
		}
		
		/// <summary>
		/// Clone the virtual channel given as argument
		/// </summary>
		/// <param name="OrigialChannel">Virtual channel to be cloned</param>
		/// <returns>Clone of the original channel</returns>
		public CS_VirtualChannel CloneVirtualChannel(CS_VirtualChannel OrigialChannel)
		{
			if (!(OrigialChannel == null))
			{
				CS_VirtualChannel oClone = new CS_VirtualChannel();
				
				oClone.Comment = OrigialChannel.Comment;
				oClone.Decimals = OrigialChannel.Decimals;
				oClone.Expression = OrigialChannel.Expression;
				oClone.Name = OrigialChannel.Name;
				oClone.Unit = OrigialChannel.Unit;
				
				return(oClone);
			}
			
			return(null);
		}
		
		#endregion
		
		#endregion
	}
	
	/// <summary>
	/// CANStream virtual channel library collection class
	/// </summary>
	public class CS_VCLibrariesCollection
	{
		#region Public members
		
		/// <summary>
		/// Collection of virtual channel libraries
		/// </summary>
		public List<CS_VirtualChannelsLibrary> Libraries;
		
		/// <summary>
		/// Flag indicating whether librairies computation has been initialized
		/// </summary>
		public bool bLibrariesInitialized;
		
		#endregion
		
		#region Private members
		
		/// <summary>
		/// Table of variable elements used by virtual channels
		/// This table is common for all libraries
		/// </summary>
		private CS_VC_Variable[] VC_Variables;
		
		/// <summary>
		/// Array of virtual channel to be computed sorted by priority
		/// </summary>
		private CS_VirtualChannel[] VC_ComputationList;
		
		#endregion
		
		public CS_VCLibrariesCollection()
		{
			Libraries = new List<CS_VirtualChannelsLibrary>();
			bLibrariesInitialized = false;
			VC_Variables = null;
			VC_ComputationList = null;
		}
		
		#region Public methods
		
		#region Collection items management
		
		/// <summary>
		/// Save the libraries collection in a XML file
		/// </summary>
		/// <param name="FilePath">Path of the file to create</param>
		public void SaveLibrariesList(string FilePath)
		{
			XmlDocument oXLibList =  new XmlDocument();
				
			XmlElement xList = oXLibList.CreateElement("LibrariesList");
			oXLibList.AppendChild(xList);
			
			foreach (CS_VirtualChannelsLibrary oLib in Libraries)
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
				if (xLibs.Name.Equals("LibrariesList"))
				{
					Libraries = new List<CS_VirtualChannelsLibrary>();
					
					foreach (XmlNode xLib in xLibs.ChildNodes)
					{
						if (File.Exists(xLib.InnerText))
						{
							CS_VirtualChannelsLibrary oLib = new CS_VirtualChannelsLibrary();
							
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
		/// Add a virtual channel library into the collection
		/// </summary>
		/// <param name="oLibrary">Virtual channel library to add</param>
		public void AddLibrary(CS_VirtualChannelsLibrary oLibrary)
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
			foreach (CS_VirtualChannelsLibrary oLib in Libraries)
			{
				if (oLib.Name.Equals(LibName))
				{
					return(true);
				}
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return the virtual channel library corresponding to the name given as argument
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <returns>Virtual channel library, null if not found</returns>
		public CS_VirtualChannelsLibrary GetLibrary(string LibName)
		{
			foreach (CS_VirtualChannelsLibrary oLib in Libraries)
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
		/// Return a flag indicating whether the channel name given exists in library name given
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <param name="ChannelName">Name of the channel to search</param>
		/// <returns>Exist flag: True = Exist / False = Doesn't exist</returns>
		public bool ChannelExistsInLibrary(string LibName, string ChannelName)
		{
			CS_VirtualChannelsLibrary oLib = GetLibrary(LibName);
			
			if (!(oLib == null))
			{
				return(oLib.ChannelExists(ChannelName));
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return the last value computed of the channel name given exists in library name given as arguments
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <param name="ChannelName">Name of the channel to search</param>
		/// <returns>Last channel computed value</returns>
		public double GetLastChannelValue(string LibName, string ChannelName)
		{
			CS_VirtualChannelsLibrary oLib = GetLibrary(LibName);
			
			if (!(oLib == null))
			{
				CS_VirtualChannel oChan = oLib.GetVirtualChannel(ChannelName);
				
				if (!(oChan == null))
				{
					if (!(oChan.InError))
					{
						return(oChan.Value);
					}
				}
			}
			
			return(0);
		}
		
		/// <summary>
		/// Return the last value computed for CAN Tx of the channel name given exists in library name given as arguments
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <param name="ChannelName">Name of the channel to search</param>
		/// <returns>Last value computed for CAN Tx</returns>
		/// <remarks>Return default channel value if channel is in error or not computed</remarks>
		public double GetLastCANTxChannelValue(string LibName, string ChannelName)
		{
			CS_VirtualChannelsLibrary oLib = GetLibrary(LibName);
			
			if (!(oLib == null))
			{
				CS_VirtualChannel oChan = oLib.GetVirtualChannel(ChannelName);
				
				if (!(oChan == null))
				{
					if (!(oChan.InError))
					{
						return(oChan.Value);
					}
					else
					{
						return(oChan.DefaultValue);
					}
				}
			}
			
			return(0);
		}
		
		/// <summary>
		/// Return the virtual channel instance correponding to the channel name given as argument of the library name given as argument
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <param name="ChannelName">Name of the channel to search</param>
		/// <returns>Virtual channel</returns>
		public CS_VirtualChannel GetVirtualChannel(string LibName, string ChannelName)
		{
			CS_VirtualChannelsLibrary oLib = GetLibrary(LibName);
			
			if (!(oLib == null))
			{
				return(oLib.GetVirtualChannel(ChannelName));
			}
			
			return(null);
		}
		
		/// <summary>
		/// Return the virtual channel expression correponding to the channel name given as argument of the library name given as argument
		/// </summary>
		/// <param name="LibName">Name of the library to search</param>
		/// <param name="ChannelName">Name of the channel to search</param>
		/// <returns>Virtual channel expression</returns>
		public string GetVirtualChannelExpression(string LibName, string ChannelName)
		{
			CS_VirtualChannel oChan = GetVirtualChannel(LibName, ChannelName);
			
			if (!(oChan== null))
			{
				return(oChan.Expression);
			}
			
			return("");
		}
		
		#endregion
		
		#region Virtual channels computation
		
		/// <summary>
		/// Initialize the computation of all virtual channels of the library
		/// </summary>
		public void InitLibrariesComputation()
		{
			//1st pass: Compile all channels of all libraries
			foreach (CS_VirtualChannelsLibrary oLib in Libraries)
			{
                if (oLib.Enabled)
                {
                    foreach (CS_VirtualChannel oChan in oLib.Channels)
                    {
                        if (oChan.Enabled)
                        {
                            oChan.InterpreteExpression(); //Virtual channel expression compilation
                        }
                    }
                }
			}
			
			//2nd pass: Create the computation order list
			List<CS_VirtualChannel> TmpOrderList = new List<CS_VirtualChannel>();
			List<string> TmpOrderListName = new List<string>();
			
			foreach (CS_VirtualChannelsLibrary oLib in Libraries)
			{
				foreach (CS_VirtualChannel oChan in oLib.Channels)
				{
					if (oChan.ComputationReady)
					{
						//Search the index of first channel depending of the current channel 
						int iDependentFirstIndex = GetDependentFirstIndex(TmpOrderListName,GetDependentList(oChan));
						
						if (iDependentFirstIndex == -1) //Dependent channels have not been added to the computation list yet
						{
							//Channel added at the bottom of the list
							TmpOrderList.Add(oChan);
							TmpOrderListName.Add(oChan.Name);
						}
						else //One or more dependent channels are in the computation list already
						{
							//Channel inserted before its first dependant
							TmpOrderList.Insert(iDependentFirstIndex, oChan);
							TmpOrderListName.Insert(iDependentFirstIndex, oChan.Name);
						}
					}
				}
			}
			
			//Final computation creation
			VC_ComputationList = TmpOrderList.ToArray();
			
			bLibrariesInitialized = true;
			TmpOrderList = null;
			TmpOrderListName = null;
			
		}
		
		/// <summary>
		/// Launch the calculation of all virtual channels of all libraries
		/// </summary>
		public void ComputeLibraries()
		{
			if (VC_ComputationList.Length > 0)
			{
				foreach (CS_VirtualChannel oChan in VC_ComputationList)
				{
					oChan.ComputeChannelValue();
					
					if ((!oChan.InError) && oChan.bComputed && oChan.HasDependent)
					{
						UpDateVariableElement(oChan.Name,oChan.Value);
					}
				}
			}
		}
		
		#endregion
		
		#region Variable element table management
		
		/// <summary>
		/// Return the variable element instance corresponding to the name given as argument
		/// </summary>
		/// <param name="Name">Name of the variable element to be retrieved</param>
		/// <returns>Variable element, null if not found</returns>
		public CS_VC_Variable GetVariableElement(string Name)
		{
			if (!(Name == null | VC_Variables == null))
			{
				foreach (CS_VC_Variable oVar in VC_Variables)
				{
					if (oVar.Name.Equals(Name))
					{
						return(oVar);
					}
				}
			}
			
			return(null);
		}
		
		/// <summary>
		/// Set the value of the variable element corresponding to the name given as argument
		/// If the variable element doesn't exist it will be created
		/// </summary>
		/// <param name="Name">Name of the variable element to set</param>
		/// <param name="Value">New value of the variable element to set</param>
		public void SetVariableElement(string Name, double Value)
		{
			if (!(Name == null))
			{
				if (!(VC_Variables == null))
				{
					foreach (CS_VC_Variable oVar in VC_Variables)
					{
						if (oVar.Name.Equals(Name))
						{
							oVar.Value = Value;
							return;
						}
					}
				}
				
				//Variable not found, create a new variable
				AddVariableValue(Name,Value);
			}
		}
		
		/// <summary>
		/// Update the value of the variable element corresponding to the name given as argument
		/// </summary>
		/// <param name="Name">Name of the variable element to update</param>
		/// <param name="value">New value of the variable element</param>
		public void UpDateVariableElement(string Name,double value)
		{
			if (!(VC_Variables == null))
			{
				foreach (CS_VC_Variable oVar in VC_Variables)
				{
					if (oVar.Name.Equals(Name))
					{
						oVar.Value = value;
						return;
					}
				}
			}
		}
		
		/// <summary>
		/// Return the variable element count
		/// </summary>
		/// <returns>Variable element count</returns>
		public int GetVariableElementCount()
		{
			if (!(VC_Variables == null))
			{
				return(VC_Variables.Length);
			}
			
			return(0);
		}
		
		/// <summary>
		///Return the variable element of the index given as argument
		/// </summary>
		/// <param name="Index">Index of the variable element to return</param>
		/// <returns>Variable element, null if index doesn't exist</returns>
		public CS_VC_Variable GetVariableAtIndex(int Index)
		{
			if (!(Index < 0 | Index >= VC_Variables.Length))
			{
				return(VC_Variables[Index]);
			}
			
			return(null);
		}
				
		#endregion
		
		#endregion
		
		#region Private methods
		
		#region Virtual channels computation
		
		private int GetDependentFirstIndex(List<string> ComputeList, string[] DependentList)
		{
			int iFirstDep = -1;
			
			foreach(string Dep in DependentList)
			{
				int iDep = ComputeList.IndexOf(Dep);
				
				if (!(iDep == -1)) //Dependent has been found
				{
					if (iFirstDep == -1) //First dependent
					{
						iFirstDep = iDep;
					}
					else //Other dependent found already
					{
						if(iDep < iFirstDep)
						{
							iFirstDep = iDep;
						}
					}
				}
			}
			
			return(iFirstDep);
		}
		
		private string[] GetDependentList(CS_VirtualChannel RefChannel)
		{
			List<string> DepList = new List<string>();
			
			foreach(CS_VirtualChannelsLibrary oLib in Libraries)
			{
				foreach(CS_VirtualChannel oChan in oLib.Channels)
				{
					if (oChan.ComputationReady)
					{
						if (oChan.IsDependantOfChannel(RefChannel.Name))
						{
							DepList.Add(oChan.Name);
							RefChannel.HasDependent = true;
						}
					}
				}
			}
			
			return(DepList.ToArray());
		}
		
		#endregion
		
		#region Variable element table management
		
		private void AddVariableValue(string Name, double Value)
		{				
			//Create a new variable structure
			if (!(Name == null))
			{
				CS_VC_Variable strNewVar = new CS_VC_Variable();
				
				strNewVar.Name = Name;
				strNewVar.Value = Value;
				
				//Update the variable table
				if (VC_Variables == null) //Variable table doesn't contain element yet
				{
					VC_Variables = new CS_VC_Variable[1];
					VC_Variables[0] = strNewVar;
					VC_Variables[0].Index = 0;
				}
				else //Variable table already contain elements
				{
					List<CS_VC_Variable> TmpTable = new List<CS_VC_Variable>();
					
					for (int i=0; i<VC_Variables.Length; i++)
					{
						TmpTable.Add(VC_Variables[i]);
					}
					
					TmpTable.Add(strNewVar);
					TmpTable[TmpTable.Count-1].Index = (ushort)(TmpTable.Count-1);
					
					VC_Variables = TmpTable.ToArray();
				}
			}
		}
		
		#endregion
		
		#endregion
	}
	
	#endregion
}
