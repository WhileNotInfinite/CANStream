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

namespace CANStream
{
	#region Structures
	
	/// <summary>
	/// Single graph axis propertie structure
	/// </summary>
	public struct CS_Axis
	{
		public double MinValue;
		public double MaxValue;
		public double StepValue;
		public List<int> SeriesIds;
	}
	
	#endregion
	
	/// <summary>
	/// All graph axis properties class
	/// </summary>
	public class GraphAxis
	{
		#region Public members
		
		public CS_Axis AxisX;
		public CS_Axis AxisY1;
		public CS_Axis AxisY2;
		
		#endregion
		
		public GraphAxis()
		{
			AxisX = new CS_Axis();
			
			AxisY1 = new CS_Axis();
			AxisY1.SeriesIds=new List<int>();
			
			AxisY2 = new CS_Axis();
			AxisY2.SeriesIds=new List<int>();
		}
	}

	/// <summary>
    /// Class of a single graphic serie
    /// </summary>
    public class SingleGraphicSerie
    {
    	#region Public members
    	
    	public string Name;
    	public List<double> Times;
    	public List<double> Data;
    	
    	#endregion
    	
    	public SingleGraphicSerie()
    	{
    		Name="";
    		Times=new List<double>();
    		Data=new List<double>();
    	}
    	
    	#region public metodes
    	
    	public double GetValueAtTime(double TimeValue)
    	{
    		for(int iSample=0;iSample<Times.Count;iSample++)
    		{
    			if(Times[iSample]>TimeValue)
    			{
    				if(!(iSample==0))
    				{
    					iSample--;
    				}
    				
    				return(Data[iSample]);
    			}
    		}
    		
    		return(Data[Data.Count-1]);
    	}
    	
    	#endregion
    	
    }
    
    /// <summary>
    /// Single graph serie formated to be plotted into a graph window
    /// </summary>
    public class FormatedGraphSerie
    {
    	#region Public member
    	
    	public string Name;
    	public double[] XValues;
    	public double[] YValues;
    	public bool Visible;
    	
    	#endregion
    	
    	public FormatedGraphSerie()
    	{
    	}
    }
    
    /// <summary>
    /// Single graph serie formated to be plotted into a real time graph window
    /// </summary>
    public class RT_FormatedGraphSerie:FormatedGraphSerie
    {
    	#region Private constants
    	
    	private const int RT_GRAPH_MAX_SAMPLES=1000;
    	
    	#endregion
    	
    	#region Private members
    	
    	private int LastSampleIndex;
    	private int SamplesCount;
    	
    	#endregion
    	
    	#region Public enums
    	
    	public enum BufferName
    	{
    		XValue = 0,
    		YValue = 1,
    	}
    	
    	#endregion
    	
    	public RT_FormatedGraphSerie(int NSamples)
    	{
    		LastSampleIndex=-1;
    		
    		if(NSamples<=RT_GRAPH_MAX_SAMPLES)
    		{
    			SamplesCount=NSamples;
    		}
    		else
    		{
    			SamplesCount=RT_GRAPH_MAX_SAMPLES;
    		}
    		
    		XValues=new double[SamplesCount];
    		YValues=new double[SamplesCount];
    		Visible=false;
    	}
    	
    	#region public methodes
    	
    	/// <summary>
    	/// Add a sample into the real time formated graphic serie
    	/// </summary>
    	/// <param name="TimeValue">Sample time value</param>
    	/// <param name="SampleValue">Sample serie value</param>
    	public void Add_RT_Sample(double TimeValue, double SampleValue)
    	{
    		if(LastSampleIndex < (SamplesCount -1)) //Add sample to the next index
    		{
    			LastSampleIndex++;
    			XValues[LastSampleIndex]=TimeValue;
    			YValues[LastSampleIndex]=SampleValue;
    		}
    		else //FIFO
    		{
    			for(int i=0;i< (SamplesCount -1);i++)
    			{
    				XValues[i]=XValues[i+1];
    				YValues[i]=YValues[i+1];
    			}
    			
    			XValues[LastSampleIndex]=TimeValue;
    			YValues[LastSampleIndex]=SampleValue;
    		}
    	}
    	
