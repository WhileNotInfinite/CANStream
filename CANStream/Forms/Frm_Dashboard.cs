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
        private int CurrentDashPageIndex;

        #endregion

        public Frm_Dashboard()
        {
            InitializeComponent();

            DashWindows = new List<Frm_Dash_Window>();
            CurrentDashPageIndex = -1;
        }

        #region Control events

        #region Form

        private void Frm_Dashboard_Load(object sender, EventArgs e)
        {
            Open_SignalExplorer();
            Open_Toolbox();
            Open_Properties(false);
            Add_DashPage();
        }

        #endregion

        #region Ribbon

        #region Dashboard panel

        private void Rib_Dash_Btn_Run_Click(object sender, EventArgs e)
        {
            Start_Dashboard();
        }

        private void Rib_Dash_Btn_Stop_Click(object sender, EventArgs e)
        {
            Stop_Dashboard();
        }

        private void Rib_Dash_Btn_RecStart_Click(object sender, EventArgs e)
        {
            Start_Record();
        }

        private void Rib_Dash_Btn_RecStop_Click(object sender, EventArgs e)
        {
            Stop_Record();
        }

        private void Rib_Dash_Btn_PageFirst_Click(object sender, EventArgs e)
        {
            Set_PageIndex(0);
        }

        private void Rib_Dash_Btn_PagePrev_Click(object sender, EventArgs e)
        {
            Set_PageIndex(CurrentDashPageIndex - 1);
        }

        private void Rib_Dash_Cmb_PageSelect_DropDownItemClicked(object sender, RibbonItemEventArgs e)
        {
            RibbonButton RibBtn_Page = (RibbonButton)e.Item;

            if (!(RibBtn_Page==null))
            {
                Frm_Dash_Window Frm = (Frm_Dash_Window)RibBtn_Page.Tag;

                if (!(Frm==null))
                {
                    Frm.Show();
                }
            }
        }

        private void Rib_Dash_Btn_PageNext_Click(object sender, EventArgs e)
        {
            Set_PageIndex(CurrentDashPageIndex + 1);
        }

        private void Rib_Dash_Btn_PageLast_Click(object sender, EventArgs e)
        {
            Set_PageIndex(DashWindows.Count - 1);
        }

        #endregion

        #region Edit panel

        private void Rib_Edit_Btn_Lock_Click(object sender, EventArgs e)
        {
            Lock_Dashboard();
        }

        private void Rib_Edit_Btn_Unlock_Click(object sender, EventArgs e)
        {
            Unlock_Dashboard();
        }

        private void Rib_Edit_Btn_Page_Add_Click(object sender, EventArgs e)
        {
            Add_DashPage();
        }

        private void Rib_Edit_Btn_Page_Del_Click(object sender, EventArgs e)
        {
            Del_DashPage();
        }

        #endregion

        #region View panel

        private void Rib_View_Btn_SignalExplorer_Click(object sender, EventArgs e)
        {
            Show_SignalExplorer();
        }

        private void Rib_View_Btn_DashControls_Click(object sender, EventArgs e)
        {
            Show_Toolbox();
        }

        private void Rib_View_Btn_ControlProperties_Click(object sender, EventArgs e)
        {
            Show_Properties();
        }

        #endregion

        #endregion

        #region Dockpanel

        private void dockPanel1_ActiveDocumentChanged(object sender, EventArgs e)
        {
            if (!(dockPanel1.ActiveDocument == null))
            {
                if (dockPanel1.ActiveDocument.GetType().Equals(typeof(Frm_Dash_Window)))
                {
                    Frm_Dash_Window Frm = (Frm_Dash_Window)dockPanel1.ActiveDocument;
                    CurrentDashPageIndex = DashWindows.IndexOf(Frm);

                    if (!(Frm.Tag == null))
                    {
                        Rib_Dash_Cmb_PageSelect.SelectedItem = (RibbonButton)Frm.Tag;
                    }
                }
            }
        }

        private void dockPanel1_ContentRemoved(object sender, DockContentEventArgs e)
        {
            if(e.Content.GetType().Equals(typeof(Frm_Dash_Window)))
            {
                Frm_Dash_Window Frm = (Frm_Dash_Window)e.Content;

                if (!(Frm.Tag == null))
                {
                    Rib_Dash_Cmb_PageSelect.DropDownItems.Remove((RibbonButton)Frm.Tag);
                }

                DashWindows.Remove(Frm);
                Frm.Dispose();
            }
        }

        #endregion

        #endregion

        #region Private methodes

        #region Form

        private void Open_SignalExplorer()
        {
            FrmSignalExplorer = new Frm_Dash_SignalExplorer();
            FrmSignalExplorer.Show(dockPanel1, DockState.DockLeft);
        }

        private void Show_SignalExplorer()
        {
            if (FrmSignalExplorer.IsDisposed)
            {
                Open_SignalExplorer();
            }
            else if (FrmSignalExplorer.IsHidden)
            {
                FrmSignalExplorer.IsHidden = false;
            }
            else if (FrmSignalExplorer.DockState.Equals(DockState.DockBottomAutoHide))
            {
                FrmSignalExplorer.DockState = DockState.DockBottom;
                FrmSignalExplorer.Show();
            }
            else if (FrmSignalExplorer.DockState.Equals(DockState.DockLeftAutoHide))
            {
                FrmSignalExplorer.DockState = DockState.DockLeft;
                FrmSignalExplorer.Show();
            }
            else if (FrmSignalExplorer.DockState.Equals(DockState.DockRightAutoHide))
            {
                FrmSignalExplorer.DockState = DockState.DockRight;
                FrmSignalExplorer.Show();
            }
            else if (FrmSignalExplorer.DockState.Equals(DockState.DockTopAutoHide))
            {
                FrmSignalExplorer.DockState = DockState.DockTop;
                FrmSignalExplorer.Show();
            }
            else if (FrmSignalExplorer.DockState.Equals(DockState.Document))
            {
                FrmSignalExplorer.Show();
            }
            else if (!(FrmSignalExplorer.Visible))
            {
                FrmSignalExplorer.Show();
            }
        }

        private void Open_Toolbox()
        {
            FrmToolBox = new Frm_Dash_ToolBox();
            FrmToolBox.Show(dockPanel1, DockState.DockLeft);
        }

        private void Show_Toolbox()
        {
            if (FrmToolBox.IsDisposed)
            {
                Open_Toolbox();
            }
            else if (FrmToolBox.IsHidden)
            {
                FrmToolBox.IsHidden = false;
            }
            else if (FrmToolBox.DockState.Equals(DockState.DockBottomAutoHide))
            {
                FrmToolBox.DockState = DockState.DockBottom;
                FrmToolBox.Show();
            }
            else if (FrmToolBox.DockState.Equals(DockState.DockLeftAutoHide))
            {
                FrmToolBox.DockState = DockState.DockLeft;
                FrmToolBox.Show();
            }
            else if (FrmToolBox.DockState.Equals(DockState.DockRightAutoHide))
            {
                FrmToolBox.DockState = DockState.DockRight;
                FrmToolBox.Show();
            }
            else if (FrmToolBox.DockState.Equals(DockState.DockTopAutoHide))
            {
                FrmToolBox.DockState = DockState.DockTop;
                FrmToolBox.Show();
            }
            else if (FrmToolBox.DockState.Equals(DockState.Document))
            {
                FrmToolBox.Show();
            }
            else if (!(FrmToolBox.Visible))
            {
                FrmToolBox.Show();
            }
        }

        private void Open_Properties(bool Visible)
        {
            FrmProperties = new Frm_Dash_ControlProperties();

            if (Visible)
            {
                FrmProperties.Show(dockPanel1, DockState.DockRight);
            }
            else
            {
                FrmProperties.Show(dockPanel1, DockState.DockRightAutoHide);
            }
        }

        private void Show_Properties()
        {
            if (FrmProperties.IsDisposed)
            {
                Open_Properties(true);
            }
            else if (FrmProperties.IsHidden)
            {
                FrmProperties.IsHidden = false;
            }
            else if (FrmProperties.DockState.Equals(DockState.DockBottomAutoHide))
            {
                FrmProperties.DockState = DockState.DockBottom;
                FrmProperties.Show();
            }
            else if (FrmProperties.DockState.Equals(DockState.DockLeftAutoHide))
            {
                FrmProperties.DockState = DockState.DockLeft;
                FrmProperties.Show();
            }
            else if (FrmProperties.DockState.Equals(DockState.DockRightAutoHide))
            {
                FrmProperties.DockState = DockState.DockRight;
                FrmProperties.Show();
            }
            else if (FrmProperties.DockState.Equals(DockState.DockTopAutoHide))
            {
                FrmProperties.DockState = DockState.DockTop;
                FrmProperties.Show();
            }
            else if (FrmProperties.DockState.Equals(DockState.Document))
            {
                FrmProperties.Show();
            }
            else if (!(FrmProperties.Visible))
            {
                FrmProperties.Show();
            }
        }

        #endregion

        #region Dashboard configuration

        private void Lock_Dashboard()
        {
            Rib_Edit_Btn_Lock.Visible = false;
            Rib_Edit_Btn_Unlock.Visible = true;

            Rib_Edit_Btn_Cut.Enabled = false;
            Rib_Edit_Btn_Copy.Enabled = false;
            Rib_Edit_Btn_Paste.Enabled = false;
            Rib_Edit_Btn_Page_Add.Enabled = false;
            Rib_Edit_Btn_Page_Del.Enabled = false;
            Rib_Edit_Cmb_Select.Enabled = false;
            Rib_Edit_Btn_Del.Enabled = false;
            Rib_Edit_Btn_Font.Enabled = false;
            Rib_Edit_Btn_Color.Enabled = false;
            Rib_Edit_Btn_Align_Left.Enabled = false;
            Rib_Edit_Btn_Align_Right.Enabled = false;
            Rib_Edit_Btn_Align_Top.Enabled = false;
            Rib_Edit_Btn_Align_Bottom.Enabled = false;
            Rib_Edit_Btn_Align_Center_Vert.Enabled = false;
            Rib_Edit_Btn_Align_Center_Horz.Enabled = false;
            Rib_Edit_Btn_Rotate_Left.Enabled = false;
            Rib_Edit_Btn_Rotate_Right.Enabled = false;
            
        }

        private void Unlock_Dashboard()
        {
            Rib_Edit_Btn_Lock.Visible = true;
            Rib_Edit_Btn_Unlock.Visible = false;

            Rib_Edit_Btn_Cut.Enabled = true;
            Rib_Edit_Btn_Copy.Enabled = true;
            Rib_Edit_Btn_Paste.Enabled = true;
            Rib_Edit_Btn_Page_Add.Enabled = true;
            Rib_Edit_Btn_Page_Del.Enabled = true;
            Rib_Edit_Cmb_Select.Enabled = true;
            Rib_Edit_Btn_Del.Enabled = true;
            Rib_Edit_Btn_Font.Enabled = true;
            Rib_Edit_Btn_Color.Enabled = true;
            Rib_Edit_Btn_Align_Left.Enabled = true;
            Rib_Edit_Btn_Align_Right.Enabled = true;
            Rib_Edit_Btn_Align_Top.Enabled = true;
            Rib_Edit_Btn_Align_Bottom.Enabled = true;
            Rib_Edit_Btn_Align_Center_Vert.Enabled = true;
            Rib_Edit_Btn_Align_Center_Horz.Enabled = true;
            Rib_Edit_Btn_Rotate_Left.Enabled = true;
            Rib_Edit_Btn_Rotate_Right.Enabled = true;
        }

        #endregion

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
            
            RibbonButton RibBtn_Page = new RibbonButton(PageName);
            RibBtn_Page.SmallImage = (Image)Icones.Dashboard_16;

            RibBtn_Page.Tag = Frm;
            Frm.Tag = RibBtn_Page;

            Rib_Dash_Cmb_PageSelect.DropDownItems.Add(RibBtn_Page);

            DashWindows.Add(Frm);

            Frm.Show(dockPanel1, DockState.Document);
        }

        private void Set_PageIndex(int Index)
        {
            if (Index >= 0 && Index < DashWindows.Count)
            {
                DashWindows[Index].Show();
            }
        }

        private void Del_DashPage()
        {
            if (CurrentDashPageIndex >= 0 && CurrentDashPageIndex < DashWindows.Count)
            {
                Frm_Dash_Window Frm = DashWindows[CurrentDashPageIndex];

                if (MessageBox.Show("Do you really want close dashboard page " + Frm.Text,
                    Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    Frm.Close();
                }
            }
        }

        #endregion

        #region Dash control

        private void Start_Dashboard()
        {
            Rib_Dash_Btn_Run.Enabled = false;
            Rib_Dash_Btn_Stop.Enabled = true;
        }

        private void Stop_Dashboard()
        {
            Rib_Dash_Btn_Run.Enabled = true;
            Rib_Dash_Btn_Stop.Enabled = false;
        }
    
        #endregion

        #region Records

        private void Start_Record()
        {
            Rib_Dash_Btn_RecStart.Enabled = false;
            Rib_Dash_Btn_RecStop.Enabled = true;
        }

        private void Stop_Record()
        {
            Rib_Dash_Btn_RecStart.Enabled = true;
            Rib_Dash_Btn_RecStop.Enabled = false;
        }

        #endregion

        #endregion
    }
}
