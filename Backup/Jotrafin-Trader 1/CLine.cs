using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D4M.WIN.Printing
{
	class CLine
	{
		List<CLineItem> itms = new List<CLineItem>();

		public CLineItem this[int i]
		{
			get { return this.itms[i]; }
		}

		public void Add(CLineItem itm)
		{
			this.itms.Add(itm);
		}

		public int Count
		{
			get { return this.itms.Count; }
		}

		public void ClearAll()
		{
			this.itms.Clear();
		}

		public int LineNumber
		{
			get { return this.itms.Count + 1; }
		}
	}
}
