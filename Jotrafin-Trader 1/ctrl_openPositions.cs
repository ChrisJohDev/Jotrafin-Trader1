using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using VTAPI;

namespace D4M.FINANCE.JOTRAFIN
{
	public partial class ctrl_openPositions : UserControl
	{
		private VTAPI.VT_API locAPI;
		private VTAPI.Positions apiPositions;
		private List<ctrl_openPosition> posList = new List<ctrl_openPosition>();

		public ctrl_openPositions()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
		}

		public void InitAPI(ref VTAPI.VT_APIClass refAPI)
		{
			this.locAPI = refAPI;
		}

		public void PositionChangeEventHandler(string id, int action)
		{
			if(action == (int)VTAPI.MessageType.MT_NEW_POSITION)
			{
				NewPosition(id);
			}
			else if (action == (int)VTAPI.MessageType.MT_CREATE_STOP)
			{
				for(int i=0;i<this.panel_op_body.Controls.Count;i++)
				{
					if (((ctrl_openPosition)this.panel_op_body.Controls[i]).Ticket == id)
					{
						((ctrl_openPosition)this.panel_op_body.Controls[i]).Stop = locAPI.Positions.ItemByID(id).StopOrder.Rate;
					}
				}
			}
		}

		private void NewPosition(string id)
		{
			IPosition pos = locAPI.Positions.ItemByID(id);
			ctrl_openPosition ctrl = new ctrl_openPosition(pos.Instrument.ID);
			ctrl.Ticket = pos.ID;
			ctrl.Instrument = pos.Instrument.currency1 + "/" + pos.Instrument.currency2;
			ctrl.Lots = pos.Amount;
			if (!pos.BuySell)// Note: bs_buy = false, bs_sell=true
				ctrl.Position = "Long";
			else
				ctrl.Position = "Short";
			ctrl.Open = pos.OpenRate;
			ctrl.Close = pos.CloseRate;
			try
			{
				ctrl.Stop = pos.StopOrder.Rate;
			}
			catch (Exception ex) { }
			try
			{
				ctrl.Limit = pos.LimitOrder.Rate;
			}
			catch (Exception ex) { }
			this.panel_op_body.Controls.Add(ctrl);
			ctrl.Dock = DockStyle.Top;
		}

		public void LoggedInEventHandler(ref VTAPI.VT_APIClass api,LoggedInEventArgs arg)
		{
			// Needs testing when we have an internet connection.
			this.apiPositions = api.Positions;
			if (apiPositions.Count > 0)
			{
				for (int i = 0; i < apiPositions.Count; i++)
				{
					IPosition pos = apiPositions.get_Items(i);
					ctrl_openPosition ctrl = new ctrl_openPosition(pos.Instrument.ID);
					ctrl.Ticket = pos.ID;
					ctrl.Instrument = pos.Instrument.currency1 + "/" + pos.Instrument.currency2;
					ctrl.Lots = pos.Amount;
					if (!pos.BuySell)// Note: bs_buy = false, bs_sell=true
						ctrl.Position = "Long";
					else
						ctrl.Position = "Short";
					ctrl.Open = pos.OpenRate;
					ctrl.Close = pos.CloseRate;
					try
					{
						ctrl.Stop = pos.StopOrder.Rate;
					}
					catch (Exception ex) { }
					try
					{
						ctrl.Limit = pos.LimitOrder.Rate;
					}
					catch (Exception ex) { }
					this.panel_op_body.Controls.Add(ctrl);
					ctrl.Dock = DockStyle.Top;
				}
			}
		}

		public void InstrumentChangeExEventHandler(string InstrumentID, double Bid, double Ask, DateTime Time)
		{
			for (int i = 0; i < this.panel_op_body.Controls.Count; i++)
			{
				if (((ctrl_openPosition)this.panel_op_body.Controls[i]).InstrID == this.locAPI.Positions.ItemByID(((ctrl_openPosition)this.panel_op_body.Controls[i]).Ticket).Instrument.ID)
					((ctrl_openPosition)this.panel_op_body.Controls[i]).InstrumentChangeExHandler(InstrumentID, Bid, Ask, Time);
			}
		}
	}
}