    	/// <summary>
    	/// Get the latest sample time value of the serie
    	/// </summary>
    	/// <returns>Latest sample time value of the serie</returns>
    	public Double GetLatestSampleTime()
    	{
    		return(XValues[LastSampleIndex]);
    	}
    	
    	/// <summary>
    	/// Get the ploting value buffer. If main buffer is not full, only filled value are sent to avoid ploting multpiple [0;0] points on the graph
    	/// </summary>
    	/// <param name="eBuffer">Name of buffer requested</param>
    	/// <returns>Buffer of plotting values</returns>
    	public double[] Get_PlotBuffer(BufferName eBuffer)
    	{
    		double[] pBuffer=null;
    		
    		switch(eBuffer)
    		{
    			case BufferName.XValue:
    				pBuffer=XValues;
    				break;
    			case BufferName.YValue:
    				pBuffer=YValues;
    				break;
    		}
    		 
    		if(LastSampleIndex == SamplesCount-1)
    		{
    			return(pBuffer);
    		}
    		else
    		{
    			double[] PlotBuffer=new double[LastSampleIndex];
    			
    			for(int i=0;i<LastSampleIndex;i++)
    			{
    				PlotBuffer[i]=pBuffer[i];
    			}
    			
    			return(PlotBuffer);
    		}
    	}
    	
    	#endregion
    }
    
	/// <summary>
	/// Class of a collection of graphic series
	/// </summary>
	public class GraphicSeries
	{
		#region Private constants
		
		private const int GRAPH_MAX_SAMPLES=1000;
		
		#endregion
		
		#region Public members
		
		/// <summary>
		/// List of single graphic serie
		/// </summary>
		public List<SingleGraphicSerie> Series;
		
		/// <summary>
		/// List of formated graphic series
		/// </summary>
		public List<FormatedGraphSerie> FormatedSeries;
		
		/// <summary>
		/// X, Y1 & Y2 axis properties structure
		/// </summary>
		public GraphAxis AxisProperties;
		
		#endregion
		
		public GraphicSeries()
		{
			Series=new List<SingleGraphicSerie>();
		}
		
		#region Public methodes
        
		/// <summary>
		/// Add a sample to a graphic serie, if the serie doesn't exist a new serie will be created
		/// </summary>
		/// <param name="SerieName">Name of the serie in which the sample will be added</param>
		/// <param name="Time">Time value of the sample</param>
		/// <param name="Value">Value of the sample</param>
        public void AddGraphicSerieSample(string SerieName, double Time, double Value)
        {
        	SingleGraphicSerie oSerie=null;
        	
        	if(!(GraphSerieExists(SerieName)))
        	{
        		oSerie=new SingleGraphicSerie();
        		oSerie.Name=SerieName;
        		Series.Add(oSerie);
        	}
        	else
        	{
        		oSerie=GetGraphSerie(SerieName);
        	}
        	
        	if(!(oSerie==null))
        	{
        		oSerie.Times.Add(Time);
        		oSerie.Data.Add(Value);
        	}
        }
        
