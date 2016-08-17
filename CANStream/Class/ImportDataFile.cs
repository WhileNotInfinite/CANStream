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
using System.Linq;
using System.IO;
using System.Text;

using Microsoft.Office.Interop.Excel;

namespace CANStream
{
    public class ImportDataChannel
    {
        #region Public members

        public string ChannelName;
        public List<double> Samples;

        #endregion

        public ImportDataChannel()
        {
            ChannelName = "";
            Samples = new List<double>();
        }
    }
    
    public class ImportDataFile
    {
        #region Public members

        public string Path;
        public List<double> Time;
        public List<ImportDataChannel> Channels;
        public bool FileLoaded;

        #endregion

        public ImportDataFile()
        {
            Path = "";
            Time = new List<double>();
            Channels = new List<ImportDataChannel>();
            FileLoaded = false;
        }

        #region Public methodes
		
        public bool ReadDataFile(string FilePath)
        {
        	return(ReadDataFile(FilePath,false));
        }
        
        public bool ReadDataFile(string FilePath, bool HeaderOnly)
        {
            bool Ret = false;
            FileInfo oDataFileInfo = new FileInfo(FilePath);
            Path = FilePath;
            
            //Any text file extension
            if (oDataFileInfo.Extension.Equals(".csv")
                |oDataFileInfo.Extension.Equals(".prn")
                |oDataFileInfo.Extension.Equals(".txt"))
            {
            	try
            	{
            		Ret = ReadCSVFile(FilePath, HeaderOnly);
            	}
            	catch
            	{
            		return(false);
            	}
            }
			
            //Excel file
            if (oDataFileInfo.Extension.Equals(".xlsx")
                |oDataFileInfo.Extension.Equals(".xls"))
            {
            	try
            	{
            		Ret=ReadExcelFile(FilePath, HeaderOnly);
            	}
            	catch
            	{
            		return(false);
            	}
            }
            
            //if (oDataFileInfo.Extension.Equals("ztx"))
            //{
            //}

            return (Ret);
        }
		
        public bool GetValueAtTime(string ChannelName, long TimeValue,out double DataValue)
        {
            DataValue = -1;

            ImportDataChannel oChan = GetDataChannel(ChannelName);
            if (oChan == null)
            {
                return(false);
            }

            if (TimeValue > Time[Time.Count - 1] * 1000)
            {
                TimeValue = TimeValue - (TimeValue / ((long)(Time[Time.Count - 1] * 1000))) * ((long)(Time[Time.Count - 1] * 1000));
                //return (false);
            }

            //for (int i = 0; i < Time[Time.Count - 1] * 1000; i++)
            for (int i = 0; i < Time.Count; i++)
            {
                if (Time[i] * 1000 == TimeValue)
                {
                    DataValue = oChan.Samples[i];
                    return (true);
                }
                else if (Time[i] * 1000 > TimeValue)
                {
                    DataValue = oChan.Samples[i - 1];
                    return (true);
                }
            }

            return (false);
        }
        
        public bool ChannelExists(string ChannelName)
        {
        	foreach (ImportDataChannel oChan in Channels)
        	{
        		if (oChan.ChannelName.Equals(ChannelName))
        		{
        			return(true);
        		}
        	}
        	
        	return(false);
        }

        #endregion

        #region Private Methodes

        private bool ReadCSVFile(string FilePath, bool HeaderOnly)
        {
            string Seperator="";
        	
        	bool FirstLine = true;
            StreamReader SR = new StreamReader(FilePath);

            while (!(SR.EndOfStream))
            {
            	string Line = SR.ReadLine();

                //Separator detection
                if (FirstLine)
            	{
            		if(Line.Contains(",")) //Comma separator
            		{
            			Seperator=","; //TODO: Comma could be a decimal separator
            		}
            		else if(Line.Contains(";")) //Semi column separator
            		{
            			Seperator=";";
            		}
            		else if(Line.Contains(" ")) //space separator
            		{
            			Seperator=" ";
            		}
            		else if(Line.Contains(Char.ConvertFromUtf32(9))) //tab separator
            		{
            			Seperator="	";
            		}
            			
            	}
            	
            	if(Seperator.Equals(""))
            	{
            		return(false);
            	}
            	
                string[] Cells = Line.Split(char.Parse(Seperator));

                if (FirstLine)
                {
                    for (int i = 0; i < Cells.Length; i++)
                    {
                        if (!(i == 0)) //First column = Time
                        {
                        	if (!(Cells[i].Equals("")))
                        	{
                        		ImportDataChannel oChan = new ImportDataChannel();
                            	oChan.ChannelName = Cells[i];
                            	Channels.Add(oChan);
                        	}
                        }
                    }

                    FirstLine = false;
                    
                    if (HeaderOnly)
                    {
                    	SR.Close();
            			SR = null;
                    	return(true);
                    }
                }
                else
                {
                    for (int i = 0; i < Cells.Length; i++)
                    {
                    	if (!(Cells[i].Equals("")))
                    	{
	                    	double Value = 0;
	                        if (double.TryParse(Cells[i], out Value))
	                        {
	                            if (i == 0) //Time
	                            {
	                                Time.Add(Value);
	                            }
	                            else //Data
	                            {
	                                if (i <= Channels.Count)
	                                {
	                                    Channels[i - 1].Samples.Add(Value);
	                                }
	                            }
	                        }
	                        else
	                        {
	                            return (false);
	                        }
                    	}
                    }
                }
            }

            //Check whether all data channels have the same number of samples than the time
            foreach(ImportDataChannel oImportChan in Channels)
            {
                if (oImportChan.Samples.Count != Time.Count)
                {
                    return (false);
                }
            }

            SR.Close();
            SR = null;
            FileLoaded = true;
            return (true);
        }
        
