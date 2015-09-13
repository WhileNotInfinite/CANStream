using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace CANStream
{
    [Serializable]
    public class DashboardGauge : AGauge
    {
        public DashboardGauge()
        {
            PropertyDescriptor descriptor = TypeDescriptor.GetProperties(this.GetType())["Anchor"];
            BrowsableAttribute attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
            FieldInfo isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
            isBrow.SetValue(attrib, false);

            descriptor = TypeDescriptor.GetProperties(this.GetType())["UseWaitCursor"];
            attrib = (BrowsableAttribute)descriptor.Attributes[typeof(BrowsableAttribute)];
            isBrow = attrib.GetType().GetField("browsable", BindingFlags.NonPublic | BindingFlags.Instance);
            isBrow.SetValue(attrib, false);
        }
    }
}
