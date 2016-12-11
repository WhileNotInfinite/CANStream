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
    partial class Frm_DataViewer_DataFile_Info_Edition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_DataViewer_DataFile_Info_Edition));
            this.Tabs_DataFiles = new System.Windows.Forms.TabControl();
            this.Cmd_Save = new System.Windows.Forms.Button();
            this.Cmd_SaveAll = new System.Windows.Forms.Button();
            this.Cmd_Cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Tabs_DataFiles
            // 
            this.Tabs_DataFiles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Tabs_DataFiles.Location = new System.Drawing.Point(3, 3);
            this.Tabs_DataFiles.Margin = new System.Windows.Forms.Padding(1);
            this.Tabs_DataFiles.Name = "Tabs_DataFiles";
            this.Tabs_DataFiles.SelectedIndex = 0;
            this.Tabs_DataFiles.Size = new System.Drawing.Size(529, 658);
            this.Tabs_DataFiles.TabIndex = 0;
            // 
            // Cmd_Save
            // 
            this.Cmd_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Save.Location = new System.Drawing.Point(448, 665);
            this.Cmd_Save.Name = "Cmd_Save";
            this.Cmd_Save.Size = new System.Drawing.Size(75, 23);
            this.Cmd_Save.TabIndex = 1;
            this.Cmd_Save.Text = "Save";
            this.Cmd_Save.UseVisualStyleBackColor = true;
            // 
            // Cmd_SaveAll
            // 
            this.Cmd_SaveAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_SaveAll.Location = new System.Drawing.Point(367, 665);
            this.Cmd_SaveAll.Name = "Cmd_SaveAll";
            this.Cmd_SaveAll.Size = new System.Drawing.Size(75, 23);
            this.Cmd_SaveAll.TabIndex = 2;
            this.Cmd_SaveAll.Text = "Save All";
            this.Cmd_SaveAll.UseVisualStyleBackColor = true;
            // 
            // Cmd_Cancel
            // 
            this.Cmd_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmd_Cancel.Location = new System.Drawing.Point(286, 665);
            this.Cmd_Cancel.Name = "Cmd_Cancel";
            this.Cmd_Cancel.Size = new System.Drawing.Size(75, 23);
            this.Cmd_Cancel.TabIndex = 3;
            this.Cmd_Cancel.Text = "Cancel";
            this.Cmd_Cancel.UseVisualStyleBackColor = true;
            // 
            // Frm_DataViewer_DataFile_Info_Edition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 698);
            this.Controls.Add(this.Cmd_Cancel);
            this.Controls.Add(this.Cmd_SaveAll);
            this.Controls.Add(this.Cmd_Save);
            this.Controls.Add(this.Tabs_DataFiles);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_DataViewer_DataFile_Info_Edition";
            this.Text = "Data files information";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs_DataFiles;
        private System.Windows.Forms.Button Cmd_Save;
        private System.Windows.Forms.Button Cmd_SaveAll;
        private System.Windows.Forms.Button Cmd_Cancel;
    }
}