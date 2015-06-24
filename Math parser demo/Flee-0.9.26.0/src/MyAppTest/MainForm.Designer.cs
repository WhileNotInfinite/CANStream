/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 2/12/2014
 * Time: 10:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace MyAppTest
{
	partial class MainForm
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.VarA = new System.Windows.Forms.TextBox();
			this.VarB = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(80, 59);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(168, 20);
			this.textBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(256, 59);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Eval";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(207, 107);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(124, 20);
			this.textBox2.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 62);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(62, 18);
			this.label1.TabIndex = 3;
			this.label1.Text = "Expression";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(161, 110);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(40, 18);
			this.label2.TabIndex = 4;
			this.label2.Text = "Result";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(57, 9);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(17, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "A";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(58, 35);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(16, 18);
			this.label4.TabIndex = 6;
			this.label4.Text = "B";
			// 
			// VarA
			// 
			this.VarA.Location = new System.Drawing.Point(80, 6);
			this.VarA.Name = "VarA";
			this.VarA.Size = new System.Drawing.Size(100, 20);
			this.VarA.TabIndex = 7;
			// 
			// VarB
			// 
			this.VarB.Location = new System.Drawing.Point(80, 32);
			this.VarB.Name = "VarB";
			this.VarB.Size = new System.Drawing.Size(100, 20);
			this.VarB.TabIndex = 8;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(339, 133);
			this.Controls.Add(this.VarB);
			this.Controls.Add(this.VarA);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox1);
			this.Name = "MainForm";
			this.Text = "MyAppTest";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox VarB;
		private System.Windows.Forms.TextBox VarA;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		
		
	}
}
