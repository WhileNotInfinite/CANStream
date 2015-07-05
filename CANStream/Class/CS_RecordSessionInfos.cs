/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 8/14/2014
 * Time: 16:10 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Xml;

namespace CANStream
{
	/// <summary>
	/// Event/Session information structure
	/// </summary>
	public struct CS_RecordUserInfo
	{
		/// <summary>
		/// Title of the user info
		/// </summary>
		public string Title;
		
		/// <summary>
		/// Value of the user info
		/// </summary>
		public string Value;
	}
	
	/// <summary>
	/// Event/Session informations collection class
	/// </summary>
	public class CS_RecordUserInfoCollection
	{
		#region Public members
		
		/// <summary>
		/// List of CS_RecordUserInfo
		/// </summary>
		public List<CS_RecordUserInfo> Informations;
		
		#endregion
		
		public CS_RecordUserInfoCollection()
		{
			Informations = new List<CS_RecordUserInfo>();
		}
		
		#region Public methodes
		
		/// <summary>
		/// Return the XML node of the user info collection
		/// </summary>
		/// <param name="oXDoc">Owner XML document</param>
		/// <param name="NodeName">Name of node to create</param>
		/// <returns>XML node of the user info collection</returns>
		public XmlElement Create_UserInfoCollectionXmlNode(XmlDocument oXDoc, string NodeName)
		{
			XmlElement xInfo = null;
			
			XmlElement xCollection = oXDoc.CreateElement(NodeName);
			
			foreach (CS_RecordUserInfo sInfo in Informations)
			{
				xInfo = oXDoc.CreateElement("UserInfo");
				
					XmlAttribute xAtrTitle = oXDoc.CreateAttribute("Title");
					xAtrTitle.Value = sInfo.Title;
					xInfo.Attributes.Append(xAtrTitle);
					
					xInfo.InnerText = sInfo.Value;
				
				xCollection.AppendChild(xInfo);
			}
			
			return(xCollection);
		}
		
		/// <summary>
		/// Save the user informations collection into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to create</param>
		public void Write_UserInfoCollection(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oInfoDoc = new XmlDocument();
				oInfoDoc.AppendChild(Create_UserInfoCollectionXmlNode(oInfoDoc, "RecordUserInfoCollection"));
				oInfoDoc.Save(fPath);
			}
		}
		
		/// <summary>
		/// Read XML node of a user info collection
		/// </summary>
		/// <param name="xCollection">XML node to read</param>
		/// <returns>Node reading error: True = No error / False =  Error</returns>
		public bool Read_UserInfoCollectionXmlNode(XmlNode xCollection)
		{
			try
			{
				Informations = new List<CS_RecordUserInfo>();
				
				foreach (XmlNode xInfo in xCollection.ChildNodes)
				{
					if (xInfo.Name.Equals("UserInfo"))
					{
						CS_RecordUserInfo sInfo = new CS_RecordUserInfo();
						
							sInfo.Title = xInfo.Attributes["Title"].Value;
							sInfo.Value = xInfo.InnerText;
						
						Informations.Add(sInfo);
					}
				}
			}
			catch
			{
				return(false);
			}
			
			return(true);
		}
		
		/// <summary>
		/// Read the user informations collection into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to read</param>
		/// <returns>File reading error flag: True = No Error / False = Error</returns>
		public bool Load_UserInfoCollection(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oInfoDoc = new XmlDocument();
				oInfoDoc.Load(fPath);
				
				return(Read_UserInfoCollectionXmlNode(oInfoDoc.FirstChild));
			}
			
