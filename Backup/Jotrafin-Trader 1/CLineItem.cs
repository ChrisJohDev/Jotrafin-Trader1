using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D4M.WIN.Printing
{
	class CLineItem
	{
		string cont;
		CLineItemFormat frmt;

		public CLineItem()
		{
			frmt = new CLineItemFormat();
		}

		public string Content
		{
			get { return this.cont; }
			set { this.cont = value; }
		}

		public CLineItemFormat ItemFormat
		{
			get { return this.frmt; }
		}
	}
}
