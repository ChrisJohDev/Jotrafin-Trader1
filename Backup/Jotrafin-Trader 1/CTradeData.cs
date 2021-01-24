using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D4M.FINANCE.JOTRAFIN
{
	public class CTradeData : ITradeData
	{
		private DateTime _date;			// Trading date
		private DateTime _time;			// Trade execution time
		private string _pair;			// Currency pair
		private string _pos;			// Position Long/Short
		private double _price;			// Executed Price
		private double _lot;			// Number of lots
		private long _tradeID;			// Market Maker ticket id or trade id
		private string _action;			// Open, partial close or close

		public CTradeData(long ticket)
		{
			this._tradeID = ticket;
			this._date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
			this._time = DateTime.Now;
		}

		public CTradeData(long ticket, DateTime time)
		{
			this._tradeID = ticket;
			this._time = time;
			this._date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
		}

		/// <summary>
		/// Gets the trade date of trade execution.
		/// </summary>
		public DateTime Date
		{
			get { return this._date; }
		}
		/// <summary>
		/// Gets the time the trade was executed.
		/// </summary>
		public DateTime Time
		{
			get { return this._time; }
		}

		/// <summary>
		/// Get set the Currency Pair.
		/// </summary>
		public string CurrencyPair
		{
			get { return this._pair; }
			set { this._pair = value; }
		}

		/// <summary>
		/// Get set the Position.
		/// Accepted values: "Long" or "Short"
		/// Note: Set to -1 if unsupport input.
		/// </summary>
		public string Position
		{
			get { return this._pos; }
			set
			{
				if (value.Equals("Long", StringComparison.OrdinalIgnoreCase) || value.Equals("Short", StringComparison.OrdinalIgnoreCase))
					this._pos = value;
				else
					this._pos = "-1";
			}
		}

		/// <summary>
		/// Gets sets the price traded.
		/// </summary>
		public double Price
		{
			get { return this._price; }
			set { this._price = value; }
		}

		/// <summary>
		/// Gets sets the number of lots traded.
		/// </summary>
		public double Lot
		{
			get { return this._lot; }
			set { this._lot = value; }
		}

		/// <summary>
		/// Gets the ticket, trade ID, ordere ID, or other identifier for the trade from the market maker.
		/// </summary>
		public long TradeID
		{
			get { return this._tradeID; }
		}

		/// <summary>
		/// Gets sets the trade action.
		/// Accepted values: Open, PartialClose, or Close
		/// </summary>
		public string Action
		{
			get { return this._action; }
			set
			{
				if (value.Equals("Open", StringComparison.OrdinalIgnoreCase) || value.Equals("PartialClose", StringComparison.OrdinalIgnoreCase) || value.Equals("Close", StringComparison.OrdinalIgnoreCase))
					this._action = value;
				else
					this._action = "-1";
			}
		}
	}

	public interface ITradeData
	{
		/// <summary>
		/// Gets the trade date of trade execution.
		/// </summary>
		DateTime Date
		{
			get;
		}
		/// <summary>
		/// Gets the time the trade was executed.
		/// </summary>
		 DateTime Time
		{
			get;
		}

		/// <summary>
		/// Get set the Currency Pair.
		/// </summary>
		 string CurrencyPair
		{
			get;
			set;
		}

		/// <summary>
		/// Get set the Position.
		/// Accepted values: "Long" or "Short"
		/// Note: Set to -1 if unsupport input.
		/// </summary>
		 string Position
		{
			get;
			set;
		}

		/// <summary>
		/// Gets sets the price traded.
		/// </summary>
		 double Price
		{
			get;
			set;
		}

		/// <summary>
		/// Gets sets the number of lots traded.
		/// </summary>
		 double Lot
		{
			get;
			set;
		}

		/// <summary>
		/// Gets the ticket, trade ID, ordere ID, or other identifier for the trade from the market maker.
		/// </summary>
		 long TradeID
		{
			get;
		}

		/// <summary>
		/// Gets sets the trade action.
		/// Accepted values: Open, PartialClose, or Close
		/// </summary>
		 string Action
		{
			get;
			set;
		}
	}
}
