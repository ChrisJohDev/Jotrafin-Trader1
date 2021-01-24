using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using VTAPI;
using D4M.WIN.Printing;
using D4M.Controls.Common;

namespace D4M.FINANCE.JOTRAFIN
{
	public partial class frm_main : Form
	{
		private VTAPI.VT_APIClass api;				// API to the trading servers
		private bool b_loggedin;					// True if logged in otherwise false
		private CTrades trades_list;				// The list of trades to watch
		private double dbl_demoBalance;				// Current balance of the demo trading account
		private double dbl_liveBalance;				// Current balance on the live account
		private int int_serverIndx;					// Index for the server we are logged on to
		private PrintDocument pivotDocument;		// Print document for pivot page
		private PrintDocument fiboDocument;			// Print document for fibo page
		private CPivotValues pivot4print;			// Print values for pivot page
		private Font normalTxtPrintFont;			// Normal text font to use for printing
		private Font normalBoldTxtPrintFont;		// Normal bold text font to use for printing
		private Font normalItalicTxtPrintFont;		// Normal itlic text font to use for printing
		private Font normalUnderTxtPrintFont;		// Normal underlined text font to use for prinitng
		private Font head1TxtPrintFont;				// Head 1 text font to use for printing
		private Font head2TxtPrintFont;				// Head 2 text font to use for printing
		private Font compNameTxtPrintFont;			// Company Name text font to use for printing
		private Font fullCmpNameTxtPrintFont;		// Full company name print font
		private Point nextPoint_panelMain;			// Holds the next point in the layout for panel_main
		private DateTime last_dateEcho;				// Holds the last date for comparison in Echo function.
		private ToolTip ttip;						// Tooltip object
		public VTAPIEventHandler apiEvents;			// API Event
		private CTradeDataDBConnect _dbConnect;		// Database connection object.
		private Thread WriteDBThread;				// Thread for running the write to database.
		private bool demoAccount;					// True if we are connected to the demo account else false.

		public delegate void LoggedInEventHandler(ref VTAPI.VT_APIClass api, LoggedInEventArgs arg);

		public event LoggedInEventHandler LoggedInEvent;


		public frm_main()
		{
			InitializeComponent();
			Initialize();
		}

		private void Initialize()
		{
			this.b_loggedin=false;
			this.trades_list = new CTrades();
			this.dbl_demoBalance = 3000.00;
			this.apiEvents = new VTAPIEventHandler();
			this.pivotDocument = new PrintDocument();
			this.pivotDocument.PrintPage+=new PrintPageEventHandler(pivotDocument_PrintPage);
			this.pivotDocument.QueryPageSettings += new QueryPageSettingsEventHandler(pivotDocument_QueryPageSettings);
			this.fiboDocument = new PrintDocument();
			this.pivot4print = new CPivotValues();
			this.normalTxtPrintFont = new Font("Perpetua", 12);
			this.normalBoldTxtPrintFont = new Font("Perpetua", 12, FontStyle.Bold);
			this.normalItalicTxtPrintFont = new Font("Perpetua", 12, FontStyle.Italic);
			this.normalUnderTxtPrintFont = new Font("Perpetua", 12, FontStyle.Underline);
			this.head1TxtPrintFont = new Font("Perpetua", 16, FontStyle.Bold);
			this.head2TxtPrintFont = new Font("Perpetua", 14, FontStyle.Bold);
			this.compNameTxtPrintFont = new Font("Lucida Calligraphy", 26);
			this.fullCmpNameTxtPrintFont = new Font("Perpetua", 10);
			this.nextPoint_panelMain = new Point(0, 0);
			this.last_dateEcho = new DateTime(1900, 1, 1);
			this.ttip = new ToolTip();
			this._dbConnect = new CTradeDataDBConnect();
			this.LoggedInEvent += new LoggedInEventHandler(this.ctrl_openPositions.LoggedInEventHandler);
			this.demoAccount = false;

			InitToolTip();

			LoginStatus();
			
			// Initializers for other parts
			InitFibo();
		}

		void pivotDocument_QueryPageSettings(object sender, QueryPageSettingsEventArgs e)
		{
			MessageBox.Show(sender.GetType().ToString());
		}

		#region Initializers
		private void InitAPI()
		{
			this.api = new VTAPI.VT_APIClass();
			AssignEventsServerEvent();
			if (Login())
			{
				// Set events assignment
				/* Sample code:
				 * this.events = new VTAPIEventHandler();
				 * vtapi.SetMsgRefresh(this.events);
				 */
				if (this.int_serverIndx == 0) demoAccount = true;
				Echo("SetMsgRefresh: " + api.SetMsgRefresh(this.apiEvents).ToString());
				// Set the refresh rate (min = 3) => 3 sec.
				api.ServerMessages.SetRefreshRate(3);
				Echo("Events Assigned.");
				b_loggedin = true;
				this.api_accounts = api.Accounts;
				api.Instruments.setSubscriptionForAll(true);
				api.Instruments.setThrowsGroupEvent(true);
				api.Instruments.setThrowsItemsEvent(true);
				Echo("RefreshRate: " + api.ServerMessages.GetRefreshRate().ToString());
				LoggedInEvent(ref this.api, new LoggedInEventArgs());
				WireUp_apiEvents();
				InitAccounts();
				RunTest();
			}

			// Put inside if statment when compiling real version.
			if (this.int_serverIndx == 1)
				GetLiveBalance();
			else if (this.int_serverIndx == 0)
				GetDemoBalance();

			// Start the Database Connect thread
			//this.WriteDBThread = new Thread(new ThreadStart(this._dbConnect.WriteDBStart));
			//this.WriteDBThread.Start();
		}

