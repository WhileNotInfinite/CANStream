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

using NumberBaseConversion;

namespace CANStream
{
	#region DBC Enums
	
	/// <summary>
	/// DBC Comment object (node, signal) enum
	/// </summary>
	public enum DBCCommentObject
	{
		Unknown = 0,
		NodeComment = 1,
		SignalComment = 2,
	}
	
	/// <summary>
	/// DBC Signal endianess enum 
	/// </summary>
	public enum DBCEndianess
	{
		Unknown=0,
		MSBFirst=1,
		LSBFirst=2,
	}
	
	#endregion
	
	/// <summary>
	/// DBC Comment class 
	/// </summary>
	public class DBCComment
	{
		#region public members
		
		/// <summary>
		/// Object of the comment (node, signal)
		/// </summary>
		public DBCCommentObject Object;
		
		/// <summary>
		/// Node identifier of the comment
		/// </summary>
		public int NodeIdentifier;
		
		/// <summary>
		/// Signal name of the comment
		/// </summary>
		public string SignalName;
		
		/// <summary>
		/// Comment text
		/// </summary>
		public string Comment;
		
		#endregion
		
		public DBCComment()
		{
			Object= DBCCommentObject.Unknown;
			NodeIdentifier=-1;
			SignalName="";
			Comment="";
		}
	}
	
	/// <summary>
	/// DBC single bit value definition class
	/// </summary>
	public class DBCValue
	{
		#region public members
		
		/// <summary>
		/// Value of the bit descripted
		/// </summary>
		public long BitValue;
		
		/// <summary>
		/// Text description of the bit
		/// </summary>
		public string BitDescription;
		
		#endregion
		
		public DBCValue()
		{
			BitValue=-1;
			BitDescription="";
		}
	}
	
	/// <summary>
	/// DBC Signal bit map class
	/// </summary>
	public class DBCSignalBitMap
	{
		#region public members
		
		/// <summary>
		/// Node identifier of signal bit map
		/// </summary>
		public int NodeIdentifier;
		
		/// <summary>
		/// Signal name of the bit map
		/// </summary>
		public string SignalName;
		
		/// <summary>
		/// Bit map values
		/// </summary>
		public List<DBCValue> BitValues;
		
		#endregion
		
		public DBCSignalBitMap()
		{
			NodeIdentifier=-1;
			SignalName="";
			BitValues=new List<DBCValue>();
		}
	}
	
	/// <summary>
	/// DBC Signal multiplexer class
	/// </summary>
	public class DBCMultiplexer
	{
		#region Public members
		
		/// <summary>
		/// Flag indicating whether the DBC signal is used to multiplex other signal of the node
		/// </summary>
		public bool IsMultiplexerSignal;
		
		/// <summary>
		/// Name of the signal multiplexing the signal
		/// </summary>
		public string MultiplexerSignal;
		
		/// <summary>
		/// Multiplexer value of the signal
		/// </summary>
		public int MultiplexerValue;
		
		#endregion
		
		public DBCMultiplexer()
		{
			IsMultiplexerSignal=false;
			MultiplexerSignal="";
			MultiplexerValue=-1;
		}
	}
	
	/// <summary>
	/// DBC CAN Signal class
	/// </summary>
	public class DBCSignal
	{
		#region public members
		
		/// <summary>
		/// CAN signal name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// CAN MUX signal properties
		/// </summary>
		public DBCMultiplexer Multiplexer;
		
		/// <summary>
		/// CAN signal start bit
		/// </summary>
		public int StartBit;
		
		/// <summary>
		/// CAN signal bit length
		/// </summary>
		public int Length;
		
		/// <summary>
		/// CAN signal endianess (MSB/LSB first)
		/// </summary>
		public DBCEndianess Endianess;
		
		/// <summary>
		/// CAN signal signedness (true = signed / false = unsigned)
		/// </summary>
		public bool Signed;
		
		/// <summary>
		/// CAN signal linearization gain
		/// </summary>
		public double Gain;
		
		/// <summary>
		/// CAN signal linearization offset
		/// </summary>
		public double Zero;
		
		/// <summary>
		/// CAN signal minimal engineering value
		/// </summary>
		public double LimitMin;
		
		/// <summary>
		/// CAN signal maximal engineering value
		/// </summary>
		public double LimitMax;
		
		/// <summary>
		/// CAN signal engineering unit
		/// </summary>
		public string Unit;
		
