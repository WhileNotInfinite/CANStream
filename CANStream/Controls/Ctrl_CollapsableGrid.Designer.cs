namespace CANStream
{
    partial class Ctrl_CollapsableGrid
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ctrl_CollapsableGrid));
            this.oGrid = new System.Windows.Forms.DataGridView();
            this.CollapsedStatusColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Img_RowState = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // oGrid
            // 
            this.oGrid.AllowUserToAddRows = false;
            this.oGrid.AllowUserToDeleteRows = false;
            this.oGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.oGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.oGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CollapsedStatusColumn,
            this.Column2});
            this.oGrid.Location = new System.Drawing.Point(3, 3);
            this.oGrid.Name = "oGrid";
            this.oGrid.RowHeadersVisible = false;
            this.oGrid.Size = new System.Drawing.Size(457, 210);
            this.oGrid.TabIndex = 0;
            this.oGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.oGrid_CellDoubleClick);
            this.oGrid.Resize += new System.EventHandler(this.oGrid_Resize);
            // 
            // CollapsedStatusColumn
            // 
            this.CollapsedStatusColumn.HeaderText = "";
            this.CollapsedStatusColumn.MinimumWidth = 21;
            this.CollapsedStatusColumn.Name = "CollapsedStatusColumn";
            this.CollapsedStatusColumn.ReadOnly = true;
            this.CollapsedStatusColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.CollapsedStatusColumn.Width = 21;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Column2";
            this.Column2.Name = "Column2";
            // 
            // Img_RowState
            // 
            this.Img_RowState.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_RowState.ImageStream")));
            this.Img_RowState.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_RowState.Images.SetKeyName(0, "Grid_NoAction2.png");
            this.Img_RowState.Images.SetKeyName(1, "1478993774_toggle-small-expand.ico");
            this.Img_RowState.Images.SetKeyName(2, "1478993842_toggle_small_collapse.ico");
            // 
            // Ctrl_CollapsableGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.oGrid);
            this.Name = "Ctrl_CollapsableGrid";
            this.Size = new System.Drawing.Size(463, 216);
            ((System.ComponentModel.ISupportInitialize)(this.oGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView oGrid;
        private System.Windows.Forms.ImageList Img_RowState;
        private System.Windows.Forms.DataGridViewImageColumn CollapsedStatusColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}
