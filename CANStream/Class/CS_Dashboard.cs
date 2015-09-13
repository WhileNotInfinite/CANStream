using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO; 

namespace CANStream
{
    #region Public enums

    public enum DashboardControlType
    {
        None = 0,
        Gauge = 1,
        BarGraph = 2,
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

        private XmlElement GetGaugeXmlNode(XmlDocument oXDoc, Control oGauge)
        {
            XmlElement xGauge = oXDoc.CreateElement("Gauge");

            return (xGauge);
        }

        #endregion

        #region Public methodes
        
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
                        if (oCtrl.GetType().Equals(typeof(DashboardGauge)))
                        {
                            xPageControls.AppendChild(GetGaugeXmlNode(oXDoc, oCtrl));
                        }
                    }
                }

                oXDoc.Save(fPath);
            }
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