        /// <summary>
        /// Format all single graph serie to be plotable into a graph window
        /// </summary>
        public void ProcessGraphicSeries()
        {
        	if(Series.Count>0)
        	{
        		FormatedSeries=new List<FormatedGraphSerie>();
        		AxisProperties=new GraphAxis();
        		
        		//Format X Axis
        		AxisProperties.AxisX.MinValue=0;
        		AxisProperties.AxisX.MaxValue=GetOverallLastTimeValue();
        		AxisProperties.AxisX.StepValue=Math.Round(AxisProperties.AxisX.MaxValue/10,0);
        		
        		//Format Y axis
        		AxisProperties.AxisY1.MinValue=GetOverallMinValue();
        		AxisProperties.AxisY1.MaxValue=GetOverallMaxValue();
        		AxisProperties.AxisY1.StepValue=Math.Round((AxisProperties.AxisY1.MaxValue - AxisProperties.AxisY1.MinValue)/10,0);
        		
        		foreach(SingleGraphicSerie oSerie in Series)
        		{
        			FormatedGraphSerie oFSerie=new FormatedGraphSerie();
        			oFSerie.Name=oSerie.Name;
        			oFSerie.Visible=true;
        			
        			int SampleCount=oSerie.Data.Count;
        			
        			if(SampleCount>GRAPH_MAX_SAMPLES)
        			{
        				SampleCount=GRAPH_MAX_SAMPLES;
        			}
        			
        			int SampleStep=(int)(oSerie.Data.Count/SampleCount);
        				
        			oFSerie.XValues=new double[SampleCount];
        			oFSerie.YValues=new double[SampleCount];
        			
        			int iFSample=0;
        			
        			for(int iSample=0;iSample<oSerie.Data.Count;iSample=iSample+SampleStep)
        			{
        				if(iFSample>=SampleCount)
        				{
        					break;
        				}
        				
        				oFSerie.XValues[iFSample]=oSerie.Times[iSample];
        				oFSerie.YValues[iFSample]=oSerie.Data[iSample];
        				iFSample++;
        			}
        			
        			FormatedSeries.Add(oFSerie);
        		}
        	}
        }
        
        /// <summary>
        /// Set the visible propertie of the specified formated serie
        /// </summary>
        /// <param name="SerieName">Name of the serie to be set</param>
        /// <param name="Visisble">Visible propertie value</param>
        public void SetFormatedSerieVisible(string SerieName, bool Visisble)
        {
        	if(!(FormatedSeries==null))
        	{
        		foreach(FormatedGraphSerie oSerie in FormatedSeries)
        		{
        			if(oSerie.Name.Equals(SerieName))
        			{
        				oSerie.Visible=Visisble;
        				return;
        			}
        		}
        	}
        }
        
        #endregion
		
		#region Private methodes
        
        private bool GraphSerieExists(string SerieName)
        {
        	foreach(SingleGraphicSerie Serie in Series)
        	{
        		if(Serie.Name.Equals(SerieName))
        		{
        			return(true);
        		}
        	}
        	
        	return(false);
        }
        
        private SingleGraphicSerie GetGraphSerie(string SerieName)
        {
        	foreach(SingleGraphicSerie Serie in Series)
        	{
        		if(Serie.Name.Equals(SerieName))
        		{
        			return(Serie);
        		}
        	}
        	
        	return(null);
        }
        
        private double GetOverallLastTimeValue()
        {
        	double LastTime=0;
        	
        	foreach(SingleGraphicSerie oSerie in Series)
        	{
        		if(LastTime==0)
        		{
        			LastTime=oSerie.Times[oSerie.Times.Count-1];
        		}
        		else
        		{
        			if(oSerie.Times[oSerie.Times.Count-1]>LastTime)
        			{
        				LastTime=oSerie.Times[oSerie.Times.Count-1];
        			}
        		}
        	}
        	
        	return(LastTime);
        }
        
        private int GetOverallMaxSampleCount()
        {
        	int MaxSample=0;
        	
        	foreach(SingleGraphicSerie oSerie in Series)
        	{
        		if(MaxSample==0)
        		{
        			MaxSample=oSerie.Data.Count;
        		}
        		else
        		{
        			if(oSerie.Data.Count>MaxSample)
        			{
        				MaxSample=oSerie.Data.Count;
        			}
        		}
        	}
        	
        	return(MaxSample);
        }
        
        private double GetOverallMaxValue()
        {
        	double MaxValue=0;
        	
        	for(int iSerie=0;iSerie<Series.Count;iSerie++)
        	{
        		for(int iSample=0;iSample<Series[iSerie].Data.Count;iSample++)
        		{
        			if(iSerie==0 & iSample==0)
        			{
        				MaxValue=Series[iSerie].Data[iSample];
        			}
        			else
        			{
        				if(Series[iSerie].Data[iSample]>MaxValue)
        				{
        					MaxValue=Series[iSerie].Data[iSample];
        				}
        			}
        		}
        	}
        	
        	return(MaxValue);
        }
        
