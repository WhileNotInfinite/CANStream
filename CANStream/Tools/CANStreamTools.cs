/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 6/26/2013
 * Time: 11:14 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Drawing;

using ChartDirector;
using NumberBaseConversion;

namespace CANStream
{
	/// <summary>
	/// CANStream project common functions
	/// </summary>
	public static class CANStreamTools
	{
		#region Public members
		
		public static string MyDocumentPath; //MyDocuement folder path
		public static string CsDataPath; //Users\xxx\AppData\Local
		
		public static RecordConversionOption TraceConversionOptions;
		
		#endregion
		
		#region Private members
		
		private static int CurrentColorId;
		
		private static CS_RecordEvent oEventCurrent = null;
		private static CS_RecordSession oSessionCurrent = null;
		
		#endregion
		
		#region Public methods
		
		public static string[] GetBinaryRowData(int ParamLength, long lRowValue)
        {
            string sBinValue = NumberBaseConverter.Dec2Bin(lRowValue);

            while (sBinValue.Length < ParamLength)
            {
                sBinValue = "0" + sBinValue;
            }

            string[] BinRowValue = new string[ParamLength];

            int i = ParamLength - 1;
            while (i >= 0)
            {
                BinRowValue[i] = sBinValue.Substring(i, 1);
                i--;
            }

            return (BinRowValue);
        }
		
		public static bool CreateFolderIfItDoesNotExist(string FolderPath)
		{
			if(!(Directory.Exists(FolderPath)))
			{
				string[] PathDetails=FolderPath.Split(char.Parse("\\"));
				string PathTmp=PathDetails[0];
				
				for(int i=0;i<PathDetails.Length;i++)
				{
					if(i==0) //First, check if the drive is ready... if not, we're fucked !
					{
						DriveInfo Drv=new DriveInfo(PathTmp);
						if(!(Drv.IsReady))
						{
							return(false);
						}
					}
					else
					{
						PathTmp=PathTmp+"\\"+PathDetails[i];
						
						if(!(Directory.Exists(PathTmp)))
						{
							Directory.CreateDirectory(PathTmp);
						}
					}
				}
			}
			
			return(true);
		}
		
		public static void ResetTrcFileInfoEventSession()
		{
			oEventCurrent = null;
			oSessionCurrent = null;
		}
		
		public static PcanTrcFileInfo[] GetTrcFileInfoList(string FolderPath)
		{
			List<PcanTrcFileInfo> FolderTrcFilesInfo = new List<PcanTrcFileInfo>();
			
			DirectoryInfo FolderInfo = new DirectoryInfo(FolderPath);
			DirectoryInfo[] SubDirsInfo = FolderInfo.GetDirectories();
			FileInfo[] TrcFiles = FolderInfo.GetFiles("*.trc");
			
			//Update event
			if (File.Exists(FolderPath + "\\EventDetails.xml"))
			{
				oEventCurrent = new CS_RecordEvent();
				
				if (!(oEventCurrent.Load_RecordEventInformationFile(FolderPath + "\\EventDetails.xml")))
				{
					oEventCurrent = null;
				}
			}
			
			//Update session
			if (File.Exists(FolderPath + "\\SessionDetails.xml"))
			{
				oSessionCurrent = new CS_RecordSession();
				
				if (!(oSessionCurrent.Load_RecordSessionInformationFile(FolderPath + "\\SessionDetails.xml")))
				{
					oSessionCurrent = null;
				}
			}
			
			//Look for trc files
			if (TrcFiles.Length > 0)
			{
				foreach (FileInfo oTrc in TrcFiles)
				{
					PcanTrcFileInfo oTrcInfo = new PcanTrcFileInfo();
					
					oTrcInfo.TrcFileInfo = oTrc;
					
					if (!(oEventCurrent == null || oSessionCurrent == null))
					{
						oTrcInfo.TrcFileEvent = oEventCurrent;
						oTrcInfo.TrcFileSession = oSessionCurrent;
					}
					
					FolderTrcFilesInfo.Add(oTrcInfo);
				}
			}
			
			//Look in sub-directories
			if (SubDirsInfo.Length > 0)
			{
				foreach (DirectoryInfo oSubDir in SubDirsInfo)
				{
					FolderTrcFilesInfo.AddRange(GetTrcFileInfoList(oSubDir.FullName));
				}
			}
			
            if (FolderTrcFilesInfo.Count > 0)
            {
                return (FolderTrcFilesInfo.ToArray());
            }

            return (null);
		}
		
