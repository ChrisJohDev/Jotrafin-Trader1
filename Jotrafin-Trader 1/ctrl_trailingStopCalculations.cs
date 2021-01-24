using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using D4M.Controls.Common;

namespace D4M.FINANCE.JOTRAFIN
{
	public partial class ctrl_trailingStopCalculations : D4MControl
	{
		private double pr, chng;
		private bool pips4, directionUp;
		private string strFrm;
		private double currTarget = -1;

		//public delegate void CloseStopCalculationControlEventHandler(object sender, CloseControlEventArgs<ctrl_trailingStopCalculations> arg);
		public event CloseControlEventHandler CloseControlEvent;
		public delegate void StopCalculatedEventHandler(object sender,StopCalculatedEventArgs arg);
		public event StopCalculatedEventHandler StopCalculated;

		public ctrl_trailingStopCalculations()
		{
			InitializeComponent();
		}

		private void ClearCalculations(object sender, EventArgs e)
		{
			UnLockInput();
			LockNavKeys();
			this.tb_in_pipsChange.ResetText();
			this.tb_in_price.ResetText();
			this.tb_out_currTarget.ResetText();
			this.tb_out_stop.ResetText();
			this.tb_out_next.ResetText();
			this.currTarget = -1;
			this.btn_calc.Enabled = true;
		}

		private void Calculate(object sender, EventArgs arg)
		{
			try
			{
				directionUp = this.rbtn_in_up.Checked;
				pips4 = this.rbtn_in_4pips.Checked;
				this.pr = double.Parse(this.tb_in_price.Text);
				if (this.tb_in_pipsChange.Text.Contains('.'))
					this.chng = double.Parse(this.tb_in_pipsChange.Text);
				else if (pips4)
					this.chng = double.Parse(this.tb_in_pipsChange.Text) / 10000;
				else
					this.chng = double.Parse(this.tb_in_pipsChange.Text) / 10;
				strFrm = pips4 ? "#,##0.0000" : "#,##0.00";
				LockInput();
				UnLockNavKeys();
				currTarget = directionUp ? pr + chng : pr - chng;
				this.btn_calc.Enabled = false;
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message);
			}
			
			ShowResult();
		}

		private void ShowResult()
		{
			if (currTarget != -1)
			{
				this.tb_out_stop.Text = (directionUp ? currTarget - chng : currTarget + chng).ToString(strFrm);
				this.tb_out_currTarget.Text = currTarget.ToString(strFrm);
				this.tb_out_next.Text = (directionUp ? currTarget + chng : currTarget - chng).ToString(strFrm);

				StopCalculatedEventArgs arg = new StopCalculatedEventArgs(this.tb_out_stop.Text, this.tb_out_currTarget.Text, this.tb_out_next.Text);
				StopCalculated(this, arg);
			}
		}

		private void LockNavKeys()
		{
			this.btn_prev.Enabled = false;
			this.btn_next.Enabled = false;
		}
		private void UnLockNavKeys()
		{
			this.btn_next.Enabled = true;
			this.btn_prev.Enabled = true;
		}
		private void LockInput()
		{
			this.panel_direction.Enabled = false;
			this.panel_pips.Enabled = false;
			this.tb_in_pipsChange.Enabled = false;
			this.tb_in_price.Enabled = false;
		}

		private void UnLockInput()
		{
			this.panel_direction.Enabled = true;
			this.panel_pips.Enabled = true;
			this.tb_in_pipsChange.Enabled = true;
			this.tb_in_price.Enabled = true;
			
		}

		private void CloseMe(object sender, EventArgs arg)
		{
			OnCloseControl(new CloseControlEventArgs());
		}

		private void OnCloseControl(D4M.Controls.Common.CloseControlEventArgs arg)
		{
			CloseControlEvent(this, arg);
		}

		private void ControlActive(object sender, EventArgs arg)
		{
			this.tb_in_price.Focus();
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData.Equals(Keys.Enter) && currTarget == -1)
			{
				this.btn_calc.PerformClick();
				this.btn_next.Focus();
				return true;
			}
			else if (currTarget != -1 && (keyData.Equals(Keys.Enter) || keyData.Equals(Keys.Right) || keyData.Equals(Keys.Up)))
			{
				this.btn_next.PerformClick();
				this.btn_next.Focus();
				return true;
			}
			else if (currTarget != -1 && (keyData.Equals(Keys.Down) || keyData.Equals(Keys.Left)))
			{
				this.btn_prev.PerformClick();
				this.btn_prev.Focus();
				return true;
			}
			else
				return base.ProcessDialogKey(keyData);
		}

		private void btn_prev_Click(object sender, EventArgs e)
		{
			if (directionUp) currTarget -= chng;
			else currTarget += chng;
			ShowResult();
		}

		private void btn_next_Click(object sender, EventArgs e)
		{
			if (directionUp) currTarget += chng;
			else currTarget -= chng;
			ShowResult();
		}
	}

	public class StopCalculatedEventArgs : EventArgs
	{
		string l, c, n;

		public StopCalculatedEventArgs(string stop, string target, string next)
		{
			l = stop;
			c = target;
			n = next;
		}

		public string Stop
		{
			get { return this.l; }
		}

		public string CurrentTarget
		{
			get { return this.c; }
		}

		public string Next
		{
			get { return this.n; }
		}
	}
}
