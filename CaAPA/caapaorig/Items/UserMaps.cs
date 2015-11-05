﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace caapaorig.Items
{
    public class UserMaps
    {

        [JsonProperty(PropertyName = "UserMapsId")]
        public int UserMapsId { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }

        public class UserMapsWrapper : Java.Lang.Object
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="CaaPa.UserMaps"/> class.
            /// </summary>
            /// <param name="UserMapsId">UserMapsId .</param>
            /// <param name="UserId">UserId .</param>
            /// <param name="MapId">MapId .</param>
            public UserMapsWrapper(UserMaps usermaps)
            {
                UserMaps = usermaps;
            }
            public UserMaps UserMaps { get; private set; }
        }
    }
}
