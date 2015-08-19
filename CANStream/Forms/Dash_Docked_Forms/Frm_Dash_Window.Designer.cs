namespace CANStream
{
    partial class Frm_Dash_Window
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Dash_Window));
            this.Dash_Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // Dash_Panel
            // 
            this.Dash_Panel.AllowDrop = true;
            this.Dash_Panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Dash_Panel.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Dash_Panel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Dash_Panel.Location = new System.Drawing.Point(3, 3);
            this.Dash_Panel.Name = "Dash_Panel";
            this.Dash_Panel.Size = new System.Drawing.Size(622, 459);
            this.Dash_Panel.TabIndex = 0;
            this.Dash_Panel.DragDrop += new System.Windows.Forms.DragEventHandler(this.Dash_Panel_DragDrop);
            this.Dash_Panel.DragOver += new System.Windows.Forms.DragEventHandler(this.Dash_Panel_DragOver);
            this.Dash_Panel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Dash_Panel_MouseClick);
            // 
            // Frm_Dash_Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(629, 466);
            this.Controls.Add(this.Dash_Panel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Dash_Window";
            this.Text = "Dash";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Dash_Panel;
    }
}