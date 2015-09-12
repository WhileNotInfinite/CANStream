using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [Browsable(false)]
        public new bool Visible { get; set; }

        public DashboardGauge()
        {
            Visible = true;
            base.Visible = Visible;
        }
    }
}
