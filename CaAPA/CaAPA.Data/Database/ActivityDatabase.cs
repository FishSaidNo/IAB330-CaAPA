using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Linq;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using System.Diagnostics;

namespace CaAPA.Data
{
	public class ActivityDatabase
	{
		public const string applicationURL = @"https://caapa.azure-mobile.net/";
		public const string applicationKey = @"coHzRHuoqnHiolDACEHMunJRIeEJUH21";

		public static MobileServiceClient MobileService = new MobileServiceClient(applicationURL, applicationKey);

		SQLiteConnection database;

		public ActivityDatabase ()
		{
			database = DependencyService.Get<ISqlite> ().GetConnection ();
			//TODO show IOC vs Dependency injection
//			database = SimpleIoc.Default.GetInstance<ISqlite> ().GetConnection ();
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Activities).Name)) {
				database.CreateTable<Activities> ();
				database.Commit ();
			}

		}

		public async Task<List<Activities>> GetAll(){
//			var items = database.Table<Activities> ().ToList<Activities>();
//			Debug.WriteLine (items);
//			return items;

			// OR
			var x = await MobileService.GetTable<Activities> ().ToListAsync ();
			return x;

		}

		public async Task<int> InsertOrUpdateActivity(Activities activity){
			//			return database.Table<Note> ().Where (x => x.NoteId == note.NoteId).Any () 
			//				? database.Update (note) : database.Insert (note);
			var lookup = await MobileService.GetTable<Activities> ().LookupAsync (activity.id);
			if (lookup != null) {
				await MobileService.GetTable<Activities> ().InsertAsync (activity);
			} else {
				await MobileService.GetTable<Activities> ().UpdateAsync (activity);
			}
			return 1;

		}

		public Activities GetActivity(int key){
			return database.Table<Activities> ().First (t => t.id == key); 
		}

		public List<Activities> SearchActivity(string searchTerm){
			return database.Table<Activities> ().Where (x => x.ActivityName.Contains (searchTerm)).ToList ();
			//return database.Query<Note> ("Select * from Note where titleText like *?*", searchTerm).ToList();

		}

		public List<Activities> SearchLocation(string searchTerm){
			return database.Table<Activities> ().Where (x => x.ActivityLocation.Contains (searchTerm)).ToList ();
			//return database.Query<Note> ("Select * from Note where NoteDetail like *?*", searchTerm).ToList();
		}

		//		public List<IGrouping<DayOfWeek,Prompt>> CountPromptsByWeekDay(){
		//			var value = 
		//				from prompt in database.Table<Prompt> ()
		//				group prompt by prompt.TimeStamp.DayOfWeek;
		//			return value.ToList ();
		//		}

	}
}

