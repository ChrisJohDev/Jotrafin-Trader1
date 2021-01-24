using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTAPI;

namespace D4M.FINANCE.JOTRAFIN
{
	class VTAPIEventHandler : VTAPI.IVT_APIEvents
	{
		public VTAPIEventHandler()
		{
		}

		public void OnAccountChange(string ID, int Action)
		{
		}

		public void OnAccountsChange()
		{
		}

		public void OnCandleUpdated(string InstrumentID, VTAPI.TimeInterval Interval, bool isNewCandle)
		{
		}

		public void OnChangesComplete()
		{
		}

		public void OnChangesStart()
		{
		}

		public void OnConnectionLost()
		{
		}

		public void OnInstrumentChange(string InstrumentID)
		{
		}

		public void OnInstrumentChangeEx(string InstrumentID, double Bid, double Ask, System.DateTime Time)
		{
		}

		public void OnInstrumentsChange()
		{
		}

		public void OnMarketStatusChange()
		{
		}

		public void OnNewAnnouncement()
		{
		}

		public void OnNewServerMessage(int MsgID)
		{
		}

		public void OnOrderChange(string ID, int Action)
		{
		}

		public void OnOrdersChange()
		{
		}

		public void OnPositionChange(string ID, int Action)
		{
		}

		public void OnPositionsChange()
		{
		}

		public void OnTradingDayClosed()
		{
		}
	}
}
