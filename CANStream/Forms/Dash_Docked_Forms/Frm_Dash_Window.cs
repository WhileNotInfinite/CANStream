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
    public partial class Frm_Dash_Window : DockContent
    {
        #region Private enums

        private enum ResizingMode
        {
            None = 0,
            FromLeft = 1,
            FromRight = 2,
            FromTop = 3,
            FromBottom = 4,
            FromLeftTop = 5,
            FromLeftBottom = 6,
            FromRightTop = 7,
            FromRightBottom = 8,
        }

        #endregion

        #region Private members

        private Point PtElementMouseDown;
        private ResizingMode ElementResizeMode;

        #endregion

        #region Public events

        public event EventHandler<DashboardControlEventArgs> DashboardControlCreated;

        public event EventHandler<DashboardControlEventArgs> DashboardControlSelected;

        public event EventHandler<DashboardControlRemovedEventArgs> DashboarControlRemoved;

        #endregion

        public Frm_Dash_Window()
        {
            InitializeComponent();

            PtElementMouseDown = Point.Empty;
        }

        #region Control events

        #region Dash_Panel

        private void Dash_Panel_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Dash_Panel_DragDrop(object sender, DragEventArgs e)
        {
            if (!(e.Data == null))
            {
                Point DropPoint = Dash_Panel.PointToClient(new Point(e.X, e.Y));
               
                ListView.SelectedListViewItemCollection LvItems = (ListView.SelectedListViewItemCollection)e.Data.GetData(typeof(ListView.SelectedListViewItemCollection));

                if (!(LvItems == null))
                {
                    foreach(ListViewItem It in LvItems)
                    {
                        DashboardControlType eCtrlType = (DashboardControlType)It.Tag;

                        switch(eCtrlType)
                        {
                            case DashboardControlType.Gauge:

                                Create_Gauge(DropPoint);
                                break;

                            case DashboardControlType.BarGraph:

                                Create_BarGraph(DropPoint);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }    
        }

        private void Dash_Panel_MouseClick(object sender, MouseEventArgs e)
        {
            Dash_Panel.Refresh();
        }

        #endregion

        #region Dash controls events

        #region Mouse events

        private void DashCtrl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                PtElementMouseDown = e.Location;
            }

            Set_SelectedElement((Control)sender);
        }

        private void DashCtrl_MouseMove(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:

                    if (ElementResizeMode.Equals(ResizingMode.None))
                    {
                        Move_Element((Control)sender, e.Location);
                    }
                    else
                    {
                        Resize_Element((Control)sender, e.Location);
                    }

                    break;

                case MouseButtons.Right:

                    break;

                default:

                    {
                        Control oCtrl = (Control)sender;
                        const int ResizeMargin = 10;

                        if (e.X <= ResizeMargin)
                        {
                            if (e.Y <= ResizeMargin)
                            {
                                Cursor = Cursors.SizeNWSE;
                                ElementResizeMode = ResizingMode.FromLeftTop;
                            }
                            else if ((oCtrl.Height - e.Y) <= ResizeMargin)
                            {
                                Cursor = Cursors.SizeNESW;
                                ElementResizeMode = ResizingMode.FromLeftBottom;
                            }
                            else
                            {
                                Cursor = Cursors.SizeWE;
                                ElementResizeMode = ResizingMode.FromLeft;
                            }
                        }
                        else if ((oCtrl.Width - e.X) <= ResizeMargin)
                        {
                            if (e.Y <= ResizeMargin)
                            {
                                Cursor = Cursors.SizeNESW;
                                ElementResizeMode = ResizingMode.FromRightTop;
                            }
                            else if ((oCtrl.Height - e.Y) <= ResizeMargin)
                            {
                                Cursor = Cursors.SizeNWSE;
                                ElementResizeMode = ResizingMode.FromRightBottom;
                            }
                            else
                            {
                                Cursor = Cursors.SizeWE;
                                ElementResizeMode = ResizingMode.FromRight;
                            }
                        }
                        else if (e.Y <= ResizeMargin)
                        {
                            Cursor = Cursors.SizeNS;
                            ElementResizeMode = ResizingMode.FromTop;
                        }
                        else if ((oCtrl.Height - e.Y) <= ResizeMargin)
                        {
                            Cursor = Cursors.SizeNS;
                            ElementResizeMode = ResizingMode.FromBottom;
                        }
                        else
                        {
                            Cursor = Cursors.Default;
                            ElementResizeMode = ResizingMode.None;
                        }
                    }

                    break;
            }
        }

        private void DashCtrl_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        #endregion

        #region Keyboard events

        private void DashCtrl_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Delete:

                    Delete_Element((Control)sender);
                    break;

                default:

                    break;
            }
        }

        #endregion

        #endregion

        #endregion

        #region Private methodes

        private void Set_SelectedElement(Control ControlSelected)
        {
            if (!(ControlSelected == null))
            {
                //Control highlighting
                ControlSelected.Focus();
                ControlSelected.Parent.Refresh();

                Graphics g = ControlSelected.Parent.CreateGraphics();
                Pen p = new Pen(SystemColors.Highlight, 4);

                g.DrawRectangle(p, new Rectangle(ControlSelected.Location, ControlSelected.Size));

                p.Dispose();
                g.Dispose();

                //Control selected event firing
                DashboardControlEventArgs e = new DashboardControlEventArgs();
                e.DashboardControl = ControlSelected;
                OnDashboardControlSelected(e);
            }
        }

        private void Move_Element(Control ControlSelected, Point NewLocation)
        {
            if (!(ControlSelected == null || PtElementMouseDown.Equals(Point.Empty)))
            {
                int NewLeft = ControlSelected.Left + (NewLocation.X - PtElementMouseDown.X);
                int NewTop = ControlSelected.Top + (NewLocation.Y - PtElementMouseDown.Y);

                if ((NewLeft >= 0 && NewLeft <= ControlSelected.Parent.Width - ControlSelected.Width) 
                    && (NewTop >= 0 && NewTop <= ControlSelected.Parent.Height - ControlSelected.Height))
                {
                    ControlSelected.Left = NewLeft;
                    ControlSelected.Top = NewTop;

                    Set_SelectedElement(ControlSelected);
                }
            }
        }

        private void Resize_Element(Control ControlSelected, Point ptMouse)
        {
            if (!(ControlSelected == null))
            {
                int NewLeft = -1;
                int NewTop = -1;
                int NewWidth = -1;
                int NewHeight = -1;

                switch (ElementResizeMode)
                {
                    case ResizingMode.FromLeft:

                        NewLeft = ControlSelected.Left + (ptMouse.X - PtElementMouseDown.X);
                        NewWidth = ControlSelected.Width + (PtElementMouseDown.X - ptMouse.X);

                        if (NewWidth >= ControlSelected.MinimumSize.Width && NewLeft > 0)
                        {
                            ControlSelected.Left = NewLeft;
                            ControlSelected.Width = NewWidth;
                        }

                        break;

                    case ResizingMode.FromRight:

                        NewWidth = ControlSelected.Width + (ptMouse.X - PtElementMouseDown.X);

                        if (NewWidth >= ControlSelected.MinimumSize.Width && NewWidth < (ControlSelected.Parent.Width - ControlSelected.Left))
                        {
                            ControlSelected.Width = NewWidth;
                            PtElementMouseDown = ptMouse;
                        }

                        break;

                    case ResizingMode.FromTop:

                        NewTop = ControlSelected.Top + (ptMouse.Y - PtElementMouseDown.Y);
                        NewHeight = ControlSelected.Height + (PtElementMouseDown.Y - ptMouse.Y);

                        if (NewHeight >= ControlSelected.MinimumSize.Height && NewTop > 0)
                        {
                            ControlSelected.Top = NewTop;
                            ControlSelected.Height = NewHeight;
                        }

                        break;

                    case ResizingMode.FromBottom:

                        NewHeight = ControlSelected.Height + (ptMouse.Y - PtElementMouseDown.Y);

                        if (NewHeight >= ControlSelected.MinimumSize.Height && NewHeight < (ControlSelected.Parent.Height - ControlSelected.Top))
                        {
                            ControlSelected.Height = NewHeight;
                            PtElementMouseDown = ptMouse;
                        }

                        break;

                    case ResizingMode.FromLeftTop:

                        NewLeft = ControlSelected.Left + (ptMouse.X - PtElementMouseDown.X);
                        NewWidth = ControlSelected.Width + (PtElementMouseDown.X - ptMouse.X);

                        NewTop = ControlSelected.Top + (ptMouse.Y - PtElementMouseDown.Y);
                        NewHeight = ControlSelected.Height + (PtElementMouseDown.Y - ptMouse.Y);

                        if (NewWidth >= ControlSelected.MinimumSize.Width && NewLeft > 0 && NewHeight >= ControlSelected.MinimumSize.Height && NewTop > 0)
                        {
                            ControlSelected.Left = NewLeft;
                            ControlSelected.Top = NewTop;

                            ControlSelected.Width = NewWidth;
                            ControlSelected.Height = NewHeight;
                        }

                        break;

                    case ResizingMode.FromLeftBottom:

                        NewLeft = ControlSelected.Left + (ptMouse.X - PtElementMouseDown.X);
                        NewWidth = ControlSelected.Width + (PtElementMouseDown.X - ptMouse.X);

                        NewHeight = ControlSelected.Height + (ptMouse.Y - PtElementMouseDown.Y);

                        if (NewWidth >= ControlSelected.MinimumSize.Width && NewLeft > 0 && NewHeight >= ControlSelected.MinimumSize.Height && NewHeight < (ControlSelected.Parent.Height - ControlSelected.Top))
                        {
                            ControlSelected.Left = NewLeft;

                            ControlSelected.Width = NewWidth;
                            ControlSelected.Height = NewHeight;

                            PtElementMouseDown.Y = ptMouse.Y;
                        }

                        break;

                    case ResizingMode.FromRightTop:

                        NewWidth = ControlSelected.Width + (ptMouse.X - PtElementMouseDown.X);

                        NewTop = ControlSelected.Top + (ptMouse.Y - PtElementMouseDown.Y);
                        NewHeight = ControlSelected.Height + (PtElementMouseDown.Y - ptMouse.Y);

                        if (NewWidth >= ControlSelected.MinimumSize.Width && NewWidth < (ControlSelected.Parent.Width - ControlSelected.Left) && NewHeight >= ControlSelected.MinimumSize.Height && NewTop > 0)
                        {
                            ControlSelected.Top = NewTop;

                            ControlSelected.Width = NewWidth;
                            ControlSelected.Height = NewHeight;

                            PtElementMouseDown.X = ptMouse.X;
                        }

                        break;

                    case ResizingMode.FromRightBottom:

                        NewWidth = ControlSelected.Width + (ptMouse.X - PtElementMouseDown.X);
                        NewHeight = ControlSelected.Height + (ptMouse.Y - PtElementMouseDown.Y);

                        if (NewWidth >= ControlSelected.MinimumSize.Width && NewWidth < (ControlSelected.Parent.Width - ControlSelected.Left)
                            && NewHeight >= ControlSelected.MinimumSize.Height && NewHeight < (ControlSelected.Parent.Height - ControlSelected.Top))
                        {
                            ControlSelected.Width = NewWidth;
                            ControlSelected.Height = NewHeight;

                            PtElementMouseDown = ptMouse;
                        }

                        break;
                }

                Set_SelectedElement(ControlSelected);
            }
        }

        private void Delete_Element(Control ControlSelected)
        {
            if (!(ControlSelected == null))
            {
                DashboardControlRemovedEventArgs e = new DashboardControlRemovedEventArgs();
                e.ControlName = ControlSelected.Name;

                ControlSelected.Parent.Controls.Remove(ControlSelected);
                Dash_Panel.Refresh();
                ControlSelected.Dispose();

                OnDahboardControlRemoved(e);
            }
        }

        private void Create_Gauge(Point Location)
        {
            DashboardGauge oGauge = new DashboardGauge();

            oGauge.Location = Location;
            oGauge.Name = Get_ControlName(oGauge.GetType());

            oGauge.MouseDown += new MouseEventHandler(DashCtrl_MouseDown);
            oGauge.MouseMove += new MouseEventHandler(DashCtrl_MouseMove);
            oGauge.MouseLeave += new EventHandler(DashCtrl_MouseLeave);
            oGauge.KeyDown += new KeyEventHandler(DashCtrl_KeyDown);

            Dash_Panel.Controls.Add(oGauge);

            DashboardControlEventArgs e = new DashboardControlEventArgs();
            e.DashboardControl = (Control)oGauge;
            OnDashboardControlCreated(e);
        }

        private void Create_BarGraph(Point Location)
        {
            DashboardBarGraph oBarGraph = new DashboardBarGraph();

            oBarGraph.Location = Location;
            oBarGraph.Name = Get_ControlName(oBarGraph.GetType());

            oBarGraph.MouseDown += new MouseEventHandler(DashCtrl_MouseDown);
            oBarGraph.MouseMove += new MouseEventHandler(DashCtrl_MouseMove);
            oBarGraph.MouseLeave += new EventHandler(DashCtrl_MouseLeave);
            oBarGraph.KeyDown += new KeyEventHandler(DashCtrl_KeyDown);

            Dash_Panel.Controls.Add(oBarGraph);

            DashboardControlEventArgs e = new DashboardControlEventArgs();
            e.DashboardControl = (Control)oBarGraph;
            OnDashboardControlCreated(e);
        }

        private string Get_ControlName(Type CtrlType)
        {
            int i = 1;

            foreach (Control Ctrl in Dash_Panel.Controls)
            {
                if(Ctrl.GetType().Equals(CtrlType))
                {
                    i++;
                }
            }

            return (CtrlType.Name + i.ToString());
        }

        #endregion

        #region Event handling methodes

        protected virtual void OnDashboardControlCreated(DashboardControlEventArgs e)
        {
            EventHandler<DashboardControlEventArgs> Handler = DashboardControlCreated;
            if (Handler != null)
            {
                Handler(this, e);
            }
        }

        protected virtual void OnDashboardControlSelected(DashboardControlEventArgs e)
        {
            EventHandler<DashboardControlEventArgs> Handler = DashboardControlSelected;
            if (Handler!=null)
            {
                Handler(this, e);
            }
        }

        protected virtual void OnDahboardControlRemoved(DashboardControlRemovedEventArgs e)
        {
            EventHandler<DashboardControlRemovedEventArgs> Handler = DashboarControlRemoved;
            if(Handler!=null)
            {
                Handler(this, e);
            }
        }

        #endregion

        #region Public methodes

        public void SelectDashboardControl(string ControlName)
        {
            foreach(Control oCtrl in Dash_Panel.Controls)
            {
                if(oCtrl.Name.Equals(ControlName))
                {
                    Set_SelectedElement(oCtrl);
                    break;
                }
            }
        }

        #endregion
    }

    #region Custom EventArgs

    public class DashboardControlEventArgs:EventArgs
    {
        public Control DashboardControl { get; set; }
    }

    public class DashboardControlRemovedEventArgs:EventArgs
    {
        public string ControlName { get; set; }
    }

    #endregion
}
