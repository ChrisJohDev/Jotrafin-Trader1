using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace D4M.FINANCE.JOTRAFIN
{
	/// <summary>
	/// Summary description for frmLogin.
	/// </summary>
	partial class CfrmLogin : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.TextBox edtUser;
		public System.Windows.Forms.TextBox edtPassword;
		private string _user, _pw;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		public CfrmLogin()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			Initialize();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.edtUser = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.edtPassword = new System.Windows.Forms.TextBox();
			this.cBox_edtServer = new System.Windows.Forms.ComboBox();
			this.checkBox_rememberPassword = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.AutoSize = true;
			this.btnCancel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(230, 112);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(50, 23);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOK.Location = new System.Drawing.Point(178, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(50, 23);
			this.btnOK.TabIndex = 4;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 3;
			this.label1.Text = "Server ID";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(100, 23);
			this.label2.TabIndex = 5;
			this.label2.Text = "User Name";
			// 
			// edtUser
			// 
			this.edtUser.Location = new System.Drawing.Point(120, 40);
			this.edtUser.Name = "edtUser";
			this.edtUser.ShortcutsEnabled = false;
			this.edtUser.Size = new System.Drawing.Size(160, 20);
			this.edtUser.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 23);
			this.label3.TabIndex = 7;
			this.label3.Text = "Password";
			// 
			// edtPassword
			// 
			this.edtPassword.Location = new System.Drawing.Point(120, 72);
			this.edtPassword.Name = "edtPassword";
			this.edtPassword.PasswordChar = '*';
			this.edtPassword.ShortcutsEnabled = false;
			this.edtPassword.Size = new System.Drawing.Size(160, 20);
			this.edtPassword.TabIndex = 2;
			// 
			// cBox_edtServer
			// 
			this.cBox_edtServer.FormattingEnabled = true;
			this.cBox_edtServer.Location = new System.Drawing.Point(120, 5);
			this.cBox_edtServer.Name = "cBox_edtServer";
			this.cBox_edtServer.Size = new System.Drawing.Size(160, 21);
			this.cBox_edtServer.TabIndex = 0;
			this.cBox_edtServer.SelectedIndexChanged += new System.EventHandler(this.cBox_edtServer_SelectedIndexChanged);
			// 
			// checkBox_rememberPassword
			// 
			this.checkBox_rememberPassword.AutoSize = true;
			this.checkBox_rememberPassword.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBox_rememberPassword.Location = new System.Drawing.Point(8, 112);
			this.checkBox_rememberPassword.Name = "checkBox_rememberPassword";
			this.checkBox_rememberPassword.Size = new System.Drawing.Size(129, 17);
			this.checkBox_rememberPassword.TabIndex = 3;
			this.checkBox_rememberPassword.Text = "Remember Password:";
			this.checkBox_rememberPassword.UseVisualStyleBackColor = true;
			// 
			// CfrmLogin
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(296, 149);
			this.Controls.Add(this.checkBox_rememberPassword);
			this.Controls.Add(this.cBox_edtServer);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.edtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.edtUser);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.btnCancel);
			this.Name = "CfrmLogin";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login Form";
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		#endregion

		private void Initialize()
		{
			LoadUserData();
		}

		private void LoadUserData()
		{
			if (this.cBox_edtServer.Items.Count > 0)
			{
				if (this.cBox_edtServer.SelectedItem.ToString() == "Demo trading")
					LoadDemoData();
				else if (this.cBox_edtServer.SelectedItem.ToString() == "Live Trading")
					LoadLiveData();
			}
			else
				LoadDemoData();
			
		}

		private void LoadLiveData()
		{
			_user = Properties.Settings.Default.LiveUserName;
			_pw = Properties.Settings.Default.LiveUserPassWord;

			if (_user != "")
				this.edtUser.Text = _user;
			if (_pw != "")
			{
				this.edtPassword.Text = _pw;
				this.checkBox_rememberPassword.Checked = true;
			}
		}

		private void LoadDemoData()
		{
			_user = Properties.Settings.Default.DemoUserName;
			_pw = Properties.Settings.Default.DemoUserPassWord;

			if (_user != "")
				this.edtUser.Text = _user;
			if (_pw != "")
			{
				this.edtPassword.Text = _pw;
				this.checkBox_rememberPassword.Checked = true;
			}
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			this._pw = this.edtPassword.Text;
			this._user = this.edtUser.Text;

			if (cBox_edtServer.SelectedItem.ToString() == "Demo trading")
			{
				Properties.Settings.Default.DemoUserName = this._user;
				if (this.checkBox_rememberPassword.Checked)
					Properties.Settings.Default.DemoUserPassWord = this._pw;
				else
					Properties.Settings.Default.DemoUserPassWord = "";
			}
			else if (cBox_edtServer.SelectedItem.ToString() == "Live Trading")
			{
				Properties.Settings.Default.LiveUserName = this._user;
				if (this.checkBox_rememberPassword.Checked)
					Properties.Settings.Default.LiveUserPassWord = this._pw;
				else
					Properties.Settings.Default.LiveUserPassWord = "";
			}
		}

		public void AddServerToList(string alias, int id)
		{
			this.cBox_edtServer.Items.Insert(id, alias);
			if (this.cBox_edtServer.Items.Count > 0)
				this.cBox_edtServer.SelectedIndex = 0;
		}

		public string User
		{
			get { return _user; }
			set { this._user = value; }
		}

		public string Password
		{
			get { return this._pw; }
			set { this._pw = value; }
		}

		private void cBox_edtServer_SelectedIndexChanged(object sender, EventArgs e)
		{
			LoadUserData();
		}
	}
}
