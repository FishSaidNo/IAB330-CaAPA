using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class Map
    {

       

        [JsonProperty(PropertyName = "mapId")]
        public int mapId { get; set; }
        [JsonProperty(PropertyName = "LocationAddress")]
        public String LocationAddress{ get; set; }
        [JsonProperty(PropertyName = "Longitude")]
        public String Longitude { get; set; }
        [JsonProperty(PropertyName = "Latitude")]
        public String Latitude{ get; set; }
        [JsonProperty(PropertyName = "URL")]
        public String URL { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public Map()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.Map"/> class.
        /// </summary>
        /// <param name="MapId" >MapId .</param>
        /// <param name="LocationAddress ">LocationAddress .</param>
        /// <param name="Longitude ">Longitude .</param>
        /// <param name="Latitude">Latitude .</param>
        /// <param name="URL" >URL .</param>
        public Map(int MapId, String LocationAddress = "", String Longitude = "", String Latitude = "", String URL = "")
        {
            this.mapId = mapId;
            this.LocationAddress = LocationAddress;
            this.LocationAddress = Longitude;
            this.Latitude = Latitude;
            this.URL = URL;
        }


        public class MapWrapper : Java.Lang.Object
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.Map"/> class.
            /// </summary>
            /// <param name="MapId" >MapId .</param>
            /// <param name="LocationAddress ">LocationAddress .</param>
            /// <param name="Longitude ">Longitude .</param>
            /// <param name="Latitude">Latitude .</param>
            /// <param name="URL" >URL .</param>
            public MapWrapper(Map map)
            {
                Map = map;
            }
            public Map Map { get; private set; }
        }

    }
}
