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

        public DbSet<caapaService.caapaInitializer> Beacons { get; set; }
        public DbSet<caapaService.caapaInitializer> Locations { get; set; }
        public DbSet<caapaService.caapaInitializer> Maps { get; set; }
        public DbSet<caapaService.caapaInitializer> Prompts { get; set; }
        public DbSet<caapaService.caapaInitializer> PromptSteps { get; set; }
        public DbSet<caapaService.caapaInitializer> Reminders { get; set; }
        public DbSet<caapaService.caapaInitializer> Settings { get; set; }
        public DbSet<caapaService.caapaInitializer> UserMaps { get; set; }
        public DbSet<caapaService.caapaInitializer> Users { get; set; }
        public DbSet<caapaService.caapaInitializer> UserSettings { get; set; }

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

        public System.Data.Entity.DbSet<caapaService.DataObjects.GuiSettings> GuiSettings { get; set; }
    }
}