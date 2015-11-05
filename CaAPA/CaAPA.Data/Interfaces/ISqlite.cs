using System;
using SQLite.Net;

namespace CaAPA.Data
{
	public interface ISqlite
	{
		SQLiteConnection GetConnection();
	}
}

