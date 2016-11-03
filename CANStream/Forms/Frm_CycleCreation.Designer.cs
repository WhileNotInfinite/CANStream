/*
 *	This file is part of CANStream.
 *
 *	CANStream program is free software: you can redistribute it and/or modify
 *	it under the terms of the GNU General Public License as published by
 *	the Free Software Foundation, either version 3 of the License, or
 *	(at your option) any later version.
 *
 *	This program is distributed in the hope that it will be useful,
 *	but WITHOUT ANY WARRANTY; without even the implied warranty of
 *	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *	GNU General Public License for more details.
 *
 *	You should have received a copy of the GNU General Public License
 *	along with this program.  If not, see <http://www.gnu.org/licenses/>.
 *
 *	CANStream Copyright © 2013-2016 whilenotinfinite@gmail.com
 */

namespace CANStream
{
    partial class Frm_CycleCreation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
        	this.label1 = new System.Windows.Forms.Label();
        	this.Txt_DataFile = new System.Windows.Forms.TextBox();
        	this.Cmd_OpenDataFile = new System.Windows.Forms.Button();
        	this.label2 = new System.Windows.Forms.Label();
        	this.Cmd_OpenAssociation = new System.Windows.Forms.Button();
        	this.Cmb_Association = new System.Windows.Forms.ComboBox();
        	this.label3 = new System.Windows.Forms.Label();
        	this.Txt_CanConfig = new System.Windows.Forms.TextBox();
        	this.Cmd_CreateCycle = new System.Windows.Forms.Button();
        	this.ProgressBar = new System.Windows.Forms.ProgressBar();
        	this.label4 = new System.Windows.Forms.Label();
        	this.Txt_CycleFile = new System.Windows.Forms.TextBox();
        	this.Cmd_SaveCycle = new System.Windows.Forms.Button();
        	this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
        	this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
        	this.label5 = new System.Windows.Forms.Label();
        	this.rTxt_Comments = new System.Windows.Forms.RichTextBox();
        	this.SuspendLayout();
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Location = new System.Drawing.Point(12, 9);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(46, 13);
        	this.label1.TabIndex = 0;
        	this.label1.Text = "Data file";
        	// 
        	// Txt_DataFile
        	// 
        	this.Txt_DataFile.Location = new System.Drawing.Point(15, 25);
        	this.Txt_DataFile.Name = "Txt_DataFile";
        	this.Txt_DataFile.Size = new System.Drawing.Size(579, 20);
        	this.Txt_DataFile.TabIndex = 1;
        	// 
        	// Cmd_OpenDataFile
        	// 
        	this.Cmd_OpenDataFile.Image = global::CANStream.Icones.File_Open_16;
        	this.Cmd_OpenDataFile.Location = new System.Drawing.Point(600, 22);
        	this.Cmd_OpenDataFile.Name = "Cmd_OpenDataFile";
        	this.Cmd_OpenDataFile.Size = new System.Drawing.Size(25, 25);
        	this.Cmd_OpenDataFile.TabIndex = 2;
        	this.Cmd_OpenDataFile.UseVisualStyleBackColor = true;
        	this.Cmd_OpenDataFile.Click += new System.EventHandler(this.Cmd_OpenDataFile_Click);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(12, 58);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(133, 13);
        	this.label2.TabIndex = 3;
        	this.label2.Text = "Cycle/Data association file";
        	// 
        	// Cmd_OpenAssociation
        	// 
        	this.Cmd_OpenAssociation.Image = global::CANStream.Icones.File_Open_16;
        	this.Cmd_OpenAssociation.Location = new System.Drawing.Point(600, 71);
        	this.Cmd_OpenAssociation.Name = "Cmd_OpenAssociation";
        	this.Cmd_OpenAssociation.Size = new System.Drawing.Size(25, 25);
        	this.Cmd_OpenAssociation.TabIndex = 4;
        	this.Cmd_OpenAssociation.UseVisualStyleBackColor = true;
        	this.Cmd_OpenAssociation.Click += new System.EventHandler(this.Cmd_OpenAssociation_Click);
        	// 
        	// Cmb_Association
        	// 
        	this.Cmb_Association.FormattingEnabled = true;
        	this.Cmb_Association.Location = new System.Drawing.Point(15, 74);
        	this.Cmb_Association.Name = "Cmb_Association";
        	this.Cmb_Association.Size = new System.Drawing.Size(579, 21);
        	this.Cmb_Association.TabIndex = 5;
        	this.Cmb_Association.SelectedIndexChanged += new System.EventHandler(this.Cmb_Association_SelectedIndexChanged);
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Location = new System.Drawing.Point(12, 109);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(149, 13);
        	this.label3.TabIndex = 6;
        	this.label3.Text = "Associated CAN Configuration";
        	// 
        	// Txt_CanConfig
        	// 
        	this.Txt_CanConfig.BackColor = System.Drawing.SystemColors.Control;
        	this.Txt_CanConfig.Location = new System.Drawing.Point(15, 125);
        	this.Txt_CanConfig.Name = "Txt_CanConfig";
        	this.Txt_CanConfig.ReadOnly = true;
        	this.Txt_CanConfig.Size = new System.Drawing.Size(579, 20);
        	this.Txt_CanConfig.TabIndex = 7;
        	// 
        	// Cmd_CreateCycle
        	// 
        	this.Cmd_CreateCycle.Location = new System.Drawing.Point(550, 289);
        	this.Cmd_CreateCycle.Name = "Cmd_CreateCycle";
        	this.Cmd_CreateCycle.Size = new System.Drawing.Size(75, 23);
        	this.Cmd_CreateCycle.TabIndex = 8;
        	this.Cmd_CreateCycle.Text = "Create";
        	this.Cmd_CreateCycle.UseVisualStyleBackColor = true;
        	this.Cmd_CreateCycle.Click += new System.EventHandler(this.Cmd_CreateCycle_Click);
        	// 
        	// ProgressBar
        	// 
        	this.ProgressBar.Location = new System.Drawing.Point(15, 289);
        	this.ProgressBar.Name = "ProgressBar";
        	this.ProgressBar.Size = new System.Drawing.Size(529, 23);
        	this.ProgressBar.TabIndex = 9;
        	this.ProgressBar.Visible = false;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Location = new System.Drawing.Point(12, 157);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(83, 13);
        	this.label4.TabIndex = 10;
        	this.label4.Text = "Output cycle file";
        	// 
        	// Txt_CycleFile
        	// 
        	this.Txt_CycleFile.Location = new System.Drawing.Point(15, 175);
        	this.Txt_CycleFile.Name = "Txt_CycleFile";
        	this.Txt_CycleFile.Size = new System.Drawing.Size(579, 20);
        	this.Txt_CycleFile.TabIndex = 11;
        	// 
        	// Cmd_SaveCycle
        	// 
        	this.Cmd_SaveCycle.Image = global::CANStream.Icones.File_Save_16;
        	this.Cmd_SaveCycle.Location = new System.Drawing.Point(600, 172);
        	this.Cmd_SaveCycle.Name = "Cmd_SaveCycle";
        	this.Cmd_SaveCycle.Size = new System.Drawing.Size(25, 25);
        	this.Cmd_SaveCycle.TabIndex = 12;
        	this.Cmd_SaveCycle.UseVisualStyleBackColor = true;
        	this.Cmd_SaveCycle.Click += new System.EventHandler(this.Cmd_SaveCycle_Click);
        	// 
        	// openFileDialog1
        	// 
        	this.openFileDialog1.FileName = "openFileDialog1";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Location = new System.Drawing.Point(15, 208);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(56, 13);
        	this.label5.TabIndex = 13;
        	this.label5.Text = "Comments";
        	// 
        	// rTxt_Comments
        	// 
        	this.rTxt_Comments.Location = new System.Drawing.Point(15, 224);
        	this.rTxt_Comments.Name = "rTxt_Comments";
        	this.rTxt_Comments.Size = new System.Drawing.Size(579, 57);
        	this.rTxt_Comments.TabIndex = 14;
        	this.rTxt_Comments.Text = "";
        	// 
        	// Frm_CycleCreation
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.ClientSize = new System.Drawing.Size(628, 324);
        	this.Controls.Add(this.rTxt_Comments);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.Cmd_SaveCycle);
        	this.Controls.Add(this.Txt_CycleFile);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.ProgressBar);
        	this.Controls.Add(this.Cmd_CreateCycle);
        	this.Controls.Add(this.Txt_CanConfig);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.Cmb_Association);
        	this.Controls.Add(this.Cmd_OpenAssociation);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.Cmd_OpenDataFile);
        	this.Controls.Add(this.Txt_DataFile);
        	this.Controls.Add(this.label1);
        	this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        	this.Icon = global::CANStream.Icones.CANStream_Icone;
        	this.MaximizeBox = false;
        	this.MinimizeBox = false;
        	this.Name = "Frm_CycleCreation";
        	this.Text = "Cycle Creation";
        	this.Load += new System.EventHandler(this.Frm_CycleCreation_Load);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.RichTextBox rTxt_Comments;
        private System.Windows.Forms.Label label5;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_DataFile;
        private System.Windows.Forms.Button Cmd_OpenDataFile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Cmd_OpenAssociation;
        private System.Windows.Forms.ComboBox Cmb_Association;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Txt_CanConfig;
        private System.Windows.Forms.Button Cmd_CreateCycle;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Txt_CycleFile;
        private System.Windows.Forms.Button Cmd_SaveCycle;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}