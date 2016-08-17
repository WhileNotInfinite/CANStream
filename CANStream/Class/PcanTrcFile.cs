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
	public class TraceRecord
	{
		#region Public members
		
		/// <summary>
		/// Record index in the trace
		/// </summary>
		public long RecordIndex;
		
		/// <summary>
		/// Record time offset since the trace start time (in ms)
		/// </summary>
		public double TimeOffset;
		
		/// <summary>
		/// Record message type (Rx/Tx)
		/// </summary>
		public CanMsgRxTx MessageType; //Rx or Tx
		
		/// <summary>
		/// Record message identifier (hex)
		/// </summary>
		public string MessageIdentifier;
		
		/// <summary>
		/// Record message data length (2,4 or 8 bytes)
		/// </summary>
		public int MessageLength;
		
		/// <summary>
		/// Record message data bytes
		/// </summary>
		public byte[] MessageData;
		
		#endregion
		
		public TraceRecord()
		{
		}
		
		#region Public methodes
		
		/// <summary>
		/// Returns all bytes of the record data in a single value in binary format
		/// </summary>
		/// <returns>binary of record data</returns>
		public string GetRecordBinaryData()
		{
			string BinValue="";
			
			for(int iByte=0;iByte<MessageData.Length;iByte++)
			{
				string ByteBinValue=NumberBaseConverter.Dec2Bin(MessageData[iByte]);
				
				while(ByteBinValue.Length<8)
				{
					ByteBinValue="0"+ByteBinValue;
				}
				
				BinValue=BinValue+ByteBinValue;
			}
			
			return(BinValue);
		}
		
		#endregion
	}
	
	public class PcanTrcFileInfo
	{
		#region Public members
		
		public FileInfo TrcFileInfo;
		public CS_RecordEvent TrcFileEvent;
		public CS_RecordSession TrcFileSession;
        public CANMessagesConfiguration TrcCanConfig;

		#endregion
		
		public PcanTrcFileInfo()
		{
			TrcFileInfo = null;
			TrcFileEvent = null;
			TrcFileSession = null;
            TrcCanConfig = null;
        }
	}
	
	/// <summary>
	/// PCAN Trace record *.trc file class
	/// </summary>
	public class PcanTrcFile
	{
		#region Public members
		
		/// <summary>
		/// Flag indicating if the PCAN Trace file (*.trc) has been sucessfully loaded
		/// </summary>
		public bool bTrcLoaded;
		
		/// <summary>
		/// Path of the PCan trace file (*.trc)
		/// </summary>
		public string BaseTrcFilePath;
		
		/// <summary>
		/// Version of PCAN Trace file (1.1)
		/// </summary>
		public string FileVersion;
		
		/// <summary>
		/// Absolute trace start time in double format
		/// Resolution of 1ms since 30th December 1899
		/// </summary>
		public double AbsDblStartTime; //41472.5916203704: 41472 number of days since 30th December 1899 / 0.5916203704 of 24 hours since 00h00
		
		/// <summary>
		/// Absolute trace start time in DateTime format
		/// </summary>
		public DateTime AbsDTStartTime;
		
		/// <summary>
		/// System date at the start of trace
		/// </summary>
		public DateTime StartTime;
		
		/// <summary>
		/// PCAN channel used to make the trace
		/// </summary>
		public string PCAN_Channel;
		
		/// <summary>
		/// List of data in raw format
		/// </summary>		
		public List<TraceRecord> Records;

        #endregion

        /// <summary>
        /// Default constructor, only create the PcanTrcFile instance
        /// </summary>
        public PcanTrcFile()
        {
            bTrcLoaded = false;
            AbsDTStartTime = new DateTime();
            StartTime = new DateTime();
            Records = new List<TraceRecord>();
        }
        
        /// <summary>
        /// Constructor 2, create the PcanTrcFile instance and read the file at the path given as argument
        /// </summary>
        /// <param name="TrcFilePath">Path of PcanTrcFile to read</param>
        public PcanTrcFile(string TrcFilePath)
		{
			bTrcLoaded=false;
			AbsDTStartTime=new DateTime();
			StartTime=new DateTime();
			Records=new List<TraceRecord>();
			
			if(!(TrcFilePath.Equals("")))
			{
				bTrcLoaded=ReadTrcFile(TrcFilePath);
				
				if(!bTrcLoaded)
				{
					Records=new List<TraceRecord>();
				}
			}
		}
		
		#region Public methodes
		
		/// <summary>
		/// Trace file (*.trc) reading function
		/// </summary>
		/// <param name="FilePath">Trace file path </param>
		/// <returns>File reading result (True: No error /False: Error)</returns>
		public bool ReadTrcFile(string FilePath)
		{
			return(ReadTrcFile(FilePath,false));
		}
		
		/// <summary>
		/// Trace file (*.trc) reading function
		/// </summary>
		/// <param name="FilePath">Trace file path</param>
		/// <param name="HeaderOnly">Header only reading option</param>
		/// <returns>File reading result (True: No error /False: Error)</returns>
		public bool ReadTrcFile(string FilePath,bool HeaderOnly)
		{
			bool Ret=true;
			
			BaseTrcFilePath=FilePath;
			
			StreamReader SR=new StreamReader(FilePath);
			
			try
			{
				while(!(SR.EndOfStream))
				{
					string Line=SR.ReadLine();
					
					if(Line.StartsWith(";")) //Header
					{
						if(Line.Contains("$FILEVERSION"))
						{
							int i=Line.IndexOf("=")+1;
							FileVersion=Line.Substring(i,Line.Length-i);
						}
						
						if(Line.Contains("$STARTTIME"))
						{
							int i=Line.IndexOf("=")+1;
							string StrStartTime=Line.Substring(i,Line.Length-i);
							double DblStartTime=0;
							
							if(Double.TryParse(StrStartTime,out DblStartTime))
							{
								AbsDblStartTime=DblStartTime;
								DblStartTime=(double)((int)DblStartTime);
								DateTime Dec30th1899=new DateTime(1899,12,30);
								AbsDTStartTime=Dec30th1899.AddDays(DblStartTime);
								AbsDTStartTime=AbsDTStartTime.AddMilliseconds((AbsDblStartTime-DblStartTime)*86400000); //86400000 millisecond in 1 day
							}
						}
						
						if(Line.Contains("Start time:"))
						{
							int i=Line.IndexOf(":")+2;
							string StrStartTime=Line.Substring(i,Line.Length-i);
							
							string[] SplitedStartTime=StrStartTime.Split(Char.Parse(" "));
							string[] SplitedDate=SplitedStartTime[0].Split(Char.Parse("/"));
							string[] SplitedTime=SplitedStartTime[1].Split(Char.Parse(":"));
							string[] SplitedSecond=SplitedTime[2].Split(Char.Parse("."));
							
							StartTime=StartTime.AddYears(int.Parse(SplitedDate[2])-1);
							StartTime=StartTime.AddMonths(int.Parse(SplitedDate[1])-1);
							StartTime=StartTime.AddDays(Double.Parse(SplitedDate[0])-1);
							StartTime=StartTime.AddHours(Double.Parse(SplitedTime[0]));
							StartTime=StartTime.AddMinutes(Double.Parse(SplitedTime[1]));
							StartTime=StartTime.AddSeconds(Double.Parse(SplitedSecond[0]));
							StartTime=StartTime.AddMilliseconds(Double.Parse(SplitedSecond[1]));	
						}
						
						if(Line.Contains("PCAN-Channel:"))
						{
							int i=Line.IndexOf(":")+2;
							PCAN_Channel=Line.Substring(i,Line.Length-i);
						}
					}
					else //Data
					{
						if(HeaderOnly)
						{
							break; //Loop exit if header reading only option is set
						}
						
						TraceRecord oRecord=new TraceRecord();
						
						string[] StrRecord=Line.Split(Char.Parse(" "));
						
						//Remove empty cells
						{
							//Count empty cells
							int EmptyCnt=0;
							for(int i=0;i<StrRecord.Length;i++)
							{
								if(StrRecord[i].Equals(""))
								{
									EmptyCnt++;
								}
							}
							
							//Create a new temporary array sized to the non empty cells count
							string[] TmpArray=new string[StrRecord.Length-EmptyCnt];
							
							//Fill the temporary array
							int j=0;
							for(int i=0;i<StrRecord.Length;i++)
							{
								if(!(StrRecord[i].Equals("")))
								{
									TmpArray[j]=StrRecord[i];
									j++;
								}
							}
							
							//Update the final array
							StrRecord=TmpArray;
							TmpArray=null;
						}
						
						oRecord.RecordIndex=long.Parse(StrRecord[0].Substring(0,StrRecord[0].Length-1));
						oRecord.TimeOffset=double.Parse(StrRecord[1]);
												
						CanMsgRxTx Test;
						if(Enum.TryParse(StrRecord[2],out Test))
						{
							oRecord.MessageType=Test;
							
							oRecord.MessageIdentifier=StrRecord[3];
							
							//Remove not necessary 0 at the begining of identifier
							if(oRecord.MessageIdentifier.StartsWith("0"))
							{
								while(oRecord.MessageIdentifier.StartsWith("0"))
								{
									oRecord.MessageIdentifier=oRecord.MessageIdentifier.Substring(1,oRecord.MessageIdentifier.Length-1);
								}
							}
							
							oRecord.MessageLength=int.Parse(StrRecord[4]);
							
							oRecord.MessageData=new byte[oRecord.MessageLength];
							
							for(int i=0;i<oRecord.MessageLength;i++)
							{
								oRecord.MessageData[i]=(byte)(NumberBaseConverter.Hex2Dec(StrRecord[i+5]));
							}
							
							Records.Add(oRecord);
						}
					}
				}
			}
			catch
			{
				Ret=false;
			}
			
			SR.Close();
			SR=null;
			
			return(Ret);
		}
		
		#endregion
	}
}