			return(false);
		}
		
		#endregion
	}
	
	/// <summary>
	/// Record session class
	/// </summary>
	public class CS_RecordSession
	{
		#region Public members
		
		/// <summary>
		/// Record session name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Record session starting date
		/// </summary>
		public DateTime SessionDate;
		
		/// <summary>
		/// Record session comment
		/// </summary>
		public string Comment;
		
		/// <summary>
		/// User info of the record session
		/// </summary>
		public CS_RecordUserInfoCollection UserInfos;
			
		#endregion
		
		public CS_RecordSession()
		{
			Name = "New session";
			SessionDate = DateTime.Now;
			Comment = "";
			UserInfos = new CS_RecordUserInfoCollection();
		}
		
		#region Public methodes
		
		/// <summary>
		/// Return the XML node of the record session
		/// </summary>
		/// <param name="oXDoc">Owner XML document</param>
		/// <param name="NodeName">Name of node to create</param>
		/// <returns>XML node of the record session</returns>
		public XmlElement Create_RecordSessionInfoXmlNode(XmlDocument oXDoc, string NodeName)
		{
			XmlElement xProp = null;
			
			XmlElement xSession = oXDoc.CreateElement(NodeName);
			
				xProp = oXDoc.CreateElement("Name");
				xProp.InnerText = Name;
				xSession.AppendChild(xProp);
				
				xProp = oXDoc.CreateElement("Date");
				xProp.InnerText = SessionDate.ToString();
				xSession.AppendChild(xProp);
				
				xProp = oXDoc.CreateElement("Comment");
				xProp.InnerText = Comment;
				xSession.AppendChild(xProp);
				
				xSession.AppendChild(UserInfos.Create_UserInfoCollectionXmlNode(oXDoc, "SessionUserInfo"));
			
			return(xSession);
		}
		
		/// <summary>
		/// Save the record session into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to create</param>
		public void Write_RecordSessionInformationFile(string fPath)
		{
			if(!(fPath.Equals("")))
			{
				XmlDocument oXDoc= new XmlDocument();
				oXDoc.AppendChild(Create_RecordSessionInfoXmlNode(oXDoc, "RecordSessionInformation"));
				oXDoc.Save(fPath);
			}
		}
		
		/// <summary>
		/// Read XML node of a record session
		/// </summary>
		/// <param name="xSession">XML node to read</param>
		/// <returns>Node reading error: True = No error / False =  Error</returns>
		public bool Read_RecordSessionInfoXmlNode(XmlNode xSession)
		{
			try
			{
				XmlNode xProp = null;
				
				xProp = xSession.SelectSingleNode("Name");
				Name = xProp.InnerText;
				
				xProp = xSession.SelectSingleNode("Date");
				SessionDate = DateTime.Parse(xProp.InnerText);
				
				xProp = xSession.SelectSingleNode("Comment");
				Comment = xProp.InnerText;
				
				UserInfos.Read_UserInfoCollectionXmlNode(xSession.SelectSingleNode("SessionUserInfo"));
			}
			catch
			{
				return(false);
			}
			
			return(true);
		}
		
		/// <summary>
		/// Read the record session into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to read</param>
		/// <returns>File reading error flag: True = No Error / False = Error</returns>
		public bool Load_RecordSessionInformationFile(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oXSession = new XmlDocument();
				oXSession.Load(fPath);
				
				return(Read_RecordSessionInfoXmlNode(oXSession.FirstChild));
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return a clone of the current object
		/// </summary>
		/// <returns>Clone of the current object</returns>
		public CS_RecordSession Clone()
		{
			CS_RecordSession oClone = new CS_RecordSession();
			
			oClone.Name = Name;
			oClone.SessionDate = SessionDate;
			oClone.Comment = Comment;
			
			foreach(CS_RecordUserInfo sInfo in UserInfos.Informations)
			{
				CS_RecordUserInfo rui = new CS_RecordUserInfo();
				rui.Title = sInfo.Title;
				rui.Value = sInfo.Value;
				
				oClone.UserInfos.Informations.Add(rui);
			}
			
			return(oClone);
		}
		
		#endregion
	}
	
	/// <summary>
	/// Record event class
	/// </summary>
	public class CS_RecordEvent
	{
		#region Public members
		
		/// <summary>
		/// Record event name
		/// </summary>
		public string Name;
		
		/// <summary>
		/// Record event starting date
		/// </summary>
		public DateTime StartingDate;
		
		/// <summary>
		/// Record event comment
		/// </summary>
		public string Comment;
		
		/// <summary>
		/// Sessions list of the event
		/// </summary>
		public List<CS_RecordSession> Sessions;
		
		/// <summary>
		/// Record session currently in use inside the event
		/// </summary>
		public CS_RecordSession CurrentSession;
		
		/// <summary>
		/// Event user informations
		/// </summary>
		public CS_RecordUserInfoCollection UserInfos;
		
		#endregion
		
		public CS_RecordEvent()
		{
			Name = "New event";
			StartingDate = DateTime.Now;
			Comment = "";
			Sessions = new List<CS_RecordSession>();
			UserInfos = new CS_RecordUserInfoCollection();
			
			//Creation of the first session of the event
			CS_RecordSession oSession = new CS_RecordSession();
			Sessions.Add(oSession);
			CurrentSession = Sessions[0];
		}
		
		#region Public methodes
		
		#region Session functions
	
		/// <summary>
		/// Return the record session corresponding to the name given as argument
		/// </summary>
		/// <param name="Name">Name of the session to return</param>
		/// <returns>Record session corresponding to the name given as argument. Null if not found.</returns>
		public CS_RecordSession Get_RecordSession(string SessionName)
		{
			if (!(SessionName.Equals("")))
			{
				foreach (CS_RecordSession oSession in Sessions)
				{
					if (oSession.Name.Equals(SessionName))
					{
						return(oSession);
					}
				}
			}
			
			return(null);
		}
		
		/// <summary>
		/// Return a flag indicating whether or not a session corresponding the name
		/// given a argument exist within the event
		/// </summary>
		/// <param name="SessionName">Name of the session to search</param>
		/// <returns>Existance flag: True = Session exists / False = Session doesn't exist</returns>
		public bool RecordSessionExists(string SessionName)
		{
			foreach (CS_RecordSession oSession in Sessions)
			{
				if (oSession.Name.Equals(SessionName))
				{
					return(true);
				}
			}
			
			return(false);
		}
		
		/// <summary>
		/// Return the index of session corresponding to the name given as argument
		/// </summary>
		/// <param name="SessionName">Name of the session to search<</param>
		/// <returns>Index of session corresponding to the name given as argument, return -1 if not found</returns>
		public int Get_SessionIndex(string SessionName)
		{
			for (int i=0; i<Sessions.Count; i++)
			{
				if (Sessions[i].Name.Equals(SessionName))
				{
					return(i);
				}
			}
			
			return(-1);
		}
		
		#endregion
		
		#region Event information file
		
		/// <summary>
		/// Return the XML node of the record event
		/// </summary>
		/// <param name="oXDoc">Owner XML document</param>
		/// <param name="NodeName">Name of node to create</param>
		/// <returns>XML node of the record event</returns>
		public XmlElement Create_RecordEventInfoXmlNode(XmlDocument oXDoc, string NodeName)
		{
			XmlElement xProp = null;
			
			XmlElement xEvent = oXDoc.CreateElement(NodeName);
			
				xProp = oXDoc.CreateElement("Name");
				xProp.InnerText = Name;
				xEvent.AppendChild(xProp);
				
				xProp = oXDoc.CreateElement("Date");
				xProp.InnerText = StartingDate.ToString();
				xEvent.AppendChild(xProp);
				
				xProp = oXDoc.CreateElement("Comment");
				xProp.InnerText = Comment;
				xEvent.AppendChild(xProp);
				
				xEvent.AppendChild(UserInfos.Create_UserInfoCollectionXmlNode(oXDoc, "EventUserInfo"));
			
			return(xEvent);
		}
		
		/// <summary>
		/// Save the record event into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to create</param>
		public void Write_RecordEventInformationFile(string fPath)
		{
			if(!(fPath.Equals("")))
			{
				XmlDocument oXDoc= new XmlDocument();
				oXDoc.AppendChild(Create_RecordEventInfoXmlNode(oXDoc, "EventSessionInformation"));
				oXDoc.Save(fPath);
			}
		}
		
		/// <summary>
		/// Read XML node of a record event
		/// </summary>
		/// <param name="xEvent">XML node to read</param>
		/// <returns>Node reading error: True = No error / False =  Error</returns>
		public bool Read_RecordEventInfoXmlNode(XmlNode xEvent)
		{
			try
			{
				XmlNode xProp = null;
				
				xProp = xEvent.SelectSingleNode("Name");
				Name = xProp.InnerText;
				
				xProp = xEvent.SelectSingleNode("Date");
				StartingDate = DateTime.Parse(xProp.InnerText);
				
				xProp = xEvent.SelectSingleNode("Comment");
				Comment = xProp.InnerText;
				
				UserInfos.Read_UserInfoCollectionXmlNode(xEvent.SelectSingleNode("EventUserInfo"));
			}
			catch
			{
				return(false);
			}
			
			return(true);
		}
		
		/// <summary>
		/// Read the record event into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to read</param>
		/// <returns>File reading error flag: True = No Error / False = Error</returns>
		public bool Load_RecordEventInformationFile(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oXEvent = new XmlDocument();
				oXEvent.Load(fPath);
				
				return(Read_RecordEventInfoXmlNode(oXEvent.FirstChild));
			}
			
			return(false);
		}
		
		#endregion
		
		#endregion
	}
	
	/// <summary>
	/// Record event collection class
	/// </summary>
	public class CS_RecordEventsCollection
	{
		#region Public members
		
		public List<CS_RecordEvent> Events;
		
		#endregion
		
		public CS_RecordEventsCollection()
		{
			Events = new List<CS_RecordEvent>();
		}
		
		#region Public methods
		
		/// <summary>
		/// Save the record event collection into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to create</param>
		public void Write_EventsCollectionFile(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oXEventsCollection = new XmlDocument();
				
				XmlElement xCollection = oXEventsCollection.CreateElement("RecordEventsCollection");
				oXEventsCollection.AppendChild(xCollection);
				
				foreach (CS_RecordEvent oEvent in Events)
				{
					XmlElement xEvent = oEvent.Create_RecordEventInfoXmlNode(oXEventsCollection, "RecordEvent");
					
						XmlElement xSessions = oXEventsCollection.CreateElement("Sessions");
						xEvent.AppendChild(xSessions);
					
						foreach (CS_RecordSession oSession in oEvent.Sessions)
						{
							xSessions.AppendChild(oSession.Create_RecordSessionInfoXmlNode(oXEventsCollection, "RecordSession"));
						}
						
						XmlElement xActiveSession = oXEventsCollection.CreateElement("ActiveSession");
						xActiveSession.InnerText = oEvent.CurrentSession.Name;
						xEvent.AppendChild(xActiveSession);
					
					xCollection.AppendChild(xEvent);
				}
				
				oXEventsCollection.Save(fPath);
			}
		}
		
		/// <summary>
		/// Read the record event collection into an XML file
		/// </summary>
		/// <param name="fPath">Path of file to read</param>
		/// <returns>File reading error flag: True = No Error / False = Error</returns>
		public bool Read_EventsCollectionFile(string fPath)
		{
			try
			{
				XmlDocument oXEventsCollection = new XmlDocument();
				oXEventsCollection.Load(fPath);
				
				Events = new List<CS_RecordEvent>();
				XmlNode xCollection = oXEventsCollection.SelectSingleNode("RecordEventsCollection");
				
				foreach (XmlNode xEvent in xCollection.ChildNodes)
				{
					if (xEvent.Name.Equals("RecordEvent"))
					{
						CS_RecordEvent oEvent = new CS_RecordEvent();
						
						if (oEvent.Read_RecordEventInfoXmlNode(xEvent))
						{
							XmlNode xSessionsList = xEvent.SelectSingleNode("Sessions");
							oEvent.Sessions = new List<CS_RecordSession>();
							
							foreach (XmlNode xSession in xSessionsList.ChildNodes)
							{
								if (xSession.Name.Equals("RecordSession"))
								{
									CS_RecordSession oSession = new CS_RecordSession();
									
									if (oSession.Read_RecordSessionInfoXmlNode(xSession))
									{
										oEvent.Sessions.Add(oSession);
									}
								}
							}
							
							XmlNode xActiveSession = xEvent.SelectSingleNode("ActiveSession");
							oEvent.CurrentSession = oEvent.Get_RecordSession(xActiveSession.InnerText);
							
							Events.Add(oEvent);
						}
					}
				}
			}
			catch
			{
				return(false);
			}
			
			return(true);
		}
		
		/// <summary>
		/// Return the index in the collection of the record event corresponding to the name and starting date given as arguments
		/// </summary>
		/// <param name="EventName">Name of the event</param>
		/// <param name="EventDate">Starting date of the event</param>
		/// <returns>Index in the collection of the record event</returns>
		/// <remarks>Return -1 if the record event is not found</remarks>
		public int Get_RecordEventIndex(string EventName, DateTime EventDate)
		{
			for (int i=0; i<Events.Count; i++)
			{
				if (Events[i].Name.Equals(EventName) && Events[i].StartingDate.Date.Equals(EventDate.Date))
				{
					return(i);
				}
			}
			
			return(-1);
		}
		
		#endregion
	}
}
