namespace D4M.FINANCE.JOTRAFIN
{
	partial class frm_EnterTrade
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.groupBox_information = new System.Windows.Forms.GroupBox();
			this.groupBox_risk = new System.Windows.Forms.GroupBox();
			this.txtBox_riskInCurrency = new System.Windows.Forms.TextBox();
			this.lbl_riskInCurrency = new System.Windows.Forms.Label();
			this.txtBox_balanceOnLoss = new System.Windows.Forms.TextBox();
			this.lbl_balanceOnLoss = new System.Windows.Forms.Label();
			this.txtBox_riskInPercent = new System.Windows.Forms.TextBox();
			this.lbl_riskInPercent = new System.Windows.Forms.Label();
			this.groupBox_profits = new System.Windows.Forms.GroupBox();
			this.txtBox_limit1Profit = new System.Windows.Forms.TextBox();
			this.lbl_limit1 = new System.Windows.Forms.Label();
			this.lbl_limit2 = new System.Windows.Forms.Label();
			this.txtBox_profitTotal = new System.Windows.Forms.TextBox();
			this.txtBox_limit2Profit = new System.Windows.Forms.TextBox();
			this.lbl_profitTotal = new System.Windows.Forms.Label();
			this.lbl_limit3 = new System.Windows.Forms.Label();
			this.txtBox_limit3Profit = new System.Windows.Forms.TextBox();
			this.txtBox_tradeID = new System.Windows.Forms.TextBox();
			this.lbl_tradeID = new System.Windows.Forms.Label();
			this.txtBox_currentBalance = new System.Windows.Forms.TextBox();
			this.lbl_currentBalance = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.checkBox_trailingStop = new System.Windows.Forms.CheckBox();
			this.txtBox_limit3Lots = new System.Windows.Forms.TextBox();
			this.lbl_limit3Lots = new System.Windows.Forms.Label();
			this.txtBox_limit2Lots = new System.Windows.Forms.TextBox();
			this.lbl_limit2Lots = new System.Windows.Forms.Label();
			this.txtBox_limit1Lots = new System.Windows.Forms.TextBox();
			this.lbl_limit1Lots = new System.Windows.Forms.Label();
			this.txtBox_limit3Price = new System.Windows.Forms.TextBox();
			this.lbl_limit3Price = new System.Windows.Forms.Label();
			this.txtBox_limit2Price = new System.Windows.Forms.TextBox();
			this.lbl_limit2Price = new System.Windows.Forms.Label();
			this.txtBox_limit1Price = new System.Windows.Forms.TextBox();
			this.lbl_limit1Price = new System.Windows.Forms.Label();
			this.txtBox_stop = new System.Windows.Forms.TextBox();
			this.lbl_stop = new System.Windows.Forms.Label();
			this.txtBox_lots = new System.Windows.Forms.TextBox();
			this.lbl_lots = new System.Windows.Forms.Label();
			this.lbl_position = new System.Windows.Forms.Label();
			this.cBox_position = new System.Windows.Forms.ComboBox();
			this.lbl_currency = new System.Windows.Forms.Label();
			this.cBox_currency = new System.Windows.Forms.ComboBox();
			this.txtBox_price = new System.Windows.Forms.TextBox();
			this.lbl_price = new System.Windows.Forms.Label();
			this.panel_buttons = new System.Windows.Forms.Panel();
			this.lbl_notes = new System.Windows.Forms.Label();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.btn_ok = new System.Windows.Forms.Button();
			this.panel_notes = new System.Windows.Forms.Panel();
			this.txtBox_notes = new System.Windows.Forms.TextBox();
			this.groupBox_information.SuspendLayout();
			this.groupBox_risk.SuspendLayout();
			this.groupBox_profits.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.panel_buttons.SuspendLayout();
			this.panel_notes.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox_information
			// 
			this.groupBox_information.BackColor = System.Drawing.Color.PowderBlue;
			this.groupBox_information.Controls.Add(this.groupBox_risk);
			this.groupBox_information.Controls.Add(this.groupBox_profits);
			this.groupBox_information.Controls.Add(this.txtBox_tradeID);
			this.groupBox_information.Controls.Add(this.lbl_tradeID);
			this.groupBox_information.Controls.Add(this.txtBox_currentBalance);
			this.groupBox_information.Controls.Add(this.lbl_currentBalance);
			this.groupBox_information.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox_information.Location = new System.Drawing.Point(0, 0);
			this.groupBox_information.Name = "groupBox_information";
			this.groupBox_information.Size = new System.Drawing.Size(528, 138);
			this.groupBox_information.TabIndex = 0;
			this.groupBox_information.TabStop = false;
			this.groupBox_information.Text = "Trade Information";
			// 
			// groupBox_risk
			// 
			this.groupBox_risk.BackColor = System.Drawing.Color.MistyRose;
			this.groupBox_risk.Controls.Add(this.txtBox_riskInCurrency);
			this.groupBox_risk.Controls.Add(this.lbl_riskInCurrency);
			this.groupBox_risk.Controls.Add(this.txtBox_balanceOnLoss);
			this.groupBox_risk.Controls.Add(this.lbl_balanceOnLoss);
			this.groupBox_risk.Controls.Add(this.txtBox_riskInPercent);
			this.groupBox_risk.Controls.Add(this.lbl_riskInPercent);
			this.groupBox_risk.Location = new System.Drawing.Point(151, 12);
			this.groupBox_risk.Name = "groupBox_risk";
			this.groupBox_risk.Size = new System.Drawing.Size(204, 87);
			this.groupBox_risk.TabIndex = 19;
			this.groupBox_risk.TabStop = false;
			this.groupBox_risk.Text = "Risk";
			// 
			// txtBox_riskInCurrency
			// 
			this.txtBox_riskInCurrency.Enabled = false;
			this.txtBox_riskInCurrency.Location = new System.Drawing.Point(96, 19);
			this.txtBox_riskInCurrency.Name = "txtBox_riskInCurrency";
			this.txtBox_riskInCurrency.ReadOnly = true;
			this.txtBox_riskInCurrency.Size = new System.Drawing.Size(88, 20);
			this.txtBox_riskInCurrency.TabIndex = 17;
			this.txtBox_riskInCurrency.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_riskInCurrency
			// 
			this.lbl_riskInCurrency.AutoSize = true;
			this.lbl_riskInCurrency.Location = new System.Drawing.Point(5, 22);
			this.lbl_riskInCurrency.Name = "lbl_riskInCurrency";
			this.lbl_riskInCurrency.Size = new System.Drawing.Size(87, 13);
			this.lbl_riskInCurrency.TabIndex = 16;
			this.lbl_riskInCurrency.Text = "Risk in Currency:";
			// 
			// txtBox_balanceOnLoss
			// 
			this.txtBox_balanceOnLoss.Enabled = false;
			this.txtBox_balanceOnLoss.Location = new System.Drawing.Point(96, 61);
			this.txtBox_balanceOnLoss.Name = "txtBox_balanceOnLoss";
			this.txtBox_balanceOnLoss.ReadOnly = true;
			this.txtBox_balanceOnLoss.Size = new System.Drawing.Size(88, 20);
			this.txtBox_balanceOnLoss.TabIndex = 7;
			this.txtBox_balanceOnLoss.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_balanceOnLoss
			// 
			this.lbl_balanceOnLoss.AutoSize = true;
			this.lbl_balanceOnLoss.Location = new System.Drawing.Point(5, 64);
			this.lbl_balanceOnLoss.Name = "lbl_balanceOnLoss";
			this.lbl_balanceOnLoss.Size = new System.Drawing.Size(89, 13);
			this.lbl_balanceOnLoss.TabIndex = 6;
			this.lbl_balanceOnLoss.Text = "Balance on Loss:";
			// 
			// txtBox_riskInPercent
			// 
			this.txtBox_riskInPercent.Enabled = false;
			this.txtBox_riskInPercent.Location = new System.Drawing.Point(96, 40);
			this.txtBox_riskInPercent.Name = "txtBox_riskInPercent";
			this.txtBox_riskInPercent.ReadOnly = true;
			this.txtBox_riskInPercent.Size = new System.Drawing.Size(88, 20);
			this.txtBox_riskInPercent.TabIndex = 9;
			this.txtBox_riskInPercent.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_riskInPercent
			// 
			this.lbl_riskInPercent.AutoSize = true;
			this.lbl_riskInPercent.Location = new System.Drawing.Point(6, 43);
			this.lbl_riskInPercent.Name = "lbl_riskInPercent";
			this.lbl_riskInPercent.Size = new System.Drawing.Size(82, 13);
			this.lbl_riskInPercent.TabIndex = 8;
			this.lbl_riskInPercent.Text = "Risk in Percent:";
			// 
			// groupBox_profits
			// 
			this.groupBox_profits.BackColor = System.Drawing.Color.PaleGreen;
			this.groupBox_profits.Controls.Add(this.txtBox_limit1Profit);
			this.groupBox_profits.Controls.Add(this.lbl_limit1);
			this.groupBox_profits.Controls.Add(this.lbl_limit2);
			this.groupBox_profits.Controls.Add(this.txtBox_profitTotal);
			this.groupBox_profits.Controls.Add(this.txtBox_limit2Profit);
			this.groupBox_profits.Controls.Add(this.lbl_profitTotal);
			this.groupBox_profits.Controls.Add(this.lbl_limit3);
			this.groupBox_profits.Controls.Add(this.txtBox_limit3Profit);
			this.groupBox_profits.Location = new System.Drawing.Point(371, 13);
			this.groupBox_profits.Name = "groupBox_profits";
			this.groupBox_profits.Size = new System.Drawing.Size(151, 120);
			this.groupBox_profits.TabIndex = 18;
			this.groupBox_profits.TabStop = false;
			this.groupBox_profits.Text = "Profits";
			// 
			// txtBox_limit1Profit
			// 
			this.txtBox_limit1Profit.Enabled = false;
			this.txtBox_limit1Profit.Location = new System.Drawing.Point(50, 19);
			this.txtBox_limit1Profit.Name = "txtBox_limit1Profit";
			this.txtBox_limit1Profit.ReadOnly = true;
			this.txtBox_limit1Profit.Size = new System.Drawing.Size(88, 20);
			this.txtBox_limit1Profit.TabIndex = 3;
			this.txtBox_limit1Profit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_limit1
			// 
			this.lbl_limit1.AutoSize = true;
			this.lbl_limit1.Location = new System.Drawing.Point(10, 22);
			this.lbl_limit1.Name = "lbl_limit1";
			this.lbl_limit1.Size = new System.Drawing.Size(40, 13);
			this.lbl_limit1.TabIndex = 2;
			this.lbl_limit1.Text = "Limit 1:";
			// 
			// lbl_limit2
			// 
			this.lbl_limit2.AutoSize = true;
			this.lbl_limit2.Location = new System.Drawing.Point(10, 46);
			this.lbl_limit2.Name = "lbl_limit2";
			this.lbl_limit2.Size = new System.Drawing.Size(40, 13);
			this.lbl_limit2.TabIndex = 10;
			this.lbl_limit2.Text = "Limit 2:";
			// 
			// txtBox_profitTotal
			// 
			this.txtBox_profitTotal.Enabled = false;
			this.txtBox_profitTotal.Location = new System.Drawing.Point(50, 91);
			this.txtBox_profitTotal.Name = "txtBox_profitTotal";
			this.txtBox_profitTotal.ReadOnly = true;
			this.txtBox_profitTotal.Size = new System.Drawing.Size(88, 20);
			this.txtBox_profitTotal.TabIndex = 15;
			this.txtBox_profitTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtBox_limit2Profit
			// 
			this.txtBox_limit2Profit.Enabled = false;
			this.txtBox_limit2Profit.Location = new System.Drawing.Point(50, 43);
			this.txtBox_limit2Profit.Name = "txtBox_limit2Profit";
			this.txtBox_limit2Profit.ReadOnly = true;
			this.txtBox_limit2Profit.Size = new System.Drawing.Size(88, 20);
			this.txtBox_limit2Profit.TabIndex = 11;
			this.txtBox_limit2Profit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_profitTotal
			// 
			this.lbl_profitTotal.AutoSize = true;
			this.lbl_profitTotal.Location = new System.Drawing.Point(10, 94);
			this.lbl_profitTotal.Name = "lbl_profitTotal";
			this.lbl_profitTotal.Size = new System.Drawing.Size(34, 13);
			this.lbl_profitTotal.TabIndex = 14;
			this.lbl_profitTotal.Text = "Total:";
			// 
			// lbl_limit3
			// 
			this.lbl_limit3.AutoSize = true;
			this.lbl_limit3.Location = new System.Drawing.Point(10, 70);
			this.lbl_limit3.Name = "lbl_limit3";
			this.lbl_limit3.Size = new System.Drawing.Size(40, 13);
			this.lbl_limit3.TabIndex = 12;
			this.lbl_limit3.Text = "Limit 3:";
			// 
			// txtBox_limit3Profit
			// 
			this.txtBox_limit3Profit.Enabled = false;
			this.txtBox_limit3Profit.Location = new System.Drawing.Point(50, 67);
			this.txtBox_limit3Profit.Name = "txtBox_limit3Profit";
			this.txtBox_limit3Profit.ReadOnly = true;
			this.txtBox_limit3Profit.Size = new System.Drawing.Size(88, 20);
			this.txtBox_limit3Profit.TabIndex = 13;
			this.txtBox_limit3Profit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtBox_tradeID
			// 
			this.txtBox_tradeID.Enabled = false;
			this.txtBox_tradeID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBox_tradeID.Location = new System.Drawing.Point(64, 27);
			this.txtBox_tradeID.Name = "txtBox_tradeID";
			this.txtBox_tradeID.ReadOnly = true;
			this.txtBox_tradeID.Size = new System.Drawing.Size(81, 20);
			this.txtBox_tradeID.TabIndex = 5;
			this.txtBox_tradeID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_tradeID
			// 
			this.lbl_tradeID.AutoSize = true;
			this.lbl_tradeID.Location = new System.Drawing.Point(6, 30);
			this.lbl_tradeID.Name = "lbl_tradeID";
			this.lbl_tradeID.Size = new System.Drawing.Size(52, 13);
			this.lbl_tradeID.TabIndex = 4;
			this.lbl_tradeID.Text = "Trade ID:";
			// 
			// txtBox_currentBalance
			// 
			this.txtBox_currentBalance.Enabled = false;
			this.txtBox_currentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.txtBox_currentBalance.Location = new System.Drawing.Point(27, 73);
			this.txtBox_currentBalance.Name = "txtBox_currentBalance";
			this.txtBox_currentBalance.ReadOnly = true;
			this.txtBox_currentBalance.Size = new System.Drawing.Size(102, 20);
			this.txtBox_currentBalance.TabIndex = 1;
			this.txtBox_currentBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_currentBalance
			// 
			this.lbl_currentBalance.AutoSize = true;
			this.lbl_currentBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_currentBalance.Location = new System.Drawing.Point(27, 59);
			this.lbl_currentBalance.Name = "lbl_currentBalance";
			this.lbl_currentBalance.Size = new System.Drawing.Size(102, 13);
			this.lbl_currentBalance.TabIndex = 0;
			this.lbl_currentBalance.Text = "Current Balance:";
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = System.Drawing.Color.PaleGoldenrod;
			this.groupBox1.Controls.Add(this.checkBox_trailingStop);
			this.groupBox1.Controls.Add(this.txtBox_limit3Lots);
			this.groupBox1.Controls.Add(this.lbl_limit3Lots);
			this.groupBox1.Controls.Add(this.txtBox_limit2Lots);
			this.groupBox1.Controls.Add(this.lbl_limit2Lots);
			this.groupBox1.Controls.Add(this.txtBox_limit1Lots);
			this.groupBox1.Controls.Add(this.lbl_limit1Lots);
			this.groupBox1.Controls.Add(this.txtBox_limit3Price);
			this.groupBox1.Controls.Add(this.lbl_limit3Price);
			this.groupBox1.Controls.Add(this.txtBox_limit2Price);
			this.groupBox1.Controls.Add(this.lbl_limit2Price);
			this.groupBox1.Controls.Add(this.txtBox_limit1Price);
			this.groupBox1.Controls.Add(this.lbl_limit1Price);
			this.groupBox1.Controls.Add(this.txtBox_stop);
			this.groupBox1.Controls.Add(this.lbl_stop);
			this.groupBox1.Controls.Add(this.txtBox_lots);
			this.groupBox1.Controls.Add(this.lbl_lots);
			this.groupBox1.Controls.Add(this.lbl_position);
			this.groupBox1.Controls.Add(this.cBox_position);
			this.groupBox1.Controls.Add(this.lbl_currency);
			this.groupBox1.Controls.Add(this.cBox_currency);
			this.groupBox1.Controls.Add(this.txtBox_price);
			this.groupBox1.Controls.Add(this.lbl_price);
			this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupBox1.Location = new System.Drawing.Point(0, 138);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(528, 129);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Trade";
			// 
			// checkBox_trailingStop
			// 
			this.checkBox_trailingStop.AutoSize = true;
			this.checkBox_trailingStop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_trailingStop.Location = new System.Drawing.Point(162, 74);
			this.checkBox_trailingStop.Name = "checkBox_trailingStop";
			this.checkBox_trailingStop.Size = new System.Drawing.Size(88, 17);
			this.checkBox_trailingStop.TabIndex = 5;
			this.checkBox_trailingStop.Text = "Trailing Stop:";
			this.checkBox_trailingStop.UseVisualStyleBackColor = true;
			// 
			// txtBox_limit3Lots
			// 
			this.txtBox_limit3Lots.Location = new System.Drawing.Point(452, 95);
			this.txtBox_limit3Lots.Name = "txtBox_limit3Lots";
			this.txtBox_limit3Lots.Size = new System.Drawing.Size(57, 20);
			this.txtBox_limit3Lots.TabIndex = 11;
			this.txtBox_limit3Lots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_limit3Lots
			// 
			this.lbl_limit3Lots.AutoSize = true;
			this.lbl_limit3Lots.Location = new System.Drawing.Point(412, 98);
			this.lbl_limit3Lots.Name = "lbl_limit3Lots";
			this.lbl_limit3Lots.Size = new System.Drawing.Size(30, 13);
			this.lbl_limit3Lots.TabIndex = 39;
			this.lbl_limit3Lots.Text = "Lots:";
			// 
			// txtBox_limit2Lots
			// 
			this.txtBox_limit2Lots.Location = new System.Drawing.Point(452, 69);
			this.txtBox_limit2Lots.Name = "txtBox_limit2Lots";
			this.txtBox_limit2Lots.Size = new System.Drawing.Size(57, 20);
			this.txtBox_limit2Lots.TabIndex = 9;
			this.txtBox_limit2Lots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_limit2Lots
			// 
			this.lbl_limit2Lots.AutoSize = true;
			this.lbl_limit2Lots.Location = new System.Drawing.Point(412, 72);
			this.lbl_limit2Lots.Name = "lbl_limit2Lots";
			this.lbl_limit2Lots.Size = new System.Drawing.Size(30, 13);
			this.lbl_limit2Lots.TabIndex = 37;
			this.lbl_limit2Lots.Text = "Lots:";
			// 
			// txtBox_limit1Lots
			// 
			this.txtBox_limit1Lots.Location = new System.Drawing.Point(452, 43);
			this.txtBox_limit1Lots.Name = "txtBox_limit1Lots";
			this.txtBox_limit1Lots.Size = new System.Drawing.Size(57, 20);
			this.txtBox_limit1Lots.TabIndex = 7;
			this.txtBox_limit1Lots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_limit1Lots
			// 
			this.lbl_limit1Lots.AutoSize = true;
			this.lbl_limit1Lots.Location = new System.Drawing.Point(412, 46);
			this.lbl_limit1Lots.Name = "lbl_limit1Lots";
			this.lbl_limit1Lots.Size = new System.Drawing.Size(30, 13);
			this.lbl_limit1Lots.TabIndex = 35;
			this.lbl_limit1Lots.Text = "Lots:";
			// 
			// txtBox_limit3Price
			// 
			this.txtBox_limit3Price.Location = new System.Drawing.Point(345, 95);
			this.txtBox_limit3Price.Name = "txtBox_limit3Price";
			this.txtBox_limit3Price.Size = new System.Drawing.Size(57, 20);
			this.txtBox_limit3Price.TabIndex = 10;
			this.txtBox_limit3Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_limit3Price
			// 
			this.lbl_limit3Price.AutoSize = true;
			this.lbl_limit3Price.Location = new System.Drawing.Point(305, 98);
			this.lbl_limit3Price.Name = "lbl_limit3Price";
			this.lbl_limit3Price.Size = new System.Drawing.Size(40, 13);
			this.lbl_limit3Price.TabIndex = 33;
			this.lbl_limit3Price.Text = "Limit 3:";
			// 
			// txtBox_limit2Price
			// 
			this.txtBox_limit2Price.Location = new System.Drawing.Point(345, 69);
			this.txtBox_limit2Price.Name = "txtBox_limit2Price";
			this.txtBox_limit2Price.Size = new System.Drawing.Size(57, 20);
			this.txtBox_limit2Price.TabIndex = 8;
			this.txtBox_limit2Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_limit2Price
			// 
			this.lbl_limit2Price.AutoSize = true;
			this.lbl_limit2Price.Location = new System.Drawing.Point(305, 72);
			this.lbl_limit2Price.Name = "lbl_limit2Price";
			this.lbl_limit2Price.Size = new System.Drawing.Size(40, 13);
			this.lbl_limit2Price.TabIndex = 31;
			this.lbl_limit2Price.Text = "Limit 2:";
			// 
			// txtBox_limit1Price
			// 
			this.txtBox_limit1Price.Location = new System.Drawing.Point(345, 43);
			this.txtBox_limit1Price.Name = "txtBox_limit1Price";
			this.txtBox_limit1Price.Size = new System.Drawing.Size(57, 20);
			this.txtBox_limit1Price.TabIndex = 6;
			this.txtBox_limit1Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_limit1Price
			// 
			this.lbl_limit1Price.AutoSize = true;
			this.lbl_limit1Price.Location = new System.Drawing.Point(305, 46);
			this.lbl_limit1Price.Name = "lbl_limit1Price";
			this.lbl_limit1Price.Size = new System.Drawing.Size(40, 13);
			this.lbl_limit1Price.TabIndex = 29;
			this.lbl_limit1Price.Text = "Limit 1:";
			// 
			// txtBox_stop
			// 
			this.txtBox_stop.Location = new System.Drawing.Point(199, 46);
			this.txtBox_stop.Name = "txtBox_stop";
			this.txtBox_stop.Size = new System.Drawing.Size(57, 20);
			this.txtBox_stop.TabIndex = 4;
			this.txtBox_stop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtBox_stop.TextChanged += new System.EventHandler(this.txtBox_stop_TextChanged);
			// 
			// lbl_stop
			// 
			this.lbl_stop.AutoSize = true;
			this.lbl_stop.Location = new System.Drawing.Point(159, 49);
			this.lbl_stop.Name = "lbl_stop";
			this.lbl_stop.Size = new System.Drawing.Size(32, 13);
			this.lbl_stop.TabIndex = 27;
			this.lbl_stop.Text = "Stop:";
			// 
			// txtBox_lots
			// 
			this.txtBox_lots.Location = new System.Drawing.Point(64, 73);
			this.txtBox_lots.Name = "txtBox_lots";
			this.txtBox_lots.Size = new System.Drawing.Size(57, 20);
			this.txtBox_lots.TabIndex = 3;
			this.txtBox_lots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_lots
			// 
			this.lbl_lots.AutoSize = true;
			this.lbl_lots.Location = new System.Drawing.Point(24, 76);
			this.lbl_lots.Name = "lbl_lots";
			this.lbl_lots.Size = new System.Drawing.Size(30, 13);
			this.lbl_lots.TabIndex = 25;
			this.lbl_lots.Text = "Lots:";
			// 
			// lbl_position
			// 
			this.lbl_position.AutoSize = true;
			this.lbl_position.Location = new System.Drawing.Point(196, 23);
			this.lbl_position.Name = "lbl_position";
			this.lbl_position.Size = new System.Drawing.Size(47, 13);
			this.lbl_position.TabIndex = 23;
			this.lbl_position.Text = "Position:";
			// 
			// cBox_position
			// 
			this.cBox_position.Items.AddRange(new object[] {
            "Long",
            "Short"});
			this.cBox_position.Location = new System.Drawing.Point(248, 20);
			this.cBox_position.MaxDropDownItems = 2;
			this.cBox_position.Name = "cBox_position";
			this.cBox_position.Size = new System.Drawing.Size(80, 21);
			this.cBox_position.TabIndex = 1;
			// 
			// lbl_currency
			// 
			this.lbl_currency.AutoSize = true;
			this.lbl_currency.Location = new System.Drawing.Point(12, 23);
			this.lbl_currency.Name = "lbl_currency";
			this.lbl_currency.Size = new System.Drawing.Size(52, 13);
			this.lbl_currency.TabIndex = 21;
			this.lbl_currency.Text = "Currency:";
			// 
			// cBox_currency
			// 
			this.cBox_currency.FormattingEnabled = true;
			this.cBox_currency.Location = new System.Drawing.Point(64, 20);
			this.cBox_currency.Name = "cBox_currency";
			this.cBox_currency.Size = new System.Drawing.Size(121, 21);
			this.cBox_currency.TabIndex = 0;
			// 
			// txtBox_price
			// 
			this.txtBox_price.Location = new System.Drawing.Point(64, 47);
			this.txtBox_price.Name = "txtBox_price";
			this.txtBox_price.Size = new System.Drawing.Size(57, 20);
			this.txtBox_price.TabIndex = 2;
			this.txtBox_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_price
			// 
			this.lbl_price.AutoSize = true;
			this.lbl_price.Location = new System.Drawing.Point(24, 50);
			this.lbl_price.Name = "lbl_price";
			this.lbl_price.Size = new System.Drawing.Size(34, 13);
			this.lbl_price.TabIndex = 18;
			this.lbl_price.Text = "Price:";
			// 
			// panel_buttons
			// 
			this.panel_buttons.BackColor = System.Drawing.Color.LightGray;
			this.panel_buttons.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel_buttons.Controls.Add(this.lbl_notes);
			this.panel_buttons.Controls.Add(this.btn_cancel);
			this.panel_buttons.Controls.Add(this.btn_ok);
			this.panel_buttons.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel_buttons.Location = new System.Drawing.Point(0, 267);
			this.panel_buttons.Name = "panel_buttons";
			this.panel_buttons.Size = new System.Drawing.Size(528, 39);
			this.panel_buttons.TabIndex = 3;
			// 
			// lbl_notes
			// 
			this.lbl_notes.AutoSize = true;
			this.lbl_notes.Location = new System.Drawing.Point(3, 22);
			this.lbl_notes.Name = "lbl_notes";
			this.lbl_notes.Size = new System.Drawing.Size(38, 13);
			this.lbl_notes.TabIndex = 2;
			this.lbl_notes.Text = "Notes:";
			// 
			// btn_cancel
			// 
			this.btn_cancel.AutoSize = true;
			this.btn_cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(249, 6);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(50, 23);
			this.btn_cancel.TabIndex = 1;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			// 
			// btn_ok
			// 
			this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btn_ok.Location = new System.Drawing.Point(193, 6);
			this.btn_ok.Name = "btn_ok";
			this.btn_ok.Size = new System.Drawing.Size(50, 23);
			this.btn_ok.TabIndex = 0;
			this.btn_ok.Text = "OK";
			this.btn_ok.UseVisualStyleBackColor = true;
			this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
			// 
			// panel_notes
			// 
			this.panel_notes.Controls.Add(this.txtBox_notes);
			this.panel_notes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_notes.Location = new System.Drawing.Point(0, 306);
			this.panel_notes.Name = "panel_notes";
			this.panel_notes.Size = new System.Drawing.Size(528, 109);
			this.panel_notes.TabIndex = 2;
			// 
			// txtBox_notes
			// 
			this.txtBox_notes.AcceptsReturn = true;
			this.txtBox_notes.AllowDrop = true;
			this.txtBox_notes.BackColor = System.Drawing.Color.Black;
			this.txtBox_notes.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtBox_notes.ForeColor = System.Drawing.Color.Lime;
			this.txtBox_notes.Location = new System.Drawing.Point(0, 0);
			this.txtBox_notes.Multiline = true;
			this.txtBox_notes.Name = "txtBox_notes";
			this.txtBox_notes.Size = new System.Drawing.Size(528, 109);
			this.txtBox_notes.TabIndex = 12;
			// 
			// frm_EnterTrade
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(528, 415);
			this.Controls.Add(this.panel_notes);
			this.Controls.Add(this.panel_buttons);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox_information);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_EnterTrade";
			this.ShowIcon = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Enter Trade Form";
			this.TopMost = true;
			this.groupBox_information.ResumeLayout(false);
			this.groupBox_information.PerformLayout();
			this.groupBox_risk.ResumeLayout(false);
			this.groupBox_risk.PerformLayout();
			this.groupBox_profits.ResumeLayout(false);
			this.groupBox_profits.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.panel_buttons.ResumeLayout(false);
			this.panel_buttons.PerformLayout();
			this.panel_notes.ResumeLayout(false);
			this.panel_notes.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.GroupBox groupBox_information;
		private System.Windows.Forms.TextBox txtBox_tradeID;
		private System.Windows.Forms.Label lbl_tradeID;
		private System.Windows.Forms.TextBox txtBox_limit1Profit;
		private System.Windows.Forms.Label lbl_limit1;
		private System.Windows.Forms.TextBox txtBox_profitTotal;
		private System.Windows.Forms.Label lbl_profitTotal;
		private System.Windows.Forms.TextBox txtBox_limit3Profit;
		private System.Windows.Forms.Label lbl_limit3;
		private System.Windows.Forms.TextBox txtBox_limit2Profit;
		private System.Windows.Forms.Label lbl_limit2;
		private System.Windows.Forms.TextBox txtBox_riskInPercent;
		private System.Windows.Forms.Label lbl_riskInPercent;
		private System.Windows.Forms.TextBox txtBox_balanceOnLoss;
		private System.Windows.Forms.Label lbl_balanceOnLoss;
		private System.Windows.Forms.GroupBox groupBox_profits;
		private System.Windows.Forms.TextBox txtBox_riskInCurrency;
		private System.Windows.Forms.Label lbl_riskInCurrency;
		private System.Windows.Forms.TextBox txtBox_currentBalance;
		private System.Windows.Forms.Label lbl_currentBalance;
		private System.Windows.Forms.GroupBox groupBox_risk;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lbl_currency;
		private System.Windows.Forms.ComboBox cBox_currency;
		private System.Windows.Forms.TextBox txtBox_price;
		private System.Windows.Forms.Label lbl_price;
		private System.Windows.Forms.TextBox txtBox_lots;
		private System.Windows.Forms.Label lbl_lots;
		private System.Windows.Forms.Label lbl_position;
		private System.Windows.Forms.ComboBox cBox_position;
		private System.Windows.Forms.CheckBox checkBox_trailingStop;
		private System.Windows.Forms.TextBox txtBox_limit3Lots;
		private System.Windows.Forms.Label lbl_limit3Lots;
		private System.Windows.Forms.TextBox txtBox_limit2Lots;
		private System.Windows.Forms.Label lbl_limit2Lots;
		private System.Windows.Forms.TextBox txtBox_limit1Lots;
		private System.Windows.Forms.Label lbl_limit1Lots;
		private System.Windows.Forms.TextBox txtBox_limit3Price;
		private System.Windows.Forms.Label lbl_limit3Price;
		private System.Windows.Forms.TextBox txtBox_limit2Price;
		private System.Windows.Forms.Label lbl_limit2Price;
		private System.Windows.Forms.TextBox txtBox_limit1Price;
		private System.Windows.Forms.Label lbl_limit1Price;
		private System.Windows.Forms.TextBox txtBox_stop;
		private System.Windows.Forms.Label lbl_stop;
		private System.Windows.Forms.Panel panel_buttons;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Button btn_ok;
		private System.Windows.Forms.Label lbl_notes;
		private System.Windows.Forms.Panel panel_notes;
		private System.Windows.Forms.TextBox txtBox_notes;
	}
}