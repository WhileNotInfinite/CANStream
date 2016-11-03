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