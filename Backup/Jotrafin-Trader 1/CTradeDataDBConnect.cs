using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;

namespace D4M.FINANCE.JOTRAFIN
{
	class CTradeDataDBConnect
	{

		public void WriteDBStart()
		{
			int dummy = 0;
			for (int i = 0; i < 10000; i++)
			{
				dummy += i;
			}
			Thread.Sleep(0);
		}
	}
}
