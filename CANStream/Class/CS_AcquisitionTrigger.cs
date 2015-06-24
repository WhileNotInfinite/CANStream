/*
 * Created by SharpDevelop.
 * User: Vincent
 * Date: 08/02/2015
 * Time: 12:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
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