		public static int GetParamByteLength(int ParamLength)
		{
			double dLen=ParamLength/8;
			int iLen=(int) dLen;
			
			if(!(dLen==iLen))
			{
				iLen++;
			}
				
			return(iLen);
		}
		
		public static int GetRGBColor(Color ColorSelected)
        {
            string R = NumberBaseConverter.Dec2Hex(Convert.ToInt32(ColorSelected.R));
            string G = NumberBaseConverter.Dec2Hex(Convert.ToInt32(ColorSelected.G));
            string B = NumberBaseConverter.Dec2Hex(Convert.ToInt32(ColorSelected.B));

            if (R.Length < 2)
            {
                R = "0" + R;
            }

            if (G.Length < 2)
            {
                G = "0" + G;
            }

            if (B.Length < 2)
            {
                B = "0" + B;
            }

            string RGB = R + G + B;
            return (Convert.ToInt32(NumberBaseConverter.Hex2Dec(RGB)));
            
        }

        public static int GetRandomColor()
        {
            CurrentColorId++;
			
            if(CurrentColorId == 16)
            {
            	CurrentColorId=0;
            }
            
            switch (CurrentColorId)
            {
                case 0:
                    return (GetRGBColor(Color.Red));
                case 1:
                    return (GetRGBColor(Color.Cyan));
                case 2:
                    return (GetRGBColor(Color.LightGreen));
                case 3:
                    return (GetRGBColor(Color.Yellow));
                case 4:
                    return (GetRGBColor(Color.Pink));
                case 5:
                    return (GetRGBColor(Color.Blue));
                case 6:
                    return (GetRGBColor(Color.Green));
                case 7:
                    return (GetRGBColor(Color.Orange));
                case 8:
                    return (GetRGBColor(Color.Purple));
                case 9:
                    return (GetRGBColor(Color.LightBlue));
                case 10:
                    return (GetRGBColor(Color.GreenYellow));
                case 11:
                    return (GetRGBColor(Color.OrangeRed));
                case 12:
                    return (GetRGBColor(Color.Salmon));
                case 13:
                    return (GetRGBColor(Color.SteelBlue));
                case 14:
                    return (GetRGBColor(Color.DarkGreen));
                case 15:
                    CurrentColorId = -1;
                    return (GetRGBColor(Color.Olive));
                default:
                    CurrentColorId = -1;
                    return (GetRGBColor(Color.Magenta));
            }
        }
		
        public static void ResetRandomColor()
        {
        	CurrentColorId=-1;
        }
        
        public static void Draw_CycleGraph(CANStreamCycle oCycle, WinChartViewer oChart)
        {
        	Draw_CycleGraph(oCycle, oChart, -1, -1, -1);
        }
        