		/// <summary>
		/// CAN signal bit map definition
		/// </summary>
		public DBCSignalBitMap BitMap;
		
		/// <summary>
		/// CAN signal comment
		/// </summary>
		public List<DBCComment> Comments;
		
		/// <summary>
		/// CAN signal destination
		/// </summary>
		public string Destination;
		
		#endregion
		
		public DBCSignal()
		{
			Name="";
			Multiplexer=null;
			StartBit=-1;
			Length=-1;
			Endianess= DBCEndianess.Unknown;
			Signed = false;
			Gain=1;
			Zero=0;
			LimitMin=0;
			LimitMax=0;
			Unit="";
			Destination="";
			BitMap=null;
			Comments=new List<DBCComment>();	
		}
		
		#region Public methodes
		
		/// <summary>
		/// Return the signal comments list in a single string
		/// </summary>
		/// <returns>Signal comments</returns>
		public string GetSignalComments()
		{
			string sComment="";
			
			if(Comments.Count>0)
			{
				for(int i=0;i<Comments.Count;i++)
				{
					sComment=sComment+Comments[i].Comment;
					
					if(!(i==Comments.Count-1))
					{
						sComment=sComment+" ";
					}
				}
				
				return(sComment);
			}
			
			return("");
		}
		
		#endregion
	}
	
	/// <summary>
	/// DBC CAN Frame class
	/// </summary>
	public class DBCFrame
	{
		#region public members
		
		/// <summary>
		/// CAN node identifier
		/// </summary>
		public int Identifier;
		
		/// <summary>
		/// CAN node name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// CAN node length in Byte
		/// </summary>
		public int ByteLength;
		
		/// <summary>
		/// CAN node transmitter (source)
		/// </summary>
		public string Transmitter;
		
		/// <summary>
		/// CAN signal of the node
		/// </summary>
		public List<DBCSignal> Signals;
		
		/// <summary>
		/// Node comments
		/// </summary>
		public List<DBCComment> Comments;
		
		#endregion
		
		public DBCFrame()
		{
			Identifier=-1;
			Name="";
			ByteLength=-1;
			Transmitter="";
			Signals=new List<DBCSignal>();
			Comments=new List<DBCComment>();
		}
		
		#region public methodes
		
		/// <summary>
		/// Return the name of the signal multiplexing the other signal of the node
		/// </summary>
		/// <returns>Name of the signal multiplexing the other signal of the node</returns>
		public string GetMultiplexerSignalName()
		{
			foreach(DBCSignal oSig in Signals)
			{
				if(!(oSig.Multiplexer==null))
				{
					if(oSig.Multiplexer.IsMultiplexerSignal)
					{
						return(oSig.Name);
					}
				}
			}
			
			return("");
		}
		
		/// <summary>
		/// Return the signal comments list in a single string
		/// </summary>
		/// <returns>Signal comments</returns>
		public string GetNodeComments()
		{
			string sComment="";
			
			for(int i=0;i<Comments.Count;i++)
			{
				sComment=sComment+Comments[i].Comment;
				
				if(!(i==Comments.Count-1))
				{
					sComment=sComment+" ";
				}
			}
			
			return(sComment);
		}
		
		#endregion
	}
	
	/// <summary>
	/// Vector CAN DBC file class
	/// </summary>
	public class CanDBCFile
	{
		#region public members
		
		/// <summary>
		/// DBC version
		/// </summary>
		public string Version;
		
		/// <summary>
		/// CAN bus components list
		/// </summary>
		public string[] BusComponents;
		
		/// <summary>
		/// CAN bus nodes
		/// </summary>
		public List<DBCFrame> Frames;
		
		#endregion
		
		public CanDBCFile()
		{
			Version="";
			BusComponents=null;
			Frames=new List<DBCFrame>();
		}
		
		#region Public methods
		
