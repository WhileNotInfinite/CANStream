using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace CANStream
{
    #region Enums declarations

    /// <summary>
    /// Signal value format enumeration
    /// </summary>
    public enum SignalValueFormat
    {
        /// <summary>Signal value format autmatic</summary>
    	Auto = 0,

        /// <summary>Signal value format decimal</summary>
        Decimal = 1,

        /// <summary>Signal value format hexadecimal</summary>
        Hexadecimal = 2,

        /// <summary>Signal value format binary</summary>
        Binary = 3,

        /// <summary>Signal value format enumeration</summary>
        Enum = 4,
    }

    /// <summary>
    /// Signal alarm status enumeration
    /// </summary>
    public enum SignalAlarmStatus
    {
        /// <summary>No alarm</summary>
        None = 0,

        /// <summary>Value exceeding the min warning limit</summary>
        WarningMin = 1,

        /// <summary>Value exceeding the max warning limit</summary>
        WarningMax = 2,

        /// <summary>Value exceeding the min alarm limit</summary>
        AlarmMin = 3,

        /// <summary>Value exceeding the max alarm limit</summary>
        AlarmMax = 4,
    }

    #endregion

    #region Public structures declaration

    /// <summary>
    /// Signal enumeration value structure
    /// </summary>
    [Serializable]
    public struct EnumerationValue
    {
        /// <summary>Enumeration value</summary> 
        public int Value;

        /// <summary>Enumeration text</summary> 
        public string Text;
    }

    /// <summary>
    /// Signal alarm value structure
    /// </summary>
    [Serializable]
    public struct SignalAlarmValue
    {
        /// <summary>Alarm value enabling flag</summary>
        public bool Enabled;

        /// <summary>Alarm threshold value</summary>
        public double Value;

        /// <summary>Value font color when value threshold is exceeded</summary>
        public System.Drawing.Color ForeColor;

        /// <summary>Value back color when value threshold is exceeded</summary>
        public System.Drawing.Color BackColor;
    }

    #endregion

    #region SignalFormatProperties class definition

    /// <summary>
    /// Signal value format class
    /// </summary>
    [Serializable]
    public class SignalFormatProperties
    {
        #region Private constants

        private const int AutoDecNumbers = 3;

        #endregion

        #region Public members

        /// <summary>Value format type</summary> 
        public SignalValueFormat FormatType;

        /// <summary>Number of decimals digits for 'decimal' format</summary> 
        public int Decimals;

        /// <summary>Value format enumeration</summary>
        public List<EnumerationValue> Enums;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public SignalFormatProperties()
        {
            FormatType = SignalValueFormat.Auto;
            Decimals = 2;
            Enums = new List<EnumerationValue>();
        }

        #region Private methodes

        private string GetEnumText(int EnumValue)
        {
            foreach (EnumerationValue sEnum in Enums)
            {
                if (sEnum.Value == EnumValue)
                {
                    return (sEnum.Text);
                }
            }

            return ("<?>");
        }

        private int GetEnumValue(string EnumText)
        {
            foreach (EnumerationValue sEnum in Enums)
            {
                if (sEnum.Text.Equals(EnumText))
                {
                    return (sEnum.Value);
                }
            }

            return (0);
        }

        #endregion

        #region Public methodes

        /// <summary>
        /// Returns a clone of the current SignalFormatProperties object
        /// </summary>
        /// <returns>Clone of the current SignalFormatProperties object</returns>
        public SignalFormatProperties Get_Clone()
        {
            SignalFormatProperties oClone = new SignalFormatProperties();

            oClone.FormatType = this.FormatType;
            oClone.Decimals = this.Decimals;

            oClone.Enums = new List<EnumerationValue>();
            foreach (EnumerationValue sEnum in this.Enums)
            {
                oClone.Enums.Add(sEnum);
            }

            return (oClone);
        }

        /// <summary>
        /// Returns the current decoded value of the signal formated according to its value format properties
        /// </summary>
        /// <param name="ValIn"> Value to format</param>
        /// <returns>Current decoded value of the signal formated according to its value format properties</returns>
        public string GetSignalFormatedValue(double ValIn)
        {
            string sValue = "";

            switch (FormatType)
            {
                case SignalValueFormat.Auto:

                    sValue = Math.Round(ValIn, AutoDecNumbers).ToString();
                    break;

                case SignalValueFormat.Binary:

                    sValue = Convert.ToString((int)ValIn, 2);
                    break;

                case SignalValueFormat.Decimal:

                    sValue = Math.Round(ValIn, Decimals).ToString();
                    break;

                case SignalValueFormat.Enum:

                    sValue = GetEnumText((int)ValIn);
                    break;

                case SignalValueFormat.Hexadecimal:

                    sValue = "0x" + ((int)ValIn).ToString("X");
                    break;
            }

            return (sValue);
        }

        /// <summary>
        /// Returns the numerical decoded value of the signal from the formated value according to is value format properties  
        /// </summary>
        /// <param name="FormatedValue">Formated decoded value of the paramter</param>
        /// <returns>Numerical decoded value of the signal</returns>
        public double SetSignalFormatedValue(string FormatedValue)
        {
            double DecodValue = double.NaN;

            try
            {
                switch (FormatType)
                {
                    case SignalValueFormat.Auto:

                        DecodValue = Convert.ToDouble(FormatedValue);
                        break;

                    case SignalValueFormat.Binary:

                        DecodValue = (double)(Convert.ToInt32(FormatedValue, 2));
                        break;

                    case SignalValueFormat.Decimal:

                        DecodValue = Convert.ToDouble(FormatedValue);
                        break;

                    case SignalValueFormat.Enum:

                        DecodValue = (double)GetEnumValue(FormatedValue);
                        break;

                    case SignalValueFormat.Hexadecimal:

                        if (FormatedValue.StartsWith("0x")) //Remove '0x' prefix
                        {
                            FormatedValue = FormatedValue.Substring(2, FormatedValue.Length - 2);
                        }

                        DecodValue = (double)(int.Parse(FormatedValue, System.Globalization.NumberStyles.HexNumber));
                        break;
                }
            }
            catch
            {
                //Nothing
            }

            return (DecodValue);
        }

        /// <summary>
        /// Return all enumeration text into an array of string
        /// </summary>
        /// <returns>All enumeration text</returns>
        public string[] GetEnumerationNames()
        {
            string[] Names = null;

            if (Enums.Count > 0)
            {
                Names = new string[Enums.Count];

                for (int i = 0; i < Enums.Count; i++)
                {
                    Names[i] = Enums[i].Text;
                }
            }

            return (Names);
        }

        /// <summary>
        /// Return the XML node of the current SignalFormatProperties object
        /// </summary>
        /// <param name="oXmlDoc">XmlDocument class reference creating the node</param>
        /// <returns>XML node of the current SignalFormatProperties</returns>
        public XmlElement GetSignalFormatXmlNode(XmlDocument oXmlDoc, string NodeName)
        {
            XmlElement xSignalFormat = oXmlDoc.CreateElement(NodeName);

            XmlElement xFormatType = oXmlDoc.CreateElement("FormatType");
            xFormatType.InnerText = FormatType.ToString();
            xSignalFormat.AppendChild(xFormatType);

            XmlElement xFormatDec = oXmlDoc.CreateElement("FormatDecimals");
            xFormatDec.InnerText = Decimals.ToString();
            xSignalFormat.AppendChild(xFormatDec);

            if (Enums.Count > 0)
            {
                XmlElement xFormatEnums = oXmlDoc.CreateElement("FormatEnums");
                xSignalFormat.AppendChild(xFormatEnums);

                foreach (EnumerationValue sEnum in Enums)
                {
                    XmlElement xEnum = oXmlDoc.CreateElement("Enumeration");
                    xFormatEnums.AppendChild(xEnum);

                    XmlElement xEnumVal = oXmlDoc.CreateElement("EnumValue");
                    xEnumVal.InnerText = sEnum.Value.ToString();
                    xEnum.AppendChild(xEnumVal);

                    XmlElement xEnumText = oXmlDoc.CreateElement("EnumText");
                    xEnumText.InnerText = sEnum.Text;
                    xEnum.AppendChild(xEnumText);
                }
            }

            return (xSignalFormat);
        }

        /// <summary>
        /// Read the SignalFormatProperties XML node and set the current object
        /// </summary>
        /// <param name="xSignalFormat">XML Node to read</param>
        /// <returns>Read error flag: True = No Error / False = Error</returns>
        public bool ReadSignalFormatXmlNode(XmlNode xSignalFormat)
        {
            XmlNode xFormatType = xSignalFormat.SelectSingleNode("FormatType");
            if (!(xFormatType == null))
            {
                SignalValueFormat eFormatType;
                if (Enum.TryParse(xFormatType.InnerText, out eFormatType))
                {
                    FormatType = eFormatType;
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }

            XmlNode xFormatDec = xSignalFormat.SelectSingleNode("FormatDecimals");
            if (!(xFormatDec == null))
            {
                int nDec;
                if (int.TryParse(xFormatDec.InnerText, out nDec))
                {
                    Decimals = nDec;
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }

            XmlNode xFormatEnums = xSignalFormat.SelectSingleNode("FormatEnums");
            if (!(xFormatEnums == null))
            {
                Enums = new List<EnumerationValue>();

                foreach (XmlNode xEnum in xFormatEnums.ChildNodes)
                {
                    EnumerationValue sEnum = new EnumerationValue();

                    XmlNode xEnumVal = xEnum.SelectSingleNode("EnumValue");
                    if (!(xEnumVal == null))
                    {
                        int eVal;
                        if (int.TryParse(xEnumVal.InnerText, out eVal))
                        {
                            sEnum.Value = eVal;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    XmlNode xEnumText = xEnum.SelectSingleNode("EnumText");
                    if (!(xEnumText == null))
                    {
                        sEnum.Text = xEnumText.InnerText;
                    }
                    else
                    {
                        return (false);
                    }

                    Enums.Add(sEnum);
                }
            }
            else
            {
                //Enumeration list may not exist if parameter isn't an enum
            }

            return (true);
        }

        #endregion
    }

    #endregion

    #region SignalAlarmsProperties class definition

    /// <summary>
    /// Signal alarm values class
    /// </summary>
    [Serializable]
    public class SignalAlarmsProperties
    {
        #region Public members

        /// <summary>Signal alarms enabling flag</summary>
        public bool Enabled;

        /// <summary>Signal lower warning limit</summary>
        public SignalAlarmValue WarningLimitMin;

        /// <summary>Signal upper warning limit</summary>
        public SignalAlarmValue WarningLimitMax;

        /// <summary>Signal lower alarm limit</summary>
        public SignalAlarmValue AlarmLimitMin;

        /// <summary>Signal upper alarm limit</summary>
        public SignalAlarmValue AlarmLimitMax;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public SignalAlarmsProperties()
        {
            Enabled = false;

            WarningLimitMin = new SignalAlarmValue();
            WarningLimitMin.Enabled = false;
            WarningLimitMin.Value = 0;
            WarningLimitMin.BackColor = System.Drawing.SystemColors.Window;
            WarningLimitMin.ForeColor = System.Drawing.Color.Orange;

            WarningLimitMax = new SignalAlarmValue();
            WarningLimitMax.Enabled = false;
            WarningLimitMax.Value = 0;
            WarningLimitMax.BackColor = System.Drawing.SystemColors.Window;
            WarningLimitMax.ForeColor = System.Drawing.Color.Orange;

            AlarmLimitMin = new SignalAlarmValue();
            AlarmLimitMin.Enabled = false;
            AlarmLimitMin.Value = 0;
            AlarmLimitMin.BackColor = System.Drawing.SystemColors.Window;
            AlarmLimitMin.ForeColor = System.Drawing.Color.Red;

            AlarmLimitMax = new SignalAlarmValue();
            AlarmLimitMax.Enabled = false;
            AlarmLimitMax.Value = 0;
            AlarmLimitMax.BackColor = System.Drawing.SystemColors.Window;
            AlarmLimitMax.ForeColor = System.Drawing.Color.Red;
        }

        #region Public methodes

        /// <summary>
        /// Returns a clone of the current SignalAlarmsProperties object
        /// </summary>
        /// <returns>Clone of the current SignalAlarmsProperties object</returns>
        public SignalAlarmsProperties Get_Clone()
        {
            SignalAlarmsProperties oClone = new SignalAlarmsProperties();

            oClone.Enabled = this.Enabled;

            oClone.WarningLimitMin.Enabled = this.WarningLimitMin.Enabled;
            oClone.WarningLimitMin.Value = this.WarningLimitMin.Value;
            oClone.WarningLimitMin.BackColor = this.WarningLimitMin.BackColor;
            oClone.WarningLimitMin.ForeColor = this.WarningLimitMin.ForeColor;

            oClone.WarningLimitMax.Enabled = this.WarningLimitMax.Enabled;
            oClone.WarningLimitMax.Value = this.WarningLimitMax.Value;
            oClone.WarningLimitMax.BackColor = this.WarningLimitMax.BackColor;
            oClone.WarningLimitMax.ForeColor = this.WarningLimitMax.ForeColor;

            oClone.AlarmLimitMin.Enabled = this.AlarmLimitMin.Enabled;
            oClone.AlarmLimitMin.Value = this.AlarmLimitMin.Value;
            oClone.AlarmLimitMin.BackColor = this.AlarmLimitMin.BackColor;
            oClone.AlarmLimitMin.ForeColor = this.AlarmLimitMin.ForeColor;

            oClone.AlarmLimitMax.Enabled = this.AlarmLimitMax.Enabled;
            oClone.AlarmLimitMax.Value = this.AlarmLimitMax.Value;
            oClone.AlarmLimitMax.BackColor = this.AlarmLimitMax.BackColor;
            oClone.AlarmLimitMax.ForeColor = this.AlarmLimitMax.ForeColor;

            return (oClone);
        }

        /// <summary>
        /// Return the current signal alarm status
        /// </summary>
        /// <param name="ValIn">Current signal value</param>
        /// <returns>Current signal alarm status</returns>
        public SignalAlarmStatus ProcessAlarms(double ValIn)
        {
            if (Enabled)
            {
                if (AlarmLimitMin.Enabled && ValIn <= AlarmLimitMin.Value)
                {
                    return (SignalAlarmStatus.AlarmMin);
                }

                if (AlarmLimitMax.Enabled && ValIn >= AlarmLimitMax.Value)
                {
                    return (SignalAlarmStatus.AlarmMax);
                }

                if (WarningLimitMin.Enabled && ValIn <= WarningLimitMin.Value)
                {
                    return (SignalAlarmStatus.WarningMin);
                }

                if (WarningLimitMax.Enabled && ValIn >= WarningLimitMax.Value)
                {
                    return (SignalAlarmStatus.WarningMax);
                }
            }

            return (SignalAlarmStatus.None);
        }

        /// <summary>
        /// Return the alarm properties structure corresponding to the status given as argument
        /// </summary>
        /// <param name="eAlarm">Alarm status</param>
        /// <returns>Alarm properties structure corresponding to the status given as argument</returns>
        /// <remarks>Return null if status is 'None' or unknown</remarks>
        public Nullable<SignalAlarmValue> GetAlarmProperties(SignalAlarmStatus eAlarm)
        {
            switch (eAlarm)
            {
                case SignalAlarmStatus.WarningMin:

                    return (WarningLimitMin);

                case SignalAlarmStatus.WarningMax:

                    return (WarningLimitMax);

                case SignalAlarmStatus.AlarmMin:

                    return (AlarmLimitMin);

                case SignalAlarmStatus.AlarmMax:

                    return (AlarmLimitMax);
            }

            return (null);
        }

        /// <summary>
        /// Return the XML node of the current SignalAlarmsProperties object
        /// </summary>
        /// <param name="oXmlDoc">XmlDocument class reference creating the node</param>
        /// <returns>XML node of the current SignalAlarmsProperties</returns>
        public XmlElement GetSignalAlarmsXmlNode(XmlDocument oXmlDoc, string NodeName)
        {
            XmlElement xSignalAlarms = oXmlDoc.CreateElement(NodeName);

            XmlElement xAlarmsEnabled = oXmlDoc.CreateElement("AlarmsEnabled");
            xAlarmsEnabled.InnerText = Enabled.ToString();
            xSignalAlarms.AppendChild(xAlarmsEnabled);

            XmlElement xAlarmActive, xAlarmVal, xAlarmForeColor, xAlarmBackColor;

            XmlElement xWarningMin = oXmlDoc.CreateElement("WarningMin");
            xSignalAlarms.AppendChild(xWarningMin);

                xAlarmActive = oXmlDoc.CreateElement("AlarmActive");
                xAlarmActive.InnerText = WarningLimitMin.Enabled.ToString();
                xWarningMin.AppendChild(xAlarmActive);

                xAlarmVal = oXmlDoc.CreateElement("AlarmValue");
                xAlarmVal.InnerText = WarningLimitMin.Value.ToString();
                xWarningMin.AppendChild(xAlarmVal);

                xAlarmForeColor = oXmlDoc.CreateElement("AlarmForeColor");
                xAlarmForeColor.InnerText = WarningLimitMin.ForeColor.ToArgb().ToString();
                xWarningMin.AppendChild(xAlarmForeColor);

                xAlarmBackColor = oXmlDoc.CreateElement("AlarmBackColor");
                xAlarmBackColor.InnerText = WarningLimitMin.BackColor.ToArgb().ToString();
                xWarningMin.AppendChild(xAlarmBackColor);

            XmlElement xWarningMax = oXmlDoc.CreateElement("WarningMax");
            xSignalAlarms.AppendChild(xWarningMax);

                xAlarmActive = oXmlDoc.CreateElement("AlarmActive");
                xAlarmActive.InnerText = WarningLimitMax.Enabled.ToString();
                xWarningMax.AppendChild(xAlarmActive);

                xAlarmVal = oXmlDoc.CreateElement("AlarmValue");
                xAlarmVal.InnerText = WarningLimitMax.Value.ToString();
                xWarningMax.AppendChild(xAlarmVal);

                xAlarmForeColor = oXmlDoc.CreateElement("AlarmForeColor");
                xAlarmForeColor.InnerText = WarningLimitMax.ForeColor.ToArgb().ToString();
                xWarningMax.AppendChild(xAlarmForeColor);

                xAlarmBackColor = oXmlDoc.CreateElement("AlarmBackColor");
                xAlarmBackColor.InnerText = WarningLimitMax.BackColor.ToArgb().ToString();
                xWarningMax.AppendChild(xAlarmBackColor);

            XmlElement xAlarmMin = oXmlDoc.CreateElement("AlarmMin");
            xSignalAlarms.AppendChild(xAlarmMin);

                xAlarmActive = oXmlDoc.CreateElement("AlarmActive");
                xAlarmActive.InnerText = AlarmLimitMin.Enabled.ToString();
                xAlarmMin.AppendChild(xAlarmActive);

                xAlarmVal = oXmlDoc.CreateElement("AlarmValue");
                xAlarmVal.InnerText = AlarmLimitMin.Value.ToString();
                xAlarmMin.AppendChild(xAlarmVal);

                xAlarmForeColor = oXmlDoc.CreateElement("AlarmForeColor");
                xAlarmForeColor.InnerText = AlarmLimitMin.ForeColor.ToArgb().ToString();
                xAlarmMin.AppendChild(xAlarmForeColor);

                xAlarmBackColor = oXmlDoc.CreateElement("AlarmBackColor");
                xAlarmBackColor.InnerText = AlarmLimitMin.BackColor.ToArgb().ToString();
                xAlarmMin.AppendChild(xAlarmBackColor);

            XmlElement xAlarmMax = oXmlDoc.CreateElement("AlarmMax");
            xSignalAlarms.AppendChild(xAlarmMax);

                xAlarmActive = oXmlDoc.CreateElement("AlarmActive");
                xAlarmActive.InnerText = AlarmLimitMax.Enabled.ToString();
                xAlarmMax.AppendChild(xAlarmActive);

                xAlarmVal = oXmlDoc.CreateElement("AlarmValue");
                xAlarmVal.InnerText = AlarmLimitMax.Value.ToString();
                xAlarmMax.AppendChild(xAlarmVal);

                xAlarmForeColor = oXmlDoc.CreateElement("AlarmForeColor");
                xAlarmForeColor.InnerText = AlarmLimitMax.ForeColor.ToArgb().ToString();
                xAlarmMax.AppendChild(xAlarmForeColor);

                xAlarmBackColor = oXmlDoc.CreateElement("AlarmBackColor");
                xAlarmBackColor.InnerText = AlarmLimitMax.BackColor.ToArgb().ToString();
                xAlarmMax.AppendChild(xAlarmBackColor);

            return (xSignalAlarms);
        }

        /// <summary>
        /// Read the SignalAlarmsProperties XML node and set the current object
        /// </summary>
        /// <param name="xSignalAlarms">XML Node to read</param>
        /// <returns>Read error flag: True = No Error / False = Error</returns>
        public bool ReadSignalAlarmsXmlNode(XmlNode xSignalAlarms)
        {
            XmlNode xAlarmsEnabled = xSignalAlarms.SelectSingleNode("AlarmsEnabled");
            if (!(xAlarmsEnabled == null))
            {
                bool bEnabled;
                if (bool.TryParse(xAlarmsEnabled.InnerText, out bEnabled))
                {
                    Enabled = bEnabled;
                }
                else
                {
                    return (false);
                }

                XmlNode xAlarmActive, xAlarmVal, xAlarmForeColor, xAlarmBackColor;

                XmlNode xWarningMin = xSignalAlarms.SelectSingleNode("WarningMin");
                if (!(xWarningMin == null))
                {
                    xAlarmActive = xWarningMin.SelectSingleNode("AlarmActive");
                    if (!(xAlarmActive == null))
                    {
                        if (bool.TryParse(xAlarmActive.InnerText, out bEnabled))
                        {
                            WarningLimitMin.Enabled = bEnabled;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmVal = xWarningMin.SelectSingleNode("AlarmValue");
                    if (!(xAlarmVal == null))
                    {
                        double Val;
                        if (double.TryParse(xAlarmVal.InnerText, out Val))
                        {
                            WarningLimitMin.Value = Val;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmForeColor = xWarningMin.SelectSingleNode("AlarmForeColor");
                    if (!(xAlarmForeColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmForeColor.InnerText, out iColor))
                        {
                            WarningLimitMin.ForeColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmBackColor = xWarningMin.SelectSingleNode("AlarmBackColor");
                    if (!(xAlarmBackColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmBackColor.InnerText, out iColor))
                        {
                            WarningLimitMin.BackColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                }
                else
                {
                    return (false);
                }

                XmlNode xWarningMax = xSignalAlarms.SelectSingleNode("WarningMax");
                if (!(xWarningMax == null))
                {
                    xAlarmActive = xWarningMax.SelectSingleNode("AlarmActive");
                    if (!(xAlarmActive == null))
                    {
                        if (bool.TryParse(xAlarmActive.InnerText, out bEnabled))
                        {
                            WarningLimitMax.Enabled = bEnabled;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmVal = xWarningMax.SelectSingleNode("AlarmValue");
                    if (!(xAlarmVal == null))
                    {
                        double Val;
                        if (double.TryParse(xAlarmVal.InnerText, out Val))
                        {
                            WarningLimitMax.Value = Val;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmForeColor = xWarningMax.SelectSingleNode("AlarmForeColor");
                    if (!(xAlarmForeColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmForeColor.InnerText, out iColor))
                        {
                            WarningLimitMax.ForeColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmBackColor = xWarningMax.SelectSingleNode("AlarmBackColor");
                    if (!(xAlarmBackColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmBackColor.InnerText, out iColor))
                        {
                            WarningLimitMax.BackColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                }
                else
                {
                    return (false);
                }

                XmlNode xAlarmMin = xSignalAlarms.SelectSingleNode("AlarmMin");
                if (!(xAlarmMin == null))
                {
                    xAlarmActive = xAlarmMin.SelectSingleNode("AlarmActive");
                    if (!(xAlarmActive == null))
                    {
                        if (bool.TryParse(xAlarmActive.InnerText, out bEnabled))
                        {
                            AlarmLimitMin.Enabled = bEnabled;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmVal = xAlarmMin.SelectSingleNode("AlarmValue");
                    if (!(xAlarmVal == null))
                    {
                        double Val;
                        if (double.TryParse(xAlarmVal.InnerText, out Val))
                        {
                            AlarmLimitMin.Value = Val;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmForeColor = xAlarmMin.SelectSingleNode("AlarmForeColor");
                    if (!(xAlarmForeColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmForeColor.InnerText, out iColor))
                        {
                            AlarmLimitMin.ForeColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmBackColor = xAlarmMin.SelectSingleNode("AlarmBackColor");
                    if (!(xAlarmBackColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmBackColor.InnerText, out iColor))
                        {
                            AlarmLimitMin.BackColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                }
                else
                {
                    return (false);
                }

                XmlNode xAlarmMax = xSignalAlarms.SelectSingleNode("AlarmMax");
                if (!(xAlarmMax == null))
                {
                    xAlarmActive = xAlarmMax.SelectSingleNode("AlarmActive");
                    if (!(xAlarmActive == null))
                    {
                        if (bool.TryParse(xAlarmActive.InnerText, out bEnabled))
                        {
                            AlarmLimitMax.Enabled = bEnabled;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmVal = xAlarmMax.SelectSingleNode("AlarmValue");
                    if (!(xAlarmVal == null))
                    {
                        double Val;
                        if (double.TryParse(xAlarmVal.InnerText, out Val))
                        {
                            AlarmLimitMax.Value = Val;
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmForeColor = xAlarmMax.SelectSingleNode("AlarmForeColor");
                    if (!(xAlarmForeColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmForeColor.InnerText, out iColor))
                        {
                            AlarmLimitMax.ForeColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }

                    xAlarmBackColor = xAlarmMax.SelectSingleNode("AlarmBackColor");
                    if (!(xAlarmBackColor == null))
                    {
                        int iColor;
                        if (int.TryParse(xAlarmBackColor.InnerText, out iColor))
                        {
                            AlarmLimitMax.BackColor = System.Drawing.Color.FromArgb(iColor);
                        }
                        else
                        {
                            return (false);
                        }
                    }
                    else
                    {
                        return (false);
                    }
                }
                else
                {
                    return (false);
                }
            }
            else
            {
                return (false);
            }

            return (true);
        }

        #endregion
    }

    #endregion

}
