using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

namespace CANStream
{
    public partial class Frm_Dashboard : Form
    {
        #region Private members

        private Frm_Dash_SignalExplorer FrmSignalExplorer;
        private Frm_Dash_ToolBox FrmToolBox;
        private Frm_Dash_ControlProperties FrmProperties;
        private List<Frm_Dash_Window> DashWindows;

        #endregion

        public Frm_Dashboard()
        {
            InitializeComponent();

            FrmSignalExplorer = new Frm_Dash_SignalExplorer();
            FrmToolBox = new Frm_Dash_ToolBox();
            FrmProperties = new Frm_Dash_ControlProperties();
            DashWindows = new List<Frm_Dash_Window>();
        }

        #region Control events

        #region Form

        private void Frm_Dashboard_Load(object sender, EventArgs e)
        {
            FrmSignalExplorer.Show(dockPanel1, DockState.DockLeft);
            FrmToolBox.Show(dockPanel1, DockState.DockLeft);
            FrmProperties.Show(dockPanel1, DockState.DockRightAutoHide);

            Add_DashPage();
        }

        #endregion

        #endregion

        #region Private methodes

        #region Dash Pages

        private void Add_DashPage()
        {
            Add_DashPage("");
        }
        
        private void Add_DashPage(string PageName)
        {
            Frm_Dash_Window Frm = new Frm_Dash_Window();

            if (PageName.Equals(""))
            {
                PageName = "Dash " + (DashWindows.Count + 1).ToString();
            }

            Frm.Text = PageName;
            DashWindows.Add(Frm);

            Frm.Show(dockPanel1, DockState.Document);
        }

        #endregion

        #endregion
    }
}