		/// <summary>
		/// DBC file reading function
		/// </summary>
		/// <param name="FilePath">File path of the DBC</param>
		/// <returns>Reading result (True: OK; False: Error)</returns>
		public bool ReadDBC(string FilePath)
		{
			if(!(FilePath.Equals("")))
			{
				StreamReader SR=new StreamReader(FilePath);
				
				while(!SR.EndOfStream)
				{
					string line=SR.ReadLine();
					
					if(line.Length>4 & !(line.StartsWith("\t")))
					{
						line=line.TrimStart(Char.Parse(" "));
						
						int iEntrySep=line.IndexOf(" ");
						string EntryId=line.Substring(0,iEntrySep);
						
						string EntryData=line.Substring(iEntrySep+1,line.Length-(iEntrySep+1));
						
						if(EntryId.Equals("VERSION")) //DBC Version
						{
							Version=EntryData.Substring(1,EntryData.Length-2); //Suppression of "
						}
						else if(EntryId.Equals("BU_:")) //Bus components
						{
							BusComponents=EntryData.Split(Char.Parse(" "));
						}
						else if (EntryId.Equals("BO_")) //Node
						{
							DBCFrame oNode=new DBCFrame();
							
							string[] NodeData=EntryData.Split(Char.Parse(" "));
							
							//oNode.Identifier=Int16.Parse(NodeData[0]);
							if (int.TryParse(NodeData[0], out oNode.Identifier))
							{
								oNode.Name=NodeData[1].Substring(0,NodeData[1].Length-1); //Suppression of :
								oNode.ByteLength=Int16.Parse(NodeData[2]);
								oNode.Transmitter=NodeData[3];
								
								Frames.Add(oNode);
							}
							
						}
						else if (EntryId.Equals("SG_")) //Signal
						{
							DBCSignal oSignal=new DBCSignal();
							
							EntryData=FilterDoubleSpace(EntryData);
							string[] SignalData=EntryData.Split(Char.Parse(" "));
							
							int PtOffset=0;
							
							string strTmp;
							string[] strArray;
							int i;
							
							//Name
							oSignal.Name=SignalData[0];
							
							//Multiplexer
							if (SignalData.Length>7)
							{
								PtOffset=1;
								
								oSignal.Multiplexer=new DBCMultiplexer();
								
								if(SignalData[1].Equals("M"))
								{
									oSignal.Multiplexer.IsMultiplexerSignal=true;
								}
								else
								{
									oSignal.Multiplexer.MultiplexerSignal=GetMultiplexerSignalInLastNode();
									oSignal.Multiplexer.MultiplexerValue=Int16.Parse(SignalData[1].Substring(1,SignalData[1].Length-1));
								}
							}
							
							//Start bit, length, endianess, signedness
							i=SignalData[2+PtOffset].IndexOf("@");
							strTmp=SignalData[2+PtOffset].Substring(0,i);
							strArray=strTmp.Split(Char.Parse("|"));
							
							oSignal.StartBit=Int16.Parse(strArray[0]);
							oSignal.Length=Int16.Parse(strArray[1]);
							
							strTmp=SignalData[2+PtOffset].Substring(i+1,2);
							
							if (strTmp.Substring(0,1).Equals("0")) //Big Endian (MSB)
							{
								oSignal.Endianess = DBCEndianess.MSBFirst;
							}
							else //Little endian (LSB)
							{
								oSignal.Endianess = DBCEndianess.LSBFirst;
							}
							
							
							if (strTmp.Substring(1,1).Equals("-"))
							{
								oSignal.Signed = true;
							}
							else
							{
								oSignal.Signed = false;
							}
							
							//Linearization gain and offset
							strTmp=SignalData[3+PtOffset].Substring(1,SignalData[3+PtOffset].Length-2);
							strArray=strTmp.Split(Char.Parse(","));
							
							oSignal.Gain=Double.Parse(strArray[0]);
							oSignal.Zero=Double.Parse(strArray[1]);
							
							//Limit values
							strTmp=SignalData[4+PtOffset].Substring(1,SignalData[4+PtOffset].Length-2);
							strArray=strTmp.Split(Char.Parse("|"));
							
							oSignal.LimitMin=Double.Parse(strArray[0]);
							oSignal.LimitMax=Double.Parse(strArray[1]);
							
							//Unit
							strTmp=SignalData[5+PtOffset].Substring(1,SignalData[5+PtOffset].Length-2);
							
							oSignal.Unit=strTmp;
							
							//Transmitter
							oSignal.Destination=SignalData[6+PtOffset];
							
							AddSignalToLastNode(oSignal);
						}
						else if (EntryId.Equals("CM_")) //Comment
						{
							DBCComment oComment=new DBCComment();
							
							int i=EntryData.IndexOf("\"",0);
							oComment.Comment=EntryData.Substring(i+1,EntryData.Length-(i+3));
							
							string sTmp=EntryData.Substring(0,i);
							string[] CommentData=sTmp.Split(Char.Parse(" "));
							
							if (int.TryParse(CommentData[1], out oComment.NodeIdentifier))
							{
								if(CommentData[0].Equals("BO_"))
								{
									oComment.Object= DBCCommentObject.NodeComment;
									//oComment.NodeIdentifier=Int16.Parse(CommentData[1]);
									oComment.SignalName="";
								}
								else if(CommentData[0].Equals("SG_"))
								{
									oComment.Object= DBCCommentObject.SignalComment;
									//oComment.NodeIdentifier=Int16.Parse(CommentData[1]);
									oComment.SignalName=CommentData[2];
								}
								else
								{
									oComment.Object= DBCCommentObject.Unknown;
								}
							}
							else
							{
								oComment = null;
							}
							
							if (!(oComment == null)) SetCommentToObject(oComment);
						}
						else if (EntryId.Equals("VAL_")) //Bit map values
						{
							DBCSignalBitMap oBitMap=new DBCSignalBitMap();
							
							int j=0;
							int i=EntryData.IndexOf(" ");
							oBitMap.NodeIdentifier=Int16.Parse(EntryData.Substring(0,i));
							
							j=EntryData.IndexOf(" ",i+1);
							oBitMap.SignalName=EntryData.Substring(i+1,j-i);
							
							while (j<EntryData.Length-2)
							{
								DBCValue oBit=new DBCValue();
								
								i=EntryData.IndexOf("\"",j);
								string sTmp1=EntryData.Substring(j+1,i-j-1).Trim();
								
								oBit.BitValue=Int64.Parse(sTmp1);
								
								j=i+1;
								
								i=EntryData.IndexOf("\"",j);
								string sTmp2=EntryData.Substring(j,i-j);
								oBit.BitDescription=sTmp2;
								
								j=i+1;
							}
							
							SetBitMapToSignal(oBitMap);
						}
					}
				}
				
				SR.Close();
				SR=null;
				return(true);
			}
			
			return(false);
		}
		
