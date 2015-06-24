/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 7/17/2013
 * Time: 11:37 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

namespace CANStream
{
	/// <summary>
	/// CANStream global constants class
	/// </summary>
	public static class CANStreamConstants
	{
		#region Registry Keys
		
		public const string CS_REG_KEY = "HKEY_CURRENT_USER\\Software\\CanStream";
		
		#endregion
		
		#region Import data file constants
		
		/// <summary>
		/// Import data file extension filter list
		/// </summary>
		public const string DataFileFilter="CSV file|*.csv|PRN file|*.prn|Text file|*.txt|Microsoft Excel 97 file|*.xls|Microsoft Excel xml file|*.xlsx";
		
		/// <summary>
		/// Default import data file extension filter index
		/// </summary>
		public const int DataFileFilterIndex=0;
		
		/// <summary>
		/// Import data file reading error text message
		/// </summary>
		public const string DataFileReadingErrorText="Data file reading error !\nCheck whether the file isn't locked by another application or the file doesn't contain unexpected character or stucture";
		
		#endregion
		
		#region Record conversion
		
		public const string StackDirectory="\\CANStream\\Records\\Stack";
		public const string DataDirectory="\\CANStream\\Records\\Data";
		public const string RawDirectory="\\CANStream\\Records\\Raw";
		public const long TextRecordDataFileSizeMax = 50 * 1048576; // 1 MByte = 1048576 Bytes
		
		#endregion
		
		#region Cycle graph constants
		
		public const int CycleGraphPlotAreaLeft = 60;
		public const int CycleGraphPlotAreaTop = 20;
		public const int CycleGraphPlotAreaWidthOffset = 250;
		public const int CycleGraphPlotAreaHeightOffset = 70;
		
		#endregion
	}
}