        private double GetOverallMinValue()
        {
        	double MinValue=0;
        	
        	for(int iSerie=0;iSerie<Series.Count;iSerie++)
        	{
        		for(int iSample=0;iSample<Series[iSerie].Data.Count;iSample++)
        		{
        			if(iSerie==0 & iSample==0)
        			{
        				MinValue=Series[iSerie].Data[iSample];
        			}
        			else
        			{
        				if(Series[iSerie].Data[iSample]<MinValue)
        				{
        					MinValue=Series[iSerie].Data[iSample];
        				}
        			}
        		}
        	}
        	
        	return(MinValue);
        }
        
        #endregion   
	}
	
	/// <summary>
	/// Class of a collection of real time graphic serie
	/// </summary>
	public class RT_GraphicSeries
	{
		#region Public members
		
		public List<RT_FormatedGraphSerie> RTSeries;
		public int BufferSize;
		
		#endregion
		
		public RT_GraphicSeries()
		{
			RTSeries=new List<RT_FormatedGraphSerie>();
		}
		
		#region Public methodes
		
		/// <summary>
		/// Add a sample to a real time graphic serie, if the serie doesn't exist a new serie will be created
		/// </summary>
		/// <param name="SerieName">Name of the serie in which the sample will be added</param>
		/// <param name="TimeValue">Time value of the sample</param>
		/// <param name="SampleValue">Value of the sample</param>
		public void AddSerieSamples(string SerieName,double TimeValue,double SampleValue)
		{
			int iSerie=-1;
			for(int i=0;i<RTSeries.Count;i++)
			{
				if(RTSeries[i].Name.Equals(SerieName))
				{
					iSerie=i;
					break;
				}
			}
			
			if(iSerie==-1)
			{
				RT_FormatedGraphSerie oNewSerie=new RT_FormatedGraphSerie(BufferSize);
				oNewSerie.Name=SerieName;
				RTSeries.Add(oNewSerie);
				iSerie=RTSeries.Count-1;
			}
			
			RTSeries[iSerie].Add_RT_Sample(TimeValue,SampleValue);
		}
		
		/// <summary>
		/// Set the visible propertie of the specified formated real time serie
		/// </summary>
		/// <param name="SerieName">Name of the serie to be set</param>
		/// <param name="bVisible">Visible propertie value</param>
		public void SetSerieVisible(string SerieName,bool bVisible)
		{
			foreach(RT_FormatedGraphSerie oSerie in RTSeries)
			{
				if(oSerie.Name.Equals(SerieName))
				{
					oSerie.Visible=bVisible;
					break;
				}
			}
		}
		
		/// <summary>
		/// Get the minimum time value overall series
		/// </summary>
		/// <returns>Minimum time value overall series</returns>
		public double GetMinTimeSampleOverAll()
		{
			double MinTime=0;
			
			for(int i=0;i<RTSeries.Count;i++)
			{
				if(i==0)
				{
					MinTime=RTSeries[i].XValues[0];
				}
				else
				{
					if(RTSeries[i].XValues[0]<MinTime)
					{
						MinTime=RTSeries[i].XValues[0];
					}
				}
			}
			
			return(MinTime);
		}
		
		/// <summary>
		/// Get the latest time value overall series
		/// </summary>
		/// <returns>Latest time value overall series</returns>
		public double GetMaxTimeSampleOverAll()
		{
			double MaxTime=0;
			
			for(int i=0;i<RTSeries.Count;i++)
			{
				if(i==0)
				{
					MaxTime=RTSeries[i].GetLatestSampleTime();
				}
				else
				{
					if(RTSeries[i].GetLatestSampleTime()>MaxTime)
					{
						MaxTime=RTSeries[i].GetLatestSampleTime();
					}
				}
			}
			
			return(MaxTime);
		}
		
		#endregion
	}
}
