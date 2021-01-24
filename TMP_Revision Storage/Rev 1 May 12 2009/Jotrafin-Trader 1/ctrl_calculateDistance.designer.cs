namespace D4M.FINANCE.JOTRAFIN
{
	partial class ctrl_calculateDistance
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
			this.lbl_in_1 = new System.Windows.Forms.Label();
			this.tb_in_1 = new System.Windows.Forms.TextBox();
			this.tb_in_2 = new System.Windows.Forms.TextBox();
			this.lbl_in_2 = new System.Windows.Forms.Label();
			this.btn_calc = new System.Windows.Forms.Button();
			this.tb_out = new System.Windows.Forms.TextBox();
			this.lbl_out = new System.Windows.Forms.Label();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.closeForm = new System.Windows.Forms.ToolStripMenuItem();
			this.tb_direction = new System.Windows.Forms.TextBox();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbl_in_1
			// 
			this.lbl_in_1.AutoSize = true;
			this.lbl_in_1.Location = new System.Drawing.Point(3, 0);
			this.lbl_in_1.Name = "lbl_in_1";
			this.lbl_in_1.Size = new System.Drawing.Size(40, 13);
			this.lbl_in_1.TabIndex = 0;
			this.lbl_in_1.Text = "Price 1";
			// 
			// tb_in_1
			// 
			this.tb_in_1.Location = new System.Drawing.Point(6, 17);
			this.tb_in_1.Name = "tb_in_1";
			this.tb_in_1.Size = new System.Drawing.Size(46, 20);
			this.tb_in_1.TabIndex = 1;
			this.tb_in_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// tb_in_2
			// 
			this.tb_in_2.Location = new System.Drawing.Point(58, 17);
			this.tb_in_2.Name = "tb_in_2";
			this.tb_in_2.Size = new System.Drawing.Size(46, 20);
			this.tb_in_2.TabIndex = 3;
			this.tb_in_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_in_2
			// 
			this.lbl_in_2.AutoSize = true;
			this.lbl_in_2.Location = new System.Drawing.Point(55, 0);
			this.lbl_in_2.Name = "lbl_in_2";
			this.lbl_in_2.Size = new System.Drawing.Size(40, 13);
			this.lbl_in_2.TabIndex = 2;
			this.lbl_in_2.Text = "Price 2";
			// 
			// btn_calc
			// 
			this.btn_calc.AutoSize = true;
			this.btn_calc.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_calc.Location = new System.Drawing.Point(110, 15);
			this.btn_calc.Name = "btn_calc";
			this.btn_calc.Size = new System.Drawing.Size(61, 23);
			this.btn_calc.TabIndex = 4;
			this.btn_calc.Text = "Calculate";
			this.btn_calc.UseVisualStyleBackColor = true;
			this.btn_calc.Click += new System.EventHandler(this.btn_calc_Click);
			// 
			// tb_out
			// 
			this.tb_out.Location = new System.Drawing.Point(58, 42);
			this.tb_out.Name = "tb_out";
			this.tb_out.Size = new System.Drawing.Size(46, 20);
			this.tb_out.TabIndex = 6;
			this.tb_out.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// lbl_out
			// 
			this.lbl_out.AutoSize = true;
			this.lbl_out.Location = new System.Drawing.Point(3, 45);
			this.lbl_out.Name = "lbl_out";
			this.lbl_out.Size = new System.Drawing.Size(49, 13);
			this.lbl_out.TabIndex = 5;
			this.lbl_out.Text = "Distance";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeForm});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.ShowImageMargin = false;
			this.contextMenuStrip1.Size = new System.Drawing.Size(79, 26);
			// 
			// closeForm
			// 
			this.closeForm.Name = "closeForm";
			this.closeForm.Size = new System.Drawing.Size(78, 22);
			this.closeForm.Text = "Close";
			this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
			// 
			// tb_direction
			// 
			this.tb_direction.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tb_direction.Enabled = false;
			this.tb_direction.Location = new System.Drawing.Point(110, 45);
			this.tb_direction.Name = "tb_direction";
			this.tb_direction.ReadOnly = true;
			this.tb_direction.Size = new System.Drawing.Size(61, 13);
			this.tb_direction.TabIndex = 7;
			this.tb_direction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// frm_calculateDistance
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.tb_direction);
			this.Controls.Add(this.tb_out);
			this.Controls.Add(this.lbl_out);
			this.Controls.Add(this.btn_calc);
			this.Controls.Add(this.tb_in_2);
			this.Controls.Add(this.lbl_in_2);
			this.Controls.Add(this.tb_in_1);
			this.Controls.Add(this.lbl_in_1);
			this.Name = "frm_calculateDistance";
			this.Size = new System.Drawing.Size(175, 71);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label lbl_in_1;
		private System.Windows.Forms.TextBox tb_in_1;
		private System.Windows.Forms.TextBox tb_in_2;
		private System.Windows.Forms.Label lbl_in_2;
		private System.Windows.Forms.Button btn_calc;
		private System.Windows.Forms.TextBox tb_out;
		private System.Windows.Forms.Label lbl_out;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem closeForm;
		private System.Windows.Forms.TextBox tb_direction;
	}
}
