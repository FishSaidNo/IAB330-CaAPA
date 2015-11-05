using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Microsoft.WindowsAzure.Mobile.Service;
using Microsoft.WindowsAzure.Mobile.Service.Tables;
using caapaService.DataObjects;
using System.Collections;
using System.Data;

namespace caapaService.Models
{
    public class caapaContext : DbContext
    {
        
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to alter your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
        //
        // To enable Entity Framework migrations in the cloud, please ensure that the 
        // service name, set by the 'MS_MobileServiceName' AppSettings in the local 
        // Web.config, is the same as the service name when hosted in Azure.
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public caapaContext() : base(connectionStringName)
        {
             //this.Database.ExecuteSqlCommand("select * from user");

        }

        public System.Data.Entity.DbSet<caapaService.DataObjects.Beacon> Beacon { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.GuiSettings> GuiSettings { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.Location> Location { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.Map> Map { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.Prompt> Prompt { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.PromptStep> PromptStep { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.Reminder> Reminder { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.Settings> Settings { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.UserMaps> UserMaps { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.Users> Users { get; set; }
        public System.Data.Entity.DbSet<caapaService.DataObjects.UserSettings> UserSettings { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            string schema = ServiceSettingsDictionary.GetSchemaName();
            if (!string.IsNullOrEmpty(schema))
            {
                modelBuilder.HasDefaultSchema(schema);
            }

            modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

 
     
    }
}