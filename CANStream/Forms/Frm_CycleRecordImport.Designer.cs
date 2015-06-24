/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 10/20/2014
 * Time: 11:32 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_CycleRecordImport
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
			this.components = new System.ComponentModel.Container();
			this.label1 = new System.Windows.Forms.Label();
			this.Lst_TrcFiles = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.Txt_CanConfig = new System.Windows.Forms.TextBox();
			this.Txt_CycleOut = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.Cmd_Create = new System.Windows.Forms.Button();
			this.Cmd_Cancel = new System.Windows.Forms.Button();
			this.PB_TrcFileListProgress = new System.Windows.Forms.ProgressBar();
			this.Lbl_TrcFileListProgress = new System.Windows.Forms.Label();
			this.Lbl_TrcFileProcessingProgress = new System.Windows.Forms.Label();
			this.PB_TrcFileProcessingProgress = new System.Windows.Forms.ProgressBar();
			this.Cmd_AddTrcFiles = new System.Windows.Forms.Button();
			this.Cmd_DelTrcFiles = new System.Windows.Forms.Button();
			this.Cmd_ClearTrcFiles = new System.Windows.Forms.Button();
			this.Cmd_OpenCanCfg = new System.Windows.Forms.Button();
			this.Cmd_CycleOutFile = new System.Windows.Forms.Button();
			this.TT_Cmd_AddTrcFiles = new System.Windows.Forms.ToolTip(this.components);
			this.TT_Cmd_DelTrcFiles = new System.Windows.Forms.ToolTip(this.components);
			this.TT_Cmd_ClearTrcFiles = new System.Windows.Forms.ToolTip(this.components);
			this.TT_Cmd_OpenCanCfg = new System.Windows.Forms.ToolTip(this.components);
			this.TT_Cmd_CycleOutFile = new System.Windows.Forms.ToolTip(this.components);
			this.Dlg_OpenFile = new System.Windows.Forms.OpenFileDialog();
			this.Dlg_SaveFile = new System.Windows.Forms.SaveFileDialog();
			this.BGW_TraceImport = new System.ComponentModel.BackgroundWorker();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Trace record files";
			// 
			// Lst_TrcFiles
			// 
			this.Lst_TrcFiles.FormattingEnabled = true;
			this.Lst_TrcFiles.Location = new System.Drawing.Point(12, 27);
			this.Lst_TrcFiles.Name = "Lst_TrcFiles";
			this.Lst_TrcFiles.Size = new System.Drawing.Size(588, 95);
			this.Lst_TrcFiles.TabIndex = 1;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(12, 134);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 15);
			this.label2.TabIndex = 2;
			this.label2.Text = "CAN Configuration";
			// 
			// Txt_CanConfig
			// 
			this.Txt_CanConfig.Location = new System.Drawing.Point(12, 152);
			this.Txt_CanConfig.Name = "Txt_CanConfig";
			this.Txt_CanConfig.Size = new System.Drawing.Size(588, 20);
			this.Txt_CanConfig.TabIndex = 3;
			// 
			// Txt_CycleOut
			// 
			this.Txt_CycleOut.Location = new System.Drawing.Point(12, 200);
			this.Txt_CycleOut.Name = "Txt_CycleOut";
			this.Txt_CycleOut.Size = new System.Drawing.Size(588, 20);
			this.Txt_CycleOut.TabIndex = 5;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(12, 182);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 15);
			this.label3.TabIndex = 4;
			this.label3.Text = "Output cycle file";
			// 
			// Cmd_Create
			// 
			this.Cmd_Create.Location = new System.Drawing.Point(557, 338);
			this.Cmd_Create.Name = "Cmd_Create";
			this.Cmd_Create.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Create.TabIndex = 6;
			this.Cmd_Create.Text = "Create";
			this.Cmd_Create.UseVisualStyleBackColor = true;
			this.Cmd_Create.Click += new System.EventHandler(this.Cmd_CreateClick);
			// 
			// Cmd_Cancel
			// 
			this.Cmd_Cancel.Location = new System.Drawing.Point(476, 338);
			this.Cmd_Cancel.Name = "Cmd_Cancel";
			this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
			this.Cmd_Cancel.TabIndex = 7;
			this.Cmd_Cancel.Text = "Cancel";
			this.Cmd_Cancel.UseVisualStyleBackColor = true;
			this.Cmd_Cancel.Click += new System.EventHandler(this.Cmd_CancelClick);
			// 
			// PB_TrcFileListProgress
			// 
			this.PB_TrcFileListProgress.Location = new System.Drawing.Point(12, 253);
			this.PB_TrcFileListProgress.Name = "PB_TrcFileListProgress";
			this.PB_TrcFileListProgress.Size = new System.Drawing.Size(620, 23);
			this.PB_TrcFileListProgress.TabIndex = 8;
			this.PB_TrcFileListProgress.Visible = false;
			// 
			// Lbl_TrcFileListProgress
			// 
			this.Lbl_TrcFileListProgress.Location = new System.Drawing.Point(12, 235);
			this.Lbl_TrcFileListProgress.Name = "Lbl_TrcFileListProgress";
			this.Lbl_TrcFileListProgress.Size = new System.Drawing.Size(100, 15);
			this.Lbl_TrcFileListProgress.TabIndex = 9;
			this.Lbl_TrcFileListProgress.Text = "File:";
			this.Lbl_TrcFileListProgress.Visible = false;
			// 
			// Lbl_TrcFileProcessingProgress
			// 
			this.Lbl_TrcFileProcessingProgress.Location = new System.Drawing.Point(12, 282);
			this.Lbl_TrcFileProcessingProgress.Name = "Lbl_TrcFileProcessingProgress";
			this.Lbl_TrcFileProcessingProgress.Size = new System.Drawing.Size(100, 15);
			this.Lbl_TrcFileProcessingProgress.TabIndex = 11;
			this.Lbl_TrcFileProcessingProgress.Text = "label5";
			this.Lbl_TrcFileProcessingProgress.Visible = false;
			// 
			// PB_TrcFileProcessingProgress
			// 
			this.PB_TrcFileProcessingProgress.Location = new System.Drawing.Point(12, 300);
			this.PB_TrcFileProcessingProgress.Name = "PB_TrcFileProcessingProgress";
			this.PB_TrcFileProcessingProgress.Size = new System.Drawing.Size(620, 23);
			this.PB_TrcFileProcessingProgress.TabIndex = 10;
			this.PB_TrcFileProcessingProgress.Visible = false;
			// 
			// Cmd_AddTrcFiles
			// 
			this.Cmd_AddTrcFiles.Image = global::CANStream.Icones.Item_Add_16;
			this.Cmd_AddTrcFiles.Location = new System.Drawing.Point(606, 27);
			this.Cmd_AddTrcFiles.Name = "Cmd_AddTrcFiles";
			this.Cmd_AddTrcFiles.Size = new System.Drawing.Size(26, 26);
			this.Cmd_AddTrcFiles.TabIndex = 12;
			this.Cmd_AddTrcFiles.UseVisualStyleBackColor = true;
			this.Cmd_AddTrcFiles.Click += new System.EventHandler(this.Cmd_AddTrcFilesClick);
			// 
			// Cmd_DelTrcFiles
			// 
			this.Cmd_DelTrcFiles.Image = global::CANStream.Icones.Item_Del_16;
			this.Cmd_DelTrcFiles.Location = new System.Drawing.Point(606, 52);
			this.Cmd_DelTrcFiles.Name = "Cmd_DelTrcFiles";
			this.Cmd_DelTrcFiles.Size = new System.Drawing.Size(26, 26);
			this.Cmd_DelTrcFiles.TabIndex = 13;
			this.Cmd_DelTrcFiles.UseVisualStyleBackColor = true;
			this.Cmd_DelTrcFiles.Click += new System.EventHandler(this.Cmd_DelTrcFilesClick);
			// 
			// Cmd_ClearTrcFiles
			// 
			this.Cmd_ClearTrcFiles.Image = global::CANStream.Icones.Item_Clear_16;
			this.Cmd_ClearTrcFiles.Location = new System.Drawing.Point(606, 77);
			this.Cmd_ClearTrcFiles.Name = "Cmd_ClearTrcFiles";
			this.Cmd_ClearTrcFiles.Size = new System.Drawing.Size(26, 26);
			this.Cmd_ClearTrcFiles.TabIndex = 14;
			this.Cmd_ClearTrcFiles.UseVisualStyleBackColor = true;
			this.Cmd_ClearTrcFiles.Click += new System.EventHandler(this.Cmd_ClearTrcFilesClick);
			// 
			// Cmd_OpenCanCfg
			// 
			this.Cmd_OpenCanCfg.Image = global::CANStream.Icones.File_Open_16;
			this.Cmd_OpenCanCfg.Location = new System.Drawing.Point(606, 148);
			this.Cmd_OpenCanCfg.Name = "Cmd_OpenCanCfg";
			this.Cmd_OpenCanCfg.Size = new System.Drawing.Size(26, 26);
			this.Cmd_OpenCanCfg.TabIndex = 15;
			this.Cmd_OpenCanCfg.UseVisualStyleBackColor = true;
			this.Cmd_OpenCanCfg.Click += new System.EventHandler(this.Cmd_OpenCanCfgClick);
			// 
			// Cmd_CycleOutFile
			// 
			this.Cmd_CycleOutFile.Image = global::CANStream.Icones.File_Save_16;
			this.Cmd_CycleOutFile.Location = new System.Drawing.Point(606, 196);
			this.Cmd_CycleOutFile.Name = "Cmd_CycleOutFile";
			this.Cmd_CycleOutFile.Size = new System.Drawing.Size(26, 26);
			this.Cmd_CycleOutFile.TabIndex = 16;
			this.Cmd_CycleOutFile.UseVisualStyleBackColor = true;
			this.Cmd_CycleOutFile.Click += new System.EventHandler(this.Cmd_CycleOutFileClick);
			// 
			// BGW_TraceImport
			// 
			this.BGW_TraceImport.WorkerReportsProgress = true;
			this.BGW_TraceImport.WorkerSupportsCancellation = true;
			this.BGW_TraceImport.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_TraceImportDoWork);
			this.BGW_TraceImport.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGW_TraceImportProgressChanged);
			this.BGW_TraceImport.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_TraceImportRunWorkerCompleted);
			// 
			// Frm_CycleRecordImport
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(637, 373);
			this.Controls.Add(this.Cmd_CycleOutFile);
			this.Controls.Add(this.Cmd_OpenCanCfg);
			this.Controls.Add(this.Cmd_ClearTrcFiles);
			this.Controls.Add(this.Cmd_DelTrcFiles);
			this.Controls.Add(this.Cmd_AddTrcFiles);
			this.Controls.Add(this.Lbl_TrcFileProcessingProgress);
			this.Controls.Add(this.PB_TrcFileProcessingProgress);
			this.Controls.Add(this.Lbl_TrcFileListProgress);
			this.Controls.Add(this.PB_TrcFileListProgress);
			this.Controls.Add(this.Cmd_Cancel);
			this.Controls.Add(this.Cmd_Create);
			this.Controls.Add(this.Txt_CycleOut);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.Txt_CanConfig);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.Lst_TrcFiles);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = global::CANStream.Icones.CANStream_Icone;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Frm_CycleRecordImport";
			this.Text = "Trace record import";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.ComponentModel.BackgroundWorker BGW_TraceImport;
		private System.Windows.Forms.SaveFileDialog Dlg_SaveFile;
		private System.Windows.Forms.OpenFileDialog Dlg_OpenFile;
		private System.Windows.Forms.ToolTip TT_Cmd_CycleOutFile;
		private System.Windows.Forms.ToolTip TT_Cmd_OpenCanCfg;
		private System.Windows.Forms.ToolTip TT_Cmd_ClearTrcFiles;
		private System.Windows.Forms.ToolTip TT_Cmd_DelTrcFiles;
		private System.Windows.Forms.ToolTip TT_Cmd_AddTrcFiles;
		private System.Windows.Forms.Button Cmd_CycleOutFile;
		private System.Windows.Forms.Button Cmd_OpenCanCfg;
		private System.Windows.Forms.Button Cmd_ClearTrcFiles;
		private System.Windows.Forms.Button Cmd_DelTrcFiles;
		private System.Windows.Forms.Button Cmd_AddTrcFiles;
		private System.Windows.Forms.ProgressBar PB_TrcFileProcessingProgress;
		private System.Windows.Forms.Label Lbl_TrcFileProcessingProgress;
		private System.Windows.Forms.Label Lbl_TrcFileListProgress;
		private System.Windows.Forms.ProgressBar PB_TrcFileListProgress;
		private System.Windows.Forms.Button Cmd_Cancel;
		private System.Windows.Forms.Button Cmd_Create;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox Txt_CycleOut;
		private System.Windows.Forms.TextBox Txt_CanConfig;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ListBox Lst_TrcFiles;
		private System.Windows.Forms.Label label1;
	}
}
