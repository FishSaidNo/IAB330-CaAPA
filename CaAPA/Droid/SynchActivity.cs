using Android.App;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using System;
using System.IO;

namespace caapa
{
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

