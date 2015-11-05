using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using GalaSoft.MvvmLight.Ioc;
using AltBeaconOrg.BoundBeacon;
using caapa;
using System.Threading.Tasks;

namespace CaAPA.Droid
{
	[Activity (Label = "CaAPA.Droid", Icon = "@drawable/awareIcon2", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleInstance, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, IBeaconConsumer
	{
		public const string applicationURL = @"https://caapa.azure-mobile.net/";
		public const string applicationKey = @"coHzRHuoqnHiolDACEHMunJRIeEJUH21";

		public static MobileServiceClient client = new MobileServiceClient(applicationURL, applicationKey);

        //Mobile Service sync table used to access data
        public IMobileServiceSyncTable<caapa.Beacon> beaconTable;
        public IMobileServiceSyncTable<Prompt> promptTable;
		public IMobileServiceSyncTable<CaAPA.Data.Activities> activityTable;



        // public  const string applicationURL = @"https://caapa.azure-mobile.net/";
        // public const string applicationKey = @"coHzRHuoqnHiolDACEHMunJRIeEJUH21";

        public const string localDbFilename = "caapa_db.sqlite";

        //Adapter to map the items list to the view

        public BeaconAdapter beaconadapter;
        public PromptAdapter promptadapter;
        public ActivityAdapter activityadapter;


        private Action<int, Result, Intent> _activityResultCallBack;

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            //TODO show IOC vs Dependency injection
            //			SimpleIoc.Default.Register<ISqlite> (new SqliteDroid ());
            SimpleIoc.Default.Register<Data.ISqlite>(() => new SqliteDroid());

			activityTable = client.GetSyncTable<CaAPA.Data.Activities> ();

            await InitLocalStoreAsync();

            LoadApplication(new App());

        }

        #region IBeaconConsumer Implementation
        public void OnBeaconServiceConnect()
		{
			var beaconService = Xamarin.Forms.DependencyService.Get<Data.IAltBeaconService>();
			beaconService.StartMonitoring();
			beaconService.StartRanging();

		}
		#endregion

		public void ConfigureActivityResultCallBack(Action<int, Result, Intent> callback)
		{
			if (callback == null)
				throw new ArgumentNullException("callback");
			_activityResultCallBack = callback;
		}

		protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
		{
			base.OnActivityResult(requestCode, resultCode, data);
			if (_activityResultCallBack != null)
			{
				_activityResultCallBack.Invoke(requestCode, resultCode, data);
				_activityResultCallBack = null;
			}
		}
        private bool writedb()
        {
            // new code to initialize the SQLite store

            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), localDbFilename);
            var docFolder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var dbFile = Path.Combine(docFolder, localDbFilename); // FILE NAME TO USE WHEN COPIED


            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }


            if (!System.IO.File.Exists(dbFile))
            {
                // var s = Resources.OpenRawResource(Resource.Raw.Data);  // DATA FILE RESOURCE ID
                // FileStream writeStream = new FileStream(dbFile, FileMode.OpenOrCreate, FileAccess.Write);
                // ReadWriteStream(s, writeStream);
                Stream myinput = Assets.Open("caapa_db.sqlite");
                Stream myOutput = new FileStream(path, FileMode.OpenOrCreate);
                ReadWriteStream(myinput, myOutput);
            }

