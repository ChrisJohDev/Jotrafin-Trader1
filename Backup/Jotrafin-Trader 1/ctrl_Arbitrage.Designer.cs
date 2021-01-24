namespace D4M.FINANCE.JOTRAFIN
{
	partial class ctrl_Arbitrage
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.cb_in_A = new System.Windows.Forms.ComboBox();
			this.lbl_cb_selectedArbitrage = new System.Windows.Forms.Label();
			this.gb_Arbitrage = new System.Windows.Forms.GroupBox();
			this.btn_trade_pair3 = new System.Windows.Forms.Button();
			this.tb_pair3 = new System.Windows.Forms.TextBox();
			this.lbl_pair3 = new System.Windows.Forms.Label();
			this.btn_trade_pair2 = new System.Windows.Forms.Button();
			this.tb_pair2 = new System.Windows.Forms.TextBox();
			this.lbl_pair2 = new System.Windows.Forms.Label();
			this.btn_trade_pair1 = new System.Windows.Forms.Button();
			this.tb_pair1 = new System.Windows.Forms.TextBox();
			this.lbl_pair1 = new System.Windows.Forms.Label();
			this.lbl_cb_in_A = new System.Windows.Forms.Label();
			this.lbl_cb_in_B = new System.Windows.Forms.Label();
			this.cb_in_B = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.cb_in_C = new System.Windows.Forms.ComboBox();
			this.tb_out_price_a = new System.Windows.Forms.TextBox();
			this.tb_out_price_b = new System.Windows.Forms.TextBox();
			this.tb_out_price_c = new System.Windows.Forms.TextBox();
			this.gb_Arbitrage.SuspendLayout();
			this.SuspendLayout();
			// 
			// cb_in_A
			// 
			this.cb_in_A.FormattingEnabled = true;
			this.cb_in_A.Location = new System.Drawing.Point(13, 40);
			this.cb_in_A.Name = "cb_in_A";
			this.cb_in_A.Size = new System.Drawing.Size(75, 21);
			this.cb_in_A.TabIndex = 0;
			this.cb_in_A.Text = "-Pair A-";
			this.cb_in_A.SelectedIndexChanged += new System.EventHandler(this.cb_in_A_SelectedIndexChanged);
			// 
			// lbl_cb_selectedArbitrage
			// 
			this.lbl_cb_selectedArbitrage.AutoSize = true;
			this.lbl_cb_selectedArbitrage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lbl_cb_selectedArbitrage.Location = new System.Drawing.Point(89, 4);
			this.lbl_cb_selectedArbitrage.Name = "lbl_cb_selectedArbitrage";
			this.lbl_cb_selectedArbitrage.Size = new System.Drawing.Size(75, 13);
			this.lbl_cb_selectedArbitrage.TabIndex = 1;
			this.lbl_cb_selectedArbitrage.Text = "Currency Pairs";
			// 
			// gb_Arbitrage
			// 
			this.gb_Arbitrage.Controls.Add(this.btn_trade_pair3);
			this.gb_Arbitrage.Controls.Add(this.tb_pair3);
			this.gb_Arbitrage.Controls.Add(this.lbl_pair3);
			this.gb_Arbitrage.Controls.Add(this.btn_trade_pair2);
			this.gb_Arbitrage.Controls.Add(this.tb_pair2);
			this.gb_Arbitrage.Controls.Add(this.lbl_pair2);
			this.gb_Arbitrage.Controls.Add(this.btn_trade_pair1);
			this.gb_Arbitrage.Controls.Add(this.tb_pair1);
			this.gb_Arbitrage.Controls.Add(this.lbl_pair1);
			this.gb_Arbitrage.Location = new System.Drawing.Point(4, 100);
			this.gb_Arbitrage.Name = "gb_Arbitrage";
			this.gb_Arbitrage.Size = new System.Drawing.Size(232, 88);
			this.gb_Arbitrage.TabIndex = 2;
			this.gb_Arbitrage.TabStop = false;
			this.gb_Arbitrage.Text = "Arbitrage Opportunities";
			// 
			// btn_trade_pair3
			// 
			this.btn_trade_pair3.AutoSize = true;
			this.btn_trade_pair3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_trade_pair3.Location = new System.Drawing.Point(180, 63);
			this.btn_trade_pair3.Name = "btn_trade_pair3";
			this.btn_trade_pair3.Size = new System.Drawing.Size(45, 23);
			this.btn_trade_pair3.TabIndex = 8;
			this.btn_trade_pair3.Text = "Trade";
			this.btn_trade_pair3.UseVisualStyleBackColor = true;
			// 
			// tb_pair3
			// 
			this.tb_pair3.Location = new System.Drawing.Point(84, 64);
			this.tb_pair3.Name = "tb_pair3";
			this.tb_pair3.ReadOnly = true;
			this.tb_pair3.Size = new System.Drawing.Size(64, 20);
			this.tb_pair3.TabIndex = 7;
			this.tb_pair3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_pair3
			// 
			this.lbl_pair3.AutoSize = true;
			this.lbl_pair3.Location = new System.Drawing.Point(8, 68);
			this.lbl_pair3.Name = "lbl_pair3";
			this.lbl_pair3.Size = new System.Drawing.Size(35, 13);
			this.lbl_pair3.TabIndex = 6;
			this.lbl_pair3.Text = "label1";
			// 
			// btn_trade_pair2
			// 
			this.btn_trade_pair2.AutoSize = true;
			this.btn_trade_pair2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_trade_pair2.Location = new System.Drawing.Point(180, 39);
			this.btn_trade_pair2.Name = "btn_trade_pair2";
			this.btn_trade_pair2.Size = new System.Drawing.Size(45, 23);
			this.btn_trade_pair2.TabIndex = 5;
			this.btn_trade_pair2.Text = "Trade";
			this.btn_trade_pair2.UseVisualStyleBackColor = true;
			// 
			// tb_pair2
			// 
			this.tb_pair2.Location = new System.Drawing.Point(84, 40);
			this.tb_pair2.Name = "tb_pair2";
			this.tb_pair2.ReadOnly = true;
			this.tb_pair2.Size = new System.Drawing.Size(64, 20);
			this.tb_pair2.TabIndex = 4;
			this.tb_pair2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_pair2
			// 
			this.lbl_pair2.AutoSize = true;
			this.lbl_pair2.Location = new System.Drawing.Point(8, 44);
			this.lbl_pair2.Name = "lbl_pair2";
			this.lbl_pair2.Size = new System.Drawing.Size(35, 13);
			this.lbl_pair2.TabIndex = 3;
			this.lbl_pair2.Text = "label1";
			// 
			// btn_trade_pair1
			// 
			this.btn_trade_pair1.AutoSize = true;
			this.btn_trade_pair1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_trade_pair1.Location = new System.Drawing.Point(180, 15);
			this.btn_trade_pair1.Name = "btn_trade_pair1";
			this.btn_trade_pair1.Size = new System.Drawing.Size(45, 23);
			this.btn_trade_pair1.TabIndex = 2;
			this.btn_trade_pair1.Text = "Trade";
			this.btn_trade_pair1.UseVisualStyleBackColor = true;
			// 
			// tb_pair1
			// 
			this.tb_pair1.Location = new System.Drawing.Point(84, 16);
			this.tb_pair1.Name = "tb_pair1";
			this.tb_pair1.ReadOnly = true;
			this.tb_pair1.Size = new System.Drawing.Size(64, 20);
			this.tb_pair1.TabIndex = 1;
			this.tb_pair1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_pair1
			// 
			this.lbl_pair1.AutoSize = true;
			this.lbl_pair1.Location = new System.Drawing.Point(8, 20);
			this.lbl_pair1.Name = "lbl_pair1";
			this.lbl_pair1.Size = new System.Drawing.Size(35, 13);
			this.lbl_pair1.TabIndex = 0;
			this.lbl_pair1.Text = "label1";
			// 
			// lbl_cb_in_A
			// 
			this.lbl_cb_in_A.AutoSize = true;
			this.lbl_cb_in_A.Location = new System.Drawing.Point(13, 24);
			this.lbl_cb_in_A.Name = "lbl_cb_in_A";
			this.lbl_cb_in_A.Size = new System.Drawing.Size(38, 13);
			this.lbl_cb_in_A.TabIndex = 3;
			this.lbl_cb_in_A.Text = "Pair A:";
			// 
			// lbl_cb_in_B
			// 
			this.lbl_cb_in_B.AutoSize = true;
			this.lbl_cb_in_B.Location = new System.Drawing.Point(92, 24);
			this.lbl_cb_in_B.Name = "lbl_cb_in_B";
			this.lbl_cb_in_B.Size = new System.Drawing.Size(38, 13);
			this.lbl_cb_in_B.TabIndex = 5;
			this.lbl_cb_in_B.Text = "Pair B:";
			// 
			// cb_in_B
			// 
			this.cb_in_B.FormattingEnabled = true;
			this.cb_in_B.Location = new System.Drawing.Point(92, 40);
			this.cb_in_B.Name = "cb_in_B";
			this.cb_in_B.Size = new System.Drawing.Size(75, 21);
			this.cb_in_B.TabIndex = 4;
			this.cb_in_B.Text = "-Pair B-";
			this.cb_in_B.SelectedIndexChanged += new System.EventHandler(this.cb_in_B_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(172, 24);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(38, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Pair C:";
			// 
			// cb_in_C
			// 
			this.cb_in_C.FormattingEnabled = true;
			this.cb_in_C.Location = new System.Drawing.Point(172, 40);
			this.cb_in_C.Name = "cb_in_C";
			this.cb_in_C.Size = new System.Drawing.Size(75, 21);
			this.cb_in_C.TabIndex = 6;
			this.cb_in_C.Text = "-Pair C-";
			this.cb_in_C.SelectedIndexChanged += new System.EventHandler(this.cb_in_C_SelectedIndexChanged);
			// 
			// tb_out_price_a
			// 
			this.tb_out_price_a.Location = new System.Drawing.Point(12, 64);
			this.tb_out_price_a.Name = "tb_out_price_a";
			this.tb_out_price_a.ReadOnly = true;
			this.tb_out_price_a.Size = new System.Drawing.Size(75, 20);
			this.tb_out_price_a.TabIndex = 8;
			// 
			// tb_out_price_b
			// 
			this.tb_out_price_b.Location = new System.Drawing.Point(92, 64);
			this.tb_out_price_b.Name = "tb_out_price_b";
			this.tb_out_price_b.ReadOnly = true;
			this.tb_out_price_b.Size = new System.Drawing.Size(75, 20);
			this.tb_out_price_b.TabIndex = 9;
			// 
			// tb_out_price_c
			// 
			this.tb_out_price_c.Location = new System.Drawing.Point(172, 64);
			this.tb_out_price_c.Name = "tb_out_price_c";
			this.tb_out_price_c.ReadOnly = true;
			this.tb_out_price_c.Size = new System.Drawing.Size(75, 20);
			this.tb_out_price_c.TabIndex = 10;
			// 
			// ctrl_Arbitrage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Controls.Add(this.tb_out_price_c);
			this.Controls.Add(this.tb_out_price_b);
			this.Controls.Add(this.tb_out_price_a);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.cb_in_C);
			this.Controls.Add(this.lbl_cb_in_B);
			this.Controls.Add(this.cb_in_B);
			this.Controls.Add(this.lbl_cb_in_A);
			this.Controls.Add(this.gb_Arbitrage);
			this.Controls.Add(this.lbl_cb_selectedArbitrage);
			this.Controls.Add(this.cb_in_A);
			this.Name = "ctrl_Arbitrage";
			this.Size = new System.Drawing.Size(252, 203);
			this.gb_Arbitrage.ResumeLayout(false);
			this.gb_Arbitrage.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cb_in_A;
		private System.Windows.Forms.Label lbl_cb_selectedArbitrage;
		private System.Windows.Forms.GroupBox gb_Arbitrage;
		private System.Windows.Forms.TextBox tb_pair1;
		private System.Windows.Forms.Label lbl_pair1;
		private System.Windows.Forms.Button btn_trade_pair3;
		private System.Windows.Forms.TextBox tb_pair3;
		private System.Windows.Forms.Label lbl_pair3;
		private System.Windows.Forms.Button btn_trade_pair2;
		private System.Windows.Forms.TextBox tb_pair2;
		private System.Windows.Forms.Label lbl_pair2;
		private System.Windows.Forms.Button btn_trade_pair1;
		private System.Windows.Forms.Label lbl_cb_in_A;
		private System.Windows.Forms.Label lbl_cb_in_B;
		private System.Windows.Forms.ComboBox cb_in_B;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cb_in_C;
		private System.Windows.Forms.TextBox tb_out_price_a;
		private System.Windows.Forms.TextBox tb_out_price_b;
		private System.Windows.Forms.TextBox tb_out_price_c;
	}
}
