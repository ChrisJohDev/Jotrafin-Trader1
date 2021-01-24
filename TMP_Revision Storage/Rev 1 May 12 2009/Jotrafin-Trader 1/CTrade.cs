using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace D4M.FINANCE.JOTRAFIN
{
	public class CTrade: Object
	{
		private double dbl_price;						// Initial price for the trade
		private double dbl_stop;						// Stop / Loss price
		private double dbl_limit_1;						// First limit if staggered limit trade else limit
		private double dbl_limit_2;						// Second limit if staggered limit trade else not used
		private double dbl_limit_3;						// Third limit if staggered limit trade else not used
		private bool b_trailingStop;					// True if the trade uses a trailing stop
		private bool b_tradeActive;						// True when trade is iniated and opened
		private string str_trade_id;					// Internal trade id for the trade
		private string str_trade_note;					// Optional trade notes
		private string str_trade_type;					// If namned trade type ex. Flagpost, etc. else blank
		private string str_position;					// Type of position (Long / Short)
		private string str_pair;						// Currency Pair
		private DateTime dt_trade_created;				// Date and time that the trade was created
		private DateTime dt_trade_started;				// Date and Time the trade was executed and opened
		private DateTime dt_trade_modified;				// Date and time the trade was last modified
		private const string LAST_TRADE_ID_FILE = "LastInternalTradeID.txt";	// Text file where the latest used trade id is stored
		private double dbl_tradeLots;					// Number of lots entered in the trade
		private double bdl_limit1_lots;					// Number of lots for Limit 1
		private double dbl_limit2_lots;					// Number of lots for Limit 2
		private double dbl_limit3_lots;					// Number of lots for Limit 3

		public CTrade():base()
		{
			this.dbl_price = -1.0;
			this.dbl_stop = -1.0;
			this.dbl_limit_1 = -1.0;
			this.dbl_limit_2 = -1.0;
			this.dbl_limit_3 = -1.0;
			this.b_trailingStop = false;
			this.b_tradeActive = false;
			this.str_trade_id = GetNewTradeID();
			this.str_trade_note = "";
			this.str_trade_type = "";
			this.str_position = "-1";
			this.dt_trade_created = DateTime.UtcNow;
			this.dt_trade_modified = DateTime.UtcNow;
			this.dbl_tradeLots = 1;
			this.bdl_limit1_lots = 0;
			this.dbl_limit2_lots = 0;
			this.dbl_limit3_lots = 0;
		}


		#region Help Functions
		private string GetNewTradeID()
		{
			System.IO.StreamReader r;
			string tId = "", month, year, day;
			if (!File.Exists(LAST_TRADE_ID_FILE))
			{
				
			}
			else
			{
				r = File.OpenText(LAST_TRADE_ID_FILE);
				tId = r.ReadLine();
				string[] tmp = tId.Split('-');
				r.Dispose();
				// Find date in the first array or the split string.
				int y = int.Parse(tmp[0].Substring(0, 2));
				int m = int.Parse(tmp[0].Substring(2, 2));
				int d = int.Parse(tmp[0].Substring(4, 2));

				if (y != DateTime.Now.Year-2000 || m != DateTime.Now.Month || d != DateTime.Now.Day)
				{
					y = DateTime.Now.Year-2000;
					m = DateTime.Now.Month;
					d = DateTime.Now.Day;
					tmp[1] = "0001";
				}
				else
				{
					int p = int.Parse(tmp[1]);
					p++; // Advance p by one from previous value.

					if (p > 999)
					{
						tmp[1] = p.ToString();
					}
					else if (p > 99)
					{
						tmp[1] = "0" + p.ToString();
					}
					else if (p > 9)
					{
						tmp[1] = "00" + p.ToString();
					}
					else
					{
						tmp[1] = "000" + p.ToString();
					}
				}
				// Put it all together
				if(d>9)
				{
					day = d.ToString();
				}
				else
				{
					day = "0" + d.ToString();
				}
				if (m > 9)
				{
					month = m.ToString();
				}
				else
				{
					month = "0" + m.ToString();
				}
				if (y > 9)
				{
					year = y.ToString();
				}
				else
				{
					year = "0" + y.ToString();
				}

				tId = year + month + day + "-" + tmp[1];
			}

			// Return result
			return tId;
		}
		private void writeIdToFile()
		{
			// Write the new data to the file
			File.WriteAllText(LAST_TRADE_ID_FILE, this.str_trade_id);
		}
		private void Error(string msg)
		{
			
		}
		#endregion (Help Functions)

		#region Accessors
		public double Price
		{
			get { return this.dbl_price; }
			set { this.dbl_price = value; }
		}
		public double Stop
		{
			get { return this.dbl_stop; }
			set { this.dbl_stop = value; }
		}
		public double Limit1
		{
			get { return this.dbl_limit_1; }
			set { this.dbl_limit_1 = value; }
		}
		public double Limit2
		{
			get { return this.dbl_limit_2; }
			set { this.dbl_limit_2 = value; }
		}
		public double Limit3
		{
			get { return this.dbl_limit_3; }
			set { this.dbl_limit_3 = value; }
		}
		public bool TrailingStop
		{
			get { return this.b_trailingStop; }
			set { this.b_trailingStop = value; }
		}
		public bool TradeActive
		{
			get { return this.b_tradeActive; }
			set { this.b_tradeActive = value; }
		}
		public string TradeID
		{
			get { return this.str_trade_id; }
		}
		public string Note
		{
			get { return this.str_trade_note; }
			set { this.str_trade_note = value; }
		}
		public string TradeType
		{
			get { return this.str_trade_type; }
			set { this.str_trade_type = value; }
		}
		public string Position
		{
			get
			{
				if (this.str_position == "-1") return null;
				else return this.str_position;
			}
			set
			{
				if (value == "Long" || value == "Short")
					this.str_position = value;
				else
				{
					this.str_position = "-1";
					throw new NotSupportedException("Value must be Long or Short. No other values supported.");
				}
			}
		}
		public DateTime CreationDate
		{
			get { return this.dt_trade_created; }
		}
		public DateTime LastModifiedDate
		{
			get { return this.dt_trade_modified; }
			set { this.dt_trade_modified = value; }
		}
		public DateTime StartDate
		{
			get { return this.dt_trade_started; }
			set { this.dt_trade_started = value; }
		}
		public double TradeLots
		{
			get { return this.dbl_tradeLots; }
			set { this.dbl_tradeLots = value; }
		}
		public double Lots_Limit1
		{
			get { return this.bdl_limit1_lots; }
			set
			{
				if (value <= this.dbl_tradeLots)
					this.bdl_limit1_lots = value;
				else
					throw new CTradeInputException("Entered number of lots needs to be less than or equal to " + this.dbl_tradeLots.ToString());
			}
		}
		public double Lots_Limit2
		{
			get { return this.dbl_limit2_lots; }
			set
			{
				if (this.bdl_limit1_lots > 0 && value <= this.dbl_tradeLots - this.bdl_limit1_lots)
					this.dbl_limit2_lots = value;
				else if (this.bdl_limit1_lots <= 0)
					throw new CTradeInputException("There are no lots entered for Limit 1. Set value for Limit 1 lots first.");
				else
					throw new CTradeInputException("Entered number of lots needs to be less than or equal to " + (this.dbl_tradeLots - this.bdl_limit1_lots).ToString());
			}
		}
		public double Lots_Limit3
		{
			get { return this.dbl_limit3_lots; }
			set
			{
				if (this.bdl_limit1_lots > 0 && this.dbl_limit2_lots > 0 && value <= this.dbl_tradeLots - this.bdl_limit1_lots - this.dbl_limit2_lots)
					this.dbl_limit3_lots = value;
				else if (this.bdl_limit1_lots <= 0)
					throw new CTradeInputException("There are no lots entered for Limit 1. Set value for Limit 1 lots first.");
				else if (this.dbl_limit2_lots <= 0)
					throw new CTradeInputException("There are no lots entered for Limit 2. Set value for Limit 2 lots first.");
				else
					throw new CTradeInputException("Entered number of lots needs to be less than or equal to " + this.dbl_tradeLots.ToString());
			}
		}
		public string Pair
		{
			get { return this.str_pair; }
			set { this.str_pair = value; }
		}
		#endregion (Accessors)

		public void CommitNewTradeID()
		{
			writeIdToFile();
		}
	}

	public class CTradeInputException : Exception
	{

		public CTradeInputException(string msg):base(msg)
		{
		}
		public CTradeInputException(string msg, Exception innerException):base(msg,innerException)
		{
		}
		public CTradeInputException(): base()
		{
		}
	}

	public class CTrades : Object
	{
		List<CTrade> data;

		public CTrades()
		{
			data = new List<CTrade>();
			this.data.Capacity = 10;
		}

		public bool Add(CTrade elm)
		{
			int tst = this.data.Count, tst2=-1;
			this.data.Add(elm);
			tst2 = this.data.Count;

			if (tst2 > tst && tst2 != -1)
				return true;
			else
				return false;
		}

		public int Count
		{
			get { return this.data.Count; }
		}

		public bool RemoveItem(int indx)
		{
			int tst = this.data.Count, tst2 = -1;
			this.data.RemoveAt(indx);
			tst2 = this.data.Count;

			if (tst2 < tst && tst2 != -1)
				return true;
			else
				return false;
		}

		public CTrade GetItem(int indx)
		{
			return this.data[indx];
		}

	}
}
