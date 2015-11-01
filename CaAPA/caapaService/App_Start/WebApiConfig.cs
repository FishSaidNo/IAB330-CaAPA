using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.WindowsAzure.Mobile.Service;
using caapaService.Models;
using caapaService.DataObjects;

namespace caapaService
{
    public static class WebApiConfig
    {
        public static void Register()
        {
            // Use this class to set configuration options for your mobile service
            ConfigOptions options = new ConfigOptions();

            // Use this class to set WebAPI configuration options
            HttpConfiguration config = ServiceConfig.Initialize(new ConfigBuilder(options));

            // To display errors in the browser during development, uncomment the following
            // line. Comment it out again when you deploy your service for production use.
             config.IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always;

            // Set default and null value handling to "Include" for Json Serializer
            config.Formatters.JsonFormatter.SerializerSettings.DefaultValueHandling = Newtonsoft.Json.DefaultValueHandling.Include;
            config.Formatters.JsonFormatter.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Include;

            Database.SetInitializer(new caapaInitializer());
        }
    }


    public class caapaInitializer : ClearDatabaseSchemaIfModelChanges<caapaContext>
    {
        protected override void Seed(caapaContext context)
        {
            List<Beacon> BeaconsList = new List<Beacon>
            {
           
            };

            List<GuiSettings> GuiSettingsList = new List<GuiSettings>
            {
                
            };

            List<Location> LocationList = new List<Location>
            {

            };

            List<Map> MapList = new List<Map>
            {

            };

            List<Map> PromptList = new List<Map>
            {

            };

            List<PromptStep> PromptStepList = new List<PromptStep>
            {

            };

            List<Reminder> ReminderList = new List<Reminder>
            {

            };

            List<Settings> SettingsList = new List<Settings>
            {

            };

            List<UserMaps>UserMapsList = new List<UserMaps>
            {

            };
            List<Users> UsersList = new List<Users>
            {

            };
            List<UserSettings> UserSettingsList = new List<UserSettings>
            {

            };

            base.Seed(context);
        }
    }
}

