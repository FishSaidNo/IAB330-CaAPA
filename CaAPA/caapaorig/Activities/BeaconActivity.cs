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
    public class BeaconActivity : Activity
    {

        //Mobile Service Client reference
        private MobileServiceClient beacon;

        //Mobile Service sync table used to access data
        private IMobileServiceSyncTable<Beacon> beaconTable;

        //Adapter to map the items list to the view
        private Adapters.BeaconAdapter adapter;

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
            var toDoTable = client.GetSyncTable <Beacon> ();

            textNewToDo = FindViewById<EditText> (Resource.Id.textNewToDo);

            // Create an adapter to bind the items with the view
            adapter = new Adapters.BeaconAdapter(this, Resource.Layout.Row_List_To_Do);
            var listViewBeacon = FindViewById<ListView> (Resource.Id.listViewToDo);
            listViewBeacon.Adapter = adapter;

            // Load the items from the Mobile Service
            OnRefreshItemsSelected ();
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
	            await beaconTable.PullAsync("allTodoItems", beaconTable.CreateQuery()); // query ID is used for incremental sync
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
                var list = await beaconTable.Where (beacon => beacon.Complete == false).ToListAsync ();

                adapter.Clear ();

                //foreach (Beacon current in list)
                //    adapter.Add (current);

            } catch (Exception e) {
                CreateAndShowDialog (e, "Error");
            }
        }

        public async Task CheckBeacon (Beacon beacon)
        {
            if (client == null) {
                return;
            }

            // Set the item as completed and update it in the table
            beacon.Complete = true;
            try {
                await beaconTable.UpdateAsync(beacon); // update the new item in the local database
                await SyncAsync(); // send changes to the mobile service

                if (beacon.Complete)
                    adapter.Remove (beacon);

            } catch (Exception e) {
                CreateAndShowDialog (e, "Error");
            }
        }

        [Java.Interop.Export()]
        public async void AddBeacon (View view)
        {
            if (client == null || string.IsNullOrWhiteSpace (textNewToDo.Text)) {
                return;
            }

            // Create a new item
            var beacon = new Beacon {
                //Text = textNewToDo.Text

                //add collum = value
                //for each collumn
                //leave complete it is nessecary for the localdb

                Complete = false
            };

            try {
                await beaconTable.InsertAsync(beacon); // insert the new item into the local database
                await SyncAsync(); // send changes to the mobile service

                if (!beacon.Complete) {
                    adapter.Add (beacon);
                }
            } catch (Exception e) {
                CreateAndShowDialog (e, "Error");
            }

            textNewToDo.Text = "";
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


