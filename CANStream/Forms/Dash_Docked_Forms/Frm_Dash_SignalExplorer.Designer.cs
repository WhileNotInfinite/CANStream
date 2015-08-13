namespace CANStream
{
    partial class Frm_Dash_SignalExplorer
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
            this.TV_SignalExplorer = new System.Windows.Forms.TreeView();
            this.Grp_Filter = new System.Windows.Forms.GroupBox();
            this.Cmb_Filter = new System.Windows.Forms.ComboBox();
            this.Grp_Filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // TV_SignalExplorer
            // 
            this.TV_SignalExplorer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TV_SignalExplorer.Location = new System.Drawing.Point(2, 3);
            this.TV_SignalExplorer.Name = "TV_SignalExplorer";
            this.TV_SignalExplorer.ShowRootLines = false;
            this.TV_SignalExplorer.Size = new System.Drawing.Size(228, 320);
            this.TV_SignalExplorer.TabIndex = 0;
            // 
            // Grp_Filter
            // 
            this.Grp_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Filter.Controls.Add(this.Cmb_Filter);
            this.Grp_Filter.Location = new System.Drawing.Point(2, 329);
            this.Grp_Filter.Name = "Grp_Filter";
            this.Grp_Filter.Size = new System.Drawing.Size(228, 44);
            this.Grp_Filter.TabIndex = 1;
            this.Grp_Filter.TabStop = false;
            this.Grp_Filter.Text = "Filter";
            // 
            // Cmb_Filter
            // 
            this.Cmb_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Filter.FormattingEnabled = true;
            this.Cmb_Filter.Location = new System.Drawing.Point(10, 19);
            this.Cmb_Filter.Name = "Cmb_Filter";
            this.Cmb_Filter.Size = new System.Drawing.Size(212, 21);
            this.Cmb_Filter.TabIndex = 0;
            // 
            // Frm_Dash_SignalExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(234, 375);
            this.Controls.Add(this.Grp_Filter);
            this.Controls.Add(this.TV_SignalExplorer);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeMode = System.Windows.Forms.ImeMode.On;
            this.Name = "Frm_Dash_SignalExplorer";
            this.Text = "CAN Signal explorer";
            this.Grp_Filter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TV_SignalExplorer;
        private System.Windows.Forms.GroupBox Grp_Filter;
        private System.Windows.Forms.ComboBox Cmb_Filter;
    }
}