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

        [Browsable(false)]
        public DataGridView Grid
        {
            get
            {
                return (this.oGrid);
            }
        }

        #endregion

        #region Internal properties

        internal DataGridView DataGrid
        {
            get
            {
                return (this.oGrid);
            }
        }

        internal ImageList Img_RowStates
        {
            get
            {
                return (Img_RowState);
            }
        }

        #endregion

        #region Private members

        private CollapsableGridRowCollection GridRows;

        #endregion

        public Ctrl_CollapsableGrid()
        {
            InitializeComponent();

            GridRows = new CollapsableGridRowCollection(this);
        }

        #region Control events

        private void oGrid_Resize(object sender, EventArgs e)
        {
            if (oGrid.Columns.Count > 1)
            {
                oGrid.Columns.GetLastColumn(DataGridViewElementStates.None, DataGridViewElementStates.None).Width = oGrid.Width - 500;
            }
        }

        private void oGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                CollapsableGridRow oRow = Get_GridRow(e.RowIndex);

                if (!(oRow == null))
                {
                    if (!(oRow.RowState == CollapsableGridRowState.NoChildren))
                    {
                        if (oRow.RowState == CollapsableGridRowState.Collapsed)
                        {
                            oRow.Expand();
                        }
                        else
                        {
                            oRow.Collapse();
                        }
                    }
                }
            }
        }

        #endregion

        #region Private methodes

        private CollapsableGridRow Get_GridRow(int RowIndex)
        {
            if (RowIndex >= 0 && RowIndex < oGrid.Rows.Count)
            {
                foreach (CollapsableGridRow oRow in Rows)
                {
                    CollapsableGridRow oRowFound = oRow.Get_ChildRowAtIndex(RowIndex);

                    if (!(oRowFound == null))
                    {
                        return (oRowFound);
                    }
                }
            }

            return (null);
        }

        #endregion

        #region Public methodes

        public void ExpandAllRows()
        {
            foreach (CollapsableGridRow oRow in Rows)
            {
                oRow.ExpandAll();
            }
        }

        public void CollapseAllRows()
        {
            foreach(CollapsableGridRow oRow in Rows)
            {
                oRow.Collapse();
            }
        }

        #endregion
    }

    public class CollapsableGridRow
    {
        #region Public Properties

        public Ctrl_CollapsableGrid CollapsableGrid
        {
            get
            {
                return (oCollapsableGrid);
            }

            internal set
            {
                oCollapsableGrid = value;
            }
        }

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

        public CollapsableGridRowState RowState
        {
            get
            {
                return (eRowState);
            }

            set
            {
                if ((value != eRowState) || (ThisRow.Cells[0].Value == null))
                {
                    eRowState = value;

                    switch (eRowState)
                    {
                        case CollapsableGridRowState.Collapsed:

                            this.ThisRow.Cells[0].Value = this.CollapsableGrid.Img_RowStates.Images[1];
                            break;

                        case CollapsableGridRowState.Expanded:

                            this.ThisRow.Cells[0].Value = this.CollapsableGrid.Img_RowStates.Images[2];
                            break;

                        default:

                            this.ThisRow.Cells[0].Value = this.CollapsableGrid.Img_RowStates.Images[0];
                            break;

                    }
                }
            }
        }

        #endregion

        #region Private members

        private Ctrl_CollapsableGrid oCollapsableGrid;

        private DataGridViewRow GridRow;

        private CollapsableGridRow RowParent;

        private CollapsableGridRowCollection RowChildren;

        private CollapsableGridRowState eRowState;

        #endregion

        #region Constructors

        public CollapsableGridRow()
        {
            oCollapsableGrid = null;
            GridRow = null;
            RowParent = null;
            RowChildren = new CollapsableGridRowCollection(null);
            eRowState = CollapsableGridRowState.NoChildren;
        }

        public CollapsableGridRow(DataGridViewRow DataGridRow)
        {
            GridRow = DataGridRow;
            RowParent = null;
            RowChildren = new CollapsableGridRowCollection(this);
            eRowState = CollapsableGridRowState.NoChildren;
        }

        #endregion

        #region Internal methodes

        internal CollapsableGridRow Get_ChildRowAtIndex(int RowIndex)
        {
            if (this.ThisRow.Index == RowIndex)
            {
                return (this);
            }

            foreach (CollapsableGridRow oChildRow in Children)
            {
                if (oChildRow.ThisRow.Index == RowIndex)
                {
                    return (oChildRow);
                }
                else
                {
                    if (oChildRow.Children.Count > 0)
                    {
                        CollapsableGridRow oGranChildRow = oChildRow.Get_ChildRowAtIndex(RowIndex);

                        if (!(oGranChildRow == null))
                        {
                            return (oGranChildRow);
                        }
                    }
                }
            }

            return (null);
        }
        
        internal int Get_LastChildIndex()
        {
            int LastIndex = this.ThisRow.Index;

            if(this.Children.Count>0)
            {
                LastIndex = this.Children.Last().Get_LastChildIndex();
            }

            return (LastIndex);
        }

        #endregion

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

                this.RowState = CollapsableGridRowState.Collapsed;
            }
        }

        public void Expand()
        {
            if (this.RowChildren.Count > 0)
            {
                foreach (CollapsableGridRow oChildRow in RowChildren)
                {
                    oChildRow.ThisRow.Visible = true;
                }

                this.RowState = CollapsableGridRowState.Expanded;
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

                this.RowState = CollapsableGridRowState.Expanded;
            }
        }

        #endregion
    }

    public class CollapsableGridRowCollection : List<CollapsableGridRow>
    {
        #region Private members

        private object oContainerObject;

        #endregion

        public CollapsableGridRowCollection(object Container)
        {
            oContainerObject = Container;
        }

        #region Public methodes

        public CollapsableGridRow Add()
        {
            if (oContainerObject.GetType().Equals(typeof(Ctrl_CollapsableGrid)))
            {
                DataGridView oGrid = ((Ctrl_CollapsableGrid)oContainerObject).DataGrid;

                int iNewRow = oGrid.Rows.Add();

                CollapsableGridRow oNewRow = new CollapsableGridRow(oGrid.Rows[iNewRow]);
                oNewRow.CollapsableGrid = (Ctrl_CollapsableGrid)oContainerObject;
                oNewRow.RowState = CollapsableGridRowState.NoChildren;
                base.Add(oNewRow);

                return (oNewRow);
            }
            else if (oContainerObject.GetType().Equals(typeof(CollapsableGridRow)))
            {
                CollapsableGridRow oRowContainer = (CollapsableGridRow)oContainerObject;

                //int iNewRow = oRowContainer.ThisRow.Index + oRowContainer.Children.Count + 1;
                int iNewRow = oRowContainer.Get_LastChildIndex() + 1;
                oRowContainer.ThisRow.DataGridView.Rows.Insert(iNewRow, 1);

                CollapsableGridRow oNewRow = new CollapsableGridRow(oRowContainer.ThisRow.DataGridView.Rows[iNewRow]);
                oNewRow.CollapsableGrid = oRowContainer.CollapsableGrid;
                oNewRow.Parent = oRowContainer;
                oRowContainer.RowState = CollapsableGridRowState.Expanded;
                oNewRow.RowState = CollapsableGridRowState.NoChildren;
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
            if (oContainerObject.GetType().Equals(typeof(Ctrl_CollapsableGrid)))
            {
                DataGridView oGrid = ((Ctrl_CollapsableGrid)oContainerObject).DataGrid;

                oGrid.Rows.Clear();
                base.Clear();
            }
            else if (oContainerObject.GetType().Equals(typeof(CollapsableGridRow)))
            {
                CollapsableGridRow oRowContainer = (CollapsableGridRow)oContainerObject;

                foreach(CollapsableGridRow oChildRow in oRowContainer.Children)
                {
                    oChildRow.Children.Clear();
                }

                oRowContainer.CollapsableGrid.Grid.Rows.Remove(oRowContainer.ThisRow);
            }
            
            //TODO: Remove old code
            /*
            if (oContainerObject.GetType().Equals(typeof(DataGridView)))
            {
                DataGridView oGrid = (DataGridView)oContainerObject;

                oGrid.Rows.Clear();
                base.Clear();
            }
            */
        }

        public CollapsableGridRow GetCollapsableRowAtGridRowIndex(int RowIndex)
        {
            foreach (CollapsableGridRow oCRow in this)
            {
                if(oCRow.ThisRow.Index==RowIndex)
                {
                    return (oCRow);
                }
                else
                {
                    if(oCRow.Children.Count>0)
                    {
                        CollapsableGridRow oRowFound = oCRow.Children.GetCollapsableRowAtGridRowIndex(RowIndex);

                        if(!(oRowFound==null))
                        {
                            return (oRowFound);
                        }
                    }
                }
            }

            return (null);
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
