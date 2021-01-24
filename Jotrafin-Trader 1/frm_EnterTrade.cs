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
	public partial class frm_EnterTrade : Form
	{
		private CTrade tr;
		private double dbl_balance;
		private bool b_cancelFormClosing;

		public frm_EnterTrade()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			this.tr = new CTrade();
			this.txtBox_tradeID.Text = this.tr.TradeID;
			this.cBox_position.SelectedIndex = 0;
			this.b_cancelFormClosing = false;
			this.FormClosing+= new FormClosingEventHandler(OnFormClosing);
		}

		#region Accessors
		/// <summary>
		/// Gets the CTrade object.
		/// </summary>
		public CTrade Trade
		{
			get { return this.tr; }
		}
		public double Balance
		{
			get { return this.dbl_balance; }
			set 
			{ 
				this.dbl_balance = value;
				this.txtBox_currentBalance.Text = this.dbl_balance.ToString("$#,##0.00");
			}
		}
		#endregion (Accessors)

		#region Event Handlers
		private void btn_ok_Click(object sender, EventArgs e)
		{
			LoadData();
			this.tr.CommitNewTradeID();
			this.Close();
		}
		private void txtBox_stop_TextChanged(object sender, EventArgs e)
		{
			if (this.txtBox_stop.Text.Length > 0)
				CalculateRisk();
		}
		#endregion (Event Handlers)

		#region Help Functions
		private void CalculateRisk()
		{
			double p = 0, s, r, bol, rip, l = 0;

			if (this.txtBox_price.Text.Length > 0)
				p = double.Parse(this.txtBox_price.Text);		// Price
			s = double.Parse(this.txtBox_stop.Text);			// Stop
			if (this.txtBox_lots.Text.Length > 0)
				l = double.Parse(this.txtBox_lots.Text);		// Number of lots
			r = Math.Abs(p - s) * 10000 * 10 * l;
			bol = this.dbl_balance - r;							// Balance On Loss
			rip = r / this.dbl_balance;							// Risk in percent of current balance

			// Displpay values
			this.txtBox_riskInCurrency.Text = r.ToString("$#,##0.00");
			this.txtBox_riskInPercent.Text = rip.ToString("0.00%");
			this.txtBox_balanceOnLoss.Text = bol.ToString("$#,##0.00");
		}
		#endregion (Help Functions)
		
		private void LoadData()
		{
			bool ok = true;
			if (this.txtBox_price.Text != "")
				this.tr.Price = double.Parse(this.txtBox_price.Text);
			else
			{
				ok = false;
				MessageBox.Show("Enter a price!","Entry Error!",MessageBoxButtons.OK,MessageBoxIcon.Warning);
				this.b_cancelFormClosing = true;
				this.txtBox_price.Focus();
			}
			if(ok && this.txtBox_lots.Text!="")
				this.tr.TradeLots = double.Parse(this.txtBox_lots.Text);
			else
			{
				if (ok)
				{
					ok = false;
					MessageBox.Show("Lots can not be blank!\r\nEnter a value greater or equal to 0.1", "Entry Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.b_cancelFormClosing = true;
					this.txtBox_lots.Focus();
				}
			}
			if(ok)
				//this.tr.Pair = this.cBox_currency.SelectedItem.ToString();  // Un-comment when Currency Pair is ready to use.
			if (this.cBox_position.SelectedItem.ToString() == "Long" || (string)this.cBox_position.SelectedItem == "Short")
				this.tr.Position = this.cBox_position.SelectedItem.ToString();
			else
			{
				if (ok)
				{
					ok = false;
					MessageBox.Show("Position can ONLY have one of the two supplied values \"Long\" or \"Short\".\r\nPlease select on of the provided values.", "Entry Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					MessageBox.Show("Selected Text: " + cBox_position.SelectedText + "\r\nSelected Item: " + cBox_position.SelectedItem + "\r\nSelected Value: " + cBox_position.SelectedValue);
					this.b_cancelFormClosing = true;
					this.cBox_position.Focus();
				}
			}
			if(ok && this.txtBox_stop.Text!="")
				this.tr.Stop = double.Parse(this.txtBox_stop.Text);
			else
			{
				if (ok)
				{
					ok = false;
					MessageBox.Show("Enter Stop/Loss price!\r\nNo trades without proper stops accepted.", "Entry Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					this.b_cancelFormClosing = true;
					this.txtBox_stop.Focus();
				}
			}

			if (ok && this.txtBox_limit1Price.Text != "")
				this.tr.Limit1 = double.Parse(this.txtBox_limit1Price.Text);
			if (ok && this.txtBox_limit1Lots.Text != "")
				this.tr.Lots_Limit1 = double.Parse(this.txtBox_limit1Lots.Text);
			if (ok && this.txtBox_limit2Price.Text != "")
				this.tr.Limit2 = double.Parse(this.txtBox_limit2Price.Text);
			if (ok && this.txtBox_limit2Lots.Text != "")
				this.tr.Lots_Limit2 = double.Parse(this.txtBox_limit2Lots.Text);
			if (ok && this.txtBox_limit3Price.Text != "")
				this.tr.Limit3 = double.Parse(this.txtBox_limit3Price.Text);
			if (ok && this.txtBox_limit3Lots.Text != "")
				this.tr.Lots_Limit3 = double.Parse(this.txtBox_limit3Lots.Text);
			if (ok && this.txtBox_notes.Text != "")
				this.tr.Note = this.txtBox_notes.Text;
			this.tr.TrailingStop = this.checkBox_trailingStop.Checked;
		}

		public void OnFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = this.b_cancelFormClosing;
			this.b_cancelFormClosing = false;
		}
	}

	public class InvalidEntryArgs : EventArgs
	{
	}

	public delegate void InvalidEntryEventHandler(object sender, InvalidEntryArgs e);
}
