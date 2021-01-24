using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D4M.WIN.Printing
{
	class CLineDocument
	{
		List<CLinePage> pages = new List<CLinePage>();
		string name;

		public CLineDocument()
		{
			this.name = "";
		}

		public CLineDocument(string name)
		{
			this.name = name;
		}

		public string DocumentName
		{
			get { return this.name; }
			set { this.name = value; }
		}

		public CLinePage this[int i]
		{
			get { return this.pages[i]; }
		}

		public int Count
		{
			get { return this.pages.Count; }
		}
	}
}
