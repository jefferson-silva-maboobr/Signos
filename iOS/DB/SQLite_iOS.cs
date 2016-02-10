using Signos.Droid.DB;
using System;
using System.IO;
using SQLite;

[assembly: Xamarin.Forms.Dependency (typeof(SQLite_iOS))]
namespace Signos.Droid.DB
{
	public class SQLite_iOS : ISQLite
	{
		public SQLiteConnection GetConnection ()
		{
			var filename = "SignosDB.db3";
                string folder =
                    Environment.GetFolderPath (Environment.SpecialFolder.Personal);
                string libraryFolder = Path.Combine (folder, "..", "Library");
                var path = Path.Combine(libraryFolder, filename);
                var connection = new SQLiteConnection(path);
                return connection;
		}
	}
}

