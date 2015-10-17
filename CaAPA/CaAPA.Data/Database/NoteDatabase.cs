using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;

namespace CaAPA.Data
{
	public class NoteDatabase
	{
		public static MobileServiceClient MobileService = new MobileServiceClient(
			"https://caapa.azure-mobile.net/",
			"coHzRHuoqnHiolDACEHMunJRIeEJUH21"
		);

		SQLiteConnection database;
		public NoteDatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();
			//TODO show IOC vs Dependency injection
//			database = SimpleIoc.Default.GetInstance<ISqlite> ().GetConnection ();
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Note).Name)) {
				database.CreateTable<Note> ();
				database.Commit ();
			}
		}

		public List<Note> GetAll(){
			var items = database.Table<Note> ().ToList<Note>();

			return items;
		}

//		public int InsertOrUpdateNote(Note note){
//			return database.Table<Note> ().Where (x => x.titleText == note.titleText).Count () > 0 
//				? database.Update (note) : database.Insert (note);
//		}

		public async Task<int> InsertOrUpdateNote(Note note){
			//			return database.Table<Note> ().Where (x => x.NoteId == note.NoteId).Any () 
			//				? database.Update (note) : database.Insert (note);
			var lookup = await MobileService.GetTable<Note> ().LookupAsync (note.id);
			if (lookup != null) {
				await MobileService.GetTable<Note> ().InsertAsync (note);
			} else {
				await MobileService.GetTable<Note> ().UpdateAsync (note);
			}
			return 1;

		}

		public Note GetNote(string key){
			return database.Table<Note> ().First (t => t.titleText == key); 
		}

	}
}