        public static void Draw_CycleGraph(CANStreamCycle oCycle, WinChartViewer oChart, double TimeCursorVal, double xStartPos, double xEndPos)
        {
    		CANStreamTools.ResetRandomColor();
    		
    		//Create graphic
    		XYChart Graph=new XYChart(oChart.Width,
    		                          	oChart.Height,
    		                         	CANStreamTools.GetRGBColor(Color.White),
    		                         	CANStreamTools.GetRGBColor(Color.Black),
    		                         	0);
    		
    		//Create plotting area
    		Graph.setPlotArea(CANStreamConstants.CycleGraphPlotAreaLeft,
    		                  CANStreamConstants.CycleGraphPlotAreaTop,
    		                  oChart.Width - CANStreamConstants.CycleGraphPlotAreaWidthOffset,
    		                  oChart.Height-CANStreamConstants.CycleGraphPlotAreaHeightOffset,
    		                  CANStreamTools.GetRGBColor(Color.White),-1,
    		                  CANStreamTools.GetRGBColor(Color.LightGray),
    		                  CANStreamTools.GetRGBColor(Color.LightGray),
    		                  CANStreamTools.GetRGBColor(Color.LightGray));
    		
    		//Create legend
    		Graph.addLegend(oChart.Width-185,20,true,"Arial",10).setBackground(Chart.Transparent);
    		
    		//Create X axis
    		Axis AxeX=Graph.xAxis();
    		AxeX.setLinearScale(oCycle.GraphSeries.AxisProperties.AxisX.MinValue,
    		                    oCycle.GraphSeries.AxisProperties.AxisX.MaxValue,
    		                    oCycle.GraphSeries.AxisProperties.AxisX.StepValue);
    		
    		AxeX.setRounding(true,true);
    		AxeX.setTitle("Time [sec]");
    		
    		//Add data to the graphic
    		foreach(FormatedGraphSerie oSerie in oCycle.GraphSeries.FormatedSeries)
    		{
    			if(oSerie.Visible)
    			{
        			LineLayer Layer = Graph.addLineLayer();
        		
        			Layer.addDataSet(oSerie.YValues,CANStreamTools.GetRandomColor(),oSerie.Name);
        			Layer.setXData(oSerie.XValues);
        			Layer.setLineWidth(2);
    			}
    		}
    		
    		//Current position in cycle cursor
    		if (TimeCursorVal > 0)
    		{
    			Mark oTimeCursor = AxeX.addMark(TimeCursorVal, GetRGBColor(Color.Black), "");
    			oTimeCursor.setLineWidth(2);
    		}
    		
    		//Cycle start position cursor
    		if ((xStartPos > 0) && (xStartPos > oCycle.GraphSeries.AxisProperties.AxisX.MinValue))
			{
				AxeX.addMark(xStartPos, GetRGBColor(Color.Blue), "Start");
			}
    		
    		//Cycle end position cursor
    		if ((xEndPos > 0) && (xEndPos < oCycle.GraphSeries.AxisProperties.AxisX.MaxValue))
			{
				AxeX.addMark(xEndPos, GetRGBColor(Color.Red), "End");
			}
    		
    		//Graphic display
    		oChart.Image=Graph.makeImage();
        }
        
        public static void Init_RecordConversionOption(string BasePath)
        {
        	TraceConversionOptions = new RecordConversionOption();
			TraceConversionOptions.SourceFileFolder = BasePath + CANStreamConstants.StackDirectory;
			TraceConversionOptions.OutputFileFolder = BasePath + CANStreamConstants.DataDirectory;
			TraceConversionOptions.SourceFileBackUpFolder = BasePath + CANStreamConstants.RawDirectory;
			TraceConversionOptions.TrcFileList = null;
			TraceConversionOptions.OutputFileFormat = RecordConversionFormat.Text;
        }
        
        public static string GetScaledFileSize(long FileSize)
        {
        	double ScaledSize = FileSize;
        	int iScale = 0;
        	string sScale = "";
        	
        	while (ScaledSize > 1024)
        	{
        		ScaledSize /= 1024;
        		iScale++;
        	}
        	
        	switch (iScale)
        	{	
        		case 1: //Kilo Byte
        			
        			sScale = "KB";
        			break;
        			
        		case 2: //Mega Byte
        			
        			sScale = "MB";
        			break;
        			
        		case 3: //Giga Byte
        			
        			sScale = "GB";
        			break;
        			
        		case 4: //Tera Byte
        			
        			sScale = "TB";
        			break;
        			
        		default:
        			
        			sScale = "Bytes";
        			ScaledSize = FileSize;
        			break;
        	}
        	
        	return(Math.Round(ScaledSize, 3).ToString() + " " + sScale);
        }

        public static Type CS_GetType(string typeName)
        {
            var type = Type.GetType(typeName);
            if (type != null) return type;
            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = a.GetType(typeName);
                if (type != null)
                    return type;
            }
            return null;
        }

        #endregion

        #region Private methods
        #endregion
    }
}
