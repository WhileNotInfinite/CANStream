using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization; //Test
using System.IO; //Test

namespace CANStream
{
    #region Public enums

    public enum DashboardControlType
    {
        None = 0,
        Gauge = 1,
    }

    #endregion

    public class CS_DashboardPage
    {
        #region Public members

        public string Name;
        public List<Control> Controls;

        #endregion

        public CS_DashboardPage()
        {
            Name = "";
            Controls = new List<Control>();
        }
    }

    public class CS_Dashboard
    {
        #region Private constants

        private readonly string[] ExcludedProperties = {
            "Visible",
            "AllowDrop",
            "AutoSize",
            "ImeMode",
            "BackgroundImageLayout",
            "AccessibilityObject",
            "AccessibleRole",
            "Anchor",
            "AutoScrollOffset",
            "LayoutEngine",
            "BindingContext",
            "CanFocus",
            "CanSelect",
            "Capture",
            "CausesValidation",
            "CompanyName",
            "ContainsFocus",
            "Controls",
            "Created",
            "Cursor",
            "DataBindings",
            "IsDisposed",
            "Disposing",
            "Dock",
            "Enabled",
            "Focused",
            "Handle",
            "HasChildren",
            "IsHandleCreated",
            "InvokeRequired",
            "IsAccessible",
            "IsMirrored",
            "Margin",
            "Parent",
            "ProductName",
            "ProductVersion",
            "RecreatingHandle",
            "RightToLeft",
            "TabIndex",
            "TabStop",
            "TopLevelControl",
            "UseWaitCursor",
            "WindowTarget",
            "Padding"
        };

        #endregion

        #region Public members

        public bool Locked;

        public List<CS_DashboardPage> Pages;

        #endregion

        public CS_Dashboard()
        {
            Locked = false;
            Pages = new List<CS_DashboardPage>();
        }

        #region Private methodes

        private bool IsExcludedProperty(string PropertyName)
        {
            foreach (string Prop in ExcludedProperties)
            {
                if (Prop.Equals(PropertyName))
                {
                    return (true);
                }
            }

            return (false);
        }

        #endregion

        #region Public methodes
        /*
        public void Write_DashboardFile(string fPath)
        {
            if (!(fPath.Equals("")))
            {
                XmlDocument oXDoc = new XmlDocument();
                XmlElement xDash = oXDoc.CreateElement("DashboardConfiguration");
                oXDoc.AppendChild(xDash);

                XmlElement xLocked = oXDoc.CreateElement("Locked");
                xLocked.InnerText = Locked.ToString();
                xDash.AppendChild(xLocked);

                XmlElement xPages = oXDoc.CreateElement("Pages");
                xDash.AppendChild(xPages);

                foreach (CS_DashboardPage oPage in Pages)
                {
                    XmlElement xPage = oXDoc.CreateElement("DashboardPage");
                    xPages.AppendChild(xPage);

                    XmlElement xPageName = oXDoc.CreateElement("PageName");
                    xPageName.InnerText = oPage.Name;
                    xPage.AppendChild(xPageName);

                    XmlElement xPageControls = oXDoc.CreateElement("PageControls");
                    xPage.AppendChild(xPageControls);

                    foreach (Control oCtrl in oPage.Controls)
                    {
                        XmlElement xCtrl = oXDoc.CreateElement("DashboardControl");
                        xPageControls.AppendChild(xCtrl);

                        XmlElement xCtrlName = oXDoc.CreateElement("ControlName");
                        xCtrlName.InnerText = oCtrl.Name;
                        xCtrl.AppendChild(xCtrlName);

                        Type oCtrlType = oCtrl.GetType();

                        XmlElement xCtrlType = oXDoc.CreateElement("ControlType");
                        xCtrlType.InnerText = oCtrlType.FullName;
                        xCtrl.AppendChild(xCtrlType);

                        XmlElement xProperties = oXDoc.CreateElement("Properties");
                        xCtrl.AppendChild(xProperties);

                        foreach (PropertyInfo oProp in oCtrlType.GetProperties())
                        {
                            if (!(IsExcludedProperty(oProp.Name)))
                            {
                                object oPropValue = oProp.GetValue(oCtrl);

                                if (!(oPropValue == null))
                                {
                                    XmlElement xProp = oXDoc.CreateElement(oProp.Name);

                                    XmlAttribute xAtrPropType = oXDoc.CreateAttribute("PropertyType");
                                    xAtrPropType.Value = oProp.PropertyType.FullName;
                                    xProp.Attributes.Append(xAtrPropType);

                                    PropertyInfo[] MemberProperties = oProp.PropertyType.GetProperties();

                                    if (MemberProperties.Length > 0)
                                    {
                                        XmlElement xMembers = oXDoc.CreateElement("PropertyMembers");
                                        xProp.AppendChild(xMembers);

                                        foreach (PropertyInfo oMember in MemberProperties)
                                        {
                                            if (oMember.CanWrite)
                                            {
                                                object oMemberValue = oMember.GetValue(oProp);

                                                if (!(oMemberValue == null))
                                                {
                                                    XmlElement xPropMember = oXDoc.CreateElement(oMember.Name);

                                                    XmlAttribute xAtrMemberType = oXDoc.CreateAttribute("MemberType");
                                                    xAtrMemberType.Value = oMember.PropertyType.FullName;
                                                    xPropMember.Attributes.Append(xAtrMemberType);

                                                    xPropMember.InnerText = oMemberValue.ToString();

                                                    xMembers.AppendChild(xPropMember);
                                                }
                                            }
                                        }
                                    }
                                    else
                                    {
                                        xProp.InnerText = oPropValue.ToString();
                                    }

                                    xProperties.AppendChild(xProp);
                                }

                                //XmlElement xProp = oXDoc.CreateElement("Property");
                                //
                                //XmlElement xPropName = oXDoc.CreateElement("PropName");
                                //xPropName.InnerText = oProp.Name;
                                //
                                //XmlElement xPropType = oXDoc.CreateElement("PropType");
                                //xPropType.InnerText = oProp.PropertyType.FullName;
                                //xProp.AppendChild(xPropType);
                                //
                                //XmlElement xPropValue = oXDoc.CreateElement("PropValue");
                                //object PropValue = oProp.GetValue((object)oCtrl);
                                //
                                //if (!(PropValue == null))
                                //{
                                //    xProperties.AppendChild(xProp);
                                //    xProp.AppendChild(xPropName);
                                //
                                //    if (oProp.PropertyType.Equals(typeof(Color)))
                                //    {
                                //        Color oColor = (Color)PropValue;
                                //        xPropValue.InnerText = oColor.ToArgb().ToString();
                                //    }
                                //    else if (oProp.PropertyType.Equals(typeof(Font)))
                                //    {
                                //        Font oFont = (Font)PropValue;
                                //        xPropValue.InnerText = oFont.ToHfont().ToInt64().ToString();
                                //    }
                                //    else if (oProp.PropertyType.BaseType.Equals(typeof(Enum)))
                                //    {
                                //        Enum oEnum = (Enum)PropValue;
                                //        xPropValue.InnerText = ((int)PropValue).ToString();
                                //    }
                                //    else if (oProp.PropertyType.BaseType.Equals(typeof(BaseCollection)))
                                //    {
                                //        int i = 1;
                                //    }
                                //    else
                                //    {
                                //        xPropValue.InnerText = PropValue.ToString();
                                //    }
                                //
                                //    xProp.AppendChild(xPropValue);
                            }
                        }
                    }
                }

                oXDoc.Save(fPath);
            }
        }
        */

