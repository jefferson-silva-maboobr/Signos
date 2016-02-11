using System;
using SQLite;

namespace Zodiaco
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection ();
	}
}