		private void RunTest()
		{
			for (int i = 0; i < this.api.Instruments.Count; i++)
			{
				Echo("---\r\nInstr ID: " + api.Instruments.get_Items(i).ID + "\r\nPair: " + api.Instruments.get_Items(i).currency1 + "\\" + api.Instruments.get_Items(i).currency2 + "\r\nDigits: " + api.Instruments.get_Items(i).pointSize.ToString()+"\r\nDigits2: "+api.Instruments.get_Items(i).points.ToString());
			}
		}
		private void InitAccounts()
		{
			double tmpBal = -1.0;
			double tmpUM = -1.0;
			double tmpAM = -1.0;
			if (this.demoAccount)
			{
				dbl_demoBalance = this.api.Accounts.get_Items(0).Balance;
				tmpBal = dbl_demoBalance;
				tmpAM = this.api.Accounts.get_Items(0).UsableMargin;
				tmpUM = this.api.Accounts.get_Items(0).UsedMargin;
			}
			else if (this.int_serverIndx == 1)
			{
				dbl_liveBalance = api.Accounts.get_Items(1).Balance;
				tmpAM = this.api.Accounts.get_Items(1).UsableMargin;
				tmpUM = this.api.Accounts.get_Items(1).UsedMargin;
				tmpBal = dbl_liveBalance;
			}
			if (tmpBal != -1.0)
			{
				this.textBox_account_out_balance.Text = tmpBal.ToString("#,##0.00");
				this.textBox_account__out_usedMargin.Text = tmpUM.ToString("#,##0.00");
				this.textBox_account__out_availMargin.Text = tmpAM.ToString("#,##0.00");
				this.textBox_account__out_balance3perc.Text = (tmpBal * 0.03).ToString("#,##0.00");
			}
			else
			{
				this.textBox_account_out_balance.Text = "No Account!";
			}

			this.ctrl_openPositions.InitAPI(ref this.api);
			// Init events
			this.apiEvents.API_PositionChangeEvent += new VTAPIEventHandler.API_PositionChangeEventHandler(this.ctrl_openPositions.PositionChangeEventHandler);
			this.apiEvents.API_InstrumentChangeExEvent += new VTAPIEventHandler.API_InstrumentChnageExEventHandler(this.ctrl_openPositions.InstrumentChangeExEventHandler);
		}
		private void InitFibo()
		{
			this.comboBox_fibo_input_direction.SelectedIndex = 0;
			this.comboBox_fibo_limit_target.SelectedIndex = 3;
			this.comboBox_fibo_limit2_target.SelectedIndex = 1;
		}
		private void InitToolTip()
		{
			this.ttip.AutomaticDelay = 1000;
			this.ttip.AutoPopDelay = 10000;
			this.ttip.BackColor = Color.AntiqueWhite;
			this.ttip.ForeColor = Color.DarkBlue;
			this.ttip.InitialDelay = 1000;
			this.ttip.IsBalloon = false;
			this.ttip.ReshowDelay = 500;
			this.ttip.ShowAlways = true;
			this.ttip.UseAnimation = true;

			// Link items.
		}
		#endregion (Initializers)

