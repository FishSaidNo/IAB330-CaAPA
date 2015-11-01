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

namespace caapa
{
    public class SynchActivity
    {

        public  const string applicationURL = @"https://caapa.azure-mobile.net/";
        public const string applicationKey = @"coHzRHuoqnHiolDACEHMunJRIeEJUH21";

        public const string localDbFilename = "localstore.db";

        // Create the Mobile Service Client instance, using the provided
        // Mobile Service URL and key
        MobileServiceClient client = new MobileServiceClient(applicationURL, applicationKey);


        public MobileServiceClient getClient() {
            return client;
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

            BeaconActivity beaconact = new BeaconActivity();
            GuiSettingsActivity guisettingsact = new GuiSettingsActivity();
           
            store.DefineTable<Beacon>();
            store.DefineTable<GuiSettings>();
            store.DefineTable<Location>();
            store.DefineTable<Map>();
            store.DefineTable<Prompt>();
            store.DefineTable<PromptStep>();
            store.DefineTable<Reminder>();
            store.DefineTable<Settings>();
            store.DefineTable<UserSettings>();
            store.DefineTable<Users>();
            store.DefineTable<UserMaps>();


            // Uses the default conflict handler, which fails on conflict
            // To use a different conflict handler, pass a parameter to InitializeAsync. For more details, see http://go.microsoft.com/fwlink/?LinkId=521416
            await client.SyncContext.InitializeAsync(store);
        }
    }
}