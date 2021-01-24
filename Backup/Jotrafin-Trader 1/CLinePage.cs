using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D4M.WIN.Printing
{
	class CLinePage
	{
		List<CLine> lines = new List<CLine>();
		string name;

		public CLinePage()
		{
			this.name = "";
		}

		public CLinePage(string name)
		{
			this.name = name;
		}

		public CLine this[int i]
		{
			get { return this.lines[i]; }
		}

		public int Count
		{
			get { return this.lines.Count; }
		}

		public int PageNumber
		{
			get { return this.lines.Count + 1; }
		}

		public string PageName
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public void Add(CLine line)
		{
			this.lines.Add(line);
		}
	}
}
