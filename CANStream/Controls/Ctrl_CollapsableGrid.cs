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

            GridRows = new CollapsableGridRowCollection(this.oGrid);
            GridRows.ParentRow = null;
        }
    }

    public class CollapsableGridRow
    {
        #region Public Properties

        public DataGridViewRow ThisRow
        {
            get
            {
                return (GridRow);
            }
        }

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

        private DataGridViewRow GridRow;

        private CollapsableGridRow RowParent;

        private CollapsableGridRowCollection RowChildren;

        private CollapsableGridRowState RowState;

        #endregion

        public CollapsableGridRow()
        {
            GridRow = null;
            RowParent = null;
            RowChildren = new CollapsableGridRowCollection(null);
            RowState = CollapsableGridRowState.NoChildren;
        }

        public CollapsableGridRow(DataGridViewRow DataGridRow)
        {
            GridRow = DataGridRow;
            RowParent = null;
            RowChildren = new CollapsableGridRowCollection(null);
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
                    oChildRow.ThisRow.Visible = false;
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
                    oChildRow.ThisRow.Visible = true;
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
                    oChildRow.ThisRow.Visible = true;
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
        #region Internal members

        internal CollapsableGridRow ParentRow;

        #endregion

        #region Private members

        private DataGridView oRefGrid;

        #endregion

        public CollapsableGridRowCollection(DataGridView DataGridRef)
        {
            oRefGrid = DataGridRef;
            ParentRow = null;
        }

        #region Public methodes

        public CollapsableGridRow Add()
        {
            CollapsableGridRow oNewRow = null;

            if (!(oRefGrid == null))
            {
                int iNewRow = oRefGrid.Rows.Add();

                oNewRow = new CollapsableGridRow(oRefGrid.Rows[iNewRow]);
                base.Add(oNewRow);

                return (oNewRow);
            }
            else
            {
                return (null);
            }
            
        }

        public new void Clear()
        {
            if (!(oRefGrid == null))
            {
                oRefGrid.Rows.Clear();
                base.Clear();
            }
        }

        #endregion
    }

    public enum CollapsableGridRowState
    {
        NoChildren = 0,
        Collapsed = 1,
        Expanded = 2,
    }
}
