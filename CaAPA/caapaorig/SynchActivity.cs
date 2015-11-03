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
using caapa.Activities;
using caapa.Adapters;

namespace caapa
{
    [Activity(MainLauncher = true,
           Icon = "@drawable/ic_launcher", Label = "@string/app_name",
           Theme = "@style/AppTheme")]

    public class SynchActivity : Activity
    {

        //Mobile Service Client reference
        private MobileServiceClient client = new MobileServiceClient("https://caapa.azure-mobile.net/", "coHzRHuoqnHiolDACEHMunJRIeEJUH21");

        //Mobile Service sync table used to access data
        private IMobileServiceSyncTable<Beacon> beaconTable;
        private IMobileServiceSyncTable<GuiSettings> guisettingsTable ;
        private IMobileServiceSyncTable<Location> locationTable;


        // public  const string applicationURL = @"https://caapa.azure-mobile.net/";
        // public const string applicationKey = @"coHzRHuoqnHiolDACEHMunJRIeEJUH21";

        public const string localDbFilename = "localstore.db";

        protected override async void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Activity_To_Do);

            CurrentPlatform.Init();

            //var adapter = new BeaconAdapter(this, Resource.Layout.Row_List_To_Do);

            // Create the Mobile Service Client instance, using the provided
            // Mobile Service URL and key
            await InitLocalStoreAsync();

           
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
           
            store.DefineTable<Beacon>();
            store.DefineTable<GuiSettings>();
            store.DefineTable<Location>();
            //store.DefineTable<Map>();
            //store.DefineTable<Prompt>();
            //store.DefineTable<PromptStep>();
            //store.DefineTable<Reminder>();
            //store.DefineTable<Settings>();
            //store.DefineTable<UserMaps>();
            //store.DefineTable<UserSettings>();
            //store.DefineTable<Users>();


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
                await guisettingsTable.PullAsync("allGuiSettings", guisettingsTable.CreateQuery()); // query ID is used for incremental sync
                await locationTable.PullAsync("allBeacons", locationTable.CreateQuery()); // query ID is used for incremental sync
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


        // Called when the refresh menu option is selected
        private async void OnRefreshItemsSelected()
        {
            await SyncAsync(); // get changes from the mobile service
            //await RefreshItemsFromTableAsync(); // refresh view using local database
        }

        //Refresh the list with the items in the local database
        private async Task RefreshItemsFromTableAsync()
        {
      
        }

        public async Task CheckItem(Beacon beacon)
        {
          
        }

        [Java.Interop.Export()]
        public async void AddItem(View view)
        {
           
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
    }
}

/*

    Beacon beacon= new Beacon {};
            await client.GetTable<Beacon>().InsertAsync(beacon);
            GuiSettings guisetting = new GuiSettings { };
            await client.GetTable<GuiSettings>().InsertAsync(guisetting);
            Location location = new Location { };
            await client.GetTable<Location>().InsertAsync(location);
*/
