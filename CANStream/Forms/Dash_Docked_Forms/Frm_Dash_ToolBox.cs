using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace CANStream
{
    public partial class Frm_Dash_ToolBox : DockContent
    {
        public Frm_Dash_ToolBox()
        {
            InitializeComponent();

            Fill_ToolboxList();
        }

        #region Control events

        private void LV_Tools_ItemDrag(object sender, ItemDragEventArgs e)
        {
            LV_Tools.DoDragDrop(LV_Tools.SelectedItems, DragDropEffects.Move);
        }

        private void LV_Tools_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        #endregion

        #region Private methodes

        private void Fill_ToolboxList()
        {
            ListViewItem It = null;

            LV_Tools.Items.Clear();

            It = LV_Tools.Items.Add("Gauge", 0);
            It.Tag = DashboardControlType.Gauge;
        }

        #endregion
    }
}
