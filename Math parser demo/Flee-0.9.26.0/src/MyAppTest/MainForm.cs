/*
 * Created by SharpDevelop.
 * User: VBrault
 * Date: 2/12/2014
 * Time: 10:07 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using Ciloci.Flee;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MyAppTest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private class ExprOwner
		{
			public double A;
			public double B;
			
			public ExprOwner()
			{
				A=0;
				B=0;
			}
		}
		
		ExpressionContext MyContext;
		//ExprOwner oOwner;
		
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//oOwner = new MainForm.ExprOwner();
			//MyContext = new ExpressionContext(oOwner);
			MyContext = new ExpressionContext();
			
			MyContext.Options.IntegersAsDoubles=true;
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, System.EventArgs e)
		{
			IGenericExpression<double> Expr = null;
			
			try
			{
				MyContext.Variables.Clear();
				
				double dVarA = Convert.ToDouble(VarA.Text);
				double dVarB = Convert.ToDouble(VarB.Text);
				
				MyContext.Variables.Add("A",dVarA);
				MyContext.Variables.Add("B",dVarB);
				
				Expr = MyContext.CompileGeneric<double>(textBox1.Text);
				
				//oOwner.A = Convert.ToDouble(VarA.Text);
				//oOwner.B = Convert.ToDouble(VarB.Text);
				
				double Res = Expr.Evaluate();
				textBox2.Text = Res.ToString();
			}
			catch (ExpressionCompileException Ex)
			{
				textBox2.Text = Ex.Message;
		
			}
		}
	}
}
