using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Mobile.Service;
using Newtonsoft.Json;

namespace caapaService.DataObjects
{
    public class UserMaps: EntityData
    {
        [JsonProperty(PropertyName = "MapId")]
        public int MapId { get; set; }
        [JsonProperty(PropertyName = "UserId")]
        public int UserId { get; set; }

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
