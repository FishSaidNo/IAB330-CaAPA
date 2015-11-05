using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class Location
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

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public class LocationWrapper : Java.Lang.Object
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.Location"/> class.
            /// </summary>
            /// <param name="LocationName ">ocationName .</param>
            /// <param name="LocationDesc ">LocationDesc .</param>
            /// <param name="BeaconId">BeaconId.</param>
            /// <param name="UserId" >UserId .</param>
            public LocationWrapper(Location location)
            {
                Location = location; ;
            }
            public Location Location { get; private set; }
        }
    }
}