            return true;

        }

        // readStream is the stream you need to read
        // writeStream is the stream you want to write to
        private void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            // write the required bytes
            while (bytesRead > 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }

        private async Task InitLocalStoreAsync()
        {
            // new code to initialize the SQLite store

            writedb();

            var store = new MobileServiceSQLiteStore(localDbFilename);

            store.DefineTable<caapa.SharedBeacon>();
            store.DefineTable<GuiSettings>();
            store.DefineTable<Location>();
            store.DefineTable<Map>();
            store.DefineTable<Prompt>();
            store.DefineTable<PromptStep>();
            store.DefineTable<Reminder>();
            store.DefineTable<Settings>();
            store.DefineTable<UserMaps>();
            store.DefineTable<UserSettings>();
            store.DefineTable<Users>();

            CurrentPlatform.Init();

            // Uses the default conflict handler, which fails on conflict
            // To use a different conflict handler, pass a parameter to InitializeAsync. For more details, see http://go.microsoft.com/fwlink/?LinkId=521416
            await client.SyncContext.InitializeAsync(store);
        }


        private async Task SyncAsync()
        {
            try
            {
                await client.SyncContext.PushAsync();
                await beaconTable.PullAsync("allBeacons", beaconTable.CreateQuery()); // query ID is used for incremental sync
                                                                                      //   await guisettingsTable.PullAsync("allGuiSettings", guisettingsTable.CreateQuery()); // query ID is used for incremental sync
                                                                                      //   await locationTable.PullAsync("allBeacons", locationTable.CreateQuery()); // query ID is used for incremental sync
            }
            catch (Java.Net.MalformedURLException)
            {
                CreateAndShowDialog(new Exception("There was an error creating the Mobile Service. Verify the URL"), "Error");
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }
        }

        private void CreateAndShowDialog(Exception exception, String title)
        {
            CreateAndShowDialog(exception.Message, title);
        }

        private void CreateAndShowDialog(string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this);

            builder.SetMessage(message);
            builder.SetTitle(title);
            builder.Create().Show();


        }


        /*****Beacon***/

        public async void OnRefreshBeaconsSelected()
        {
            await SyncAsync(); // get changes from the mobile service
            await RefreshBeaconsFromTableAsync(); // refresh view using local database
        }

        public async Task RefreshBeaconsFromTableAsync()
        {
            try
            {

                // Get the items that weren't marked as completed and add them in the adapter
                var list = await beaconTable.Where(beacon => beacon.Complete == false).ToListAsync();

                beaconadapter.Clear();

                foreach (caapa.Beacon current in list)
                    beaconadapter.Add(current);

            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }
        }
        public async Task CheckBeacon(caapa.Beacon beacon)
        {
            if (client == null)
            {
                return;
            }

            // Set the item as completed and update it in the table
            beacon.Complete = true;
            try
            {
                await beaconTable.UpdateAsync(beacon); // update the new item in the local database
                await SyncAsync(); // send changes to the mobile service

                if (beacon.Complete)
                    beaconadapter.Remove(beacon);

            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }
        }
        public async void AddBeacon(View view)
        {
            if (client == null)
            {
                return;
            }

            // Create a new item
            var beacon = new caapa.Beacon
            {

                //add collum = value
                //for each collumn
                //leave complete it is nessecary for the localdb

                //this may need to wait for the gui integration

                Complete = false
            };

            try
            {
                await beaconTable.InsertAsync(beacon); // insert the new item into the local database
                await SyncAsync(); // send changes to the mobile service

                if (!beacon.Complete)
                {
                    beaconadapter.Add(beacon);
                }
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }

        }

		/******Activities*******/

		public async void OnRefreshActivitiesSelected()
		{
			await SyncAsync(); // get changes from the mobile service
			await RefreshActivitiesFromTableAsync(); // refresh view using local database
		}

		public async Task RefreshActivitiesFromTableAsync()
		{
			try
			{

				// Get the items that weren't marked as completed and add them in the adapter
				var list = await activityTable.Where(activity => activity.Complete == false).ToListAsync();

				activityadapter.Clear();

				foreach (CaAPA.Data.Activities current in list)
					activityadapter.Add(current);

			}
			catch (Exception e)
			{
				CreateAndShowDialog(e, "Error");
			}
		}

		public async Task CheckActivity(CaAPA.Data.Activities activity)
		{
			if (client == null)
			{
				return;
			}

			// Set the item as completed and update it in the table
			activity.Complete = true;
			try
			{
				await activityTable.UpdateAsync(activity); // update the new item in the local database
				await SyncAsync(); // send changes to the mobile service

				if (activity.Complete)
					activityadapter.Remove(activity);

			}
			catch (Exception e)
			{
				CreateAndShowDialog(e, "Error");
			}
		}

		public async void AddActivity(CaAPA.Data.Activities activity)
		{
			if (client == null)
			{
				return;
			}

			try
			{
				await activityTable.InsertAsync(activity); // insert the new item into the local database
				await SyncAsync(); // send changes to the mobile service

				if (!activity.Complete)
				{
					activityadapter.Add(activity);
				}
			}
			catch (Exception e)
			{
				CreateAndShowDialog(e, "Error");
			}

		}

        /******Prompt********/

        public async void OnRefreshPromptsSelected()
        {
            await SyncAsync(); // get changes from the mobile service
            await RefreshPromptsFromTableAsync(); // refresh view using local database
        }

        public async Task RefreshPromptsFromTableAsync()
        {
            try
            {

                // Get the items that weren't marked as completed and add them in the adapter
                var list = await promptTable.Where(prompt => prompt.Complete == false).ToListAsync();

                promptadapter.Clear();

                foreach (Prompt current in list)
                    promptadapter.Add(current);

            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }
        }

        public async Task CheckPrompt(Prompt prompt)
        {
            if (client == null)
            {
                return;
            }

            // Set the item as completed and update it in the table
            prompt.Complete = true;
            try
            {
                await promptTable.UpdateAsync(prompt); // update the new item in the local database
                await SyncAsync(); // send changes to the mobile service

                if (prompt.Complete)
                    promptadapter.Remove(prompt);

            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }
        }

        public async void AddPrompt(Prompt prompt)
        {
            if (client == null)
            {
                return;
            }

            try
            {
                await promptTable.InsertAsync(prompt); // insert the new item into the local database
                await SyncAsync(); // send changes to the mobile service

                if (!prompt.Complete)
                {
                    promptadapter.Add(prompt);
                }
            }
            catch (Exception e)
            {
                CreateAndShowDialog(e, "Error");
            }

        }
	}

}

