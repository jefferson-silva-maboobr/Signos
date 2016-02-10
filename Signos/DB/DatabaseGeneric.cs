using System;
using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace Signos
{
	public class DatabaseGeneric
	{
		private static object locker = new object ();
		private static DatabaseGeneric _instance;
		private static SQLiteConnection _database;

		public static DatabaseGeneric Instance {
			get {
				if (_instance == null) {
					_instance = new DatabaseGeneric ();
				}
				return _instance;
			}
		}

		public DatabaseGeneric ()
		{
			_database = DependencyService.Get<ISQLite> ().GetConnection ();
			_database.CreateTable<SignoItem> ();
		}

		public IEnumerable<T> GetObjects<T> () where T : IObject, new()
		{
			lock (locker) {
				return (from i in _database.Table<T> ()
				        select i).ToList ();
			}
		}

		public T GetObjectByID<T> (int id) where T : IObject, new()
		{
			lock (locker) {
				return _database.Table<T> ().FirstOrDefault (x => x.id == id);
			}
		}

		public int SaveObject<T> (T obj) where T : IObject
		{
			lock (locker) {
				if (GetObjectByID <SignoItem> (obj.id) != null) {
					_database.Update (obj);
					return obj.id;
				} else {
					return _database.Insert (obj);
				}
			}
		}

		public int DeleteObject<T> (int id) where T : IObject, new()
		{
			lock (locker) {
				return _database.Delete<T> (id);
			}
		}

		public void DeleteAllObjects<T> ()
		{
			lock (locker) {
				_database.DropTable<T> ();
				_database.CreateTable<T> ();
			}
		}
	}
}
