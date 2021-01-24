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
	public partial class ctrl_openPosition : UserControl
	{
		private string numFormat = "0.0000";
		private double _open = -1, _close = -1, _pipsDivider = 0.0001;
		private string _instrID;
		VTAPI.Position _pos;

		public ctrl_openPosition(string instrumentID)
			: base()
		{
			//this._pos = this.ParentForm.api.Positions.get_item
			this._instrID = instrumentID;
			InitializeComponent();
		}

		#region Accessors
		public void SetPositionRef(ref VTAPI.Position pos)
		{
			this._pos = pos;
		}
		/// <summary>
		/// Gets or sets the number format used for this control.
		/// Default is '0.0000'
		/// </summary>
		public string NumberFormat
		{
			get { return this.numFormat; }
			set { this.numFormat = value; }
		}

		/// <summary>
		/// Gets or sets the factor with which to multiply prices with to put them in an integer PIP format.
		/// </summary>
		public double PIP_Divider
		{
			get { return this._pipsDivider; }
			set { this._pipsDivider = value; }
		}

		/// <summary>
		/// Gets the Instrument ID.
		/// </summary>
		public string InstrID
		{
			get { return this._instrID; }
		}

		/// <summary>
		/// Sets the ticket number/id.
		/// </summary>
		public string Ticket
		{
			get { return this.tb_ticket.Text; }
			set { this.tb_ticket.Text = value; }
		}

		/// <summary>
		/// Sets the instrument.
		/// </summary>
		public string Instrument
		{
			set { this.tb_instrument.Text = value; }
		}

		/// <summary>
		/// Sets the number of lots.
		/// </summary>
		public double Lots
		{
			set { this.tb_lots.Text = value.ToString("0.0"); }
		}

		/// <summary>
		/// Sets the position.
		/// Long / Short
		/// </summary>
		public string Position
		{
			set { this.tb_position.Text = value; }
		}

		/// <summary>
		/// Sets the opening price.
		/// </summary>
		public double Open
		{
			set 
			{
				this._open = value;
				this.tb_open.Text = this._open.ToString(numFormat);
			}
		}

		/// <summary>
		/// Sets the current closing price.
		/// </summary>
		public double Close
		{
			set 
			{
				this._close = value;
				this.tb_close.Text = this._close.ToString(numFormat);
				CalculatePIPS_PL();
			}
		}

		/// <summary>
		/// Sets the stop loss price.
		/// </summary>
		public double Stop
		{
			set { this.tb_stop.Text = value.ToString(numFormat); }
		}

		/// <summary>
		/// Sets the Limit or take profit price.
		/// </summary>
		public double Limit
		{
			set { this.tb_limit.Text = value.ToString(numFormat); }
		}

		/// <summary>
		/// Calculates the P/L in real PIPs for the position.
		/// </summary>
		private void CalculatePIPS_PL()
		{
			double res = -1.0;

			if (this._open != -1 && this._close != -1)
			{
				if (this.tb_position.Text == "Short")
					res = (this._open - this._close) / this.PIP_Divider;
				else
					res = (this._close - this._open)/this.PIP_Divider;
			}

			this.tb_pipsPL.Text = Math.Round(res, 0).ToString();
		}
		#endregion (Accessors)

		#region Context Menu Handlers
		/// <summary>
		/// Closes the position. Opens the Close confirmation form.
		/// Close confirmation contains an active price and PIPs P/L.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ctrl_ToolStripItem_close_Click(object sender, EventArgs e)
		{
			((frm_main)this.FindForm()).RunPositionForm(true, false, false, false, true, this.tb_ticket.Text);
		}

		/// <summary>
		/// Opens the Manage Stop form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ctrl_ToolStripItem_stop_Click(object sender, EventArgs e)
		{
			((frm_main)this.FindForm()).RunPositionForm(true, true, false, false, false, this.tb_ticket.Text);
		}

		/// <summary>
		/// Opens the manage limit form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ctrl_ToolStripItem_limit_Click(object sender, EventArgs e)
		{
			((frm_main)this.FindForm()).RunPositionForm(true, false, true, false, false, this.tb_ticket.Text);
		}
		#endregion (Context Menu Handlers)

		#region Event Handlers
		public void InstrumentChangeExHandler(string InstrumentID, double Bid, double Ask, DateTime Time)
		{
			if (InstrumentID == _instrID)
			{
				if (this.tb_position.Text == "Short")
				{
					Close = Ask;
				}
				else
				{
					Close = Bid;
				}
			}
		}
		#endregion (Event Handlers)
	}
}
