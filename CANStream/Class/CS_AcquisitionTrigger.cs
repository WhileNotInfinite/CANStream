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

namespace CANStream
{
	/// <summary>
	/// CANStream acquisition trigger class
	/// </summary>
	public class CS_AcquisitionTrigger
	{
		#region Public events
		
		public event EventHandler<TriggerChangedEventArg> TriggerStatusChanged;
		
		#endregion
		
		#region Public members
		
		/// <summary>Trigger name</summary>
		public string Name;
		
		/// <summary>Post trigger time</summary>
		public int PostTrigger;
		
		/// <summary>Trigger state (True: triggering condition true / False: triggering condition false</summary>
		public bool Status;
		
		/// <summary>Trigger avialability status</summary>
		public bool Available;
		
		#endregion
		
		#region Private members
		
		/// <summary>Trigger math expression</summary>
		private string Expression;
		
		#endregion
		
		/// <summary>
		/// Default constructor
		/// </summary>
		public CS_AcquisitionTrigger()
		{
			Name = "";
			Expression = "";
			PostTrigger = 0;
			
			Status = false;
			Available = false;
		}
		
		#region Public methods
		
		public void UpdateTriggerStatus()
		{
			bool OldStatus = Status;
			
			if (OldStatus != Status)
			{
				//Trigger status changed event firing
				TriggerChangedEventArg Args = new TriggerChangedEventArg();
				Args.Status=Status;
				OnTriggerStatusChanged(Args);
			}
		}
		
		#endregion
		
		#region Events handling methods
		
		protected virtual void OnTriggerStatusChanged(TriggerChangedEventArg e)
		{
			EventHandler<TriggerChangedEventArg> Handler = TriggerStatusChanged;
			if (Handler != null)
			{
				Handler(this, e);
			}
		}
		
		#endregion
	}
	
	/// <summary>
	/// Trigger status changed event argument
	/// </summary>
	public class TriggerChangedEventArg : EventArgs
	{
		public bool Status {get; set;}
	}
}
