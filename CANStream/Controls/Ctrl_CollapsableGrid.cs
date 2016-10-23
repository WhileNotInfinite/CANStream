using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANStream
{
    public partial class Ctrl_CollapsableGrid : UserControl
    {
        #region Control properties

        [Category("Misc"), Browsable(true), Description("Columns of the grid")]
        public DataGridViewColumnCollection Columns
        {
            get
            {
                return (oGrid.Columns);
            }
        }

        [Browsable(false)]
        public CollapsableGridRowCollection Rows
        {
            get
            {
                return (GridRows);
            }
        }

        #endregion

        #region Private members

        private CollapsableGridRowCollection GridRows;

        #endregion

        public Ctrl_CollapsableGrid()
        {
            InitializeComponent();

            GridRows = new CollapsableGridRowCollection();

            //Rows collection events callback
            GridRows.RowAdded += new EventHandler<CollapsableGridRowAddedEventArgs>(GridRowsAdded);
            GridRows.RowsCleared += new EventHandler(GridRowsCleared);
        }

        #region Internal events callback

        private void GridRowsAdded(object sender, CollapsableGridRowAddedEventArgs e)
        {
            int iRow = oGrid.Rows.Add(e.NewRow as DataGridViewRow);

            oGrid.Rows[iRow].Cells[0].Value = Img_RowState.Images[1];
        }

        private void GridRowsCleared(object sender, EventArgs e)
        {
            oGrid.Rows.Clear();
        }

        #endregion
    }

    public class CollapsableGridRow : DataGridViewRow
    {
        #region Public Properties

        public CollapsableGridRow Parent
        {
            get
            {
                return (RowParent);
            }

            set
            {
                RowParent = value;
            }
        }

        public CollapsableGridRowCollection Children
        {
            get
            {
                return (RowChildren);
            }
        }

        #endregion

        #region Private members

        private CollapsableGridRow RowParent;

        private CollapsableGridRowCollection RowChildren;

        private CollapsableGridRowState RowState;

        #endregion

        public CollapsableGridRow()
        {
            RowParent = null;
            RowChildren = new CollapsableGridRowCollection();
            RowState = CollapsableGridRowState.NoChildren;
        }

        #region Public methodes

        public void Collapse()
        {
            if (this.RowChildren.Count > 0)
            {
                foreach (CollapsableGridRow oChildRow in RowChildren)
                {
                    oChildRow.Collapse();
                    oChildRow.Visible = false;
                }

                RowState = CollapsableGridRowState.Collapsed;
            }
        }

        public void Expand()
        {
            if (this.RowChildren.Count > 0)
            {
                foreach(CollapsableGridRow oChildRow in RowChildren)
                {
                    oChildRow.Visible = true;
                }

                RowState = CollapsableGridRowState.Expanded;
            }
        }

        public void ExpandAll()
        {
            if (this.RowChildren.Count > 0)
            {
                foreach (CollapsableGridRow oChildRow in RowChildren)
                {
                    oChildRow.Visible = true;
                    oChildRow.ExpandAll();
                }

                RowState = CollapsableGridRowState.Expanded;
            }
        }

        public void AddChild(CollapsableGridRow oChildRow)
        {
            if (!(oChildRow == null))
            {
                oChildRow.Parent = this;
                this.Children.Add(oChildRow);
                this.Expand();
            }
        }

        #endregion
    }

    public class CollapsableGridRowCollection : List<CollapsableGridRow>
    {
        #region Internal Events

        internal event EventHandler<CollapsableGridRowAddedEventArgs> RowAdded;
        internal event EventHandler RowsCleared;

        #endregion

        public CollapsableGridRowCollection()
        {
            
        }

        #region Events handling methods

        protected virtual void OnRowAdded(CollapsableGridRow oNewRow)
        {
            EventHandler<CollapsableGridRowAddedEventArgs> Handler = RowAdded;

            if (Handler != null)
            {
                CollapsableGridRowAddedEventArgs RowAddedEvtArg = new CollapsableGridRowAddedEventArgs();
                RowAddedEvtArg.NewRow = oNewRow;

                Handler(this, RowAddedEvtArg);
            }
        }

        protected virtual void OnRowsCleared()
        {
            EventHandler Handler = RowsCleared;

            if (Handler != null)
            {
                Handler(this, new EventArgs());
            }
        }

        #endregion

        #region Public methodes

        public CollapsableGridRow Add()
        {
            CollapsableGridRow oRow = new CollapsableGridRow();
            Add(oRow);
            return (oRow);
        }

        public new void Add(CollapsableGridRow item)
        {
            base.Add(item);
            OnRowAdded(item);
        }

        public new void Clear()
        {
            base.Clear();
            OnRowsCleared();
        }

        #endregion
    }

    public class CollapsableGridRowAddedEventArgs : EventArgs
    {
        public CollapsableGridRow NewRow { get; set; }

        public CollapsableGridRowAddedEventArgs()
        {
            NewRow = null;
        }
    }

    public enum CollapsableGridRowState
    {
        NoChildren = 0,
        Collapsed = 1,
        Expanded = 2,
    }
}
