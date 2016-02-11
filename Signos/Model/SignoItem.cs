using System;
using System.Collections.Generic;
using SQLite;

namespace Zodiaco
{
	public class SignoItem : IObject
	{
		[PrimaryKey]
		public int id { get; set; }

		[MaxLength (20)]
		public string name { get; set; }

		[MaxLength (300)]
		public string imageURI { get; set; }

		[MaxLength (200)]
		public string message { get; set; }

		[MaxLength (200)]
		public string author { get; set; }

		[MaxLength (10)]
		public long timestamp { get; set; }

		[MaxLength (6)]
		public string color { get; set; }

		/*******************
		* Database methods
		********************/
		public static SignoItem GetItemByID (int id)
		{
			return DatabaseGeneric.Instance.GetObjectByID <SignoItem> (id);
		}

		public static List<SignoItem> GetItems ()
		{
			return new List<SignoItem> (DatabaseGeneric.Instance.GetObjects<SignoItem> ());
		}

		public static int SaveItem (SignoItem item)
		{
			return DatabaseGeneric.Instance.SaveObject<SignoItem> (item);
		}

		public static int DeleteItem (int id)
		{
			return DatabaseGeneric.Instance.DeleteObject<SignoItem> (id);
		}

		public static void DeleteAllItems ()
		{
			DatabaseGeneric.Instance.DeleteAllObjects<SignoItem> ();
		}
	}
}

