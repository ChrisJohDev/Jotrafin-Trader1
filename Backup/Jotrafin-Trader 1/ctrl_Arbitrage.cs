using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTAPI;

namespace D4M.FINANCE.JOTRAFIN
{
	/// <summary>
	/// Control is working.
	/// However, the algorithms used in the function "CalculateArbitrage()" needs to be refined and tuned.
	/// The trade buttons are not functioning. Needs to write the code for trade execution and the logic for the execution.
	/// </summary>
	public partial class ctrl_Arbitrage : UserControl
	{
		private CArbitrage data = new CArbitrage();
		private DateTime lastUpdate = new DateTime();
		private VTAPI.Instruments api_instruments;			// Class wide instruments class.

		
		public ctrl_Arbitrage()
		{
			InitializeComponent();
		}

		/// <summary>
		/// To be hooked up to the API_InstrumentChangeExEvent.
		/// </summary>
		/// <param name="InstrumentID"></param>
		/// <param name="Bid"></param>
		/// <param name="Ask"></param>
		/// <param name="Time"></param>
		public void HandleInstrumentChangeEx(string InstrumentID, double Bid, double Ask, System.DateTime Time)
		{
			//	The construct
			// this.tb_out_price_a.Text = Bid.ToString();
			// this.Invalidate(this.tb_out_price_a.Region);
			// Works!

			bool newData = false;
			if (data["pairA"].ID == InstrumentID)
			{
				data["pairA"].Ask = Ask;
				data["pairA"].Bid = Bid;
				lastUpdate = Time;
				newData = true;
				this.tb_out_price_a.Text = Bid.ToString();
				this.Invalidate(this.tb_out_price_a.Region);
			}
			else if (data["pairB"].ID == InstrumentID)
			{
				data["pairB"].Ask = Ask;
				data["pairB"].Bid = Bid;
				lastUpdate = Time;
				newData = true;
				this.tb_out_price_b.Text = Bid.ToString();
				this.Invalidate(this.tb_out_price_b.Region);
			}
			else if (data["pairC"].ID == InstrumentID)
			{
				data["pairC"].Ask = Ask;
				data["pairC"].Bid = Bid;
				lastUpdate = Time;
				newData = true;
				this.tb_out_price_c.Text = Bid.ToString();
				this.Invalidate(this.tb_out_price_c.Region);
			}

			if(newData) CalculateArbitrage();
		}

		/// <summary>
		/// Function is working but the algorithms needs to be refined and tuned.
		/// </summary>
		private void CalculateArbitrage()
		{
			if (data.Count == 3)
			{
				// We need to have a close look at the calculations of the arbitrage prices.
				double a = (data["pairA"].Bid - data["pairB"].Ask * data["pairC"].Ask) / data["pairA"].PointSize;
				double b = (data["pairB"].Bid - data["pairA"].Ask / data["pairC"].Ask) / data["pairA"].PointSize;
				double c = (data["pairC"].Bid - data["pairA"].Ask / data["pairB"].Ask) / data["pairA"].PointSize;
				if (a > 0)
				{
					this.tb_pair1.BackColor = Color.MediumBlue;
					this.tb_pair1.ForeColor = Color.Yellow;
				}
				else if (a == 0)
				{
					this.tb_pair1.BackColor = Color.White;
					this.tb_pair1.ForeColor = Color.DarkGray;
				}
				else
				{
					this.tb_pair1.BackColor = Color.Red;
					this.tb_pair1.ForeColor = Color.White;
				}
				this.tb_pair1.Text = a.ToString("#,##0.00");
				this.tb_pair2.Text = b.ToString("#,##0.00");
				this.tb_pair3.Text = c.ToString("#,##0.00");
			}
		}

		/// <summary>
		/// Must be invoked before module loads.
		/// </summary>
		/// <param name="ins">The VTAPI.Instruments object to examin.</param>
		public void LoadArbitrageCurrencies(VTAPI.Instruments ins)
		{
			this.api_instruments = ins;
			string tmpPair = "";
			string tmpID = "";
			// Loads currency pairs into ComboBoxes for selection
			for(int i=0;i<ins.Count;i++)
			{
				tmpPair = ins.get_Items(i).currency1 + "/" + ins.get_Items(i).currency2;
				tmpID = ins.get_Items(i).ID;
				this.cb_in_A.Items.Add(tmpPair);
				this.cb_in_B.Items.Add(tmpPair);
				this.cb_in_C.Items.Add(tmpPair);
			}
		}

