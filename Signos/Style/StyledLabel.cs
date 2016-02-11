using System;
using Xamarin.Forms;

namespace Signos
{
	public enum StyleType
	{
		Italic,
		Bold,
		BoldItalic
	}

	public class StyledLabel : Label
	{
		public StyleType Style { get; set; }
	}
}


