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
    partial class Frm_ParamEnumerationEdition
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ParamEnumerationEdition));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TSB_Apply = new System.Windows.Forms.ToolStripButton();
            this.TSB_Cancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TSB_Add_Eum = new System.Windows.Forms.ToolStripButton();
            this.TSB_Del_Enum = new System.Windows.Forms.ToolStripButton();
            this.TSB_Clear_Enum = new System.Windows.Forms.ToolStripButton();
            this.Grid_Enum = new System.Windows.Forms.DataGridView();
            this.Enum_Value_Column = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Enum_Text_Col = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Context_GridEnum = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TSMI_Add_Value = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Del_Value = new System.Windows.Forms.ToolStripMenuItem();
            this.TSMI_Clear_Value = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Enum)).BeginInit();
            this.Context_GridEnum.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSB_Apply,
            this.TSB_Cancel,
            this.toolStripSeparator1,
            this.TSB_Add_Eum,
            this.TSB_Del_Enum,
            this.TSB_Clear_Enum});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(283, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TSB_Apply
            // 
            this.TSB_Apply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Apply.Image = global::CANStream.Icones.Apply_16;
            this.TSB_Apply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Apply.Name = "TSB_Apply";
            this.TSB_Apply.Size = new System.Drawing.Size(23, 22);
            this.TSB_Apply.Text = "toolStripButton1";
            this.TSB_Apply.ToolTipText = "Apply changes";
            this.TSB_Apply.Click += new System.EventHandler(this.TSB_Apply_Click);
            // 
            // TSB_Cancel
            // 
            this.TSB_Cancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Cancel.Image = global::CANStream.Icones.Cancel_16;
            this.TSB_Cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Cancel.Name = "TSB_Cancel";
            this.TSB_Cancel.Size = new System.Drawing.Size(23, 22);
            this.TSB_Cancel.Text = "toolStripButton2";
            this.TSB_Cancel.ToolTipText = "Cancel";
            this.TSB_Cancel.Click += new System.EventHandler(this.TSB_Cancel_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // TSB_Add_Eum
            // 
            this.TSB_Add_Eum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Add_Eum.Image = global::CANStream.Icones.Enumeration_Add_16;
            this.TSB_Add_Eum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Add_Eum.Name = "TSB_Add_Eum";
            this.TSB_Add_Eum.Size = new System.Drawing.Size(23, 22);
            this.TSB_Add_Eum.Text = "toolStripButton3";
            this.TSB_Add_Eum.ToolTipText = "Add an enumeration value";
            this.TSB_Add_Eum.Click += new System.EventHandler(this.TSB_Add_Eum_Click);
            // 
            // TSB_Del_Enum
            // 
            this.TSB_Del_Enum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Del_Enum.Image = global::CANStream.Icones.Enumeration_Del_16;
            this.TSB_Del_Enum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Del_Enum.Name = "TSB_Del_Enum";
            this.TSB_Del_Enum.Size = new System.Drawing.Size(23, 22);
            this.TSB_Del_Enum.Text = "toolStripButton4";
            this.TSB_Del_Enum.ToolTipText = "Remove selected enumeration values";
            this.TSB_Del_Enum.Click += new System.EventHandler(this.TSB_Del_Enum_Click);
            // 
            // TSB_Clear_Enum
            // 
            this.TSB_Clear_Enum.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TSB_Clear_Enum.Image = global::CANStream.Icones.Delete_16;
            this.TSB_Clear_Enum.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TSB_Clear_Enum.Name = "TSB_Clear_Enum";
            this.TSB_Clear_Enum.Size = new System.Drawing.Size(23, 22);
            this.TSB_Clear_Enum.Text = "toolStripButton5";
            this.TSB_Clear_Enum.ToolTipText = "Clear enumeration values";
            this.TSB_Clear_Enum.Click += new System.EventHandler(this.TSB_Clear_Enum_Click);
            // 
            // Grid_Enum
            // 
            this.Grid_Enum.AllowUserToAddRows = false;
            this.Grid_Enum.AllowUserToDeleteRows = false;
            this.Grid_Enum.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid_Enum.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid_Enum.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Enum_Value_Column,
            this.Enum_Text_Col});
            this.Grid_Enum.ContextMenuStrip = this.Context_GridEnum;
            this.Grid_Enum.Location = new System.Drawing.Point(0, 28);
            this.Grid_Enum.Name = "Grid_Enum";
            this.Grid_Enum.RowHeadersVisible = false;
            this.Grid_Enum.Size = new System.Drawing.Size(283, 398);
            this.Grid_Enum.TabIndex = 1;
            // 
            // Enum_Value_Column
            // 
            this.Enum_Value_Column.HeaderText = "Value";
            this.Enum_Value_Column.Name = "Enum_Value_Column";
            // 
            // Enum_Text_Col
            // 
            this.Enum_Text_Col.HeaderText = "Text";
            this.Enum_Text_Col.Name = "Enum_Text_Col";
            this.Enum_Text_Col.Width = 180;
            // 
            // Context_GridEnum
            // 
            this.Context_GridEnum.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TSMI_Add_Value,
            this.TSMI_Del_Value,
            this.TSMI_Clear_Value});
            this.Context_GridEnum.Name = "Context_GridEnum";
            this.Context_GridEnum.Size = new System.Drawing.Size(208, 70);
            // 
            // TSMI_Add_Value
            // 
            this.TSMI_Add_Value.Image = global::CANStream.Icones.Enumeration_Add_16;
            this.TSMI_Add_Value.Name = "TSMI_Add_Value";
            this.TSMI_Add_Value.Size = new System.Drawing.Size(207, 22);
            this.TSMI_Add_Value.Text = "Add enum value";
            this.TSMI_Add_Value.Click += new System.EventHandler(this.TSMI_Add_Value_Click);
            // 
            // TSMI_Del_Value
            // 
            this.TSMI_Del_Value.Image = global::CANStream.Icones.Enumeration_Del_16;
            this.TSMI_Del_Value.Name = "TSMI_Del_Value";
            this.TSMI_Del_Value.Size = new System.Drawing.Size(207, 22);
            this.TSMI_Del_Value.Text = "Del selected enum values";
            this.TSMI_Del_Value.Click += new System.EventHandler(this.TSMI_Del_Value_Click);
            // 
            // TSMI_Clear_Value
            // 
            this.TSMI_Clear_Value.Image = global::CANStream.Icones.Delete_16;
            this.TSMI_Clear_Value.Name = "TSMI_Clear_Value";
            this.TSMI_Clear_Value.Size = new System.Drawing.Size(207, 22);
            this.TSMI_Clear_Value.Text = "Clear enum values";
            this.TSMI_Clear_Value.Click += new System.EventHandler(this.TSMI_Clear_Value_Click);
            // 
            // Frm_ParamEnumerationEdition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 427);
            this.Controls.Add(this.Grid_Enum);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Frm_ParamEnumerationEdition";
            this.Text = "Enumeration edition";
            this.Deactivate += new System.EventHandler(this.Frm_ParamEnumerationEdition_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Frm_ParamEnumerationEdition_FormClosing);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid_Enum)).EndInit();
            this.Context_GridEnum.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TSB_Apply;
        private System.Windows.Forms.DataGridView Grid_Enum;
        private System.Windows.Forms.ToolStripButton TSB_Cancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TSB_Add_Eum;
        private System.Windows.Forms.ToolStripButton TSB_Del_Enum;
        private System.Windows.Forms.ToolStripButton TSB_Clear_Enum;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enum_Value_Column;
        private System.Windows.Forms.DataGridViewTextBoxColumn Enum_Text_Col;
        private System.Windows.Forms.ContextMenuStrip Context_GridEnum;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Add_Value;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Del_Value;
        private System.Windows.Forms.ToolStripMenuItem TSMI_Clear_Value;
    }
}