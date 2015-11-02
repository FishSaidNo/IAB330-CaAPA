using System;
using SQLite.Net.Attributes;
using CaAPA.Data;

namespace CaAPA.Data
{
	public class SharedBeacon
	{
		[PrimaryKey, AutoIncrement]
		public string Id { get; set; }
		[NotNull, MaxLength(128)]
		public string UUID { get; set; }
		[NotNull, MaxLength(128)]
		public string Name {get; set; }
		public string Description {get; set; }
		public string Distance { get; set; }

		public SharedBeacon() {
			
		}

		public SharedBeacon(string id, string uuid, string name, string description, string distance) {
			Id = id;
			UUID = uuid;
			Name = name;
			Description = description;
			Distance = distance;
		}
	}
}

