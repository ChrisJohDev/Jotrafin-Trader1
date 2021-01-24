namespace D4M.FINANCE.JOTRAFIN
{
	partial class frm_PositionManager
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
			this.panel1 = new System.Windows.Forms.Panel();
			this.cancel_btn = new System.Windows.Forms.Button();
			this.ok_btn = new System.Windows.Forms.Button();
			this.Functionality_lbl = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.cancel_btn);
			this.panel1.Controls.Add(this.ok_btn);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel1.Location = new System.Drawing.Point(0, 300);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(512, 34);
			this.panel1.TabIndex = 0;
			// 
			// cancel_btn
			// 
			this.cancel_btn.AutoSize = true;
			this.cancel_btn.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.cancel_btn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel_btn.Location = new System.Drawing.Point(456, 4);
			this.cancel_btn.Name = "cancel_btn";
			this.cancel_btn.Size = new System.Drawing.Size(50, 23);
			this.cancel_btn.TabIndex = 1;
			this.cancel_btn.Text = "Cancel";
			this.cancel_btn.UseVisualStyleBackColor = true;
			// 
			// ok_btn
			// 
			this.ok_btn.Location = new System.Drawing.Point(404, 4);
			this.ok_btn.Name = "ok_btn";
			this.ok_btn.Size = new System.Drawing.Size(50, 23);
			this.ok_btn.TabIndex = 0;
			this.ok_btn.Text = "OK";
			this.ok_btn.UseVisualStyleBackColor = true;
			// 
			// Functionality_lbl
			// 
			this.Functionality_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.Functionality_lbl.Dock = System.Windows.Forms.DockStyle.Top;
			this.Functionality_lbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Functionality_lbl.Location = new System.Drawing.Point(0, 0);
			this.Functionality_lbl.Name = "Functionality_lbl";
			this.Functionality_lbl.Size = new System.Drawing.Size(512, 20);
			this.Functionality_lbl.TabIndex = 1;
			this.Functionality_lbl.Text = "label1";
			this.Functionality_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frm_PositionManager
			// 
			this.AcceptButton = this.ok_btn;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.cancel_btn;
			this.ClientSize = new System.Drawing.Size(512, 334);
			this.Controls.Add(this.Functionality_lbl);
			this.Controls.Add(this.panel1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frm_PositionManager";
			this.Text = "Position Manager";
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.Button cancel_btn;
		private System.Windows.Forms.Button ok_btn;
		public System.Windows.Forms.Label Functionality_lbl;
	}
}