		#region Helper functions
		private int StrToInt(string S)
		{
			return (int)TypeDescriptor.GetConverter(typeof(int)).ConvertFrom(S);
		}
		private string IntToStr(int I)
		{
			return (string)TypeDescriptor.GetConverter(typeof(int)).ConvertToString(I);
		}
		public void Echo(string msg)
		{
			DateTime dt = DateTime.Now;
			if (dt.Date > last_dateEcho.Date)
			{
				last_dateEcho = dt;
				edtConsole.Text += "[" + dt.ToString("yyyy-MMM-dd") + "]\r\n---\r\n";
				edtConsole.SelectionStart = edtConsole.Text.Length;
				edtConsole.ScrollToCaret();
			}
			edtConsole.Text += "[" + dt.ToString("HH:mm:ss") + "] ";
			edtConsole.Text += msg + "\r\n";
			edtConsole.SelectionStart = edtConsole.Text.Length;
			edtConsole.ScrollToCaret();
		}
		public void Echo(string msg, string head)
		{
			DateTime dt = DateTime.Now;
			
			if (dt.Date > last_dateEcho.Date)
			{
				last_dateEcho = dt;
				edtConsole.Text += "[" + dt.ToString("yyyy-MMM-dd") + "]\r\n---\r\n";
				edtConsole.SelectionStart = edtConsole.Text.Length;
				edtConsole.ScrollToCaret();
			}
			edtConsole.Text += head + "\r\n";
			edtConsole.SelectionStart = edtConsole.Text.Length;
			edtConsole.ScrollToCaret();
			edtConsole.Text += "[" + dt.ToString("HH:mm:ss") + "] ";
			edtConsole.Text += msg + "\r\n";
			edtConsole.SelectionStart = edtConsole.Text.Length;
			edtConsole.ScrollToCaret();
		}
		private void ShowError(string errormsg)
		{
			MessageBox.Show(errormsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		/// <summary>
		/// Returns the selected number of decimals selected in the tab page Pivot.
		/// </summary>
		/// <returns>Returns 2, 3, 4, 5, or -1 for failure.</returns>
		private int GetPivotDecimals()
		{
			int rv = -1;
			if (radioButton_pivot_input_decimals_2.Checked) rv = 2;
			else if (radioButton_pivot_input_decimals_3.Checked) rv = 3;
			else if (radioButton_pivot_input_decimals_4.Checked) rv = 4;
			else if (radioButton_pivot_input_decimals_5.Checked) rv = 5;

			return rv;
		}

		private void AssignEventsServerEvent()
		{
			//this.api.OnNewServerMessage +=
		//	  new VTAPI.IVT_APIEvents_OnNewServerMessageEventHandler(this.OnNewServerMessage);
			this.api.SetMsgRefresh(this.apiEvents);
			this.apiEvents.API_NewServerMessageEvent += new VTAPIEventHandler.API_NewServerMessageEventHandler(this.api_OnNewServerMessage);
		}

		private void OnNewServerMessage(int msg_index)
		{
			string msg_text = this.api.ServerMessages.get_Items(msg_index).get_Details(0);
			Echo(msg_text);
			checkBalance();
		}

		/// <summary>
		/// Wires up all apiEvents events. Is called in InitAPI when logged in to the servers and apiEvents is initialized. 
		/// </summary>
		private void WireUp_apiEvents()
		{
			// Final check that we are actually logged in.
			if (api.LoggedIn)
			{
				
			}
		}

		private void checkBalance()
		{
			double tmpBal = -1.0;
			double tmpUM = -1.0;
			double tmpAM = -1.0;
			if (this.demoAccount)
			{
				dbl_demoBalance = this.api.Accounts.get_Items(0).Balance;
				tmpBal = dbl_demoBalance;
				tmpAM = this.api.Accounts.get_Items(0).UsableMargin;
				tmpUM = this.api.Accounts.get_Items(0).UsedMargin;
			}
			else if (this.int_serverIndx == 1)
			{
				dbl_liveBalance = api.Accounts.get_Items(1).Balance;
				tmpAM = this.api.Accounts.get_Items(1).UsableMargin;
				tmpUM = this.api.Accounts.get_Items(1).UsedMargin;
				tmpBal = dbl_liveBalance;
			}
			if (tmpBal != -1.0)
			{
				this.textBox_account_out_balance.Text = tmpBal.ToString("#,##0.00");
				this.textBox_account__out_usedMargin.Text = tmpUM.ToString("#,##0.00");
				this.textBox_account__out_availMargin.Text = tmpAM.ToString("#,##0.00");
				this.textBox_account__out_balance3perc.Text = (tmpBal * 0.03).ToString("#,##0.00");
			}
			else
			{
				this.textBox_account_out_balance.Text = "No Account!";
			}
		}

		/// <summary>
		/// Handles the Account Change event keeping the accounts page up-to-date.
		/// </summary>
		/// <param name="id"></param>
		/// <param name="action"></param>
		private void apiEvents_API_AccountChangeEvent(string id, int action)
		{
			Echo("AccountChangeEvent: ID: " + id + ", Action: " + action.ToString());
		}

		private void GetDemoBalance()
		{
			if (api.LoggedIn)
			{
				this.dbl_demoBalance = api.Accounts.get_Items(0).Balance;
			}
			else
			{
				if (Properties.Settings.Default.DemoBalance != -1)
					this.dbl_demoBalance = Properties.Settings.Default.DemoBalance;
				else
					this.dbl_demoBalance = Properties.Settings.Default.DefaultDemoBalance;
			}
		}
		private void GetLiveBalance()
		{
			//throw new NotImplementedException();
		}
		private void UnInitAPI()
		{
			if (b_loggedin)
			{
				if (LogOut())
				{
					//Echo("Logout: " + res.ToString());
					if (this.api != null) this.api.Finalize();
					api = null;
				}
			}
		}
		private void ShowServerList()
		{
			Echo(this.api.GetServerList());
		}
		private bool EditIndex(int index)
		{
			CfrmEditIndex f = new CfrmEditIndex();
			f.edtIndex.Text = IntToStr(index);
			if (f.ShowDialog(this) == DialogResult.OK)
			{
				index = StrToInt(f.edtIndex.Text);
				return true;
			}
			else
				return false;
		}
		private bool EditID(string id)
		{
			/*
			CfrmEditIndex f = new CfrmEditIndex();
			f.edtIndex.Text = id;
			if (f.ShowDialog(this) == DialogResult.OK)
			{
				id = f.edtIndex.Text;
				return true;
			}
			else
				return false;
			 */
			return false;
		}
		private bool Login()
		{
			CfrmLogin frmLogin = new CfrmLogin();
			frmLogin.edtUser.Text = "";
			frmLogin.edtPassword.Text = "";
			int res = -1;
			XmlDocument doc = new XmlDocument();
			doc.LoadXml(this.api.GetServerList());
			XmlNodeList snodes = doc.GetElementsByTagName("server");
			XmlNode snode;

			for (int i = 0; i < snodes.Count; i++)
			{
				snode = snodes.Item(i);
				frmLogin.AddServerToList(snode.Attributes.GetNamedItem("alias").Value,
					int.Parse(snode.Attributes.GetNamedItem("id").Value));
			}

			if (frmLogin.ShowDialog(this) == DialogResult.OK)
			{
				try
				{
					int serverID = frmLogin.cBox_edtServer.SelectedIndex;
					this.int_serverIndx = serverID;
					if(!this.api.LoggedIn)
						res = this.api.Login(frmLogin.edtUser.Text, frmLogin.edtPassword.Text, serverID);
					Echo("Login: " + res.ToString());
					if (res == 0) return true;
					else Echo(api.GetErrorMessage(res));
				}
				catch (Exception e)
				{
					ShowError(e.Message+"\r\n"+api.GetErrorMessage(res));
					return false;
				}
			}
			for (int i = 0; i < api.GetAccountCount(); i++)
			{
				this.api_accounts = (AccountsClass)api.Accounts;
			}
			return false;
		}
		//private bool Login()
		//{
		//    CfrmLogin frmLogin = new CfrmLogin();
		//    frmLogin.edtUser.Text = "";
		//    frmLogin.edtPassword.Text = "";
		//    int res = -1;
		//    XmlDocument doc = new XmlDocument();
		//    doc.LoadXml(this.api.GetServerList());
		//    XmlNodeList snodes = doc.GetElementsByTagName("server");
		//    XmlNode snode;

		//    for (int i = 0; i < snodes.Count; i++)
		//    {
		//        snode = snodes.Item(i);
		//        frmLogin.AddServerToList(snode.Attributes.GetNamedItem("alias").Value,
		//            int.Parse(snode.Attributes.GetNamedItem("id").Value));
		//    }

		//    if (frmLogin.ShowDialog(this) == DialogResult.OK)
		//    {
		//        try
		//        {
		//            int serverID = frmLogin.cBox_edtServer.SelectedIndex;
		//            this.int_serverIndx = serverID;
		//            //Echo("U: " + frmLogin.edtUser.Text + ", P: " + frmLogin.edtPassword.Text + ", S: " + serverID.ToString());
		//            res = this.api.Login(frmLogin.edtUser.Text, frmLogin.edtPassword.Text, serverID);
		//            Echo("Login: " + res.ToString());
		//            if(res==0) return true;
		//        }
		//        catch (Exception e)
		//        {
		//            Echo("Catch: " + e.Message);
		//            return false;
		//        }
		//    }
		//    //for (int i = 0; i < api.GetAccountCount(); i++)
		//    //{
		//    //    this.api_accounts = (AccountsClass)api.Accounts;
		//    //}
		//    return false;

		//            //try
		//            //{
		//            //    int serverID = -1;
		//            //    serverID = frmLogin.cBox_edtServer.SelectedIndex;
		//            //    this.int_serverIndx = serverID;
		//            //    string tmpU = frmLogin.User;
		//            //    string tmpP = frmLogin.Password;
		//            //    Echo("Logging in user: " + tmpU + " ...");
		//            //    Echo("Data User: " + tmpU + ", P: " + tmpP + ", Serv: " + serverID.ToString());
		//            //    System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		//            //    timer.Interval = 500;
		//            //    timer.Start();

		//            //    res = -1;
		//            //    if (tmpU != "" && tmpP != "" && serverID != -1)
		//            //        res = this.api.Login(frmLogin.edtUser.Text, frmLogin.edtPassword.Text, serverID);
		//            //    else
		//            //        Echo("Error in loggin info: User: " + tmpU + ", Pword: " + tmpP + ", ServerID: " + serverID.ToString());
		//            //    Echo("Login: " + res.ToString());
		//            //    if (res == 0)
		//            //    {
		//            //        Echo("User " + tmpU + " logged in.");
		//            //        loggedIn = true;
		//            //        this.LoggedInEvent(ref api, new LoggedInEventArgs());
		//            //        return true;
		//            //    }
		//            //    else
		//            //    {
		//            //        Echo("Loggin failed! Message: " + api.GetErrorMessage(res));
		//            //        return false;
		//            //    }
		//            //}
		//            //catch (Exception e)
		//            //{
		//            //    Echo("Loggin exception! Message: " + e.Message);
		//            //    //Echo("Inner exception: " + e.InnerException.Message);
		//            //    Echo("Stack trace: " + e.StackTrace);
		//            //    Echo("Faulting method: " + e.TargetSite);
		//            //    //ShowError(e.Message);
		//            //    return false;
		//            //}
		//    //    }
		//    //    else
		//    //        return false;
		//    //}
		//    //else
		//    //{
		//    //    Echo("Already logged in!");
		//    //    return true;
		//    //}
		//}
		private bool LogOut()
		{
			try
			{
				this.api.Logout();
				this.b_loggedin = false;
				return true;
			}
			catch (Exception e)
			{
				ShowError(e.Message);
				return false;
			}
		}
		private void LoginStatus()
		{
			if (this.b_loggedin)
				this.statusbar_loggedin_lbl.Text = Properties.Resources.LoggedIn;
			else
				this.statusbar_loggedin_lbl.Text = Properties.Resources.NotLoggedIn;
		}
		/// <summary>
		/// Plaaces controls in the panel_mainTab.
		/// </summary>
		private void PlaceAddedControl_panelMain()
		{
			Point np = nextPoint_panelMain;
			int newH = 0;
			if (panel_mainTab.Controls[panel_mainTab.Controls.Count - 1].Width + np.X > panel_mainTab.Width)
			{
				for (int i = 0; i < panel_mainTab.Controls.Count; i++)
				{
					if (newH < panel_mainTab.Controls[i].Location.Y + panel_mainTab.Controls[i].Height)
						newH = panel_mainTab.Controls[i].Location.Y + panel_mainTab.Controls[i].Height;
				}
				np.Y = newH;
				np.X = 0;
			}

			// Place the control
			panel_mainTab.Controls[panel_mainTab.Controls.Count - 1].Location = np;
		}
		#endregion (Helper functions)

		#region Event Handlers
		private void menu_edit_alwaysOnTop_Click(object sender, EventArgs e)
		{
			if (this.TopMost)
				this.TopMost = false;
			else
				this.TopMost = true;

			this.menu_edit_alwaysOnTop.Checked = this.TopMost;
			this.statusbar_form_alwaysOnTop.Checked = this.TopMost;
		}
		private void Login_evntHndlr(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(ToolStripButton))
			{
				toolStrip_MouseUp(sender, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
			}
			InitAPI();
			LoginStatus();
		}
		private void Logout_evntHndlr(object sender, EventArgs e)
		{
			UnInitAPI();
			LoginStatus();
		}
		private void Place_trade_evntHndlr(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(ToolStripButton))
			{
				toolStrip_MouseUp(sender, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
			}
			EnterTrade();
		}
		private void exitApplication(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private void menu_tools_resetDemoAccount_Click(object sender, EventArgs e)
		{
			ResetDemoBalance();
		}
		private void tabControl_main_SelectedIndexChanged(object sender, EventArgs e)
		{

			switch (((TabControl)sender).SelectedTab.Name)
			{
				case "tabPage_fibo":
					this.AcceptButton = this.btn_fibo_calculate;
					this.textBox_fibo_input_high.Focus();
					break;
				case "tabPage_pivot":
					this.AcceptButton = this.btn_pivot_calculate;
					this.textBox_pivot_input_high.Focus();
					break;
				default:
					this.AcceptButton = null;
					break;
			}
		}
		private void frm_main_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
				exitApplication(this, new EventArgs());
		}
		/// <summary>
		/// Clears the panel_mainTab from all controls.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="arg"></param>
		private void ClearMainTabPanel(object sender, EventArgs arg)
		{
			panel_mainTab.Controls.Clear();
			// Reset the variable for control placement
			this.nextPoint_panelMain.X = 0;
			this.nextPoint_panelMain.Y = 0;
		}
		private void CalcMaxLotSize(object sender, EventArgs e)
		{
			this.tabControl_main.SelectedTab = this.tabPage_main;
			ctrl_CalculateMaxLotSize ctrl = new ctrl_CalculateMaxLotSize();
			if(!CheckControlExists_panelMainTab(ctrl.GetType()))
			{
			panel_mainTab.Controls.Add(ctrl);
			ctrl.MaxLotSizeCalculated += new ctrl_CalculateMaxLotSize.MaxLotSizeCalculatedEventHandler(ctrl_MaxLotSizeCalculated);
			ctrl.CloseControlEvent+=new D4MControl.CloseControlEventHandler(RemoveControlMainTabPanel);
			}
			else
			{
				try
				{
					GetControlFromType(ctrl.GetType()).Focus();
				}
				catch (Exception ex)
				{ }
			}
		}
		/// <summary>
		/// Adds a new ctrl_calculateDistance control to panel_mainTab's control list
		/// and hooks up cotrol specific events to their event handlers.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CalcDistance(object sender, EventArgs e)
		{
			if (sender.GetType() == typeof(ToolStripButton))
			{
				toolStrip_MouseUp(sender, new MouseEventArgs(MouseButtons.Left, 1, 1, 1, 0));
			}
			this.tabControl_main.SelectedTab = this.tabPage_main;
			ctrl_calculateDistance ctrl = new ctrl_calculateDistance();
			if (!CheckControlExists_panelMainTab(ctrl.GetType()))
			{
				panel_mainTab.Controls.Add(ctrl);
				ctrl.DistanceCalculated += new ctrl_calculateDistance.DistanceCalculatedEventsHandler(frm_DistanceCalculated);
				ctrl.CloseControlEvent += new D4MControl.CloseControlEventHandler(RemoveControlMainTabPanel);
			}
			else
			{
				try
				{
					GetControlFromType(ctrl.GetType()).Focus();
				}
				catch (Exception ex)
				{ }
			}
		}
		private void CalcTrailingStop(object sender, EventArgs e)
		{
			this.tabControl_main.SelectedTab = this.tabPage_main;
			ctrl_trailingStopCalculations ctrl = new ctrl_trailingStopCalculations();
			if (!CheckControlExists_panelMainTab(ctrl.GetType()))
			{
				panel_mainTab.Controls.Add(ctrl);
				ctrl.StopCalculated += new ctrl_trailingStopCalculations.StopCalculatedEventHandler(ctrl_StopCalculated);
				ctrl.CloseControlEvent += new D4MControl.CloseControlEventHandler(RemoveControlMainTabPanel);
			}
			else
			{
				try
				{
					GetControlFromType(ctrl.GetType()).Focus();
				}
				catch (Exception ex)
				{ }
			}
		}
		/// <summary>
		/// Event handler for controls sending an event that the calculation is done.
		/// Sends the results to be printed to the Echo function.
		/// Control of type: ctrl_trailingStopCaclulations
		/// </summary>
		/// <param name="sender">Object invoking the call</param>
		/// <param name="arg">Calculation parameters</param>
		private void ctrl_StopCalculated(object sender, StopCalculatedEventArgs arg)
		{
			Echo("Last: " + arg.Stop + " | Current: " + arg.CurrentTarget + " | Next: " + arg.Next,"Trailing Stop:");
		}
		/// <summary>
		/// Responds to the panel_mainTab added control event.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void panel_mainTab_ControlAdded(object sender, ControlEventArgs e)
		{
			this.panel_mainTab.SuspendLayout();
			PlaceAddedControl_panelMain();
			this.panel_mainTab.ResumeLayout();
			if (panel_mainTab.Controls.Count > 0)
			{
				panel_mainTab.ScrollControlIntoView(panel_mainTab.Controls[panel_mainTab.Controls.Count - 1]);
				panel_mainTab.Controls[panel_mainTab.Controls.Count - 1].Focus();
				// Update next controls location point.
				this.nextPoint_panelMain.Y = this.panel_mainTab.Controls[panel_mainTab.Controls.Count - 1].Location.Y;
				this.nextPoint_panelMain.X = this.panel_mainTab.Controls[panel_mainTab.Controls.Count - 1].Location.X + panel_mainTab.Controls[panel_mainTab.Controls.Count - 1].Width;
			}

		}
		/// <summary>
		/// Removes a control in the main tab panel.
		/// </summary>
		/// <param name="sender">The control to remove.</param>
		/// <param name="arg">Close control event arguments.</param>
		private void RemoveControlMainTabPanel(object sender, D4M.Controls.Common.CloseControlEventArgs arg)
		{
			this.panel_mainTab.SuspendLayout();
			try
			{
				// Remove the selected control
				panel_mainTab.Controls.Remove((D4MControl)sender);
				// Re-arrange the remaining controls
				ResetControls_panelMainTab();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Control: " + sender.ToString() + " is not a D4MControl");
			}
			this.panel_mainTab.ResumeLayout();
		}
		#region External Forms & Controls Event Handlers
		void frm_CloseDistanceCalcControl(object sender, CloseControlEventArgs arg)
		{
			if (panel_mainTab.Controls.Contains((ctrl_calculateDistance)sender))
				this.panel_mainTab.Controls.Remove((ctrl_calculateDistance)sender);
			else panel_mainTab.Controls.Clear();
		}
		/// <summary>
		/// Handles the MaxLotSizeCalculated event from the frm_CalculateMaxLotSize
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e">Contains the calculated lot size.</param>
		void ctrl_MaxLotSizeCalculated(object sender, MaxLotSizeCalculatedEventArgs e)
		{
			Echo("Max Lot Size: " + e.LotSize.ToString("0.0"));
		}
		void frm_DistanceCalculated(object sender, DistanceCaclulatedEventArgs arg)
		{
			Echo("Distance: " + arg.Distance.ToString("0.0") + " " + arg.Direction);
		}
		#endregion (External Forms & Controls Event Handlers)
		#region Special Event Handlers
		private void textBox_fibo_input_high_Enter(object sender, EventArgs e)
		{
			if (this.textBox_fibo_input_high.Text != "")
			{
				if (this.textBox_fibo_input_high.Text.IndexOf('.') != -1)
					this.textBox_fibo_input_high.Select(this.textBox_fibo_input_high.Text.IndexOf('.') + 1, 4);
			}
		}
		private void textBox_fibo_input_low_Enter(object sender, EventArgs e)
		{
			if (this.textBox_fibo_input_low.Text != "")
			{
				if (this.textBox_fibo_input_low.Text.IndexOf('.') != -1)
					this.textBox_fibo_input_low.Select(this.textBox_fibo_input_low.Text.IndexOf('.') + 1, 4);
			}
		}
		private void textBox_pivot_input_high_Enter(object sender, EventArgs e)
		{
			if (this.textBox_pivot_input_high.Text != "")
			{
				if (this.textBox_pivot_input_high.Text.IndexOf('.') != -1)
					this.textBox_pivot_input_high.Select(this.textBox_pivot_input_high.Text.IndexOf('.') + 1, 4);
			}
		}
		private void textBox_pivot_input_low_Enter(object sender, EventArgs e)
		{
			if (this.textBox_pivot_input_low.Text != "")
			{
				if (this.textBox_pivot_input_low.Text.IndexOf('.') != -1)
					this.textBox_pivot_input_low.Select(this.textBox_pivot_input_low.Text.IndexOf('.') + 1, 4);
			}
		}
		private void textBox_pivot_input_close_Enter(object sender, EventArgs e)
		{
			if (this.textBox_pivot_input_close.Text != "")
			{
				int dec = GetPivotDecimals();
				if (this.textBox_pivot_input_close.Text.IndexOf('.') != -1)
					this.textBox_pivot_input_close.Select(this.textBox_pivot_input_close.Text.IndexOf('.') + 1, 4);
			}
		}
		#endregion (Special Event Handlers)
		#endregion (Event Handlers)

		#region Functions
		#region Private Functions
		private void EnterTrade()
		{
			frm_EnterTrade frm = new frm_EnterTrade();
			// Edit if the index for demo server changes in the VTAPI
			if (this.int_serverIndx == 0)
				frm.Balance = this.dbl_demoBalance;
			else
				frm.Balance = this.dbl_liveBalance;

			if (frm.ShowDialog(this) == DialogResult.OK)
			{
				this.trades_list.Add(frm.Trade);
				Echo("Number of trades: " + this.trades_list.Count + " | last ID: " + frm.Trade.TradeID);// For test only!
			}

		}
		private void ResetDemoBalance()
		{
			frm_confirmResetDemoBalance frm = new frm_confirmResetDemoBalance();
			if (frm.ShowDialog(this) == DialogResult.OK)
			{
				Properties.Settings.Default.DemoBalance = -1.0;
				if (frm.NewAmount)
				{
					Properties.Settings.Default.DefaultDemoBalance = frm.NewDefaultAmount;
					this.dbl_demoBalance = frm.NewDefaultAmount;
				}
				else
					this.dbl_demoBalance = Properties.Settings.Default.DefaultDemoBalance;

				Echo("Demo Account Balance is reset!");
				Echo("New balance: " + this.dbl_demoBalance.ToString("$#,##0.00"));
			}
		}
		private void ResetControls_panelMainTab()
		{
			int newH = 0;
			Point np = new Point(0, 0);

			foreach (Control ctrl in panel_mainTab.Controls)
			{
				if (np.X + ctrl.Width > panel_mainTab.Width)
				{
					np.Y = newH;
					np.X = 0;
				}
				// Get next row location.
				if (newH < ctrl.Height + np.Y) newH = ctrl.Height + np.Y;
				// Place control.
				ctrl.Location = np;
				// Set next horrisontal location
				np.X += ctrl.Width;
			}
			// Update next control location point value.
			this.nextPoint_panelMain = np;
		}
		private Control GetControlFromType(Type type)
		{
			foreach (Control c in panel_mainTab.Controls)
			{
				if (type == c.GetType())
				{
					return c;
				}
			}
			return null;
		}
		private bool CheckControlExists_panelMainTab(Type t)
		{
			bool rv = false;

			foreach (object obj in panel_mainTab.Controls)
			{
				if (t == obj.GetType())
				{
					rv = true;
					break;
				}
			}

			return rv;
		}
		#endregion (Private Functions)
		#region Public Functions
		public void RunPositionForm(bool openPos, bool stop, bool limit, bool change, bool close, string id)
		{
			frm_PositionManager frm = new frm_PositionManager(ref this.api);
			if (openPos && stop) frm.Functionality_lbl.Text = "Manage Stop";
			else if (openPos && limit) frm.Functionality_lbl.Text = "Manage Limit";
			//else if(
		}
		#endregion (Public Dunctions)
		#endregion (Functions)

		#region Tab Specific Functions
		private void CalculateFibo(object Sender, EventArgs e)
		{
			double high = 0, low = 0, out_23, out_38, out_50, out_61, out_76, out_161, out_261;
			double lim_100, lim_161, lim_261, lim_100a, lim_161a, lim_261a;
			double lim2_100, lim2_161, lim2_261, lim2_100a, lim2_161a, lim2_261a;
			double targetPrice = 0, targetPrice2 = 0;
			int direction, target = 0, target2 = 0;

			// Get input
			if (this.textBox_fibo_input_high.Text != "")
				high = double.Parse(this.textBox_fibo_input_high.Text);
			if (this.textBox_fibo_input_low.Text != "")
				low = double.Parse(this.textBox_fibo_input_low.Text);
			direction = this.comboBox_fibo_input_direction.SelectedIndex;

			// Calculate Fibo levels
			// Set up as default direction for calculation purposes
			double res = high - low;
			out_23 = high - res * 0.236;
			out_38 = high - res * 0.382;
			out_50 = high - res * 0.500;
			out_61 = high - res * 0.618;
			out_76 = high - res * 0.764;
			if (direction == 0)
			{
				out_161 = high - res * 1.618;
				out_261 = high - res * 2.618;
			}
			else
			{
				out_161 = low + res * 1.618;
				out_261 = low + res * 2.618;
			}

			// Display results
			if (direction == 0)   //Up
			{
				this.textBox_fibo_236.Text = Math.Round(out_23, 4).ToString("0.0000");
				this.textBox_fibo_382.Text = Math.Round(out_38, 4).ToString("0.0000");
				this.textBox_fibo_500.Text = Math.Round(out_50, 4).ToString("0.0000");
				this.textBox_fibo_618.Text = Math.Round(out_61, 4).ToString("0.0000");
				this.textBox_764.Text = Math.Round(out_76, 4).ToString("0.0000");
			}
			else   // Down
			{
				this.textBox_fibo_236.Text = Math.Round(out_76, 4).ToString("0.0000");
				this.textBox_fibo_382.Text = Math.Round(out_61, 4).ToString("0.0000");
				this.textBox_fibo_500.Text = Math.Round(out_50, 4).ToString("0.0000");
				this.textBox_fibo_618.Text = Math.Round(out_38, 4).ToString("0.0000");
				this.textBox_764.Text = Math.Round(out_23, 4).ToString("0.0000");
			}
			this.textBox_fibo_1618.Text = Math.Round(out_161, 4).ToString("0.0000");
			this.textBox_fibo_2618.Text = Math.Round(out_261, 4).ToString("0.0000");

			// Calculate Limit levels
			switch (this.comboBox_fibo_limit_target.SelectedIndex)
			{
				case 0:			// 23% level
					target = 0;
					targetPrice = direction == 0 ? out_23 : out_76;
					break;
				case 1:			// 38% level
					target = 1;
					targetPrice = direction == 0 ? out_38 : out_61;
					break;
				case 2:			// 50% level
					target = 2;
					targetPrice = out_50;
					break;
				case 3:			// 61% level
					target = 3;
					targetPrice = direction == 0 ? out_61 : out_38;
					break;
				case 4:
					target = 4;
					targetPrice = direction == 0 ? out_76 : out_23;
					break;
			}

			switch (this.comboBox_fibo_limit2_target.SelectedIndex)
			{
				case 0:			// 23% level
					target2 = 0;
					targetPrice2 = direction == 0 ? out_23 : out_76;
					break;
				case 1:			// 38% level
					target2 = 1;
					targetPrice2 = direction == 0 ? out_38 : out_61;
					break;
				case 2:			// 50% level
					target2 = 2;
					targetPrice2 = out_50;
					break;
				case 3:			// 61% level
					target2 = 3;
					targetPrice2 = direction == 0 ? out_61 : out_38;
					break;
				case 4:
					target2 = 4;
					targetPrice2 = direction == 0 ? out_76 : out_23;
					break;
			}

			// Calculate the limits
			res = direction == 0 ? high - targetPrice : targetPrice - low;
			double res2 = direction == 0 ? high - targetPrice2 : targetPrice2 - low;
			lim_100 = direction == 0 ? high : low;
			lim2_100 = direction == 0 ? high : low;
			lim_161 = direction == 0 ? res * 1.618 + targetPrice : targetPrice - res * 1.618;
			lim_261 = direction == 0 ? targetPrice + res * 2.618 : targetPrice - res * 2.618;
			lim2_161 = direction == 0 ? res2 * 1.618 + targetPrice2 : targetPrice2 - res2 * 1.618;
			lim2_261 = direction == 0 ? targetPrice2 + res2 * 2.618 : targetPrice2 - res2 * 2.618;
			// These following calculations needs to be reaplaced when we have a proper system for deciding wich currency we are presently using so that currency specific properties can be used.
			lim_100a = Math.Round(Math.Abs(targetPrice - lim_100), 4) * 10000 * 10;
			lim_161a = Math.Round(Math.Abs(lim_161 - targetPrice), 4) * 10000 * 10;
			lim_261a = Math.Round(Math.Abs(lim_261 - targetPrice), 4) * 10000 * 10;
			lim2_100a = Math.Round(Math.Abs(targetPrice2 - lim2_100), 4) * 10000 * 10;
			lim2_161a = Math.Round(Math.Abs(lim2_161 - targetPrice2), 4) * 10000 * 10;
			lim2_261a = Math.Round(Math.Abs(lim2_261 - targetPrice2), 4) * 10000 * 10;

			// Display limit data
			this.textBox_fibo_limit_targetPrice.Text = Math.Round(targetPrice, 4).ToString("0.0000");
			this.textBox_fibo_limit_1000.Text = Math.Round(lim_100, 4).ToString("0.0000");
			this.textBox_fibo_limit_1618.Text = Math.Round(lim_161, 4).ToString("0.0000");
			this.textBox_fibo_limit_2618.Text = Math.Round(lim_261, 4).ToString("0.0000");
			this.textBox_fibo_limit_1000_amount.Text = Math.Round(lim_100a, 2).ToString("$#,##0.00");
			this.textBox_fibo_limit_1618_amount.Text = Math.Round(lim_161a, 2).ToString("$#,##0.00");
			this.textBox_fibo_limit_2618_amount.Text = Math.Round(lim_261a, 2).ToString("$#,##0.00");
			// limit 2 level
			this.textBox_fibo_limit2_targetPrice.Text = Math.Round(targetPrice2, 4).ToString("0.0000");
			this.textBox_fibo_limit2_1000.Text = Math.Round(lim2_100, 4).ToString("0.0000");
			this.textBox_fibo_limit2_1618.Text = Math.Round(lim2_161, 4).ToString("0.0000");
			this.textBox_fibo_limit2_2618.Text = Math.Round(lim2_261, 4).ToString("0.0000");
			this.textBox_fibo_limit2_1000_amount.Text = Math.Round(lim2_100a, 2).ToString("$#,##0.00");
			this.textBox_fibo_limit2_1618_amount.Text = Math.Round(lim2_161a, 2).ToString("$#,##0.00");
			this.textBox_fibo_limit2_2618_amount.Text = Math.Round(lim2_261a, 2).ToString("$#,##0.00");
		}
		private void CalculatePivot(object sender, EventArgs e)
		{
			double high, low, close, p, rm1, r1, rm2, rm2a, r2, r2a, rm3, rm3a, r3, sm1, s1, sm2, sm2a, s2, s2a, sm3, sm3a, s3;
			bool inputOK = true;

			// Get inputs
			high = this.textBox_pivot_input_high.Text != "" ? double.Parse(this.textBox_pivot_input_high.Text) : -1.0;
			low = this.textBox_pivot_input_low.Text != "" ? double.Parse(this.textBox_pivot_input_low.Text) : -1.0;
			close = this.textBox_pivot_input_close.Text != "" ? double.Parse(this.textBox_pivot_input_close.Text) : -1.0;
			string f = "0.0000";

			if (high == -1.0 || low == -1.0 || close == -1.0) inputOK = false;
			else inputOK = true;
			
			// Calculate the pivot levels
			if (inputOK)
			{
				// Calculate the pivot level
				p = (high + low + close) / 3;		// Pivot level

				// Calculate standard pivot levels
				r1 = 2 * p - low;					// Resistence R1
				s1 = 2 * p - high;					// Support S1
				r2 = p + (r1 - s1);					// Resistance R2
				r2a = 3 * p - 2 * low;				// Resisteance R2A (alternative)
				s2 = p - (r1 - s1);					// Support S2
				s2a = 3 * p - 2 * high;				// Support S2A (alternative)
				r3 = high + 2 * (p - low);			// Resisteance R3
				s3 = low - 2 * (high - p);			// Support S3

				// Calculate middle levels
				rm1 = (p + r1) / 2;					// Resistance RM1
				rm2 = (r1 + r2) / 2;				// Resistance RM2
				rm2a = (r1 + r2a) / 2;				// Resistance RM2A (alternative)
				rm3 = (r2 + r3) / 2;				// Resistance RM3
				rm3a = (r2a + r3) / 2;				// Resistance RM3A (alternative)
				sm1 = (p + s1) / 2;					// Support SM1
				sm2 = (s1 + s2) / 2;				// Support SM2
				sm2a = (s1 + s2a) / 2;				// Support SM2A (alternative)
				sm3 = (s2 + s3) / 2;				// Support SM3
				sm3a = (s2a + s3) / 2;				// Support SM3A (alternative)

				// Display results
				this.textBox_pivot_pivot.Text = Math.Round(p, 4).ToString(f);

				this.textBox_pivot_resistance_r1.Text = Math.Round(r1, 4).ToString(f);
				this.textBox_pivot_resistance_r2.Text = Math.Round(r2, 4).ToString(f);
				this.textBox_pivot_resistance_r3.Text = Math.Round(r3, 4).ToString(f);
				this.textBox_pivot_resistance_rm1.Text = Math.Round(rm1, 4).ToString(f);
				this.textBox_pivot_resistance_rm2.Text = Math.Round(rm2, 4).ToString(f);
				this.textBox_pivot_resistance_rm3.Text = Math.Round(rm3, 4).ToString(f);
				// Alternative resistance
				//this.textBox_pivot_resistance_r2a.Text = Math.Round(r2a, 4).ToString(f);
				//this.textBox_pivot_resistance_rm2a.Text = Math.Round(rm2a, 4).ToString(f);
				//this.textBox_pivot_resistance_rm3a.Text = Math.Round(rm3a, 4).ToString(f);

				this.textBox_pivot_support_s1.Text = Math.Round(s1, 4).ToString(f);
				this.textBox_pivot_support_s2.Text = Math.Round(s2, 4).ToString(f);
				this.textBox_pivot_support_s3.Text = Math.Round(s3, 4).ToString(f);
				this.textBox_pivot_support_sm1.Text = Math.Round(sm1, 4).ToString(f);
				this.textBox_pivot_support_sm2.Text = Math.Round(sm2, 4).ToString(f);
				this.textBox_pivot_support_sm3.Text = Math.Round(sm3, 4).ToString(f);
				// Alternative support
				//this.textBox_pivot_support_s2a.Text = Math.Round(s2a, 4).ToString(f);
				//this.textBox_pivot_support_sm2a.Text = Math.Round(sm2a, 4).ToString(f);
				//this.textBox_pivot_support_sm3a.Text = Math.Round(sm3a, 4).ToString(f);

				if (this.checkBox_pivot_input_addPrint.Checked)
				{
					CPivotValue val = new CPivotValue();
					val.Date = this.dateTimePicker_pivot_date.Value;
					val.Dbl_PivotPoint = p;
					val.Dbl_R1 = r1;
					val.Dbl_R2 = r2;
					val.Dbl_R2A = r2a;
					val.Dbl_R3 = r3;
					val.Dbl_RM1 = rm1;
					val.Dbl_RM2 = rm2;
					val.Dbl_RM2A = rm2a;
					val.Dbl_RM3 = rm3;
					val.Dbl_RM3A = rm3a;
					val.Dbl_S1 = s1;
					val.Dbl_S2 = s2;
					val.Dbl_S2A = s2a;
					val.Dbl_S3 = s3;
					val.Dbl_SM1 = sm1;
					val.Dbl_SM2 = sm2;
					val.Dbl_SM2A = sm2a;
					val.Dbl_SM3 = sm3;
					val.Dbl_SM3A = sm3a;
					this.pivot4print.Add(val);
				}
			}
		}
		#endregion (Tab Specific Functions)

		#region Print Calls Event Handlers
		private void menu_file_pageSetup_Click(object sender, EventArgs e)
		{
			bool pageOK = true;
			switch (this.tabControl_main.SelectedTab.Name)
			{
				case "tabPage_pivot":
					this.pageSetupDialog.Document = this.pivotDocument;
					break;
				case "tabPage_fibo":
					this.pageSetupDialog.Document = this.fiboDocument;
					break;
				default:
					MessageBox.Show("No available page selected to print!", "Print Page Selection Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					pageOK = false;
					break;
				
			}
			if(pageOK) this.pageSetupDialog.ShowDialog();
		}

		private void menu_file_printPreview_Click(object sender, EventArgs e)
		{
			bool pageOK = true;
			switch (this.tabControl_main.SelectedTab.Name)
			{
				case "tabPage_pivot":
					this.printPreviewDialog.Document = this.pivotDocument;
					break;
				case "tabPage_fibo":
					this.printPreviewDialog.Document = this.fiboDocument;
					break;
				default:
					MessageBox.Show("No available page selected to preview!", "Page Selection Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					pageOK = false;
					break;
			}
			if (pageOK)
			{
				this.printPreviewDialog.PrintPreviewControl.Zoom = 0.8;
				this.printPreviewDialog.UseAntiAlias = false;
				this.printPreviewDialog.Width = this.printPreviewDialog.Document.DefaultPageSettings.Bounds.Width + 50;
				this.printPreviewDialog.Height = (int)Math.Round((double)(this.printPreviewDialog.Document.DefaultPageSettings.Bounds.Height / 2), 0) + 100;
				this.printPreviewDialog.ShowDialog(this);
			}
		}

		private void LoadPivotPage()
		{
			
		}

		private void menu_file_print_Click(object sender, EventArgs e)
		{
			bool pageOK = true;
			switch (this.tabControl_main.SelectedTab.Name)
			{
				case "tabPage_pivot":
					//this.pageSetupDialog.Document = this.pivotDocument;
					break;
				case "tabPage_fibo":
					//this.pageSetupDialog.Document = this.fiboDocument;
					break;
				default:
					//MessageBox.Show("No available page selected to print!", "Print Page Selection Error!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					pageOK = false;
					break;
			}
		}
		#endregion (Print Calls Event Handlers)

		private void pivotDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
		{
			StringFormat cname = new StringFormat();
			cname.Alignment = StringAlignment.Center;
			cname.LineAlignment = StringAlignment.Near;
			RectangleF prnRect = this.pivotDocument.DefaultPageSettings.PrintableArea;
			RectangleF currRect = prnRect;
			int lineHeightNormal = 18;
			this.pivotDocument.OriginAtMargins = true;
			e.Graphics.DrawString("Jotrafin", this.compNameTxtPrintFont, Brushes.DarkBlue, currRect, cname);
			currRect.Y += 45;
			e.Graphics.DrawString("Johannesson Trading & Financing", this.fullCmpNameTxtPrintFont, Brushes.Teal, currRect, cname);
			currRect.Y += 5 * lineHeightNormal;
			int doc_width = this.pivotDocument.DefaultPageSettings.Bounds.Width;
			int doc_height = this.pivotDocument.DefaultPageSettings.Bounds.Height;
			int pa_top = (int)Math.Round(this.pivotDocument.DefaultPageSettings.PrintableArea.Top,0);
			int pa_left = (int)Math.Round(this.pivotDocument.DefaultPageSettings.PrintableArea.Left,0);
			int pa_height = (int)Math.Round(this.pivotDocument.DefaultPageSettings.PrintableArea.Height,0);
			int pa_width = (int)Math.Round(this.pivotDocument.DefaultPageSettings.PrintableArea.Width,0);
			int pa_right = (int)Math.Round(this.pivotDocument.DefaultPageSettings.PrintableArea.Right, 0);
			int xpos = pa_left;
			Pen resSupDiv = new Pen(Color.Black,1);
			Pen dividerPen = new Pen(Color.Black,3);
			SizeF s;
			
			if(this.pivot4print.Count>0)
			{
				this.pivotDocument.DocumentName = "Pivot Levels";
				//e.HasMorePages = true;
			    for(int i =0;i<this.pivot4print.Count;i++)
			    {
					xpos = pa_left;
					e.Graphics.DrawString("Date: ", this.normalUnderTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += 40;
					e.Graphics.DrawString(pivot4print.Items[i].Date_String, this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += 160;
					e.Graphics.DrawString("Currency Pair:", this.normalUnderTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += 100;
					e.Graphics.DrawString(pivot4print.Items[i].Pair, this.normalBoldTxtPrintFont,Brushes.Black, xpos, currRect.Y);

					// Next line (Pivot Point)
					currRect.Y += 3*lineHeightNormal;
					xpos = pa_left;
					e.Graphics.DrawString("Pivot Level:", this.normalUnderTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += 100;
					e.Graphics.DrawString(pivot4print.Items[i].PivotPoint, normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);

					// Next line (Resistance)
					currRect.Y += 2 * lineHeightNormal;
					xpos = pa_left;
					e.Graphics.DrawString("Resistance Levels", head2TxtPrintFont, Brushes.Black, xpos, currRect.Y);
					currRect.Y += lineHeightNormal + (int)Math.Round((double)(lineHeightNormal/2),0); // New Line
					// RM1
					e.Graphics.DrawString("RM1:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("RM1:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width,0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].RM1, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].RM1, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 100 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// R1
					e.Graphics.DrawString("R1:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("R1:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].R1, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].R1, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// RM2
					e.Graphics.DrawString("RM2:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("RM2:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].RM2, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].RM2, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// RM2A
					e.Graphics.DrawString("RM2A:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("RM2A:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].RM2A, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].RM2A, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// R2
					e.Graphics.DrawString("R2:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("R2:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].R2, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].R2, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// R2A
					e.Graphics.DrawString("R2A:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("R2A:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].R2A, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].R2A, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// RM3
					e.Graphics.DrawString("RM3:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("RM3:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].RM3, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].RM3, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// RM3A
					e.Graphics.DrawString("RM3A:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("RM3A:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].RM3A, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].RM3A, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// R3
					e.Graphics.DrawString("R3:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("R3:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].R3, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].R3, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}

					// Resisteance Support Divider
					currRect.Y += lineHeightNormal + 6;
					xpos = pa_left;
					e.Graphics.DrawLine(resSupDiv, xpos, (int)Math.Round(currRect.Y, 0), pa_right, (int)Math.Round(currRect.Y, 0));
					currRect.Y += lineHeightNormal + 6;

					// New Line (Support)
					e.Graphics.DrawString("Support Levels", head2TxtPrintFont, Brushes.Black, xpos, currRect.Y);
					currRect.Y += lineHeightNormal + (int)Math.Round((double)(lineHeightNormal / 2), 0); // New Line
					// SM1
					e.Graphics.DrawString("SM1:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("SM1:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].SM1, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].SM1, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// S1
					e.Graphics.DrawString("S1:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("S1:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].S1, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].S1, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// SM2
					e.Graphics.DrawString("SM2:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("SM2:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].SM2, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].SM2, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// SM2A
					e.Graphics.DrawString("SM2A:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("SM2A:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].SM2A, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].SM2A, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// S2
					e.Graphics.DrawString("S2:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("S2:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].S2, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].S2, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// S2A
					e.Graphics.DrawString("S2A:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("S2A:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].S2A, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].S2A, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// SM3
					e.Graphics.DrawString("SM3:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("SM3:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].SM3, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].SM3, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// SM3A
					e.Graphics.DrawString("SM3A:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("SM3A:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].SM3A, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].SM3A, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}
					// S3
					e.Graphics.DrawString("S3:", this.normalBoldTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					s = e.Graphics.MeasureString("S3:", this.normalBoldTxtPrintFont);
					xpos += (int)Math.Round(s.Width, 0) + 5;
					e.Graphics.DrawString(pivot4print.Items[i].S3, this.normalTxtPrintFont, Brushes.Black, xpos, currRect.Y);
					xpos += (int)Math.Round(e.Graphics.MeasureString(pivot4print.Items[i].S3, this.normalTxtPrintFont).Width, 0) + 15;
					if (xpos + 200 > pa_right)
					{
						currRect.Y += lineHeightNormal;
						xpos = pa_left;
					}

					// Group Divider
					currRect.Y += lineHeightNormal + 6;
					xpos = pa_left;
					e.Graphics.DrawLine(dividerPen, xpos, (int)Math.Round(currRect.Y, 0), pa_right, (int)Math.Round(currRect.Y, 0));
					currRect.Y += lineHeightNormal *2;
			    }
				//e.HasMorePages = false;
			}
		}

		private void statusbar_ontop_btn_ButtonClick(object sender, EventArgs e)
		{
			menu_edit_alwaysOnTop_Click(sender, e);
		}

		private void toolStrip_arbitrage_Click(object sender, EventArgs e)
		{
			if (this.api.LoggedIn)
			{
				ctrl_Arbitrage ctrl = new ctrl_Arbitrage();
				ctrl.LoadArbitrageCurrencies(api.Instruments);
				this.panel_mainTab.Controls.Add(ctrl);
				apiEvents.API_InstrumentChangeExEvent += new VTAPIEventHandler.API_InstrumentChnageExEventHandler(ctrl.HandleInstrumentChangeEx);
			}
			else
			{
				Echo("Arbitrage control not available when Not Logged in!");
			}

		}

		private void toolStrip_MouseDown(object sender, MouseEventArgs e)
		{
			((ToolStripButton)(sender)).Image = Image.FromFile(@"D:\C#\Jotrafin-Trader 1\Jotrafin-Trader 1\Blue Button Down24x70.png");
				//Properties.Resources.ToolStripBtnDown
			
		}
		private void toolStrip_MouseUp(object sender, MouseEventArgs e)
		{
			((ToolStripButton)(sender)).Image = Image.FromFile(@"D:\C#\Jotrafin-Trader 1\Jotrafin-Trader 1\Blue Button24x70.png");
		}
	}

	public class LoggedInEventArgs : EventArgs
	{
	}
}
