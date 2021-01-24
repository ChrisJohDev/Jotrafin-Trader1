using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VTAPI;
using System.Windows.Forms;

namespace D4M.FINANCE.JOTRAFIN
{
	public class VTAPIEventHandler : VTAPI.IVT_APIEvents
	{
		// Public Delgates
		public delegate void API_AccountChangeEventHandler(string id, int action);
		public delegate void API_AccountsChangeEventHandler();
		public delegate void API_CandleUpdatedEventHandler(string instrumentID, VTAPI.TimeInterval interval, bool isNewCandle);
		public delegate void API_ChangesCompleteEventHandler();
		public delegate void API_ChangesStartEventHandler();
		public delegate void API_ConnectionLostEventHandler();
		public delegate void API_InstrumentChangeEventHandler(string instrument);
		public delegate void API_InstrumentChnageExEventHandler(string instrumentID, double bid, double ask, DateTime time);
		public delegate void API_InstrumentsChangeEventHandler();
		public delegate void API_MarketStatusChangeEventHandler();
		public delegate void API_NewAnnouncementEventHandler();
		public delegate void API_NewServerMessageEventHandler(int MsgID);
		public delegate void API_OrderChangeEventHandler(string id, int action);
		public delegate void API_OrdersChangeEventHandler();
		public delegate void API_PositionChangeEventHandler(string id, int action);
		public delegate void API_PositionsChangeEventHandler();
		public delegate void API_TradingDayClosedEventHandler();

		// Public Events
		public event API_AccountChangeEventHandler API_AccountChangeEvent;
		public event API_AccountsChangeEventHandler API_AccountsChangeEvent;
		public event API_CandleUpdatedEventHandler API_CandleUpdatedEvent;
		public event API_ChangesCompleteEventHandler API_ChangesCompleteEvent;
		public event API_ChangesStartEventHandler API_ChangesStartEvent;
		public event API_ConnectionLostEventHandler API_ConnectionLostEvent;
		public event API_InstrumentChangeEventHandler API_InstrumentChangeEvent;
		public event API_InstrumentChnageExEventHandler API_InstrumentChangeExEvent;
		public event API_InstrumentsChangeEventHandler API_InstrumentsChangeEvent;
		public event API_MarketStatusChangeEventHandler API_MarketStatusChangeEvent;
		public event API_NewAnnouncementEventHandler API_NewAnnouncementEvent;
		public event API_NewServerMessageEventHandler API_NewServerMessageEvent;
		public event API_OrderChangeEventHandler API_OrderChangeEvent;
		public event API_OrdersChangeEventHandler API_OrdersChangeEvent;
		public event API_PositionChangeEventHandler API_PositionChangeEvent;
		public event API_PositionsChangeEventHandler API_PositionsChangeEvent;
		public event API_TradingDayClosedEventHandler API_TradingDayClosedEvent;
	
		public VTAPIEventHandler()
		{
		}

		public void OnAccountChange(string ID, int Action)
		{
			API_AccountChangeEvent(ID, Action);
		}
		public void OnAccountsChange()
		{
			API_AccountsChangeEvent();
		}
		public void OnCandleUpdated(string InstrumentID, VTAPI.TimeInterval Interval, bool isNewCandle)
		{
			API_CandleUpdatedEvent(InstrumentID, Interval, isNewCandle);
		}
		public void OnChangesComplete()
		{
			// Frequently called
			API_ChangesCompleteEvent();
		}
		public void OnChangesStart()
		{
			// Frequently called
			API_ChangesStartEvent();
		}
		public void OnConnectionLost()
		{
			API_ConnectionLostEvent();
		}
		public void OnInstrumentChange(string InstrumentID)
		{
			// Frequently called
			API_InstrumentChangeEvent(InstrumentID);
		}
		public void OnInstrumentChangeEx(string InstrumentID, double Bid, double Ask, System.DateTime Time)
		{
			// Frequently called
			API_InstrumentChangeExEvent(InstrumentID, Bid, Ask, Time);
		}
		public void OnInstrumentsChange()
		{
			// Frequently called
			API_InstrumentsChangeEvent();
		}
		public void OnMarketStatusChange()
		{
			API_MarketStatusChangeEvent();
		}
		public void OnNewAnnouncement()
		{
			API_NewAnnouncementEvent();
		}
		public void OnNewServerMessage(int MsgID)
		{
			API_NewServerMessageEvent(MsgID);
		}
		public void OnOrderChange(string ID, int Action)
		{
			API_OrderChangeEvent(ID, Action);
		}
		public void OnOrdersChange()
		{
			API_OrdersChangeEvent();
		}
		public void OnPositionChange(string ID, int Action)
		{
			API_PositionChangeEvent(ID, Action);
		}
		public void OnPositionsChange()
		{
			API_PositionsChangeEvent();
		}

		public void OnTradingDayClosed()
		{
			API_TradingDayClosedEvent();
		}
	}
}
