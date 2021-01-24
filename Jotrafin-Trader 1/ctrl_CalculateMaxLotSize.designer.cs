namespace D4M.FINANCE.JOTRAFIN
{
	partial class ctrl_CalculateMaxLotSize
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
			this.components = new System.ComponentModel.Container();
			this.lbl_in_equity = new System.Windows.Forms.Label();
			this.textBox_in_equity = new System.Windows.Forms.TextBox();
			this.lbl_in_pips = new System.Windows.Forms.Label();
			this.textBox_in_pips = new System.Windows.Forms.TextBox();
			this.textBox_in_pipValue = new System.Windows.Forms.TextBox();
			this.lbl_in_pipValue = new System.Windows.Forms.Label();
			this.textBox_in_risk = new System.Windows.Forms.TextBox();
			this.lbl_in_risk = new System.Windows.Forms.Label();
			this.button_calc = new System.Windows.Forms.Button();
			this.textBox_out_lotSize = new System.Windows.Forms.TextBox();
			this.lbl_out_lotSize = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeControl = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_in_equity
			// 
			this.lbl_in_equity.AutoSize = true;
			this.lbl_in_equity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_in_equity.Location = new System.Drawing.Point(1, 0);
			this.lbl_in_equity.Name = "lbl_in_equity";
			this.lbl_in_equity.Size = new System.Drawing.Size(26, 9);
			this.lbl_in_equity.TabIndex = 0;
			this.lbl_in_equity.Text = "Equity";
			// 
			// textBox_in_equity
			// 
			this.textBox_in_equity.Location = new System.Drawing.Point(3, 12);
			this.textBox_in_equity.Name = "textBox_in_equity";
			this.textBox_in_equity.Size = new System.Drawing.Size(76, 20);
			this.textBox_in_equity.TabIndex = 0;
			this.textBox_in_equity.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox_in_equity.Enter += new System.EventHandler(this.textBox_Enter);
			// 
			// lbl_in_pips
			// 
			this.lbl_in_pips.AutoSize = true;
			this.lbl_in_pips.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_in_pips.Location = new System.Drawing.Point(82, 0);
			this.lbl_in_pips.Name = "lbl_in_pips";
			this.lbl_in_pips.Size = new System.Drawing.Size(22, 9);
			this.lbl_in_pips.TabIndex = 2;
			this.lbl_in_pips.Text = "PIPS";
			// 
			// textBox_in_pips
			// 
			this.textBox_in_pips.Location = new System.Drawing.Point(84, 12);
			this.textBox_in_pips.Name = "textBox_in_pips";
			this.textBox_in_pips.Size = new System.Drawing.Size(31, 20);
			this.textBox_in_pips.TabIndex = 1;
			this.textBox_in_pips.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox_in_pips.Enter += new System.EventHandler(this.textBox_Enter);
			// 
			// textBox_in_pipValue
			// 
			this.textBox_in_pipValue.Location = new System.Drawing.Point(121, 12);
			this.textBox_in_pipValue.Name = "textBox_in_pipValue";
			this.textBox_in_pipValue.Size = new System.Drawing.Size(45, 20);
			this.textBox_in_pipValue.TabIndex = 2;
			this.textBox_in_pipValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox_in_pipValue.Enter += new System.EventHandler(this.textBox_Enter);
			// 
			// lbl_in_pipValue
			// 
			this.lbl_in_pipValue.AutoSize = true;
			this.lbl_in_pipValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_in_pipValue.Location = new System.Drawing.Point(119, 0);
			this.lbl_in_pipValue.Name = "lbl_in_pipValue";
			this.lbl_in_pipValue.Size = new System.Drawing.Size(38, 9);
			this.lbl_in_pipValue.TabIndex = 4;
			this.lbl_in_pipValue.Text = "PIP Value";
			// 
			// textBox_in_risk
			// 
			this.textBox_in_risk.Location = new System.Drawing.Point(172, 12);
			this.textBox_in_risk.Name = "textBox_in_risk";
			this.textBox_in_risk.Size = new System.Drawing.Size(36, 20);
			this.textBox_in_risk.TabIndex = 3;
			this.textBox_in_risk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.textBox_in_risk.Enter += new System.EventHandler(this.textBox_Enter);
			// 
			// lbl_in_risk
			// 
			this.lbl_in_risk.AutoSize = true;
			this.lbl_in_risk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(0)));
			this.lbl_in_risk.Location = new System.Drawing.Point(170, 0);
			this.lbl_in_risk.Name = "lbl_in_risk";
			this.lbl_in_risk.Size = new System.Drawing.Size(38, 9);
			this.lbl_in_risk.TabIndex = 6;
			this.lbl_in_risk.Tag = "";
			this.lbl_in_risk.Text = "Max Risk";
			// 
			// button_calc
			// 
			this.button_calc.AutoSize = true;
			this.button_calc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.button_calc.Location = new System.Drawing.Point(2, 36);
			this.button_calc.Name = "button_calc";
			this.button_calc.Size = new System.Drawing.Size(61, 23);
			this.button_calc.TabIndex = 4;
			this.button_calc.Text = "Calculate";
			this.button_calc.UseVisualStyleBackColor = true;
			this.button_calc.Click += new System.EventHandler(this.Calculate);
			// 
			// textBox_out_lotSize
			// 
			this.textBox_out_lotSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.textBox_out_lotSize.Location = new System.Drawing.Point(145, 38);
			this.textBox_out_lotSize.Name = "textBox_out_lotSize";
			this.textBox_out_lotSize.Size = new System.Drawing.Size(63, 20);
			this.textBox_out_lotSize.TabIndex = 10;
			this.textBox_out_lotSize.TabStop = false;
			this.textBox_out_lotSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_out_lotSize
			// 
			this.lbl_out_lotSize.AutoSize = true;
			this.lbl_out_lotSize.Location = new System.Drawing.Point(73, 41);
			this.lbl_out_lotSize.Name = "lbl_out_lotSize";
			this.lbl_out_lotSize.Size = new System.Drawing.Size(68, 13);
			this.lbl_out_lotSize.TabIndex = 9;
			this.lbl_out_lotSize.Text = "Max Lot Size";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeControl});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(104, 26);
			// 
			// closeControl
			// 
			this.closeControl.Name = "closeControl";
			this.closeControl.Size = new System.Drawing.Size(103, 22);
			this.closeControl.Text = "Close";
			this.closeControl.Click += new System.EventHandler(this.closeControl_Click);
			// 
			// ctrl_CalculateMaxLotSize
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.textBox_out_lotSize);
			this.Controls.Add(this.lbl_out_lotSize);
			this.Controls.Add(this.button_calc);
			this.Controls.Add(this.textBox_in_risk);
			this.Controls.Add(this.lbl_in_risk);
			this.Controls.Add(this.textBox_in_pipValue);
			this.Controls.Add(this.lbl_in_pipValue);
			this.Controls.Add(this.textBox_in_pips);
			this.Controls.Add(this.lbl_in_pips);
			this.Controls.Add(this.textBox_in_equity);
			this.Controls.Add(this.lbl_in_equity);
			this.Name = "ctrl_CalculateMaxLotSize";
			this.Size = new System.Drawing.Size(213, 63);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_in_equity;
		private System.Windows.Forms.TextBox textBox_in_equity;
		private System.Windows.Forms.Label lbl_in_pips;
		private System.Windows.Forms.TextBox textBox_in_pips;
		private System.Windows.Forms.TextBox textBox_in_pipValue;
		private System.Windows.Forms.Label lbl_in_pipValue;
		private System.Windows.Forms.TextBox textBox_in_risk;
		private System.Windows.Forms.Label lbl_in_risk;
		private System.Windows.Forms.Button button_calc;
		private System.Windows.Forms.TextBox textBox_out_lotSize;
		private System.Windows.Forms.Label lbl_out_lotSize;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem closeControl;
	}
}