using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using D4M.Controls.Common;

namespace D4M.FINANCE.JOTRAFIN
{
	public partial class ctrl_calculateDistance : D4MControl
	{
		double in1, in2, out1, formFact;
		string dir;

		public delegate void DistanceCalculatedEventsHandler(object sender, DistanceCaclulatedEventArgs arg);
		public event DistanceCalculatedEventsHandler DistanceCalculated;
		//public delegate void CloseDistanceCalcControlEventsHandler(object sender, CloseControlEventArgs<ctrl_calculateDistance> arg);
		//public event CloseDistanceCalcControlEventsHandler CloseDistanceCalcControl;
		public event CloseControlEventHandler CloseControlEvent;

		public ctrl_calculateDistance()
		{
			InitializeComponent();
		}

		private void btn_calc_Click(object sender, EventArgs e)
		{
			CalculateDistance();
		}

		private void CalculateDistance()
		{
			try
			{
				in1 = double.Parse(this.tb_in_1.Text);
				in2 = double.Parse(this.tb_in_2.Text);
				int len1 = this.tb_in_1.Text.Length - this.tb_in_1.Text.IndexOf('.');
				int len2 = this.tb_in_2.Text.IndexOf('.');

				if (len1 > 2 || len2 > 2)
				{
					formFact = 10000;
				}
				else
				{
					formFact = 100;
				}
				if (in1 > in2)
					dir = "PIPS Down";
				else if (in2 > in1)
					dir = "PIPS Up";
				else
					dir = "";
			}
			catch (Exception e)
			{
			}

			this.out1 = Math.Round(Math.Abs(this.in1 - this.in2)*formFact,0);
			OnDistanceCalculated(new DistanceCaclulatedEventArgs(this.out1, this.dir));

			this.tb_out.Text = this.out1.ToString();
			this.tb_direction.Text = this.dir;
		}

		protected virtual void OnDistanceCalculated(DistanceCaclulatedEventArgs arg)
		{
			DistanceCalculated(this, arg);
		}

		protected virtual void OnCloseControl(D4M.Controls.Common.CloseControlEventArgs arg)
		{
			CloseControlEvent(this, arg);
		}

		private void closeForm_Click(object sender, EventArgs e)
		{
			OnCloseControl(new D4M.Controls.Common.CloseControlEventArgs());
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if(keyData.Equals(Keys.Enter))
			{
				this.btn_calc.PerformClick();
			}
			return base.ProcessDialogKey(keyData);
		}
	}

	public class DistanceCaclulatedEventArgs : EventArgs
	{
		private double d = 0;
		private string dir = "";
		public DistanceCaclulatedEventArgs(double distance, string direction)
		{
			d = distance;
			dir = direction;
		}

		public double Distance
		{
			get { return this.d; }
		}

		public string Direction
		{
			get { return this.dir; }
		}
	}

	//public class CloseControlEventArgs : EventArgs
	//{
		
	//}
}
