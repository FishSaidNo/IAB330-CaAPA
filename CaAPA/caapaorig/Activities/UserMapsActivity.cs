using System;
using Android.OS;
using Android.App;
using Android.Views;
using Android.Widget;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using System.IO;
using System.Threading;
using caapaorig;
using caapaorig.Items;

namespace caapa.Activities
{
    [Activity (MainLauncher = true, 
               Icon="@drawable/ic_launcher", Label="@string/app_name",
               Theme="@style/AppTheme")]
    public class UserMapsActivity : Activity
    {

        //Mobile Service Client reference
        private MobileServiceClient UserMaps;

        //Mobile Service sync table used to access data
        private IMobileServiceSyncTable<UserMaps> usermapsTable;

        //Adapter to map the items list to the view
        private Adapters.UserMapsAdapter adapter;

        //EditText containing the "New ToDo" text
        private EditText textNewToDo;

        public const string applicationURL = @"https://caapa.azure-mobile.net/";
        public const string applicationKey = @"coHzRHuoqnHiolDACEHMunJRIeEJUH21";

        public const string localDbFilename = "localstore.db";

        // Create the Mobile Service Client instance, using the provided
        // Mobile Service URL and key
        public MobileServiceClient client = new MobileServiceClient(applicationURL, applicationKey);

        protected override async void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Activity_To_Do);

            CurrentPlatform.Init ();

           // await InitLocalStoreAsync();

            // Get the Mobile Service sync table instance to use
            var usermapsTable = client.GetSyncTable <UserMaps> ();

            //textNewToDo = FindViewById<EditText> (Resource.Id.textNewToDo); //change to fit

            // Create an adapter to bind the items with the view
            adapter = new Adapters.UserMapsAdapter(this, Resource.Layout.Row_List_To_Do);
            var listViewUserMaps = FindViewById<ListView> (Resource.Id.listViewToDo);
            listViewUserMaps.Adapter = adapter;

            // Load the items from the Mobile Service
            OnRefreshItemsSelected ();
        }

        private async Task InitLocalStoreAsync()
        {
            // new code to initialize the SQLite store
            string path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), localDbFilename);

            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }

            var store = new MobileServiceSQLiteStore(localDbFilename);
            store.DefineTable<UserMaps>();

            // Uses the default conflict handler, which fails on conflict
            // To use a different conflict handler, pass a parameter to InitializeAsync. For more details, see http://go.microsoft.com/fwlink/?LinkId=521416
            await client.SyncContext.InitializeAsync(store);

        }

        //Initializes the activity menu
        public override bool OnCreateOptionsMenu (IMenu menu)
        {
            MenuInflater.Inflate (Resource.Menu.activity_main, menu);
            return true;
        }

        //Select an option from the menu
        public override bool OnOptionsItemSelected (IMenuItem item)
        {
            if (item.ItemId == Resource.Id.menu_refresh) {
                item.SetEnabled(false);

                OnRefreshItemsSelected ();
                
                item.SetEnabled(true);
            }
            return true;
        }

        public async Task SyncAsync()
        {
			try {
                var cancel = new CancellationToken();
	            await client.SyncContext.PushAsync(cancel);
	            await usermapsTable.PullAsync("UserMaps", usermapsTable.CreateQuery()); // query ID is used for incremental sync
			} catch (Java.Net.MalformedURLException) {
				CreateAndShowDialog (new Exception ("There was an error creating the Mobile Service. Verify the URL"), "Error");
			} catch (Exception e) {
				CreateAndShowDialog (e, "Error");
			}
        }

        // Called when the refresh menu option is selected
       public async void OnRefreshItemsSelected ()
        {
            await SyncAsync(); // get changes from the mobile service
            await RefreshItemsFromTableAsync(); // refresh view using local database
        }

        //Refresh the list with the items in the local database
        public async Task RefreshItemsFromTableAsync ()
        {
            try {
                // Get the items that weren't marked as completed and add them in the adapter
                var list = await usermapsTable.Where (usermap => usermap.Complete == false).ToListAsync ();

                adapter.Clear ();

                foreach (UserMaps current in list)
                    adapter.Add (current);

            } catch (Exception e) {
                CreateAndShowDialog (e, "Error");
            }
        }

        public async Task CheckUserMaps(UserMaps usermap)
        {
            if (client == null) {
                return;
            }

            // Set the item as completed and update it in the table
            usermap.Complete = true;
            try {
                await usermapsTable.UpdateAsync(usermap); // update the new item in the local database
                await SyncAsync(); // send changes to the mobile service

                if (usermap.Complete)
                    adapter.Remove (usermap);

            } catch (Exception e) {
                CreateAndShowDialog (e, "Error");
            }
        }

        [Java.Interop.Export()]
        public async void AddUserMaps(View view) {
      
            if (client == null || string.IsNullOrWhiteSpace (textNewToDo.Text)) {
                return;
            }

            // Create a new item
            var usermap = new UserMaps
            {
                //Text = textNewToDo.Text

                //add collum = value
                //for each collumn
                //leave complete it is nessecary for the localdb

                Complete = false
            };

            try {
                await usermapsTable.InsertAsync(usermap); // insert the new item into the local database
                await SyncAsync(); // send changes to the mobile service

                if (!usermap.Complete) {
                    adapter.Add (usermap);
                }
            } catch (Exception e) {
                CreateAndShowDialog (e, "Error");
            }

            //textNewToDo.Text = "";
        }

        private void CreateAndShowDialog (Exception exception, String title)
        {
            CreateAndShowDialog (exception.Message, title);
        }

        private void CreateAndShowDialog (string message, string title)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder (this);

            //builder.SetMessage (message);
            //builder.SetTitle (title);

            builder.Create ().Show ();
        }
    }
}


