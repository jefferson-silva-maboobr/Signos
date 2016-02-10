using System.IO;
using Signos.Droid.DB;
using SQLite;

[assembly: Xamarin.Forms.Dependency (typeof(SQLite_Android))]
namespace Signos.Droid.DB
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

