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
			if (database.TableMappings.All(t => t.MappedType.Name != typeof(Activity).Name)) {
				database.CreateTable<Activity> ();
				database.Commit ();
			}
		}

		public async Task<List<Activity>> GetAll(){
			//			var items = database.Table<Note> ().ToList<Note>();
			//
			//			return items;

			// OR
			var x = await MobileService.GetTable<Activity> ().ToListAsync ();
			return x;

		}

		public async Task<int> InsertOrUpdateActivity(Activity activity){
			//			return database.Table<Note> ().Where (x => x.NoteId == note.NoteId).Any () 
			//				? database.Update (note) : database.Insert (note);
			var lookup = await MobileService.GetTable<Activity> ().LookupAsync (activity.id);
			if (lookup != null) {
				await MobileService.GetTable<Activity> ().InsertAsync (activity);
			} else {
				await MobileService.GetTable<Activity> ().UpdateAsync (activity);
			}
			return 1;

		}

		public Activity GetActivity(int key){
			return database.Table<Activity> ().First (t => t.id == key); 
		}

		public List<Activity> SearchActivity(string searchTerm){
			return database.Table<Activity> ().Where (x => x.ActivityName.Contains (searchTerm)).ToList ();
			//return database.Query<Note> ("Select * from Note where titleText like *?*", searchTerm).ToList();

		}

		public List<Activity> SearchLocation(string searchTerm){
			return database.Table<Activity> ().Where (x => x.ActivityLocation.Contains (searchTerm)).ToList ();
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

