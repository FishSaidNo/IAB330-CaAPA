using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class Location: EntityData
    {
        [JsonProperty(PropertyName = "LocationId")]
        public int LocationId { get; set; }
        [JsonProperty(PropertyName = "LocationName")]
        public String LocationName{ get; set; }
        [JsonProperty(PropertyName = "LocationDesc")]
        public String LocationDesc { get; set; }
        [JsonProperty(PropertyName = "BeaconId")]
        public int BeaconId { get; set; }
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }

        public Location()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.Location"/> class.
        /// </summary>
        /// <param name="LocationName ">ocationName .</param>
        /// <param name="LocationDesc ">LocationDesc .</param>
        /// <param name="BeaconId">BeaconId.</param>
        /// <param name="UserId" >UserId .</param>
        public Location(int locationId, int BeaconId, int UserId, String LocationName = "", String LocationDesc = "")
        {
            this.LocationId = LocationId;
            this.LocationName = LocationName;
            this.LocationDesc = LocationDesc;
            this.BeaconId = BeaconId;
            this.UserId = UserId;
        }
    }
}