        public void Write_DashboardFile(string fPath)
        {
            Color c = Color.Blue;

            FileStream oFile = File.Open(fPath, FileMode.OpenOrCreate);
            XmlSerializer serializer = new XmlSerializer(typeof(Color));
            serializer.Serialize(oFile, c);
            oFile.Close();
        }

        public bool Read_DashboardFile(string fPath)
        {
            if (!(fPath.Equals("")))
            {
                try
                {
                    XmlDocument oXDoc = new XmlDocument();
                    oXDoc.Load(fPath);

                    XmlNode xDash = oXDoc.SelectSingleNode("DashboardConfiguration");

                    XmlNode xLocked = xDash.SelectSingleNode("Locked");
                    Locked = bool.Parse(xLocked.InnerText);

                    XmlNode xPages = xDash.SelectSingleNode("Pages");
                    Pages.Clear();

                    foreach (XmlNode xPage in xPages.ChildNodes)
                    {
                        CS_DashboardPage oPage = new CS_DashboardPage();

                        XmlNode xPageName = xPage.SelectSingleNode("PageName");
                        oPage.Name = xPageName.InnerText;

                        XmlNode xControls = xPage.SelectSingleNode("PageControls");

                        foreach (XmlNode xCtrl in xControls.ChildNodes)
                        {
                            XmlNode xCtrlType = xCtrl.SelectSingleNode("ControlType");
                            Type oCtrlType = Type.GetType(xCtrlType.InnerText);

                            Control oCtrl = Activator.CreateInstance(oCtrlType) as Control;

                            XmlNode xCtrlName = xCtrl.SelectSingleNode("ControlName");
                            oCtrl.Name = xCtrlName.InnerText;

                            XmlNode xProps = xCtrl.SelectSingleNode("Properties");

                            foreach (XmlNode xProperty in xProps.ChildNodes)
                            {
                                XmlNode xPropType = xProperty.SelectSingleNode("PropType");
                                XmlNode xPropValue = xProperty.SelectSingleNode("PropValue");
                                XmlNode xPropName = xProperty.SelectSingleNode("PropName");

                                //Type oPropType = Type.GetType(xPropType.InnerText);
                                Type oPropType = CANStreamTools.CS_GetType(xPropType.InnerText);
                                PropertyInfo oProp = oCtrlType.GetProperty(xPropName.InnerText, oPropType);

                                if (oPropType.Equals(typeof(Color)))
                                {
                                    Color oColor = Color.FromArgb(int.Parse(xPropValue.InnerText));
                                    oProp.SetValue(oCtrl, oColor);
                                }
                                else if (oPropType.Equals(typeof(Font)))
                                {
                                    //Font oFont = Font.FromHfont(((IntPtr)Int64.Parse(xPropValue.InnerText)));
                                    //oProp.SetValue(oCtrl, oFont);
                                }
                                else if (oPropType.BaseType.Equals(typeof(Enum)))
                                {
                                    Enum oEnum = (Enum)Activator.CreateInstance(oPropType);
                                    oEnum = (Enum)Enum.Parse(oPropType, xPropValue.InnerText);
                                    oProp.SetValue(oCtrl, oEnum);
                                }
                                else
                                {
                                    oProp.SetValue(oCtrl, Convert.ChangeType(xPropValue.InnerText, oProp.PropertyType));
                                }
                            }

                            oPage.Controls.Add(oCtrl);
                        }

                        Pages.Add(oPage);
                    }

                    return (true);
                }
                catch
                {
                    return (false);
                }
            }

            return (false);
        }

        #endregion
    }
}