		/// <summary>
		/// Convert the DBC object into a CANStream CAN configuration object
		/// </summary>
		/// <param name="Rate">CAN bus Baud rate</param>
		/// <param name="CanNodeName">CAN device name</param>
		/// <returns>CANStream CAN configuration object of the DBC</returns>
		public CANMessagesConfiguration Convert_DBC_to_XCC(int Rate, string CanNodeName)
		{
			CANMessagesConfiguration oXCC =new CANMessagesConfiguration();
			
			//Bus Baud rate
			oXCC.CanRate=Rate;
			
			//Config name
			oXCC.Name="DBC:";
			if (!(BusComponents == null))
			{
				for(int i =0;i<BusComponents.Length;i++)
				{
					oXCC.Name=oXCC.Name + " " + BusComponents[i];
				}
			}
			
			foreach(DBCFrame oFrame in Frames)
			{
				CANMessage oCSMsg=new CANMessage();
				
				oCSMsg.Identifier=NumberBaseConverter.Dec2Hex(oFrame.Identifier);
                oCSMsg.DLC = oFrame.ByteLength;
                oCSMsg.Name=oFrame.Name;
				oCSMsg.Comment=oFrame.GetNodeComments();
				oCSMsg.Period=1000; //Default value
				
				//oCSMsg.RxTx=CanMsgRxTx.Tx; //Default value
				if (oFrame.Transmitter.Equals(CanNodeName))
				{
					oCSMsg.RxTx = CanMsgRxTx.Tx;
				}
				else
				{
					oCSMsg.RxTx = CanMsgRxTx.Rx;
				}
				
				oCSMsg.MultiplexerName=oFrame.GetMultiplexerSignalName();
				
				foreach(DBCSignal oSignal in oFrame.Signals)
				{
					if ((oCSMsg.RxTx.Equals(CanMsgRxTx.Tx)) || (oCSMsg.RxTx.Equals(CanMsgRxTx.Rx) && oSignal.Destination.Equals(CanNodeName)))
					{
						CANParameter oCSParam=new CANParameter();
						
						oCSParam.Name=oSignal.Name;
						oCSParam.Comment=oSignal.GetSignalComments();
						oCSParam.Unit=oSignal.Unit;
						
						oCSParam.StartBit=oSignal.StartBit;
						oCSParam.Length=oSignal.Length;
						oCSParam.Endianess=(CanParameterEndianess)Enum.Parse(typeof(CanParameterEndianess),oSignal.Endianess.ToString());
						oCSParam.Signed = oSignal.Signed;
						
						oCSParam.Gain=oSignal.Gain;
						oCSParam.Zero=oSignal.Zero;
						
						if(!(oSignal.Multiplexer==null))
						{
							if(!(oSignal.Multiplexer.IsMultiplexerSignal))
							{
								oCSParam.IsMultiplexed = true;
								oCSParam.MultiplexerValue = oSignal.Multiplexer.MultiplexerValue;
							}
						}
						
						oCSMsg.Parameters.Add(oCSParam);
					}
				}
				
				if(oCSMsg.Parameters.Count > 0)
				{
					oXCC.Messages.Add(oCSMsg);
				}
			}
			
			return(oXCC);
		}
		
