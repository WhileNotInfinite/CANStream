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
            LoggingMode = ChannelLoggingMode.DefaultFrequency;
            LoggingFrequency = 0;
        }
    }

    #endregion

    /// <summary>
    /// Record logging configuration class
    /// </summary>
    public class CS_RecordLoggingConfiguration
    {
        #region Public members
        #endregion

        #region Private members

        /// <summary>
        /// List of LoggingChannelConfiguration structures of the current logging configuration class
        /// </summary>
        private List<LoggingChannelConfiguration> LoggingChannels;

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
            LoggingChannels = new List<LoggingChannelConfiguration>();
            LoggingConfigPath = "";
        }

        #region Public methodes

        /// <summary>
        /// Add a LoggingChannelConfiguration object to the logging channel configuration list of the current CS_RecordLoggingConfiguration object
        /// </summary>
        /// <param name="Channel">LoggingChannelConfiguration object to be added</param>
        /// <returns>Channel addition no error flag: True = No Error / False = Error</returns>
        public bool Add_LoggingChannel(LoggingChannelConfiguration Channel)
        {
            if(!(Channel.Name.Equals("")))
            {
                LoggingChannels.Add(Channel);
                return (true);
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
            foreach (LoggingChannelConfiguration oChan in LoggingChannels)
            {
                if(oChan.Name.Equals(ChannelName))
                {
                    return (oChan);
                }
            }

            return (null);
        }

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

                XmlElement xChannels = oXDoc.CreateElement("LoggingChannels");
                xConfig.AppendChild(xChannels);

                foreach(LoggingChannelConfiguration oChannel in LoggingChannels)
                {
                    XmlElement xProp;

                    XmlElement xChan = oXDoc.CreateElement("ChannelConfiguration");

                    XmlAttribute xAtrName = oXDoc.CreateAttribute("Name");
                    xAtrName.Value = oChannel.Name;
                    xChan.Attributes.Append(xAtrName);

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
                XmlDocument oXDoc = new XmlDocument();
                oXDoc.Load(FilePath);

                XmlNode xConfig = oXDoc.SelectSingleNode("RecordLoggingConfigruation");
                XmlNode xChannels = xConfig.SelectSingleNode("LoggingChannels");

                LoggingChannels = new List<LoggingChannelConfiguration>();

                foreach (XmlNode xChan in xChannels.ChildNodes)
                {
                    XmlNode xProp;

                    LoggingChannelConfiguration oChannel = new LoggingChannelConfiguration();

                    oChannel.Name = xChan.Attributes["Name"].Value;

                    xProp = xChan.SelectSingleNode("LoggingMode");
                    oChannel.LoggingMode = (ChannelLoggingMode)(Enum.Parse(typeof(ChannelLoggingMode), xProp.InnerText));

                    xProp = xChan.SelectSingleNode("LoggingFrequency");
                    oChannel.LoggingFrequency = double.Parse(xProp.InnerText);

                    LoggingChannels.Add(oChannel);
                }

                return (true);
            }
            catch
            {
                return (false);
            }
        }

        #endregion
    }
}
