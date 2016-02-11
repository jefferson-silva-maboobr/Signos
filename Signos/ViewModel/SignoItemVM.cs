using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Zodiaco
{
	public class SignoItemVM
	{
		private static SignoItemVM _instance;

		public static SignoItemVM Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SignoItemVM ();
				}
				return _instance;
			}
		}

		public List<SignoItem> GetSignosAsync () {
			return SignoItem.GetItems ();
		}

		public SignoItem GetSigno (int signoId) {
			return SignoItem.GetItemByID (signoId);
		}
	}
}

