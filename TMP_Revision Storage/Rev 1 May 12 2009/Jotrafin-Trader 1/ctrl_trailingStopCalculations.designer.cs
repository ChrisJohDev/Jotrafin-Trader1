namespace D4M.FINANCE.JOTRAFIN
{
	partial class ctrl_trailingStopCalculations
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
			this.components = new System.ComponentModel.Container();
			this.lbl_in_price = new System.Windows.Forms.Label();
			this.tb_in_price = new System.Windows.Forms.TextBox();
			this.tb_in_pipsChange = new System.Windows.Forms.TextBox();
			this.lbl_in_pipsChange = new System.Windows.Forms.Label();
			this.tb_out_stop = new System.Windows.Forms.TextBox();
			this.lbl_out_stop = new System.Windows.Forms.Label();
			this.tb_out_currTarget = new System.Windows.Forms.TextBox();
			this.lbl_out_currTarget = new System.Windows.Forms.Label();
			this.tb_out_next = new System.Windows.Forms.TextBox();
			this.lbl_out_next = new System.Windows.Forms.Label();
			this.btn_calc = new System.Windows.Forms.Button();
			this.panel_direction = new System.Windows.Forms.Panel();
			this.rbtn_in_down = new System.Windows.Forms.RadioButton();
			this.rbtn_in_up = new System.Windows.Forms.RadioButton();
			this.panel_pips = new System.Windows.Forms.Panel();
			this.rbtn_in_4pips = new System.Windows.Forms.RadioButton();
			this.rbtn_in_2pips = new System.Windows.Forms.RadioButton();
			this.btn_clear = new System.Windows.Forms.Button();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.trailingStopCalculationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.cntxtMenuClose = new System.Windows.Forms.ToolStripMenuItem();
			this.btn_next = new System.Windows.Forms.Button();
			this.btn_prev = new System.Windows.Forms.Button();
			this.panel_direction.SuspendLayout();
			this.panel_pips.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_in_price
			// 
			this.lbl_in_price.AutoSize = true;
			this.lbl_in_price.Location = new System.Drawing.Point(4, 4);
			this.lbl_in_price.Name = "lbl_in_price";
			this.lbl_in_price.Size = new System.Drawing.Size(34, 13);
			this.lbl_in_price.TabIndex = 1;
			this.lbl_in_price.Text = "Price:";
			// 
			// tb_in_price
			// 
			this.tb_in_price.Location = new System.Drawing.Point(7, 21);
			this.tb_in_price.Name = "tb_in_price";
			this.tb_in_price.Size = new System.Drawing.Size(48, 20);
			this.tb_in_price.TabIndex = 0;
			this.tb_in_price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_in_pipsChange
			// 
			this.tb_in_pipsChange.Location = new System.Drawing.Point(61, 21);
			this.tb_in_pipsChange.Name = "tb_in_pipsChange";
			this.tb_in_pipsChange.Size = new System.Drawing.Size(48, 20);
			this.tb_in_pipsChange.TabIndex = 2;
			this.tb_in_pipsChange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_in_pipsChange
			// 
			this.lbl_in_pipsChange.AutoSize = true;
			this.lbl_in_pipsChange.Location = new System.Drawing.Point(58, 4);
			this.lbl_in_pipsChange.Name = "lbl_in_pipsChange";
			this.lbl_in_pipsChange.Size = new System.Drawing.Size(32, 13);
			this.lbl_in_pipsChange.TabIndex = 3;
			this.lbl_in_pipsChange.Text = "PIPs:";
			// 
			// tb_out_stop
			// 
			this.tb_out_stop.BackColor = System.Drawing.Color.Red;
			this.tb_out_stop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_out_stop.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tb_out_stop.ForeColor = System.Drawing.Color.White;
			this.tb_out_stop.Location = new System.Drawing.Point(4, 104);
			this.tb_out_stop.Name = "tb_out_stop";
			this.tb_out_stop.ReadOnly = true;
			this.tb_out_stop.Size = new System.Drawing.Size(58, 20);
			this.tb_out_stop.TabIndex = 4;
			this.tb_out_stop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// lbl_out_stop
			// 
			this.lbl_out_stop.AutoSize = true;
			this.lbl_out_stop.Location = new System.Drawing.Point(17, 87);
			this.lbl_out_stop.Name = "lbl_out_stop";
			this.lbl_out_stop.Size = new System.Drawing.Size(32, 13);
			this.lbl_out_stop.TabIndex = 5;
			this.lbl_out_stop.Text = "Stop:";
			// 
			// tb_out_currTarget
			// 
			this.tb_out_currTarget.BackColor = System.Drawing.Color.LightCyan;
			this.tb_out_currTarget.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_out_currTarget.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.tb_out_currTarget.ForeColor = System.Drawing.Color.Navy;
			this.tb_out_currTarget.Location = new System.Drawing.Point(66, 104);
			this.tb_out_currTarget.Name = "tb_out_currTarget";
			this.tb_out_currTarget.ReadOnly = true;
			this.tb_out_currTarget.Size = new System.Drawing.Size(58, 20);
			this.tb_out_currTarget.TabIndex = 6;
			this.tb_out_currTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tb_out_currTarget.WordWrap = false;
			// 
			// lbl_out_currTarget
			// 
			this.lbl_out_currTarget.AutoSize = true;
			this.lbl_out_currTarget.Location = new System.Drawing.Point(61, 86);
			this.lbl_out_currTarget.Name = "lbl_out_currTarget";
			this.lbl_out_currTarget.Size = new System.Drawing.Size(68, 13);
			this.lbl_out_currTarget.TabIndex = 7;
			this.lbl_out_currTarget.Text = "Target Price:";
			// 
			// tb_out_next
			// 
			this.tb_out_next.BackColor = System.Drawing.SystemColors.InactiveCaption;
			this.tb_out_next.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.tb_out_next.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
			this.tb_out_next.Location = new System.Drawing.Point(128, 104);
			this.tb_out_next.Name = "tb_out_next";
			this.tb_out_next.ReadOnly = true;
			this.tb_out_next.Size = new System.Drawing.Size(48, 20);
			this.tb_out_next.TabIndex = 8;
			this.tb_out_next.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tb_out_next.WordWrap = false;
			// 
			// lbl_out_next
			// 
			this.lbl_out_next.AutoSize = true;
			this.lbl_out_next.Location = new System.Drawing.Point(136, 86);
			this.lbl_out_next.Name = "lbl_out_next";
			this.lbl_out_next.Size = new System.Drawing.Size(32, 13);
			this.lbl_out_next.TabIndex = 9;
			this.lbl_out_next.Text = "Next:";
			// 
			// btn_calc
			// 
			this.btn_calc.AutoSize = true;
			this.btn_calc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_calc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btn_calc.Location = new System.Drawing.Point(101, 44);
			this.btn_calc.Margin = new System.Windows.Forms.Padding(2);
			this.btn_calc.Name = "btn_calc";
			this.btn_calc.Size = new System.Drawing.Size(31, 19);
			this.btn_calc.TabIndex = 10;
			this.btn_calc.Text = "Calc";
			this.btn_calc.UseVisualStyleBackColor = true;
			this.btn_calc.Click += new System.EventHandler(this.Calculate);
			// 
			// panel_direction
			// 
			this.panel_direction.Controls.Add(this.rbtn_in_down);
			this.panel_direction.Controls.Add(this.rbtn_in_up);
			this.panel_direction.Location = new System.Drawing.Point(115, -2);
			this.panel_direction.Name = "panel_direction";
			this.panel_direction.Size = new System.Drawing.Size(58, 43);
			this.panel_direction.TabIndex = 12;
			// 
			// rbtn_in_down
			// 
			this.rbtn_in_down.AutoSize = true;
			this.rbtn_in_down.Location = new System.Drawing.Point(3, 24);
			this.rbtn_in_down.Name = "rbtn_in_down";
			this.rbtn_in_down.Size = new System.Drawing.Size(53, 17);
			this.rbtn_in_down.TabIndex = 1;
			this.rbtn_in_down.Text = "Down";
			this.rbtn_in_down.UseVisualStyleBackColor = true;
			// 
			// rbtn_in_up
			// 
			this.rbtn_in_up.AutoSize = true;
			this.rbtn_in_up.Checked = true;
			this.rbtn_in_up.Location = new System.Drawing.Point(3, 8);
			this.rbtn_in_up.Name = "rbtn_in_up";
			this.rbtn_in_up.Size = new System.Drawing.Size(39, 17);
			this.rbtn_in_up.TabIndex = 0;
			this.rbtn_in_up.TabStop = true;
			this.rbtn_in_up.Text = "Up";
			this.rbtn_in_up.UseVisualStyleBackColor = true;
			// 
			// panel_pips
			// 
			this.panel_pips.Controls.Add(this.rbtn_in_4pips);
			this.panel_pips.Controls.Add(this.rbtn_in_2pips);
			this.panel_pips.Location = new System.Drawing.Point(7, 48);
			this.panel_pips.Name = "panel_pips";
			this.panel_pips.Size = new System.Drawing.Size(83, 29);
			this.panel_pips.TabIndex = 13;
			// 
			// rbtn_in_4pips
			// 
			this.rbtn_in_4pips.AutoSize = true;
			this.rbtn_in_4pips.Checked = true;
			this.rbtn_in_4pips.Location = new System.Drawing.Point(41, 4);
			this.rbtn_in_4pips.Name = "rbtn_in_4pips";
			this.rbtn_in_4pips.Size = new System.Drawing.Size(31, 17);
			this.rbtn_in_4pips.TabIndex = 1;
			this.rbtn_in_4pips.TabStop = true;
			this.rbtn_in_4pips.Text = "4";
			this.rbtn_in_4pips.UseVisualStyleBackColor = true;
			// 
			// rbtn_in_2pips
			// 
			this.rbtn_in_2pips.AutoSize = true;
			this.rbtn_in_2pips.Location = new System.Drawing.Point(4, 4);
			this.rbtn_in_2pips.Name = "rbtn_in_2pips";
			this.rbtn_in_2pips.Size = new System.Drawing.Size(31, 17);
			this.rbtn_in_2pips.TabIndex = 0;
			this.rbtn_in_2pips.Text = "2";
			this.rbtn_in_2pips.UseVisualStyleBackColor = true;
			// 
			// btn_clear
			// 
			this.btn_clear.AutoSize = true;
			this.btn_clear.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btn_clear.Location = new System.Drawing.Point(136, 44);
			this.btn_clear.Margin = new System.Windows.Forms.Padding(2);
			this.btn_clear.Name = "btn_clear";
			this.btn_clear.Size = new System.Drawing.Size(34, 19);
			this.btn_clear.TabIndex = 14;
			this.btn_clear.Text = "Clear";
			this.btn_clear.UseVisualStyleBackColor = true;
			this.btn_clear.Click += new System.EventHandler(this.ClearCalculations);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trailingStopCalculationsToolStripMenuItem,
            this.toolStripSeparator1,
            this.cntxtMenuClose});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(210, 76);
			// 
			// trailingStopCalculationsToolStripMenuItem
			// 
			this.trailingStopCalculationsToolStripMenuItem.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.trailingStopCalculationsToolStripMenuItem.BackColor = System.Drawing.SystemColors.ControlLight;
			this.trailingStopCalculationsToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.trailingStopCalculationsToolStripMenuItem.Enabled = false;
			this.trailingStopCalculationsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ActiveCaption;
			this.trailingStopCalculationsToolStripMenuItem.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
			this.trailingStopCalculationsToolStripMenuItem.Name = "trailingStopCalculationsToolStripMenuItem";
			this.trailingStopCalculationsToolStripMenuItem.Size = new System.Drawing.Size(209, 22);
			this.trailingStopCalculationsToolStripMenuItem.Text = "Trailing Stop Calculations";
			this.trailingStopCalculationsToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(206, 6);
			// 
			// cntxtMenuClose
			// 
			this.cntxtMenuClose.AutoToolTip = true;
			this.cntxtMenuClose.Name = "cntxtMenuClose";
			this.cntxtMenuClose.Size = new System.Drawing.Size(209, 22);
			this.cntxtMenuClose.Text = "Close";
			this.cntxtMenuClose.ToolTipText = "Close Trailing Stop Calculations Module";
			this.cntxtMenuClose.Click += new System.EventHandler(this.CloseMe);
			// 
			// btn_next
			// 
			this.btn_next.AutoSize = true;
			this.btn_next.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_next.Enabled = false;
			this.btn_next.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btn_next.Location = new System.Drawing.Point(137, 64);
			this.btn_next.Margin = new System.Windows.Forms.Padding(2);
			this.btn_next.Name = "btn_next";
			this.btn_next.Size = new System.Drawing.Size(20, 19);
			this.btn_next.TabIndex = 16;
			this.btn_next.Text = ">";
			this.btn_next.UseVisualStyleBackColor = true;
			this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
			// 
			// btn_prev
			// 
			this.btn_prev.AutoSize = true;
			this.btn_prev.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_prev.Enabled = false;
			this.btn_prev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.btn_prev.Location = new System.Drawing.Point(110, 64);
			this.btn_prev.Margin = new System.Windows.Forms.Padding(2);
			this.btn_prev.Name = "btn_prev";
			this.btn_prev.Size = new System.Drawing.Size(20, 19);
			this.btn_prev.TabIndex = 15;
			this.btn_prev.Text = "<";
			this.btn_prev.UseVisualStyleBackColor = true;
			this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
			// 
			// ctrl_trailingStopCalculations
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.btn_next);
			this.Controls.Add(this.btn_prev);
			this.Controls.Add(this.panel_pips);
			this.Controls.Add(this.btn_clear);
			this.Controls.Add(this.panel_direction);
			this.Controls.Add(this.tb_out_next);
			this.Controls.Add(this.btn_calc);
			this.Controls.Add(this.lbl_out_next);
			this.Controls.Add(this.tb_out_currTarget);
			this.Controls.Add(this.lbl_out_currTarget);
			this.Controls.Add(this.tb_out_stop);
			this.Controls.Add(this.lbl_out_stop);
			this.Controls.Add(this.tb_in_pipsChange);
			this.Controls.Add(this.lbl_in_pipsChange);
			this.Controls.Add(this.tb_in_price);
			this.Controls.Add(this.lbl_in_price);
			this.Name = "ctrl_trailingStopCalculations";
			this.Size = new System.Drawing.Size(191, 131);
			this.Tag = "Trailing Stop Calculations";
			this.panel_direction.ResumeLayout(false);
			this.panel_direction.PerformLayout();
			this.panel_pips.ResumeLayout(false);
			this.panel_pips.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_in_price;
		private System.Windows.Forms.TextBox tb_in_price;
		private System.Windows.Forms.TextBox tb_in_pipsChange;
		private System.Windows.Forms.Label lbl_in_pipsChange;
		private System.Windows.Forms.TextBox tb_out_stop;
		private System.Windows.Forms.Label lbl_out_stop;
		private System.Windows.Forms.TextBox tb_out_currTarget;
		private System.Windows.Forms.Label lbl_out_currTarget;
		private System.Windows.Forms.TextBox tb_out_next;
		private System.Windows.Forms.Label lbl_out_next;
		private System.Windows.Forms.Button btn_calc;
		private System.Windows.Forms.Panel panel_direction;
		private System.Windows.Forms.RadioButton rbtn_in_down;
		private System.Windows.Forms.RadioButton rbtn_in_up;
		private System.Windows.Forms.Panel panel_pips;
		private System.Windows.Forms.RadioButton rbtn_in_4pips;
		private System.Windows.Forms.RadioButton rbtn_in_2pips;
		private System.Windows.Forms.Button btn_clear;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem cntxtMenuClose;
		private System.Windows.Forms.Button btn_next;
		private System.Windows.Forms.Button btn_prev;
		private System.Windows.Forms.ToolStripMenuItem trailingStopCalculationsToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
	}
}
