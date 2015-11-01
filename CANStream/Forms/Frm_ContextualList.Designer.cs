/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 2/6/2014
 * Time: 13:34 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CANStream
{
	partial class Frm_ContextualList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_ContextualList));
            this.LV_Items = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Img_LVItems = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // LV_Items
            // 
            this.LV_Items.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.LV_Items.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.LV_Items.Location = new System.Drawing.Point(4, 3);
            this.LV_Items.MultiSelect = false;
            this.LV_Items.Name = "LV_Items";
            this.LV_Items.Size = new System.Drawing.Size(178, 208);
            this.LV_Items.SmallImageList = this.Img_LVItems;
            this.LV_Items.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.LV_Items.TabIndex = 0;
            this.LV_Items.UseCompatibleStateImageBehavior = false;
            this.LV_Items.View = System.Windows.Forms.View.Details;
            this.LV_Items.DoubleClick += new System.EventHandler(this.LV_ItemsDoubleClick);
            this.LV_Items.KeyDown += new System.Windows.Forms.KeyEventHandler(this.LV_ItemsKeyDown);
            this.LV_Items.MouseLeave += new System.EventHandler(this.LV_ItemsMouseLeave);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 173;
            // 
            // Img_LVItems
            // 
            this.Img_LVItems.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Img_LVItems.ImageStream")));
            this.Img_LVItems.TransparentColor = System.Drawing.Color.Transparent;
            this.Img_LVItems.Images.SetKeyName(0, "add-brick-icone-9028-16.png");
            this.Img_LVItems.Images.SetKeyName(1, "add-plugin-icone-5344-16.png");
            this.Img_LVItems.Images.SetKeyName(2, "add-rack-icone-7430-16.png");
            this.Img_LVItems.Images.SetKeyName(3, "parametres-theme-icone-3702-16.png");
            this.Img_LVItems.Images.SetKeyName(4, "edu-des-mathematiques-icone-4069-16.png");
            this.Img_LVItems.Images.SetKeyName(5, "gear-wheel-system-package-icone-9540-16.png");
            // 
            // Frm_ContextualList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(185, 214);
            this.Controls.Add(this.LV_Items);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Frm_ContextualList";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Frm_ContextualList";
            this.Activated += new System.EventHandler(this.Frm_ContextualList_Activated);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ImageList Img_LVItems;
		private System.Windows.Forms.ListView LV_Items;
	}
}