        private bool ReadExcelFile(string FilePath, bool HeaderOnly)
        {
        	bool Ret=true;
        	string CellTxt = "";
        	
        	Microsoft.Office.Interop.Excel.Workbook oXlWrkBk=null;
        	Microsoft.Office.Interop.Excel.Worksheet oXlWrkSht=null;
        	Microsoft.Office.Interop.Excel.Range oXlCell=null;
        
        	Microsoft.Office.Interop.Excel._Application oXlApp=new ApplicationClass();
        	oXlApp.Visible=false;
        	
        	try
        	{
        		oXlWrkBk=oXlApp.Workbooks.Open(FilePath);
        		oXlWrkSht=(Worksheet) oXlWrkBk.Worksheets[1];
        		
        		int iLine=1;
        		oXlCell=(Range)oXlWrkSht.Cells[iLine,1];
        		CellTxt = oXlCell.Text.ToString();
        		
        		//while(!(oXlCell.Text.Equals("")))
        		while (!CellTxt.Equals(""))
        		{
        			int iCol=1;
        			int DataCnt=0;
        			
        			oXlCell=(Range)oXlWrkSht.Cells[iLine,iCol];
        			CellTxt = oXlCell.Text.ToString();
        			
        			//while(!(oXlCell.Text.ToString().Equals("")))
        			while (!CellTxt.Equals(""))
        			{
        				if(iLine==1)
	        			{
	        				if(iCol!=1) //First column = Time
	        				{
		        				ImportDataChannel oChan = new ImportDataChannel();
		        				//oChan.ChannelName = oXlCell.Text.ToString();
		        				oChan.ChannelName = CellTxt;
	                            Channels.Add(oChan);
	        				}
	        			}
	        			else
	        			{
							double Value = 0;
							//if (double.TryParse(oXlCell.Text.ToString(), out Value))
							if (double.TryParse(CellTxt, out Value))
	                        {
	                            if (iCol == 1) //Time
	                            {
	                                Time.Add(Value);
	                            }
	                            else //Data
	                            {
	                                if (iCol-1 <= Channels.Count)
	                                {
	                                    Channels[iCol - 2].Samples.Add(Value);
	                                    DataCnt++;
	                                }
	                            }
	                        }
	                        else
	                        {
	                            Ret=false;
	                            break;
	                        }	        				
	        			}
	        			
	        			iCol++;
	        			oXlCell=(Range)oXlWrkSht.Cells[iLine,iCol];
	        			CellTxt = oXlCell.Text.ToString();
        			}
        			
        			if(!(iLine==1))
        			{
        				if(!(DataCnt==Channels.Count)) //Some data are missing
        				{
        					Ret=false;
        				}
        			}
        			
        			if(!(Ret))
        			{
        				break; //Loop exit on error detection
        			}
        			
        			iLine++;
        			oXlCell=(Range)oXlWrkSht.Cells[iLine,1];
        			CellTxt = oXlCell.Text.ToString();
        			
        			if (HeaderOnly)
        			{
        				break;
        			}
        		}
        	}
        	catch
        	{
        		Ret=false;
        	}
        	
        	if (!HeaderOnly)
        	{
        		FileLoaded = true;
        	}
        	
        	oXlWrkBk.Close(false);
        	oXlWrkBk=null;
        	
        	oXlApp.Quit();
        	oXlApp=null;
        	
        	return(Ret);
        }

        private ImportDataChannel GetDataChannel(string ChannelName)
        {
            foreach (ImportDataChannel oChan in Channels)
            {
                if (oChan.ChannelName.Equals(ChannelName))
                {
                    return (oChan);
                }
            }

            return (null);
        }

        #endregion
    }
}
