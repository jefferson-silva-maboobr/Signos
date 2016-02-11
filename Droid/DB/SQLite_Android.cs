using System.IO;
using SQLite;
using Zodiaco.Droid.DB;

[assembly: Xamarin.Forms.Dependency (typeof(SQLite_Android))]
namespace Zodiaco.Droid.DB
{
	public class SQLite_Android : ISQLite
	{
		public SQLiteConnection GetConnection ()
		{
			var filename = "SignosDB.db3";
			string folder = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
			var path = Path.Combine (folder, filename);
			var connection = new SQLiteConnection (path);
			return connection;
		}
	}
}

