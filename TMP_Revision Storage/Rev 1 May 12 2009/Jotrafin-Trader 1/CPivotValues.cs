using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace D4M.FINANCE.JOTRAFIN
{
	class CPivotValues
	{
		private List<CPivotValue> items = new List<CPivotValue>();

		public CPivotValues()
		{
		}

		public List<CPivotValue> Items
		{
			get{return items;}
		}

		public void Add(CPivotValue pivot)
		{
			this.items.Add(pivot);
		}

		public void ClearList()
		{
			this.items.Clear();
		}

		public int Count
		{
			get { return this.items.Count; }
		}
	}

	class CPivotValue
	{
		private double pp,rm1,rm2,rm3,r1,r2,r3,sm1,sm2,sm3,s1,s2,s3,rm2a,rm3a,r2a,sm2a,sm3a,s2a;
		private string pair;
		private DateTime date;
		private int decimals;

		public CPivotValue()
		{
			this.decimals = 4;
			this.pair = "EUR/USD";
			this.date = DateTime.Now;
		}

		#region String Accessors
		public string PivotPoint
		{
			get	{ return Math.Round(pp, decimals).ToString(formatString()); }
		}
		public string RM1
		{
			get { return Math.Round(rm1, decimals).ToString(formatString()); }
		}
		public string RM2
		{
			get { return Math.Round(rm2, decimals).ToString(formatString()); }
		}
		public string RM3
		{
			get { return Math.Round(rm3, decimals).ToString(formatString()); }
		}
		public string RM3A
		{
			get { return Math.Round(rm3a, decimals).ToString(formatString()); }
		}
		public string RM2A
		{
			get { return Math.Round(rm2a, decimals).ToString(formatString()); }
		}
		public string R1
		{
			get { return Math.Round(r1, decimals).ToString(formatString()); }
		}
		public string R2
		{
			get { return Math.Round(r2, decimals).ToString(formatString()); }
		}
		public string R3
		{
			get { return Math.Round(r3, decimals).ToString(formatString()); }
		}
		public string R2A
		{
			get { return Math.Round(r2a, decimals).ToString(formatString()); }
		}
		public string SM1
		{
			get { return Math.Round(sm1, decimals).ToString(formatString()); }
		}
		public string SM2
		{
			get { return Math.Round(sm2, decimals).ToString(formatString()); }
		}
		public string SM3
		{
			get { return Math.Round(sm3, decimals).ToString(formatString()); }
		}
		public string SM3A
		{
			get { return Math.Round(sm3a, decimals).ToString(formatString()); }
		}
		public string SM2A
		{
			get { return Math.Round(sm2a, decimals).ToString(formatString()); }
		}
		public string S1
		{
			get { return Math.Round(s1, decimals).ToString(formatString()); }
		}
		public string S2
		{
			get { return Math.Round(s2, decimals).ToString(formatString()); }
		}
		public string S3
		{
			get { return Math.Round(s3, decimals).ToString(formatString()); }
		}
		public string S2A
		{
			get { return Math.Round(s2a, decimals).ToString(formatString()); }
		}
		public string Pair
		{
			get { return pair; }
			set { this.pair = value; }
		}
		public string Decimals_String
		{
			get { return this.decimals.ToString(); }
		}
		public string Date_String
		{
			get { return this.date.ToString("MMM/dd/yyyy"); }
		}
		#endregion (String Accessors)

		#region Double Accessors
		public double Dbl_PivotPoint
		{
			get { return pp; }
			set { pp = value; }
		}
		public double Dbl_RM1
		{
			get { return this.rm1; }
			set { this.rm1 = value; }
		}
		public double Dbl_RM2
		{
			get { return this.rm2; }
			set { this.rm2 = value; }
		}
		public double Dbl_RM3
		{
			get { return this.rm3; }
			set { this.rm3 = value; }
		}
		public double Dbl_R1
		{
			get { return this.r1; }
			set { this.r1 = value; }
		}
		public double Dbl_R2
		{
			get { return this.r2; }
			set { this.r2 = value; }
		}
		public double Dbl_R3
		{
			get { return this.r3; }
			set { this.r3 = value; }
		}
		public double Dbl_RM3A
		{
			get { return this.rm3a; }
			set { this.rm3a = value; }
		}
		public double Dbl_RM2A
		{
			get { return this.rm2a; }
			set { this.rm2a = value; }
		}
		public double Dbl_R2A
		{
			get { return this.r2a; }
			set { this.r2a = value; }
		}
		public double Dbl_SM1
		{
			get { return this.sm1; }
			set { this.sm1 = value; }
		}
		public double Dbl_SM2
		{
			get { return this.sm2; }
			set { this.sm2 = value; }
		}
		public double Dbl_SM3
		{
			get { return this.sm3; }
			set { this.sm3 = value; }
		}
		public double Dbl_S1
		{
			get { return this.s1; }
			set { this.s1 = value; }
		}
		public double Dbl_S2
		{
			get { return this.s2; }
			set { this.s2 = value; }
		}
		public double Dbl_S3
		{
			get { return this.s3; }
			set { this.s3 = value; }
		}
		public double Dbl_SM3A
		{
			get { return this.sm3a; }
			set { this.sm3a = value; }
		}
		public double Dbl_SM2A
		{
			get { return this.sm2a; }
			set { this.sm2a = value; }
		}
		public double Dbl_S2A
		{
			get { return this.s2a; }
			set { this.s2a = value; }
		}
		public double DBL_Decimals
		{
			get { return double.Parse(this.decimals.ToString()); }
		}
		#endregion (Double Accessors)

		#region General Accessors
		public DateTime Date
		{
			get { return this.date; }
			set { this.date = value; }
		}
		public int Decimals
		{
			get { return this.decimals; }
			set { this.decimals = value; }
		}
		#endregion (General Accessors)

		private string formatString()
		{
			string rv = "#,##0";

			for (int i = 0; i < decimals; i++)
			{
				if (i == 0) rv += ".0";
				else rv += "0";
			}

			return rv;
		}
	}
}
