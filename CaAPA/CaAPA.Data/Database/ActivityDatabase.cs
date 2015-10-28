using System;
using SQLite.Net;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Ioc;

namespace CaAPA.Data
{
    class ActivityDatabase
    {
        SQLiteConnection database;

        public ActivityDatabase()
        {
            database = DependencyService.Get<ISqlite>().GetConnection();
            if(database.TableMappings.All(t => t.MappedType.Name != typeof(Activity).Name))
            {
                database.CreateTable<Activity>();
                database.Commit();
            }
        }

        public List<Activity> GetAllActivities()
        {
            var list = database.Table<Activity>().ToList<Activity>();
            return list;
        }

        public int InsertActivity(Activity activity)
        {
            //
            return database.Table<Activity>().Where(x => x.ActivityName == activity.ActivityName).Count() == 0
                ? database.Insert(activity) : database.Insert(activity);
        }

       /* public void InstertActivitiy(Activity activity)
        {
            
        }*/

        public Activity GetActivity(string key)
        {
            return database.Table<Activity>().First(t => t.ActivityName == key);
        }
    }
}
