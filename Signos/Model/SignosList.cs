using System;
using System.Collections.Generic;

namespace Signos
{
	public class SignosBean
	{
		public List<SignoItem> Signos = new List<SignoItem> ();

		public SignosBean (List<SignoItem> list)
		{
			this.Signos = list;
		}

		public List<SignoItem> Get ()
		{
			return this.Signos;
		}
	}
}

