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
    public partial class Frm_Dash_ControlProperties : DockContent
    {
        #region Private members

        private bool CmbEventsDisabled;

        #endregion

        #region Public events

        public event EventHandler<ControlsListSelectedChangedEventArgs> ControlsListSelectedChanged;

        #endregion

        public Frm_Dash_ControlProperties()
        {
            InitializeComponent();

            CmbEventsDisabled = false;
        }

        #region Control events

        private void Cmb_Controls_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!CmbEventsDisabled)
            {
                ControlsListSelectedChangedEventArgs EvtArg = new ControlsListSelectedChangedEventArgs();
                EvtArg.ControlName = Cmb_Controls.SelectedItem.ToString();
                OnControlsListSelectedChanged(EvtArg);
            }
        }

        #endregion

        #region Event handling methodes

        protected virtual void OnControlsListSelectedChanged(ControlsListSelectedChangedEventArgs e)
        {
            EventHandler<ControlsListSelectedChangedEventArgs> Handler = ControlsListSelectedChanged;
            if(Handler!=null)
            {
                Handler(this, e);
            }
        }

        #endregion

        #region Public methodes

        public void Set_PropertyGridControl(Control Ctrl)
        {
            PropGrid.SelectedObject = Ctrl;

            if (!(Ctrl == null))
            {
                CmbEventsDisabled = true;
                Cmb_Controls.SelectedIndex = Cmb_Controls.Items.IndexOf(Ctrl.Name);
                CmbEventsDisabled = false;
            }
        }

        public void Add_ControlItem(string ControlName)
        {
            Cmb_Controls.Items.Add(ControlName);
        }

        public void Del_ControlItem(string ControlName)
        {
            Cmb_Controls.Items.RemoveAt(Cmb_Controls.Items.IndexOf(ControlName));
        }

        public void Clear_ControlItems()
        {
            Cmb_Controls.Items.Clear();
            PropGrid.SelectedObject = null;
        }

        #endregion
    }

    public class ControlsListSelectedChangedEventArgs:EventArgs
    {
       public string ControlName { get; set; }
    }
}
