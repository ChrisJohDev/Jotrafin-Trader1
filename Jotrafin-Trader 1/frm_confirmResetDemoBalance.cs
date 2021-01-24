using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D4M.FINANCE.JOTRAFIN
{
	public partial class frm_confirmResetDemoBalance : Form
	{
		public bool NewAmount;
		public double NewDefaultAmount;
		private bool cancelClosing;

		public frm_confirmResetDemoBalance()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			this.cancelClosing = false;
			this.FormClosing += new FormClosingEventHandler(this.OnFormClosing_hndlr); 
		}


		public void OnFormClosing_hndlr(object sender, FormClosingEventArgs ex)
		{
			ex.Cancel = this.cancelClosing;
			this.cancelClosing = false;			// Reset the cancelClosing variable.
		}
		private void checkBox_newDefault_CheckedChanged(object sender, EventArgs e)
		{
			this.NewAmount = this.checkBox_newDefault.Checked;
			if (this.checkBox_newDefault.Checked)
			{
				this.lbl_defaultAmount.Visible = true;
				this.txtBox_defaultAmount.Visible = true;
				this.txtBox_defaultAmount.Focus();
			}
			else
			{
				this.lbl_defaultAmount.Visible = false;
				this.txtBox_defaultAmount.Visible = false;
			}
		}

		private void bnt_ok_Click(object sender, EventArgs e)
		{
			if (this.NewAmount)
			{
				try
				{
					this.NewDefaultAmount = double.Parse(this.txtBox_defaultAmount.Text);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Box can NOT be empty. Only digits 0-9 and period \".\" are allowed.\r\nIf no new amount is to be entered then un-check box!", "Input Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
					this.cancelClosing = true;
				}
			}
		}
	}
}
