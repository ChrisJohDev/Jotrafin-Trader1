using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Printing;

namespace D4M.WIN.Printing
{
	class CLineItemFormat
	{
		Font itmFont;

		public void SetFont(System.Drawing.FontFamily family,float emSize)
		{
			itmFont = new Font(family, emSize);
		}

		public void SetFont(string familyName, float emSize)
		{
			itmFont = new Font(familyName, emSize);
		}

		public void SetFont(System.Drawing.FontFamily family, float emSize, System.Drawing.FontStyle style)
		{
			itmFont = new Font(family, emSize, style);
		}

		public void SetFont(System.Drawing.FontFamily family, float emSize, System.Drawing.GraphicsUnit unit)
		{
			itmFont = new Font(family, emSize, unit);
		}

		public void SetFont(string familyName, float emSize, System.Drawing.FontStyle style)
		{
			itmFont = new Font(familyName, emSize, style);
		}

		public void SetFont(string familyName, float emSize, System.Drawing.GraphicsUnit unit)
		{
			itmFont = new Font(familyName, emSize, unit);
		}

		public void SetFont(System.Drawing.FontFamily family, float emSize, System.Drawing.FontStyle style, System.Drawing.GraphicsUnit unit)
		{
			itmFont = new Font(family, emSize, style, unit);
		}

		public void SetFont(string familyName, float emSize, System.Drawing.FontStyle style, System.Drawing.GraphicsUnit unit)
		{
			itmFont = new Font(familyName, emSize, style, unit);
		}

		public void SetFont(System.Drawing.FontFamily family, float emSize, System.Drawing.FontStyle style, System.Drawing.GraphicsUnit unit, byte gdiCharSet)
		{
			itmFont = new Font(family, emSize, style, unit, gdiCharSet);
		}

		public void SetFont(string familyName, float emSize, System.Drawing.FontStyle style, System.Drawing.GraphicsUnit unit, byte gdiCharSet)
		{
			itmFont = new Font(familyName, emSize, style, unit, gdiCharSet);
		}

		public System.Drawing.Font ItemFont
		{
			get { return this.itmFont; }
		}
	}
}
