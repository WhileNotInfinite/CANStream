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
        #region Private classes

        private class PropertyFilterItem
        {
            #region Public members

            public string ObjectName;
            public string PropertyName;
            public bool Value;
            public bool Visible;
            public List<PropertyFilterItem> SubItems;

            #endregion

            public PropertyFilterItem()
            {
                SubItems = new List<PropertyFilterItem>();
            }
        }

        private class PropertiesComparisonFilter
        {
            #region Public members

            public List<PropertyFilterItem> PropertiesFilter;

            #endregion

            public PropertiesComparisonFilter()
            {
                PropertiesFilter = new List<PropertyFilterItem>();
            }

            public PropertiesComparisonFilter(Type oBaseType)
            {
                PropertiesFilter = new List<PropertyFilterItem>();
                Create_PropertiesList(oBaseType, PropertiesFilter);
            }

            #region Private methodes

            private void Create_PropertiesList(Type ObjType, List<PropertyFilterItem> oItemList)
            {
                foreach (FieldInfo oField in ObjType.GetFields())
                {
                    PropertyFilterItem sProp = new PropertyFilterItem();

                    sProp.ObjectName = ObjType.Name;
                    sProp.PropertyName = oField.Name;
                    sProp.Value = true;
                    sProp.Visible = true;

                    oItemList.Add(sProp);

                    if (oField.FieldType.Name == "Nullable`1")
                    {
                        Type NullableType = Nullable.GetUnderlyingType(oField.FieldType);
                        Create_PropertiesList(NullableType, sProp.SubItems);
                    }
                    else if (oField.FieldType.Namespace.Equals("System.Collections.Generic"))
                    {
                        Type ListItemType = oField.FieldType.GetProperty("Item").PropertyType;
                        Create_PropertiesList(ListItemType, sProp.SubItems);
                    }
                    else if (oField.FieldType.BaseType == typeof(System.ValueType)) //Structure
                    {
                        Create_PropertiesList(oField.FieldType, sProp.SubItems);
                    }
                    else if (oField.FieldType.BaseType == typeof(object))
                    {
                        Create_PropertiesList(oField.FieldType, sProp.SubItems);
                    }
                }
            }

            #endregion
        }

        #endregion

        #region Private enums

        private enum ComparisonFile
        {
            None = 0,
            FileA = 1,
            FileB = 2,
        }

        private enum MergeDirection
        {
            None = 0,
            From_A_To_B = 1,
            From_B_To_A = 2,
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

        private int NDifferenceFound
        {
            get
            {
                return (mNDifferenceFound);
            }

            set
            {
                mNDifferenceFound = value;

                StatusBar_Lbl_DiffCount.Text = mNDifferenceFound.ToString() + " Differences found";

                if (mNDifferenceFound > 0)
                {
                    TS_Btn_MergeAll_A_to_B.Enabled = true;
                    TS_Btn_MergeAll_B_to_A.Enabled = true;
                    StatusBar_Lbl_DiffCount.ForeColor = Color.Red;
                }
                else
                {
                    TS_Btn_MergeAll_A_to_B.Enabled = false;
                    TS_Btn_MergeAll_B_to_A.Enabled = false;
                    StatusBar_Lbl_DiffCount.ForeColor = Color.Green;
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

        private bool MergeEnabled
        {
            get
            {
                return (mMergeEnabled);
            }

            set
            {
                mMergeEnabled = value;

                TS_Btn_Merge_A_to_B.Enabled = mMergeEnabled;
                TS_Btn_Merge_B_to_A.Enabled = mMergeEnabled;
            }
        }

        private bool FileAModified
        {
            get
            {
                return (mFileAModified);
            }

            set
            {
                mFileAModified = value;

                TS_Btn_FileA_Save.Enabled = mFileAModified;
                TS_Btn_SaveAll.Enabled = (mFileAModified && FileBModified);
            }
        }

        private bool FileBModified
        {
            get
            {
                return (mFileBModified);
            }

            set
            {
                mFileBModified = value;
                TS_Btn_SaveAll.Enabled = (FileAModified && mFileBModified);
                TS_Btn_FileB_Save.Enabled = mFileBModified;
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

        private int mNDifferenceFound;
        private int mMergeCount;

        private bool mMergeEnabled;
        private bool mFileAModified;
        private bool mFileBModified;

        private PropertiesComparisonFilter oPropertiesFilter;

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

            oPropertiesFilter = new PropertiesComparisonFilter(typeof(CANMessagesConfiguration));
        }

        #region Control events

        #region Form

        private void Frm_CAN_Config_Compar_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(FileAModified)
            {
                DialogResult Rep = MessageBox.Show("Comparison file A has been modified\nDo you want save modifications prior to close the comparison ?",
                                                    Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch(Rep)
                {
                    case DialogResult.Yes:
                        Save_ComparisonFile(ComparisonFile.FileA, false);
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;

                    default: //No
                        break;
                }
            }

            if(FileBModified)
            {
                DialogResult Rep = MessageBox.Show("Comparison file B has been modified\nDo you want save modifications prior to close the comparison ?",
                                                    Application.ProductName, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                switch (Rep)
                {
                    case DialogResult.Yes:
                        Save_ComparisonFile(ComparisonFile.FileB, false);
                        break;

                    case DialogResult.Cancel:
                        e.Cancel = true;
                        break;

                    default: //No
                        break;
                }
            }
        }

        #endregion

        #region TS_Main

        private void TS_Btn_FileA_Open_Click(object sender, EventArgs e)
        {
            Open_ComparisonFile(ComparisonFile.FileA);
        }

        private void TS_Btn_FileA_Save_Click(object sender, EventArgs e)
        {
            Save_ComparisonFile(ComparisonFile.FileA);
        }

        private void TS_Btn_FileB_Open_Click(object sender, EventArgs e)
        {
            Open_ComparisonFile(ComparisonFile.FileB);
        }

        private void TS_Btn_FileB_Save_Click(object sender, EventArgs e)
        {
            Save_ComparisonFile(ComparisonFile.FileB);
        }

        private void TS_Btn_SaveAll_Click(object sender, EventArgs e)
        {
            Save_AllFiles();
        }

        private void TS_Btn_MergeAll_B_to_A_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want merge all differences from the file B to the file A ?",
                               Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Merge_AllProperties(CGrid_Comparison.Rows.GetCollapsableRowAtGridRowIndex(0), MergeDirection.From_B_To_A);
            }
        }

        private void TS_Btn_Merge_B_to_A_Click(object sender, EventArgs e)
        {
            if (!(CGrid_Comparison.Grid.SelectedCells == null))
            {
                CollapsableGridRow oCRow = CGrid_Comparison.Rows.GetCollapsableRowAtGridRowIndex(CGrid_Comparison.Grid.SelectedCells[0].RowIndex);

                if (!(oCRow == null))
                {
                    Merge_Property(oCRow, MergeDirection.From_B_To_A);
                }
            }
        }

        private void TS_Btn_Merge_A_to_B_Click(object sender, EventArgs e)
        {
            if (!(CGrid_Comparison.Grid.SelectedCells == null))
            {
                CollapsableGridRow oCRow = CGrid_Comparison.Rows.GetCollapsableRowAtGridRowIndex(CGrid_Comparison.Grid.SelectedCells[0].RowIndex);

                if (!(oCRow == null))
                {
                    Merge_Property(oCRow, MergeDirection.From_A_To_B);
                }
            }
        }

        private void TS_Btn_MergeAll_A_to_B_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want merge all differences from the file A to the file B ?",
                               Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Merge_AllProperties(CGrid_Comparison.Rows.GetCollapsableRowAtGridRowIndex(0), MergeDirection.From_A_To_B);
            }
        }

        private void TS_Btn_RefreshCompar_Click(object sender, EventArgs e)
        {
            Show_Comparison();
        }

        #endregion

        #region Grid

        private void CGrid_Comparison_SelectedRowChanged(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow oRow = CGrid_Comparison.Grid.Rows[e.RowIndex];

            if(!(oRow.Tag==null))
            {
                MergeEnabled = (bool)oRow.Tag;
            }
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

        private void Save_ComparisonFile(ComparisonFile eCompFile)
        {
            Save_ComparisonFile(eCompFile, true);
        }

        private void Save_ComparisonFile(ComparisonFile eCompFile, bool RefreshComparison)
        {
            bool bMultipleBusCfg;
            string OriginalConfigPath;
            string BackupConfigPath;

            CANMessagesConfiguration oSingleBusConfig = null;
            MultipleContollerCANConfiguration oMultipleBusConfig = null;
            
            Dlg_SaveFile.InitialDirectory = CANStreamTools.MyDocumentPath + "\\CANStream\\CAN Configuration";

            if (MultipleBus_CANCfg_A != null) //Comparison of multiple buses CAN configurations
            {
                Dlg_SaveFile.Filter = "Multiple CAN bus configuration|*.mcb";
                bMultipleBusCfg = true;
            }
            else //Comparison of single CAN configurations
            {
                Dlg_SaveFile.Filter = "CAN Configuration file|*.xcc";
                bMultipleBusCfg = false;
            }

            switch (eCompFile)
            {
                case ComparisonFile.FileA:
                    {
                        if(bMultipleBusCfg)
                        {
                            oMultipleBusConfig = MultipleBus_CANCfg_A;
                            OriginalConfigPath = MultipleBus_CANCfg_A.FilePath;
                        }
                        else
                        {
                            oSingleBusConfig = SingleBus_CANCfg_A;
                            OriginalConfigPath = SingleBus_CANCfg_A.ConfigFilePath;
                        }
                    }
                    break;

                case ComparisonFile.FileB:
                    {
                        if (bMultipleBusCfg)
                        {
                            oMultipleBusConfig = MultipleBus_CANCfg_B;
                            OriginalConfigPath = MultipleBus_CANCfg_B.FilePath;
                        }
                        else
                        {
                            oSingleBusConfig = SingleBus_CANCfg_B;
                            OriginalConfigPath = SingleBus_CANCfg_B.ConfigFilePath;
                        }
                    }
                    break;

                default:
                    return;
            }

            if (!(oMultipleBusConfig == null && oSingleBusConfig == null))
            {
                Dlg_SaveFile.FileName = Path.GetFileNameWithoutExtension(OriginalConfigPath);

                if (Dlg_SaveFile.ShowDialog() == DialogResult.OK)
                {
                    BackupConfigPath = Get_BackupFilePath(OriginalConfigPath);

                    File.Copy(OriginalConfigPath, BackupConfigPath, true);

                    if (oMultipleBusConfig != null)
                    {
                        oMultipleBusConfig.WriteControllersConfiguration(Dlg_SaveFile.FileName);
                    }
                    else
                    {
                        oSingleBusConfig.WriteCANConfigurationFile(Dlg_SaveFile.FileName);
                    }

                    if (eCompFile == ComparisonFile.FileA)
                    {
                        FileAModified = false;
                    }
                    else
                    {
                        FileBModified = false;
                    }

                    if (RefreshComparison)
                    {
                        Show_Comparison();
                    }
                }
            }
        }

        private void Save_AllFiles()
        {
            Save_ComparisonFile(ComparisonFile.FileA, false);
            Save_ComparisonFile(ComparisonFile.FileB, true);
        }

        private string Get_BackupFilePath(string OriginalFilePath)
        {
            string BackupFileName = Path.GetFileNameWithoutExtension(OriginalFilePath);

            string sDate = DateTime.Now.ToShortDateString().Replace("/", "");
            string sTime = DateTime.Now.ToShortTimeString().Replace(":", "");
            BackupFileName += ("_" + sDate + "_" + sTime);

            return (Path.GetDirectoryName(OriginalFilePath) + "\\" + BackupFileName + ".bak");
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
                oCfgRow.ThisRow.Tag = false;

                ParametersToCompareCount = Math.Max(SingleBus_CANCfg_A.GetParameterCount(), SingleBus_CANCfg_B.GetParameterCount());
                ComparedParamatersCount = 0;
                NDifferenceFound = 0;
                MergeCount = 0;

                StatusBar_Lbl_DiffCount.Visible = false;
                StatusBar_Lbl_MergeCount.Visible = false;

                Compare_Objects(typeof(CANMessagesConfiguration), SingleBus_CANCfg_A, SingleBus_CANCfg_B, oCfgRow);

                StatusBar_Lbl_DiffCount.Visible = true;
                StatusBar_Lbl_MergeCount.Visible = true;
                TS_Btn_RefreshCompar.Enabled = true;
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
                                oNullableObjRow.ThisRow.Tag = false;

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
                            Compar_ColorField(oObjType, oField.Name, ObjA, ObjB, oBaseRow);
                        }
                        else if (oField.FieldType.Namespace.Equals("System.Collections.Generic"))
                        {
                            CollapsableGridRow oListRow = oBaseRow.Children.Add();
                            oListRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = oField.Name;
                            oListRow.ThisRow.Tag = false;

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

            oObjRow.ThisRow.Cells[GRID_COL_PROP_NAME].Tag = oField.Name;
            oObjRow.ThisRow.Cells[GRID_COL_FILE_A].Tag = ObjA;
            oObjRow.ThisRow.Cells[GRID_COL_FILE_B].Tag = ObjB;

            oObjRow.ThisRow.Tag = false;

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
                    object ItemB = Find_ItemInList(ItemA, ListB);

                    CollapsableGridRow oItemRow = oBaseRow.Children.Add();
                    oItemRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = ItemA.GetType().Name + " #" + (i + 1).ToString();

                    string Item_KeyFielName = Get_ObjetKeyFieldName(ItemA);
                    string ItemA_KeyFieldValue = ItemA.GetType().GetField(Item_KeyFielName).GetValue(ItemA).ToString();
                    oItemRow.ThisRow.Cells[GRID_COL_FILE_A].Value = Item_KeyFielName + ": " + ItemA_KeyFieldValue;

                    oItemRow.ThisRow.Tag = false;

                    oItemRow.ThisRow.Cells[GRID_COL_PROP_NAME].Tag = "Item #" + i.ToString();
                    oItemRow.ThisRow.Cells[GRID_COL_FILE_A].Tag = ListA;
                    oItemRow.ThisRow.Cells[GRID_COL_FILE_B].Tag = ListB;

                    if (!(ItemB == null)) //An item exists at the current index in ListB
                    {
                        string ItemB_KeyFieldValue = ItemB.GetType().GetField(Item_KeyFielName).GetValue(ItemB).ToString();
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_B].Value = Item_KeyFielName + ": " + ItemB_KeyFieldValue;

                        Compare_Objects(ItemA.GetType(), ItemA, ItemB, oItemRow);

                        if (oItemRow.Children.Count == 0)
                        {
                            oBaseRow.Children.Delete(oItemRow.ThisRow.Index);
                        }
                    }
                    else //No item in ListB at the current index
                    {
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_B].Value = "Null";
                        oItemRow.ThisRow.Tag = true;
                        Color_GridRow(oItemRow.ThisRow);
                    }

                    if (ItemA.GetType() == typeof(CANParameter))
                    {
                        ComparedParamatersCount++;
                    }
                }

                //Compare remaining ListB items if any
                for (int i = 0; i < CountB; i++)
                {
                    object[] Index = { i };
                    object ItemB = ListB.GetType().GetProperty("Item").GetValue(ListB, Index);

                    object ItemA = Find_ItemInList(ItemB, ListA);

                    if (ItemA == null) //Otherwise it has been compared already in the 1st loop
                    {
                        string Item_KeyFielName = Get_ObjetKeyFieldName(ItemB);
                        string ItemB_KeyFieldValue = ItemB.GetType().GetField(Item_KeyFielName).GetValue(ItemB).ToString();

                        CollapsableGridRow oItemRow = oBaseRow.Children.Add();
                        oItemRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = ItemB.GetType().Name + " #" + (i + 1).ToString();
                        oItemRow.ThisRow.Tag = true;

                        oItemRow.ThisRow.Cells[GRID_COL_PROP_NAME].Tag = "Item #" + i.ToString();
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_A].Tag = ListA;
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_B].Tag = ListB;

                        oItemRow.ThisRow.Cells[GRID_COL_FILE_A].Value = "Null";
                        oItemRow.ThisRow.Cells[GRID_COL_FILE_B].Value = Item_KeyFielName + ": " + ItemB_KeyFieldValue;
                        Color_GridRow(oItemRow.ThisRow);

                        if (ItemB.GetType() == typeof(CANParameter))
                        {
                            ComparedParamatersCount++;
                        }
                    }
                }                
            }
        }

        public string Get_ObjetKeyFieldName(object Obj)
        {
            string KeyFieldName = "";

            if (Obj.GetType() == typeof(CANMessage))
            {
                KeyFieldName = "Identifier";
            }
            else if (Obj.GetType() == typeof(CANParameter))
            {
                KeyFieldName = "Name";
            }
            else if (Obj.GetType() == typeof(EnumerationValue))
            {
                KeyFieldName = "Value";
            }

            return (KeyFieldName);
        }

        private object Find_ItemInList(object Item, object List)
        {
            Type oItemType = Item.GetType();
            string KeyFieldName = Get_ObjetKeyFieldName(Item);

            object KeyFieldValue = oItemType.GetField(KeyFieldName).GetValue(Item);

            Type oListType = List.GetType();
            int ListCount = (int)(oListType.GetProperty("Count").GetValue(List));

            for (int i = 0; i < ListCount; i++)
            {
                object[] Index = { i };
                object oListIt = oListType.GetProperty("Item").GetValue(List, Index);

                if (oItemType.GetField(KeyFieldName).GetValue(oListIt).ToString().Equals(KeyFieldValue.ToString()))
                {
                    return (oListIt);
                }
            }

            return (null);
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
                    oPropRow.ThisRow.Cells[GRID_COL_PROP_NAME].Tag = FieldName;
                    oPropRow.ThisRow.Tag = true;

                    oPropRow.ThisRow.Cells[GRID_COL_FILE_A].Value = sValA;
                    oPropRow.ThisRow.Cells[GRID_COL_FILE_B].Value = sValB;

                    oPropRow.ThisRow.Cells[GRID_COL_FILE_A].Tag = ObjA;
                    oPropRow.ThisRow.Cells[GRID_COL_FILE_B].Tag = ObjB;

                    Color_GridRow(oPropRow.ThisRow);
                    NDifferenceFound++;
                }
            }
        }

        private void Compar_ColorField(Type oObjType, string FieldName, object ObjA, object ObjB, CollapsableGridRow oBaseRow)
        {
            Color ColorA = Color.Empty;
            Color ColorB = Color.Empty;

            if (!(ObjA == null))
            {
                ColorA = (Color)oObjType.InvokeMember(FieldName, BindingFlags.GetField, null, ObjA, null);
            }

            if (!(ObjB == null))
            {
                ColorB = (Color)oObjType.InvokeMember(FieldName, BindingFlags.GetField, null, ObjB, null);
            }

            if (ColorA.ToArgb() != ColorB.ToArgb())
            {
                CollapsableGridRow oColorRow = oBaseRow.Children.Add();
                oColorRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = FieldName;
                oColorRow.ThisRow.Tag = true;

                oColorRow.ThisRow.Cells[GRID_COL_PROP_NAME].Tag = FieldName;
                oColorRow.ThisRow.Cells[GRID_COL_FILE_A].Tag = ObjA;
                oColorRow.ThisRow.Cells[GRID_COL_FILE_B].Tag = ObjB;

                oColorRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ColorA.ToString();
                oColorRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ColorB.ToString();
                Color_GridRow(oColorRow.ThisRow);

                NDifferenceFound++;
            }
        }

        private void Color_GridRow(DataGridViewRow oRow)
        {
            Color DIFF_BACKCOLOR = Color.Tomato;
            Color DIFF_FORECOLOR = Color.Black;
            Color EQUAL_BACKCOLOR = Color.LightGreen;
            Color EQUAL_FORECOLOR = Color.Black;

            if (!(oRow == null))
            {
                Color BackColor = EQUAL_BACKCOLOR;
                Color ForeColor = EQUAL_FORECOLOR;

                if (oRow.Cells[GRID_COL_FILE_A].Value.ToString() != oRow.Cells[GRID_COL_FILE_B].Value.ToString())
                {
                    BackColor = DIFF_BACKCOLOR;
                    ForeColor = DIFF_FORECOLOR;
                }

                for (int i = 1; i < oRow.Cells.Count; i++)
                {
                    oRow.Cells[i].Style.BackColor = BackColor;
                    oRow.Cells[i].Style.ForeColor = ForeColor;
                }
            }
        }

        #endregion

        #region Properties comparison filter



        #endregion

        #region Properties merge

        private void Merge_AllProperties(CollapsableGridRow oBaseRow, MergeDirection eMergeDirection)
        {
            if ((bool)(oBaseRow.ThisRow.Tag) == true)
            {
                Merge_Property(oBaseRow, eMergeDirection);
            }

            foreach(CollapsableGridRow oChildRow in oBaseRow.Children)
            {
                Merge_AllProperties(oChildRow, eMergeDirection);
            }
        }

        private void Merge_Property(CollapsableGridRow oRow, MergeDirection eMergeDirection)
        {
            string PropName = oRow.ThisRow.Cells[GRID_COL_PROP_NAME].Tag.ToString();
            object ObjA = oRow.ThisRow.Cells[GRID_COL_FILE_A].Tag;
            object ObjB = oRow.ThisRow.Cells[GRID_COL_FILE_B].Tag;

            if (!(ObjA == null || ObjB == null)) //Source and destination objects are not null
            {
                Type ObjType = ObjA.GetType();

                if (ObjType == ObjB.GetType()) //Source and destination objects are of the same type
                {
                    if (!(PropName.StartsWith("Item"))) //Current object is not an item of a list
                    {
                        object PropA = null;
                        object PropB = null;

                        PropA = ObjType.InvokeMember(PropName, BindingFlags.GetField, null, ObjA, null);
                        PropB = ObjType.InvokeMember(PropName, BindingFlags.GetField, null, ObjB, null);

                        if (!(PropA == null && PropB == null)) //Field name exists in the object type
                        {
                            switch (eMergeDirection)
                            {
                                case MergeDirection.From_A_To_B:
                                    {
                                        ObjType.GetField(PropName).SetValue(ObjB, PropA);
                                        FileBModified = true;

                                        oRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ObjType.GetField(PropName).GetValue(ObjB).ToString();
                                        Color_GridRow(oRow.ThisRow);
                                    }
                                    break;

                                case MergeDirection.From_B_To_A:
                                    {
                                        ObjType.GetField(PropName).SetValue(ObjA, PropB);
                                        FileAModified = true;

                                        oRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ObjType.GetField(PropName).GetValue(ObjA).ToString();
                                        Color_GridRow(oRow.ThisRow);
                                    }
                                    break;

                                default:
                                    return;
                            }

                            if (ObjType.BaseType == typeof(System.ValueType))
                            {
                                if (eMergeDirection == MergeDirection.From_A_To_B)
                                {
                                    Set_ParentObject(ObjB, oRow, GRID_COL_FILE_B);
                                }
                                else
                                {
                                    Set_ParentObject(ObjA, oRow, GRID_COL_FILE_A);
                                }
                            }
                        }
                    }
                    else //Current object is an item of a list
                    {
                        object ListA = oRow.ThisRow.Cells[GRID_COL_FILE_A].Tag;
                        object ListB = oRow.ThisRow.Cells[GRID_COL_FILE_B].Tag;

                        object ItemA = null;
                        object ItemB = null;

                        int ItemIndex = Get_ListItemIndex(PropName);
                        object[] ObjItemIndex = { ItemIndex };

                        if(!(oRow.ThisRow.Cells[GRID_COL_FILE_A].Value.ToString().Equals("Null")))
                        {
                            ItemA = ListA.GetType().GetProperty("Item").GetValue(ListA, ObjItemIndex);
                        }

                        if (!(oRow.ThisRow.Cells[GRID_COL_FILE_B].Value.ToString().Equals("Null")))
                        {
                            ItemB = ListA.GetType().GetProperty("Item").GetValue(ListB, ObjItemIndex);
                        }

                        switch(eMergeDirection)
                        {
                            case MergeDirection.From_A_To_B:
                                {
                                    if(ItemA!=null)
                                    {
                                        int ListBCount = (int)ListB.GetType().GetProperty("Count").GetValue(ListB);

                                        if (ItemIndex < ListBCount)
                                        {
                                            object[] InsertArgs = { ((object)ItemIndex), ItemA };
                                            ListB.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, ListB, InsertArgs);
                                        }
                                        else
                                        {
                                            object[] AddArgs = { ItemA };
                                            ListB.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, ListB, AddArgs);
                                        }

                                        FileBModified = true;
                                        oRow.ThisRow.Cells[GRID_COL_FILE_B].Value = oRow.ThisRow.Cells[GRID_COL_FILE_A].Value;
                                        Color_GridRow(oRow.ThisRow);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cannot merge a null value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                break;

                            case MergeDirection.From_B_To_A:
                                {
                                    if(ItemB!=null)
                                    {
                                        int ListACount = (int)ListB.GetType().GetProperty("Count").GetValue(ListA);

                                        if (ItemIndex < ListACount)
                                        {
                                            object[] InsertArgs = { ((object)ItemIndex), ItemB };
                                            ListA.GetType().InvokeMember("Insert", BindingFlags.InvokeMethod, null, ListA, InsertArgs);
                                        }
                                        else
                                        {
                                            object[] AddArgs = { ItemB };
                                            ListA.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, ListA, AddArgs);
                                        }

                                        FileAModified = true;
                                        oRow.ThisRow.Cells[GRID_COL_FILE_A].Value = oRow.ThisRow.Cells[GRID_COL_FILE_B].Value;
                                        Color_GridRow(oRow.ThisRow);
                                    }
                                    else
                                    {
                                        MessageBox.Show("Cannot merge a null value !", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                break;

                            default:
                                return;
                        }
                    }

                    MergeCount++;
                    NDifferenceFound--;
                }
            }
        }

        private void Set_ParentObject(object oMergedObj, CollapsableGridRow oRow, int ColId)
        {
            object oParentObject = oRow.Parent.ThisRow.Cells[ColId].Tag;
            Type oParentType = oParentObject.GetType();
            string PropName = oRow.Parent.ThisRow.Cells[GRID_COL_PROP_NAME].Tag.ToString();

            if (PropName.StartsWith("Item")) //Parent object is an item of a list
            {
                object[] ItemIndex = { Get_ListItemIndex(PropName) };
                oParentType.GetProperty("Item").SetValue(oParentObject, oMergedObj, ItemIndex);
            }
            else //Parent object is a single field of an object
            {
                oParentType.GetField(PropName).SetValue(oParentObject, oMergedObj);
            }

            if (oParentType.BaseType == typeof(System.ValueType))
            {
                Set_ParentObject(oParentObject, oRow.Parent, ColId);
            }
        }

        private int Get_ListItemIndex(string PropName)
        {
            int IndexStart = PropName.IndexOf("#") + 1;
            string sIndex = PropName.Substring(IndexStart, PropName.Length - IndexStart);

            return (int.Parse(sIndex));
        }

        #endregion

        #endregion
    }
}
