namespace CANStream
{
    partial class Frm_Dash_ToolBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Dash_ToolBox));
            this.Grp_Filter = new System.Windows.Forms.GroupBox();
            this.Cmb_Filter = new System.Windows.Forms.ComboBox();
            this.LV_Tools = new System.Windows.Forms.ListView();
            this.Img_LV_Tools = new System.Windows.Forms.ImageList(this.components);
            this.Grp_Filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // Grp_Filter
            // 
            this.Grp_Filter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grp_Filter.Controls.Add(this.Cmb_Filter);
            this.Grp_Filter.Location = new System.Drawing.Point(3, 411);
            this.Grp_Filter.Name = "Grp_Filter";
            this.Grp_Filter.Size = new System.Drawing.Size(228, 44);
            this.Grp_Filter.TabIndex = 2;
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
            // LV_Tools
            // 
            this.LV_Tools.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LV_Tools.Location = new System.Drawing.Point(3, 2);
            this.LV_Tools.Name = "LV_Tools";
            this.LV_Tools.Size = new System.Drawing.Size(228, 403);
            this.LV_Tools.SmallImageList = this.Img_LV_Tools;
            this.LV_Tools.TabIndex = 3;
            this.LV_Tools.UseCompatibleStateImageBehavior = false;
            this.LV_Tools.View = System.Windows.Forms.View.SmallIcon;
            this.LV_Tools.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.LV_Tools_ItemDrag);
            this.LV_Tools.DragOver += new System.Windows.Forms.DragEventHandler(this.LV_Tools_DragOver);
            // 
            // Img_LV_Tools
            // 
            this.Img_LV_Tools.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_LV_Tools.ImageStream")));
            this.Img_LV_Tools.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_LV_Tools.Images.SetKeyName(0, "1439828977_100_Pressure_Reading.png");
            // 
            // Frm_Dash_ToolBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(235, 457);
            this.Controls.Add(this.LV_Tools);
            this.Controls.Add(this.Grp_Filter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HideOnClose = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Frm_Dash_ToolBox";
            this.Text = "Toolbox";
            this.Grp_Filter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Grp_Filter;
        private System.Windows.Forms.ComboBox Cmb_Filter;
        private System.Windows.Forms.ListView LV_Tools;
        private System.Windows.Forms.ImageList Img_LV_Tools;
    }
}