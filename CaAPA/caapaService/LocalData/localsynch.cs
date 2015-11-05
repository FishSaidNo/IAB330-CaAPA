using System;
using System.Collections.Generic;
using System.Linq;
using caapaService.Controllers;
using caapaService.DataObjects;
using System.Threading.Tasks;
using SQLitePCL;
using Microsoft.WindowsAzure.MobileServices.SQLiteStore;
using ZumoContrib.Sync;
using Heyns.ZumoClient;

namespace caapaService.data
{
    public class localsynch
    {
        public class synchlocal
        {

            public async Task InitializeStoreAsync()
            {
                try
                {

                    var sqliteStore = localdb();

                    sqliteStore.DefineTable<Beacon>();
                    sqliteStore.DefineTable<GuiSettings>();
                    sqliteStore.DefineTable<Location>();
                    sqliteStore.DefineTable<Map>();
                    sqliteStore.DefineTable<Prompt>();
                    sqliteStore.DefineTable<PromptStep>();
                    sqliteStore.DefineTable<Reminder>();
                    sqliteStore.DefineTable<Settings>();
                    sqliteStore.DefineTable<UserMaps>();
                    sqliteStore.DefineTable<Users>();
                    sqliteStore.DefineTable<UserSettings>();



                    await sqliteStore.InitializeAsync();

                }
                catch (Exception ex)
                {

                }

            }


            public MobileServiceSQLiteStore localdb()
            {

                var sqliteStore = new MobileServiceSQLiteStore("caapalocal.db");
                return sqliteStore;
            }

        }

    }

}
