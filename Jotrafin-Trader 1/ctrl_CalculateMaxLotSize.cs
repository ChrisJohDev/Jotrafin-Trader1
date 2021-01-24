using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using D4M.Controls.Common;

namespace D4M.FINANCE.JOTRAFIN
{
	public partial class ctrl_CalculateMaxLotSize : D4MControl
	{
		double equity, risk, pips, pipValue, lotSize;

		public delegate void MaxLotSizeCalculatedEventHandler(object sender, MaxLotSizeCalculatedEventArgs e);
		public event MaxLotSizeCalculatedEventHandler MaxLotSizeCalculated;
		public event CloseControlEventHandler CloseControlEvent;

		public ctrl_CalculateMaxLotSize()
		{
			InitializeComponent();
			this.textBox_in_equity.Focus();
		}

		private void Calculate(object sender, EventArgs e)
		{
			if (getData() || sender.GetType()==typeof(string) && ((string)sender).Equals("external"))
			{
				double tmp_risk = equity * risk;
				double tmp_lots = 0;

				if (equity < 10000)
				{
					for (int i = 1; i < 1701; i++)
					{
						tmp_lots = (double.Parse(i.ToString()) / 10) * pipValue * pips;
						if (tmp_lots > tmp_risk)
						{
							lotSize = (double.Parse(i.ToString()) - 1) / 10;
							break;
						}
					}
				}
				else
				{
					for (int i = 1; i < 171; i++)
					{
						tmp_lots = (double.Parse(i.ToString())) * pipValue * pips;
						if (tmp_lots > tmp_risk)
						{
							lotSize = (double.Parse(i.ToString()) - 1);
							break;
						}
					}
				}
				this.textBox_out_lotSize.Text = lotSize.ToString("0.0");
				OnMaxLotSizeCalculated(new MaxLotSizeCalculatedEventArgs(this.lotSize));
			}
		}

		private bool getData()
		{
			bool rv = true;

			try
			{
				if (this.textBox_in_equity.Text != "") this.equity = double.Parse(this.textBox_in_equity.Text);
				else rv = false;

				if (this.textBox_in_pips.Text != "") this.pips = double.Parse(this.textBox_in_pips.Text);
				else rv = false;

				if (this.textBox_in_pipValue.Text != "") this.pipValue = double.Parse(this.textBox_in_pipValue.Text);
				else rv = false;

				if (this.textBox_in_risk.Text != "")
					this.risk = double.Parse(this.textBox_in_risk.Text) >= 1.0 ? double.Parse(this.textBox_in_risk.Text) / 100.0 : double.Parse(this.textBox_in_risk.Text);
				else rv = false;
			}
			catch (Exception ex)
			{
				rv = false;
			}
			return rv;
		}

		public double CalculateMaxLotSize(double equity, double pips, double pipValue, double percRisk)
		{
			this.equity = equity;
			this.pipValue = pipValue;
			this.pips = pips;
			this.risk = percRisk;

			Calculate("external", new EventArgs());

			return this.lotSize;
		}

		public double LotSize
		{
			get { return this.lotSize; }
		}

		protected virtual void OnMaxLotSizeCalculated(MaxLotSizeCalculatedEventArgs e)
		{
			MaxLotSizeCalculated(this, e);
		}

		private void textBox_Enter(object sender, EventArgs e)
		{
			((TextBox)sender).SelectAll();
		}

		private void frm_CalculateMaxLotSize_Activated(object sender, EventArgs e)
		{
			this.textBox_in_equity.Focus();
		}

		private void closeControl_Click(object sender, EventArgs e)
		{
			OnCloseControl(new D4M.Controls.Common.CloseControlEventArgs());
		}

		protected virtual void OnCloseControl(D4M.Controls.Common.CloseControlEventArgs arg)
		{
			CloseControlEvent(this, arg);
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if(keyData.Equals(Keys.Enter))
			{
				this.button_calc.PerformClick();
			}
			return base.ProcessDialogKey(keyData);
		}
	}

	public class MaxLotSizeCalculatedEventArgs : EventArgs
	{
		private double lotSize;

		public MaxLotSizeCalculatedEventArgs(double lotSize)
			: base()
		{
			this.lotSize = lotSize;
		}

		public double LotSize
		{
			get { return this.lotSize; }
		}
	}
}
