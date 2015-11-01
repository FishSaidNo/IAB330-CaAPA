using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class UserMaps
    {
       

        [JsonProperty(PropertyName = "MapId")]
        public int MapId { get; set; }
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public UserMaps()
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CaaPa.UserMaps"/> class.
        /// </summary>
        /// <param name="MapId">=MapId .</param>
        /// <param name="UserId">=UserId .</param>

        public UserMaps(int MapId, int UserId)
        {
            this.MapId = MapId;
            this.UserId = UserId;
        }
    }
}