		#endregion
		
		#region Private methods
		
		/// <summary>
		/// Add a new signal to the last node of the DBC node collection
		/// </summary>
		/// <param name="NewSignal">DBC signal to be added</param>
		private void AddSignalToLastNode(DBCSignal NewSignal)
		{
			if(Frames.Count>0)
			{
				Frames[Frames.Count-1].Signals.Add(NewSignal);
			}
		}
		
		/// <summary>
		/// Get the name of signal multiplexing the last node of DBC
		/// </summary>
		/// <returns>Name of signal multiplexing the last node</returns>
		private string GetMultiplexerSignalInLastNode()
		{
			if(Frames.Count>0)
			{
				foreach(DBCSignal oSignal in Frames[Frames.Count-1].Signals)
				{
					if(!(oSignal.Multiplexer==null))
					{
						if(oSignal.Multiplexer.IsMultiplexerSignal)
						{
							return(oSignal.Name);
						}
					}
				}
				
				return("");
			}
			
			return("");
		}
		
		/// <summary>
		/// Set the DBC comment given as argument to the appropriate object (node or signal)
		/// </summary>
		/// <param name="NewComment">Comment to be set</param>
		private void SetCommentToObject(DBCComment NewComment)
		{
			switch(NewComment.Object)
			{
				case DBCCommentObject.NodeComment:
					
					foreach(DBCFrame oNode in Frames)
					{
						if(oNode.Identifier.Equals(NewComment.NodeIdentifier))
						{
							oNode.Comments.Add(NewComment);
							return;
						}
					}
					
					break;
					
				case DBCCommentObject.SignalComment:
					
					foreach(DBCFrame oNode in Frames)
					{
						if(oNode.Identifier.Equals(NewComment.NodeIdentifier))
						{
							foreach(DBCSignal oSignal in oNode.Signals)
							{
								if(oSignal.Name.Equals(NewComment.SignalName))
								{
									oSignal.Comments.Add(NewComment);
									return;
								}
							}
						}
					}
					
					break;
					
				case DBCCommentObject.Unknown:
					
					return;
			}
		}
		
		/// <summary>
		/// Set the bit value definitions given as argument to the appropriate signal
		/// </summary>
		/// <param name="NewBitMap">Bit value definitions to be set</param>
		private void SetBitMapToSignal(DBCSignalBitMap NewBitMap)
		{
			foreach(DBCFrame oNode in Frames)
			{
				if(oNode.Identifier.Equals(NewBitMap.NodeIdentifier))
				{
					foreach(DBCSignal oSignal in oNode.Signals)
					{
						if(oSignal.Name.Equals(NewBitMap.SignalName))
						{
							oSignal.BitMap=NewBitMap;
							return;
						}
					}
				}
			}
		}
		
		/// <summary>
		/// Remove the double space from a DBC line
		/// </summary>
		/// <param name="TxtIn">DBC line to process</param>
		/// <returns>DBC line processed</returns>
		private string FilterDoubleSpace(string TxtIn)
		{
			string TxtOut="";
			char[] InCharArray=TxtIn.ToCharArray();
			
			for(int i=0;i<InCharArray.Length;i++)
			{
				if(!(i==0))
				{
					if(!(InCharArray[i].Equals(char.Parse(" "))) 
					   |(InCharArray[i].Equals(char.Parse(" ")) & !(InCharArray[i-1].Equals(char.Parse(" ")))))
					{
						TxtOut=TxtOut + InCharArray[i].ToString();
					}
				}
				else
				{
					TxtOut=TxtOut + InCharArray[i].ToString();
				}
			}
			
			return(TxtOut);
		}
		
		#endregion
	}
}
