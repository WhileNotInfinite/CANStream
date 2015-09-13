namespace CANStream
{
    partial class DashboardBarGraph
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Pic_BarGraph = new System.Windows.Forms.PictureBox();
            this.Lbl_Title = new System.Windows.Forms.Label();
            this.Pic_Scale = new System.Windows.Forms.PictureBox();
            this.Lbl_Value = new System.Windows.Forms.Label();
            this.Lbl_MinValue = new System.Windows.Forms.Label();
            this.Lbl_MaxValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_BarGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Scale)).BeginInit();
            this.SuspendLayout();
            // 
            // Pic_BarGraph
            // 
            this.Pic_BarGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pic_BarGraph.BackColor = System.Drawing.Color.White;
            this.Pic_BarGraph.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Pic_BarGraph.Location = new System.Drawing.Point(80, 44);
            this.Pic_BarGraph.Name = "Pic_BarGraph";
            this.Pic_BarGraph.Size = new System.Drawing.Size(316, 48);
            this.Pic_BarGraph.TabIndex = 0;
            this.Pic_BarGraph.TabStop = false;
            // 
            // Lbl_Title
            // 
            this.Lbl_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Lbl_Title.AutoSize = true;
            this.Lbl_Title.Location = new System.Drawing.Point(3, 103);
            this.Lbl_Title.Name = "Lbl_Title";
            this.Lbl_Title.Size = new System.Drawing.Size(35, 13);
            this.Lbl_Title.TabIndex = 1;
            this.Lbl_Title.Text = "label1";
            // 
            // Pic_Scale
            // 
            this.Pic_Scale.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Pic_Scale.Location = new System.Drawing.Point(80, 5);
            this.Pic_Scale.Name = "Pic_Scale";
            this.Pic_Scale.Size = new System.Drawing.Size(316, 33);
            this.Pic_Scale.TabIndex = 2;
            this.Pic_Scale.TabStop = false;
            // 
            // Lbl_Value
            // 
            this.Lbl_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_Value.Location = new System.Drawing.Point(3, 5);
            this.Lbl_Value.Name = "Lbl_Value";
            this.Lbl_Value.Size = new System.Drawing.Size(71, 33);
            this.Lbl_Value.TabIndex = 3;
            this.Lbl_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_MinValue
            // 
            this.Lbl_MinValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_MinValue.Location = new System.Drawing.Point(3, 44);
            this.Lbl_MinValue.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_MinValue.Name = "Lbl_MinValue";
            this.Lbl_MinValue.Size = new System.Drawing.Size(71, 24);
            this.Lbl_MinValue.TabIndex = 4;
            this.Lbl_MinValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lbl_MaxValue
            // 
            this.Lbl_MaxValue.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Lbl_MaxValue.Location = new System.Drawing.Point(3, 68);
            this.Lbl_MaxValue.Margin = new System.Windows.Forms.Padding(0);
            this.Lbl_MaxValue.Name = "Lbl_MaxValue";
            this.Lbl_MaxValue.Size = new System.Drawing.Size(71, 24);
            this.Lbl_MaxValue.TabIndex = 5;
            this.Lbl_MaxValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DashboardBarGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Lbl_MaxValue);
            this.Controls.Add(this.Lbl_MinValue);
            this.Controls.Add(this.Lbl_Value);
            this.Controls.Add(this.Pic_Scale);
            this.Controls.Add(this.Lbl_Title);
            this.Controls.Add(this.Pic_BarGraph);
            this.Name = "DashboardBarGraph";
            this.Size = new System.Drawing.Size(399, 125);
            ((System.ComponentModel.ISupportInitialize)(this.Pic_BarGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Pic_Scale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pic_BarGraph;
        private System.Windows.Forms.Label Lbl_Title;
        private System.Windows.Forms.PictureBox Pic_Scale;
        private System.Windows.Forms.Label Lbl_Value;
        private System.Windows.Forms.Label Lbl_MinValue;
        private System.Windows.Forms.Label Lbl_MaxValue;
    }
}