		/// <summary>
		/// Handles the Selected Index Changed event for input into curreny pair A.
		/// </summary>
		/// <param name="sender">Sending object.</param>
		/// <param name="e">Arguments from EventArgs class.</param>
		private void cb_in_A_SelectedIndexChanged(object sender, EventArgs e)
		{
			string tmpID = ((ComboBox)sender).SelectedIndex.ToString();
			if (!data.Keys.Contains("pairA"))
			{
				CArbitrageObject obj = new CArbitrageObject();
				obj.ID = tmpID;
				data.Add("pairA", obj);
			}
			else
			{
				data["pairA"].ID = tmpID;
			}
			// Load other relevant data from Instrument class.
			data["pairA"].Pair = this.api_instruments.get_Items(int.Parse(tmpID)).currency1 + "/" + this.api_instruments.get_Items(int.Parse(tmpID)).currency2;
			data["pairA"].PointSize = this.api_instruments.get_Items(int.Parse(tmpID)).pointSize;
			// Change text in the lable
			this.lbl_pair1.Text = data["pairA"].Pair;
		}

		/// <summary>
		/// Handles the Selected Index Changed event for input into curreny pair B.
		/// </summary>
		/// <param name="sender">Sending object.</param>
		/// <param name="e">Arguments from EventArgs class.</param>
		private void cb_in_B_SelectedIndexChanged(object sender, EventArgs e)
		{
			string tmpID = ((ComboBox)sender).SelectedIndex.ToString();
			if (!data.Keys.Contains("pairB"))
			{
				CArbitrageObject obj = new CArbitrageObject();
				obj.ID = tmpID;
				data.Add("pairB", obj);
			}
			else
			{
				data["pairB"].ID = tmpID;
			}
			// Load other relevant data from Instrument class.
			data["pairB"].Pair = this.api_instruments.get_Items(int.Parse(tmpID)).currency1 + "/" + this.api_instruments.get_Items(int.Parse(tmpID)).currency2;
			data["pairB"].PointSize = this.api_instruments.get_Items(int.Parse(tmpID)).pointSize;
			// Change text in the lable
			this.lbl_pair2.Text = data["pairB"].Pair;
		}

		/// <summary>
		/// Handles the Selected Index Changed event for input into curreny pair C.
		/// </summary>
		/// <param name="sender">Sending object.</param>
		/// <param name="e">Arguments from EventArgs class.</param>
		private void cb_in_C_SelectedIndexChanged(object sender, EventArgs e)
		{
			string tmpID = ((ComboBox)sender).SelectedIndex.ToString();
			if (!data.Keys.Contains("pairC"))
			{
				CArbitrageObject obj = new CArbitrageObject();
				obj.ID = tmpID;
				data.Add("pairC", obj);
			}
			else
			{
				data["pairC"].ID = tmpID;
			}
			// Load other relevant data from Instrument class.
			data["pairC"].Pair = this.api_instruments.get_Items(int.Parse(tmpID)).currency1 + "/" + this.api_instruments.get_Items(int.Parse(tmpID)).currency2;
			data["pairC"].PointSize = this.api_instruments.get_Items(int.Parse(tmpID)).pointSize;
			// Change text in the lable
			this.lbl_pair3.Text = data["pairC"].Pair;
		}

		
	}

	public class CArbitrage : Dictionary<string, CArbitrageObject>
	{
		private const int NO_OF_PAIRS = 3;

	}

	public class CArbitrageObject : Object
	{
		private string _pair, _id, _numFormat;
		private double _ask, _bid, _pointSize;

		public CArbitrageObject()
		{
			_pair = "";
			_id = "";
			_ask = -1;
			_bid = -1;
		}

		#region Private Help Functions
		private void setNumFormat()
		{
			this._numFormat = this._pointSize.ToString();
			this._numFormat.Replace('1', '0');
		}
		#endregion (Private Help Functions)

		#region Accessors
		public double Ask
		{
			get { return this._ask > 0 ? this._ask : 0; }
			set
			{
				if (value > 0)
					this._ask = value;
				else
					this._ask = -1;
			}
		}
		public double Bid
		{
			get { return this._bid > 0 ? this._bid : 0; }
			set
			{
				if (value > 0)
					this._bid = value;
				else
					this._bid = -1;
			}
		}
		public string Pair
		{
			get { return _pair != "" ? this._pair : null; }
			set { this._pair = value; }
		}
		public string ID
		{
			get { return this._id != "" ? this._id : null; }
			set { this._id = value; }
		}
		/// <summary>
		/// Spread as a decimal value. (Ask - Bid)
		/// </summary>
		public double Spread
		{
			get { return Math.Abs(this._ask - this._bid); }
		}

		/// <summary>
		/// Gets sets the Point Size as a decimal value.
		/// Ex. 0.0001 instead of 10,000 or 0.01 instead of 100.
		/// For multiplication factors use PointSizeInverse
		/// </summary>
		public double PointSize
		{
			get { return this._pointSize; }
			set { this._pointSize = value; setNumFormat(); }
		}

		/// <summary>
		/// Gets the reversed value of Point Size.
		/// </summary>
		public double PointSizeInverse
		{
			get { return 1 / this._pointSize; }
		}

		/// <summary>
		/// Gets the number format to be used for the pair.
		/// Ex. "0.0000" for EUR/USD pair or "0.00" for USD/JPY pair.
		/// </summary>
		public string NumberFormat
		{
			get { return this._numFormat; }
		}
		#endregion Accessors
	}
}
