using System;
using SQLite;

namespace Signos
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection ();
	}
}

