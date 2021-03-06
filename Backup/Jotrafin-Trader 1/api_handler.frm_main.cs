﻿using System;
using System.Text;
using System.Linq;
using VTAPI;


namespace D4M.FINANCE.JOTRAFIN
{
	/// <summary>
	/// Contains the main functions for communication with the VTAPI.
	/// </summary>
	public partial class frm_main
	{
		//private VTAPI.VT_APIClass api;						// API to the trading servers
		private VTAPI.Accounts api_accounts;				// Accounts collection.
		private VTAPI.Instruments api_instruments;			// Instruments collection
		private VTAPI.ServerMessages api_servMessages;		// Server messages collection
		private VTAPI.Positions api_positions;				// Open possitions collection
		private VTAPI.Orders api_orders;					// Orders collection

		#region VT_API Event handlers
		
		void api_OnTradingDayClosed()
		{
			Echo("OnTradingDayClosed");
		}

		void api_OnPositionsChange()
		{
			Echo("OnPositionsChange");
		}

		void api_OnPositionChange(string ID, int Action)
		{
			Echo("OnPositionChange");
		}

		void api_OnOrdersChange()
		{
			Echo("OnOrdersChange");
		}

		void api_OnOrderChange(string ID, int Action)
		{
			Echo("OnOrderChange");
		}

		private void api_OnNewServerMessage(int msg_index)
		{
			string msg_text = this.api.ServerMessages.get_Items(msg_index).get_Details(0);
			Echo(" api OnServerMessage: " + msg_text);
		}

		void api_OnNewAnnouncement()
		{
			Echo("OnNewAnnouncement");
		}

		void api_OnMarketStatusChange()
		{
			Echo("OnMarketStatusChange");
		}

		void api_OnInstrumentsChange()
		{
			Echo("OnInstrumentsChange");
		}

		void api_OnInstrumentChangeEx(string InstrumentID, double Bid, double Ask, DateTime Time)
		{
			Echo("OnInstrumentChangeEx");
		}

		void api_OnInstrumentChange(string InstrumentID)
		{
			Echo("OnInstrumentChange");
		}

		void api_OnConnectionLost()
		{
			Echo("OnConnectionLost");
		}

		void api_OnChangesStart()
		{
			Echo("OnChangesStart");
		}

		void api_OnChangesComplete()
		{
			Echo("OnChangesComplete");
		}

		void api_OnCandleUpdate(string InstrumentID, TimeInterval Interval, bool isNewCandle)
		{
			Echo("OnCandleUpdated");
		}

		void api_OnAccountsChange()
		{
			Echo("OnAccountsChange");
		}

		void api_OnAccountChange(string ID, int Action)
		{
			Echo("OnAccountChange");
		}
		#endregion (VT_API Event handlers)

		/// <summary>
		/// Assigns the events generated by the VTAPIEventHandler class.
		/// </summary>
		private void AssignEvents()
		{
			this.apiEvents.API_AccountChangeEvent += new VTAPIEventHandler.API_AccountChangeEventHandler(this.api_OnAccountChange);
			this.apiEvents.API_AccountsChangeEvent += new VTAPIEventHandler.API_AccountsChangeEventHandler(this.api_OnAccountsChange);
			this.apiEvents.API_CandleUpdatedEvent += new VTAPIEventHandler.API_CandleUpdatedEventHandler(this.api_OnCandleUpdate);
			this.apiEvents.API_ChangesCompleteEvent += new VTAPIEventHandler.API_ChangesCompleteEventHandler(api_OnChangesComplete);
			this.apiEvents.API_ChangesStartEvent += new VTAPIEventHandler.API_ChangesStartEventHandler(api_OnChangesStart);
			this.apiEvents.API_ConnectionLostEvent += new VTAPIEventHandler.API_ConnectionLostEventHandler(api_OnConnectionLost);
			this.apiEvents.API_InstrumentChangeEvent += new VTAPIEventHandler.API_InstrumentChangeEventHandler(api_OnInstrumentChange);
			this.apiEvents.API_InstrumentChangeExEvent += new VTAPIEventHandler.API_InstrumentChnageExEventHandler(api_OnInstrumentChangeEx);
			this.apiEvents.API_InstrumentsChangeEvent += new VTAPIEventHandler.API_InstrumentsChangeEventHandler(api_OnInstrumentsChange);
			this.apiEvents.API_MarketStatusChangeEvent += new VTAPIEventHandler.API_MarketStatusChangeEventHandler(api_OnMarketStatusChange);
			this.apiEvents.API_NewAnnouncementEvent += new VTAPIEventHandler.API_NewAnnouncementEventHandler(api_OnNewAnnouncement);
			this.apiEvents.API_NewServerMessageEvent += new VTAPIEventHandler.API_NewServerMessageEventHandler(api_OnNewServerMessage);
			this.apiEvents.API_OrderChangeEvent += new VTAPIEventHandler.API_OrderChangeEventHandler(api_OnOrderChange);
			this.apiEvents.API_OrdersChangeEvent += new VTAPIEventHandler.API_OrdersChangeEventHandler(api_OnOrdersChange);
			this.apiEvents.API_PositionChangeEvent += new VTAPIEventHandler.API_PositionChangeEventHandler(api_OnPositionChange);
			this.apiEvents.API_PositionsChangeEvent += new VTAPIEventHandler.API_PositionsChangeEventHandler(api_OnPositionsChange);
			this.apiEvents.API_TradingDayClosedEvent += new VTAPIEventHandler.API_TradingDayClosedEventHandler(api_OnTradingDayClosed);
		}


		/// <summary>
		/// Just a simple test function for testing properties of the VTAPI.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public void Test(object sender, EventArgs e)
		{
			//VTAPI.Instrument inst = api.GetInstrumentByCurrency("eur", "usd");
			api_instruments = api.Instruments;
			api_instruments.setSubscriptionForAll(true);
			
			try
			{
				for (int i = 0; i < api_instruments.Count; i++)
				{
					Echo("Ask: " + api_instruments.get_Items(i).Ask.ToString() + " | Bid: " + api_instruments.get_Items(i).Bid.ToString());
					Echo("BuyInterest: " + api_instruments.get_Items(i).BuyInterest.ToString());
					Echo("Currency 1: " + api_instruments.get_Items(i).currency1 + " | Currency 2: " + api_instruments.get_Items(i).currency2);
					Echo("History: " + api_instruments.get_Items(i).GetHistory((int)VTAPI.TimeInterval.T_10_MIN, true, 2));
					Echo("Instrument ID: " + api_instruments.get_Items(i).ID);
					Echo("Instrument Index: " + api_instruments.get_Items(i).Index.ToString());
					Echo("Lot Size: " + api_instruments.get_Items(i).LotSize.ToString());
					Echo("Max: " + api_instruments.get_Items(i).Max.ToString());
					Echo("Min: " + api_instruments.get_Items(i).Min.ToString());
					Echo("Pip Value: " + api_instruments.get_Items(i).pipValue.ToString());
					Echo("Points: " + api_instruments.get_Items(i).points.ToString());
					Echo("Point Size: " + api_instruments.get_Items(i).pointSize.ToString());
					Echo("Sell Interest: " + api_instruments.get_Items(i).SellInterest.ToString());
					Echo("Time: " + api_instruments.get_Items(i).Time.ToString());
					Echo("Obj to string: " + api_instruments.get_Items(i).ToString());
				}
				Echo("No of Instruments: " + api_instruments.Count.ToString());
				

			}
			catch (Exception ex)
			{
				Echo("API Error: " + ex.Message);
			}

		}

	}
}
