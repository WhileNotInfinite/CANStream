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

        #region Public events

        public event EventHandler<DataGridViewCellEventArgs> SelectedRowChanged;

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

        private List<CollapsableGridRowState> RowsCollapsingContext;

        #endregion

        public Ctrl_CollapsableGrid()
        {
            InitializeComponent();

            DataGridViewPictureAndTextColumn oPicTxtColumn = new DataGridViewPictureAndTextColumn();
            oPicTxtColumn.Width = 21;
            oPicTxtColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            this.oGrid.Columns.Add(oPicTxtColumn);

            GridRows = new CollapsableGridRowCollection(this);
            RowsCollapsingContext = new List<CollapsableGridRowState>();
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

        private void oGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            OnSelectedRowChanged(e);
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

        #region Event handling methodes

        protected virtual void OnSelectedRowChanged(DataGridViewCellEventArgs e)
        {
            EventHandler<DataGridViewCellEventArgs> Handler = SelectedRowChanged;
            if (Handler != null)
            {
                Handler(this, e);
            }
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

        public void SaveRowsCollapsingContext()
        {
            RowsCollapsingContext = this.Rows.GetRowCollapsingContext();
        }

        public void RestoreRowsCollapsingContext()
        {
            this.Rows.RestoreRowCollapsingContext(RowsCollapsingContext);
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

        public int Level
        {
            get
            {
                return (mLevel);
            }

            internal set
            {
                mLevel = value;

                this.ThisRow.Cells[0].Style.Padding = new Padding(5 + (mLevel * 15), 0, 0, 5);
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

                    DataGridViewPictureAndTextCell oPicTxtCell = this.ThisRow.Cells[0] as DataGridViewPictureAndTextCell;

                    switch (eRowState)
                    {
                        case CollapsableGridRowState.Collapsed:

                            oPicTxtCell.Picture = this.CollapsableGrid.Img_RowStates.Images[1];
                            break;

                        case CollapsableGridRowState.Expanded:

                            oPicTxtCell.Picture = this.CollapsableGrid.Img_RowStates.Images[2];
                            break;

                        default:

                            oPicTxtCell.Picture = this.CollapsableGrid.Img_RowStates.Images[0];
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

        private int mLevel;

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

        internal void Remove_ChildRowAtIndex(int RowIndex)
        {
            for (int iRow = 0; iRow < Children.Count; iRow++)
            {
                if (Children[iRow].ThisRow.Index == RowIndex)
                {
                    Children.RemoveAt(iRow);
                    return;
                }
            }
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

        #region Internal methodes

        internal List<CollapsableGridRowState> GetRowCollapsingContext()
        {
            List<CollapsableGridRowState> CollapsingContext = new List<CollapsableGridRowState>();

            foreach(CollapsableGridRow oCRow in this)
            {
                CollapsingContext.Add(oCRow.RowState);

                if(oCRow.Children.Count>0)
                {
                    CollapsingContext.AddRange(oCRow.Children.GetRowCollapsingContext());
                }
            }

            return (CollapsingContext);
        }

        internal void RestoreRowCollapsingContext(List<CollapsableGridRowState>Context)
        {
            foreach(CollapsableGridRow oCRow in this)
            {
                if (oCRow.ThisRow.Index < Context.Count)
                {
                    oCRow.RowState = Context[oCRow.ThisRow.Index];

                    switch(oCRow.RowState)
                    {
                        case CollapsableGridRowState.Collapsed:

                            oCRow.Collapse();
                            break;

                        case CollapsableGridRowState.Expanded:

                            oCRow.Expand();
                            break;

                        default: //CollapsableGridRowState.NoChildren

                            break;
                    }

                    if (oCRow.Children.Count > 0)
                    {
                        oCRow.Children.RestoreRowCollapsingContext(Context);
                    }
                }
            }
        }

        #endregion

        #region Public methodes

        public CollapsableGridRow Add()
        {
            return (Add(""));
        }

        public CollapsableGridRow Add(string RowHeaderText)
        {
            if (oContainerObject.GetType().Equals(typeof(Ctrl_CollapsableGrid)))
            {
                DataGridView oGrid = ((Ctrl_CollapsableGrid)oContainerObject).DataGrid;

                int iNewRow = oGrid.Rows.Add();

                CollapsableGridRow oNewRow = new CollapsableGridRow(oGrid.Rows[iNewRow]);
                oNewRow.CollapsableGrid = (Ctrl_CollapsableGrid)oContainerObject;
                oNewRow.ThisRow.Cells[0].Value = RowHeaderText;
                oNewRow.Level = 0;
                oNewRow.RowState = CollapsableGridRowState.NoChildren;
                base.Add(oNewRow);

                oGrid.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.DisplayedCells);

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
                oNewRow.ThisRow.Cells[0].Value = RowHeaderText;
                oNewRow.Level = oRowContainer.Level + 1;
                oNewRow.RowState = CollapsableGridRowState.NoChildren;
                base.Add(oNewRow);

                oRowContainer.CollapsableGrid.DataGrid.AutoResizeColumn(0, DataGridViewAutoSizeColumnMode.DisplayedCells);

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

                    if (!(oChildRow.ThisRow.Index == -1))
                    {
                        oRowContainer.CollapsableGrid.Grid.Rows.Remove(oChildRow.ThisRow);
                    }
                }
            }
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

        public void Delete(int RowIndex)
        {
            CollapsableGridRow oCRow = GetCollapsableRowAtGridRowIndex(RowIndex);

            if (!(oCRow == null))
            {
                if(oCRow.Children.Count>0)
                {
                    oCRow.Children.Clear();
                }

                if (oContainerObject.GetType().Equals(typeof(Ctrl_CollapsableGrid)))
                {
                    DataGridView oGrid = ((Ctrl_CollapsableGrid)oContainerObject).DataGrid;

                    if (!(oCRow.ThisRow == null))
                    {
                        oGrid.Rows.Remove(oCRow.ThisRow);
                    }
                }
                else if (oContainerObject.GetType().Equals(typeof(CollapsableGridRow)))
                {
                    CollapsableGridRow oRowContainer = (CollapsableGridRow)oContainerObject;

                    if (!(oCRow.ThisRow == null))
                    {
                        oRowContainer.Remove_ChildRowAtIndex(oCRow.ThisRow.Index);
                        oRowContainer.CollapsableGrid.Grid.Rows.Remove(oCRow.ThisRow);
                    }
                }
            }
        }

        #endregion
    }

    public class DataGridViewPictureAndTextColumn : DataGridViewTextBoxColumn
    {
        public DataGridViewPictureAndTextColumn() : base()
        {
            this.CellTemplate = new DataGridViewPictureAndTextCell();
            this.ReadOnly = true;
        }
    }

    public class DataGridViewPictureAndTextCell : DataGridViewTextBoxCell
    {
        public Image Picture { get; set; }

        public int CellContentWidth { get; private set; }

        public DataGridViewPictureAndTextCell() : base()
        {
            Picture = null;
            this.Style.Alignment = DataGridViewContentAlignment.NotSet;
            this.Style.WrapMode = DataGridViewTriState.False;
            this.Style.Padding = new Padding(5, 0, 0, 0);
        }

        protected override void Paint(Graphics graphics, Rectangle clipBounds, Rectangle cellBounds, int rowIndex, DataGridViewElementStates cellState, object value, object formattedValue, string errorText, DataGridViewCellStyle cellStyle, DataGridViewAdvancedBorderStyle advancedBorderStyle, DataGridViewPaintParts paintParts)
        {
            const float SpacerWidth = 5;

            base.Paint(graphics, clipBounds, cellBounds, rowIndex, cellState, value, "", errorText, cellStyle, advancedBorderStyle, paintParts);

            string CellText = "";
            if (!(value == null))
            {
                CellText = value.ToString();
            }

            PointF Ptf = new PointF(
                                    (float)cellStyle.Padding.Left,
                                    0F
                                    );

            CellContentWidth = cellStyle.Padding.Left;

            if (!(Picture == null))
            {
                Ptf.Y = (float)(cellBounds.Y + ((cellBounds.Height / 2) - (Picture.Height / 2)));
                graphics.DrawImage(Picture, Ptf);
                CellContentWidth += Picture.Width;

                Ptf.X += ((float)Picture.Width + (float)SpacerWidth);
            }

            if (!(CellText == ""))
            {
                SizeF TxtSize = graphics.MeasureString(CellText, cellStyle.Font);

                Ptf.Y = (float)(cellBounds.Y + ((cellBounds.Height / 2) - (TxtSize.Height / 2)));

                Color TextColor = cellStyle.ForeColor;
                if ((cellState & DataGridViewElementStates.Selected)== DataGridViewElementStates.Selected)
                {
                    TextColor = cellStyle.SelectionForeColor;
                }

                Brush b = new SolidBrush(TextColor);

                graphics.DrawString(CellText, cellStyle.Font, b, Ptf);

                CellContentWidth += (int)(SpacerWidth + TxtSize.Width);
            }
        }
    }

    public enum CollapsableGridRowState
    {
        NoChildren = 0,
        Collapsed = 1,
        Expanded = 2,
    }
}
