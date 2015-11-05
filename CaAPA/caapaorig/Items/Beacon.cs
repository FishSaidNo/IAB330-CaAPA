using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class Beacon
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

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }


    public class BeaconWrapper : Java.Lang.Object
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.Beacon"/> class.
        /// </summary>
        /// <param name="BeaconId ">BeaconId .</param>
        /// <param name="BeaconBluetoothKey ">BeaconBluetoothKey .</param>
        /// <param name="BeaconName ">BeaconName .</param>
        /// <param name="BeaconDesc">BeaconDesc.</param>
        /// <param name="LoationId">LocationID.</param>
        public BeaconWrapper(Beacon beacon)
        {
            Beacon = beacon;
        }
     public Beacon Beacon { get; private set; }
    }
}
