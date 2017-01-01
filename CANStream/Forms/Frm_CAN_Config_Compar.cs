using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
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

        private const int GRID_COL_PROP_NAME = 1;
        private const int GRID_COL_FILE_A = 2;
        private const int GRID_COL_FILE_B = 3;

        #endregion

        #region Private members

        private bool FileALoaded;
        private bool FileBLoaded;

        private CANMessagesConfiguration SingleBus_CANCfg_A;
        private CANMessagesConfiguration SingleBus_CANCfg_B;

        private MultipleContollerCANConfiguration MultipleBus_CANCfg_A;
        private MultipleContollerCANConfiguration MultipleBus_CANCfg_B;

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

            CGrid_Comparison.Columns[GRID_COL_PROP_NAME].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CGrid_Comparison.Columns[GRID_COL_FILE_A].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CGrid_Comparison.Columns[GRID_COL_FILE_B].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;

            CGrid_Comparison.Columns[GRID_COL_PROP_NAME].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            CGrid_Comparison.Columns[GRID_COL_FILE_A].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            CGrid_Comparison.Columns[GRID_COL_FILE_B].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            int GridWith = CGrid_Comparison.Width - CGrid_Comparison.Columns[0].Width - 25;
            CGrid_Comparison.Columns[GRID_COL_PROP_NAME].Width = GridWith / 4;

            GridWith -= CGrid_Comparison.Columns[GRID_COL_PROP_NAME].Width;
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
            CollapsableGridRow oParentRow = null;
            CollapsableGridRow oChildRow = null;

            Type CANConfig_T = typeof(CANMessagesConfiguration);

            oParentRow = CGrid_Comparison.Rows.Add();
            oParentRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = CANConfig_T.Name.ToString();

            //CAN Configuration properties
            foreach(FieldInfo oField in CANConfig_T.GetFields())
            {
                if(oField.FieldType.Namespace.Equals("System")) //Type is generic
                {
                    object ValueA = CANConfig_T.InvokeMember(oField.Name, BindingFlags.GetField, null, SingleBus_CANCfg_A, null);
                    object ValueB = CANConfig_T.InvokeMember(oField.Name, BindingFlags.GetField, null, SingleBus_CANCfg_B, null);

                    oChildRow = oParentRow.Children.Add();
                    oChildRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = oField.Name.ToString();
                    oChildRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ValueA.ToString();
                    oChildRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ValueB.ToString();
                    Color_GridRow(oChildRow.ThisRow);
                }
                else //Type is a custom class
                {
                    if (!(oField.FieldType.Namespace.Equals("System.Collections.Generic"))) //Type is a custom class and not a List<T>
                    {
                        //TODO: Compare custom class
                    }
                }
            }

            //CAN Frames comparison
            int iFrame = 0;

            foreach(CANMessage oFrame in SingleBus_CANCfg_A.Messages)
            {
                oChildRow = oParentRow.Children.Add();
                oChildRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = "CAN Frame";
                Compare_Frame(oChildRow, oFrame, SingleBus_CANCfg_B.GetCANMessage(oFrame.Identifier, MessageResearchOption.Identifier));
                oChildRow.Collapse();

                iFrame++;
                StatusBar_Progress.Value = (iFrame * 100 / SingleBus_CANCfg_A.Messages.Count);
            }
        }

        private void Compare_Frame(CollapsableGridRow oBaseRow, CANMessage FrameA, CANMessage FrameB)
        {
            if (!(FrameA == null && FrameB == null))
            {
                CollapsableGridRow oPropRow = null;

                Type CANFrame_T = typeof(CANMessage);

                //CAN Frame properties
                foreach (FieldInfo oField in CANFrame_T.GetFields())
                {
                    if (oField.FieldType.Namespace.Equals("System")) //Type is generic
                    {
                        oPropRow = oBaseRow.Children.Add();
                        oPropRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = oField.Name;

                        if (!(FrameA == null || FrameB == null))
                        {
                            object ValueA = CANFrame_T.InvokeMember(oField.Name, BindingFlags.GetField, null, FrameA, null);
                            object ValueB = CANFrame_T.InvokeMember(oField.Name, BindingFlags.GetField, null, FrameB, null);

                            oPropRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ValueA.ToString();
                            oPropRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ValueB.ToString();
                            Color_GridRow(oPropRow.ThisRow);
                        }
                        else
                        {
                            if (FrameA == null)
                            {
                                object ValueB = CANFrame_T.InvokeMember(oField.Name, BindingFlags.GetField, null, FrameB, null);
                                oPropRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ValueB.ToString();
                            }

                            if (FrameB == null)
                            {
                                object ValueA = CANFrame_T.InvokeMember(oField.Name, BindingFlags.GetField, null, FrameA, null);
                                oPropRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ValueA.ToString();
                            }
                        }
                    }
                    else  //Type is a custom class and not a List<T>
                    {
                        if (!(oField.FieldType.Namespace.Equals("System.Collections.Generic"))) //Type is generic
                        {
                            //TODO: Compare custom class
                        }
                    }
                }

                //CAN Signals comparison
                if(!(FrameA==null || FrameB==null))
                {
                    foreach (CANParameter oSignal in FrameA.Parameters)
                    {
                        oPropRow = oBaseRow.Children.Add();
                        oPropRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = "CAN Signal";
                        Compare_CANSignal(oPropRow, oSignal, FrameB.GetCANParameter(oSignal.Name, ParameterResearchOption.Name));
                        oPropRow.Collapse();
                    }
                }
                else
                {
                    if (FrameA == null)
                    {
                        foreach(CANParameter oSignal in FrameB.Parameters)
                        {
                            oPropRow = oBaseRow.Children.Add();
                            oPropRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = "CAN Signal";
                            Compare_CANSignal(oPropRow, null, oSignal);
                            oPropRow.Collapse();
                        }
                    }

                    if (FrameB == null)
                    {
                        foreach (CANParameter oSignal in FrameA.Parameters)
                        {
                            oPropRow = oBaseRow.Children.Add();
                            oPropRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = "CAN Signal";
                            Compare_CANSignal(oPropRow, oSignal, null);
                            oPropRow.Collapse();
                        }
                    }
                }
            }
        }

        private void Compare_CANSignal(CollapsableGridRow oBaseRow, CANParameter SignalA, CANParameter SignalB)
        {
            if(!(SignalA==null && SignalB==null))
            {
                CollapsableGridRow oPropRow = null;

                Type CANSignal_T = typeof(CANParameter);

                //CAN Signal properties
                foreach(FieldInfo oField in CANSignal_T.GetFields())
                {
                    if(oField.FieldType.Namespace.Equals("System")) //Type is generic
                    {
                        oPropRow = oBaseRow.Children.Add();
                        oPropRow.ThisRow.Cells[GRID_COL_PROP_NAME].Value = oField.Name;

                        if (!(SignalA == null || SignalB == null))
                        {
                            object ValueA = CANSignal_T.InvokeMember(oField.Name, BindingFlags.GetField, null, SignalA, null);
                            object ValueB = CANSignal_T.InvokeMember(oField.Name, BindingFlags.GetField, null, SignalB, null);

                            oPropRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ValueA.ToString();
                            oPropRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ValueB.ToString();
                            Color_GridRow(oPropRow.ThisRow);
                        }
                        else
                        {
                            if (SignalA == null)
                            {
                                object ValueB = CANSignal_T.InvokeMember(oField.Name, BindingFlags.GetField, null, SignalB, null);
                                oPropRow.ThisRow.Cells[GRID_COL_FILE_B].Value = ValueB.ToString();
                            }

                            if (SignalB == null)
                            {
                                object ValueA = CANSignal_T.InvokeMember(oField.Name, BindingFlags.GetField, null, SignalA, null);
                                oPropRow.ThisRow.Cells[GRID_COL_FILE_A].Value = ValueA.ToString();
                            }
                        }
                    }
                    else //Type is not generic
                    {
                        //TODO
                    }
                }
            }
        }

        private void Color_GridRow(DataGridViewRow oRow)
        {
            Color EQUAL_BACKCOLOR = Color.LightGreen;
            Color DIFF_BACKCOLOR = Color.Tomato;
            Color EQUAL_FORECOLOR = Color.Black;
            Color DIFF_FORECOLOR = Color.Black;

            if(!(oRow==null))
            {
                Color BackColor = Color.Empty;
                Color ForeColor = Color.Empty;

                if(oRow.Cells[GRID_COL_FILE_A].Value.ToString().Equals(oRow.Cells[GRID_COL_FILE_B].Value.ToString()))
                {
                    BackColor = EQUAL_BACKCOLOR;
                    ForeColor = EQUAL_FORECOLOR;
                }
                else
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

        #endregion
    }
}
