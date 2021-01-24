using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTAPI;

namespace D4M.FINANCE.JOTRAFIN
{
	public partial class frm_PositionManager : Form
	{
		//bool openPos, bool stop, bool limit, bool change, bool close, string id
		private bool b_openPosition, b_stop, b_limit, b_change, b_close;
		private string str_id;
		VT_APIClass api;

		public frm_PositionManager(ref VT_APIClass xapi)
		{
			this.api = xapi;
			// Set default values
			this.str_id = "-1";
			this.b_change = false;
			this.b_close = false;
			this.b_limit = false;
			this.b_openPosition = false;
			this.b_stop = false;
			InitializeComponent();
		}

		#region Accessors
		/// <summary>
		/// True if the position is an Open position. False if it is a Pending Order.
		/// </summary>
		public bool OpenPosition
		{
			get { return this.b_openPosition; }
			set { this.b_openPosition = value; }
		}

		/// <summary>
		/// True if the form is supposed to act on a stop.
		/// </summary>
		public bool Stop
		{
			get { return this.b_stop; }
			set { this.b_stop = value; }
		}

		/// <summary>
		/// True if the form is supposed to act on a limit.
		/// </summary>
		public bool Limit
		{
			get { return this.b_limit; }
			set { this.b_limit = value; }
		}

		/// <summary>
		/// True if the form is supposed to act on a entry price of a Pending Order.
		/// </summary>
		public bool Change
		{
			get { return this.b_change; }
			set { this.b_change = value; }
		}

		/// <summary>
		/// True if the form is supposed to close an open position.
		/// </summary>
		public bool Close
		{
			get { return this.b_close; }
			set { this.b_close = value; }
		}

		/// <summary>
		/// The id of the pending order or open position.
		/// </summary>
		public string PositionID
		{
			get { return this.str_id; }
			set { this.str_id = value; }
		}
		#endregion (Accessors)
	}
}
