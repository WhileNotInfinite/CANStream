/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 2/13/2014
 * Time: 14:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_VirtualChannelTest
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cmd_Test = new System.Windows.Forms.Button();
            this.rTxt_ChannelExpression = new System.Windows.Forms.RichTextBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Grid_VariableValues = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Cmd_Quit = new System.Windows.Forms.Button();
            this.Cmd_SetChanExpr = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.rTxt_ErrorLog = new System.Windows.Forms.RichTextBox();
            this.Txt_Result = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Chk_FormatedResult = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_VariableValues)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(516, 331);
            this.splitContainer1.SplitterDistance = 97;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.Cmd_Test);
            this.groupBox1.Controls.Add(this.rTxt_ChannelExpression);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(510, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Expression";
            // 
            // Cmd_Test
            // 
            this.Cmd_Test.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Test.Location = new System.Drawing.Point(6, 63);
            this.Cmd_Test.Name = "Cmd_Test";
            this.Cmd_Test.Size = new System.Drawing.Size(498, 23);
            this.Cmd_Test.TabIndex = 1;
            this.Cmd_Test.Text = "Test";
            this.Cmd_Test.UseVisualStyleBackColor = true;
            this.Cmd_Test.Click += new System.EventHandler(this.Cmd_TestClick);
            // 
            // rTxt_ChannelExpression
            // 
            this.rTxt_ChannelExpression.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxt_ChannelExpression.Location = new System.Drawing.Point(6, 19);
            this.rTxt_ChannelExpression.Name = "rTxt_ChannelExpression";
            this.rTxt_ChannelExpression.Size = new System.Drawing.Size(498, 38);
            this.rTxt_ChannelExpression.TabIndex = 0;
            this.rTxt_ChannelExpression.Text = "";
            this.rTxt_ChannelExpression.TextChanged += new System.EventHandler(this.RTxt_ChannelExpressionTextChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Size = new System.Drawing.Size(516, 230);
            this.splitContainer2.SplitterDistance = 231;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.Grid_VariableValues);
            this.groupBox2.Location = new System.Drawing.Point(3, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(225, 227);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Variable values";
            // 
            // Grid_VariableValues
            // 
            this.Grid_VariableValues.AllowUserToAddRows = false;
            this.Grid_VariableValues.AllowUserToDeleteRows = false;
            this.Grid_VariableValues.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_VariableValues.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_VariableValues.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.Grid_VariableValues.Location = new System.Drawing.Point(6, 19);
            this.Grid_VariableValues.Name = "Grid_VariableValues";
            this.Grid_VariableValues.RowHeadersVisible = false;
            this.Grid_VariableValues.Size = new System.Drawing.Size(213, 202);
            this.Grid_VariableValues.TabIndex = 0;
            this.Grid_VariableValues.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_VariableValuesCellValueChanged);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 130;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Value";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.Chk_FormatedResult);
            this.groupBox3.Controls.Add(this.Cmd_Quit);
            this.groupBox3.Controls.Add(this.Cmd_SetChanExpr);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.rTxt_ErrorLog);
            this.groupBox3.Controls.Add(this.Txt_Result);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(-1, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(279, 227);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Evaluation";
            // 
            // Cmd_Quit
            // 
            this.Cmd_Quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Quit.Location = new System.Drawing.Point(117, 198);
            this.Cmd_Quit.Name = "Cmd_Quit";
            this.Cmd_Quit.Size = new System.Drawing.Size(75, 23);
            this.Cmd_Quit.TabIndex = 5;
            this.Cmd_Quit.Text = "Quit";
            this.Cmd_Quit.UseVisualStyleBackColor = true;
            this.Cmd_Quit.Click += new System.EventHandler(this.Cmd_QuitClick);
            // 
            // Cmd_SetChanExpr
            // 
            this.Cmd_SetChanExpr.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_SetChanExpr.Location = new System.Drawing.Point(198, 198);
            this.Cmd_SetChanExpr.Name = "Cmd_SetChanExpr";
            this.Cmd_SetChanExpr.Size = new System.Drawing.Size(75, 23);
            this.Cmd_SetChanExpr.TabIndex = 4;
            this.Cmd_SetChanExpr.Text = "Set channel";
            this.Cmd_SetChanExpr.UseVisualStyleBackColor = true;
            this.Cmd_SetChanExpr.Click += new System.EventHandler(this.Cmd_SetChanExprClick);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Error message";
            // 
            // rTxt_ErrorLog
            // 
            this.rTxt_ErrorLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rTxt_ErrorLog.BackColor = System.Drawing.SystemColors.Control;
            this.rTxt_ErrorLog.Location = new System.Drawing.Point(6, 88);
            this.rTxt_ErrorLog.Name = "rTxt_ErrorLog";
            this.rTxt_ErrorLog.ReadOnly = true;
            this.rTxt_ErrorLog.Size = new System.Drawing.Size(267, 104);
            this.rTxt_ErrorLog.TabIndex = 2;
            this.rTxt_ErrorLog.Text = "";
            // 
            // Txt_Result
            // 
            this.Txt_Result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Txt_Result.BackColor = System.Drawing.SystemColors.HotTrack;
            this.Txt_Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Txt_Result.ForeColor = System.Drawing.SystemColors.Info;
            this.Txt_Result.Location = new System.Drawing.Point(6, 35);
            this.Txt_Result.Name = "Txt_Result";
            this.Txt_Result.Size = new System.Drawing.Size(267, 26);
            this.Txt_Result.TabIndex = 1;
            this.Txt_Result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Result";
            // 
            // Chk_FormatedResult
            // 
            this.Chk_FormatedResult.AutoSize = true;
            this.Chk_FormatedResult.Checked = true;
            this.Chk_FormatedResult.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Chk_FormatedResult.Location = new System.Drawing.Point(148, 18);
            this.Chk_FormatedResult.Name = "Chk_FormatedResult";
            this.Chk_FormatedResult.Size = new System.Drawing.Size(125, 17);
            this.Chk_FormatedResult.TabIndex = 6;
            this.Chk_FormatedResult.Text = "Show formated result";
            this.Chk_FormatedResult.UseVisualStyleBackColor = true;
            this.Chk_FormatedResult.CheckedChanged += new System.EventHandler(this.Chk_FormatedResult_CheckedChanged);
            // 
            // Frm_VirtualChannelTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 331);
            this.Controls.Add(this.splitContainer1);
            this.Icon = global::CANStream.Icones.Virtual_Channel_Icone;
            this.MinimumSize = new System.Drawing.Size(532, 369);
            this.Name = "Frm_VirtualChannelTest";
            this.Text = "Frm_VirtualChannelTest";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_VirtualChannelTestFormClosing);
            this.Load += new System.EventHandler(this.Frm_VirtualChannelTestLoad);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Grid_VariableValues)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.Button Cmd_Test;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
		private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox Txt_Result;
		private System.Windows.Forms.RichTextBox rTxt_ErrorLog;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button Cmd_SetChanExpr;
		private System.Windows.Forms.Button Cmd_Quit;
		private System.Windows.Forms.DataGridView Grid_VariableValues;
		private System.Windows.Forms.RichTextBox rTxt_ChannelExpression;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox Chk_FormatedResult;
    }
}
