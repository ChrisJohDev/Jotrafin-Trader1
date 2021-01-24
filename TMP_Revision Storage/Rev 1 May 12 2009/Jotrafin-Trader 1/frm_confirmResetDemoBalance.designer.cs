namespace D4M.FINANCE.JOTRAFIN
{
	partial class frm_confirmResetDemoBalance
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
			this.checkBox_newDefault = new System.Windows.Forms.CheckBox();
			this.bnt_ok = new System.Windows.Forms.Button();
			this.btn_cancel = new System.Windows.Forms.Button();
			this.lbl_defaultAmount = new System.Windows.Forms.Label();
			this.txtBox_defaultAmount = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// checkBox_newDefault
			// 
			this.checkBox_newDefault.AutoSize = true;
			this.checkBox_newDefault.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_newDefault.Location = new System.Drawing.Point(14, 12);
			this.checkBox_newDefault.Name = "checkBox_newDefault";
			this.checkBox_newDefault.Size = new System.Drawing.Size(244, 17);
			this.checkBox_newDefault.TabIndex = 0;
			this.checkBox_newDefault.Text = "Enter new Default amount for demo account? ";
			this.checkBox_newDefault.UseVisualStyleBackColor = true;
			this.checkBox_newDefault.CheckedChanged += new System.EventHandler(this.checkBox_newDefault_CheckedChanged);
			// 
			// bnt_ok
			// 
			this.bnt_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.bnt_ok.Location = new System.Drawing.Point(164, 106);
			this.bnt_ok.Name = "bnt_ok";
			this.bnt_ok.Size = new System.Drawing.Size(50, 23);
			this.bnt_ok.TabIndex = 1;
			this.bnt_ok.Text = "OK";
			this.bnt_ok.UseVisualStyleBackColor = true;
			this.bnt_ok.Click += new System.EventHandler(this.bnt_ok_Click);
			// 
			// btn_cancel
			// 
			this.btn_cancel.AutoSize = true;
			this.btn_cancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btn_cancel.Location = new System.Drawing.Point(220, 106);
			this.btn_cancel.Name = "btn_cancel";
			this.btn_cancel.Size = new System.Drawing.Size(50, 23);
			this.btn_cancel.TabIndex = 2;
			this.btn_cancel.Text = "Cancel";
			this.btn_cancel.UseVisualStyleBackColor = true;
			// 
			// lbl_defaultAmount
			// 
			this.lbl_defaultAmount.AutoSize = true;
			this.lbl_defaultAmount.Location = new System.Drawing.Point(84, 32);
			this.lbl_defaultAmount.Name = "lbl_defaultAmount";
			this.lbl_defaultAmount.Size = new System.Drawing.Size(105, 13);
			this.lbl_defaultAmount.TabIndex = 3;
			this.lbl_defaultAmount.Text = "New Default Amount";
			this.lbl_defaultAmount.Visible = false;
			// 
			// txtBox_defaultAmount
			// 
			this.txtBox_defaultAmount.Location = new System.Drawing.Point(87, 49);
			this.txtBox_defaultAmount.Name = "txtBox_defaultAmount";
			this.txtBox_defaultAmount.Size = new System.Drawing.Size(100, 20);
			this.txtBox_defaultAmount.TabIndex = 4;
			this.txtBox_defaultAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtBox_defaultAmount.Visible = false;
			this.txtBox_defaultAmount.WordWrap = false;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 77);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(267, 13);
			this.label2.TabIndex = 5;
			this.label2.Text = "Click OK to reset the demo account to its default value.";
			// 
			// frm_confirmResetDemoBalance
			// 
			this.AcceptButton = this.bnt_ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btn_cancel;
			this.ClientSize = new System.Drawing.Size(273, 137);
			this.ControlBox = false;
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtBox_defaultAmount);
			this.Controls.Add(this.lbl_defaultAmount);
			this.Controls.Add(this.btn_cancel);
			this.Controls.Add(this.bnt_ok);
			this.Controls.Add(this.checkBox_newDefault);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frm_confirmResetDemoBalance";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Confirm Reset Demo Balance";
			this.TopMost = true;
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox checkBox_newDefault;
		private System.Windows.Forms.Button bnt_ok;
		private System.Windows.Forms.Button btn_cancel;
		private System.Windows.Forms.Label lbl_defaultAmount;
		private System.Windows.Forms.TextBox txtBox_defaultAmount;
		private System.Windows.Forms.Label label2;
	}
}