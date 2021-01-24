namespace D4M.FINANCE.JOTRAFIN
{
	partial class ctrl_openPosition
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
			this.tb_ticket = new System.Windows.Forms.TextBox();
			this.tb_instrument = new System.Windows.Forms.TextBox();
			this.tb_position = new System.Windows.Forms.TextBox();
			this.tb_open = new System.Windows.Forms.TextBox();
			this.tb_pipsPL = new System.Windows.Forms.TextBox();
			this.tb_lots = new System.Windows.Forms.TextBox();
			this.tb_close = new System.Windows.Forms.TextBox();
			this.tb_stop = new System.Windows.Forms.TextBox();
			this.tb_limit = new System.Windows.Forms.TextBox();
			this.ctrl_openPosition_contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ctrl_ToolStripItem_close = new System.Windows.Forms.ToolStripMenuItem();
			this.ctrl_ToolStripItem_stop = new System.Windows.Forms.ToolStripMenuItem();
			this.ctrl_ToolStripItem_limit = new System.Windows.Forms.ToolStripMenuItem();
			this.ctrl_openPosition_contextMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// tb_ticket
			// 
			this.tb_ticket.Location = new System.Drawing.Point(0, 0);
			this.tb_ticket.Name = "tb_ticket";
			this.tb_ticket.Size = new System.Drawing.Size(70, 20);
			this.tb_ticket.TabIndex = 0;
			this.tb_ticket.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_instrument
			// 
			this.tb_instrument.Location = new System.Drawing.Point(71, 0);
			this.tb_instrument.Name = "tb_instrument";
			this.tb_instrument.Size = new System.Drawing.Size(64, 20);
			this.tb_instrument.TabIndex = 1;
			// 
			// tb_position
			// 
			this.tb_position.Location = new System.Drawing.Point(170, 0);
			this.tb_position.Name = "tb_position";
			this.tb_position.Size = new System.Drawing.Size(32, 20);
			this.tb_position.TabIndex = 2;
			// 
			// tb_open
			// 
			this.tb_open.Location = new System.Drawing.Point(203, 0);
			this.tb_open.Name = "tb_open";
			this.tb_open.Size = new System.Drawing.Size(40, 20);
			this.tb_open.TabIndex = 3;
			this.tb_open.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_pipsPL
			// 
			this.tb_pipsPL.Location = new System.Drawing.Point(367, 0);
			this.tb_pipsPL.Name = "tb_pipsPL";
			this.tb_pipsPL.Size = new System.Drawing.Size(36, 20);
			this.tb_pipsPL.TabIndex = 4;
			this.tb_pipsPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_lots
			// 
			this.tb_lots.Location = new System.Drawing.Point(136, 0);
			this.tb_lots.Name = "tb_lots";
			this.tb_lots.Size = new System.Drawing.Size(33, 20);
			this.tb_lots.TabIndex = 5;
			this.tb_lots.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_close
			// 
			this.tb_close.Location = new System.Drawing.Point(244, 0);
			this.tb_close.Name = "tb_close";
			this.tb_close.Size = new System.Drawing.Size(40, 20);
			this.tb_close.TabIndex = 6;
			this.tb_close.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_stop
			// 
			this.tb_stop.Location = new System.Drawing.Point(285, 0);
			this.tb_stop.Name = "tb_stop";
			this.tb_stop.Size = new System.Drawing.Size(40, 20);
			this.tb_stop.TabIndex = 7;
			this.tb_stop.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_limit
			// 
			this.tb_limit.Location = new System.Drawing.Point(326, 0);
			this.tb_limit.Name = "tb_limit";
			this.tb_limit.Size = new System.Drawing.Size(40, 20);
			this.tb_limit.TabIndex = 8;
			this.tb_limit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// ctrl_openPosition_contextMenu
			// 
			this.ctrl_openPosition_contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ctrl_ToolStripItem_close,
            this.ctrl_ToolStripItem_stop,
            this.ctrl_ToolStripItem_limit});
			this.ctrl_openPosition_contextMenu.Name = "ctrl_openPosition_contextMenu";
			this.ctrl_openPosition_contextMenu.ShowImageMargin = false;
			this.ctrl_openPosition_contextMenu.Size = new System.Drawing.Size(128, 92);
			this.ctrl_openPosition_contextMenu.Text = "Manage Open Position";
			// 
			// ctrl_ToolStripItem_close
			// 
			this.ctrl_ToolStripItem_close.Name = "ctrl_ToolStripItem_close";
			this.ctrl_ToolStripItem_close.Size = new System.Drawing.Size(127, 22);
			this.ctrl_ToolStripItem_close.Text = "Close";
			this.ctrl_ToolStripItem_close.Click += new System.EventHandler(this.ctrl_ToolStripItem_close_Click);
			// 
			// ctrl_ToolStripItem_stop
			// 
			this.ctrl_ToolStripItem_stop.Name = "ctrl_ToolStripItem_stop";
			this.ctrl_ToolStripItem_stop.Size = new System.Drawing.Size(127, 22);
			this.ctrl_ToolStripItem_stop.Text = "Stop";
			this.ctrl_ToolStripItem_stop.Click += new System.EventHandler(this.ctrl_ToolStripItem_stop_Click);
			// 
			// ctrl_ToolStripItem_limit
			// 
			this.ctrl_ToolStripItem_limit.Name = "ctrl_ToolStripItem_limit";
			this.ctrl_ToolStripItem_limit.Size = new System.Drawing.Size(127, 22);
			this.ctrl_ToolStripItem_limit.Text = "Limit";
			this.ctrl_ToolStripItem_limit.Click += new System.EventHandler(this.ctrl_ToolStripItem_limit_Click);
			// 
			// ctrl_openPosition
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tb_limit);
			this.Controls.Add(this.tb_stop);
			this.Controls.Add(this.tb_close);
			this.Controls.Add(this.tb_lots);
			this.Controls.Add(this.tb_pipsPL);
			this.Controls.Add(this.tb_open);
			this.Controls.Add(this.tb_position);
			this.Controls.Add(this.tb_instrument);
			this.Controls.Add(this.tb_ticket);
			this.Name = "ctrl_openPosition";
			this.Size = new System.Drawing.Size(406, 24);
			this.ctrl_openPosition_contextMenu.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox tb_ticket;
		private System.Windows.Forms.TextBox tb_instrument;
		private System.Windows.Forms.TextBox tb_position;
		private System.Windows.Forms.TextBox tb_open;
		private System.Windows.Forms.TextBox tb_pipsPL;
		private System.Windows.Forms.TextBox tb_lots;
		private System.Windows.Forms.TextBox tb_close;
		private System.Windows.Forms.TextBox tb_stop;
		private System.Windows.Forms.TextBox tb_limit;
		private System.Windows.Forms.ContextMenuStrip ctrl_openPosition_contextMenu;
		private System.Windows.Forms.ToolStripMenuItem ctrl_ToolStripItem_close;
		private System.Windows.Forms.ToolStripMenuItem ctrl_ToolStripItem_stop;
		private System.Windows.Forms.ToolStripMenuItem ctrl_ToolStripItem_limit;
	}
}
