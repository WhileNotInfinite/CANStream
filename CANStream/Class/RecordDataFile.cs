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
	/// <summary>
	/// Enum of possible final file format
	/// </summary>
	public enum RecordConversionFormat
	{
		Text=0,
		Wintax=1,
	}
	
	/// <summary>
	/// PCAN Trace record conversion option structure
	/// </summary>
	public struct RecordConversionOption
	{
		#region Public members
		
		/// <summary>
		/// Path of folder containing the *.trc file to convert
		/// </summary>
		public string SourceFileFolder;
		
		/// <summary>
		/// List of *.trc files to convert
		/// </summary>
		/// <remarks>
		/// If null, all *.trc files of the source folder will be converted
		/// </remarks>
		//public string[] TrcFileList;
		public PcanTrcFileInfo[] TrcFileList;
		
		/// <summary>
		/// Conversion output format (ASCII or Wintax or ....)
		/// </summary>
		public RecordConversionFormat OutputFileFormat;
		
		/// <summary>
		/// Path of folder hosting files issued by conversion process
		/// </summary>
		public string OutputFileFolder;
		
		/// <summary>
		/// Path of folder used to backup source *.trc converted files
		/// </summary>
		public string SourceFileBackUpFolder;
		
		#endregion
	}
	
	/// <summary>
	/// Record data channel sample structure
	/// </summary>
	public struct RecordDataSample
	{
		#region Public members
		
		/// <summary>
		/// Time stamp of sample: Offset in ms from the absolute start time of TRC
		/// </summary>
		public double TimeStamp;
		
		/// <summary>
		/// Sample value
		/// </summary>
		public double SampleValue;
		
		#endregion
		/*
		public RecordDataSample()
		{
			TimeStamp=-1;
			SampleValue=0;
		}
		*/
	}
	
	/// <summary>
	/// Record data channel class
	/// </summary>
	public class RecordDataChannel
	{
		#region Public members
		
		/// <summary>
		/// Record data channel name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Minimum time between two channel samples
		/// </summary>
		public double MinSampleTime;
		
		/// <summary>
		/// Maximum time between two channel samples
		/// </summary>
		public double MaxSampleTime;
		
		/// <summary>
		/// Channel data samples
		/// </summary>
		public List<RecordDataSample> Samples;
		
		#endregion
		
		#region Private members
		
		private int LastAccessedSampleIndex;
		
		#endregion
		
		public RecordDataChannel()
		{
			Samples=new List<RecordDataSample>();
			LastAccessedSampleIndex = 0;
		}
		
		#region Public methodes
		
		/// <summary>
		/// Get the channel value at the time given as argument
		/// </summary>
		/// <param name="TimeValue">Value of time</param>
		/// <returns>Value of sample at this time</returns>
		public double GetValueAtTime(double TimeValue)
		{
			for(int iSample=0;iSample<Samples.Count;iSample++)
			{
				if(Samples[iSample].TimeStamp>=TimeValue)
				{
					if(Samples[iSample].TimeStamp==TimeValue | iSample==0)
					{
						return(Samples[iSample].SampleValue);
					}
					else
					{
						return(Samples[iSample-1].SampleValue);
					}
				}
			}
			
			return(Samples[Samples.Count - 1].SampleValue);
		}
		
		/// <summary>
		/// Get the channel value at the time given as argument
		/// </summary>
		/// <param name="TimeValue">Value of time</param>
		/// <returns>Value of sample at this time</returns>
		/// <remarks>Faster than 'GetValueAtTime' method </remarks>
		public double FastGetValueAtTime(double TimeValue)
		{
			double Value=0;
			
			if (Samples[LastAccessedSampleIndex].TimeStamp > TimeValue)
			{
				LastAccessedSampleIndex = 0;
			}
			
			for(int iSample=LastAccessedSampleIndex; iSample<Samples.Count; iSample++)
			{
				if(Samples[iSample].TimeStamp>=TimeValue)
				{
					if(Samples[iSample].TimeStamp==TimeValue | iSample==0)
					{
						Value = Samples[iSample].SampleValue;
					}
					else
					{
						Value = Samples[iSample-1].SampleValue;
					}
					
					if (!(iSample == 0))
					{
						LastAccessedSampleIndex = iSample - 1;
					}
					
					return(Value);
				}
			}
			
			return(Samples[Samples.Count - 1].SampleValue);
		}
		
		#endregion
	}
	
	/// <summary>
	/// Converted trace record file class
	/// </summary>
	/// <remarks>
	/// class derived from PcanTrcFile
	/// </remarks>
	public class RecordDataFile:PcanTrcFile
	{
		#region Public members
		
		/// <summary>
		/// List of record data channel
		/// </summary>
		public List<RecordDataChannel> Channels;
		
		/// <summary>
		/// Graphic series of the record
		/// </summary>
		public GraphicSeries GraphSeries;
		
		#endregion
		
		#region Private members
		
		private bool bTrcConverted;
		private CANMessagesConfiguration oCanConfig;
		private CS_VCLibrariesCollection VCLibraries;
		
		private CS_RecordEvent oRecordEvent;
		private CS_RecordSession oRecordSession;
		
		#endregion
		
        public RecordDataFile(PcanTrcFileInfo oTrcInfo, string VCLibCollectionPath) : base(oTrcInfo.TrcFileInfo.FullName)
        {
			bTrcConverted=false;
			Channels=new List<RecordDataChannel>();
			
			oRecordEvent = null;
			oRecordSession = null;
			
			if(bTrcLoaded)
			{
                if (!(oTrcInfo.TrcCanConfig == null))
                {
                    oCanConfig = oTrcInfo.TrcCanConfig;

                    VCLibraries = null;
                    if (!(VCLibCollectionPath.Equals("")))
                    {
                        VCLibraries = new CS_VCLibrariesCollection();
                        VCLibraries.LoadLibrariesList(VCLibCollectionPath);
                    }

                    bTrcConverted = DecodeTrcFile();

                    oRecordEvent = oTrcInfo.TrcFileEvent;
                    oRecordSession = oTrcInfo.TrcFileSession;
                }
			}
		}
		
		#region Public methods
		
		/// <summary>
		/// Converts the decoded PCAN trace file into a the specified format
		/// </summary>
		/// <param name="OutputFolder">Output file folder</param>
		/// <param name="OutputFormat">Output format</param>
		/// <returns>Converion result (True: OK / False: Error)</returns>
		public bool ConvertTrcFile(string OutputFolder,RecordConversionFormat OutputFormat)
		{
			switch(OutputFormat)
			{
				case RecordConversionFormat.Text:
					return(WriteTextRecordData(OutputFolder));
				case RecordConversionFormat.Wintax:
					return(WriteWintaxRecordData(OutputFolder));
				default:
					return(false);
			}
		}
		
		/// <summary>
		/// Read a Record data file in ascii format
		/// </summary>
		/// <param name="FilePath">Path of the record data file</param>
		/// <returns>return false if an error occurs</returns>
		public bool ReadRecordDataFile(string FilePath)
		{
			if(!(File.Exists(FilePath)))
			{
				return(false);
			}
			
			StreamReader SR=new StreamReader(FilePath);
			int iLine=0;
			
			Channels=new List<RecordDataChannel>();
			
			while(!(SR.EndOfStream))
			{
				string sLine=SR.ReadLine();
				string[] LineVal=sLine.Split(Char.Parse(";"));
				
				if(iLine==0)
				{
					for(int i=0;i<LineVal.Length;i++)
					{
						if(!(i==0)) //First column is time
						{
							RecordDataChannel oChan=new RecordDataChannel();
							oChan.Name=LineVal[i];
							Channels.Add(oChan);
						}
					}
				}
				else
				{
					double TimeStamp=0;
					
					for(int i=0;i<LineVal.Length;i++)
					{
						double Value=0;
						
						if(Double.TryParse(LineVal[i],out Value))
						{
							if(i==0) //Get timestamp value
							{
								TimeStamp=Value;
							}
							else //Get sample value
							{
								RecordDataSample oSample=new RecordDataSample();
								
								oSample.TimeStamp=TimeStamp;
								oSample.SampleValue=Value;
								
								Channels[i].Samples.Add(oSample);
							}
						}
						else
						{
							return(false);
						}
					}
				}
			}
			
			SR.Close();
			SR=null;
			
			return(true);
		}
		
		/// <summary>
		/// Create the graphic series of the record
		/// </summary>
		public void CreateRecordGrahphicSeries()
		{
			if(!(Channels==null))
			{
				GraphSeries=new GraphicSeries();
				
				foreach(RecordDataChannel oChan in Channels)
				{
					SingleGraphicSerie oSerie=new SingleGraphicSerie();
					
					oSerie.Name=oChan.Name;
					
					foreach(RecordDataSample oSample in oChan.Samples)
					{
						oSerie.Times.Add(oSample.TimeStamp);
						oSerie.Data.Add(oSample.SampleValue);
					}
					
					GraphSeries.Series.Add(oSerie);
				}
				
				GraphSeries.ProcessGraphicSeries();
			}
		}
		
		#endregion
		
		#region Private methods
		
		/// <summary>
		/// Decodes the PCAN trace file CAN messages in raw format into the engineering format according to the specified CAN Configuration
		/// </summary>
		/// <returns>Decoding result (True: OK / False: Error)</returns>
		private bool DecodeTrcFile()
		{
			bool bComputeVirtuals = false;
			long iRecord = 0;
				
			if (!(VCLibraries == null))
			{
				VCLibraries.InitLibrariesComputation();
				bComputeVirtuals = true;
			}
			
			foreach(TraceRecord Record in Records)
			{
				iRecord++;
				
				if(oCanConfig.IsUsedIdentifier(Record.MessageIdentifier))
				{
					CANMessage oMessage=oCanConfig.GetCANMessage(Record.MessageIdentifier, MessageResearchOption.Identifier);
					
					if(!(oMessage==null))
					{
						CANMessageDecoded oMsgDecoded = new CANMessageDecoded(oMessage,Record);
						
						if (oMsgDecoded.bMessageDecoded)
						{
							foreach(CANParameter oParam in oMsgDecoded.Parameters)
							{
								AddDataSample(oParam.Name,Record.TimeOffset,oParam.DecodedValue);
								
								if (bComputeVirtuals)
								{
									VCLibraries.UpDateVariableElement(oParam.Name,oParam.DecodedValue);
								}
							}
							
							if (bComputeVirtuals)
							{
								VCLibraries.ComputeLibraries();
								
								foreach(CS_VirtualChannelsLibrary oLib in VCLibraries.Libraries)
								{
									foreach(CS_VirtualChannel oVirtual in oLib.Channels)
									{
										if (oVirtual.bComputed && (oVirtual.bNewValue | iRecord == Records.Count)) //Virtual channel computation for the last record in order to have value until the end
										{
											oVirtual.bNewValue = false;
											
											if (!oVirtual.InError)
											{
												if(!Double.IsNaN(oVirtual.Value))
												{
													AddDataSample(oVirtual.Name, Record.TimeOffset, oVirtual.Value);
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			
			return(true);
		}
		
		/// <summary>
		/// Add a data sample to a specific channel.
		/// </summary>
		/// <remarks>
		/// If the channel given in argument doesn't exist, it will be created
		/// </remarks>
		/// <param name="ChannelName">Destination channel name of the sample</param>
		/// <param name="TimeStamp">Time stamp value of the sample</param>
		/// <param name="DataValue">Engineering value of the sample</param>
		private void AddDataSample(string ChannelName,double TimeStamp,double DataValue)
		{
			bool bNewChannel=false;
			RecordDataChannel oChannel=GetRecordDataChannel(ChannelName);
			
			if(oChannel==null) //The channel doesn't exist yet, we create it
			{
				bNewChannel=true;
				
				oChannel=new RecordDataChannel();
				oChannel.Name=ChannelName;
			}
			
			//Create the new sample
			RecordDataSample oSample=new RecordDataSample();
			oSample.TimeStamp=TimeStamp;
			oSample.SampleValue=DataValue;
			
			//Add the new sample to the sample collection of channel
			oChannel.Samples.Add(oSample);
			
			//Update the channel min & max sampletime
			if(oChannel.Samples.Count>1) //Need 2 samples at least, to compute sample time
			{
				int iSample=oChannel.Samples.Count-1;
				double SampleTime=oChannel.Samples[iSample].TimeStamp-oChannel.Samples[iSample-1].TimeStamp;
				
				if(oChannel.Samples.Count==2) //First sample time calculation
				{
					oChannel.MinSampleTime=SampleTime;
					oChannel.MaxSampleTime=SampleTime;
				}
				else
				{
					if(SampleTime<oChannel.MinSampleTime)
					{
						oChannel.MinSampleTime=SampleTime;
					}
					
					if(SampleTime>oChannel.MaxSampleTime)
					{
						oChannel.MaxSampleTime=SampleTime;
					}
				}
			}
			
			if(bNewChannel) //Add the channel to the collection if we just created it
			{
				Channels.Add(oChannel);
			}
		}
				
		/// <summary>
		/// Return the instance of RecordDataChannel of the channel name given as argument
		/// </summary>
		/// <param name="ChannelName">Name of the channel to get</param>
		/// <returns>Instance of RecordDataChannel</returns>
		private RecordDataChannel GetRecordDataChannel(string ChannelName)
		{
			foreach(RecordDataChannel oChan in Channels)
			{
				if(oChan.Name.Equals(ChannelName))
				{
					return(oChan);
				}
			}
			
			return(null);
		}
		
		/// <summary>
		/// Returns the minimal sample time of all channels
		/// </summary>
		/// <returns>Overall min sample time</returns>
		private double GetOverallMinSampleTime()
		{
			double MinSampleTime=-1;
			
			for(int i=0;i<Channels.Count;i++)
			{
				if(i==0)
				{
					MinSampleTime=Channels[i].MinSampleTime;
				}
				else
				{
					if(Channels[i].MinSampleTime<MinSampleTime)
					{
						MinSampleTime=Channels[i].MinSampleTime;
					}
				}
			}
			
			if(MinSampleTime < 1) //Sample time limit min 1ms
			{
				MinSampleTime = 1;
			}
			
			return(MinSampleTime);
		}
		
		/// <summary>
		/// Converts the decoded PCAN trace file into a text file
		/// </summary>
		/// <param name="OutputFolder">Output file folder</param>
		/// <returns>Converion result (True: OK / False: Error)</returns>
		private bool WriteTextRecordData(string OutputFolder)
		{
			if(Channels.Count==0)
			{
				return(false);
			}
			
			string OutFilePath=BuildOutputFilePtah(OutputFolder, RecordConversionFormat.Text);
			
			bool FileSplited = false;
			
			StreamWriter SW=new StreamWriter(OutFilePath);
			FileInfo OutFileInfo = new FileInfo(OutFilePath);
			
			string Line = "";
			
			//Channels name
			WriteTextRecordDataHeader(SW);
			
			//Data
			double SampleTime=GetOverallMinSampleTime();
			
			if(SampleTime<=0)
			{
				return(false);
			}
			
			double Time = Records[0].TimeOffset;
			
			while(Time<=Records[Records.Count-1].TimeOffset)
			{
				Line=((Time - Records[0].TimeOffset) / 1000).ToString();
				
				for(int iChan=0;iChan<Channels.Count;iChan++)
				{
					Line = Line + ";" + Channels[iChan].FastGetValueAtTime(Time).ToString();
				}
				
				SW.WriteLine(Line);
				
				OutFileInfo.Refresh();
				
				if (OutFileInfo.Length > CANStreamConstants.TextRecordDataFileSizeMax) //Out file larger than 50 MBytes => close the file, eventually rename it and create a new one.
				{
					FileSplited = true;
					
					SW.Close();
					SW.Dispose();
					SW = null;
					OutFileInfo = null;
					 
					RenameTextRecordDataFile(OutFilePath);
					
					SW = new StreamWriter(OutFilePath);
					OutFileInfo = new FileInfo(OutFilePath);
					
					WriteTextRecordDataHeader(SW);
				}
				
				Time=Time+SampleTime;
			}
			
			SW.Close();
			SW.Dispose();
			SW = null;
			OutFileInfo = null;
			
			if (FileSplited)
			{
				RenameTextRecordDataFile(OutFilePath);
			}
			
			return(true);
		}
		
		private void WriteTextRecordDataHeader(StreamWriter SW)
		{
			string Line = "";
			
			//Channels name
			Line = "Time";
			for(int iChan=0; iChan<Channels.Count; iChan++)
			{
				Line = Line + ";" + Channels[iChan].Name;
			}
			
			SW.WriteLine(Line);
		}
		
		private void RenameTextRecordDataFile(string FilePath)
		{
			string FolderPath = Path.GetDirectoryName(FilePath);
			string BaseName = Path.GetFileNameWithoutExtension(FilePath);
			string Extension = Path.GetExtension(FilePath);
			string FinalPath = FolderPath + "\\" + BaseName + Extension;
			
			int Indice = 0;
			
			while (File.Exists(FinalPath))
			{
				Indice++;
				FinalPath = FolderPath + "\\" + BaseName + "_" + Indice.ToString("D2") + Extension;
			}
			
			File.Copy(FilePath, FinalPath);
			File.Delete(FilePath);
			
		}
		
		/// <summary>
		/// Converts the decoded PCAN trace file into a Wintax data file
		/// </summary>
		/// <param name="OutputFolder">Output file folder</param>
		/// <returns>Converion result (True: OK / False: Error)</returns>
		private bool WriteWintaxRecordData(string OutputFolder)
		{
			return(false);
		}
		
		/// <summary>
		/// Build the final converted data file path
		/// </summary>
		/// <param name="OutputFolder">Output file folder</param>
		/// <param name="OutputFormat">Output format</param>
		/// <returns>Final converted data file path</returns>
		private string BuildOutputFilePtah(string OutputFolder,RecordConversionFormat OutputFormat)
		{
			string OutputFile=OutputFolder;
			
			if(!(OutputFolder.EndsWith("\\")))
			{
				OutputFile=OutputFile+"\\";
			}
			
			if (!(oRecordEvent == null || oRecordSession == null))
			{
				if (!(Directory.Exists(OutputFile + oRecordEvent.Name)))
				{
					Directory.CreateDirectory(OutputFile + oRecordEvent.Name);
					oRecordEvent.Write_RecordEventInformationFile(OutputFile + oRecordEvent.Name + "\\EventDetails.xml");
				}
				
				OutputFile += (oRecordEvent.Name + "\\");
				
				if (!(Directory.Exists(OutputFile + oRecordSession.Name)))
				{
					Directory.CreateDirectory(OutputFile + oRecordSession.Name);
					oRecordSession.Write_RecordSessionInformationFile(OutputFile + oRecordSession.Name + "\\SessionDetails.xml");
				}
				
				OutputFile += (oRecordSession.Name + "\\");
			}
			
			OutputFile=OutputFile+Path.GetFileNameWithoutExtension(BaseTrcFilePath);
			
			switch(OutputFormat)
			{
				case RecordConversionFormat.Text:
					OutputFile=OutputFile+".csv";
					break;
				case RecordConversionFormat.Wintax:
					OutputFile=OutputFile+".ztx";
					break;
				default:
					OutputFile=OutputFile+".csv";
					break;
			}
			
			return(OutputFile);
		}
		
		#endregion
	}
}
