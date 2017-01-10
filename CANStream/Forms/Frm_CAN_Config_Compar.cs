using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CANStream
{
    public partial class Frm_CAN_Config_Compar : Form
    {
        #region Private enums

        private enum ComparisonFile
        {
            None = 0,
            FileA = 1,
            FileB = 2,
        }

        #endregion

        #region Private constants

        private const int GRID_COL_PROP_NAME = 0;
        private const int GRID_COL_FILE_A = 1;
        private const int GRID_COL_FILE_B = 2;

        #endregion

        #region Private properties

        private int ComparedParamatersCount
        {
            get
            {
                return (mComparedParamatersCount);
            }

            set
            {
                mComparedParamatersCount = value;

                int Perc = 0;

                if (ParametersToCompareCount > 0)
                {
                    Perc = Math.Min((mComparedParamatersCount * 100 / ParametersToCompareCount), 100);

                    if (this.StatusBar_Progress.Value != Perc)
                    {
                        this.StatusBar_Progress.Value = Perc;
                    }
                }
            }
        }

        private int MergeCount
        {
            get
            {
                return (mMergeCount);
            }

            set
            {
                mMergeCount = value;

                this.StatusBar_Lbl_MergeCount.Text = mMergeCount.ToString() + " Elements merged";
            }
        }

        #endregion

        #region Private members

        private bool FileALoaded;
        private bool FileBLoaded;

        private CANMessagesConfiguration SingleBus_CANCfg_A;
        private CANMessagesConfiguration SingleBus_CANCfg_B;

        private MultipleContollerCANConfiguration MultipleBus_CANCfg_A;
        private MultipleContollerCANConfiguration MultipleBus_CANCfg_B;

        private int ParametersToCompareCount;
        private int mComparedParamatersCount;

        private int NDifferenceFound;
        private int mMergeCount;

        #endregion

        public Frm_CAN_Config_Compar()
        {
            InitializeComponent();

            FileALoaded = false;
            FileBLoaded = false;

            SingleBus_CANCfg_A = null;
            SingleBus_CANCfg_B = null;

            MultipleBus_CANCfg_A = null;
            MultipleBus_CANCfg_B = null;

            ParametersToCompareCount = 0;

            Init_ComparisonGrid();
        }

        #region Control events

        #region TS_Main

        private void TS_Btn_FileA_Open_Click(object sender, EventArgs e)
        {
            Open_ComparisonFile(ComparisonFile.FileA);
        }

        private void TS_Btn_FileB_Open_Click(object sender, EventArgs e)
        {
            Open_ComparisonFile(ComparisonFile.FileB);
        }

        #endregion

        #endregion

        #region Private methodes

        #region Collapsable grid methodes

        private void Init_ComparisonGrid()
        {
            CGrid_Comparison.Columns[GRID_COL_PROP_NAME].HeaderText = "Property";
            CGrid_Comparison.Columns.Add("Col_FileA", "File A");
            CGrid_Comparison.Columns.Add("Col_FileA", "File B");

            CGrid_Comparison.Columns[GRID_COL_PROP_NAME].ReadOnly = true;
            CGrid_Comparison.Columns[GRID_COL_FILE_A].ReadOnly = true;
            CGrid_Comparison.Columns[GRID_COL_FILE_B].ReadOnly = true;

            CGrid_Comparison.Columns[GRID_COL_FILE_A].SortMode = DataGridViewColumnSortMode.NotSortable;
            CGrid_Comparison.Columns[GRID_COL_FILE_B].SortMode = DataGridViewColumnSortMode.NotSortable;

            CGrid_Comparison.Columns[GRID_COL_PROP_NAME].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CGrid_Comparison.Columns[GRID_COL_FILE_A].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CGrid_Comparison.Columns[GRID_COL_FILE_B].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            CGrid_Comparison.Columns[GRID_COL_FILE_A].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CGrid_Comparison.Columns[GRID_COL_FILE_B].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            int GridWith = CGrid_Comparison.Width - CGrid_Comparison.Columns[0].Width - 25;

            CGrid_Comparison.Columns[GRID_COL_FILE_A].Width = GridWith / 2;
            CGrid_Comparison.Columns[GRID_COL_FILE_B].Width = GridWith / 2;
        }

        #endregion

        #region Files management

        private void Open_ComparisonFile(ComparisonFile eCompFile)
        {
            if (!(eCompFile == ComparisonFile.None))
            {
                Dlg_OpenFile.FileName = "";
                Dlg_OpenFile.FilterIndex = 1;
                Dlg_OpenFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";

                if(Dlg_OpenFile.ShowDialog().Equals(DialogResult.OK))
                {
                    string FileExt = Path.GetExtension(Dlg_OpenFile.FileName);

                    if(FileExt.Equals(".xcc")) //Single bus CAN configuration file
                    {
                        if(eCompFile== ComparisonFile.FileA) //Loading comparison file A
                        {
                            SingleBus_CANCfg_A = new CANMessagesConfiguration();
                            MultipleBus_CANCfg_A = null;

                            if(SingleBus_CANCfg_A.ReadCANConfigurationFile(Dlg_OpenFile.FileName))
                            {
                                if (FileBLoaded) //Comparison file B is loaded already
                                {
                                    if (MultipleBus_CANCfg_B != null) //Comparison file B is a multiple bus CAN config
                                    {
                                        SingleBus_CANCfg_B = null;
                                        MultipleBus_CANCfg_B = null;
                                        FileBLoaded = false;
                                        CGrid_Comparison.Rows.Clear();
                                        StatusBar_Lbl_FileB.Visible = false;
                                        StatusBar_Lbl_FileB.Text = "";
                                        return;
                                    }
                                }

                                StatusBar_Lbl_FileA.Visible = true;
                                StatusBar_Lbl_FileA.Text = "File A: " + Path.GetFileName(Dlg_OpenFile.FileName);

                                Show_Comparison();
                            }
                            else
                            {
                                MessageBox.Show("An error occured while reading the CAN configuration file A !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FileALoaded = false;
                                return;
                            }
                        }
                        else //Loading comparison file B
                        {
                            SingleBus_CANCfg_B = new CANMessagesConfiguration();
                            MultipleBus_CANCfg_B = null;

                            if (SingleBus_CANCfg_B.ReadCANConfigurationFile(Dlg_OpenFile.FileName))
                            {
                                if (FileALoaded) //Comparison file A is loaded already
                                {
                                    if (MultipleBus_CANCfg_A != null) //Comparison file A is a multiple bus CAN config
                                    {
                                        SingleBus_CANCfg_A = null;
                                        MultipleBus_CANCfg_A = null;
                                        FileALoaded = false;
                                        CGrid_Comparison.Rows.Clear();
                                        StatusBar_Lbl_FileA.Visible = false;
                                        StatusBar_Lbl_FileA.Text = "";
                                        return;
                                    }
                                }

                                StatusBar_Lbl_FileB.Visible = true;
                                StatusBar_Lbl_FileB.Text = "File B: " + Path.GetFileName(Dlg_OpenFile.FileName);

                                Show_Comparison();
                            }
                            else
                            {
                                MessageBox.Show("An error occured while reading the CAN configuration file B !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FileBLoaded = false;
                                return;
                            }
                        }
                    }
                    else if(FileExt.Equals(".mcb")) //Multiple bus CAN configuration file
                    {
                        if (eCompFile == ComparisonFile.FileA) //Loading comparison file A
                        {
                            SingleBus_CANCfg_A = null;
                            MultipleBus_CANCfg_A = new MultipleContollerCANConfiguration();

                            if (MultipleBus_CANCfg_A.ReadControllersConfiguaration(Dlg_OpenFile.FileName))
                            {
                                if (FileBLoaded) //Comparison file B is loaded already
                                {
                                    if (SingleBus_CANCfg_B != null) //Comparison file B is a single bus CAN config
                                    {
                                        SingleBus_CANCfg_B = null;
                                        MultipleBus_CANCfg_B = null;
                                        FileBLoaded = false;
                                        CGrid_Comparison.Rows.Clear();
                                        StatusBar_Lbl_FileB.Visible = false;
                                        StatusBar_Lbl_FileB.Text = "";
                                        return;
                                    }
                                }

                                StatusBar_Lbl_FileA.Visible = true;
                                StatusBar_Lbl_FileA.Text = Path.GetFileName(Dlg_OpenFile.FileName);

                                Show_Comparison();
                            }
                            else
                            {
                                MessageBox.Show("An error occured while reading the CAN configuration file A !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FileALoaded = false;
                                return;
                            }
                        }
                        else //Loading comparison file B
                        {
                            SingleBus_CANCfg_B = null;
                            MultipleBus_CANCfg_B = new MultipleContollerCANConfiguration();

                            if (MultipleBus_CANCfg_B.ReadControllersConfiguaration(Dlg_OpenFile.FileName))
                            {
                                if (FileALoaded) //Comparison file A is loaded already
                                {
                                    if (SingleBus_CANCfg_A != null) //Comparison file A is a single bus CAN config
                                    {
                                        SingleBus_CANCfg_A = null;
                                        MultipleBus_CANCfg_A = null;
                                        FileALoaded = false;
                                        CGrid_Comparison.Rows.Clear();
                                        StatusBar_Lbl_FileA.Visible = false;
                                        StatusBar_Lbl_FileA.Text = "";
                                        return;
                                    }
                                }

                                StatusBar_Lbl_FileB.Visible = true;
                                StatusBar_Lbl_FileB.Text = Path.GetFileName(Dlg_OpenFile.FileName);

                                Show_Comparison();
                            }
                            else
                            {
                                MessageBox.Show("An error occured while reading the CAN configuration file B !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                FileBLoaded = false;
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Unsuppported file extension !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }
                }
            }
        }

        #endregion

        #region Files comparison

        private void Show_Comparison()
        {
            CGrid_Comparison.Rows.Clear();

            Cursor = Cursors.WaitCursor;
            StatusBar_Progress.Value = 0;
            StatusBar_Progress.Visible = true;

            if (SingleBus_CANCfg_A!=null && SingleBus_CANCfg_B!=null)
            {
                Compare_SingleBusConfiguration();
            }
            else if(MultipleBus_CANCfg_A!=null && MultipleBus_CANCfg_B!=null)
            {
                Compare_MultipleBusConfiguration();
            }
            else
            {
                //Nothing to do
            }

            StatusBar_Progress.Visible = false;
            Cursor = Cursors.Default;
        }

        private void Compare_MultipleBusConfiguration()
        {

        }

        private void Compare_SingleBusConfiguration()
        {
            if (SingleBus_CANCfg_A != null && SingleBus_CANCfg_B != null)
            {
                CollapsableGridRow oCfgRow = CGrid_Comparison.Rows.Add();

                oCfgRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = "CAN Configuration";
                oCfgRow.ThisRow.Cells[GRID_COL_FILE_A].Value = Path.GetFileName(SingleBus_CANCfg_A.ConfigFilePath);
                oCfgRow.ThisRow.Cells[GRID_COL_FILE_B].Value = Path.GetFileName(SingleBus_CANCfg_B.ConfigFilePath);

                ParametersToCompareCount = Math.Max(SingleBus_CANCfg_A.GetParameterCount(), SingleBus_CANCfg_B.GetParameterCount());
                ComparedParamatersCount = 0;
                NDifferenceFound = 0;
                MergeCount = 0;

                StatusBar_Lbl_MergeCount.Visible = false;

                Compare_Objects(typeof(CANMessagesConfiguration), SingleBus_CANCfg_A, SingleBus_CANCfg_B, oCfgRow);

                StatusBar_Lbl_DiffCount.Visible = true;
                StatusBar_Lbl_DiffCount.Text = NDifferenceFound.ToString() + " Differences found";

                StatusBar_Lbl_MergeCount.Visible = true;
            }
        }

        private void Compare_Objects(Type oObjType, object ObjA, object ObjB, CollapsableGridRow oBaseRow)
        {
            if (!(oObjType == null))
            {
                foreach (FieldInfo oField in oObjType.GetFields())
                {
                    if (!(oField.IsInitOnly))
                    {
                        if (oField.FieldType.Name == "Nullable`1")
                        {
                            object oFieldA = null;
                            object oFieldB = null;

                            if (!(ObjA == null))
                            {
                                oFieldA = oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjA, null);
                            }

                            if(!(ObjB==null))
                            {
                                oFieldB = oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjB, null);
                            }

                            if (!(oFieldA == null && oFieldB == null))
                            {
                                Type oNullableType = Nullable.GetUnderlyingType(oField.FieldType);

                                CollapsableGridRow oNullableObjRow = oBaseRow.Children.Add();
                                oNullableObjRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = oField.Name;

                                Compare_Objects(oNullableType, oFieldA, oFieldB, oNullableObjRow);

                                if (oNullableObjRow.Children.Count == 0)
                                {
                                    oBaseRow.Children.Delete(oNullableObjRow.ThisRow.Index);
                                }
                            }
                        }
                        else if (oField.FieldType.Namespace.Equals("System"))
                        {
                            Compar_BasicType_Field(oObjType, oField.Name, ObjA, ObjB, oBaseRow);
                        }
                        else if (oField.FieldType.BaseType == typeof(Enum))
                        {
                            Compar_BasicType_Field(oObjType, oField.Name, ObjA, ObjB, oBaseRow);
                        }
                        else if (oField.FieldType == typeof(Color))
                        {
                            Color ColorA = Color.Empty;
                            Color ColorB = Color.Empty;

                            if(!(ObjA==null))
                            {
                                ColorA = (Color)oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjA, null);
                            }

                            if(!(ObjB==null))
                            {
                                ColorB = (Color)oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjB, null);
                            }

                            Compar_ColorField(
                                               ColorA,
                                               ColorB,
                                               oField.Name,
                                               oBaseRow
                                              );

                        }
                        else if (oField.FieldType.Namespace.Equals("System.Collections.Generic"))
                        {
                            CollapsableGridRow oListRow = oBaseRow.Children.Add();
                            oListRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = oField.Name;

                            Compar_List_Field(oField, ObjA, ObjB, oListRow);

                            if (oListRow.Children.Count == 0)
                            {
                                oBaseRow.Children.Delete(oListRow.ThisRow.Index);
                            }
                        }
                        else if (oField.FieldType.BaseType == typeof(System.ValueType)) //Structure
                        {
                            Compare_CustomType(oObjType, ObjA, ObjB, oBaseRow, oField);
                        }
                        else if (oField.FieldType.BaseType == typeof(object))
                        {
                            Compare_CustomType(oObjType, ObjA, ObjB, oBaseRow, oField);
                        }
                    }
                }
            }
        }

        private void Compare_CustomType(Type oObjType, object ObjA, object ObjB, CollapsableGridRow oBaseRow, FieldInfo oField)
        {
            CollapsableGridRow oObjRow = oBaseRow.Children.Add();
            oObjRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = oField.Name;

            if (!(ObjA == null || ObjB == null))
            {
                Compare_Objects(oField.FieldType,
                                oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjA, null),
                                oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjB, null),
                                oObjRow);
            }
            else
            {
                if(ObjA==null)
                {
                    Compare_Objects(oField.FieldType,
                                null,
                                oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjB, null),
                                oObjRow);
                }

                if(ObjB==null)
                {
                    Compare_Objects(oField.FieldType,
                                oObjType.InvokeMember(oField.Name, BindingFlags.GetField, null, ObjA, null),
                                null,
                                oObjRow);
                }
            }

            if (oObjRow.Children.Count == 0)
            {
                oBaseRow.Children.Delete(oObjRow.ThisRow.Index);
            }
        }

        private void Compar_List_Field(FieldInfo oListField, object ObjA, object ObjB, CollapsableGridRow oBaseRow)
        {
            if (oListField.FieldType.GetGenericTypeDefinition().Name.Equals("List`1"))
            {
                object ListA = null;
                object ListB = null;

                int CountA = -1;
                int CountB = -1;

                if (!(ObjA == null))
                {
                    ListA = oListField.GetValue(ObjA);

                    if (!(ListA == null))
                    {
                        CountA = (int)ListA.GetType().GetProperty("Count").GetValue(ListA);
                    }
                }

                if (!(ObjB == null))
                {
                    ListB = oListField.GetValue(ObjB);

                    if (!(ListB == null))
                    {
                        CountB = (int)ListA.GetType().GetProperty("Count").GetValue(ListB);
                    }
                }

                //Compare all items of ListA
                for (int i = 0; i < CountA; i++)
                {
                    object[] Index = { i };

                    object ItemA = ListA.GetType().GetProperty("Item").GetValue(ListA, Index);
                    object ItemB = null;

                    if (i < CountB)
                    {
                        ItemB = ListB.GetType().GetProperty("Item").GetValue(ListB, Index);
                    }

                    CollapsableGridRow oItemRow = oBaseRow.Children.Add();
                    oItemRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = ItemA.GetType().Name + " #" + (i + 1).ToString();

                    if (!(ItemB == null)) //An item exists at the current index in ListB
                    {
                        Compare_Objects(ItemA.GetType(), ItemA, ItemB, oItemRow);

                        if (oItemRow.Children.Count == 0)
                        {
                            oBaseRow.Children.Delete(oItemRow.ThisRow.Index);
                        }
                    }
                    else //No item in ListB at the current index
                    {
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ItemA.GetType().Name; //TODO: Get something more representative of the item such as its name or identifier
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_B].Value = "Null";
                        Color_GridRow(oItemRow.ThisRow);
                    }

                    if (ItemA.GetType() == typeof(CANParameter))
                    {
                        ComparedParamatersCount++;
                    }
                }

                //Compare remaining ListB items if any
                if (CountB > CountA)
                {
                    object[] Index = { 0 };
                    object ItemB = ListB.GetType().GetProperty("Item").GetValue(ListB, Index);

                    for (int i = CountA; i < CountB; i++)
                    {
                        CollapsableGridRow oItemRow = oBaseRow.Children.Add();
                        oItemRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = ItemB.GetType().Name + " #" + (i + 1).ToString();
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_A].Value = "Null";
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ItemB.GetType().Name; //TODO: Get something more representative of the item such as its name or identifier
                        Color_GridRow(oItemRow.ThisRow);

                        if (ItemB.GetType() == typeof(CANParameter))
                        {
                            ComparedParamatersCount++;
                        }
                    }
                }
            }
        }

        private void Compar_BasicType_Field(Type oObjType, string FieldName, object ObjA, object ObjB, CollapsableGridRow oBaseRow)
        {
            if (!(FieldName.Equals("")))
            {
                string sValA = "Null";
                string sValB = "Null";

                if (ObjA != null && ObjB != null)
                {
                    object ValA = oObjType.InvokeMember(FieldName, BindingFlags.GetField, null, ObjA, null);

                    if (ValA != null)
                    {
                        sValA = ValA.ToString();
                    }

                    object ValB = oObjType.InvokeMember(FieldName, BindingFlags.GetField, null, ObjB, null);

                    if (ValB != null)
                    {
                        sValB = ValB.ToString();
                    }
                }
                else
                {
                    if (ObjA == null)
                    {
                        object ValB = oObjType.InvokeMember(FieldName, BindingFlags.GetField, null, ObjB, null);

                        if (ValB != null)
                        {
                            sValB = ValB.ToString();
                        }
                    }

                    if (ObjB == null)
                    {
                        object ValA = oObjType.InvokeMember(FieldName, BindingFlags.GetField, null, ObjA, null);

                        if (ValA != null)
                        {
                            sValA = ValA.ToString();
                        }
                    }
                }

                if (sValA != sValB)
                {
                    CollapsableGridRow oPropRow = oBaseRow.Children.Add();
                    oPropRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = FieldName;
                    oPropRow.ThisRow.Cells[GRID_COL_FILE_A].Value = sValA;
                    oPropRow.ThisRow.Cells[GRID_COL_FILE_B].Value = sValB;
                    Color_GridRow(oPropRow.ThisRow);
                    NDifferenceFound++;
                }
            }
        }

        private void Compar_ColorField(Color ColorA, Color ColorB, string FieldName, CollapsableGridRow oBaseRow)
        {
            if (ColorA.ToArgb() != ColorB.ToArgb())
            {
                CollapsableGridRow oColorRow = oBaseRow.Children.Add();
                oColorRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = FieldName;
                oColorRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ColorA.ToKnownColor().ToString();
                oColorRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ColorB.ToKnownColor().ToString();
                NDifferenceFound++;
            }
        }

        private void Color_GridRow(DataGridViewRow oRow)
        {
            Color DIFF_BACKCOLOR = Color.Tomato;
            Color DIFF_FORECOLOR = Color.Black;

            if (!(oRow == null))
            {
                for (int i = 1; i < oRow.Cells.Count; i++)
                {
                    oRow.Cells[i].Style.BackColor = DIFF_BACKCOLOR;
                    oRow.Cells[i].Style.ForeColor = DIFF_FORECOLOR;
                }
            }
        }

        #endregion

        #endregion
    }
}
