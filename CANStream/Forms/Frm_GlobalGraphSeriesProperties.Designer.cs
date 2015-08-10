/*
 * Created by SharpDevelop.
 * User: Vincent
 * Date: 05/07/2015
 * Time: 15:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_GlobalGraphSeriesProperties
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.TS_Main = new System.Windows.Forms.ToolStrip();
			this.TSB_Apply = new System.Windows.Forms.ToolStripButton();
			this.TSB_Cancel = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_New = new System.Windows.Forms.ToolStripButton();
			this.TSB_Del = new System.Windows.Forms.ToolStripButton();
			this.TSB_Clear = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_Copy = new System.Windows.Forms.ToolStripButton();
			this.TSB_Past = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.TSB_LoadElementFile = new System.Windows.Forms.ToolStripButton();
			this.Grid_GlobalSeriesProps = new System.Windows.Forms.DataGridView();
			this.Dlg_OpenElementsFile = new System.Windows.Forms.OpenFileDialog();
			this.GridCol_Name = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Label = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Color = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Fomat = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Scale = new System.Windows.Forms.DataGridViewComboBoxColumn();
			this.GridCol_Min = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Max = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_YAxis = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Grid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_RefLine = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.GridCol_Details = new System.Windows.Forms.DataGridViewButtonColumn();
			this.TS_Main.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid_GlobalSeriesProps)).BeginInit();
			this.SuspendLayout();
			// 
			// TS_Main
			// 
			this.TS_Main.ImageScalingSize = new System.Drawing.Size(32, 32);
			this.TS_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.TSB_Apply,
									this.TSB_Cancel,
									this.toolStripSeparator1,
									this.TSB_New,
									this.TSB_Del,
									this.TSB_Clear,
									this.toolStripSeparator2,
									this.TSB_Copy,
									this.TSB_Past,
									this.toolStripSeparator3,
									this.TSB_LoadElementFile});
			this.TS_Main.Location = new System.Drawing.Point(0, 0);
			this.TS_Main.Name = "TS_Main";
			this.TS_Main.Size = new System.Drawing.Size(758, 39);
			this.TS_Main.TabIndex = 0;
			this.TS_Main.Text = "toolStrip1";
			// 
			// TSB_Apply
			// 
			this.TSB_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Apply.Image = global::CANStream.Icones.Apply_32;
			this.TSB_Apply.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Apply.Name = "TSB_Apply";
			this.TSB_Apply.Size = new System.Drawing.Size(36, 36);
			this.TSB_Apply.Text = "toolStripButton1";
			this.TSB_Apply.ToolTipText = "Apply modifications";
			this.TSB_Apply.Click += new System.EventHandler(this.TSB_ApplyClick);
			// 
			// TSB_Cancel
			// 
			this.TSB_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Cancel.Image = global::CANStream.Icones.Cancel_32;
			this.TSB_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Cancel.Name = "TSB_Cancel";
			this.TSB_Cancel.Size = new System.Drawing.Size(36, 36);
			this.TSB_Cancel.Text = "toolStripButton2";
			this.TSB_Cancel.ToolTipText = "Cancel modifications";
			this.TSB_Cancel.Click += new System.EventHandler(this.TSB_CancelClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
			// 
			// TSB_New
			// 
			this.TSB_New.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_New.Image = global::CANStream.Icones.Global_Prop_Add_32;
			this.TSB_New.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_New.Name = "TSB_New";
			this.TSB_New.Size = new System.Drawing.Size(36, 36);
			this.TSB_New.Text = "toolStripButton3";
			this.TSB_New.ToolTipText = "Create new global serie properties";
			this.TSB_New.Click += new System.EventHandler(this.TSB_NewClick);
			// 
			// TSB_Del
			// 
			this.TSB_Del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Del.Image = global::CANStream.Icones.Global_Prop_Del_32;
			this.TSB_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Del.Name = "TSB_Del";
			this.TSB_Del.Size = new System.Drawing.Size(36, 36);
			this.TSB_Del.Text = "toolStripButton4";
			this.TSB_Del.ToolTipText = "Delete selected global series properties";
			// 
			// TSB_Clear
			// 
			this.TSB_Clear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Clear.Image = global::CANStream.Icones.Delete_32;
			this.TSB_Clear.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Clear.Name = "TSB_Clear";
			this.TSB_Clear.Size = new System.Drawing.Size(36, 36);
			this.TSB_Clear.Text = "toolStripButton5";
			this.TSB_Clear.ToolTipText = "Clear global series properties";
			this.TSB_Clear.Click += new System.EventHandler(this.TSB_ClearClick);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
			// 
			// TSB_Copy
			// 
			this.TSB_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Copy.Image = global::CANStream.Icones.Copy_32;
			this.TSB_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Copy.Name = "TSB_Copy";
			this.TSB_Copy.Size = new System.Drawing.Size(36, 36);
			this.TSB_Copy.Text = "toolStripButton6";
			this.TSB_Copy.ToolTipText = "Copy selected global series properties";
			this.TSB_Copy.Click += new System.EventHandler(this.TSB_CopyClick);
			// 
			// TSB_Past
			// 
			this.TSB_Past.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_Past.Image = global::CANStream.Icones.Paste_32;
			this.TSB_Past.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_Past.Name = "TSB_Past";
			this.TSB_Past.Size = new System.Drawing.Size(36, 36);
			this.TSB_Past.Text = "toolStripButton7";
			this.TSB_Past.ToolTipText = "Past global series properties from clipboard";
			this.TSB_Past.Click += new System.EventHandler(this.TSB_PastClick);
			// 
			// toolStripSeparator3
			// 
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
			// 
			// TSB_LoadElementFile
			// 
			this.TSB_LoadElementFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.TSB_LoadElementFile.Image = global::CANStream.Icones.Virtual_Channel_Element_32;
			this.TSB_LoadElementFile.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.TSB_LoadElementFile.Name = "TSB_LoadElementFile";
			this.TSB_LoadElementFile.Size = new System.Drawing.Size(36, 36);
			this.TSB_LoadElementFile.Text = "toolStripButton8";
			this.TSB_LoadElementFile.ToolTipText = "Load an elements file";
			this.TSB_LoadElementFile.Click += new System.EventHandler(this.TSB_LoadElementFileClick);
			// 
			// Grid_GlobalSeriesProps
			// 
			this.Grid_GlobalSeriesProps.AllowUserToAddRows = false;
			this.Grid_GlobalSeriesProps.AllowUserToDeleteRows = false;
			this.Grid_GlobalSeriesProps.AllowUserToResizeRows = false;
			this.Grid_GlobalSeriesProps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
									| System.Windows.Forms.AnchorStyles.Left) 
									| System.Windows.Forms.AnchorStyles.Right)));
			this.Grid_GlobalSeriesProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.Grid_GlobalSeriesProps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.GridCol_Name,
									this.GridCol_Label,
									this.GridCol_Unit,
									this.GridCol_Color,
									this.GridCol_Fomat,
									this.GridCol_Scale,
									this.GridCol_Min,
									this.GridCol_Max,
									this.GridCol_YAxis,
									this.GridCol_Grid,
									this.GridCol_RefLine,
									this.GridCol_Details});
			this.Grid_GlobalSeriesProps.Location = new System.Drawing.Point(12, 42);
			this.Grid_GlobalSeriesProps.Name = "Grid_GlobalSeriesProps";
			this.Grid_GlobalSeriesProps.RowHeadersVisible = false;
			this.Grid_GlobalSeriesProps.Size = new System.Drawing.Size(734, 361);
			this.Grid_GlobalSeriesProps.TabIndex = 1;
			// 
			// Dlg_OpenElementsFile
			// 
			this.Dlg_OpenElementsFile.FileName = "openFileDialog1";
			// 
			// GridCol_Name
			// 
			this.GridCol_Name.HeaderText = "Serie";
			this.GridCol_Name.Name = "GridCol_Name";
			// 
			// GridCol_Label
			// 
			this.GridCol_Label.HeaderText = "Label";
			this.GridCol_Label.Name = "GridCol_Label";
			// 
			// GridCol_Unit
			// 
			this.GridCol_Unit.HeaderText = "Unit";
			this.GridCol_Unit.Name = "GridCol_Unit";
			this.GridCol_Unit.Width = 50;
			// 
			// GridCol_Color
			// 
			this.GridCol_Color.HeaderText = "Color";
			this.GridCol_Color.Name = "GridCol_Color";
			this.GridCol_Color.Width = 50;
			// 
			// GridCol_Fomat
			// 
			this.GridCol_Fomat.HeaderText = "Format";
			this.GridCol_Fomat.Name = "GridCol_Fomat";
			this.GridCol_Fomat.Width = 50;
			// 
			// GridCol_Scale
			// 
			this.GridCol_Scale.HeaderText = "Scale";
			this.GridCol_Scale.Name = "GridCol_Scale";
			this.GridCol_Scale.Width = 50;
			// 
			// GridCol_Min
			// 
			this.GridCol_Min.HeaderText = "Min";
			this.GridCol_Min.Name = "GridCol_Min";
			this.GridCol_Min.Width = 50;
			// 
			// GridCol_Max
			// 
			this.GridCol_Max.HeaderText = "Max";
			this.GridCol_Max.Name = "GridCol_Max";
			this.GridCol_Max.Width = 50;
			// 
			// GridCol_YAxis
			// 
			this.GridCol_YAxis.HeaderText = "Y Axis";
			this.GridCol_YAxis.Name = "GridCol_YAxis";
			this.GridCol_YAxis.Width = 50;
			// 
			// GridCol_Grid
			// 
			this.GridCol_Grid.HeaderText = "Grid";
			this.GridCol_Grid.Name = "GridCol_Grid";
			this.GridCol_Grid.Width = 50;
			// 
			// GridCol_RefLine
			// 
			this.GridCol_RefLine.HeaderText = "Ref Lines";
			this.GridCol_RefLine.Name = "GridCol_RefLine";
			this.GridCol_RefLine.Width = 80;
			// 
			// GridCol_Details
			// 
			this.GridCol_Details.HeaderText = "Details";
			this.GridCol_Details.Name = "GridCol_Details";
			this.GridCol_Details.Width = 50;
			// 
			// Frm_GlobalGraphSeriesProperties
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(758, 415);
			this.Controls.Add(this.Grid_GlobalSeriesProps);
			this.Controls.Add(this.TS_Main);
			this.Icon = global::CANStream.Icones.CANStream_Icone;
			this.Name = "Frm_GlobalGraphSeriesProperties";
			this.Text = "Global graphic series properties";
			this.TS_Main.ResumeLayout(false);
			this.TS_Main.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.Grid_GlobalSeriesProps)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.DataGridViewButtonColumn GridCol_Details;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_RefLine;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Grid;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_YAxis;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Max;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Min;
		private System.Windows.Forms.DataGridViewComboBoxColumn GridCol_Scale;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Fomat;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Color;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Unit;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Label;
		private System.Windows.Forms.DataGridViewTextBoxColumn GridCol_Name;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenElementsFile;
		private System.Windows.Forms.ToolStripButton TSB_LoadElementFile;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
		private System.Windows.Forms.ToolStripButton TSB_Past;
		private System.Windows.Forms.ToolStripButton TSB_Copy;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton TSB_Clear;
		private System.Windows.Forms.ToolStripButton TSB_Del;
		private System.Windows.Forms.ToolStripButton TSB_New;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton TSB_Cancel;
		private System.Windows.Forms.DataGridView Grid_GlobalSeriesProps;
		private System.Windows.Forms.ToolStripButton TSB_Apply;
		private System.Windows.Forms.ToolStrip TS_Main;
	}
}
