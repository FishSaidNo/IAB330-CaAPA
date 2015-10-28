using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class Beacon: EntityData
    {
        [JsonProperty(PropertyName = "BeaconId")]
        public int BeaconId { get; set; }
        [JsonProperty(PropertyName = "BeaconBluetoothKey")]
        public String BeaconBluetoothKey { get; set; }
        [JsonProperty(PropertyName = "BeaconName")]
        public String BeaconName { get; set; }
        [JsonProperty(PropertyName = "BeaconDesc")]
        public String BeaconDesc { get; set; }
        [JsonProperty(PropertyName = "LocationId")]
        public int LocationId { get; set; }


        public Beacon()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.Beacon"/> class.
        /// </summary>
        /// <param name="BeaconId ">BeaconId .</param>
        /// <param name="BeaconBluetoothKey ">BeaconBluetoothKey .</param>
        /// <param name="BeaconName ">BeaconName .</param>
        /// <param name="BeaconDesc">BeaconDesc.</param>
        /// <param name="LoationId">LocationID.</param>
        public Beacon(int BeaconId, int LocationId, String BeaconBluetoothKey = "", string BeaconName = "", string BeaconDesc = "") 
        {
            this.BeaconId = BeaconId;
            this.BeaconBluetoothKey = BeaconBluetoothKey;
            this.BeaconName = BeaconName;
            this.BeaconDesc = BeaconDesc;
            this.LocationId = LocationId;   
            }
    }

}
