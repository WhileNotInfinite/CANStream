using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CANStream
{
    #region Public enums

    /// <summary>
    /// Enumeration of logging mode for a particular channel
    /// </summary>
    public enum ChannelLoggingMode
    {
        DefaultFrequency = 0,   /// <summary>Logging frequency is the same as PCAN Trace file</summary>
        CustomFrequency = 1,    /// <summary>Logging frequency is defined by the user</summary>
        NotLogged = 2,          /// <summary>Channel is not logged and won't appear in the record data file</summary>
    }

    #endregion

    #region Public sub class

    /// <summary>
    /// Record data file channel logging configuration class
    /// </summary>
    public class LoggingChannelConfiguration
    {
        #region Public properties

        /// <summary>Name of the logging channel</summary>
        public string Name { get; set; }

        /// <summary>
        /// Full path of the current LoggingChannelConfiguration within the group hierarchy
        /// </summary>
        public string Path { get; set; }

        /// <summary>Logging mode of the logging channel</summary>
        public ChannelLoggingMode LoggingMode { get; set; }

        /// <summary>Logging frequency of the logging channel</summary>
        public double LoggingFrequency { get; set; }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoggingChannelConfiguration()
        {
            Name = "";
            Path = "";
            LoggingMode = ChannelLoggingMode.DefaultFrequency;
            LoggingFrequency = 0;
        }
    }

    /// <summary>
    /// Channel logging configuration group class
    /// </summary>
    public class LoggingChannelGroup
    {
        #region Public properties

        /// <summary>
        /// Group name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Full path of the current LoggingChannelGroup within the group hierarchy
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Logging channels contained in the current group
        /// </summary>
        public List<LoggingChannelConfiguration> LoggingChannels { get; set; }

        /// <summary>
        /// Sub logging channel groups of the current group
        /// </summary>
        public List<LoggingChannelGroup> SubGroups { get; set; }

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoggingChannelGroup()
        {
            Name = "";
            FullPath = "";
            LoggingChannels = new List<LoggingChannelConfiguration>();
            SubGroups = new List<LoggingChannelGroup>();
        }

        #region Public methodes

        /// <summary>
        /// Returns the first level child sub group corresponding to the group name given as argument
        /// </summary>
        /// <param name="GroupName">Name of the group to retrieve</param>
        /// <returns>LoggingChannelGroup object corresponding to the group name given as argument</returns>
        /// <remarks>Returns null if the group is not found</remarks>
        public LoggingChannelGroup Get_SubGroup(string GroupName)
        {
            foreach (LoggingChannelGroup oGroup in this.SubGroups)
            {
                if(oGroup.Name.Equals(GroupName))
                {
                    return (oGroup);
                }
            }

            return (null);
        }

        /// <summary>
        /// Return the LoggingChannelGroup object corresponding to the group path given as argument
        /// </summary>
        /// <param name="GroupPath">Path of the LoggingChannelGroup object to retrive</param>
        /// <returns>LoggingChannelGroup object corresponding to the group path given as argument</returns>
        /// <remarks>Return null if the group is not found</remarks>
        public LoggingChannelGroup Get_GroupAtPath(string GroupPath)
        {
            string[] GroupNames = GroupPath.Split('\\');
            LoggingChannelGroup oCurrentGroup = this;

            if (GroupNames.Length > 0)
            {
                for (int i = 0; i < GroupNames.Length; i++)
                {
                    LoggingChannelGroup oSubGroup = oCurrentGroup.Get_SubGroup(GroupNames[i]);

                    if (!(oSubGroup == null))
                    {
                        if (i < GroupNames.Length - 1)
                        {
                            oCurrentGroup = oSubGroup;
                        }
                        else
                        {
                            return (oSubGroup);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return (null);
        }

        /// <summary>
        /// Return the LoggingChannelGroup object corresponding to the name given as argument looking recursively into sub groups hierarchy of the current group
        /// </summary>
        /// <param name="GroupName">Name of the group to retrieve</param>
        /// <returns>LoggingChannelGroup object corresponding to the name given as argument</returns>
        /// <remarks>Returns null if the group is not found</remarks>
        public LoggingChannelGroup Get_TreeSubGroup(string GroupName)
        {
            LoggingChannelGroup oGroup = Get_SubGroup(GroupName);

            if (oGroup == null)
            {
                foreach(LoggingChannelGroup oSubGroup in SubGroups)
                {
                    oGroup = oSubGroup.Get_TreeSubGroup(GroupName);
                    if (!(oGroup == null)) return (oGroup);
                }
            }
            else
            {
                return (oGroup);
            }

            return (null);
        }

        /// <summary>
        /// Returns the logging channel object corresponding to the name given as argument within logging channels of the curent group
        /// </summary>
        /// <param name="ChannelName">Name of the logging channel object to retrieve</param>
        /// <returns>Logging channel object corresponding to the name given as argument</returns>
        /// <remarks>Return null if the Logging channel is not found</remarks>
        public LoggingChannelConfiguration Get_LoggingChannel(string ChannelName)
        {
            foreach (LoggingChannelConfiguration oChannel in LoggingChannels)
            {
                if (oChannel.Name.Equals(ChannelName))
                {
                    return (oChannel);
                }
            }

            return (null);
        }

        /// <summary>
        /// Returns the logging channel object corresponding to the name given as argument looking recursively into sub groups hierarchy of the current group
        /// </summary>
        /// <param name="ChannelName">Name of the logging channel object to retrieve</param>
        /// <returns>Logging channel object corresponding to the name given as argument</returns>
        /// <remarks>Return null if the Logging channel is not found</remarks>
        public LoggingChannelConfiguration Get_TreeLoggingChannel(string ChannelName)
        {
            LoggingChannelConfiguration oChannel = this.Get_LoggingChannel(ChannelName);

            if (oChannel == null)
            {
                foreach (LoggingChannelGroup oSubGroup in this.SubGroups)
                {
                    oChannel = oSubGroup.Get_TreeLoggingChannel(ChannelName);

                    if (!(oChannel == null))
                    {
                        return (oChannel);
                    }
                }
            }
            else
            {
                return (oChannel);
            }

            return (null);
        }

        /// <summary>
        /// Returns all pathes of all sub groups looking recursively into sub groups hierarchy of the current group
        /// </summary>
        /// <returns>Pathes of sub groups hierarchy</returns>
        public List<string> Get_FullGroupsPathesList()
        {
            List<string> Pathes = new List<string>();

            foreach(LoggingChannelGroup oSubGroup in this.SubGroups)
            {
                Pathes.Add(oSubGroup.FullPath);

                List<string> SubGroupPathes = oSubGroup.Get_FullGroupsPathesList();

                if(SubGroupPathes.Count>0)
                {
                    Pathes.AddRange(SubGroupPathes);
                }
            }

            return (Pathes);
        }

        /// <summary>
        /// Returns all LoggingChannel objects of the current group including all sub groups looking recursively into sub groups hierarchy of the current group
        /// </summary>
        /// <returns>LoggingChannel objects list of the group hierarchy</returns>
        public List<LoggingChannelConfiguration> Get_FullChannelHierarchy()
        {
            List<LoggingChannelConfiguration> oChannelList = new List<LoggingChannelConfiguration>();

            oChannelList.AddRange(this.LoggingChannels);

            foreach (LoggingChannelGroup oSubGroup in this.SubGroups)
            {
                List<LoggingChannelConfiguration> oSubGroupChannels = oSubGroup.Get_FullChannelHierarchy();

                if (oSubGroupChannels.Count > 0)
                {
                    oChannelList.AddRange(oSubGroupChannels);
                }
            }

            return (oChannelList);
        }

        /// <summary>
        /// Returns the LoggingChannel object count within the sub group hierarchy of the current group
        /// </summary>
        /// <returns>LoggingChannel object count</returns>
        public int Get_HierarchyLoggingChannelsCount()
        {
            int ChannelsCount = 0;

            ChannelsCount += this.LoggingChannels.Count;

            foreach(LoggingChannelGroup oSubGroup in this.SubGroups)
            {
                ChannelsCount += oSubGroup.Get_HierarchyLoggingChannelsCount();
            }

            return (ChannelsCount);
        }

        #endregion
    }

    #endregion

    /// <summary>
    /// Record logging configuration class
    /// </summary>
    public class CS_RecordLoggingConfiguration
    {
        #region Public porperties

        public int ChannelsCount
        {
            get
            {
                return (oRootGroup.Get_HierarchyLoggingChannelsCount());
            }
        }

        #endregion

        #region Private members

        /// <summary>
        /// Root group of the current CS_RecordLoggingConfiguration object
        /// </summary>
        private LoggingChannelGroup oRootGroup;

        /// <summary>
        /// File path of the current CS_RecordLoggingConfiguration class storage file
        /// </summary>
        private string LoggingConfigPath;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public CS_RecordLoggingConfiguration()
        {
            LoggingConfigPath = "";

            oRootGroup = new LoggingChannelGroup();
            oRootGroup.Name = "Root";
            oRootGroup.FullPath = "Root";
        }

        #region Public methodes

        #region Logging channels management

        /// <summary>
        /// Add a LoggingChannelConfiguration object to the root group of the current RecordLoggingConfiguration object
        /// </summary>
        /// <param name="Channel">LoggingChannelConfiguration object to be added</param>
        /// <returns>Channel addition no error flag: True = No Error / False = Error</returns>
        public bool Add_LoggingChannel(LoggingChannelConfiguration Channel)
        {
            return (Add_LoggingChannel(Channel, oRootGroup));
        }

        /// <summary>
        /// Add a LoggingChannelConfiguration object to the group path given as argumennt of the current RecordLoggingConfiguration object
        /// </summary>
        /// <param name="Channel">LoggingChannelConfiguration object to be added</param>
        /// <param name="GroupPath">Path of LoggingChannelGroup in which the channel will be added</param>
        /// <returns>Channel addition no error flag: True = No Error / False = Error</returns>
        public bool Add_LoggingChannel(LoggingChannelConfiguration Channel, string GroupPath)
        {
            LoggingChannelGroup oSubGroup = oRootGroup.Get_GroupAtPath(GroupPath);

            if (!(oSubGroup == null))
            {
                return (Add_LoggingChannel(Channel, oSubGroup));
            }

            return (false);
        }

        /// <summary>
        /// Add a LoggingChannelConfiguration object to the LoggingChannelGroup object given as argument of the current RecordLoggingConfiguration object
        /// </summary>
        /// <param name="Channel">LoggingChannelConfiguration object to be added</param>
        /// <param name="DestGoup">LoggingChannelGroup object reference in which the channel will be added</param>
        /// <returns>Channel addition no error flag: True = No Error / False = Error</returns>
        public bool Add_LoggingChannel(LoggingChannelConfiguration Channel, LoggingChannelGroup DestGoup)
        {
            if (!(Channel == null || DestGoup == null))
            {
                if (DestGoup.Get_LoggingChannel(Channel.Name) == null)
                {
                    Channel.Path = DestGoup.FullPath;
                    DestGoup.LoggingChannels.Add(Channel);

                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// Returns the LoggingChannelConfiguration object from the logging channel configuration list corresponding to the name given as argument
        /// </summary>
        /// <param name="ChannelName">Name of the LoggingChannelConfiguration object to search</param>
        /// <returns>LoggingChannelConfiguration object corresponding to the name given as argument</returns>
        /// <remarks>Returns null if the LoggingChannelConfiguration object is not found</remarks>
        public LoggingChannelConfiguration Get_LoggingChannel(string ChannelName)
        {
            return (oRootGroup.Get_TreeLoggingChannel(ChannelName));
        }

        #endregion

        #region LoggingChannels groups management

        /// <summary>
        /// Add a logging channel group to the root group of the current RecordLoggingConfiguration object
        /// </summary>
        /// <param name="GroupName">Name of the group to add</param>
        /// <returns>>Group addition no error flag: True = No Error / False = Error</returns>
        public bool Add_LoggingChannelGroup(string GroupName)
        {
            return (Add_LoggingChannelGroup(GroupName, oRootGroup));
        }

        /// <summary>
        /// Add a logging channel group to the group path given as argument
        /// </summary>
        /// <param name="GroupName">Name of the group to add</param>
        /// <param name="ParentGroupPath">Path of group in which the new group will be created</param>
        /// <returns>Group addition no error flag: True = No Error / False = Error</returns>
        public bool Add_LoggingChannelGroup(string GroupName, string ParentGroupPath)
        {
            LoggingChannelGroup oParentGroup = oRootGroup.Get_GroupAtPath(ParentGroupPath);

            if (!(oParentGroup == null))
            {
                return (Add_LoggingChannelGroup(GroupName, oParentGroup));
            }

            return (false);
        }

        /// <summary>
        /// Add a logging channel group to the group object reference given as argument
        /// </summary>
        /// <param name="GroupName">Name of the group to add</param>
        /// <param name="ParentGroup">Group object reference in which the new group will be created</param>
        /// <returns>Group addition no error flag: True = No Error / False = Error</returns>
        public bool Add_LoggingChannelGroup(string GroupName, LoggingChannelGroup ParentGroup)
        {
            if (!(GroupName.Equals("") || ParentGroup == null))
            {
                if (ParentGroup.Get_SubGroup(GroupName) == null)
                {
                    LoggingChannelGroup oNewGroup = new LoggingChannelGroup();
                    oNewGroup.Name = GroupName;
                    oNewGroup.FullPath = ParentGroup.FullPath + "\\" + GroupName;

                    ParentGroup.SubGroups.Add(oNewGroup);
                    return (true);
                }
            }

            return (false);
        }

        /// <summary>
        /// Returns the LoggingChannelGroup object from the logging channel group hierarchy corresponding to the name given as argument
        /// </summary>
        /// <param name="GroupName">Name of the group to retrieve</param>
        /// <returns>Group corresponding to the name given as argument</returns>
        /// /// <remarks>Returns null if the group is not found</remarks>
        public LoggingChannelGroup Get_LoggingChannelGroup(string GroupName)
        {
            return (oRootGroup.Get_TreeSubGroup(GroupName));
        }

        #endregion

        #region CS_RecordLoggingConfiguration file management

        /// <summary>
        /// Write the current CS_RecordLoggingConfiguration into the default filepath
        /// </summary>
        /// <returns>No error flag:True = No Error / False = Error</returns>
        public bool Write_LoggingConfigurationFile()
        {
            if(!(LoggingConfigPath.Equals("")))
            {
                return (Write_LoggingConfigurationFile(LoggingConfigPath));
            }

            return (false);
        }

        /// <summary>
        /// Write the current CS_RecordLoggingConfiguration into the filepath given as argument
        /// </summary>
        /// <param name="FilePath">Path of the file to be written</param>
        /// <returns>No error flag:True = No Error / False = Error</returns>
        public bool Write_LoggingConfigurationFile(string FilePath)
        {
            if(!(FilePath.Equals("")))
            {
                XmlDocument oXDoc = new XmlDocument();

                XmlElement xConfig = oXDoc.CreateElement("RecordLoggingConfigruation");
                oXDoc.AppendChild(xConfig);

                XmlElement xRootGroup = oXDoc.CreateElement("LoggingChannels_RootGroup");
                xConfig.AppendChild(xRootGroup);

                List<string> SubGroupHierarchy = oRootGroup.Get_FullGroupsPathesList();
                foreach(string SubGroupPath in SubGroupHierarchy)
                {
                    XmlElement xGroup = oXDoc.CreateElement("GroupPath");
                    xGroup.InnerText = SubGroupPath;
                    xRootGroup.AppendChild(xGroup);
                }

                XmlElement xChannels = oXDoc.CreateElement("LoggingChannels");
                xConfig.AppendChild(xChannels);

                List<LoggingChannelConfiguration> LoggingChannelHierarchy = oRootGroup.Get_FullChannelHierarchy();
                foreach(LoggingChannelConfiguration oChannel in LoggingChannelHierarchy)
                {
                    XmlElement xProp;

                    XmlElement xChan = oXDoc.CreateElement("ChannelConfiguration");

                    XmlAttribute xAtrName = oXDoc.CreateAttribute("Name");
                    xAtrName.Value = oChannel.Name;
                    xChan.Attributes.Append(xAtrName);

                    xProp = oXDoc.CreateElement("GroupPath");
                    xProp.InnerText = oChannel.Path;
                    xChan.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("LoggingMode");
                    xProp.InnerText = oChannel.LoggingMode.ToString();
                    xChan.AppendChild(xProp);

                    xProp = oXDoc.CreateElement("LoggingFrequency");
                    xProp.InnerText = oChannel.LoggingFrequency.ToString();
                    xChan.AppendChild(xProp);

                    xChannels.AppendChild(xChan);
                }

                oXDoc.Save(FilePath);
                return (true);
            }

            return (false);
        }

        /// <summary>
        /// Read a CS_RecordLoggingConfiguration object into the specified file path
        /// </summary>
        /// <param name="FilePath">Path of the file to read</param>
        /// <returns>No error flag:True = No Error / False = Error</returns>
        public bool Read_LoggingConfigurationFile(string FilePath)
        {
            try
            {
                oRootGroup.LoggingChannels.Clear();
                oRootGroup.SubGroups.Clear();

                XmlDocument oXDoc = new XmlDocument();
                oXDoc.Load(FilePath);

                XmlNode xConfig = oXDoc.SelectSingleNode("RecordLoggingConfigruation");

                XmlNode xGroups = xConfig.SelectSingleNode("LoggingChannels_RootGroup");
                foreach(XmlNode xSubGroup in xGroups.ChildNodes)
                {
                    string[] GroupParents = xSubGroup.InnerText.Split('\\');

                    string GroupName = GroupParents.Last();
                    string ParentPath = "";

                    for (int i = 0; i < GroupParents.Length - 2; i++)
                    {
                        ParentPath += GroupParents[i];
                        if (i < GroupParents.Length - 2) ParentPath += "\\";
                    }

                    if(!(GroupName.Equals("") || ParentPath.Equals("")))
                    {
                        Add_LoggingChannelGroup(GroupName, ParentPath);
                    }

                }

                XmlNode xChannels = xConfig.SelectSingleNode("LoggingChannels");
                foreach (XmlNode xChan in xChannels.ChildNodes)
                {
                    XmlNode xProp;

                    LoggingChannelConfiguration oChannel = new LoggingChannelConfiguration();

                    oChannel.Name = xChan.Attributes["Name"].Value;

                    xProp = xChan.SelectSingleNode("LoggingMode");
                    oChannel.LoggingMode = (ChannelLoggingMode)(Enum.Parse(typeof(ChannelLoggingMode), xProp.InnerText));

                    xProp = xChan.SelectSingleNode("LoggingFrequency");
                    oChannel.LoggingFrequency = double.Parse(xProp.InnerText);

                    xProp = xChan.SelectSingleNode("GroupPath");

                    if(!(xProp.InnerText.Equals("")))
                    {
                        Add_LoggingChannel(oChannel, xProp.InnerText);
                    }
                }

                return (true);
            }
            catch
            {
                return (false);
            }
        }

        #endregion

        #endregion
    }
}
