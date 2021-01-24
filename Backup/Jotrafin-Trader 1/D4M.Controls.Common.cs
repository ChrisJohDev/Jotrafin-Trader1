using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D4M.Controls.Common
{
	public class D4MControl : UserControl
	{
		public delegate void CloseControlEventHandler(object sender, D4M.Controls.Common.CloseControlEventArgs arg);
	}
	public class CloseControlEventArgs : EventArgs
	{
	}
}
