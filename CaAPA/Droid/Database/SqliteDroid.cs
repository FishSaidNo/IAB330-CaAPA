using System;
using CaAPA.Data;
using SQLite.Net;
using System.IO;
using Xamarin.Forms;
using CaAPA.Droid;

//TODO show IOC vs Dependency Injection
[assembly: Dependency (typeof (SqliteDroid))]

namespace CaAPA.Droid
{
	public class SqliteDroid : ISqlite
	{
		public SqliteDroid(){
		}
		#region ISqlite implementation

		public SQLiteConnection GetConnection ()
		{
			const string sqliteFilename = "caapa_db.sqlite";
			var documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			var path = Path.Combine (documentsPath, sqliteFilename);
			var plat = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
			//Create the connection
			var conn = new SQLiteConnection(plat,path);

			return conn;
		}

		#endregion


	}
}

