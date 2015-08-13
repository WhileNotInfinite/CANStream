namespace CANStream
{
    partial class Frm_Dash_ControlProperties
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
            this.PropGrid = new System.Windows.Forms.PropertyGrid();
            this.Cmb_Controls = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // PropGrid
            // 
            this.PropGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PropGrid.CategoryForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.PropGrid.Location = new System.Drawing.Point(3, 30);
            this.PropGrid.Name = "PropGrid";
            this.PropGrid.Size = new System.Drawing.Size(240, 447);
            this.PropGrid.TabIndex = 0;
            // 
            // Cmb_Controls
            // 
            this.Cmb_Controls.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Cmb_Controls.FormattingEnabled = true;
            this.Cmb_Controls.Location = new System.Drawing.Point(3, 3);
            this.Cmb_Controls.Name = "Cmb_Controls";
            this.Cmb_Controls.Size = new System.Drawing.Size(240, 21);
            this.Cmb_Controls.TabIndex = 1;
            // 
            // Frm_Dash_ControlProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(245, 482);
            this.Controls.Add(this.Cmb_Controls);
            this.Controls.Add(this.PropGrid);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Frm_Dash_ControlProperties";
            this.Text = "Properties";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid PropGrid;
        private System.Windows.Forms.ComboBox Cmb_Controls;
    }
}