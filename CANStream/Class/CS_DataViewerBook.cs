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
using System.Xml;

using Ctrl_GraphWindow;

namespace CANStream
{
	[Serializable]
    public class CS_DataViewerPage
	{
		#region Public members
		
		#region Saved members
		
		public string Name;
		public int KeyId;
		
		public GraphWindowProperties GraphicProperties;
		
		#endregion
		
		#endregion
		
		public CS_DataViewerPage()
		{
			Name = "";
			KeyId = -1;
			
			GraphicProperties = new GraphWindowProperties();
        }

        #region Public methodes

        public CS_DataViewerPage Get_Clone()
        {
            CS_DataViewerPage oClone = new CS_DataViewerPage();

                oClone.Name = this.Name;
                oClone.KeyId = -1;
                oClone.GraphicProperties = this.GraphicProperties.Get_Clone();

            return (oClone);
        }

        #endregion
    }
	
	public class CS_DataViewerBook
	{
		#region Public members
		
		#region Saved members
		
		public List<CS_DataViewerPage> Pages;
		
		#endregion
		
		#region Unsaved members
		
		public bool bModified;
		public string FilePath;
		
		#endregion
		
		#endregion
		
		public CS_DataViewerBook()
		{
			Pages = new List<CS_DataViewerPage>();
			
			bModified = false;
			FilePath = "";
		}
		
		#region Public methodes
		
		#region ViewerBook file management
		
		public void Write_BookFile(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				XmlDocument oXDoc = new XmlDocument();
				
				XmlElement xBook = oXDoc.CreateElement("DataViewerBook");
				oXDoc.AppendChild(xBook);
				
					XmlElement xViewerPages = oXDoc.CreateElement("ViewerPages");
					xBook.AppendChild(xViewerPages);
					
						foreach (CS_DataViewerPage oPage in Pages)
						{
							XmlElement xPage = oXDoc.CreateElement("DataViewerPage");
							xViewerPages.AppendChild(xPage);
							
							XmlAttribute xAtrPageName = oXDoc.CreateAttribute("Name");
							xAtrPageName.Value = oPage.Name;
							xPage.Attributes.Append(xAtrPageName);
							
							XmlAttribute xAtrPageKey = oXDoc.CreateAttribute("KeyId");
							xAtrPageKey.Value = oPage.KeyId.ToString();
							xPage.Attributes.Append(xAtrPageKey);
							
								XmlElement xWindowConfig = oPage.GraphicProperties.Create_PropertiesXmlNode(oXDoc, "GraphWindowProperties");
								if (!(xWindowConfig ==  null)) xPage.AppendChild(xWindowConfig);
						}
				
				oXDoc.Save(fPath);
				FilePath = fPath;
				bModified = false;
			}
		}
		
		public bool Read_BookFile(string fPath)
		{
			if (!(fPath.Equals("")))
			{
				try
				{
					Pages = new List<CS_DataViewerPage>();
					
					XmlDocument oXDoc = new XmlDocument();
					oXDoc.Load(fPath);
					
					XmlNode xBook = oXDoc.SelectSingleNode("DataViewerBook");
					
						XmlNode xViewerPages = xBook.SelectSingleNode("ViewerPages");
						
							foreach (XmlNode xPage in xViewerPages.ChildNodes)
							{
								CS_DataViewerPage oPage = new CS_DataViewerPage();
								
								oPage.Name = xPage.Attributes["Name"].Value;
								oPage.KeyId = int.Parse(xPage.Attributes["KeyId"].Value);
								
									XmlNode xConfig = xPage.SelectSingleNode("GraphWindowProperties");
									
									if (!(oPage.GraphicProperties.Read_PropertiesXmlNode(xConfig)))
									{
										return(false);
									}
								
								Pages.Add(oPage);
							}
					
					FilePath = fPath;
					bModified = false;
				}
				catch
				{
					return(false);
				}
			}
			
			return(true);
		}
		
		#endregion
		
		#region ViewerPages functions
		
		public CS_DataViewerPage Get_DataViewerPage(int PageKeyId)
		{
			foreach (CS_DataViewerPage oPage in Pages)
			{
				if (oPage.KeyId == PageKeyId)
				{
					return(oPage);
				}
			}
			
			return(null);
		}

        public bool DataViewerPageExists(string PageName)
        {
            foreach (CS_DataViewerPage oPage in Pages)
            {
                if (oPage.Name.Equals(PageName))
                {
                    return (true);
                }
            }

            return (false);
        }

		#endregion
		
		#endregion
	}
}
